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
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;


namespace Poisk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        private FirebaseAuthClient client;
        public MainWindow ()
        {
            InitializeComponent();
        }

        private async void Button_Click (object sender, RoutedEventArgs e)
        {
            try
            {

                UserCredential userCredential = await client.SignInWithEmailAndPasswordAsync(TextBoxEmail.Text, Passw.Password);

                TaskWindow windowTask = new TaskWindow();
                windowTask.Show();
                this.Close();
            } catch (Exception)
            {
                MessageBox.Show("Вход не выполнен", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Load (object sender, RoutedEventArgs e)
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyByHDIDGVBr4uoWpI8cEJhTcAIerJzLBV0",
                AuthDomain = "ttplaner-837d4.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                    {
                        new EmailProvider()
                    }

            };
            client = new FirebaseAuthClient(config);
        }

        private void TextBoxPassword_PasswordChanged (object sender, RoutedEventArgs e)
        {

        }
    }
}
