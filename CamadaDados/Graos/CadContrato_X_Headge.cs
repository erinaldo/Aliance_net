using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Graos
{
    public class TList_CadContrato_Headge : List<TRegistro_CadContrato_Headge> { }

    
    public class TRegistro_CadContrato_Headge
    {
        private decimal? id_Headge;
        
        public decimal? ID_Headge
        {
            get { return id_Headge; }
            set
            {
                id_Headge = value;
                id_Headgestr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_Headgestr;
        
        public string ID_Headgestr
        {
            get { return id_Headgestr; }
            set
            {
                id_Headgestr = value;
                try
                {
                    id_Headge = Convert.ToDecimal(value);
                }
                catch
                { id_Headge = null; }
            }
        }
        
        public string DS_Headge { get; set; }
        
        public decimal Nr_Contrato { get; set; }
        
        public string TpValor { get; set; }
        
        public string CD_UnidValor { get; set; }
        
        public string SG_UnidValor { get; set; }
        
        public string DS_UnidValor { get; set; }
        
        public string CD_Clifor { get; set; }
        
        public string NM_Clifor { get; set; }
        
        public string CD_Endereco { get; set; }
        
        public string DS_Endereco { get; set; }
        
        public string Tp_Duplicata { get; set; }
        
        public string DS_TpDuplicata { get; set; }
        
        public string CD_CondPgto { get; set; }
        
        public string DS_CondPgto { get; set; }
        
        public decimal Vl_Headge { get; set; }
        
        public decimal Pc_Headge { get; set; }
        
        public string DS_Observacao { get; set; }        

        public TRegistro_CadContrato_Headge()
        {
            this.id_Headge = null;
            this.id_Headgestr = string.Empty;
            this.DS_Headge = string.Empty;
            this.Nr_Contrato = decimal.Zero;
            this.TpValor = string.Empty;
            this.CD_UnidValor = string.Empty;
            this.DS_UnidValor = string.Empty;
            this.SG_UnidValor = string.Empty;
            this.CD_Clifor = string.Empty;
            this.NM_Clifor = string.Empty;
            this.CD_Endereco = string.Empty;
            this.DS_Endereco = string.Empty;
            this.Tp_Duplicata = string.Empty;
            this.DS_TpDuplicata = string.Empty;
            this.CD_CondPgto = string.Empty;
            this.DS_CondPgto = string.Empty;
            this.Vl_Headge = decimal.Zero;
            this.Pc_Headge = decimal.Zero;
            this.DS_Observacao = string.Empty;  
        }

        public TRegistro_CadContrato_Headge Copy()
        {
            return new TRegistro_CadContrato_Headge()
            {
                CD_Clifor = this.CD_Clifor,
                CD_CondPgto = this.CD_CondPgto,
                CD_Endereco = this.CD_Endereco,
                CD_UnidValor = this.CD_UnidValor,
                DS_CondPgto = this.DS_CondPgto,
                DS_Endereco = this.DS_Endereco,
                DS_Headge = this.DS_Headge,
                DS_Observacao = this.DS_Observacao,
                DS_TpDuplicata = this.DS_TpDuplicata,
                DS_UnidValor = this.DS_UnidValor,
                id_Headge = this.id_Headge,
                ID_Headge = this.ID_Headge,
                id_Headgestr = this.id_Headgestr,
                ID_Headgestr = this.ID_Headgestr,
                NM_Clifor = this.NM_Clifor,
                Nr_Contrato = this.Nr_Contrato,
                Pc_Headge = this.Pc_Headge,
                SG_UnidValor = this.SG_UnidValor,
                Tp_Duplicata = this.Tp_Duplicata,
                TpValor = this.TpValor,
                Vl_Headge = this.Vl_Headge
            };
        }
    }

    public class TCD_CadContrato_Headge : TDataQuery
    {
        public TCD_CadContrato_Headge()
        { }

        public TCD_CadContrato_Headge(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("SELECT " + strTop + "a.id_headge, b.ds_headge, a.nr_contrato, ");
                sql.AppendLine("a.tpvalor, a.cd_unidvalor, d.ds_unidade as ds_unidValor, d.Sigla_Unidade as SG_UnidValor,");
                sql.AppendLine("a.cd_clifor, a.cd_endereco, f.ds_endereco,  a.tp_duplicata, g.DS_TpDuplicata, ");
                sql.AppendLine("a.cd_condpgto, h.ds_condpgto, a.vl_headge, a.pc_headge, a.ds_observacao, e.NM_clifor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM tb_gro_Contrato_X_Headge a ");
            sql.AppendLine("join tb_gro_Headge b ");
            sql.AppendLine("on a.id_headge = b.id_headge ");
            
            sql.AppendLine("left outer join tb_est_unidade d ");
            sql.AppendLine("on d.cd_unidade = a.cd_unidvalor ");
            sql.AppendLine("left outer join tb_fin_clifor e ");
            sql.AppendLine("on e.cd_clifor = a.cd_clifor ");
            sql.AppendLine("left outer join tb_fin_endereco f ");
            sql.AppendLine("on f.cd_clifor = a.cd_clifor ");
            sql.AppendLine("and f.cd_endereco = a.cd_endereco ");
            sql.AppendLine("left outer join tb_fin_TpDuplicata g ");
            sql.AppendLine("on g.tp_duplicata = a.tp_duplicata ");
            sql.AppendLine("left outer join tb_fin_CondPgto h ");
            sql.AppendLine("on h.Cd_condPgto = a.cd_condPgto ");


            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            
            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public TList_CadContrato_Headge Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadContrato_Headge lista = new TList_CadContrato_Headge();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadContrato_Headge reg = new TRegistro_CadContrato_Headge();

                    if (!reader.IsDBNull(reader.GetOrdinal("id_headge")))
                        reg.ID_Headge = reader.GetDecimal(reader.GetOrdinal("id_headge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Headge")))
                        reg.DS_Headge = reader.GetString(reader.GetOrdinal("DS_Headge")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("nr_contrato")))
                        reg.Nr_Contrato = reader.GetDecimal(reader.GetOrdinal("nr_contrato"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TpValor")))
                        reg.TpValor = reader.GetString(reader.GetOrdinal("TpValor"));

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_UnidValor")))
                        reg.CD_UnidValor = reader.GetString(reader.GetOrdinal("CD_UnidValor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_UnidValor")))
                        reg.SG_UnidValor = reader.GetString(reader.GetOrdinal("SG_UnidValor")).Trim();                    
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_UnidValor")))
                        reg.DS_UnidValor = reader.GetString(reader.GetOrdinal("DS_UnidValor")).Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Clifor")))
                        reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Clifor")))
                        reg.NM_Clifor = reader.GetString(reader.GetOrdinal("NM_Clifor")).Trim();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Endereco")))
                        reg.CD_Endereco = reader.GetString(reader.GetOrdinal("CD_Endereco"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Endereco")))
                        reg.DS_Endereco = reader.GetString(reader.GetOrdinal("DS_Endereco")).Trim();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Duplicata")))
                        reg.Tp_Duplicata = reader.GetString(reader.GetOrdinal("TP_Duplicata"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TpDuplicata")))
                        reg.DS_TpDuplicata = reader.GetString(reader.GetOrdinal("DS_TpDuplicata")).Trim();
                    
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_CondPgto")))
                        reg.CD_CondPgto = reader.GetString(reader.GetOrdinal("CD_CondPgto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_CondPgto")))
                        reg.DS_CondPgto = reader.GetString(reader.GetOrdinal("DS_CondPgto")).Trim();

                    if (!reader.IsDBNull(reader.GetOrdinal("Vl_Headge")))
                        reg.Vl_Headge = reader.GetDecimal(reader.GetOrdinal("Vl_Headge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_Headge")))
                        reg.Pc_Headge = reader.GetDecimal(reader.GetOrdinal("PC_Headge"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacao")))
                        reg.DS_Observacao = reader.GetString(reader.GetOrdinal("DS_Observacao")).Trim();
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

        public string Grava(TRegistro_CadContrato_Headge vRegistro)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
            hs.Add("@P_NR_CONTRATO", vRegistro.Nr_Contrato);
            hs.Add("@P_TPVALOR", vRegistro.TpValor);
            hs.Add("@P_CD_UNIDVALOR", vRegistro.CD_UnidValor);
            hs.Add("@P_CD_CLIFOR", vRegistro.CD_Clifor);
            hs.Add("@P_CD_ENDERECO", vRegistro.CD_Endereco);
            hs.Add("@P_TP_DUPLICATA", vRegistro.Tp_Duplicata);
            hs.Add("@P_CD_CONDPGTO", vRegistro.CD_CondPgto);
            hs.Add("@P_VL_HEADGE", vRegistro.Vl_Headge);
            hs.Add("@P_PC_HEADGE", vRegistro.Pc_Headge);
            hs.Add("@P_DS_OBSERVACAO", vRegistro.DS_Observacao);

            return this.executarProc("IA_GRO_CONTRATO_X_HEADGE", hs);
        }

        public string Deleta(TRegistro_CadContrato_Headge vRegistro)
        {
            Hashtable hs = new Hashtable(2);
            hs.Add("@P_ID_HEADGE", vRegistro.ID_Headge);
            hs.Add("@P_NR_CONTRATO", vRegistro.Nr_Contrato);
            return this.executarProc("EXCLUI_GRO_CONTRATO_X_HEADGE", hs);
        }

    }
}