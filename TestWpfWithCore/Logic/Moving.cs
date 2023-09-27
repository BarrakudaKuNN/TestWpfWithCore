using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestWpfWithCore.Logic
{
    internal class Moving
    {
        public static event Action boom;
        public static int y=10;
        public static int x=10;
        //"658,361,0,0" 10,10,0,0"
        public static async void Move(Button button)
        {
            Task.Run(async () => await Direction());
            Task.Run(async () => await Refresh());

        }

        public static async Task Direction()
        {
            for (int i = 0; i < 10; i++)
            {
                y+=10;
                x+=10;
                boom.Invoke();
                await Task.Delay(100);
            }
        }
        public static async Task Refresh()
        {
            boom.Invoke();
        }
        

    }
}
