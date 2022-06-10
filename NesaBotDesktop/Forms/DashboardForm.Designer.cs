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
      ((System.ComponentModel.ISupportInitialize)(this.pb_account)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_settings)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_meme)).BeginInit();
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
      this.pb_meme.Image = global::NesaBotDesktop.Properties.Resources.meme01;
      this.pb_meme.InitialImage = global::NesaBotDesktop.Properties.Resources.meme01;
      this.pb_meme.Location = new System.Drawing.Point(0, 87);
      this.pb_meme.Name = "pb_meme";
      this.pb_meme.Size = new System.Drawing.Size(363, 385);
      this.pb_meme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_meme.TabIndex = 10;
      this.pb_meme.TabStop = false;
      // 
      // DashboardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(363, 472);
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
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private PictureBox pb_account;
    private PictureBox pb_settings;
    private Label lb_title;
    private PictureBox pb_meme;
  }
}