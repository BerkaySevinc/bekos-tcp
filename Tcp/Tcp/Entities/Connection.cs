using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


// IsLost propu olmalı şuan IsDisconnected olan
// Dispose private olmalı .Disconnect() çağırıldığında IsLost true olmalı ve sonra Dispose Çağırılmalı
// CheckIsConnected public mi olmalı

namespace BekoS.Tcp;

public class Connection
{
    public IPAddress Address { get; }
    public int Port { get; }


    private bool _isDisconnected;
    public bool IsDisconnected
    {
        get => _isDisconnected ? true : (_isDisconnected = CheckIsDisconnected());
        private set => _isDisconnected = value;
    }

    public bool IsDisconnectedIntentionally { get; private set; }

    public NetworkStream Stream { get; }



    private System.Threading.Timer? pingTimer;

    private readonly object latencyUpdatedEventLock = new();

    private EventHandler<LatencyUpdatedEventArgs>? _latencyUpdated;
    public event EventHandler<LatencyUpdatedEventArgs>? LatencyUpdated
    {
        add
        {
            lock (latencyUpdatedEventLock)
            {
                if (_latencyUpdated is null)
                    pingTimer = new System.Threading.Timer(PingTimerCallback, null, 0, Timeout.Infinite);

                _latencyUpdated += value;
            }
        }
        remove
        {
            lock (latencyUpdatedEventLock)
            {
                _latencyUpdated -= value;
                if (_latencyUpdated is null)
                {
                    pingTimer?.Change(Timeout.Infinite, Timeout.Infinite);
                    pingTimer?.Dispose();
                    pingTimer = null;
                }
            }
        }
    }

    protected virtual void OnLatencyUpdated(LatencyUpdatedEventArgs e) =>
        _latencyUpdated?.Invoke(this, e);


    private Socket socket;
    public Connection(Socket socket)
    {
        if (socket.RemoteEndPoint is not IPEndPoint endPoint) throw new SocketException();

        Address = endPoint.Address;
        Port = endPoint.Port;

        this.socket = socket;
        Stream = new NetworkStream(socket, true);
    }

    private bool CheckIsDisconnected()
    {
        try
        {
            return socket.Poll(1, SelectMode.SelectRead) && socket.Available is 0;
        }
        catch
        {
            return true;
        }
    }

    private void PingTimerCallback(object? state)
    {
        var pingSender = new Ping();
        pingSender.PingCompleted += PingCompletedCallback;

        // Wait 10 seconds for a reply.
        int timeout = 10000;

        pingSender.SendAsync(Address, timeout, null);
    }

    private void PingCompletedCallback(object sender, PingCompletedEventArgs e)
    {
        if (e.Reply is null) return;

        var args = new LatencyUpdatedEventArgs((int)(e.Reply.RoundtripTime / 2));
        OnLatencyUpdated(args);

        pingTimer?.Change(1000, Timeout.Infinite);
    }

    public void Disconnect()
    {
        if (IsDisconnected) return;

        try
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
            Stream.Close();
        }
        catch { }

        socket.Dispose();
        Stream.Dispose();

        IsDisconnected = true;
        IsDisconnectedIntentionally = true;
    }
}
