using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;
using Utils;
using CamadaDados.Faturamento.LoteAnvisa;

namespace CamadaDados.Estoque
{
    #region Estoque
    public class TList_RegLanEstoque : List<TRegistro_LanEstoque>, IComparer<TRegistro_LanEstoque>
    {
        #region IComparer<TRegistro_LanEstoque> Members
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

        public TList_RegLanEstoque()
        { }

        public TList_RegLanEstoque(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanEstoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanEstoque x, TRegistro_LanEstoque y)
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
    
    public class TRegistro_LanEstoque
    {
        public string Cd_empresa
        {
            get;
            set;
        }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        {
            get;
            set;
        }
        public string Ds_produto
        { get; set; }
        private decimal? id_variedade;
        public decimal? Id_variedade
        {
            get { return id_variedade; }
            set
            {
                id_variedade = value;
                id_variedadestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_variedadestr;
        public string Id_variedadestr
        {
            get { return id_variedadestr; }
            set
            {
                id_variedadestr = value;
                try
                {
                    id_variedade = decimal.Parse(value);
                }
                catch { id_variedade = null; }
            }
        }
        public string Ds_variedade
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Ds_grupo
        { get; set; }
        public decimal Id_lanctoestoque
        {
            get;
            set;
        }
        public string Cd_local
        {
            get;
            set;
        }
        public string Ds_local
        { get; set; }
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set { dt_lancto = value;
                _dt_lancto_STR = (value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty);
            }
        }
        private string _dt_lancto_STR;
        public string Dt_lancto_STR
        {
            get
            {
                try
                {
                    return Convert.ToDateTime(_dt_lancto_STR).ToString("dd/MM/yyyy");
                }
                catch { return ""; }
            }
            set
            {
                _dt_lancto_STR = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch { dt_lancto = null; }
            }
        }
        private string tp_movimento;
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set { 
                tp_movimento = value; 
             if (value == "E")
                  { tp_movimento_String = "ENTRADA";
                    _ST_Quantidade_Entrada = true;
                    _ST_Quantidade_Saida = false;
                  }
                    else
                if (value == "S")
                { tp_movimento_String = "SAIDA";
                  _ST_Quantidade_Entrada = false;
                  _ST_Quantidade_Saida = true;
                }
            }
        
        }
        private string tp_movimento_String;
        public string Tp_movimento_String
        {
            get { return tp_movimento_String; }
            set { tp_movimento_String = value;
               if (value == "E")
              { tp_movimento_String = "ENTRADA";
              _ST_Quantidade_Entrada = true;
              _ST_Quantidade_Saida = false;
              }
              else
                if (value == "S")
                { tp_movimento_String = "SAIDA";
                _ST_Quantidade_Entrada = false;
                _ST_Quantidade_Saida = true;
                }
            }
        }
        private decimal qtd_entrada;
        public decimal Qtd_entrada
        {
            get { return qtd_entrada; }
            set { qtd_entrada = value;
            _saldo = qtd_entrada - qtd_saida;
            }
        }
        private decimal qtd_saida;
        public decimal Qtd_saida
        {
            get { return qtd_saida; }
            set { qtd_saida = value;
            _saldo = qtd_entrada - qtd_saida;
            }
        }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return vl_subtotal; }
            set { vl_subtotal = value; }
        }
        private decimal vl_medioestoque;
        public decimal Vl_medioestoque
        {
            get { return vl_medioestoque; }
            set { vl_medioestoque = value; }
        }
        public decimal Vl_UEPS
        { get; set; }
        private string tp_lancto;
        public string Tp_lancto
        {
            get { return tp_lancto; }
            set 
            { 
                tp_lancto = value;
                if (value.Equals("M"))
                    _TP_Lancto_String = "MANUAL";
                else if (value.Equals("N"))
                    _TP_Lancto_String = "NORMAL";
                else if (value.Equals("I"))
                    _TP_Lancto_String = "INVENTÁRIO";
                else if (value.Equals("P"))
                    _TP_Lancto_String = "PROVISÃO";
                else if (value.Equals("T"))
                    _TP_Lancto_String = "TRANSFERÊNCIA";
                else if (value.Equals("L"))
                    _TP_Lancto_String = "COMP/DEV";
            }
        }
        private string _TP_Lancto_String;
        public string TP_Lancto_String
        {
            get { return _TP_Lancto_String; }
            set 
            { 
                _TP_Lancto_String = value;
                if (value.Equals("MANUAL"))
                    tp_lancto = "M";
                else if (value.Equals("NORMAL"))
                    tp_lancto = "N";
                else if (value.Equals("INVENTÁRIO"))
                    tp_lancto = "I";
                else if (value.Equals("PROVISÃO"))
                    tp_lancto = "P";
                else if (value.Equals("TRANSFERÊNCIA"))
                    tp_lancto = "T";
                else if (value.Equals("COMP/DEV"))
                    tp_lancto = "L";
            }
        }
        private string ds_observacao;
        public string Ds_observacao
        {
            get { return ds_observacao; }
            set { ds_observacao = value; }
        }
        private string st_registro;
        public string St_registro
        {
            get { return st_registro; }
            set { st_registro = value;
            if (value == "A")
            {
                _st_registro_String = "Ativo";
                _st_registro_Bool = false;
            }
            else
                if (value == "C")
                {
                    _st_registro_String = "Cancelado";
                    _st_registro_Bool = true;
                }
            }
        }
        private string _st_registro_String;
        public string St_registro_String
        {
            get { return _st_registro_String; }
            set { _st_registro_String = value;
            if (value == "Ativo")
            {
                 st_registro = "A";
                _st_registro_Bool = false;
            }
            else
                if (value == "Cancelado")
                {
                     st_registro = "C";
                    _st_registro_Bool = true;
                }
            }
        }
        private bool _st_registro_Bool;
        public bool St_registro_Bool
        {
            get { return _st_registro_Bool; }
            set { _st_registro_Bool = value;
            if (value == false)
            {
                _st_registro_String = "Ativo";
                st_registro = "A";
            }
            else
                if (value == true)
                {
                    _st_registro_String = "Cancelado";
                    st_registro = "C";
                }
            }
        }
        private decimal _saldo;
        public decimal Saldo
        {
            get {
                _saldo = qtd_entrada - qtd_saida;
                return _saldo; }
            set { _saldo = value; }
        }
        private string _Sigla_Unidade;
        public string Sigla_Unidade
        {
            get { return _Sigla_Unidade; }
            set { _Sigla_Unidade = value; }
        }
        private bool _ST_Quantidade_Entrada;
        public bool ST_Quantidade_Entrada
        {
            get { return _ST_Quantidade_Entrada; }
            set { _ST_Quantidade_Entrada = value; }
        }
        private bool _ST_Quantidade_Saida;
        public bool ST_Quantidade_Saida
        {
            get { return _ST_Quantidade_Saida; }
            set { _ST_Quantidade_Saida = value; }
        }
        public decimal Qt_min_estoque
        { get; set; }
        public TList_MovLoteAnvisa lMovLoteAnvisa
        { get; set; }
        public Cadastros.TList_ValorCaracteristica lGrade { get; set; } = new Cadastros.TList_ValorCaracteristica();
        public decimal? Id_Rua { get; set; }
        public decimal? Id_Secao { get; set; }
        public decimal? Id_Celula { get; set; }


        public string Ds_Rua { get; set; }
        public string Ds_Secao { get; set; }
        public string Ds_Celula { get; set; }

        public TRegistro_LanEstoque()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Id_Rua = null;
            Id_Secao = null;
            Id_Celula = null;
            Ds_Rua = string.Empty;
            Ds_Secao = string.Empty;
            Ds_Celula = string.Empty;
            Ds_produto = string.Empty;
            id_variedade = null;
            id_variedadestr = string.Empty;
            Ds_variedade = string.Empty;
            Cd_grupo = string.Empty;
            Ds_grupo = string.Empty;
            Id_lanctoestoque = decimal.Zero;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            dt_lancto = DateTime.Now;
            Dt_lancto_STR = DateTime.Now.ToString(); 
            tp_movimento = string.Empty;
            qtd_entrada = decimal.Zero;
            qtd_saida = decimal.Zero;
            vl_unitario = decimal.Zero;
            vl_subtotal = decimal.Zero;
            vl_medioestoque = decimal.Zero;
            Vl_UEPS = decimal.Zero;
            tp_lancto = string.Empty;
            TP_Lancto_String = string.Empty;
            Qt_min_estoque = decimal.Zero;
            st_registro = "A";
            St_registro_String = "ATIVO";
            St_registro_Bool = false;
            lMovLoteAnvisa = new TList_MovLoteAnvisa();
        }
    }
    
    public class TRegistro_SaldoEstoque
    {
        public string Cd_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Ds_abreviadaProduto
        { get; set; }
        public decimal Tot_entrada
        { get; set; }
        public decimal Tot_saida
        { get; set; }
        public decimal Tot_saldo
        { get; set; }
        public decimal Vl_estoque_ent
        { get; set; }
        public decimal Vl_estoque_sai
        { get; set; }
        public decimal Vl_saldoestoque
        { get; set; }
        public decimal Vl_medio
        { get; set; }
        public decimal Vl_ueps
        { get; set; }

        public TRegistro_SaldoEstoque()
        {
            Cd_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Ds_abreviadaProduto = string.Empty;
            Tot_entrada = decimal.Zero;
            Tot_saida = decimal.Zero;
            Tot_saldo = decimal.Zero;
            Vl_estoque_ent = decimal.Zero;
            Vl_estoque_sai = decimal.Zero;
            Vl_saldoestoque = decimal.Zero;
            Vl_medio = decimal.Zero;
            Vl_ueps = decimal.Zero;
        }
    }

    public class TCD_LanEstoque : TDataQuery
    {
        public TCD_LanEstoque()
        { }

        public TCD_LanEstoque(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public TCD_LanEstoque(string vNM_ProcSqlBusca)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        public TCD_LanEstoque(string vNM_ProcSqlBusca, BancoDados.TObjetoBanco banco)
        {
            NM_ProcSqlBusca = vNM_ProcSqlBusca;
            Banco_Dados = banco;
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " A.CD_Empresa, A.CD_Produto, A.Id_LanctoEstoque, ");
                sql.AppendLine("A.CD_Local, A.DT_Lancto, A.TP_Movimento, A.QTD_Entrada, A.QTD_Saida, ");
                sql.AppendLine("A.Vl_Unitario, A.Vl_Subtotal, A.Tp_Lancto, A.ST_Registro, A.DS_Observacao, ");
                sql.AppendLine("B.NM_Empresa, E.DS_Local, C.DS_Produto, f.sigla_Unidade, ");
                sql.AppendLine("c.cd_grupo, gp.ds_grupo, h.qt_min_estoque, a.id_variedade, vr.ds_variedade, ");
                sql.AppendLine("Vl_MedioEstoque = isnull((select x.vl_medio from vtb_est_vlestoque x ");
                sql.AppendLine("                            where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                            and x.cd_produto = a.cd_produto), 0), ");
                sql.AppendLine("Vl_UEPS = isnull(dbo.F_FAT_ULTIMACOMPRA(a.cd_empresa, a.cd_produto), 0), c.id_rua, c.id_secao,c.id_celula,r.ds_rua, s.ds_secao, ca.ds_celula  ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_EST_Estoque A ");
            sql.AppendLine("INNER JOIN TB_DIV_Empresa B ");
            sql.AppendLine("on A.CD_Empresa = B.CD_Empresa");
            sql.AppendLine("INNER JOIN TB_EST_Produto C ");
            sql.AppendLine("ON A.CD_Produto = C.CD_Produto");
            sql.AppendLine("INNER JOIN TB_EST_GrupoProduto gp ");
            sql.AppendLine("ON c.cd_grupo = gp.cd_grupo ");
            sql.AppendLine("INNER JOIN TB_EST_TpProduto tp ");
            sql.AppendLine("ON c.tp_produto = tp.tp_produto ");
            sql.AppendLine("LEFT OUTER join TB_EST_LocalArm E ");
            sql.AppendLine("ON A.CD_Local = E.CD_Local");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_UNIDADE F ");
            sql.AppendLine("ON F.CD_Unidade = c.cd_unidade");
            sql.AppendLine("LEFT OUTER JOIN TB_Est_prov_x_estoque g ");
            sql.AppendLine("on a.id_lanctoestoque = g.id_lanctoestoque ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_Produto_QTDEstoque h ");
            sql.AppendLine("on a.cd_produto = h.cd_produto ");
            sql.AppendLine("and a.cd_empresa = h.cd_empresa ");
            sql.AppendLine("LEFT OUTER JOIN TB_EST_Variedade vr ");
            sql.AppendLine("on a.cd_produto = vr.cd_produto ");
            sql.AppendLine("and a.id_variedade = vr.id_variedade ");
            sql.AppendLine("left join TB_AMX_Rua r ");
            sql.AppendLine("on c.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_Secao s ");
            sql.AppendLine("on c.id_secao = s.id_secao and s.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_CelulaArm ca ");
            sql.AppendLine("on ca.id_celula = c.id_celula and ca.id_secao = s.id_secao and ca.id_rua = r.id_rua");

            sql.AppendLine("where isnull(tp.st_composto, 'N') <> 'S' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            if (vGroup.Trim() != string.Empty)
                sql.AppendLine(" group by " + vGroup.Trim());
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine(" order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaSinteticoEstoque(TpBusca[] filtro, string vNm_campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();
            if (vNm_campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select a.cd_empresa, d.NM_Empresa, ");
                sql.AppendLine("a.cd_produto, b.DS_Produto, c.Sigla_Unidade, ");
                sql.AppendLine("a.Tot_Entrada, a.Tot_Saida, a.Tot_Saldo, ");
                sql.AppendLine("a.Vl_Estoque_ent, a.Vl_Estoque_sai, ");
                sql.AppendLine("a.Vl_SaldoEstoque, a.Vl_Medio, ");
                sql.AppendLine("vl_custocontabil = ISNULL(a.Tot_Saldo, 0) * ISNULL(a.Vl_Medio, 0), ");
                sql.AppendLine("vl_ultimacompra = DBO.F_FAT_ULTIMACOMPRA(A.CD_EMPRESA, A.CD_PRODUTO), ");
                sql.AppendLine("Qtd_reservada = ISNULL((select sum(isnull(x.qtd_saldoreserva, 0)) ");
                sql.AppendLine("                        from VTB_FAT_RESERVAESTPEDIDO x ");
                sql.AppendLine("                        where a.cd_empresa = x.cd_empresa ");
                sql.AppendLine("                        and a.cd_produto = x.cd_produto), 0), ");
                sql.AppendLine("qt_min_estoque = isnull((select QT_Min_Estoque ");
                sql.AppendLine("                        from TB_EST_Produto_QTDEstoque x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto), 0), ");
                sql.AppendLine("saldo_minimo = a.tot_saldo - isnull((select QT_Min_Estoque ");
                sql.AppendLine("                        from TB_EST_Produto_QTDEstoque x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto), 0), b.id_rua, b.id_secao,b.id_celula,r.ds_rua, s.ds_secao, ca.ds_celula ");
            }
            else
                sql.AppendLine("select " + vNm_campo.Trim() + " ");
            sql.AppendLine("from VTB_EST_VLESTOQUE a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_empresa = d.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_TpProduto e ");
            sql.AppendLine("on b.tp_produto = e.tp_produto ");
            sql.AppendLine("left join TB_AMX_Rua r ");
            sql.AppendLine("on b.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_Secao s ");
            sql.AppendLine("on b.id_secao = s.id_secao and s.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_CelulaArm ca ");
            sql.AppendLine("on ca.id_celula = b.id_celula and ca.id_secao = s.id_secao and ca.id_rua = r.id_rua");

            sql.AppendLine("where ISNULL(b.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(e.st_composto, 'N') <> 'S'");
            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());

            return sql.ToString();
        }
        private string SqlCodeBuscaSinteticoEstoqueSaldo(TpBusca[] filtro, string vNm_campo, string vOrder)
        {
            StringBuilder sql = new StringBuilder();
            if (vNm_campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select  b.id_rua, b.id_secao,b.id_celula,r.ds_rua, s.ds_secao, ca.ds_celula , a.cd_empresa, d.NM_Empresa, ");
                sql.AppendLine("a.cd_produto, b.DS_Produto, c.Sigla_Unidade, ");
                sql.AppendLine("a.Tot_Entrada, a.Tot_Saida, a.Tot_Saldo, ");
                sql.AppendLine("a.Vl_Estoque_ent, a.Vl_Estoque_sai, ");
                sql.AppendLine("a.Vl_SaldoEstoque, a.Vl_Medio, ");
                sql.AppendLine("vl_custocontabil = ISNULL(a.Tot_Saldo, 0) * ISNULL(a.Vl_Medio, 0), ");
                sql.AppendLine("vl_ultimacompra = DBO.F_FAT_ULTIMACOMPRA(A.CD_EMPRESA, A.CD_PRODUTO), ");
                sql.AppendLine("qt_min_estoque = isnull((select QT_Min_Estoque ");
                sql.AppendLine("                        from TB_EST_Produto_QTDEstoque x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto), 0), ");
                sql.AppendLine("saldo_minimo = a.tot_saldo - isnull((select QT_Min_Estoque ");
                sql.AppendLine("                        from TB_EST_Produto_QTDEstoque x ");
                sql.AppendLine("                        where x.cd_empresa = a.cd_empresa ");
                sql.AppendLine("                        and x.cd_produto = a.cd_produto), 0), ");
                sql.AppendLine("                        qtd_requisicao = (select isnull(sum(o.quantidade),0) from tb_cmp_requisicao o ");
				sql.AppendLine("                        	where o.cd_produto = a.cd_produto and a.cd_empresa = o.CD_Empresa ");
				sql.AppendLine("                        	and isnull((select top 1 x.Nr_Pedido from TB_FAT_Pedido_Itens x ");
				sql.AppendLine("                        	inner join TB_CMP_OrdemCompra_X_PedItem y ");
				sql.AppendLine("                        	on x.CD_Produto = y.CD_Produto ");
				sql.AppendLine("                        	and x.Nr_Pedido = y.Nr_Pedido ");
				sql.AppendLine("                        	and x.ID_PedidoItem = y.ID_PedidoItem ");
				sql.AppendLine("                        	inner join TB_CMP_OrdemCompra h ");
				sql.AppendLine("                        	on y.ID_OC = h.ID_OC ");
				sql.AppendLine("                        	join vtb_fat_pedido ped on ped.nr_pedido = x.nr_pedido ");
				sql.AppendLine("                        	where ped.vl_totalfat_entrada > 0 ");
				sql.AppendLine("                        	and a.CD_Empresa = h.CD_Empresa ");
				sql.AppendLine("                        	and a.CD_Produto = x.CD_Produto ");
				sql.AppendLine("                        	and o.ID_Requisicao = h.ID_Requisicao ");
				sql.AppendLine("                        	and h.ST_Registro <> 'C' ");
				sql.AppendLine("                        	and x.ST_Registro <> 'C'), 0) = 0), ");
                sql.AppendLine("                        qtd_orcamento = ( select isnull(sum(x.quantidade),0) from TB_FAT_Orcamento_Item x ");
				sql.AppendLine("                            join TB_EST_Produto_QTDEstoque z on x.cd_produto = z.cd_produto ");
				sql.AppendLine("                            join vTB_FAT_Orcamento op on x.nr_orcamento = op.NR_Orcamento ");
				sql.AppendLine("                            where x.cd_produto = a.cd_produto and op.st_registro = 'AB'), ");
                sql.AppendLine("                        qtd_pedido = (select isnull(sum(o.quantidade),0) from tb_fat_pedido_itens o ");
				sql.AppendLine("                            join TB_EST_Produto_QTDEstoque z on o.cd_produto = z.cd_produto ");
                sql.AppendLine("                            join vtb_fat_pedido pe on o.Nr_Pedido = pe.Nr_Pedido where o.cd_produto = a.cd_produto and pe.vl_totalfat_entrada = 0), ");
                sql.AppendLine("saldo_total = ( ( isnull( ");
                sql.AppendLine("        		    a.tot_saldo , 0) ");
                sql.AppendLine("                        	+ ");
				sql.AppendLine("                        		(select isnull(sum(o.quantidade),0) from tb_cmp_requisicao o ");
				sql.AppendLine("                        		where o.cd_produto = a.cd_produto and a.cd_empresa = o.CD_Empresa ");
				sql.AppendLine("                        		and isnull((select top 1 x.Nr_Pedido from TB_FAT_Pedido_Itens x ");
				sql.AppendLine("                        		inner join TB_CMP_OrdemCompra_X_PedItem y ");
				sql.AppendLine("                        		on x.CD_Produto = y.CD_Produto ");
				sql.AppendLine("                        		and x.Nr_Pedido = y.Nr_Pedido ");
				sql.AppendLine("                        		and x.ID_PedidoItem = y.ID_PedidoItem ");
				sql.AppendLine("                        		inner join TB_CMP_OrdemCompra h ");
				sql.AppendLine("                        		on y.ID_OC = h.ID_OC ");
				sql.AppendLine("                        		join vtb_fat_pedido ped on ped.nr_pedido = x.nr_pedido ");
				sql.AppendLine("                        		where ped.vl_totalfat_entrada > 0 ");
				sql.AppendLine("                        		and a.CD_Empresa = h.CD_Empresa ");
				sql.AppendLine("                        		and a.CD_Produto = x.CD_Produto ");
				sql.AppendLine("                        		and o.ID_Requisicao = h.ID_Requisicao ");
                sql.AppendLine("                        		and h.ST_Registro <> 'C' ");
				sql.AppendLine("                        		and x.ST_Registro <> 'C'), 0) = 0 ) ");
				sql.AppendLine("                        	) - (   ");
				sql.AppendLine("                        		( select isnull(sum(x.quantidade),0) from TB_FAT_Orcamento_Item x ");
				sql.AppendLine("                        		join TB_EST_Produto_QTDEstoque z on x.cd_produto = z.cd_produto ");
				sql.AppendLine("                        		join vTB_FAT_Orcamento op on x.nr_orcamento = op.NR_Orcamento ");
				sql.AppendLine("                        		where x.cd_produto = a.cd_produto and op.st_registro = 'AB') ");
				sql.AppendLine("                        	+ ");
				sql.AppendLine("                        		(select isnull(sum(o.quantidade),0) from tb_fat_pedido_itens o ");
				sql.AppendLine("                        		join TB_EST_Produto_QTDEstoque z on o.cd_produto = z.cd_produto ");
                sql.AppendLine("                        		join vtb_fat_pedido pe on o.Nr_Pedido = pe.Nr_Pedido where o.cd_produto = a.cd_produto and pe.vl_totalfat_entrada = 0 and pe.st_pedido <> 'P'");
                sql.AppendLine("                        		) ) ");
				sql.AppendLine("                        	) ");
            }
            else
            {
                sql.AppendLine("select " +vNm_campo + "");
            }
            sql.AppendLine("from VTB_EST_VLESTOQUE a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on b.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("inner join TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_empresa = d.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_TpProduto e ");
            sql.AppendLine("on b.tp_produto = e.tp_produto ");
            sql.AppendLine("left join TB_AMX_Rua r ");
            sql.AppendLine("on b.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_Secao s ");
            sql.AppendLine("on b.id_secao = s.id_secao and s.id_rua = r.id_rua ");
            sql.AppendLine("left join TB_AMX_CelulaArm ca ");
            sql.AppendLine("on ca.id_celula = b.id_celula and ca.id_secao = s.id_secao and ca.id_rua = r.id_rua");
            sql.AppendLine("where ISNULL(b.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and e.st_composto <> 'S' ");
            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
            if (vOrder.Trim() != string.Empty)
                sql.AppendLine("order by " + vOrder.Trim());

            return sql.ToString();
        }
        public System.Data.DataTable BuscarEstoqueSintetico(TpBusca[] filtro, string vNm_campo, string vOrder)
        {
            return ExecutarBusca(SqlCodeBuscaSinteticoEstoque(filtro, vNm_campo, vOrder), null);
        }
        public System.Data.DataTable BuscarEstoqueSinteticoSaldo(TpBusca[] filtro, string vNm_campo, string vOrder)
        {
            return ExecutarBusca(SqlCodeBuscaSinteticoEstoqueSaldo(filtro, vNm_campo, vOrder), null);
        }

        public object BuscarEstoqueSintenticoEscalar(TpBusca[] filtro, string vNm_campo)
        {
            return executarEscalar(SqlCodeBuscaSinteticoEstoque(filtro, vNm_campo, string.Empty), null);
        }
        public object BuscarEstoqueSintenticoSaldoEscalar(TpBusca[] filtro, string vNm_campo)
        {
            return executarEscalar(SqlCodeBuscaSinteticoEstoqueSaldo(filtro, vNm_campo, string.Empty), null);
        }
        public string SqlCodeBuscaSaldo_Estoque(TpBusca[] vBusca, Int32 vTop, string vNm_campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if(vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (vNm_campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.cd_produto, a.tot_entrada, a.tot_saida, ");
                sql.AppendLine("b.ds_produto, b.DS_AbreviadaProduto, a.tot_saldo, a.vl_estoque_ent, ");
                sql.AppendLine("a.vl_estoque_sai, a.vl_saldoestoque, a.vl_medio, a.vl_ueps ");
            }
            else
                sql.AppendLine("select " + strTop + " " + vNm_campo.Trim() + " ");
            sql.AppendLine("from vtb_est_vlestoque a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_tpproduto c ");
            sql.AppendLine("on b.tp_produto = c.tp_produto ");

            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vGroup))
                sql.AppendLine("group by " + vGroup.Trim());
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }
        
        public string SqlCodeBuscaSaldo_EstoqueLocal(TpBusca[] vBusca, Int32 vTop, string vNm_campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNm_campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, a.cd_produto, ");
                sql.AppendLine("b.ds_produto, a.cd_local, c.ds_local, ");
                sql.AppendLine("a.tot_entrada, a.tot_saida, a.tot_saldo, ");
                sql.AppendLine("a.vl_estoque_ent, a.vl_estoque_sai, ");
                sql.AppendLine("a.vl_saldoestoque, a.vl_medio, a.vl_ueps ");
            }
            else
                sql.AppendLine("select " + strTop + " " + vNm_campo.Trim() + " ");
            sql.AppendLine("from VTB_EST_VLESTOQUELOCAL a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join TB_EST_LocalArm c ");
            sql.AppendLine("on a.cd_local = c.cd_local ");
            string cond = " where ";
            if (vBusca != null)
                foreach (TpBusca filtro in vBusca)
                {
                    sql.AppendLine(cond + "(" + filtro.vNM_Campo + " " + filtro.vOperador + " " + filtro.vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public System.Data.DataTable BuscarSaldo_EstoqueLocal(TpBusca[] vBusca, Int32 vTop, string vNm_campo, string vGroup)
        {
            return ExecutarBusca(SqlCodeBuscaSaldo_EstoqueLocal(vBusca, vTop, vNm_campo), null);
        }

        public object BuscarSaldo_EstoqueEscalar(TpBusca[] vBusca, string vNm_campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBuscaSaldo_Estoque(vBusca, 1, vNm_campo, string.Empty, string.Empty), null);
        }

        public System.Data.DataTable BuscarSaldo_Estoque(TpBusca[] vBusca, Int32 vTop, string vNm_campo, string vGroup)
        {
            return ExecutarBusca(SqlCodeBuscaSaldo_Estoque(vBusca, vTop, vNm_campo, vGroup, string.Empty), null);
        }
                
        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), vParametros);    
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
            else
                return ExecutarBuscaEscalar(GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, 1, vNM_Campo }).ToString(), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (string.IsNullOrEmpty(NM_ProcSqlBusca))
                return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo, vGroup, vOrder), vParametros);
            else
                return ExecutarBuscaEscalar(GetType().GetMethod(NM_ProcSqlBusca).Invoke(this, new object[] { vBusca, 1, vNM_Campo, vGroup, vOrder }).ToString(), null);
        }

        public decimal BuscarVlEstoqueUltimaCompra(string Cd_empresa,
                                                   string Cd_produto)
        {
            if ((!string.IsNullOrEmpty(Cd_empresa)) &&
                (!string.IsNullOrEmpty(Cd_produto)))
            {
                Hashtable hs = new Hashtable(3);
                hs.Add("@CD_PRODUTO", Cd_produto.Trim());
                hs.Add("@CD_EMPRESA", Cd_empresa.Trim());
                hs.Add("@QUANTIDADE_RET", 1);
                hs.Add("@@VL_TOT", 0);
                string retorno = executarProc("CONSULTA_VL_ESTOQUE", hs);
                try
                {
                    return decimal.Parse(getPubVariavel(retorno, "@@VL_TOT"));
                }
                catch
                { return decimal.Zero; }
            }
            else
                return decimal.Zero;
        }

        public decimal BuscarVlUltimaCompra(string Cd_empresa, string Cd_produto)
        {
            if (!string.IsNullOrWhiteSpace(Cd_empresa) && !string.IsNullOrWhiteSpace(Cd_produto))
            {
                Hashtable hs = new Hashtable(2);
                hs.Add("@P_CD_EMPRESA", Cd_empresa);
                hs.Add("@P_CD_PRODUTO", Cd_produto);
                try
                {
                    return decimal.Parse(getPubVariavel(executarProc("F_FAT_ULTIMACOMPRA", hs), "@RETURN_VALUE"));
                }
                catch { return decimal.Zero; }
            }
            else return decimal.Zero;
        }

        public TList_RegLanEstoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            TList_RegLanEstoque lista = new TList_RegLanEstoque();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vGroup, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanEstoque reg = new TRegistro_LanEstoque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_variedade")))
                        reg.Id_variedade = reader.GetDecimal(reader.GetOrdinal("id_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_variedade")))
                        reg.Ds_variedade = reader.GetString(reader.GetOrdinal("ds_variedade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("CD_Grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Grupo")))
                        reg.Ds_grupo = reader.GetString(reader.GetOrdinal("DS_Grupo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque"))))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Local"))))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Lancto"))))
                        reg.Dt_lancto = reader.GetDateTime(reader.GetOrdinal("DT_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Movimento"))))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Entrada"))))
                        reg.Qtd_entrada = reader.GetDecimal(reader.GetOrdinal("QTD_Entrada"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Saida"))))
                        reg.Qtd_saida = reader.GetDecimal(reader.GetOrdinal("QTD_Saida"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("VL_Unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_SubTotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("VL_SubTotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_MedioEstoque"))))
                        reg.Vl_medioestoque = reader.GetDecimal(reader.GetOrdinal("Vl_MedioEstoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_UEPS"))))
                        reg.Vl_UEPS = reader.GetDecimal(reader.GetOrdinal("Vl_UEPS"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Lancto"))))
                        reg.Tp_lancto = reader.GetString(reader.GetOrdinal("TP_Lancto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade"))))
                        reg.Sigla_Unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Min_Estoque")))
                        reg.Qt_min_estoque = reader.GetDecimal(reader.GetOrdinal("QT_Min_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_rua")))
                        reg.Id_Rua = reader.GetDecimal(reader.GetOrdinal("id_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_rua")))
                        reg.Ds_Rua = reader.GetString(reader.GetOrdinal("ds_rua"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_secao")))
                        reg.Id_Secao = reader.GetDecimal(reader.GetOrdinal("id_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_secao")))
                        reg.Ds_Secao = reader.GetString(reader.GetOrdinal("ds_secao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Celula")))
                        reg.Id_Celula = reader.GetDecimal(reader.GetOrdinal("Id_Celula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_Celula")))
                        reg.Ds_Celula = reader.GetString(reader.GetOrdinal("Ds_Celula"));

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

        public List<TRegistro_SaldoEstoque> SelectSaldoEstoque(TpBusca[] vBusca)
        {
            List<TRegistro_SaldoEstoque> lista = new List<TRegistro_SaldoEstoque>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBuscaSaldo_Estoque(vBusca, 0, string.Empty, string.Empty, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaldoEstoque reg = new TRegistro_SaldoEstoque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_AbreviadaProduto")))
                        reg.Ds_abreviadaProduto = reader.GetString(reader.GetOrdinal("DS_AbreviadaProduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tot_entrada")))
                        reg.Tot_entrada = reader.GetDecimal(reader.GetOrdinal("tot_entrada"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tot_saida"))))
                        reg.Tot_saida = reader.GetDecimal(reader.GetOrdinal("tot_saida"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("tot_saldo"))))
                        reg.Tot_saldo = reader.GetDecimal(reader.GetOrdinal("tot_saldo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_estoque_ent"))))
                        reg.Vl_estoque_ent = reader.GetDecimal(reader.GetOrdinal("vl_estoque_ent"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_estoque_sai"))))
                        reg.Vl_estoque_sai = reader.GetDecimal(reader.GetOrdinal("vl_estoque_sai"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_saldoestoque"))))
                        reg.Vl_saldoestoque = reader.GetDecimal(reader.GetOrdinal("vl_saldoestoque"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_medio"))))
                        reg.Vl_medio = reader.GetDecimal(reader.GetOrdinal("vl_medio"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_ueps"))))
                        reg.Vl_ueps = reader.GetDecimal(reader.GetOrdinal("vl_ueps"));

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

        public string GravaEstoque(TRegistro_LanEstoque val)
        {
            Hashtable hs = new Hashtable(14);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_VARIEDADE", val.Id_variedade);
            hs.Add("@@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_QTD_ENTRADA", val.Qtd_entrada);
            hs.Add("@P_QTD_SAIDA", val.Qtd_saida);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_TP_LANCTO", val.Tp_lancto);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("INCLUI_EST_ESTOQUE", hs);
        }

        public string DeletaEstoque(TRegistro_LanEstoque val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            return executarProc("EXCLUI_EST_ESTOQUE", hs);
        }

        public void CancelarEstoque(TRegistro_LanEstoque val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);

            executarProc("CANCELA_EST_ESTOQUE", hs);
        }

        public string AcertarVlMedio(TRegistro_LanEstoque val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_CD_LOCAL", val.Cd_local);
            hs.Add("@P_VL_CUSTOMEDIO", val.Vl_medioestoque);
            hs.Add("@P_DT_LANCTO", val.Dt_lancto);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return executarProc("STP_EST_ACERTOVLMEDIO", hs);
        }
    }
    #endregion

    #region "Classe Reserva Saldo Estoque"
    public class TList_ReservaEstoque : List<TRegistro_ReservaEstoque>, IComparer<TRegistro_ReservaEstoque>
    {
        #region IComparer<TRegistro_ReservaEstoque> Members
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

        public TList_ReservaEstoque()
        { }

        public TList_ReservaEstoque(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_ReservaEstoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_ReservaEstoque x, TRegistro_ReservaEstoque y)
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
    
    public class TRegistro_ReservaEstoque
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_local
        { get; set; }
        
        public string Ds_local
        { get; set; }
        
        public string Sigla_unidade
        { get; set; }
        
        public decimal Qtd_reservada
        { get; set; }
        
        public decimal Qtd_saidaest
        { get; set; }
        
        public decimal Qtd_entradaest
        { get; set; }
        
        public decimal Qtd_saldoreserva
        { get; set; }
        
        public decimal Qtd_estoque
        { get; set; }
        
        public decimal Qtd_saldofuturo
        { get; set; }

        public TRegistro_ReservaEstoque()
        {
            Cd_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_local = string.Empty;
            Ds_local = string.Empty;
            Sigla_unidade = string.Empty;
            Qtd_reservada = decimal.Zero;
            Qtd_saidaest = decimal.Zero;
            Qtd_entradaest = decimal.Zero;
            Qtd_saldoreserva = decimal.Zero;
            Qtd_estoque = decimal.Zero;
            Qtd_saldofuturo = decimal.Zero;
        }
    }

    public class TCD_ReservaEstoque : TDataQuery
    {
        public TCD_ReservaEstoque()
        { }

        public TCD_ReservaEstoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Trim().Equals(string.Empty))
            {
                sql.AppendLine("Select " + strTop + " a.cd_empresa, a.cd_produto, b.ds_produto, c.sigla_unidade, ");
                sql.AppendLine("a.qtd_reservada, a.qtd_saidaest, a.qtd_entradaest, a.qtd_saldoreserva, ");
                sql.AppendLine("a.qtd_estoque, a.qtd_saldofuturo, a.cd_local, d.ds_local ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_EST_RESERVAESTOQUE a ");
            sql.AppendLine("inner join tb_est_produto b ");
            sql.AppendLine("on a.cd_produto = b.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade c ");
            sql.AppendLine("on b.cd_unidade = c.cd_unidade ");
            sql.AppendLine("inner join tb_est_localarm d ");
            sql.AppendLine("on a.cd_local = d.cd_local ");

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

        public TList_ReservaEstoque Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_ReservaEstoque lista = new TList_ReservaEstoque();

            bool podeFecharBco = false;

            if (Banco_Dados == null)
            {
                CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ReservaEstoque reg = new TRegistro_ReservaEstoque();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("Sigla_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Reservada")))
                        reg.Qtd_reservada = reader.GetDecimal(reader.GetOrdinal("QTD_Reservada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_SaidaEst")))
                        reg.Qtd_saidaest = reader.GetDecimal(reader.GetOrdinal("QTD_SaidaEst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_EntradaEst")))
                        reg.Qtd_entradaest = reader.GetDecimal(reader.GetOrdinal("QTD_EntradaEst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_SaldoReserva")))
                        reg.Qtd_saldoreserva = reader.GetDecimal(reader.GetOrdinal("QTD_SaldoReserva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Estoque")))
                        reg.Qtd_estoque = reader.GetDecimal(reader.GetOrdinal("QTD_Estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_SaldoFuturo")))
                        reg.Qtd_saldofuturo = reader.GetDecimal(reader.GetOrdinal("QTD_SaldoFuturo"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (podeFecharBco)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Classe Grade Estoque
    public class TRegistro_SaldoGrade
    {
        public string Cd_empresa { get; set; } = string.Empty;
        public string Nm_empresa { get; set; } = string.Empty;
        public string Cd_produto { get; set; } = string.Empty;
        public string Ds_produto { get; set; } = string.Empty;
        private decimal? id_caracteristica = null;
        public decimal? Id_caracteristica
        {
            get { return id_caracteristica; }
            set
            {
                id_caracteristica = value;
                id_caracteristicastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caracteristicastr = string.Empty;
        public string Id_caracteristicastr
        {
            get { return id_caracteristicastr; }
            set
            {
                id_caracteristicastr = value;
                try
                {
                    id_caracteristica = decimal.Parse(value);
                }
                catch { id_caracteristica = null; }
            }
        }
        public string Ds_caracteristica { get; set; } = string.Empty;
        private decimal? id_item = null;
        public decimal? Id_item
        {
            get { return id_item; }
            set
            {
                id_item = value;
                id_itemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_itemstr = string.Empty;
        public string Id_itemstr
        {
            get { return id_itemstr; }
            set
            {
                id_itemstr = value;
                try
                {
                    id_item = decimal.Parse(value);
                }
                catch { id_item = null; }
            }
        }
        public string Valor { get; set; } = string.Empty;
        public decimal Qtd_entrada { get; set; } = decimal.Zero;
        public decimal Qtd_saida { get; set; } = decimal.Zero;
        public decimal Saldo { get; set; } = decimal.Zero;
    }

    public class TList_GradeEstoque : List<TRegistro_GradeEstoque>, IComparer<TRegistro_GradeEstoque>
    {
        #region IComparer<TRegistro_GradeEstoque> Members
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

        public TList_GradeEstoque()
        { }

        public TList_GradeEstoque(System.ComponentModel.PropertyDescriptor Prop,
                                   System.Windows.Forms.SortOrder Dir)
        {
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_GradeEstoque value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_GradeEstoque x, TRegistro_GradeEstoque y)
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
        
    public class TRegistro_GradeEstoque
    {
        
        public string Cd_empresa
        {get; set;}
        
        public string Nm_empresa
        { get; set; }
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public decimal Id_lanctoestoque
        { get; set; }
        private decimal? id_caracteristica;
        
        public decimal? Id_caracteristica
        {
            get { return id_caracteristica; }
            set
            {
                id_caracteristica = value;
                id_caracteristicastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_caracteristicastr;
        
        public string Id_caracteristicastr
        {
            get { return id_caracteristicastr; }
            set
            {
                id_caracteristicastr = value;
                try
                {
                    id_caracteristica = Convert.ToDecimal(value);
                }
                catch
                { id_caracteristica = null; }
            }
        }
        
        public string Ds_caracteristica
        { get; set; }
        
        public decimal? Id_item
        { get; set; }
        
        public string valor
        { get; set; }
        
        public decimal? quantidade
        { get; set; }

        public TRegistro_GradeEstoque()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Id_lanctoestoque = decimal.Zero;
            Id_caracteristica = null;
            Id_caracteristicastr = string.Empty;
            Ds_caracteristica = string.Empty;
            Id_item = null;
            valor = string.Empty;
            quantidade = null;
        }
    }

    public class TCD_GradeEstoque : TDataQuery
    {
        public TCD_GradeEstoque()
        { }

        public TCD_GradeEstoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, int vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + " A.CD_Empresa, B.NM_Empresa,  A.CD_Produto, C.DS_Produto, A.Id_LanctoEstoque, ");
                sql.AppendLine("a.id_caracteristica, a.id_item, e.valor, a.quantidade ");
                
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_EST_GradeEstoque A ");
            sql.AppendLine("INNER JOIN TB_DIV_Empresa B ");
            sql.AppendLine("on A.CD_Empresa = B.CD_Empresa");
            sql.AppendLine("INNER JOIN TB_EST_Produto c ");
            sql.AppendLine("on A.CD_Produto = c.CD_Produto");
            sql.AppendLine("INNER JOIN TB_EST_Estoque D ");
            sql.AppendLine("on A.ID_LanctoEstoque = D.ID_LanctoEstoque ");
            sql.AppendLine("INNER JOIN TB_EST_ValorCaracteristica e");
            sql.AppendLine("on A.ID_Caracteristica = e.ID_Caracteristica ");
            sql.AppendLine("and A.ID_Item = e.ID_Item ");
            

            string cond = " where ";
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

        public TList_GradeEstoque Select(TpBusca[] vBusca, int vTop, string vNm_Campo)
        {
            TList_GradeEstoque lista = new TList_GradeEstoque();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNm_Campo));
                while (reader.Read())
                {
                    TRegistro_GradeEstoque reg = new TRegistro_GradeEstoque();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_LanctoEstoque"))))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("ID_LanctoEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caracteristica")))
                        reg.Id_caracteristica = reader.GetDecimal(reader.GetOrdinal("id_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Ds_caracteristica = reader.GetString(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.valor = reader.GetString(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));

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

        public List<TRegistro_SaldoGrade> Select(string Cd_empresa, string Cd_produto, bool St_comsaldo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, b.nm_empresa, ");
            sql.AppendLine("a.cd_produto, c.ds_produto, a.id_caracteristica, ");
            sql.AppendLine("d.ds_caracteristica, a.id_item, e.valor, ");
            sql.AppendLine("a.qtd_entrada, a.qtd_saida, a.saldo ");

            sql.AppendLine("from vtb_est_saldogradeestoque a ");
            sql.AppendLine("join tb_div_empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("join tb_est_produto c ");
            sql.AppendLine("on a.cd_produto = c.cd_produto ");
            sql.AppendLine("join tb_est_caracteristica d ");
            sql.AppendLine("on a.id_caracteristica = d.id_caracteristica ");
            sql.AppendLine("join tb_est_valorcaracteristica e ");
            sql.AppendLine("on a.id_caracteristica = e.id_caracteristica ");
            sql.AppendLine("and a.id_item = e.id_item ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.cd_produto = '" + Cd_produto.Trim() + "'");
            if (St_comsaldo)
                sql.AppendLine("and a.saldo > 0 ");
            sql.AppendLine("order by e.valor ");

            List<TRegistro_SaldoGrade> lista = new List<TRegistro_SaldoGrade>();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            try
            {
                reader = ExecutarBusca(sql.ToString());
                while (reader.Read())
                {
                    TRegistro_SaldoGrade reg = new TRegistro_SaldoGrade();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_caracteristica"))))
                        reg.Id_caracteristica = reader.GetDecimal(reader.GetOrdinal("id_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_caracteristica")))
                        reg.Ds_caracteristica = reader.GetString(reader.GetOrdinal("ds_caracteristica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_item")))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("id_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("valor")))
                        reg.Valor = reader.GetString(reader.GetOrdinal("valor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_entrada")))
                        reg.Qtd_entrada = reader.GetDecimal(reader.GetOrdinal("qtd_entrada"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qtd_saida")))
                        reg.Qtd_saida = reader.GetDecimal(reader.GetOrdinal("qtd_saida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("saldo")))
                        reg.Saldo = reader.GetDecimal(reader.GetOrdinal("saldo"));

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

        public string GravarGradeEstoque(TRegistro_GradeEstoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_CARACTERISTICA", val.Id_caracteristica);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_QUANTIDADE", val.quantidade);

            return executarProc("IA_EST_GRADEESTOQUE", hs);
        }

        public string ExcluirGradeEstoque(TRegistro_GradeEstoque val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(5);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_ID_CARACTERISTICA", val.Id_caracteristica);
            hs.Add("@P_ID_ITEM", val.Id_item);

            return executarProc("EXCLUI_EST_GRADEESTOQUE", hs);
        }
    }
    #endregion
}
