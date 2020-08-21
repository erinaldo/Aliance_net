using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace CamadaDados.Faturamento.NotaFiscal
{
    public class TList_DevolucaoFIN : List<TRegistro_DevolucaoFIN>
    { }

    public class TRegistro_DevolucaoFIN
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? nr_lanctofiscal;
        public decimal? Nr_lanctofiscal
        {
            get { return nr_lanctofiscal; }
            set
            {
                nr_lanctofiscal = value;
                nr_lanctofiscalstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctofiscalstr;
        public string Nr_lanctofiscalstr
        {
            get { return nr_lanctofiscalstr; }
            set
            {
                nr_lanctofiscalstr = value;
                try
                {
                    nr_lanctofiscal = decimal.Parse(value);
                }
                catch { nr_lanctofiscal = null; }
            }
        }
        private decimal? id_devolucao;
        public decimal? Id_devolucao
        {
            get { return id_devolucao; }
            set
            {
                id_devolucao = value;
                id_devolucaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_devolucaostr;
        public string Id_devolucaostr
        {
            get { return id_devolucaostr; }
            set
            {
                id_devolucaostr = value;
                try
                {
                    id_devolucao = decimal.Parse(value);
                }
                catch { id_devolucao = null; }
            }
        }
        private decimal? nr_lancto;
        public decimal? Nr_lancto
        {
            get { return nr_lancto; }
            set
            {
                nr_lancto = value;
                nr_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_lanctostr;
        public string Nr_lanctostr
        {
            get { return nr_lanctostr; }
            set
            {
                nr_lanctostr = value;
                try
                {
                    nr_lancto = decimal.Parse(value);
                }
                catch { nr_lancto = null; }
            }
        }
        private decimal? cd_parcela;
        public decimal? Cd_parcela
        {
            get { return cd_parcela; }
            set
            {
                cd_parcela = value;
                cd_parcelastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_parcelastr;
        public string Cd_parcelastr
        {
            get { return cd_parcelastr; }
            set
            {
                cd_parcelastr = value;
                try
                {
                    cd_parcela = decimal.Parse(value);
                }
                catch { cd_parcela = null; }
            }
        }
        private decimal? id_adto;
        public decimal? Id_adto
        {
            get { return id_adto; }
            set
            {
                id_adto = value;
                id_adtostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_adtostr;
        public string Id_adtostr
        {
            get { return id_adtostr; }
            set
            {
                id_adtostr = value;
                try
                {
                    id_adto = decimal.Parse(value);
                }
                catch { id_adto = null; }
            }
        }
        public string Cd_contager
        { get; set; }
        private decimal? cd_lanctocaixa;
        public decimal? Cd_lanctocaixa
        {
            get { return cd_lanctocaixa; }
            set
            {
                cd_lanctocaixa = value;
                cd_lanctocaixastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_lanctocaixastr;
        public string Cd_lanctocaixastr
        {
            get { return cd_lanctocaixastr; }
            set
            {
                cd_lanctocaixastr = value;
                try
                {
                    cd_lanctocaixa = decimal.Parse(value);
                }
                catch { cd_lanctocaixa = null; }
            }
        }
        public decimal Vl_devolvido
        { get; set; }

        public TRegistro_DevolucaoFIN()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            nr_lanctofiscal = null;
            nr_lanctofiscalstr = string.Empty;
            id_devolucao = null;
            id_devolucaostr = string.Empty;
            nr_lancto = null;
            nr_lanctostr = string.Empty;
            cd_parcela = null;
            cd_parcelastr = string.Empty;
            id_adto = null;
            id_adtostr = string.Empty;
            Cd_contager = string.Empty;
            cd_lanctocaixa = null;
            cd_lanctocaixastr = string.Empty;
            Vl_devolvido = decimal.Zero;
        }
    }

    public class TCD_DevolucaoFIN : TDataQuery
    {
        public TCD_DevolucaoFIN() { }

        public TCD_DevolucaoFIN(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT" + strTop + " a.CD_Empresa, a.Nr_LanctoFiscal, ");
                sql.AppendLine("a.Id_Devolucao, a.NR_Lancto, a.CD_Parcela, a.ID_Adto, ");
                sql.AppendLine("a.cd_contager, a.cd_lanctocaixa, a.Vl_Devolvido ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_DevolucaoFIN a ");

            string cond = " Where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_DevolucaoFIN Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_DevolucaoFIN lista = new TList_DevolucaoFIN();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DevolucaoFIN reg = new TRegistro_DevolucaoFIN();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Devolucao")))
                        reg.Id_devolucao = reader.GetDecimal(reader.GetOrdinal("ID_Devolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Parcela")))
                        reg.Cd_parcela = reader.GetDecimal(reader.GetOrdinal("CD_Parcela"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Adto")))
                        reg.Id_adto = reader.GetDecimal(reader.GetOrdinal("ID_Adto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGer")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_LanctoCaixa")))
                        reg.Cd_lanctocaixa = reader.GetDecimal(reader.GetOrdinal("CD_LanctoCaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Devolvido")))
                        reg.Vl_devolvido = reader.GetDecimal(reader.GetOrdinal("Vl_Devolvido"));

                    lista.Add(reg);
                }
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
            return lista;
        }

        public string Gravar(TRegistro_DevolucaoFIN val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);
            hs.Add("@P_CD_PARCELA", val.Cd_parcela);
            hs.Add("@P_ID_ADTO", val.Id_adto);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_LANCTOCAIXA", val.Cd_lanctocaixa);
            hs.Add("@P_VL_DEVOLVIDO", val.Vl_devolvido);

            return executarProc("IA_FAT_DEVOLUCAOFIN", hs);
        }

        public string Excluir(TRegistro_DevolucaoFIN val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_ID_DEVOLUCAO", val.Id_devolucao);

            return executarProc("EXCLUI_FAT_DEVOLUCAOFIN", hs);
        }
    }
}
