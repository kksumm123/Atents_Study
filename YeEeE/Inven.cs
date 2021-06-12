using System;
using System.Collections.Generic;
using System.Text;
using static ShortCut;
class Inven
{
    int row;
    int column;
    List<Item> inventory = new List<Item>();


    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (!(inventory.Contains(item)) && inventory[i] == null)
            {
                inventory[i] = item;
                return true;
            }
        }
        return false;
    }

    /*
     □ □ □ □ □
     □ □ □ □ □
     □ □ □ □ □

     0 1 2 3 4 
     5 6 7 8 9
     */
    public void InvenItem()
    {
        int idx = 0;
        while (true)
        {
            Console.Clear();
            Print("");
            Print("이동 : 방향키");
            Print("ESC : 나가기");
            Print("아이템은 중복 습득이 불가능합니다.");
            Print("");
            InvenRender(idx);
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.LeftArrow:
                    idx = (idx == 0 ? 0 : --idx);
                    break;
                case ConsoleKey.UpArrow:
                    idx = (idx - column < 0 ? idx : idx - column);
                    break;
                case ConsoleKey.RightArrow:
                    idx = (idx == inventory.Count - 1 ? idx : ++idx);
                    break;
                case ConsoleKey.DownArrow:
                    idx = (idx + column > inventory.Count - 1 ? idx : idx + column);
                    break;
                case ConsoleKey.Escape:
                    return;
            }
        }
    }
    void InvenRender(int idx)
    {
        if (idx < 0 || idx > inventory.Count)
            return;
        int selectIdx = idx;

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                if (selectIdx == (i * column) + j)
                    Console.Write("●");
                else if (inventory[((i * column) + j)] == null)
                    Console.Write("□");
                else
                    Console.Write("■");
                
            }
            Console.WriteLine("");
        }
        Print("");
        Print("선택된 아이템 :");
        if (inventory[selectIdx] != null)
        {
            Print($"아이템명 : {inventory[selectIdx].Name}");
            Print($"공격력 : {inventory[selectIdx].Att}");
            Print($"체력 : {inventory[selectIdx].MaxHp}");
        }
        else
            Print("없음.");
    }


    public Inven(int row, int column)
    {
        this.row = row;
        this.column = column;
        for (int i = 0; i < row * column; i++)
            inventory.Add(null);
    }
}
