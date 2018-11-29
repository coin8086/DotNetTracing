using System.Diagnostics;

namespace TracingLib
{
    public static class MyTrace
    {
        private const string sourceName = "MyTraceSource";

        private static TraceSource source = new TraceSource(sourceName);

        public static void TraceInfo(string msg)
        {
            source.TraceEvent(TraceEventType.Information, 0, msg);
        }

        public static void TraceError(string msg)
        {
            source.TraceEvent(TraceEventType.Error, 1, msg);
        }

        public static void Flush()
        {
            source.Flush();
        }
    }
}
