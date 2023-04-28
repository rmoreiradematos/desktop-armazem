using System;
using System.Drawing;
using System.Windows.Forms;

namespace Views
{
    public class Menu : Form
    {
        public Menu()
        {
            this.Text = "Menu";
            this.Size = new Size(300, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            var btnProdutos = CreateButton("Produtos", 50, 70, 150, 50);
            btnProdutos.Click += BtnProdutos_Click;
            this.Controls.Add(btnProdutos);

            var btnAlmoxarifados = CreateButton("Almoxarifados", 120, 140, 150, 50);
            btnAlmoxarifados.Click += BtnAlmoxarifados_Click;
            this.Controls.Add(btnAlmoxarifados);

            var btnSaldos = CreateButton("Saldos", 120, 210, 150, 50);
            btnSaldos.Click += BtnSaldos_Click;
            this.Controls.Add(btnSaldos);

            var btnSair = CreateButton("Sair", 120, 280, 150, 50);
            btnSair.Click += BtnSair_Click;
            this.Controls.Add(btnSair);
        }

        private void BtnProdutos_Click(object sender, EventArgs e)
        {
            new ListarProduto().Show();
        }

        private void BtnAlmoxarifados_Click(object sender, EventArgs e)
        {
            new ListarAlmoxarifado().Show();
        }

        private void BtnSaldos_Click(object sender, EventArgs e)
        {
            new ListarSaldo().Show();
        }

        private void BtnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Button CreateButton(string text, int x, int y, int width, int height)
        {
            var button = new Button
            {
                Text = text,
                Size = new Size(width, height),
                Location = new Point(x, y),
            };
            return button;
        }
    }
}
