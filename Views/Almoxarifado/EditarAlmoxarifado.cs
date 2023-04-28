using Models;
using Controllers;

namespace Views
{
    public class EditarAlmoxarifado : Form
    {
        private readonly Almoxarifado almoxarifado;
        private readonly Label labelNome;
        private readonly TextBox textBoxNome;
        private readonly Button buttonSalvar;

        public EditarAlmoxarifado(Almoxarifado almoxarifado)
        {
            this.almoxarifado = almoxarifado;

            Text = "Editar almoxarifado";
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            Size = new System.Drawing.Size(280, 220);

            labelNome = new Label
            {
                Text = "Nome:",
                Location = new System.Drawing.Point(10, 40),
                Size = new System.Drawing.Size(50, 20)
            };

            textBoxNome = new TextBox
            {
                Text = almoxarifado.Nome,
                Location = new System.Drawing.Point(80, 40),
                Size = new System.Drawing.Size(150, 20)
            };

            buttonSalvar = new Button
            {
                Text = "Salvar",
                Location = new System.Drawing.Point(80, 110),
                Size = new System.Drawing.Size(150, 35)
            };
            buttonSalvar.Click += ButtonSalvar_Click;

            Controls.AddRange(new Control[]
            {
                labelNome, textBoxNome, buttonSalvar
            });
        }

        private void AtualizarAlmoxarifado()
        {
            almoxarifado.Nome = textBoxNome.Text;
            AlmoxarifadoController.AtualizarAlmoxarifado(almoxarifado);
            MessageBox.Show("O almoxarifado foi alterado com sucesso!");
        }

        private void FecharFormulario()
        {
            var listarAlmoxarifado = Application.OpenForms.OfType<ListarAlmoxarifado>().FirstOrDefault();
            listarAlmoxarifado?.RefreshList();
            Close();
        }

        private void ButtonSalvar_Click(object sender, EventArgs e)
        {
            AtualizarAlmoxarifado();
            FecharFormulario();
        }
    }
}
