using Deportic.Services;
using System.Linq.Expressions;

namespace Deportic
{
    public partial class Form1 : Form
    {
        private readonly UsuarioService usuarioService;

        public Form1()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lblResultados.Text = "cargando...";
            try
            {
                var usuarios = usuarioService.ObtenerUsuarios();

                if (usuarios.Any())
                {
                    lblResultados.Text = string.Join(",", usuarios.Select(u => $"{u.Id}: {u.Name}"));
                }
                else
                {
                    lblResultados.Text = "no hay registros en la tabla de 'usuarios'.";
                }
            }
            catch (Exception ex)
            {
                lblResultados.Text = $"Error: {ex.Message}";
            }
        }
    }
}

