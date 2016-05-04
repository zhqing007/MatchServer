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
    public partial class TeamForm : Window {
        public teaminfodb tif;

        public TeamForm() {
            InitializeComponent();
        }

        private void bOK_Click(object sender, RoutedEventArgs e) {
            this.tif.Name = this.nameBox.Text;
            this.tif.Description = this.descriptionBox.Text;

            int saveinfo = StaticClass.serviceClient.AddTeam(tif);
            if (saveinfo == 2)
                MessageBox.Show("队名已存在，请修改！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
            else {
                MessageBox.Show("添加成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
        }

        private void bCancle_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
