using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void botonCalcular_Click(object sender, EventArgs e)
        {
            int resultado;
            try //esto es para que intente correr esto como intenta toma
            {
                resultado = calcular();
                lbResultado.Text = " = " + resultado;
            }
            
            catch (Exception ex) { //el catch con el objeto exception, captura ese error que hubo
                MessageBox.Show("Hubo un error al calcular.. consutla a tu dev..");
            }

            finally //al finlay no le importa si hubo error o no, se ejecuta igual. aca pones las instrucciones que necesitamos que si o si tiene que ejecutarse
            {
                //instrucciones...
                //operacion sensible...
            }

           // catch (DivideByZeroException ex2)
           // {
            //    MessageBox.Show("ERROR 0 NO SE PUEDE DIVIDIR");
            //}
            
            
            

        }

        private int calcular()
        {
            int a, b, r;
            try
            {
                a = int.Parse(txt1.Text);
                b = int.Parse(txt2.Text);
                r = a / b;
                return r;
            }
            catch (Exception ex)
            {

                throw ex;//esta palabra reserva es para devolver una execepcion, osea lanza la excepcion
            }
        }


    }
}
