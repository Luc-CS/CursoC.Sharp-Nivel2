using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class PaginaInicio : Form
    {
        public PaginaInicio()
        {
            InitializeComponent();
        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MaxYMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MaxYMin.Visible = false;
            restaurar.Visible = true;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            MaxYMin.Visible = true;
            restaurar.Visible = false;
        }
        private void cargarPanelFormulario(object formhija)
        {
            if(this.panelMedio.Controls.Count > 0)//si tiene mas de algun control o formulario en este caso
            {
                this.panelMedio.Controls.RemoveAt(0);//se lo removemos totalmente a 0
                Form fh = formhija as Form;//aca convierte el objeto nombre, a un form
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelMedio.Controls.Add(fh);
                this.panelMedio.Tag = fh;
                fh.Show();
            }
            else
            {
                Form fh = formhija as Form;//aca convierte el objeto nombre, a un form
                fh.TopLevel = false;
                fh.Dock = DockStyle.Fill;
                this.panelMedio.Controls.Add(fh);
                this.panelMedio.Tag = fh;
                fh.Show();
            }
        }
        private void PaginaInicio_Load(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Form nuevo = new productos();
            cargarPanelFormulario(nuevo);
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            Form nuevo = new marcas();
            cargarPanelFormulario(nuevo);
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            Form nuevo = new categorias();
            cargarPanelFormulario(nuevo);
        }
    }
}
