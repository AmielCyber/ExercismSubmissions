using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        string[] updatedSponsers = new string[this.sponsors.Length + sponsors.Length];
        int index = 0;
        foreach (string ogSponser in this.sponsors)
        {
            updatedSponsers[index] = ogSponser;
            index++;
        }
        foreach (string newSponsor in sponsors)
        {
            updatedSponsers[index] = newSponsor;
            index++;
        }
        this.sponsors = updatedSponsers;
    }

    public string DisplaySponsor(int sponsorNum) => this.sponsors[sponsorNum];

    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum <= this.latestSerialNum)
        {
            serialNum = this.latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
        this.latestSerialNum = serialNum;
        batteryPercentage = this.batteryPercentage;
        distanceDrivenInMeters = this.distanceDrivenInMeters;
        return true;
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        bool success = car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters);
        if (distanceDrivenInMeters == 0 || !success)
            return "no data";
        return $"usage-per-meter={(100 - batteryPercentage) / distanceDrivenInMeters}";
    }
}
