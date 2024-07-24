using System.Diagnostics;

namespace TracingLib
{
    public static class MyTrace
    {
        public const string Source = "MyTraceSource";

        private static TraceSource ts = new TraceSource(Source);

        public static void Info(string msg)
        {
            ts.TraceEvent(TraceEventType.Information, 0, $"[Info] {msg}");
        }

        public static void Error(string msg)
        {
            ts.TraceEvent(TraceEventType.Error, 1, $"[Error] {msg}");
        }

        public static void Flush()
        {
            ts.Flush();
        }
    }
}
