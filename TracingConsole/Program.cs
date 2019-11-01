using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using TracingLib;

namespace TracingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add listener by code. See App.config for configuration in XML.
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.AutoFlush = true;

            //To add listeners for default tracing methods, config "listeners"
            //element under "trace" element in App.config.
            Trace.WriteLine("Call Trace.WriteLine");
            Console.WriteLine("I'm main!");
            Trace.TraceInformation("Call Trace.TraceInformation");
            Trace.TraceError("Call Trace.TraceError");

            //Trace with TraceSource in code. "MyTraceSource" is configed in
            //App.config.
            TraceSource ts = new TraceSource("MyTraceSource");
            ts.TraceEvent(TraceEventType.Information, 123, "My trace event.");
            ts.TraceEvent(TraceEventType.Error, 123, "My trace error event.");
            ts.Flush();
            ts.Close();

            //MyTrace uses the same "MyTraceSource" as above code. Attention:
            //there has to be <trace autoflush="true" ...> in App.config to
            //see the output from MyTrace.TraceInfo/Error, though it uses the
            //same "MyTraceSource" like the above code.
            MyTrace.TraceInfo("MyTrace works!");
            MyTrace.TraceError("MyTrace(error) works!");
        }
    }
}
