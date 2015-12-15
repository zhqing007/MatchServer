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
    public partial class TeamForm : Form {
        public teaminfodb tif;

        public TeamForm() {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void add_Click(object sender, EventArgs e) {
            this.tif.Name = this.nameBox.Text;
            this.tif.Description = this.descriptionBox.Text;

            int saveinfo = StaticClass.serviceClient.AddTeam(tif);
            if (saveinfo == 2)
                MessageBox.Show("队名已存在，请修改！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else {
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
