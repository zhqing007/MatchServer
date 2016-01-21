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
    /// SelectMatch.xaml 的交互逻辑
    /// </summary>
    public partial class SelectMatch : Window {
        public matchinfo mif;

        public SelectMatch() {
            InitializeComponent();
            this.DialogResult = false;
            matchinfodb[] matchs = StaticClass.serviceClient.GetMatchs();
            foreach (matchinfodb mifdb in matchs)
                matchlistBox.Items.Add(new matchinfo(mifdb));
        }

        private void open_Click(object sender, RoutedEventArgs e) {
            if (matchlistBox.SelectedItems.Count < 1) {
                MessageBox.Show("没有选择比赛！");
                return;
            }
            mif = (matchinfo)(matchlistBox.SelectedItem);
            this.DialogResult = true;
            Close();
        }

        private void cancle_Click(object sender, RoutedEventArgs e) {
            Close();
        }
    }
}
