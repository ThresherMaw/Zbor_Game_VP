namespace Zbor
{
    partial class Zbor
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Zbor));
            this.layout = new System.Windows.Forms.TableLayoutPanel();
            this.txtGuess = new System.Windows.Forms.TextBox();
            this.guessTip = new System.Windows.Forms.ToolTip(this.components);
            this.letterTip = new System.Windows.Forms.ToolTip(this.components);
            this.definitionLink = new System.Windows.Forms.LinkLabel();
            this.lblScore = new System.Windows.Forms.Label();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initLayout = new System.Windows.Forms.TableLayoutPanel();
            this.bonusScoreLabel = new System.Windows.Forms.Label();
            this.bonusLabel = new System.Windows.Forms.Label();
            this.gridBox = new System.Windows.Forms.GroupBox();
            this.btnRecords = new System.Windows.Forms.Button();
            this.guessBox = new System.Windows.Forms.GroupBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.contextMenuStrip.SuspendLayout();
            this.gridBox.SuspendLayout();
            this.guessBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            this.layout.BackColor = System.Drawing.SystemColors.Control;
            this.layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.layout.ColumnCount = 5;
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layout.Cursor = System.Windows.Forms.Cursors.Default;
            this.layout.Location = new System.Drawing.Point(13, 62);
            this.layout.Margin = new System.Windows.Forms.Padding(0);
            this.layout.Name = "layout";
            this.layout.RowCount = 5;
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.layout.Size = new System.Drawing.Size(141, 121);
            this.layout.TabIndex = 0;
            // 
            // txtGuess
            // 
            this.txtGuess.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.txtGuess.BackColor = System.Drawing.SystemColors.Window;
            this.txtGuess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGuess.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGuess.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGuess.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtGuess.Location = new System.Drawing.Point(12, 19);
            this.txtGuess.Name = "txtGuess";
            this.txtGuess.Size = new System.Drawing.Size(142, 22);
            this.txtGuess.TabIndex = 0;
            this.txtGuess.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.guessTip.SetToolTip(this.txtGuess, "Внесете збор со 5 букви\r\nкако ваш обид");
            this.txtGuess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessNormalKeys);
            this.txtGuess.KeyUp += new System.Windows.Forms.KeyEventHandler(this.guess_KeyUp);
            this.txtGuess.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ProcessPreviewKeys);
            // 
            // guessTip
            // 
            this.guessTip.IsBalloon = true;
            this.guessTip.ToolTipTitle = "Внесете го вашиот збор овде";
            // 
            // definitionLink
            // 
            this.definitionLink.ActiveLinkColor = System.Drawing.Color.Red;
            this.definitionLink.AutoSize = true;
            this.definitionLink.Cursor = System.Windows.Forms.Cursors.Help;
            this.definitionLink.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.definitionLink.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.definitionLink.Location = new System.Drawing.Point(50, 42);
            this.definitionLink.Name = "definitionLink";
            this.definitionLink.Size = new System.Drawing.Size(81, 16);
            this.definitionLink.TabIndex = 1;
            this.definitionLink.TabStop = true;
            this.definitionLink.Text = "Што е Збор! ?";
            this.definitionLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.letterTip.SetToolTip(this.definitionLink, "Кликнете за дефиниција");
            this.definitionLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.definitionLink_LinkClicked);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Lucida Fax", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblScore.Location = new System.Drawing.Point(3, 14);
            this.lblScore.Margin = new System.Windows.Forms.Padding(0);
            this.lblScore.MinimumSize = new System.Drawing.Size(45, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(60, 16);
            this.lblScore.TabIndex = 4;
            this.lblScore.Text = "0 поени";
            this.lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.difficultyToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(122, 76);
            // 
            // difficultyToolStripMenuItem
            // 
            this.difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.easyToolStripMenuItem,
            this.mediumToolStripMenuItem,
            this.hardToolStripMenuItem});
            this.difficultyToolStripMenuItem.Name = "difficultyToolStripMenuItem";
            this.difficultyToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.difficultyToolStripMenuItem.Text = "Тежина";
            // 
            // easyToolStripMenuItem
            // 
            this.easyToolStripMenuItem.Checked = true;
            this.easyToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.easyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("easyToolStripMenuItem.Image")));
            this.easyToolStripMenuItem.Name = "easyToolStripMenuItem";
            this.easyToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.easyToolStripMenuItem.Tag = "Easy";
            this.easyToolStripMenuItem.Text = "Лесно";
            this.easyToolStripMenuItem.Click += new System.EventHandler(this.ChangeDifficultyLevel);
            // 
            // mediumToolStripMenuItem
            // 
            this.mediumToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mediumToolStripMenuItem.Image")));
            this.mediumToolStripMenuItem.Name = "mediumToolStripMenuItem";
            this.mediumToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.mediumToolStripMenuItem.Tag = "Medium";
            this.mediumToolStripMenuItem.Text = "Средно";
            this.mediumToolStripMenuItem.Click += new System.EventHandler(this.ChangeDifficultyLevel);
            // 
            // hardToolStripMenuItem
            // 
            this.hardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hardToolStripMenuItem.Image")));
            this.hardToolStripMenuItem.Name = "hardToolStripMenuItem";
            this.hardToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.hardToolStripMenuItem.Tag = "Hard";
            this.hardToolStripMenuItem.Text = "Тешко";
            this.hardToolStripMenuItem.Click += new System.EventHandler(this.ChangeDifficultyLevel);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.aboutToolStripMenuItem.Text = "За Збор!";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.PrikaziZaZbor);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quitToolStripMenuItem.Image")));
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.quitToolStripMenuItem.Text = "Излез";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.IzlezOdIgra);
            // 
            // initLayout
            // 
            this.initLayout.ColumnCount = 5;
            this.initLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.initLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.initLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.initLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.initLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.initLayout.Location = new System.Drawing.Point(13, 39);
            this.initLayout.Margin = new System.Windows.Forms.Padding(0);
            this.initLayout.Name = "initLayout";
            this.initLayout.RowCount = 1;
            this.initLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.initLayout.Size = new System.Drawing.Size(141, 25);
            this.initLayout.TabIndex = 6;
            // 
            // bonusScoreLabel
            // 
            this.bonusScoreLabel.AutoSize = true;
            this.bonusScoreLabel.Font = new System.Drawing.Font("Microsoft YaHei", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusScoreLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bonusScoreLabel.Location = new System.Drawing.Point(127, 186);
            this.bonusScoreLabel.Name = "bonusScoreLabel";
            this.bonusScoreLabel.Size = new System.Drawing.Size(13, 14);
            this.bonusScoreLabel.TabIndex = 7;
            this.bonusScoreLabel.Text = "0";
            // 
            // bonusLabel
            // 
            this.bonusLabel.AutoSize = true;
            this.bonusLabel.Font = new System.Drawing.Font("Microsoft YaHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bonusLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.bonusLabel.Location = new System.Drawing.Point(94, 186);
            this.bonusLabel.Margin = new System.Windows.Forms.Padding(0);
            this.bonusLabel.Name = "bonusLabel";
            this.bonusLabel.Size = new System.Drawing.Size(37, 14);
            this.bonusLabel.TabIndex = 8;
            this.bonusLabel.Text = "Бонус:";
            // 
            // gridBox
            // 
            this.gridBox.Controls.Add(this.btnRecords);
            this.gridBox.Controls.Add(this.layout);
            this.gridBox.Controls.Add(this.bonusScoreLabel);
            this.gridBox.Controls.Add(this.initLayout);
            this.gridBox.Controls.Add(this.bonusLabel);
            this.gridBox.Controls.Add(this.lblScore);
            this.gridBox.Location = new System.Drawing.Point(13, 7);
            this.gridBox.Name = "gridBox";
            this.gridBox.Size = new System.Drawing.Size(170, 209);
            this.gridBox.TabIndex = 1;
            this.gridBox.TabStop = false;
            // 
            // btnRecords
            // 
            this.btnRecords.Location = new System.Drawing.Point(79, 11);
            this.btnRecords.Name = "btnRecords";
            this.btnRecords.Size = new System.Drawing.Size(75, 23);
            this.btnRecords.TabIndex = 0;
            this.btnRecords.Text = "Рекорди";
            this.btnRecords.UseVisualStyleBackColor = true;
            this.btnRecords.Click += new System.EventHandler(this.btnRecords_Click);
            // 
            // guessBox
            // 
            this.guessBox.Controls.Add(this.messageLabel);
            this.guessBox.Controls.Add(this.txtGuess);
            this.guessBox.Controls.Add(this.definitionLink);
            this.guessBox.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guessBox.Location = new System.Drawing.Point(13, 222);
            this.guessBox.Name = "guessBox";
            this.guessBox.Size = new System.Drawing.Size(170, 64);
            this.guessBox.TabIndex = 0;
            this.guessBox.TabStop = false;
            this.guessBox.Text = "Твое мислење:";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Microsoft YaHei", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.messageLabel.Location = new System.Drawing.Point(12, 44);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(0, 14);
            this.messageLabel.TabIndex = 6;
            // 
            // Zbor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(194, 296);
            this.Controls.Add(this.gridBox);
            this.Controls.Add(this.guessBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Zbor";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Збор";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProcessNormalKeys);
            this.contextMenuStrip.ResumeLayout(false);
            this.gridBox.ResumeLayout(false);
            this.gridBox.PerformLayout();
            this.guessBox.ResumeLayout(false);
            this.guessBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TableLayoutPanel layout;
        private System.Windows.Forms.TextBox txtGuess;
        private System.Windows.Forms.ToolTip guessTip;
        private System.Windows.Forms.ToolTip letterTip;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.LinkLabel definitionLink;
        private System.Windows.Forms.TableLayoutPanel initLayout;
        private System.Windows.Forms.Label bonusScoreLabel;
        private System.Windows.Forms.Label bonusLabel;
        private System.Windows.Forms.GroupBox gridBox;
        private System.Windows.Forms.GroupBox guessBox;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button btnRecords;
    }
}

