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
using System.Collections.ObjectModel;

namespace WpfMatchClient {
    /// <summary>
    /// ManualGroup.xaml 的交互逻辑
    /// </summary>
    public partial class ManualGroup : Window {
        private ObservableCollection<String> teamCollection;
        private matchinfo mInfo;
        private ListBox dropSource = null;
        private List<ListBox> lBox_list = new List<ListBox>();
        public ManualGroup(ObservableCollection<String> _teams, matchinfo _matchinfo) {
            InitializeComponent();
            teamCollection = _teams;
            mInfo = _matchinfo;
        }

        public List<String> GetTeamName(int groupnum) {
            if (groupnum < 1 || groupnum > mInfo.GroupCount)
                return null;
            ObservableCollection<string> teamname =
                (ObservableCollection<String>)(lBox_list[groupnum - 1].ItemsSource);

            return teamname.ToList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            this.teamlistbox.ItemsSource = teamCollection;

            for (int i = 0; i < mInfo.GroupCount; ++i) {
                lBox_list.Add(new ListBox());
                lBox_list[i].Height = teamlistbox.Height / 2 - 10;
                lBox_list[i].Width = 120;
                lBox_list[i].HorizontalAlignment = HorizontalAlignment.Left;
                lBox_list[i].VerticalAlignment = VerticalAlignment.Top;                
                lBox_list[i].AllowDrop = true;
                lBox_list[i].ItemsSource = new ObservableCollection<string>();
                lBox_list[i].Drop += listTeam_Drop;
                lBox_list[i].PreviewMouseMove += listTeam_PreviewMouseMove;

                if (i == 0)
                    lBox_list[i].Margin = new Thickness(teamlistbox.Width + 20
                        , teamlistbox.Margin.Top, 0, 0);
                else
                    lBox_list[i].Margin = new Thickness(
                        (i % 4) != 0 ? lBox_list[i - 1].Margin.Left + lBox_list[i].Width + 20 : teamlistbox.Width + 20
                        , (i % 4) != 0 ? lBox_list[i - 1].Margin.Top : lBox_list[i - 1].Margin.Top + lBox_list[i].Height + 20
                        , 0, 0);
                Label teamlable = new Label();
                teamlable.Content = "第" + (i + 1) + "组:";
                teamlable.Margin = new Thickness(lBox_list[i].Margin.Left
                    , lBox_list[i].Margin.Top - 20, 0, 0);

                manualgrid.Children.Add(teamlable);
                manualgrid.Children.Add(lBox_list[i]);
            }
        }

        private void listTeam_Drop(object sender, DragEventArgs e) {
            if (sender == dropSource) return;

            //仅支持文本的拖放
            if (!e.Data.GetDataPresent(DataFormats.StringFormat)) return;

            //获取拖拽的文件
            string[] teams = (string[])e.Data.GetData(DataFormats.StringFormat);
            ListBox listB = (ListBox)sender;
            ObservableCollection<String> listS = (ObservableCollection<String>)(listB.ItemsSource);
            listS.Add(teams[0]);

            listS = (ObservableCollection<String>)(dropSource.ItemsSource);
            listS.Remove(teams[0]);
        }

        private void listTeam_PreviewMouseMove(object sender, MouseEventArgs e) {
            if (Mouse.LeftButton != MouseButtonState.Pressed) return;

            ListBox listB = dropSource = (ListBox)sender;
            if (listB.SelectedIndex > -1) {
                //只使用了Listbox单选功能
                string[] teams = new string[1];
                teams[0] = listB.SelectedItem.ToString();

                DragDrop.DoDragDrop(listB
                    , new DataObject(DataFormats.StringFormat, teams), DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void snake_b_Click(object sender, RoutedEventArgs e) {

        }

        private void ok_b_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = true;
            this.Close();
        }

        private void cancle_b_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("afaf");
        }
    }
}
