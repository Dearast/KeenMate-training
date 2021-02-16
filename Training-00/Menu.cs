using System;

namespace Functions
{
    internal class Menu
    {
        //NOTE Variables
        private string m_label;
        private string[] m_elements;
        private int pointer = 0;
        private bool m_loopSelection;
        private int m_collumnCount = 1; //TODO do for more collumn select
        private int m_pos_x;
        private int m_pos_y;

        //NOTE Colors
        ConsoleColor m_default_foreground;
        ConsoleColor m_default_background;
        ConsoleColor m_selected_foreground;
        ConsoleColor m_selected_background;

        public Menu(string t_label, string[] t_elements, bool t_drawInMiddle = true, bool t_loopSelection = false)
        {
            m_label = t_label;
            m_elements = t_elements;
            m_loopSelection = t_loopSelection;

            if(t_drawInMiddle)
            {
                int elementMaxSize = 0;
                foreach (var element in m_elements)
                {
                    if(element.Length > elementMaxSize)
                    {
                        elementMaxSize = element.Length;
                    }
                }

                m_pos_x = (Console.WindowWidth / 2) - (elementMaxSize / 2);
                m_pos_y = (Console.WindowHeight / 2) - (m_elements.Length / 2);
            }

            Set_Color();
        }

        public Menu(string[] t_elements, int t_pos_x = 0, int t_pos_y = 0, bool t_loopSelection = false)
        {
            m_elements = t_elements;
            m_loopSelection = t_loopSelection;

            m_pos_x = t_pos_x;
            m_pos_y = t_pos_y;

            Set_Color();
        }

        public void Update(ConsoleKeyInfo t_ans)
        {
            switch (t_ans.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if (pointer < 1)
                        {
                            if (m_loopSelection)
                            {
                                pointer = (m_elements.Length - 1);
                            }
                        }
                        else
                        {
                            pointer--;
                        }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (pointer > (m_elements.Length - 2))
                        {
                            if (m_loopSelection)
                            {
                                pointer = 0;
                            }
                        }
                        else
                        {
                            pointer++;
                        }
                        break;
                    }
            }
        }

        public void Draw(ConsoleTools t_consT)
        {
            //NOTE Set color as defualt
            t_consT.Set_Color(ConsoleColor.Green, m_default_background);
            t_consT.Set_Cursor_Position((Console.WindowWidth / 2) - (m_label.Length / 2), m_pos_y - 2);
            t_consT.WriteLine(m_label);
            t_consT.Set_Color(m_default_foreground, m_default_background);
            for (int i = 0; i < m_elements.Length; i++)
            {
                t_consT.Set_Cursor_Position((Console.WindowWidth / 2) - (m_elements[i].Length / 2), m_pos_y + i);
                if (pointer == i)
                {
                    t_consT.Set_Color(m_selected_foreground, m_selected_background);
                    t_consT.WriteLine(m_elements[i]);
                    //NOTE Set color to default
                    t_consT.Set_Color(m_default_foreground, m_default_background);
                }
                else
                {
                    t_consT.WriteLine(m_elements[i]);
                }
            }
        }

        public void Set_Color(ConsoleColor t_default_foreground = ConsoleColor.White, ConsoleColor t_default_background = ConsoleColor.Black, ConsoleColor t_selected_foreground = ConsoleColor.White, ConsoleColor t_selected_background = ConsoleColor.DarkGray)
        {
            m_default_foreground = t_default_foreground;
            m_default_background = t_default_background;
            m_selected_foreground = t_selected_foreground;
            m_selected_background = t_selected_background;
        }

        public int Get_Pointer()
        {
            return pointer;
        }

        public string Get_Pointer_ElementName()
        {
            return m_elements[pointer];
        }
    }
}