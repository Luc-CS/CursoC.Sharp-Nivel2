using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;


namespace DiscosPruebaADO
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null; // null porque para que en el otro constructor sea null, y el otro se pueda cargar
        private OpenFileDialog archivo = null;//
        public frmAltaPokemon()
        {
            InitializeComponent();
            Text = "Agregar Pokemon";
        }
        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";
        }

        private void botonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    //lbErrorNumero.Visible = true;
                    return false;
                }
            }
                //
            return true;
        }
        private bool soloLetras(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (char.IsNumber(caracter))
                {
                    return false;
                }
            }
            return true;
        }
        private bool verificarCampos()
        {
            bool verificador = false;
            //campo numero
            if(string.IsNullOrEmpty(textNumero.Text) || soloNumeros(textNumero.Text) == false)
            {
                lbErrorNumero.Visible = true;
                verificador = true;
            }
            else
            {
                lbErrorNumero.Visible = false;
            }
            //campo de nombre
            if(string.IsNullOrEmpty(textNombre.Text) || soloLetras(textNombre.Text) == false)
            {
                lbErrorNombre.Visible = true;
                verificador = true;
            }
            else { 
            
                lbErrorNombre.Visible= false;
            }
            //mensaje de error
            if (verificador == true)
            {
                lbErrorMensaje.Visible = true;
            }
            else if(lbErrorNombre.Visible == false && lbErrorNombre.Visible == false)
            {
                lbErrorNumero.Visible = false;

            }
            return verificador;
        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            
            PokemonNegocio negocio = new PokemonNegocio();

            if (verificarCampos() == false)
            {
                try
                {

                    if (pokemon == null)
                        pokemon = new Pokemon();

                    pokemon.Numero = int.Parse(textNumero.Text);
                    pokemon.Nombre = textNombre.Text;
                    pokemon.Descripcion = textDescripcion.Text;
                    pokemon.UrlImagen = textUrlImagen.Text;
                    pokemon.Tipo = (Elemento)cbTipo.SelectedItem;
                    pokemon.Debilidad = (Elemento)cbDebilidad.SelectedItem;

                    if (pokemon.Id != 0)
                    {
                        negocio.Modificar(pokemon);
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        negocio.Agregar(pokemon);
                        MessageBox.Show("Agregado exitosamente");
                    }
                    if (archivo != null && !(textUrlImagen.Text.ToUpper().Contains("HTTP")))//si arhicvo no esta null y el textoUrlImagen no tiene http significa que selecciono una imagen local
                    {
                        // guardo la imagen
                        //esto agregaria, imagen seleccionada a la carpeta deseada.
                        File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
                        //file es una clase static  || //el archivo.safefilename, es el nombre de archivo original
                        //cree una carpeta llamada: poke-app
                        //despues voy a , App.Config que es el archivo XML
                        //donde cree una instancia para la configuracion de mi App
                        //agregue una clave(key) que identifica la configuracion a la carpeta: images-folder y el value, donde deje la tuya de la carpeta donde se encuentra las imagenes
                        //ademas agregue la referencia: system.configurencion.
                    }
                    Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmAltaPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();

            try
            {
                cbTipo.DataSource = elementoNegocio.listar();//le cargo,lo que expulsa la lista que seria la descripcion
                cbTipo.ValueMember = "Id";//como el elemento clave
                cbTipo.DisplayMember = "Descripcion";
                cbDebilidad.DataSource = elementoNegocio.listar();
                cbDebilidad.ValueMember = "Id";
                cbDebilidad.DisplayMember = "Descripcion";

                if(pokemon != null)//es un modificar
                {
                    textNumero.Text = pokemon.Numero.ToString();
                    textNombre.Text = pokemon.Nombre;
                    textDescripcion.Text = pokemon.Descripcion;
                    textUrlImagen.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);

                    //con esto preselecciona los valores que eligas
                    cbTipo.SelectedValue = pokemon.Tipo.Id;
                    cbDebilidad.SelectedValue = pokemon.Debilidad.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            //hacemos pusimos un dropdownstyles downlist para que no se pueda escribir y solo elija algo de la lista
        }

        private void textUrlImagen_Leave(object sender, EventArgs e)
        {

            cargarImagen(textUrlImagen.Text);
  
        }
        private void cargarImagen(string imagen)//hicimos esto porque, si la url no funciona o no carga se rompia todo, asi que le cargamos imagen estandar
        {
            try
            {
                pbPokemon.Load(imagen);//(selecionado.UrlImagen)
            }
            catch (Exception ex)
            {
                pbPokemon.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");

            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();//esto es para abrir la ventana externa de abrir archivos, osea solicita al usario que abra un archivo

            archivo.Filter = "jpg|*.jpg;|png|*.png";//un filtro que debe incluir si o si para ser aceptado, .jpg al final del archivo
            //archivo.Filter = "png|*.png";
            if(archivo.ShowDialog() == DialogResult.OK)//si le di OK, a la seleccion de imagen, osea elije una imagen y acepta
            {
                textUrlImagen.Text = archivo.FileName; //esto le da el nombre y ruta del archivo, en este caso seria el url de la imagen
                cargarImagen(archivo.FileName);

             
            }
        }
    }
}
