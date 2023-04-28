using System;
using System.Linq;
using System.Windows.Forms;
using Models;
using Controllers;

namespace Views
{
    public class EditarProduto : Form
    {
        private Label lblName;
        private TextBox txtName;
        private Label lblPrice;
        private TextBox txtPrice;
        private Button btnEdit;
        private Models.Produto produto;

        private ProdutoController produtoController = new ProdutoController();

        public void btnEdit_Click(object sender, EventArgs e)
        {
            produto.Nome = txtName.Text;
            produto.Preco = Convert.ToDecimal(txtPrice.Text);

            produtoController.AtualizarProduto(produto);
            MessageBox.Show("O produto foi alterado com sucesso!");

            ListarProduto ProdutoList = Application.OpenForms.OfType<ListarProduto>().FirstOrDefault();
            if (ProdutoList != null)
            {
                ProdutoList.RefreshList();
            }
            this.Close();
        }

        public EditarProduto(Models.Produto produto)
        {
            this.produto = produto;

            this.Text = "Editar produto";
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
            this.txtName.Text = produto.Nome;
            this.txtName.Location = new System.Drawing.Point(80, 40);
            this.txtName.Size = new System.Drawing.Size(150, 20);

            this.lblPrice = new Label();
            this.lblPrice.Text = "Preço:";
            this.lblPrice.Location = new System.Drawing.Point(10, 70);
            this.lblPrice.Size = new System.Drawing.Size(50, 20);

            this.txtPrice = new TextBox();
            this.txtPrice.Text = produto.Preco.ToString();
            this.txtPrice.Location = new System.Drawing.Point(80, 70);
            this.txtPrice.Size = new System.Drawing.Size(150, 20);

            this.btnEdit = new Button();
            this.btnEdit.Text = "Salvar";
            this.btnEdit.Location = new System.Drawing.Point(80, 110);
            this.btnEdit.Size = new System.Drawing.Size(150, 35);
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnEdit);
        }
    }
}
