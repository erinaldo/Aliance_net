using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Balanca.Cadastros
{
    public class TList_CFGFinPsAvulsa : List<TRegistro_CFGFinPsAvulsa>, IComparer<TRegistro_CFGFinPsAvulsa>
    {
        #region IComparer<TRegistro_CFGFinPsAvulsa> Members
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

        public TList_CFGFinPsAvulsa()
        { }

        public TList_CFGFinPsAvulsa(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CFGFinPsAvulsa value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CFGFinPsAvulsa x, TRegistro_CFGFinPsAvulsa y)
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

    
    public class TRegistro_CFGFinPsAvulsa
    {
        
        public string Cd_empresa
        { get; set; }
        
        public string Nm_empresa
        { get; set; }
        
        public string Tp_pesagem
        { get; set; }
        
        public string Nm_tppesagem
        { get; set; }
        
        public string Cd_cliforpadrao
        { get; set; }
        
        public string Nm_cliforpadrao
        { get; set; }
        
        public string Cd_endpadrao
        { get; set; }
        
        public string Ds_endpadrao
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
                    tp_docto = Convert.ToDecimal(value);
                }
                catch
                { tp_docto = null; }
            }
        }
        
        public string Ds_tpdocto
        { get; set; }
        
        public string Cd_condpgto
        { get; set; }
        
        public string Ds_condpgto
        { get; set; }
        
        public string Cd_portador
        { get; set; }
        
        public string Ds_portador
        { get; set; }
        
        public string Cd_juro
        { get; set; }
        
        public string Ds_juro
        { get; set; }
        
        public string Cd_moeda
        { get; set; }
        
        public string Ds_moeda
        { get; set; }
        
        public string Tp_duplicata
        { get; set; }
        
        public string Ds_tpduplicata
        { get; set; }
        
        public string Cd_historico
        { get; set; }
        
        public string Ds_historico
        { get; set; }
        
        public string Cd_contager
        { get; set; }
        
        public string Ds_contager
        { get; set; }
        
        public string Tp_mov
        { get; set; }

        public TRegistro_CFGFinPsAvulsa()
        {
            this.Cd_empresa = string.Empty;
            this.Nm_empresa = string.Empty;
            this.Tp_pesagem = string.Empty;
            this.Nm_tppesagem = string.Empty;
            this.Cd_cliforpadrao = string.Empty;
            this.Nm_cliforpadrao = string.Empty;
            this.Cd_endpadrao = string.Empty;
            this.Ds_endpadrao = string.Empty;
            this.tp_docto = null;
            this.tp_doctostr = string.Empty;
            this.Ds_tpdocto = string.Empty;
            this.Cd_condpgto = string.Empty;
            this.Ds_condpgto = string.Empty;
            this.Cd_portador = string.Empty;
            this.Ds_portador = string.Empty;
            this.Cd_juro = string.Empty;
            this.Ds_juro = string.Empty;
            this.Cd_moeda = string.Empty;
            this.Ds_moeda = string.Empty;
            this.Tp_duplicata = string.Empty;
            this.Ds_tpduplicata = string.Empty;
            this.Cd_historico = string.Empty;
            this.Ds_historico = string.Empty;
            this.Cd_contager = string.Empty;
            this.Ds_contager = string.Empty;
            this.Tp_mov = string.Empty;
        }
    }

    public class TCD_CFGFinPsAvulsa : TDataQuery
    {
        public TCD_CFGFinPsAvulsa()
        { }

        public TCD_CFGFinPsAvulsa(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("Select " + strTop + " a.CD_Empresa, b.NM_Empresa, ");
                sql.AppendLine("a.Tp_Pesagem, c.NM_TpPesagem, ");
                sql.AppendLine("a.CD_CliforPadrao, d.NM_Clifor, ");
                sql.AppendLine("a.CD_EndPadrao, e.DS_Endereco, ");
                sql.AppendLine("a.Tp_Docto, f.DS_TpDocto, ");
                sql.AppendLine("a.TP_Duplicata, g.DS_TpDuplicata, g.tp_mov, ");
                sql.AppendLine("a.CD_Historico, h.DS_Historico, ");
                sql.AppendLine("a.CD_CondPGTO, i.DS_CondPGTO, ");
                sql.AppendLine("i.CD_Portador, j.DS_Portador, ");
                sql.AppendLine("i.CD_Juro, k.DS_Juro, ");
                sql.AppendLine("i.CD_Moeda, l.DS_Moeda_Singular, ");
                sql.AppendLine("a.CD_ContaGer, m.DS_ContaGer ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from TB_BAL_CFGFinPsAvulsa a ");
            sql.AppendLine("inner join TB_DIV_Empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("inner join TB_BAL_TpPesagem c ");
            sql.AppendLine("on a.Tp_Pesagem = c.Tp_Pesagem ");
            sql.AppendLine("inner join VTB_FIN_CLIFOR d ");
            sql.AppendLine("on a.CD_CliforPadrao = d.CD_Clifor ");
            sql.AppendLine("inner join VTB_FIN_ENDERECO e ");
            sql.AppendLine("on a.CD_CliforPadrao = e.CD_Clifor ");
            sql.AppendLine("and a.CD_EndPadrao = e.CD_Endereco ");
            sql.AppendLine("inner join TB_FIN_TPDocto_Dup f ");
            sql.AppendLine("on a.Tp_Docto = f.Tp_Docto ");
            sql.AppendLine("inner join TB_FIN_TPDuplicata g ");
            sql.AppendLine("on a.TP_Duplicata = g.TP_Duplicata ");
            sql.AppendLine("inner join TB_FIN_Historico h ");
            sql.AppendLine("on a.CD_Historico = h.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_CondPGTO i ");
            sql.AppendLine("on a.CD_CondPGTO = i.CD_CondPGTO ");
            sql.AppendLine("left outer join TB_FIN_Portador j ");
            sql.AppendLine("on i.CD_Portador = j.CD_Portador ");
            sql.AppendLine("left outer join TB_FIN_Juro k ");
            sql.AppendLine("on i.CD_Juro = k.CD_Juro ");
            sql.AppendLine("left outer join TB_FIN_Moeda l ");
            sql.AppendLine("on i.CD_Moeda = l.DS_Moeda_Singular ");
            sql.AppendLine("left outer join TB_FIN_ContaGer m ");
            sql.AppendLine("on a.CD_ContaGer = m.CD_ContaGer ");

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

        public TList_CFGFinPsAvulsa Select(Utils.TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            TList_CFGFinPsAvulsa lista = new TList_CFGFinPsAvulsa();
            bool podeFecharBco = false;
            if (this.Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            System.Data.SqlClient.SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CFGFinPsAvulsa reg = new TRegistro_CFGFinPsAvulsa();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Empresa"))))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("CD_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.Nm_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Pesagem"))))
                        reg.Tp_pesagem = reader.GetString(reader.GetOrdinal("TP_Pesagem"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_TpPesagem")))
                        reg.Nm_tppesagem = reader.GetString(reader.GetOrdinal("NM_TpPesagem"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CliforPadrao"))))
                        reg.Cd_cliforpadrao = reader.GetString(reader.GetOrdinal("CD_CliforPadrao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NM_Clifor"))))
                        reg.Nm_cliforpadrao = reader.GetString(reader.GetOrdinal("NM_Clifor"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_EndPadrao"))))
                        reg.Cd_endpadrao = reader.GetString(reader.GetOrdinal("CD_EndPadrao"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Endereco"))))
                        reg.Ds_endpadrao = reader.GetString(reader.GetOrdinal("DS_Endereco"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("Tp_Docto"))))
                        reg.Tp_docto = reader.GetDecimal(reader.GetOrdinal("Tp_Docto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDocto"))))
                        reg.Ds_tpdocto = reader.GetString(reader.GetOrdinal("DS_TpDocto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Duplicata"))))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata"))))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Mov")))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_Mov"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico"))))
                        reg.Cd_historico = reader.GetString(reader.GetOrdinal("CD_Historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Historico"))))
                        reg.Ds_historico = reader.GetString(reader.GetOrdinal("DS_Historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_CondPGTO"))))
                        reg.Cd_condpgto = reader.GetString(reader.GetOrdinal("CD_CondPGTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_CondPGTO"))))
                        reg.Ds_condpgto = reader.GetString(reader.GetOrdinal("DS_CondPGTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Portador"))))
                        reg.Cd_portador = reader.GetString(reader.GetOrdinal("CD_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Portador"))))
                        reg.Ds_portador = reader.GetString(reader.GetOrdinal("DS_Portador"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Juro"))))
                        reg.Cd_juro = reader.GetString(reader.GetOrdinal("CD_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Juro"))))
                        reg.Ds_juro = reader.GetString(reader.GetOrdinal("DS_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Moeda"))))
                        reg.Cd_moeda = reader.GetString(reader.GetOrdinal("CD_Moeda"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_Moeda_Singular"))))
                        reg.Ds_moeda = reader.GetString(reader.GetOrdinal("DS_Moeda_Singular"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_ContaGer"))))
                        reg.Cd_contager = reader.GetString(reader.GetOrdinal("CD_ContaGer"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_ContaGer"))))
                        reg.Ds_contager = reader.GetString(reader.GetOrdinal("DS_ContaGer"));

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

        public string GravarCFGFinPsAvulsa(TRegistro_CFGFinPsAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(9);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);
            hs.Add("@P_CD_CLIFORPADRAO", val.Cd_cliforpadrao);
            hs.Add("@P_CD_ENDPADRAO", val.Cd_endpadrao);
            hs.Add("@P_TP_DOCTO", val.Tp_docto);
            hs.Add("@P_CD_CONDPGTO", val.Cd_condpgto);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_CD_HISTORICO", val.Cd_historico);
            hs.Add("@P_CD_CONTAGER", val.Cd_contager);

            return this.executarProc("IA_BAL_CFGFINPSAVULSA", hs);
        }

        public string DeletarCFGFinPsAvulsa(TRegistro_CFGFinPsAvulsa val)
        {
            System.Collections.Hashtable hs = new System.Collections.Hashtable(2);
            hs.Add("@P_CD_EMPRESA", val.Cd_empresa);
            hs.Add("@P_TP_PESAGEM", val.Tp_pesagem);

            return this.executarProc("EXCLUI_BAL_CFGFINPSAVULSA", hs);
        }
    }
}
