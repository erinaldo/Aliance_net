using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel
{
    #region Venda Combustivel
    public class TList_VendaCombustivel : List<TRegistro_VendaCombustivel>, IComparer<TRegistro_VendaCombustivel>
    {
        #region IComparer<TRegistro_VendaCombustivel> Members
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

        public TList_VendaCombustivel()
        { }

        public TList_VendaCombustivel(System.ComponentModel.PropertyDescriptor Prop,
                                      System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_VendaCombustivel value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_VendaCombustivel x, TRegistro_VendaCombustivel y)
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
    
    public class TRegistro_VendaCombustivel
    {
        private decimal? id_venda;
        public decimal? Id_venda
        {
            get { return id_venda; }
            set
            {
                id_venda = value;
                id_vendastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_vendastr;
        public string Id_vendastr
        {
            get { return id_vendastr; }
            set
            {
                id_vendastr = value;
                try
                {
                    id_venda = decimal.Parse(value);
                }
                catch
                { id_venda = null; }
            }
        }
        private decimal? id_bico;
        public decimal? Id_bico
        {
            get { return id_bico; }
            set
            {
                id_bico = value;
                id_bicostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bicostr;
        public string Id_bicostr
        {
            get { return id_bicostr; }
            set
            {
                id_bicostr = value;
                try
                {
                    id_bico = decimal.Parse(value);
                }
                catch
                { id_bico = null; }
            }
        }
        public string Enderecofisicobico
        { get; set; }
        public string Ds_label
        { get; set; }
        private decimal? id_bomba;
        public decimal? Id_bomba
        {
            get { return id_bomba; }
            set
            {
                id_bomba = value;
                id_bombastr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_bombastr;
        public string Id_bombastr
        {
            get { return id_bombastr; }
            set
            {
                id_bombastr = value;
                try
                {
                    id_bomba = decimal.Parse(value);
                }
                catch
                { id_bomba = null; }
            }
        }
        private decimal? id_tanque;
        public decimal? Id_tanque
        {
            get { return id_tanque; }
            set
            {
                id_tanque = value;
                id_tanquestr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_tanquestr;
        public string Id_tanquestr
        {
            get { return id_tanquestr; }
            set
            {
                id_tanquestr = value;
                try
                {
                    id_tanque = decimal.Parse(value);
                }
                catch
                { id_tanque = null; }
            }
        }
        private decimal? id_lancto;
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Ds_abreviadaProduto
        { get; set; }
        public string Cd_grupo
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }
        public string Sigla_unidade
        { get; set; }
        public string Cd_local
        { get; set; }
        public string Ds_local
        { get; set; }
        public decimal? Id_lancto
        {
            get { return id_lancto; }
            set
            {
                id_lancto = value;
                id_lanctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_lanctostr;
        public string Id_lanctostr
        {
            get { return id_lanctostr; }
            set
            {
                id_lanctostr = value;
                try
                {
                    id_lancto = decimal.Parse(value);
                }
                catch
                { id_lancto = null; }
            }
        }
        private decimal? id_cupom;
        public decimal? Id_cupom
        {
            get { return id_cupom; }
            set
            {
                id_cupom = value;
                id_cupomstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_cupomstr;
        public string Id_cupomstr
        {
            get { return id_cupomstr; }
            set
            {
                id_cupomstr = value;
                try
                {
                    id_cupom = decimal.Parse(value);
                }
                catch
                { id_cupom = null; }
            }
        }
        public string LoginSessao
        { get; set; }
        private decimal volumeabastecido;
        public decimal Volumeabastecido
        {
            get { return Math.Round(volumeabastecido, 3, MidpointRounding.AwayFromZero); }
            set { volumeabastecido = Math.Round(value, 3, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_unitario;
        public decimal Vl_unitario
        {
            get { return Math.Round(vl_unitario, 7, MidpointRounding.AwayFromZero); }
            set { vl_unitario = Math.Round(value, 7, MidpointRounding.AwayFromZero); }
        }
        private decimal vl_subtotal;
        public decimal Vl_subtotal
        {
            get { return Math.Round(vl_subtotal, 2, MidpointRounding.AwayFromZero); }
            set { vl_subtotal = Math.Round(value, 2, MidpointRounding.AwayFromZero); }
        }
        public decimal Tempoabastecimento
        { get; set; }
        public decimal Numeroabastecimento
        { get; set; }
        public decimal Encerrantebico
        { get; set; }
        private DateTime? dt_abastecimento;
        public DateTime? Dt_abastecimento
        {
            get { return dt_abastecimento; }
            set
            {
                dt_abastecimento = value;
                dt_abastecimentostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy HH:mm:ss") : string.Empty;
            }
        }
        private string dt_abastecimentostr;
        public string Dt_abastecimentostr
        {
            get
            {
                try
                {
                    return DateTime.Parse(dt_abastecimentostr).ToString("dd/MM/yyyy HH:mm:ss");
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
        public string St_afericao
        { get; set; }
        public bool St_afericaobool
        { get { return St_afericao.Trim().ToUpper().Equals("S"); } }
        public string Tp_registro
        { get; set; }
        public string Tipo_registro
        {
            get
            {
                if (Tp_registro.Trim().ToUpper().Equals("A"))
                    return "AUTOMATICO";
                else if (Tp_registro.Trim().ToUpper().Equals("M"))
                    return "MANUAL";
                else return string.Empty;
            }
        }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ATIVO";
                else if (St_registro.Trim().ToUpper().Equals("F"))
                    return "FATURADO";
                else if (St_registro.Trim().ToUpper().Equals("E"))
                    return "EM ESPERA";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else if (St_registro.Trim().ToUpper().Equals("I"))
                    return "INCONSISTENTE";
                else return string.Empty;
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Cd_condfiscal_produto
        { get; set; }
        public string Cd_frentista
        { get; set; }
        public string Nm_frentista
        { get; set; }
        public string Placaveiculo
        { get; set; }
        public decimal Km_atual
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Cpf_motorista
        { get; set; }
        public string Nr_frota
        { get; set; }
        public string Login_espera
        { get; set; }
        private decimal? id_convenio;
        public decimal? Id_convenio
        {
            get { return id_convenio; }
            set
            {
                id_convenio = value;
                id_conveniostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_conveniostr;
        public string Id_conveniostr
        {
            get { return id_conveniostr; }
            set
            {
                id_conveniostr = value;
                try
                {
                    id_convenio = decimal.Parse(value);
                }
                catch
                { id_convenio = null; }
            }
        }
        public string StringAbast
        { get; set; }
        public decimal? Id_caixa
        { get; set; }
        public bool St_processar
        { get; set; }

        public CamadaDados.Faturamento.Fidelizacao.TRegistro_PontosFidelidade rPontosFid
        { get; set; }

        public TRegistro_VendaCombustivel()
        {
            this.id_venda = null;
            this.id_vendastr = string.Empty;
            this.id_bico = null;
            this.id_bicostr = string.Empty;
            this.Enderecofisicobico = string.Empty;
            this.Ds_label = string.Empty;
            this.id_bomba = null;
            this.id_bombastr = string.Empty;
            this.id_tanque = null;
            this.id_tanquestr = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Cd_produto = string.Empty;
            this.Ds_produto = string.Empty;
            this.Ds_abreviadaProduto = string.Empty;
            this.Cd_grupo = string.Empty;
            this.Cd_condfiscal_produto = string.Empty;
            this.Cd_unidade = string.Empty;
            this.Ds_unidade = string.Empty;
            this.Sigla_unidade = string.Empty;
            this.Cd_local = string.Empty;
            this.Ds_local = string.Empty;
            this.id_lancto = null;
            this.id_lanctostr = string.Empty;
            this.id_cupom = null;
            this.id_cupomstr = string.Empty;
            this.LoginSessao = string.Empty;
            this.volumeabastecido = decimal.Zero;
            this.vl_unitario = decimal.Zero;
            this.vl_subtotal = decimal.Zero;
            this.Tempoabastecimento = decimal.Zero;
            this.Numeroabastecimento = decimal.Zero;
            this.Encerrantebico = decimal.Zero;
            this.dt_abastecimento = null;
            this.dt_abastecimentostr = string.Empty;
            this.St_afericao = "N";
            this.Tp_registro = "A";
            this.St_registro = "A";
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_endereco = string.Empty;
            this.id_convenio = null;
            this.id_conveniostr = string.Empty;
            this.Placaveiculo = string.Empty;
            this.Km_atual = decimal.Zero;
            this.Nm_motorista = string.Empty;
            this.Cpf_motorista = string.Empty;
            this.Nr_frota = string.Empty;
            this.Login_espera = string.Empty;
            this.StringAbast = string.Empty;
            this.Cd_frentista = string.Empty;
            this.Nm_frentista = string.Empty;
            this.Id_caixa = null;
            this.St_processar = false;
            this.rPontosFid = null;
        }
    }

    public class TCD_VendaCombustivel : TDataQuery
    {
        public TCD_VendaCombustivel()
        { }

        public TCD_VendaCombustivel(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.ID_Venda, a.ID_Bico, b.EnderecoFisicoBico, d.cd_grupo, ");
                sql.AppendLine("b.ID_Bomba, b.Id_Tanque, c.CD_Produto, d.DS_Produto, d.ds_abreviadaProduto, b.ds_label, ");
                sql.AppendLine("d.CD_Unidade, c.CD_Local, e.DS_Local, a.Id_lancto, g.ds_unidade, a.nr_frota, a.id_caixa, ");
                sql.AppendLine("a.VolumeAbastecido, a.Vl_Unitario, a.Vl_SubTotal, g.sigla_unidade, a.loginespera, ");
                sql.AppendLine("a.TempoAbastecimento, a.NumeroAbastecimento, a.Id_Cupom, a.placaveiculo, ");
                sql.AppendLine("a.EncerranteBico, a.DT_Abastecimento, a.ST_Registro, d.cd_condfiscal_produto, ");
                sql.AppendLine("a.cd_empresa, f.nm_empresa, a.tp_registro, a.st_afericao, a.km_atual, a.nm_motorista, ");
                sql.AppendLine("a.cd_clifor, h.nm_clifor, a.id_convenio, a.StringAbast, a.cd_endereco, i.ds_endereco, ");
                sql.AppendLine("a.cd_frentista, j.nm_clifor as nm_frentista, a.Cpf_motorista, l.Login as LoginSessao ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_VendaCombustivel a ");
            sql.AppendLine("inner join TB_PDC_BicoBomba b ");
            sql.AppendLine("on a.ID_Bico = b.ID_Bico ");
            sql.AppendLine("inner join TB_PDC_Tanque c ");
            sql.AppendLine("on b.Id_Tanque = c.Id_Tanque ");
            sql.AppendLine("and b.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on c.CD_Produto = d.CD_Produto ");
            sql.AppendLine("inner join TB_EST_LocalArm e ");
            sql.AppendLine("on c.CD_Local = e.CD_Local ");
            sql.AppendLine("inner join tb_div_empresa f ");
            sql.AppendLine("on a.cd_empresa = f.cd_empresa ");
            sql.AppendLine("inner join TB_EST_Unidade g ");
            sql.AppendLine("on d.cd_unidade = g.cd_unidade ");
            sql.AppendLine("left outer join tb_fin_clifor h ");
            sql.AppendLine("on a.cd_clifor = h.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_endereco i ");
            sql.AppendLine("on a.cd_clifor = i.cd_clifor ");
            sql.AppendLine("and a.cd_endereco = i.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_clifor j ");
            sql.AppendLine("on a.cd_frentista = j.cd_clifor ");
            sql.AppendLine("left outer join tb_pdv_vendarapida k ");
            sql.AppendLine("on a.cd_empresa = k.cd_empresa ");
            sql.AppendLine("and a.id_cupom = k.id_vendarapida ");
            sql.AppendLine("left outer join tb_pdv_sessao l ");
            sql.AppendLine("on k.id_pdv = l.id_pdv ");
            sql.AppendLine("and k.id_sessao = l.id_sessao ");

            sql.AppendLine("where isnull(a.st_registro, 'A') <> 'C'");

            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
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
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo, vOrder), vParametros);
        }

        public TList_VendaCombustivel Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_VendaCombustivel lista = new TList_VendaCombustivel();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaCombustivel reg = new TRegistro_VendaCombustivel();
                    if (!(reader.IsDBNull(reader.GetOrdinal("Id_Cupom"))))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("Id_Cupom"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("id_lancto"))))
                        reg.Id_lancto = reader.GetDecimal(reader.GetOrdinal("id_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginsessao")))
                        reg.LoginSessao = reader.GetString(reader.GetOrdinal("loginSessao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_produto"))))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("ds_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_abreviadaproduto")))
                        reg.Ds_abreviadaProduto = reader.GetString(reader.GetOrdinal("ds_abreviadaproduto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condfiscal_produto")))
                        reg.Cd_condfiscal_produto = reader.GetString(reader.GetOrdinal("cd_condfiscal_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("sigla_Unidade")))
                        reg.Sigla_unidade = reader.GetString(reader.GetOrdinal("sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EnderecoFisicoBico")))
                        reg.Enderecofisicobico = reader.GetString(reader.GetOrdinal("EnderecoFisicoBico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_label")))
                        reg.Ds_label = reader.GetString(reader.GetOrdinal("ds_label"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Venda")))
                        reg.Id_venda = reader.GetDecimal(reader.GetOrdinal("ID_Venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("ID_Bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_Bomba")))
                        reg.Id_bomba = reader.GetDecimal(reader.GetOrdinal("ID_Bomba"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_local")))
                        reg.Cd_local = reader.GetString(reader.GetOrdinal("cd_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_local")))
                        reg.Ds_local = reader.GetString(reader.GetOrdinal("ds_local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_Tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("Id_Tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_unitario")))
                        reg.Vl_unitario = reader.GetDecimal(reader.GetOrdinal("vl_unitario"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VolumeAbastecido")))
                        reg.Volumeabastecido = reader.GetDecimal(reader.GetOrdinal("VolumeAbastecido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("vl_subtotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TempoAbastecimento")))
                        reg.Tempoabastecimento = reader.GetDecimal(reader.GetOrdinal("TempoAbastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NumeroAbastecimento")))
                        reg.Numeroabastecimento = reader.GetDecimal(reader.GetOrdinal("NumeroAbastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EncerranteBico")))
                        reg.Encerrantebico = reader.GetDecimal(reader.GetOrdinal("EncerranteBico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Abastecimento")))
                        reg.Dt_abastecimento = reader.GetDateTime(reader.GetOrdinal("DT_Abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_afericao")))
                        reg.St_afericao = reader.GetString(reader.GetOrdinal("st_afericao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("placaveiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("placaveiculo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("km_atual")))
                        reg.Km_atual = reader.GetDecimal(reader.GetOrdinal("km_atual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_motorista")))
                        reg.Nm_motorista = reader.GetString(reader.GetOrdinal("nm_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cpf_motorista")))
                        reg.Cpf_motorista = reader.GetString(reader.GetOrdinal("cpf_motorista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_frota")))
                        reg.Nr_frota = reader.GetString(reader.GetOrdinal("nr_frota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("loginespera")))
                        reg.Login_espera = reader.GetString(reader.GetOrdinal("loginespera"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_convenio")))
                        reg.Id_convenio = reader.GetDecimal(reader.GetOrdinal("id_convenio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("stringabast")))
                        reg.StringAbast = reader.GetString(reader.GetOrdinal("stringabast"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_frentista")))
                        reg.Cd_frentista = reader.GetString(reader.GetOrdinal("cd_frentista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_frentista")))
                        reg.Nm_frentista = reader.GetString(reader.GetOrdinal("nm_frentista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_grupo")))
                        reg.Cd_grupo = reader.GetString(reader.GetOrdinal("cd_grupo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_caixa")))
                        reg.Id_caixa = reader.GetDecimal(reader.GetOrdinal("id_caixa"));

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

        public string Gravar(TRegistro_VendaCombustivel val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(28);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_BICO", val.Id_bico);
            hs.Add("@P_ID_CUPOM", val.Id_cupom);
            hs.Add("@P_ID_LANCTO", val.Id_lancto);
            hs.Add("@P_CD_PRODUTO", val.Cd_produto);
            hs.Add("@P_VOLUMEABASTECIDO", val.Volumeabastecido);
            hs.Add("@P_VL_UNITARIO", val.Vl_unitario);
            hs.Add("@P_VL_SUBTOTAL", val.Vl_subtotal);
            hs.Add("@P_TEMPOABASTECIMENTO", val.Tempoabastecimento);
            hs.Add("@P_NUMEROABASTECIMENTO", val.Numeroabastecimento);
            hs.Add("@P_ENCERRANTEBICO", val.Encerrantebico);
            hs.Add("@P_DT_ABASTECIMENTO", val.Dt_abastecimento);
            hs.Add("@P_ST_AFERICAO", val.St_afericao);
            hs.Add("@P_TP_REGISTRO", val.Tp_registro);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_KM_ATUAL", val.Km_atual);
            hs.Add("@P_NM_MOTORISTA", val.Nm_motorista);
            hs.Add("@P_CPF_MOTORISTA", val.Cpf_motorista);
            hs.Add("@P_NR_FROTA", val.Nr_frota);
            hs.Add("@P_LOGINESPERA", val.Login_espera);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_ID_CONVENIO", val.Id_convenio);
            hs.Add("@P_CD_FRENTISTA", val.Cd_frentista);
            hs.Add("@P_ID_CAIXA", val.Id_caixa);
            hs.Add("@P_STRINGABAST", val.StringAbast);

            return this.executarProc("IA_PDC_VENDACOMBUSTIVEL", hs);
        }

        public string Excluir(TRegistro_VendaCombustivel val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_ID_VENDA", val.Id_venda);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return this.executarProc("EXCLUI_PDC_VENDACOMBUSTIVEL", hs);
        }
    }
    #endregion

    #region Venda Conveniencia Painel Gerencial
    
    public class TRegistro_VendaConvPainel
    {
        
        public string Grupo
        { get; set; }
        
        public decimal Vl_venda
        { get; set; }
        
        public decimal Pc_representatividade
        { get; set; }
        
        public decimal Vl_tend
        { get; set; }

        public TRegistro_VendaConvPainel()
        {
            this.Grupo = string.Empty;
            this.Vl_venda = decimal.Zero;
            this.Pc_representatividade = decimal.Zero;
            this.Vl_tend = decimal.Zero;
        }
    }

    public class TCD_VendaConvPainel : TDataQuery
    {
        public TCD_VendaConvPainel()
        { }

        public TCD_VendaConvPainel(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select e.DS_Config as Grupo, SUM(ISNULL(b.Vl_SubTotal, 0) + ISNULL(b.Vl_Acrescimo, 0) - ISNULL(b.Vl_Desconto, 0)) as Vl_venda ");

            sql.AppendLine("from TB_PDV_CupomFiscal a ");
            sql.AppendLine("inner join TB_PDV_CupomFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.cd_empresa ");
            sql.AppendLine("and a.Id_Cupom = b.Id_Cupom ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_PDC_CFGPainelVendaConv_X_Grupo d ");
            sql.AppendLine("on c.CD_Grupo = d.CD_Grupo ");
            sql.AppendLine("inner join TB_PDC_CFGPainelVendaConv e ");
            sql.AppendLine("on d.ID_Config = e.ID_Config ");

            sql.AppendLine("where ISNULL(a.ST_CUPOM, 'N') <> 'S' ");
            sql.AppendLine("and ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'C' ");
            
            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            sql.AppendLine("group by e.DS_Config ");

            sql.AppendLine("union all ");

            sql.AppendLine("select 'OUTROS' as Grupo, SUM(ISNULL(b.Vl_SubTotal, 0) + ISNULL(b.Vl_Acrescimo, 0) - ISNULL(b.Vl_Desconto, 0)) as Vl_Venda ");

            sql.AppendLine("from TB_PDV_CupomFiscal a ");
            sql.AppendLine("inner join TB_PDV_CupomFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.cd_empresa ");
            sql.AppendLine("and a.Id_Cupom = b.Id_Cupom ");

            sql.AppendLine("where ISNULL(a.ST_CUPOM, 'N') <> 'S' ");
            sql.AppendLine("and ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and not exists(select 1 from TB_EST_Produto x ");
            sql.AppendLine("				inner join TB_PDC_CFGPainelVendaConv_X_Grupo y ");
            sql.AppendLine("				on x.CD_Grupo = y.CD_Grupo ");
            sql.AppendLine("				where x.CD_Produto = b.CD_Produto) ");
            sql.AppendLine("and not exists(select 1 from tb_est_tpproduto x ");
		    sql.AppendLine("                inner join tb_est_produto y ");
			sql.AppendLine("            	on x.tp_produto = y.tp_produto ");
			sql.AppendLine("            	where b.cd_produto = y.cd_produto ");
            sql.AppendLine("	            and isnull(x.st_combustivel, 'N') = 'S') ");

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            sql.AppendLine("group by a.CD_Empresa ");

            return sql.ToString();
        }

        public List<TRegistro_VendaConvPainel> Select(Utils.TpBusca[] vBusca)
        {
            bool podeFecharBco = false;
            List<TRegistro_VendaConvPainel> lista = new List<TRegistro_VendaConvPainel>();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VendaConvPainel reg = new TRegistro_VendaConvPainel();
                    if (!(reader.IsDBNull(reader.GetOrdinal("grupo"))))
                        reg.Grupo = reader.GetString(reader.GetOrdinal("grupo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("vl_venda"))))
                        reg.Vl_venda = reader.GetDecimal(reader.GetOrdinal("vl_venda"));

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

    #region Abastecidas Dia
    
    public class TRegistro_AbastecidasDia
    {
        
        public int Hora
        { get; set; }
        
        public int Qt_abastecida
        { get; set; }
        
        public decimal Tot_volumeabastecido
        { get; set; }
        
        public decimal TempoAbast
        { get; set; }

        public TRegistro_AbastecidasDia()
        {
            this.Hora = 0;
            this.Qt_abastecida = 0;
            this.Tot_volumeabastecido = decimal.Zero;
            this.TempoAbast = decimal.Zero;
        }
    }

    public class TCD_AbastecidasDia : TDataQuery
    {
        public TCD_AbastecidasDia()
        { }

        public TCD_AbastecidasDia(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, string Tempo)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select DATEPART(" + Tempo.Trim().ToUpper() + ", a.DT_Abastecimento) as Tempo, COUNT(*) as Qtde, ");
            sql.AppendLine("SUM(a.VolumeAbastecido) as Volume, ");
            sql.AppendLine("SUM(a.TempoAbastecimento) as TempoAbast ");

            sql.AppendLine("from TB_PDC_VendaCombustivel a ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') in ('A', 'E', 'F') ");
            sql.AppendLine("and ISNULL(a.ST_Afericao, 'N') <> 'S' ");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            sql.AppendLine("group by DATEPART(" + Tempo.Trim().ToUpper() + ", a.DT_Abastecimento) ");
            sql.AppendLine("order by DATEPART(" + Tempo.Trim().ToUpper() + ", a.DT_Abastecimento) ");

            return sql.ToString();
        }

        public List<TRegistro_AbastecidasDia> Select(Utils.TpBusca[] vBusca, string Tempo)
        {
            bool podeFecharBco = false;
            List<TRegistro_AbastecidasDia> lista = new List<TRegistro_AbastecidasDia>();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Tempo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AbastecidasDia reg = new TRegistro_AbastecidasDia();
                    if (!reader.IsDBNull(reader.GetOrdinal("Tempo")))
                        reg.Hora = reader.GetInt32(reader.GetOrdinal("Tempo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Qtde")))
                        reg.Qt_abastecida = reader.GetInt32(reader.GetOrdinal("Qtde"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Volume")))
                        reg.Tot_volumeabastecido = reader.GetDecimal(reader.GetOrdinal("Volume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TempoAbast")))
                        reg.TempoAbast = reader.GetDecimal(reader.GetOrdinal("TempoAbast"));

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
}
