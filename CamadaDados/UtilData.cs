using System;

namespace CamadaDados
{
    public static class UtilData
    {
        public static DateTime Data_Servidor()
        {
            try
            {
                object data = new TDataQuery().executarEscalar("set dateformat dmy SELECT GETDATE()", null);
                return Convert.ToDateTime(data.ToString(), new System.Globalization.CultureInfo("pt-BR"));
            }
            catch
            { return DateTime.Now; }
        }

        public static DateTime Data_Servidor(BancoDados.TObjetoBanco banco)
        {
            try
            {
                object data = new TDataQuery(banco).executarEscalar("set dateformat dmy SELECT GETDATE()", null);
                return Convert.ToDateTime(data.ToString(), new System.Globalization.CultureInfo("pt-BR"));
            }
            catch
            {
                return DateTime.Now;
            }
        }

        public static bool Data_Servidor(ref DateTime dt_servidor)
        {
            try
            {
                object data = new TDataQuery().executarEscalar("set dateformat dmy SELECT GETDATE()", null);
                dt_servidor = Convert.ToDateTime(data.ToString(), new System.Globalization.CultureInfo("pt-BR"));
                return true;
            }
            catch 
            {
                dt_servidor = DateTime.Now;
                return false; 
            }
        }
    }
}
