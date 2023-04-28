using Models;
using Controllers;
using System.Windows.Forms;

namespace Views
{
    public class EditarSaldo : Form
    {
        private readonly Label lblIdProduto;
        private readonly Label lblIdAlmoxarifado;
        private readonly Label lblQuantidade;
        private readonly TextBox txtIdProduto;
        private readonly TextBox txtIdAlmoxarifado;
        private readonly TextBox txtQuantidade;
        private readonly Button btnEdit;

        private readonly SaldoController saldoController = new SaldoController();
        private readonly Models.Saldo saldo;

        public EditarSaldo(Models.Saldo saldo)
        {
            this.saldo = saldo;

            Text = "Editar Saldo";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            Size = new System.Drawing.Size(350, 250);

            lblIdProduto = new Label
            {
                Text = "Id do produto:",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(150, 20)
            };

            txtIdProduto = new TextBox
            {
                Text = saldo.IdProduto.ToString(),
                Location = new System.Drawing.Point(170, 40),
                Size = new System.Drawing.Size(150, 20)
            };

            lblIdAlmoxarifado = new Label
            {
                Text = "Id do almoxarifado:",
                Location = new System.Drawing.Point(10, 70),
                Size = new System.Drawing.Size(150, 20)
            };

            txtIdAlmoxarifado = new TextBox
            {
                Text = saldo.IdAlmoxarifado.ToString(),
                Location = new System.Drawing.Point(170, 70),
                Size = new System.Drawing.Size(150, 20)
            };

            lblQuantidade = new Label
            {
                Text = "Quantidade:",
                Location = new System.Drawing.Point(10, 100),
                Size = new System.Drawing.Size(150, 20)
            };

            txtQuantidade = new TextBox
            {
                Text = saldo.Quantidade.ToString(),
                Location = new System.Drawing.Point(170, 100),
                Size = new System.Drawing.Size(150, 20)
            };

            btnEdit = new Button
            {
                Text = "Alterar",
                Location = new System.Drawing.Point(170, 150),
                Size = new System.Drawing.Size(150, 35)
            };
            btnEdit.Click += BtnEdit_Click;

            Controls.AddRange(new Control[]
            {
                lblIdProduto, txtIdProduto, lblIdAlmoxarifado, txtIdAlmoxarifado,
                lblQuantidade, txtQuantidade, btnEdit
            });
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            saldo.IdProduto = int.Parse(txtIdProduto.Text);
            saldo.IdAlmoxarifado = int.Parse(txtIdAlmoxarifado.Text);
            saldo.Quantidade = int.Parse(txtQuantidade.Text);

            saldoController.AtualizarSaldo(saldo);
            MessageBox.Show("O saldo foi alterado com sucesso!");

            ListarSaldo saldoList = Application.OpenForms.OfType<ListarSaldo>().FirstOrDefault();
            saldoList?.RefreshList();
            Close();
        }
    }
}
