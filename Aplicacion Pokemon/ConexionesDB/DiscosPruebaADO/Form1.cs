using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace DiscosPruebaADO
{
    public partial class Form1 : Form
    {
        private List<Pokemon> listaPokemon;//puedo hacer esto porque es una clase el form
        private bool visibilidadFiltroAvanzado = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvDiscos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();//carga el formulario 

            //cargo  el cb campo
            cbCampo.Items.Add("Numero");
            cbCampo.Items.Add("Nombre");
            cbCampo.Items.Add("Descripcion");


        }
        private void cargar()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();//guardo la lista porque antes solo la mostraba directamente
                dgvDiscos.DataSource = negocio.listar();
                ocultarColumnas();
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvDiscos.Columns["UrlImagen"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
        }
        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)//es mejor un selectionChanged, porque con clink, en una misma celda recarga la imagen, cone ste  recarga la imagen cuando es una opcion diferente
        {
            if(dgvDiscos.CurrentRow != null)//hicimos este if, porque se rompia
            {
                Pokemon selecionado = (Pokemon)dgvDiscos.CurrentRow.DataBoundItem; //Aca es cuando selecciona la grilla quiero que me de el objeto enlazado
                cargarImagen(selecionado.UrlImagen);
            }
          

        }

        private void cargarImagen(string imagen)//hicimos esto porque, si la url no funciona o no carga se rompia todo, asi que le cargamos imagen estandar
        {
            try
            {
                picBoxPokemon.Load(imagen);//(selecionado.UrlImagen)
            }
            catch(Exception ex) {
                picBoxPokemon.Load("https://editorial.unc.edu.ar/wp-content/uploads/sites/33/2022/09/placeholder.png");
               
            }
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();
            cargar();
            
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            if (dgvDiscos.CurrentRow != null)
            {
                seleccionado = (Pokemon)dgvDiscos.CurrentRow.DataBoundItem;
                frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);//porque queresmos que sea igual pero con los datos cargados
                modificar.ShowDialog();
                cargar();
            }
            else
            {
                MessageBox.Show("Porfavor, seleccione un pokemon para modificar");
            }

        }

        private void btEliminarFisico_Click(object sender, EventArgs e)
        {
            PokemonNegocio eliminarFisico = new PokemonNegocio();
            Pokemon pokemon = new Pokemon();
            
            try
            {
                //un dialogresult para capturar lo que retorna el show
                //despues como veras hago una sobrecargar del messagebox.show(mensaje central,titulo,botones si o no,icono de warning);
                DialogResult respuesta = MessageBox.Show("¿Estas seguro de eliminar este elemento permanentemente?" , "Eliminando",MessageBoxButtons.YesNo , MessageBoxIcon.Warning);//vamos a capturar el return que tira esta funcion, el cual retorna un valor
                if (respuesta == DialogResult.Yes)
                {
                    pokemon = (Pokemon)dgvDiscos.CurrentRow.DataBoundItem;//agarramos el pokemon seleccionado en la grilla
                    eliminarFisico.eliminar(pokemon.Id);//le paso el id al cual va eliminar
                    cargar();//esto actualiza la grilla
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if (cbCampo.SelectedIndex < 0)//esto es como un vector, el cbcampo si esta en -1 significa que no tiene nada seleccionado
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }
            if (cbCriterio.SelectedIndex < 0)//esto es como un vector, el cbcampo si esta en -1 significa que no tiene nada seleccionado
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }
            
            if(cbCampo.SelectedItem.ToString() == "Numero")
            {
                if (string.IsNullOrEmpty(textFiltroAvanzado.Text))//esto es por la posibilidad si esta nulo
                {
                    MessageBox.Show("Debes cargar el filtro para numericos..");
                    return true;
                }
                    if (!(soloNumeros(textFiltroAvanzado.Text)))
                    {
                        MessageBox.Show("Porfavor, ingrese solo numeros.");
                        return true;
                    }
                
            }
            return false;
        }

        private bool soloNumeros (string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))//si el caracter, es numero retorna false y da a el validarfiltro,la advertencia.
                    return false;

            }
            return true;
        }

        private void botonFiltro_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if (validarFiltro())
                    return;
            
                string campo = cbCampo.SelectedItem.ToString();
                string criterio = cbCriterio.SelectedItem.ToString();
                string filtro = textFiltroAvanzado.Text;

                dgvDiscos.DataSource = negocio.filtrar(campo,criterio,filtro);

            }
                
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void textFiltro_TextChanged(object sender, EventArgs e)//esto es para que el filtro sea mas eficiente y no deba tocar el boton, si no que al escribir, ya este haciendo la busqueda
        {
            List<Pokemon> listaFiltrada;
            string filtro = textFiltro.Text;
            if (filtro.Length >=3/*filtro != ""*/)
            {
                //el findall, es como un filtro que devolveria todoss los elementos en ese filtro. guardamos todo lo que retorne a list filtrada
                //PARA BUSCAR LA PALABRA COMPLETA//listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper() == filtro.ToUpper());//a lo que esta en el  textFiltro devolveria lo que sea igual a ese texto, pensalo como un bucle que preguntaria siempre lo mismo, y devuelve si es verdad
                //el .ToUpper es para que todo este en Mayuscula, esto no se ve visualmente, pero es para que cunado busqueen en una letra minicusla, no afecte a la busqueda y lo encuentre igual.

                //aca ademas que haes que este todo en mayusculas,hacemos un contenedor de que esa palabra del filtro, este incluida en el contenedor es correcto
                //ademas que coincidan la descripcion del tipo de pokemon (pensa que es como un if el findall, por eso se puede usar un ||)
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaPokemon;
            }
            dgvDiscos.DataSource = null;//primero limpiamos 
            dgvDiscos.DataSource = listaFiltrada;//despues le damos la nueva lista
            ocultarColumnas();
        }

        private void cbCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cbCampo.SelectedItem.ToString();
            if(opcion == "Numero")
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Mayor a");
                cbCriterio.Items.Add("Menor a");
                cbCriterio.Items.Add("Igual a");
            }
            else
            {
                cbCriterio.Items.Clear();
                cbCriterio.Items.Add("Comienza con");
                cbCriterio.Items.Add("Termina con");
                cbCriterio.Items.Add("Contiene");
            }
        }

        private void btnMostrarFiltroAvanzado_Click(object sender, EventArgs e)
        {
            if (visibilidadFiltroAvanzado==false)
            { 
                lbCampo.Visible = true;
                lbCriterio.Visible = true;
                lbFiltroAvanzado.Visible = true;
                textFiltroAvanzado.Visible = true;
                cbCampo.Visible = true;
                cbCriterio.Visible = true;
                btnFiltroBuscar.Visible = true;

                visibilidadFiltroAvanzado = true;
            }
            else
            {
                lbCampo.Visible = false;
                lbCriterio.Visible = false;
                lbFiltroAvanzado.Visible = false;
                textFiltroAvanzado.Visible = false;
                cbCampo.Visible = false;
                cbCriterio.Visible = false;
                btnFiltroBuscar.Visible = false;

                visibilidadFiltroAvanzado=false;


            }
        }
    }
}
