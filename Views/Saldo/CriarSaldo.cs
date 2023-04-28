using Controllers;
using Models;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Views
{
    public class CriarSaldo : Form
    {
        private readonly SaldoController saldoController = new SaldoController();

        public Label lblIdProduto;
        public TextBox txtIdProduto;
        public Label lblIdAlmoxarifado;
        public TextBox txtIdAlmoxarifado;
        public Label lblQuantidade;
        public TextBox txtQuantidade;
        public Button btnRegister;

        public CriarSaldo()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Registar Saldo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new Size(350, 250);

            this.lblIdProduto = new Label { Text = "Id do produto:", Location = new Point(10, 40), Size = new Size(150, 20) };
            this.txtIdProduto = new TextBox { Location = new Point(170, 40), Size = new Size(150, 20) };
            this.lblIdAlmoxarifado = new Label { Text = "Id do almoxarifado:", Location = new Point(10, 70), Size = new Size(150, 20) };
            this.txtIdAlmoxarifado = new TextBox { Location = new Point(170, 70), Size = new Size(150, 20) };
            this.lblQuantidade = new Label { Text = "Quantidade:", Location = new Point(10, 100), Size = new Size(150, 20) };
            this.txtQuantidade = new TextBox { Location = new Point(170, 100), Size = new Size(150, 20) };
            this.btnRegister = new Button { Text = "Registrar", Location = new Point(170, 150), Size = new Size(150, 35) };
            this.btnRegister.Click += new EventHandler(btnRegister_Click);

            this.Controls.Add(this.lblIdProduto);
            this.Controls.Add(this.lblIdAlmoxarifado);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.txtIdAlmoxarifado);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btnRegister);
        }

        private void ClearForm()
        {
            txtIdProduto.Clear();
            txtIdAlmoxarifado.Clear();
            txtQuantidade.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var saldo = new Models.Saldo(
                    Convert.ToInt32(txtIdProduto.Text),
                    Convert.ToInt32(txtIdAlmoxarifado.Text),
                    Convert.ToInt32(txtQuantidade.Text)
                );

                saldoController.CriarSaldo(saldo);
                MessageBox.Show("Saldo foi registrado com sucesso!");

                ClearForm();

                var saldoList = Application.OpenForms.OfType<ListarSaldo>().FirstOrDefault();
                if (saldoList != null)
                {
                    saldoList.RefreshList();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
