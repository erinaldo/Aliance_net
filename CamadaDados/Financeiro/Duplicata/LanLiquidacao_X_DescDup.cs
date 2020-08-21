using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Financeiro.Duplicata
{
    public class TList_LanLiquidacao_X_DescDup : List<TRegistro_LanLiquidacao_X_DescDup>
    { }
    
    public class TRegistro_LanLiquidacao_X_DescDup
    {
        
        public decimal? Id_lancto
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public decimal? Nr_lancto
        { get; set; }
        
        public decimal? Cd_parcela
        { get; set; }
        
        public decimal? Id_liquid
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public decimal? Cd_lanctocaixa
        { get; set; }

        public TRegistro_LanLiquidacao_X_DescDup()
        {
            this.Id_lancto = decimal.Zero;
            this.Cd_empresa = string.Empty;
            this.Nr_lancto = decimal.Zero;
            this.Cd_parcela = decimal.Zero;
            this.Id_liquid = decimal.Zero;
            this.Cd_contager = string.Empty;
            this.Cd_lanctocaixa = decimal.Zero;
        }
    }

    public class TCD_LanLiquidacao_X_DescDup : TDataQuery
    {
        public TCD_LanLiquidacao_X_DescDup()
        { }

        public TCD_LanLiquidacao_X_DescDup(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_lancto, a.cd_empresa, a.nr_lancto, ");
                sql.AppendLine("a.cd_parcela, a.id_liquid, a.cd_contager, a.cd_lanctocaixa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fin_liquidacao_x_descdup a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
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
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_LanLiquidacao_X_DescDup Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_LanLiquidacao_X_DescDup lista = new TList_LanLiquidacao_X_DescDup();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanLiquidacao_X_DescDup reg = new TRegistro_LanLiquidacao_X_DescDup();
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Lancto"))))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("ID_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Liquid"))))
                        reg.Id_liquid = reader.GetDecimal(reader.GetOrdinal("ID_Liquid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));

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

        public string GravarLiquidacao_X_DescDup(TRegistro_LanLiquidacao_X_DescDup val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(7);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_LIQUID", val.Id_liquid);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);

            return this.executarProc("IA_FIN_LIQUIDACAO_X_DESCDUP", hs);
        }

        public string DeletarLiquidacao_X_DescDup(TRegistro_LanLiquidacao_X_DescDup val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);

            return this.executarProc("EXCLUI_FIN_LIQUIDACAO_X_DESCDUP", hs);
        }
    }
}
