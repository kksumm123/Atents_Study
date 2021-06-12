using System;
using System.Collections.Generic;
using static ShortCut;

class Player : FightUnit
{
    int addAtt = 0;
    int addMaxHp = 0;
    int gold;
    int level = 1;
    int exp = 0;
    public int Level 
    { get { return level; } }

    Dictionary<string, int> skillListDic
        = new Dictionary<string, int>() {
            { "강한공격", 1 }
        , { "벽력일섬",  1 }
            , { "초토화",  1 }
            , { "힐", 1 }
                };
    public Inven inven = new Inven(2, 5);

    public void Rest()
    {
        int skillMaxUsePoint = 1;

        Console.Clear();
        Print("zzzZZZ");
        Pause();
        Print("푹 쉬었습니다");
        curHp = maxHp;

        List<string> skillNames = new List<string>();
        foreach (string skill in skillListDic.Keys)
            skillNames.Add(skill);
        foreach (var item in skillNames)
            skillListDic[item] = skillMaxUsePoint;
        Pause();
    }
    public void GetGold(int value)
    {
        gold += value;
        Print($"+{value} Gold");
    }
    public void GetExp(int value)
    {
        exp += value;
        Print($"+{value} Exp");
        while (exp >= (level * 10)) // Level Up
        {
            exp -= (level * 10);
            level++;
            maxHp += 3;
            curHp = maxHp;
            Print($"레벨업 ! Lv.{level - 1} -> Lv.{level}");
            Pause();
            Print($"체력이 모두 회복되고 최대 체력이 3 증가합니다.");
        }
    }
    public void GetItem(Item item)
    {
        if (item != null)
        {
            if (inven.AddItem(item))
            {
                if (item.Att != 0)
                    addAtt += item.Att;
                if (item.MaxHp != 0)
                {
                    addMaxHp += item.MaxHp;
                    maxHp += addMaxHp;
                }
            }
        }
    }
    public bool IsReinforce()
    {
        return gold >= att * 2;
    }
    public void Reinforce()
    {
        gold -= att * 2;
        att++;
        Print("무기가 강화되었습니다 !");
        Print($"공격력 : {att - 1} -> {att}");
    }

    public string Skill(FightUnit Other)
    {
        string selectedSkill = SkillSelect();
        int nomarlAtt = this.Att + addAtt;
        float skillAtt = 1;
        switch (selectedSkill)
        {
            case "강한공격":
                skillAtt = 1.5f;
                Print("강하게 친다");
                break;
            case "벽력일섬":
                skillAtt = 2f;
                Console.Clear();
                Print("번개의 호흡");
                Pause();
                Print("일의 형");
                Pause();
                Print("벽력일섬");
                Pause();
                PrintHekirekiReverce();
                break;
            case "초토화":
                skillAtt = 4f;
                Console.Clear();
                Print("초토화");
                Pause();
                Print초토화();
                break;
            case "힐":
                Print("체력을 회복합니다.");
                return "HEAL";
            case "NONESELECT":
                return "NONESELECT";
        }

        int totalAtt = (int)(nomarlAtt * skillAtt);
        Other.CurHp -= totalAtt;
        Print($"{this.name}이(가) {Other.Name}에게 {totalAtt} 만큼의 피해를 주었습니다.");
        return "SELECTED";


        string SkillSelect() // 스킬정보를 나열하고 사용가능 횟수를 출력
        {
            int idx = 0;
            // 사용자 입력을 받아 쉽게 처리하기 위한 리스트 선언
            // 리스트에는 스킬명이 들어감
            List<string> skillList = new List<string>();
            Print("-----------------");
            Print("스킬공격력 - 강한공격 : 1.5배, 벽력일섬 : 2배, 초토화 : 4배");
            foreach (KeyValuePair<string, int> skill in skillListDic)
            {
                //{skill.Key} : {skill.Value}
                skillList.Add(skill.Key);
                Print($"{++idx}. {skill.Key} - 사용가능 횟수 {skill.Value} 회");
            }
            Print($"{++idx}. 나가기");

            // 스킬 추가를 위한 확장성 고려하여 코딩
            while (true)
            {
                char inputIdxChar = Console.ReadKey(true).KeyChar;
                // 숫자 1번키 ~ 9번키 사이의 입력이라면
                if (inputIdxChar >= '1' && inputIdxChar <= '9')
                {
                    // 입력된 숫자를 인덱스로 변환
                    int inputIdxInt = int.Parse(inputIdxChar.ToString());
                    if (skillList.Count > --inputIdxInt) // 0부터 시작이므로 -1
                    {
                        // 스킬목록딕셔너리[스킬명리스트] 값 (= 사용가능횟수)가 0보다 크다면
                        if (skillListDic[skillList[inputIdxInt]] > 0)
                        { // 사용가능 횟수 1 차감
                            skillListDic[skillList[inputIdxInt]]--;
                            Print(skillList[inputIdxInt]);
                            return skillList[inputIdxInt];
                        }
                        else
                        { // 사용가능 횟수 부족
                            Print($"{skillList[inputIdxInt]} 사용가능 횟수가 부족합니다.");
                        }
                    }
                    else if (idx == inputIdxInt + 1)
                    { // 나가기 버튼
                        return "NONESELECT";
                    }
                }
            }
        }
    }
    public void SkillHeal()
    {
        curHp = maxHp;
    }
    override public void Attack(FightUnit Other)
    {
        int totalAtt = this.Att + addAtt;
        Other.CurHp -= totalAtt;
        Print($"{this.name}이(가) {Other.Name}에게 {totalAtt} 만큼의 피해를 주었습니다.");
    }


    override public void StatusRender()
    {
        Print($"{name}------");
        Print($"Lv(Exp) : {level}({exp})");
        Print($"공격력  (+ 추가공격력) : {att + addAtt} (+ {addAtt})");
        Print($"체력 : {curHp} / {maxHp}");
        Print($"골드 : {gold} Gold");
        Print("------------");
        Print("");
    }
    public Player(string _name, int _att, int _maxHp)
    {
        name = _name;
        att = _att;
        maxHp = _maxHp;
        curHp = 1;
    }
}

