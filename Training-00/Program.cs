﻿using System;

namespace Functions
{
    internal class Program
    {
        static Properties props;
        static ConsoleTools conTol;
        static Menu menu;
        static bool running = true;
        static ConsoleKeyInfo ans;

        private static void Main(string[] args)
        {
            // Setup Console
            props = new Properties("[Keen|Mate] - Training - Functions");
            menu = new Menu
                (
                    "Main Menu",
                    new string[] 
                    {
                        "Lower and Upper text",
                        "sorting text",
                        "Trim text",
                        "Remove part of text",
                        "Find part of tex",
                        "Copy text",
                        "Reverse text",
                        "1st letter after space will be uppercase",
                        "last word will uppercase",
                        "every second word will uppercase",
                        "delet without trim",
                        "calculator"
                    },
                    true
                );

            // Init call
            Init();
            //Console.ReadKey();

            //WriteFunctions();
            //SelectFunction();
        }

        public static void Init()
        {
            conTol = new ConsoleTools(ConsoleColor.Green);
            conTol.WriteLine("[Keen|Mate] Training - Done by Damien Clément", true);
            conTol.NextRow(3);

            Update();

            //WriteFunctions();
            //SelectFunction();
        }

        public static void Update()
        {
            while(running)
            {
                //NOTE Get console key
                menu.Update(ans);
                menu.Draw(conTol);
                ans = Console.ReadKey(true);
                switch(ans.Key)
                {
                    case ConsoleKey.Enter:
                        {
                            switch (menu.Get_Pointer_ElementName())
                            {
                                case "Lower and Upper text":
                                    {
                                        loverUpperText();
                                        break;
                                    }
                                case "sorting text":
                                    {
                                        sortingText();
                                        break;
                                    }
                                case "Trim text":
                                    {
                                        TrimText();
                                        break;
                                    }
                                case "Remove part of text":
                                    {
                                        RemovePartOfText();
                                        break;
                                    }
                                case "Find part of tex":
                                    {
                                        FindPartOfText();
                                        break;
                                    }
                                case "Copy text":
                                    {
                                        CopyText();
                                        break;
                                    }
                                case "Reverse text":
                                    {
                                        ReverseString();
                                        break;
                                    }
                                case "1st letter after space will be uppercase":
                                    {
                                        uppercase();
                                        break;
                                    }
                                case "last word will uppercase":
                                    {
                                        uppercaseLastWord();
                                        break;
                                    }
                                case "every second word will uppercase":
                                    {
                                        everySecondWordWillUppercase();
                                        break;
                                    }
                                case "delet without trim":
                                    {
                                        deleteWithoutTrim();
                                        break;
                                    }
                                case "calculator":
                                    {
                                        Calculator();
                                        break;
                                    }
                                default:
                                    {
                                        string output = "Pointer - " + menu.Get_Pointer();
                                        conTol.WriteLine(output);
                                        break;
                                    }
                            }
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            running = false;
                            break;
                        }
                }
            }
        }

        public static void Back()
        {
            conTol.WriteLine("Press any key to go back");
            Console.ReadKey(true);
            conTol.Clear();
            conTol = new ConsoleTools(ConsoleColor.Green);
            conTol.WriteLine("[Keen|Mate] Training - Done by Damien Clément", true);
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

        public static void WriteFunctions()
        {
            //Console.Clear();
            Console.WriteLine("press key for call function");
            Console.WriteLine("0 = Lower and Upper text");
            Console.WriteLine("1 = sorting text");
            Console.WriteLine("2 = Trim text");
            Console.WriteLine("3 = Remove part of text");
            Console.WriteLine("4 = Find part of text");
            Console.WriteLine("5 = Copy text");
            Console.WriteLine("6 = Reverse text");
            Console.WriteLine("7 = 1st letter after space will be uppercase");
            Console.WriteLine("8 = last word will uppercase");
            Console.WriteLine("9 = every second word will uppercase");
            Console.WriteLine("10 = delet without trim");
            Console.WriteLine("11 = calculation");
        }

        public static void SelectFunction()
        {
            string check = Console.ReadLine();
            switch (check)
            {
                case "0":
                    loverUpperText();
                    break;

                case "1":
                    sortingText();
                    break;

                case "2":
                    TrimText();
                    break;

                case "3":
                    RemovePartOfText();
                    break;

                case "4":
                    FindPartOfText();
                    break;

                case "5":
                    CopyText();
                    break;

                case "6":
                    ReverseString();
                    break;

                case "7":
                    uppercase();
                    break;

                case "8":
                    uppercaseLastWord();
                    break;

                case "9":
                    everySecondWordWillUppercase();
                    break;

                case "10":
                    deleteWithoutTrim();
                    break;

                case "11":
                    Calculator();
                    break;

                default:
                    Write("Bad select function please reapet");
                    SelectFunction();
                    break;
            }
        }

        public static void loverUpperText()
        {
            conTol.Clear();
            conTol.WriteLine("Lowercase and uppercase function");
            conTol.WriteLine("Write text and then push enter");

            string defaultText = Console.ReadLine();
            string lowerText = defaultText.ToLower();
            string upperText = defaultText.ToUpper();

            conTol.WriteLine(defaultText + " this is a default text" + "\n" + lowerText + " this is a lower text" + "\n" + upperText + " this is a upper text");

            Back();
        }

        public static void sortingText()
        {
            conTol.Clear();
            conTol.WriteLine("Soritng text function");
            conTol.WriteLine("Write text and then push enter");

            string sort = Console.ReadLine();
            char[] sortChar = sort.ToCharArray();
            Array.Sort(sortChar);
            string sorted = string.Empty;
            foreach (var item in sortChar)
            {
                sorted += item;
            }

            conTol.WriteLine("Before: " + sort);
            conTol.WriteLine("After: " + sorted);

            Back();
        }

        public static void TrimText()
        {
            Console.Clear();
            Write("Trim text function");
            Write("press key for call function" + "\n" + "0 = remove characters from begin of text" + "\n" +
                "1 = remove characters from end of text" + "\n" + "2 = remove character from both side");
            string check = Console.ReadLine();
            if (check == "0")
            {
                Write("Write text and then push enter");
                string text = Console.ReadLine();
                Write("write all characters for remove [ WITHOUT SPACES AND DOTS ] and then push enter");
                string charText = Console.ReadLine();
                char[] Char = charText.ToCharArray();
                string NewString = text.TrimStart(Char);
                Write("Before: " + text);
                Write("After: " + NewString);
            }
            else if (check == "1")
            {
                Write("Write text and then push enter");
                string text = Console.ReadLine();
                Write("write all characters for remove [ WITHOUT SPACES AND DOTS ] and then push enter");
                string charText = Console.ReadLine();
                char[] Char = charText.ToCharArray();
                string NewString = text.TrimEnd(Char);
                Write("Before: " + text);
                Write("After: " + NewString);
            }
            else if (check == "2")
            {
                Write("Write text and then push enter");
                string text = Console.ReadLine();
                Write("write all characters for remove [ WITHOUT SPACES AND DOTS ] and then push enter");
                string charText = Console.ReadLine();
                char[] Char = charText.ToCharArray();
                string NewString = text.Trim(Char);
                Write("Before: " + text);
                Write("After: " + NewString);
            }
            WriteFunctions();
            SelectFunction();
        }

        public static void RemovePartOfText()
        {
            Console.Clear();
            Write("Remove part of text function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            Write("Write two int for position and for length");
            string pos1 = Console.ReadLine();
            int posx = int.Parse(pos1);
            string pos2 = Console.ReadLine();
            int posy = int.Parse(pos2);
            string newText = text.Remove(posx, posy);
            Write("Before: " + text);
            Write("After: " + newText);
            WriteFunctions();
            SelectFunction();
        }

        public static void FindPartOfText()
        {
            Console.Clear();
            Write("Find part of text function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            Write("Write text and then push enter");
            string startText = Console.ReadLine();
            Write("Write text and then push enter");
            string endText = Console.ReadLine();
            if (text.Contains(startText) && text.Contains(endText))
            {
                int Start = text.IndexOf(startText, 0) + startText.Length;
                int End = text.IndexOf(endText, Start);
                string strToReplace = text.Substring(Start, End - Start);
                Write("Find");
                Write(strToReplace);
            }
            else
            {
                Write("Text not contain finding part of text");
            }
            WriteFunctions();
            SelectFunction();
        }

        public static void CopyText()
        {
            Console.Clear();
            Write("Copy text function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            Write("Write number for multiplication");
            string numberText = Console.ReadLine();
            int number = int.Parse(numberText);
            string[] writeText = new string[number];
            for (int i = 0; i < number; i++)
            {
                writeText[i] = text;
                Write(writeText[i]);
            }
            WriteFunctions();
            SelectFunction();
        }

        public static void ReverseString()
        {
            Console.Clear();
            Write("Reverse text function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            char[] charX = text.ToCharArray();
            Array.Reverse(charX);
            string reversed = string.Empty;
            foreach (var item in charX)
            {
                reversed += item;
            }
            Write("Before: " + text);
            Write("After: " + reversed);
            WriteFunctions();
            SelectFunction();
        }

        public static void uppercase()
        {
            Console.Clear();
            Write("Uppercase function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            char[] charX = text.ToCharArray();
            charX[0] = Char.ToUpper(charX[0]);
            for (int i = 0; i < charX.Length; i++)
            {
                if (Char.IsWhiteSpace(charX[i]))
                {
                    charX[i + 1] = Char.ToUpper(charX[i + 1]);
                }
            }
            string newText = string.Empty;
            foreach (var item in charX)
            {
                newText += item;
            }
            Write("Before: " + text);
            Write("After: " + newText);
            WriteFunctions();
            SelectFunction();
        }

        public static void uppercaseLastWord()
        {
            Console.Clear();
            Write("Uppercase last word function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            char[] charX = text.ToCharArray();
            for (int i = (charX.Length - 1); i > 1; i--)
            {
                if (Char.IsWhiteSpace(charX[i]))
                {
                    for (int y = 0; y < (charX.Length - i); y++)
                    {
                        charX[i + y] = Char.ToUpper(charX[i + y]);
                    }
                    break;
                }
            }
            string newText = string.Empty;
            foreach (var item in charX)
            {
                newText += item;
            }
            Write("Before: " + text);
            Write("After: " + newText);
            WriteFunctions();
            SelectFunction();
        }

        public static void everySecondWordWillUppercase()
        {
            Console.Clear();
            Write("Every second word will uppercase function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            bool second = true;
            int start = 0;
            int end = 0;
            int value = 0;
            char[] charX = text.ToCharArray();
            for (int i = 0; i < charX.Length; i++)
            {
                if (Char.IsWhiteSpace(charX[i]))
                {
                    if (second == false)
                    {
                        second = true;
                        Write("second");
                    }
                    else
                    {
                        for (int y = i + 1; y < charX.Length; y++)
                        {
                            if (Char.IsWhiteSpace(charX[y]))
                            {
                                start = i;
                                end = y;
                                value = end - start;
                                Write("find second word");
                                Write("start " + start);
                                Write("end " + end);
                                Write("value is " + value);
                                for (int x = 0; x < value; x++)
                                {
                                    Write("lets change");
                                    charX[x + start] = Char.ToUpper(charX[x + start]);
                                }
                                second = false;
                                break;
                            }
                        }
                    }
                }
            }
            string newText = string.Empty;
            foreach (var item in charX)
            {
                newText += item;
            }
            Write("Before: " + text);
            Write("After: " + newText);
            WriteFunctions();
            SelectFunction();
        }

        public static void deleteWithoutTrim()
        {
            Console.Clear();
            Write("Deleting without trim function");
            Write("Write text and then push enter");
            string text = Console.ReadLine();
            Write("Write text and then push enter");
            string deleteText = Console.ReadLine();
            char[] charX = deleteText.ToCharArray();
            char[] charText = text.ToCharArray();
            string newText = text;
            for (int i = 0; i < charText.Length; i++)
            {
                Deleting(ref newText, charX);
            }
            Write("Before: " + text);
            Write("After: " + newText);
            WriteFunctions();
            SelectFunction();
        }

        public static void Deleting(ref string newText_, char[] CharX_)
        {
            char[] newTextChar = newText_.ToCharArray();
            for (int i = 0; i < newTextChar.Length; i++)
            {
                if (newTextChar[i] == CharX_[0])
                {
                    newText_ = newText_.Remove(i, 1);
                    break;
                }
            }
        }

        public static void Calculator()
        {
            Console.Clear();
            Write("Calculate function");
            Write("Select function");
            Write("0 = +");
            Write("1 = -");
            Write("2 = /");
            Write("3 = *");
            Write("4 = power");
            Write("5 = while power");
            Write("6 = do/while power");
            Write("7 = [f (x) = x ^ (x-1)]");
            Write("8 = time");
            string check = Console.ReadLine();
            if (check == "0")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = numberCalcul + numberCalcul2;
                Console.WriteLine(value);
            }
            else if (check == "1")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = numberCalcul - numberCalcul2;
                Write(value.ToString());
            }
            else if (check == "2")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = numberCalcul / numberCalcul2;
                Write(value.ToString());
            }
            else if (check == "3")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = numberCalcul * numberCalcul2;
                Write(value.ToString());
            }
            else if (check == "4")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = (float)Math.Pow(numberCalcul, numberCalcul2);
                Write(value.ToString());
            }
            else if (check == "5")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = numberCalcul;
                while (value < numberCalcul2)
                {
                    value = (float)Math.Pow(value, 2);
                    Write(value.ToString());
                }
            }
            else if (check == "6")
            {
                Console.Clear();
                Write("write two number");
                string calcul = Console.ReadLine();
                float numberCalcul = float.Parse(calcul, System.Globalization.CultureInfo.InvariantCulture);
                string calcul2 = Console.ReadLine();
                float numberCalcul2 = float.Parse(calcul2, System.Globalization.CultureInfo.InvariantCulture);
                float value = numberCalcul;
                do
                {
                    value = (float)Math.Pow(value, 2);
                    Write(value.ToString());
                } while (value < numberCalcul2);
            }
            else if (check == "7")
            {
                Console.Clear();
                Write("f(x) = x ^ (x - 1)");
                for (int i = -10; i < 10; i++)
                {
                    float value = (float)Math.Pow(i, (i - 1));
                    Write(value.ToString());
                }
            }
            else if (check == "8")
            {
                do
                {
                    Write(DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second
                        + "." + DateTime.Now.Millisecond);
                } while (!Console.KeyAvailable);
                {
                    Write("stopped");
                    Write(DateTime.Now.Hour + "." + DateTime.Now.Minute + "." + DateTime.Now.Second);
                }
            }
            WriteFunctions();
            SelectFunction();
        }
    }
}