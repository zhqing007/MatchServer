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
    /// NewPerson.xaml 的交互逻辑
    /// </summary>
    public partial class NewPerson : Window {
        PersonData perdata;
        public NewPerson() {
            InitializeComponent();
            perdata = new PersonData();
        }

        public PersonData GetPerson() {
            return perdata;
        }

        private void okbutton_Click(object sender, RoutedEventArgs e) {
            if (nameBox.Text.Trim().Length == 0 ||
                numBox.Text.Trim().Length == 0) {
                MessageBox.Show("必填信息为空，请填写！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }

            perdata.Num = numBox.Text.Trim();
            perdata.Name = nameBox.Text.Trim();
            perdata.Sex = sexcombo.Text;
            
            //int saveinfo = StaticClass.serviceClient.AddPerson(perdata);
            //if (saveinfo == 2) {
            //    MessageBox.Show("人员已存在，请修改！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
            //    return;
            //}
            //else
            //    MessageBox.Show("添加成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true;
            this.Close();
        }

        private void canclebutton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
