Here's another example of `Web.config` file. It enables trace output onto web page, while to a local file `d:\web.log` at the same time. Note that it may be necessary to write to a local file no matter to web page or not, because dependent assemblies may only write to files on tracing.

```xml
<?xml version="1.0" encoding="UTF-8"?>
<configuration>
  <system.web>

    <!-- Tracing: Enable/Disable trace output on web page in IIS. -->
    <!-- When enabled, the logs can be found at URL path /Trace.axd. -->
    <trace enabled="true" requestLimit="100" localOnly="false" />

  </system.web>

  <!-- Tracing: Config trace listeners, sources and switches -->
  <system.diagnostics>
    <sharedListeners>
      <add name="WebOutput" type="System.Web.WebPageTraceListener, System.Web, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"/>
      <!-- The output file path must be writable by the IIS process. -->
      <add name="FileOutput" type="System.Diagnostics.TextWriterTraceListener" traceOutputOptions="DateTime,ProcessId,ThreadId" initializeData="d:\trace.log" />
    </sharedListeners>

    <!-- Config default tracing listeners for code like `Trace.TraceInformation(...)` -->
    <trace autoflush="true" indentsize="4">
      <listeners>
        <remove name="Default" />
        <add name="WebOutput" />
        <add name="FileOutput" />
      </listeners>
    </trace>

    <!-- Config tracing listeners for TraceSource objects, for code like `ts.TraceEvent(...)`. -->
    <sources>
      <!-- source name="HpcStoreApi" switchName="MySourceSwitch" switchType="System.Diagnostics.SourceSwitch" -->
      <!-- Can be turn off by switchValue="Off". Note that the switch value is case-sensitive. -->
      <source name="MyTraceSource" switchValue="All">
        <listeners>
          <add name="WebOutput" />
          <add name="FileOutput" />
          <remove name ="Default" />
        </listeners>
      </source>
    </sources>

    <!-- switches>
      <add name="MySourceSwitch" value="All" />
    </switches -->
  </system.diagnostics>

</configuration>
```
