using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Bekos.Tcp;


public class LatencyUpdatedEventArgs : EventArgs
{
    public int Latency { get; }

    public LatencyUpdatedEventArgs(int latency) => Latency = latency;
}
