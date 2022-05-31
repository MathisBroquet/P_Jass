using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P_Jass
{
    class Username
    {
        private string _user;

        public Username(string user)
        {
            _user = user;
        }

        public void Display()
        {
            Console.Clear();
            string username = @"_|    _|    _|_|_|  _|_|_|_|  _|_|_|    _|      _|    _|_|    _|      _|  _|_|_|_|  
_|    _|  _|        _|        _|    _|  _|_|    _|  _|    _|  _|_|  _|_|  _|        
_|    _|    _|_|    _|_|_|    _|_|_|    _|  _|  _|  _|_|_|_|  _|  _|  _|  _|_|_|    
_|    _|        _|  _|        _|    _|  _|    _|_|  _|    _|  _|      _|  _|        
  _|_|    _|_|_|    _|_|_|_|  _|    _|  _|      _|  _|    _|  _|      _|  _|_|_|_|";
            Console.WriteLine(username);
            do
            {
                for (int i = 0; i < username.Length/5; i++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        Console.SetCursorPosition(i, x);
                        if ("" == "_")
                        {
                            Console.SetCursorPosition(i, x);
                            Console.WriteLine('█');
                        }
                        Thread.Sleep(50);
                    }
                }

                for (int i = 0; i < username.Length / 5; i++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        Console.SetCursorPosition(i, x);
                        if (Console.Read().ToString() == "█")
                        {
                            Console.SetCursorPosition(i, x);
                            Console.WriteLine('_');
                        }
                    }
                }
            } while (true);
        }
    }
}
