using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.PostoCombustivel.Cadastros
{
    public class TList_CfgPosto : List<TRegistro_CfgPosto>, IComparer<TRegistro_CfgPosto>
    {
        #region IComparer<TRegistro_CfgPosto> Members
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

        public TList_CfgPosto()
        { }

        public TList_CfgPosto(System.ComponentModel.PropertyDescriptor Prop,
                              System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CfgPosto value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CfgPosto x, TRegistro_CfgPosto y)
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
    
    public class TRegistro_CfgPosto
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_clifor
        { get; set; }
        public string Cd_fornecedor
        { get; set; }
        public string Nm_fornecedor
        { get; set; }
        public string Cd_conveniencia
        { get; set; }
        public string Nm_conveniencia
        { get; set; }
        public string Cd_tabelapreco
        { get; set; }
        public string Ds_tabelapreco
        { get; set; }
        public string Tp_duplicata
        { get; set; }
        public string Ds_tpduplicata
        { get; set; }
        private decimal? tp_docto;
        public decimal? Tp_docto
        {
            get { return tp_docto; }
            set
            {
                tp_docto = value;
                tp_doctostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctostr;
        public string Tp_doctostr
        {
            get { return tp_doctostr; }
            set
            {
                tp_doctostr = value;
                try
                {
                    tp_docto = decimal.Parse(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        public string Ds_tpdocto
        { get; set; }
        public string Cd_historico
        { get; set; }
        public string Ds_historico
        { get; set; }
        public string Cd_terminal
        { get; set; }
        public string Ds_terminal
        { get; set; }
        public string Cd_condpgto { get; set; } = string.Empty;
        public string Ds_condpgto { get; set; } = string.Empty;
        public string Tp_duplicataemp { get; set; } = string.Empty;
        public string Ds_tpduplicataemp { get; set; } = string.Empty;
        private decimal? tp_doctoemp = null;
        public decimal? Tp_doctoemp
        {
            get { return tp_doctoemp; }
            set
            {
                tp_doctoemp = value;
                tp_doctoempstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string tp_doctoempstr = string.Empty;
        public string Tp_doctosempstr
        {
            get { return tp_doctoempstr; }
            set
            {
                tp_doctoempstr = value;
                try
                {
                    tp_doctoemp = decimal.Parse(value);
                }
                catch { tp_doctoemp = null; }
            }
        }
        public string Ds_tpdoctoemp { get; set; } = string.Empty;
        private string tp_concentrador;
        public string Tp_concentrador
        {
            get { return tp_concentrador; }
            set
            {
                tp_concentrador = value;
                if (value.Trim().ToUpper().Equals("CT"))
                    tipo_concentrador = "COMPANYTEC";
                else if (value.Trim().ToUpper().Equals("GB"))
                    tipo_concentrador = "GILBARCO";
                else if (value.Trim().ToUpper().Equals("VW"))
                    tipo_concentrador = "VWTECH";
                else if (value.Trim().ToUpper().Equals("HT"))
                    tipo_concentrador = "HORUSTECH";
                else if (value.Trim().ToUpper().Equals("SA"))
                    tipo_concentrador = "SEM AUTOMAÇÃO";
            }
        }
        private string tipo_concentrador;
        public string Tipo_concentrador
        {
            get { return tipo_concentrador; }
            set
            {
                tipo_concentrador = value;
                if (value.Trim().ToUpper().Equals("COMPANYTEC"))
                    tp_concentrador = "CT";
                else if (value.Trim().ToUpper().Equals("GILBARCO"))
                    tp_concentrador = "GB";
                else if (value.Trim().ToUpper().Equals("VWTECH"))
                    tp_concentrador = "VW";
                else if (value.Trim().ToUpper().Equals("HORUSTECH"))
                    tp_concentrador = "HT";
                else if (value.Trim().ToUpper().Equals("SEM AUTOMAÇÃO"))
                    tp_concentrador = "SA";
            }
        }
        public decimal Porta_comunicacao
        { get; set; }
        public string Porta
        { get { return "COM" + Porta_comunicacao.ToString(); } }
        public string Host_ip
        { get; set; }
        public decimal Porta_ip
        { get; set; }
        public decimal Tmp_abastecimento
        { get; set; }
        public decimal Tmp_abastonline
        { get; set; }
        private string tp_leituraencerrantebico;
        public string Tp_leituraencerrantebico
        {
            get { return tp_leituraencerrantebico; }
            set
            {
                tp_leituraencerrantebico = value;
                if (value.Trim().ToUpper().Equals("A"))
                    tipo_leituraencerrantebico = "ABERTURA";
                else if (value.Trim().ToUpper().Equals("F"))
                    tipo_leituraencerrantebico = "FECHAMENTO";
            }
        }

        public decimal diasValidadeVale
        { get; set; }

        private string tipo_leituraencerrantebico;
        public string Tipo_leituraencerrantebico
        {
            get { return tipo_leituraencerrantebico; }
            set
            {
                tipo_leituraencerrantebico = value;
                if (value.Trim().ToUpper().Equals("ABERTURA"))
                    tp_leituraencerrantebico = "A";
                else if (value.Trim().ToUpper().Equals("FECHAMENTO"))
                    tp_leituraencerrantebico = "F";
            }
        }
        private string tp_modoencerrante;
        public string Tp_modoencerrante
        {
            get { return tp_modoencerrante; }
            set
            {
                tp_modoencerrante = value;
                if (value.Trim().ToUpper().Equals("C"))
                    tipo_modoencerrante = "CAPTURAR";
                else if (value.Trim().ToUpper().Equals("L"))
                    tipo_modoencerrante = "CALCULAR";
            }
        }
        private string tipo_modoencerrante;
        public string Tipo_modoencerrante
        {
            get { return tipo_modoencerrante; }
            set
            {
                tipo_modoencerrante = value;
                if (value.Trim().ToUpper().Equals("CAPTURAR"))
                    tp_modoencerrante = "C";
                else if (value.Trim().ToUpper().Equals("CALCULAR"))
                    tp_modoencerrante = "L";
            }
        }
        private string st_calcvltotal;
        public string St_calcvltotal
        {
            get { return st_calcvltotal; }
            set
            {
                st_calcvltotal = value;
                st_calcvltotalbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_calcvltotalbool;
        public bool St_calcvltotalbool
        {
            get { return st_calcvltotalbool; }
            set
            {
                st_calcvltotalbool = value;
                st_calcvltotal = value ? "S" : "N";
            }
        }
        private string st_alterarpreco;
        public string St_alterarpreco
        {
            get { return st_alterarpreco; }
            set
            {
                st_alterarpreco = value;
                st_alterarprecobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_alterarprecobool;
        public bool St_alterarprecobool
        {
            get { return st_alterarprecobool; }
            set
            {
                st_alterarprecobool = value;
                st_alterarpreco = value ? "S" : "N";
            }
        }
        public decimal Vl_multiplochtroco
        { get; set; }
        private string st_chtrocodireto;
        public string St_chtrocodireto
        {
            get { return st_chtrocodireto; }
            set
            {
                st_chtrocodireto = value;
                st_chtrocodiretobool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_chtrocodiretobool;
        public bool St_chtrocodiretobool
        {
            get { return st_chtrocodiretobool; }
            set
            {
                st_chtrocodiretobool = value;
                st_chtrocodireto = value ? "S" : "N";
            }
        }
        private string st_vendaforaconv;
        public string St_vendaforaconv
        {
            get { return st_vendaforaconv; }
            set
            {
                st_vendaforaconv = value;
                st_vendaforaconvbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_vendaforaconvbool;
        public bool St_vendaforaconvbool
        {
            get { return st_vendaforaconvbool; }
            set
            {
                st_vendaforaconvbool = value;
                st_vendaforaconv = value ? "S" : "N";
            }
        }
        private string st_identfrentista;
        public string St_identfrentista
        {
            get { return st_identfrentista; }
            set
            {
                st_identfrentista = value;
                st_identfrentistabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_identfrentistabool;
        public bool St_identfrentistabool
        {
            get { return st_identfrentistabool; }
            set
            {
                st_identfrentistabool = value;
                st_identfrentista = value ? "S" : "N";
            }
        }
        private string st_encerrantecaixa;
        public string St_encerrantecaixa
        {
            get { return st_encerrantecaixa; }
            set
            {
                st_encerrantecaixa = value;
                st_encerrantecaixabool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_encerrantecaixabool;
        public bool St_encerrantecaixabool
        {
            get { return st_encerrantecaixabool; }
            set
            {
                st_encerrantecaixabool = value;
                st_encerrantecaixa = value ? "S" : "N";
            }
        }
        public decimal Qt_maxabastespera
        { get; set; }
        private string st_emitirvale_fid;
        public string St_emitirvale_fid
        {
            get { return st_emitirvale_fid; }
            set
            {
                st_emitirvale_fid = value;
                st_emitirvale_fidbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_emitirvale_fidbool;
        public bool St_emitirvale_fidbool
        {
            get { return st_emitirvale_fidbool; }
            set
            {
                st_emitirvale_fidbool = value;
                st_emitirvale_fid = value ? "S" : "N";
            }
        }
        public decimal Qt_pontosvale_fid
        { get; set; }
        public decimal Qt_maxvaledia
        { get; set; }
        public string Ds_msgvale
        { get; set; }
        private decimal fatorconvvolume;
        public decimal Fatorconvvolume
        {
            get { return fatorconvvolume; }
            set
            {
                fatorconvvolume = value;
                fatorconvvolumestr = value.ToString();
            }
        }
        private string fatorconvvolumestr;
        public string Fatorconvvolumestr
        {
            get { return fatorconvvolumestr; }
            set
            {
                fatorconvvolumestr = value;
                try
                {
                    fatorconvvolume = decimal.Parse(value);
                }
                catch { fatorconvvolume = decimal.Zero; }
            }
        }
        private decimal fatorconvunit;
        public decimal Fatorconvunit
        {
            get { return fatorconvunit; }
            set
            {
                fatorconvunit = value;
                fatorconvunitstr = value.ToString();
            }
        }
        private string fatorconvunitstr;
        public string Fatorconvunitstr
        {
            get { return fatorconvunitstr; }
            set
            {
                fatorconvunitstr = value;
                try
                {
                    fatorconvunit = decimal.Parse(value);
                }
                catch { fatorconvunit = decimal.Zero; }
            }
        }
        private decimal fatorconvsubtotal;
        public decimal Fatorconvsubtotal
        {
            get { return fatorconvsubtotal; }
            set
            {
                fatorconvsubtotal = value;
                fatorconvsubtotalstr = value.ToString();
            }
        }
        private string fatorconvsubtotalstr;
        public string Fatorconvsubtotalstr
        {
            get { return fatorconvsubtotalstr; }
            set
            {
                fatorconvsubtotalstr = value;
                try
                {
                    fatorconvsubtotal = decimal.Parse(value);
                }
                catch { fatorconvsubtotal = decimal.Zero; }
            }
        }
        private string st_NFDiretaForaUF;
        public string St_NFDiretaForaUF
        {
            get { return st_NFDiretaForaUF; }
            set
            {
                st_NFDiretaForaUF = value;
                st_NFDiretaForaUFbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_NFDiretaForaUFbool;
        public bool St_NFDiretaForaUFbool
        {
            get { return st_NFDiretaForaUFbool; }
            set
            {
                st_NFDiretaForaUFbool = value;
                st_NFDiretaForaUF = value ? "S" : "N";
            }
        }
        private string st_afericaoajustaest;
        public string St_afericaoajustaest
        {
            get { return st_afericaoajustaest; }
            set
            {
                st_afericaoajustaest = value;
                st_afericaoajustaestbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_afericaoajustaestbool;
        public bool St_afericaoajustaestbool
        {
            get { return st_afericaoajustaestbool; }
            set
            {
                st_afericaoajustaestbool = value;
                st_afericaoajustaest = value ? "S" : "N";
            }
        }


        public TRegistro_CfgPosto()
        {
            Cd_empresa = string.Empty;
            Nm_empresa = string.Empty;
            Cd_clifor = string.Empty;
            Cd_fornecedor = string.Empty;
            Nm_fornecedor = string.Empty;
            Cd_conveniencia = string.Empty;
            Nm_conveniencia = string.Empty;
            Cd_tabelapreco = string.Empty;
            Ds_tabelapreco = string.Empty;
            Tp_duplicata = string.Empty;
            Ds_tpduplicata = string.Empty;
            tp_docto = null;
            tp_doctostr = string.Empty;
            Ds_tpdocto = string.Empty;
            Cd_historico = string.Empty;
            Ds_historico = string.Empty;
            Cd_terminal = string.Empty;
            Ds_terminal = string.Empty;
            tp_concentrador = string.Empty;
            tipo_concentrador = string.Empty;
            Porta_comunicacao = 1;
            Host_ip = string.Empty;
            Porta_ip = decimal.Zero;
            Tmp_abastecimento = decimal.Zero;
            Tmp_abastonline = decimal.Zero;
            tp_leituraencerrantebico = string.Empty;
            tipo_leituraencerrantebico = string.Empty;
            tp_modoencerrante = string.Empty;
            tipo_modoencerrante = string.Empty;
            st_calcvltotal = "N";
            st_calcvltotalbool = false;
            st_alterarpreco = "N";
            st_alterarprecobool = false;
            Vl_multiplochtroco = decimal.Zero;
            st_chtrocodireto = "N";
            st_chtrocodiretobool = false;
            st_vendaforaconv = "N";
            st_vendaforaconvbool = false;
            st_identfrentista = "N";
            st_identfrentistabool = false;
            st_encerrantecaixa = "N";
            st_encerrantecaixabool = false;
            Qt_maxabastespera = decimal.Zero;
            st_emitirvale_fid = string.Empty;
            st_emitirvale_fidbool = false;
            Qt_pontosvale_fid = decimal.Zero;
            Qt_maxvaledia = decimal.Zero;
            Ds_msgvale = string.Empty;
            fatorconvvolume = decimal.Zero;
            fatorconvvolumestr = "0";
            fatorconvunit = decimal.Zero;
            fatorconvunitstr = "0";
            fatorconvsubtotal = decimal.Zero;
            fatorconvsubtotalstr = "0";
            diasValidadeVale = decimal.Zero;
            st_NFDiretaForaUF = string.Empty;
            st_NFDiretaForaUFbool = false;
            st_afericaoajustaest = "N";
            st_afericaoajustaestbool = false;
        }
    }

    public class TCD_CfgPosto : TDataQuery
    {
        public TCD_CfgPosto()
        { }

        public TCD_CfgPosto(BancoDados.TObjetoBanco banco)
        { Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + vTop.ToString();

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("select " + strTop + " a.cd_empresa, b.nm_empresa, b.cd_clifor, ");
                sql.AppendLine("a.cd_fornecedor, c.nm_clifor as nm_fornecedor, ");
                sql.AppendLine("a.tp_concentrador, a.porta_comunicacao, a.st_calcvltotal, ");
                sql.AppendLine("a.tmp_abastecimento, a.tmp_abastonline, a.st_vendaforaconv, ");
                sql.AppendLine("a.tp_leituraencerrantebico, a.vl_multiplochtroco, ");
                sql.AppendLine("a.tp_modoencerrante, a.st_alterarpreco, a.qt_maxabastespera, ");
                sql.AppendLine("a.cd_conveniencia, d.nm_empresa as NM_Conveniencia, ");
                sql.AppendLine("a.cd_tabelapreco, e.ds_tabelapreco, a.host_ip, a.porta_ip, ");
                sql.AppendLine("a.tp_duplicata, f.ds_tpduplicata, f.cd_historico_dup, ");
                sql.AppendLine("a.tp_docto, g.ds_tpdocto, h.ds_historico, a.st_identfrentista, ");
                sql.AppendLine("a.cd_terminal, i.ds_terminal, a.cd_condpgto, j.ds_condpgto, ");
                sql.AppendLine("a.tp_duplicataemp, k.ds_tpduplicata as ds_tpduplicataemp, ");
                sql.AppendLine("a.tp_doctoemp, l.ds_tpdocto as ds_tpdoctoemp, ");
                sql.AppendLine("a.St_ChTrocoDireto, a.st_encerrantecaixa, a.st_afericaoajustaest, ");
                sql.AppendLine("a.st_emitirvale_fid, a.qt_pontosvale_fid, a.qt_maxvaledia, a.ds_msgvale, ");
                sql.AppendLine("a.FatorConvVolume, a.FatorConvUnit, a.FatorConvSubtotal, a.DiasValidadeVale, a.ST_NFDiretaForaUF ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_PDC_CfgPosto a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.cd_empresa = b.cd_empresa ");
            sql.AppendLine("left outer join VTB_FIN_Clifor c ");
            sql.AppendLine("on a.cd_fornecedor = c.cd_clifor ");
            sql.AppendLine("left outer join TB_DIV_Empresa d ");
            sql.AppendLine("on a.cd_conveniencia = d.cd_empresa ");
            sql.AppendLine("left outer join TB_DIV_TabelaPreco e ");
            sql.AppendLine("on a.cd_tabelapreco = e.cd_tabelapreco ");
            sql.AppendLine("left outer join TB_FIN_TpDuplicata f ");
            sql.AppendLine("on a.tp_duplicata = f.tp_duplicata ");
            sql.AppendLine("left outer join TB_FIN_TpDocto_dup g ");
            sql.AppendLine("on a.tp_docto = g.tp_docto ");
            sql.AppendLine("left outer join TB_FIN_Historico h ");
            sql.AppendLine("on f.cd_historico_dup = h.cd_historico ");
            sql.AppendLine("left outer join tb_div_terminal i ");
            sql.AppendLine("on a.cd_terminal = i.cd_terminal ");
            sql.AppendLine("left outer join tb_fin_condpgto j ");
            sql.AppendLine("on a.cd_condpgto = j.cd_condpgto ");
            sql.AppendLine("left outer join tb_fin_tpduplicata k ");
            sql.AppendLine("on a.tp_duplicataemp = k.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_tpdocto_dup l ");
            sql.AppendLine("on a.tp_doctoemp = l.tp_docto ");

            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, string.Empty), null);
        }

        public override System.Data.DataTable Buscar(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(Utils.TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        public TList_CfgPosto Select(Utils.TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CfgPosto lista = new TList_CfgPosto();
            if (Banco_Dados == null)
                podeFecharBco = CriarBanco_Dados(false);
            System.Data.SqlClient.SqlDataReader reader = ExecutarBusca(SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CfgPosto reg = new TRegistro_CfgPosto();
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("cd_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("nm_empresa"))))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("nm_empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("cd_clifor"))))
                        reg.Cd_clifor = reader.GetString(reader.GetOrdinal("cd_clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_fornecedor")))
                        reg.Cd_fornecedor = reader.GetString(reader.GetOrdinal("cd_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_fornecedor")))
                        reg.Nm_fornecedor = reader.GetString(reader.GetOrdinal("nm_fornecedor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_conveniencia")))
                        reg.Cd_conveniencia = reader.GetString(reader.GetOrdinal("cd_conveniencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("nm_conveniencia")))
                        reg.Nm_conveniencia = reader.GetString(reader.GetOrdinal("nm_conveniencia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_tabelapreco")))
                        reg.Cd_tabelapreco = reader.GetString(reader.GetOrdinal("cd_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tabelapreco")))
                        reg.Ds_tabelapreco = reader.GetString(reader.GetOrdinal("ds_tabelapreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_concentrador")))
                        reg.Tp_concentrador = reader.GetString(reader.GetOrdinal("tp_concentrador"));
                    if (!reader.IsDBNull(reader.GetOrdinal("porta_comunicacao")))
                        reg.Porta_comunicacao = reader.GetDecimal(reader.GetOrdinal("porta_comunicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tmp_abastecimento")))
                        reg.Tmp_abastecimento = reader.GetDecimal(reader.GetOrdinal("tmp_abastecimento"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tmp_abastonline")))
                        reg.Tmp_abastonline = reader.GetDecimal(reader.GetOrdinal("tmp_abastonline"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_leituraencerrantebico")))
                        reg.Tp_leituraencerrantebico = reader.GetString(reader.GetOrdinal("tp_leituraencerrantebico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_calcvltotal")))
                        reg.St_calcvltotal = reader.GetString(reader.GetOrdinal("st_calcvltotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_modoencerrante")))
                        reg.Tp_modoencerrante = reader.GetString(reader.GetOrdinal("tp_modoencerrante"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_alterarpreco")))
                        reg.St_alterarpreco = reader.GetString(reader.GetOrdinal("st_alterarpreco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("vl_multiplochtroco")))
                        reg.Vl_multiplochtroco = reader.GetDecimal(reader.GetOrdinal("vl_multiplochtroco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("host_ip")))
                        reg.Host_ip = reader.GetString(reader.GetOrdinal("host_ip"));
                    if (!reader.IsDBNull(reader.GetOrdinal("porta_ip")))
                        reg.Porta_ip = reader.GetDecimal(reader.GetOrdinal("porta_ip"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicata")))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("tp_duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicata")))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("ds_tpduplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historico_dup")))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("cd_historico_dup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historico")))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_docto")))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("tp_docto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdocto")))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("ds_tpdocto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_terminal")))
                        reg.Cd_terminal = reader.GetString(reader.GetOrdinal("cd_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_terminal")))
                        reg.Ds_terminal = reader.GetString(reader.GetOrdinal("ds_terminal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("St_ChTrocoDireto")))
                        reg.St_chtrocodireto = reader.GetString(reader.GetOrdinal("St_chTrocoDireto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_vendaforaconv")))
                        reg.St_vendaforaconv = reader.GetString(reader.GetOrdinal("st_vendaforaconv"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_identfrentista")))
                        reg.St_identfrentista = reader.GetString(reader.GetOrdinal("st_identfrentista"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_encerrantecaixa")))
                        reg.St_encerrantecaixa = reader.GetString(reader.GetOrdinal("st_encerrantecaixa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_maxabastespera")))
                        reg.Qt_maxabastespera = reader.GetDecimal(reader.GetOrdinal("qt_maxabastespera"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_emitirvale_fid")))
                        reg.St_emitirvale_fid = reader.GetString(reader.GetOrdinal("st_emitirvale_fid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_pontosvale_fid")))
                        reg.Qt_pontosvale_fid = reader.GetDecimal(reader.GetOrdinal("qt_pontosvale_fid"));
                    if (!reader.IsDBNull(reader.GetOrdinal("qt_maxvaledia")))
                        reg.Qt_maxvaledia = reader.GetDecimal(reader.GetOrdinal("qt_maxvaledia"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_msgvale")))
                        reg.Ds_msgvale = reader.GetString(reader.GetOrdinal("ds_msgvale"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FatorConvVolume")))
                        reg.Fatorconvvolume = reader.GetDecimal(reader.GetOrdinal("FatorConvVolume"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FatorConvUnit")))
                        reg.Fatorconvunit = reader.GetDecimal(reader.GetOrdinal("FatorConvUnit"));
                    if (!reader.IsDBNull(reader.GetOrdinal("FatorConvSubTotal")))
                        reg.Fatorconvsubtotal = reader.GetDecimal(reader.GetOrdinal("FatorConvSubTotal"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DiasValidadeVale")))
                        reg.diasValidadeVale = reader.GetDecimal(reader.GetOrdinal("DiasValidadeVale"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_NFDiretaForaUF")))
                        reg.St_NFDiretaForaUF = reader.GetString(reader.GetOrdinal("ST_NFDiretaForaUF"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_condpgto")))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("cd_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_condpgto")))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("ds_condpgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_duplicataemp")))
                        reg.Tp_duplicataemp = reader.GetString(reader.GetOrdinal("tp_duplicataemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpduplicataemp")))
                        reg.Ds_tpduplicataemp = reader.GetString(reader.GetOrdinal("ds_tpduplicataemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("tp_doctoemp")))
                        reg.Tp_doctoemp = reader.GetDecimal(reader.GetOrdinal("tp_doctoemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_tpdoctoemp")))
                        reg.Ds_tpdoctoemp = reader.GetString(reader.GetOrdinal("ds_tpdoctoemp"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_afericaoajustaest")))
                        reg.St_afericaoajustaest = reader.GetString(reader.GetOrdinal("st_afericaoajustaest"));

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

        public string Gravar(TRegistro_CfgPosto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(36);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_CD_FORNECEDOR", val.Cd_fornecedor);
            hs.Add("@P_CD_CONVENIENCIA", val.Cd_conveniencia);
            hs.Add("@P_CD_TABELAPRECO", val.Cd_tabelapreco);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_TERMINAL", val.Cd_terminal);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_TP_DUPLICATAEMP", val.Tp_duplicataemp);
            hs.Add("@P_TP_DOCTOEMP", val.Tp_doctoemp);
            hs.Add("@P_TP_CONCENTRADOR", val.Tp_concentrador);
            hs.Add("@P_PORTA_COMUNICACAO", val.Porta_comunicacao);
            hs.Add("@P_HOST_IP", val.Host_ip);
            hs.Add("@P_PORTA_IP", val.Porta_ip);
            hs.Add("@P_TMP_ABASTECIMENTO", val.Tmp_abastecimento);
            hs.Add("@P_TMP_ABASTONLINE", val.Tmp_abastonline);
            hs.Add("@P_TP_LEITURAENCERRANTEBICO", val.Tp_leituraencerrantebico);
            hs.Add("@P_ST_CALCVLTOTAL", val.St_calcvltotal);
            hs.Add("@P_TP_MODOENCERRANTE", val.Tp_modoencerrante);
            hs.Add("@P_ST_ALTERARPRECO", val.St_alterarpreco);
            hs.Add("@P_VL_MULTIPLOCHTROCO", val.Vl_multiplochtroco);
            hs.Add("@P_ST_CHTROCODIRETO", val.St_chtrocodireto);
            hs.Add("@P_ST_VENDAFORACONV", val.St_vendaforaconv);
            hs.Add("@P_ST_IDENTFRENTISTA", val.St_identfrentista);
            hs.Add("@P_ST_ENCERRANTECAIXA", val.St_encerrantecaixa);
            hs.Add("@P_QT_MAXABASTESPERA", val.Qt_maxabastespera);
            hs.Add("@P_ST_EMITIRVALE_FID", val.St_emitirvale_fid);
            hs.Add("@P_QT_PONTOSVALE_FID", val.Qt_pontosvale_fid);
            hs.Add("@P_QT_MAXVALEDIA", val.Qt_maxvaledia);
            hs.Add("@P_DS_MSGVALE", val.Ds_msgvale);
            hs.Add("@P_FATORCONVVOLUME", val.Fatorconvvolume);
            hs.Add("@P_FATORCONVUNIT", val.Fatorconvunit);
            hs.Add("@P_FATORCONVSUBTOTAL", val.Fatorconvsubtotal);
            hs.Add("@P_DIASVALIDADEVALE", val.diasValidadeVale);
            hs.Add("@P_ST_NFDIRETAFORAUF", val.St_NFDiretaForaUF);
            hs.Add("@P_ST_AFERICAOAJUSTAEST", val.St_afericaoajustaest);

            return executarProc("IA_PDC_CFGPOSTO", hs);
        }

        public string Excluir(TRegistro_CfgPosto val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(1);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);

            return executarProc("EXCLUI_PDC_CFGPOSTO", hs);
        }
    }
}
