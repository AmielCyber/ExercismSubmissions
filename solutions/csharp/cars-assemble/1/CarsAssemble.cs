using System;

static class AssemblyLine
{
    private const int ProductionPerSpeed = 221;
    public static double SuccessRate(int speed)
    {
        if(speed < 1){
            return 0;
        }
        if(speed < 5){
            return 1.0;
        }
        if(speed < 9){
            return 0.90;
        }
        if(speed < 10){
            return 0.80;
        }
        return 0.77;
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return ProductionPerSpeed * speed * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        return (int)ProductionRatePerHour(speed) / 60;
    }
}
