using System;

namespace Functions
{
    internal class Properties
    {
        private string m_console_title = "[Keen|Mate] - Training";

        public Properties(string t_console_title)
        {
            m_console_title = t_console_title;

            Set_Console_Title(m_console_title);
        }

        private static void Set_Console_Title(string t_console_title)
        {
            Console.Title = t_console_title;
        }
    }
}