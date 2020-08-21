using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Servicos
{
    public class TList_LoteOS : List<TRegistro_LoteOS>
    { }

    
    public class TRegistro_LoteOS
    {
        private decimal? id_lote;
        
        public decimal? Id_lote
        {
            get { return id_lote; }
            set
            {
                id_lote = value;
                id_lotestr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_lotestr;
        
        public string Id_lotestr
        {
            get { return id_lotestr; }
            set
            {
                id_lotestr = value;
                try
                {
                    id_lote = Convert.ToDecimal(value);
                }
                catch
                { id_lote = null; }
            }
        }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public decimal? Nr_pedido
        { get; set; }
        
        public string Cd_fornecedor
        { get; set; }
        
        public string Nm_fornecedor
        { get; set; }
        
        public string Cd_endfornecedor
        { get; set; }
        
        public string Ds_endfornecedor
        { get; set; }
        
        public string Ds_lote
        { get; set; }
        
        public string Ds_observacao
        { get; set; }
        private DateTime? dt_enviolote;
        
        public DateTime? Dt_enviolote
        {
            get{return dt_enviolote;}
            set
            {
                dt_enviolote = value;
                dt_enviolotestr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_enviolotestr;
        public string Dt_enviolotestr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_enviolotestr).ToString("dd/MM/yyyy");
                }
                catch
                {return string.Empty;}
            }
            set
            {
                dt_enviolotestr = value;
                try
                {
                    dt_enviolote = Convert.ToDateTime(value);
                }
                catch
                {dt_enviolote = null;}
            }
        }
        private DateTime? dt_prevdevolucao;
        
        public DateTime? Dt_prevdevolucao
        {
            get { return dt_prevdevolucao; }
            set
            {
                dt_prevdevolucao = value;
                dt_prevdevolucaostr = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string dt_prevdevolucaostr;
        public string Dt_prevdevolucaostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_prevdevolucaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_prevdevolucaostr = value;
                try
                {
                    dt_prevdevolucao = Convert.ToDateTime(value);
                }
                catch
                { dt_prevdevolucao = null; }
            }
        }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTO";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTO"))
                    status = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADO"))
                    status = "P";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    status = "C";
            }
        }
        
        public bool St_gerarpedidoremessa
        { get; set; }
        
        public TList_Lote_X_Servicos LServicos
        { get; set; }
        
        public TList_Lote_X_Servicos LServicosDel
        { get; set; }
        
        public TList_LanServico lOs
        { get; set; }
        
        public TList_LanServico lOsDel
        { get; set; }
        
        public CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento lNf
        { get; set; }
        
        public CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item lItensPedido
        { get; set; }

        public TRegistro_LoteOS()
        {
            this.id_lote = null;
            this.id_lotestr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nr_pedido = null;
            this.Cd_fornecedor = string.Empty;
            this.Nm_fornecedor = string.Empty;
            this.Cd_endfornecedor = string.Empty;
            this.Ds_endfornecedor = string.Empty;
            this.Ds_lote = string.Empty;
            this.Ds_observacao = string.Empty;
            this.dt_enviolote = DateTime.Now;
            this.dt_enviolotestr = DateTime.Now.ToString();
            this.dt_prevdevolucao = null;
            this.dt_prevdevolucaostr = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTO";
            this.St_gerarpedidoremessa = false;
            this.LServicos = new TList_Lote_X_Servicos();
            this.LServicosDel = new TList_Lote_X_Servicos();
            this.lOs = new TList_LanServico();
            this.lOsDel = new TList_LanServico();
            this.lNf = new CamadaDados.Faturamento.NotaFiscal.TList_RegLanFaturamento();
            this.lItensPedido = new CamadaDados.Faturamento.Pedido.TList_RegLanPedido_Item();
        }
    }

    public class TCD_LoteOS : TDataQuery
    {
        public TCD_LoteOS()
        { }

        public TCD_LoteOS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strtop = string.Empty;
            if (vTop > 0)
                strtop = " top " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strtop + " a.id_lote, a.ds_lote, a.ds_observacao, ");
                sql.AppendLine("a.cd_fornecedor, b.NM_Clifor, a.cd_empresa, a.nr_pedido, ");
                sql.AppendLine("a.cd_endfornecedor, c.DS_Endereco, d.nm_empresa, ");
                sql.AppendLine("a.dt_enviolote, a.dt_prevdevolucao, isnull(a.st_registro, 'A') as st_registro ");
            }
            else
                sql.AppendLine("Select " + strtop + " " + vNM_Campo);

            sql.AppendLine("from tb_ose_lote a ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR b ");
            sql.AppendLine("on a.cd_fornecedor = b.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO c ");
            sql.AppendLine("on a.cd_fornecedor = c.CD_Clifor ");
            sql.AppendLine("and a.cd_endfornecedor = c.CD_Endereco ");
            sql.AppendLine("inner join tb_div_empresa d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
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

        public TList_LoteOS Select(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            TList_LoteOS lista = new TList_LoteOS();
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
                    TRegistro_LoteOS reg = new TRegistro_LoteOS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_LOte")))
                        reg.Id_lote = reader.GetDecimal(reader.GetOrdinal("ID_LOte"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Lote")))
                        reg.Ds_lote = reader.GetString(reader.GetOrdinal("DS_Lote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Fornecedor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("CD_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndFornecedor")))
                        reg.Cd_endfornecedor = reader.GetString(reader.GetOrdinal("CD_EndFornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endfornecedor = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_enviolote")))
                        reg.Dt_enviolote = reader.GetDateTime(reader.GetOrdinal("dt_enviolote"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_prevdevolucao")))
                        reg.Dt_prevdevolucao = reader.GetDateTime(reader.GetOrdinal("dt_prevdevolucao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string GravarLoteOS(TRegistro_LoteOS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(13);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_ENDFORNECEDOR", val.Cd_endfornecedor);
            hs.Add("@P_DS_LOTE", val.Ds_lote);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DT_ENVIOLOTE", val.Dt_enviolote);
            hs.Add("@P_DT_PREVDEVOLUCAO", val.Dt_prevdevolucao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_OSE_LOTE", hs);
        }

        public string DeletarLoteOS(TRegistro_LoteOS val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_LOTE", val.Id_lote);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_OSE_LOTE", hs);
        }
    }
}
