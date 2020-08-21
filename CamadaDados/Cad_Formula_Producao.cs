using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Utils;
using Querys;

namespace CamadaDados.Producao.Cadastros
{
    public class TList_CadFormula_Producao : List<TRegistro_CadFormula_Producao>
    { }

    public class TRegistro_CadFormula_Producao
    {
        private string CD_Empresa;

        public string CD_empresa
        {
            get { return CD_Empresa; }
            set { CD_Empresa = value; }
        }

        private string NM_Empresa;

        public string NM_empresa
        {
            get { return NM_Empresa; }
            set { NM_Empresa = value; }
        }        
        

        private string CD_Produto;

        public string CD_produto
        {
            get { return CD_Produto; }
            set { CD_Produto = value; }
        }

        private string ds_Produto;

        public string Ds_produto
        {
            get { return ds_Produto; }
            set { ds_Produto = value; }
        }
        
        private decimal CD_Versao;

        public decimal CD_versao
        {
            get { return CD_Versao; }
            set { CD_Versao = value; }
        }

        private string CD_TPLanEstoque;

        public string CD_tpLanEstoque
        {
            get { return CD_TPLanEstoque; }
            set { CD_TPLanEstoque = value; }
        }

        private string DS_TPLanEstoque;

        public string DS_tpLanEstoque
        {
            get { return DS_TPLanEstoque; }
            set { DS_TPLanEstoque = value; }
        }
         


        private string CD_Unidade;

        public string CD_unidade
        {
            get { return CD_Unidade; }
            set { CD_Unidade = value; }
        }

        private string Ds_Unidade;

        public string Ds_unidade
        {
            get { return Ds_Unidade; }
            set { Ds_Unidade = value; }
        }

        private string sigla_Unidade;

        public string Sigla_Unidade
        {
            get { return sigla_Unidade; }
            set { sigla_Unidade = value; }
        }

        private string CD_Local;

        public string CD_local
        {
            get { return CD_Local; }
            set { CD_Local = value; }
        }

        private string DS_Local;

        public string DS_local
        {
            get { return DS_Local; }
            set { DS_Local = value; }
        }

        private decimal QTD_por_Explosao;

        public decimal QTD_por_explosao
        {
            get { return QTD_por_Explosao; }
            set { QTD_por_Explosao = value; }
        }

        private string DS_Observacoes;

        public string ds_Observacoes
        {
            get { return DS_Observacoes; }
            set { DS_Observacoes = value; }
        }

        private string DS_Indicacao;

        public string ds_Indicacao
        {
            get { return DS_Indicacao; }
            set { DS_Indicacao = value; }
        }

        private string DS_Formula;

        public string ds_Formula
        {
            get { return DS_Formula; }
            set { DS_Formula = value; }
        }

        private string NM_Responsavel;

        public string nm_Responsavel
        {
            get { return NM_Responsavel; }
            set { NM_Responsavel = value; }
        }

        private string TP_Formula;
        public string tp_Formula
        {
            get { return TP_Formula; }
            set 
            { TP_Formula = value;
                if (value.Trim().Equals("C"))
                    TPFormula = "Composição";
                else if(value.Trim().Equals("D"))
                    TPFormula = "Decomposição";
            }
        }

        private string TPFormula;
        public string tpformula
        {
            get { return TPFormula; }
            set 
            { TPFormula = value;
              if (value.Trim().Equals("Composição"))
                TP_Formula = "C";
              else if (value.Trim().Equals("Decomposição"))
                TP_Formula = "D";
            }
        }
        
        private decimal Pc_QuebraTecnica;

        public decimal Pc_quebraTecnica
        {
            get { return Pc_QuebraTecnica; }
            set { Pc_QuebraTecnica = value; }
        }

        private decimal TempoMistura;

        public decimal tempoMistura
        {
            get { return TempoMistura; }
            set { TempoMistura = value; }
        }

        private string ST_Ativado;

        public string st_Ativado
        {
            get { return ST_Ativado; }
            set { ST_Ativado = value;
            STAtivado = value.Trim().Equals("S");
            }
        }

        private bool STAtivado;
        public bool stativado
        {
            get { return STAtivado; }
            set
            {
                STAtivado = value;
                if (value)
                    ST_Ativado = "S";
                else
                    ST_Ativado = "N";
            }
        }


        private string cd_unidade_produto;

        public string Cd_unidade_produto
        {
            get { return cd_unidade_produto; }
            set { cd_unidade_produto = value; }
        }
            

        public TRegistro_CadFormula_Producao()
        {
            this.CD_Empresa = "";
            this.NM_empresa = "";
            this.CD_Produto = "";
            this.ds_Produto = "";
            this.CD_Versao = 0;
            this.CD_TPLanEstoque = "";
            this.DS_tpLanEstoque = "";
            this.CD_Unidade = "";
            this.Ds_unidade = "";
            this.sigla_Unidade = "";
            this.CD_Local = "";
            this.DS_local = "";
            this.QTD_por_Explosao = 0;
            this.DS_Observacoes = "";
            this.DS_Indicacao = "";
            this.DS_Formula = "";
            this.NM_Responsavel = "";
            this.TP_Formula = "C";
            this.Pc_QuebraTecnica = 0;
            this.TempoMistura = 0;
            this.ST_Ativado = "";    
        }
    }


    public class TCD_CadFormula_Producao : TDataQuery
    {
        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
        {
            return ExecutarBusca(SqlCodeBusca(vBusca, vTop, ""), null);
        }

        public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
        {
            return ExecutarBuscaEscalar(SqlCodeBusca(vBusca, 1, vNM_Campo), null);
        }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            StringBuilder sql;
            string cond, strTop;
            Int16 i;
            strTop = "";
            if (vTop > 0)
            {
                strTop = "TOP " + Convert.ToString(vTop);
            }
            sql = new StringBuilder();
            if (vNM_Campo.Length == 0)
            {

              sql.AppendLine(" Select " + strTop + " a.cd_empresa, b.nm_empresa, a.cd_produto, c.ds_produto, a.cd_Versao, a.ds_Formula,  " );
              sql.AppendLine(" a.cd_TpLAnEstoque, d.ds_TpLanEstoque, a.cd_unidade, e.ds_unidade , e.Sigla_Unidade,  " );
              sql.AppendLine(" a.cd_local, f.ds_Local , a.qtd_por_explosao, a.ds_observacoes, a.ds_Indicacao, a.NM_Responsavel, a.TP_Formula,  " );
              sql.AppendLine(" a.Pc_quebraTecnica, a.TempoMistura, a.ST_Ativado, c.cd_unidade as cd_unidade_produto " );                 
                              
            }
            else
            {
                sql.Append("Select " + strTop + " " + vNM_Campo + " ");
            }

            sql.AppendLine(" from tb_PRD_FormulaProducao a  ");
            sql.AppendLine(" inner join tb_empresa b on (b.cd_empresa = a.cd_Empresa)  ");
            sql.AppendLine(" inner join tb_produto c  on (c.cd_produto = a.cd_produto)  ");
            sql.AppendLine(" left outer join tb_tplanEstoque d on (d.cd_tpLanEstoque = a.cd_tplanEstoque)  ");
            sql.AppendLine(" left outer join tb_unidade e on (e.cd_unidade = a.cd_unidade)  ");
            sql.AppendLine(" left outer join tb_localArm f on (f.cd_local = a.cd_local)  ");

            cond = " where ";
            if (vBusca != null)
                if (vBusca.Length > 0)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.Append(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");
                        cond = " and ";
                    }
            return sql.ToString();
        }

        public TList_CadFormula_Producao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadFormula_Producao lista = new TList_CadFormula_Producao();
            SqlDataReader reader;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
            {
                this.CriarBanco_Dados(false);
                podeFecharBco = true;
            }

            try
            {
                if (vNM_Campo == "")
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), ""));
                else
                    reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));

                while (reader.Read())
                {
                    TRegistro_CadFormula_Producao CadFormula_Producao = new TRegistro_CadFormula_Producao();
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_EMPRESA")))
                        CadFormula_Producao.CD_empresa = reader.GetString(reader.GetOrdinal("CD_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_EMPRESA")))
                        CadFormula_Producao.NM_empresa = reader.GetString(reader.GetOrdinal("NM_EMPRESA"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_PRODUTO")))
                        CadFormula_Producao.CD_produto = reader.GetString(reader.GetOrdinal("CD_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_PRODUTO")))
                        CadFormula_Producao.Ds_produto = reader.GetString(reader.GetOrdinal("DS_PRODUTO"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Versao")))
                        CadFormula_Producao.CD_versao = reader.GetDecimal(reader.GetOrdinal("CD_Versao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_TPLAnEstoque")))
                        CadFormula_Producao.CD_tpLanEstoque = reader.GetString(reader.GetOrdinal("CD_TPLAnEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_TPLAnEstoque")))
                        CadFormula_Producao.DS_tpLanEstoque = reader.GetString(reader.GetOrdinal("DS_TPLAnEstoque"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade")))
                        CadFormula_Producao.CD_unidade = reader.GetString(reader.GetOrdinal("CD_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Unidade")))
                        CadFormula_Producao.Ds_unidade = reader.GetString(reader.GetOrdinal("DS_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("Sigla_Unidade")))
                        CadFormula_Producao.Sigla_Unidade = reader.GetString(reader.GetOrdinal("Sigla_Unidade"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Local")))
                        CadFormula_Producao.CD_local = reader.GetString(reader.GetOrdinal("CD_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Local")))
                        CadFormula_Producao.DS_local = reader.GetString(reader.GetOrdinal("DS_Local"));
                    if (!reader.IsDBNull(reader.GetOrdinal("QTD_por_Explosao")))
                        CadFormula_Producao.QTD_por_explosao = reader.GetDecimal(reader.GetOrdinal("QTD_por_Explosao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Observacoes")))
                        CadFormula_Producao.ds_Observacoes = reader.GetString(reader.GetOrdinal("DS_Observacoes"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Indicacao")))
                        CadFormula_Producao.ds_Indicacao = reader.GetString(reader.GetOrdinal("DS_Indicacao"));
                    if (!reader.IsDBNull(reader.GetOrdinal("DS_Formula")))
                        CadFormula_Producao.ds_Formula = reader.GetString(reader.GetOrdinal("DS_Formula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("NM_Responsavel")))
                        CadFormula_Producao.nm_Responsavel = reader.GetString(reader.GetOrdinal("NM_Responsavel"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TP_Formula")))
                        CadFormula_Producao.tp_Formula = reader.GetString(reader.GetOrdinal("TP_Formula"));
                    if (!reader.IsDBNull(reader.GetOrdinal("PC_QuebraTecnica")))
                        CadFormula_Producao.Pc_quebraTecnica = reader.GetDecimal(reader.GetOrdinal("PC_QuebraTecnica"));
                    if (!reader.IsDBNull(reader.GetOrdinal("TempoMistura")))
                        CadFormula_Producao.tempoMistura = reader.GetDecimal(reader.GetOrdinal("TempoMistura"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ST_Ativado")))
                        CadFormula_Producao.st_Ativado = reader.GetString(reader.GetOrdinal("ST_Ativado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("CD_Unidade_Produto")))
                        CadFormula_Producao.Cd_unidade_produto = reader.GetString(reader.GetOrdinal("CD_Unidade_Produto"));
                    lista.Add(CadFormula_Producao); 
                }
            }
            finally
            {
                if (podeFecharBco)
                    this.deletarBanco_Dados();
            }
            return lista;
        
        }

        public string GravarFormula_Producao(TRegistro_CadFormula_Producao val)
        {
            Hashtable hs = new Hashtable();
                   hs.Add("@P_CD_EMPRESA", val.CD_empresa); 
                   hs.Add("@P_CD_PRODUTO", val.CD_produto); 
                   hs.Add("@P_CD_VERSAO", val.CD_versao); 
                   hs.Add("@P_CD_TPLANESTOQUE", val.CD_tpLanEstoque); 
                   hs.Add("@P_CD_UNIDADE", val.CD_unidade); 
                   hs.Add("@P_CD_LOCAL", val.CD_local); 
                   hs.Add("@P_QTD_POR_EXPLOSAO", val.QTD_por_explosao); 
                   hs.Add("@P_DS_OBSERVACOES", val.ds_Observacoes); 
                   hs.Add("@P_DS_INDICACAO", val.ds_Indicacao); 
                   hs.Add("@P_DS_FORMULA", val.ds_Formula); 
                   hs.Add("@P_NM_RESPONSAVEL", val.nm_Responsavel); 
                   hs.Add("@P_TP_FORMULA", val.tp_Formula); 
                   hs.Add("@P_PC_QUEBRATECNICA", val.Pc_quebraTecnica);
                   hs.Add("@P_TEMPOMISTURA", val.tempoMistura);
                   hs.Add("@P_ST_ATIVADO", val.st_Ativado); 
            return executarProc("IA_PRD_FORMULAPRODUCAO", hs);

        }

        public string DeletarFormula_Producao(TRegistro_CadFormula_Producao val)
        {
            Hashtable hs = new Hashtable();
            hs.Add("@P_CD_EMPRESA", val.CD_empresa);
            hs.Add("@P_CD_PRODUTO", val.CD_produto);
            hs.Add("@P_CD_VERSAO", val.CD_versao);
            return this.executarProc("EXCLUI_PRD_FORMULAPRODUCAO", hs);
        }

    }

}
