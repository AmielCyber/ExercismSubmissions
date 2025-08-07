abstract class Character
{
  private string _characterType;

  protected Character(string characterType)
  {
    _characterType = characterType;
  }

  public abstract int DamagePoints(Character target);

  public virtual bool Vulnerable()
  {
    return false;
  }

  public override string ToString()
  {
    return $"Character is a {_characterType}";
  }
}

class Warrior : Character
{
  private int _defaultDamage = 6;
  private int _criticalDamage = 10;

  public Warrior() : base("Warrior") { }

  public override int DamagePoints(Character target)
  {
    return target.Vulnerable() ? _criticalDamage : _defaultDamage;
  }
}

class Wizard : Character
{
  private bool _hasSpell;
  private int _damageWithSpell = 12;
  private int _damageWithoutSpell = 3;

  public Wizard() : base("Wizard")
  {
    _hasSpell = false;
  }

  public override int DamagePoints(Character target)
  {
    return _hasSpell ? _damageWithSpell : _damageWithoutSpell;
  }

  public void PrepareSpell()
  {
    _hasSpell = true;
  }

  public override bool Vulnerable()
  {
    return !_hasSpell;
  }
}
