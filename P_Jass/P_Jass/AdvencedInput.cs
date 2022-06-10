using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace P_Jass
{
    public static class Console
    {
        public static String ReadLocation(int left, int top, int maxLength, Regex regex, string str = "", string message = "")
        {
            //Properties
            char[] chars = new char[maxLength];
            ConsoleKeyInfo keyInfo;
            int count = str.Length;
            int deplace = str.Length;
            bool done = false;
            for (int i = 0; i < str.Length; i++)
            {
                chars[i] = str[i];
            }   //Put the actuel username
            System.Console.SetCursorPosition(left + count, top);

            //Modify the username
            while (!done)
            {
                keyInfo = System.Console.ReadKey(true);
                //Try to save the new username
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    //Check if the string is correct and save it in th DB 
                    if (regex.IsMatch(new String(chars)))
                    {
                        try
                        {
                            //TODO : Make a connection to the database and try to insert the username
                        }
                        catch (Exception e)
                        {
                            message = e.ToString();
                            break;
                        }
                        done = true;
                    }
                    //Write an error
                    else
                    {
                        Thread thread = new Thread(() => error(left, top, deplace, message));
                        thread.Start();
                    }
                }
                //Save the user input for his username
                else if (System.Console.CursorLeft < maxLength + left && System.Console.CursorLeft >= left || keyInfo.Key == ConsoleKey.Backspace || keyInfo.Key == ConsoleKey.LeftArrow)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.Backspace:
                            //If a minimum of one character is present
                            if (count > 0)
                           {
                                if (deplace != count && count < maxLength - 1 && left + deplace > left)
                                {
                                    for (int i = 0; i <= count - deplace + 1; i++)
                                    {
                                        chars[deplace + i - 1] = chars[deplace + i];
                                    }

                                    System.Console.SetCursorPosition(left, top);
                                    for (int i = 0; i < chars.Length; i++)
                                    {
                                        System.Console.Write(chars[i]);
                                    }
                                    System.Console.SetCursorPosition(left + deplace + 1, top);
                                }
                                else if(deplace == 0)
                                {
                                }
                                else
                                {
                                    System.Console.Write("\b \b");
                                }

                                if (deplace >= 1 && deplace < maxLength + 1)
                                {
                                    deplace--;
                                }
                                if (count < 20)
                                {
                                    chars[count] = '\0';
                                }

                                if (count >= 1 && count < maxLength + 1)
                                {
                                    count--;
                                }
                            }
                            break;
                        case ConsoleKey.Enter:
                            done = true;
                            break;
                        case ConsoleKey.LeftArrow:
                            if (left + deplace > left && deplace - 1 <= count)
                            {
                                deplace--;
                                System.Console.SetCursorPosition(deplace + left, top);
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (deplace < left + maxLength && deplace < count && deplace >= 0)
                            {
                                deplace++;
                                System.Console.SetCursorPosition(deplace + left, top);
                            }
                            break;
                        case ConsoleKey.Delete:
                            if (deplace < count)
                            {
                                for (int i = 1; i < count - deplace; i++)
                                {
                                    chars[deplace + i - 1] = chars[deplace + i];
                                }

                                System.Console.SetCursorPosition(left, top);
                                chars[count - 1] = '\0';
                                for (int i = 0; i < chars.Length; i++)
                                {
                                    System.Console.Write(chars[i]);
                                }
                                System.Console.SetCursorPosition(left + deplace + 1, top);
                                count--;
                            }
                            break;
                        default:
                            if (count < chars.Length && keyInfo.KeyChar <= 254 && keyInfo.KeyChar >= 32)
                            {
                                if (deplace != count && count < maxLength)
                                {
                                    for (int i = 0; i <= count - deplace; i++)
                                    {
                                        if (count - i + 1 < 20)
                                        {
                                            chars[count - i + 1] = chars[count - i];
                                        }
                                    }

                                    chars[deplace] = keyInfo.KeyChar;

                                    System.Console.SetCursorPosition(left, top);
                                    for (int i = 0; i < chars.Length; i++)
                                    {
                                        System.Console.Write(chars[i]);
                                    }
                                    System.Console.SetCursorPosition(left + deplace + 1, top);
                                }
                                else
                                {
                                    chars[count] = keyInfo.KeyChar;
                                    System.Console.Write(keyInfo.KeyChar);
                                }
                                deplace++;
                                count++;
                            }
                            break;
                    }

                    if (regex.IsMatch(new String(chars)))
                    {
                        System.Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.SetCursorPosition(left - 1, top - 1);
                        System.Console.Write('╔');
                        System.Console.SetCursorPosition(left + maxLength, top - 1);
                        System.Console.Write('╗');
                        System.Console.SetCursorPosition(left - 1, top + 1);
                        System.Console.Write('╚');
                        System.Console.SetCursorPosition(left + maxLength, top + 1);
                        System.Console.Write('╝');
                        System.Console.ForegroundColor = ConsoleColor.Gray;
                        System.Console.SetCursorPosition(left, top + 2);
                        for (int i = 0; i < message.Length; i++)
                        {
                            System.Console.Write(' ');
                        }
                        System.Console.SetCursorPosition(left + deplace, top);

                    }
                    else if (!regex.IsMatch(new String(chars)))
                    {
                        System.Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.SetCursorPosition(left - 1, top - 1);
                        System.Console.Write('╔');
                        System.Console.SetCursorPosition(left + maxLength, top - 1);
                        System.Console.Write('╗');
                        System.Console.SetCursorPosition(left - 1, top + 1);
                        System.Console.Write('╚');
                        System.Console.SetCursorPosition(left + maxLength, top + 1);
                        System.Console.Write('╝');
                        System.Console.ForegroundColor = ConsoleColor.Gray;

                        System.Console.SetCursorPosition(left + deplace, top);
                    }
                }
            }
            return new String(chars);
        }

        private static void error(int left, int top, int deplace, string message)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.SetCursorPosition(left, top + 2);
            System.Console.Write(message);
            System.Console.ForegroundColor = ConsoleColor.Gray;

            System.Console.SetCursorPosition(left + deplace, top);
            Thread.Sleep(10000);
            for (int i = 0; i < message.Length; i++)
            {
                System.Console.SetCursorPosition(left + i, top + 2);
                System.Console.Write(' ');
            }
        }
    }
}
