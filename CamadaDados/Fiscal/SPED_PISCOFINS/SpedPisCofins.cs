using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Fiscal.SPED_PISCOFINS
{
    #region Registro Arquivo
    public class TList_RegArquivo : List<TRegistro_RegArquivo>
    {
        public void Adiciona(TRegistro_RegArquivo reg)
        {
            if (Exists(p => p.Registro.Trim().ToUpper().Equals(reg.Registro.Trim().ToUpper())))
                Find(p => p.Registro.Trim().ToUpper().Equals(reg.Registro.Trim().ToUpper())).Qtd_linha += reg.Qtd_linha;
            else
                Add(reg);
        }
    }

    public class TRegistro_RegArquivo
    {
        public string Registro
        { get; set; }
        public decimal Qtd_linha
        { get; set; }
    }
    #endregion

    #region Dados Empresa
    
    public class TRegistro_DadosEmpresa
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nr_cnpj
        { get; set; }
        
        public string Uf
        { get; set; }
        
        public string Cd_cidade
        { get; set; }
        
        public string Tp_naturezaPJ
        { get; set; }
        
        public string Tp_atividadespedpiscofins
        { get; set; }
        
        public string Tp_incidtributaria
        { get; set; }
        
        public string Tp_apropcredito
        { get; set; }
        
        public string Tp_contribuicao
        { get; set; }
        
        public string Tp_regimecumulativo
        { get; set; }
        
        public string Insc_estadual
        { get; set; }
        
        public string Insc_municipal
        { get; set; }
        
        public string Cd_clifor_contador
        { get; set; }
        
        public string Crc_contador
        { get; set; }
        
        public string Cnpj_escritorio_contabil
        { get; set; }
        
        public string Cd_modelo_ecf
        { get; set; }
        
        public string LayoutSpedPisCofins
        { get; set; }

        public TRegistro_DadosEmpresa()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Nr_cnpj = string.Empty;
            Uf = string.Empty;
            Cd_cidade = string.Empty;
            Tp_naturezaPJ = string.Empty;
            Tp_atividadespedpiscofins = string.Empty;
            Tp_incidtributaria = string.Empty;
            Tp_apropcredito = string.Empty;
            Tp_contribuicao = string.Empty;
            Tp_regimecumulativo = string.Empty;
            Insc_estadual = string.Empty;
            Insc_municipal = string.Empty;
            Cd_clifor_contador = string.Empty;
            Crc_contador = string.Empty;
            Cnpj_escritorio_contabil = string.Empty;
            Cd_modelo_ecf = string.Empty;
            LayoutSpedPisCofins = string.Empty;
        }
    }

    public class TCD_DadosEmpresa : TDataQuery
    {
        public TCD_DadosEmpresa()
        { }

        public TCD_DadosEmpresa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, a.NM_Empresa, b.NR_CGC, a.crc_contador, ");
            sql.AppendLine("c.UF, c.CD_Cidade, c.Insc_Estadual, a.Insc_Municipal, a.layoutspedpiscofins, ");
            sql.AppendLine("a.tp_naturezaPJ, a.TP_ATIVIDADESPEDPISCOFINS, a.tp_incidtributaria, ");
            sql.AppendLine("a.TP_APROPCREDITO, a.TP_CONTRIBUICAO, a.TP_REGIMECUMULATIVO, ");
            sql.AppendLine("a.CD_Clifor_Contador, d.NR_CGC as Cnpj_escritorio_contabil, ");
            sql.AppendLine("cd_modelo_ecf = (select top 1 x.cd_modelo ");
            sql.AppendLine("                    from tb_pdv_cfgcupomfiscal x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa)");

            sql.AppendLine("from TB_DIV_Empresa a ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = c.CD_Endereco ");
            sql.AppendLine("left outer join VTB_FIN_Clifor d ");
            sql.AppendLine("on a.cd_escritorio_contabil = d.cd_clifor ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<TRegistro_DadosEmpresa> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DadosEmpresa> lista = new List<TRegistro_DadosEmpresa>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DadosEmpresa reg = new TRegistro_DadosEmpresa();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Nr_cnpj = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("uf")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_municipal")))
                        reg.Insc_municipal = reader.GetString(reader.GetOrdinal("insc_municipal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_naturezaPJ")))
                        reg.Tp_naturezaPJ = reader.GetString(reader.GetOrdinal("tp_naturezaPJ"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_ATIVIDADESPEDPISCOFINS")))
                        reg.Tp_atividadespedpiscofins = reader.GetString(reader.GetOrdinal("TP_ATIVIDADESPEDPISCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_incidtributaria")))
                        reg.Tp_incidtributaria = reader.GetString(reader.GetOrdinal("tp_incidtributaria"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_APROPCREDITO")))
                        reg.Tp_apropcredito = reader.GetString(reader.GetOrdinal("TP_APROPCREDITO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_CONTRIBUICAO")))
                        reg.Tp_contribuicao = reader.GetString(reader.GetOrdinal("TP_CONTRIBUICAO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_REGIMECUMULATIVO")))
                        reg.Tp_regimecumulativo = reader.GetString(reader.GetOrdinal("TP_REGIMECUMULATIVO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_clifor_contador")))
                        reg.Cd_clifor_contador = reader.GetString(reader.GetOrdinal("cd_clifor_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("crc_contador")))
                        reg.Crc_contador = reader.GetString(reader.GetOrdinal("crc_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cnpj_escritorio_contabil")))
                        reg.Cnpj_escritorio_contabil = reader.GetString(reader.GetOrdinal("Cnpj_escritorio_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo_ecf")))
                        reg.Cd_modelo_ecf = reader.GetString(reader.GetOrdinal("cd_modelo_ecf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("layoutspedpiscofins")))
                        reg.LayoutSpedPisCofins = reader.GetString(reader.GetOrdinal("layoutspedpiscofins"));
                    
                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Participantes
    
    public class TRegistro_Participante
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Cd_pais
        { get; set; }
        public string Cnpj
        { get; set; }
        public string Cpf
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Insc_estadual
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Numero
        { get; set; }
        public string Complemento
        { get; set; }
        public string Bairro
        { get; set; }

        public TRegistro_Participante()
        {
            Cd_clifor = string.Empty;
            Nm_clifor = string.Empty;
            Cd_pais = string.Empty;
            Cnpj = string.Empty;
            Cpf = string.Empty;
            Cd_endereco = string.Empty;
            Insc_estadual = string.Empty;
            Cd_cidade = string.Empty;
            Ds_endereco = string.Empty;
            Numero = string.Empty;
            Complemento = string.Empty;
            Bairro = string.Empty;
        }
    }

    public class TCD_Participamente : TDataQuery
    {
        public TCD_Participamente()
        { }

        public TCD_Participamente(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct CD_Clifor, NM_Clifor, ");
            sql.AppendLine("NR_CGC, NR_CPF, Cd_endereco, Insc_Estadual, ");
            sql.AppendLine("CD_Cidade, DS_Endereco, Numero, ");
            sql.AppendLine("DS_Complemento, Bairro, CD_PAIS ");

            sql.AppendLine("from VTB_FIS_ParticipamenteSPED ");

            sql.AppendLine("where isnull(ST_GerarSpedPisCofins, 'N') = 'S'");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public List<TRegistro_Participante> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_Participante> lista = new List<TRegistro_Participante>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Participante reg = new TRegistro_Participante();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Cnpj = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cpf")))
                        reg.Cpf = reader.GetString(reader.GetOrdinal("nr_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        reg.Complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_pais")))
                        reg.Cd_pais = reader.GetString(reader.GetOrdinal("cd_pais"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Plano Contas
    public class TRegistro_PlanoContas
    {
        public DateTime? Dt_alt { get; set; } = DateTime.Now;
        public string Tp_contasped { get; set; } = string.Empty;
        public string Tp_conta { get; set; } = string.Empty;
        public decimal Nivelconta { get; set; } = decimal.Zero;
        public decimal Cd_conta_CTB { get; set; } = decimal.Zero;
        public string Ds_contaCTB { get; set; } = string.Empty;
        public string Cd_referencia { get; set; } = string.Empty;
    }
    public class TCD_PlanoContas:TDataQuery
    {
        public TCD_PlanoContas() { }
        public TCD_PlanoContas(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }
        public List<TRegistro_PlanoContas> Select(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct a.dt_alt, a.tp_contasped, a.TP_Conta, a.NivelConta, a.CD_Conta_CTB, a.DS_ContaCTB, a.Cd_referencia ");
            sql.AppendLine("from VTB_FIS_CONTACTBSPED a ");
            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.data))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'");
            sql.AppendLine("and isnull(a.ST_GerarSpedPisCofins, 'N') = 'S' ");

            List<TRegistro_PlanoContas> lista = new List<TRegistro_PlanoContas>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(sql.ToString());
            try
            {
                while (reader.Read())
                {
                    TRegistro_PlanoContas reg = new TRegistro_PlanoContas();
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_alt")))
                        reg.Dt_alt = reader.GetDateTime(reader.GetOrdinal("dt_alt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_contasped")))
                        reg.Tp_contasped = reader.GetString(reader.GetOrdinal("tp_contasped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Conta")))
                        reg.Tp_conta = reader.GetString(reader.GetOrdinal("TP_Conta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NivelConta")))
                        reg.Nivelconta = reader.GetDecimal(reader.GetOrdinal("NivelConta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Conta_CTB")))
                        reg.Cd_conta_CTB = reader.GetDecimal(reader.GetOrdinal("CD_Conta_CTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaCTB")))
                        reg.Ds_contaCTB = reader.GetString(reader.GetOrdinal("DS_ContaCTB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Referencia")))
                        reg.Cd_referencia = reader.GetString(reader.GetOrdinal("CD_Referencia"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Unidades
    public class TRegistro_Unidade
    {
        public string Cd_unidade
        { get; set; }
        public string Ds_unidade
        { get; set; }

        public TRegistro_Unidade()
        {
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
        }
    }

    public class TCD_Unidade : TDataQuery
    {
        public TCD_Unidade()
        { }

        public TCD_Unidade(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    DateTime? Dt_ini,
                                    DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct c.CD_Unidade, d.DS_Unidade ");
            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on d.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("where a.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");

            sql.AppendLine("union ");

            sql.AppendLine("select distinct c.CD_Unidade, d.DS_Unidade ");
            sql.AppendLine("from TB_PDV_NFCe a ");
            sql.AppendLine("inner join TB_PDV_NFCe_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.id_nfce = b.id_nfce ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on d.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");

            return sql.ToString();
        }

        public List<TRegistro_Unidade> Select(string Cd_empresa,
                                              DateTime? Dt_ini,
                                              DateTime? Dt_fin)
        {
            List<TRegistro_Unidade> lista = new List<TRegistro_Unidade>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Unidade reg = new TRegistro_Unidade();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_unidade")))
                        reg.Ds_unidade = reader.GetString(reader.GetOrdinal("ds_unidade"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Itens da Nota
    public class TRegistro_ItensNota
    {
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public string Codigobarra
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Tp_item
        { get; set; }
        public string Ncm
        { get; set; }
        public decimal? Id_genero
        { get; set; }
        public string Id_tpservico
        { get; set; }

        public TRegistro_ItensNota()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Codigobarra = string.Empty;
            Cd_unidade = string.Empty;
            Tp_item = string.Empty;
            Ncm = string.Empty;
            Id_genero = null;
            Id_tpservico = string.Empty;
        }
    }

    public class TCD_ItensNota : TDataQuery
    {
        public TCD_ItensNota()
        { }

        public TCD_ItensNota(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    DateTime? Dt_ini,
                                    DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.CD_Produto, c.DS_Produto, ");
            sql.AppendLine("c.CD_Unidade, c.TP_Item, c.NCM, c.ID_Genero, ");
            sql.AppendLine("c.TP_Produto, c.ID_TPServico, ");
            sql.AppendLine("cd_codbarra = (select top 1 x.CD_CodBarra ");
            sql.AppendLine("				from TB_EST_CodBarra x ");
            sql.AppendLine("				where x.CD_Produto = c.CD_Produto ");
            sql.AppendLine("            	order by x.DT_Cad asc) ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on d.CD_Unidade = c.CD_Unidade ");
            sql.AppendLine("where a.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22') ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end)))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            
            sql.AppendLine("union ");

            sql.AppendLine("select b.CD_Produto, c.DS_Produto, ");
            sql.AppendLine("c.CD_Unidade, c.TP_Item, c.NCM, c.ID_Genero, ");
            sql.AppendLine("c.TP_Produto, c.ID_TPServico, ");
            sql.AppendLine("cd_codbarra = (select top 1 x.CD_CodBarra ");
            sql.AppendLine("				from TB_EST_CodBarra x ");
            sql.AppendLine("				where x.CD_Produto = c.CD_Produto ");
            sql.AppendLine("            	order by x.DT_Cad asc) ");
            sql.AppendLine("from TB_PDV_NFCe a ");
            sql.AppendLine("inner join TB_PDV_NFCe_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Id_NFCe = b.Id_NFCe ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on c.CD_Unidade = d.CD_Unidade ");
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and a.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), a.DT_Emissao))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");

            return sql.ToString();
        }

        public List<TRegistro_ItensNota> Select(string Cd_empresa,
                                                DateTime? Dt_ini,
                                                DateTime? Dt_fin)
        {
            List<TRegistro_ItensNota> lista = new List<TRegistro_ItensNota>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ItensNota reg = new TRegistro_ItensNota();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_item")))
                        reg.Tp_item = reader.GetString(reader.GetOrdinal("tp_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_genero")))
                        reg.Id_genero = reader.GetDecimal(reader.GetOrdinal("id_genero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpservico")))
                        reg.Id_tpservico = reader.GetString(reader.GetOrdinal("id_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CodBarra")))
                        reg.Codigobarra = reader.GetString(reader.GetOrdinal("CD_CodBarra"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Movimentacao Comercial
    
    public class TRegistro_MovComercial
    {
        
        public decimal? Cd_movimentacao
        { get; set; }
        
        public string Ds_movimentacao
        { get; set; }

        public TRegistro_MovComercial()
        {
            Cd_movimentacao = null;
            Ds_movimentacao = string.Empty;
        }
    }

    public class TCD_MovComercial : TDataQuery
    {
        public TCD_MovComercial()
        { }

        public TCD_MovComercial(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct b.cd_movimentacao, b.ds_movimentacao ");

            sql.AppendLine("from TB_FAT_NotaFiscal_Item a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal c ");
            sql.AppendLine("on a.cd_empresa = c.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = c.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao b ");
            sql.AppendLine("on c.cd_movimentacao = b.cd_movimentacao ");

            sql.AppendLine("where c.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public List<TRegistro_MovComercial> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_MovComercial> lista = new List<TRegistro_MovComercial>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovComercial reg = new TRegistro_MovComercial();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("cd_movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_movimentacao")))
                        reg.Ds_movimentacao = reader.GetString(reader.GetOrdinal("ds_movimentacao"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Dados Adicionais
    
    public class TRegistro_DadosAdicionais
    {
        
        public string Cd_dadosadicionais
        { get; set; }
        
        public string Ds_dadosadicionais
        { get; set; }

        public TRegistro_DadosAdicionais()
        {
            Cd_dadosadicionais = string.Empty;
            Ds_dadosadicionais = string.Empty;
        }
    }

    public class TCD_DadosAdicionais : TDataQuery
    {
        public TCD_DadosAdicionais()
        { }

        public TCD_DadosAdicionais(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct case when LEN(a.Nr_LanctoFiscal) > 6 then SUBSTRING(CONVERT(varchar(15), Nr_LanctoFiscal), 1, 6) else a.nr_lanctofiscal end as cd_dadosadicionais, ");
            sql.AppendLine("DadosAdicionais = ISNULL(DadosAdicionais, '') + dbo.F_FAT_DADOSADICIONAIS(a.cd_empresa, a.nr_lanctofiscal) ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join TB_FIS_Movimentacao b ");
            sql.AppendLine("on a.cd_movimentacao = b.cd_movimentacao ");
            sql.AppendLine("and isnull(b.st_gerarspedpiscofins, 'N') = 'S' ");

            sql.AppendLine("where ISNULL(DadosAdicionais, '') + dbo.F_FAT_DADOSADICIONAIS(a.cd_empresa, a.nr_lanctofiscal) <> '' ");
            sql.AppendLine("and a.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')");
            //Nao informar se for NFe emissao Propria
            sql.AppendLine("and ((a.cd_modelo <> '55') or (a.tp_nota = 'T')) ");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public List<TRegistro_DadosAdicionais> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DadosAdicionais> lista = new List<TRegistro_DadosAdicionais>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DadosAdicionais reg = new TRegistro_DadosAdicionais();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_dadosadicionais")))
                        reg.Cd_dadosadicionais = reader.GetDecimal(reader.GetOrdinal("cd_dadosadicionais")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("DadosAdicionais")))
                        reg.Ds_dadosadicionais = reader.GetString(reader.GetOrdinal("DadosAdicionais"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Cupom Fiscal Eletronico
    public class TRegistro_NFCe
    {
        public decimal? Id_cupom
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string St_registro
        { get; set; }
        public string Nr_serie
        { get; set; }
        public decimal? Id_coo_ecf
        { get; set; }
        public string Chave_acesso
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public decimal Vl_itens
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_outrasdesp
        { get; set; }
        public decimal Vl_cupom
        { get; set; }
        public decimal Vl_basecalcicms
        { get; set; }
        public decimal Vl_icms
        { get; set; }
        public decimal Vl_pis
        { get; set; }
        public decimal Vl_cofins
        { get; set; }

        public TRegistro_NFCe()
        {
            Id_cupom = null;
            Cd_modelo = string.Empty;
            St_registro = string.Empty;
            Nr_serie = string.Empty;
            Id_coo_ecf = null;
            Chave_acesso = string.Empty;
            Dt_emissao = null;
            Vl_itens = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_basecalcicms = decimal.Zero;
            Vl_icms = decimal.Zero;
            Vl_pis = decimal.Zero;
            Vl_cofins = decimal.Zero;
        }
    }

    public class TCD_NFCe : TDataQuery
    {
        public TCD_NFCe() { }

        public TCD_NFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(string Cd_empresa, DateTime Dt_ini, DateTime Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.id_nfce, a.CD_Modelo, a.ST_Registro, a.Nr_Serie, ");
            sql.AppendLine("a.nr_nfce, a.Chave_Acesso, a.DT_Emissao, ");
            sql.AppendLine("Vl_Itens = isnull((select sum(isnull(x.vl_subtotal, 0)) ");
            sql.AppendLine("                    from TB_PDV_nfce_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_Desc = isnull((select sum(isnull(x.vl_desconto, 0)) ");
            sql.AppendLine("                    from TB_PDV_nfce_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_OutrasDesp = isnull((select sum(ISNULL(x.vl_juro_fin, 0) + ISNULL(x.vl_acrescimo, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_cupom = isnull((select sum(isnull(x.vl_subtotal, 0) + ISNULL(x.vl_juro_fin, 0) + ISNULL(x.vl_frete, 0) + ISNULL(x.vl_acrescimo, 0) - isnull(x.vl_desconto, 0)) ");
            sql.AppendLine("                    from TB_PDV_nfce_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_BaseICMS = isnull((select sum(isnull(x.Vl_BaseCalcICMS, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_ICMS = isnull((select sum(isnull(x.Vl_ICMS, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa  ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_PIS = isnull((select sum(isnull(x.Vl_Pis, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_COFINS = isnull((select sum(isnull(x.vl_cofins, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0) ");

            sql.AppendLine("from TB_PDV_NFCe a ");

            sql.AppendLine("where a.CD_Modelo = '65' ");
            sql.AppendLine("and a.CD_Empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.DT_Emissao))) between '" + Dt_ini.ToString("yyyyMMdd") + "' and '" + Dt_fin.ToString("yyyyMMdd") + "'");
            sql.AppendLine("and exists(select 1 from TB_FAT_Lote_X_NFCe x ");
            sql.AppendLine("            where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("            and x.id_cupom = a.id_nfce ");
            sql.AppendLine("            and x.status in('100', '150'))");

            return sql.ToString();
        }

        public List<TRegistro_NFCe> Select(string Cd_empresa, DateTime Dt_ini, DateTime Dt_fin)
        {
            List<TRegistro_NFCe> lista = new List<TRegistro_NFCe>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFCe reg = new TRegistro_NFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_nfce")))
                        reg.Id_cupom = reader.GetDecimal(reader.GetOrdinal("id_nfce"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("nr_serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NFCe")))
                        reg.Id_coo_ecf = reader.GetDecimal(reader.GetOrdinal("NR_NFCe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso")))
                        reg.Chave_acesso = reader.GetString(reader.GetOrdinal("Chave_Acesso"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Itens")))
                        reg.Vl_itens = reader.GetDecimal(reader.GetOrdinal("Vl_Itens"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desc")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_OutrasDesp")))
                        reg.Vl_outrasdesp = reader.GetDecimal(reader.GetOrdinal("Vl_OutrasDesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_cupom")))
                        reg.Vl_cupom = reader.GetDecimal(reader.GetOrdinal("Vl_cupom"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseICMS")))
                        reg.Vl_basecalcicms = reader.GetDecimal(reader.GetOrdinal("Vl_BaseICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pis")))
                        reg.Vl_pis = reader.GetDecimal(reader.GetOrdinal("vl_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cofins")))
                        reg.Vl_cofins = reader.GetDecimal(reader.GetOrdinal("vl_cofins"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Consolidacao NFC-e
    public class TRegistro_DetNFCe
    {
        public string Cd_cfop
        { get; set; }
        public decimal Vl_operacao
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public string Cd_st_pis
        { get; set; }
        public decimal Vl_basecalc_pis
        { get; set; }
        public decimal Pc_aliquota_pis
        { get; set; }
        public decimal Vl_pis
        { get; set; }
        public string Cd_st_cofins
        { get; set; }
        public decimal Vl_basecalc_cofins
        { get; set; }
        public decimal Pc_aliquota_cofins
        { get; set; }
        public decimal Vl_cofins
        { get; set; }
        public decimal? Cd_contactb_sped
        { get; set; }

        public TRegistro_DetNFCe()
        {
            Cd_cfop = string.Empty;
            Vl_operacao = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Cd_st_pis = string.Empty;
            Vl_basecalc_pis = decimal.Zero;
            Pc_aliquota_pis = decimal.Zero;
            Vl_pis = decimal.Zero;
            Cd_st_cofins = string.Empty;
            Vl_basecalc_cofins = decimal.Zero;
            Pc_aliquota_cofins = decimal.Zero;
            Vl_cofins = decimal.Zero;
            Cd_contactb_sped = null;
        }
    }

    public class TCD_DetNFCe : TDataQuery
    {
        public TCD_DetNFCe() { }

        public TCD_DetNFCe(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        public string SqlCodeBusca(string Cd_empresa, string Id_cupom)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_cfop, a.cd_st_pis as Cd_stPIS, a.Cd_st_cofins as Cd_stCofins, ");
            sql.AppendLine("a.Pc_aliquotapis as Pc_aliquota_pis, a.Pc_aliquotacofins as Pc_aliquota_cofins, a.Cd_contactb_sped, ");
            sql.AppendLine("vl_operacao = isnull(sum(isnull(a.vl_contabil, 0)), 0), ");
            sql.AppendLine("vl_desconto = isnull(sum(isnull(a.vl_desconto, 0)), 0), ");
            sql.AppendLine("vl_basecalc_pis = isnull(sum(isnull(a.vl_basecalcPIS, 0)), 0), ");
            sql.AppendLine("vl_pis = isnull(sum(isnull(a.vl_pis, 0)), 0), ");
            sql.AppendLine("vl_basecalc_cofins = isnull(sum(isnull(a.vl_basecalcCofins, 0)), 0), ");
            sql.AppendLine("vl_cofins = isnull(sum(isnull(a.vl_cofins, 0)), 0)");

            sql.AppendLine("from VTB_FIS_NFCEITEM a ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.ID_NFCE = " + Id_cupom);

            sql.AppendLine("group by a.CD_CFOP, a.cd_st_pis, a.Cd_st_cofins, ");
            sql.AppendLine("a.Pc_aliquotapis, a.Pc_aliquotacofins, a.Cd_contactb_sped ");

            return sql.ToString();
        }

        public List<TRegistro_DetNFCe> Select(string Cd_empresa, string Id_cupom)
        {
            List<TRegistro_DetNFCe> lista = new List<TRegistro_DetNFCe>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Id_cupom));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetNFCe reg = new TRegistro_DetNFCe();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_stPIS")))
                        reg.Cd_st_pis = reader.GetString(reader.GetOrdinal("Cd_stPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_stCofins")))
                        reg.Cd_st_cofins = reader.GetString(reader.GetOrdinal("Cd_stCofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquota_pis")))
                        reg.Pc_aliquota_pis = reader.GetDecimal(reader.GetOrdinal("Pc_aliquota_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquota_cofins")))
                        reg.Pc_aliquota_cofins = reader.GetDecimal(reader.GetOrdinal("Pc_aliquota_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_operacao")))
                        reg.Vl_operacao = reader.GetDecimal(reader.GetOrdinal("vl_operacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalc_pis")))
                        reg.Vl_basecalc_pis = reader.GetDecimal(reader.GetOrdinal("vl_basecalc_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_pis")))
                        reg.Vl_pis = reader.GetDecimal(reader.GetOrdinal("vl_pis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_basecalc_cofins")))
                        reg.Vl_basecalc_cofins = reader.GetDecimal(reader.GetOrdinal("vl_basecalc_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_cofins")))
                        reg.Vl_cofins = reader.GetDecimal(reader.GetOrdinal("vl_cofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Consolidacao Vendas PIS

    public class TRegistro_ConsVendaPIS
    {
        
        public string Cd_produto
        { get; set; }
        
        public string Ncm
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }

        public TRegistro_ConsVendaPIS()
        {
            Cd_produto = string.Empty;
            Ncm = string.Empty;
            Vl_subtotal = decimal.Zero;
        }
    }

    public class TCD_ConsVendaPIS : TDataQuery
    {
        public TCD_ConsVendaPIS()
        { }

        public TCD_ConsVendaPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.CD_Produto, c.NCM, ");
            sql.AppendLine("Vl_subtotal = ISNULL(SUM(ISNULL(b.Vl_SubTotal, 0) - ISNULL(b.vl_desconto, 0)), 0) ");

            sql.AppendLine("from VTB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_movimentacao = d.cd_movimentacao ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by b.CD_Produto, c.NCM ");

            return sql.ToString();
        }

        public List<TRegistro_ConsVendaPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ConsVendaPIS> lista = new List<TRegistro_ConsVendaPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsVendaPIS reg = new TRegistro_ConsVendaPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Consolidacao Vendas COFINS
    
    public class TRegistro_ConsVendaCOFINS
    {
        
        public string Cd_produto
        { get; set; }
        
        public string Ncm
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }

        public TRegistro_ConsVendaCOFINS()
        {
            Cd_produto = string.Empty;
            Ncm = string.Empty;
            Vl_subtotal = decimal.Zero;
        }
    }

    public class TCD_ConsVendaCOFINS : TDataQuery
    {
        public TCD_ConsVendaCOFINS()
        { }

        public TCD_ConsVendaCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.CD_Produto, c.NCM, ");
            sql.AppendLine("Vl_subtotal = ISNULL(SUM(ISNULL(b.Vl_SubTotal, 0) - ISNULL(b.vl_desconto, 0)), 0) ");

            sql.AppendLine("from VTB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_movimentacao = d.cd_movimentacao ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by b.CD_Produto, c.NCM ");

            return sql.ToString();
        }

        public List<TRegistro_ConsVendaCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ConsVendaCOFINS> lista = new List<TRegistro_ConsVendaCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ConsVendaCOFINS reg = new TRegistro_ConsVendaCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ncm")))
                        reg.Ncm = reader.GetString(reader.GetOrdinal("ncm"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_subtotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_subtotal"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Vendas PIS
    
    public class TRegistro_DetVendaPIS
    {
        
        public string Cd_st
        { get; set; }
        
        public string Cd_cfop
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }
        
        public decimal Vl_desconto
        { get; set; }
        
        public decimal Vl_basecalc
        { get; set; }
        
        public decimal Pc_aliquota
        { get; set; }
        
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetVendaPIS()
        {
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Vl_subtotal = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetVendaPIS : TDataQuery
    {
        public TCD_DetVendaPIS()
        { }

        public TCD_DetVendaPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.Cd_St_PIS as Cd_StPis, b.CD_CFOP, b.Pc_aliquotaPIS, f.CD_Conta_CTB as Cd_contactb_sped, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Contabil, 0)), 0) as Vl_SubTotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Desconto, 0)), 0) as Vl_Desconto, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcPIS, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_pis, 0)), 0) as Vl_PIS ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.cd_movimentacao ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB f ");
            sql.AppendLine("on b.Id_LoteCTB_Fat = f.Id_LoteCTB ");
            sql.AppendLine("and f.D_C = case when a.Tp_Movimento = 'E' then 'D' else 'C' end ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by b.Cd_St_pis, b.CD_CFOP, b.Pc_aliquotaPIS, a.Tp_Movimento, f.CD_Conta_CTB ");
            return sql.ToString();
        }

        public List<TRegistro_DetVendaPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DetVendaPIS> lista = new List<TRegistro_DetVendaPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetVendaPIS reg = new TRegistro_DetVendaPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_stpis")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("cd_stpis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_PIS")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Vendas COFINS
    
    public class TRegistro_DetVendaCOFINS
    {
        
        public string Cd_st
        { get; set; }
        
        public string Cd_cfop
        { get; set; }
        
        public decimal Vl_subtotal
        { get; set; }
        
        public decimal Vl_desconto
        { get; set; }
        
        public decimal Vl_basecalc
        { get; set; }
        
        public decimal Pc_aliquota
        { get; set; }
        
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetVendaCOFINS()
        {
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Vl_subtotal = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetVendaCOFINS : TDataQuery
    {
        public TCD_DetVendaCOFINS()
        { }

        public TCD_DetVendaCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.Cd_St_Cofins as Cd_StCOFINS, b.CD_CFOP, b.Pc_aliquotaCOFINS, f.CD_Conta_CTB as Cd_contactb_sped, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Contabil, 0)), 0) as Vl_SubTotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Desconto, 0)), 0) as Vl_Desconto, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcCofins, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Cofins, 0)), 0) as Vl_Imposto ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.cd_movimentacao ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB f ");
            sql.AppendLine("on b.Id_LoteCTB_Fat = f.Id_LoteCTB ");
            sql.AppendLine("and f.D_C = case when a.Tp_Movimento = 'E' then 'D' else 'C' end ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by b.Cd_St_cofins, b.CD_CFOP, b.Pc_aliquotaCofins, a.Tp_Movimento, f.CD_Conta_CTB ");
            return sql.ToString();

        }

        public List<TRegistro_DetVendaCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DetVendaCOFINS> lista = new List<TRegistro_DetVendaCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetVendaCOFINS reg = new TRegistro_DetVendaCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StCOFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_imposto")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Compras PIS
    
    public class TRegistro_DetCompraPIS
    {
        public string Cnpj_cpf
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetCompraPIS()
        {
            Cnpj_cpf = string.Empty;
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Vl_subtotal = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetCompraPIS : TDataQuery
    {
        public TCD_DetCompraPIS()
        { }

        public TCD_DetCompraPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select case when isnull(c.nr_cgc, '') = '' then c.nr_cpf else c.nr_cgc end as cnpj_cpf, ");
            sql.AppendLine("b.Cd_St_pis as Cd_StPIS, b.CD_CFOP, b.Pc_aliquotaPIS, g.CD_Conta_CTB as Cd_contactb_sped, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Contabil, 0)), 0) as Vl_SubTotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Desconto, 0)), 0) as Vl_Desconto, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcPIS, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_pis, 0)), 0) as Vl_PIS ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_movimentacao = d.cd_movimentacao ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB g ");
            sql.AppendLine("on b.Id_LoteCTB_Fat = g.Id_LoteCTB ");
            sql.AppendLine("and g.D_C = case when a.Tp_Movimento = 'E' then 'D' else 'C' end ");
                        
            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by c.nr_cgc, c.nr_cpf, b.Cd_St_pis, b.CD_CFOP, b.Pc_aliquotaPIS, a.Tp_Movimento, g.CD_Conta_CTB ");
            return sql.ToString();
        }

        public List<TRegistro_DetCompraPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DetCompraPIS> lista = new List<TRegistro_DetCompraPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetCompraPIS reg = new TRegistro_DetCompraPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("cnpj_cpf")))
                        reg.Cnpj_cpf = reader.GetString(reader.GetOrdinal("cnpj_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_stpis")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("cd_stpis"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_PIS")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Compras COFINS
    
    public class TRegistro_DetCompraCOFINS
    {
        public string Cnpj_cpf
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetCompraCOFINS()
        {
            Cnpj_cpf = string.Empty;
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Vl_subtotal = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetCompraCOFINS : TDataQuery
    {
        public TCD_DetCompraCOFINS()
        { }

        public TCD_DetCompraCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select case when isnull(c.nr_cgc, '') = '' then c.nr_cpf else c.nr_cgc end as Cnpj_cpf, ");
            sql.AppendLine("b.Cd_St_cofins as Cd_StCOFINS, b.CD_CFOP, b.Pc_aliquotaCOFINS, g.CD_Conta_CTB as Cd_contactb_sped, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Contabil, 0)), 0) as Vl_SubTotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Desconto, 0)), 0) as Vl_Desconto, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcCofins, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_cofins, 0)), 0) as Vl_Imposto ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_clifor = c.cd_clifor ");
            sql.AppendLine("inner join TB_FIS_Movimentacao d ");
            sql.AppendLine("on a.cd_movimentacao = d.cd_movimentacao ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB g ");
            sql.AppendLine("on b.Id_LoteCTB_Fat = g.Id_LoteCTB ");
            sql.AppendLine("and g.D_C = case when a.Tp_Movimento = 'E' then 'D' else 'C' end ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by c.nr_cgc, c.nr_cpf, b.Cd_St_cofins, b.CD_CFOP, b.Pc_aliquotaCofins, a.Tp_Movimento, g.CD_Conta_CTB ");
            return sql.ToString();
        }

        public List<TRegistro_DetCompraCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DetCompraCOFINS> lista = new List<TRegistro_DetCompraCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetCompraCOFINS reg = new TRegistro_DetCompraCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cnpj_cpf")))
                        reg.Cnpj_cpf = reader.GetString(reader.GetOrdinal("Cnpj_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StCOFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_imposto")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento ECF PIS
    
    public class TRegistro_DetECFPIS
    {
        public string Cd_produto
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_imposto
        { get; set; }

        public TRegistro_DetECFPIS()
        {
            Cd_produto = string.Empty;
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Vl_subtotal = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetECFPIS : TDataQuery
    {
        public TCD_DetECFPIS()
        { }

        public TCD_DetECFPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Produto, a.CD_CFOP, a.Cd_St_PIS as Cd_StPIS, a.PC_AliquotaPIS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_SubTotal, 0) + ISNULL(a.Vl_Acrescimo, 0) + ISNULL(a.vl_juro_fin, 0) + ISNULL(a.vl_frete, 0)  - ISNULL(a.Vl_Desconto, 0)), 0) as Vl_subtotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_BaseCalcPIS, 0)), 0) as Vl_basecalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_PIS, 0)), 0) as Vl_imposto ");

            sql.AppendLine("from TB_PDV_NFCe_Item a ");
            sql.AppendLine("inner join TB_PDV_NFCe b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("and a.id_nfce = b.id_nfce ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            sql.AppendLine("group by a.CD_Produto, a.CD_CFOP, a.Cd_St_PIS, a.PC_AliquotaPIS ");
            return sql.ToString();
        }

        public List<TRegistro_DetECFPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DetECFPIS> lista = new List<TRegistro_DetECFPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetECFPIS reg = new TRegistro_DetECFPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StPIS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_imposto")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_imposto"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento ECF COFINS
    
    public class TRegistro_DetECFCofins
    {
        public string Cd_produto
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_imposto
        { get; set; }

        public TRegistro_DetECFCofins()
        {
            Cd_produto = string.Empty;
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Vl_subtotal = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetECFCofins : TDataQuery
    {
        public TCD_DetECFCofins()
        { }

        public TCD_DetECFCofins(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Produto, a.CD_CFOP, a.Cd_St_Cofins as Cd_StCOFINS, a.Pc_aliquotaCOFINS, ");
            sql.AppendLine("ISNULL(SUM(isnull(a.Vl_SubTotal, 0) + ISNULL(a.Vl_Acrescimo, 0) + ISNULL(a.vl_juro_fin, 0) + isnull(a.vl_frete, 0)  - isnull(a.Vl_Desconto, 0)), 0) as Vl_subtotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_basecalcCofins, 0)), 0) as Vl_basecalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_Cofins, 0)), 0) as Vl_imposto ");

            sql.AppendLine("from TB_NFCe_Item a ");
            sql.AppendLine("inner join TB_PDV_NFCe b ");
            sql.AppendLine("on a.cd_empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Id_NFCe = b.Id_NFCe ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                }
            sql.AppendLine("group by a.CD_Produto, a.CD_CFOP, a.Cd_St_Cofins, a.Pc_aliquotaCofins ");
            return sql.ToString();
        }

        public List<TRegistro_DetECFCofins> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DetECFCofins> lista = new List<TRegistro_DetECFCofins>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetECFCofins reg = new TRegistro_DetECFCofins();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StCOFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_imposto")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_imposto"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Transporte PIS
    
    public class TRegistro_DetCTRPIS
    {
        public string Tp_movimento
        { get; set; }
        public string Tp_frete
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Id_basecreditoPIS
        { get; set; }
        public decimal Vl_item
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetCTRPIS()
        {
            Tp_movimento = string.Empty;
            Tp_frete = string.Empty;
            Cd_st = string.Empty;
            Id_basecreditoPIS = string.Empty;
            Vl_item = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetCTRPIS : TDataQuery
    {
        public TCD_DetCTRPIS()
        { }

        public TCD_DetCTRPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Nr_lancto,
                                    string Tp_registro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Tp_Movimento, a.FreteporConta as Tp_frete, ");
            sql.AppendLine("b.Cd_St_pis as Cd_StPIS, b.Id_basecreditoPIS, b.Pc_aliquotaPIS, ");
            sql.AppendLine("Vl_item = ISNULL(SUM(ISNULL(b.Vl_Contabil, 0)), 0), ");
            sql.AppendLine("Vl_basecalcPIS = ISNULL(SUM(ISNULL(b.Vl_basecalcPIS, 0)), 0), ");
            sql.AppendLine("Vl_PIS = ISNULL(SUM(ISNULL(b.Vl_PIS, 0)), 0), ");
            sql.AppendLine("f.CD_Conta_CTB as Cd_contactb_sped ");
            
            sql.AppendLine("from TB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB f ");
            sql.AppendLine("on b.Id_LoteCTB_Fat = f.Id_LoteCTB ");
            sql.AppendLine("and f.D_C = case when a.Tp_Movimento = 'E' then 'D' else 'C' end ");

            sql.AppendLine("where a.cd_empresa = '" + (Tp_registro.Trim().ToUpper().Equals("NFF") ? Cd_empresa.Trim() : string.Empty ) + "'");
            sql.AppendLine("and a.nr_lanctofiscal = " + (Tp_registro.Trim().ToUpper().Equals("NFF") ? Nr_lancto : "null"));

            sql.AppendLine("group by a.Tp_Movimento, a.FreteporConta, b.Cd_St_pis, b.Id_basecreditoPIS, b.Pc_aliquotaPIS, f.CD_Conta_CTB ");

            sql.AppendLine("union all ");

            sql.AppendLine("select a.tp_movimento, a.Tp_tomador as TP_Frete, ");
            sql.AppendLine("a.CD_StPIS, a.Id_BaseCreditoPIS , a.Pc_AliquotaPIS, ");
            sql.AppendLine("a.Vl_Frete as Vl_Item, ");
            sql.AppendLine("a.Vl_BaseCalcPIS, a.Vl_PIS, ");
            sql.AppendLine("Cd_contactb_sped = (select x.CD_Conta_CTB ");
            sql.AppendLine("					from TB_CTB_LanctosCTB x ");
            sql.AppendLine("					where x.Id_LoteCTB = a.id_lotectb ");
            sql.AppendLine("					and x.d_c = case when a.tp_movimento = 'E' then 'D' else 'C' end) ");

            sql.AppendLine("from VTB_CTR_CONHECIMENTOFRETE a ");

            sql.AppendLine("where a.cd_empresa = '" + (Tp_registro.Trim().ToUpper().Equals("CTR") ? Cd_empresa.Trim() : string.Empty) + "'");
            sql.AppendLine("and a.nr_lanctoCTR = " + (Tp_registro.Trim().ToUpper().Equals("CTR") ? Nr_lancto : "null"));

            return sql.ToString();
        }

        public List<TRegistro_DetCTRPIS> Select(string Cd_empresa,
                                                string Nr_lancto,
                                                string Tp_registro)
        {
            List<TRegistro_DetCTRPIS> lista = new List<TRegistro_DetCTRPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Nr_lancto, Tp_registro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetCTRPIS reg = new TRegistro_DetCTRPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("tp_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StPIS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_BaseCreditoPIS")))
                        reg.Id_basecreditoPIS = reader.GetDecimal(reader.GetOrdinal("ID_BaseCreditoPIS")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_item")))
                        reg.Vl_item = reader.GetDecimal(reader.GetOrdinal("Vl_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcPIS")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_PIS")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Transporte COFINS
    
    public class TRegistro_DetCTRCofins
    {
        public string Tp_movimento
        { get; set; }
        public string Tp_frete
        { get; set; }
        public string Cd_st
        { get; set; }
        public string Id_basecreditoCOFINS
        { get; set; }
        public decimal Vl_item
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetCTRCofins()
        {
            Tp_movimento = string.Empty;
            Tp_frete = string.Empty;
            Cd_st = string.Empty;
            Id_basecreditoCOFINS = string.Empty;
            Vl_item = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Pc_aliquota = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetCTRCofins : TDataQuery
    {
        public TCD_DetCTRCofins()
        { }

        public TCD_DetCTRCofins(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Nr_lancto,
                                    string Tp_registro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Tp_Movimento, a.FreteporConta as Tp_frete, ");
            sql.AppendLine("b.Cd_St_cofins as Cd_StCOFINS, b.ID_BaseCreditoCOFINS, b.Pc_aliquotaCOFINS, ");
            sql.AppendLine("Vl_item = ISNULL(SUM(ISNULL(b.Vl_Contabil, 0)), 0), ");
            sql.AppendLine("Vl_basecalcCOFINS = ISNULL(SUM(ISNULL(b.Vl_basecalcCofins, 0)), 0), ");
            sql.AppendLine("Vl_COFINS = ISNULL(SUM(ISNULL(b.Vl_Cofins, 0)), 0), ");
            sql.AppendLine("f.CD_Conta_CTB as Cd_contactb_sped ");

            sql.AppendLine("from TB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB f ");
            sql.AppendLine("on b.Id_LoteCTB_Fat = f.Id_LoteCTB ");
            sql.AppendLine("and f.D_C = case when a.Tp_Movimento = 'E' then 'D' else 'C' end ");

            sql.AppendLine("where a.cd_empresa = '" + (Tp_registro.Trim().ToUpper().Equals("NFF") ? Cd_empresa.Trim() : string.Empty) + "'");
            sql.AppendLine("and a.nr_lanctofiscal = " + (Tp_registro.Trim().ToUpper().Equals("NFF") ? Nr_lancto : "null"));

            sql.AppendLine("group by a.Tp_Movimento, a.FreteporConta, b.Cd_St_cofins, b.ID_BaseCreditoCofins, b.Pc_aliquotaCofins, f.CD_Conta_CTB ");

            sql.AppendLine("union all ");

            sql.AppendLine("select a.tp_movimento, a.Tp_tomador as TP_Frete, ");
            sql.AppendLine("a.CD_StCOFINS, a.ID_BaseCreditoCOFINS, a.Pc_AliquotaCOFINS, ");
            sql.AppendLine("a.Vl_Frete as Vl_Item, ");
            sql.AppendLine("a.Vl_BaseCalcCOFINS, a.Vl_COFINS, ");
            sql.AppendLine("Cd_contactb_sped = (select x.CD_Conta_CTB ");
            sql.AppendLine("					from TB_CTB_LanctosCTB x ");
            sql.AppendLine("					where x.Id_LoteCTB = a.id_lotectb ");
            sql.AppendLine("					and x.d_c = case when a.tp_movimento = 'E' then 'D' else 'C' end) ");

            sql.AppendLine("from VTB_CTR_CONHECIMENTOFRETE a ");

            sql.AppendLine("where a.cd_empresa = '" + (Tp_registro.Trim().ToUpper().Equals("CTR") ? Cd_empresa.Trim() : string.Empty) + "'");
            sql.AppendLine("and a.nr_lanctoCTR = " + (Tp_registro.Trim().ToUpper().Equals("CTR") ? Nr_lancto : "null"));

            return sql.ToString();
        }

        public List<TRegistro_DetCTRCofins> Select(string Cd_empresa,
                                                string Nr_lancto,
                                                string Tp_registro)
        {
            List<TRegistro_DetCTRCofins> lista = new List<TRegistro_DetCTRCofins>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Nr_lancto, Tp_registro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetCTRCofins reg = new TRegistro_DetCTRCofins();
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_frete")))
                        reg.Tp_frete = reader.GetString(reader.GetOrdinal("tp_frete"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StCOFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_basecreditoCOFINS")))
                        reg.Id_basecreditoCOFINS = reader.GetDecimal(reader.GetOrdinal("id_basecreditoCOFINS")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_item")))
                        reg.Vl_item = reader.GetDecimal(reader.GetOrdinal("Vl_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcCOFINS")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_COFINS")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_COFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Comunicacao PIS
    
    public class TRegistro_DetComPIS
    {
        public string Cd_st
        { get; set; }
        public decimal? Tp_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_item
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetComPIS()
        {
            Cd_st = string.Empty;
            Tp_basecalc = null;
            Pc_aliquota = decimal.Zero;
            Vl_item = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetComPIS : TDataQuery
    {
        public TCD_DetComPIS()
        { }

        public TCD_DetComPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Nr_lancto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Cd_St_pis as Cd_StPIS, a.Id_basecreditoPIS, a.Pc_aliquotaPIS, ");
            sql.AppendLine("Vl_item = ISNULL(SUM(ISNULL(a.Vl_Contabil, 0)), 0), ");
            sql.AppendLine("Vl_basecalc = ISNULL(SUM(ISNULL(a.Vl_basecalcPIS, 0)), 0), ");
            sql.AppendLine("Vl_imposto = ISNULL(SUM(ISNULL(a.Vl_pis, 0)), 0), ");
            sql.AppendLine("f.CD_Conta_CTB as Cd_contactb_sped ");

            sql.AppendLine("from VTB_FAT_NOTAFISCAL_ITEM a ");
            sql.AppendLine("inner join tb_fat_notafiscal b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB f ");
            sql.AppendLine("on a.Id_LoteCTB_Fat = f.Id_LoteCTB ");
            sql.AppendLine("and f.D_C = case when b.Tp_Movimento = 'E' then 'D' else 'C' end ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.nr_lanctofiscal = " + Nr_lancto);

            sql.AppendLine("group by a.Cd_St_pis, a.Id_basecreditoPIS, a.Pc_aliquotaPIS, f.CD_Conta_CTB ");

            return sql.ToString();
        }

        public List<TRegistro_DetComPIS> Select(string Cd_empresa,
                                                string Nr_lancto)
        {
            List<TRegistro_DetComPIS> lista = new List<TRegistro_DetComPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Nr_lancto));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetComPIS reg = new TRegistro_DetComPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StPIS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_basecreditoPIS")))
                        reg.Tp_basecalc = reader.GetDecimal(reader.GetOrdinal("Id_basecreditoPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_item")))
                        reg.Vl_item = reader.GetDecimal(reader.GetOrdinal("Vl_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Imposto")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Comunicacao COFINS
    
    public class TRegistro_DetComCOFINS
    {
        public string Cd_st
        { get; set; }
        public decimal? Tp_basecalc
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_item
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_imposto
        { get; set; }
        public decimal? Cd_contactb_sped { get; set; } = null;

        public TRegistro_DetComCOFINS()
        {
            Cd_st = string.Empty;
            Tp_basecalc = null;
            Pc_aliquota = decimal.Zero;
            Vl_item = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_imposto = decimal.Zero;
        }
    }

    public class TCD_DetComCOFINS : TDataQuery
    {
        public TCD_DetComCOFINS()
        { }

        public TCD_DetComCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Nr_lancto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Cd_St_cofins as Cd_StCOFINS, a.Id_basecreditoCOFINS, a.Pc_aliquotaCOFINS, ");
            sql.AppendLine("Vl_item = ISNULL(SUM(ISNULL(a.Vl_Contabil, 0)), 0), ");
            sql.AppendLine("Vl_basecalc = ISNULL(SUM(ISNULL(a.Vl_basecalcCofins, 0)), 0), ");
            sql.AppendLine("Vl_imposto = ISNULL(SUM(ISNULL(a.Vl_Cofins, 0)), 0), ");
            sql.AppendLine("f.CD_Conta_CTB as Cd_contactb_sped ");

            sql.AppendLine("from VTB_FAT_NOTAFISCAL_ITEM a ");
            sql.AppendLine("inner join tb_fat_notafiscal b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("left outer join TB_CTB_LanctosCTB f ");
            sql.AppendLine("on a.Id_LoteCTB_Fat = f.Id_LoteCTB ");
            sql.AppendLine("and f.D_C = case when b.Tp_Movimento = 'E' then 'D' else 'C' end ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.nr_lanctofiscal = " + Nr_lancto);

            sql.AppendLine("group by a.Cd_St_cofins, a.Id_basecreditoCofins, a.Pc_aliquotaCofins, f.CD_Conta_CTB ");

            return sql.ToString();
        }

        public List<TRegistro_DetComCOFINS> Select(string Cd_empresa,
                                                string Nr_lancto)
        {
            List<TRegistro_DetComCOFINS> lista = new List<TRegistro_DetComCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Nr_lancto));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DetComCOFINS reg = new TRegistro_DetComCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StCOFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_basecreditoCOFINS")))
                        reg.Tp_basecalc = reader.GetDecimal(reader.GetOrdinal("Id_basecreditoCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_item")))
                        reg.Vl_item = reader.GetDecimal(reader.GetOrdinal("Vl_item"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Imposto")))
                        reg.Vl_imposto = reader.GetDecimal(reader.GetOrdinal("Vl_Imposto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Credito PIS
    
    public class TRegistro_CreditoPIS
    {
        public decimal? Tp_cred
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_PIS
        { get; set; }

        public TRegistro_CreditoPIS()
        {
            Tp_cred = null;
            Pc_aliquota = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_PIS = decimal.Zero;
        }
    }

    public class TCD_CreditoPIS : TDataQuery
    {
        public TCD_CreditoPIS()
        { }

        public TCD_CreditoPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.Id_TpCredPIS, b.Pc_aliquotaPIS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcPIS, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_PIS, 0)), 0) as Vl_PIS ");

            sql.AppendLine("from TB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_CFOP f ");
            sql.AppendLine("on b.cd_cfop = f.cd_cfop ");
            sql.AppendLine("and isnull(f.st_bonificacao, 'N') <> 'S' ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by b.Id_TpCredPIS, b.Pc_aliquotaPIS ");
            sql.AppendLine("order by b.Id_TpCredPIS ");

            return sql.ToString();
        }

        public List<TRegistro_CreditoPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_CreditoPIS> lista = new List<TRegistro_CreditoPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CreditoPIS reg = new TRegistro_CreditoPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_TpCredPIS")))
                        reg.Tp_cred = reader.GetDecimal(reader.GetOrdinal("Id_TpCredPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_PIS")))
                        reg.Vl_PIS = reader.GetDecimal(reader.GetOrdinal("Vl_PIS"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Base Credito PIS
    
    public class TRegistro_BaseCalcCred
    {
        public decimal? Id_basecredito
        { get; set; }
        public string Cd_st
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }

        public TRegistro_BaseCalcCred()
        {
            Id_basecredito = null;
            Cd_st = string.Empty;
            Vl_basecalc = decimal.Zero;
        }
    }

    public class TCD_BaseCalcCred : TDataQuery
    {
        public TCD_BaseCalcCred()
        { }

        public TCD_BaseCalcCred(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.Id_basecreditoPIS, b.cd_st_pis as Cd_StPIS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcPIS, 0)), 0) as Vl_BaseCalc ");

            sql.AppendLine("from TB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_CFOP d ");
            sql.AppendLine("on b.cd_cfop = d.cd_cfop ");
            sql.AppendLine("and isnull(d.st_bonificacao, 'N') <> 'S' ");

            sql.AppendLine("where a.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')");

            string cond = " and ";

            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");

            sql.AppendLine("group by b.Id_basecreditoPIS, b.Cd_St_pis ");

            return sql.ToString();
        }

        public List<TRegistro_BaseCalcCred> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_BaseCalcCred> lista = new List<TRegistro_BaseCalcCred>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_BaseCalcCred reg = new TRegistro_BaseCalcCred();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_basecreditoPIS")))
                        reg.Id_basecredito = reader.GetDecimal(reader.GetOrdinal("Id_basecreditoPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StPIS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento por codigo Receita PIS

    public class TRegistro_receitaPIS
    {
        public decimal? Id_receita
        { get; set; }
        public decimal Vl_debito
        { get; set; }

        public TRegistro_receitaPIS()
        {
            Id_receita = null;
            Vl_debito = decimal.Zero;
        }
    }

    public class TCD_ReceitaPIS : TDataQuery
    {
        public TCD_ReceitaPIS() { }

        public TCD_ReceitaPIS(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_ReceitaPIS, sum(isnull(a.vl_pis, 0)) as vl_debito ");

            sql.AppendLine("from VTB_FIS_REGM205 a ");

            string cond = " where ";

            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by a.ID_ReceitaPIS ");

            return sql.ToString();
        }

        public List<TRegistro_receitaPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_receitaPIS> lista = new List<TRegistro_receitaPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_receitaPIS reg = new TRegistro_receitaPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ReceitaPIS")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("ID_ReceitaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_debito")))
                        reg.Vl_debito = reader.GetDecimal(reader.GetOrdinal("vl_debito"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }

    #endregion

    #region Detalhamento Contribuicao PIS

    public class TRegistro_ContribuicaoPIS
    {
        public decimal? Id_tpcontribuicao
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_PIS
        { get; set; }

        public TRegistro_ContribuicaoPIS()
        {
            Id_tpcontribuicao = null;
            Pc_aliquota = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_PIS = decimal.Zero;
        }
    }

    public class TCD_ContribuicaoPIS : TDataQuery
    {
        public TCD_ContribuicaoPIS()
        { }

        public TCD_ContribuicaoPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_TPCONTRIBUICAOPIS, a.PC_ALIQUOTAPIS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_SubTotal, 0)), 0) as Vl_SubTotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_BaseCalc, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_PIS, 0)), 0) as Vl_PIS ");

            sql.AppendLine("from VTB_FIS_REGM210 a ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by a.ID_TPCONTRIBUICAOPIS, a.PC_ALIQUOTAPIS ");

            return sql.ToString();
        }

        public List<TRegistro_ContribuicaoPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ContribuicaoPIS> lista = new List<TRegistro_ContribuicaoPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ContribuicaoPIS reg = new TRegistro_ContribuicaoPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_TPCONTRIBUICAOPIS")))
                        reg.Id_tpcontribuicao = reader.GetDecimal(reader.GetOrdinal("ID_TPCONTRIBUICAOPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_ALIQUOTAPIS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("PC_ALIQUOTAPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_PIS")))
                        reg.Vl_PIS = reader.GetDecimal(reader.GetOrdinal("Vl_PIS"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Receitas Isentas PIS
    
    public class TRegistro_ReceitasIsentasPIS
    {
        public string Cd_st
        { get; set; }
        public decimal? Id_detrecIsenta
        { get; set; }
        public decimal Vl_Receita
        { get; set; }
        public decimal? Cd_conta_ctb
        { get; set; }

        public TRegistro_ReceitasIsentasPIS()
        {
            Cd_st = string.Empty;
            Id_detrecIsenta = null;
            Vl_Receita = decimal.Zero;
            Cd_conta_ctb = null;
        }
    }

    public class TCD_ReceitasIsentasPIS : TDataQuery
    {
        public TCD_ReceitasIsentasPIS()
        { }

        public TCD_ReceitasIsentasPIS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Cd_St_PIS, a.ID_DetRecIsentaPIS, a.Cd_ContaCTB_Sped, a.Vl_SubTotal as Vl_Receita ");

            sql.AppendLine("from VTB_FIS_REGM400 a ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public List<TRegistro_ReceitasIsentasPIS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ReceitasIsentasPIS> lista = new List<TRegistro_ReceitasIsentasPIS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ReceitasIsentasPIS reg = new TRegistro_ReceitasIsentasPIS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_St_PIS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_St_PIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DetRecIsentaPIS")))
                        reg.Id_detrecIsenta = reader.GetDecimal(reader.GetOrdinal("ID_DetRecIsentaPIS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ContaCTB_Sped")))
                        reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("Cd_ContaCTB_Sped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Receita")))
                        reg.Vl_Receita = reader.GetDecimal(reader.GetOrdinal("Vl_Receita"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Credito COFINS
    
    public class TRegistro_CreditoCOFINS
    {
        public decimal? Tp_cred
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_COFINS
        { get; set; }

        public TRegistro_CreditoCOFINS()
        {
            Tp_cred = null;
            Pc_aliquota = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_COFINS = decimal.Zero;
        }
    }

    public class TCD_CreditoCOFINS : TDataQuery
    {
        public TCD_CreditoCOFINS()
        { }

        public TCD_CreditoCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.Id_TpCredCOFINS, b.Pc_aliquotaCOFINS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcCofins, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_Cofins, 0)), 0) as Vl_COFINS ");

            sql.AppendLine("from TB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_CFOP e ");
            sql.AppendLine("on b.cd_cfop = e.cd_cfop ");
            sql.AppendLine("and isnull(e.st_bonificacao, 'N') <> 'S' ");

            string cond = " where ";

            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by b.Id_TpCredCofins, b.Pc_aliquotaCofins ");
            sql.AppendLine("order by b.Id_TpCredCofins ");

            return sql.ToString();
        }

        public List<TRegistro_CreditoCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_CreditoCOFINS> lista = new List<TRegistro_CreditoCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CreditoCOFINS reg = new TRegistro_CreditoCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_TpCredCOFINS")))
                        reg.Tp_cred = reader.GetDecimal(reader.GetOrdinal("Id_TpCredCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_COFINS")))
                        reg.Vl_COFINS = reader.GetDecimal(reader.GetOrdinal("Vl_COFINS"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento Base Credito COFINS
    public class TRegistro_BaseCalcCredCOFINS
    {
        
        public decimal? Id_basecredito
        { get; set; }
        
        public string Cd_st
        { get; set; }
        
        public decimal Vl_basecalc
        { get; set; }

        public TRegistro_BaseCalcCredCOFINS()
        {
            Id_basecredito = null;
            Cd_st = string.Empty;
            Vl_basecalc = decimal.Zero;
        }
    }

    public class TCD_BaseCalcCredCOFINS : TDataQuery
    {
        public TCD_BaseCalcCredCOFINS()
        { }

        public TCD_BaseCalcCredCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.Id_basecreditoCOFINS, b.Cd_St_cofins as Cd_StCOFINS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(b.Vl_basecalcCofins, 0)), 0) as Vl_BaseCalc ");

            sql.AppendLine("from TB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = b.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FIS_Movimentacao c ");
            sql.AppendLine("on a.cd_movimentacao = c.CD_Movimentacao ");
            sql.AppendLine("inner join TB_FIS_CFOP d ");
            sql.AppendLine("on b.cd_cfop = d.cd_cfop ");
            sql.AppendLine("and isnull(d.st_bonificacao, 'N') <> 'S' ");

            sql.AppendLine("where a.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");

            sql.AppendLine("group by b.Id_basecreditoCofins, b.Cd_St_cofins ");

            return sql.ToString();
        }

        public List<TRegistro_BaseCalcCredCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_BaseCalcCredCOFINS> lista = new List<TRegistro_BaseCalcCredCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_BaseCalcCredCOFINS reg = new TRegistro_BaseCalcCredCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_basecreditoCOFINS")))
                        reg.Id_basecredito = reader.GetDecimal(reader.GetOrdinal("Id_basecreditoCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StCOFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_StCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Detalhamento por codigo Receita COFINS

    public class TRegistro_receitaCOFINS
    {
        public decimal? Id_receita
        { get; set; }
        public decimal Vl_debito
        { get; set; }

        public TRegistro_receitaCOFINS()
        {
            Id_receita = null;
            Vl_debito = decimal.Zero;
        }
    }

    public class TCD_ReceitaCOFINS : TDataQuery
    {
        public TCD_ReceitaCOFINS() { }

        public TCD_ReceitaCOFINS(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_ReceitaCOFINS, sum(isnull(a.vl_cofins, 0)) as vl_debito ");

            sql.AppendLine("from VTB_FIS_REGM605 a ");

            string cond = " where ";

            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by a.ID_ReceitaCOFINS ");

            return sql.ToString();
        }

        public List<TRegistro_receitaCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_receitaCOFINS> lista = new List<TRegistro_receitaCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_receitaCOFINS reg = new TRegistro_receitaCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_ReceitaCOFINS")))
                        reg.Id_receita = reader.GetDecimal(reader.GetOrdinal("ID_ReceitaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_debito")))
                        reg.Vl_debito = reader.GetDecimal(reader.GetOrdinal("vl_debito"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }

    #endregion

    #region Detalhamento Contribuicao COFINS

    public class TRegistro_ContribuicaoCOFINS
    {
        public decimal? Id_tpcontribuicao
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_subtotal
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_COFINS
        { get; set; }

        public TRegistro_ContribuicaoCOFINS()
        {
            Id_tpcontribuicao = null;
            Pc_aliquota = decimal.Zero;
            Vl_subtotal = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_COFINS = decimal.Zero;
        }
    }

    public class TCD_ContribuicaoCOFINS : TDataQuery
    {
        public TCD_ContribuicaoCOFINS()
        { }

        public TCD_ContribuicaoCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Id_TpContribuicaoCOFINS, a.Pc_aliquotaCOFINS, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_SubTotal, 0)), 0) as Vl_SubTotal, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_BaseCalc, 0)), 0) as Vl_BaseCalc, ");
            sql.AppendLine("ISNULL(SUM(ISNULL(a.Vl_COFINS, 0)), 0) as Vl_COFINS ");

            sql.AppendLine("from VTB_FIS_REGM610 a ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            sql.AppendLine("group by a.Id_TpContribuicaoCOFINS, a.Pc_aliquotaCOFINS ");

            return sql.ToString();
        }

        public List<TRegistro_ContribuicaoCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ContribuicaoCOFINS> lista = new List<TRegistro_ContribuicaoCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ContribuicaoCOFINS reg = new TRegistro_ContribuicaoCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Id_TpContribuicaoCOFINS")))
                        reg.Id_tpcontribuicao = reader.GetDecimal(reader.GetOrdinal("Id_TpContribuicaoCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaCOFINS")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_subtotal = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_COFINS")))
                        reg.Vl_COFINS = reader.GetDecimal(reader.GetOrdinal("Vl_COFINS"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region Receitas Isentas COFINS
    
    public class TRegistro_ReceitasIsentasCOFINS
    {
        public string Cd_st
        { get; set; }
        public decimal? Id_detrecIsenta
        { get; set; }
        public decimal Vl_Receita
        { get; set; }
        public decimal? Cd_conta_ctb
        { get; set; }

        public TRegistro_ReceitasIsentasCOFINS()
        {
            Cd_st = string.Empty;
            Id_detrecIsenta = null;
            Vl_Receita = decimal.Zero;
            Cd_conta_ctb = null;
        }
    }

    public class TCD_ReceitasIsentasCOFINS : TDataQuery
    {
        public TCD_ReceitasIsentasCOFINS()
        { }

        public TCD_ReceitasIsentasCOFINS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.Cd_St_COFINS, a.ID_DetRecIsentaCOFINS, a.Cd_contactb_sped, a.Vl_SubTotal as Vl_Receita ");

            sql.AppendLine("from VTB_FIS_REGM800 a ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }

            return sql.ToString();
        }

        public List<TRegistro_ReceitasIsentasCOFINS> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ReceitasIsentasCOFINS> lista = new List<TRegistro_ReceitasIsentasCOFINS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ReceitasIsentasCOFINS reg = new TRegistro_ReceitasIsentasCOFINS();
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_St_COFINS")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_St_COFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_DetRecIsentaCOFINS")))
                        reg.Id_detrecIsenta = reader.GetDecimal(reader.GetOrdinal("ID_DetRecIsentaCOFINS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_conta_ctb = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Receita")))
                        reg.Vl_Receita = reader.GetDecimal(reader.GetOrdinal("Vl_Receita"));

                    lista.Add(reg);
                }
                return lista;
            }
            finally
            {
                reader.Close();
                reader.Dispose();
                if (st_transacao)
                    deletarBanco_Dados();
            }
        }
    }
    #endregion
}
