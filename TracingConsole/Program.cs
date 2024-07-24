using System;
using System.Diagnostics;
using TracingLib;

namespace TracingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main");

            //See App.config for trace configuration in XML.

            //Add trace listener by code.
            //Debug.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Debug.AutoFlush = true;

            //To add listeners for default tracing methods, config "listeners"
            //element under "trace" element in App.config.
            Trace.WriteLine("Trace.WriteLine");
            Trace.TraceInformation("Trace.TraceInformation");
            Trace.TraceError("Trace.Error");

            //Trace with TraceSource in code. "MyTraceSource" is configed in
            //App.config.
            TraceSource ts = new TraceSource("MyTraceSource");
            ts.TraceEvent(TraceEventType.Information, 123, "MyTraceSource information event");
            ts.TraceEvent(TraceEventType.Error, 123, "MyTraceSource error event");
            ts.Flush();
            ts.Close();

            //MyTrace uses the same "MyTraceSource" as above code. Attention:
            //there has to be <trace autoflush="true" ...> in App.config to
            //see the output from MyTrace.Info/Error.
            MyTrace.Info("MyTrace info");
            MyTrace.Error("MyTrace error");
        }
    }
}
