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
    public partial class SelectMatch : Form {
        public matchinfo mif;

        public SelectMatch() {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            matchinfodb[] matchs = StaticClass.serviceClient.GetMatchs();
            foreach (matchinfodb mifdb in matchs)
                matchlistBox.Items.Add(new matchinfo(mifdb));
        }

        private void open_Click(object sender, EventArgs e) {
            if (matchlistBox.SelectedItems.Count < 1) {
                MessageBox.Show("没有选择比赛！");
                return;
            }
            mif = (matchinfo)(matchlistBox.SelectedItem);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void cancle_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
