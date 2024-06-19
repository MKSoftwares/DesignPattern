using DesignPattern.Extensoes.Enums;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DesignPattern.Extensoes
{
    public static class StringExtensions
    {
        /// <summary>
        /// Retorna apenas os números contidos em uma string
        /// </summary>
        public static string SoNumero(this string campo)
        {
            return SoNumero(campo, false, false);
        }

        /// <summary>
        /// Retorna apenas os números contidos em uma string
        /// </summary>
        /// <param name="campo">String a ser processada</param>
        /// <param name="permiteVirgula">Se irá permitir virgulas ou não</param>
        /// <returns></returns>
        public static string SoNumero(this string campo, bool permiteVirgula)
        {
            return SoNumero(campo, permiteVirgula, false);
        }

        public static bool IsNullOrEmpty<TObject>(this IEnumerable<TObject> enumerable)
        {
            return !(enumerable?.Any() ?? false);
        }

        /// <summary>
        /// Retorna apenas os números contidos em uma string
        /// </summary>
        /// <param name="campo">String a ser processada</param>
        /// <param name="permiteVirgula">Se irá permitir virgulas ou não</param>
        /// <param name="podeNegativo">Se irá retornar o simbolo de negativo '-' caso exista</param>
        /// <returns></returns>
        public static string SoNumero(this string campo, bool permiteVirgula, bool podeNegativo)
        {
            var vaPosicao = 1;
            var vaResultado = string.Empty;

            if (campo == null)
                return "";

            while (vaPosicao <= campo.Length)
            {
                var vaCaracter = campo.Substring(vaPosicao - 1, 1);
                if ((permiteVirgula) | (podeNegativo))
                {
                    if (vaCaracter.IsNumeric())
                        vaResultado += vaCaracter;
                }
                else
                {
                    if (vaCaracter.IsNumeric())
                        vaResultado += vaCaracter;
                }
                vaPosicao++;
            }

            return vaResultado;
        }

        public static bool ValidadeCnpj(this string value)
        {
            var multiplicador1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var multiplicador2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            value = value.Trim();

            value = value.Replace(".", "").Replace("-", "").Replace("/", "");

            if (value.Length != 14)
                return false;

            var tempCnpj = value.Substring(0, 12);

            var soma = 0;

            for (var i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            var digito = resto.ToString();

            tempCnpj += digito;

            soma = 0;

            for (var i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto;

            return value.EndsWith(digito);
        }

        public static bool ValidadeCpf(this string value)
        {
            var totalDigitoI = 0;
            var totalDigitoIi = 0;
            // Limpa o CPF
            var clearCPF = value.Trim();
            clearCPF = clearCPF.Replace("-", ""); // Remove Separador de Dígito Verificador
            clearCPF = clearCPF.Replace(".", ""); // Remove os Separadores das Casas
                                                  // Verifica o Tamanho do Texto de Input
            if (clearCPF.Length != 11)
            {
                return false;
            }

            // Verifica os Patterns mais Comuns para CPF's Inválidos
            if (clearCPF.Equals("00000000000") ||
                clearCPF.Equals("11111111111") ||
                clearCPF.Equals("22222222222") ||
                clearCPF.Equals("33333333333") ||
                clearCPF.Equals("44444444444") ||
                clearCPF.Equals("55555555555") ||
                clearCPF.Equals("66666666666") ||
                clearCPF.Equals("77777777777") ||
                clearCPF.Equals("88888888888") ||
                clearCPF.Equals("99999999999"))
            {
                return false;
            }

            // Verifica se no Array Existe Apenas Números
            foreach (var c in clearCPF)
            {
                if (!char.IsNumber(c))
                {
                    return false;
                }
            }

            // Converte o CPF em Array Numérico para Validar
            var cpfArray = new int[11];
            for (var i = 0; i < clearCPF.Length; i++)
            {
                cpfArray[i] = int.Parse(clearCPF[i].ToString());
            }

            // Computa os Totais para os 2 Dígitos Verificadores
            for (var position = 0; position < cpfArray.Length - 2; position++)
            {
                totalDigitoI += cpfArray[position] * (10 - position);
                totalDigitoIi += cpfArray[position] * (11 - position);
            }

            // Aplica Regras do Dígito 1
            var modI = totalDigitoI % 11;
            if (modI < 2)
            {
                modI = 0;
            }
            else
            {
                modI = 11 - modI;
            }

            // Verifica o Digito 1
            if (cpfArray[9] != modI)
            {
                return false;
            }

            // Aplica o Peso para o Digito Verificador 2
            totalDigitoIi += modI * 2;
            // Aplica Regras do Dígito Verificador 2
            var modII = totalDigitoIi % 11;
            if (modII < 2)
            {
                modII = 0;
            }
            else
            {
                modII = 11 - modII;
            }

            // Verifica o Digito 2
            if (cpfArray[10] != modII)
            {
                return false;
            }

            // CPF Válido!
            return true;
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string LimparTexto(this string strTexto)
        {
            strTexto = Regex.Replace(strTexto, "[ÁÀÂÃ]", "A");
            strTexto = Regex.Replace(strTexto, "[ÉÈÊ]", "E");
            strTexto = Regex.Replace(strTexto, "[Í]", "I");
            strTexto = Regex.Replace(strTexto, "[ÓÒÔÕ]", "O");
            strTexto = Regex.Replace(strTexto, "[ÚÙÛÜ]", "U");
            strTexto = Regex.Replace(strTexto, "[Ç]", "C");
            strTexto = Regex.Replace(strTexto, "[áàâã]", "a");
            strTexto = Regex.Replace(strTexto, "[éèê]", "e");
            strTexto = Regex.Replace(strTexto, "[í]", "i");
            strTexto = Regex.Replace(strTexto, "[óòôõ]", "o");
            strTexto = Regex.Replace(strTexto, "[úùûü]", "u");
            strTexto = Regex.Replace(strTexto, "[ç]", "c");
            strTexto = Regex.Replace(strTexto, "[��]", "_");
            return Regex.Replace(strTexto, @"[,%'*]", "").Trim();
        }

        public static string PadLeftT<T>(this T value, int length, char padChar = '0', bool decimalFormat = false) where T : IConvertible
        {
            Type type = value.GetType();
            if (type == typeof(short) || type == typeof(int) || type == typeof(long))
            {
                return value.ToString(CultureInfo.CurrentCulture).PadLeft(length, padChar);
            }
            else if (type == typeof(decimal))
            {
                decimal valueDecimal;
                if (decimalFormat == true)
                {
                    valueDecimal = value.ToDecimal(CultureInfo.InvariantCulture.NumberFormat);
                    return valueDecimal.ToString().PadLeft(length, padChar);
                }
                else
                {
                    valueDecimal = value.ToDecimal(CultureInfo.InvariantCulture.NumberFormat) * 100;
                    return ((long)valueDecimal).ToString().PadLeft(length, padChar);
                }
            }
            else
            {
                return value.ToString().PadLeft(length, padChar);
            }
        }
        //_______________________________________________________________________________________________________________________________________________________________________________
        public static string PadRightT<T>(this T value, int length, char padChar = ' ')
        {
            return value.ToString().PadRight(length, padChar);
        }

        public static string LimitarComprimento(this string valor, int comprimentoMaximo)
        {
            return valor.Length > comprimentoMaximo ? valor.Substring(0, comprimentoMaximo) : valor;
        }

        public static string? LimitarComprimentoPossivelNulo(this string? valor, int comprimentoMaximo)
        {
            if (valor == null)
                return null;

            return valor.Length > comprimentoMaximo ? valor.Substring(0, comprimentoMaximo) : valor;
        }

        public static string CompletaCasas(this string valor, int casas, ETipoAlinha alinharA = ETipoAlinha.Esquerdo, char caracter = ' ')
        {
            //' ' = Char
            //" " = String

            var result = valor;

            if (valor == null)
                valor = "";

            if (valor.Length >= casas)
            {
                result = valor.Substring(0, casas);
            }
            else
            {
                switch (alinharA)
                {
                    case ETipoAlinha.Direito:
                        if (valor.Length >= casas)
                        {
                            result = valor.Substring(0, casas);
                        }
                        else
                        {
                            result = valor.PadLeft(casas, caracter);
                        }
                        break;

                    case ETipoAlinha.Esquerdo:
                        if (valor.Length <= casas)
                        {
                            result = valor.PadRight(casas, caracter);
                        }
                        break;

                    case ETipoAlinha.Centro:
                        var temp = casas - valor.Length;
                        if (temp > 0)
                        {
                            temp = Convert.ToInt32(temp / 2);
                        } //pega a parte inteira da divisão

                        if (temp > 0)
                        {
                            result = valor.PadLeft(temp + valor.Length, caracter);
                        }
                        break;
                }
            }
            return result;
        }
    }
}
