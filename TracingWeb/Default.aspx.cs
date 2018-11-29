using System;
using TracingLib;

namespace TracingWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.Write("info", "I'm tracing on web!");
            System.Diagnostics.Trace.WriteLine("I'm tracing with System.Diagnostics.Trace!");

            //Trace with System.Diagnostics.TraceSource
            //var ts = new System.Diagnostics.TraceSource("MyTraceSource");
            //ts.TraceEvent(System.Diagnostics.TraceEventType.Information, 123, "My trace event.");
            //ts.TraceEvent(System.Diagnostics.TraceEventType.Error, 123, "My trace error event.");
            //ts.Flush();
            //ts.Close();

            MyTrace.TraceInfo("MyTrace works!");
            MyTrace.TraceError("MyTrace(error) works!");
        }
    }
}