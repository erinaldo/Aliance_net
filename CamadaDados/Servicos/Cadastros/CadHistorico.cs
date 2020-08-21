using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Drawing;

namespace CamadaDados.Servicos.Cadastros
{
    public class TList_OSE_Historico : List<TRegistro_OSE_Historico>
    { }

    public class TRegistro_OSE_Historico
    {
        private decimal _ID_OS;
        public decimal ID_OS
        {
            get { return _ID_OS; }
            set { _ID_OS = value; }
        }

        private string _CD_Empresa;
        public string CD_Empresa
        {
            get { return _CD_Empresa; }
            set { _CD_Empresa = value; }
        }

        private decimal _ID_Historico;
        public decimal ID_Historico
        {
            get { return _ID_Historico; }
            set { _ID_Historico = value; }
        }

        private string _LOGIN;
        public string LOGIN
        {
            get { return _LOGIN; }
            set { _LOGIN = value; }
        }

        private string _DS_Historico;
        public string DS_Historico
        {
            get { return _DS_Historico; }
            set { _DS_Historico = value; }
        }

        private DateTime _DT_Historico;
        public DateTime DT_Historico
        {
            get { return _DT_Historico; }
            set { _DT_Historico = value; }
        }

        public TRegistro_OSE_Historico()
        {
            _ID_OS = decimal.Zero;
            _CD_Empresa = string.Empty;
            _ID_Historico = decimal.Zero;
            _LOGIN = string.Empty;
            _DS_Historico = string.Empty; 
            _DT_Historico = DateTime.Now;
            
        }
    }

    public class TCD_OSE_Historico : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = "";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (vNM_Campo.Length == 0)
                sql.AppendLine(" SELECT " + strTop + " a.ID_OS, a.CD_Empresa, a.Login, a.DS_Historico, a.DT_Historico ");

            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine(" FROM TB_OSE_Historico a");
            

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_OSE_Historico Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_OSE_Historico lista = new TList_OSE_Historico();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_OSE_Historico reg = new TRegistro_OSE_Historico();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_OS")))
                        reg.ID_OS = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.CD_Empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.LOGIN = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico")))
                        reg.DS_Historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Historico")))
                        reg.DT_Historico = reader.GetDateTime(reader.GetOrdinal("DT_Historico"));
                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        }

        public string Grava(TRegistro_OSE_Historico vRegistro)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_OS", vRegistro.ID_OS);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_LOGIN", vRegistro.LOGIN);
            hs.Add("@P_ID_HISTORICO", vRegistro.ID_Historico);
            hs.Add("@P_DS_HISTORICO", vRegistro.DS_Historico);
            hs.Add("@P_DT_HISTORICO", vRegistro.DT_Historico);
            return this.executarProc("IA_OSE_HISTORICO", hs);
        }

        public string Deleta(TRegistro_OSE_Historico vRegistro)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_OS", vRegistro.ID_OS);
            hs.Add("@P_CD_EMPRESA", vRegistro.CD_Empresa);
            hs.Add("@P_ID_HISTORICO", vRegistro.ID_Historico);
            return this.executarProc("EXCLUI_OSE_HISTORICO", hs);
        }
    }
}
