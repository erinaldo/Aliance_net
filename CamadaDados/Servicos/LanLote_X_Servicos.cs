using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Servicos
{
    public class TList_Lote_X_Servicos : List<TRegistro_Lote_X_Servicos>
    { }

    
    public class TRegistro_Lote_X_Servicos
    {
        
        public decimal? Id_lote
        { get; set; }
        
        public decimal? Id_os
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public TRegistro_Lote_X_Servicos()
        {
            this.Id_lote = null;
            this.Id_os = null;
            this.Cd_empresa = string.Empty;
        }
    }

    public class TCD_Lote_X_Servicos : TDataQuery
    {
        public TCD_Lote_X_Servicos()
        { }

        public TCD_Lote_X_Servicos(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
                sql.AppendLine("select " + strtop + " a.id_lote, a.id_os, a.cd_empresa ");
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_ose_lote_x_servico a ");
            sql.AppendLine("inner join tb_ose_lote b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_lote = b.id_lote ");
            sql.AppendLine("inner join tb_ose_servico c ");
            sql.AppendLine("on a.id_os = c.id_os ");
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.executarEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Lote_X_Servicos Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_Lote_X_Servicos lista = new TList_Lote_X_Servicos();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Lote_X_Servicos reg = new TRegistro_Lote_X_Servicos();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOte")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_LOte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_OS")))
                        reg.Id_os = reader.GetDecimal(reader.GetOrdinal("ID_OS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));

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

        public string GravarLote_X_Servicos(TRegistro_Lote_X_Servicos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("IA_OSE_LOTE_X_SERVICO", hs);
        }

        public string DeletarLote_X_Servicos(TRegistro_Lote_X_Servicos val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_ID_OS", val.Id_os);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_OSE_LOTE_X_SERVICO", hs);
        }
    }
}
