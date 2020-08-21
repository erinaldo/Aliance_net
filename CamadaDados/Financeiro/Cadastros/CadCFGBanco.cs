using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using CamadaDados.Diversos;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadCFGBanco : List<TRegistro_CadCFGBanco>
    { }
    
    public class TRegistro_CadCFGBanco
    {
        private decimal? id_config;
        public decimal? Id_config
        {
            get { return id_config; }
            set
            {
                id_config = value;
                id_configstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configstr;
        public string Id_configstr
        {
            get { return id_configstr; }
            set
            {
                id_configstr = value;
                try
                {
                    id_config = decimal.Parse(value);
                }
                catch { id_config = null; }
            }
        }
        public string Ds_config
        { get; set; }
        public TRegistro_CadBanco Banco
        { get; set; }
        public TRegistro_CadEmpresa Empresa
        { get; set; }
        public string Cd_portador
        { get; set; }
        public string Ds_portador
        { get; set; }
        public string Cd_contager
        { get; set; }
        public string Ds_contager
        { get; set; }
        public string Nr_contacorrente { get; set; } = string.Empty;
        public string Digitoconta { get; set; } = string.Empty;
        public string Codigocedente 
        { get; set; }
        public string Digitocedente 
        { get; set; }
        public string Ano 
        { get; set; }
        public decimal Nossonumero 
        { get; set; }
        public string Ds_localpagamento 
        { get; set; }
        public string Postocedente 
        { get; set; }
        private string aceite_sn;
        public string Aceite_sn 
        {
            get { return aceite_sn; }
            set
            {
                aceite_sn = value;
                if (value.Trim().ToUpper().Equals("A"))
                    aceite = "ACEITE";
                else if (value.Trim().ToUpper().Equals("N"))
                    aceite = "NÃO ACEITE";
            }
        }
        private string aceite;
        public string Aceite
        {
            get { return aceite; }
            set
            {
                aceite = value;
                if (value.Trim().ToUpper().Equals("ACEITE"))
                    aceite_sn = "A";
                else if (value.Trim().ToUpper().Equals("NÃO ACEITE"))
                    aceite_sn = "N";
            }
        }
        private decimal? especiedocumento;
        public decimal? EspecieDocumento 
        {
            get { return especiedocumento; }
            set
            {
                especiedocumento = value;
                especiedocumentostring = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string especiedocumentostring;
        public string Especiedocumentostring
        {
            get { return especiedocumentostring; }
            set
            {
                especiedocumentostring = value;
                try
                {
                    especiedocumento = Convert.ToDecimal(value);
                }
                catch
                { especiedocumento = null; }
            }
        }
        public string Ds_instrucoes 
        { get; set; }
        private System.Drawing.Image logo_banco;
        public System.Drawing.Image Logo_banco
        {
            get { return logo_banco; }
            set
            {
                logo_banco = value;
                if (logo_banco != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        logo_banco.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        img = ms.ToArray();
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        private byte[] img;
        public byte[] Img
        {
            get{ return img; }
            set
            {
                img = value;
                if (value != null)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        ms.Write(value, 0, value.Length);
                        logo_banco = System.Drawing.Image.FromStream(ms);
                        ms.Close();
                        ms.Dispose();
                    }
                }
            }
        }
        private string tp_cobranca;
        public string Tp_cobranca
        {
            get { return tp_cobranca; }
            set
            {
                tp_cobranca = value;
                if (value.Trim().ToUpper().Equals("CR"))
                    tipo_cobranca = "COM REGISTRO";
                else if (value.Trim().ToUpper().Equals("SR"))
                    tipo_cobranca = "SEM REGISTRO";
            }
        }
        private string tipo_cobranca;
        public string Tipo_cobranca
        {
            get { return tipo_cobranca; }
            set
            {
                tipo_cobranca = value;
                if (value.Trim().ToUpper().Equals("COM REGISTRO"))
                    tp_cobranca = "CR";
                else if (value.Trim().ToUpper().Equals("SEM REGISTRO"))
                    tp_cobranca = "SR";
            }
        }
        public string Tp_carteira
        { get; set; }
        public string Modalidade
        { get; set; }
        public decimal Pc_jurodia
        { get; set; }
        private string tp_jurodia;
        public string Tp_jurodia
        {
            get { return tp_jurodia; }
            set
            {
                tp_jurodia = value;
                if (value.Trim().ToUpper().Equals("V"))
                    Tipo_jurodia = "R$";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_cobranca = "%";
            }
        }
        private string tipo_jurodia;
        public string Tipo_jurodia
        {
            get { return tipo_cobranca; }
            set
            {
                tipo_cobranca = value;
                if (value.Trim().Equals("R$"))
                    tp_jurodia = "V";
                else if (value.Trim().Equals("%"))
                    tp_jurodia = "P";

            }
        }
        public decimal Pc_desconto
        { get; set; }
        private string tp_desconto;
        public string Tp_desconto
        {
            get { return tp_desconto; }
            set
            {
                tp_desconto = value;
                if (value.Trim().ToUpper().Equals("V"))
                    tipo_desconto = "R$";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_desconto = "%";
            }
        }
        private string tipo_desconto;
        public string Tipo_desconto
        {
            get { return tipo_desconto; }
            set
            {
                tipo_desconto = value;
                if (value.Trim().Equals("R$"))
                    tp_desconto = "V";
                else if (value.Trim().Equals("%"))
                    tp_desconto = "P";
            }
        }
        public decimal Nr_diasdesconto
        { get; set; }
        public decimal Pc_multa
        { get; set; }
        private string tp_multa;
        public string Tp_multa
        {
            get { return tp_multa; }
            set
            {
                tp_multa = value;
                if (value.Trim().ToUpper().Equals("V"))
                    tipo_multa = "R$";
                else if (value.Trim().ToUpper().Equals("P"))
                    tipo_multa = "%";
            }
        }
        private string tipo_multa;
        public string Tipo_multa
        {
            get { return tipo_multa; }
            set
            {
                tipo_multa = value;
                if (value.Trim().Equals("R$"))
                    tp_multa = "V";
                else if (value.Trim().Equals("%"))
                    tp_multa = "P";
            }
        }
        public decimal Nr_diasmulta
        { get; set; }
        public string Cd_historico_desconto
        { get; set; }
        public string Ds_historico_desconto
        { get; set; }
        public string Cd_historico_taxadesc
        { get; set; }
        public string Ds_historico_taxadesc
        { get; set; }
        public string Cd_historico_baixadesc
        { get; set; }
        public string Ds_historico_baixadesc
        { get; set; }
        public string Cd_historico_taxacob
        { get; set; }
        public string Ds_historico_taxacob
        { get; set; }
        public string Cd_centroresultTXCob
        { get; set; }
        public string Ds_centroresultTXCob
        { get; set; }
        private string tp_layoutbloqueto;
        public string Tp_layoutbloqueto
        {
            get { return tp_layoutbloqueto; }
            set
            {
                tp_layoutbloqueto = value;
                if (value.Trim().ToUpper().Equals("N"))
                    tipo_layoutbloqueto = "NORMAL";
                else if (value.Trim().ToUpper().Equals("C"))
                    tipo_layoutbloqueto = "CARNE";
            }
        }
        private string tipo_layoutbloqueto;
        public string Tipo_layoutbloqueto
        {
            get { return tipo_layoutbloqueto; }
            set
            {
                tipo_layoutbloqueto = value;
                if (value.Trim().ToUpper().Equals("NORMAL"))
                    tp_layoutbloqueto = "N";
                else if (value.Trim().ToUpper().Equals("CARNE"))
                    tp_layoutbloqueto = "C";
            }
        }
        public decimal Nr_diasprotesto
        { get; set; }
        private string st_protestoauto;
        public string St_protestoauto
        {
            get { return st_protestoauto; }
            set
            {
                st_protestoauto = value;
                st_protestoautobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_protestoautobool;
        public bool St_protestoautobool
        {
            get { return st_protestoautobool; }
            set
            {
                st_protestoautobool = value;
                st_protestoauto = value ? "S" : "N";
            }
        }
        public string ConvenioCobranca
        { get; set; }
        public string Cd_bancocorrespondente
        { get; set; }
        public string Ds_bancocorrespondente
        { get; set; }
        public string Nr_agenciacorrespondente
        { get; set; }
        public string Nr_contacorrespondente
        { get; set; }
        public string Carteiracorrespondente
        { get; set; }
        private string tp_layoutremessa;
        public string Tp_layoutremessa
        {
            get { return tp_layoutremessa; }
            set
            {
                tp_layoutremessa = value;
                if (value.Trim().ToUpper().Equals("2"))
                    tipo_layoutremessa = "LAYOUT CNAB 240";
                else if (value.Trim().ToUpper().Equals("4"))
                    tipo_layoutremessa = "LAYOUT CNAB 400";
            }
        }
        private string tipo_layoutremessa;
        public string Tipo_layoutremessa
        {
            get { return tipo_layoutremessa; }
            set
            {
                tipo_layoutremessa = value;
                if (value.Trim().ToUpper().Equals("LAYOUT CNAB 240"))
                    tp_layoutremessa = "2";
                else if (value.Trim().ToUpper().Equals("LAYOUT CNAB 400"))
                    tp_layoutremessa = "4";
            }
        }
        private string tp_layoutretorno;
        public string Tp_layoutretorno
        {
            get { return tp_layoutretorno; }
            set
            {
                tp_layoutretorno = value;
                if (value.Trim().ToUpper().Equals("2"))
                    tipo_layoutretorno = "LAYOUT CNAB 240";
                else if (value.Trim().ToUpper().Equals("4"))
                    tipo_layoutretorno = "LAYOUT CNAB 400";
            }
        }
        private string tipo_layoutretorno;
        public string Tipo_layoutretorno
        {
            get { return tipo_layoutretorno; }
            set
            {
                tipo_layoutretorno = value;
                if (value.Trim().ToUpper().Equals("LAYOUT CNAB 240"))
                    tp_layoutretorno = "2";
                else if (value.Trim().ToUpper().Equals("LAYOUT CNAB 400"))
                    tp_layoutretorno = "4";
            }
        }
        public decimal Vl_taxa
        { get; set; }
        public string St_registro
        { get; set; }
        public string Status
        {
            get
            {
                if (St_registro.Trim().ToUpper().Equals("A"))
                    return "ABERTO";
                else if (St_registro.Trim().ToUpper().Equals("C"))
                    return "CANCELADO";
                else return string.Empty;
            }
        }

        public TRegistro_CadCFGBanco()
        {
            id_config = null;
            id_configstr = string.Empty;
            Ds_config = string.Empty;
            Banco = new TRegistro_CadBanco();
            Empresa = new TRegistro_CadEmpresa();
            Cd_portador = string.Empty;
            Ds_portador = string.Empty;
            Codigocedente = string.Empty;
            Digitocedente = string.Empty;
            Ano = string.Empty;
            Nossonumero = decimal.Zero;
            Ds_localpagamento = string.Empty;
            Postocedente = string.Empty;
            aceite = string.Empty;
            aceite_sn = string.Empty;
            especiedocumento = null;
            especiedocumentostring = string.Empty;
            Ds_instrucoes = string.Empty;
            logo_banco = null;
            img = null;
            tp_cobranca = string.Empty;
            tipo_cobranca = string.Empty;
            Tp_carteira = string.Empty;
            Modalidade = string.Empty;
            Pc_jurodia = decimal.Zero;
            tp_jurodia = string.Empty;
            tipo_jurodia = string.Empty;
            Pc_desconto = decimal.Zero;
            tp_desconto = string.Empty;
            tipo_desconto = string.Empty;
            Nr_diasdesconto = decimal.Zero;
            Pc_multa = decimal.Zero;
            tp_multa = string.Empty;
            tipo_multa = string.Empty;
            Nr_diasmulta = decimal.Zero;
            Cd_contager = string.Empty;
            Ds_contager = string.Empty;
            Cd_historico_desconto = string.Empty;
            Ds_historico_desconto = string.Empty;
            Cd_historico_taxadesc = string.Empty;
            Ds_historico_taxadesc = string.Empty;
            Cd_historico_baixadesc = string.Empty;
            Ds_historico_baixadesc = string.Empty;
            Cd_historico_taxacob = string.Empty;
            Ds_historico_taxacob = string.Empty;
            Cd_centroresultTXCob = string.Empty;
            Ds_centroresultTXCob = string.Empty;
            tp_layoutbloqueto = string.Empty;
            tipo_layoutbloqueto = string.Empty;
            Nr_diasdesconto = decimal.Zero;
            tp_layoutretorno = string.Empty;
            tipo_layoutretorno = string.Empty;
            tp_layoutremessa = string.Empty;
            tipo_layoutremessa = string.Empty;
            st_protestoauto = "N";
            st_protestoautobool = false;
            ConvenioCobranca = string.Empty;
            Cd_bancocorrespondente = string.Empty;
            Ds_bancocorrespondente = string.Empty;
            Nr_agenciacorrespondente = string.Empty;
            Nr_contacorrespondente = string.Empty;
            Carteiracorrespondente = string.Empty;
            Vl_taxa = decimal.Zero;
            St_registro = "A";
        }
    }

    public class TCD_CadCFGBanco : TDataQuery
    {
        public TCD_CadCFGBanco()
        { }

        public TCD_CadCFGBanco(BancoDados.TObjetoBanco banco)
        {
            Banco_Dados = banco;
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.id_config, a.ds_config, ");
                sql.AppendLine("a.digitocedente, a.ano, a.nossonumero, a.ds_localpagamento, a.tp_carteira, ");
                sql.AppendLine("a.postocedente, a.aceite_sn, a.especiedocumento, a.DS_instrucoes, ");
                sql.AppendLine("a.codigocedente, a.logo_banco, a.tp_cobranca, a.cd_portador, d.ds_portador, ");
                sql.AppendLine("a.pc_jurodia, a.modalidade, a.st_registro,  a.tp_layoutbloqueto, ");
                sql.AppendLine("a.pc_desconto, a.nr_diasdesconto, a.pc_multa, a.nr_diasmulta, a.nr_diasprotesto, ");
                sql.AppendLine("a.tp_layoutremessa, a.tp_layoutretorno, a.st_protestoauto, ");
                sql.AppendLine("a.conveniocobranca, a.nr_agenciacorrespondente, ");
                sql.AppendLine("a.nr_contacorrespondente, a.carteiracorrespondente, ");
                sql.AppendLine("a.cd_bancocorrespondente, banco.ds_banco as ds_bancocorrespondente, ");
                sql.AppendLine("a.tp_jurodia, a.tp_desconto, a.tp_multa, a.vl_taxa, ");
                //Dados da Conta
                sql.AppendLine("a.cd_contager, e.ds_contager, e.nr_contacorrente, e.digitoconta, ");
                //Dados do banco
                sql.AppendLine("b.cd_banco, b.ds_banco, ");
                //Dados da empresa
                sql.AppendLine("c.cd_empresa, c.nm_empresa, ");
                //Dados Historico Desconto Duplicata
                sql.AppendLine("a.cd_historico_desconto, hdesc.ds_historico as ds_historico_desconto, ");
                //Dados Historico Taxa Desconto Duplicta
                sql.AppendLine("a.cd_historico_taxadesc, htaxa.ds_historico as ds_historico_taxadesc, ");
                //Dados Historico Baixa Desconto Duplicata
                sql.AppendLine("a.cd_historico_baixadesc, hbaixa.ds_historico as ds_historico_baixadesc, ");
                //Dados Historico Taxa Cobranca
                sql.AppendLine("a.cd_historico_taxacob, htaxacob.ds_historico as ds_historico_taxacob, ");
                //Centro Resultado Taxa Cobranca
                sql.AppendLine("a.cd_centroresultTXCob, crTx.ds_centroresultado as ds_centroresultTXCob ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_COB_CFGBanco a ");
            sql.AppendLine("inner join TB_FIN_Banco b ");
            sql.AppendLine("on a.cd_banco = b.cd_banco ");
            sql.AppendLine("inner join TB_DIV_Empresa c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("inner join TB_FIN_Portador d ");
            sql.AppendLine("on a.cd_portador = d.cd_portador ");
            sql.AppendLine("inner join tb_fin_contager e ");
            sql.AppendLine("on a.cd_contager = e.cd_contager ");
            sql.AppendLine("left outer join tb_fin_historico hdesc ");
            sql.AppendLine("on a.cd_historico_desconto = hdesc.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico htaxa ");
            sql.AppendLine("on a.cd_historico_taxadesc = htaxa.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico hbaixa ");
            sql.AppendLine("on a.cd_historico_baixadesc = hbaixa.cd_historico ");
            sql.AppendLine("left outer join tb_fin_historico htaxacob ");
            sql.AppendLine("on a.cd_historico_taxacob = htaxacob.cd_historico ");
            sql.AppendLine("left outer join tb_fin_banco banco ");
            sql.AppendLine("on a.cd_bancocorrespondente = banco.cd_banco");
            sql.AppendLine("left outer join TB_FIN_CentroResultado crTx ");
            sql.AppendLine("on a.cd_centroresultTXCob = crTx.cd_centroresult ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public TList_CadCFGBanco Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadCFGBanco lista = new TList_CadCFGBanco();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadCFGBanco reg = new TRegistro_CadCFGBanco();
                    //Dados da config banco
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_config = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_config = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("codigocedente")))
                        reg.Codigocedente = reader.GetString(reader.GetOrdinal("codigocedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DigitoCedente"))))
                        reg.Digitocedente = reader.GetString(reader.GetOrdinal("DigitoCedente"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Ano"))))
                        reg.Ano = reader.GetString(reader.GetOrdinal("Ano"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NossoNumero"))))
                        reg.Nossonumero = reader.GetDecimal(reader.GetOrdinal("NossoNumero"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_LocalPagamento"))))
                        reg.Ds_localpagamento = reader.GetString(reader.GetOrdinal("DS_LocalPagamento"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PostoCedente"))))
                        reg.Postocedente = reader.GetString(reader.GetOrdinal("PostoCedente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Aceite_SN")))
                        reg.Aceite_sn = reader.GetString(reader.GetOrdinal("Aceite_SN"));
                    if (!reader.IsDBNull(reader.GetOrdinal("EspecieDocumento")))
                        reg.EspecieDocumento = reader.GetDecimal(reader.GetOrdinal("EspecieDocumento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Instrucoes"))) 
                    	reg.Ds_instrucoes = reader.GetString(reader.GetOrdinal("DS_Instrucoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("logo_banco")))
                        reg.Img = (byte[])reader.GetValue(reader.GetOrdinal("logo_banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_cobranca")))
                        reg.Tp_cobranca = reader.GetString(reader.GetOrdinal("tp_cobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_carteira")))
                        reg.Tp_carteira = reader.GetString(reader.GetOrdinal("tp_carteira"));
                    if (!reader.IsDBNull(reader.GetOrdinal("modalidade")))
                        reg.Modalidade = reader.GetString(reader.GetOrdinal("modalidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Portador")))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Portador")))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_JuroDia")))
                        reg.Pc_jurodia = reader.GetDecimal(reader.GetOrdinal("PC_JuroDia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_jurodia")))
                        reg.Tp_jurodia = reader.GetString(reader.GetOrdinal("tp_jurodia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Desconto")))
                        reg.Pc_desconto = reader.GetDecimal(reader.GetOrdinal("PC_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_desconto")))
                        reg.Tp_desconto = reader.GetString(reader.GetOrdinal("tp_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasDesconto")))
                        reg.Nr_diasdesconto = reader.GetDecimal(reader.GetOrdinal("NR_DiasDesconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Multa")))
                        reg.Pc_multa = reader.GetDecimal(reader.GetOrdinal("PC_Multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_multa")))
                        reg.Tp_multa = reader.GetString(reader.GetOrdinal("tp_multa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasMulta")))
                        reg.Nr_diasmulta = reader.GetDecimal(reader.GetOrdinal("NR_DiasMulta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_Contager")))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Contager")))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_Contager"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contacorrente")))
                        reg.Nr_contacorrente = reader.GetString(reader.GetOrdinal("nr_contacorrente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("digitoconta")))
                        reg.Digitoconta = reader.GetString(reader.GetOrdinal("digitoconta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_LayoutBloqueto")))
                        reg.Tp_layoutbloqueto = reader.GetString(reader.GetOrdinal("TP_LayoutBloqueto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DiasProtesto")))
                        reg.Nr_diasprotesto = reader.GetDecimal(reader.GetOrdinal("NR_DiasProtesto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_LayoutRemessa")))
                        reg.Tp_layoutremessa = reader.GetString(reader.GetOrdinal("TP_LayoutRemessa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_LayoutRetorno")))
                        reg.Tp_layoutretorno = reader.GetString(reader.GetOrdinal("TP_LayoutRetorno"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_protestoauto")))
                        reg.St_protestoauto = reader.GetString(reader.GetOrdinal("st_protestoauto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("conveniocobranca")))
                        reg.ConvenioCobranca = reader.GetString(reader.GetOrdinal("conveniocobranca"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_bancocorrespondente")))
                        reg.Cd_bancocorrespondente = reader.GetString(reader.GetOrdinal("cd_bancocorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_bancocorrespondente")))
                        reg.Ds_bancocorrespondente = reader.GetString(reader.GetOrdinal("ds_bancocorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_agenciacorrespondente")))
                        reg.Nr_agenciacorrespondente = reader.GetString(reader.GetOrdinal("nr_agenciacorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contacorrespondente")))
                        reg.Nr_contacorrespondente = reader.GetString(reader.GetOrdinal("nr_contacorrespondente"));
                    if (!reader.IsDBNull(reader.GetOrdinal("carteiracorrespondente")))
                        reg.Carteiracorrespondente = reader.GetString(reader.GetOrdinal("carteiracorrespondente"));
                    //Dados do banco
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Banco"))))
                        reg.Banco.Cd_banco = reader.GetString(reader.GetOrdinal("CD_Banco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Banco")))
                        reg.Banco.Ds_banco = reader.GetString(reader.GetOrdinal("DS_Banco"));
                    //Dados da empresa
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Empresa.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Empresa.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    //Dados Historico Desconto
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_Desconto")))
                        reg.Cd_historico_desconto = reader.GetString(reader.GetOrdinal("CD_Historico_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_Desconto")))
                        reg.Ds_historico_desconto = reader.GetString(reader.GetOrdinal("DS_Historico_Desconto"));
                    //Dados Historico Taxa Desconto
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_TaxaDesc")))
                        reg.Cd_historico_taxadesc = reader.GetString(reader.GetOrdinal("CD_Historico_TaxaDesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_TaxaDesc")))
                        reg.Ds_historico_taxadesc = reader.GetString(reader.GetOrdinal("DS_Historico_TaxaDesc"));
                    //Dados Historico Baixa Desconto
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_BaixaDesc")))
                        reg.Cd_historico_baixadesc = reader.GetString(reader.GetOrdinal("CD_Historico_BaixaDesc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_BaixaDesc")))
                        reg.Ds_historico_baixadesc = reader.GetString(reader.GetOrdinal("DS_Historico_BaixaDesc"));
                    //Dados Historico Taxa Cobranca
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_TaxaCob")))
                        reg.Cd_historico_taxacob = reader.GetString(reader.GetOrdinal("CD_Historico_TaxaCob"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_TaxaCob")))
                        reg.Ds_historico_taxacob = reader.GetString(reader.GetOrdinal("DS_Historico_TaxaCob"));
                    //Centro Resultado Taxa Cobranca
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresultTXCob")))
                        reg.Cd_centroresultTXCob = reader.GetString(reader.GetOrdinal("cd_centroresultTXCob"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultTXCob")))
                        reg.Ds_centroresultTXCob = reader.GetString(reader.GetOrdinal("ds_centroresultTXCob"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_taxa")))
                        reg.Vl_taxa = reader.GetDecimal(reader.GetOrdinal("vl_taxa"));

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

        public string Gravar(TRegistro_CadCFGBanco val)
        {
            Hashtable hs = new Hashtable(44);
            hs.Add("@P_ID_CONFIG", val.Id_config);
            hs.Add("@P_DS_CONFIG", val.Ds_config);
            hs.Add("@P_CD_BANCO", val.Banco.Cd_banco);
            hs.Add("@P_CD_EMPRESA", val.Empresa.Cd_empresa);
            hs.Add("@P_CODIGOCEDENTE", val.Codigocedente);
            hs.Add("@P_DIGITOCEDENTE", val.Digitocedente);
            hs.Add("@P_ANO", val.Ano);
            hs.Add("@P_NOSSONUMERO", val.Nossonumero);
            hs.Add("@P_DS_LOCALPAGAMENTO", val.Ds_localpagamento);
            hs.Add("@P_POSTOCEDENTE", val.Postocedente);
            hs.Add("@P_ACEITE_SN", val.Aceite_sn);
            hs.Add("@P_ESPECIEDOCUMENTO", val.EspecieDocumento);
            hs.Add("@P_DS_INSTRUCOES", val.Ds_instrucoes);
            hs.Add("@P_LOGO_BANCO", val.Img);
            hs.Add("@P_TP_COBRANCA", val.Tp_cobranca);
            hs.Add("@P_TP_CARTEIRA", val.Tp_carteira);
            hs.Add("@P_MODALIDADE", val.Modalidade);
            hs.Add("@P_CD_PORTADOR", val.Cd_portador);
            hs.Add("@P_PC_JURODIA", val.Pc_jurodia);
            hs.Add("@P_TP_JURODIA", val.Tp_jurodia);
            hs.Add("@P_PC_DESCONTO", val.Pc_desconto);
            hs.Add("@P_TP_DESCONTO", val.Tp_desconto);
            hs.Add("@P_NR_DIASDESCONTO", val.Nr_diasdesconto);
            hs.Add("@P_PC_MULTA", val.Pc_multa);
            hs.Add("@P_TP_MULTA", val.Tp_multa);
            hs.Add("@P_NR_DIASMULTA", val.Nr_diasmulta);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);
            hs.Add("@P_CD_HISTORICO_DESCONTO", val.Cd_historico_desconto);
            hs.Add("@P_CD_HISTORICO_TAXADESC", val.Cd_historico_taxadesc);
            hs.Add("@P_CD_HISTORICO_BAIXADESC", val.Cd_historico_baixadesc);
            hs.Add("@P_CD_HISTORICO_TAXACOB", val.Cd_historico_taxacob);
            hs.Add("@P_CD_CENTRORESULTTXCOB", val.Cd_centroresultTXCob);
            hs.Add("@P_TP_LAYOUTBLOQUETO", val.Tp_layoutbloqueto);
            hs.Add("@P_NR_DIASPROTESTO", val.Nr_diasprotesto);
            hs.Add("@P_TP_LAYOUTREMESSA", val.Tp_layoutremessa);
            hs.Add("@P_TP_LAYOUTRETORNO", val.Tp_layoutretorno);
            hs.Add("@P_ST_PROTESTOAUTO", val.St_protestoauto);
            hs.Add("@P_CONVENIOCOBRANCA", val.ConvenioCobranca);
            hs.Add("@P_CD_BANCOCORRESPONDENTE", val.Cd_bancocorrespondente);
            hs.Add("@P_NR_AGENCIACORRESPONDENTE", val.Nr_agenciacorrespondente);
            hs.Add("@P_NR_CONTACORRESPONDENTE", val.Nr_contacorrespondente);
            hs.Add("@P_CARTEIRACORRESPONDENTE", val.Carteiracorrespondente);
            hs.Add("@P_VL_TAXA", val.Vl_taxa);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return executarProc("IA_COB_CFGBANCO", hs);
        }

        public string Excluir(TRegistro_CadCFGBanco val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_ID_CONFIG", val.Id_config);

            return executarProc("EXCLUI_COB_CFGBANCO", hs);
        }
    }
}
