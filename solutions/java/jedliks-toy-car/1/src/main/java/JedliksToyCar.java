public class JedliksToyCar {
    private int metersDriven;
    private int batteryPercentage;
    private static final int BATTERY_PER_DRIVE = 1;
    private static final int METERS_PER_DRIVE = 20;

    public JedliksToyCar() {
        this.metersDriven = 0;
        this.batteryPercentage = 100;
    };

    public static JedliksToyCar buy() {
        return new JedliksToyCar();
    }

    public String distanceDisplay() {
        return "Driven " + metersDriven + " meters";
    }

    public String batteryDisplay() {
        if (batteryPercentage > 0)
            return "Battery at " + this.batteryPercentage + "%";
        return "Battery empty";
    }

    public void drive() {
        if (batteryPercentage >= BATTERY_PER_DRIVE) {
            batteryPercentage -= BATTERY_PER_DRIVE;
            metersDriven += METERS_PER_DRIVE;
        } else {
            batteryPercentage = 0;
        }
    }
}
