using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MatchClient.MatchService;

namespace MatchClient {
    public partial class MainForm : Form {
        matchinfo matchinfo;

        public MainForm() {
            InitializeComponent();
            this.orderpage.Parent = null;
        }

        private void newButton_Click(object sender, EventArgs e) {
            NewMatch newmform = new NewMatch();
            newmform.ShowDialog();

            if (newmform.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            TeamListView.Items.Clear();
            cardview.Items.Clear();
            matchinfo = newmform.mif ;

            foreach (string teamobj in newmform.teamlist) {
                ListViewItem teamitem = new ListViewItem(teamobj);
                teamitem.SubItems.Add("未分组");
                TeamListView.Items.Add(teamitem);
            }

            addCard();
        }

        private void optionButton_Click(object sender, EventArgs e) {
            OptionForm opf = new OptionForm();
            opf.ShowDialog();
        }

        private void openButton_Click(object sender, EventArgs e) {
            SelectMatch smform = new SelectMatch();
            smform.ShowDialog();
            if (smform.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;

            TeamListView.Items.Clear();
            cardview.Items.Clear();
            matchinfo = smform.mif;

            teaminfodb[] teamdbs = StaticClass.serviceClient.GetMatchTeams(matchinfo.Name);

            foreach (teaminfodb teamdb in teamdbs) {
                teaminfo tinfo = new teaminfo(teamdb);
                ListViewItem teamitem = new ListViewItem(tinfo.ToString());
                teamitem.SubItems.Add(tinfo.Group == 0 ? "未分组" : tinfo.Group.ToString());
                teamitem.Tag = tinfo;
                TeamListView.Items.Add(teamitem);
            }

            if (teamdbs[0].Group != 0) {
                this.orderpage.Parent = this.worktabControl;
                return;
            }

            addCard();
        }

        private void addCard() {
            List<int> grouplist = new List<int>();
            int tcount = TeamListView.Items.Count / matchinfo.GroupCount;//每组最少数
            int scount = TeamListView.Items.Count % matchinfo.GroupCount;//最后余数

            //为每组分配最少数
            for (int i = 0; i < matchinfo.GroupCount; ++i) {
                grouplist.Add(tcount);
            }

            //分配余数
            for (int i = 1; i <= scount; ++i) {
                ++grouplist[grouplist.Count - i];
            }

            List<ListViewItem> itemlist = new List<ListViewItem>();
            for (int g = 1; g <= grouplist.Count; ++g) {
                for (int i = 0; i < grouplist[g - 1]; ++i) {
                    ListViewItem item = new ListViewItem("未抽");
                    item.BackColor = Color.Black;
                    item.ForeColor = Color.White;
                    item.Tag = g;
                    itemlist.Add(item);
                }
            }

            Random ran = new Random(System.DateTime.Now.Second);

            while (itemlist.Count > 0) {
                int RandKey = ran.Next(0, itemlist.Count);
                cardview.Items.Add(itemlist[RandKey]);
                itemlist.RemoveAt(RandKey);
            }         
        }


        private void TeamListView_SelectedIndexChanged(object sender, EventArgs e) {
            if (TeamListView.SelectedItems.Count == 0) return;
            selectTeamBox.Text = TeamListView.SelectedItems[0].Text;
        }

        private void save_Click(object sender, EventArgs e) {
            teaminfodb[] teamarray = new teaminfodb[TeamListView.Items.Count];

            for (int i = 0; i < TeamListView.Items.Count; ++i) {
                teaminfo tinfo = (teaminfo)(TeamListView.Items[i].Tag);
                teamarray[i] = tinfo.ToDB();
                teamarray[i].Group = Int32.Parse(TeamListView.Items[i].SubItems[1].Text);
            }

            StaticClass.serviceClient.SaveMatchTeams(teamarray);
            this.save.Enabled = false;
            this.orderpage.Parent = this.worktabControl;
        }

        private void cardview_MouseUp(object sender, MouseEventArgs e) {
            if (cardview.SelectedItems.Count == 0) return;

            if (TeamListView.SelectedItems.Count == 0 ||
                    !TeamListView.SelectedItems[0].SubItems[1].Text.Equals("未分组")) {
                MessageBox.Show("请选择一个尚未抽签的队伍！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(TeamListView.SelectedItems[0].Text + "所抽分组为" + cardview.SelectedItems[0].Tag,
                "结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TeamListView.SelectedItems[0].SubItems[1].Text = cardview.SelectedItems[0].Tag.ToString();
            cardview.Items.Remove(cardview.SelectedItems[0]);

            if (cardview.Items.Count == 0) save.Enabled = true;
        }
    }
}
