using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public class Extenso
    {
        public string ValorExtenso(decimal pdbl_Valor, string MoedaSingular, string MoedaPlural)
        {
            string strValorExtenso = string.Empty; //Variável que irá armazenar o valor por extenso do número informado
            string strNumero = string.Empty;       //Irá armazenar o número para exibir por extenso
            string strCentena = string.Empty;
            string strDezena = string.Empty;

            decimal dblCentavos = decimal.Zero;
            decimal dblValorInteiro = decimal.Zero;
            int intContador = 0;
            bool bln_Bilhao = false;
            bool bln_Milhao = false;
            bool bln_Mil = false;
            bool bln_Unidade = false;

            //Verificar se foi informado um dado indevido
            if (pdbl_Valor == 0 || pdbl_Valor <= 0)
                if (Parametros.pubCultura.Trim().Equals("es-ES"))
                    strValorExtenso = "Compruebe que el valor negativo o nada se ha informado";
                else
                    strValorExtenso = "Verificar se há valor negativo ou nada foi informado";
            if (pdbl_Valor > (decimal)9999999999.99)
                if (Parametros.pubCultura.Trim().Equals("es-ES"))
                    strValorExtenso = "Valor no es compatible con la función";
                else
                    strValorExtenso = "Valor não suportado pela Função";
            else //Entrada padrão do método
            {
                //Gerar Extenso Centavos
                dblCentavos = pdbl_Valor - decimal.Floor(pdbl_Valor);
                //Gerar Extenso parte Inteira
                dblValorInteiro = decimal.Floor(pdbl_Valor);
                if (dblValorInteiro > 0)
                {
                    if (dblValorInteiro > 999)
                        bln_Mil = true;
                    if (dblValorInteiro > 999999)
                    {
                        bln_Milhao = true;
                        bln_Mil = false;
                    }
                    if (dblValorInteiro > 999999999)
                    {
                        bln_Mil = false;
                        bln_Milhao = false;
                        bln_Bilhao = true;
                    }

                    for (int i = (dblValorInteiro.ToString().Trim().Length) - 1; i >= 0; i--)
                    {
                        strNumero = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 1);
                        switch (i)
                        {            /*******/
                            case 9:  /*Bilhão*
                                         /*******/
                                {
                                    decimal tam = Convert.ToDecimal(dblValorInteiro.ToString().Length);

                                    if (tam == 10 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(1)) == 0)
                                        strValorExtenso = fcn_Numero_Unidade(strNumero) + ((Convert.ToInt64(strNumero) > 1) ?
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhões de" : 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhão de");
                                    else if (tam == 11 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(2)) == 0)
                                        strValorExtenso = fcn_Numero_Unidade(strNumero) + ((Convert.ToInt64(strNumero) > 1) ? 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhões de" : 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhão de");
                                    else if (tam == 12 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(3)) == 0)
                                        strValorExtenso = fcn_Numero_Unidade(strNumero) + ((Convert.ToInt64(strNumero) > 1) ? 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhões de" : 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhão de");
                                    else
                                    {
                                        if (Convert.ToDecimal(dblValorInteiro.ToString().Substring(1)) >= 1000)
                                            bln_Mil = true;
                                        strValorExtenso = fcn_Numero_Unidade(strNumero) + ((Convert.ToInt64(strNumero) > 1) ? 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhões," : 
                                            Parametros.pubCultura.Trim().Equals("es-ES") ? " Miles de millones" : " Bilhão,");
                                    }
                                    bln_Bilhao = true;
                                    break;
                                }
                            case 8: /********/
                            case 5: //Centena*
                            case 2: /********/
                                {
                                    if (Convert.ToInt64(strNumero) > 0)
                                    {
                                        strCentena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 3);

                                        if (Convert.ToInt64(strCentena) > 100 && Convert.ToInt64(strCentena) < 200)
                                            strValorExtenso = strValorExtenso + (Parametros.pubCultura.Trim().Equals("es-ES") ? " Cien " : " Cento e ");
                                        else
                                            strValorExtenso = strValorExtenso + " " + fcn_Numero_Centena(strNumero);
                                        if (intContador == 8)
                                            bln_Milhao = true;
                                        else if (intContador == 5)
                                            bln_Mil = true;
                                    }
                                    break;
                                }
                            case 7: /*****************/
                            case 4: //Dezena de Milhão*
                            case 1: /*****************/
                                {
                                    if (Convert.ToInt64(strNumero) > 0)
                                    {
                                        strDezena = Mid(dblValorInteiro.ToString().Trim(), (dblValorInteiro.ToString().Trim().Length - i) - 1, 2);//

                                        if (Convert.ToInt64(strDezena) > 10 && Convert.ToInt64(strDezena) < 20)
                                        {
                                            strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? 
                                                Parametros.pubCultura.Trim() != "es-ES" ? " e " : " " : " ")
                                            + fcn_Numero_Dezena0(Right(strDezena, 1));//corrigido

                                            bln_Unidade = true;
                                        }
                                        else
                                        {
                                            strValorExtenso = strValorExtenso + (Right(strValorExtenso, 5).Trim() == "entos" ? 
                                                Parametros.pubCultura.Trim() != "es-ES" ? " e " : " " : " ")
                                            + fcn_Numero_Dezena1(Left(strDezena, 1));//corrigido

                                            bln_Unidade = false;
                                        }
                                        if (intContador == 7)
                                            bln_Milhao = true;
                                        else if (intContador == 4)
                                            bln_Mil = true;
                                    }
                                    break;
                                }
                            case 6: /******************/
                            case 3: //Unidade de Milhão*
                            case 0: /******************/
                                {
                                    if (Convert.ToInt64(strNumero) > 0 && !bln_Unidade)
                                    {
                                        if ((Right(strValorExtenso, 5).Trim()) == "entos"
                                        || (Right(strValorExtenso, 3).Trim()) == "nte"
                                        || (Right(strValorExtenso, 3).Trim()) == "nta")
                                            strValorExtenso = strValorExtenso + (Parametros.pubCultura.Trim() != "es-ES" ? " e " : " ");
                                        else
                                            strValorExtenso = strValorExtenso + " ";
                                        strValorExtenso = strValorExtenso + fcn_Numero_Unidade(strNumero);
                                    }
                                    if (i == 6)
                                    {
                                        if (bln_Milhao || Convert.ToInt64(strNumero) > 0)
                                        {
                                            decimal tam = dblValorInteiro.ToString().Length;


                                            if (tam == 7 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(1)) == 0)
                                                strValorExtenso = strValorExtenso + ((Convert.ToInt64(strNumero) == 1) && !bln_Unidade ? 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhão de" : 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhões de");
                                            else if (tam == 8 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(2)) == 0)
                                                strValorExtenso = strValorExtenso + ((Convert.ToInt64(strNumero) == 1) && !bln_Unidade ? 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhão de" : 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhões de");
                                            else if (tam == 9 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(3)) == 0)
                                                strValorExtenso = strValorExtenso + ((Convert.ToInt64(strNumero) == 1) && !bln_Unidade ? 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhão de" : 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhões de");
                                            else
                                                strValorExtenso = strValorExtenso + ((Convert.ToInt64(strNumero) == 1) && !bln_Unidade ? 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhão," : 
                                                    Parametros.pubCultura.Trim().Equals("es-ES") ? " Millones" : " Milhões,");

                                            bln_Milhao = true;

                                            //Gambis
                                            if (tam == 7 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(1)) > 0)
                                            {
                                                if (Convert.ToDecimal(dblValorInteiro.ToString().Substring(1)) >= 1000)
                                                    bln_Mil = true;
                                                strValorExtenso = strValorExtenso.Replace(",", Parametros.pubCultura.Trim() != "es-ES" ? " e" : " ").ToString();

                                            }
                                            else if (tam == 8 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(2)) >= 0)
                                            {
                                                if (Convert.ToDecimal(dblValorInteiro.ToString().Substring(2)) >= 1000)
                                                    bln_Mil = true;
                                                strValorExtenso = strValorExtenso.Replace(",", Parametros.pubCultura.Trim() != "es-ES" ? " e" : " ").ToString();

                                            }
                                            else if (tam == 9 && Convert.ToDecimal(dblValorInteiro.ToString().Substring(3)) > 0)
                                            {
                                                if (Convert.ToDecimal(dblValorInteiro.ToString().Substring(3)) > 1000)
                                                    bln_Mil = true;
                                                strValorExtenso = strValorExtenso.Replace(",", Parametros.pubCultura.Trim() != "es-ES" ? " e" : " ").ToString();

                                            }
                                        }
                                    }
                                    if (i == 3)
                                    {
                                        if (bln_Mil || Convert.ToInt64(strNumero) > 0)
                                        {
                                            strValorExtenso = strValorExtenso + " Mil";
                                            bln_Mil = true;

                                            decimal tam = Convert.ToDecimal(dblValorInteiro.ToString().Length);
                                            if (Convert.ToDecimal(dblValorInteiro.ToString().Substring(3)) > 0)
                                                strValorExtenso = strValorExtenso + (Parametros.pubCultura.Trim() != "es-ES" ? " e" : " ");
                                        }
                                    }
                                    if (i == 0)
                                    {
                                        if ((bln_Bilhao && !bln_Milhao && !bln_Mil
                                        && Right((dblValorInteiro.ToString().Trim()), 3) == "0")
                                        || (!bln_Bilhao && bln_Milhao && !bln_Mil
                                        && Right((dblValorInteiro.ToString().Trim()), 3) == "0"))
                                            strValorExtenso = strValorExtenso + " de ";
                                        strValorExtenso = strValorExtenso + ((Convert.ToInt64(dblValorInteiro.ToString())) > 1 ? " " + MoedaPlural.Trim() + " " : " " + MoedaSingular.Trim() + " ");
                                    }
                                    bln_Unidade = false;
                                    break;
                                }
                        }
                    }//
                }
                if (dblCentavos > 0)
                {
                    if (Convert.ToDouble(dblCentavos.ToString()) > 0 //0#
                    && dblCentavos < (decimal)0.1)
                    {
                        strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                        strValorExtenso = strValorExtenso + ((Convert.ToDouble(dblCentavos.ToString()) > 0) ? 
                            Parametros.pubCultura.Trim() != "es-ES" ? " e " :" " : " ")
                        + fcn_Numero_Unidade(strNumero) + ((Convert.ToDouble(strNumero) > 1) ? " Centavos " : " Centavo ");
                    }
                    else if (dblCentavos > (decimal)0.1 && dblCentavos < (decimal)0.2)
                    {
                        strNumero = Right(((Decimal.Round(dblCentavos, 2) - (decimal)0.1).ToString().Trim()), 1);
                        strValorExtenso = strValorExtenso + ((Convert.ToDouble(dblCentavos.ToString()) > 0) ? 
                            Parametros.pubCultura.Trim() != "es-ES" ? " e " :" " : " ")
                        + fcn_Numero_Dezena0(strNumero) + " Centavos ";
                    }
                    else
                    {
                        if (dblCentavos > 0) //0#
                        {
                            strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Trim(), 2);
                            strValorExtenso = strValorExtenso + ((Convert.ToDouble(strNumero) > 0) ? 
                                Parametros.pubCultura.Trim() != "es-ES" ? " e " : " " : " ")
                            + fcn_Numero_Dezena1(Left(strNumero, 1));
                            if (Right(dblCentavos.ToString("N2", new System.Globalization.CultureInfo("pt-BR", true)).Trim(), 1) != "0")
                            {
                                strNumero = Right((Decimal.Round(dblCentavos, 2)).ToString().Trim(), 1);
                                if (Convert.ToDouble(strNumero) > 0)
                                    if (Mid(strValorExtenso.Trim(), strValorExtenso.Trim().Length - 2, 1) == "e")
                                        strValorExtenso = strValorExtenso + " " + fcn_Numero_Unidade(strNumero);
                                    else
                                        strValorExtenso = strValorExtenso + (Parametros.pubCultura.Trim() != "es-ES" ? " e " : " ") + fcn_Numero_Unidade(strNumero);
                            }
                            strValorExtenso = strValorExtenso + " Centavos ";
                        }
                    }
                }
                if (dblValorInteiro < 1) strValorExtenso = Mid(strValorExtenso.Trim(), 2, strValorExtenso.Trim().Length - 2);
            }
            return strValorExtenso.Trim();
        }

        private string fcn_Numero_Dezena0(string pstrDezena0)
        {
            //Vetor que irá conter o número por extenso
            ArrayList array_Dezena0 = new ArrayList();
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "once" : "Onze");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "doce" : "Doze");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Trece" : "Treze");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Catorce" : "Quatorze");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Quince" : "Quinze");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Dieciséis" : "Dezesseis");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Diecisiete" : "Dezessete");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Dieciocho" : "Dezoito");
            array_Dezena0.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Diecinueve" : "Dezenove");

            return array_Dezena0[((Convert.ToInt32(pstrDezena0)) - 1)].ToString();
        }

        private string fcn_Numero_Dezena1(string pstrDezena1)
        {
            //Vetor que irá conter o número por extenso
            ArrayList array_Dezena1 = new ArrayList();

            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Diez" : "Dez");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Veinte" : "Vinte");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Treinta" : "Trinta");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Cuarenta" : "Quarenta");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Cincuenta" : "Cinquenta");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Sesenta" : "Sessenta");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Setenta" : "Setenta");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Ochenta" : "Oitenta");
            array_Dezena1.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Noventa" : "Noventa");

            return array_Dezena1[((Convert.ToInt32(pstrDezena1)) - 1)].ToString();
        }

        private string fcn_Numero_Centena(string pstrCentena)
        {
            //Vetor que irá conter o número por extenso
            ArrayList array_Centena = new ArrayList();

            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Cien" : "Cem");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Doscientos" : "Duzentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Trescientos" : "Trezentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Cuatrocientos" : "Quatrocentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Quinientos" : "Quinhentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Seiscientos" : "Seiscentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Setecientos" : "Setecentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Ochocientos" : "Oitocentos");
            array_Centena.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Novecientos" : "Novecentos");

            return array_Centena[((Convert.ToInt32(pstrCentena)) - 1)].ToString();
        }

        private string fcn_Numero_Unidade(string pstrUnidade)
        {
            //Vetor que irá conter o número por extenso
            ArrayList array_Unidade = new ArrayList();

            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Uno" : "Um");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Dos" : "Dois");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Tres" : "Tres");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Cuatro" : "Quatro");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Cinco" : "Cinco");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Seis" : "Seis");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Siete" : "Sete");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Ocho" : "Oito");
            array_Unidade.Add(Parametros.pubCultura.Trim().Equals("es-ES") ? "Nueve" : "Nove");

            return array_Unidade[((Convert.ToInt32(pstrUnidade)) - 1)].ToString();
        }
        //Começa aqui os Métodos de Compatibilazação com VB 6 .........Left() Right() Mid()

        public static string Left(string param, int length)
        {
            //we start at 0 since we want to get the characters starting from the
            //left and with the specified lenght and assign it to a variable
            if (param == "")
                return "";
            string result = param.Substring(0, length);
            //return the result of the operation
            return result;
        }
        public static string Right(string param, int length)
        {
            //start at the index based on the lenght of the sting minus
            //the specified lenght and assign it a variable
            if (param == "")
                return "";
            string result = param.Substring(param.Length - length, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex, int length)
        {
            //start at the specified index in the string ang get N number of
            //characters depending on the lenght and assign it to a variable
            string result = param.Substring(startIndex, length);
            //return the result of the operation
            return result;
        }

        public static string Mid(string param, int startIndex)
        {
            //start at the specified index and return all characters after it
            //and assign it to a variable
            string result = param.Substring(startIndex);
            //return the result of the operation
            return result;
        }
        ////Acaba aqui os Métodos de Compatibilazação com VB 6 .........
    }
}
