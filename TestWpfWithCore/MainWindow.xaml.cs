using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestWpfWithCore.Logic;

namespace TestWpfWithCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thread moveThread;
        Moving moving;
        public MainWindow()
        {
            InitializeComponent();
            moving = new Moving(Dispatcher);
        }

        private void Button_Target_Click(object sender, RoutedEventArgs e)
        {

            //moveThread = new Thread(new ThreadStart(MoveButton));
            //moveThread.Start();
            moving.Move(Button_slow_guy);

        }
        private void MoveButton()
        {
            for (int i = 0; i < 100; i++)
            {
                Dispatcher.Invoke(() =>
                {
                    Button_Target.Margin = new Thickness(i, i, 0, 0);
                });
                Thread.Sleep(50);
            }
        }

        private void Button_slow_guy_Click(object sender, RoutedEventArgs e)
        {
            moving.Move(Button_slow_guy);
        }
    }
}
