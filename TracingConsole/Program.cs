using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TracingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add listener by code
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.AutoFlush = true;

            Trace.WriteLine("I'm tracing!");
            Console.WriteLine("I'm main!");
            Debug.WriteLine("I'm debugging!");

            TraceSource ts = new TraceSource("MyTraceSource");
            ts.TraceEvent(TraceEventType.Information, 123, "My trace event.");
            ts.TraceEvent(TraceEventType.Error, 123, "My trace error event.");
            ts.Flush();
            ts.Close();
        }
    }
}
