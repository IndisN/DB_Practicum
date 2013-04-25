using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Viewer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window_AddUser : Window
    {
        public Window_AddUser()
        {
            InitializeComponent();
        }

        private void Load_Clicked(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).LoadImage();
        }

        private void LoctFocus_Hndl(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).IfAllFilled();
        }

        private void Button_Click_Accept(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).AddUserToDB();
            //(this.Parent as MainWindow).relationsColl.ItemsSource = (App.Current.Resources["mvvm"] as MVVM).RelationsColl;
            //(this.Parent as MainWindow).usersColl.ItemsSource = (App.Current.Resources["mvvm"] as MVVM).UsersColl;
        }
    }
}
