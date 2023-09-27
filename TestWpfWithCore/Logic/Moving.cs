using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestWpfWithCore.Logic
{
    internal class Moving
    {
        Button toMove;

        int y=10;
        int x=10;


        public Moving(Button button) 
        {
            this.toMove = button;
        }
        //"658,361,0,0" 10,10,0,0"
        public async void Move()
        {
            await Direction();
            toMove.Margin = new Thickness(y, x, 0, 0);
        }

        public async Task Direction()
        {
            for (int i = 0; i < 200; i++)
            {
                y++;
                x++;
                await Task.Delay(100);
            }
        }

    }
}
