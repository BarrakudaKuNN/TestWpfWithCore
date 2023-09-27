using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Moving moving;
        public MainWindow()
        {
            InitializeComponent();
            Moving.boom += Moving_boom;
        }

        private void Moving_boom(object? sender, EventArgs e)
        {
            Button_Target.Margin = new Thickness(Moving.x, Moving.y, 0, 0);
        }

        private void Button_Target_Click(object sender, RoutedEventArgs e)
        {
            Moving.Move(Button_Target);
        }
    }
}
