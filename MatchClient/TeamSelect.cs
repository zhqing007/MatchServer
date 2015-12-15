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
    public partial class TeamSelect : Form {
        public TeamSelect() {
            InitializeComponent();
            teaminfodb[] teamsdb = StaticClass.serviceClient.GetTeams();
            foreach (teaminfodb teamdb in teamsdb) {
                this.teamListBox.Items.Add(new teaminfo(teamdb));
            }
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void addbutton_Click(object sender, EventArgs e) {
            if (teamListBox.SelectedItems.Count == 0) {
                MessageBox.Show("请选择要添加的队！");
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancle_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
