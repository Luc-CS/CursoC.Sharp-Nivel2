using dominio;
using negocio;
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
    public partial class productos : Form
    {
        private List<Articulo> articulosLista;
        private ArticuloNegocio articuloData = new ArticuloNegocio();

        private int cantClicksFiltro = 0;
        private int cantClickDetalles = 0;
        public productos()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            try
            {
                articulosLista = articuloData.ListarArticulos();
                dgvProductos.DataSource = articulosLista;
                ocultarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        private bool soloNumeros(string cadena)
        {


            foreach (char c in cadena)
            {
                if (c == ',')
                {
                    cadena = cadena.Replace(',', '.');


                }
                if (!char.IsDigit(c) && !(c == ','))
                {

                    lbFiltro.ForeColor = Color.Red;
                    MessageBox.Show("SOLO DEBE INGRESAR NUMEROS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            lbFiltro.ForeColor = Color.Black;
            return true;
        }
        private bool sinCaracterEspecial(string cadena)
        {
            foreach (char s in cadena)
            {
                if (!char.IsLetterOrDigit(s))
                {

                    lbFiltro.ForeColor = Color.Red;

                    MessageBox.Show("SOLO DEBE INGRESAR NUMEROS Y LETRAS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;


                }
                else
                {
                    lbFiltro.ForeColor = Color.Black;
                }

            }

            return true;

        }
        private bool camposVacios()
        {
            bool band = true;
            if (cboCampo.SelectedIndex == -1)//CAMPO
            {
                lbCampo.ForeColor = Color.Red;
                band = false;
            }
            else { lbCampo.ForeColor = Color.Black; }

            if (cboCriterio.SelectedIndex == -1)
            {
                lbCriterio.ForeColor = Color.Red;
                band = false;
            }
            else { lbCriterio.ForeColor = Color.Black; }


            if (string.IsNullOrEmpty(txtFiltro.Text) && !(cboCampo.SelectedIndex == 2 || cboCampo.SelectedIndex == 3))
            {

                lbFiltro.ForeColor = Color.Red;

                band = false;
            }
            else
            {
                lbFiltro.ForeColor = Color.Black;
            }

            if (band == false)
            {
                MessageBox.Show("COMPLETE LOS CAMPOS EN ROJO", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool validar()

        {

            if (!camposVacios()) { return false; }




            if (cboCampo.SelectedIndex == 1 && !soloNumeros(txtFiltro.Text))
            {
                return false;
            }

            if ((cboCampo.SelectedIndex == 0 || cboCampo.SelectedIndex == 4) && !(sinCaracterEspecial(txtFiltro.Text)))
            {
                return false;
            }







            return true;

        }

        private string cambiarPuntoPorComa(string cadena)
        {

            foreach (char c in cadena)
            {
                if (c == ',')
                {
                    cadena = cadena.Replace(',', '.');


                }

            }
            return cadena;
        }
        private void ocultarColumnas()
        {
            dgvProductos.Columns["_id"].Visible = false;
            dgvProductos.Columns["_imagenUrl"].Visible = false;
            dgvProductos.Columns["Codigo"].Visible = false;
            dgvProductos.Columns["categoria"].Visible = false;


        }

        private void cargarImagen(string img)
        {

            try
            {
                imagenArt.Load(img);

            }
            catch (Exception ex)
            {
                imagenArt.Load("https://static.vecteezy.com/system/resources/previews/005/723/771/non_2x/photo-album-icon-image-symbol-or-no-image-flat-design-on-a-white-background-vector.jpg");
            }

        }

        private void productos_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("NOMBRE");
            cboCampo.Items.Add("PRECIO");
            cboCampo.Items.Add("CATEGORIA");
            cboCampo.Items.Add("MARCA");
            cboCampo.Items.Add("CODIGO");
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (cantClicksFiltro == 1)
            {

                cambiarVisibilidad(false, 1);
                cambiarVisibilidad(true, 2);
                cargar();
                btnFiltrar.BackColor = Color.White;
                cantClicksFiltro--;



            }
            else
            {
                btnFiltrar.BackColor = Color.PaleTurquoise;
                cambiarVisibilidad(true, 1);
                cantClicksFiltro++;


            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow != null && dgvProductos.CurrentRow.DataBoundItem != null)
            {
                Articulo artaux = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
                cargarImagen(artaux._imagenUrl);
                lblCodArtRsp.Text = artaux.Codigo.ToUpper();
                lblcategoriaRsp.Text = artaux.categoria._Descripcion.ToUpper();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaProducto alta = new AltaProducto();
            alta.ShowDialog();
            cargar();
        }

        private void btnDetalleArticulo_Click(object sender, EventArgs e)
        {
            if (cantClickDetalles == 1)
            {
                cambiarVisibilidad(false, 0);
                btnDetalleArticulo.BackColor = Color.White;
                cantClickDetalles--;
            }
            else
            {

                cambiarVisibilidad(true, 0);

                btnDetalleArticulo.BackColor = Color.PaleTurquoise;

                cantClickDetalles++;
            }
        }

        private void cambiarVisibilidad(bool estado, int lugar)
        {

            if (lugar == 0)
            {
                
                lbCategoria.Visible = estado;
                lbCodigo.Visible = estado;
                lblcategoriaRsp.Visible = estado;
                lblCodArtRsp.Visible = estado;
            }
            else if (lugar == 1)
            {
                btnBuscar.Visible = estado;
                cboCampo.Visible = estado;
                cboCriterio.Visible = estado;
                txtFiltro.Visible = estado;
                lbCampo.Visible = estado;
                lbCriterio.Visible = estado;
                lbFiltro.Visible = estado;

            }
            else if (lugar == 2)
            {
                btnModificar.Enabled = estado;
                btnDetalleArticulo.Enabled = estado;
                btnEliminar.Enabled = estado;
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo art = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
            AltaProducto formSecundario = new AltaProducto(art);
            formSecundario.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult respuesta = MessageBox.Show("¿Estas seguro de esto?", "ELIMINAR ARTICULO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (respuesta == DialogResult.Yes)
            {
                Articulo art = (Articulo)dgvProductos.CurrentRow.DataBoundItem;
                articuloData.EliminarArticulo(art._Id);

            }
            cargar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validar()) return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = cambiarPuntoPorComa(txtFiltro.Text);
                //REALICE ESTA METODO PORQUE A LA HORA DE MANDAR LA CONSULTA NO ME ACEPTABA LA COMA.
                //PERO CUANDO AGREGABA UN ARTICULO NO ME TOMABA LA COMA PERO SI EL PUNTO , ENTONCES OPTE 
                //POR INTERCAMBIAR LA , POR EL .


                dgvProductos.DataSource = articuloData.BuscadaFiltrada(campo, criterio, filtro);


                if (dgvProductos.Rows.Count == 0)
                {

                    cambiarVisibilidad(false, 2);
                }
                else
                {
                    cambiarVisibilidad(true, 2);
                }




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboCampo.Text)
                {

                    case "MARCA":

                        cboCriterio.DataSource = null;
                        cboCriterio.Items.Clear();
                        MarcaData marcaData = new MarcaData();
                        cboCriterio.DataSource = marcaData.listarMarcas();

                        txtFiltro.Enabled = false;
                        lbFiltro.Enabled = false;



                        break;

                    case "NOMBRE":
                        cboCriterio.DataSource = null;
                        cboCriterio.Items.Clear();
                        cboCriterio.Items.Add("COMIENZA CON");
                        cboCriterio.Items.Add("TERMINA CON");
                        cboCriterio.Items.Add("CONTIENE");
                        txtFiltro.Enabled = true;
                        lbFiltro.Enabled = true;

                        break;


                    case "PRECIO":
                        cboCriterio.DataSource = null;
                        cboCriterio.Items.Clear();
                        cboCriterio.Items.Add("MAYOR A");
                        cboCriterio.Items.Add("MENOR A");
                        cboCriterio.Items.Add("IGUAL A");
                        txtFiltro.Enabled = true;
                        lbFiltro.Enabled = true;

                        break;


                    case "CATEGORIA":
                        cboCriterio.DataSource = null;
                        cboCriterio.Items.Clear();
                        CategoriaNegocio categoriaData = new CategoriaNegocio();
                        cboCriterio.DataSource = categoriaData.listarCategorias();
                        txtFiltro.Enabled = false;
                        lbFiltro.Enabled = false;


                        break;


                    case "CODIGO":

                        cboCriterio.DataSource = null;
                        cboCriterio.Items.Clear();
                        cboCriterio.Items.Add("COMIENZA CON");
                        cboCriterio.Items.Add("TERMINA CON");
                        cboCriterio.Items.Add("CONTIENE");
                        txtFiltro.Enabled = true;
                        lbFiltro.Enabled = true;

                        break;

                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
        }
    }
}
