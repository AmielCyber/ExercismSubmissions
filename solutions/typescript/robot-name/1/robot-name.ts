const COMBINATIONS = 26 * 26 * 10 * 10 * 10;
export class Robot {
  protected static letter: string[] = [..."ABCDEFGHIJKLMNOPQRSTUVWXYZ"]
  private static usedNumber = new Array<boolean>(COMBINATIONS);
  private _number: number;
  private _name: string;

  constructor() {
    this._number = Robot.getUnusedNumber();
    this._name = Robot.getNameFromNumber(this._number);
  }

  public get name(): string {
    return this._name;
  }

  public resetName(): void {
    this._number = Robot.getUnusedNumber();
    this._name = Robot.getNameFromNumber(this._number);
  }

  public static releaseNames(): void {
    for (let num = 0; num < this.usedNumber.length; num++)
      this.usedNumber[num] = false;
  }

  private static getUnusedNumber(): number {
    let randomNumber = this.getRandomInteger(COMBINATIONS);
    let safeCount = 0;
    while (this.usedNumber[randomNumber]) {
      if (randomNumber === this.usedNumber.length - 1) {
        randomNumber = 0;
      } else {
        randomNumber++;
      }
      safeCount++;
      if (safeCount >= COMBINATIONS)
        throw Error("There are no unused numbers.");
    }
    this.usedNumber[randomNumber] = true;
    return randomNumber;
  }

  private static getNameFromNumber(index: number): string {
    const radix26Num = Math.floor(index / 1000).toString(26);
    const letters = this.radix26ToLetters(radix26Num);
    const digits = (index % 1000).toString().padStart(3, "0");
    return letters + digits;
  }

  private static radix26ToLetters(radix26: string): string {
    let letters = "";
    for (const ch of radix26) {
      letters += this.letter[parseInt(ch, 26)];
    }
    return letters.padStart(2, "A");
  }

  private static getRandomInteger(max: number): number {
    return Math.floor(Math.random() * max);
  }
}
