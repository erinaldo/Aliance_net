using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Querys;
using Utils;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal.SPED
{
    public class TCD_SPEDFiscal : TDataQuery
    {
        private string SqlCodeParticipantes(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("a.CD_Clifor, b.NM_Clifor, b.NR_CGC, b.NR_CPF, c.Insc_Estadual, c.CD_Cidade, c.DS_Endereco, c.Numero, c.DS_Complemento, c.Bairro, c.CD_Pais ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            sql.AppendLine("INNER JOIN vTB_FIN_Clifor b ON a.CD_Clifor = b.CD_Clifor ");
            sql.AppendLine("INNER JOIN vTB_FIN_Endereco c ON b.CD_Clifor = c.CD_Clifor ");
            
            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectParticipantes(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeParticipantes(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[11];
                    
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    else
                        reg[1] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Pais"))))
                        reg[2] = reader.GetString(reader.GetOrdinal("CD_Pais"));
                    else
                        reg[2] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CGC"))))
                        reg[3] = reader.GetString(reader.GetOrdinal("NR_CGC"));
                    else
                        reg[3] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CPF"))))
                        reg[4] = reader.GetString(reader.GetOrdinal("NR_CPF"));
                    else
                        reg[4] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Insc_Estadual"))))
                        reg[5] = reader.GetString(reader.GetOrdinal("Insc_Estadual"));
                    else
                        reg[5] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Cidade"))))
                        reg[6] = reader.GetString(reader.GetOrdinal("CD_Cidade"));
                    else
                        reg[6] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Endereco"))))
                        reg[7] = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    else
                        reg[7] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Numero"))))
                        reg[8] = reader.GetString(reader.GetOrdinal("Numero"));
                    else
                        reg[8] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Complemento"))))
                        reg[9] = reader.GetString(reader.GetOrdinal("DS_Complemento"));
                    else
                        reg[9] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Bairro"))))
                        reg[10] = reader.GetString(reader.GetOrdinal("Bairro"));
                    else
                        reg[10] = "";
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

        private string SqlCodeUnidades(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("b.CD_Unidade, C.DS_Unidade ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal_Item b ON a.Nr_LanctoFiscal = b.Nr_LanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_EST_Unidade c ON b.CD_Unidade = c.CD_unidade ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectUnidades(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeUnidades(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[2];

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Unidade"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Unidade"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    else
                        reg[1] = "";
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

        private string SqlCodeItemsNota(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("    a.CD_Produto, c.DS_Produto, a.CD_Unidade, a.ID_NFItem, a.vl_desconto, a.vl_freteitema.Vl_Unitario, a.Vl_SubTotal, ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal_Item a ");
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal b ON a.Nr_LanctoFiscal = b.Nr_LanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_EST_Produto c ON a.CD_Produto = c.CD_Produto ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectItemsNota(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeItemsNota(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[0];

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("CD_Produto"));
                    else
                        reg[reg.Length - 1] = "";

                    Array.Resize(ref reg, reg.Length + 1);
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Produto"))))
                        reg[reg.Length - 1] = reader.GetString(reader.GetOrdinal("DS_Produto"));
                    else
                        reg[reg.Length - 1] = "";
                    
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

        private string SqlCodeFatorConversao(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("    a.CD_Unidade, (CASE WHEN d.ST_Fator = '/' THEN (1/VL_Indice) ELSE VL_Indice END) AS VL_Indice ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal_Item a ");
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal b ON a.Nr_LanctoFiscal = b.Nr_LanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_EST_Produto c ON a.CD_Produto = c.CD_Produto ");
            sql.AppendLine("INNER JOIN TB_EST_Converte_Unid d ON d.CD_Unidade_Orig = a.CD_Unidade AND d.CD_Unidade_Dest = c.CD_Unidade ");
            sql.AppendLine("WHERE a.CD_Unidade <> c.CD_Unidade ");

            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }

        public List<string[]> SelectFatorConversao(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeFatorConversao(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[2];

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Unidade"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Indice"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("VL_Indice"));
                    else
                        reg[1] = "";
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

        private string SqlCodeNaturezaOperacao(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("    a.CD_CFOP, b.DS_CFOP ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            sql.AppendLine("INNER JOIN TB_FIS_CFOP b ON a.CD_CFOP = b.CD_CFOP ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectNaturezaOperacao(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeNaturezaOperacao(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[2];

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CFOP"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CFOP"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    else
                        reg[1] = "";
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

        private string SqlCodeDadosAdicionais(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("    '000001' as CD_DadosAdicionais, a.DadosAdicionais, a.NR_LanctoFiscal ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectDadosAdicionais(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeDadosAdicionais(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[2];

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_DadosAdicionais"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_DadosAdicionais"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DadosAdicionais"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("DadosAdicionais"));
                    else
                        reg[1] = "";
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

        private string SqlCodeOBSFiscal(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("    b.CD_ObservacaoFiscal, c.DS_ObservacaoFiscal ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal_X_Observacao b ON a.NR_LanctoFiscal = b.NR_LanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_FIS_ObservacaoFiscal c ON b.CD_ObservacaoFiscal = c.CD_ObservacaoFiscal ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectOBSFiscal(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeOBSFiscal(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[2];

                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ObservacaoFiscal"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_ObservacaoFiscal"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ObservacaoFiscal"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("DS_ObservacaoFiscal"));
                    else
                        reg[1] = "";
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

        private string SqlCodeNotaFiscal(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT ");
            sql.AppendLine("    a.NR_LanctoFiscal, a.NR_NotaFiscal, CASE WHEN a.TP_Movimento = 'E' THEN '0' ELSE '1' END AS IND_OPER, ");
            sql.AppendLine("	CASE WHEN a.TP_Nota = 'P' THEN '0' ELSE '1' END AS IND_EMIT, a.CD_Clifor, a.CD_Modelo, a.CD_Sit, a.NR_Serie, a.Numero, a.Chave_Acesso_NFE, ");
            sql.AppendLine("	a.DT_Emissao, a.DT_SaiEnt, a.VL_TotalNota, ISNULL((SELECT CASE WHEN isnull(x.QT_Parcelas,0) = 1 THEN '0' ELSE '1' END  ");
            sql.AppendLine("												FROM TB_FIN_CondPGTO x WHERE x.CD_CondPGTO = a.CD_CondPGTO),'0') AS Cond_PAGTO, ");
            sql.AppendLine("	a.VL_Desconto, (SELECT SUM(x.VL_SubTotal) FROM TB_FAT_NotaFiscal_Item x WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) AS VL_SUBTotalProduto, ");
            sql.AppendLine("	(CASE WHEN a.FreteporConta = 'E' THEN '1' ELSE '2' END) as FretePorConta, a.VL_Frete, a.VL_Seguro, a.VL_OutrasDesp,  ");
            sql.AppendLine("	(SELECT SUM(x.Vl_BaseCalc_ICMS) FROM TB_FAT_NotaFiscal_Item x WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) AS VL_TotalBaseCalc, ");
            sql.AppendLine("	(SELECT SUM(x.VL_ICMS) FROM TB_FAT_NotaFiscal_Item x WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) AS VL_ICMS, ");
            sql.AppendLine("	(SELECT SUM(x.Vl_BaseCalcSubstTrib) FROM TB_FAT_NotaFiscal_Item x WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) AS Vl_BaseCalcSubstTrib, ");
            sql.AppendLine("	(SELECT SUM(x.VL_ICMS_SubsTrib) FROM TB_FAT_NotaFiscal_Item x WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) AS VL_ICMS_SubsTrib, ");
            sql.AppendLine("	(SELECT SUM(x.Vl_IPI) FROM TB_FAT_NotaFiscal_Item x WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) AS Vl_IPI, ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_Imposto) FROM TB_FAT_NotaFiscal_Item x  ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal ");
            sql.AppendLine("	 AND w.ST_Pis = 'S'),0) AS Vl_PIS, ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_Imposto) FROM TB_FAT_NotaFiscal_Item x  ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal ");
            sql.AppendLine("	 AND w.ST_Cofins = 'S'),0) AS Vl_Cofins, ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_ImpostoRetido) FROM TB_FAT_NotaFiscal_Item x  ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal ");
            sql.AppendLine("	 AND w.ST_Pis = 'S'),0) AS Vl_PISST, ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_ImpostoRetido) FROM TB_FAT_NotaFiscal_Item x  ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal ");
            sql.AppendLine("	 AND w.ST_Cofins = 'S'),0) AS Vl_CofinsST, a.ST_Registro ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectNotaFiscal(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeNotaFiscal(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[29];
            
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        reg[0] = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal")).ToString();
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal"))))
                        reg[1] = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal")).ToString();
                    else
                        reg[1] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("IND_OPER"))))
                        reg[2] = reader.GetString(reader.GetOrdinal("IND_OPER"));
                    else
                        reg[2] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("IND_EMIT"))))
                        reg[3] = reader.GetString(reader.GetOrdinal("IND_EMIT"));
                    else
                        reg[3] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg[4] = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    else
                        reg[4] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Modelo"))))
                        reg[5] = reader.GetString(reader.GetOrdinal("CD_Modelo"));
                    else
                        reg[5] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Sit"))))
                        reg[6] = reader.GetString(reader.GetOrdinal("CD_Sit"));
                    else
                        reg[6] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Serie"))))
                        reg[7] = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    else
                        reg[7] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Numero"))))
                        reg[8] = reader.GetString(reader.GetOrdinal("Numero"));
                    else
                        reg[8] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Chave_Acesso_NFE"))))
                        reg[9] = reader.GetString(reader.GetOrdinal("Chave_Acesso_NFE"));
                    else
                        reg[9] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Emissao"))))
                        reg[10] = reader.GetDateTime(reader.GetOrdinal("DT_Emissao")).ToString("ddMMyyyy");
                    else
                        reg[10] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt"))))
                        reg[11] = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt")).ToString("ddMMyyyy");
                    else
                        reg[11] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_TotalNota"))))
                        reg[12] = reader.GetDecimal(reader.GetOrdinal("VL_TotalNota")).ToString();
                    else
                        reg[12] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Cond_PAGTO"))))
                        reg[13] = reader.GetString(reader.GetOrdinal("Cond_PAGTO"));
                    else
                        reg[13] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Desconto"))))
                        reg[14] = reader.GetDecimal(reader.GetOrdinal("VL_Desconto")).ToString();
                    else
                        reg[14] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_SUBTotalProduto"))))
                        reg[15] = reader.GetDecimal(reader.GetOrdinal("VL_SUBTotalProduto")).ToString();
                    else
                        reg[15] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("FretePorConta"))))
                        reg[16] = reader.GetString(reader.GetOrdinal("FretePorConta"));
                    else
                        reg[16] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Frete"))))
                        reg[17] = reader.GetDecimal(reader.GetOrdinal("VL_Frete")).ToString();
                    else
                        reg[17] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Seguro"))))
                        reg[18] = reader.GetDecimal(reader.GetOrdinal("VL_Seguro")).ToString();
                    else
                        reg[18] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_TotalBaseCalc"))))
                        reg[19] = reader.GetDecimal(reader.GetOrdinal("VL_TotalBaseCalc")).ToString();
                    else
                        reg[19] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_ICMS"))))
                        reg[20] = reader.GetDecimal(reader.GetOrdinal("VL_ICMS")).ToString();
                    else
                        reg[20] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalcSubstTrib"))))
                        reg[21] = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalcSubstTrib")).ToString();
                    else
                        reg[21] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_ICMS_SubsTrib"))))
                        reg[22] = reader.GetDecimal(reader.GetOrdinal("VL_ICMS_SubsTrib")).ToString();
                    else
                        reg[22] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_IPI"))))
                        reg[23] = reader.GetDecimal(reader.GetOrdinal("Vl_IPI")).ToString();
                    else
                        reg[23] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_PIS"))))
                        reg[24] = reader.GetDecimal(reader.GetOrdinal("Vl_PIS")).ToString();
                    else
                        reg[24] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_Cofins"))))
                        reg[25] = reader.GetDecimal(reader.GetOrdinal("Vl_Cofins")).ToString();
                    else
                        reg[25] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_PISST"))))
                        reg[26] = reader.GetDecimal(reader.GetOrdinal("Vl_PISST")).ToString();
                    else
                        reg[26] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_CofinsST"))))
                        reg[27] = reader.GetDecimal(reader.GetOrdinal("Vl_CofinsST")).ToString();
                    else
                        reg[27] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_OutrasDesp"))))
                        reg[28] = reader.GetDecimal(reader.GetOrdinal("VL_OutrasDesp")).ToString();
                    else
                        reg[28] = "";

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

        private string SqlCodeOutrosImpostos(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT  ");
            sql.AppendLine("	ISNULL((SELECT SUM(CASE WHEN x.VL_ICMS > 0 THEN 0 ELSE x.VL_Subtotal END) FROM TB_FAT_NotaFiscal_Item x ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal) ,0) AS VL_SERV_NT, ");
            sql.AppendLine("    ISNULL((SELECT SUM(y.VL_BaseCalc) FROM TB_FAT_NotaFiscal_Item x   ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem  ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto  ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal  ");
            sql.AppendLine("	 AND w.ST_ISSQN = 'S'),0) AS VL_BaseCalcISSQN,  ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_Imposto) FROM TB_FAT_NotaFiscal_Item x   ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem  ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto  ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal  ");
            sql.AppendLine("	 AND w.ST_ISSQN = 'S'),0) AS Vl_ISSQN,  ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_BaseCalc) FROM TB_FAT_NotaFiscal_Item x   ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem  ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto  ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal  ");
            sql.AppendLine("	 AND w.ST_IRRF = 'S'),0) AS VL_BaseCalcIRRF,  ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_Imposto) FROM TB_FAT_NotaFiscal_Item x   ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem  ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto  ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal ");
            sql.AppendLine("	 AND w.ST_IRRF = 'S'),0) AS Vl_IRRF, ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_BaseCalc) FROM TB_FAT_NotaFiscal_Item x   ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem  ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto  ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal  ");
            sql.AppendLine("	 AND w.ST_INSS = 'S'),0) AS VL_BaseCalcINSS,  ");
            sql.AppendLine("	ISNULL((SELECT SUM(y.VL_Imposto) FROM TB_FAT_NotaFiscal_Item x   ");
            sql.AppendLine("	 INNER JOIN TB_FAT_Impostos y ON x.CD_Empresa = y.CD_Empresa AND x.Nr_LanctoFiscal = y.Nr_LanctoFiscal AND x.ID_NFItem = y.ID_NFItem  ");
            sql.AppendLine("	 INNER JOIN TB_FIS_Imposto w ON y.CD_Imposto = w.CD_Imposto  ");
            sql.AppendLine("	 WHERE x.Nr_LanctoFiscal = a.Nr_LanctoFiscal  ");
            sql.AppendLine("	 AND w.ST_INSS = 'S'),0) AS VL_INSS, a.NR_LanctoFiscal ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");

            string cond = " WHERE ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectOutrosImpostos(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeOutrosImpostos(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[7];

                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_SERV_NT"))))
                        reg[0] = reader.GetDecimal(reader.GetOrdinal("VL_SERV_NT")).ToString();
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_BaseCalcISSQN"))))
                        reg[1] = reader.GetDecimal(reader.GetOrdinal("VL_BaseCalcISSQN")).ToString();
                    else
                        reg[1] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_ISSQN"))))
                        reg[2] = reader.GetDecimal(reader.GetOrdinal("Vl_ISSQN")).ToString();
                    else
                        reg[2] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_BaseCalcIRRF"))))
                        reg[3] = reader.GetDecimal(reader.GetOrdinal("VL_BaseCalcIRRF")).ToString();
                    else
                        reg[3] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Vl_IRRF"))))
                        reg[4] = reader.GetDecimal(reader.GetOrdinal("Vl_IRRF")).ToString();
                    else
                        reg[4] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_BaseCalcINSS"))))
                        reg[5] = reader.GetDecimal(reader.GetOrdinal("VL_BaseCalcINSS")).ToString();
                    else
                        reg[5] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_INSS"))))
                        reg[6] = reader.GetDecimal(reader.GetOrdinal("VL_INSS")).ToString();
                    else
                        reg[6] = "";

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

        private string SqlCodeTitulosaPrazo(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT  ");
            sql.AppendLine("	a.NR_LanctoFiscal, c.NR_Lancto, CASE WHEN a.TP_Nota = 'T' THEN '1' ELSE '0' END AS TP_Emissao, ");
            sql.AppendLine("	'00' as TP_Titulo, c.QT_Parcelas, c.DS_Observacao, c.VL_Documento ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal_X_Duplicata b ON a.NR_LanctoFiscal = b.NR_LanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_FIN_Duplicata c ON c.NR_Lancto = b.NR_LanctoDuplicata AND b.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("WHERE c.QT_Parcelas > 1 ");

            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectTitulosaPrazo(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeTitulosaPrazo(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[7];

                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal"))))
                        reg[0] = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal")).ToString();
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg[1] = reader.GetDecimal(reader.GetOrdinal("NR_Lancto")).ToString();
                    else
                        reg[1] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Emissao"))))
                        reg[2] = reader.GetString(reader.GetOrdinal("TP_Emissao"));
                    else
                        reg[2] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Titulo"))))
                        reg[3] = reader.GetString(reader.GetOrdinal("TP_Titulo"));
                    else
                        reg[3] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                        reg[4] = reader.GetString(reader.GetOrdinal("DS_Observacao"));
                    else
                        reg[4] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Documento"))))
                        reg[5] = reader.GetDecimal(reader.GetOrdinal("VL_Documento")).ToString();
                    else
                        reg[5] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("QT_Parcelas"))))
                        reg[6] = reader.GetDecimal(reader.GetOrdinal("QT_Parcelas")).ToString();
                    else
                        reg[6] = "";
                    
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

        private string SqlCodeParcela(TpBusca[] vBusca, string NR_Lancto)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT  ");
            sql.AppendLine("	a.NR_LanctoFiscal, c.NR_Lancto, d.CD_Parcela, d.DT_Vencto, d.VL_Parcela ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            sql.AppendLine("INNER JOIN TB_FAT_NotaFiscal_X_Duplicata b ON a.NR_LanctoFiscal = b.NR_LanctoFiscal AND a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_FIN_Duplicata c ON c.NR_Lancto = b.NR_LanctoDuplicata AND b.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("INNER JOIN TB_FIN_Parcela d ON d.NR_Lancto = c.NR_Lancto AND d.CD_Empresa = c.CD_Empresa ");
            sql.AppendLine("WHERE c.QT_Parcelas > 1 ");
            sql.AppendLine("AND c.NR_Lancto = '" + NR_Lancto + "' ");

            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectParcela(TpBusca[] vBusca, string NR_Lancto)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeParcela(vBusca, NR_Lancto));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[4];

                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_Lancto"))))
                        reg[0] = reader.GetDecimal(reader.GetOrdinal("NR_Lancto")).ToString();
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Parcela"))))
                        reg[1] = reader.GetDecimal(reader.GetOrdinal("CD_Parcela")).ToString();
                    else
                        reg[1] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("DT_Vencto"))))
                        reg[2] = reader.GetDateTime(reader.GetOrdinal("DT_Vencto")).ToString("ddMMyyyy");
                    else
                        reg[2] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("VL_Parcela"))))
                        reg[3] = reader.GetDecimal(reader.GetOrdinal("VL_Parcela")).ToString();
                    else
                        reg[3] = "";

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

        private string SqlCodeVolumes(TpBusca[] vBusca)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SET DATEFORMAT dmy ");
            sql.AppendLine("SELECT DISTINCT  ");
            sql.AppendLine("	a.NR_LanctoFiscal, a.CD_Clifor, a.PlacaVeiculo, a.Quantidade, a.PesoBruto, a.PesoLiquido ");
            sql.AppendLine("FROM TB_FAT_NotaFiscal a ");
            
            string cond = " AND ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " AND ";
                }
            return sql.ToString();
        }

        public List<string[]> SelectVolumes(TpBusca[] vBusca)
        {
            List<string[]> lista = new List<string[]>();
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeVolumes(vBusca));

            try
            {
                while (reader.Read())
                {
                    string[] reg = new string[5];
                    
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                        reg[0] = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    else
                        reg[0] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("PlacaVeiculo"))))
                        reg[1] = reader.GetString(reader.GetOrdinal("PlacaVeiculo"));
                    else
                        reg[1] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("Quantidade"))))
                        reg[2] = reader.GetString(reader.GetOrdinal("Quantidade")).ToString();
                    else
                        reg[2] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("PesoBruto"))))
                        reg[3] = reader.GetDecimal(reader.GetOrdinal("PesoBruto")).ToString();
                    else
                        reg[3] = "";
                    if (!(reader.IsDBNull(reader.GetOrdinal("PesoLiquido"))))
                        reg[4] = reader.GetDecimal(reader.GetOrdinal("PesoLiquido")).ToString();
                    else
                        reg[4] = "";

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
