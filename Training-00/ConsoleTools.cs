using System;

namespace Functions
{
    internal class ConsoleTools
    {
        private ConsoleColor m_foreground;
        private ConsoleColor m_background;

        public ConsoleTools(ConsoleColor t_foregroundColor = ConsoleColor.White, ConsoleColor t_backgroundColor = ConsoleColor.Black)
        {
            Set_Color(t_foregroundColor, t_backgroundColor);
        }

        public void WriteLine(string text, bool center = false)
        {
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
        }

        public void NextRow(int t_rowCount)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + t_rowCount);
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void Set_Color(ConsoleColor t_foregroundColor = ConsoleColor.White, ConsoleColor t_backgroundColor = ConsoleColor.Black)
        {
            m_foreground = t_foregroundColor;
            m_background = t_backgroundColor;

            Console.ForegroundColor = t_foregroundColor;
            Console.BackgroundColor = t_backgroundColor;
        }

        public void Set_Cursor_Position(int t_pos_x, int t_pos_y)
        {
            Console.SetCursorPosition(t_pos_x, t_pos_y);
        }
    }
}