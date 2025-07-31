public class LogLevels {

  public static String message(String logLine) {
    int startIndex = logLine.indexOf(":") + 1;
    return logLine.substring(startIndex).trim();
  }

  public static String logLevel(String logLine) {
    int startIndex = logLine.indexOf("[") + 1;
    int endIndex = logLine.indexOf("]");
    return logLine.substring(startIndex, endIndex).toLowerCase();
  }

  public static String reformat(String logLine) {
    return message(logLine) + " (" + logLevel(logLine) + ")";
  }
}
