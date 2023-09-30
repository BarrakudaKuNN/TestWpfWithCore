using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TestWpfWithCore.Logic
{
    internal class Moving
    {
        
        Button button1;
        Dispatcher dispatcher;
        public static int y = 10;
        public static int x = 10;

        public Moving(Button button,Dispatcher dispatcher)
        { 
            this.button1 = button;
            this.dispatcher = dispatcher;
        }

        Thread second_Button_Move;

        public void Move()
        {
            second_Button_Move = new Thread(new ThreadStart(Move_Logic));
            second_Button_Move.Start();
        }

        void Move_Logic()
        {
            int j = 0;
            for (int i = 0; i < 100; i++,j++)
            {
                dispatcher.Invoke(() =>
                {
                    button1.Margin = new Thickness(x, y, 0, 0);
                });
                x += 4;
                y += 6;
                Thread.Sleep(50);
            }
        }
    }
}
