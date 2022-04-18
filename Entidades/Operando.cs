using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        //ATRIBUTOS
        private double numero;

        //CONSTRUCTORES

        public Operando(double numero)
        {
            this.numero = numero;
        }
        public Operando() : this(0)
        { }
        public Operando(string strNumero)
        {
            this.numero = ValidarOperando(strNumero);
        }
        //PROPIEDADES
        public string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }


        //METODOS

        /// <summary>
        ///  Valida el operando que recibe, si el resultado es false , devuelve 0
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns> si el resultado es verdadero retorna el numero, si es flase retorna 0 </returns> 
        private double ValidarOperando(string strNumero)
        {
            double esNumero;
            bool resultado;

            resultado = Double.TryParse(strNumero, out esNumero);

            strNumero = strNumero.Replace('.', ',');

            if (resultado)
            {
                return esNumero;
            }

            return 0;

        }


        /// <summary>
        /// comprueba que el numero sea binario
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>retorna true o false</returns>
        private bool EsBinario(string binario)
        {
            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    return true;
                }

            }
            return false;
        }

        /// <summary>
        /// Si es posible connvierte a decimal el numero binario
        /// <param name="binario"> Recibe un numero a convertir, es de tipo string </param>
        /// <returns> retorna el numero decimal o el mensaje  </returns>
        public string BinarioDecimal(string binario)
        {
            string resultado;
            int numAEvaluar;
            int acumulador;
            int numDecimal = 0;

            if (EsBinario(binario))
            {
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    numAEvaluar = int.Parse(binario[i].ToString());
                    if (numAEvaluar != 0)
                    {
                        acumulador = (int)Math.Pow(2, binario.Length - 1 - i);

                    }
                    else
                    {
                        acumulador = 0;
                    }
                    numDecimal += acumulador;
                }
                resultado = numDecimal.ToString();
            }
            else
            {
                resultado = "Valor invalido";
            }

            return resultado;
        }

        /// <summary>
        /// Si es posible convierte el numero decimal a binario,
        /// </summary>
        /// <param name="numero"> Recibe un numero a convertir, es de tipo double </param>
        /// <returns> Devuelve el numero en decimal o  el mensaje   </returns>
        public string DecimalBinario(double numero)
        {
            string numBinario = string.Empty;
            int numeroDecimal;
            int resultado;

            numeroDecimal = Math.Abs((int)numero);

          
            if (numeroDecimal > 0)
            {
                while (numeroDecimal != 0)
                {
                    resultado = numeroDecimal % 2;
                    numeroDecimal /= 2;
                    numBinario = resultado.ToString() + numBinario;
                }
                
            }
            else
            {
                numBinario = "Valor Invalido";
            }

            return numBinario;
        }
        /// <summary>
        /// comprueba si se puede convertir  de decimal a binario en string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns> retorna el numero binario en string o mensaje </returns>
        public string DecimalBinario(string numero)
        {
            double binario;
            bool respuesta;

            respuesta = (Double.TryParse(numero, out binario));

            if (respuesta == false)
            {
                Console.WriteLine("Valor invalido");
            }
            return DecimalBinario(binario); ;
        }

        // OPERADORES

        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;
            if (n2.numero != 0)
            {
                resultado = n1.numero / n2.numero;
            }
            else
            {
                resultado = Double.MinValue;
            }
            return resultado;
        }

    }
}
