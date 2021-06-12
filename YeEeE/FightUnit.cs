using static ShortCut;
class FightUnit
{
    protected string name;
    protected int att;
    protected int curHp;
    protected int maxHp;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public int Att
    {
        get { return att; }
        set { att = value; }
    }
    public int CurHp
    {
        get { return curHp; }
        set { curHp = value; }
    }

    public bool IsDead()
    {
        if (this.curHp > 0)
            return false;
        else
            return true;
    }
    virtual public void Attack(FightUnit Other)
    {
        Other.CurHp -= this.Att;
        Print($"{this.name}이(가) {Other.name}에게 {this.Att} 만큼의 피해를 주었습니다.");
    }
    virtual public void StatusRender()
    {
        Print($"{name}------");
        Print($"공격력 : {att}");
        Print($"체력 : {curHp} / {maxHp}");
        Print("------------");
        Print("");
    }
}

