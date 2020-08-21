using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CamadaDados.Contabil.Cadastro
{

    public class TList_Cad_CTB_ParamZeramento : List<TRegistro_Cad_CTB_ParamZeramento>
    { }

    public class TRegistro_Cad_CTB_ParamZeramento
    {
        public string Cd_empresa
        { get; set; }
        public string ds_empresa
        { get; set; }

        private decimal? cd_CReceitas;
        public decimal? Cd_CReceitas
        {
            get { return cd_CReceitas; }
            set
            {
                cd_CReceitas = value;
                cd_CReceitasstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_CReceitasstr;
        public string Cd_CReceitasstr
        {
            get { return cd_CReceitasstr; }
            set
            {
                cd_CReceitasstr = value;
                try
                {
                    cd_CReceitas = Convert.ToDecimal(value);
                }
                catch
                { cd_CReceitas = null; }
            }
        }
        public string ds_creceitas
        { get; set; }
        public string Cd_classifreceitas
        { get; set; }

        private decimal? cd_CDespesas;
        public decimal? Cd_CDespesas
        {
            get { return cd_CDespesas; }
            set
            {
                cd_CDespesas = value;
                cd_CDespesasstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_CDespesasstr;
        public string Cd_CDespesasstr
        {
            get { return cd_CDespesasstr; }
            set
            {
                cd_CDespesasstr = value;
                try
                {
                    cd_CDespesas = Convert.ToDecimal(value);
                }
                catch
                { cd_CDespesas = null; }
            }
        }
        public string ds_despesas
        { get; set; }
        public string Cd_classifdespesas
        { get; set; }

        private decimal? cd_cLucro;
        public decimal? Cd_cLucro
        {
            get { return cd_cLucro; }
            set
            {
                cd_cLucro = value;
                cd_cLucrostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_cLucrostr;
        public string Cd_cLucrostr
        {
            get { return cd_cLucrostr; }
            set
            {
                cd_cLucrostr = value;
                try
                {
                    cd_cLucro = Convert.ToDecimal(value);
                }
                catch
                { cd_cLucro = null; }
            }
        }
        public string ds_lucro
        { get; set; }
        public string Cd_classiflucro
        { get; set; }

        private decimal? cd_cCusto;
        public decimal? Cd_cCusto
        {
            get { return cd_cCusto; }
            set
            {
                cd_cCusto = value;
                cd_cCustostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_cCustostr;
        public string Cd_cCustostr
        {
            get { return cd_cCustostr; }
            set
            {
                cd_cCustostr = value;
                try
                {
                    cd_cCusto = Convert.ToDecimal(value);
                }
                catch
                { cd_cCusto = null; }
            }
        }
        public string ds_custo
        { get; set; }
        public string Cd_classifcusto
        { get; set; }

        private decimal? cd_cResultadoL;
        public decimal? Cd_cResultadoL
        {
            get { return cd_cResultadoL; }
            set
            {
                cd_cResultadoL = value;
                cd_cResultadoLstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_cResultadoLstr;
        public string Cd_cResultadoLstr
        {
            get { return cd_cResultadoLstr; }
            set
            {
                cd_cResultadoLstr = value;
                try
                {
                    cd_cResultadoL = Convert.ToDecimal(value);
                }
                catch
                { cd_cResultadoL = null; }
            }
        }
        public string ds_resultadoL
        { get; set; }
        public string Cd_classifresultadoL
        { get; set; }

        private decimal? cd_contaresultado;
        public decimal? Cd_contaresultado
        {
            get { return cd_contaresultado; }
            set
            {
                cd_contaresultado = value;
                cd_contaresultadostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_contaresultadostr;
        public string Cd_contaresultadostr
        {
            get { return cd_contaresultadostr; }
            set
            {
                cd_contaresultadostr = value;
                try
                {
                    cd_contaresultado = decimal.Parse(value);
                }
                catch { cd_contaresultado = null; }
            }
        }
        public string Ds_contaresultado
        { get; set; }
        public string Cd_classifresultado
        { get; set; }

        private decimal? cd_cResultadoP;
        public decimal? Cd_cResultadoP
        {
            get { return cd_cResultadoP; }
            set
            {
                cd_cResultadoP = value;
                cd_cResultadoPstr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_cResultadoPstr;
        public string Cd_cResultadoPstr
        {
            get { return cd_cResultadoPstr; }
            set
            {
                cd_cResultadoPstr = value;
                try
                {
                    cd_cResultadoP = decimal.Parse(value);
                }
                catch { cd_cResultadoP = null; }
            }
        }
        public string Ds_resultadoP
        { get; set; }
        public string Cd_classifresultadoP
        { get; set; }

        public  TRegistro_Cad_CTB_ParamZeramento() 
        {
            this.Cd_empresa = string.Empty;
            this.Cd_CReceitas = null;
            this.Cd_cCusto = null;
            this.Cd_CDespesas = null;
            this.Cd_cLucro = null;
            this.cd_contaresultado = null;
            this.cd_contaresultadostr = string.Empty;
            this.Cd_classifresultado = string.Empty;
            this.cd_cResultadoL = null;
            this.cd_cResultadoP = null;
            this.ds_creceitas = string.Empty;
            this.ds_custo = string.Empty;
            this.ds_despesas = string.Empty;
            this.ds_empresa = string.Empty;
            this.ds_lucro = string.Empty;
            this.ds_resultadoL = string.Empty;
            this.Ds_resultadoP = string.Empty;
            this.Cd_classifcusto = string.Empty;
            this.Cd_classifdespesas = string.Empty;
            this.Cd_classiflucro = string.Empty;
            this.Cd_classifreceitas = string.Empty;
            this.Cd_classifresultadoL = string.Empty;
            this.Cd_classifresultadoP = string.Empty;
        }
    }

    public class TCD_Cad_CTB_ParamZeramento : TDataQuery
    {
        public TCD_Cad_CTB_ParamZeramento()
        { }

        public TCD_Cad_CTB_ParamZeramento(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);
            StringBuilder sql = new StringBuilder();

            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine(" SELECT " + strTop + " B.NM_Empresa, C.DS_ContaCTB AS ds_cReceitas, D.DS_ContaCTB AS ds_cDespesas, ");
                sql.AppendLine("E.DS_ContaCTB AS ds_cLucro, F.DS_ContaCTB AS ds_cCusta, G.DS_ContaCTB AS ds_cResultadoL, ");
                sql.AppendLine("B.CD_Empresa as CD_EMPRESA, C.CD_Conta_CTB AS CD_cReceitas, D.CD_Conta_CTB AS CD_cDespesas, ");
                sql.AppendLine("E.CD_Conta_CTB AS CD_cLucro, F.CD_Conta_CTB AS CD_cCusta, G.CD_Conta_CTB AS CD_cResultadoL, ");
                sql.AppendLine("c.cd_classificacao as Cd_classifReceita, d.cd_classificacao as Cd_classifDespesa, ");
                sql.AppendLine("e.cd_classificacao as Cd_classifLucro, f.cd_classificacao as Cd_classifCusto, ");
                sql.AppendLine("g.cd_classificacao as Cd_classifResultadoL, a.CD_ContaResultadoP, ");
                sql.AppendLine("h.ds_contactb as Ds_resultadoP, h.cd_classificacao as Cd_ClassifResultadoP, ");
                sql.AppendLine("a.cd_contaresultado, r.ds_contactb as ds_contaresultado, r.cd_classificacao as cd_classifresultado ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("FROM  tb_ctb_paramzeramento a ");
            sql.AppendLine("join tb_div_empresa b ");
            sql.AppendLine("on a.CD_Empresa = b.CD_Empresa ");
            sql.AppendLine("join TB_CTB_PlanoContas c ");
            sql.AppendLine("on a.CD_ContaReceitas = c.CD_Conta_CTB ");
            sql.AppendLine("join TB_CTB_PlanoContas d ");
            sql.AppendLine("on a.CD_ContaDespesas = d.CD_Conta_CTB ");
            sql.AppendLine("join TB_CTB_PlanoContas r ");
            sql.AppendLine("on a.CD_ContaResultado = r.CD_Conta_CTB ");
            sql.AppendLine("left join TB_CTB_PlanoContas e  ");
            sql.AppendLine("on a.CD_ContaLucro = e.CD_Conta_CTB ");
            sql.AppendLine("left join TB_CTB_PlanoContas f  ");
            sql.AppendLine("on a.CD_ContaCusto = f.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas g  ");
            sql.AppendLine("on a.CD_ContaResultadoL = g.CD_Conta_CTB ");
            sql.AppendLine("left outer join TB_CTB_PlanoContas h ");
            sql.AppendLine("on a.CD_ContaResultadoP = h.CD_Conta_CTB ");

            sql.AppendLine("where isnull(b.st_registro, 'A') <> 'C'");

            string cond = " and ";
            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
            if (!string.IsNullOrEmpty(vOrderBy))
                sql.Append("Order by " + vOrderBy);

            return sql.ToString();
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty, string.Empty), null);
        }

        public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
        {
            return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo, string.Empty), null);
        }

        public TList_Cad_CTB_ParamZeramento Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo, string vOrderBy)
        {
            TList_Cad_CTB_ParamZeramento lista = new TList_Cad_CTB_ParamZeramento();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo, vOrderBy));
                while (reader.Read())
                {
                    TRegistro_Cad_CTB_ParamZeramento reg = new TRegistro_Cad_CTB_ParamZeramento();

                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cCusta")))
                        reg.Cd_cCusto = reader.GetDecimal(reader.GetOrdinal("Cd_cCusta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_ccusta")))
                        reg.ds_custo = reader.GetString(reader.GetOrdinal("ds_ccusta"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CDespesas")))
                        reg.Cd_CDespesas = reader.GetDecimal(reader.GetOrdinal("Cd_CDespesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cdespesas")))
                        reg.ds_despesas = reader.GetString(reader.GetOrdinal("ds_cdespesas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cLucro")))
                        reg.Cd_cLucro = reader.GetDecimal(reader.GetOrdinal("Cd_cLucro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_clucro")))
                        reg.ds_lucro = reader.GetString(reader.GetOrdinal("ds_clucro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_CReceitas")))
                        reg.Cd_CReceitas = reader.GetDecimal(reader.GetOrdinal("Cd_CReceitas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_creceitas")))
                        reg.ds_creceitas = reader.GetString(reader.GetOrdinal("ds_creceitas"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_cResultadoL")))
                        reg.Cd_cResultadoL = reader.GetDecimal(reader.GetOrdinal("Cd_cResultadoL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_cresultadoL")))
                        reg.ds_resultadoL = reader.GetString(reader.GetOrdinal("ds_cresultadoL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_empresa")))
                        reg.Cd_empresa = reader.GetString(reader.GetOrdinal("Cd_empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Empresa")))
                        reg.ds_empresa = reader.GetString(reader.GetOrdinal("NM_Empresa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_classifReceita")))
                        reg.Cd_classifreceitas = reader.GetString(reader.GetOrdinal("Cd_classifReceita"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_classifDespesa")))
                        reg.Cd_classifdespesas = reader.GetString(reader.GetOrdinal("Cd_classifDespesa"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_classifLucro")))
                        reg.Cd_classiflucro = reader.GetString(reader.GetOrdinal("Cd_classifLucro"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_classifCusto")))
                        reg.Cd_classifcusto = reader.GetString(reader.GetOrdinal("Cd_classifCusto"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_classifResultadoL")))
                        reg.Cd_classifresultadoL = reader.GetString(reader.GetOrdinal("Cd_classifResultadoL"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_ContaResultadoP")))
                        reg.Cd_cResultadoP = reader.GetDecimal(reader.GetOrdinal("CD_ContaResultadoP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Ds_resultadoP")))
                        reg.Ds_resultadoP = reader.GetString(reader.GetOrdinal("Ds_resultadoP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Cd_ClassifResultadoP")))
                        reg.Cd_classifresultadoP = reader.GetString(reader.GetOrdinal("Cd_ClassifResultadoP"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_contaresultado")))
                        reg.Cd_contaresultado = reader.GetDecimal(reader.GetOrdinal("cd_contaresultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_contaresultado")))
                        reg.Ds_contaresultado = reader.GetString(reader.GetOrdinal("ds_contaresultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_classifresultado")))
                        reg.Cd_classifresultado = reader.GetString(reader.GetOrdinal("cd_classifresultado"));

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

        public string Gravar(TRegistro_Cad_CTB_ParamZeramento vRegistro)
        {
            Hashtable hs = new Hashtable(8);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);
            hs.Add("@P_CD_CONTARECEITAS", vRegistro.Cd_CReceitas);
            hs.Add("@P_CD_CONTADESPESAS", vRegistro.Cd_CDespesas);
            hs.Add("@P_CD_CONTALUCRO", vRegistro.Cd_cLucro);
            hs.Add("@P_CD_CONTACUSTO", vRegistro.Cd_cCusto);
            hs.Add("@P_CD_CONTARESULTADO", vRegistro.Cd_contaresultado);
            hs.Add("@P_CD_CONTARESULTADOL", vRegistro.Cd_cResultadoL);
            hs.Add("@P_CD_CONTARESULTADOP", vRegistro.Cd_cResultadoP);

            return this.executarProc("IA_CTB_PARAMZERAMENTO", hs);
        }

        public string Excluir(TRegistro_Cad_CTB_ParamZeramento vRegistro)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_EMPRESA", vRegistro.Cd_empresa);

            return this.executarProc("EXCLUI_CTB_PARAMZERAMENTO", hs);
        }
    }
}
