namespace NesaBotDesktop {
  partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.tb_username = new System.Windows.Forms.TextBox();
      this.tb_password = new System.Windows.Forms.TextBox();
      this.btn_login = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // tb_username
      // 
      this.tb_username.Location = new System.Drawing.Point(79, 145);
      this.tb_username.Name = "tb_username";
      this.tb_username.Size = new System.Drawing.Size(201, 23);
      this.tb_username.TabIndex = 0;
      // 
      // tb_password
      // 
      this.tb_password.Location = new System.Drawing.Point(79, 184);
      this.tb_password.Name = "tb_password";
      this.tb_password.Size = new System.Drawing.Size(201, 23);
      this.tb_password.TabIndex = 1;
      // 
      // btn_login
      // 
      this.btn_login.Location = new System.Drawing.Point(205, 224);
      this.btn_login.Name = "btn_login";
      this.btn_login.Size = new System.Drawing.Size(75, 23);
      this.btn_login.TabIndex = 2;
      this.btn_login.Text = "Login";
      this.btn_login.UseVisualStyleBackColor = true;
      this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.btn_login);
      this.Controls.Add(this.tb_password);
      this.Controls.Add(this.tb_username);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private TextBox tb_username;
    private TextBox tb_password;
    private Button btn_login;
  }
}