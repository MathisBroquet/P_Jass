using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace P_Jass
{
    class Presentation
    {
        private List<Slide> _slides;
        private int _slideNbr = 0;
        private ConsoleKey _key;
        public Presentation(List<Slide> slides)
        {
            _slides = slides;
        }

        public void Start()
        {
            _slides[_slideNbr].Display();
            do
            {
                _key = System.Console.ReadKey(true).Key;

                switch (_key)
                {
                    case ConsoleKey.Spacebar:
                        _slideNbr++;
                        if (_slides.Count - 1 >= _slideNbr)
                        {
                            ClearLinesNext();
                            _slides[_slideNbr].Display();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        _slideNbr++;
                        if (_slides.Count - 1 >= _slideNbr)
                        {
                            ClearLinesNext();
                            _slides[_slideNbr].Display();
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        _slideNbr++;
                        if (_slides.Count - 1 >= _slideNbr)
                        {
                            ClearLinesNext();
                            _slides[_slideNbr].Display();
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        _slideNbr--;
                        if (0 <= _slideNbr)
                        {
                            ClearLinesPrevious();
                            _slides[_slideNbr].Display();
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        _slideNbr--;
                        if (0 <= _slideNbr)
                        {
                            ClearLinesPrevious();
                            _slides[_slideNbr].Display();
                        }
                        break;
                    default:
                        break;
                }
            } while (_slideNbr != _slides.Count || (_key != ConsoleKey.Enter && _key != ConsoleKey.DownArrow && _key != ConsoleKey.RightArrow && _key != ConsoleKey.Spacebar));
            ClearLinesNext();
        }

        private void ClearLinesNext()
        {
            System.Console.CursorVisible = false;
            for (int i = 0; i < System.Console.WindowHeight; i++)
            {
                for (int j = 0; j < System.Console.WindowWidth; j++)
                {
                    System.Console.SetCursorPosition(j, i);
                    System.Console.WriteLine(' ');
                }
                    Thread.Sleep(10);
            }
        }

        private void ClearLinesPrevious()
        {
            System.Console.CursorVisible = false;
            for (int i = 0; i < System.Console.WindowHeight; i++)
            {
                for (int j = 0; j < System.Console.WindowWidth; j++)
                {
                    System.Console.SetCursorPosition(System.Console.WindowWidth - 1 - j, System.Console.WindowHeight - 1 - i);
                    System.Console.WriteLine(' ');
                }
                Thread.Sleep(1);
            }
        }
    }
}
