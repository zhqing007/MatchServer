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
    public partial class OptionForm : Form {
        public OptionForm() {
            InitializeComponent();
            teaminfodb[] teamsdb = StaticClass.serviceClient.GetTeams();
            foreach (teaminfodb teamdb in teamsdb) {
                this.teamListBox.Items.Add(new teaminfo(teamdb));
            }
        }

        private void addteam_Click(object sender, EventArgs e) {
            TeamForm tf = new TeamForm();
            tf.ShowDialog();
            if (tf.DialogResult == System.Windows.Forms.DialogResult.OK) {
                this.teamListBox.Items.Add(new teaminfo(tf.tif));
            }
        }

        private void delteam_Click(object sender, EventArgs e) {
            if (teamListBox.SelectedIndex < 0) return;

            if(MessageBox.Show("确认删除所选项？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == System.Windows.Forms.DialogResult.No)
                return;

            StaticClass.serviceClient.DelTeam(((teaminfo)(teamListBox.SelectedItem)).Name);
            teamListBox.Items.Remove(teamListBox.SelectedItem);
        }

        private void close_Click(object sender, EventArgs e) {
            this.Close();
        }
    }   
}
