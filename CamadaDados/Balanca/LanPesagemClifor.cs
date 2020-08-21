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
    public class TList_RegLanPesagemClifor : List<TRegistro_LanPesagemClifor>, IComparer<TRegistro_LanPesagemClifor>
    {
        #region IComparer<TRegistro_LanPesagemClifor> Members
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

        public TList_RegLanPesagemClifor()
        { }

        public TList_RegLanPesagemClifor(System.ComponentModel.PropertyDescriptor Prop,
                                         System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_LanPesagemClifor value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_LanPesagemClifor x, TRegistro_LanPesagemClifor y)
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
    public class TRegistro_LanPesagemClifor
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
        public decimal Id_desdobro
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

        private decimal? nr_contrato;
        [DataMember]
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = value.HasValue ? value.Value.ToString() : string.Empty;
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
        [DataMember]
        public string Tp_Movimento
        {
            get;
            set;
        }
        [DataMember]
        public string Tp_MovtoPedido
        {
            get;
            set;
        }
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
                    return Convert.ToDateTime(dt_emissaostr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_emissaostr = value;
                try
                {
                    dt_emissao = Convert.ToDateTime(value);
                }
                catch
                { dt_emissao = null; }
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
                dt_saientstr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_saientstr;
        public string Dt_saientstr
        {
            get 
            {
                try
                {
                    return Convert.ToDateTime(dt_saientstr).ToString("dd/MM/yyyy");
                }
                catch
                { return string.Empty; }
            }
            set
            {
                dt_saientstr = value;
                try
                {
                    dt_saient = Convert.ToDateTime(value);
                }
                catch
                { dt_saient = null; }
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
        public string Nf_mestra
        {
            get;
            set;
        }
        [DataMember]
        public string Digitomestra
        {
            get;
            set;
        }
        [DataMember]
        public decimal? Nr_LanctoFiscal_Mestra
        { get; set; }
        [DataMember]
        public string Nome_cliforpedido
        {
            get;
            set;
        }
        [DataMember]
        public string Nome_clifor
        {
            get;
            set;
        }
        [DataMember]
        public string Tp_pessoa
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_endereco
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_uf
        { get; set; }
        [DataMember]
        public string Uf
        {
            get;
            set;
        }
        [DataMember]
        public string Uf_Emp
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_clifor
        {
            get;
            set;
        }
        [DataMember]
        public string Cd_condfiscal_clifor
        {
            get;
            set;
        }
        [DataMember]
        public string Nr_cgc_cpf_clifor
        {
            get;
            set;
        }
        [DataMember]
        public string Insc_estadual_clifor
        { get; set; }
        [DataMember]
        public string Cd_cliforpedido
        {
            get;
            set;
        }
        [DataMember]
        public string Nr_cgc_cpf_cliforpedido
        {
            get;
            set;
        }
        [DataMember]
        public string Tp_Natureza_Classif
        { get; set; }
        [DataMember]
        public string Tp_Natureza_Pesagem
        { get; set; }
        
        private string st_registro;
        [DataMember]
        public string St_registro
        {
            get { return st_registro; }
            set 
            { 
                st_registro = value; 
                if(value.Trim().Equals("C"))
                    if (Desdobroprodutos != null)
                    {
                        if (DesdProdExcluir == null)
                            DesdProdExcluir = new TList_RegLanPesagemProduto();
                        for (int i = 0; i < Desdobroprodutos.Count; i++)
                        {
                            Desdobroprodutos[i].St_registro = "C";
                            DesdProdExcluir.Add(Desdobroprodutos[i]);
                            Desdobroprodutos.RemoveAt(i);
                        }
                    }
            }
        }
        [DataMember]
        public string Ds_enderecofornecedor
        {
            get;
            set;
        }
        [DataMember]
        public string Ds_cidadefornecedor
        {
            get;
            set;
        }
        [DataMember]
        public TList_RegLanPesagemProduto Desdobroprodutos
        {
            get;
            set;
        }
        [DataMember]
        public TList_RegLanPesagemProduto DesdProdExcluir
        {
            get;
            set;
        }
        public string TP_Nota 
        {
            get { return this.Tp_pessoa.Trim().Equals("J") && this.Tp_Movimento.Trim().ToUpper().Equals("E") ? "T" : "P"; }
        }
        [DataMember]
        public string cd_condPgto { get; set; }
        [DataMember]
        public string Cd_transportadora
        { get; set; }
        [DataMember]
        public string Nm_transportadora
        { get; set; }
        [DataMember]
        public string Nr_cpfcnpj_transp
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
        private string freteporconta;
        [DataMember]
        public string Freteporconta
        {
            get { return freteporconta; }
            set
            {
                freteporconta = value;
                if (value.Trim().ToUpper().Equals("1"))
                    tipo_frete = "REMETENTE";
                else if (value.Trim().ToUpper().Equals("2"))
                    tipo_frete = "DESTINATARIO";
            }
        }
        private string tipo_frete;
        [DataMember]
        public string Tipo_frete
        {
            get { return tipo_frete; }
            set
            {
                tipo_frete = value;
                if (value.Trim().ToUpper().Equals("REMETENTE"))
                    freteporconta = "1";
                else if (value.Trim().ToUpper().Equals("DESTINATARIO"))
                    freteporconta = "2";
            }
        }
        [DataMember]
        public bool St_aplicar
        { get; set; }
        
        public TRegistro_LanPesagemClifor()
        {
            this.Cd_empresa = string.Empty;
            this.Id_ticket = decimal.Zero;
            this.Tp_pesagem = string.Empty;
            this.Id_desdobro = decimal.Zero;
            this.nr_pedido = null;
            this.nr_pedidostring = string.Empty;
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.Tp_Movimento = string.Empty;
            this.Tp_MovtoPedido = string.Empty;
            this.Nr_notafiscal = string.Empty;
            this.Nr_serie = string.Empty;
            this.Cd_modelo = string.Empty;
            this.dt_emissao = DateTime.Now;
            this.dt_emissaostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.dt_saient = DateTime.Now;
            this.dt_saientstr = DateTime.Now.ToString("dd/MM/yyyy");
            this.ChaveAcessoNFE = string.Empty;
            this.OBS_Fiscal = string.Empty;
            this.DadosAdicionais = string.Empty;
            this.Nf_mestra = string.Empty;
            this.Digitomestra = string.Empty;
            this.Nr_LanctoFiscal_Mestra = null;
            this.Nome_cliforpedido = string.Empty;
            this.Nome_clifor = string.Empty;
            this.Tp_pessoa = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Cd_uf = string.Empty;
            this.Uf = string.Empty;
            this.Uf_Emp = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Cd_condfiscal_clifor = string.Empty;
            this.Nr_cgc_cpf_clifor = string.Empty;
            this.Insc_estadual_clifor = string.Empty;
            this.Cd_cliforpedido = string.Empty;
            this.Nr_cgc_cpf_cliforpedido = string.Empty;
            this.Tp_Natureza_Classif = string.Empty;
            this.Tp_Natureza_Pesagem = string.Empty;
            this.st_registro = "A";
            this.Ds_cidadefornecedor = string.Empty;
            this.Ds_enderecofornecedor = string.Empty;
            this.Desdobroprodutos = new TList_RegLanPesagemProduto();
            this.DesdProdExcluir = new TList_RegLanPesagemProduto();
            this.cd_condPgto = string.Empty;
            this.Cd_transportadora = string.Empty;
            this.Nm_transportadora = string.Empty;
            this.Nr_cpfcnpj_transp = string.Empty;
            this.Cd_endtransportadora = string.Empty;
            this.Ds_endtransportadora = string.Empty;
            this.Placaveiculo = string.Empty;
            this.Especie = string.Empty;
            this.Numero = string.Empty;
            this.Marca = string.Empty;
            this.Quantidade = decimal.Zero;
            this.Pesobruto = decimal.Zero;
            this.Pesoliquido = decimal.Zero;
            this.freteporconta = string.Empty;
            this.tipo_frete = string.Empty;
            this.St_aplicar = false;
        }
    }

    public class TCD_LanPesagemClifor : TDataQuery
    {
        public TCD_LanPesagemClifor()
        { }

        public TCD_LanPesagemClifor(string vNM_ProcSqlBusca)
        {
            this.NM_ProcSqlBusca = vNM_ProcSqlBusca;
        }

        public TCD_LanPesagemClifor(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.ID_Ticket, ");
                sql.AppendLine("a.TP_Pesagem, p.Tp_movimento, a.nr_contrato, a.freteporconta, ");
                sql.AppendLine("a.ID_Desdobro, a.NR_Pedido, a.Nr_notafiscal, a.Nr_Serie, serie.cd_modelo, ");
                sql.AppendLine("a.DT_Emissao, a.dt_saient, nfm.nr_notafiscal as NF_Mestra, d.Insc_Estadual as Insc_Estadual_clifor, ");
                sql.AppendLine("nfm.nr_serie as DigitoMestra, a.NR_LanctoFiscal_Mestra, ped.TP_Movimento as TP_MovtoPedido, ");
                sql.AppendLine("case when isNull(a.nome_cliforpedido, '') = '' then (select y.NM_Clifor From TB_FAT_Pedido x inner join VTB_FIN_Clifor y ");
                sql.AppendLine("                                   On y.CD_Clifor = x.CD_Clifor Where x.NR_Pedido = a.NR_Pedido) else a.nome_cliforpedido end as nome_cliforpedido, ");
                sql.AppendLine("a.TP_Pessoa, a.CD_Clifor, isNull(f.NR_CGC, f.NR_CPF)as NR_CGC_CPF_Clifor, f.nm_clifor as nome_clifor, f.cd_condfiscal_clifor, ");
                sql.AppendLine("a.CD_Endereco, d.DS_Endereco as DS_EnderecoFornecedor, a.CD_CliforPedido, isNull(c.NR_CGC, c.NR_CPF) as NR_CGC_CPF_CliforPedido, ");
                sql.AppendLine("d.DS_Cidade as DS_CidadeFornecedor, d.cd_uf, d.uf, a.ST_Registro, ee.uf as UF_Emp, cto.TP_Natureza_Pesagem, cto.TP_Natureza_Classif, a.OBS_Fiscal, a.DadosAdicionais, a.ChaveAcessoNFE, ped.cd_condPgto, ");
                sql.AppendLine("a.cd_transportadora, isnull(a.nm_transportadora, cTransp.nm_clifor) as nm_transportadora, isnull(cTransp.nr_cgc, cTransp.nr_cpf) as nr_cpfcnpj_transp, ");
                sql.AppendLine("a.cd_endtransportadora, cEndTransp.ds_endereco as ds_endtransportadora, ");
                sql.AppendLine("a.placaveiculo, a.especie, a.numero, a.marca, a.quantidade, a.pesobruto, a.pesoliquido ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");
            sql.AppendLine("From TB_Bal_Clifor a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("On b.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("inner join VTB_BAL_PsGraos p ");
            sql.AppendLine("on p.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and p.id_ticket = a.id_ticket ");
            sql.AppendLine("and p.tp_pesagem = a.tp_pesagem");
            sql.AppendLine("inner join VTB_FIN_Clifor ce ");
            sql.AppendLine("on ce.cd_clifor = b.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_Endereco ee ");
            sql.AppendLine("on ee.cd_clifor = b.cd_clifor ");
            sql.AppendLine("and ee.cd_endereco = b.cd_endereco ");
            sql.AppendLine("inner join TB_BAL_TPPesagem e ");
            sql.AppendLine("On e.TP_Pesagem = a.TP_Pesagem ");
            sql.AppendLine("left outer join TB_FAT_SerieNF serie ");
            sql.AppendLine("on a.nr_serie = serie.nr_serie ");
            sql.AppendLine("left outer join TB_GRO_Contrato cto ");
            sql.AppendLine("on cto.nr_contrato = a.nr_contrato ");
            sql.AppendLine("left outer join TB_FAT_Notafiscal nfm ");
            sql.AppendLine("on nfm.cd_empresa = a.cd_empresa ");
            sql.AppendLine("and nfm.nr_lanctofiscal = a.nr_lanctofiscal_mestra ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("On c.CD_Clifor = a.CD_CliforPedido ");
            sql.AppendLine("left outer join VTB_FIN_Clifor f ");
            sql.AppendLine("On f.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_Endereco d ");
            sql.AppendLine("On d.CD_Clifor = a.CD_Clifor ");
            sql.AppendLine("and d.CD_Endereco = a.CD_Endereco ");
            sql.AppendLine("left outer join TB_FAT_Pedido ped ");
            sql.AppendLine("On ped.NR_Pedido = a.NR_Pedido ");
            sql.AppendLine("left outer join vtb_fin_clifor cTransp ");
            sql.AppendLine("on a.cd_transportadora = cTransp.cd_clifor ");
            sql.AppendLine("left outer join vtb_fin_endereco cEndTransp ");
            sql.AppendLine("on a.cd_transportadora = cEndTransp.cd_clifor ");
            sql.AppendLine("and a.cd_endtransportadora = cEndTransp.cd_endereco ");
            
            sql.AppendLine("where isNull(a.ST_Registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (int i = 0; i < (vBusca.Length); i++)
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            if (this.NM_ProcSqlBusca.Trim() == "")
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            else
            {
                Type t = this.GetType();
                System.Reflection.MethodInfo m = t.GetMethod(this.NM_ProcSqlBusca,
                                                            System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.NonPublic |
                                                            System.Reflection.BindingFlags.Instance);
                string sql = m.Invoke(this, new object[] { vBusca }).ToString();
                return this.ExecutarBuscaEscalar(sql, null);
            }
        }

        public TList_RegLanPesagemClifor Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_RegLanPesagemClifor lista = new TList_RegLanPesagemClifor();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LanPesagemClifor reg = new TRegistro_LanPesagemClifor();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Ticket"))))
                        reg.Id_ticket = reader.GetDecimal(reader.GetOrdinal("ID_Ticket"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_Desdobro"))))
                        reg.Id_desdobro = reader.GetDecimal(reader.GetOrdinal("ID_Desdobro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Pedido"))))
                        reg.Nr_pedido = reader.GetDecimal(reader.GetOrdinal("NR_Pedido"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal"))))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal")).ToString();
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serie"))))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt"))))
                        reg.Dt_SaiEnt = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    
                    if (!(reader.IsDBNull(reader.GetOrdinal("NF_Mestra"))))
                        reg.Nf_mestra = reader.GetString(reader.GetOrdinal("NF_Mestra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DigitoMestra"))))
                        reg.Digitomestra = reader.GetString(reader.GetOrdinal("DigitoMestra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal_Mestra"))))
                        reg.Nr_LanctoFiscal_Mestra = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal_Mestra"));
                    
                    if (!(reader.IsDBNull(reader.GetOrdinal("OBS_Fiscal"))))
                        reg.OBS_Fiscal = reader.GetString(reader.GetOrdinal("OBS_Fiscal"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DadosAdicionais"))))
                        reg.DadosAdicionais = reader.GetString(reader.GetOrdinal("DadosAdicionais"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ChaveAcessoNFE"))))
                        reg.ChaveAcessoNFE = reader.GetString(reader.GetOrdinal("ChaveAcessoNFE"));

                    if (!(reader.IsDBNull(reader.GetOrdinal("Nome_CliforPedido"))))
                        reg.Nome_cliforpedido = reader.GetString(reader.GetOrdinal("Nome_CliforPedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nome_clifor"))))
                        reg.Nome_clifor = reader.GetString(reader.GetOrdinal("nome_clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pessoa"))))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("TP_Pessoa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Endereco"))))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CGC_CPF_Clifor"))))
                        reg.Nr_cgc_cpf_clifor = reader.GetString(reader.GetOrdinal("NR_CGC_CPF_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Insc_Estadual_Clifor")))
                        reg.Insc_estadual_clifor = reader.GetString(reader.GetOrdinal("Insc_Estadual_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CliforPedido"))))
                        reg.Cd_cliforpedido = reader.GetString(reader.GetOrdinal("CD_CliforPedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CGC_CPF_CliforPedido"))))
                        reg.Nr_cgc_cpf_cliforpedido = reader.GetString(reader.GetOrdinal("NR_CGC_CPF_CliforPedido"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("UF"))))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_uf")))
                        reg.Cd_uf = reader.GetString(reader.GetOrdinal("cd_uf"));
                   
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CidadeFornecedor"))))
                        reg.Ds_cidadefornecedor = reader.GetString(reader.GetOrdinal("DS_CidadeFornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_EnderecoFornecedor"))))
                        reg.Ds_enderecofornecedor = reader.GetString(reader.GetOrdinal("DS_EnderecoFornecedor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_MovtoPedido"))))
                        reg.Tp_MovtoPedido = reader.GetString(reader.GetOrdinal("TP_MovtoPedido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondFiscal_Clifor")))
                        reg.Cd_condfiscal_clifor = reader.GetString(reader.GetOrdinal("CD_CondFiscal_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_movimento")))
                        reg.Tp_Movimento = reader.GetString(reader.GetOrdinal("Tp_movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF_Emp")))
                        reg.Uf_Emp = reader.GetString(reader.GetOrdinal("UF_Emp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Natureza_Classif")))
                        reg.Tp_Natureza_Classif = reader.GetString(reader.GetOrdinal("TP_Natureza_Classif"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Natureza_Pesagem")))
                        reg.Tp_Natureza_Pesagem = reader.GetString(reader.GetOrdinal("TP_Natureza_Pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Contrato")))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("Nr_Contrato"));

                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condPgto")))
                        reg.cd_condPgto = reader.GetString(reader.GetOrdinal("cd_condPgto"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Transportadora")))
                        reg.Cd_transportadora = reader.GetString(reader.GetOrdinal("CD_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Transportadora")))
                        reg.Nm_transportadora = reader.GetString(reader.GetOrdinal("NM_Transportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_CPFCNPJ_Transp")))
                        reg.Nr_cpfcnpj_transp = reader.GetString(reader.GetOrdinal("NR_CPFCNPJ_Transp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EndTransportadora")))
                        reg.Cd_endtransportadora = reader.GetString(reader.GetOrdinal("CD_EndTransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endtransportadora")))
                        reg.Ds_endtransportadora = reader.GetString(reader.GetOrdinal("ds_endtransportadora"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo")))
                        reg.Placaveiculo = reader.GetString(reader.GetOrdinal("PlacaVeiculo"));
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

        public string GravarPesagemClifor(TRegistro_LanPesagemClifor val)
        {
            Hashtable hs = new Hashtable(32);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_DESDOBRO", val.Id_desdobro);
            hs.Add("@P_NR_PEDIDO", val.Nr_pedido);
            hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
            hs.Add("@P_NR_LANCTOFISCAL_MESTRA", val.Nr_LanctoFiscal_Mestra);

            hs.Add("@P_NOME_CLIFORPEDIDO", val.Nome_cliforpedido);
            hs.Add("@P_TP_PESSOA", val.Tp_pessoa);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_CLIFORPEDIDO", val.Cd_cliforpedido);

            hs.Add("@P_OBS_FISCAL", val.OBS_Fiscal);
            hs.Add("@P_DADOSADICIONAIS", val.DadosAdicionais);
            hs.Add("@P_CHAVEACESSONFE", val.ChaveAcessoNFE);

            hs.Add("@P_NR_NOTAFISCAL", val.Nr_notafiscal);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_SAIENT", val.Dt_SaiEnt);

            hs.Add("@P_CD_TRANSPORTADORA", val.Cd_transportadora);
            hs.Add("@P_NM_TRANSPORTADORA", val.Nm_transportadora);
            hs.Add("@P_NR_CPFCNPJ_TRANSP", val.Nr_cpfcnpj_transp);
            hs.Add("@P_CD_ENDTRANSPORTADORA", val.Cd_endtransportadora);
            hs.Add("@P_PLACAVEICULO", val.Placaveiculo);
            hs.Add("@P_ESPECIE", val.Especie);
            hs.Add("@P_NUMERO", val.Numero);
            hs.Add("@P_MARCA", val.Marca);
            hs.Add("@P_QUANTIDADE", val.Quantidade);
            hs.Add("@P_PESOBRUTO", val.Pesobruto);
            hs.Add("@P_PESOLIQUIDO", val.Pesoliquido);
            hs.Add("@P_FRETEPORCONTA", val.Freteporconta);

            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_BAL_CLIFOR", hs);
        }

        public string DeletarPesagemClifor(TRegistro_LanPesagemClifor val)
        {
            Hashtable hs = new Hashtable(4);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_ID_DESDOBRO", val.Id_desdobro);

            return this.executarProc("EXCLUI_BAL_CLIFOR", hs);
        }

        public void recalculaNotas(TRegistro_LanPesagem val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_ID_TICKET", val.Id_ticket);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            this.executarProc("F_RECALCULANOTA", hs);
        }
    }
}
