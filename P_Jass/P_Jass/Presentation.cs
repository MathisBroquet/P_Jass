using System;
using System.Collections.Generic;
using System.Text;

namespace P_Jass
{
    class Presentation
    {
        //Properties
        private string _title;
        private string _str1;
        private string _str2;
        private PresentationType _presentationType;

        public enum PresentationType
        {
            TitleAndText,
            TitleDoubleText,
        }

        /// <summary>
        /// Constructor for one title and a text under
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        public Presentation(string title, string text)
        {
            _presentationType = PresentationType.TitleAndText;
            _title = title;
            _str1 = text;
        }

        /// <summary>
        /// Constructor for one title and under two texts between
        /// </summary>
        /// <param name="title">Title of the slide</param>
        /// <param name="text1">First text</param>
        /// <param name="text2">Second text</param>
        public Presentation(string title, string text1, string text2)
        {
            _presentationType = PresentationType.TitleDoubleText;
            _title = title;
            _str1 = text1;
            _str2 = text2;
        }

        public void Display()
        {
            switch (_presentationType)
            {
                case PresentationType.TitleAndText:
                    DisplayTitle(_title);
                    DisplaySingleText(_str1);
                    break;
                case PresentationType.TitleDoubleText:
                    DisplayTitle(_title);
                    DisplayDoubleText(_str1, _str2);
                    break;
                default:
                    break;
            }
        }

        private void DisplayTitle(string title)
        {
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write('┌');
            for (int i = 0; i < System.Console.WindowWidth - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.Write('┐');
            System.Console.Write($"| {title}");
            for (int i = 0; i < System.Console.WindowWidth - title.Length - 3; i++)
            {
                System.Console.Write(' ');
            }
            System.Console.Write('|');
            System.Console.Write('└');
            for (int i = 0; i < System.Console.WindowWidth - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.WriteLine('┘');
        }

        private void DisplayDoubleText(string text1, string text2)
        {
            System.Console.SetCursorPosition(0, 3);
            int tempcount = 0;
            int count = 0;
            string[] wrd1 = text1.Split(' ');
            System.Console.Write('┌');
            for (int i = 0; i < System.Console.WindowWidth / 2 - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.WriteLine('┐');

            for (int i = 0; i < System.Console.WindowHeight - 5; i++)
            {
                tempcount = 0;
                System.Console.Write('|');
                while (tempcount < System.Console.WindowWidth / 2 - 2)
                {
                    if (count < wrd1.Length && tempcount + wrd1[count].Length + 1 <= System.Console.WindowWidth / 2 - 2)
                    {
                        System.Console.Write(wrd1[count] + " ");
                        tempcount += wrd1[count].Length + 1;
                        count++;
                    }
                    else
                    {
                        System.Console.Write(" ");
                        tempcount++;
                    }
                }
                System.Console.WriteLine('|');
            }

            System.Console.Write('└');
            for (int i = 0; i < System.Console.WindowWidth / 2 - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.Write('┘');


            System.Console.SetCursorPosition(System.Console.WindowWidth / 2, 3);
            tempcount = 0;
            count = 0;
            int cursor = 3;
            string[] wrd2 = text2.Split(' ');
            System.Console.Write('┌');
            for (int i = 0; i < System.Console.WindowWidth / 2 - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.WriteLine('┐');
            System.Console.SetCursorPosition(System.Console.WindowWidth / 2, ++cursor);

            for (int i = 0; i < System.Console.WindowHeight - 7; i++)
            {
                tempcount = 0;
                System.Console.Write('|');
                while (tempcount < System.Console.WindowWidth / 2 - 2)
                {
                    if (count < wrd1.Length && tempcount + wrd1[count].Length + 1 <= System.Console.WindowWidth / 2 - 2)
                    {
                        System.Console.Write(wrd1[count] + " ");
                        tempcount += wrd1[count].Length + 1;
                        count++;
                    }
                    else
                    {
                        System.Console.Write(" ");
                        tempcount++;
                    }
                }
                System.Console.WriteLine('|');
                System.Console.SetCursorPosition(System.Console.WindowWidth / 2, ++cursor);
            }

            System.Console.Write('└');
            for (int i = 0; i < System.Console.WindowWidth / 2 - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.Write('┘');
        }

        private void DisplaySingleText(string text1)
        {
            System.Console.SetCursorPosition(0, 3);
            int tempcount = 0;
            int count = 0;
            string[] wrd1 = text1.Split(' ');
            System.Console.Write('┌');
            for (int i = 0; i < System.Console.WindowWidth - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.Write('┐');

            for (int i = 0; i < System.Console.WindowHeight - 7; i++)
            {
                tempcount = 0;
                System.Console.Write('|');
                while (tempcount < System.Console.WindowWidth - 2)
                {
                    if (count < wrd1.Length && tempcount + wrd1[count].Length + 1 <= System.Console.WindowWidth - 2)
                    {
                        System.Console.Write(wrd1[count] + " ");
                        tempcount += wrd1[count].Length + 1;
                        count++;
                    }
                    else
                    {
                        System.Console.Write(" ");
                        tempcount++;
                    }
                }
                System.Console.Write('|');
            }

            System.Console.Write('└');
            for (int i = 0; i < System.Console.WindowWidth - 2; i++)
            {
                System.Console.Write('─');
            }
            System.Console.Write('┘');
        }
    }
}
