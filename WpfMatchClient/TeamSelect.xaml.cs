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
    /// TeamSelect.xaml 的交互逻辑
    /// </summary>
    public partial class TeamSelect : Window {
        public TeamSelect() {
            InitializeComponent();
            teaminfodb[] teamsdb = StaticClass.serviceClient.GetTeams();
            foreach (teaminfodb teamdb in teamsdb) {
                this.teamlistBox.Items.Add(new teaminfo(teamdb));
            }
            this.DialogResult = false;
        }

        private void bAdd_Click(object sender, RoutedEventArgs e) {
            if (teamlistBox.SelectedItems.Count == 0) {
                MessageBox.Show("请选择要添加的队！");
                return;
            }
            this.DialogResult = true;
            this.Close();
        }

        private void bCancle_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
