using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Utils;
using System.Data.SqlClient;

namespace CamadaDados.Faturamento.Cadastros
{
    public class TList_CFGPrePedido : List<TRegistro_CFGPrePedido>
    { }

    [DataContract]
    public class TRegistro_CFGPrePedido
    {
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public string Nm_empresa
        { get; set; }
        [DataMember]
        public string Cfg_pedido
        { get; set; }
        [DataMember]
        public string Ds_tipopedido
        { get; set; }
        [DataMember]
        public string Tp_movimento
        { get; set; }
        [DataMember]
        public string Cd_moeda
        { get; set; }
        [DataMember]
        public string Ds_moeda
        { get; set; }
        [DataMember]
        public string Sigla
        { get; set; }
        [DataMember]
        public string Cd_local
        { get; set; }
        [DataMember]
        public string Ds_local
        { get; set; }
        private decimal? cd_vendedor;
        [DataMember]
        public decimal? Cd_vendedor
        {
            get { return cd_vendedor; }
            set
            {
                cd_vendedor = value;
                cd_vendedorstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_vendedorstr;
        [DataMember]
        public string Cd_vendedorstr
        {
            get { return cd_vendedorstr; }
            set
            {
                cd_vendedorstr = value;
                try
                {
                    cd_vendedor = Convert.ToDecimal(value);
                }
                catch
                { cd_vendedor = null; }
            }
        }
        [DataMember]
        public string Nomevendedor
        { get; set; }

        public TRegistro_CFGPrePedido()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cfg_pedido = string.Empty;
            this.Ds_tipopedido = string.Empty;
            this.Tp_movimento = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Sigla = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.cd_vendedor = null;
            this.cd_vendedorstr = string.Empty;
            this.Nomevendedor = string.Empty;
        }
    }

    public class TCD_CFGPrePedido : TDataQuery
    {
        public TCD_CFGPrePedido()
        { }

        public TCD_CFGPrePedido(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.CD_Local, c.DS_Local, a.cd_vendedor, f.nomevendedor, ");
                sql.AppendLine("a.CD_Moeda, d.DS_Moeda_Singular, d.Sigla, ");
                sql.AppendLine("a.CFG_Pedido, e.DS_TipoPedido, e.tp_movimento ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FAT_CFGPrePedido a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_LocalArm c ");
            sql.AppendLine("on a.cd_local = c.cd_local ");
            sql.AppendLine("inner join TB_FIN_Moeda d ");
            sql.AppendLine("on a.CD_Moeda = d.CD_Moeda ");
            sql.AppendLine("inner join TB_FAT_CFGPedido e ");
            sql.AppendLine("on a.CFG_Pedido = e.CFG_Pedido ");
            sql.AppendLine("inner join tb_fat_vendedor f ");
            sql.AppendLine("on a.cd_vendedor = f.cd_vendedor ");
            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
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

        public TList_CFGPrePedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CFGPrePedido lista = new TList_CFGPrePedido();
            bool podeFecharBco = false;

            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGPrePedido reg = new TRegistro_CFGPrePedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CFG_Pedido")))
                        reg.Cfg_pedido = reader.GetString(reader.GetOrdinal("CFG_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TipoPedido")))
                        reg.Ds_tipopedido = reader.GetString(reader.GetOrdinal("DS_TipoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Moeda")))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular")))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla")))
                        reg.Sigla = reader.GetString(reader.GetOrdinal("Sigla"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Vendedor")))
                        reg.Cd_vendedor = reader.GetDecimal(reader.GetOrdinal("CD_Vendedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NomeVendedor")))
                        reg.Nomevendedor = reader.GetString(reader.GetOrdinal("NomeVendedor"));

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

        public string GravarCFGPrePedido(TRegistro_CFGPrePedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CFG_PEDIDO", val.Cfg_pedido);
            hs.Add("@P_CD_MOEDA", val.Cd_moeda);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_CD_VENDEDOR", val.Cd_vendedor);

            return this.executarProc("IA_FAT_CFGPREPEDIDO", hs);
        }

        public string ExcluirCFGPrePedido(TRegistro_CFGPrePedido val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_FAT_CFGPREPEDIDO", hs);
        }
    }
}
