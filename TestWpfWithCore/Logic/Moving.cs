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

        static int y=10;
        static int x=10;
        //"658,361,0,0" 10,10,0,0"
        public static async void Move(Button button)
        {
            Task.Run(async () => await Direction());
            Task.Run(async () => await Refresh(button));

            button.Margin = new Thickness(y, x, 0, 0);
               
            
        }

        public static async Task Direction()
        {
            for (int i = 0; i < 200; i++)
            {
                y++;
                x++;
                await Task.Delay(100);
            }
        }
        public static async Task Refresh(Button button)
        {
            for (int i = 0; i < 200; i++)
            {
                button.Margin = new Thickness(y, x, 0, 0);
                await Task.Delay(100);
            }
        }

    }
}
