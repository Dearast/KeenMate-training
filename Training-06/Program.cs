using System;
using System.Configuration;

namespace Training_06
{
    class Program
    {
        public static string TitleName = ConfigurationManager.AppSettings["titleName"];

        public static void WriteAsWriteLine(string text, int color)
        {
            char[] charx = text.ToCharArray();
            ConsoleColor colorC = ConsoleColor.White;
            Color(color, out colorC);
            for (int i = 0; i < charx.Length; i++)
            {
                Console.ForegroundColor = colorC;
                Console.Write(charx[i].ToString());
            }
        }

        public static void Color(int colorID, out ConsoleColor color)
        {
            color = ConsoleColor.White;
            switch (colorID)
            {
                case 0:
                    color = ConsoleColor.DarkYellow;
                    break;
                default:
                    color = ConsoleColor.White;
                    break;
            }
        }

        public static void CheckString(ref string text)
        {
            if (text == string.Empty)
            {
                text = "0";
            }
        }

        public static void WriteLine(string text, ConsoleColor color = ConsoleColor.White, bool center = false, bool backToDefault = false, ConsoleColor backColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = color;
            Console.BackgroundColor = backColor;
            if (center)
            {
                int screenWidth = Console.WindowWidth;
                int stringWidth = text.Length;
                int spaces = (screenWidth / 2) + (stringWidth / 2);
                Console.WriteLine(text.PadLeft(spaces));
            }
            else
            {
                Console.WriteLine(text);
            }

            if (backToDefault)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        static void Main(string[] args)
        {
            Console.Title = TitleName;
            WriteLine("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
            Start();
            Console.ReadKey();
        }

        public static void Start(int selectLevelB = 0)
        {
            int width = 100;
            int height = 30;
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
            width -= 10;
            height -= 5;
            CollisionCount(0, width);
            string selectLevelStr = string.Empty;
            if (selectLevelB == 0)
            {
                selectLevelStr = Console.ReadLine();
                CheckString(ref selectLevelStr);
            }
            int alcoholic = 0;
            int profesionalAlcoholic = 0;
            int berserker = 0;
            int selectLevel = int.Parse(selectLevelStr);
            SetDifficultLevel(selectLevel, out alcoholic, out profesionalAlcoholic, out berserker);
            int[,] array;
            Create2DArray(out array, width, height);
            AddArrayID(ref array, width, height, alcoholic, profesionalAlcoholic, berserker);
            Console.Clear();
            DrawMap(array, width, height);
            Console.ReadKey();
            CleanPeople(ref array, width, height);
#if !DEBUG
			Console.Clear();
			DrawMap(array, width, height);
			System.Console.SetCursorPosition(1, 1);
			Console.ReadKey();
			Start(selectLevel);
#endif
        }

        public static void CleanPeople(ref int[,] array, int width, int height)
        {
            for (int y = 1; y < (height - 1); y++)
            {
#if DEBUG
                WriteLine("Check next row");
#endif
                for (int x = 1; x < (width - 1); x++)
                {
                    if (x == 1 && y == 1)
                    {
                        array[x, y] = 0;
                    }
                    else if (x == ((width - 1) - 1) && y == 1)
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        if (array[x - 1, y] <= 2 || array[x, y + 1] <= 2)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                    }
                    else if (x == 1 && y == ((width - 1) - 1))
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        if (array[x + 1, y] <= 2 || array[x, y - 1] <= 2)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                    }
                    else if (x == ((width - 1) - 1) && y == ((width - 1) - 1))
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        if (array[x - 1, y] <= 2 || array[x, y - 1] <= 2)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                    }
                    else if (y == 1)
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        int missing = 0;
                        if (array[x - 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x + 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x, y + 1] <= 2)
                        {
                            missing++;
                        }

                        if (missing > 1)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                        missing = 0;
                    }
                    else if (y == ((height - 1) - 1))
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        int missing = 0;
                        if (array[x - 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x + 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x, y - 1] <= 2)
                        {
                            missing++;
                        }

                        if (missing > 1)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                        missing = 0;
                    }
                    else if (x == 1)
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        int missing = 0;
                        if (array[x, y + 1] <= 2)
                        {
                            missing++;
                        }

                        if (array[x + 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x, y - 1] <= 2)
                        {
                            missing++;
                        }

                        if (missing > 1)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                        missing = 0;
                    }
                    else if (x == ((width - 1) - 1))
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        int missing = 0;
                        if (array[x, y + 1] <= 2)
                        {
                            missing++;
                        }

                        if (array[x - 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x, y - 1] <= 2)
                        {
                            missing++;
                        }

                        if (missing > 1)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                        missing = 0;
                    }
                    else
                    {
#if DEBUG
                        WriteLine("Checking - " + x + "|" + y);
#endif
                        int missing = 0;
                        if (array[x, y + 1] <= 2)
                        {
                            missing++;
                        }

                        if (array[x - 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x, y - 1] <= 2)
                        {
                            missing++;
                        }

                        if (array[x + 1, y] <= 2)
                        {
                            missing++;
                        }

                        if (array[x, y + 1] <= 2)
                        {
                            missing++;
                        }

                        if (missing > 2)
                        {
                            array[x, y] = 0;
#if DEBUG
                            WriteLine("Removed - " + x + "|" + y);
#endif
                        }
                        missing = 0;
                    }
                }
            }
        }

        public static void DrawMap(int[,] array, int width, int height)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (array[x, y] == 1)
                    {
                        Console.Write("-");
                    }
                    else if (array[x, y] == 2)
                    {
                        Console.Write("|");
                    }
                    else if (array[x, y] == 3)
                    {
                        Console.Write("ß");
                    }
                    else if (array[x, y] == 4)
                    {
                        Console.Write("ß");
                    }
                    else if (array[x, y] == 5)
                    {
                        Console.Write("ß");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("");
            }
        }

        public static void AddArrayID(ref int[,] array, int width, int height, int alcoholic, int profesionalAlcoholic,
            int berserker)
        {
            Random r = new Random();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int random = r.Next(0, 100);
                    if (y == 0 || y == (height - 1))
                    {
                        array[x, y] = 1;
                    }
                    else if (x == 0 || x == (width - 1))
                    {
                        array[x, y] = 2;
                    }
                    else
                    {
                        if (random > alcoholic)
                        {
                            array[x, y] = 3;
                        }
                        else if (random > profesionalAlcoholic)
                        {
                            array[x, y] = 4;
                        }
                        else if (random > berserker)
                        {
                            array[x, y] = 5;
                        }
                    }
                }
            }
        }

        public static void Create2DArray(out int[,] array, int width, int height)
        {
            array = new int[width, height];
        }

        public static void SetDifficultLevel(int selectLevel, out int alcoholic, out int profesionalAlcoholic,
            out int berserker)
        {
            alcoholic = 0;
            profesionalAlcoholic = 0;
            berserker = 0;
            switch (selectLevel)
            {
                case 1:
                    alcoholic = 25;
                    profesionalAlcoholic = 36;
                    berserker = 55;
                    break;
                case 2:
                    alcoholic = 30;
                    profesionalAlcoholic = 42;
                    berserker = 50;
                    break;
                case 3:
                    alcoholic = 35;
                    profesionalAlcoholic = 50;
                    berserker = 65;
                    break;
                default:

                    break;
            }
        }

        public static void CollisionCount(int count, int widthScreen)
        {
            string text = string.Empty;
            int length = ((widthScreen - 20) * 2) - TitleName.Length;
            for (int i = 0; i < length; i++)
            {
                text += " ";
            }
            Console.Title = TitleName + text + "Current collision - " + count;
        }
    }
}
