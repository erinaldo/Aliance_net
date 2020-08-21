using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Frota
{
    #region Abast X Duplicata
    public class TList_Abast_X_Duplicata : List<TRegistro_Abast_X_Duplicata>
    { }
    
    public class TRegistro_Abast_X_Duplicata
    {
        private decimal? id_abastecimento;
        public decimal? Id_abastecimento
        {
            get { return id_abastecimento; }
            set
            {
                id_abastecimento = value;
                id_abastecimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_abastecimentostr;
        public string Id_abastecimentostr
        {
            get { return id_abastecimentostr; }
            set
            {
                id_abastecimentostr = value;
                try
                {
                    id_abastecimento = decimal.Parse(value);
                }
                catch
                { id_abastecimento = null; }
            }
        }
        public string Cd_empresa
        { get; set; }
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
                catch
                { nr_lancto = null; }
            }
        }

        public TRegistro_Abast_X_Duplicata()
        {
            this.id_abastecimento = null;
            this.id_abastecimentostr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.nr_lancto = null;
            this.nr_lanctostr = string.Empty;
        }
    }

    public class TCD_Abast_X_Duplicata : TDataQuery
    {
        public TCD_Abast_X_Duplicata()
        { }

        public TCD_Abast_X_Duplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.ID_Abastecimento, a.CD_Empresa, a.NR_Lancto ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_Abast_X_Duplicata a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_Abast_X_Duplicata Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_Abast_X_Duplicata lista = new TList_Abast_X_Duplicata();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_Abast_X_Duplicata reg = new TRegistro_Abast_X_Duplicata();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Abastecimento")))
                        reg.Id_abastecimento = reader.GetDecimal(reader.GetOrdinal("ID_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("NR_Lancto"));

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

        public string Gravar(TRegistro_Abast_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("IA_FRT_ABAST_X_DUPLICATA", hs);
        }

        public string Excluir(TRegistro_Abast_X_Duplicata val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTO", val.Nr_lancto);

            return this.executarProc("EXCLUI_FRT_ABAST_X_DUPLICATA", hs);
        }
    }
    #endregion

    #region AbastVeiculo
    public class TList_AbastVeiculo : List<TRegistro_AbastVeiculo>, IComparer<TRegistro_AbastVeiculo>
    {
        #region IComparer<TRegistro_AbastVeiculo> Members
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

        public TList_AbastVeiculo()
        { }

        public TList_AbastVeiculo(System.ComponentModel.PropertyDescriptor Prop,
                                  System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_AbastVeiculo value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_AbastVeiculo x, TRegistro_AbastVeiculo y)
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

    public class TRegistro_AbastVeiculo
    {
        private decimal? id_abastecimento;
        public decimal? Id_abastecimento
        {
            get { return id_abastecimento; }
            set
            {
                id_abastecimento = value;
                id_abastecimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_abastecimentostr;
        public string Id_abastecimentostr
        {
            get { return id_abastecimentostr; }
            set
            {
                id_abastecimentostr = value;
                try
                {
                    id_abastecimento = decimal.Parse(value);
                }
                catch
                { id_abastecimento = null; }
            }
        }
        private decimal? id_veiculo;
        public decimal? Id_veiculo
        {
            get { return id_veiculo; }
            set
            {
                id_veiculo = value;
                id_veiculostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_veiculostr;
        public string Id_veiculostr
        {
            get { return id_veiculostr; }
            set
            {
                id_veiculostr = value;
                try
                {
                    id_veiculo = decimal.Parse(value);
                }
                catch
                { id_veiculo = null; }
            }
        }
        public string Ds_veiculo
        { get; set; }
        public string Placa
        { get; set; }
        private decimal? id_viagem;
        public decimal? Id_viagem
        {
            get { return id_viagem; }
            set
            {
                id_viagem = value;
                id_viagemstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_viagemstr;
        public string Id_viagemstr
        {
            get { return id_viagemstr; }
            set
            {
                id_viagemstr = value;
                try
                {
                    id_viagem = decimal.Parse(value);
                }
                catch
                { id_viagem = null; }
            }
        }
        public string Ds_viagem
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        private decimal? id_despesa;
        public decimal? Id_despesa
        {
            get { return id_despesa; }
            set
            {
                id_despesa = value;
                id_despesastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_despesastr;
        public string Id_despesastr
        {
            get { return id_despesastr; }
            set
            {
                id_despesastr = value;
                try
                {
                    id_despesa = decimal.Parse(value);
                }
                catch
                { id_despesa = null; }
            }
        }
        public string Ds_despesa
        { get; set; }
        public string LoginRequisicao
        { get; set; }
        public string LoginAbastecida
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal? Id_lanctoestoque
        { get; set; }
        private DateTime? dt_requisicao;
        public DateTime? Dt_requisicao
        {
            get { return dt_requisicao; }
            set
            {
                dt_requisicao = value;
                dt_requisicaostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_requisicaostr;
        public string Dt_requisicaostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_requisicaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_requisicaostr = value;
                try
                {
                    dt_requisicao = DateTime.Parse(value);
                }
                catch
                { dt_requisicao = null; }
            }
        }
        public decimal Volume_requisicao
        { get; set; }
        private DateTime? dt_abastecimento;
        public DateTime? Dt_abastecimento
        {
            get { return dt_abastecimento; }
            set
            {
                dt_abastecimento = value;
                dt_abastecimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_abastecimentostr;
        public string Dt_abastecimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_abastecimentostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_abastecimentostr = value;
                try
                {
                    dt_abastecimento = DateTime.Parse(value);
                }
                catch
                { dt_abastecimento = null; }
            }
        }
        public decimal Volume
        { get; set; }
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        private string tp_abastecimento;
        public string Tp_abastecimento
        {
            get { return tp_abastecimento; }
            set
            {
                tp_abastecimento = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_abastecimento = "PROPRIO";
                else if (value.Trim().ToUpper().Equals("T"))
                    tipo_abastecimento = "TERCEIRO";
            }
        }
        private string tipo_abastecimento;
        public string Tipo_abastecimento
        {
            get { return tipo_abastecimento; }
            set
            {
                tipo_abastecimento = value;
                if (value.Trim().ToUpper().Equals("PROPRIO"))
                    tp_abastecimento = "P";
                else if (value.Trim().ToUpper().Equals("TERCEIRO"))
                    tp_abastecimento = "T";
            }
        }
        private string tp_pagamento;
        public string Tp_pagamento
        {
            get { return tp_pagamento; }
            set
            {
                tp_pagamento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_pagamento = "EMPRESA";
                else if (value.Trim().ToUpper().Equals("M"))
                    tipo_pagamento = "MOTORISTA";
            }
        }
        private string tipo_pagamento;
        public string Tipo_pagamento
        {
            get { return tipo_pagamento; }
            set
            {
                tipo_pagamento = value;
                if (value.Trim().ToUpper().Equals("EMPRESA"))
                    tp_pagamento = "E";
                else if (value.Trim().ToUpper().Equals("MOTORISTA"))
                    tp_pagamento = "M";
            }
        }
        public decimal Km_atual
        { get; set; }
        public decimal Media
        { get; set; }
        private string tp_captura;
        public string Tp_captura
        {
            get { return tp_captura; }
            set
            {
                tp_captura = value;
                if (value.Trim().ToUpper().Equals("M"))
                    tipo_captura = "MANUAL";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_captura = "AUTOMATICA";
            }
        }
        private string tipo_captura;
        public string Tipo_captura
        {
            get { return tipo_captura; }
            set
            {
                tipo_captura = value;
                if (value.Trim().ToUpper().Equals("MANUAL"))
                    tp_captura = "M";
                else if (value.Trim().ToUpper().Equals("AUTOMATICA"))
                    tp_captura = "A";
            }
        }
        public string Nr_notafiscal
        { get; set; }
        public string Cd_fornecedor
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        private string tp_registro;
        public string Tp_registro
        {
            get { return tp_registro; }
            set
            {
                tp_registro = value;
                if (value.Trim().ToUpper().Equals("R"))
                    tipo_registro = "REQUISIÇÃO";
                else if (value.Trim().ToUpper().Equals("A"))
                    tipo_registro = "ABASTECIMENTO";
            }
        }
        private string tipo_registro;
        public string Tipo_registro
        {
            get { return tipo_registro; }
            set
            {
                tipo_registro = value;
                if (value.Trim().ToUpper().Equals("REQUISIÇÃO"))
                    tp_registro = "R";
                else if (value.Trim().ToUpper().Equals("ABASTECIMENTO"))
                    tp_registro = "A";
            }
        }
        public string Ds_observacao
        { get; set; }
        public bool St_processar
        { get; set; }
        public TRegistro_Abastecidas rAbast
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata rDup
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup
        { get; set; }
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCCusto
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_ItensXMLNFe rProdForn
        { get; set; }

        public TRegistro_AbastVeiculo()
        {
            this.id_abastecimento = null;
            this.id_abastecimentostr = string.Empty;
            this.id_veiculo = null;
            this.id_veiculostr = string.Empty;
            this.Ds_veiculo = string.Empty;
            this.Placa = string.Empty;
            this.id_viagem = null;
            this.id_viagemstr = string.Empty;
            this.Ds_viagem = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.id_despesa = null;
            this.id_despesastr = string.Empty;
            this.Ds_despesa = string.Empty;
            this.LoginRequisicao = string.Empty;
            this.LoginAbastecida = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Id_lanctoestoque = null;
            this.dt_requisicao = null;
            this.dt_requisicaostr = string.Empty;
            this.Volume_requisicao = decimal.Zero;
            this.dt_abastecimento = null;
            this.dt_abastecimentostr = string.Empty;
            this.Volume = decimal.Zero;
            this.Vl_unitario = decimal.Zero;
            this.Vl_subtotal = decimal.Zero;
            this.tp_abastecimento = "T";
            this.tipo_abastecimento = "TERCEIRO";
            this.tp_pagamento = "E";
            this.tipo_pagamento = "EMPRESA";
            this.Km_atual = decimal.Zero;
            this.Media = decimal.Zero;
            this.tp_captura = string.Empty;
            this.tipo_captura = string.Empty;
            this.Nr_notafiscal = string.Empty;
            this.Cd_fornecedor = string.Empty;
            this.Nm_fornecedor = string.Empty;
            this.tp_registro = string.Empty;
            this.tipo_registro = string.Empty;
            this.Ds_observacao = string.Empty;
            this.St_processar = false;
            this.rAbast = null;
            this.rDup = null;
            this.lDup = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.lCCusto = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
            this.rProdForn = null;
        }
    }

    public class TCD_AbastVeiculo : TDataQuery
    {
        public TCD_AbastVeiculo()
        { }

        public TCD_AbastVeiculo(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Abastecimento, a.CD_Empresa, ");
                sql.AppendLine("b.NM_Empresa, a.ID_Viagem, c.DS_Viagem, a.TP_Abastecimento, a.TP_Pagamento, ");
                sql.AppendLine("a.Id_Veiculo, d.DS_Veiculo, a.ID_Despesa, a.ds_observacao, ");
                sql.AppendLine("e.DS_Despesa, a.LoginRequisicao, a.LoginAbastecida, a.DT_Abastecimento, d.placa, ");
                sql.AppendLine("a.dt_requisicao, a.volume_requisicao, a.tp_registro, ");
                sql.AppendLine("a.Volume, a.Vl_Unitario, a.volume * a.vl_unitario as Vl_subtotal, ");
                sql.AppendLine("a.KM_Atual, a.TP_Captura, a.NR_NotaFiscal, a.NM_Fornecedor, ");
                sql.AppendLine("a.cd_produto, f.ds_produto, a.id_lanctoestoque, ");
                sql.AppendLine("Media = DBO.F_CALC_MEDIAKMFROTA(a.CD_Empresa, a.ID_VEICULO, a.ID_Abastecimento) ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FRT_AbastVeiculo a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("left outer join TB_FRT_Viagem c ");
            sql.AppendLine("on a.cd_empresa = c.CD_Empresa ");
            sql.AppendLine("and a.ID_Viagem = c.ID_Viagem ");
            sql.AppendLine("inner join TB_FRT_Veiculo d ");
            sql.AppendLine("on a.id_veiculo = d.id_veiculo ");
            sql.AppendLine("inner join TB_FRT_Despesa e ");
            sql.AppendLine("on a.ID_Despesa = e.ID_Despesa ");
            sql.AppendLine("inner join TB_EST_Produto f ");
            sql.AppendLine("on a.cd_produto = f.cd_produto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder);
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, string.Empty), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo, string vGroup, string vOrder, System.Collections.Hashtable vParametros)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), null);
        }

        public TList_AbastVeiculo Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AbastVeiculo lista = new TList_AbastVeiculo();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, string.Empty));
                while (reader.Read())
                {
                    TRegistro_AbastVeiculo reg = new TRegistro_AbastVeiculo();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Abastecimento")))
                        reg.Id_abastecimento = reader.GetDecimal(reader.GetOrdinal("ID_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Viagem")))
                        reg.Id_viagem = reader.GetDecimal(reader.GetOrdinal("ID_Viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Viagem")))
                        reg.Ds_viagem = reader.GetString(reader.GetOrdinal("DS_Viagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Veiculo")))
                        reg.Id_veiculo = reader.GetDecimal(reader.GetOrdinal("Id_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Veiculo")))
                        reg.Ds_veiculo = reader.GetString(reader.GetOrdinal("DS_Veiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placa")))
                        reg.Placa = reader.GetString(reader.GetOrdinal("placa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Despesa")))
                        reg.Id_despesa = reader.GetDecimal(reader.GetOrdinal("ID_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Despesa")))
                        reg.Ds_despesa = reader.GetString(reader.GetOrdinal("DS_Despesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginRequisicao")))
                        reg.LoginRequisicao = reader.GetString(reader.GetOrdinal("LoginRequisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("LoginAbastecida")))
                        reg.LoginAbastecida = reader.GetString(reader.GetOrdinal("LoginAbastecida"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_lanctoestoque")))
                        reg.Id_lanctoestoque = reader.GetDecimal(reader.GetOrdinal("id_lanctoestoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_requisicao")))
                        reg.Dt_requisicao = reader.GetDateTime(reader.GetOrdinal("dt_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("volume_requisicao")))
                        reg.Volume_requisicao = reader.GetDecimal(reader.GetOrdinal("volume_requisicao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abastecimento")))
                        reg.Dt_abastecimento = reader.GetDateTime(reader.GetOrdinal("DT_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volume")))
                        reg.Volume = reader.GetDecimal(reader.GetOrdinal("Volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("Vl_Unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Abastecimento")))
                        reg.Tp_abastecimento = reader.GetString(reader.GetOrdinal("TP_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Pagamento")))
                        reg.Tp_pagamento = reader.GetString(reader.GetOrdinal("TP_Pagamento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("KM_Atual")))
                        reg.Km_atual = reader.GetDecimal(reader.GetOrdinal("KM_Atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Captura")))
                        reg.Tp_captura = reader.GetString(reader.GetOrdinal("TP_Captura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetString(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("NM_Fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_observacao")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("ds_observacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("media")))
                        reg.Media = reader.GetDecimal(reader.GetOrdinal("media"));

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

        public string Gravar(TRegistro_AbastVeiculo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(22);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);
            hs.Add("@P_ID_VEICULO", val.Id_veiculo);
            hs.Add("@P_ID_VIAGEM", val.Id_viagem);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_DESPESA", val.Id_despesa);
            hs.Add("@P_LOGINREQUISICAO", val.LoginRequisicao);
            hs.Add("@P_LOGINABASTECIDA", val.LoginAbastecida);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_ID_LANCTOESTOQUE", val.Id_lanctoestoque);
            hs.Add("@P_DT_REQUISICAO", val.Dt_requisicao);
            hs.Add("@P_VOLUME_REQUISICAO", val.Volume_requisicao);
            hs.Add("@P_DT_ABASTECIMENTO", val.Dt_abastecimento);
            hs.Add("@P_VOLUME", val.Volume);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_TP_ABASTECIMENTO", val.Tp_abastecimento);
            hs.Add("@P_TP_PAGAMENTO", val.Tp_pagamento);
            hs.Add("@P_KM_ATUAL", val.Km_atual);
            hs.Add("@P_TP_CAPTURA", val.Tp_captura);
            hs.Add("@P_NR_NOTAFISCAL", val.Nr_notafiscal);
            hs.Add("@P_NM_FORNECEDOR", val.Nm_fornecedor);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_DS_OBSERVACAO", val.Ds_observacao);

            return this.executarProc("IA_FRT_ABASTVEICULO", hs);
        }

        public string Excluir(TRegistro_AbastVeiculo val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);

            return this.executarProc("EXCLUI_FRT_ABASTVEICULO", hs);
        }
    }
    #endregion

    #region AbastFrota X CCusto
    public class TList_AbastFrota_X_CCusto : List<TRegistro_AbastFrota_X_CCusto> { }

    public class TRegistro_AbastFrota_X_CCusto
    {
        private decimal? id_abastecimento;
        public decimal? Id_abastecimento
        {
            get { return id_abastecimento; }
            set
            {
                id_abastecimento = value;
                id_abastecimentostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_abastecimentostr;
        public string Id_abastecimentostr
        {
            get { return id_abastecimentostr; }
            set
            {
                id_abastecimentostr = value;
                try
                {
                    id_abastecimento = decimal.Parse(value);
                }
                catch { id_abastecimento = null; }
            }
        }
        private decimal? id_ccustolan;
        public decimal? Id_ccustolan
        {
            get { return id_ccustolan; }
            set
            {
                id_ccustolan = value;
                id_ccustolanstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_ccustolanstr;
        public string Id_ccustolanstr
        {
            get { return id_ccustolanstr; }
            set
            {
                id_ccustolanstr = value;
                try
                {
                    id_ccustolan = decimal.Parse(value);
                }
                catch { id_ccustolan = null; }
            }
        }
    }

    public class TCD_AbastFrota_X_CCusto : TDataQuery
    {
        public TCD_AbastFrota_X_CCusto() { }

        public TCD_AbastFrota_X_CCusto(BancoDados.TObjetoBanco banco) { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
                sql.AppendLine("select " + strTop + " a.id_abastecimento, a.id_ccustolan ");
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIN_AbastFrota_X_CCusto a ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_AbastFrota_X_CCusto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_AbastFrota_X_CCusto lista = new TList_AbastFrota_X_CCusto();
            System.Data.SqlClient.SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_AbastFrota_X_CCusto reg = new TRegistro_AbastFrota_X_CCusto();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Abastecimento")))
                        reg.Id_abastecimento = reader.GetDecimal(reader.GetOrdinal("ID_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_CCustoLan")))
                        reg.Id_ccustolan = reader.GetDecimal(reader.GetOrdinal("ID_CCustoLan"));

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

        public string Gravar(TRegistro_AbastFrota_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("IA_FIN_ABASTFROTA_X_CCUSTO", hs);
        }

        public string Excluir(TRegistro_AbastFrota_X_CCusto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_ABASTECIMENTO", val.Id_abastecimento);
            hs.Add("@P_ID_CCUSTOLAN", val.Id_ccustolan);

            return this.executarProc("EXCLUI_FIN_ABASTFROTA_X_CCUSTO", hs);
        }
    }
    #endregion
}
