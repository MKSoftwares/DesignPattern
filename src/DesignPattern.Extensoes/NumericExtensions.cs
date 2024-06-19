using System.Globalization;

namespace DesignPattern.Extensoes
{
    public static class NumericExtensions
    {
        /// <summary>Verifica se uma string contem apenas numeros. </summary>
        /// <param name="value">String a ser verificada</param>
        /// <returns>Retorna true se string conter apenas numeros.</returns>
        public static bool IsNumeric(this string value)
        {
            var inputValue = Convert.ToString(value);
            return double.TryParse(inputValue, NumberStyles.Any, null, out var dummy);
        }

        /// <summary>Converte uma string em número inteiro negativo ou não, de  16 bits (-32.768 a 32.767)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Inteiro de 16 bits com sinal (-32.768 a 32.767)</returns>
        public static short ToShort(this string value)
        {
            short.TryParse(value, out var resultado);
            return resultado;
        }

        /// <summary>Converte uma string em número inteiro negativo ou não, de 32 bits (-2.147.483.648 a 2.147.483.647)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Inteiro assinado de 32 bits (-2.147.483.648 a 2.147.483.647)</returns>
        public static int ToInt(this string value)
        {
            int.TryParse(value, out var resultado);
            return resultado;
        }

        /// <summary>Converte uma string em número inteiro negativo ou não, de 64 bits (-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Inteiro assinado de 64 bits (-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807)</returns>
        public static long ToLong(this string value)
        {
            long.TryParse(value, out var resultado);
            return resultado;
        }

        /// <summary>Converte uma string em número inteiro negativo ou não, de 64 bits (-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Inteiro assinado de 64 bits (-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807)</returns>
        public static long ToLong(this ulong value)
        {
            return (long)value;
        }

        /// <summary>Converte uma string em número inteiro positivo de 64 bits (9.223.372.036.854.775.807)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Inteiro assinado de 64 bits (9.223.372.036.854.775.807)</returns>
        public static ulong ToULong(this string value)
        {
            if (value.IsEmpty())
                return 0;

            ulong.TryParse(value, out var resultado);
            return resultado;
        }

        /// <summary>Converte uma string em número inteiro positivo de 64 bits (9.223.372.036.854.775.807)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Inteiro assinado de 64 bits (9.223.372.036.854.775.807)</returns>
        public static ulong ToULong(this long value)
        {
            return (ulong)value;
        }

        /// <summary>Converte uma string em número decimal negativo ou não, de 64 bits (-79.228.162.514.264.337.593.543.950.335 a 79.228.162.514.264.337.593.543.950.335)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Decial assinado (-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807)</returns>
        public static decimal ToDecimal(this object value)
        {
            decimal resultado = 0;
            if (value == null)
                return resultado;
            decimal.TryParse(value.ToString(), out resultado);
            return resultado;
        }

        /// <summary>Converte uma string em número decimal negativo ou não, de 64 bits (-79.228.162.514.264.337.593.543.950.335 a 79.228.162.514.264.337.593.543.950.335)</summary>
        /// <param name="value">Valor a ser convertido</param>
        /// <returns>Decial assinado (-9.223.372.036.854.775.808 a 9.223.372.036.854.775.807)</returns>
        public static decimal ToDecimal(this decimal? value)
        {
            if (value == null)
                return 0;

            return value.Value;
        }

        public static decimal RoundDecimal(this decimal value, int tamanho = 2)
        {
            int temp = 9;
            for (int i = 0; i < 9; i++)
            {
                temp--;
                if (temp > tamanho)
                    value = Math.Round(value, temp, MidpointRounding.AwayFromZero);
                else
                    break;
            }

            return Math.Round(value, tamanho, MidpointRounding.AwayFromZero);
        }

        public static double RoundDouble(this double value, int tamanho = 2)
        {
            int temp = 9;
            for (int i = 0; i < 9; i++)
            {
                temp--;
                if (temp > tamanho)
                    value = Math.Round(value, temp, MidpointRounding.AwayFromZero);
                else
                    break;
            }

            return Math.Round(value, tamanho, MidpointRounding.AwayFromZero);
        }

        public static double ToObjectDouble(this object value)
        {
            double resultado = 0;
            Double.TryParse(value.ToString(), out resultado);
            return resultado;
        }

        public static string ToCifraoReais(this decimal valor)
        {
            return String.Format(new CultureInfo("pt-BR"), "{0:c2}", valor);
        }
    }
}
