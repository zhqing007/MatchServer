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
    /// NewMatch.xaml 的交互逻辑
    /// </summary>
    public partial class NewMatch : Window {
        public matchinfo mif;
        public List<string> teamlist;

        public NewMatch() {
            InitializeComponent();
            this.DialogResult = false;    
        }

        private void bAdd_Click(object sender, RoutedEventArgs e) {
            TeamSelect ts = new TeamSelect();
            ts.ShowDialog();
            if (ts.DialogResult == true) {
                foreach (object team in ts.teamlistBox.SelectedItems) {
                    bool inlist = false;
                    foreach (object teamobj in teamlistBox.Items) {
                        if (team.ToString().Equals(teamobj.ToString())) {
                            inlist = true;
                            break;
                        }
                    }
                    if (inlist) continue;
                    teamlistBox.Items.Add(team);
                }
            }

        }

        private void bOK_Click(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("确认保存赛事基本信息？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.No)
                return;

            matchinfodb mifdb = new matchinfodb();
            mifdb.Name = matchname.Text.Trim();
            mifdb.GroupCount = (int)(this.countslider.Value);

            int saveinfo = StaticClass.serviceClient.AddMatch(mifdb);
            if (saveinfo == 2)
                MessageBox.Show("赛事名已存在，请修改！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
            else {
                mif = new matchinfo(mifdb);
                teamlist = new List<string>();

                foreach (object teamobj in teamlistBox.Items) {
                    teamlist.Add(teamobj.ToString());
                    StaticClass.serviceClient.AddMatchTeam(mif.Name, teamobj.ToString());
                }
                MessageBox.Show("添加成功！", "成功", MessageBoxButton.OK, MessageBoxImage.Information);
                this.DialogResult = true;
                this.Close();
            }
        }

        private void bRemove_Click(object sender, RoutedEventArgs e) {
            if (teamlistBox.SelectedItems.Count < 0) return;

            if (MessageBox.Show("确认移除所选项？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.No)
                return;

            foreach (object teamobj in teamlistBox.SelectedItems) {
                teamlistBox.Items.Remove(teamobj);
            }
        }

        private void bCancle_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
