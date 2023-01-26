/*

1. Si envio un string vacio debera retornar 0.
2. Si envio 2 numeros separados por coma debera retornar la suma de los mismos.
3. Si envio cualquier cantidad de numeros separados por coma debera retornar la suma de los mismos.
4. Si envio cualquier cantidad de numeros separados por cualquier delimitador debera retornarme la suma de los numeros.
5. Si envio numeros negativos debera retornarme una exception.
6. Si envio un caracter no valido como numero separado por coma debera retornar una exception.
7. Si envio numeros mayores a 100 debera no tenerlos en cuenta para la suma y solo tener en cuenta los positivos.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestCalculator
{
    internal class Calculator
    {
        public int Add (string numbers)
        {
            int result;

            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numeros = numbers.Split(',', ';', ':', '|', ' ');

            var numerosInvalidos = numeros.Where(num => !int.TryParse(num, out int numeroInvalido))
                                          .Any();

            if (numerosInvalidos)
            {
                throw new ArgumentException("Caracteres no validos");
            }

            var numerosNegativos = numeros.Select(int.Parse)
                                          .Where(num => num < 0)
                                          .Any();

            if (numerosNegativos)
            {
                throw new ArgumentException("No se pueden utilizar numeros negativos");
            }

            result = numeros.Select(int.Parse)
                            .Sum();

            return result;
        }
    }
}
