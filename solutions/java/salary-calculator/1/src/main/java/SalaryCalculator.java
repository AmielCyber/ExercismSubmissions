public class SalaryCalculator {
    private static final int DAYS_SKIPPED_PENALTY = 5;
    private static final int BONUS_PRODUCT_AMOUNT = 20;
    private static final int REGULAR_PRODUCT_PAY = 10;
    private static final int BONUS_PRODUCT_PAY = 13;

    private static final double SKIP_PENALTY = 0.85;
    private static final double BASE_SALARY = 1000.0;
    private static final double SALARY_CAP = 2000.0;

    public double salaryMultiplier(int daysSkipped) {
        return daysSkipped < DAYS_SKIPPED_PENALTY ? 1.0 : SKIP_PENALTY;
    }

    public int bonusMultiplier(int productsSold) {
        return productsSold < BONUS_PRODUCT_AMOUNT ? REGULAR_PRODUCT_PAY : BONUS_PRODUCT_PAY;
    }

    public double bonusForProductsSold(int productsSold) {
        return productsSold * bonusMultiplier(productsSold);
    }

    public double finalSalary(int daysSkipped, int productsSold) {
        double salary = (BASE_SALARY * salaryMultiplier(daysSkipped)) + (productsSold * bonusMultiplier(productsSold));

        return salary > SALARY_CAP ? SALARY_CAP : salary;
    }
}
