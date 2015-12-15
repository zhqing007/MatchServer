namespace MatchClient {
    partial class TeamSelect {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.teamListBox = new System.Windows.Forms.ListBox();
            this.addbutton = new System.Windows.Forms.Button();
            this.cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // teamListBox
            // 
            this.teamListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.teamListBox.FormattingEnabled = true;
            this.teamListBox.ItemHeight = 15;
            this.teamListBox.Location = new System.Drawing.Point(0, 0);
            this.teamListBox.Name = "teamListBox";
            this.teamListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.teamListBox.Size = new System.Drawing.Size(513, 529);
            this.teamListBox.TabIndex = 0;
            // 
            // addbutton
            // 
            this.addbutton.Location = new System.Drawing.Point(305, 540);
            this.addbutton.Name = "addbutton";
            this.addbutton.Size = new System.Drawing.Size(83, 30);
            this.addbutton.TabIndex = 1;
            this.addbutton.Text = "添加";
            this.addbutton.UseVisualStyleBackColor = true;
            this.addbutton.Click += new System.EventHandler(this.addbutton_Click);
            // 
            // cancle
            // 
            this.cancle.Location = new System.Drawing.Point(418, 540);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(83, 30);
            this.cancle.TabIndex = 2;
            this.cancle.Text = "取消";
            this.cancle.UseVisualStyleBackColor = true;
            this.cancle.Click += new System.EventHandler(this.cancle_Click);
            // 
            // TeamSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 582);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.addbutton);
            this.Controls.Add(this.teamListBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeamSelect";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "队伍选择";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ListBox teamListBox;
        private System.Windows.Forms.Button addbutton;
        private System.Windows.Forms.Button cancle;
    }
}