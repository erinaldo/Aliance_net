using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace CamadaDados.Fiscal.GIA_ICMS
{
    public class TList_GIAICMS : List<TRegistro_GIAICMS>
    { }

    
    public class TRegistro_GIAICMS
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Insc_estadual
        { get; set; }
        
        public DateTime Dt_referencia
        { get; set; }
        public string Mes_referencia
        { get { return Dt_referencia.ToString("dd/MM/yyyy").Substring(3, 2); } }
        public string Ano_referencia
        { get { return Dt_referencia.ToString("dd/MM/yyyy").Substring(6, 4); } }
        
        public string Tp_gia
        { get; set; }
        public string Tipo_gia
        {
            get{
                if(Tp_gia.Trim().Equals("43"))
                    return "NORMAL";
                else if(Tp_gia.Trim().Equals("51"))
                    return "RETIFICAÇÃO";
                else return string.Empty;
            }
        }
        
        public string Crc_contador
        { get; set; }
        
        public decimal Vl_despesas
        { get; set; }
        
        public decimal Vl_produtosprimarios
        { get; set; }
        
        public decimal Vl_servicos
        { get; set; }
        
        public decimal Vl_estoque
        { get; set; }
        
        public decimal Qtd_funcionario
        { get; set; }
        
        public decimal Vl_folhapgto
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public string Numero
        { get; set; }
        
        public string Bairro
        { get; set; }
        
        public string Cep
        { get; set; }
        
        public string Ds_cidade
        { get; set; }
        
        public string UF
        { get; set; }
        public decimal Campo10
        {
            get { return Vl_despesas + Vl_produtosprimarios + Vl_servicos; }
        }   
        
        public decimal Campo11
        { get; set; }
        
        public decimal Campo13
        { get; set; }
              
        public decimal Campo14
        { get; set; }
        
        public decimal Campo15
        { get; set; }
        
        public decimal Campo16
        { get; set; }
        
        public decimal Campo17
        { get; set; }
        
        public decimal Campo18
        { get; set; }
        
        public decimal Campo19
        { get; set; }
        public decimal Campo20
        {
            get { return Campo11 + Campo13 + Campo14 + Campo15 + Campo16 + Campo17 + Campo18 + Campo19; } 
        }
        
        public decimal Campo21
        { get; set; }
        
        public decimal Campo23
        { get; set; }
        
        public decimal Campo24
        { get; set; }
        
        public decimal Campo25
        { get; set; }
        
        public decimal Campo26
        { get; set; }
        
        public decimal Campo27
        { get; set; }
        
        public decimal Campo28
        { get; set; }
        
        public decimal Campo29
        { get; set; }
        public decimal Campo30
        {
            get { return Campo21 + Campo23 + Campo24 + Campo25 + Campo26 + Campo27 + Campo28 + Campo29; } 
        }
        
        public decimal Campo31
        { get; set; }
        
        public decimal Campo33
        { get; set; }
        
        public decimal Campo34
        { get; set; }
        
        public decimal Campo35
        { get; set; }
        
        public decimal Campo36
        { get; set; }
        
        public decimal Campo39
        { get; set; }
        public decimal Campo40
        {
            get { return Campo31 + Campo33 + Campo34 + Campo35 + Campo36 + Campo39; } 
        }
        
        public decimal Campo41
        { get; set; }
        
        public decimal Campo43
        { get; set; }
        
        public decimal Campo44
        { get; set; }
        
        public decimal Campo45
        { get; set; }
        
        public decimal Campo46
        { get; set; }
        
        public decimal Campo49
        { get; set; }
        public decimal Campo50
        {
            get { return Campo41 + Campo43 + Campo44 + Campo45 + Campo46 + Campo49; } 
        }
        
        public decimal Campo51
        { get; set; }
        
        public decimal Campo52
        { get; set; }
        
        public decimal Campo53
        { get; set; }
        
        public decimal Campo54
        { get; set; }
        
        public decimal Campo55
        { get; set; }
        
        public decimal Campo56
        { get; set; }
        
        public decimal Campo58
        { get; set; }
        
        public decimal Campo59
        { get; set; }
        public decimal Campo60
        {
            get { return Campo51 + Campo52 + Campo53 + Campo54 + Campo55 + Campo56 + Campo58 + Campo59; } 
        }
        
        public decimal Campo61
        { get; set; }
        
        public decimal Campo62
        { get; set; }
        
        public decimal Campo63
        { get; set; }
        
        public decimal Campo64
        { get; set; }
        
        public decimal Campo65
        { get; set; }
        
        public decimal Campo66
        { get; set; }
        
        public decimal Campo67
        { get; set; }
        
        public decimal Campo68
        { get; set; }
        
        public decimal Campo69
        { get; set; }
        public decimal Campo70
        {
            get { return Campo61 + Campo62 + Campo63 + Campo64 + Campo65 + Campo66 + Campo67 + Campo68 + Campo69; } 
        }
        public decimal Campo80
        {
            get { return (Campo70 - Campo60) >  0 ? Math.Abs(Campo70 - Campo60 ) : decimal.Zero;}
        }
        public decimal Campo90
        {
            get { return (Campo60 - Campo70) > 0 ? Math.Abs(Campo60 - Campo70) : decimal.Zero; }
        }

        public TRegistro_GIAICMS()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Tp_gia = "43";
            this.Crc_contador = string.Empty;
            this.Vl_despesas = decimal.Zero;
            this.Vl_produtosprimarios = decimal.Zero;
            this.Vl_servicos = decimal.Zero;
            this.Vl_estoque = decimal.Zero;
            this.Qtd_funcionario = decimal.Zero;
            this.Vl_folhapgto = decimal.Zero;
            this.Ds_endereco = string.Empty;
            this.Ds_cidade = string.Empty;
            this.Numero = string.Empty;
            this.Bairro = string.Empty;
            this.Cep = string.Empty;
            this.UF = string.Empty;
            this.Campo11 = decimal.Zero;
            this.Campo13 = decimal.Zero;
            this.Campo14 = decimal.Zero;
            this.Campo15 = decimal.Zero;
            this.Campo16 = decimal.Zero;
            this.Campo17 = decimal.Zero;
            this.Campo18 = decimal.Zero;
            this.Campo19 = decimal.Zero;
            this.Campo21 = decimal.Zero;
            this.Campo23 = decimal.Zero;
            this.Campo24 = decimal.Zero;
            this.Campo25 = decimal.Zero;
            this.Campo26 = decimal.Zero;
            this.Campo27 = decimal.Zero;
            this.Campo28 = decimal.Zero;
            this.Campo29 = decimal.Zero;
            this.Campo31 = decimal.Zero;
            this.Campo33 = decimal.Zero;
            this.Campo34 = decimal.Zero;
            this.Campo35 = decimal.Zero;
            this.Campo36 = decimal.Zero;
            this.Campo39 = decimal.Zero;
            this.Campo41 = decimal.Zero;
            this.Campo43 = decimal.Zero;
            this.Campo44 = decimal.Zero;
            this.Campo45 = decimal.Zero;
            this.Campo46 = decimal.Zero;
            this.Campo49 = decimal.Zero;
            this.Campo51 = decimal.Zero;
            this.Campo52 = decimal.Zero;
            this.Campo53 = decimal.Zero;
            this.Campo54 = decimal.Zero;
            this.Campo55 = decimal.Zero;
            this.Campo56 = decimal.Zero;
            this.Campo58 = decimal.Zero;
            this.Campo59 = decimal.Zero;
            this.Campo61 = decimal.Zero;
            this.Campo62 = decimal.Zero;
            this.Campo63 = decimal.Zero;
            this.Campo64 = decimal.Zero;
            this.Campo65 = decimal.Zero;
            this.Campo66 = decimal.Zero;
            this.Campo67 = decimal.Zero;
            this.Campo68 = decimal.Zero;
            this.Campo69 = decimal.Zero;
        }
    }

    public class TCD_GIA_ICMS : TDataQuery
    {
        public TCD_GIA_ICMS()
        { }

        public TCD_GIA_ICMS(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        public TList_GIAICMS Select(string Cd_empresa,
                                    string Dt_ini,
                                    string Dt_fin)
        {
            TList_GIAICMS lista = new TList_GIAICMS();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Collections.Hashtable hs = new System.Collections.Hashtable(3);
            hs.Add("@P_CD_EMPRESA", Cd_empresa);
            hs.Add("@P_DT_INI", Dt_ini);
            hs.Add("@P_DT_FIN", Dt_fin);
            System.Data.SqlClient.SqlDataReader reader = this.executarProcReader("SQL_FIS_GIAICMS", hs);
            try
            {
                while (reader.Read())
                {
                    TRegistro_GIAICMS reg = new TRegistro_GIAICMS();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("insc_estadual"))))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("crc_contador"))))
                        reg.Crc_contador = reader.GetString(reader.GetOrdinal("crc_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_despesas")))
                        reg.Vl_despesas = reader.GetDecimal(reader.GetOrdinal("vl_despesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_produtosprimarios")))
                        reg.Vl_produtosprimarios = reader.GetDecimal(reader.GetOrdinal("vl_produtosprimarios"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_servicos")))
                        reg.Vl_servicos = reader.GetDecimal(reader.GetOrdinal("vl_servicos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_estoque")))
                        reg.Vl_estoque = reader.GetDecimal(reader.GetOrdinal("vl_estoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_funcionarios")))
                        reg.Qtd_funcionario = reader.GetInt32(reader.GetOrdinal("nr_funcionarios"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_folhapgto")))
                        reg.Vl_folhapgto = reader.GetDecimal(reader.GetOrdinal("vl_folhapgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_endereco"))))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("numero"))))
                        reg.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("UF"))))
                        reg.UF = reader.GetString(reader.GetOrdinal("UF"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cep"))))
                        reg.Cep= reader.GetString(reader.GetOrdinal("Cep"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("bairro"))))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo11")))
                        reg.Campo11 = reader.GetDecimal(reader.GetOrdinal("campo11"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo13")))
                        reg.Campo13 = reader.GetDecimal(reader.GetOrdinal("campo13"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo14")))
                        reg.Campo14 = reader.GetDecimal(reader.GetOrdinal("campo14"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo15")))
                        reg.Campo15 = reader.GetDecimal(reader.GetOrdinal("campo15"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo16")))
                        reg.Campo16 = reader.GetDecimal(reader.GetOrdinal("campo16"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo17")))
                        reg.Campo17 = reader.GetDecimal(reader.GetOrdinal("campo17"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo18")))
                        reg.Campo18 = reader.GetDecimal(reader.GetOrdinal("campo18"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo19")))
                        reg.Campo19 = reader.GetDecimal(reader.GetOrdinal("campo19"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo21")))
                        reg.Campo21 = reader.GetDecimal(reader.GetOrdinal("campo21"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo23")))
                        reg.Campo23 = reader.GetDecimal(reader.GetOrdinal("campo23"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo24")))
                        reg.Campo24 = reader.GetDecimal(reader.GetOrdinal("campo24"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo25")))
                        reg.Campo25 = reader.GetDecimal(reader.GetOrdinal("campo25"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo26")))
                        reg.Campo26 = reader.GetDecimal(reader.GetOrdinal("campo26"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo27")))
                        reg.Campo27 = reader.GetDecimal(reader.GetOrdinal("campo27"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo28")))
                        reg.Campo28 = reader.GetDecimal(reader.GetOrdinal("campo28"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo29")))
                        reg.Campo29 = reader.GetDecimal(reader.GetOrdinal("campo29"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo31")))
                        reg.Campo31 = reader.GetDecimal(reader.GetOrdinal("campo31"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo33")))
                        reg.Campo33 = reader.GetDecimal(reader.GetOrdinal("campo33"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo34")))
                        reg.Campo34 = reader.GetDecimal(reader.GetOrdinal("campo34"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo35")))
                        reg.Campo35 = reader.GetDecimal(reader.GetOrdinal("campo35"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo36")))
                        reg.Campo36 = reader.GetDecimal(reader.GetOrdinal("campo36"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo39")))
                        reg.Campo39 = reader.GetDecimal(reader.GetOrdinal("campo39"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo41")))
                        reg.Campo41 = reader.GetDecimal(reader.GetOrdinal("campo41"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo43")))
                        reg.Campo43 = reader.GetDecimal(reader.GetOrdinal("campo43"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo44")))
                        reg.Campo44 = reader.GetDecimal(reader.GetOrdinal("campo44"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo45")))
                        reg.Campo45 = reader.GetDecimal(reader.GetOrdinal("campo45"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo46")))
                        reg.Campo46 = reader.GetDecimal(reader.GetOrdinal("campo46"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo49")))
                        reg.Campo49 = reader.GetDecimal(reader.GetOrdinal("campo49"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo51")))
                        reg.Campo51 = reader.GetDecimal(reader.GetOrdinal("campo51"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo52")))
                        reg.Campo52 = reader.GetDecimal(reader.GetOrdinal("campo52"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo53")))
                        reg.Campo53 = reader.GetDecimal(reader.GetOrdinal("campo53"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo54")))
                        reg.Campo54 = reader.GetDecimal(reader.GetOrdinal("campo54"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo55")))
                        reg.Campo55 = reader.GetDecimal(reader.GetOrdinal("campo55"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo56")))
                        reg.Campo56 = reader.GetDecimal(reader.GetOrdinal("campo56"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo58")))
                        reg.Campo58 = reader.GetDecimal(reader.GetOrdinal("campo58"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo59")))
                        reg.Campo59 = reader.GetDecimal(reader.GetOrdinal("campo59"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo61")))
                        reg.Campo61 = reader.GetDecimal(reader.GetOrdinal("campo61"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo62")))
                        reg.Campo62 = reader.GetDecimal(reader.GetOrdinal("campo62"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo63")))
                        reg.Campo63 = reader.GetDecimal(reader.GetOrdinal("campo63"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo64")))
                        reg.Campo64 = reader.GetDecimal(reader.GetOrdinal("campo64"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo65")))
                        reg.Campo65 = reader.GetDecimal(reader.GetOrdinal("campo65"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo66")))
                        reg.Campo66 = reader.GetDecimal(reader.GetOrdinal("campo66"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo67")))
                        reg.Campo67 = reader.GetDecimal(reader.GetOrdinal("campo67"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo68")))
                        reg.Campo68 = reader.GetDecimal(reader.GetOrdinal("campo68"));
                    if (!reader.IsDBNull(reader.GetOrdinal("campo69")))
                        reg.Campo69 = reader.GetDecimal(reader.GetOrdinal("campo69"));
                    
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
}
