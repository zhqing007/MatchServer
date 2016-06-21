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
using WpfMatchClient.MatchService;

namespace WpfMatchClient {
    /// <summary>
    /// TeamForm.xaml 的交互逻辑
    /// </summary>
    public partial class PersonForm : Window {
        public teaminfo tif;

        public PersonForm() {
            InitializeComponent();            
        }

        private void bOK_Click(object sender, RoutedEventArgs e) {
            if (nameBox.Text.Trim().Length == 0 ||
                loginameBox.Text.Trim().Length == 0 ||
                passwordBox.Text.Trim().Length == 0) {

                MessageBox.Show("必填信息为空，请填写！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            this.tif.Name = this.nameBox.Text;
            this.tif.Description = this.descriptionBox.Text;
            this.tif.Loginname = this.loginameBox.Text;
            this.tif.Password = this.passwordBox.Text;

            if (this.Title.Equals("修改队伍")) {
                StaticClass.serviceClient.UpDateTeam(tif.ToDB());
            }
            else {
                int saveinfo = StaticClass.serviceClient.AddTeam(tif.ToDB());
                if (saveinfo == 2) {
                    MessageBox.Show("队名已存在，请修改！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                if (saveinfo == 4) {
                    MessageBox.Show("登录名已存在，请修改！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
                    return;
                }
                else
                    MessageBox.Show("添加成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            this.DialogResult = true;
            this.Close();
        }

        private void bCancle_Click(object sender, RoutedEventArgs e) {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if (this.Title.Equals("修改队伍")) {
                this.nameBox.Text = this.tif.Name;
                this.descriptionBox.Text = this.tif.Description;
                this.loginameBox.Text = this.tif.Loginname;
                this.passwordBox.Text = this.tif.Password;
                this.nameBox.IsReadOnly = true;
                this.loginameBox.IsReadOnly = true;
            }
        }
    }
}
