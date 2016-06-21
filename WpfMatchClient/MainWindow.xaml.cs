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
using WpfMatchClient.MatchService;
using System.Threading;

namespace WpfMatchClient {
    public delegate void renew(TeamStatus sersta); 
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public uint ver;
        public string matchname;
        matchinfo _matchinfo;
        Thread tbthread;

        ObservableCollection<TeamItem> teamitemList = new ObservableCollection<TeamItem>();
        internal ObservableCollection<TeamItem> TeamItemList {
            get { return teamitemList; }
            set { teamitemList = value; }
        }

        public MainWindow() {
            InitializeComponent();
            tbthread = null;
        }

        private void SetThread() {
            if (tbthread != null) {
                StaticClass.isclosed = true;
                while (!tbthread.ThreadState.Equals(ThreadState.Stopped))
                    Thread.Sleep(1000);
            }
            read_thread readth = new read_thread(this, new renew(this.RenewTeamlist));
            tbthread = new Thread(new ThreadStart(readth.readservice));
            tbthread.Start();
        }

        public void RenewTeamlist(TeamStatus sersta) {
        }

        private void addCard() {
            List<int> grouplist = new List<int>();
            int tcount = TeamListView.Items.Count / _matchinfo.GroupCount;//每组最少数
            int scount = TeamListView.Items.Count % _matchinfo.GroupCount;//最后余数

            //为每组分配最少数
            for (int i = 0; i < _matchinfo.GroupCount; ++i) {
                grouplist.Add(tcount);
            }

            //分配余数
            for (int i = 1; i <= scount; ++i) {
                ++grouplist[grouplist.Count - i];
            }

            List<ListViewItem> itemlist = new List<ListViewItem>();
            for (int g = 1; g <= grouplist.Count; ++g) {
                for (int i = 0; i < grouplist[g - 1]; ++i) {
                    //ListViewItem item = new ListViewItem("未抽");
                    //item.BackColor = Color.Black;
                    //item.ForeColor = Color.White;
                    //item.Tag = g;
                    //itemlist.Add(item);
                }
            }

            Random ran = new Random(System.DateTime.Now.Second);

            while (itemlist.Count > 0) {
                int RandKey = ran.Next(0, itemlist.Count);
                //cardview.Items.Add(itemlist[RandKey]);
                itemlist.RemoveAt(RandKey);
            }
        }

        private void newButton_Click(object sender, RoutedEventArgs e) {
            NewMatch newmform = new NewMatch();
            newmform.ShowDialog();

            if (newmform.DialogResult != true)
                return;

            //TeamListView.Items.Clear();
            teamitemList.Clear();
            //cardview.Items.Clear();
            _matchinfo = newmform.mif;
            Dictionary<string, int> drawdic = new Dictionary<string, int>();
            foreach (string teamobj in newmform.teamlist) {
                drawdic.Add(teamobj, 0);
                teamitemList.Add(new TeamItem(teamobj, "未分组"));
            }
            StaticClass.serviceClient.InitDic(drawdic);
            ver = 0;
            //ListViewItem teamitem = new ListViewItem();
            //teamitem.Content = teamobj;
            //teamitem.
            //teamitem.SubItems.Add("未分组");

            addCard();
        }

        private void openButton_Click(object sender, RoutedEventArgs e) {
            SelectMatch smform = new SelectMatch();
            smform.ShowDialog();
            if (smform.DialogResult != true)
                return;

            teamitemList.Clear();
            //cardview.Items.Clear();
            _matchinfo = smform.mif;

            teaminfodb[] teamdbs = StaticClass.serviceClient.GetMatchTeams(_matchinfo.Name);
            Dictionary<string, int> drawdic = new Dictionary<string, int>();
            foreach (teaminfodb teamdb in teamdbs) {
                teaminfo tinfo = new teaminfo(teamdb);
                drawdic.Add(tinfo.ToString(), tinfo.Group);
                teamitemList.Add(new TeamItem(tinfo.ToString(),
                    tinfo.Group == 0 ? "未分组" : tinfo.Group.ToString(), tinfo));
            }
            StaticClass.serviceClient.InitDic(drawdic);
            ver = 0;
            //if (teamdbs[0].Group != 0) {
            //    this.orderpage.Parent = this.worktabControl;
            //    return;
            //}

            addCard();
        }

        private void optionButton_Click(object sender, RoutedEventArgs e) {
            OptionForm opf = new OptionForm();
            opf.ShowDialog();
        }

        private void save_Click(object sender, RoutedEventArgs e) {
            NewMatch a = new NewMatch();
            a.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            TeamListView.ItemsSource = teamitemList;
        }

        private void manual_b_Click(object sender, RoutedEventArgs e) {
            if (teamitemList.Count == 0) return;
            ObservableCollection<String> teamname = new ObservableCollection<String>();

            foreach (TeamItem item in teamitemList) {
                teamname.Add(item.Name);
            }
            ManualGroup mg = new ManualGroup(teamname, _matchinfo);
            mg.ShowDialog();

            if (mg.DialogResult == false) return;
             
            for (int i = 1; i <= _matchinfo.GroupCount; ++i) {
                List<String> nameList = mg.GetTeamName(i);

                foreach (String name in nameList)
                    for (int j = 0; j < teamitemList.Count; ++j) {
                        TeamItem item = teamitemList[j];
                        if (item.Name.Equals(name)) {                            
                            item.Status = i.ToString();
                            teamitemList.Remove(item);
                            teamitemList.Insert(j, item);
                            break;
                        }
                    }
            }
        }

    }

    public class TeamItem {
        private string _name;
        private string _status;
        private object _tag;

        public string Status {
            get { return _status; }
            set { _status = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public object Tag {
            get { return _tag; }
            set { _tag = value; }
        }

        public TeamItem(string name, string status, object tag = null) {
            _name = name;
            _status = status;
            _tag = tag;
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
            while (!(StaticClass.isclosed)) {
                Thread.Sleep(2000);
                TeamStatus serSta = StaticClass.serviceClient.GetServerStatus();
                if (serSta.Ver == mw.ver) continue;
                mw.Dispatcher.Invoke(listrenew);
            }
        }
    }
}
