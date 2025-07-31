export class DnDCharacter {
  public strength = 0;
  public dexterity = 0;
  public constitution = 0;
  public intelligence = 0;
  public wisdom = 0;
  public charisma = 0;
  public hitpoints = 10;

  constructor() {
    this.strength = DnDCharacter.getAbilityScore();
    this.dexterity = DnDCharacter.getAbilityScore();
    this.constitution = DnDCharacter.getAbilityScore();
    this.intelligence = DnDCharacter.getAbilityScore();
    this.wisdom = DnDCharacter.getAbilityScore();
    this.charisma = DnDCharacter.getAbilityScore();
    this.hitpoints += DnDCharacter.getModifierFor(this.constitution);
  }

  public static generateAbilityScore(): number {
    return this.getAbilityScore();
  }

  public static getModifierFor(abilityValue: number): number {
    return Math.floor((abilityValue - 10) / 2);
  }

  private static getAbilityScore(): number {
    let min = Number.MAX_VALUE;
    let sum = 0;
    for (let i = 0; i < 4; i++) {
      const rollNum = this.getDiceRollNum();
      if (rollNum < min)
        min = rollNum
      sum += rollNum;
    }
    sum -= min;
    return sum;
  }

  private static getDiceRollNum(): number {
    return Math.floor(Math.random() * 7);
  }
}
