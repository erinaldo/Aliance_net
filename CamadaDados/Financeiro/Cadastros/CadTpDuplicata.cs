using System;
using System.Collections.Generic;
using System.Collections;
using Utils;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
	public class TList_CadTpDuplicata : List<TRegistro_CadTpDuplicata>, IComparer<TRegistro_CadTpDuplicata>
    {
        #region IComparer<TRegistro_CadTpDuplicata> Members
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

        public TList_CadTpDuplicata()
        { }

        public TList_CadTpDuplicata(System.ComponentModel.PropertyDescriptor Prop,
                                    System.Windows.Forms.SortOrder Dir)
        { 
            Propriedade = Prop;
            Direcao = Dir;
        }

        private object GetPropertyValue(TRegistro_CadTpDuplicata value,
                                        string Propriedade)
        {
            System.Reflection.PropertyInfo pInfo =
                value.GetType().GetProperty(Propriedade);
            return pInfo.GetValue(value, null);
        }

        public int Compare(TRegistro_CadTpDuplicata x, TRegistro_CadTpDuplicata y)
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
    
    public class TRegistro_CadTpDuplicata
    {
        public string Tp_duplicata { get; set; }
        public string Ds_tpduplicata { get; set; }
        private string tp_mov;
        public string Tp_mov 
        {
            get { return tp_mov; }
            set
            {
                tp_mov = value;
                if (value.Trim().ToUpper().Equals("P"))
                    tipo_mov = "PAGAR";
                else if (value.Trim().ToUpper().Equals("R"))
                    tipo_mov = "RECEBER";
            }
        }
        private string tipo_mov;
        public string Tipo_mov
        {
            get { return tipo_mov; }
            set
            {
                tipo_mov = value;
                if (value.Trim().ToUpper().Equals("PAGAR"))
                    tp_mov = "P";
                else if (value.Trim().ToUpper().Equals("RECEBER"))
                    tp_mov = "R";
            }
        }
        public string Cd_historico_dup { get; set; }
        public string Ds_historico_dup { get; set; }
        public string Cd_historico_juro { get; set; }
        public string Ds_historico_juro { get; set; }
        public string Cd_historico_desconto { get; set; }
        public string Ds_historico_desconto { get; set; }
        public string Cd_historico_dcamb_ativa { get; set; }
        public string Ds_historico_dcamb_ativa { get; set; }
        public string Cd_historico_dcamb_passiva { get; set; }
        public string Ds_historico_dcamb_passiva { get; set; }
        public string Cd_historico_trocoCH { get; set; }
        public string Ds_historico_trocoCH { get; set; }
        public string Cd_portadoragrupar
        { get; set; }
        public string Ds_portadoragrupar
        { get; set; }
        public string Cd_contageragrupar
        { get; set; }
        public string Ds_contageragrupar
        { get; set; }
        public string Cd_historicoagrup
        { get; set; }
        public string Ds_historicoagrup
        { get; set; }
        public string Cd_historicoquitacaoagrup
        { get; set; }
        public string Ds_historicoquitacaoagrup
        { get; set; }
        public string Cd_portadorperdadup
        { get; set; }
        public string Ds_portadorperdadup
        { get; set; }
        public string Cd_contagerperdadup
        { get; set; }
        public string Ds_contagerperdadup
        { get; set; }
        public string Cd_historicoperdadup
        { get; set; }
        public string Ds_historicoperdadup
        { get; set; }
        public string Cd_historicoquitperdadup
        { get; set; }
        public string Ds_historicoquitperdadup
        { get; set; }
        private decimal? id_configboleto;
        public decimal? Id_configboleto
        {
            get { return id_configboleto; }
            set
            {
                id_configboleto = value;
                id_configboletostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string id_configboletostr;
        public string Id_configboletostr
        {
            get { return id_configboletostr; }
            set
            {
                id_configboletostr = value;
                try
                {
                    id_configboleto = decimal.Parse(value);
                }
                catch { id_configboleto = null; }
            }
        }
        public string Ds_configboleto
        { get; set; }
        public string St_registro { get; set; }
        public bool St_processar
        { get; set; }

        public TRegistro_CadTpDuplicata()
        {
            this.Tp_duplicata = string.Empty;
            this.Ds_tpduplicata = string.Empty;
            this.Tp_mov = string.Empty;
            this.tipo_mov = string.Empty;
            this.Cd_historico_dup = string.Empty;
            this.Ds_historico_dup = string.Empty;
            this.Cd_historico_juro = string.Empty;
            this.Ds_historico_juro = string.Empty;
            this.Cd_historico_desconto = string.Empty;
            this.Ds_historico_desconto = string.Empty;
            this.Cd_historico_dcamb_ativa = string.Empty;
            this.Ds_historico_dcamb_ativa = string.Empty;
            this.Cd_historico_dcamb_passiva = string.Empty;
            this.Ds_historico_dcamb_passiva = string.Empty;
            this.Cd_historico_trocoCH = string.Empty;
            this.Ds_historico_trocoCH = string.Empty;
            this.Cd_portadoragrupar = string.Empty;
            this.Ds_portadoragrupar = string.Empty;
            this.Cd_contageragrupar = string.Empty;
            this.Ds_contageragrupar = string.Empty;
            this.Cd_historicoagrup = string.Empty;
            this.Ds_historicoagrup = string.Empty;
            this.Cd_historicoquitacaoagrup = string.Empty;
            this.Ds_historicoquitacaoagrup = string.Empty;
            this.Cd_portadorperdadup = string.Empty;
            this.Ds_portadorperdadup = string.Empty;
            this.Cd_contagerperdadup = string.Empty;
            this.Ds_contagerperdadup = string.Empty;
            this.Cd_historicoperdadup = string.Empty;
            this.Ds_historicoperdadup = string.Empty;
            this.Cd_historicoquitperdadup = string.Empty;
            this.Ds_historicoquitperdadup = string.Empty;
            this.id_configboleto = null;
            this.id_configboletostr = string.Empty;
            this.Ds_configboleto = string.Empty;
            this.St_registro = "A";
            this.St_processar = false;
        }
    }

    public class TCD_CadTpDuplicata : TDataQuery
    {
        public TCD_CadTpDuplicata()
        { }

        public TCD_CadTpDuplicata(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }
        
        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " TP_Duplicata, DS_TpDuplicata, a.DT_Cad, a.DT_Alt, a.st_registro, ");
                sql.AppendLine("a.TP_MOV, a.id_config, cg.ds_config, ");
                sql.AppendLine(" a.CD_Historico_Juro, c.DS_Historico as DS_Historico_Juro, ");
                sql.AppendLine("a.CD_Historico_Desconto, d.DS_Historico as DS_Historico_Desconto, ");
                sql.AppendLine("a.CD_Historico_Dup, e.DS_Historico as DS_Historico_Dup, ");
                sql.AppendLine("a.CD_Historico_DCamb_Ativa, f.DS_Historico as DS_Historico_DCamb_Ativa, ");
                sql.AppendLine("a.CD_Historico_DCamb_Passiva, g.DS_Historico as DS_Historico_DCamb_Passiva, ");
                sql.AppendLine("a.CD_Historico_TrocoCH, i.DS_Historico as DS_Historico_TrocoCH, ");
                sql.AppendLine("a.CD_PortadorAgrupar, j.ds_portador as DS_PortadorAgrupar, ");
                sql.AppendLine("a.CD_ContaGerAgrupar, k.ds_contager as DS_ContaGerAgrupar, ");
                sql.AppendLine("a.CD_HistoricoAgrup, l.ds_historico as DS_HistoricoAgrup, ");
                sql.AppendLine("a.cd_historicoquitacaoagrup, m.ds_historico as ds_historicoquitacaoagrup, ");
                sql.AppendLine("a.cd_portadorperdadup, n.ds_portador as ds_portadorperdadup, ");
                sql.AppendLine("a.cd_contagerperdadup, o.ds_contager as ds_contagerperdadup, ");
                sql.AppendLine("a.cd_historicoperdadup, p.ds_historico as ds_historicoperdadup, ");
                sql.AppendLine("a.cd_historicoquitperdadup, q.ds_historico as ds_historicoquitperdadup ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIN_TpDuplicata a ");
            sql.AppendLine("left outer join TB_FIN_Historico c ");
            sql.AppendLine("On c.CD_Historico = a.CD_Historico_Juro ");
            sql.AppendLine("left outer join TB_FIN_Historico d ");
            sql.AppendLine("On d.CD_Historico = a.CD_Historico_Desconto ");
            sql.AppendLine("left outer join TB_FIN_Historico e ");
            sql.AppendLine("On e.CD_Historico = a.CD_Historico_Dup ");
            sql.AppendLine("left outer join TB_FIN_Historico f ");
            sql.AppendLine("On f.CD_Historico = a.CD_Historico_DCamb_Ativa ");
            sql.AppendLine("left outer join TB_FIN_Historico g ");
            sql.AppendLine("On g.CD_Historico = a.CD_Historico_DCamb_Passiva ");
            sql.AppendLine("left outer join TB_Cob_CfgBanco cg ");
            sql.AppendLine("On cg.ID_Config = a.ID_Config ");
            sql.AppendLine("left outer join TB_FIN_Historico i ");
            sql.AppendLine("On i.CD_Historico = a.CD_Historico_TrocoCH ");
            sql.AppendLine("left outer join TB_FIN_Portador j ");
            sql.AppendLine("On a.CD_PortadorAgrupar = j.CD_Portador ");
            sql.AppendLine("left outer join TB_FIN_ContaGer k ");
            sql.AppendLine("On a.CD_ContaGerAgrupar = k.CD_ContaGer ");
            sql.AppendLine("left outer join TB_FIN_Historico l ");
            sql.AppendLine("On a.CD_HistoricoAgrup = l.CD_Historico ");
            sql.AppendLine("left outer join TB_FIN_Historico m ");
            sql.AppendLine("on a.cd_historicoquitacaoagrup = m.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_Portador n ");
            sql.AppendLine("on a.cd_portadorperdadup = n.cd_portador ");
            sql.AppendLine("left outer join TB_FIN_ContaGer o ");
            sql.AppendLine("on a.cd_contagerperdadup = o.cd_contager ");
            sql.AppendLine("left outer join TB_FIN_Historico p ");
            sql.AppendLine("on a.cd_historicoperdadup = p.cd_historico ");
            sql.AppendLine("left outer join TB_FIN_Historico q ");
            sql.AppendLine("on a.cd_historicoquitperdadup = q.cd_historico ");

            sql.AppendLine("Where isNull(a.ST_Registro, 'A') <> 'C'");
            string cond = " and ";

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
            return sql.ToString();
        }
        
        public TList_CadTpDuplicata Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadTpDuplicata lista = new TList_CadTpDuplicata();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadTpDuplicata reg = new TRegistro_CadTpDuplicata();
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_Duplicata"))))
                        reg.Tp_duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata"))))
                        reg.Ds_tpduplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_MOV"))))
                        reg.Tp_mov = reader.GetString(reader.GetOrdinal("TP_MOV"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Dup"))))
                        reg.Cd_historico_dup = reader.GetString(reader.GetOrdinal("CD_Historico_Dup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_Dup")))
                        reg.Ds_historico_dup = reader.GetString(reader.GetOrdinal("DS_Historico_Dup"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Juro"))))
                        reg.Cd_historico_juro = reader.GetString(reader.GetOrdinal("CD_Historico_Juro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_Juro")))
                        reg.Ds_historico_juro = reader.GetString(reader.GetOrdinal("DS_Historico_Juro"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_Desconto"))))
                        reg.Cd_historico_desconto = reader.GetString(reader.GetOrdinal("CD_Historico_Desconto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_Desconto")))
                        reg.Ds_historico_desconto = reader.GetString(reader.GetOrdinal("DS_Historico_Desconto"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_DCamb_Ativa"))))
                        reg.Cd_historico_dcamb_ativa = reader.GetString(reader.GetOrdinal("CD_Historico_DCamb_Ativa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_DCamb_Ativa")))
                        reg.Ds_historico_dcamb_ativa = reader.GetString(reader.GetOrdinal("DS_Historico_DCamb_Ativa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_Historico_DCamb_Passiva"))))
                        reg.Cd_historico_dcamb_passiva = reader.GetString(reader.GetOrdinal("CD_Historico_DCamb_Passiva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_DCamb_Passiva")))
                        reg.Ds_historico_dcamb_passiva = reader.GetString(reader.GetOrdinal("DS_Historico_DCamb_Passiva"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Historico_TrocoCH")))
                        reg.Cd_historico_trocoCH = reader.GetString(reader.GetOrdinal("CD_Historico_TrocoCH"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Historico_TrocoCH")))
                        reg.Ds_historico_trocoCH = reader.GetString(reader.GetOrdinal("DS_Historico_TrocoCH"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_Registro"))))
                        reg.St_registro = reader.GetString(reader.GetOrdinal("ST_Registro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("id_config")))
                        reg.Id_configboleto = reader.GetDecimal(reader.GetOrdinal("id_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_config")))
                        reg.Ds_configboleto = reader.GetString(reader.GetOrdinal("ds_config"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PortadorAgrupar")))
                        reg.Cd_portadoragrupar = reader.GetString(reader.GetOrdinal("CD_PortadorAgrupar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PortadorAgrupar")))
                        reg.Ds_portadoragrupar = reader.GetString(reader.GetOrdinal("DS_PortadorAgrupar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaGerAgrupar")))
                        reg.Cd_contageragrupar = reader.GetString(reader.GetOrdinal("CD_ContaGerAgrupar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_ContaGerAgrupar")))
                        reg.Ds_contageragrupar = reader.GetString(reader.GetOrdinal("DS_ContaGerAgrupar"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_HistoricoAgrup")))
                        reg.Cd_historicoagrup = reader.GetString(reader.GetOrdinal("CD_HistoricoAgrup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_HistoricoAgrup")))
                        reg.Ds_historicoagrup = reader.GetString(reader.GetOrdinal("ds_historicoagrup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoquitacaoagrup")))
                        reg.Cd_historicoquitacaoagrup = reader.GetString(reader.GetOrdinal("cd_historicoquitacaoagrup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicoquitacaoagrup")))
                        reg.Ds_historicoquitacaoagrup = reader.GetString(reader.GetOrdinal("ds_historicoquitacaoagrup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_portadorperdadup")))
                        reg.Cd_portadorperdadup = reader.GetString(reader.GetOrdinal("cd_portadorperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_portadorperdadup")))
                        reg.Ds_portadorperdadup = reader.GetString(reader.GetOrdinal("ds_portadorperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contagerperdadup")))
                        reg.Cd_contagerperdadup = reader.GetString(reader.GetOrdinal("cd_contagerperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contagerperdadup")))
                        reg.Ds_contagerperdadup = reader.GetString(reader.GetOrdinal("ds_contagerperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoperdadup")))
                        reg.Cd_historicoperdadup = reader.GetString(reader.GetOrdinal("cd_historicoperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicoperdadup")))
                        reg.Ds_historicoperdadup = reader.GetString(reader.GetOrdinal("ds_historicoperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_historicoquitperdadup")))
                        reg.Cd_historicoquitperdadup = reader.GetString(reader.GetOrdinal("cd_historicoquitperdadup"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_historicoquitperdadup")))
                        reg.Ds_historicoquitperdadup = reader.GetString(reader.GetOrdinal("ds_historicoquitperdadup"));

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

        public string Gravar(TRegistro_CadTpDuplicata val)
        {
            Hashtable hs = new Hashtable(19);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);
            hs.Add("@P_DS_TPDUPLICATA", val.Ds_tpduplicata);
            hs.Add("@P_TP_MOV", val.Tp_mov);
            hs.Add("@P_CD_HISTORICO_DUP", val.Cd_historico_dup);
            hs.Add("@P_CD_HISTORICO_JURO", val.Cd_historico_juro);
            hs.Add("@P_CD_HISTORICO_DESCONTO", val.Cd_historico_desconto);
            hs.Add("@P_CD_HISTORICO_DCAMB_ATIVA", val.Cd_historico_dcamb_ativa);
            hs.Add("@P_CD_HISTORICO_DCAMB_PASSIVA", val.Cd_historico_dcamb_passiva);
            hs.Add("@P_CD_HISTORICO_TROCOCH", val.Cd_historico_trocoCH);
            hs.Add("@P_ID_CONFIG", val.Id_configboleto);
            hs.Add("@P_CD_PORTADORAGRUPAR", val.Cd_portadoragrupar);
            hs.Add("@P_CD_CONTAGERAGRUPAR", val.Cd_contageragrupar);
            hs.Add("@P_CD_HISTORICOAGRUP", val.Cd_historicoagrup);
            hs.Add("@P_CD_HISTORICOQUITACAOAGRUP", val.Cd_historicoquitacaoagrup);
            hs.Add("@P_CD_PORTADORPERDADUP", val.Cd_portadorperdadup);
            hs.Add("@P_CD_CONTAGERPERDADUP", val.Cd_contagerperdadup);
            hs.Add("@P_CD_HISTORICOPERDADUP", val.Cd_historicoperdadup);
            hs.Add("@P_CD_HISTORICOQUITPERDADUP", val.Cd_historicoquitperdadup);
            hs.Add("@P_ST_REGISTRO", val.St_registro);
            
            return executarProc("IA_FIN_TPDUPLICATA", hs);

        }

        public string Excluir(TRegistro_CadTpDuplicata val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_TP_DUPLICATA", val.Tp_duplicata);

            return executarProc("EXCLUI_FIN_TPDUPLICATA", hs);
        }
    }
}
