class CalculatorConundrum {

  public String calculate(int operand1, int operand2, String operation) {
    return switch (operation) {
      case null -> throw new IllegalArgumentException("Operation cannot be null");
      case "+" -> getAdditionResult(operand1, operand2);
      case "*" -> getMultiplicationResult(operand1, operand2);
      case "/" -> getDivisionResult(operand1, operand2);
      case "" -> throw new IllegalArgumentException("Operation cannot be empty");
      default -> throw new IllegalOperationException("Operation '" + operation + "' does not exist");
    };
  }

  private String getAdditionResult(int operand1, int operand2) {
    return getResultString(operand1, operand2, operand1 + operand2, "+");
  }

  private String getMultiplicationResult(int operand1, int operand2) {
    return getResultString(operand1, operand2, operand1 * operand2, "*");
  }

  private String getDivisionResult(int operand1, int operand2) {
    try {
      int result = operand1 / operand2;
      return getResultString(operand1, operand2, result, "/");
    } catch (Exception e) {
      throw new IllegalOperationException("Division by zero is not allowed", e);
    }
  }

  private String getResultString(int operand1, int operand2, int result, String operand) {
    return String.format("%d %s %d = %d", operand1, operand, operand2, result);
  }
}
