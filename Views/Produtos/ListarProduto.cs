using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Controllers;

namespace Views
{
    public class ListarProduto : Form
    {
        private ListView listProducts;
        private ProdutoController produtoController = new ProdutoController();

        public ListarProduto()
        {
            InitializeComponent();
            RefreshList();
        }

        private void InitializeComponent()
        {
            this.listProducts = new ListView();
            this.SuspendLayout();

            // 
            // listProducts
            // 
            this.listProducts.Location = new System.Drawing.Point(50, 50);
            this.listProducts.Size = new System.Drawing.Size(605, 180);
            this.listProducts.View = View.Details;
            this.listProducts.Columns.Add("ID", 50);
            this.listProducts.Columns.Add("Nome", 100);
            this.listProducts.Columns.Add("Preço", 100);
            this.listProducts.Columns[0].Width = 30;
            this.listProducts.Columns[1].Width = 100;
            this.listProducts.Columns[2].Width = 80;
            this.listProducts.FullRowSelect = true;

            // 
            // ListarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 370);
            this.Controls.Add(this.listProducts);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Listar Produtos";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            Button btnAdd = new Button();
            btnAdd.Text = "Adicionar";
            btnAdd.Size = new Size(100, 30);
            btnAdd.Location = new Point(50, 270);
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button();
            btnEdit.Text = "Editar";
            btnEdit.Size = new Size(100, 30);
            btnEdit.Location = new Point(170, 270);
            btnEdit.Click += new EventHandler(btnEdit_Click);
            this.Controls.Add(btnEdit);

            Button btnDelete = new Button();
            btnDelete.Text = "Deletar";
            btnDelete.Size = new Size(100, 30);
            btnDelete.Location = new Point(290, 270);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            this.Controls.Add(btnDelete);

            Button btnClose = new Button();
            btnClose.Text = "Sair";
            btnClose.Size = new Size(100, 30);
            btnClose.Location = new Point(550, 270);
            btnClose.Click += new EventHandler(btnExit_Click);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new CriarProduto().ShowDialog();
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Produto produto = GetProdutoBySelected();
                var editarProdutoView = new EditarProduto(produto);
                if (editarProdutoView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Produto modificado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Models.Produto produto = GetProdutoBySelected();
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse item?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result ==DialogResult.Yes)
                {
                    produtoController.DeletarProduto(produto);
                    RefreshList();
                }
            }
            catch (System.Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void AddToListView(Models.Produto produto)
        {
            ListViewItem item = new ListViewItem(produto.Id.ToString());
            item.SubItems.Add(produto.Nome);
            item.SubItems.Add(produto.Preco.ToString());
            listProducts.Items.Add(item);
        }

        public void RefreshList()
        {
            listProducts.Items.Clear();

            List<Models.Produto> produtos = produtoController.ListarProdutos();

            foreach (Models.Produto produto in produtos)
            {
                AddToListView(produto);
            }
        }

        public Models.Produto GetProdutoBySelected()
        {
            if (listProducts.SelectedItems.Count > 0)
            {
                int selectedProduct = int.Parse(listProducts.SelectedItems[0].Text);
                return produtoController.BuscarProduto(selectedProduct);
            }
            else
            {
                throw new Exception("Por gentileza, selecione um item para prosseguir com a ação");
            }
        }
    }
}
