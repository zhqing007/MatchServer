namespace MatchClient {
    partial class NewMatch {
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
            this.removeteam = new System.Windows.Forms.Button();
            this.addteam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.matchname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.save = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupcount = new System.Windows.Forms.NumericUpDown();
            this.teamlistBox = new System.Windows.Forms.ListBox();
            this.cancle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupcount)).BeginInit();
            this.SuspendLayout();
            // 
            // removeteam
            // 
            this.removeteam.Location = new System.Drawing.Point(129, 516);
            this.removeteam.Name = "removeteam";
            this.removeteam.Size = new System.Drawing.Size(103, 31);
            this.removeteam.TabIndex = 4;
            this.removeteam.Text = "移除";
            this.removeteam.UseVisualStyleBackColor = true;
            this.removeteam.Click += new System.EventHandler(this.removeteam_Click);
            // 
            // addteam
            // 
            this.addteam.Location = new System.Drawing.Point(20, 516);
            this.addteam.Name = "addteam";
            this.addteam.Size = new System.Drawing.Size(103, 31);
            this.addteam.TabIndex = 3;
            this.addteam.Text = "添加";
            this.addteam.UseVisualStyleBackColor = true;
            this.addteam.Click += new System.EventHandler(this.addteam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "赛事名：";
            // 
            // matchname
            // 
            this.matchname.Location = new System.Drawing.Point(90, 19);
            this.matchname.Name = "matchname";
            this.matchname.Size = new System.Drawing.Size(502, 25);
            this.matchname.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "参赛队伍：";
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(369, 516);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(103, 31);
            this.save.TabIndex = 10;
            this.save.Text = "确定";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "分组数：";
            // 
            // groupcount
            // 
            this.groupcount.Location = new System.Drawing.Point(90, 57);
            this.groupcount.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.groupcount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.groupcount.Name = "groupcount";
            this.groupcount.Size = new System.Drawing.Size(106, 25);
            this.groupcount.TabIndex = 8;
            this.groupcount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // teamlistBox
            // 
            this.teamlistBox.FormattingEnabled = true;
            this.teamlistBox.ItemHeight = 15;
            this.teamlistBox.Location = new System.Drawing.Point(20, 122);
            this.teamlistBox.Name = "teamlistBox";
            this.teamlistBox.Size = new System.Drawing.Size(572, 379);
            this.teamlistBox.TabIndex = 11;
            // 
            // cancle
            // 
            this.cancle.Location = new System.Drawing.Point(489, 516);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(103, 31);
            this.cancle.TabIndex = 12;
            this.cancle.Text = "取消";
            this.cancle.UseVisualStyleBackColor = true;
            this.cancle.Click += new System.EventHandler(this.cancle_Click);
            // 
            // NewMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 559);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.teamlistBox);
            this.Controls.Add(this.save);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupcount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.matchname);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.removeteam);
            this.Controls.Add(this.addteam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMatch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新赛事";
            ((System.ComponentModel.ISupportInitialize)(this.groupcount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button removeteam;
        private System.Windows.Forms.Button addteam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox matchname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown groupcount;
        private System.Windows.Forms.ListBox teamlistBox;
        private System.Windows.Forms.Button cancle;

    }
}