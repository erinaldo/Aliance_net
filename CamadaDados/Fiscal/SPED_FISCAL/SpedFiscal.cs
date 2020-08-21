using System;
using System.Collections.Generic;
using System.Text;

namespace CamadaDados.Fiscal.SPED_FISCAL
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
        public string Insc_estadual
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Insc_municipal
        { get; set; }
        public string Fone
        { get; set; }
        public string Email
        { get; set; }
        public string Ds_cidade
        { get; set; }
        public string Cd_clifor_contador
        { get; set; }
        public string Crc_contador
        { get; set; }
        public string Ds_uf
        { get; set; }
        public string Cep
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Numero
        { get; set; }
        public string Bairro
        { get; set; }
        public string Ds_complemento
        { get; set; }
        public string Tp_perfilfiscal
        { get; set; }
        public string Tp_atividadespedfiscal
        { get; set; }
        public string LayoutSpedFiscal
        { get; set; }

        public TRegistro_DadosEmpresa()
        {
            Bairro = string.Empty;
            Cd_cidade = string.Empty;
            Cd_clifor_contador = string.Empty;
            Crc_contador = string.Empty;
            Cd_empresa = string.Empty;
            Cep = string.Empty;
            Ds_cidade = string.Empty;
            Ds_complemento = string.Empty;
            Ds_endereco = string.Empty;
            Ds_uf = string.Empty;
            Email = string.Empty;
            Fone = string.Empty;
            Insc_estadual = string.Empty;
            Insc_municipal = string.Empty;
            Nm_empresa = string.Empty;
            Nr_cnpj = string.Empty;
            Numero = string.Empty;
            Uf = string.Empty;
            Tp_perfilfiscal = string.Empty;
            Tp_atividadespedfiscal = string.Empty;
            LayoutSpedFiscal = string.Empty;
        }
    }

    public class TCD_DadosEmpresa:TDataQuery
    {
        public TCD_DadosEmpresa()
        { }

        public TCD_DadosEmpresa(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, a.NM_Empresa, b.NR_CGC, a.CRC_Contador, ");
            sql.AppendLine("c.UF, c.Insc_Estadual, c.CD_Cidade, a.Insc_Municipal, ");
            sql.AppendLine("c.Fone, b.Email, c.DS_Cidade, a.CD_Clifor_Contador, ");
            sql.AppendLine("c.DS_UF, c.Cep, c.DS_Endereco, c.Numero, c.Bairro, ");
            sql.AppendLine("a.tp_perfilfiscal, a.tp_atividadespedfiscal, c.DS_Complemento, ");
            sql.AppendLine("a.layoutspedfiscal ");

            sql.AppendLine("from TB_DIV_Empresa a ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR b ");
            sql.AppendLine("on a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO c ");
            sql.AppendLine("on a.CD_Clifor = c.CD_Clifor ");
            sql.AppendLine("and a.CD_Endereco = c.CD_Endereco ");

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
                    if (!reader.IsDBNull(reader.GetOrdinal("fone")))
                        reg.Fone = reader.GetString(reader.GetOrdinal("fone"));
                    if (!reader.IsDBNull(reader.GetOrdinal("email")))
                        reg.Email = reader.GetString(reader.GetOrdinal("email"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cidade")))
                        reg.Ds_cidade = reader.GetString(reader.GetOrdinal("ds_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor_contador")))
                        reg.Cd_clifor_contador = reader.GetString(reader.GetOrdinal("cd_clifor_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("crc_contador")))
                        reg.Crc_contador = reader.GetString(reader.GetOrdinal("crc_contador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_uf")))
                        reg.Ds_uf = reader.GetString(reader.GetOrdinal("ds_uf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cep")))
                        reg.Cep = reader.GetString(reader.GetOrdinal("cep"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        reg.Ds_complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_perfilfiscal")))
                        reg.Tp_perfilfiscal = reader.GetString(reader.GetOrdinal("tp_perfilfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_atividadespedfiscal")))
                        reg.Tp_atividadespedfiscal = reader.GetString(reader.GetOrdinal("tp_atividadespedfiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("layoutspedfiscal")))
                        reg.LayoutSpedFiscal = reader.GetString(reader.GetOrdinal("layoutspedfiscal"));

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
    
    public class TRegistro_CodeParticipante
    {
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_cnpj
        { get; set; }
        public string Nr_cpf
        { get; set; }
        public string Insc_estadual
        { get; set; }
        public string Cd_cidade
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Ds_endereco
        { get; set; }
        public string Numero
        { get; set; }
        public string Ds_complemento
        { get; set; }
        public string Bairro
        { get; set; }
        public string Cd_pais
        { get; set; }

        public TRegistro_CodeParticipante()
        {
            Bairro = string.Empty;
            Cd_cidade = string.Empty;
            Cd_clifor = string.Empty;
            Cd_pais = string.Empty;
            Ds_complemento = string.Empty;
            Cd_endereco = string.Empty;
            Ds_endereco = string.Empty;
            Insc_estadual = string.Empty;
            Nm_clifor = string.Empty;
            Nr_cnpj = string.Empty;
            Nr_cpf = string.Empty;
            Numero = string.Empty;
        }
    }

    public class TCD_CodeParticipante : TDataQuery
    {
        public TCD_CodeParticipante()
        { }

        public TCD_CodeParticipante(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct CD_Clifor, NM_Clifor, ");
            sql.AppendLine("NR_CGC, NR_CPF, Insc_Estadual, ");
            sql.AppendLine("CD_Cidade, CD_Endereco, DS_Endereco, Numero, ");
            sql.AppendLine("DS_Complemento, Bairro, CD_PAIS ");

            sql.AppendLine("from VTB_FIS_ParticipamenteSPED ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<TRegistro_CodeParticipante> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_CodeParticipante> lista = new List<TRegistro_CodeParticipante>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CodeParticipante reg = new TRegistro_CodeParticipante();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("nm_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Nr_cnpj = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cpf")))
                        reg.Nr_cpf = reader.GetString(reader.GetOrdinal("nr_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cidade")))
                        reg.Cd_cidade = reader.GetString(reader.GetOrdinal("cd_cidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("cd_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("ds_endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("numero")))
                        reg.Numero = reader.GetString(reader.GetOrdinal("numero"));
                    if (!reader.IsDBNull(reader.GetOrdinal("bairro")))
                        reg.Bairro = reader.GetString(reader.GetOrdinal("bairro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_complemento")))
                        reg.Ds_complemento = reader.GetString(reader.GetOrdinal("ds_complemento"));
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

    #region Unidades
    
    public class TRegistro_CodeUnidade
    {
        
        public string Cd_unidade
        { get; set; }
        
        public string Ds_unidade
        { get; set; }

        public TRegistro_CodeUnidade()
        {
            Cd_unidade = string.Empty;
            Ds_unidade = string.Empty;
        }
    }

    public class TCD_CodeUnidade : TDataQuery
    {
        public TCD_CodeUnidade()
        { }

        public TCD_CodeUnidade(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    bool St_industria,
                                    DateTime Dt_ini,
                                    DateTime Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select c.CD_Unidade, d.DS_Unidade ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal_Item b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join TB_EST_Unidade d ");
            sql.AppendLine("on d.CD_Unidade = c.CD_Unidade ");

            sql.AppendLine("where (a.cd_modelo in('01', '1B', '04', '02', '2D', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22') or (a.CD_Modelo = '55' and a.TP_Nota = 'T'))");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end) >= '" + Dt_ini.ToString("yyyyMMdd") + "'");
            sql.AppendLine("and (case when a.tp_movimento = 'S' then a.dt_emissao else a.dt_saient end) <= '" + Dt_fin.ToString("yyyyMMdd") + " 23:59:59'");

            sql.AppendLine("union ");

            sql.AppendLine("select c.CD_Unidade, d.DS_Unidade ");
            
            sql.AppendLine("from tb_pdv_nfce a ");
            sql.AppendLine("inner join tb_pdv_nfce_item b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("and a.id_nfce = b.id_nfce ");
            sql.AppendLine("inner join tb_est_produto c ");
            sql.AppendLine("on b.cd_produto = c.cd_produto ");
            sql.AppendLine("inner join tb_est_unidade d ");
            sql.AppendLine("on c.cd_unidade = d.cd_unidade ");

            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and ISNULL(b.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and a.cd_modelo <> '65'");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) >= '" + Dt_ini.ToString("yyyyMMdd") + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.dt_emissao))) <= '" + Dt_fin.ToString("yyyyMMdd") + "'");
            if (St_industria)
            {
                sql.AppendLine("union ");
                sql.AppendLine("Select a.CD_Unidade, c.DS_Unidade ");
                sql.AppendLine("from TB_EST_Produto a ");
                sql.AppendLine("inner join TB_EST_TpProduto b ");
                sql.AppendLine("on a.TP_Produto = b.TP_Produto ");
                sql.AppendLine("and a.tp_item <> '07' ");
                sql.AppendLine("and a.tp_item <> '08' ");
                sql.AppendLine("and a.tp_item <> '09' ");
                sql.AppendLine("and a.tp_item <> '99' ");
                sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
                sql.AppendLine("and isnull(b.st_servico, 'N') <> 'S' ");
                sql.AppendLine("inner join tb_est_unidade c ");
                sql.AppendLine("on a.cd_unidade = c.cd_unidade ");
                sql.AppendLine("where ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
                sql.AppendLine("                from TB_EST_Estoque x ");
                sql.AppendLine("                where x.CD_Produto = a.CD_Produto ");
                sql.AppendLine("                and ISNULL(x.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("                and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '" + Dt_fin.ToString("yyyyMMdd") + "'), 0) > 0");
            }
            if (Dt_fin.Month.Equals(2))
            {
                sql.AppendLine("union ");
                sql.AppendLine("select a.CD_Unidade, b.DS_Unidade ");
                sql.AppendLine("from TB_EST_Produto a ");
                sql.AppendLine("inner join TB_EST_Unidade b ");
                sql.AppendLine("on a.CD_Unidade = b.CD_Unidade ");
                sql.AppendLine("where ISNULL(a.ST_Registro, 'A') = 'A' ");
                sql.AppendLine("and ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
                sql.AppendLine("      from TB_EST_Estoque x ");
                sql.AppendLine("      where x.CD_Produto = a.CD_Produto ");
                sql.AppendLine("      and ISNULL(x.ST_Registro, 'A') = 'A' ");
                sql.AppendLine("      and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
                sql.AppendLine("      and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '"
                                      + new DateTime(Dt_fin.AddMonths(-2).Year,
                                        Dt_fin.AddMonths(-2).Month,
                                        DateTime.DaysInMonth(Dt_fin.AddMonths(-2).Year,
                                        Dt_fin.AddMonths(-2).Month)).ToString("yyyyMMdd") + "' ), 0) > 0 ");
                sql.AppendLine("and ISNULL((select sum(case when x.tp_movimento = 'E' then x.vl_subtotal else 0 end) - ");
                sql.AppendLine("                    sum(case when x.tp_movimento = 'S' then x.vl_subtotal else 0 end) ");
                sql.AppendLine("      from TB_EST_Estoque x ");
                sql.AppendLine("      where x.CD_Produto = a.CD_Produto ");
                sql.AppendLine("      and ISNULL(x.ST_Registro, 'A') = 'A' ");
                sql.AppendLine("      and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
                sql.AppendLine("      and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '"
                                      + new DateTime(Dt_fin.AddMonths(-2).Year,
                                        Dt_fin.AddMonths(-2).Month,
                                        DateTime.DaysInMonth(Dt_fin.AddMonths(-2).Year,
                                        Dt_fin.AddMonths(-2).Month)).ToString("yyyyMMdd") + "' ), 0) > 0 ");
            }

            return sql.ToString();
        }

        public List<TRegistro_CodeUnidade> Select(string Cd_empresa,
                                                  bool St_industria,
                                                  DateTime Dt_ini,
                                                  DateTime Dt_fin)
        {
            List<TRegistro_CodeUnidade> lista = new List<TRegistro_CodeUnidade>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, St_industria, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CodeUnidade reg = new TRegistro_CodeUnidade();
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

    #region Itens Nota
    
    public class TRegistro_CodeItensNota
    {
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public string Tp_item
        { get; set; }
        
        public string Ncm
        { get; set; }
        
        public string Cd_anp
        { get; set; }
        
        public decimal? Id_genero
        { get; set; }
        
        public string Tp_produto
        { get; set; }
        
        public string Id_tpservico
        { get; set; }
        
        public decimal Pc_aliquotaicms
        { get; set; }
        public string CEST { get; set; } = string.Empty;

        public TRegistro_CodeItensNota()
        {
            Cd_produto = string.Empty;
            Cd_unidade = string.Empty;
            Ds_produto = string.Empty;
            Id_genero = null;
            Id_tpservico = string.Empty;
            Ncm = string.Empty;
            Cd_anp = string.Empty;
            Pc_aliquotaicms = decimal.Zero;
            Tp_item = string.Empty;
            Tp_produto = string.Empty;
        }
    }

    public class TCD_CodeItensNota : TDataQuery
    {
        public TCD_CodeItensNota()
        { }

        public TCD_CodeItensNota(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    bool St_industria,
                                    DateTime? Dt_ini,
                                    DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct a.CD_Produto, a.DS_Produto, ");
            sql.AppendLine("a.CD_Unidade, a.TP_ITEM, a.NCM, a.ID_Genero, ");
            sql.AppendLine("a.TP_Produto, a.ID_TPServico,  a.CD_ANP, a.CEST ");
            sql.AppendLine("from VTB_FIS_ITENSSPED a ");
            sql.AppendLine("where a.CD_Empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.DT_Movimento))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") +"' ");
            if (St_industria)
            {
                sql.AppendLine("union ");
                sql.AppendLine("Select a.CD_Produto, a.DS_Produto, ");
                sql.AppendLine("a.CD_Unidade, a.TP_Item, a.NCM, a.ID_Genero, ");
                sql.AppendLine("a.TP_Produto, a.ID_TPServico, a.CD_ANP, c.CEST ");
                sql.AppendLine("from TB_EST_Produto a ");
                sql.AppendLine("inner join TB_EST_TpProduto b ");
                sql.AppendLine("on a.TP_Produto = b.TP_Produto ");
                sql.AppendLine("and a.tp_item <> '07' ");
                sql.AppendLine("and a.tp_item <> '08' ");
                sql.AppendLine("and a.tp_item <> '09' ");
                sql.AppendLine("and a.tp_item <> '99' ");
                sql.AppendLine("and isnull(a.st_registro, 'A') <> 'C' ");
                sql.AppendLine("and isnull(b.st_servico, 'N') <> 'S' ");
                sql.AppendLine("left outer join tb_fis_ncm c ");
                sql.AppendLine("on a.ncm = c.ncm ");
                sql.AppendLine("where ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
                sql.AppendLine("                from TB_EST_Estoque x ");
                sql.AppendLine("                where x.CD_Produto = a.CD_Produto ");
                sql.AppendLine("                and ISNULL(x.ST_Registro, 'A') <> 'C' ");
                sql.AppendLine("                and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
                sql.AppendLine("                and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '" + Dt_fin.Value.ToString("yyyyMMdd") + "'), 0) > 0");
            }
            if (Dt_fin.Value.Month.Equals(2))
            {
                sql.AppendLine("union ");
                sql.AppendLine("select a.CD_Produto, a.DS_Produto, ");
                sql.AppendLine("a.CD_Unidade, a.TP_Item, a.NCM, a.ID_Genero, ");
                sql.AppendLine("a.TP_Produto, a.ID_TPServico, a.CD_ANP, c.CEST ");
                sql.AppendLine("from TB_EST_Produto a ");
                sql.AppendLine("inner join TB_EST_TpProduto b ");
                sql.AppendLine("on a.TP_Produto = b.TP_Produto ");
                sql.AppendLine("inner join TB_FIS_NCM c ");
                sql.AppendLine("on a.NCM = c.NCM ");
                sql.AppendLine("where ISNULL(a.ST_Registro, 'A') = 'A' ");
                sql.AppendLine("and ISNULL(b.ST_Servico, 'N') <> 'S' ");
                sql.AppendLine("and ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
                sql.AppendLine("      from TB_EST_Estoque x ");
                sql.AppendLine("      where x.CD_Produto = a.CD_Produto ");
                sql.AppendLine("      and ISNULL(x.ST_Registro, 'A') = 'A' ");
                sql.AppendLine("      and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
                sql.AppendLine("      and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '"
                                      + new DateTime(Dt_fin.Value.AddMonths(-2).Year,
                                        Dt_fin.Value.AddMonths(-2).Month,
                                        DateTime.DaysInMonth(Dt_fin.Value.AddMonths(-2).Year,
                                        Dt_fin.Value.AddMonths(-2).Month)).ToString("yyyyMMdd") + "' ), 0) > 0 ");
                sql.AppendLine("and ISNULL((select sum(case when x.tp_movimento = 'E' then x.vl_subtotal else 0 end) - ");
                sql.AppendLine("                    sum(case when x.tp_movimento = 'S' then x.vl_subtotal else 0 end) ");
                sql.AppendLine("      from TB_EST_Estoque x ");
                sql.AppendLine("      where x.CD_Produto = a.CD_Produto ");
                sql.AppendLine("      and ISNULL(x.ST_Registro, 'A') = 'A' ");
                sql.AppendLine("      and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
                sql.AppendLine("      and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '"
                                      + new DateTime(Dt_fin.Value.AddMonths(-2).Year,
                                        Dt_fin.Value.AddMonths(-2).Month,
                                        DateTime.DaysInMonth(Dt_fin.Value.AddMonths(-2).Year,
                                        Dt_fin.Value.AddMonths(-2).Month)).ToString("yyyyMMdd") + "' ), 0) > 0 ");
            }
            sql.AppendLine("order by a.cd_produto ");

            return sql.ToString();
        }

        public List<TRegistro_CodeItensNota> Select(string Cd_empresa,
                                                    bool St_industria,
                                                    DateTime? Dt_ini,
                                                    DateTime? Dt_fin)
        {
            List<TRegistro_CodeItensNota> lista = new List<TRegistro_CodeItensNota>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, St_industria, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CodeItensNota reg = new TRegistro_CodeItensNota();
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
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_produto")))
                        reg.Tp_produto = reader.GetString(reader.GetOrdinal("tp_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tpservico")))
                        reg.Id_tpservico = reader.GetString(reader.GetOrdinal("id_tpservico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_anp")))
                        reg.Cd_anp = reader.GetString(reader.GetOrdinal("cd_anp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CEST")))
                        reg.CEST = reader.GetString(reader.GetOrdinal("CEST"));

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

    #region Fator Conversao
    
    public class TRegistro_FatorConversao
    {
        
        public string Cd_unidade
        { get; set; }
        
        public decimal Vl_indice
        { get; set; }

        public TRegistro_FatorConversao()
        {
            Cd_unidade = string.Empty;
            Vl_indice = decimal.Zero;
        }
    }

    public class TCD_FatorConversao : TDataQuery
    {
        public TCD_FatorConversao()
        { }

        public TCD_FatorConversao(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct a.CD_Unidade, case when c.ST_Fator = '/' then 1 / c.VL_Indice else c.VL_Indice end as vl_indice ");

            sql.AppendLine("from TB_FAT_NotaFiscal_Item a ");
            sql.AppendLine("inner join TB_EST_Produto b ");
            sql.AppendLine("on a.CD_Produto = b.CD_Produto ");
            sql.AppendLine("inner join TB_EST_Converte_Unid c ");
            sql.AppendLine("on c.CD_Unidade_Orig = a.CD_Unidade ");
            sql.AppendLine("and c.CD_Unidade_Dest = b.CD_Unidade ");
            sql.AppendLine("inner join TB_FAT_NotaFiscal d ");
            sql.AppendLine("on a.cd_empresa = d.cd_empresa ");
            sql.AppendLine("and a.nr_lanctofiscal = d.nr_lanctofiscal ");
            sql.AppendLine("inner join TB_FAT_SerieNF e ");
            sql.AppendLine("on d.nr_serie = e.nr_serie ");
            sql.AppendLine("and d.cd_modelo = e.cd_modelo ");

            sql.AppendLine("where a.CD_Unidade <> b.CD_Unidade ");
            sql.AppendLine("and d.cd_modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22')");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public List<TRegistro_FatorConversao> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_FatorConversao> lista = new List<TRegistro_FatorConversao>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_FatorConversao reg = new TRegistro_FatorConversao();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_indice")))
                        reg.Vl_indice = reader.GetDecimal(reader.GetOrdinal("vl_indice"));

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
        
        public decimal? Cd_movto
        { get; set; }
        
        public string Ds_movimentacao
        { get; set; }

        public TRegistro_MovComercial()
        {
            Cd_movto = null;
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

            sql.AppendLine("where (c.cd_modelo in('01', '1B', '04', '02', '2D', '07', '08', '8B', '09', '10', '11', '26', '27', '57')");
            sql.AppendLine("or (c.cd_modelo = '55' and c.tp_nota = 'T'))");

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
                        reg.Cd_movto = reader.GetDecimal(reader.GetOrdinal("cd_movimentacao"));
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

    #region Nota Fiscal
    
    public class TRegistro_NotaFiscal
    {
        public string Cd_empresa
        { get; set; }
        public decimal Nr_lanctofiscal
        { get; set; }
        public string Nr_serie
        { get; set; }
        public decimal Nr_notafiscal
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Tp_nota
        { get; set; }
        public string St_registro
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Chave_acesso_nfe
        { get; set; }
        public DateTime Dt_emissao
        { get; set; }
        public DateTime Dt_saient
        { get; set; }
        public string Freteporconta
        { get; set; }
        public decimal Cd_movimentacao
        { get; set; }
        public string Tp_serie
        { get; set; }
        public string Cd_condpgto
        { get; set; }
        public decimal Qt_parcelas
        { get; set; }
        //Dados Item Nota
        public decimal Id_nfitem
        { get; set; }
        public string Cd_produto
        { get; set; }
        public string Ds_produto
        { get; set; }
        public decimal Quantidade
        { get; set; }
        public string Cd_unidade
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public bool St_movestoque
        { get; set; }
        public decimal Id_tanque
        { get; set; }
        public decimal Vl_seguro
        { get; set; }
        public decimal Vl_outrasdesp
        { get; set; }
        public decimal Vl_totalnota
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public decimal Vl_totalprodutosservicos
        { get; set; }
        public decimal Vl_frete
        { get; set; }
        public string Cd_st
        { get; set; }
        public decimal Vl_totalbasecalcicms
        { get; set; }
        public decimal Pc_aliquotaicms
        { get; set; }
        public decimal Vl_totalicms
        { get; set; }
        public string Cd_stipi
        { get; set; }
        public decimal Vl_basecalcipi
        { get; set; }
        public decimal Pc_aliquotaipi
        { get; set; }
        public decimal Vl_totalipi
        { get; set; }
        public bool St_NFVinculada
        { get; set; }

        public TRegistro_NotaFiscal()
        {
            Cd_empresa = string.Empty;
            Nr_lanctofiscal = decimal.Zero;
            Nr_serie = string.Empty;
            Nr_notafiscal = decimal.Zero;
            Tp_movimento = string.Empty;
            Tp_nota = string.Empty;
            St_registro = string.Empty;
            Cd_modelo = string.Empty;
            Cd_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Chave_acesso_nfe = string.Empty;
            Dt_emissao = DateTime.Now;
            Dt_saient = DateTime.Now;
            Freteporconta = string.Empty;
            Cd_movimentacao = decimal.Zero;
            Vl_seguro = decimal.Zero;
            Vl_outrasdesp = decimal.Zero;
            Tp_serie = string.Empty;
            Cd_condpgto = string.Empty;
            Qt_parcelas = decimal.Zero;
            Vl_totalnota = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_totalprodutosservicos = decimal.Zero;
            Vl_frete = decimal.Zero;
            Vl_totalbasecalcicms = decimal.Zero;
            Vl_totalicms = decimal.Zero;
            Vl_totalipi = decimal.Zero;
            St_NFVinculada = false;
            Id_nfitem = decimal.Zero;
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Quantidade = decimal.Zero;
            Cd_unidade = string.Empty;
            Cd_cfop = string.Empty;
            St_movestoque = false;
            Id_tanque = decimal.Zero;
            Cd_st = string.Empty;
            Pc_aliquotaicms = decimal.Zero;
            Cd_stipi = string.Empty;
            Vl_basecalcipi = decimal.Zero;
            Pc_aliquotaipi = decimal.Zero;
        }
    }

    public class TCD_NotaFiscal : TDataQuery
    {
        public TCD_NotaFiscal()
        { }

        public TCD_NotaFiscal(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, a.Nr_LanctoFiscal, a.Nr_Serie, a.Nr_NotaFiscal, ");
            sql.AppendLine("a.Tp_Movimento, a.Tp_Nota, a.ST_Registro, a.CD_Modelo, a.CD_Clifor, a.CD_Endereco, ");
            sql.AppendLine("a.Chave_Acesso_NFE, a.DT_Emissao, a.DT_SaiEnt, a.FreteporConta, a.CD_Movimentacao, ");
            sql.AppendLine("a.Tp_Serie, a.CD_CondPGTO, a.QT_Parcelas, a.Vl_Seguro, a.Vl_OutrasDesp, ");
            sql.AppendLine("a.vl_contabil, a.Vl_Desconto, a.Vl_SubTotal, a.VL_FreteItem, ");
            sql.AppendLine("a.ID_NFItem, a.CD_Produto, a.DS_Produto, a.Quantidade, a.CD_Unidade, ");
            sql.AppendLine("a.CD_CFOP, a.CD_Movimentacao, a.st_movestoque, ");
            sql.AppendLine("a.id_tanque, a.ST_NFVinculada, a.Cd_St_icms, a.Vl_basecalcicms, ");
            sql.AppendLine("a.Pc_aliquotaicms, a.Vl_icms, a.cd_st_ipi, a.Vl_basecalcipi, ");
            sql.AppendLine("a.Pc_aliquotaipi, a.Vl_ipi ");

            sql.AppendLine("from VTB_FIS_NotaFiscalSped a  ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<TRegistro_NotaFiscal> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_NotaFiscal> lista = new List<TRegistro_NotaFiscal>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NotaFiscal reg = new TRegistro_NotaFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("Nr_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("Tp_Nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_NFE")))
                        reg.Chave_acesso_nfe = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FreteporConta")))
                        reg.Freteporconta = reader.GetString(reader.GetOrdinal("FreteporConta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Movimentacao")))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_Movimentacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Serie")))
                        reg.Tp_serie = reader.GetString(reader.GetOrdinal("Tp_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QT_Parcelas")))
                        reg.Qt_parcelas = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Seguro")))
                        reg.Vl_seguro = reader.GetDecimal(reader.GetOrdinal("Vl_Seguro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_OutrasDesp")))
                        reg.Vl_outrasdesp = reader.GetDecimal(reader.GetOrdinal("Vl_OutrasDesp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_contabil")))
                        reg.Vl_totalnota = reader.GetDecimal(reader.GetOrdinal("vl_contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("Vl_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_SubTotal")))
                        reg.Vl_totalprodutosservicos = reader.GetDecimal(reader.GetOrdinal("Vl_SubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_FreteItem")))
                        reg.Vl_frete = reader.GetDecimal(reader.GetOrdinal("VL_FreteItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ID_NFItem")))
                        reg.Id_nfitem = reader.GetDecimal(reader.GetOrdinal("ID_NFItem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Produto")))
                        reg.Ds_produto = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_movestoque")))
                        reg.St_movestoque = reader.GetString(reader.GetOrdinal("st_movestoque")).ToString().Trim().ToUpper().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_NFVinculada")))
                        reg.St_NFVinculada = reader.GetString(reader.GetOrdinal("ST_NFVinculada")).ToString().ToUpper().Trim().Equals("S");
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_St_icms")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("Cd_St_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcicms")))
                        reg.Vl_totalbasecalcicms = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaicms")))
                        reg.Pc_aliquotaicms = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_totalicms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st_ipi")))
                        reg.Cd_stipi = reader.GetString(reader.GetOrdinal("cd_st_ipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcipi")))
                        reg.Vl_basecalcipi = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaipi")))
                        reg.Pc_aliquotaipi = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ipi")))
                        reg.Vl_totalipi = reader.GetDecimal(reader.GetOrdinal("Vl_ipi"));

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
            sql.AppendLine("DadosAdicionais = ISNULL(DadosAdicionais, ISNULL(ObsFiscal, '')) + dbo.F_FAT_DADOSADICIONAIS(a.cd_empresa, a.nr_lanctofiscal) ");
            
            sql.AppendLine("from TB_FAT_NotaFiscal a ");

            sql.AppendLine("where ISNULL(DadosAdicionais, ISNULL(ObsFiscal, '')) + dbo.F_FAT_DADOSADICIONAIS(a.cd_empresa, a.nr_lanctofiscal) <> '' ");
            sql.AppendLine("and (a.cd_modelo in('01', '1B', '04', '02', '2D', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22') or (a.CD_Modelo = '55' and a.TP_Nota = 'T'))");

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

    #region Observacao Fiscal
    
    public class TRegistro_ObservacaoFiscal
    {
        
        public string Cd_observacao
        { get; set; }
        
        public string Ds_observacao
        { get; set; }

        public TRegistro_ObservacaoFiscal()
        {
            Cd_observacao = string.Empty;
            Ds_observacao = string.Empty;
        }
    }

    public class TCD_ObservacaoFiscal : TDataQuery
    {
        public TCD_ObservacaoFiscal()
        { }

        public TCD_ObservacaoFiscal(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select distinct a.nr_lanctofiscal as cd_observacao, a.ObsFiscal ");

            sql.AppendLine("from TB_FAT_NotaFiscal a ");
            sql.AppendLine("where ISNULL(a.ObsFiscal, '') <> '' ");

            sql.AppendLine("and (a.cd_modelo in('01', '1B', '04', '02', '2D', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22') or (a.CD_Modelo = '55' and a.TP_Nota = 'T'))");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
            return sql.ToString();
        }

        public List<TRegistro_ObservacaoFiscal> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ObservacaoFiscal> lista = new List<TRegistro_ObservacaoFiscal>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ObservacaoFiscal reg = new TRegistro_ObservacaoFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_observacao")))
                        reg.Cd_observacao = reader.GetDecimal(reader.GetOrdinal("cd_observacao")).ToString();
                    if (!reader.IsDBNull(reader.GetOrdinal("obsfiscal")))
                        reg.Ds_observacao = reader.GetString(reader.GetOrdinal("obsfiscal"));

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

    #region Armazenamento Combustivel
    
    public class TRegistro_ArmazenamentoCombustivel
    {
        
        public decimal Id_tanque
        { get; set; }
        
        public decimal Quantidade
        { get; set; }

        public TRegistro_ArmazenamentoCombustivel()
        {
            Id_tanque = decimal.Zero;
            Quantidade = decimal.Zero;
        }
    }

    public class TCD_ArmazenamentoCombustivel : TDataQuery
    {
        public TCD_ArmazenamentoCombustivel()
        { }

        public TCD_ArmazenamentoCombustivel(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select e.Id_Tanque, a.Quantidade ");

            sql.AppendLine("from TB_FAT_NotaFiscal_Item a ");
            sql.AppendLine("inner join TB_EST_Produto c ");
            sql.AppendLine("on a.CD_Produto = c.CD_Produto ");
            sql.AppendLine("inner join TB_EST_TpProduto d ");
            sql.AppendLine("on c.TP_Produto = d.TP_Produto ");
            sql.AppendLine("inner join TB_PDC_Tanque e ");
            sql.AppendLine("on a.CD_Local = e.CD_Local ");
            sql.AppendLine("and a.CD_Empresa = e.CD_Empresa ");
            sql.AppendLine("and a.CD_Produto = e.CD_Produto ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public List<TRegistro_ArmazenamentoCombustivel> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_ArmazenamentoCombustivel> lista = new List<TRegistro_ArmazenamentoCombustivel>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ArmazenamentoCombustivel reg = new TRegistro_ArmazenamentoCombustivel();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade"));

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
        public decimal? Nr_nfce
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

        public TRegistro_NFCe()
        {
            Id_cupom = null;
            Cd_modelo = string.Empty;
            St_registro = string.Empty;
            Nr_serie = string.Empty;
            Nr_nfce = null;
            Chave_acesso = string.Empty;
            Dt_emissao = null;
            Vl_itens = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Vl_cupom = decimal.Zero;
            Vl_basecalcicms = decimal.Zero;
            Vl_icms = decimal.Zero;
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
            sql.AppendLine("a.NR_NFCe, a.Chave_Acesso, a.DT_Emissao, ");
            sql.AppendLine("Vl_Itens = isnull((select sum(isnull(x.vl_subtotal, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_Desc = isnull((select sum(isnull(x.vl_desconto, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_OutrasDesp = isnull((select sum(ISNULL(x.vl_juro_fin, 0) + ISNULL(x.vl_acrescimo, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_cupom = isnull((select sum(isnull(x.vl_subtotal, 0) + ISNULL(x.vl_juro_fin, 0) + ISNULL(x.vl_frete, 0) + ISNULL(x.vl_acrescimo, 0) - isnull(x.vl_desconto, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_BaseICMS = isnull((select sum(isnull(x.Vl_BaseCalcICMS, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.id_nfce = a.id_nfce), 0), ");
            sql.AppendLine("Vl_ICMS = isnull((select sum(isnull(x.Vl_ICMS, 0)) ");
            sql.AppendLine("                    from TB_PDV_NFCe_Item x ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa  ");
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
                        reg.Nr_nfce = reader.GetDecimal(reader.GetOrdinal("NR_NFCe"));
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

    #region Analitico Cupom Fiscal Eletronico
    public class TRegistro_NFCeC190
    {
        public string Cd_st_icms
        { get; set; }
        public string Cd_cfop
        { get; set; }
        public decimal Pc_aliquota
        { get; set; }
        public decimal Vl_operacao
        { get; set; }
        public decimal Vl_basecalc
        { get; set; }
        public decimal Vl_icms
        { get; set; }

        public TRegistro_NFCeC190()
        {
            Cd_st_icms = string.Empty;
            Cd_cfop = string.Empty;
            Pc_aliquota = decimal.Zero;
            Vl_operacao = decimal.Zero;
            Vl_basecalc = decimal.Zero;
            Vl_icms = decimal.Zero;
        }
    }

    public class TCD_NFCeC190 : TDataQuery
    {
        public TCD_NFCeC190() { }

        public TCD_NFCeC190(BancoDados.TObjetoBanco banco) { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa, string Id_cupom)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.cd_st_icms, b.CD_CFOP, b.pc_aliquotaicms, ");
            sql.AppendLine("Vl_operacao = sum(isnull(b.vl_contabil, 0)), ");
            sql.AppendLine("Vl_basecalc = sum(isnull(b.Vl_basecalcicms, 0)), ");
            sql.AppendLine("Vl_icms = sum(isnull(b.Vl_icms, 0)) ");

            sql.AppendLine("from TB_PDV_NFCe a ");
            sql.AppendLine("inner join vtb_fis_nfceitem b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.id_nfce = b.id_nfce ");

            sql.AppendLine("where a.CD_Modelo = '65' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            sql.AppendLine("and a.id_nfce = " + Id_cupom);

            sql.AppendLine("group by b.cd_st_icms, b.CD_CFOP, b.pc_aliquotaicms ");

            return sql.ToString();
        }

        public List<TRegistro_NFCeC190> Select(string Cd_empresa, string Id_cupom)
        {
            List<TRegistro_NFCeC190> lista = new List<TRegistro_NFCeC190>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Id_cupom));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFCeC190 reg = new TRegistro_NFCeC190();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st_icms")))
                        reg.Cd_st_icms = reader.GetString(reader.GetOrdinal("cd_st_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaicms")))
                        reg.Pc_aliquota = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_operacao")))
                        reg.Vl_operacao = reader.GetDecimal(reader.GetOrdinal("Vl_operacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_basecalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));

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

    #region Servicos

    public class TRegistro_NFServicos
    {
        public string Cd_empresa
        { get; set; }
        public decimal Nr_lancto
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public string Tp_nota
        { get; set; }
        public string Tp_registro
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Cd_endereco
        { get; set; }
        public string Cd_modelo
        { get; set; }
        public string St_registro
        { get; set; }
        public string Nr_serie
        { get; set; }
        public string Nr_subserie
        { get; set; }
        public decimal? Nr_notafiscal
        { get; set; }
        public string Chave_acesso
        { get; set; }
        public DateTime? Dt_emissao
        { get; set; }
        public DateTime? Dt_saient
        { get; set; }
        public string Tp_cte
        { get; set; }
        public string Chave_cte_refenciado
        { get; set; }
        public decimal Vl_totalnota
        { get; set; }
        public decimal Vl_desconto
        { get; set; }
        public string Freteporconta
        { get; set; }
        public decimal Vl_totalservico
        { get; set; }
        public decimal Vl_basecalcicms
        { get; set; }
        public decimal Vl_icms
        { get; set; }
        public decimal Vl_naotributado
        { get { return Vl_totalnota - Vl_basecalcicms; } }
        public decimal? Cd_contactb_sped { get; set; } = null;
        public string Cd_cidade_ini { get; set; } = string.Empty;
        public string Cd_cidade_fin { get; set; } = string.Empty;

        public TRegistro_NFServicos()
        {
            Cd_empresa = string.Empty;
            Nr_lancto = decimal.Zero;
            Tp_movimento = string.Empty;
            Tp_nota = string.Empty;
            Tp_registro = string.Empty;
            Cd_clifor = string.Empty;
            Cd_endereco = string.Empty;
            Cd_modelo = string.Empty;
            St_registro = string.Empty;
            Nr_serie = string.Empty;
            Nr_subserie = string.Empty;
            Nr_notafiscal = null;
            Chave_acesso = string.Empty;
            Dt_emissao = null;
            Dt_saient = null;
            Tp_cte = string.Empty;
            Chave_cte_refenciado = string.Empty;
            Vl_totalnota = decimal.Zero;
            Vl_desconto = decimal.Zero;
            Freteporconta = string.Empty;
            Vl_totalservico = decimal.Zero;
            Vl_basecalcicms = decimal.Zero;
            Vl_icms = decimal.Zero;
        }
    }

    public class TCD_NFServicos : TDataQuery
    {
        public TCD_NFServicos()
        { }

        public TCD_NFServicos(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, a.nr_lanctofiscal as nr_lancto, a.Tp_Movimento, a.Tp_Nota, a.CD_Clifor, ");
            sql.AppendLine("a.CD_Endereco, a.CD_Modelo, a.ST_Registro, a.Nr_Serie, '' as nr_subserie, ");
            sql.AppendLine("a.Nr_NotaFiscal, a.Chave_Acesso_NFE, a.DT_Emissao, ");
            sql.AppendLine("a.DT_SaiEnt, '0' as TP_CTe, '' as Ch_CTe_Ref, ");
            sql.AppendLine("a.Vl_totalnota, a.vl_desconto, a.FreteporConta, a.Vl_totalservicos, ");
            sql.AppendLine("Vl_totalbasecalcicms = isnull((select sum(isnull(x.Vl_BaseCalcICMS, 0)) ");
            sql.AppendLine("							from TB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("							where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("							and x.nr_lanctofiscal = a.nr_lanctofiscal), 0), ");
            sql.AppendLine("Vl_totalicms = isnull((select sum(isnull(x.VL_ICMS, 0)) ");
            sql.AppendLine("							from TB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("							where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("							and x.nr_lanctofiscal = a.nr_lanctofiscal), 0), ");
            sql.AppendLine("Cd_contactb_sped = (select top 1 y.CD_Conta_CTB ");
            sql.AppendLine("                    from tb_fat_notafiscal_item x ");
            sql.AppendLine("                    inner join TB_CTB_LanctosCTB y ");
            sql.AppendLine("                    on y.Id_LoteCTB = x.id_lotectb_fat ");
            sql.AppendLine("                    where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("                    and x.nr_lanctofiscal = a.nr_lanctofiscal), ");
            sql.AppendLine("'' as Cd_cidade_ini, '' as Cd_cidade_fin, 'NFF' as tp_registro ");

            sql.AppendLine("from VTB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join TB_FIS_Movimentacao mov ");
            sql.AppendLine("on a.cd_movimentacao = mov.cd_movimentacao ");

            sql.AppendLine("where a.CD_Modelo in('07', '08', '8B', '09', '10', '11', '26', '27', '57') ");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");

            sql.AppendLine("union all ");

            sql.AppendLine("select a.cd_empresa, a.nr_lanctoCTR as nr_lancto, a.tp_movimento, 'T' as tp_nota, a.CD_Transportadora, ");
            sql.AppendLine("a.Cd_EndTransportadora, b.CD_Modelo, a.ST_Registro, a.Nr_Serie, '' as nr_subserie, ");
            sql.AppendLine("a.NR_CTRC, a.chaveacesso as chave_acesso_nfe, a.DT_Emissao, ");
            sql.AppendLine("a.DT_SaiEnt, isnull(a.tp_cte, '0') as TP_CTe, '' as Ch_CTe_Ref, ");
            sql.AppendLine("a.Vl_Frete, 0 as vl_desconto, case when a.TP_Tomador = '0' then '1' else '2' end as TP_Frete, ");
            sql.AppendLine("a.Vl_Frete, a.Vl_BaseCalcICMS, a.Vl_ICMS, ");
            sql.AppendLine("Cd_contactb_sped = (select x.CD_Conta_CTB ");
            sql.AppendLine("					from TB_CTB_LanctosCTB x ");
            sql.AppendLine("					where x.Id_LoteCTB = a.id_lotectb ");
            sql.AppendLine("					and x.d_c = case when a.tp_movimento = 'E' then 'D' else 'C' end), ");
            sql.AppendLine("Cd_cidade_ini = (select y.cd_cidade ");
            sql.AppendLine("					from tb_fin_endereco x ");
            sql.AppendLine("					inner join tb_fin_cidade y ");
            sql.AppendLine("					on x.cd_cidade = y.cd_cidade ");
            sql.AppendLine("					and x.cd_clifor = a.cd_remetente ");
            sql.AppendLine("					and x.cd_endereco = a.cd_endremetente), ");
            sql.AppendLine("Cd_cidade_fin = (select y.cd_cidade ");
            sql.AppendLine("					from tb_fin_endereco x ");
            sql.AppendLine("					inner join tb_fin_cidade y ");
            sql.AppendLine("					on x.cd_cidade = y.cd_cidade ");
            sql.AppendLine("					and x.cd_clifor = a.Cd_Destinatario ");
            sql.AppendLine("					and x.cd_endereco = a.Cd_EndDestinatario), 'CTR' as tp_registro ");

            sql.AppendLine("from VTB_CTR_CONHECIMENTOFRETE a ");
            sql.AppendLine("inner join TB_FAT_SerieNF b ");
            sql.AppendLine("on a.Nr_Serie = b.Nr_Serie ");
            sql.AppendLine("and a.cd_modelo = b.cd_modelo ");
            sql.AppendLine("inner join TB_FIS_Movimentacao mov ");
            sql.AppendLine("on a.cd_movimentacao = mov.cd_movimentacao ");

            sql.AppendLine("where isnull(a.st_registro, 'A') = 'P' ");
            sql.AppendLine("and b.CD_Modelo in('07', '08', '8B', '09', '10', '11', '26', '27', '57') ");

            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");

            return sql.ToString();
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca), null);
        }

        public List<TRegistro_NFServicos> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_NFServicos> lista = new List<TRegistro_NFServicos>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_NFServicos reg = new TRegistro_NFServicos();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_lancto")))
                        reg.Nr_lancto = reader.GetDecimal(reader.GetOrdinal("nr_lancto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("Tp_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Tp_Nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("Tp_Nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_registro")))
                        reg.Tp_registro = reader.GetString(reader.GetOrdinal("tp_registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("Cd_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("Nr_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_subserie")))
                        reg.Nr_subserie = reader.GetString(reader.GetOrdinal("nr_subserie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Nr_NotaFiscal")))
                        reg.Nr_notafiscal = reader.GetDecimal(reader.GetOrdinal("Nr_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_NFE")))
                        reg.Chave_acesso = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFE"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_CTe")))
                        reg.Tp_cte = reader.GetString(reader.GetOrdinal("TP_CTe"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ch_CTe_Ref")))
                        reg.Chave_cte_refenciado = reader.GetString(reader.GetOrdinal("Ch_CTe_Ref"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalnota")))
                        reg.Vl_totalnota = reader.GetDecimal(reader.GetOrdinal("Vl_totalnota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_desconto")))
                        reg.Vl_desconto = reader.GetDecimal(reader.GetOrdinal("vl_desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FreteporConta")))
                        reg.Freteporconta = reader.GetString(reader.GetOrdinal("FreteporConta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalservicos")))
                        reg.Vl_totalservico = reader.GetDecimal(reader.GetOrdinal("Vl_totalservicos"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalbasecalcicms")))
                        reg.Vl_basecalcicms = reader.GetDecimal(reader.GetOrdinal("Vl_totalbasecalcicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_totalicms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_totalicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_contactb_sped")))
                        reg.Cd_contactb_sped = reader.GetDecimal(reader.GetOrdinal("Cd_contactb_sped"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cidade_ini")))
                        reg.Cd_cidade_ini = reader.GetString(reader.GetOrdinal("Cd_cidade_ini"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cidade_fin")))
                        reg.Cd_cidade_fin = reader.GetString(reader.GetOrdinal("Cd_cidade_fin"));

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

    #region AnaliticoServicos
    
    public class TRegistro_AnaliticoServicos
    {
        
        public string Cd_st
        { get; set; }
        
        public string Cd_cfop
        { get; set; }
        
        public decimal Pc_aliquotaicms
        { get; set; }
        
        public decimal Vl_operacao
        { get; set; }
        
        public decimal Vl_basecalcicms
        { get; set; }
        
        public decimal Vl_icms
        { get; set; }
        
        public decimal Vl_reducaobasecalc
        { get; set; }

        public TRegistro_AnaliticoServicos()
        {
            Cd_st = string.Empty;
            Cd_cfop = string.Empty;
            Pc_aliquotaicms = decimal.Zero;
            Vl_operacao = decimal.Zero;
            Vl_basecalcicms = decimal.Zero;
            Vl_icms = decimal.Zero;
            Vl_reducaobasecalc = decimal.Zero;
        }
    }

    public class TCD_AnaliticoServicos : TDataQuery
    {
        public TCD_AnaliticoServicos()
        { }

        public TCD_AnaliticoServicos(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Nr_lancto,
                                    bool St_nf)
        {
            StringBuilder sql = new StringBuilder();
            if (St_nf)
            {
                sql.AppendLine("select a.CD_ST_ICMS as cd_st, a.cd_cfop, a.Pc_aliquotaICMS, ");
                sql.AppendLine("isnull(sum(isnull(a.vl_contabil,0)),0) as VL_Operacao, ");
                sql.AppendLine("isnull(sum(ISNULL(a.Vl_BaseCalcICMS, 0)),0) as Vl_basecalcicms, ");
                sql.AppendLine("isnull(sum(isnull(a.Vl_ICMS, 0)),0) as vl_ICMS, ");
                sql.AppendLine("isnull(sum(isnull(a.Vl_SubTotal, 0) - isnull(a.Vl_BaseCalcICMS,0)),0) as Vl_Red_BaseCalc ");

                sql.AppendLine("FROM VTB_FAT_NOTAFISCAL_ITEM a ");

                sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
                sql.AppendLine("and a.nr_lanctofiscal = " + Nr_lancto);

                sql.AppendLine("GROUP BY a.CD_ST_ICMS, a.cd_cfop, a.Pc_aliquotaICMS ");
            }
            else
            {
                sql.AppendLine("select a.cd_st, a.CD_CFOP, a.PC_AliquotaICMS, ");
                sql.AppendLine("a.Vl_Frete as vl_operacao, a.Vl_BaseCalcICMS, a.Vl_ICMS, ");
                sql.AppendLine("(a.Vl_Frete - a.Vl_BaseCalcICMS) as vl_red_basecalc ");

                sql.AppendLine("from VTB_CTR_CONHECIMENTOFRETE a ");

                sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
                sql.AppendLine("and a.nr_lanctoCTR = " + Nr_lancto);
            }

            return sql.ToString();
        }

        public List<TRegistro_AnaliticoServicos> Select(string Cd_empresa,
                                                        string Nr_lancto,
                                                        bool St_nf)
        {
            List<TRegistro_AnaliticoServicos> lista = new List<TRegistro_AnaliticoServicos>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Nr_lancto, St_nf));
            try
            {
                while (reader.Read())
                {
                    TRegistro_AnaliticoServicos reg = new TRegistro_AnaliticoServicos();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_st")))
                        reg.Cd_st = reader.GetString(reader.GetOrdinal("cd_st"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_cfop")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("cd_cfop"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Pc_aliquotaicms")))
                        reg.Pc_aliquotaicms = reader.GetDecimal(reader.GetOrdinal("Pc_aliquotaicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_Operacao")))
                        reg.Vl_operacao = reader.GetDecimal(reader.GetOrdinal("VL_Operacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcicms")))
                        reg.Vl_basecalcicms = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_ICMS")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("vl_ICMS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Red_BaseCalc")))
                        reg.Vl_reducaobasecalc = reader.GetDecimal(reader.GetOrdinal("Vl_Red_BaseCalc"));

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

    #region Apuracao ICMS
    
    public class TRegistro_ApuracaoICMS
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal Vl_tot_debitos
        { get; set; }
        
        public decimal Vl_tot_aj_debitos
        { get; set; }
        
        public decimal Vl_estorno_cred
        { get; set; }
        
        public decimal Vl_tot_creditos
        { get; set; }
        
        public decimal Vl_tot_aj_creditos
        { get; set; }
        
        public decimal Vl_estorno_deb
        { get; set; }
        
        public decimal Vl_sld_credor_ant
        { get; set; }
        
        public decimal Vl_tot_deducoes
        { get; set; }
        
        public decimal Vl_tot_deb_especiais
        { get; set; }

        public TRegistro_ApuracaoICMS()
        {
            Cd_empresa = string.Empty;
            Vl_tot_debitos = decimal.Zero;
            Vl_tot_aj_debitos = decimal.Zero;
            Vl_estorno_cred = decimal.Zero;
            Vl_tot_creditos = decimal.Zero;
            Vl_tot_aj_creditos = decimal.Zero;
            Vl_estorno_deb = decimal.Zero;
            Vl_sld_credor_ant = decimal.Zero;
            Vl_tot_deducoes = decimal.Zero;
            Vl_tot_deb_especiais = decimal.Zero;
        }
    }

    public class TCD_ApuracaoICMS : TDataQuery
    {
        public TCD_ApuracaoICMS()
        { }

        public TCD_ApuracaoICMS(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    DateTime? Dt_ini,
                                    DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.cd_empresa, ");
            sql.AppendLine("VL_TOT_DEBITOS = ISNULL((select SUM(ISNULL(y.Vl_ICMS, 0)) ");
            sql.AppendLine("						from TB_FAT_NOTAFISCAL x ");
            sql.AppendLine("                        inner join TB_FAT_NotaFiscal_Item y ");
            sql.AppendLine("                        on x.CD_Empresa = y.cd_empresa ");
            sql.AppendLine("                        and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("						where x.Tp_Movimento = 'S' ");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("						and x.CD_Empresa = a.cd_empresa ");
            sql.AppendLine("						and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Emissao))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.CD_Modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22') ");
            sql.AppendLine("                        and case when x.cd_modelo = '55' and x.tp_nota = 'P' then (select top 1 1 from tb_fat_lotenfe_x_notafiscal w where w.cd_empresa = x.cd_empresa and w.nr_lanctofiscal = x.nr_lanctofiscal and w.status = 100) else 1 end = 1), 0) + ");
            sql.AppendLine("				 ISNULL((select SUM(ISNULL(y.Vl_ICMS, 0)) ");
            sql.AppendLine("						from TB_PDV_NFCe x ");
            sql.AppendLine("						inner join TB_PDV_NFCe_Item y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Id_nfce = y.Id_nfce ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("						and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Emissao))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("                        and case when x.cd_modelo = '65' then (select top 1 1 from tb_fat_lote_x_nfce w where x.cd_empresa = x.cd_empresa and w.id_cupom = y.id_nfce and w.status in(100, 150)) else 1 end = 1), 0), ");

            sql.AppendLine("VL_TOT_AJ_DEBITOS = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'D' ");
            sql.AppendLine("                        and SUBSTRING(x.cd_ajuste, 3, 2) = '00' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.ST_ICMS = 0), 0), ");

            sql.AppendLine("VL_ESTORNO_CRED = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'D' ");
            sql.AppendLine("                        and SUBSTRING(x.cd_ajuste, 3, 2) = '01' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.ST_ICMS = 0), 0), ");

            sql.AppendLine("VL_TOT_CREDITOS = ISNULL((select SUM(case when st.ST_SubstTrib = 'S' then 0 else ISNULL(y.Vl_ICMS, 0) end) ");
            sql.AppendLine("						from TB_FAT_NOTAFISCAL x ");
            sql.AppendLine("                        inner join TB_FAT_NotaFiscal_Item y ");
            sql.AppendLine("                        on x.cd_empresa = y.cd_empresa ");
            sql.AppendLine("                        and x.nr_lanctofiscal = y.nr_lanctofiscal ");
            sql.AppendLine("                        inner join TB_FIS_SitTribut st ");
            sql.AppendLine("                        on y.CD_ST_ICMS = st.CD_ST ");
            sql.AppendLine("                        and y.CD_ICMS = st.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and x.CD_Modelo in('01', '1B', '04', '55', '02', '2D', '06', '29', '28', '07', '08', '8B', '09', '10', '11', '26', '27', '57', '21', '22') ");
            sql.AppendLine("						and x.Tp_Movimento = 'E' ");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("						and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_SaiEnt))) between '" + Dt_ini.Value.ToString("yyyyMMdd") +"' and '" + Dt_fin.Value.ToString("yyyyMMdd") +"' ");
            sql.AppendLine("                        and case when x.cd_modelo = '55' and x.tp_nota = 'P' then (select top 1 1 from tb_fat_lotenfe_x_notafiscal w where w.cd_empresa = x.cd_empresa and w.nr_lanctofiscal = x.nr_lanctofiscal and w.status = 100) else 1 end = 1), 0) + ");
            sql.AppendLine("				  ISNULL((select SUM(isnull(x.Vl_ICMS, 0)) ");
            sql.AppendLine("						from VTB_CTR_CONHECIMENTOFRETE x ");
            sql.AppendLine("						inner join TB_FAT_SerieNF y ");
            sql.AppendLine("						on x.Nr_Serie = y.Nr_Serie ");
            sql.AppendLine("                        and x.cd_modelo = y.cd_modelo ");
            sql.AppendLine("						where ISNULL(x.ST_Registro, 'A') = 'P' ");
            sql.AppendLine("						and x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_SaiEnt))) between '" + Dt_ini.Value.ToString("yyyyMMdd") +"' and '" + Dt_fin.Value.ToString("yyyyMMdd") +"' ");
            sql.AppendLine("						and y.CD_Modelo in('07', '08', '8B', '09', '10', '11', '26', '27', '57')), 0), ");

            sql.AppendLine("VL_TOT_AJ_CREDITOS = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'C' ");
            sql.AppendLine("                        and SUBSTRING(x.cd_ajuste, 3, 2) = '02' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.ST_ICMS = 0), 0), ");
            sql.AppendLine("VL_ESTORNO_DEB = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'C' ");
            sql.AppendLine("                        and SUBSTRING(x.cd_ajuste, 3, 2) = '03' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.ST_ICMS = 0), 0), ");
            sql.AppendLine("VL_SLD_CREDOR_ANT = ISNULL((select top 1 x.Vl_Credito ");
            sql.AppendLine("						from TB_FIS_LoteImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and y.ST_ICMS = 0 ");
            sql.AppendLine("						order by x.DT_Lote desc), 0), ");
            sql.AppendLine("VL_TOT_DEDUCOES = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'D' ");
            sql.AppendLine("                        and SUBSTRING(x.cd_ajuste, 3, 2) = '04' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.ST_ICMS = 0), 0), ");
            sql.AppendLine("VL_TOT_DEB_ESPECIAIS = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'D' ");
            sql.AppendLine("                        and SUBSTRING(x.cd_ajuste, 3, 2) = '05' ");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.ST_ICMS = 0), 0) ");

            sql.AppendLine("from TB_DIV_Empresa a ");

            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");

            return sql.ToString();
        }

        public List<TRegistro_ApuracaoICMS> Select(string Cd_empresa,
                                                   DateTime? Dt_ini,
                                                   DateTime? Dt_fin)
        {
            List<TRegistro_ApuracaoICMS> lista = new List<TRegistro_ApuracaoICMS>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ApuracaoICMS reg = new TRegistro_ApuracaoICMS();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_DEBITOS")))
                        reg.Vl_tot_debitos = reader.GetDecimal(reader.GetOrdinal("VL_TOT_DEBITOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_AJ_DEBITOS")))
                        reg.Vl_tot_aj_debitos = reader.GetDecimal(reader.GetOrdinal("VL_TOT_AJ_DEBITOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ESTORNO_CRED")))
                        reg.Vl_estorno_cred = reader.GetDecimal(reader.GetOrdinal("VL_ESTORNO_CRED"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_CREDITOS")))
                        reg.Vl_tot_creditos = reader.GetDecimal(reader.GetOrdinal("VL_TOT_CREDITOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_AJ_CREDITOS")))
                        reg.Vl_tot_aj_creditos = reader.GetDecimal(reader.GetOrdinal("VL_TOT_AJ_CREDITOS"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_ESTORNO_DEB")))
                        reg.Vl_estorno_deb = reader.GetDecimal(reader.GetOrdinal("VL_ESTORNO_DEB"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_SLD_CREDOR_ANT")))
                        reg.Vl_sld_credor_ant = reader.GetDecimal(reader.GetOrdinal("VL_SLD_CREDOR_ANT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_DEDUCOES")))
                        reg.Vl_tot_deducoes = reader.GetDecimal(reader.GetOrdinal("VL_TOT_DEDUCOES"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_DEB_ESPECIAIS")))
                        reg.Vl_tot_deb_especiais = reader.GetDecimal(reader.GetOrdinal("VL_TOT_DEB_ESPECIAIS"));

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

    #region DadosIPI
    
    public class TRegistro_DadosIPI
    {
        
        public string Cd_cfop
        { get; set; }
        
        public string Cd_stIPI
        { get; set; }
        
        public decimal Vl_contabil
        { get; set; }
        
        public decimal Vl_basecalcIPI
        { get; set; }
        
        public decimal Vl_IPI
        { get; set; }

        public TRegistro_DadosIPI()
        {
            Cd_cfop = string.Empty;
            Cd_stIPI = string.Empty;
            Vl_contabil = decimal.Zero;
            Vl_basecalcIPI = decimal.Zero;
            Vl_IPI = decimal.Zero;
        }
    }

    public class TCD_DadosIPI : TDataQuery
    {
        public TCD_DadosIPI()
        { }

        public TCD_DadosIPI(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select b.CD_CFOP, b.Cd_StIPI, ");
            sql.AppendLine("Vl_Contabil = ISNULL(SUM(ISNULL(b.vl_contabil, 0)), 0), ");
            sql.AppendLine("Vl_basecalcipi = ISNULL(SUM(ISNULL(b.Vl_basecalcipi, 0)), 0), ");
            sql.AppendLine("Vl_ipi = ISNULL(SUM(ISNULL(b.Vl_ipi, 0)), 0) ");

            sql.AppendLine("from VTB_FAT_NOTAFISCAL a ");
            sql.AppendLine("inner join VTB_FAT_NOTAFISCAL_ITEM b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("and a.Nr_LanctoFiscal = b.Nr_LanctoFiscal ");

            sql.AppendLine("where b.Vl_ipi > 0 ");
            sql.AppendLine("and ISNULL(a.ST_Registro, 'A') = 'A' ");

            string cond = " and ";
            if (filtro != null)
                for (int i = 0; i < filtro.Length; i++)
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + " )");

            sql.AppendLine("group by b.CD_CFOP, b.Cd_StIPI ");

            return sql.ToString();
        }

        public List<TRegistro_DadosIPI> Select(Utils.TpBusca[] filtro)
        {
            List<TRegistro_DadosIPI> lista = new List<TRegistro_DadosIPI>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_DadosIPI reg = new TRegistro_DadosIPI();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_StIPI")))
                        reg.Cd_stIPI = reader.GetString(reader.GetOrdinal("Cd_StIPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Contabil")))
                        reg.Vl_contabil = reader.GetDecimal(reader.GetOrdinal("Vl_Contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_basecalcipi")))
                        reg.Vl_basecalcIPI = reader.GetDecimal(reader.GetOrdinal("Vl_basecalcipi"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_ipi")))
                        reg.Vl_IPI = reader.GetDecimal(reader.GetOrdinal("Vl_ipi"));

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

    #region Apuracao IPI
    
    public class TRegistro_ApuracaoIPI
    {
        
        public string Cd_empresa
        { get; set; }
        
        public decimal Vl_sld_credor_ant
        { get; set; }
        
        public decimal Vl_tot_debito
        { get; set; }
        
        public decimal Vl_tot_credito
        { get; set; }
        
        public decimal Vl_od_ipi
        { get; set; }
        
        public decimal Vl_oc_ipi
        { get; set; }

        public TRegistro_ApuracaoIPI()
        {
            Cd_empresa = string.Empty;
            Vl_sld_credor_ant = decimal.Zero;
            Vl_tot_debito = decimal.Zero;
            Vl_tot_credito = decimal.Zero;
            Vl_od_ipi = decimal.Zero;
            Vl_oc_ipi = decimal.Zero;
        }
    }

    public class TCD_ApuracaoIPI : TDataQuery
    {
        public TCD_ApuracaoIPI()
        { }

        public TCD_ApuracaoIPI(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    DateTime? Dt_ini,
                                    DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, ");
            sql.AppendLine("VL_SLD_CREDOR_ANT = ISNULL((select top 1 x.Vl_Credito ");
            sql.AppendLine("						from TB_FIS_LoteImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and y.ST_IPI = 0 ");
            sql.AppendLine("						order by x.DT_Lote desc), 0), ");
            sql.AppendLine("VL_TOT_DEBITO = ISNULL((select SUM(ISNULL(x.Vl_totalipi, 0)) ");
            sql.AppendLine("						from VTB_FAT_NOTAFISCAL x ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.Tp_Movimento = 'S' ");
            sql.AppendLine("						and x.DT_Emissao >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'");
            sql.AppendLine("						and x.DT_Emissao <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A'), 0), ");
            sql.AppendLine("VL_TOT_CREDITO = ISNULL((select SUM(ISNULL(x.Vl_totalipi, 0)) ");
            sql.AppendLine("						from VTB_FAT_NOTAFISCAL x ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.Tp_Movimento = 'E' ");
            sql.AppendLine("						and x.DT_SaiEnt >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'");
            sql.AppendLine("						and x.DT_SaiEnt <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A'), 0), ");
            sql.AppendLine("VL_OD_IPI = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'D' ");
            sql.AppendLine("						and x.DT_Lancto >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'");
            sql.AppendLine("						and x.DT_Lancto <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'");
            sql.AppendLine("						and y.ST_IPI = 0), 0), ");
            sql.AppendLine("VL_OC_IPI = ISNULL((select SUM(ISNULL(x.Vl_Lancto, 0)) ");
            sql.AppendLine("						from TB_FIS_LanctoImposto x ");
            sql.AppendLine("						inner join TB_FIS_Imposto y ");
            sql.AppendLine("						on x.CD_Imposto = y.CD_Imposto ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("                        and x.D_C = 'C' ");
            sql.AppendLine("						and x.DT_Lancto >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_ini.Value.ToString("yyyyMMdd")) + " 00:00:00'");
            sql.AppendLine("						and x.DT_Lancto <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_fin.Value.ToString("yyyyMMdd")) + " 23:59:59'");
            sql.AppendLine("						and y.ST_IPI = 0), 0) ");

            sql.AppendLine("from TB_DIV_Empresa a ");
            sql.AppendLine("where a.cd_empresa = '" + Cd_empresa.Trim() + "'");
            
            return sql.ToString();
        }

        public List<TRegistro_ApuracaoIPI> Select(string Cd_empresa,
                                               DateTime? Dt_ini,
                                               DateTime? Dt_fin)
        {
            List<TRegistro_ApuracaoIPI> lista = new List<TRegistro_ApuracaoIPI>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa,
                                                                                              Dt_ini,
                                                                                              Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_ApuracaoIPI reg = new TRegistro_ApuracaoIPI();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_SLD_CREDOR_ANT")))
                        reg.Vl_sld_credor_ant = reader.GetDecimal(reader.GetOrdinal("VL_SLD_CREDOR_ANT"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_DEBITO")))
                        reg.Vl_tot_debito = reader.GetDecimal(reader.GetOrdinal("VL_TOT_DEBITO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_TOT_CREDITO")))
                        reg.Vl_tot_credito = reader.GetDecimal(reader.GetOrdinal("VL_TOT_CREDITO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_OD_IPI")))
                        reg.Vl_od_ipi = reader.GetDecimal(reader.GetOrdinal("VL_OD_IPI"));
                    if (!reader.IsDBNull(reader.GetOrdinal("VL_OC_IPI")))
                        reg.Vl_oc_ipi = reader.GetDecimal(reader.GetOrdinal("VL_OC_IPI"));

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

    #region Inventario Estoque
    
    public class TRegistro_Inventario
    {
        
        public string Cd_produto
        { get; set; }
        
        public string Cd_unidade
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Vl_medio
        { get; set; }
        public decimal Vl_custo
        { get { return Quantidade * Vl_medio; } }
        public string Cd_conta
        { get; set; }

        public TRegistro_Inventario()
        {
            Cd_produto = string.Empty;
            Cd_unidade = string.Empty;
            Quantidade = decimal.Zero;
            Vl_medio = decimal.Zero;
            Cd_conta = string.Empty;
        }
    }

    public class TCD_Inventario : TDataQuery
    {
        public TCD_Inventario()
        { }

        public TCD_Inventario(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    DateTime? Dt_movimento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select a.CD_Produto, a.cd_unidade, ");
            sql.AppendLine("quantidade = ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ");
            sql.AppendLine("					from TB_EST_Estoque x ");
            sql.AppendLine("					where x.CD_Produto = a.CD_Produto ");
            sql.AppendLine("					and ISNULL(x.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("					and x.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("					and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '" + Dt_movimento.Value.ToString("yyyyMMdd") +"' ), 0), ");
            sql.AppendLine("vl_medio = case when dbo.F_CUSTO_MEDIOESTOQUE('" + Cd_empresa.Trim()  + "' , a.CD_Produto, '" + Dt_movimento.Value.ToString("yyyyMMdd") +"') = 0 then ");
            sql.AppendLine("                (select x.vl_medio ");
            sql.AppendLine("                from vtb_est_vlestoque x ");
            sql.AppendLine("                where x.cd_produto = a.cd_produto ");
            sql.AppendLine("                and x.cd_empresa = '" + Cd_empresa.Trim() + "') else ");
            sql.AppendLine("                dbo.F_CUSTO_MEDIOESTOQUE('" + Cd_empresa.Trim() + "' , a.CD_Produto, '" + Dt_movimento.Value.ToString("yyyyMMdd") + "') end, ");
            sql.AppendLine("cd_conta = (select top 1 x.Vl_String ");
            sql.AppendLine("            from TB_CFG_ParamGer x ");
            sql.AppendLine("            inner join TB_CFG_ParamGer_X_Empresa y ");
            sql.AppendLine("            on x.Id_Parametro = y.id_parametro ");
            sql.AppendLine("            where y.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("            and x.ds_parametro = 'CD_CONTA_ESTOQUE') ");
            sql.AppendLine("from TB_EST_Produto a ");
            sql.AppendLine("inner join TB_EST_TpProduto b ");
            sql.AppendLine("on a.TP_Produto = b.TP_Produto ");
            sql.AppendLine("inner join TB_EST_Unidade c ");
            sql.AppendLine("on a.CD_Unidade = c.CD_Unidade ");

            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("and ISNULL(b.ST_Servico, 'N') <> 'S' ");

            sql.AppendLine("order by a.cd_produto ");

            return sql.ToString();
        }

        public List<TRegistro_Inventario> Select(string Cd_empresa,
                                               DateTime? Dt_movimento)
        {
            List<TRegistro_Inventario> lista = new List<TRegistro_Inventario>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa,
                                                                                              Dt_movimento));
            try
            {
                while (reader.Read())
                {
                    TRegistro_Inventario reg = new TRegistro_Inventario();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_unidade")))
                        reg.Cd_unidade = reader.GetString(reader.GetOrdinal("cd_unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_medio")))
                        reg.Vl_medio = reader.GetDecimal(reader.GetOrdinal("vl_medio"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conta")))
                        reg.Cd_conta = reader.GetString(reader.GetOrdinal("cd_conta"));

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

    #region Movimentacao Combustivel
    
    public class TRegistro_MovCombustivel
    {
        
        public string Cd_produto
        { get; set; }
        
        public DateTime? Dt_movimento
        { get; set; }
        
        public decimal Vol_abertura
        { get; set; }
        
        public decimal Vol_recebido
        { get; set; }
        public decimal Vol_disponivel
        { get { return Vol_abertura + Vol_recebido; } }
        
        public decimal Vol_venda
        { get; set; }
        public decimal Est_escritural
        { get { return Vol_disponivel - Vol_venda; } }
        
        public decimal Vol_fechamento
        { get; set; }
        public decimal Vol_perda
        { get { return Vol_fechamento < Est_escritural ? Est_escritural - Vol_fechamento : decimal.Zero; } }
        public decimal Vol_ganho
        { get { return Vol_fechamento > Est_escritural ? Vol_fechamento - Est_escritural : decimal.Zero; } }

        public TRegistro_MovCombustivel()
        {
            Cd_produto = string.Empty;
            Dt_movimento = null;
            Vol_abertura = decimal.Zero;
            Vol_recebido = decimal.Zero;
            Vol_venda = decimal.Zero;
            Vol_fechamento = decimal.Zero;
        }
    }

    public class TCD_MovCombustivel : TDataQuery
    {
        public TCD_MovCombustivel()
        { }

        public TCD_MovCombustivel(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa, DateTime? Dt_ini, DateTime? Dt_fin)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select c.CD_Produto, CAST(a.DT_Abastecimento as Date) as DT_Abastecimento, ");
            sql.AppendLine("vol_abertura = ISNULL((select sum(isnull(x.QTD_Combustivel, 0)) ");
            sql.AppendLine("						from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("						inner join TB_PDC_Tanque y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Id_Tanque = y.Id_Tanque ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and y.CD_Produto = c.CD_Produto ");
            sql.AppendLine("						and ((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = ");
            sql.AppendLine("						CAST(a.DT_Abastecimento as date) ");
            sql.AppendLine("						and x.TP_Medicao = 'A') or ");
            sql.AppendLine("						((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = ");
            sql.AppendLine("						DATEADD(day, -1, CAST(a.DT_Abastecimento as date)) ");
            sql.AppendLine("						and x.TP_Medicao = 'F')))), 0), ");
            sql.AppendLine("vol_recebido = ISNULL((select SUM(ISNULL(y.Quantidade, 0)) ");
            sql.AppendLine("						from TB_FAT_NotaFiscal x ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal_Item y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = y.Nr_LanctoFiscal ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal_CMI z ");
            sql.AppendLine("						on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
            sql.AppendLine("						where x.Tp_Movimento = 'E' ");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("						and x.Tp_Nota = 'T' ");
            sql.AppendLine("						and ISNULL(z.ST_Devolucao, 'N') <> 'S' ");
            sql.AppendLine("						and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_SaiEnt))) = ");
            sql.AppendLine("						CAST(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and y.CD_Produto = c.CD_Produto), 0), ");
            sql.AppendLine("vol_venda = ISNULL((select SUM(ISNULL(x.QTD_Encerrante, 0)) ");
            sql.AppendLine("						from TB_PDC_EncerranteBico x ");
            sql.AppendLine("						inner join TB_PDC_BicoBomba y ");
            sql.AppendLine("						on x.ID_Bico = y.ID_Bico ");
            sql.AppendLine("						inner join TB_PDC_Tanque z ");
            sql.AppendLine("						on y.cd_empresa = z.cd_empresa ");
            sql.AppendLine("						and y.id_tanque = z.id_tanque ");
            sql.AppendLine("						where z.cd_empresa = a.cd_empresa ");
            sql.AppendLine("						and z.cd_produto = c.cd_produto ");
            sql.AppendLine("						and cast(isnull(y.DT_Ativacao, getdate()) as DATE) <= cast(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and cast(isnull(y.DT_Desativacao, getdate()) as DATE) > cast(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and ((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = ");
            sql.AppendLine("						CAST(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and x.TP_Encerrante = 'F') or ");
            sql.AppendLine("						((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = ");
            sql.AppendLine("						DATEADD(day, 1, CAST(a.DT_Abastecimento as date)) ");
            sql.AppendLine("						and x.TP_Encerrante = 'A')))), 0) - ");
            sql.AppendLine("			ISNULL((select SUM(ISNULL(x.QTD_Encerrante, 0)) ");
            sql.AppendLine("						from TB_PDC_EncerranteBico x ");
            sql.AppendLine("						inner join TB_PDC_BicoBomba y ");
            sql.AppendLine("						on x.ID_Bico = y.ID_Bico ");
            sql.AppendLine("						inner join TB_PDC_Tanque z ");
            sql.AppendLine("						on y.cd_empresa = z.cd_empresa ");
            sql.AppendLine("						and y.id_tanque = z.id_tanque ");
            sql.AppendLine("						where z.cd_empresa = a.cd_empresa ");
            sql.AppendLine("						and z.cd_produto = c.cd_produto ");
            sql.AppendLine("						and cast(isnull(y.DT_Ativacao, getdate()) as DATE) <= cast(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and cast(isnull(y.DT_Desativacao, getdate()) as DATE) > cast(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and ((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = ");
            sql.AppendLine("						CAST(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and x.TP_Encerrante = 'A') or ");
            sql.AppendLine("						((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = ");
            sql.AppendLine("						DATEADD(day, -1, CAST(a.DT_Abastecimento as date)) ");
            sql.AppendLine("						and x.TP_Encerrante = 'F')))), 0) - ");
            sql.AppendLine("			ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("						from tb_pdc_vendacombustivel x ");
            sql.AppendLine("						where x.cd_empresa = a.cd_empresa ");
            sql.AppendLine("						and x.cd_produto = c.cd_produto ");
            sql.AppendLine("						and isnull(x.st_afericao, 'N') = 'S' ");
            sql.AppendLine("						and CAST(x.DT_Abastecimento as date) = CAST(a.DT_Abastecimento as date)), 0), ");
            sql.AppendLine("vol_fechamento = ISNULL((select sum(isnull(x.QTD_Combustivel, 0)) ");
            sql.AppendLine("						from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("						inner join TB_PDC_Tanque y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Id_Tanque = y.Id_Tanque ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and y.CD_Produto = c.CD_Produto ");
            sql.AppendLine("						and ((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = ");
            sql.AppendLine("						CAST(a.DT_Abastecimento as DATE) ");
            sql.AppendLine("						and x.TP_Medicao = 'F') or ");
            sql.AppendLine("						((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = ");
            sql.AppendLine("						DATEADD(day, 1, CAST(a.DT_Abastecimento as date)) ");
            sql.AppendLine("						and x.TP_Medicao = 'A')))), 0) ");
            
            sql.AppendLine("from TB_PDC_VendaCombustivel a ");
            sql.AppendLine("inner join TB_PDC_BicoBomba b ");
            sql.AppendLine("on a.ID_Bico = b.ID_Bico ");
            sql.AppendLine("inner join TB_PDC_Tanque c ");
            sql.AppendLine("on b.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("and b.Id_Tanque = c.Id_Tanque ");
            sql.AppendLine("inner join TB_EST_Produto d ");
            sql.AppendLine("on c.cd_produto = d.cd_produto ");
            sql.AppendLine("inner join TB_EST_TpProduto e ");
            sql.AppendLine("on d.tp_produto = e.tp_produto ");
            sql.AppendLine("and isnull(e.st_lubrificante, 'N') <> 'S' ");
            
            sql.AppendLine("where ISNULL(a.ST_Registro, 'A') <> 'C' ");
            sql.AppendLine("and a.cd_empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and convert(datetime, floor(convert(decimal(30,10), a.DT_Abastecimento))) ");
            sql.AppendLine("between '" + Dt_ini.Value.ToString("yyyyMMdd") + "' and '" + Dt_fin.Value.ToString("yyyyMMdd") + "'");

            sql.AppendLine("group by a.CD_Empresa, c.CD_Produto, CAST(a.DT_Abastecimento as Date) ");

            sql.AppendLine("order by CAST(a.DT_Abastecimento as Date), CD_Produto ");

            return sql.ToString();
        }

        public List<TRegistro_MovCombustivel> Select(string Cd_empresa,
                                                     DateTime? Dt_ini,
                                                     DateTime? Dt_fin)
        {
            List<TRegistro_MovCombustivel> lista = new List<TRegistro_MovCombustivel>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_ini, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovCombustivel reg = new TRegistro_MovCombustivel();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("dt_abastecimento")))
                        reg.Dt_movimento = reader.GetDateTime(reader.GetOrdinal("dt_abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_abertura")))
                        reg.Vol_abertura = reader.GetDecimal(reader.GetOrdinal("vol_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_recebido")))
                        reg.Vol_recebido = reader.GetDecimal(reader.GetOrdinal("vol_recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_venda")))
                        reg.Vol_venda = reader.GetDecimal(reader.GetOrdinal("vol_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_fechamento")))
                        reg.Vol_fechamento = reader.GetDecimal(reader.GetOrdinal("vol_fechamento"));

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

    #region Movimentacao Tanque
    
    public class TRegistro_MovTanque
    {
        
        public decimal? Id_tanque
        { get; set; }
        
        public decimal Vol_abertura
        { get; set; }
        
        public decimal Vol_recebido
        { get; set; }
        public decimal Vol_disponivel
        { get { return Vol_abertura + Vol_recebido; } }
        
        public decimal Vol_venda
        { get; set; }
        public decimal Est_escritural
        { get { return Vol_disponivel - Vol_venda; } }
        
        public decimal Vol_fechamento
        { get; set; }
        public decimal Vol_perda
        { get { return Vol_fechamento < Est_escritural ? Est_escritural - Vol_fechamento : decimal.Zero; } }
        public decimal Vol_ganho
        { get { return Vol_fechamento > Est_escritural ? Vol_fechamento - Est_escritural : decimal.Zero; } }

        public TRegistro_MovTanque()
        {
            Id_tanque = null;
            Vol_abertura = decimal.Zero;
            Vol_recebido = decimal.Zero;
            Vol_venda = decimal.Zero;
            Vol_fechamento = decimal.Zero;
        }
    }

    public class TCD_MovTanque : TDataQuery
    {
        public TCD_MovTanque()
        { }

        public TCD_MovTanque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    string Cd_produto,
                                    DateTime Dt_movimento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select Id_Tanque, ");
            sql.AppendLine("Vol_abertura = ISNULL((select top 1 x.QTD_Combustivel ");
            sql.AppendLine("						from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("						where x.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and x.Id_Tanque = a.Id_Tanque ");
            sql.AppendLine("						and ((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Medicao = 'A') or ");
            sql.AppendLine("						((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_movimento.AddDays(-1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Medicao = 'F'))) ");
            sql.AppendLine("						order by x.TP_Medicao), 0), ");
            sql.AppendLine("Vol_recebido = ISNULL((select SUM(ISNULL(y.Quantidade, 0)) ");
            sql.AppendLine("						from TB_FAT_NotaFiscal x ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal_Item y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = y.Nr_LanctoFiscal ");
            sql.AppendLine("						inner join TB_FAT_NotaFiscal_CMI z ");
            sql.AppendLine("						on x.CD_Empresa = z.CD_Empresa ");
            sql.AppendLine("						and x.Nr_LanctoFiscal = z.Nr_LanctoFiscal ");
            sql.AppendLine("						where x.Tp_Movimento = 'E' ");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') = 'A' ");
            sql.AppendLine("						and x.Tp_Nota = 'T' ");
            sql.AppendLine("						and ISNULL(z.ST_Devolucao, 'N') <> 'S' ");
            sql.AppendLine("						and CONVERT(datetime, floor(convert(decimal(30,10), x.DT_SaiEnt))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and y.CD_Produto = a.CD_Produto ");
            sql.AppendLine("						and y.CD_Local = a.CD_Local ");
            sql.AppendLine("						and y.CD_Empresa = a.CD_Empresa), 0), ");
            sql.AppendLine("vol_venda = ISNULL((select SUM(ISNULL(x.QTD_Encerrante, 0)) ");
            sql.AppendLine("						from TB_PDC_EncerranteBico x ");
            sql.AppendLine("						inner join TB_PDC_BicoBomba y ");
            sql.AppendLine("						on x.ID_Bico = y.ID_Bico ");
            sql.AppendLine("						where y.cd_empresa = a.cd_empresa ");
            sql.AppendLine("						and y.Id_Tanque = a.Id_Tanque ");
            sql.AppendLine("						and ((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'F') or ");
            sql.AppendLine("						((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.AddDays(1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'A'))) ");
            sql.AppendLine("                        and convert(datetime, floor(convert(decimal(30,10), isnull(y.DT_Ativacao, getdate())))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), isnull(y.DT_Desativacao, getdate())))) > '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0) - ");
            sql.AppendLine("			ISNULL((select SUM(ISNULL(x.QTD_Encerrante, 0)) ");
            sql.AppendLine("						from TB_PDC_EncerranteBico x ");
            sql.AppendLine("						inner join TB_PDC_BicoBomba y ");
            sql.AppendLine("						on x.ID_Bico = y.ID_Bico ");
            sql.AppendLine("						where y.cd_empresa = a.cd_empresa ");
            sql.AppendLine("						and y.Id_Tanque = a.Id_Tanque ");
            sql.AppendLine("						and ((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'A') or ");
            sql.AppendLine("						((convert(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.AddDays(-1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'F'))) ");
            sql.AppendLine("                        and convert(datetime, floor(convert(decimal(30,10), isnull(y.DT_Ativacao, getdate())))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), isnull(y.DT_Desativacao, getdate())))) > '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0) - ");
            sql.AppendLine("			ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("						from tb_pdc_vendacombustivel x ");
            sql.AppendLine("						inner join TB_PDC_BicoBomba y ");
            sql.AppendLine("						on x.id_bico = y.id_bico ");
            sql.AppendLine("						where y.cd_empresa = a.cd_empresa ");
            sql.AppendLine("						and y.id_tanque = a.id_tanque ");
            sql.AppendLine("						and isnull(x.st_afericao, 'N') = 'S' ");
            sql.AppendLine("						and CAST(x.DT_Abastecimento as date) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("                        and convert(datetime, floor(convert(decimal(30,10), isnull(y.DT_Ativacao, getdate())))) <= '" + Dt_movimento.ToString("yyyyMMdd") + "'");
            sql.AppendLine("						and convert(datetime, floor(convert(decimal(30,10), isnull(y.DT_Desativacao, getdate())))) > '" + Dt_movimento.ToString("yyyyMMdd") + "'), 0), ");
            sql.AppendLine("Vol_fechamento = ISNULL((select top 1 x.QTD_Combustivel ");
            sql.AppendLine("						from TB_PDC_MedicaoTanque x ");
            sql.AppendLine("						inner join TB_PDC_Tanque y ");
            sql.AppendLine("						on x.CD_Empresa = y.CD_Empresa ");
            sql.AppendLine("						and x.Id_Tanque = y.Id_Tanque ");
            sql.AppendLine("						where y.CD_Empresa = a.CD_Empresa ");
            sql.AppendLine("						and y.ID_Tanque = a.ID_Tanque ");
            sql.AppendLine("						and ((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Medicao = 'F') or ");
            sql.AppendLine("						((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Medicao))) = '" + Dt_movimento.AddDays(1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Medicao = 'A'))) ");
            sql.AppendLine("						order by x.TP_Medicao desc), 0) ");
            sql.AppendLine("from TB_PDC_Tanque a ");
            sql.AppendLine("where a.CD_Empresa = '" + Cd_empresa.Trim() + "' ");
            sql.AppendLine("and a.CD_Produto = '" + Cd_produto.Trim() + "' ");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_movimento.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_movimento.ToString("yyyyMMdd")) + "'");

            return sql.ToString();
        }

        public List<TRegistro_MovTanque> Select(string Cd_empresa, string Cd_produto, DateTime Dt_movimento)
        {
            List<TRegistro_MovTanque> lista = new List<TRegistro_MovTanque>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Cd_produto, Dt_movimento));
            try
            {
                while (reader.Read())
                {
                    TRegistro_MovTanque reg = new TRegistro_MovTanque();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_tanque")))
                        reg.Id_tanque = reader.GetDecimal(reader.GetOrdinal("id_tanque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_abertura")))
                        reg.Vol_abertura = reader.GetDecimal(reader.GetOrdinal("vol_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_recebido")))
                        reg.Vol_recebido = reader.GetDecimal(reader.GetOrdinal("vol_recebido"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_venda")))
                        reg.Vol_venda = reader.GetDecimal(reader.GetOrdinal("vol_venda"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_fechamento")))
                        reg.Vol_fechamento = reader.GetDecimal(reader.GetOrdinal("vol_fechamento"));

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

    #region VolumeVendas
    
    public class TRegistro_VolVendas
    {
        
        public decimal? Id_bico
        { get; set; }
        
        public decimal Vol_abertura
        { get; set; }
        
        public decimal Vol_fechamento
        { get; set; }
        
        public decimal Vol_afericao
        { get; set; }
        public decimal Vol_vendas
        { get { return Vol_fechamento - Vol_abertura - Vol_afericao; } }

        public TRegistro_VolVendas()
        {
            Id_bico = null;
            Vol_abertura = decimal.Zero;
            Vol_fechamento = decimal.Zero;
            Vol_afericao = decimal.Zero;
        }
    }

    public class TCD_VolVendas : TDataQuery
    {
        public TCD_VolVendas()
        { }

        public TCD_VolVendas(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Id_tanque,
                                    DateTime Dt_movimento)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.ID_Bico, ");
            sql.AppendLine("Vol_abertura = ISNULL((select top 1 x.QTD_Encerrante ");
            sql.AppendLine("						from TB_PDC_EncerranteBico x ");
            sql.AppendLine("						where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("						and ((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'A') or ");
            sql.AppendLine("						((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.AddDays(-1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'F'))) ");
            sql.AppendLine("						order by x.TP_Encerrante), 0), ");
            sql.AppendLine("Vol_fechamento = ISNULL((select top 1 x.QTD_Encerrante ");
            sql.AppendLine("						from TB_PDC_EncerranteBico x ");
            sql.AppendLine("						where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("						and ((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'F') or ");
            sql.AppendLine("						((CONVERT(datetime, floor(convert(decimal(30,10), x.DT_Encerrante))) = '" + Dt_movimento.AddDays(1).ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and x.TP_Encerrante = 'A'))) ");
            sql.AppendLine("						order by x.TP_Encerrante desc), 0), ");
            sql.AppendLine("Vol_afericao = ISNULL((select SUM(ISNULL(x.VolumeAbastecido, 0)) ");
            sql.AppendLine("						from TB_PDC_VendaCombustivel x ");
            sql.AppendLine("						where x.ID_Bico = a.ID_Bico ");
            sql.AppendLine("                        and convert(datetime, floor(convert(decimal(30,10), x.DT_Abastecimento))) = '" + Dt_movimento.ToString("yyyyMMdd") + "' ");
            sql.AppendLine("						and ISNULL(x.ST_Afericao, 'N') = 'S' ");
            sql.AppendLine("						and ISNULL(x.ST_Registro, 'A') <> 'C'), 0) ");
            sql.AppendLine("from TB_PDC_BicoBomba a ");
            sql.AppendLine("where Id_Tanque = " + Id_tanque);
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Ativacao, GETDATE())))) <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_movimento.ToString("yyyyMMdd")) + "'");
            sql.AppendLine("and CONVERT(datetime, floor(convert(decimal(30,10), ISNULL(a.DT_Desativacao, getdate())))) > '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Dt_movimento.ToString("yyyyMMdd")) + "'");

            return sql.ToString();
        }

        public List<TRegistro_VolVendas> Select(string Id_tanque, DateTime Dt_movimento)
        {
            List<TRegistro_VolVendas> lista = new List<TRegistro_VolVendas>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Id_tanque, Dt_movimento));
            try
            {
                while (reader.Read())
                {
                    TRegistro_VolVendas reg = new TRegistro_VolVendas();
                    if (!reader.IsDBNull(reader.GetOrdinal("id_bico")))
                        reg.Id_bico = reader.GetDecimal(reader.GetOrdinal("id_bico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_abertura")))
                        reg.Vol_abertura = reader.GetDecimal(reader.GetOrdinal("vol_abertura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_afericao")))
                        reg.Vol_afericao = reader.GetDecimal(reader.GetOrdinal("vol_afericao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vol_fechamento")))
                        reg.Vol_fechamento = reader.GetDecimal(reader.GetOrdinal("vol_fechamento"));

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

    #region Saldo Estoque
    public class TRegistro_SaldoEstoque
    {
        public string Cd_produto { get; set; } = string.Empty;
        public decimal Quantidade { get; set; } = decimal.Zero;
    }

    public class TCD_SaldoEstoque:TDataQuery
    {
        public TCD_SaldoEstoque()
        { }

        public TCD_SaldoEstoque(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(string Cd_empresa,
                                    DateTime Dt_fin)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("Select a.CD_Produto,  ")
                .AppendLine("quantidade = ISNULL((select SUM(ISNULL(x.QTD_Entrada, 0)) - SUM(ISNULL(x.QTD_Saida, 0)) ")
                .AppendLine("				from TB_EST_Estoque x ")
                .AppendLine("				where x.CD_Produto = a.CD_Produto ")
                .AppendLine("				and ISNULL(x.ST_Registro, 'A') <> 'C' ")
                .AppendLine("				and x.CD_Empresa = '" + Cd_empresa.Trim() + "'")
                .AppendLine("				and convert(datetime, floor(convert(decimal(30,10), x.DT_Lancto))) <= '" + Dt_fin.ToString("yyyyMMdd") + "'), 0) ")
                .AppendLine("from TB_EST_Produto a ")
                .AppendLine("inner join TB_EST_TpProduto b ")
                .AppendLine("on a.TP_Produto = b.TP_Produto ")
                .AppendLine("and isnull(a.st_registro, 'A') <> 'C' ")
                .AppendLine("and isnull(b.st_servico, 'N') <> 'S' ")
                .AppendLine("and a.tp_item <> '07' ")
                .AppendLine("and a.tp_item <> '08' ")
                .AppendLine("and a.tp_item <> '99' ")
                .AppendLine("and a.tp_item <> '09' ");

            return sql.ToString();
        }

        public List<TRegistro_SaldoEstoque> Select(string Cd_empresa, DateTime Dt_fin)
        {
            List<TRegistro_SaldoEstoque> lista = new List<TRegistro_SaldoEstoque>();
            bool st_transacao = false;
            if (Banco_Dados == null)
                st_transacao = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(Cd_empresa, Dt_fin));
            try
            {
                while (reader.Read())
                {
                    TRegistro_SaldoEstoque reg = new TRegistro_SaldoEstoque();
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_produto")))
                        reg.Cd_produto = reader.GetString(reader.GetOrdinal("cd_produto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("quantidade")))
                        reg.Quantidade = reader.GetDecimal(reader.GetOrdinal("quantidade"));

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
