using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;



// TODO: If the client count exceeds the maximum, StartAcceptingClients stops but never restarts when the count drops — fix this.
// TODO: SendMessageToAll serializes the message for each client individually; optimize to serialize once. Also add an overload that accepts a list of target connections.

// TODO: Make the Clients property public.


namespace Bekos.Tcp;

public class TcpServer<TTcpMessage> : TcpHost<TTcpMessage> where TTcpMessage : class, ITcpMessage<TTcpMessage>, new()
{
    public IPAddress Address { get; }

    public int MaxClientCount { get; }
    public List<Connection> Clients { get; } = new();
    private readonly Lock _clientsLock = new();


    public TcpServer(IPAddress localAddress, int port, int maxClientCount) : base(port)
    {
        Address = localAddress;

        MaxClientCount = maxClientCount;

        tcpListener = new TcpListener(Address, Port);
    }
    public TcpServer(IPAddress localAddress, int port) : this(localAddress, port, 32) { }
    public TcpServer(int port, int maxClientCount) : this(IPAddress.Any, port, maxClientCount) { }
    public TcpServer(int port) : this(IPAddress.Any, port) { }



    public event EventHandler<ClientConnectedEventArgs>? ClientConnected;
    public event EventHandler<ClientDisconnectedEventArgs>? ClientDisconnected;


    protected virtual void OnClientConnected(ClientConnectedEventArgs e) =>
        ClientConnected?.Invoke(this, e);

    protected virtual void OnClientDisconnected(ClientDisconnectedEventArgs e) =>
        ClientDisconnected?.Invoke(this, e);




    #region Start

    public void Start()
    {
        // Start Socket Listener & Accepting Client Connections On New Thread
        Task.Run(StartAcceptingClients);
    }

    #endregion

    #region StartAcceptingClients

    private TcpListener tcpListener;
    private void StartAcceptingClients()
    {
        // Start Socket Listener
        tcpListener.Start();

        try
        {
            // Keep Accepting Client Connections If Client Count Smaller Than MaxClientCount
            while (true)
            {
                lock (_clientsLock) { if (Clients.Count > MaxClientCount) break; }
                AcceptClient();
            }
        }
        // If Server Stopped, Catch Socket Exception
        catch (SocketException)
        {

        }
    }
    private void AcceptClient()
    {
        // Accept Connection
        var socket = tcpListener.AcceptSocket();

        // Create Host Instance
        var clientConnection = new Connection(socket);

        // Add To Client List
        lock (_clientsLock) { Clients.Add(clientConnection); }

        // Invoke ClientConnected Event
        var args = new ClientConnectedEventArgs(clientConnection);
        OnClientConnected(args);

        // Start Listening Client Messages
        StartListeningHost(clientConnection, DisconnectionCallback);
    }

    #endregion

    #region Stop

    public void Stop()
    {
        // Stop Socket Listener
        tcpListener.Stop();

        // Disconnect Clients
        lock (_clientsLock)
        {
            foreach (var client in Clients)
                client.Disconnect();
        }
    }

    #endregion

    #region DisconnectionCallback

    private void DisconnectionCallback(Connection connection)
    {
        // Remove From Client List
        lock (_clientsLock) { Clients.Remove(connection); }

        // Invoke Disconnected Event
        var args = new ClientDisconnectedEventArgs(connection, connection.IsDisconnectedIntentionally);
        OnClientDisconnected(args);
    }

    #endregion

    #region SendMessage / SendMessageToAll

    public void SendMessage(Connection client, TTcpMessage message) =>
        SendMessageToHost(client, message);

    public void SendMessageToAll(TTcpMessage message)
    {
        lock (_clientsLock)
        {
            foreach (var client in Clients)
                SendMessageToHost(client, message);
        }
    }

    #endregion

}



