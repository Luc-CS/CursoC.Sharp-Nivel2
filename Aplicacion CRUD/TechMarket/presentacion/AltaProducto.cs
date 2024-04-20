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
    public partial class AltaProducto : Form
    {
        private Articulo art = null;
        private ArticuloNegocio articuloNegocio = new ArticuloNegocio();
        public AltaProducto()
        {
            InitializeComponent();
        }
        public AltaProducto(Articulo arti)
        {
            InitializeComponent();
            art = arti;

        }

        private void ImgAgregar_Click(object sender, EventArgs e)
        {

        }
        private bool validaciones()
        {
            if (!soloNumeros(txtPrecio.Text)) { return false; }
            if (!sinCaracterEspecial(txtCodigo.Text, 1)) { return false; }
            if (!sinCaracterEspecial(txtNombre.Text, 2)) { return false; }
            if (!camposVacios()) { return false; }




            return true;
        }
        private void cargarImagen(string img)
        {

            try
            {
                ImgAgregar.Load(img);

            }
            catch (Exception ex)
            {
                ImgAgregar.Load("https://static.vecteezy.com/system/resources/previews/005/723/771/non_2x/photo-album-icon-image-symbol-or-no-image-flat-design-on-a-white-background-vector.jpg");
            }

        }

        private void cambiarImagen(object sender, EventArgs e)
        {
            cargarImagen(txtImagen.Text);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool soloNumeros(string cadena)
        {


            foreach (char c in cadena)
            {
                if (!char.IsDigit(c) && !(c == ','))
                {
                    errorPrecio.Visible = true;
                    MessageBox.Show("SOLO DEBE INGRESAR NUMEROS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            errorPrecio.Visible = false;
            return true;
        }

        private bool camposVacios()
        {

            bool band = true;
            if (string.IsNullOrEmpty(txtPrecio.Text))
            {
                errorPrecio.Visible = true;

                band = false;

            }
            else
            {
                errorPrecio.Visible = false;


            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                errorNombre.Visible = true;

                band = false;
            }

            else
            {
                errorNombre.Visible = false;

            }

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                errorCodigo.Visible = true;
                band = false;

            }
            else
            {
                errorCodigo.Visible = false;
            }


            if (!band)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }

            return band;
        }
        private bool sinCaracterEspecial(string cadena, int lugar)
        {
            foreach (char s in cadena)
            {
                if (!char.IsLetterOrDigit(s) && !char.IsSeparator(s))
                {
                    if (lugar == 1)
                    {
                        errorCodigo.Visible = true;
                    }
                    else
                    {
                        errorNombre.Visible = true;
                    }


                    MessageBox.Show("SOLO DEBE INGRESAR NUMEROS O LETRAS", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;


                }
                else
                {
                    errorNombre.Visible = true;
                    errorCodigo.Visible = false;
                }
            }

            return true;

        }

        private void AltaProducto_Load(object sender, EventArgs e)
        {
            MarcaData marcaData = new MarcaData();
            CategoriaNegocio categoriaData = new CategoriaNegocio();
            try
            {


                cargarImagen("");
                cboMarca.DataSource = marcaData.listarMarcas();//le pasas todo el obj 
                cboCategoria.DataSource = categoriaData.listarCategorias();
                cboCategoria.ValueMember = "_Id";//CONFIGURAS CLAVE(id)-VALOR donde mostrar la descricion relacionada por id
                                                 //luego en la linea 74 le pasamos el id, entonces te va a mostrar la descripcion relacionada al id
                cboCategoria.DisplayMember = "_Descripcion";
                cboMarca.ValueMember = "_Id";
                cboMarca.DisplayMember = "_Descripcion";

                if (art != null)
                {
                    cboCategoria.SelectedValue = art.categoria._Id;
                    cboMarca.SelectedValue = art.marca._Id;
                    txtCodigo.Text = art.Codigo;
                    txtDescripcion.Text = art._Descripcion;
                    txtImagen.Text = art._imagenUrl;
                    cargarImagen(art._imagenUrl);
                    txtNombre.Text = art.Nombre;
                    txtPrecio.Text = art.Precio.ToString();

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaciones()) return;

                if (art == null) { art = new Articulo(); }


                art._Descripcion = txtDescripcion.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);

                if (txtImagen.Text != "")
                {
                    art._imagenUrl = txtImagen.Text;
                }
                else
                {
                    art._imagenUrl = null;
                }


                art.Nombre = txtNombre.Text;
                art.categoria = (Categoria)cboCategoria.SelectedItem;
                art.Codigo = txtCodigo.Text;
                art.marca = (Marca)cboMarca.SelectedItem;
                if (art._Id != 0)
                {
                    articuloNegocio.modificarArticulo(art);
                    MessageBox.Show("SE HA MODIFICADO EXITOSAMENTE", "PROCESO COMPLETADO");

                }
                else
                {
                    articuloNegocio.agregarArticulo(art);
                    MessageBox.Show("SE HA AGREGADO EXITOSAMENTE", "PROCESO COMPLETADO");
                }


                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
        }
    }
}
