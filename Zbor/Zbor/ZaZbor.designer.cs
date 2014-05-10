namespace Zbor
{
    partial class ZaZbor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZaZbor));
            this.lblCreators = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.gboxZbor = new System.Windows.Forms.GroupBox();
            this.lblVerzija = new System.Windows.Forms.Label();
            this.picboxZ = new System.Windows.Forms.PictureBox();
            this.gboxZbor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxZ)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCreators
            // 
            this.lblCreators.AutoSize = true;
            this.lblCreators.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreators.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCreators.Location = new System.Drawing.Point(54, 213);
            this.lblCreators.Name = "lblCreators";
            this.lblCreators.Size = new System.Drawing.Size(236, 16);
            this.lblCreators.TabIndex = 1;
            this.lblCreators.Text = "Од Стефан Станоески и Филип Ѓорѓиоски";
            // 
            // lblText
            // 
            this.lblText.Location = new System.Drawing.Point(44, 19);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(235, 182);
            this.lblText.TabIndex = 2;
            this.lblText.Text = resources.GetString("lblText.Text");
            // 
            // gboxZbor
            // 
            this.gboxZbor.Controls.Add(this.lblVerzija);
            this.gboxZbor.Controls.Add(this.picboxZ);
            this.gboxZbor.Controls.Add(this.lblCreators);
            this.gboxZbor.Controls.Add(this.lblText);
            this.gboxZbor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gboxZbor.Location = new System.Drawing.Point(12, 12);
            this.gboxZbor.Name = "gboxZbor";
            this.gboxZbor.Size = new System.Drawing.Size(292, 232);
            this.gboxZbor.TabIndex = 3;
            this.gboxZbor.TabStop = false;
            this.gboxZbor.Text = "За Збор!";
            // 
            // lblVerzija
            // 
            this.lblVerzija.AutoSize = true;
            this.lblVerzija.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerzija.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblVerzija.Location = new System.Drawing.Point(6, 54);
            this.lblVerzija.Name = "lblVerzija";
            this.lblVerzija.Size = new System.Drawing.Size(30, 16);
            this.lblVerzija.TabIndex = 5;
            this.lblVerzija.Text = "V1.0";
            // 
            // picboxZ
            // 
            this.picboxZ.Image = ((System.Drawing.Image)(resources.GetObject("picboxZ.Image")));
            this.picboxZ.Location = new System.Drawing.Point(6, 19);
            this.picboxZ.Name = "picboxZ";
            this.picboxZ.Size = new System.Drawing.Size(32, 32);
            this.picboxZ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picboxZ.TabIndex = 4;
            this.picboxZ.TabStop = false;
            // 
            // ZaZbor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 257);
            this.Controls.Add(this.gboxZbor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZaZbor";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Збор!";
            this.gboxZbor.ResumeLayout(false);
            this.gboxZbor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxZ)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblCreators;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.GroupBox gboxZbor;
        private System.Windows.Forms.PictureBox picboxZ;
        private System.Windows.Forms.Label lblVerzija;
    }
}