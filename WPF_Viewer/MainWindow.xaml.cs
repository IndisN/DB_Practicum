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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

//using DBPracticum;

namespace WPF_Viewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            //users = new ObservableCollection<int>();
            //users.Add(1);
            //users.Add(2);
            //users.Add(3);

            //graphIC.ItemsSource = users;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Console.WriteLine("closing");
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Console.WriteLine("sizechanged");
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == System.Windows.WindowState.Maximized)
            //{
            //    (this.Resources["mvvm"] as MVVM).Window_StateChanged();
            //}
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).AddUser_Click();
        }

        private void LoadUser_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).LoadUserXML();
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).SaveUserXML((Guid)((sender as MenuItem).DataContext));  
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).DeleteUser((Guid)((sender as MenuItem).DataContext));
        }

        private void AddRel_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.Resources["mvvm"] as MVVM).AddRel_Click();
        }

        private void Window_DataContextChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {
            this.OnContentChanged(App.Current.Resources["mvvm"] as MVVM, App.Current.Resources["mvvm"] as MVVM);
            
        }
    }
}
