using Models;
using Controllers;

namespace Views
{
  public class ListarSaldo : Form
  {
    private ListView listSaldos;
    private Button btnAdd;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnClose;

    public ListarSaldo()
    {
      this.Text = "Listar Saldos";
      this.Size = new Size(720, 370);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.listSaldos = new ListView();
      this.listSaldos.Size = new Size(605, 180);
      this.listSaldos.Location = new Point(50, 50);
      this.listSaldos.View = View.Details;
      this.listSaldos.FullRowSelect = true;
      this.listSaldos.Columns.AddRange(new ColumnHeader[]
      {
                new ColumnHeader{ Text = "ID", Width = 30 },
                new ColumnHeader{ Text = "Produto", Width = 100 },
                new ColumnHeader{ Text = "Almoxarifado", Width = 100 },
                new ColumnHeader{ Text = "Quantidade", Width = 100 }
      });
      this.Controls.Add(this.listSaldos);

      this.btnAdd = new Button
      {
        Text = "Adicionar",
        Size = new Size(100, 30),
        Location = new Point(50, 270)
      };
      this.btnAdd.Click += new EventHandler(btnAdd_Click);
      this.Controls.Add(this.btnAdd);

      this.btnEdit = new Button
      {
        Text = "Editar",
        Size = new Size(100, 30),
        Location = new Point(170, 270)
      };
      this.btnEdit.Click += new EventHandler(btnEdit_Click);
      this.Controls.Add(this.btnEdit);

      this.btnDelete = new Button
      {
        Text = "Deletar",
        Size = new Size(100, 30),
        Location = new Point(290, 270)
      };
      this.btnDelete.Click += new EventHandler(btnDelete_Click);
      this.Controls.Add(this.btnDelete);

      this.btnClose = new Button
      {
        Text = "Sair",
        Size = new Size(100, 30),
        Location = new Point(550, 270)
      };
      this.btnClose.Click += new EventHandler(btnExit_Click);
      this.Controls.Add(this.btnClose);

      RefreshList();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
      new CriarSaldo().ShowDialog();
      RefreshList();
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
      try
      {
        Models.Saldo saldo = GetSelectedSaldo();
        var editarSaldoView = new Views.EditarSaldo(saldo);
        if (editarSaldoView.ShowDialog() == DialogResult.OK)
        {
          RefreshList();
          MessageBox.Show("Saldo modificado com sucesso!");
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
        Models.Saldo saldo = GetSelectedSaldo();
        DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse item?", "Confirmar exclusão", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
          Controllers.Saldo.DeletarSaldo(saldo);
          RefreshList();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void btnExit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    public void AddToListView(Models.Saldo saldo)
    {
      Models.Produto nameProduto = Controllers.Produto.BuscarProduto(saldo.IdProduto);
      Models.Almoxarifado nameAlmoxarifado = Controllers.Almoxarifado.BuscarAlmoxarifado(saldo.IdAlmoxarifado);

      string[] row = {
            saldo.Id.ToString(),
            nameProduto.Nome,
            nameAlmoxarifado.Nome,
            saldo.Quantidade.ToString()
        };
      ListViewItem item = new ListViewItem(row);
      listSaldos.Items.Add(item);
    }
    public void RefreshList()
    {
      listSaldos.Items.Clear();
      List<Models.Saldo> saldos = Controllers.Saldo.ListarSaldos();

      foreach (Models.Saldo saldo in saldos)
      {
        AddToListView(saldo);
      }
    }

    public Models.Saldo GetProdutoBySelected()
    {
      if (listSaldos.SelectedItems.Count > 0)
      {
        int selectedProduct = int.Parse(listSaldos.SelectedItems[0].Text);
        return Controllers.Saldo.BuscarSaldo(selectedProduct);
      }
      else
      {
        throw new Exception("Por gentileza, selecione um item para prosseguir com a ação");
      }
    }
  }
}
