using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Querys;
using Utils;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados.Financeiro.Duplicata
{
    public class TList_ComplDevol_X_Parcela : List<TRegistroComplDevol_X_Parcela>
    { }

    public class TRegistroComplDevol_X_Parcela
    {
        public decimal Id_compldev
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public decimal Nr_lancto
        { get; set; }
        public decimal Cd_parcela
        { get; set; }
        public decimal Vl_complemento
        { get; set; }
        public decimal Vl_devolucao
        { get; set; }

        public TRegistroComplDevol_X_Parcela()
        {
            this.Id_compldev = 0;
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = 0;
            this.Cd_parcela = 0;
            this.Vl_complemento = 0;
            this.Vl_devolucao = 0;
        }
    }

    public class TCD_ComplDevol_X_Parcela : TDataQuery
    {
        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_compldev, a.cd_empresa, ");
                sql.AppendLine("a.nr_lancto, a.cd_parcela, a.vl_complemento, a.vl_devolucao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_compldevol_x_parcela a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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

        public TList_ComplDevol_X_Parcela Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_ComplDevol_X_Parcela lista = new TList_ComplDevol_X_Parcela();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistroComplDevol_X_Parcela reg = new TRegistroComplDevol_X_Parcela();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_ComplDev"))))
                        reg.Id_compldev = reader.GetDecimal(reader.GetOrdinal("ID_ComplDev"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Complemento")))
                        reg.Vl_complemento = reader.GetDecimal(reader.GetOrdinal("Vl_Complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Devolucao")))
                        reg.Vl_devolucao = reader.GetDecimal(reader.GetOrdinal("Vl_Devolucao"));

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

        public string GravarComplDevol_X_Parcela(TRegistroComplDevol_X_Parcela val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_ID_COMPLDEV", val.Id_compldev);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_VL_COMPLEMENTO", val.Vl_complemento);
            hs.Add("@P_VL_DEVOLUCAO", val.Vl_devolucao);

            return this.executarProc("IA_FIN_COMPLDEVOL_X_PARCELA", hs);
        }

        public string ExcluirComplDevol_X_Parcela(TRegistroComplDevol_X_Parcela val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_ID_COMPLDEV", val.Id_compldev);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);

            return this.executarProc("EXCLUI_FIN_COMPLDEVOL_X_PARCELA", hs);
        }
    }
}
