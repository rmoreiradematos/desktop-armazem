using Models;
using Controllers;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Views
{
  public class ListarAlmoxarifado : Form
  {
    private ListView listAlmoxarifado;
    public ListarAlmoxarifado()
    {
      InicializarComponentes();
      RefreshList();
    }

    private void InicializarComponentes()
    {
      listAlmoxarifado = new ListView
      {
        Size = new Size(605, 180),
        Location = new Point(50, 50),
        View = View.Details,
        FullRowSelect = true
      };

      listAlmoxarifado.Columns.Add("ID", 50);
      listAlmoxarifado.Columns.Add("Nome", 100);
      listAlmoxarifado.Columns[0].Width = 30;
      listAlmoxarifado.Columns[1].Width = 100;

      Button btnAdd = CriarBotao("Adicionar", new Point(50, 270), BtnAdd_Click);
      Button btnEdit = CriarBotao("Editar", new Point(170, 270), BtnEdit_Click);
      Button btnDelete = CriarBotao("Deletar", new Point(290, 270), BtnDelete_Click);
      Button btnClose = CriarBotao("Sair", new Point(550, 270), BtnExit_Click);

      Controls.AddRange(new Control[] { listAlmoxarifado, btnAdd, btnEdit, btnDelete, btnClose });

      Size = new Size(720, 370);
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Listar Almoxarifados";
    }

    private Button CriarBotao(string text, Point location, EventHandler clickEvent)
    {
      Button botao = new Button
      {
        Text = text,
        Size = new Size(100, 30),
        Location = location
      };
      botao.Click += clickEvent;
      return botao;
    }

    private void BtnAdd_Click(object sender, EventArgs e)
    {
      new CriarAlmoxarifado().ShowDialog();
      RefreshList();
    }

    private void BtnEdit_Click(object sender, EventArgs e)
    {
      try
      {
        Models.Almoxarifado almoxarifado = GetProdutoBySelected();
        var editarAlmoxarifadoView = new EditarAlmoxarifado(almoxarifado);
        if (editarAlmoxarifadoView.ShowDialog() == DialogResult.OK)
        {
          RefreshList();
          MessageBox.Show("Almoxarifado modificado com sucesso!");
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }

    private void BtnDelete_Click(object sender, EventArgs e)
    {
      try
      {
        Models.Almoxarifado almoxarifado = GetProdutoBySelected();
        DialogResult result = MessageBox.Show("Tem certeza que deseja deletar esse item?", "Confirmar exclusão", MessageBoxButtons.YesNo);
        if (result == DialogResult.Yes)
        {
          Controllers.Almoxarifado.DeletarAlmoxarifado(almoxarifado);
          RefreshList();
        }
      }
      catch (System.Exception err)
      {
        MessageBox.Show(err.Message);
      }
    }

    private void BtnExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void AddToListView(Models.Almoxarifado almoxarifado)
    {
      ListViewItem item = new ListViewItem(almoxarifado.Id.ToString());
      item.SubItems.Add(almoxarifado.Nome);
      listAlmoxarifado.Items.Add(item);
    }
    private void RefreshList()
    {
      listAlmoxarifado.Items.Clear();
      List<Models.Almoxarifado> almoxarifados = Controllers.Almoxarifado.ListarAlmoxarifados();

      foreach (Models.Almoxarifado almoxarifado in almoxarifados)
      {
        AddToListView(almoxarifado);
      }
    }

    private Models.Almoxarifado GetProdutoBySelected()
    {
      if (listAlmoxarifado.SelectedItems.Count > 0)
      {
        int selectedProduct = int.Parse(listAlmoxarifado.SelectedItems[0].Text);
        return Controllers.Almoxarifado.BuscarAlmoxarifado(selectedProduct);
      }
      else
      {
        throw new Exception("Por gentileza, selecione um item para prosseguir com a ação");
      }
    }
  }

}
