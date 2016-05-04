namespace MatchClient {
    partial class MainForm {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.optionButton = new System.Windows.Forms.ToolStripButton();
            this.worktabControl = new System.Windows.Forms.TabControl();
            this.teamPage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.save = new System.Windows.Forms.Button();
            this.TeamListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selectTeamBox = new System.Windows.Forms.TextBox();
            this.cardview = new System.Windows.Forms.ListView();
            this.orderpage = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.worktabControl.SuspendLayout();
            this.teamPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.openButton,
            this.optionButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1002, 57);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(93, 54);
            this.newButton.Text = "新建";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // openButton
            // 
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(93, 54);
            this.openButton.Text = "打开";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // optionButton
            // 
            this.optionButton.Image = ((System.Drawing.Image)(resources.GetObject("optionButton.Image")));
            this.optionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.optionButton.Name = "optionButton";
            this.optionButton.Size = new System.Drawing.Size(93, 54);
            this.optionButton.Text = "队伍";
            this.optionButton.Click += new System.EventHandler(this.optionButton_Click);
            // 
            // worktabControl
            // 
            this.worktabControl.Controls.Add(this.teamPage);
            this.worktabControl.Controls.Add(this.orderpage);
            this.worktabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.worktabControl.Location = new System.Drawing.Point(0, 57);
            this.worktabControl.Name = "worktabControl";
            this.worktabControl.SelectedIndex = 0;
            this.worktabControl.Size = new System.Drawing.Size(1002, 546);
            this.worktabControl.TabIndex = 2;
            // 
            // teamPage
            // 
            this.teamPage.Controls.Add(this.splitContainer1);
            this.teamPage.Location = new System.Drawing.Point(4, 25);
            this.teamPage.Name = "teamPage";
            this.teamPage.Padding = new System.Windows.Forms.Padding(3);
            this.teamPage.Size = new System.Drawing.Size(994, 517);
            this.teamPage.TabIndex = 0;
            this.teamPage.Text = "分组抽签";
            this.teamPage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.save);
            this.splitContainer1.Panel1.Controls.Add(this.TeamListView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.selectTeamBox);
            this.splitContainer1.Panel2.Controls.Add(this.cardview);
            this.splitContainer1.Size = new System.Drawing.Size(988, 511);
            this.splitContainer1.SplitterDistance = 259;
            this.splitContainer1.TabIndex = 0;
            // 
            // save
            // 
            this.save.Enabled = false;
            this.save.Location = new System.Drawing.Point(158, 467);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(98, 35);
            this.save.TabIndex = 1;
            this.save.Text = "保 存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // TeamListView
            // 
            this.TeamListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.TeamListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TeamListView.FullRowSelect = true;
            this.TeamListView.Location = new System.Drawing.Point(0, 0);
            this.TeamListView.Name = "TeamListView";
            this.TeamListView.Size = new System.Drawing.Size(259, 461);
            this.TeamListView.TabIndex = 0;
            this.TeamListView.UseCompatibleStateImageBehavior = false;
            this.TeamListView.View = System.Windows.Forms.View.Details;
            this.TeamListView.SelectedIndexChanged += new System.EventHandler(this.TeamListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "队名";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "分组号";
            // 
            // selectTeamBox
            // 
            this.selectTeamBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectTeamBox.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectTeamBox.Location = new System.Drawing.Point(0, 0);
            this.selectTeamBox.Name = "selectTeamBox";
            this.selectTeamBox.ReadOnly = true;
            this.selectTeamBox.Size = new System.Drawing.Size(725, 42);
            this.selectTeamBox.TabIndex = 1;
            // 
            // cardview
            // 
            this.cardview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cardview.Location = new System.Drawing.Point(0, 48);
            this.cardview.Name = "cardview";
            this.cardview.Size = new System.Drawing.Size(725, 463);
            this.cardview.TabIndex = 0;
            this.cardview.UseCompatibleStateImageBehavior = false;
            this.cardview.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cardview_MouseUp);
            // 
            // orderpage
            // 
            this.orderpage.Location = new System.Drawing.Point(4, 25);
            this.orderpage.Name = "orderpage";
            this.orderpage.Padding = new System.Windows.Forms.Padding(3);
            this.orderpage.Size = new System.Drawing.Size(1015, 624);
            this.orderpage.TabIndex = 1;
            this.orderpage.Text = "排号抽签";
            this.orderpage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 603);
            this.Controls.Add(this.worktabControl);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "抽 抽 抽";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.worktabControl.ResumeLayout(false);
            this.teamPage.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.TabControl worktabControl;
        private System.Windows.Forms.TabPage teamPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView TeamListView;
        private System.Windows.Forms.ListView cardview;
        private System.Windows.Forms.TabPage orderpage;
        private System.Windows.Forms.ToolStripButton optionButton;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.TextBox selectTeamBox;
        private System.Windows.Forms.Button save;
    }
}

