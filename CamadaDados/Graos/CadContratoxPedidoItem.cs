using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Utils;

namespace CamadaDados.Graos
{
   
    public class TList_CadContratoxPedidoItem : List<TRegistro_CadContratoxPedidoItem> { }

    [DataContract]
    public class TRegistro_CadContratoxPedidoItem
    {
        private decimal? nr_contrato;
        [DataMember]
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string nr_contratostr;
        [DataMember]
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        private decimal? nr_pedido;
        [DataMember]
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                nr_pedidostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string nr_pedidostr;
        [DataMember]
        public string Nr_pedidostr
        {
            get { return nr_pedidostr; }
            set
            {
                nr_pedidostr = value;
                try
                {
                    nr_pedido = Convert.ToDecimal(value);
                }
                catch
                { nr_pedido = null; }
            }
        }
        [DataMember]
        public string Cd_produto
        { get; set; }
        [DataMember]
        public string Ds_produto
        { get; set; }
        private decimal? id_pedidoitem;
        [DataMember]
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                id_pedidoitemstr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_pedidoitemstr;
        [DataMember]
        public string Id_pedidoitemstr
        {
            get { return id_pedidoitemstr; }
            set
            {
                id_pedidoitemstr = value;
                try
                {
                    id_pedidoitem = Convert.ToDecimal(value);
                }
                catch
                { id_pedidoitem = null; }
            }
        }
        [DataMember]
        public string Anosafra { get; set; }
        [DataMember]
        public string Ds_safra { get; set; }
        [DataMember]
        public string Cd_empresa { get; set; }
        [DataMember]
        public string Nm_empresa { get; set; }
        [DataMember]
        public string Cd_clifor { get; set; }
        [DataMember]
        public string Nm_clifor { get; set; }
        [DataMember]
        public string Cd_Unid_Est { get; set; }
        [DataMember]
        public string Cd_Unid_Valor { get; set; }
        private DateTime? dt_abertura;
        [DataMember]
        public DateTime? Dt_abertura
        {
            get { return dt_abertura; }
            set
            {
                dt_abertura = value;
                dt_aberturastr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string dt_aberturastr;
        public string Dt_aberturastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_aberturastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_aberturastr = value;
                try
                {
                    dt_abertura = Convert.ToDateTime(value);
                }
                catch
                { dt_abertura = null; }
            }
        }
        private DateTime? dt_encerramento;
        [DataMember]
        public DateTime? Dt_encerramento
        {
            get { return dt_encerramento; }
            set
            {
                dt_encerramento = value;
                dt_encerramentostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string dt_encerramentostr;
        public string Dt_encerramentostr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_encerramentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_encerramentostr = value;
                try
                {
                    dt_encerramento = Convert.ToDateTime(value);
                }
                catch
                { dt_encerramento = null; }
            }
        }
        private string tp_movimento;
        [DataMember]
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        [DataMember]
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        private decimal? nr_contrato_origem;
        [DataMember]
        public decimal? Nr_contrato_origem
        {
            get { return nr_contrato_origem; }
            set
            {
                nr_contrato_origem = value;
                nr_contrato_origemstr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string nr_contrato_origemstr;
        [DataMember]
        public string Nr_contrato_origemstr
        {
            get { return nr_contrato_origemstr; }
            set
            {
                nr_contrato_origemstr = value;
                try
                {
                    nr_contrato_origem = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato_origem = null; }
            }
        }
        [DataMember]
        public string St_Gmo { get; set; }
        [DataMember]
        public TList_ContratoItem_X_DesdEspecial lDesdEspecial
        { get; set; }
        [DataMember]
        public TList_ContratoItem_X_DesdEspecial lDesdEspecialDel
        { get; set; }

        public TRegistro_CadContratoxPedidoItem()
        {
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Id_pedidoitemstr = string.Empty;
            this.dt_abertura = null;
            this.dt_aberturastr = string.Empty;
            this.dt_encerramento = null;
            this.dt_encerramentostr = string.Empty;
            this.nr_contrato_origem = null;
            this.nr_contrato_origemstr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Anosafra = string.Empty;
            this.Ds_safra = string.Empty;
            this.tipo_movimento = string.Empty;
            this.Cd_Unid_Est = string.Empty;
            this.Cd_Unid_Valor = string.Empty;
            this.St_Gmo = string.Empty;
            this.lDesdEspecial = new TList_ContratoItem_X_DesdEspecial();
            this.lDesdEspecialDel = new TList_ContratoItem_X_DesdEspecial();
        }
    }

    public class TCD_CadContratoxPedidoItem : TDataQuery
    {
        public TCD_CadContratoxPedidoItem()
        { }

        public TCD_CadContratoxPedidoItem(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            
            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0){
                sql.AppendLine("select " + strTop + " a.nr_contrato, a.nr_pedido, d.cd_clifor,  ");
                sql.AppendLine("a.cd_produto, b.ds_produto, d.nm_clifor, a.id_pedidoitem, ");
                sql.AppendLine("e.nr_contratoorigem, e.cd_empresa, f.nm_empresa, e.st_gmo, ");
                sql.AppendLine("e.anosafra, e.dt_abertura, e.dt_encerramento, e.tp_movimento ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_gro_contrato_x_pedidoitem a ");
            sql.AppendLine("INNER JOIN tb_est_produto b ON a.cd_produto = b.cd_produto ");
            sql.AppendLine("INNER JOIN tb_fat_pedido c ON a.nr_pedido = c.nr_pedido ");
            sql.AppendLine("INNER JOIN vtb_fin_clifor d ON c.cd_clifor = d.cd_clifor ");
            sql.AppendLine("INNER JOIN tb_gro_contrato e ON e.nr_contrato = a.nr_contrato ");
            sql.AppendLine("INNER JOIN tb_div_empresa f ON f.cd_empresa = e.cd_empresa ");
            sql.AppendLine("WHERE ISNULL(c.st_registro, '') <> 'C' ");

            string cond = " and ";
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

        public TList_CadContratoxPedidoItem Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadContratoxPedidoItem lista = new TList_CadContratoxPedidoItem();
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
                    TRegistro_CadContratoxPedidoItem reg = new TRegistro_CadContratoxPedidoItem();

                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_Contrato"))))
                        reg.Nr_contrato  = reader.GetDecimal(reader.GetOrdinal("Nr_Contrato"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("Nr_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cd_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("Cd_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_pedidoitem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("id_pedidoitem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contratoorigem")))
                        reg.Nr_contrato_origem = Convert.ToDecimal(reader.GetString(reader.GetOrdinal("nr_contratoorigem")));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("anosafra")))
                        reg.Anosafra = reader.GetString(reader.GetOrdinal("anosafra"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_abertura")))
                        reg.Dt_abertura = reader.GetDateTime(reader.GetOrdinal("dt_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_encerramento")))
                        reg.Dt_encerramento = reader.GetDateTime(reader.GetOrdinal("dt_encerramento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gmo")))
                        reg.St_Gmo = reader.GetString(reader.GetOrdinal("st_gmo"));
                    
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

        public string GravarContratoxPedidoItem(TRegistro_CadContratoxPedidoItem val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("IA_GRO_CONTRATO_X_PEDIDOITEM", hs);
        }

        public string DeletarContratoxPedidoItem(TRegistro_CadContratoxPedidoItem val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);

            return this.executarProc("EXCLUI_GRO_CONTRATO_X_PEDIDOITEM", hs);
        }

        public string DeletarTodosContratoxPedidoItem(decimal nr_pedido)
        {
            Hashtable hs = new Hashtable(5);
            hs.Add("@P_NR_PEDIDO", nr_pedido);

            return this.executarProc("EXCLUI_GRO_CONTRATO_X_PEDIDOITEMTODOS", hs);
        }

    }
}
