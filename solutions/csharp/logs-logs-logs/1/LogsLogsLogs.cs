using System;

// TODO: define the 'LogLevel' enum
enum LogLevel : short
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0,
}

static class LogLine
{
    private const string _trace = "TRC";
    private const string _debug = "DBG";
    private const string _info = "INF";
    private const string _warning = "WRN";
    private const string _error = "ERR";
    private const string _fatal = "FTL";

    public static LogLevel ParseLogLevel(string logLine) =>
        logLine.Substring(1, 3).ToUpper() switch
        {
            _trace => LogLevel.Trace,
            _debug => LogLevel.Debug,
            _info => LogLevel.Info,
            _warning => LogLevel.Warning,
            _error => LogLevel.Error,
            _fatal => LogLevel.Fatal,
            _ => LogLevel.Unknown,
        };

    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(short)logLevel}:{message}";
}
