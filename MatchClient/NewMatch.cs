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
    public partial class NewMatch : Form {
        public matchinfo mif;
        public List<string> teamlist;

        public NewMatch() {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;            
            
        }

        private void button1_Click(object sender, EventArgs e) {
        }

        private void addteam_Click(object sender, EventArgs e) {
            TeamSelect ts = new TeamSelect();
            ts.ShowDialog();
            if (ts.DialogResult == System.Windows.Forms.DialogResult.OK) {
                foreach (object team in ts.teamListBox.SelectedItems) {
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

        private void removeteam_Click(object sender, EventArgs e) {
            if (teamlistBox.SelectedItems.Count < 0) return;

            if (MessageBox.Show("确认移除所选项？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.No)
                return;

            foreach (object teamobj in teamlistBox.SelectedItems) {
                teamlistBox.Items.Remove(teamobj);
            }
        }

        private void save_Click(object sender, EventArgs e) {
            if (MessageBox.Show("确认保存赛事基本信息？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.No)
                return;

            matchinfodb mifdb = new matchinfodb();
            mifdb.Name = matchname.Text.Trim();
            mifdb.GroupCount = (int)(this.groupcount.Value);

            int saveinfo = StaticClass.serviceClient.AddMatch(mifdb);
            if (saveinfo == 2)
                MessageBox.Show("赛事名已存在，请修改！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else {
                mif = new matchinfo(mifdb);
                teamlist = new List<string>();

                foreach (object teamobj in teamlistBox.Items) {
                    teamlist.Add(teamobj.ToString());
                    StaticClass.serviceClient.AddMatchTeam(mif.Name, teamobj.ToString());
                }
                MessageBox.Show("添加成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void cancle_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
