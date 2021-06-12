using System;

class Program
{
    enum Weekend
    {
        mon,
        tue,
        wen,
        thu,
        fri,
        sat,
        sun
    }


    static void Main(string[] args)
    {
        // 구구단
        // 숫자를 입력받으면 해당 단 출력

        // 1. 입력 받아아 함
        string Get_StrNum = Console.ReadLine();
        
        // 2. 입력 받은 숫자 판단
        //int IntNum1 = Convert.ToInt32(Get_StrNum);
        //int IntNum2 = int.Parse(Get_StrNum);
        //int IntNum3;
        //int.TryParse(Get_StrNum, out IntNum3);
        int IntNum = int.Parse(Get_StrNum);
        for (Weekend week = Weekend.mon; week < Weekend.sat; week++)
        {
            Console.WriteLine($"The column is {week}");
        }
        // 3. 곱셈 출력
        for (int i = 1; i <= 9; i++)
        {
            //Console.WriteLine(IntNum + " * " + i + " = " + IntNum * i);
            Console.WriteLine($"{IntNum} * {i} = {IntNum * i}");
        }
    }
}