using System.Collections.Generic;

class Item
{
    string name;
    int att;
    int maxHp;
    public string Name
    { get { return name; } }
    public int Att
    { get { return att; } }
    public int MaxHp
    { get { return maxHp; } }

    public Item(string _name, int _att = 0, int _plusHp = 0)
    {
        this.name = _name;
        this.att = _att;
        this.maxHp = _plusHp;
    }
}
class ItemList
{
    static public Dictionary<string, Item> itemList = new Dictionary<string, Item>() {
        { "정예 : 슬라임" , new Item("슬라임 덩어리", 1, 5) }
        , { "정예 : 오크" , new Item("오크의 몽둥이", 3, 0) }
        , { "정예 : 고블린" , new Item("고블린의 단검", 2, 0) }
        , { "정예 : 트롤" , new Item("트롤의 몽둥이", 4, 0) }
        , { "정예 : 플랑크톤" , new Item("플랑크톤의 숨겨진 게살버거 비법", 15, 15) }
        , { "정예 : 아메바" , new Item("아메바의 영혼", 0, 0) }
        , { "정예 : 곰벌레" , new Item("곰벌레의 생명력", 0, 10) }
        , { "정예 : 사또밥" , new Item("사또밥", 0, 0) }
        , { "정예 : 버터링" , new Item("버터링쿠키", 0, 0) }
        , { "정예 : 하리보" , new Item("하리보젤리", 2, 10) }
    };
    //{ "슬라임", "오크", "고블린", "트롤"
    // , "플랑크톤", "아메바", "곰벌레"
    // , "사또밥", "버터링", "하리보"};

}