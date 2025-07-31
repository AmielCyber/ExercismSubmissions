export class Clock {
  private static MINUTES_IN_HOUR = 60;
  private static HOURS_IN_DAY = 24;
  protected readonly _hour: number;
  protected readonly _minute: number;

  constructor(hour: number, minute = 0) {
    this._hour = this.getStandardizedHour(hour, minute);
    this._minute = this.getStandardizedMinute(minute);
  }

  public toString(): string {
    return this._hour.toString().padStart(2, "0") + ":" + this._minute.toString().padStart(2, "0");
  }

  public plus(minutes: number): Clock {
    return new Clock(this._hour, this._minute + minutes);
  }

  public minus(minutes: number): Clock {
    return new Clock(this._hour, this._minute - minutes);
  }

  public equals(other: Clock): boolean {
    return this._hour === other._hour && this._minute === other._minute;
  }

  private getStandardizedHour(hours: number, minutes: number): number {
    const additionalHour = Math.floor(minutes / Clock.MINUTES_IN_HOUR);
    let newHour = (hours + additionalHour) % Clock.HOURS_IN_DAY;

    if (newHour < 0)
      newHour = Clock.HOURS_IN_DAY + newHour;

    return newHour;
  }

  private getStandardizedMinute(minutes: number): number {
    let newMinutes = minutes % Clock.MINUTES_IN_HOUR;
    if (newMinutes < 0)
      newMinutes = Clock.MINUTES_IN_HOUR + newMinutes;

    return newMinutes;
  }
}
