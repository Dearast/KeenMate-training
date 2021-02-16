using System;
using System.Collections.Generic;

namespace NewWriteToWindow
{
    class Program
    {
        public static string text;
        public static string textB;
        public static string TextA;
        public static List<int[]> StartText = new List<int[]>();
        public static List<int> EndRowText = new List<int>();
        public static List<int> countRow = new List<int>();

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

        static void Start(int countWindows)
        {
            int[,] ConsoleArray = new int[100, 30];
            int countPos = (int)(2 * countWindows);
            int[] windowPos = new int[countPos];
            GenerateWindow(countWindows, ref ConsoleArray);
            CreateWriteBoxForEachWindow(countWindows, ConsoleArray, ref StartText, ref EndRowText, ref countRow);
            DrawWindow(ConsoleArray);
            //each second update drawtextinwindow
            //write text
            int maxTextLength = 0;
            for (int i = 0; i < EndRowText.Count; i++)
            {
                maxTextLength += ((EndRowText[i] + 1) * countRow[i]);
            }
            do
            {
                //text += Console.ReadKey().ToString();
                if (!string.IsNullOrEmpty(text) && text.Length > maxTextLength)
                {
                    char[] textChar = text.ToCharArray();
                    ConsoleKeyInfo ans = Console.ReadKey(true);
                    if (ans.Key != ConsoleKey.LeftArrow && ans.Key != ConsoleKey.RightArrow)
                    {
                        text = string.Empty;
                        textB += textChar[0];
                        for (int i = 1; i < textChar.Length; i++)
                        {
                            text += textChar[i];
                        }
                        text += ans.KeyChar.ToString();
                    }
                    else if (ans.Key == ConsoleKey.LeftArrow && textB.Length > 1)
                    {
                        char[] newTextChar = new char[textChar.Length];
                        text = string.Empty;
                        for (int i = 0; i < textChar.Length - 1; i++)
                        {
                            newTextChar[i + 1] += textChar[i];
                        }
                        TextA += textChar[textChar.Length - 1];
                        newTextChar[0] = textB[textB.Length - 1];
                        for (int i = 0; i < textChar.Length; i++)
                        {
                            text += newTextChar[i];
                        }
                        char[] newTextB = textB.ToCharArray();
                        textB = string.Empty;
                        for (int i = 0; i < newTextB.Length - 1; i++)
                        {
                            textB += newTextB[i];
                        }
                    }
                    else if (ans.Key == ConsoleKey.RightArrow && TextA.Length > 1)
                    {
                        char[] newTextChar = new char[textChar.Length];
                        text = string.Empty;
                        for (int i = 1; i < textChar.Length; i++)
                        {
                            newTextChar[i - 1] += textChar[i];
                        }
                        textB += textChar[0];
                        newTextChar[newTextChar.Length - 1] = TextA[TextA.Length - 1];
                        for (int i = 0; i < textChar.Length; i++)
                        {
                            text += newTextChar[i];
                        }
                        char[] newTextA = TextA.ToCharArray();
                        TextA = string.Empty;
                        for (int i = 0; i < newTextA.Length - 1; i++)
                        {
                            TextA += newTextA[i];
                        }
                    }
                }
                else
                {
                    ConsoleKeyInfo ans = Console.ReadKey(true);
                    if (ans.Key != ConsoleKey.LeftArrow && ans.Key != ConsoleKey.RightArrow)
                    {
                        text += ans.KeyChar.ToString();
                    }
                }
                DrawTextInWindow();
            } while (true);
        }

        static void GenerateWindow(int countWindows, ref int[,] ConsoleArray)
        {
            int currentWindow = 0;
            while (currentWindow < countWindows)
            {
                GenerateOneWindow(ref ConsoleArray, ref currentWindow);
            }
        }

        static void GenerateOneWindow(ref int[,] ConsoleArry, ref int currentWindow)
        {
            Random r = new Random();
            int randomSizeX = r.Next(5, 15);
            int randomSizeY = r.Next(4, 5);
            int randomPosX = r.Next(randomSizeX / 2, 100 - (randomSizeX / 2));
            int randomPosY = r.Next(randomSizeY / 2, 30 - (randomSizeY / 2));
            bool isInCollision = false;
            for (int y = (randomPosY - randomSizeY / 2); y < (randomPosY + randomSizeY / 2); y++)
            {
                for (int x = (randomPosX - randomSizeX / 2); x < (randomPosX + randomSizeX / 2); x++)
                {
                    if (ConsoleArry[x, y] > 0)
                    {
                        isInCollision = true;
                    }
                    if (isInCollision)
                    {
                        break;
                    }
                }
                if (isInCollision)
                {
                    break;
                }
            }

            if (!isInCollision)
            {
                for (int y = (randomPosY - randomSizeY / 2); y < (randomPosY + randomSizeY / 2); y++)
                {
                    for (int x = (randomPosX - randomSizeX / 2); x < (randomPosX + randomSizeX / 2); x++)
                    {
                        if (y == (randomPosY - randomSizeY / 2) || y == (randomPosY + randomSizeY / 2) - 1 ||
                        x == (randomPosX - randomSizeX / 2) || x == (randomPosX + randomSizeX / 2) - 1)
                        {
                            ConsoleArry[x, y] = 99;
                        }
                        else
                        {
                            ConsoleArry[x, y] = currentWindow + 1;
                        }
                    }
                }
                currentWindow++;
            }
        }

        static void CreateWriteBoxForEachWindow(int countWindows, int[,] ConsoleArray, ref List<int[]> StartText,
        ref List<int> EndRowText, ref List<int> countRow)
        {
            for (int i = 0; i < countWindows; i++)
            {
                int[] startPos = new int[2];
                bool isFirstPos = false;
                int countRowInt = 0;
                bool isCounted = false;
                int rowLength = 0;
                int maxRowLength = 0;
                for (int y = 0; y < 30; y++)
                {
                    for (int x = 0; x < 100; x++)
                    {
                        if (isFirstPos == false && ConsoleArray[x, y] == i + 1)
                        {
                            startPos[0] = x;
                            startPos[1] = y;
                            StartText.Add(startPos);
                            isFirstPos = true;
                        }
                        else if (ConsoleArray[x, y] == i + 1 && isCounted == false)
                        {
                            isCounted = true;
                            countRowInt++;
                        }
                        else if (ConsoleArray[x, y] == i + 1)
                        {
                            rowLength++;
                        }
                    }
                    if (rowLength > maxRowLength)
                    {
                        maxRowLength = rowLength;
                        rowLength = 0;
                    }
                    else
                    {
                        rowLength = 0;
                    }
                    isCounted = false;
                }
                EndRowText.Add(maxRowLength);
                countRow.Add(countRowInt);
            }
        }

        static void DrawWindow(int[,] ConsoleArray)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 100; x++)
                {
                    if (ConsoleArray[x, y] == 99)
                    {
                        WriteTextWithUseMouse("#", y, x);
                    }
                }
            }
            Console.SetCursorPosition(0, 0);
        }

        static void DrawTextInWindow()
        {
            if (!string.IsNullOrEmpty(text))
            {
                int writeTo = 0;
                for (int i = 2; i > 0; i--)
                {
                    if (text.Length > (countRow[i] * EndRowText[i]))
                    {
                        writeTo = i;
                        break;
                    }
                }

                char[] charText = text.ToCharArray();
                int currentChar = 0;
                for (int i = 0; i < writeTo + 1; i++)
                {
                    int lastPos = 0;
                    int startPosX = StartText[i][0];
                    int startPosY = StartText[i][1];
                    for (int y = 0; y < countRow[i]; y++)
                    {
                        for (int x = 0; x < EndRowText[i] + 1; x++)
                        {
                            if (currentChar >= text.Length)
                            {
                                break;
                            }
                            WriteTextWithUseMouse(charText[currentChar].ToString(), y + startPosY, startPosX + lastPos);
                            currentChar++;
                            lastPos++;
                            Console.SetCursorPosition(startPosX + lastPos, y + startPosY);
                        }
                        lastPos = 0;
                    }
                }
            }
        }
    }
}
