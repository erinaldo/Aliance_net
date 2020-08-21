using System;
using System.Runtime.InteropServices;
using Utils;

namespace PostoCombustivel
{
    public class TCompanytec
    {
        #region Estruturas de Dados
        [StructLayout(LayoutKind.Sequential)]
        public struct retorno2
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 60)]
            public string value;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct visualizacao
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 250)]
            public string stfull;
        }
        #endregion

        #region Chamadas Externas Companytec Dll
        //Abrir porta serial
        [DllImport("companytec.dll", EntryPoint = "InicializaSerial")]
        private static extern int InicializaSerial([MarshalAs(UnmanagedType.I1)] byte np);
        //Fechar porta serial
        [DllImport("companytec.dll", EntryPoint = "FechaSerial")]
        [return: MarshalAs(UnmanagedType.I4)]
        private static extern int FechaSerial();
        //Limpar Serial
        [DllImport("companytec.dll", EntryPoint = "LimpaSerial")]
        private static extern void LimpaSerial();
        //Ler Abastecimento Memoria
        [DllImport("companytec.dll", EntryPoint = "LeStringX")]
        private static extern void LeStringX(ref retorno2 ab);
        //Avancar ponteiro leitura Memoria abastecimento
        [DllImport("companytec.dll", EntryPoint = "Incrementa")]
        private static extern void Incrementa();
        //Ler andamento dos abastecimentos
        [DllImport("companytec.dll", EntryPoint = "CobLeVis")]
        private static extern void CobLeVis(ref visualizacao ret);
        //Enviar comando para a placa
        [DllImport("companytec.dll", EntryPoint = "VB_SendText")]
        [return: MarshalAs(UnmanagedType.I4)]
        private static extern int VB_SendText(string st);
        //Ler Retorno comando
        [DllImport("companytec.dll", EntryPoint = "VB_ReceiveText")]
        [return: MarshalAs(UnmanagedType.I4)]
        private static extern int VB_ReceiveText(ref string st);
        #endregion
        
        #region Metodos Classe Companytec
        public static string CalcularChecksum(string comando)
        {
            if (!string.IsNullOrEmpty(comando))
            {
                char[] cCom = comando.ToCharArray();
                int codigo = 0;
                foreach (char c in cCom)
                    codigo += Convert.ToInt32(c);
                string check = codigo.ToString("x").ToUpper();
                if (check.Trim().Length > 1)
                    return check.Substring(check.Trim().Length - 2, 2);
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }

        public static int AbrirPortaSerial(int np)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                return InicializaSerial(Convert.ToByte(np));
            else
                return 0;
        }
        
        public static int FecharPortaSerial()
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                return FechaSerial();
            else
                return 0;
        }

        public static void LimparSerial()
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                LimpaSerial();
        }

        public static decimal LerEncerranteBico(string bico,
                                                string Tp_leitura)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
            {
                string comando = "&T" + bico.Trim() + Tp_leitura.Trim();
                comando = "(" + comando + CalcularChecksum(comando) + ")";
                if (EnviarComandoPlaca(comando) == 1)
                {
                    LerRetornoPlaca(ref comando);
                    if (!string.IsNullOrEmpty(comando))
                        if (comando.Trim().Length.Equals(16))
                            return decimal.Parse(comando.Substring(5, 8)) / 100;
                        else
                            return decimal.Zero;
                    else
                        return decimal.Zero;
                }
                else
                    return decimal.Zero;
            }
            else
                return decimal.Zero;
        }

        public static string AlterarPrecoUnitBomba(string bico, 
                                                   decimal preco)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
            {
                string comando = "&U" + bico.Trim() + "00" + preco.ToString("N3", new System.Globalization.CultureInfo("pt-BR")).SoNumero();
                comando = "(" + comando + CalcularChecksum(comando) + ")";
                if (EnviarComandoPlaca(comando) == 1)
                {
                    LerRetornoPlaca(ref comando);
                    return comando;
                }
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }
        
        public static void LerAbastecimentoMemoria(ref string st)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
            {
                retorno2 aux = new retorno2();
                LeStringX(ref aux);
                st = aux.value;
            }
        }

        public static void ProximoAbastecimento()
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                Incrementa();
        }

        public static void LerAbastecimentoOnLine(ref string Abast)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
            {
                visualizacao aux = new visualizacao();
                CobLeVis(ref aux);
                Abast = aux.stfull;
            }
        }

        public static int EnviarComandoPlaca(string comando)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                return VB_SendText(comando);
            else
                return 0;
        }

        public static int LerRetornoPlaca(ref string retorno)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                return VB_ReceiveText(ref retorno);
            else
                return 0;
        }

        public static int AtualizaDiaHoraConcentrador(DateTime Data)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
                return EnviarComandoPlaca("(&H" + Data.Day.ToString().PadLeft(2, '0') + Data.Hour.ToString().PadLeft(2, '0') + Data.Minute.ToString().PadLeft(2, '0') + ")");
            else
                return 0;
        }

        public static bool BloquearBico(string bico)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
            {
                string comando = "&M" + bico.Trim() + "B";
                comando = "(" + comando + CalcularChecksum(comando) + ")";
                if (EnviarComandoPlaca(comando) == 1)
                {
                    LerRetornoPlaca(ref comando);
                    if (comando.Length.Equals(5))
                        return comando.Substring(2, 2).Equals(bico);
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        public static bool LiberarBico(string bico)
        {
            if (Estruturas.BaixarDll("companytec.dll"))
            {
                string comando = "&M" + bico.Trim() + "L";
                comando = "(" + comando + CalcularChecksum(comando) + ")";
                if (EnviarComandoPlaca(comando) == 1)
                {
                    LerRetornoPlaca(ref comando);
                    if (comando.Length.Equals(5))
                        return comando.Substring(2, 2).Equals(bico);
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        #endregion
    }
}
