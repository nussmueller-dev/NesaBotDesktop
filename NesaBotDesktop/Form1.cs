namespace NesaBotDesktop {
  public partial class Form1 : Form {
    public Form1() {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e) {
      var markLogic = new MarksLogic("https://gbs.nesa-sg.ch/");
      var token = markLogic.GetToken("test", "asdfqwgewrgegg");
    }

    private void btn_login_Click(object sender, EventArgs e) {

    }
  }
}