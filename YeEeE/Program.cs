using System;
using System.Collections.Generic;
using System.Linq;
using static ShortCut;
// 완료 : 공격 우선순위 랜덤
// 완료 : 스킬 구현
// 완료 : 아이템 구현하기
// 완료 : 아이템 중복얻기 X
// 완료 : 아이템 옵션 적용하기
// todo : 상급 사냥터 구현하기

class Program
{
    static readonly List<string> monNameTable
        = new List<string>() { "슬라임", "오크", "고블린", "트롤"
                            , "플랑크톤", "아메바", "곰벌레"
                            , "사또밥", "버터링", "하리보"};

    //정예 몬스터 등장 확률
    private static double rateEliteMonster = 0.15;

    static void Main()
    {
        PrintStartEffect();
        PrintGameTitle();
        Print("1. 일반모드");
        Print("2. 치트모드 - 공격력 999, 체력 999, 정예몬스터 등장확률 100%, 장비 드랍률 100%");

        Player player = null;
        bool ModeSelect = true;
        string temp = "";
        while (ModeSelect)
        {
            char userInput = Console.ReadKey(true).KeyChar;
            temp += userInput.ToString();
            HiddenCommand(ref temp);
            switch (userInput)
            {
                case '1':
                    player = SetPlayer();
                    ModeSelect = false;
                    break;
                case '2':
                    player = new Player("CheatMode", 999, 999);
                    rateEliteMonster = 1;
                    Monster.rateDropItem = 1;
                    ModeSelect = false;
                    break;
            }
        }



        while (true)
        {
            Console.Clear();
            PrintGameTitle();
            player.StatusRender();
            Print("1. 마을");
            Print("2. 사냥터");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    Console.Clear();
                    Print("마을로 이동합니다.");
                    Pause();
                    Town(player);
                    break;
                case '2':
                    Console.Clear();
                    Print("사냥터로 이동합니다.");
                    Pause();
                    Battle(player);
                    break;
                default:
                    break;
            }
        }
    }

    private static void HiddenCommand(ref string temp)
    {
        if (temp.Contains("hidden"))
        {
            Print("히든 커맨드발동");
            temp = "";
        }
    }

    private static void Town(Player player)
    {
        while (true)
        {
            Console.Clear();
            PrintGameTitle();
            player.StatusRender();
            Print("1. 휴식하기");
            Print("2. 대장간");
            Print("3. 나의 인벤토리");
            Print("4. 마을 나가기");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    player.Rest();
                    break;
                case '2':
                    Console.Clear();
                    Print("대장간으로 이동합니다.");
                    Pause();
                    Forge(player);
                    break;
                case '3':
                    player.inven.InvenItem();
                    break;
                case '4':
                    Console.Clear();
                    Print("마을 밖으로 나갑니다.");
                    Pause();
                    return;
            }
        }
        // 대장간
        void Forge(Player player)
        {
            while (true)
            {
                Console.Clear();
                PrintGameTitle();
                player.StatusRender();
                Print("1. 장비 강화하기");
                Print("2. 대장간 나가기");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        if (player.IsReinforce())
                            player.Reinforce();
                        else
                            Print("강화비용은 [공격력수치 * 2] 만큼 필요합니다.");
                        Pause();
                        break;
                    case '2':
                        Console.Clear();
                        Print("대장간 밖으로 나갑니다.");
                        Pause();
                        return;
                }
            }
        }

    }
    private static void Battle(Player player)
    {
        Monster monster = GenMonster(player);

        while (player.IsDead() == false && monster.IsDead() == false)
        {
            Console.Clear();
            Print($"정예 몬스터 등장 확률 : {(int)((rateEliteMonster + (((double)player.Level - 1) / 100)) * 100)}% (공식 = (level - 1) + 15 %)");
            player.StatusRender();
            monster.StatusRender();
            Print("1. 싸운다");
            Print("2. 도망간다.");
            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    EachAttack(player, monster);
                    Pause();
                    break;
                case '2':
                    Console.Clear();
                    Print("무사히 도망쳤습니다.");
                    Pause();
                    return;
            }
        }
        if (player.IsDead())
        {
            Print($"{player.Name}이(가) 사망했습니다.");
            Print("마을로 이동됩니다.");
            Pause();
            player.Rest();
            Town(player);
        }
        else if (monster.IsDead())
        {
            Print($"{monster.Name}이(가) 사망했습니다.");
            player.GetGold(monster.DropGold());
            player.GetExp(monster.Exp());
            player.GetItem(monster.DropItem());
            Pause();
        }

        Monster GenMonster(Player player)
        {
            int addValue = 0;
            double totalRateEliteMonster = rateEliteMonster + (((double)player.Level - 1) / 100);
            if (rand.NextDouble() <= totalRateEliteMonster)
                addValue = rand.Next(20, 60);

            int monidx = rand.Next(monNameTable.Count);
            int att = rand.Next(3, 7) + addValue;
            int hp = rand.Next(5, 10) + addValue;
            Monster monstser = new Monster((addValue > 0 ? "정예 : " : "") + monNameTable[monidx], att, hp);
            return monstser;
        }

        void EachAttack(Player player, Monster monster)
        {
            // 리스트에 공격함수 2개 할당
            var attackAction =
                new List<Action<Player, Monster>>() { PlayersAttack, MonstersAttack };
            // 랜덤 인덱스
            int attackIdx = rand.Next(attackAction.Count);
            // 50%확률 플레이어, 몬스터 선공 결정
            attackAction[attackIdx](player, monster);
            Pause();
            attackAction.RemoveAt(attackIdx); // 사용한 함수 제거
            // 남은 차례 공격
            attackAction[0](player, monster);
            Pause();
            //switch (rand.Next(2))
            //{
            //    case 0:
            //        PlayersAttack(player, monster);
            //        Pause();
            //        MonstersAttack(player, monster);
            //        Pause();
            //        break;
            //    case 1:
            //        MonstersAttack(player, monster);
            //        Pause();
            //        PlayersAttack(player, monster);
            //        Pause();
            //        break;
            //}

            static void PlayersAttack(Player player, Monster monster)
            {
                if (player.IsDead() == false)
                {
                    while (true)
                    {
                        Console.Clear();
                        player.StatusRender();
                        monster.StatusRender();
                        Print("1. 일반공격.");
                        Print("2. 스킬사용.");
                        switch (Console.ReadKey(true).KeyChar)
                        {
                            case '1':
                                player.Attack(monster);
                                return;
                            case '2':
                                string result = player.Skill(monster);
                                if (result == "SELECTED")
                                    return;
                                else if (result == "HEAL")
                                {
                                    player.SkillHeal();
                                    return;
                                }
                                else
                                    break;
                        }
                    }
                }
            }
            static void MonstersAttack(Player player, Monster monster)
            {
                if (monster.IsDead() == false)
                    monster.Attack(player);
            }
        }
    }

    private static Player SetPlayer()
    {
        string name = "None";
        int att;
        int maxHp;
        bool quit = true;
        while (quit)
        {
            Console.Write("이름을 입력해주세요 : ");
            name = Console.ReadLine();
            Print($"{name}이(가) 맞습니까? (y/n)");
            string userInput = Console.ReadKey(true).KeyChar.ToString().ToLower();
            quit = (userInput != "y");
        }
        Print($"{name}님 환영합니다 !");
        Pause();

        SetPlayerStatus(out att, out maxHp);
        Player player = new Player(name, att, maxHp);
        return player;


        void SetPlayerStatus(out int att, out int maxHp)
        {
            Console.Clear();
            Print("캐릭터 능력치 조절");
            Random rand = new Random();
            bool quit = true;
            do
            {
                att = rand.Next(3, 10);
                maxHp = rand.Next(5, 10);
                Print($"공격력 : {att}, 체력 : {maxHp}");
                Print("능력치를 재설정하시겠습니까? (y/n)");
                string userInput = Console.ReadKey(true).KeyChar.ToString().ToLower();
                quit = (userInput != "n");
            } while (quit);
            Console.Clear();
            PrintGameTitle();
            Print("Hello World!");
            Pause();
        }
    }
}

