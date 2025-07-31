public class CarsAssemble {
    private final int CARS_PER_SPEED = 221;

    public double productionRatePerHour(int speed) {
        return CARS_PER_SPEED * speed * getSuccessRate(speed);
    }

    public int workingItemsPerMinute(int speed) {
        return (int) (productionRatePerHour(speed) / 60);
    }

    private double getSuccessRate(int speed) {
        if (speed >= 1 && speed <= 4)
            return 1.0;
        if (speed >= 5 && speed <= 8)
            return 0.9;
        if (speed == 9)
            return 0.8;
        return 0.77;
    }
}
