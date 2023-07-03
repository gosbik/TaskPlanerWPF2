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
using System.Windows.Shapes;
using Firebase.Database;
using Firebase.Database.Query;
using System.Reactive.Linq;
using Firebase.Auth;
using System.Collections;

namespace Poisk
{
    /// <summary>
    /// Логика взаимодействия для TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        public TaskWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.ShowDialog();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            EditWindow edit = new EditWindow();
            edit.ShowDialog();
            this.Close();
        }

        private void Button_Click_2 (object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged (object sender, SelectionChangedEventArgs e)
        {

        }

        private async void Window_Loaded (object sender, RoutedEventArgs e)
        {
            await Base();
        }
        private async Task Base ()
        {
            var firebase = new FirebaseClient("https://ttplaner-837d4-default-rtdb.firebaseio.com");
            var data = await firebase
                .Child("User")
                .OnceAsync<users>();

            var tasks = new List<userTasks>();
            int count = 0;
            foreach (var user in data)
            {
                foreach (var task in user.Object.Tasks)
                {
                    task.Value.user = user.Object;
                    tasks.Add(task.Value);
                    count++;
                }
            }
            count_label.Content = $"Показано: {count} записей";
            
            list2.ItemsSource = tasks;
           
        }
    }
}
