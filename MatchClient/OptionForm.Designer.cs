namespace MatchClient {
    partial class OptionForm {
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
            this.teamlistView = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.teamListBox = new System.Windows.Forms.ListBox();
            this.addteam = new System.Windows.Forms.Button();
            this.delteam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // teamlistView
            // 
            this.teamlistView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            this.teamlistView.Location = new System.Drawing.Point(239, -3);
            this.teamlistView.Name = "teamlistView";
            this.teamlistView.Size = new System.Drawing.Size(173, 31);
            this.teamlistView.TabIndex = 0;
            this.teamlistView.UseCompatibleStateImageBehavior = false;
            this.teamlistView.View = System.Windows.Forms.View.Details;
            this.teamlistView.Visible = false;
            // 
            // name
            // 
            this.name.Text = "名称";
            this.name.Width = 300;
            // 
            // teamListBox
            // 
            this.teamListBox.FormattingEnabled = true;
            this.teamListBox.ItemHeight = 15;
            this.teamListBox.Location = new System.Drawing.Point(12, 34);
            this.teamListBox.Name = "teamListBox";
            this.teamListBox.Size = new System.Drawing.Size(400, 499);
            this.teamListBox.TabIndex = 1;
            // 
            // addteam
            // 
            this.addteam.Location = new System.Drawing.Point(9, 551);
            this.addteam.Name = "addteam";
            this.addteam.Size = new System.Drawing.Size(84, 31);
            this.addteam.TabIndex = 2;
            this.addteam.Text = "添加";
            this.addteam.UseVisualStyleBackColor = true;
            this.addteam.Click += new System.EventHandler(this.addteam_Click);
            // 
            // delteam
            // 
            this.delteam.Location = new System.Drawing.Point(167, 551);
            this.delteam.Name = "delteam";
            this.delteam.Size = new System.Drawing.Size(84, 31);
            this.delteam.TabIndex = 3;
            this.delteam.Text = "删除";
            this.delteam.UseVisualStyleBackColor = true;
            this.delteam.Click += new System.EventHandler(this.delteam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "队伍列表：";
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(325, 551);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(84, 31);
            this.close.TabIndex = 5;
            this.close.Text = "关闭";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 594);
            this.Controls.Add(this.close);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delteam);
            this.Controls.Add(this.addteam);
            this.Controls.Add(this.teamListBox);
            this.Controls.Add(this.teamlistView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView teamlistView;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ListBox teamListBox;
        private System.Windows.Forms.Button addteam;
        private System.Windows.Forms.Button delteam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button close;
    }
}