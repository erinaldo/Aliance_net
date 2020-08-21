using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Faturamento.Pedido
{
    public class TList_EntregaPedido : List<TRegistro_EntregaPedido>, IComparer<TRegistro_EntregaPedido>
    {
        #region IComparer<TRegistro_EntregaPedido> Members
        private System.ComponentModel.PropertyDescriptor Propriedade;
        private System.Windows.Forms.SortOrder Direcao;

        private int CompareAscending(object x, object y)
        {
            if (x is IComparable)
                return new System.Collections.CaseInsensitiveComparer().Compare(x, y);
            else
                return 0;
        }

        private int CompareDescending(object x, object y)
        {
            return -CompareAscending(x, y);
        }

        public TList_EntregaPedido()
        { }

        public TList_EntregaPedido(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_EntregaPedido value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_EntregaPedido x, TRegistro_EntregaPedido y)
        {
            object col1 = GetPropertyValue(x, Propriedade.Name);
            object col2 = GetPropertyValue(y, Propriedade.Name);
            if (Direcao == System.Windows.Forms.SortOrder.Ascending)
                return CompareAscending(col1, col2);
            else
                return CompareDescending(col1, col2);
        }
        #endregion
    }

    
    public class TRegistro_EntregaPedido
    {
        private decimal? id_entrega;
        
        public decimal? Id_entrega
        {
            get { return id_entrega; }
            set
            {
                id_entrega = value;
                id_entregastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_entregastr;
        
        public string Id_entregastr
        {
            get { return id_entregastr; }
            set
            {
                id_entregastr = value;
                try
                {
                    id_entrega = decimal.Parse(value);
                }
                catch
                { id_entrega = null; }
            }
        }
        private decimal? nr_pedido;
        
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set
            {
                nr_pedido = value;
                if (value.HasValue)
                    nr_pedidostr = value.Value.ToString();
                else
                    nr_pedidostr = string.Empty;
            }
        }
        private string nr_pedidostr;
        
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
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        private decimal? id_pedidoitem;
        
        public decimal? Id_pedidoitem
        {
            get { return id_pedidoitem; }
            set
            {
                id_pedidoitem = value;
                if (value.HasValue)
                    id_pedidoitemstr = value.Value.ToString();
                else
                    id_pedidoitemstr = string.Empty;
            }
        }
        private string id_pedidoitemstr;
        
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
        
        public string Login
        { get; set; }
        
        public decimal Qtd_entregue
        { get; set; }
        
        public decimal Qtd_estoque
        { get; set; }
        public decimal Saldo
        {
            get { return Qtd_entregue - Qtd_estoque; }
        }
        
        public decimal Qtd_pedido
        { get; set; }
        
        public decimal Qtd_pedidoSaida
        { get; set; }
        public decimal Qtd_diferenca
        {
            get
            {
                if (this.st_registro.Trim().ToUpper().Equals("P"))
                    return this.Qtd_pedido - this.Qtd_entregue;
                else
                    return decimal.Zero;
            }
        }
        private DateTime? dt_entrega;
        
        public DateTime? Dt_entrega
        {
            get { return dt_entrega; }
            set
            {
                dt_entrega = value;
                if (value.HasValue)
                    dt_entregastr = value.Value.ToString("dd/MM/yyyy");
                else
                    dt_entregastr = string.Empty;
            }
        }
        private string dt_entregastr;
        public string Dt_entregastr
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(dt_entregastr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_entregastr = value;
                try
                {
                    dt_entrega = Convert.ToDateTime(value);
                }
                catch
                { dt_entrega = null; }
            }
        }
        
        public string Ds_observacao
        { get; set; }
        
        public string Ds_motivo_recontar
        { get; set; }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ABERTA";
                else if (value.Trim().ToUpper().Equals("P"))
                    status = "PROCESSADA";
                else if (value.Trim().ToUpper().Equals("R"))
                    status = "RECONTAR";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ABERTA"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("PROCESSADA"))
                    st_registro = "P";
                else if (value.Trim().ToUpper().Equals("RECONTAR"))
                    st_registro = "R";

            }
        }
        
        public bool St_recontar
        { get; set; }
        //Dados alocacao Almoxarifado
        private decimal? id_almox;
        
        public decimal? Id_almox
        {
            get { return id_almox; }
            set
            {
                id_almox = value;
                id_almoxstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_almoxstr;
        
        public string Id_almoxstr
        {
            get { return id_almoxstr; }
            set
            {
                id_almoxstr = value;
                try
                {
                    id_almox = decimal.Parse(value);
                }
                catch
                { id_almox = null; }
            }
        }
        
        public string Ds_almoxarifado
        { get; set; }
        private decimal? id_rua;
        
        public decimal? Id_rua
        {
            get { return id_rua; }
            set
            {
                id_rua = value;
                id_ruastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ruastr;
        
        public string Id_ruastr
        {
            get { return id_ruastr; }
            set
            {
                id_ruastr = value;
                try
                {
                    id_rua = decimal.Parse(value);
                }
                catch
                { id_rua = null; }
            }
        }
        
        public string Ds_rua
        { get; set; }
        private decimal? id_secao;
        
        public decimal? Id_secao
        {
            get { return id_secao; }
            set
            {
                id_secao = value;
                id_secaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_secaostr;
        
        public string Id_secaostr
        {
            get { return id_secaostr; }
            set
            {
                id_secaostr = value;
                try
                {
                    id_secao = decimal.Parse(value);
                }
                catch
                { id_secao = null; }
            }
        }
        
        public string Ds_secao
        { get; set; }
        private decimal? id_celula;
        
        public decimal? Id_celula
        {
            get { return id_celula; }
            set
            {
                id_celula = value;
                id_celulastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_celulastr;
        
        public string Id_celulastr
        {
            get { return id_celulastr; }
            set
            {
                id_celulastr = value;
                try
                {
                    id_celula = decimal.Parse(value);
                }
                catch
                { id_celula = null; }
            }
        }
        
        public string Ds_celula
        { get; set; }

        public TRegistro_EntregaPedido()
        {
            this.id_entrega = null;
            this.id_entregastr = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostr = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.id_pedidoitem = null;
            this.id_pedidoitemstr = string.Empty;
            this.Login = string.Empty;
            this.Qtd_entregue = decimal.Zero;
            this.Qtd_estoque = decimal.Zero;
            this.Qtd_pedido = decimal.Zero;
            this.Qtd_pedidoSaida = decimal.Zero;
            this.dt_entrega = DateTime.Now;
            this.dt_entregastr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Ds_observacao = string.Empty;
            this.Ds_motivo_recontar = string.Empty;
            this.st_registro = "A";
            this.status = "ABERTA";
            this.St_recontar = false;

            this.id_almox = null;
            this.id_almoxstr = string.Empty;
            this.Ds_almoxarifado = string.Empty;
            this.id_rua = null;
            this.id_ruastr = string.Empty;
            this.Ds_rua = string.Empty;
            this.id_secao = null;
            this.id_secaostr = string.Empty;
            this.Ds_secao = string.Empty;
            this.id_celula = null;
            this.id_celulastr = string.Empty;
            this.Ds_celula = string.Empty;
        }
    }

    public class TCD_EntregaPedido : TDataQuery
    {
        public TCD_EntregaPedido()
        { }

        public TCD_EntregaPedido(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_entrega, a.nr_pedido, a.st_registro, ");
                sql.AppendLine("a.cd_produto, b.ds_produto, c.sigla_unidade, a.ds_observacao, k.ds_almoxarifado, ");
                sql.AppendLine("a.id_pedidoitem, a.login, a.qtd_entregue, a.dt_entrega, f.id_almox,");
                sql.AppendLine("g.id_rua, h.ds_rua, g.id_secao, i.ds_secao, g.id_celula, j.ds_celula, ");
                sql.AppendLine("qtd_estoque = abs(isnull(e.qtd_entrada, 0) - isnull(e.qtd_saida, 0)), ");
                sql.AppendLine("qtd_pedidosaida = case when ped.tp_movimento = 'E' then 0 else ");
                sql.AppendLine("(peditens.quantidade - case when ped.tp_movimento = 'E' then (select isnull(SUM(case when y.Tp_Movimento = 'E' then isnull(x.Quantidade, 0) else 0 end), 0) ");
                sql.AppendLine("                        from tb_fat_notafiscal_item x ");
                sql.AppendLine("                        inner join tb_fat_notafiscal y ");
                sql.AppendLine("                        on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("                        and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                sql.AppendLine("                        where x.nr_pedido = a.nr_pedido ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto ");
                sql.AppendLine("                        and x.id_pedidoitem = a.id_pedidoitem ");
                sql.AppendLine("                        and isnull(y.st_registro, 'A') <> 'C') else ");
                sql.AppendLine("                        (select isnull(SUM(case when y.Tp_Movimento = 'S' then isnull(x.Quantidade, 0) else 0 end), 0) ");
                sql.AppendLine("                        from tb_fat_notafiscal_item x ");
                sql.AppendLine("                        inner join tb_fat_notafiscal y ");
                sql.AppendLine("                        on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("                        and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                sql.AppendLine("                        where x.nr_pedido = a.nr_pedido ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto ");
                sql.AppendLine("                        and x.id_pedidoitem = a.id_pedidoitem ");
                sql.AppendLine("                        and isnull(y.st_registro, 'A') <> 'C') end) end, ");
                sql.AppendLine("qtd_pedido = (peditens.quantidade - case when ped.tp_movimento = 'E' then (select isnull(SUM(case when y.Tp_Movimento = 'E' then isnull(x.Quantidade, 0) else 0 end), 0) ");
                sql.AppendLine("                        from tb_fat_notafiscal_item x ");
                sql.AppendLine("                        inner join tb_fat_notafiscal y ");
                sql.AppendLine("                        on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("                        and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                sql.AppendLine("                        where x.nr_pedido = a.nr_pedido ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto ");
                sql.AppendLine("                        and x.id_pedidoitem = a.id_pedidoitem ");
                sql.AppendLine("                        and isnull(y.st_registro, 'A') <> 'C') else ");
                sql.AppendLine("                        (select isnull(SUM(case when y.Tp_Movimento = 'S' then isnull(x.Quantidade, 0) else 0 end), 0) ");
                sql.AppendLine("                        from tb_fat_notafiscal_item x ");
                sql.AppendLine("                        inner join tb_fat_notafiscal y ");
                sql.AppendLine("                        on x.cd_empresa = y.cd_empresa ");
                sql.AppendLine("                        and x.nr_lanctofiscal = y.nr_lanctofiscal ");
                sql.AppendLine("                        where x.nr_pedido = a.nr_pedido ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto ");
                sql.AppendLine("                        and x.id_pedidoitem = a.id_pedidoitem ");
                sql.AppendLine("                        and isnull(y.st_registro, 'A') <> 'C') end), a.ds_motivo_recontar ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_fat_entregapedido a ");
            sql.AppendLine("inner join tb_fat_pedido_itens peditens ");
            sql.AppendLine("on a.nr_pedido = peditens.nr_pedido ");
            sql.AppendLine("and a.cd_produto = peditens.cd_produto ");
            sql.AppendLine("and a.id_pedidoitem = peditens.id_pedidoitem ");
            sql.AppendLine("inner join vtb_fat_pedido ped ");
            sql.AppendLine("on a.nr_pedido = ped.nr_pedido ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("left outer join tb_fat_notafiscal_item_x_estoque d ");
            sql.AppendLine("on a.id_entrega = d.id_entrega ");
            sql.AppendLine("left outer join tb_est_estoque e ");
            sql.AppendLine("on d.cd_empresa = e.cd_empresa ");
            sql.AppendLine("and d.cd_produto = e.cd_produto ");
            sql.AppendLine("and d.id_lanctoestoque = e.id_lanctoestoque ");
            sql.AppendLine("left outer join tb_amx_alocacaoitem f ");
            sql.AppendLine("on a.id_entrega = f.id_entrega ");
            sql.AppendLine("left outer join tb_amx_itens g ");
            sql.AppendLine("on a.cd_produto = g.cd_produto ");
            sql.AppendLine("and f.id_almox = g.id_almox ");
            sql.AppendLine("left outer join tb_amx_almoxarifado k ");
            sql.AppendLine("on f.id_almox = k.id_almox ");
            sql.AppendLine("left outer join tb_amx_rua h ");
            sql.AppendLine("on g.id_rua = h.id_rua ");
            sql.AppendLine("left outer join tb_amx_secao i ");
            sql.AppendLine("on g.id_rua = i.id_rua ");
            sql.AppendLine("and g.id_secao = i.id_secao ");
            sql.AppendLine("left outer join tb_amx_celulaarm j ");
            sql.AppendLine("on g.id_rua = j.id_rua ");
            sql.AppendLine("and g.id_secao = j.id_secao ");
            sql.AppendLine("and g.id_celula = j.id_celula ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_EntregaPedido Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_EntregaPedido lista = new TList_EntregaPedido();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_EntregaPedido reg = new TRegistro_EntregaPedido();

                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Entrega")))
                        reg.Id_entrega = reader.GetDecimal(reader.GetOrdinal("ID_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Login")))
                        reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Entregue")))
                        reg.Qtd_entregue = reader.GetDecimal(reader.GetOrdinal("QTD_Entregue"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Entrega")))
                        reg.Dt_entrega = reader.GetDateTime(reader.GetOrdinal("DT_Entrega"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Motivo_recontar")))
                        reg.Ds_motivo_recontar = reader.GetString(reader.GetOrdinal("DS_Motivo_Recontar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_Estoque")))
                        reg.Qtd_estoque = reader.GetDecimal(reader.GetOrdinal("Qtd_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtd_pedido")))
                        reg.Qtd_pedido = reader.GetDecimal(reader.GetOrdinal("Qtd_pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_pedidosaida")))
                        reg.Qtd_pedidoSaida = reader.GetDecimal(reader.GetOrdinal("qtd_pedidosaida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    //Dados alocacao almoxarifado
                    if (!reader.IsDBNull(reader.GetOrdinal("id_almox")))
                        reg.Id_almox = reader.GetDecimal(reader.GetOrdinal("id_almox"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_almoxarifado")))
                        reg.Ds_almoxarifado = reader.GetString(reader.GetOrdinal("ds_almoxarifado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_rua")))
                        reg.Id_rua = reader.GetDecimal(reader.GetOrdinal("id_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_rua")))
                        reg.Ds_rua = reader.GetString(reader.GetOrdinal("ds_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_secao")))
                        reg.Id_secao = reader.GetDecimal(reader.GetOrdinal("id_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_secao")))
                        reg.Ds_secao = reader.GetString(reader.GetOrdinal("ds_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_celula")))
                        reg.Id_celula = reader.GetDecimal(reader.GetOrdinal("id_celula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_celula")))
                        reg.Ds_celula = reader.GetString(reader.GetOrdinal("ds_celula"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
        }

        public string Gravar(TRegistro_EntregaPedido val)
        {
            Hashtable hs = new Hashtable(10);
            hs.Add("@P_ID_ENTREGA", val.Id_entrega);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_LOGIN", val.Login);
            hs.Add("@P_QTD_ENTREGUE", val.Qtd_entregue);
            hs.Add("@P_DT_ENTREGA", val.Dt_entrega);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_DS_MOTIVO_RECONTAR", val.Ds_motivo_recontar);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FAT_ENTREGAPEDIDO", hs);
        }

        public string Excluir(TRegistro_EntregaPedido val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_ENTREGA", val.Id_entrega);

            return this.executarProc("EXCLUI_FAT_ENTREGAPEDIDO", hs);
        }
    }
}
