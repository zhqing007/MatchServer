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

namespace WpfMatchClient2 {
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window {
        public LoginWindow() {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e) {
            StaticClass.teamname = StaticClass.serviceClient.UserLogin(nameBox.Text, pwBox.Text);
            if (StaticClass.teamname == null) {
                MessageBox.Show("登录名或密码错误！");
                return;
            }
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
