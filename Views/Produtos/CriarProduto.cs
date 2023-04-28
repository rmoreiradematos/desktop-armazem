using System;
using System.Linq;
using System.Windows.Forms;
using Controllers;
using Models;

namespace Views
{
    public class CriarProduto : Form
    {
        private Label lblName;
        private TextBox txtName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Button btnRegister;

        private ProdutoController produtoController = new ProdutoController();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Models.Produto produto = new Models.Produto(
                txtName.Text,
                Convert.ToDecimal(txtPrice.Text)
            );

            produtoController.CriarProduto(produto);
            MessageBox.Show("Produto foi registrado com sucesso!");

            ClearForm();

            ListarProduto ProdutoList = Application.OpenForms.OfType<ListarProduto>().FirstOrDefault();
            if (ProdutoList != null)
            {
                ProdutoList.RefreshList();
            }

            this.Close();
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtPrice.Clear();
        }

        public CriarProduto()
        {
            this.Text = "Registrar produto";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 220);

            this.lblName = new Label();
            this.lblName.Text = "Nome:";
            this.lblName.Location = new System.Drawing.Point(10, 40);
            this.lblName.Size = new System.Drawing.Size(50, 20);

            this.txtName = new TextBox();
            this.txtName.Location = new System.Drawing.Point(80, 40);
            this.txtName.Size = new System.Drawing.Size(150, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new System.Drawing.Point(10, 70);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Location = new System.Drawing.Point(80, 70);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);

            this.btnRegister = new Button();
            this.btnRegister.Text = "Registrar";
            this.btnRegister.Location = new System.Drawing.Point(80, 110);
            this.btnRegister.Size = new System.Drawing.Size(150, 35);
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnRegister);
        }
    }
}
