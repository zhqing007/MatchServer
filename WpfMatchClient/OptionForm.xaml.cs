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
    /// OptionForm.xaml 的交互逻辑
    /// </summary>
    public partial class OptionForm : Window {
        public OptionForm() {
            InitializeComponent();
            teaminfodb[] teamsdb = StaticClass.serviceClient.GetTeams();
            foreach (teaminfodb teamdb in teamsdb) {
                this.teamlistBox.Items.Add(new teaminfo(teamdb));
            }
        }

        private void bAdd_Click(object sender, RoutedEventArgs e) {
            TeamForm tf = new TeamForm();
            tf.ShowDialog();
            if (tf.DialogResult == true) {
                this.teamlistBox.Items.Add(new teaminfo(tf.tif));
            }
        }

        private void bDelete_Click(object sender, RoutedEventArgs e) {
            if (teamlistBox.SelectedIndex < 0) return;

            if (MessageBox.Show("确认删除所选项？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.No)
                return;

            StaticClass.serviceClient.DelTeam(((teaminfo)(teamlistBox.SelectedItem)).Name);
            teamlistBox.Items.Remove(teamlistBox.SelectedItem);
        }

        private void bClose_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
