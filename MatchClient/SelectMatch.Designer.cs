namespace MatchClient {
    partial class SelectMatch {
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
            this.matchlistBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.open = new System.Windows.Forms.Button();
            this.cancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // matchlistBox
            // 
            this.matchlistBox.FormattingEnabled = true;
            this.matchlistBox.ItemHeight = 15;
            this.matchlistBox.Location = new System.Drawing.Point(23, 42);
            this.matchlistBox.Name = "matchlistBox";
            this.matchlistBox.Size = new System.Drawing.Size(432, 349);
            this.matchlistBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "赛事列表:";
            // 
            // open
            // 
            this.open.Location = new System.Drawing.Point(76, 411);
            this.open.Name = "open";
            this.open.Size = new System.Drawing.Size(103, 31);
            this.open.TabIndex = 2;
            this.open.Text = "打开";
            this.open.UseVisualStyleBackColor = true;
            this.open.Click += new System.EventHandler(this.open_Click);
            // 
            // cancle
            // 
            this.cancle.Location = new System.Drawing.Point(311, 411);
            this.cancle.Name = "cancle";
            this.cancle.Size = new System.Drawing.Size(103, 31);
            this.cancle.TabIndex = 3;
            this.cancle.Text = "取消";
            this.cancle.UseVisualStyleBackColor = true;
            this.cancle.Click += new System.EventHandler(this.cancle_Click);
            // 
            // SelectMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 472);
            this.Controls.Add(this.cancle);
            this.Controls.Add(this.open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.matchlistBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectMatch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "打开";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox matchlistBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button open;
        private System.Windows.Forms.Button cancle;
    }
}