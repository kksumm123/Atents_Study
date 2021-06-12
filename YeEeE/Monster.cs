using static ShortCut;

class Monster : FightUnit
{
    static public double rateDropItem = 0.2;

    public int DropGold()
    {
        return rand.Next(att, att + maxHp);
    }
    public int Exp()
    {
        return rand.Next(att, att + maxHp);
    }
    public Item DropItem()
    {
        if (this.name.Contains("정예") && rand.NextDouble() < rateDropItem) // 20% 확률
        {
            Print($"{ItemList.itemList[name].Name}이(가) 보인다 !");
            Pause();
            return ItemList.itemList[name];
        }
        return null;
    }

    public Monster(string _name, int _att, int _maxHp)
    {
        name = _name;
        att = _att;
        maxHp = _maxHp;
        curHp = maxHp;
    }
}

