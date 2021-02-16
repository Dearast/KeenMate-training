using System;
using System.Collections.Generic;
using System.Timers;

namespace WriteToWindows
{
    class Program
    {
        public static Timer TimerStatic;
        public static int[,] PosInformation = new int[100, 30];
        public static int Time = 0;
        public static List<int> sizeWin = new List<int>();
        public static int[,] windowList1;
        public static int[,] windowList2;
        public static int[,] windowList3;
        public static string text;

        public static void WriteTextWithUseMouse(string text, int row, int lastPos)
        {
            int screenWidth = Console.WindowWidth;
            System.Console.SetCursorPosition(lastPos, row);
            Console.WriteLine(text);
        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);
            Start(3);
            Console.ReadKey();
        }

        static void Start(int maxWindows)
        {
            int window = 0;
            int countDo = 0;
            List<int> sizeWin = new List<int>();
            while (window < maxWindows && countDo < 5000)
            {
                GenerateWindow(ref window, ref PosInformation, ref sizeWin);
                countDo++;
            }
            Console.WriteLine("Windows try do " + countDo + " / Window created - " + window);
            Console.Clear();
            DrawWindow();
            Timer timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(DoEverySecond);
            timer.Start();
            TimerStatic = timer;
            ReadKeyPress();
        }

        static void GenerateWindow(ref int window, ref int[,] PosInformation, ref List<int> sizeWin)
        {
            Random r = new Random();
            int randomSizeX = r.Next(5, 25);
            int randomSizeY = r.Next(5, 15);
            int randomPosX = r.Next(randomSizeX / 2, 100 - (randomSizeX / 2));
            int randomPosY = r.Next(randomSizeY / 2, 30 - (randomSizeY / 2));
            int size = 0;
            bool isInCorrect = false;
            for (int x = (randomPosX - (randomSizeX / 2)); x < (randomPosX + (randomSizeX / 2)); x++)
            {
                for (int y = (randomPosY - (randomSizeY / 2)); y < (randomPosY + (randomSizeY / 2)); y++)
                {
                    if (PosInformation[x, y] > 0)
                    {
                        isInCorrect = true;
                        break;
                    }
                }
                if (isInCorrect)
                {
                    break;
                }
            }

            for (int x = (randomPosX - (randomSizeX / 2)); x < (randomPosX + (randomSizeX / 2)); x++)
            {
                for (int y = (randomPosY - (randomSizeY / 2)); y < (randomPosY + (randomSizeY / 2)); y++)
                {
                    if (x == (randomPosX - (randomSizeX / 2)) || x == (randomPosX - 1 + (randomSizeX / 2)) || y == (randomPosY - (randomSizeY / 2)) || y == (randomPosY - 1 + (randomSizeY / 2)))
                    {
                        PosInformation[x, y] = 99;
                    }
                    else
                    {
                        PosInformation[x, y] = window + 1;
                        size++;
                    }
                }
            }

            if (isInCorrect == false)
            {
                window++;
                if (window == 0)
                {
                    for (int x = 0; x < randomSizeX; x++)
                    {
                        for (int y = 0; y < randomSizeX; y++)
                        {

                        }
                    }
                }
                else if (window == 1)
                {
                    windowList1

                }
                else if (window == 2)
                {
                    windowList1

                }
                sizeWin.Add(size);
            }
        }

        static void DrawWindow()
        {
            int LastPosCur = Console.CursorLeft;
            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 30; y++)
                {
                    if (PosInformation[x, y] == 99)
                    {
                        WriteTextWithUseMouse("#", y + 1, x);
                    }
                }
            }
            Console.SetCursorPosition(LastPosCur, 0);
        }

        static void DrawDebug(List<int> sizeWin)
        {
            //draw only text to window
            int LastPosCur = Console.CursorLeft;

            Console.SetCursorPosition(LastPosCur, 0);
        }

        public static void ReadKeyPress()
        {
            text = Console.ReadLine();
        }

        public static void DoEverySecond(object sender, ElapsedEventArgs e)
        {
            Timer(ref Time);
            DrawDebug(sizeWin);
        }

        public static void Timer(ref int time)
        {
            time--;
        }
    }
}
