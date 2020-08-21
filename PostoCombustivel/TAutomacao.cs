using System;
using Utils;

namespace PostoCombustivel
{
    public class TAutomacao
    {
        public static bool AbrirPorta(string TP_Concentrador,
                                      decimal nPorta)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                return TCompanytec.AbrirPortaSerial(Convert.ToInt32(nPorta)) > 0;
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                return TVWTech.AbrirPorta(Convert.ToInt32(nPorta), string.Empty, 0).Equals(0);
            else return false;
        }

        public static bool FecharPorta(string TP_Concentrador)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                return TCompanytec.FecharPortaSerial() > 0;
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                return TVWTech.FecharPorta().Equals(0);
            else return false;
        }

        public static int StatusPorta(string TP_Concentrador)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                return TVWTech.StatusPorta();
            else
                return 0;
        }

        public static void LimparSerial(string TP_Concentrador)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                TCompanytec.LimparSerial();
        }

        public static void LerAbastecimentoAtual(string TP_Concentrador,
                                                 bool St_identfrentista,
                                                 ref string st)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT"))
                TCompanytec.LerAbastecimentoMemoria(ref st);
            else if (TP_Concentrador.Trim().ToUpper().Equals("ZT"))
            {
                string comando = string.Empty;
                if (St_identfrentista)
                    comando = "(&A" + TCompanytec.CalcularChecksum("&A") + ")";
                else comando = "(&A)";
                if (TCompanytec.EnviarComandoPlaca(comando).Equals(1))
                    TCompanytec.LerRetornoPlaca(ref st);
            }
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                TVWTech.LerAbastecimento(ref st);
        }

        public static void AvancarAbastecimento(string TP_Concentrador, int IdAbast)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT"))
                TCompanytec.ProximoAbastecimento();
            else if (TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                TCompanytec.EnviarComandoPlaca("(&I)");
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                TVWTech.ApagaAbastecimentoMemoria(IdAbast);
        }

        public static void LerAbastecimentoOnLine(string TP_Concentrador,
                                                  bool St_identfrentista,
                                                  string BicoInicial,
                                                  string BicoFinal,
                                                  ref string st)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT"))
                TCompanytec.LerAbastecimentoOnLine(ref st);
            else if (TP_Concentrador.Trim().ToUpper().Equals("ZT"))
            {
                string comando = string.Empty;
                if (St_identfrentista)
                    comando = "(?V" + TCompanytec.CalcularChecksum("?V") + ")";
                else comando = "(&V)";
                if (TCompanytec.EnviarComandoPlaca(comando).Equals(1))
                    TCompanytec.LerRetornoPlaca(ref st);
            }
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
            {
                if ((!string.IsNullOrEmpty(BicoInicial.SoNumero())) &&
                    (!string.IsNullOrEmpty(BicoFinal.SoNumero())))
                    TVWTech.LerStatusPista(Convert.ToInt32(BicoInicial), Convert.ToInt32(BicoFinal), ref st);
            }
        }

        public static int? TratarVirgula(string TP_Concentrador,
                                         string HexVirgula,
                                         string TP_Valor)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
            {
                string binary = HexVirgula.ConvertBinary();
                if (binary.Trim().Length.Equals(8))
                {
                    char[] vetor = binary.ToCharArray();
                    if (TP_Valor.Trim().ToUpper().Equals("T"))//Valor Total
                    {
                        string ret = vetor[6].ToString() + vetor[7].ToString();
                        return ret.PadLeft(4, '0').ConvertDecimal();
                    }
                    else if (TP_Valor.Trim().ToUpper().Equals("L"))//Litragem
                    {
                        string ret = vetor[4].ToString() + vetor[5].ToString();
                        return ret.PadLeft(4, '0').ConvertDecimal();
                    }
                    else if (TP_Valor.Trim().ToUpper().Equals("U"))//Unitario
                    {
                        string ret = vetor[2].ToString() + vetor[3].ToString();
                        return ret.PadLeft(4, '0').ConvertDecimal();
                    }
                    else return null;
                }
                else return null;
            }
            else return null;
        }

        public static decimal LerEncerranteBico(string TP_Concentrator,
                                                string bico,
                                                string TP_Leitura)
        {
            if (TP_Concentrator.Trim().ToUpper().Equals("CT") ||
                TP_Concentrator.Trim().ToUpper().Equals("ZT"))
                return TCompanytec.LerEncerranteBico(bico, TP_Leitura);
            else if (TP_Concentrator.Trim().ToUpper().Equals("VW"))
            {
                string encerrante = new string('\x20', 23);
                TVWTech.LerEncerrantes(Convert.ToInt32(bico), ref encerrante);
                if (!string.IsNullOrEmpty(encerrante.SoNumero()))
                    if (TP_Leitura.Trim().ToUpper().Equals("L"))
                        return decimal.Divide(decimal.Parse(encerrante.SoNumero().Substring(2, 8)), 100);
                    else return decimal.Divide(decimal.Parse(encerrante.SoNumero().Substring(10, 8)), 100);
                else return decimal.Zero;
            }
            else return decimal.Zero;
        }

        public static bool AtualizaDiaHoraConcentrador(string TP_Concentrador,
                                                      DateTime Data)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                return TCompanytec.AtualizaDiaHoraConcentrador(Data).Equals(1);
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                return TVWTech.AlterarDataHora(Data.ToString("ddMMyyHHmmss")).Equals(0);
            else return false;
        }

        public static bool AlteraPrecoUnitBico(string TP_Concentrador, string Bico, decimal Vl_unitario)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
            {
                string ret = TCompanytec.AlterarPrecoUnitBomba(Bico, Vl_unitario);
                return (!ret.Trim().Equals("(U?t)")) && (!ret.Trim().Equals("(U?b)"));
            }
            else if (TP_Concentrador.Trim().ToUpper().Equals("VW"))
                return TVWTech.AlterarPreco(Convert.ToInt32(Bico), Vl_unitario.ToString("N3").SoNumero()).Equals(0);
            else return false;
        }

        public static bool BloquearBico(string TP_Concentrador, string Bico)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                return TCompanytec.BloquearBico(Bico);
            else return false;
        }

        public static bool LiberarBico(string TP_Concentrador, string Bico)
        {
            if (TP_Concentrador.Trim().ToUpper().Equals("CT") ||
                TP_Concentrador.Trim().ToUpper().Equals("ZT"))
                return TCompanytec.LiberarBico(Bico);
            else return false;
        }
    }
}
