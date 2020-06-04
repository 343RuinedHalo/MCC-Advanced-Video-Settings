namespace MCCAdvancedVideoSettings
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveButton = new System.Windows.Forms.ToolStripButton();
            this.GitHubButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ReloadButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.H1Page = new System.Windows.Forms.PropertyGrid();
            this.H2Page = new System.Windows.Forms.PropertyGrid();
            this.H3Page = new System.Windows.Forms.PropertyGrid();
            this.ReachPage = new System.Windows.Forms.PropertyGrid();
            this.H4Page = new System.Windows.Forms.PropertyGrid();
            this.H2APage = new System.Windows.Forms.PropertyGrid();
            this.ODSTPage = new System.Windows.Forms.PropertyGrid();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveButton,
            this.GitHubButton,
            this.toolStripSeparator1,
            this.ReloadButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 687);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(512, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveButton
            // 
            this.SaveButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(60, 22);
            this.SaveButton.Text = "Save File";
            this.SaveButton.ToolTipText = "Write changes to \'SystemSettingsData.bin\' file";
            // 
            // GitHubButton
            // 
            this.GitHubButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GitHubButton.Image = ((System.Drawing.Image)(resources.GetObject("GitHubButton.Image")));
            this.GitHubButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GitHubButton.Name = "GitHubButton";
            this.GitHubButton.Size = new System.Drawing.Size(89, 22);
            this.GitHubButton.Text = "GitHub Project";
            this.GitHubButton.ToolTipText = "Opens the GitHub project webpage";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ReloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ReloadButton.Image = ((System.Drawing.Image)(resources.GetObject("ReloadButton.Image")));
            this.ReloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(68, 22);
            this.ReloadButton.Text = "Reload File";
            this.ReloadButton.ToolTipText = "Reloads \'SystemSettingsData.bin\' from disk. Any unsaved changes will be lost";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 687);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 687);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.H1Page);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 661);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Halo 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.H2Page);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 661);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Halo 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.H3Page);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(504, 661);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Halo 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.ODSTPage);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(504, 661);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Halo 3: ODST";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.ReachPage);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(504, 661);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Halo Reach";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.H4Page);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(504, 661);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Halo 4";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.H2APage);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(504, 661);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Halo 2: Anniversary";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // H1Page
            // 
            this.H1Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.H1Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H1Page.HelpVisible = false;
            this.H1Page.Location = new System.Drawing.Point(3, 3);
            this.H1Page.Name = "H1Page";
            this.H1Page.Size = new System.Drawing.Size(498, 655);
            this.H1Page.TabIndex = 0;
            this.H1Page.ToolbarVisible = false;
            // 
            // H2Page
            // 
            this.H2Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.H2Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H2Page.HelpVisible = false;
            this.H2Page.Location = new System.Drawing.Point(3, 3);
            this.H2Page.Name = "H2Page";
            this.H2Page.Size = new System.Drawing.Size(498, 655);
            this.H2Page.TabIndex = 1;
            this.H2Page.ToolbarVisible = false;
            // 
            // H3Page
            // 
            this.H3Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.H3Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H3Page.HelpVisible = false;
            this.H3Page.Location = new System.Drawing.Point(3, 3);
            this.H3Page.Name = "H3Page";
            this.H3Page.Size = new System.Drawing.Size(498, 655);
            this.H3Page.TabIndex = 1;
            this.H3Page.ToolbarVisible = false;
            // 
            // ReachPage
            // 
            this.ReachPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReachPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReachPage.HelpVisible = false;
            this.ReachPage.Location = new System.Drawing.Point(3, 3);
            this.ReachPage.Name = "ReachPage";
            this.ReachPage.Size = new System.Drawing.Size(498, 655);
            this.ReachPage.TabIndex = 1;
            this.ReachPage.ToolbarVisible = false;
            // 
            // H4Page
            // 
            this.H4Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.H4Page.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H4Page.HelpVisible = false;
            this.H4Page.Location = new System.Drawing.Point(3, 3);
            this.H4Page.Name = "H4Page";
            this.H4Page.Size = new System.Drawing.Size(498, 655);
            this.H4Page.TabIndex = 1;
            this.H4Page.ToolbarVisible = false;
            // 
            // H2APage
            // 
            this.H2APage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.H2APage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.H2APage.HelpVisible = false;
            this.H2APage.Location = new System.Drawing.Point(3, 3);
            this.H2APage.Name = "H2APage";
            this.H2APage.Size = new System.Drawing.Size(498, 655);
            this.H2APage.TabIndex = 2;
            this.H2APage.ToolbarVisible = false;
            // 
            // ODSTPage
            // 
            this.ODSTPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ODSTPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ODSTPage.HelpVisible = false;
            this.ODSTPage.Location = new System.Drawing.Point(3, 3);
            this.ODSTPage.Name = "ODSTPage";
            this.ODSTPage.Size = new System.Drawing.Size(498, 655);
            this.ODSTPage.TabIndex = 2;
            this.ODSTPage.ToolbarVisible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.ClientSize = new System.Drawing.Size(512, 712);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MCC Advanced Video Settings";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton ReloadButton;
        private System.Windows.Forms.ToolStripButton GitHubButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.PropertyGrid H1Page;
        private System.Windows.Forms.PropertyGrid H2Page;
        private System.Windows.Forms.PropertyGrid H3Page;
        private System.Windows.Forms.PropertyGrid ReachPage;
        private System.Windows.Forms.PropertyGrid H4Page;
        private System.Windows.Forms.PropertyGrid H2APage;
        private System.Windows.Forms.PropertyGrid ODSTPage;
    }
}

