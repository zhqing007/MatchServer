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
        List<TeamData> tdlist;

        public NewMatch() {
            InitializeComponent();
            tdlist = new List<TeamData>();
        }

        private void bAdd_Click(object sender, RoutedEventArgs e) {
            matchname.Text = matchname.Text.Trim();
            if (matchname.Text.Length == 0) {
                MessageBox.Show("赛事名未填写！", "错误", MessageBoxButton.OK, MessageBoxImage.Stop);
                return;
            }
            matchname.IsReadOnly = true;

            TeamSelect ts = new TeamSelect();
            ts.ShowDialog();
            if (ts.DialogResult != true) return;

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
                TeamData td = new TeamData();
                td.TeamName = team.ToString();
                tdlist.Add(td);
            }
        }

        private void bOK_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void bRemove_Click(object sender, RoutedEventArgs e) {
            if (teamlistBox.SelectedItems.Count <= 0) return;

            if (MessageBox.Show("确认移除所选项？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.No)
                return;

            StaticClass.serviceClient.RemovePerson(matchname.Text, teamlistBox.SelectedItem.ToString(), null);
            teamlistBox.Items.Remove(teamlistBox.SelectedValue);
            personlistBox.Items.Clear();
        }        

        private void teamlistBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (teamlistBox.SelectedItem == null) {
                persongroupBox.Visibility = System.Windows.Visibility.Hidden;
                return;
            }
            persongroupBox.Visibility = System.Windows.Visibility.Visible;
            personlistBox.Items.Clear();
            Dictionary<string, PersonData> perd = tdlist[teamlistBox.SelectedIndex].DrawInfo;
            foreach (string pernum in perd.Keys)
                personlistBox.Items.Add(perd[pernum].Name);
        }

        private void addp_b_Click(object sender, RoutedEventArgs e) {
            NewPerson npdia = new NewPerson();
            npdia.ShowDialog();
            if (npdia.DialogResult != true) return;

            PersonData pd = npdia.GetPerson();
            StaticClass.serviceClient.AddPerson(matchname.Text, teamlistBox.SelectedItem.ToString(), pd);
            ListBoxItem item = new ListBoxItem();
            item.Content = pd.Name;
            item.Tag = pd;
            personlistBox.Items.Add(item);
            tdlist[teamlistBox.SelectedIndex].DrawInfo.Add(pd.Num, pd);
        }

        private void remp_b_Click(object sender, RoutedEventArgs e) {
            if (personlistBox.SelectedItems.Count <= 0) return;

            if (MessageBox.Show("确认移除所选项？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question)
                    == MessageBoxResult.No)
                return;

            StaticClass.serviceClient.RemovePerson(matchname.Text, teamlistBox.SelectedItem.ToString(),
                (PersonData)((personlistBox.SelectedItem as ListBoxItem).Tag));
            personlistBox.Items.Remove(personlistBox.SelectedValue);
        }
    }
}
