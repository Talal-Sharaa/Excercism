abstract class Character
{
    private bool _Vulnerable;
    private string _CharacterType;
    protected Character(string characterType)
    {
        _CharacterType = characterType;
        _Vulnerable = false;
    }
    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable() => _Vulnerable;

    public override string ToString() => $"Character is a {_CharacterType}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target) => target.Vulnerable()? 10:6;
}

class Wizard : Character
{
    private bool _IsSpellPrepared = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target) => _IsSpellPrepared? 12:3;
    public override bool Vulnerable() => _IsSpellPrepared? false:true;
    public void PrepareSpell() =>
        _IsSpellPrepared = true;
}
