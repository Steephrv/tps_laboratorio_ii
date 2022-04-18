using System;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// valida si el operador es correcto y hace la operacion 
        /// </summary>
        /// <param name="num1">es del tipo Operando</param>
        /// <param name="num2">es del tipo Operando</param>
        /// <param name="operador"></param>
        /// <returns>retorna la operacion respectiva a cada caso</returns>
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double operacion;

            switch (ValidarOperador(operador))
            {
                case '+':
                    operacion = num1 + num2;
                    break;

                case '-':
                    operacion = num1 - num2;
                    break;

                case '*':
                    operacion = num1 * num2;
                    break;

                case '/':
                    operacion = num1 / num2;
                    break;

                default:
                    operacion = num1 + num2;
                    break;

            }
            return operacion;

        }
        /// <summary>
        /// Valida que el operando sea -, *, /
        /// </summary>
        /// <param name="operador"></param>
        /// <returns> retorna el operando o por defecto el +</returns>
        private static char ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '*' || operador == '/' || operador == '-')
            {
                return operador;
            }
            return '+';
        }
    }
}
