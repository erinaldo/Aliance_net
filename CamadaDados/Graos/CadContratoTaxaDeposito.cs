using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;

namespace CamadaDados.Graos
{
   
    public class TList_CadContratoTaxaDeposito : List<TRegistro_CadContratoTaxaDeposito>
    { }

    
    public class TRegistro_CadContratoTaxaDeposito
    {
        
        public decimal Id_reg
        { get; set; }
        private decimal? nr_contrato;
        
        public decimal? Nr_contrato
        {
            get { return nr_contrato; }
            set
            {
                nr_contrato = value;
                nr_contratostr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string nr_contratostr;
        
        public string Nr_contratostr
        {
            get { return nr_contratostr; }
            set
            {
                nr_contratostr = value;
                try
                {
                    nr_contrato = Convert.ToDecimal(value);
                }
                catch
                { nr_contrato = null; }
            }
        }
        private decimal? id_taxa;
        
        public decimal? Id_taxa
        {
            get { return id_taxa; }
            set
            {
                id_taxa = value;
                id_taxastr = (value.HasValue ? value.Value.ToString() : string.Empty);
            }
        }
        private string id_taxastr;
        
        public string Id_taxastr
        {
            get { return id_taxastr; }
            set
            {
                id_taxastr = value;
                try
                {
                    id_taxa = Convert.ToDecimal(value);
                }
                catch
                { id_taxa = null; }
            }
        }
        
        public string Ds_taxa
        { get; set; }
        
        public string Tp_taxa
        { get; set; }
        
        public decimal Valortaxa
        { get; set; }
        
        public string Cd_unidadetaxa
        { get; set; }
        
        public string Ds_unidadetaxa
        { get; set; }
        
        public string Sg_unidadetaxa
        { get; set; }
        
        public decimal Periodocarencia
        { get; set; }
        
        public decimal Frequencia
        { get; set; }
        
        public string Cd_tipoamostra
        { get; set; }
        
        public string Ds_tipoamostra
        { get; set; }
        
        public decimal Pc_result_maiorque
        { get; set; }
        
        public decimal Pc_result_menorque
        { get; set; }
        private string st_gerartxsomente;
        
        public string St_gerartxsomente
        {
            get { return st_gerartxsomente; }
            set
            {
                st_gerartxsomente = value;
                if (value.Trim().ToUpper().Equals("R"))
                    status_gerartxsomente = "RECEBIMENTO";
                else if (value.Trim().ToUpper().Equals("E"))
                    status_gerartxsomente = "EXPEDICAO";
            }
        }
        private string status_gerartxsomente;
        
        public string Status_gerartxsomente
        {
            get { return status_gerartxsomente; }
            set
            {
                status_gerartxsomente = value;
                if (value.Trim().ToUpper().Equals("RECEBIMENTO"))
                    st_gerartxsomente = "R";
                else if (value.Trim().ToUpper().Equals("EXPEDICAO"))
                    st_gerartxsomente = "E";
            }
        }

        public TRegistro_CadContratoTaxaDeposito()
        {
            this.Id_reg = decimal.Zero;
            this.nr_contrato = null;
            this.nr_contratostr = string.Empty;
            this.id_taxa = null;
            this.id_taxastr = string.Empty;
            this.Ds_taxa = string.Empty;
            this.Tp_taxa = string.Empty;
            this.Valortaxa = decimal.Zero;
            this.Cd_unidadetaxa = string.Empty;
            this.Ds_unidadetaxa = string.Empty;
            this.Sg_unidadetaxa = string.Empty;
            this.Periodocarencia = decimal.Zero;
            this.Frequencia = decimal.Zero;
            this.Cd_tipoamostra = string.Empty;
            this.Ds_tipoamostra = string.Empty;
            this.Pc_result_maiorque = decimal.Zero;
            this.Pc_result_menorque = decimal.Zero;
            this.st_gerartxsomente = string.Empty;
            this.status_gerartxsomente = string.Empty;
        }

        public TRegistro_CadContratoTaxaDeposito Copy()
        {
            return new TRegistro_CadContratoTaxaDeposito()
            {
                Cd_tipoamostra = this.Cd_tipoamostra,
                Cd_unidadetaxa = this.Cd_unidadetaxa,
                Ds_taxa = this.Ds_taxa,
                Ds_tipoamostra = this.Ds_tipoamostra,
                Ds_unidadetaxa = this.Ds_unidadetaxa,
                Frequencia = this.Frequencia,
                Id_reg = this.Id_reg,
                id_taxa = this.id_taxa,
                Id_taxa = this.Id_taxa,
                id_taxastr = this.id_taxastr,
                Id_taxastr = this.Id_taxastr,
                nr_contrato = this.nr_contrato,
                Nr_contrato = this.Nr_contrato,
                nr_contratostr = this.nr_contratostr,
                Nr_contratostr = this.Nr_contratostr,
                Pc_result_maiorque = this.Pc_result_maiorque,
                Pc_result_menorque = this.Pc_result_menorque,
                Periodocarencia = this.Periodocarencia,
                Sg_unidadetaxa = this.Sg_unidadetaxa,
                st_gerartxsomente = this.st_gerartxsomente,
                St_gerartxsomente = this.St_gerartxsomente,
                status_gerartxsomente = this.status_gerartxsomente,
                Status_gerartxsomente = this.Status_gerartxsomente,
                Tp_taxa = this.Tp_taxa,
                Valortaxa = this.Valortaxa
            };
        }
    }

    public class TCD_CadContratoTaxaDeposito : TDataQuery
    {
        public TCD_CadContratoTaxaDeposito()
        { }

        public TCD_CadContratoTaxaDeposito(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            string strTop = " ";
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {
                sql.AppendLine("select " + strTop + " a.id_reg, a.nr_contrato, a.id_taxa, ");
                sql.AppendLine("b.ds_taxa, a.valortaxa, a.cd_unidadetaxa, c.ds_unidade as ds_unidadetaxa, ");
                sql.AppendLine("c.sigla_unidade as sg_unidadetaxa, a.periodocarencia, ");
                sql.AppendLine("a.frequencia, a.cd_tipoamostra, d.ds_amostra, ");
                sql.AppendLine("a.pc_result_maiorque, a.pc_result_menorque, ");
                sql.AppendLine("a.st_gerartxsomente, b.tp_taxa ");
            }
            else
                sql.AppendLine(" Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("from tb_gro_contrato_taxadeposito a ");
            sql.AppendLine("inner join tb_gro_taxadeposito b ");
            sql.AppendLine("on a.id_taxa = b.id_taxa ");
            sql.AppendLine("left outer join tb_est_unidade c ");
            sql.AppendLine("on a.cd_unidadetaxa = c.cd_unidade ");
            sql.AppendLine("left outer join tb_gro_amostra d ");
            sql.AppendLine("on a.cd_tipoamostra = d.cd_tipoamostra ");
            
            string cond = " where ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                {
                    sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                    cond = " and ";
                }
            return sql.ToString();
        }

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

        public TList_CadContratoTaxaDeposito Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            bool podeFecharBco = false;
            TList_CadContratoTaxaDeposito lista = new TList_CadContratoTaxaDeposito();
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }
            SqlDataReader reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo));
            try
            {
                while (reader.Read())
                {
                    TRegistro_CadContratoTaxaDeposito reg = new TRegistro_CadContratoTaxaDeposito();

                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_REG"))))
                        reg.Id_reg= reader.GetDecimal(reader.GetOrdinal("ID_REG"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("NR_CONTRATO"))))
                        reg.Nr_contrato = reader.GetDecimal(reader.GetOrdinal("NR_CONTRATO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ID_TAXA"))))
                        reg.Id_taxa = reader.GetDecimal(reader.GetOrdinal("ID_TAXA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_TAXA"))))
                        reg.Ds_taxa = reader.GetString(reader.GetOrdinal("DS_TAXA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Taxa")))
                        reg.Tp_taxa = reader.GetString(reader.GetOrdinal("TP_Taxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("valortaxa"))))
                        reg.Valortaxa = reader.GetDecimal(reader.GetOrdinal("valortaxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_UNIDADETAXA"))))
                        reg.Cd_unidadetaxa = reader.GetString(reader.GetOrdinal("CD_UNIDADETAXA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_UnidadeTaxa"))))
                        reg.Ds_unidadetaxa = reader.GetString(reader.GetOrdinal("DS_UnidadeTaxa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("SG_UnidadeTaxa")))
                        reg.Sg_unidadetaxa = reader.GetString(reader.GetOrdinal("SG_UnidadeTaxa"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PERIODOCARENCIA"))))
                        reg.Periodocarencia = reader.GetDecimal(reader.GetOrdinal("PERIODOCARENCIA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("FREQUENCIA"))))
                        reg.Frequencia = reader.GetDecimal(reader.GetOrdinal("FREQUENCIA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_TIPOAMOSTRA"))))
                       reg.Cd_tipoamostra = reader.GetString(reader.GetOrdinal("CD_TIPOAMOSTRA"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_amostra"))))
                        reg.Ds_tipoamostra = reader.GetString(reader.GetOrdinal("ds_amostra"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_RESULT_MAIORQUE"))))
                       reg.Pc_result_maiorque = reader.GetDecimal(reader.GetOrdinal("PC_RESULT_MAIORQUE"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("PC_RESULT_MENORQUE"))))
                       reg.Pc_result_menorque  = reader.GetDecimal(reader.GetOrdinal("PC_RESULT_MENORQUE"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ST_GERARTXSOMENTE"))))
                        reg.St_gerartxsomente = reader.GetString(reader.GetOrdinal("ST_GERARTXSOMENTE"));

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

        public string GravarContratoTaxaDeposito(TRegistro_CadContratoTaxaDeposito val)
        {
            Hashtable hs = new Hashtable(11);
            hs.Add("@P_ID_REG", val.Id_reg);
			hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
			hs.Add("@P_ID_TAXA", val.Id_taxa);
			hs.Add("@P_VALORTAXA", val.Valortaxa);
			hs.Add("@P_CD_UNIDADETAXA", val.Cd_unidadetaxa);
            hs.Add("@P_PERIODOCARENCIA", val.Periodocarencia);
			hs.Add("@P_FREQUENCIA", val.Frequencia);
			hs.Add("@P_CD_TIPOAMOSTRA", val.Cd_tipoamostra);
			hs.Add("@P_PC_RESULT_MAIORQUE", val.Pc_result_maiorque);
			hs.Add("@P_PC_RESULT_MENORQUE", val.Pc_result_menorque);
            hs.Add("@P_ST_GERARTXSOMENTE", val.St_gerartxsomente);

            return this.executarProc("IA_GRO_CONTRATO_TAXADEPOSITO", hs);
        }

        public string DeletarContratoTaxaDeposito(TRegistro_CadContratoTaxaDeposito val)
        {
            Hashtable hs = new Hashtable(3);
            hs.Add("@P_ID_REG", val.Id_reg);
			hs.Add("@P_NR_CONTRATO", val.Nr_contrato);
			hs.Add("@P_ID_TAXA", val.Id_taxa);

            return this.executarProc("EXCLUI_GRO_CONTRATO_TAXADEPOSITO", hs);
        }
    }
}
