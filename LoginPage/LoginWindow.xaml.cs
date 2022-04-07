using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
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

namespace LoginPage
{
    /// <summary>
    //Made by Aviraj
    //wanted to test my skills doing a log in page.
    /// </summary>//
    public partial class MainWindow : Window
    {
        network Network = new network();
  
        public MainWindow()
        {
            InitializeComponent();
            setNews();
        }

        private async void setNews()
        {
            TextRange newsBox = new TextRange(NewsBox.Document.ContentEnd, NewsBox.Document.ContentEnd);
            string respone = await Network.postRespone("https://horizon.bond/Forms/News.php");
            newsBox.Text = respone;
        }
    

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

     

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernamebox.Text, password = passwordBox.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {


                bool Auth = await Network.postResponeAuth(username, password);

                if(Auth)
                {
                    MessageBox.Show("Logged in!");
                }
                else
                    MessageBox.Show("username or password input not right.");

            }
            else
                MessageBox.Show("Username or password box not filled.");
        }

        private void NewsBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
