public class LogLine {
    private final LogLevel logLevel;
    private final String level;
    private final String detail;

    public LogLine(String logLine) {
        this.level = getLevel(logLine);
        this.detail = getLog(logLine);
        this.logLevel = getLogLabelFromLevel(this.level);
    }

    public LogLevel getLogLevel() {
        return logLevel;
    }

    public String getOutputForShortLog() {

        return this.logLevel.getEncodedLevel() + ":" + this.detail;
    }

    private String getLevel(String logLine) {
        int startIndex = logLine.indexOf('[') + 1;
        int endIndex = logLine.indexOf(']');
        return logLine.substring(startIndex, endIndex);
    }

    private String getLog(String logLine) {
        int startIndex = logLine.indexOf(':') + 1;
        return logLine.substring(startIndex).strip();
    }

    private LogLevel getLogLabelFromLevel(String level) {
        return switch (level) {
            case "TRC":
                yield LogLevel.TRACE;
            case "DBG":
                yield LogLevel.DEBUG;
            case "INF":
                yield LogLevel.INFO;
            case "WRN":
                yield LogLevel.WARNING;
            case "ERR":
                yield LogLevel.ERROR;
            case "FTL":
                yield LogLevel.FATAL;
            default:
                yield LogLevel.UNKNOWN;
        };
    }

}
