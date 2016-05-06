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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Threading;

namespace WpfMatchClient2 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public delegate void renew();

    public partial class MainWindow : Window {
        private int id = 10;
        ObservableCollection<string> teamitemList = new ObservableCollection<string>();
        public MainWindow() {
            InitializeComponent();
            read_thread readth = new read_thread(this, new renew(this.renewDrawlist));
            Thread tbthread = new Thread(new ThreadStart(readth.readservice));
            tbthread.Start();
        }

        private void draw_Click(object sender, RoutedEventArgs e) {
            StaticClass.serviceClient.SetDrawResult("10", 2);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            drawlist.ItemsSource = teamitemList;
        }

        public void renewDrawlist() {
            teamitemList.Clear();
            foreach (string str in StaticClass.staticList)
                teamitemList.Add(str);
        }

        private void Window_Closed(object sender, EventArgs e) {
            StaticClass.isclosed = true;
        }
    }

    public class read_thread {        
        public renew listrenew;
        private MainWindow mw;

        public read_thread(MainWindow mw_, renew re) {
            listrenew = re;
            mw = mw_;
        }

        public void readservice() {
            bool logflag = false;
            while (!(StaticClass.isclosed)) {
                if (!logflag)
                    logflag = StaticClass.serviceClient.LoginIn(StaticClass.teamname);

                Dictionary<string, int> drawDic = StaticClass.serviceClient.GetDrawResult();
                StaticClass.staticList.Clear();
                foreach (string key in drawDic.Keys) {
                    StaticClass.staticList.Add(key + "   " + drawDic[key]);
                }
                mw.Dispatcher.Invoke(listrenew);
                Thread.Sleep(2000);
            }
        }
    }
}
