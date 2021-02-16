using System;
using System.Timers;

namespace NewTimeBomb
{
    class Program
    {
        public static int Time = 0;
        public static int LastPosCur = 0;
        public static int CountRandomNumber = 0;
        public static int CorrectNumber = 0;
        public static int CorrectPos = 0;
        public static int WriteRow = 3;
        public static string HiddenPass;
        public static Timer TimerStatic;
        public static int CountBomb = 1;
        public static int CurrentDestroydBomb = 0;

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

        public static void WriteTextWithCursorPosition(string text, int row, ConsoleColor color = ConsoleColor.White)
        {
            int screenWidth = Console.WindowWidth;
            System.Console.SetCursorPosition(((screenWidth / 2) - (text.Length / 2)), row);
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            Console.Title = "Training by KeenMate";
            WriteLine("Training by KeenMate | Done by Damien Clément", ConsoleColor.Green, true, true);
            WriteLine("Press any key to start game");
            Console.ReadKey();
            Start();
            WriteLine("Press any key to end game");
            Console.ReadKey();
        }

        public static void Start()
        {
            Level(out int level);
            CountRandomNumber = level * 3;
            if (CountRandomNumber > 8)
            {
                CountRandomNumber = 8;
            }
            GenerateNumber(CountRandomNumber, out string[] pass);
            DrawHiddenPass();
            Time += 90 - (level * 10);
            for (int i = 0; i < pass.Length; i++)
            {
                WriteLine(pass[i], ConsoleColor.Red);
            }
            WriteLine("Press any key to start");
            Console.ReadKey();
            Console.Clear();
            Timer timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(DoEverySecond);
            timer.Start();
            TimerStatic = timer;
            ReadPass(pass);
        }

        public static void Level(out int checkLevelInt)
        {
            WriteLine("Select level between 1-32");
            string checkLevel = Console.ReadLine();
            checkLevelInt = int.Parse(checkLevel);
            if (int.Parse(checkLevel) > 32)
            {
                checkLevel = "32";
            }
            if (int.Parse(checkLevel) >= 4)
            {
                CountBomb = (int.Parse(checkLevel) - 3);
                Time += (int.Parse(checkLevel) - 3) * 10;
            }
        }

        public static void GenerateNumber(int countNumber, out string[] textPassMulti)
        {
            textPassMulti = new string[CountBomb];
            int[] randomNumber = new int[countNumber];
            Random r = new Random();
            for (int a = 0; a < textPassMulti.Length; a++)
            {
                if (randomNumber.Length - a < 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        randomNumber[i] = r.Next(0, 9);
                        textPassMulti[a] += randomNumber[i].ToString();
                    }
                }
                else
                {
                    for (int i = 0; i < (randomNumber.Length - a); i++)
                    {
                        randomNumber[i] = r.Next(0, 9);
                        textPassMulti[a] += randomNumber[i].ToString();
                    }
                }
            }
        }

        public static void ReadPass(string[] randomNumberPass)
        {
            string checkTip = Console.ReadLine();
            if (checkTip.Length < randomNumberPass[CurrentDestroydBomb].Length)
            {
                WriteTextWithCursorPosition("pass must have same lenght", WriteRow, ConsoleColor.Red);
                WriteRow++;
                ReadPass(randomNumberPass);
            }
            WriteRow++;
            CheckNumberPass(randomNumberPass, checkTip);
        }

        public static void CheckNumberPass(string[] randomNumberPass, string check)
        {
            CorrectNumber = 0;
            CorrectPos = 0;
            char[] passChar = randomNumberPass[CurrentDestroydBomb].ToCharArray();
            char[] checkTipChar = check.ToCharArray();
            for (int i = 0; i < passChar.Length; i++)
            {
                if (passChar[i] == checkTipChar[i])
                {
                    CorrectPos++;
                }
                for (int a = 0; a < checkTipChar.Length; a++)
                {
                    if (passChar[i] == checkTipChar[a])
                    {
                        CorrectNumber++;
                    }
                }
            }
            if (CorrectNumber == CountRandomNumber)
            {
                WriteTextWithCursorPosition("this bomb " + CurrentDestroydBomb + " - is destroyed", WriteRow, ConsoleColor.Red);
                WriteRow++;
                CurrentDestroydBomb++;
                End();
            }
            ReadPass(randomNumberPass);
        }

        public static void DrawConsole()
        {
            LastPosCur = Console.CursorLeft;
            WriteTextWithCursorPosition("  ", 0, 0);
            WriteTextWithCursorPosition(Time.ToString(), 0, ConsoleColor.Green);
            WriteTextWithCursorPosition(HiddenPass, 1, ConsoleColor.White);
            WriteTextWithCursorPosition(("Correct number in pass is - " + (CorrectNumber) + " | Correct position of number is - " + CorrectPos), 2, ConsoleColor.Yellow);
            Console.SetCursorPosition(LastPosCur, WriteRow);
        }

        public static void End()
        {
            if (CurrentDestroydBomb == CountBomb)
            {
                Console.Clear();
                WriteLine("You have destroyed the bomb", ConsoleColor.Green, true);
                TimerStatic.Stop();
            }
        }

        public static void DrawHiddenPass()
        {
            for (int i = 0; i < CountRandomNumber; i++)
            {
                HiddenPass += "*";
            }
        }

        public static void Timer(ref int time)
        {
            time--;
            if (time <= 0)
            {
                TimerStatic.Stop();
                Console.Clear();
                WriteLine("BOOOOOOOOM", ConsoleColor.Red);
                WriteLine("You are dead", ConsoleColor.Red);
            }
        }

        public static void DoEverySecond(object sender, ElapsedEventArgs e)
        {
            Timer(ref Time);
            DrawConsole();
        }
    }
}
