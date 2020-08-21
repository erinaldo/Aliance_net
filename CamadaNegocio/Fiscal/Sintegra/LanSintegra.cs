using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fiscal.Sintegra;

namespace CamadaNegocio.Fiscal.Sintegra
{
    public class TCN_Sintegra
    {
        public static int Count50 = 0;
        public static int Count51 = 0;
        public static int Count53 = 0;
        public static int Count54 = 0;
        public static int Count60M = 0;
        public static int Count60A = 0;
        public static int Count60D = 0;
        public static int Count60I = 0;
        public static int Count60R = 0;
        public static int Count70 = 0;
        public static int Count71 = 0;
        public static int Count74 = 0;
        public static int Count75 = 0;

        private static string GerarArquivo(string Cd_empresa,
                                           DateTime Dt_ini,
                                           DateTime Dt_fin,
                                           Finalidades Finalidade,
                                           bool St_tipo10,
                                           bool St_tipo11,
                                           bool St_tipo50,
                                           bool St_tipo51,
                                           bool St_tipo53,
                                           bool St_tipo54,
                                           bool St_tipo60M,
                                           bool St_tipo60A,
                                           bool St_tipo60D,
                                           bool St_tipo60I,
                                           bool St_tipo60R,
                                           bool St_tipo70,
                                           bool St_tipo71,
                                           bool St_tipo74,
                                           bool St_tipo75,
                                           bool St_tipo90,
                                           Utils.ThreadEspera tEspera)
        {
            Count50 = 0;
            Count51 = 0;
            Count53 = 0;
            Count54 = 0;
            Count60M = 0;
            Count60A = 0;
            Count60D = 0;
            Count60I = 0;
            Count60R = 0;
            Count70 = 0;
            Count71 = 0;
            Count74 = 0;
            Count75 = 0;
            string retorno = string.Empty;
            //Gerar arquivo 10_11
            if (St_tipo10 && St_tipo11)
            {
                tEspera.Msg("Gerando registro 10 e 11...");
                retorno += TCN_Tipo10_11.CriarRegistroTipo10_11(Cd_empresa, Dt_ini, Dt_fin, Finalidade);
            }

            //Gerar registro 50
            if (St_tipo50)
            {
                tEspera.Msg("Gerando registro 50...");
                string ret_50 = string.Empty;
                Count50 = TCN_Tipo50.CriarRegistroTipo50(Cd_empresa, Dt_ini, Dt_fin, ref ret_50);
                retorno += ret_50;
            }
            //Gerar registro 51
            if (St_tipo51)
            {
                tEspera.Msg("Gerando registro 51...");
                string ret_51 = string.Empty;
                Count51 = TCN_Tipo51.CriarRegistroTipo51(Cd_empresa, Dt_ini, Dt_fin, ref ret_51);
                retorno += ret_51;
            }
            //Gerar registro 53
            if (St_tipo53)
            {
                tEspera.Msg("Gerando registro 53...");
                string ret_53 = string.Empty;
                Count53 = TCN_Tipo53.CriarRegistroTipo53(Cd_empresa, Dt_ini, Dt_fin, ref ret_53);
                retorno += ret_53;
            }
            //Gerar registro 54
            if (St_tipo54)
            {
                tEspera.Msg("Gerando registro 54...");
                string ret_54 = string.Empty;
                Count54 = TCN_Tipo54.CriarRegistroTipo54(Cd_empresa, Dt_ini, Dt_fin, ref ret_54);
                retorno += ret_54;
            }
            //Gerar registro 60M
            if (St_tipo60M)
            {
                tEspera.Msg("Gerando registro 60(M,A,D,I)...");
                string ret_60M = string.Empty;
                Count60M = TCN_Tipo60M.CriarRegistroTipo60M(Cd_empresa, Dt_ini, Dt_fin, St_tipo60D, St_tipo60I, ref ret_60M);
                retorno += ret_60M;
            }
            //Gerar registro 60R
            if (St_tipo60R)
            {
                tEspera.Msg("Gerando registro 60R...");
                string ret_60R = string.Empty;
                Count60R = TCN_Tipo60R.CriarRegistroTipo60R(Cd_empresa, Dt_ini, Dt_fin, ref ret_60R);
                retorno += ret_60R;
            }
            //Gerar registro 70
            if (St_tipo70)
            {
                tEspera.Msg("Gerando registro 70...");
                string ret_70 = string.Empty;
                Count70 = TCN_Tipo70.CriarRegistroTipo70(Cd_empresa, Dt_ini, Dt_fin, ref ret_70);
                retorno += ret_70;
            }
            //Gerar registro 71
            if (St_tipo71)
            {
                tEspera.Msg("Gerando registro 71...");
                string ret_71 = string.Empty;
                Count71 = TCN_Tipo71.CriarRegistroTipo71(Cd_empresa, Dt_ini, Dt_fin, ref ret_71);
                retorno += ret_71;
            }
            //Gerar registro 74
            if (St_tipo74)
            {
                tEspera.Msg("Gerando registro 74...");
                string ret_74 = string.Empty;
                Count74 = TCN_Tipo74.CriarRegistroTipo74(Cd_empresa, Dt_fin, ref ret_74);
                retorno += ret_74;
            }
            //Gerar registro 75
            if (St_tipo75)
            {
                tEspera.Msg("Gerando registro 75...");
                string ret_75 = string.Empty;
                DateTime? dt_inventario = null;
                if (St_tipo74)
                    dt_inventario = Dt_fin;
                Count75 = TCN_Tipo75.CriarRegistroTipo75(Cd_empresa, Dt_ini, Dt_fin, dt_inventario, ref ret_75);
                retorno += ret_75;
            }
            //Gerar registro 90
            if (St_tipo90)
            {
                tEspera.Msg("Gerando registro 90...");
                retorno += TCN_Tipo90.MontarRegistro90(Cd_empresa,
                                                       Count50,
                                                       Count51,
                                                       Count53,
                                                       Count54,
                                                       Count60M,
                                                       Count60A,
                                                       Count60D,
                                                       Count60I,
                                                       Count60R,
                                                       Count70,
                                                       Count71,
                                                       Count74,
                                                       Count75);
            }
            return retorno;
        }

        public static void GerarArquivo(string Cd_empresa,
                                        DateTime Dt_ini,
                                        DateTime Dt_fin,
                                        Finalidades Finalidade,
                                        string Path,
                                        bool St_tipo10,
                                        bool St_tipo11,
                                        bool St_tipo50,
                                        bool St_tipo51,
                                        bool St_tipo53,
                                        bool St_tipo54,
                                        bool St_tipo60M,
                                        bool St_tipo60A,
                                        bool St_tipo60D,
                                        bool St_tipo60I,
                                        bool St_tipo60R,
                                        bool St_tipo70,
                                        bool St_tipo71,
                                        bool St_tipo74,
                                        bool St_tipo75,
                                        bool St_tipo90,
                                        Utils.ThreadEspera tEspera)
        {
            try
            {
                if (Path.Trim().Substring(Path.Trim().Length - 1, 1) != System.IO.Path.DirectorySeparatorChar.ToString())
                    Path = Path.Trim() + System.IO.Path.DirectorySeparatorChar.ToString();
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(Path.Trim() + Cd_empresa.Trim() + Dt_ini.Month.ToString().PadLeft(2, '0') + Dt_ini.Year.ToString() + ".txt", false, System.Text.Encoding.Default))
                {
                    sw.Write(GerarArquivo(Cd_empresa, 
                                          Dt_ini, 
                                          Dt_fin, 
                                          Finalidade,
                                          St_tipo10,
                                          St_tipo11,
                                          St_tipo50,
                                          St_tipo51,
                                          St_tipo53,
                                          St_tipo54,
                                          St_tipo60M,
                                          St_tipo60A,
                                          St_tipo60D,
                                          St_tipo60I,
                                          St_tipo60R,
                                          St_tipo70,
                                          St_tipo71,
                                          St_tipo74,
                                          St_tipo75,
                                          St_tipo90,
                                          tEspera));
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }
        }
    }
}
