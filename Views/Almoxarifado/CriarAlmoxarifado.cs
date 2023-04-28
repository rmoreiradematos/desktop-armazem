using Controllers;
using Models;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Views
{
  public class CriarAlmoxarifado : Form
  {
    private Label lblName;
    private TextBox txtName;
    private Button btnRegister;

    public CriarAlmoxarifado()
    {
      InicializarComponentes();
    }

    private void InicializarComponentes()
    {
      lblName = new Label
      {
        Text = "Nome:",
        Location = new Point(10, 40),
        Size = new Size(50, 20)
      };

      txtName = new TextBox
      {
        Location = new Point(80, 40),
        Size = new Size(150, 20)
      };

      btnRegister = new Button
      {
        Text = "Registrar",
        Location = new Point(80, 110),
        Size = new Size(150, 35)
      };
      btnRegister.Click += btnRegister_Click;

      Controls.AddRange(new Control[] { lblName, txtName, btnRegister });

      Text = "Registar Almoxarifado";
      StartPosition = FormStartPosition.CenterScreen;
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MaximizeBox = false;
      MinimizeBox = false;
      ShowIcon = false;
      ShowInTaskbar = false;
      Size = new Size(280, 220);
    }

    private void btnRegister_Click(object sender, EventArgs e)
    {
      Models.Almoxarifado almoxarifado = new Models.Almoxarifado(txtName.Text);
      Controllers.Almoxarifado.CriarAlmoxarifado(almoxarifado);
      MessageBox.Show("Almoxarifado foi registrado com sucesso!");

      ClearForm();

      ListarAlmoxarifado AlmoxarifadoList = Application.OpenForms.OfType<ListarAlmoxarifado>().FirstOrDefault();
      if (AlmoxarifadoList != null)
      {
        AlmoxarifadoList.RefreshList();
      }

      Close();
    }

    private void ClearForm()
    {
      txtName.Clear();
    }
  }
}