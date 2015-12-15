using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using MatchServerLib;

namespace MatchHost {
    public partial class Form1 : Form {
        ServiceHost host;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            MatchService server = new MatchService();
            host = new ServiceHost(server);
            host.Open();
        }

        private void close_Click(object sender, EventArgs e) {
            MatchService ts = (MatchService)(host.SingletonInstance);
            host.Close();
            this.Close();
        }
    }
}
