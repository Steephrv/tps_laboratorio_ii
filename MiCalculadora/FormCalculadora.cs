using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        ///     Carga los operadores y setea  el index del primero elemento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.Items.Add(" ");
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("/");
            cmbOperador.Items.Add("*");
            cmbOperador.SelectedIndex = 0;
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }
        /// <summary>
        /// Limpia o borra todos los elementos de la pantalla
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.lblResultado.Text = "";
            this.cmbOperador.SelectedIndex = this.cmbOperador.FindStringExact(" ");
            this.lstOperaciones.Items.Clear();
        }

        /// <summary>
        /// borra todo al dar click en el boton limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Cierra la aplicacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Recibe operandos y operador y usa la funcion operar de la clase calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns> retorna el resultado</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            Operando n1 = new Operando(numero1);
            Operando n2 = new Operando(numero2);
            char operadorChar = char.Parse(operador);
            double resultado = Calculadora.Operar(n1, n2, operadorChar);
            return resultado;
        }
        /// <summary>
        /// Corrobora que se ingresen los dos numeros y luego opera, de lo contrario tirara un mensaje de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string num1 = this.txtNumero1.Text;
            string num2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.GetItemText(this.cmbOperador.SelectedItem);

            if (string.IsNullOrEmpty(num1) || string.IsNullOrEmpty(num2))
            {
                MessageBox.Show("ERROR, Ingrese los dos numeros", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = false;
            }
            else
            {
                if (num2 == "0" && operador == "/")
                {
                    this.lblResultado.Text = "ERROR, no se puede dividir por 0";
                    this.btnConvertirABinario.Enabled = false;
                    this.btnConvertirADecimal.Enabled = false;
                }
                else
                {

                    double resultado = Operar(num1, num2, operador);
                    this.lblResultado.Text = resultado.ToString();
                    this.lstOperaciones.Items.Insert(0, $"{this.txtNumero1.Text} {operador} {this.txtNumero2.Text} = {resultado}");
                    this.btnConvertirABinario.Enabled = true;
                    this.btnConvertirADecimal.Enabled = true;
                }
            }  
        }
        /// <summary>
        /// Convierte el resultado de la operacion en numero binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != "")
            {
    
                string numeroStr = this.lblResultado.Text;
                
                if ((double.TryParse(numeroStr, out double numero) == true))
                {
                    Operando numeroABinario = new Operando();
                    
                    this.lblResultado.Text = numeroABinario.DecimalBinario(lblResultado.Text);
                    btnConvertirABinario.Enabled = false;
                    btnConvertirADecimal.Enabled = true;

                }
                else
                {
                    this.lblResultado.Text = "No se puede convertir";
                }
                
            }
        }

        /// <summary>
        /// Convierte el numero binario a numero decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero = this.lblResultado.Text;

            Operando numeroADecimal = new Operando();

            this.lblResultado.Text = numeroADecimal.BinarioDecimal(numero);

            btnConvertirABinario.Enabled = true;
            btnConvertirADecimal.Enabled = false;
        }

        /// <summary>
        /// Funcion que se llama al cerrar el formulario, pedira confirmacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro que desea salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
