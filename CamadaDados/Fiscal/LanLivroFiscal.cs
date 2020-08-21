using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Fiscal
{
    public class TList_LivroFiscal : List<TRegistro_LivroFiscal>
    { }

    
    public class TRegistro_LivroFiscal
    {
        
        public decimal? Id_livro
        { get; set; }
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Nr_cgcempresa
        { get; set; }
        
        public string Insc_estadualempresa
        { get; set; }
        
        public decimal Nr_lanctofiscal
        { get; set; }
        
        public decimal Nr_doctofiscal
        { get; set; }
        
        public string Tp_nota
        { get; set; }
        
        public string Cd_cfop
        { get; set; }
        
        public string Ds_cfop
        { get; set; }
        
        public string Nr_serie
        { get; set; }
        
        public string Ds_serie
        { get; set; }
        
        public string Cd_modelo
        { get; set; }
        
        public string Uf
        { get; set; }
        private string tp_movimento;
        
        public string Tp_movimento
        {
            get { return tp_movimento; }
            set
            {
                tp_movimento = value;
                if (value.Trim().ToUpper().Equals("E"))
                    tipo_movimento = "ENTRADA";
                else if (value.Trim().ToUpper().Equals("S"))
                    tipo_movimento = "SAIDA";
            }
        }
        private string tipo_movimento;
        
        public string Tipo_movimento
        {
            get { return tipo_movimento; }
            set
            {
                tipo_movimento = value;
                if (value.Trim().ToUpper().Equals("ENTRADA"))
                    tp_movimento = "E";
                else if (value.Trim().ToUpper().Equals("SAIDA"))
                    tp_movimento = "S";
            }
        }
        
        public string Cd_clifor
        { get; set; }
        
        public string Nm_clifor
        { get; set; }
        
        public string Insc_estadual
        { get; set; }
        
        public string Nr_cgc
        { get; set; }
        
        public string Nr_cpf
        { get; set; }
        
        public string Tp_pessoa
        { get; set; }
        
        public string Cd_endereco
        { get; set; }
        
        public string Ds_endereco
        { get; set; }
        
        public DateTime? Dt_emissao
        { get; set; }
        
        public DateTime? Dt_saient
        { get; set; }
        
        public decimal Vl_contabil
        { get; set; }
        
        public decimal Pc_aliquotaicms
        { get; set; }
        
        public decimal Pc_aliquotaipi
        { get; set; }
        
        public string Especie
        { get; set; }
        
        public decimal Vl_basecalc
        { get; set; }
        
        public decimal Vl_icms_subst
        { get; set; }
        
        public decimal Vl_icms
        { get; set; }
        
        public decimal Vl_ipi
        { get; set; }
        
        public decimal Vl_isentas
        { get; set; }
        
        public decimal Vl_outros
        { get; set; }
        private string st_registro;
        
        public string St_registro
        {
            get { return st_registro; }
            set
            {
                st_registro = value;
                if (value.Trim().ToUpper().Equals("A"))
                    status = "ATIVO";
                else if (value.Trim().ToUpper().Equals("C"))
                    status = "CANCELADO";
            }
        }
        private string status;
        
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value.Trim().ToUpper().Equals("ATIVO"))
                    st_registro = "A";
                else if (value.Trim().ToUpper().Equals("CANCELADO"))
                    st_registro = "C";
            }
        }

        public TRegistro_LivroFiscal()
        {
            this.Id_livro = null;
            this.Cd_cfop = string.Empty;
            this.Cd_clifor = string.Empty;
            this.Cd_empresa = string.Empty;
            this.Cd_endereco = string.Empty;
            this.Ds_cfop = string.Empty;
            this.Ds_endereco = string.Empty;
            this.Ds_serie = string.Empty;
            this.Cd_modelo = string.Empty;
            this.Dt_emissao = null;
            this.Dt_saient = null;
            this.Especie = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Nr_lanctofiscal = decimal.Zero;
            this.Nr_doctofiscal = decimal.Zero;
            this.Tp_nota = string.Empty;
            this.Nr_serie = string.Empty;
            this.Pc_aliquotaicms = decimal.Zero;
            this.Pc_aliquotaipi = decimal.Zero;
            this.st_registro = string.Empty;
            this.status = string.Empty;
            this.tipo_movimento = string.Empty;
            this.tp_movimento = string.Empty;
            this.Uf = string.Empty;
            this.Vl_basecalc = decimal.Zero;
            this.Vl_contabil = decimal.Zero;
            this.Vl_icms = decimal.Zero;
            this.Vl_icms_subst = decimal.Zero;
            this.Vl_ipi = decimal.Zero;
            this.Vl_isentas = decimal.Zero;
            this.Vl_outros = decimal.Zero;
            this.Nr_cgcempresa = string.Empty;
            this.Insc_estadualempresa = string.Empty;
            this.Insc_estadual = string.Empty;
            this.Nr_cgc = string.Empty;
            this.Nr_cpf = string.Empty;
            this.Tp_pessoa = string.Empty;
        }
    }

    public class TCD_LivroFiscal : TDataQuery
    {
        public TCD_LivroFiscal()
        { }

        public TCD_LivroFiscal(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int16 vTop, string vNM_Campo, string vOrder)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.CD_Empresa, b.NM_Empresa, a.CD_CFOP, c.DS_CFOP, ");
                sql.AppendLine("a.Nr_DoctoFiscal, a.Nr_Serie, a.cd_modelo, d.DS_SerieNf, a.UF, ");
                sql.AppendLine("a.Tp_Movimento, a.CD_Clifor, e.NM_Clifor, a.NR_LanctoFiscal, ");
                sql.AppendLine("a.CD_Endereco, f.DS_Endereco, a.DT_Emissao, ");
                sql.AppendLine("a.DT_SaiEnt, a.Vl_contabil, a.Pc_aliquotaicms, ");
                sql.AppendLine("a.especie, a.Vl_BaseCalc, a.Vl_Icms_subst, a.Vl_icms, ");
                sql.AppendLine("a.Vl_Isentas, a.Vl_Outros, a.st_registro, a.tp_nota, ");
                sql.AppendLine("e.tp_pessoa, e.nr_cgc, e.nr_cpf, f.insc_estadual, ");
                sql.AppendLine("g.nr_cgc as nr_cgcempresa, h.insc_estadual as insc_estadualempresa ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_FIS_LIVROFISCAL a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIS_CFOP c ");
            sql.AppendLine("on a.CD_CFOP = c.CD_CFOP ");
            sql.AppendLine("inner join TB_FAT_SerieNF d ");
            sql.AppendLine("on a.Nr_Serie = d.Nr_Serie ");
            sql.AppendLine("and a.Cd_modelo = d.Cd_modelo ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR e ");
            sql.AppendLine("on a.CD_Clifor = e.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO f ");
            sql.AppendLine("on a.CD_Clifor = f.CD_Clifor ");
            sql.AppendLine("and a.cd_Endereco = f.CD_Endereco ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR g ");
            sql.AppendLine("on b.cd_clifor = g.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO h ");
            sql.AppendLine("on b.cd_clifor = h.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = h.cd_endereco ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                    cond = " and ";
                }
            if (!string.IsNullOrEmpty(vOrder))
                sql.AppendLine("order by " + vOrder.Trim());
            return sql.ToString();
        }

        private string SqlCodeBuscaFatLivro(Utils.TpBusca[] filtro)
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select a.CD_Empresa, b.NM_Empresa, a.CD_CFOP, c.DS_CFOP, ");
            sql.AppendLine("a.Nr_NotaFiscal, a.Nr_Serie, a.cd_modelo, d.DS_SerieNf, a.UF, ");
            sql.AppendLine("a.Tp_Movimento, a.CD_Clifor, e.NM_Clifor, a.NR_LanctoFiscal, ");
            sql.AppendLine("a.CD_Endereco, f.DS_Endereco, a.DT_Emissao, a.st_registro, a.tp_nota, ");
            sql.AppendLine("e.tp_pessoa, e.nr_cgc, e.nr_cpf, f.insc_estadual, ");
            sql.AppendLine("g.nr_cgc as nr_cgcempresa, h.insc_estadual as insc_estadualempresa, ");
            sql.AppendLine("a.DT_SaiEnt, a.especie, a.Pc_aliquotaicms, ");
            sql.AppendLine("Vl_contabil = ISNULL(SUM(ISNULL(a.Vl_contabil, 0)), 0), ");
            sql.AppendLine("Vl_BaseCalc = ISNULL(SUM(ISNULL(a.Vl_BaseCalc, 0)), 0), ");
            sql.AppendLine("Vl_Icms_subst = ISNULL(SUM(ISNULL(a.Vl_Icms_subst, 0)), 0), ");
            sql.AppendLine("Vl_icms = ISNULL(SUM(ISNULL(a.Vl_icms, 0)), 0), ");
            sql.AppendLine("Vl_Isentas = ISNULL(SUM(ISNULL(a.Vl_Isentas, 0)), 0), ");
            sql.AppendLine("Vl_Outros = ISNULL(SUM(ISNULL(a.Vl_Outros, 0)), 0) ");

            sql.AppendLine("from VTB_FAT_LIVROFISCAL a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_FIS_CFOP c ");
            sql.AppendLine("on a.CD_CFOP = c.CD_CFOP ");
            sql.AppendLine("inner join TB_FAT_SerieNF d ");
            sql.AppendLine("on a.Nr_Serie = d.Nr_Serie ");
            sql.AppendLine("and a.Cd_modelo = d.Cd_modelo ");
            sql.AppendLine("left outer join VTB_FIN_CLIFOR e ");
            sql.AppendLine("on a.CD_Clifor = e.CD_Clifor ");
            sql.AppendLine("left outer join VTB_FIN_ENDERECO f ");
            sql.AppendLine("on a.CD_Clifor = f.CD_Clifor ");
            sql.AppendLine("and a.cd_Endereco = f.CD_Endereco ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR g ");
            sql.AppendLine("on b.cd_clifor = g.cd_clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO h ");
            sql.AppendLine("on b.cd_clifor = h.cd_clifor ");
            sql.AppendLine("and b.cd_endereco = h.cd_endereco ");

            string cond = " where ";
            if (filtro != null)
                for (int i = 0; i < (filtro.Length); i++)
                {
                    sql.AppendLine(cond + "(" + filtro[i].vNM_Campo + " " + filtro[i].vOperador + " " + filtro[i].vVL_Busca + ")");
                    cond = " and ";
                }

            sql.AppendLine("group by a.CD_Empresa, b.NM_Empresa, a.CD_CFOP, c.DS_CFOP, ");
            sql.AppendLine("a.Nr_NotaFiscal, a.Nr_Serie, a.cd_modelo, d.DS_SerieNf, a.UF, ");
            sql.AppendLine("a.Tp_Movimento, a.CD_Clifor, e.NM_Clifor, a.NR_LanctoFiscal, ");
            sql.AppendLine("a.CD_Endereco, f.DS_Endereco, a.DT_Emissao, a.st_registro, a.tp_nota, ");
            sql.AppendLine("e.tp_pessoa, e.nr_cgc, e.nr_cpf, f.insc_estadual, ");
            sql.AppendLine("g.nr_cgc, h.insc_estadual, ");
            sql.AppendLine("a.DT_SaiEnt, a.especie, a.Pc_aliquotaicms ");

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

        public TList_LivroFiscal Select(Utils.TpBusca[] filtro, Int16 vTop, string vNM_Campo, string vOrder)
        {
            bool podeFecharBco = false;
            TList_LivroFiscal lista = new TList_LivroFiscal();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(filtro, vTop, vNM_Campo, vOrder));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LivroFiscal reg = new TRegistro_LivroFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgcempresa")))
                        reg.Nr_cgcempresa = reader.GetString(reader.GetOrdinal("nr_cgcempresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadualempresa")))
                        reg.Insc_estadualempresa = reader.GetString(reader.GetOrdinal("insc_estadualempresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_DoctoFiscal")))
                        reg.Nr_doctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_DoctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("TP_Nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SerieNf")))
                        reg.Ds_serie = reader.GetString(reader.GetOrdinal("DS_SerieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Nr_cgc = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cpf")))
                        reg.Nr_cpf = reader.GetString(reader.GetOrdinal("nr_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Contabil")))
                        reg.Vl_contabil = reader.GetDecimal(reader.GetOrdinal("Vl_Contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("especie")))
                        reg.Especie = reader.GetString(reader.GetOrdinal("especie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Icms_subst")))
                        reg.Vl_icms_subst = reader.GetDecimal(reader.GetOrdinal("Vl_Icms_subst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaicms")))
                        reg.Pc_aliquotaicms = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Isentas")))
                        reg.Vl_isentas = reader.GetDecimal(reader.GetOrdinal("Vl_Isentas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Outros")))
                        reg.Vl_outros = reader.GetDecimal(reader.GetOrdinal("Vl_Outros"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public TList_LivroFiscal SelectFatLivro(Utils.TpBusca[] filtro)
        {
            bool podeFecharBco = false;
            TList_LivroFiscal lista = new TList_LivroFiscal();
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBuscaFatLivro(filtro));
            try
            {
                while (reader.Read())
                {
                    TRegistro_LivroFiscal reg = new TRegistro_LivroFiscal();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgcempresa")))
                        reg.Nr_cgcempresa = reader.GetString(reader.GetOrdinal("nr_cgcempresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadualempresa")))
                        reg.Insc_estadualempresa = reader.GetString(reader.GetOrdinal("insc_estadualempresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CFOP")))
                        reg.Cd_cfop = reader.GetString(reader.GetOrdinal("CD_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CFOP")))
                        reg.Ds_cfop = reader.GetString(reader.GetOrdinal("DS_CFOP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_NotaFiscal")))
                        reg.Nr_doctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_NotaFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_nota")))
                        reg.Tp_nota = reader.GetString(reader.GetOrdinal("TP_Nota"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_LanctoFiscal")))
                        reg.Nr_lanctofiscal = reader.GetDecimal(reader.GetOrdinal("NR_LanctoFiscal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NR_Serie")))
                        reg.Nr_serie = reader.GetString(reader.GetOrdinal("NR_Serie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_SerieNf")))
                        reg.Ds_serie = reader.GetString(reader.GetOrdinal("DS_SerieNf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_modelo")))
                        reg.Cd_modelo = reader.GetString(reader.GetOrdinal("cd_modelo"));
                    if (!reader.IsDBNull(reader.GetOrdinal("UF")))
                        reg.Uf = reader.GetString(reader.GetOrdinal("UF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Movimento")))
                        reg.Tp_movimento = reader.GetString(reader.GetOrdinal("TP_Movimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.Nm_clifor = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_pessoa")))
                        reg.Tp_pessoa = reader.GetString(reader.GetOrdinal("tp_pessoa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cgc")))
                        reg.Nr_cgc = reader.GetString(reader.GetOrdinal("nr_cgc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_cpf")))
                        reg.Nr_cpf = reader.GetString(reader.GetOrdinal("nr_cpf"));
                    if (!reader.IsDBNull(reader.GetOrdinal("insc_estadual")))
                        reg.Insc_estadual = reader.GetString(reader.GetOrdinal("insc_estadual"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.Cd_endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.Ds_endereco = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_Emissao")))
                        reg.Dt_emissao = reader.GetDateTime(reader.GetOrdinal("DT_Emissao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DT_SaiEnt")))
                        reg.Dt_saient = reader.GetDateTime(reader.GetOrdinal("DT_SaiEnt"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Contabil")))
                        reg.Vl_contabil = reader.GetDecimal(reader.GetOrdinal("Vl_Contabil"));
                    if (!reader.IsDBNull(reader.GetOrdinal("especie")))
                        reg.Especie = reader.GetString(reader.GetOrdinal("especie"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_BaseCalc")))
                        reg.Vl_basecalc = reader.GetDecimal(reader.GetOrdinal("Vl_BaseCalc"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Icms_subst")))
                        reg.Vl_icms_subst = reader.GetDecimal(reader.GetOrdinal("Vl_Icms_subst"));
                    if (!reader.IsDBNull(reader.GetOrdinal("pc_aliquotaicms")))
                        reg.Pc_aliquotaicms = reader.GetDecimal(reader.GetOrdinal("pc_aliquotaicms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_icms")))
                        reg.Vl_icms = reader.GetDecimal(reader.GetOrdinal("Vl_icms"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Isentas")))
                        reg.Vl_isentas = reader.GetDecimal(reader.GetOrdinal("Vl_Isentas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Outros")))
                        reg.Vl_outros = reader.GetDecimal(reader.GetOrdinal("Vl_Outros"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_registro")))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("st_registro"));

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

        public string Gravar(TRegistro_LivroFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(23);
            hs.Add("@P_ID_LIVRO", val.Id_livro);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_NR_LANCTOFISCAL", val.Nr_lanctofiscal);
            hs.Add("@P_CD_CFOP", val.Cd_cfop);
            hs.Add("@P_NR_SERIE", val.Nr_serie);
            hs.Add("@P_CD_MODELO", val.Cd_modelo);
            hs.Add("@P_CD_CLIFOR", val.Cd_clifor);
            hs.Add("@P_CD_ENDERECO", val.Cd_endereco);
            hs.Add("@P_UF", val.Uf);
            hs.Add("@P_NR_DOCTOFISCAL", val.Nr_doctofiscal);
            hs.Add("@P_TP_MOVIMENTO", val.Tp_movimento);
            hs.Add("@P_DT_EMISSAO", val.Dt_emissao);
            hs.Add("@P_DT_SAIENT", val.Dt_saient);
            hs.Add("@P_VL_CONTABIL", val.Vl_contabil);
            hs.Add("@P_PC_ALIQUOTAICMS", val.Pc_aliquotaicms);
            hs.Add("@P_ESPECIE", val.Especie);
            hs.Add("@P_VL_BASECALC", val.Vl_basecalc);
            hs.Add("@P_VL_ICMS_SUBST", val.Vl_icms_subst);
            hs.Add("@P_VL_ICMS", val.Vl_icms);
            hs.Add("@P_TP_NOTA", val.Tp_nota);
            hs.Add("@P_VL_ISENTAS", val.Vl_isentas);
            hs.Add("@P_VL_OUTROS", val.Vl_outros);
            hs.Add("@P_ST_REGISTRO", val.St_registro);

            return this.executarProc("IA_FIS_LIVROFISCAL", hs);
        }

        public string Excluir(TRegistro_LivroFiscal val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_ID_LIVRO", val.Id_livro);

            return this.executarProc("EXCLUI_FIS_LIVROFISCAL", hs);
        }
    }
}
