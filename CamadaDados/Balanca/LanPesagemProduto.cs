using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using System.Runtime.Serialization;

namespace CamadaDados.Balanca
{
    #region "Desdobro Aplicar"
    public class TList_DesdobroAplicar : List<TRegistro_DesdobroAplicar>, IComparer<TRegistro_DesdobroAplicar>
    {
        #region IComparer<TRegistro_DesdobroAplicar> Members
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

        public TList_DesdobroAplicar()
        { }

        public TList_DesdobroAplicar(System.ComponentModel.PropertyDescriptor Prop,
                                     System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_DesdobroAplicar value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_DesdobroAplicar x, TRegistro_DesdobroAplicar y)
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
    [DataContract]
    public class TRegistro_DesdobroAplicar
    {
        [DataMember]
        public string Cd_empresa
        { get; set; }
        [DataMember]
        public decimal Id_ticket
        { get; set; }
        [DataMember]
        public decimal Id_desdobro
        { get; set; }
        [DataMember]
        public decimal Id_item
        { get; set; }
        [DataMember]
        public decimal? Nr_pedido
        { get; set; }
        [DataMember]
        public decimal? Nr_pedidoProduto
        { get; set; }
        [DataMember]
        public decimal? Id_pedidoItem
        { get; set; }
        [DataMember]
        public string CD_Produto
        { get; set; }
        [DataMember]
        public string Cd_UnidEst
        { get; set; }
        [DataMember]
        public string CD_UnidValor
        { get; set; }
        [DataMember]
        public decimal Qtd_nota
        { get; set; }
        [DataMember]
        public decimal Qtd_notaliquido
        { get; set; }
        [DataMember]
        public string Cd_clifor
        { get; set; }
        [DataMember]
        public string Nome_clifor
        { get; set; }
        [DataMember]
        public string Cd_cliforPedido
        { get; set; }
        [DataMember]
        public string Nome_CliforPedido
        { get; set; }
        [DataMember]
        public string Nr_Contrato
        { get; set; }
        [DataMember]
        public string TP_Natureza_Classif
        { get; set; }
        [DataMember]
        public string TP_Natureza_Pesagem
        { get; set; }
        [DataMember]
        public string Tp_pesagem
        { get; set; }
        [DataMember]
        public string Cd_local
        { get; set; }
        [DataMember]
        public string Cd_condfiscal_clifor
        { get; set; }
        [DataMember]
        public string Uf
        { get; set; }
        [DataMember]
        public string UFEmp
        { get; set; }
        [DataMember]
        public decimal Qtd_aplicar
        { get; set; }
        private string tp_pessoa;
        [DataMember]
        public string Tp_pessoa
        {
            get { return tp_pessoa; }
            set
            {
                tp_pessoa = value;
                if (value.ToUpper().Trim().Equals("J"))
                    tipo_pessoa = "JURIDICA";
                else if (value.ToUpper().Trim().Equals("F"))
                    tipo_pessoa = "FISICA";
            }
        }
        private string tipo_pessoa;
        [DataMember]
        public string Tipo_pessoa
        {
            get { return tipo_pessoa; }
            set
            {
                tipo_pessoa = value;
                if (value.ToUpper().Trim().Equals("JURIDICA"))
                    tp_pessoa = "J";
                else if (value.ToUpper().Trim().Equals("FISICA"))
                    tp_pessoa = "F";
            }
        }
        [DataMember]
        public string Cd_endereco
        { get; set; }
        [DataMember]
        public string Nr_notafiscal
        { get; set; }
        [DataMember]
        public string Nr_serie
        { get; set; }
        [DataMember]
        public string Cd_modelo
        { get; set; }
        private DateTime? dt_emissao;
        [DataMember]
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set
            {
                dt_emissao = value;
                dt_emissaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostr;
        public string Dt_emissaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = DateTime.Parse(value);
                }
                catch { dt_emissao = null; }
            }
        }
        private DateTime? dt_saient;
        [DataMember]
        public DateTime? Dt_SaiEnt
        {
            get { return dt_saient; }
            set
            {
                dt_saient = value;
                dt_saientstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string dt_saientstr;
        public string Dt_saientstr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_saientstr).ToString("dd/MM/yyyy");
                }
                catch { return string.Empty; }
            }
            set
            {
                dt_saientstr = value;
                try
                {
                    dt_saient = DateTime.Parse(value);
                }
                catch { dt_saient = null; }
            }
        }
        [DataMember]
        public string ChaveAcessoNFE
        { get; set; }
        [DataMember]
        public string OBS_Fiscal
        { get; set; }
        [DataMember]
        public string DadosAdicionais
        { get; set; }
        [DataMember]
        public decimal? Nr_LanctoFiscal_Mestra
        { get; set; }
        private decimal vl_unitario;
        [DataMember]        
        public decimal Vl_unitario
        {
            get { return vl_unitario; }
            set { vl_unitario = value; }
        }
        [DataMember]
        public decimal Vl_subtotal
        { get; set; }
        [DataMember]
        public decimal Vl_basecalc
        { get; set; }
        [DataMember]
        public decimal Pc_desdobro
        { get; set; }
        [DataMember]
        public decimal Vl_icms
        { get; set; }
        [DataMember]
        public string Cd_condfiscal_produto
        { get; set; }
        [DataMember]
        public string Tp_movtopedido
        { get; set; }
        [DataMember]
        public string Tp_Movimento
        { get; set; }
        [DataMember]
        public string Cd_transportadora
        { get; set; }
        [DataMember]
        public string Nm_transportadora
        { get; set; }
        [DataMember]
        public string Nr_cgccpf_transp
        { get; set; }
        [DataMember]
        public string Cd_endtransportadora
        { get; set; }
        [DataMember]
        public string Ds_endtransportadora
        { get; set; }
        [DataMember]
        public string Placaveiculo
        { get; set; }
        [DataMember]
        public string Especie
        { get; set; }
        [DataMember]
        public string Numero
        { get; set; }
        [DataMember]
        public string Marca
        { get; set; }
        [DataMember]
        public decimal Quantidade
        { get; set; }
        [DataMember]
        public decimal Pesobruto
        { get; set; }
        [DataMember]
        public decimal Pesoliquido
        { get; set; }
        [DataMember]
        public string Freteporconta
        { get; set; }
        [DataMember]
        public bool St_aplicar
        { get; set; }
        [DataMember]
        public string cd_condPgto { get; set; }
        [DataMember]
        public decimal? Id_autoriz
        { get; set; }

        public TRegistro_DesdobroAplicar()
        {
            this.Cd_clifor = string.Empty;
            this.Cd_cliforPedido = string.Empty;
            this.Cd_condfiscal_clifor = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.cd_condPgto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Cd_local = string.Empty;
            this.Cd_modelo = string.Empty;
            this.CD_Produto = string.Empty;
            this.Cd_UnidEst = string.Empty;
            this.CD_UnidValor = string.Empty;
            this.ChaveAcessoNFE = string.Empty;
            this.DadosAdicionais = string.Empty;
            this.dt_emissao = null;
            this.dt_emissaostr = string.Empty;
            this.dt_saient = null;
            this.dt_saientstr = string.Empty;
            this.Id_desdobro = decimal.Zero;
            this.Id_item = decimal.Zero;
            this.Id_pedidoItem = null;
            this.Id_ticket = decimal.Zero;
            this.Nome_clifor = string.Empty;
            this.Nome_CliforPedido = string.Empty;
            this.Nr_Contrato = string.Empty;
            this.Nr_LanctoFiscal_Mestra = null;
            this.Nr_notafiscal = string.Empty;
            this.Nr_pedido = null;
            this.Nr_pedidoProduto = null;
            this.Nr_serie = string.Empty;
            this.OBS_Fiscal = string.Empty;
            this.Pc_desdobro = decimal.Zero;
            this.Qtd_aplicar = decimal.Zero;
            this.Qtd_nota = decimal.Zero;
            this.Qtd_notaliquido = decimal.Zero;
            this.St_aplicar = false;
            this.tipo_pessoa = string.Empty;
            this.Tp_Movimento = string.Empty;
            this.Tp_movtopedido = string.Empty;
            this.TP_Natureza_Classif = string.Empty;
            this.TP_Natureza_Pesagem = string.Empty;
            this.Tp_pesagem = string.Empty;
            this.tp_pessoa = string.Empty;
            this.Uf = string.Empty;
            this.UFEmp = string.Empty;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.vl_unitario = decimal.Zero;
            this.Cd_transportadora = string.Empty;
            this.Nm_transportadora = string.Empty;
            this.Nr_cgccpf_transp = string.Empty;
            this.Cd_endtransportadora = string.Empty;
            this.Ds_endtransportadora = string.Empty;
            this.Placaveiculo = string.Empty;
            this.Especie = string.Empty;
            this.Numero = string.Empty;
            this.Marca = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Pesobruto = decimal.Zero;
            this.Pesoliquido = decimal.Zero;
            this.Freteporconta = string.Empty;
            this.Id_autoriz = null;
        }
    }

    public class TCD_DesdobroAplicar : TDataQuery
    {
        public TCD_DesdobroAplicar()
        { }

        public TCD_DesdobroAplicar(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, a.ID_Ticket, b.nr_pedido as Nr_PedidoProduto, ");
                sql.AppendLine("b.ID_Desdobro, b.ID_Item, b.cd_produto, a.Tp_Movimento, b.QTD_nota, b.QTD_NotaLiquido, ");
                sql.AppendLine("cto.tp_natureza_classif, cto.tp_natureza_pesagem, isnull(a.Nr_contrato, b.nr_contrato) as nr_contrato, ");
                sql.AppendLine("b.cd_CliforPedido, b.Nome_CliforPedido, b.CD_Clifor, b.Nome_Clifor, a.TP_Pesagem, ");
                sql.AppendLine("a.CD_Local, cl.CD_CondFiscal_Clifor, endClifor.UF, endEmp.UF as UFEmp, a.id_autoriz, ");
                sql.AppendLine("QTD_Aplicar = round(isnull(( case when a.tp_movimento = 'E' then ");
                sql.AppendLine("                                (case when b.TP_Pessoa = 'F' then ");
                sql.AppendLine("                                    b.QTD_NotaLiquido ");
                sql.AppendLine("                                else ");
                sql.AppendLine("									(case when((Select x.TP_Natureza_Pesagem From TB_GRO_Contrato x ");
                sql.AppendLine("                                                inner join TB_GRO_Contrato_X_PedidoItem y ");
                sql.AppendLine("                                                on x.nr_contrato = y.nr_contrato ");
                sql.AppendLine("                                                Where y.NR_Pedido = isNull(e.NR_Pedido, @NR_PEDIDO)");
                sql.AppendLine("                                                and y.CD_Produto = b.CD_Produto) = 'O')then ");
                sql.AppendLine("                                        b.QTD_Nota ");
                sql.AppendLine("                                    else ");
                sql.AppendLine("                                        b.QTD_NotaLiquido ");
                sql.AppendLine("                                    end) ");
                sql.AppendLine("                                end) ");
                sql.AppendLine("                            else ");
                sql.AppendLine("                                b.QTD_NotaLiquido ");
                sql.AppendLine("                            end),0) -  ");
                sql.AppendLine("isnull((SELECT Sum(isnull(X.QTD_Aplicado,0) ) ");
                sql.AppendLine("From TB_BAL_Aplicacao_Pedido X ");
                sql.AppendLine("Where X.CD_Empresa = A.CD_Empresa ");
                sql.AppendLine("and X.ID_Ticket = A.ID_Ticket ");
                sql.AppendLine("and X.TP_Pesagem = a.TP_Pesagem ");
                sql.AppendLine("and x.id_desdobro = b.id_desdobro ");
                sql.AppendLine("and x.id_item = b.id_item),0),0) ");
                sql.AppendLine(",b.Tp_Pessoa, b.Cd_endereco, b.Nr_NotaFiscal, b.Nr_Serie, ");
                sql.AppendLine("b.DT_Emissao, b.Vl_unitario, b.nr_pedido, ped.tp_movimento as Tp_MovtoPed, ");
                sql.AppendLine("b.vl_subTotal, b.vl_baseCalc, b.Pc_desdobro, b.vl_icms, ep.CD_CondFiscal_Produto, serie.cd_modelo, ");
                sql.AppendLine("ep.cd_unidade as CD_UnidEst, b.CD_unidValor, b.id_pedidoItem, ");
                sql.AppendLine("b.Dt_SaiEnt, b.ChaveAcessoNFE, b.OBS_Fiscal, b.DadosAdicionais, b.Nr_LanctoFiscal_Mestra, ped.cd_condPgto, ");
                sql.AppendLine("b.cd_transportadora, isnull(b.nm_transportadora, cTransp.nm_clifor) as nm_transportadora, b.nr_cpfcnpj_transp, ");
                sql.AppendLine("b.cd_endtransportadora, cEndTransp.ds_endereco as ds_endtransportadora, ");
                sql.AppendLine("b.placaveiculo, b.especie, b.numero, b.marca, b.quantidade, b.pesobruto, b.pesoliquido, b.freteporconta ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from VTB_BAL_PSGRAOS a ");
            sql.AppendLine("inner join VTB_BAL_DESDOBRO b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Tp_Pesagem = b.Tp_Pesagem ");
            sql.AppendLine("and a.ID_Ticket = b.ID_Ticket ");
            sql.AppendLine("inner join VTB_FIN_Clifor cl ");
            sql.AppendLine("On cl.CD_clifor = b.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco ");
            sql.AppendLine("endClifor On endClifor.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("and endClifor.CD_Endereco = b.CD_Endereco ");
            sql.AppendLine("inner join TB_EST_Produto ep ");
            sql.AppendLine("On ep.CD_Produto = a.CD_Produto ");
            sql.AppendLine("inner join TB_BAL_TPPesagem tpps ");
            sql.AppendLine("on a.tp_pesagem = tpps.tp_pesagem ");
            sql.AppendLine("inner join TB_DIV_Empresa em ");
            sql.AppendLine("on em.cd_empresa = a.cd_empresa");
            sql.AppendLine("inner join VTB_FIN_Clifor clemp ");
            sql.AppendLine("On clemp.CD_clifor = em.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco endEmp ");
            sql.AppendLine("On endEmp.CD_Clifor = em.CD_Clifor ");
            sql.AppendLine("and endEmp.CD_Endereco = em.CD_Endereco ");
            sql.AppendLine("left outer join tb_fat_serienf serie ");
            sql.AppendLine("on b.Nr_Serie = serie.nr_serie ");
            sql.AppendLine("left outer join TB_BAL_Aplicacao_Pedido e ");
            sql.AppendLine("On e.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and e.ID_Ticket = b.ID_Ticket ");
            sql.AppendLine("and e.TP_Pesagem = b.Tp_Pesagem ");
            sql.AppendLine("and e.ID_Desdobro = b.ID_Desdobro ");
            sql.AppendLine("and e.ID_Item = b.ID_Item ");
            sql.AppendLine("left outer join vtb_fat_pedido ped ");
            sql.AppendLine("on b.Nr_pedidoclifor = ped.nr_pedido ");
            sql.AppendLine("left outer join TB_GRO_Contrato cto ");
            sql.AppendLine("on cto.nr_contrato = b.nr_contrato ");
            sql.AppendLine("left outer join vtb_fin_clifor cTransp ");
            sql.AppendLine("on b.cd_transportadora = cTransp.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco cEndTransp ");
            sql.AppendLine("on b.cd_transportadora = cEndTransp.cd_clifor ");
            sql.AppendLine("and b.cd_endtransportadora = cEndTransp.cd_endereco ");
            
            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C' ");
            sql.AppendLine("and isnull(b.st_registro,'A') <> 'C'  ");
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            sql.AppendLine("order by a.id_ticket ");
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

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), vParametros);
        }

        public TList_DesdobroAplicar Select(TpBusca[] vBusca, short vTop, string vNM_Campo, Hashtable vParametros)
        {
            TList_DesdobroAplicar lista = new TList_DesdobroAplicar();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBuscaReader(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), vParametros);
            try
            {
                while (reader.Read())
                {
                    TRegistro_DesdobroAplicar reg = new TRegistro_DesdobroAplicar();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Ticket")))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Desdobro")))
                        reg.Id_desdobro = reader.GetDecimal(reader.GetOrdinal("ID_Desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.CD_Produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Autoriz")))
                        reg.Id_autoriz = reader.GetDecimal(reader.GetOrdinal("ID_Autoriz"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CliforPedido"))))
                        reg.Cd_cliforPedido = reader.GetString(reader.GetOrdinal("CD_CliforPedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nome_CliforPedido"))))
                        reg.Nome_CliforPedido = reader.GetString(reader.GetOrdinal("Nome_CliforPedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nr_Contrato"))))
                        reg.Nr_Contrato = reader.GetDecimal(reader.GetOrdinal("Nr_Contrato")).ToString();

                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_natureza_classif"))))
                        reg.TP_Natureza_Classif = reader.GetString(reader.GetOrdinal("tp_natureza_classif")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("tp_natureza_pesagem"))))
                        reg.TP_Natureza_Pesagem = reader.GetString(reader.GetOrdinal("tp_natureza_pesagem")).ToString();                    

                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_Nota")))
                        reg.Qtd_nota = reader.GetDecimal(reader.GetOrdinal("QTD_Nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_NotaLiquido")))
                        reg.Qtd_notaliquido = reader.GetDecimal(reader.GetOrdinal("QTD_NotaLiquido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Nome_Clifor"))))
                        reg.Nome_clifor = reader.GetString(reader.GetOrdinal("Nome_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Local"))))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Clifor"))))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("UF"))))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("UFEmp"))))
                        reg.UFEmp = reader.GetString(reader.GetOrdinal("UFEmp"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Aplicar"))))
                        reg.Qtd_aplicar = reader.GetDecimal(reader.GetOrdinal("QTD_Aplicar"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pessoa"))))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_SaiEnt = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Desdobro")))
                        reg.Pc_desdobro = reader.GetDecimal(reader.GetOrdinal("PC_Desdobro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("VL_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));

                    if (!reader.IsDBNull(reader.GetOrdinal("ChaveAcessoNFE")))
                        reg.ChaveAcessoNFE = reader.GetString(reader.GetOrdinal("ChaveAcessoNFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("OBS_Fiscal")))
                        reg.OBS_Fiscal = reader.GetString(reader.GetOrdinal("OBS_Fiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DadosAdicionais")))
                        reg.DadosAdicionais = reader.GetString(reader.GetOrdinal("DadosAdicionais"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal_Mestra")))
                        reg.Nr_LanctoFiscal_Mestra = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal_Mestra"));

                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Pedido")))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_PedidoProduto")))
                        reg.Nr_pedidoProduto = reader.GetDecimal(reader.GetOrdinal("Nr_PedidoProduto"));
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_PedidoItem")))
                        reg.Id_pedidoItem = reader.GetDecimal(reader.GetOrdinal("ID_PedidoItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidValor")))
                        reg.CD_UnidValor = reader.GetString(reader.GetOrdinal("CD_UnidValor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidEst")))
                        reg.Cd_UnidEst = reader.GetString(reader.GetOrdinal("CD_UnidEst"));

                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_Movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_MovtoPed")))
                        reg.Tp_movtopedido = reader.GetString(reader.GetOrdinal("Tp_MovtoPed"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condPgto")))
                        reg.cd_condPgto = reader.GetString(reader.GetOrdinal("cd_condPgto"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPFCNPJ_Transp")))
                        reg.Nr_cgccpf_transp = reader.GetString(reader.GetOrdinal("NR_CPFCNPJ_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndTransportadora")))
                        reg.Cd_endtransportadora = reader.GetString(reader.GetOrdinal("CD_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endtransportadora")))
                        reg.Ds_endtransportadora = reader.GetString(reader.GetOrdinal("ds_endtransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placaveiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("placaveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("especie")))
                        reg.Especie = reader.GetString(reader.GetOrdinal("especie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("marca")))
                        reg.Marca = reader.GetString(reader.GetOrdinal("marca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PesoBruto")))
                        reg.Pesobruto = reader.GetDecimal(reader.GetOrdinal("PesoBruto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PesoLiquido")))
                        reg.Pesoliquido = reader.GetDecimal(reader.GetOrdinal("PesoLiquido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FretePorConta")))
                        reg.Freteporconta = reader.GetString(reader.GetOrdinal("FretePorConta"));
                    
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
    }
    #endregion

    #region "Pesagem Produto"
    public class TList_RegLanPesagemProduto : List<TRegistro_LanPesagemProduto>, IComparer<TRegistro_LanPesagemProduto>
    {
        #region IComparer<TRegistro_LanPesagemProduto> Members
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

        public TList_RegLanPesagemProduto()
        { }

        public TList_RegLanPesagemProduto(System.ComponentModel.PropertyDescriptor Prop,
                                          System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPesagemProduto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPesagemProduto x, TRegistro_LanPesagemProduto y)
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
    [DataContract]
    public class TRegistro_LanPesagemProduto
    {
        [DataMember]
        public string Cd_empresa
        {
            get;
            set;
        }
        [DataMember]
        public decimal Id_ticket
        {
            get;
            set;
        }
        [DataMember]
        public string Tp_pesagem
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_produto
        {
            get;
            set;
        }
        [DataMember]
        public string Ds_produto
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_condfiscal_produto
        {
            get;
            set;
        }
        [DataMember]
        public decimal Id_desdobro
        {
            get;
            set;
        }
        [DataMember]
        public decimal Id_item
        {
            get;
            set;
        }

        private decimal? nr_pedido;
        [DataMember]
        public decimal? Nr_pedido
        {
            get { return nr_pedido; }
            set 
            { 
                nr_pedido = value;
                nr_pedidostring = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string nr_pedidostring;
        [DataMember]
        public string Nr_pedidostring
        {
            get { return nr_pedidostring; }
            set
            {
                nr_pedidostring = value;
                try
                {
                    nr_pedido = Convert.ToDecimal(value);
                }
                catch
                { nr_pedido = null; }
            }
        }

        public decimal? _Id_pedidoitem;
        [DataMember]
        public decimal? Id_pedidoitem
        {   
            get { return _Id_pedidoitem;}
            set 
            {
                _Id_pedidoitem = value;
                _Id_PedidoItemStr = value.HasValue ? value.Value.ToString() : string.Empty;
            } 
        }
        private string _Id_PedidoItemStr;
        [DataMember]
        public string Id_PedidoItemStr
        {
            get { return _Id_PedidoItemStr; }
            set
            {
                _Id_PedidoItemStr = value;
                try
                {
                    _Id_pedidoitem = Convert.ToDecimal(value);
                }
                catch
                { _Id_pedidoitem = null; }
            }
        }
        private string _Cd_UnidValor;
        [DataMember]
        public string Cd_UnidValor 
        {
            get
            { return _Cd_UnidValor; }
            set 
            {
                _Cd_UnidValor = value;
                if ((_Qtd_nota > 0) && (_Vl_unitario > 0) && _Cd_UnidValor != "" && Cd_UnidEstoque != "")
                    _Vl_subtotal = Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(_Cd_UnidEstoque, _Cd_UnidValor, _Qtd_nota * _Vl_unitario), 2);

            }
        }
        [DataMember]
        public string Ds_unidvalor
        { get; set; }
        [DataMember]
        public string Sigla_unidvalor
        { get; set; }
        private string _Cd_UnidEstoque;
        [DataMember]
        public string Cd_UnidEstoque
        {
            get
            { return _Cd_UnidEstoque; }
            set 
            {
                _Cd_UnidEstoque = value;
                if ((_Qtd_nota > 0) && (_Vl_unitario > 0) && _Cd_UnidValor != "" && _Cd_UnidEstoque != "")
                    _Vl_subtotal = Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(this.Cd_UnidEstoque, this.Cd_UnidValor, _Qtd_nota * _Vl_unitario), 2);

            }
        }
        [DataMember]
        public string Nr_notafiscal
        {
            get;
            set;
        }
        [DataMember]
        public string Nr_serie
        {
            get;
            set;
        }
        [DataMember]
        public string Ds_serienf
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_modelo
        { get; set; }
        [DataMember]
        public string Ds_modelo
        { get; set; }
        private decimal _Qtd_nota;
        [DataMember]
        public decimal Qtd_nota
        {
            get
            {
                return _Qtd_nota;
            }
            set
            {
                _Qtd_nota = value;
                if ((_Vl_unitario > 0) && Cd_UnidValor != "" && Cd_UnidEstoque != "")
                    _Vl_subtotal = Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(this.Cd_UnidEstoque, this.Cd_UnidValor, _Qtd_nota * _Vl_unitario), 2);

            }
        }
        [DataMember]
        public decimal Qtd_descontoclass
        {
            get;
            set;
        }
        [DataMember]
        public decimal Qtd_notaliquido
        {
            get;
            set;
        }
        [DataMember]
        public decimal Qtd_aplicar
        {
            get;
            set;
        }
        [DataMember]
        public decimal Vl_subtotalaplicar
        {
            get;
            set;
        }
        private DateTime? dt_emissao;
        [DataMember]
        public DateTime? Dt_emissao
        {
            get { return dt_emissao; }
            set 
            { 
                dt_emissao = value;
                dt_emissaostring = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_emissaostring;
        [DataMember]
        public string Dt_emissaostring
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_emissaostring).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostring = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                { dt_emissao = null; }
            }
        }

        private decimal _Vl_unitario;
        [DataMember]
        public decimal Vl_unitario
        {
            get { return _Vl_unitario; }
            set
            {
                _Vl_unitario = value;
                if ((_Qtd_nota > 0) && (_Vl_unitario > 0) && _Cd_UnidValor != "" && _Cd_UnidEstoque != "")
                    _Vl_subtotal = Math.Round(new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(this.Cd_UnidEstoque, this.Cd_UnidValor, _Qtd_nota * _Vl_unitario), 2);

            }
        }
        private decimal _Vl_subtotal;
        [DataMember]
        public decimal Vl_subtotal
        {
            get
            {
                return _Vl_subtotal;
            }
            set
            {
                _Vl_subtotal = Math.Round(value, 2);
                if ((_Qtd_nota > 0) && (_Vl_unitario > 0) && Cd_UnidValor != "" && Cd_UnidEstoque != "")
                    _Vl_unitario = new Estoque.Cadastros.TCD_CadConvUnidade().ConvertUnid(this.Cd_UnidValor, this.Cd_UnidEstoque, _Vl_subtotal / _Qtd_nota);

            }
        }
        [DataMember]
        public decimal Vl_basecalc
        {
            get;
            set;
        }
        [DataMember]
        public decimal Pc_desdobro
        {
            get;
            set;
        }
        [DataMember]
        public decimal Vl_frete
        {
            get;
            set;
        }
        [DataMember]
        public decimal Vl_icms
        {
            get;
            set;
        }
        private string st_transm;
        [DataMember]
        public string St_transm
        {
            get { return st_transm; }
            set 
            { 
                st_transm = value;
                st_transmite = st_transm.Trim().Equals("S");
            }
        }
        private bool st_transmite;
        [DataMember]
        public bool St_transmite
        {
            get { return st_transmite; }
            set 
            { 
                st_transmite = value;
                if (st_transmite)
                    st_transm = "S";
                else
                    st_transm = "N";
            }
        }
        [DataMember]
        public string Nr_lote
        {
            get;
            set;
        }
        private string st_registro;
        [DataMember]
        public string St_registro
        {
            get { return st_registro; }
            set 
            {
                st_registro = value;
                status = st_registro.Trim().Equals("A");
            }
        }
        private bool status;
        [DataMember]
        public bool Status
        {
            get { return status; }
            set 
            { 
                status = value;
                if (status)
                    st_registro = "A";
                else
                    st_registro = "C";
            }
        }
        [DataMember]
        public string Cd_local
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_variedade
        {
            get;
            set;
        }
        [DataMember]
        public decimal? Id_autoriz
        { get; set; }
        [DataMember]
        public string Nome_clifor
        { get; set; }
        [DataMember]
        public string Ds_enderecofornecedor
        { get; set; }
        [DataMember]
        public string Ds_cidadefornecedor
        { get; set; }

        public TRegistro_LanPesagemProduto()
        {
            this._Cd_UnidEstoque = string.Empty;
            this._Cd_UnidValor = string.Empty;
            this._Id_pedidoitem = null;
            this._Id_PedidoItemStr = string.Empty;
            this._Qtd_nota = decimal.Zero;
            this._Vl_subtotal = decimal.Zero;
            this._Vl_unitario = decimal.Zero;
            this.Cd_condfiscal_produto = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_local = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Cd_produto = string.Empty;
            this.Cd_UnidEstoque = string.Empty;
            this.Cd_UnidValor = string.Empty;
            this.Cd_variedade = string.Empty;
            this.Ds_modelo = string.Empty;
            this.Ds_produto = string.Empty;
            this.Ds_serienf = string.Empty;
            this.Ds_unidvalor = string.Empty;
            this.dt_emissao = null;
            this.dt_emissaostring = string.Empty;
            this.Id_desdobro = decimal.Zero;
            this.Id_item = decimal.Zero;
            this.Id_pedidoitem = null;
            this.Id_PedidoItemStr = string.Empty;
            this.Id_ticket = decimal.Zero;
            this.Nr_lote = string.Empty;
            this.Nr_notafiscal = string.Empty;
            this.nr_pedido = null;
            this.nr_pedidostring = string.Empty;
            this.Nr_serie = string.Empty;
            this.Pc_desdobro = decimal.Zero;
            this.Qtd_aplicar = decimal.Zero;
            this.Qtd_descontoclass = decimal.Zero;
            this.Qtd_nota = decimal.Zero;
            this.Qtd_notaliquido = decimal.Zero;
            this.Sigla_unidvalor = string.Empty;
            this.st_registro = "A";
            this.st_transm = string.Empty;
            this.st_transmite = false;
            this.status = true;
            this.Tp_pesagem = string.Empty;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_frete = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.Vl_subtotalaplicar = decimal.Zero;
            this.Id_autoriz = null;
            this.Nome_clifor = string.Empty;
            this.Ds_enderecofornecedor = string.Empty;
            this.Ds_cidadefornecedor = string.Empty;
        }
    }

    public class TCD_LanPesagemProduto : TDataQuery
    {
        public TCD_LanPesagemProduto()
        { }

        public TCD_LanPesagemProduto(string vNM_ProcBusca)
        {
            this.NM_ProcSqlBusca = vNM_ProcBusca;
        }

        public TCD_LanPesagemProduto(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vGroup, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Desdobro, ");
                sql.AppendLine("a.ID_Ticket, a.TP_Pesagem, a.cd_unidValor, c.cd_unidade, unid.sigla_unidade as sigla_unidvalor, ");
                sql.AppendLine("a.CD_Produto, c.DS_Produto, a.ID_Item, a.NR_Pedido, a.Id_PedidoItem, ");
                sql.AppendLine("f.NR_NotaFiscal, c.cd_condfiscal_produto, unid.ds_unidade as ds_unidadevalor, ");
                sql.AppendLine("f.NR_Serie, d.DS_SerieNF, a.QTD_Nota, a.QTD_DescontoClass, a.QTD_NotaLiquido, ");
                sql.AppendLine("f.DT_Emissao, a.Vl_Unitario, a.Vl_SubTotal, a.Vl_BaseCalc, a.PC_Desdobro, ");
                sql.AppendLine("a.Vl_Frete, a.Vl_ICMS, a.ST_Transm, a.NR_Lote, a.ST_Registro, e.cd_modelo, e.ds_modelo, ");
                sql.AppendLine("cli.NM_Clifor as nome_clifor, endClifor.ds_endereco as Ds_enderecofornecedor, endClifor.ds_cidade as Ds_cidadefornecedor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_Bal_Produto a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("On b.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("On c.CD_Produto = a.CD_Produto ");
            sql.AppendLine("inner join TB_BAL_Clifor f ");
            sql.AppendLine("on f.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and f.id_ticket = a.id_ticket ");
            sql.AppendLine("and f.tp_pesagem = a.tp_pesagem ");
            sql.AppendLine("and f.id_desdobro = a.id_desdobro ");
            sql.AppendLine("inner join TB_FIN_Clifor cli ");
            sql.AppendLine("on f.CD_Clifor = cli.CD_Clifor ");
            sql.AppendLine("inner join vtb_fin_endereco endClifor ");
            sql.AppendLine("on f.cd_clifor = endClifor.cd_clifor ");
            sql.AppendLine("and f.cd_endereco = endClifor.cd_endereco ");
            sql.AppendLine("inner join tb_est_unidade unid ");
            sql.AppendLine("on a.cd_unidValor = unid.cd_unidade ");
            sql.AppendLine("left outer join TB_FAT_SerieNF d ");
            sql.AppendLine("On d.NR_Serie = f.NR_Serie ");
            sql.AppendLine("left outer join tb_fat_modelonf e ");
            sql.AppendLine("on d.cd_modelo = e.cd_modelo ");
            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if(vGroup.Trim() != string.Empty)
                sql.AppendLine(vGroup);
            if(vOrder.Trim() != string.Empty)
                sql.AppendLine(vOrder);
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty, string.Empty), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, string.Empty, string.Empty, string.Empty }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, string.Empty, string.Empty }).ToString();
                return this.ExecutarBusca(sql, null);
            }
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo, string vGroup, string vOrder, Hashtable vParametros)
        {
            if (this.NM_ProcSqlBusca.Trim().Equals(string.Empty))
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vGroup, vOrder), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca, vTop, vNM_Campo, vGroup, vOrder }).ToString();
                return this.ExecutarBusca(sql, vParametros);
            }
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty, string.Empty), null);
        }

        public TList_RegLanPesagemProduto Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanPesagemProduto lista = new TList_RegLanPesagemProduto();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty, string.Empty));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanPesagemProduto reg = new TRegistro_LanPesagemProduto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Item"))))
                        reg.Id_item = reader.GetDecimal(reader.GetOrdinal("ID_Item"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Desdobro"))))
                        reg.Id_desdobro = reader.GetDecimal(reader.GetOrdinal("ID_Desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_PedidoItem"))))
                        reg.Id_pedidoitem = reader.GetDecimal(reader.GetOrdinal("Id_PedidoItem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal"))))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serie"))))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_SerieNF"))))
                        reg.Ds_serienf = reader.GetString(reader.GetOrdinal("DS_SerieNF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_Nota"))))
                        reg.Qtd_nota = reader.GetDecimal(reader.GetOrdinal("QTD_Nota"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_DescontoClass"))))
                        reg.Qtd_descontoclass = reader.GetDecimal(reader.GetOrdinal("QTD_DescontoClass"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("QTD_NotaLiquido"))))
                        reg.Qtd_notaliquido = reader.GetDecimal(reader.GetOrdinal("QTD_NotaLiquido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("dt_emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("dt_emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_unitario"))))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_subtotal"))))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_basecalc"))))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("vl_basecalc"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("pc_desdobro"))))
                        reg.Pc_desdobro = reader.GetDecimal(reader.GetOrdinal("pc_desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_frete"))))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("vl_frete"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_icms"))))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("vl_icms"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_transm"))))
                        reg.St_transm = reader.GetString(reader.GetOrdinal("st_transm"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nr_lote"))))
                        reg.Nr_lote = reader.GetString(reader.GetOrdinal("nr_lote"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("st_registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Modelo")))
                        reg.Ds_modelo = reader.GetString(reader.GetOrdinal("DS_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidValor")))
                        reg.Cd_UnidValor = reader.GetString(reader.GetOrdinal("CD_UnidValor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidadevalor")))
                        reg.Ds_unidvalor = reader.GetString(reader.GetOrdinal("ds_unidadevalor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_UnidValor")))
                        reg.Sigla_unidvalor = reader.GetString(reader.GetOrdinal("Sigla_UnidValor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_UnidEstoque = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nome_clifor")))
                        reg.Nome_clifor = reader.GetString(reader.GetOrdinal("Nome_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_enderecofornecedor")))
                        reg.Ds_enderecofornecedor = reader.GetString(reader.GetOrdinal("DS_EnderecoFornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_CidadeFornecedor")))
                        reg.Ds_cidadefornecedor = reader.GetString(reader.GetOrdinal("DS_CidadeFornecedor"));


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

        public string GravarPesagemProduto(TRegistro_LanPesagemProduto val)
        {
            Hashtable hs = new Hashtable(21);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_ID_DESDOBRO", val.Id_desdobro);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_ID_PEDIDOITEM", val.Id_pedidoitem);
            hs.Add("@P_QTD_NOTA", val.Qtd_nota);
            hs.Add("@P_QTD_DESCONTOCLASS", val.Qtd_descontoclass);
            hs.Add("@P_QTD_NOTALIQUIDO", val.Qtd_notaliquido);
            hs.Add("@P_CD_UNIDVALOR", val.Cd_UnidValor);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_VL_BASECALC", val.Vl_basecalc);
            hs.Add("@P_PC_DESDOBRO", val.Pc_desdobro);
            hs.Add("@P_VL_FRETE", val.Vl_frete);
            hs.Add("@P_VL_ICMS", val.Vl_icms);
            hs.Add("@P_ST_TRANSM", val.St_transm);
            hs.Add("@P_NR_LOTE", val.Nr_lote);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            

            return this.executarProc("IA_BAL_PRODUTO", hs);
        }

        public string DeletarPesagemProduto(TRegistro_LanPesagemProduto val)
        {
            Hashtable hs = new Hashtable(6);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_ITEM", val.Id_item);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_DESDOBRO", val.Id_desdobro);

            return this.executarProc("EXCLUI_BAL_PRODUTO", hs);
        }
    }
    #endregion
}
