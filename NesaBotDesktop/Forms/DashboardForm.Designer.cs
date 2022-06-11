namespace NesaBotDesktop.Forms {
  partial class DashboardForm {
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
      this.pb_account = new System.Windows.Forms.PictureBox();
      this.pb_settings = new System.Windows.Forms.PictureBox();
      this.lb_title = new System.Windows.Forms.Label();
      this.pb_meme = new System.Windows.Forms.PictureBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label5 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label8 = new System.Windows.Forms.Label();
      this.label9 = new System.Windows.Forms.Label();
      this.pa_discordCommands = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.pb_account)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_settings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_meme)).BeginInit();
      this.pa_discordCommands.SuspendLayout();
      this.SuspendLayout();
      // 
      // pb_account
      // 
      this.pb_account.Image = global::NesaBotDesktop.Properties.Resources.account;
      this.pb_account.InitialImage = global::NesaBotDesktop.Properties.Resources.account;
      this.pb_account.Location = new System.Drawing.Point(5, 4);
      this.pb_account.Name = "pb_account";
      this.pb_account.Size = new System.Drawing.Size(49, 50);
      this.pb_account.TabIndex = 0;
      this.pb_account.TabStop = false;
      this.pb_account.Click += new System.EventHandler(this.pb_account_Click);
      // 
      // pb_settings
      // 
      this.pb_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.pb_settings.Image = global::NesaBotDesktop.Properties.Resources.settings;
      this.pb_settings.InitialImage = global::NesaBotDesktop.Properties.Resources.settings;
      this.pb_settings.Location = new System.Drawing.Point(310, 4);
      this.pb_settings.Name = "pb_settings";
      this.pb_settings.Size = new System.Drawing.Size(49, 50);
      this.pb_settings.TabIndex = 1;
      this.pb_settings.TabStop = false;
      this.pb_settings.Click += new System.EventHandler(this.pb_settings_Click);
      // 
      // lb_title
      // 
      this.lb_title.Anchor = System.Windows.Forms.AnchorStyles.Top;
      this.lb_title.AutoSize = true;
      this.lb_title.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lb_title.Location = new System.Drawing.Point(131, 9);
      this.lb_title.Name = "lb_title";
      this.lb_title.Size = new System.Drawing.Size(100, 24);
      this.lb_title.TabIndex = 9;
      this.lb_title.Text = "Nesa-Bot";
      // 
      // pb_meme
      // 
      this.pb_meme.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.pb_meme.Image = global::NesaBotDesktop.Properties.Resources.Teacher;
      this.pb_meme.InitialImage = global::NesaBotDesktop.Properties.Resources.meme01;
      this.pb_meme.Location = new System.Drawing.Point(0, 87);
      this.pb_meme.Name = "pb_meme";
      this.pb_meme.Size = new System.Drawing.Size(363, 385);
      this.pb_meme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_meme.TabIndex = 10;
      this.pb_meme.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label1.Location = new System.Drawing.Point(5, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(200, 19);
      this.label1.TabIndex = 11;
      this.label1.Text = "Discord-Bot commands:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label2.Location = new System.Drawing.Point(206, 33);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(59, 15);
      this.label2.TabIndex = 12;
      this.label2.Text = "!nesa join";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(5, 33);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(107, 15);
      this.label3.TabIndex = 13;
      this.label3.Text = "Channel beitreten: ";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(5, 56);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(108, 15);
      this.label4.TabIndex = 15;
      this.label4.Text = "Channel verlassen: ";
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label5.Location = new System.Drawing.Point(206, 56);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(69, 15);
      this.label5.TabIndex = 14;
      this.label5.Text = "!nesa leave";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(5, 79);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(130, 15);
      this.label6.TabIndex = 16;
      this.label6.Text = "Persönlich informieren:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label7.Location = new System.Drawing.Point(206, 79);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(57, 15);
      this.label7.TabIndex = 17;
      this.label7.Text = "!nesa dm";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.label8.Location = new System.Drawing.Point(206, 101);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(63, 15);
      this.label8.TabIndex = 19;
      this.label8.Text = "!nesa stop";
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(5, 101);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(193, 15);
      this.label9.TabIndex = 18;
      this.label9.Text = "Nicht mehr persönlich informieren:";
      // 
      // pa_discordCommands
      // 
      this.pa_discordCommands.BackColor = System.Drawing.Color.White;
      this.pa_discordCommands.Controls.Add(this.label1);
      this.pa_discordCommands.Controls.Add(this.label8);
      this.pa_discordCommands.Controls.Add(this.label2);
      this.pa_discordCommands.Controls.Add(this.label9);
      this.pa_discordCommands.Controls.Add(this.label3);
      this.pa_discordCommands.Controls.Add(this.label7);
      this.pa_discordCommands.Controls.Add(this.label5);
      this.pa_discordCommands.Controls.Add(this.label6);
      this.pa_discordCommands.Controls.Add(this.label4);
      this.pa_discordCommands.ForeColor = System.Drawing.Color.Black;
      this.pa_discordCommands.Location = new System.Drawing.Point(10, 202);
      this.pa_discordCommands.Name = "pa_discordCommands";
      this.pa_discordCommands.Size = new System.Drawing.Size(275, 121);
      this.pa_discordCommands.TabIndex = 20;
      // 
      // DashboardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(363, 472);
      this.Controls.Add(this.pa_discordCommands);
      this.Controls.Add(this.pb_meme);
      this.Controls.Add(this.lb_title);
      this.Controls.Add(this.pb_settings);
      this.Controls.Add(this.pb_account);
      this.MaximumSize = new System.Drawing.Size(379, 511);
      this.MinimumSize = new System.Drawing.Size(379, 511);
      this.Name = "DashboardForm";
      this.Text = "Dashboard";
      this.Load += new System.EventHandler(this.DashboardForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pb_account)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_settings)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_meme)).EndInit();
      this.pa_discordCommands.ResumeLayout(false);
      this.pa_discordCommands.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private PictureBox pb_account;
    private PictureBox pb_settings;
    private Label lb_title;
    private PictureBox pb_meme;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Label label5;
    private Label label6;
    private Label label7;
    private Label label8;
    private Label label9;
    private Panel pa_discordCommands;
  }
}