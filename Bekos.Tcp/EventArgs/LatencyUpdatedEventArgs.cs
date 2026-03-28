using System;



namespace Bekos.Tcp;


public class LatencyUpdatedEventArgs : EventArgs
{
    public int Latency { get; }

    public LatencyUpdatedEventArgs(int latency) => Latency = latency;
}
