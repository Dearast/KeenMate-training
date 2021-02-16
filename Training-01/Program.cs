using System;

namespace NewColoring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Training by KeenMate";
            Write("Training by KeenMate \t\t\t\t\t Done by Damien Clément", ConsoleColor.Green, true);
            ChangeColor();
        }

        public static void BackSelect()
        {
            Write("Write 0 for reset");
            string checkPress = Console.ReadLine();
            if (checkPress == "0")
            {
                ChangeColor();
            }
        }

        public static void ChangeColor()
        {
            Write("Write year");
            string check = Console.ReadLine();
            int year = int.Parse(check);
            ConsoleColor BackMonth;
            ConsoleColor Month;
            for (int i = -5; i < 5; i++)
            {
                int newYear = year + i;
                Write("year - " + newYear);
                for (int y = 0; y < 12; y++)
                {
                    if (y < 4.5f && y > 1.5f)
                    {
                        Month = ConsoleColor.DarkGreen;
                    }
                    else if (y > 4.5f && y < 7.5f)
                    {
                        Month = ConsoleColor.DarkRed;
                    }
                    else if (y > 7.5f && y < 10.5f)
                    {
                        Month = ConsoleColor.DarkMagenta;
                    }
                    else
                    {
                        Month = ConsoleColor.DarkBlue;
                    }

                    if (newYear % 4 == 0)
                    {
                        BackMonth = y == 2 ? ConsoleColor.DarkBlue : ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        BackMonth = ConsoleColor.Black;
                    }

                    Write("month - " + (y + 1), Month, false, BackMonth);
                    for (int a = 0; a < 30; a++)
                    {
                        Write("day - " + (a + 1), Month, false, BackMonth);
                    }
                }
                if (i <= 8)
                {
                    Write("-------------------------------------------------------------");
                }
            }
            BackSelect();
        }
        public static void Write(string text, ConsoleColor color = ConsoleColor.White, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = backColor;
            Console.WriteLine(text);
            if (backToDefault)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
