namespace NesaBotDesktop {
  partial class LoginForm {
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
      this.tb_username = new System.Windows.Forms.TextBox();
      this.tb_password = new System.Windows.Forms.TextBox();
      this.lb_username = new System.Windows.Forms.Label();
      this.lb_password = new System.Windows.Forms.Label();
      this.lb_title = new System.Windows.Forms.Label();
      this.lb_url = new System.Windows.Forms.Label();
      this.tb_url = new System.Windows.Forms.TextBox();
      this.btn_safe = new System.Windows.Forms.Button();
      this.btn_cancel = new System.Windows.Forms.Button();
      this.pb_errorArrowUrl = new System.Windows.Forms.PictureBox();
      this.pb_errorArrowUsername = new System.Windows.Forms.PictureBox();
      this.pb_errorArrowPassword = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pb_errorArrowUrl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_errorArrowUsername)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_errorArrowPassword)).BeginInit();
      this.SuspendLayout();
      // 
      // tb_username
      // 
      this.tb_username.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tb_username.Location = new System.Drawing.Point(12, 159);
      this.tb_username.Name = "tb_username";
      this.tb_username.Size = new System.Drawing.Size(231, 23);
      this.tb_username.TabIndex = 1;
      // 
      // tb_password
      // 
      this.tb_password.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tb_password.Location = new System.Drawing.Point(12, 228);
      this.tb_password.Name = "tb_password";
      this.tb_password.PasswordChar = '*';
      this.tb_password.Size = new System.Drawing.Size(231, 23);
      this.tb_password.TabIndex = 2;
      // 
      // lb_username
      // 
      this.lb_username.AutoSize = true;
      this.lb_username.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.lb_username.Location = new System.Drawing.Point(12, 141);
      this.lb_username.Name = "lb_username";
      this.lb_username.Size = new System.Drawing.Size(85, 14);
      this.lb_username.TabIndex = 6;
      this.lb_username.Text = "Benutzername";
      // 
      // lb_password
      // 
      this.lb_password.AutoSize = true;
      this.lb_password.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.lb_password.Location = new System.Drawing.Point(12, 210);
      this.lb_password.Name = "lb_password";
      this.lb_password.Size = new System.Drawing.Size(58, 14);
      this.lb_password.TabIndex = 7;
      this.lb_password.Text = "Passwort";
      // 
      // lb_title
      // 
      this.lb_title.AutoSize = true;
      this.lb_title.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.lb_title.Location = new System.Drawing.Point(12, 18);
      this.lb_title.Name = "lb_title";
      this.lb_title.Size = new System.Drawing.Size(309, 24);
      this.lb_title.TabIndex = 8;
      this.lb_title.Text = "Bitte gib deine Nesa Daten ein";
      // 
      // lb_url
      // 
      this.lb_url.AutoSize = true;
      this.lb_url.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.lb_url.Location = new System.Drawing.Point(12, 74);
      this.lb_url.Name = "lb_url";
      this.lb_url.Size = new System.Drawing.Size(59, 14);
      this.lb_url.TabIndex = 5;
      this.lb_url.Text = "Nesa URL";
      // 
      // tb_url
      // 
      this.tb_url.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
      this.tb_url.Location = new System.Drawing.Point(12, 92);
      this.tb_url.Name = "tb_url";
      this.tb_url.Size = new System.Drawing.Size(231, 23);
      this.tb_url.TabIndex = 0;
      // 
      // btn_safe
      // 
      this.btn_safe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btn_safe.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.btn_safe.Location = new System.Drawing.Point(226, 286);
      this.btn_safe.Name = "btn_safe";
      this.btn_safe.Size = new System.Drawing.Size(93, 29);
      this.btn_safe.TabIndex = 4;
      this.btn_safe.Text = "Speichern";
      this.btn_safe.UseVisualStyleBackColor = true;
      this.btn_safe.Click += new System.EventHandler(this.btn_safe_Click);
      // 
      // btn_cancel
      // 
      this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btn_cancel.Font = new System.Drawing.Font("Roboto", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
      this.btn_cancel.Location = new System.Drawing.Point(12, 286);
      this.btn_cancel.Name = "btn_cancel";
      this.btn_cancel.Size = new System.Drawing.Size(97, 29);
      this.btn_cancel.TabIndex = 3;
      this.btn_cancel.Text = "Abbrechen";
      this.btn_cancel.UseVisualStyleBackColor = true;
      this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
      // 
      // pb_errorArrowUrl
      // 
      this.pb_errorArrowUrl.Image = global::NesaBotDesktop.Properties.Resources.arrow_left;
      this.pb_errorArrowUrl.InitialImage = global::NesaBotDesktop.Properties.Resources.arrow_left;
      this.pb_errorArrowUrl.Location = new System.Drawing.Point(248, 69);
      this.pb_errorArrowUrl.Name = "pb_errorArrowUrl";
      this.pb_errorArrowUrl.Size = new System.Drawing.Size(72, 70);
      this.pb_errorArrowUrl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_errorArrowUrl.TabIndex = 9;
      this.pb_errorArrowUrl.TabStop = false;
      this.pb_errorArrowUrl.Visible = false;
      // 
      // pb_errorArrowUsername
      // 
      this.pb_errorArrowUsername.Image = global::NesaBotDesktop.Properties.Resources.arrow_left;
      this.pb_errorArrowUsername.InitialImage = global::NesaBotDesktop.Properties.Resources.arrow_left;
      this.pb_errorArrowUsername.Location = new System.Drawing.Point(248, 136);
      this.pb_errorArrowUsername.Name = "pb_errorArrowUsername";
      this.pb_errorArrowUsername.Size = new System.Drawing.Size(72, 70);
      this.pb_errorArrowUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_errorArrowUsername.TabIndex = 10;
      this.pb_errorArrowUsername.TabStop = false;
      this.pb_errorArrowUsername.Visible = false;
      // 
      // pb_errorArrowPassword
      // 
      this.pb_errorArrowPassword.Image = global::NesaBotDesktop.Properties.Resources.arrow_left;
      this.pb_errorArrowPassword.InitialImage = global::NesaBotDesktop.Properties.Resources.arrow_left;
      this.pb_errorArrowPassword.Location = new System.Drawing.Point(248, 205);
      this.pb_errorArrowPassword.Name = "pb_errorArrowPassword";
      this.pb_errorArrowPassword.Size = new System.Drawing.Size(72, 70);
      this.pb_errorArrowPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      this.pb_errorArrowPassword.TabIndex = 11;
      this.pb_errorArrowPassword.TabStop = false;
      this.pb_errorArrowPassword.Visible = false;
      // 
      // LoginForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(332, 327);
      this.Controls.Add(this.pb_errorArrowPassword);
      this.Controls.Add(this.pb_errorArrowUsername);
      this.Controls.Add(this.pb_errorArrowUrl);
      this.Controls.Add(this.btn_cancel);
      this.Controls.Add(this.btn_safe);
      this.Controls.Add(this.lb_url);
      this.Controls.Add(this.tb_url);
      this.Controls.Add(this.lb_title);
      this.Controls.Add(this.lb_password);
      this.Controls.Add(this.lb_username);
      this.Controls.Add(this.tb_password);
      this.Controls.Add(this.tb_username);
      this.Name = "LoginForm";
      this.Text = "Login";
      ((System.ComponentModel.ISupportInitialize)(this.pb_errorArrowUrl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_errorArrowUsername)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pb_errorArrowPassword)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private TextBox tb_username;
    private TextBox tb_password;
    private Label lb_username;
    private Label lb_password;
    private Label lb_title;
    private Label lb_url;
    private TextBox tb_url;
    private Button btn_safe;
    private Button btn_cancel;
    private PictureBox pb_errorArrowUrl;
    private PictureBox pb_errorArrowUsername;
    private PictureBox pb_errorArrowPassword;
  }
}