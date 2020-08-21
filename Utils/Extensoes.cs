using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class Extensoes
    {
        public static string SoNumero(this object valor)
        {
            if (valor == null)
                return string.Empty;
            string ret = string.Empty;
            foreach (char c in valor.ToString().ToCharArray())
                if (char.IsNumber(c))
                    ret += c;
            return ret;
        }

        public static bool IsDateTime(this object valor)
        {
            try
            {
                Convert.ToDateTime(valor);
                return true;
            }catch { return false; }
        }

        public static string ConvertBinary(this object valor)
        {
            if (valor == null)
                return string.Empty;
            else if (string.IsNullOrEmpty(valor.ToString()))
                return string.Empty;
            else
            {
                char[] vetor = valor.ToString().ToCharArray();
                string retorno = string.Empty;
                foreach (char c in vetor)
                    retorno += Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0');
                return retorno;
            }
        }

        public static string ConvertHexaDecimal(this string valor)
        {
            if (valor == null)
                return string.Empty;
            else
            {
                char[] values = valor.ToCharArray();
                string hexa = string.Empty;
                foreach (char c in values)
                {
                    int value = Convert.ToInt32(c);
                    hexa += String.Format("{0:X}", value);
                }
                return hexa;
            }
        }

        public static byte[] ToByteArray(this string valor)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(valor);
        }

        public static int? ConvertDecimal(this object valor)
        {
            if (valor == null)
                return null;
            else if (string.IsNullOrEmpty(valor.ToString()))
                return null;
            else return Convert.ToInt32(Convert.ToString(Convert.ToInt32(valor.ToString(), 2), 10));
        }

        public static bool NumeroPar(this int valor)
        {
            return (valor % 2).Equals(0);
        }

        public static bool Multiplo10(this int valor)
        {
            return (valor % 10).Equals(0);
        }

        public static bool NumeroImpar(this int valor)
        {
            return !(valor % 2).Equals(0);
        }

        public static string FormatStringDireita(this object valor, int Tamanho, char Caracter)
        {
            if (valor == null)
                return string.Empty;
            if (valor.ToString().Length.Equals(Tamanho))
                return valor.ToString();
            else if (valor.ToString().Length > Tamanho)
                return valor.ToString().Substring(0, Tamanho);
            else
                return valor.ToString().PadRight(Tamanho, Caracter);
        }

        public static string FormatStringEsquerda(this object valor, int tamanho, char caracter)
        {
            if (valor == null)
                return string.Empty;
            if (valor.ToString().Length.Equals(tamanho))
                return valor.ToString();
            else if (valor.ToString().Length > tamanho)
                return valor.ToString().Substring(valor.ToString().Length - tamanho, tamanho);
            else
                return valor.ToString().PadLeft(tamanho, caracter);
        }

        public static string SeparadorDiretorio(this object valor)
        {
            if (valor == null)
                return string.Empty;
            if (valor.ToString().EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                return valor.ToString();
            else
                return valor.ToString() + System.IO.Path.DirectorySeparatorChar.ToString();
        }

        public static string RemoverCaracteres(this object valor)
        {
            if (valor == null)
                return string.Empty;
            string retorno = valor.ToString();
            //Remover acentos do (a) minusculo
            retorno = Regex.Replace(retorno, "[äáâàã]", "a");
            //Remover acentos do (A) maiusculo
            retorno = Regex.Replace(retorno, "[ÄÅÁÂÀÃ]", "A");
            //Remover acentos do (e) minusculo
            retorno = Regex.Replace(retorno, "[éêëè]", "e");
            //Remover acentos do (E) maiusculo
            retorno = Regex.Replace(retorno, "[ÉÊËÈ]", "E");
            //Remover acentos do (i) minusculo
            retorno = Regex.Replace(retorno, "[íîïì]", "i");
            //Remover acentos do (I) maiusculo
            retorno = Regex.Replace(retorno, "[ÍÎÏÌ]", "I");
            //Remover acentos do (o) minusculo
            retorno = Regex.Replace(retorno, "[öóôòõ]", "o");
            //Remover acentos do (O) maiusculo
            retorno = Regex.Replace(retorno, "[ÖÓÔÒÕ]", "O");
            //Remover acentos do (u) minusculo
            retorno = Regex.Replace(retorno, "[üúûù]", "u");
            //Remover acentos do (U) maiusculo
            retorno = Regex.Replace(retorno, "[ÜÚÛ]", "U");
            //Remover acentos do (ç) minusculo
            retorno = Regex.Replace(retorno, "[ç]", "c");
            //Remover acentos do (Ç) maiusculo
            retorno = Regex.Replace(retorno, "[Ç]", "C");
            //Remover caracter especial
            retorno = Regex.Replace(retorno, "[º]", "");
            //Remover acentos do (nº) minusculo
            retorno = Regex.Replace(retorno, "[nº]", "n");
            //Remover acentos do (Nº) maiusculo
            retorno = Regex.Replace(retorno, "[Nº]", "N");
            //Remover acentos do (nª) minusculo
            retorno = Regex.Replace(retorno, "[nª]", "n");
            //Remover acentos do (Nª) maiusculo
            retorno = Regex.Replace(retorno, "[Nª]", "N");

            return retorno;
        }

        public static string SubstCaracteresEsp(this object valor)
        {
            if (valor == null)
                return string.Empty;
            string retorno = valor.ToString();
            //Sinal <
            retorno = Regex.Replace(retorno, "[<]", "&lt;");
            //Sinal >
            retorno = Regex.Replace(retorno, "[>]", "&gt;");
            //Sinal &
            retorno = Regex.Replace(retorno, "[&]", "&amp;");
            //Sinal "
            retorno = Regex.Replace(retorno, "[\"]", "&quot;");
            //Sinal '
            retorno = Regex.Replace(retorno, "[']", "&#39;");

            return retorno;
        }
    }
}
