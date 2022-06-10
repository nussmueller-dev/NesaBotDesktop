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
      ((System.ComponentModel.ISupportInitialize)(this.pb_account)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_settings)).BeginInit();
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
      this.pb_settings.Image = global::NesaBotDesktop.Properties.Resources.settings;
      this.pb_settings.InitialImage = global::NesaBotDesktop.Properties.Resources.settings;
      this.pb_settings.Location = new System.Drawing.Point(316, 4);
      this.pb_settings.Name = "pb_settings";
      this.pb_settings.Size = new System.Drawing.Size(49, 50);
      this.pb_settings.TabIndex = 1;
      this.pb_settings.TabStop = false;
      this.pb_settings.Click += new System.EventHandler(this.pb_settings_Click);
      // 
      // DashboardForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(369, 472);
      this.Controls.Add(this.pb_settings);
      this.Controls.Add(this.pb_account);
      this.Name = "DashboardForm";
      this.Text = "DashboardForm";
      this.Load += new System.EventHandler(this.DashboardForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pb_account)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_settings)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private PictureBox pb_account;
    private PictureBox pb_settings;
  }
}