namespace Ekran
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.Startbutt = new System.Windows.Forms.Button();
            this.PotG = new System.Windows.Forms.PictureBox();
            this.expy = new System.Windows.Forms.ProgressBar();
            this.hapeki = new System.Windows.Forms.ProgressBar();
            this.PotR = new System.Windows.Forms.PictureBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.HMain = new System.Windows.Forms.PictureBox();
            this.HOff = new System.Windows.Forms.PictureBox();
            this.HandMain = new System.Windows.Forms.TextBox();
            this.HandOff = new System.Windows.Forms.TextBox();
            this.MainH = new System.Windows.Forms.TextBox();
            this.OffH = new System.Windows.Forms.TextBox();
            this.kasa = new System.Windows.Forms.TextBox();
            this.Potred = new System.Windows.Forms.TextBox();
            this.Potgreen = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOff)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.textBox1.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.textBox1.Location = new System.Drawing.Point(12, 618);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(521, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.UseWaitCursor = true;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.pictureBox1.Image = global::Ekran.Properties.Resources.logo;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(539, 384);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 102;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.textBox2.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Bold);
            this.textBox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox2.Location = new System.Drawing.Point(12, 383);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(521, 228);
            this.textBox2.TabIndex = 111;
            this.textBox2.Text = "";
            this.textBox2.UseWaitCursor = true;
            // 
            // Startbutt
            // 
            this.Startbutt.Location = new System.Drawing.Point(539, 355);
            this.Startbutt.Name = "Startbutt";
            this.Startbutt.Size = new System.Drawing.Size(75, 23);
            this.Startbutt.TabIndex = 112;
            this.Startbutt.Text = "START";
            this.Startbutt.UseVisualStyleBackColor = true;
            this.Startbutt.UseWaitCursor = true;
            this.Startbutt.Click += new System.EventHandler(this.Startbutt_Click);
            // 
            // PotG
            // 
            this.PotG.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PotG.Location = new System.Drawing.Point(731, 190);
            this.PotG.Name = "PotG";
            this.PotG.Size = new System.Drawing.Size(64, 64);
            this.PotG.TabIndex = 113;
            this.PotG.TabStop = false;
            this.PotG.UseWaitCursor = true;
            this.PotG.Visible = false;
            // 
            // expy
            // 
            this.expy.ForeColor = System.Drawing.Color.Purple;
            this.expy.Location = new System.Drawing.Point(695, 306);
            this.expy.Name = "expy";
            this.expy.Size = new System.Drawing.Size(100, 20);
            this.expy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.expy.TabIndex = 114;
            this.expy.UseWaitCursor = true;
            this.expy.Visible = false;
            // 
            // hapeki
            // 
            this.hapeki.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.hapeki.ForeColor = System.Drawing.Color.Red;
            this.hapeki.Location = new System.Drawing.Point(545, 306);
            this.hapeki.Maximum = 20;
            this.hapeki.Name = "hapeki";
            this.hapeki.Size = new System.Drawing.Size(100, 20);
            this.hapeki.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.hapeki.TabIndex = 115;
            this.hapeki.UseWaitCursor = true;
            this.hapeki.Visible = false;
            // 
            // PotR
            // 
            this.PotR.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PotR.Location = new System.Drawing.Point(545, 190);
            this.PotR.Name = "PotR";
            this.PotR.Size = new System.Drawing.Size(64, 64);
            this.PotR.TabIndex = 116;
            this.PotR.TabStop = false;
            this.PotR.UseWaitCursor = true;
            this.PotR.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(545, 286);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 117;
            this.textBox3.UseWaitCursor = true;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(695, 286);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 13);
            this.textBox4.TabIndex = 118;
            this.textBox4.UseWaitCursor = true;
            // 
            // HMain
            // 
            this.HMain.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.HMain.Location = new System.Drawing.Point(545, 12);
            this.HMain.Name = "HMain";
            this.HMain.Size = new System.Drawing.Size(64, 64);
            this.HMain.TabIndex = 119;
            this.HMain.TabStop = false;
            this.HMain.UseWaitCursor = true;
            this.HMain.Visible = false;
            // 
            // HOff
            // 
            this.HOff.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.HOff.Location = new System.Drawing.Point(545, 101);
            this.HOff.Name = "HOff";
            this.HOff.Size = new System.Drawing.Size(64, 64);
            this.HOff.TabIndex = 120;
            this.HOff.TabStop = false;
            this.HOff.UseWaitCursor = true;
            this.HOff.Visible = false;
            // 
            // HandMain
            // 
            this.HandMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.HandMain.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HandMain.Location = new System.Drawing.Point(615, 56);
            this.HandMain.Name = "HandMain";
            this.HandMain.Size = new System.Drawing.Size(172, 13);
            this.HandMain.TabIndex = 121;
            this.HandMain.UseWaitCursor = true;
            this.HandMain.Visible = false;
            // 
            // HandOff
            // 
            this.HandOff.BackColor = System.Drawing.SystemColors.ControlDark;
            this.HandOff.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.HandOff.Location = new System.Drawing.Point(615, 145);
            this.HandOff.Name = "HandOff";
            this.HandOff.Size = new System.Drawing.Size(172, 13);
            this.HandOff.TabIndex = 122;
            this.HandOff.UseWaitCursor = true;
            this.HandOff.Visible = false;
            // 
            // MainH
            // 
            this.MainH.BackColor = System.Drawing.SystemColors.ControlDark;
            this.MainH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainH.Location = new System.Drawing.Point(625, 12);
            this.MainH.Name = "MainH";
            this.MainH.Size = new System.Drawing.Size(100, 13);
            this.MainH.TabIndex = 123;
            this.MainH.UseWaitCursor = true;
            this.MainH.Visible = false;
            // 
            // OffH
            // 
            this.OffH.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OffH.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.OffH.Location = new System.Drawing.Point(625, 101);
            this.OffH.Name = "OffH";
            this.OffH.Size = new System.Drawing.Size(100, 13);
            this.OffH.TabIndex = 124;
            this.OffH.UseWaitCursor = true;
            this.OffH.Visible = false;
            // 
            // kasa
            // 
            this.kasa.BackColor = System.Drawing.SystemColors.ControlDark;
            this.kasa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kasa.Location = new System.Drawing.Point(545, 332);
            this.kasa.Name = "kasa";
            this.kasa.Size = new System.Drawing.Size(100, 13);
            this.kasa.TabIndex = 125;
            this.kasa.UseWaitCursor = true;
            this.kasa.Visible = false;
            // 
            // Potred
            // 
            this.Potred.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Potred.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Potred.Location = new System.Drawing.Point(615, 190);
            this.Potred.Name = "Potred";
            this.Potred.Size = new System.Drawing.Size(30, 13);
            this.Potred.TabIndex = 126;
            this.Potred.UseWaitCursor = true;
            this.Potred.Visible = false;
            // 
            // Potgreen
            // 
            this.Potgreen.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Potgreen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Potgreen.Location = new System.Drawing.Point(695, 190);
            this.Potgreen.Name = "Potgreen";
            this.Potgreen.Size = new System.Drawing.Size(30, 13);
            this.Potgreen.TabIndex = 127;
            this.Potgreen.UseWaitCursor = true;
            this.Potgreen.Visible = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(804, 652);
            this.Controls.Add(this.Potgreen);
            this.Controls.Add(this.Potred);
            this.Controls.Add(this.kasa);
            this.Controls.Add(this.OffH);
            this.Controls.Add(this.MainH);
            this.Controls.Add(this.HandOff);
            this.Controls.Add(this.HandMain);
            this.Controls.Add(this.HOff);
            this.Controls.Add(this.HMain);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.PotR);
            this.Controls.Add(this.hapeki);
            this.Controls.Add(this.expy);
            this.Controls.Add(this.PotG);
            this.Controls.Add(this.Startbutt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "Form1";
            this.Text = "Labirynth";
            this.UseWaitCursor = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PotR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.Button Startbutt;
        private System.Windows.Forms.PictureBox PotG;
        private System.Windows.Forms.ProgressBar expy;
        private System.Windows.Forms.ProgressBar hapeki;
        private System.Windows.Forms.PictureBox PotR;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.PictureBox HMain;
        private System.Windows.Forms.PictureBox HOff;
        private System.Windows.Forms.TextBox HandMain;
        private System.Windows.Forms.TextBox HandOff;
        private System.Windows.Forms.TextBox MainH;
        private System.Windows.Forms.TextBox OffH;
        private System.Windows.Forms.TextBox kasa;
        private System.Windows.Forms.TextBox Potred;
        private System.Windows.Forms.TextBox Potgreen;
    }
}
