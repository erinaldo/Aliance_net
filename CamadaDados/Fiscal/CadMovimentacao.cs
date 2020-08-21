using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Data;

namespace CamadaDados.Fiscal
{
    
    public class TRegistro_CadMovimentacao
    {
        private decimal? cd_movimentacao;
        public decimal? Cd_movimentacao
        {
            get { return cd_movimentacao; }
            set
            {
                cd_movimentacao = value;
                cd_movimentacaostr = value.HasValue ? value.Value.ToString() : string.Empty;
            }
        }
        private string cd_movimentacaostr;
        public string Cd_movimentacaostr
        {
            get { return cd_movimentacaostr; }
            set
            {
                cd_movimentacaostr = value;
                try
                {
                    cd_movimentacao = decimal.Parse(value);
                }
                catch
                { cd_movimentacao = null; }
            }
        }
        public string ds_movimentacao { get; set; }
        public string cd_obsfiscal_dentroestado { get; set; }
        public string cd_obsfiscal_foraestado { get; set; }
        public string cd_obsfiscal_internacional { get; set; }
        public string cd_dadosAdicionais_dentroestado { get; set; }
        public string cd_dadosAdicionais_foraestado { get; set; }
        public string cd_dadosAdicionais_internacional { get; set; }
        public string ds_dadosAdicionais_dentroestado { get; set; }
        public string ds_dadosAdicionais_foraestado { get; set; }
        public string ds_dadosAdicionais_internacional { get; set; }
        public string cd_historico { get; set; }
        public string ds_historico { get; set; }
        public string Cd_centroresult
        { get; set; }
        public string Ds_centroresultado
        { get; set; }
        public string tp_movimento { get; set; }
        public string ds_obsfiscaldentroestado { get; set; }
        public string ds_obsfiscalforaestado { get; set; }
        public string ds_obsfiscalinternacional { get; set; }
        private string st_gerarspedpiscofins;
        public string St_gerarspedpiscofins
        {
            get { return st_gerarspedpiscofins; }
            set
            {
                st_gerarspedpiscofins = value;
                st_gerarspedpiscofinsbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_gerarspedpiscofinsbool;
        public bool St_gerarspedpiscofinsbool
        {
            get { return st_gerarspedpiscofinsbool; }
            set
            {
                st_gerarspedpiscofinsbool = value;
                st_gerarspedpiscofins = value ? "S" : "N";
            }
        }
        private string st_vendaconsumidor;
        public string St_vendaconsumidor
        {
            get { return st_vendaconsumidor; }
            set
            {
                st_vendaconsumidor = value;
                st_vendaconsumidorbool = value.Trim().ToUpper().Equals("S");
            }
        }
        private bool st_vendaconsumidorbool;
        public bool St_vendaconsumidorbool
        {
            get { return st_vendaconsumidorbool; }
            set
            {
                st_vendaconsumidorbool = value;
                st_vendaconsumidor = value ? "S" : "N";
            }
        }
        public bool St_agregar { get; set; }

        public TRegistro_CadMovimentacao()
        {
            cd_movimentacao = null;
            cd_movimentacaostr = string.Empty;
            ds_movimentacao = string.Empty;
            cd_obsfiscal_dentroestado = string.Empty;
            cd_obsfiscal_foraestado = string.Empty;
            cd_obsfiscal_internacional = string.Empty;
            cd_dadosAdicionais_dentroestado = string.Empty;
            cd_dadosAdicionais_foraestado = string.Empty;
            cd_dadosAdicionais_internacional = string.Empty;
            ds_dadosAdicionais_dentroestado = string.Empty;
            ds_dadosAdicionais_foraestado = string.Empty;
            ds_dadosAdicionais_internacional = string.Empty;
            cd_historico = string.Empty;
            tp_movimento = string.Empty;
            ds_obsfiscaldentroestado = string.Empty;
            ds_obsfiscalforaestado = string.Empty;
            ds_obsfiscalinternacional = string.Empty;
            ds_historico = string.Empty;
            this.Cd_centroresult = string.Empty;
            this.Ds_centroresultado = string.Empty;
            this.st_gerarspedpiscofins = "N";
            this.st_gerarspedpiscofinsbool = false;
            this.st_vendaconsumidor = "N";
            this.st_vendaconsumidorbool = false;
            this.St_agregar = false;
        }
    }
    
    public class TList_CadMovimentacao : List<TRegistro_CadMovimentacao>
    { }

    public class TCD_CadMovimentacao : TDataQuery
    {
        public TCD_CadMovimentacao()
        { }

        public TCD_CadMovimentacao(BancoDados.TObjetoBanco banco)
        { this.Banco_Dados = banco; }

        private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
        {
            string strTop = string.Empty;
            if (vTop > 0)
                strTop = "TOP " + Convert.ToString(vTop);

            StringBuilder sql = new StringBuilder();
            if (string.IsNullOrEmpty(vNM_Campo))
            {
                sql.AppendLine("Select " + strTop + " a.CD_Movimentacao, a.DS_Movimentacao, ");
                sql.AppendLine("a.CD_ObsFiscal_DentroEstado, b.DS_ObservacaoFiscal as DS_ObsFiscalDentroEstado, ");
                sql.AppendLine("a.CD_ObsFiscal_ForaEstado, c.DS_ObservacaoFiscal as DS_ObsFiscalForaEstado, ");
                sql.AppendLine("a.CD_ObsFiscal_Internacional, i.DS_ObservacaoFiscal as DS_ObsFiscalInternacional, ");
                sql.AppendLine("a.CD_DadosAdic_DentroEstado, b.DS_ObservacaoFiscal as DS_DadosAdicDentroEstado,");
                sql.AppendLine("a.CD_DadosAdic_ForaEstado, c.DS_ObservacaoFiscal as DS_DadosAdicForaEstado,");
                sql.AppendLine("a.CD_DadosAdic_Internacional, i.DS_ObservacaoFiscal as DS_DadosAdicInternacional, ");
                sql.AppendLine("a.CD_Historico, g.DS_Historico, a.CD_CentroResult, j.DS_CentroResultado, ");
                sql.AppendLine("a.TP_Movimento, a.st_gerarspedpiscofins, a.st_vendaconsumidor ");
            }
            else
                sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

            sql.AppendLine("From TB_FIS_Movimentacao a ");
            sql.AppendLine("left outer join TB_FIS_ObservacaoFiscal b ");
            sql.AppendLine("On b.CD_ObservacaoFiscal = a.CD_ObsFiscal_DentroEstado ");
            sql.AppendLine("left outer join TB_FIS_ObservacaoFiscal c ");
            sql.AppendLine("On c.CD_ObservacaoFiscal = a.CD_ObsFiscal_ForaEstado ");
            sql.AppendLine("left outer join TB_FIN_Historico g ");
            sql.AppendLine("On g.CD_Historico = a.CD_Historico ");
            sql.AppendLine("left outer join TB_FIS_ObservacaoFiscal i ");
            sql.AppendLine("On i.CD_ObservacaoFiscal = a.CD_ObsFiscal_Internacional ");
            sql.AppendLine("left outer join TB_FIN_CentroResultado j ");
            sql.AppendLine("on a.cd_centroresult = j.cd_centroresult ");

            sql.AppendLine("Where isNull(a.ST_Registro,'A') <> 'C'");

            if (vBusca != null)
                for (int i = 0; i < (vBusca.Length); i++)
                    sql.AppendLine(" and (" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + " )");

            return sql.ToString();
        }

        public TList_CadMovimentacao Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
        {
            TList_CadMovimentacao lista = new TList_CadMovimentacao();
            SqlDataReader reader = null;
            bool podeFecharBco = false;
            if (Banco_Dados == null)
                podeFecharBco = this.CriarBanco_Dados(false);

            try
            {
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                while (reader.Read())
                {
                    TRegistro_CadMovimentacao reg = new TRegistro_CadMovimentacao();
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_MOVIMENTACAO"))))
                        reg.Cd_movimentacao = reader.GetDecimal(reader.GetOrdinal("CD_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_MOVIMENTACAO"))))
                        reg.ds_movimentacao = reader.GetString(reader.GetOrdinal("DS_MOVIMENTACAO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_OBSFISCAL_DENTROESTADO"))))
                        reg.cd_obsfiscal_dentroestado = reader.GetString(reader.GetOrdinal("CD_OBSFISCAL_DENTROESTADO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_OBSFISCAL_FORAESTADO"))))
                        reg.cd_obsfiscal_foraestado = reader.GetString(reader.GetOrdinal("CD_OBSFISCAL_FORAESTADO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_OBSFISCAL_INTERNACIONAL"))))
                        reg.cd_obsfiscal_internacional = reader.GetString(reader.GetOrdinal("CD_OBSFISCAL_INTERNACIONAL"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_HISTORICO"))))
                        reg.cd_historico = reader.GetString(reader.GetOrdinal("CD_HISTORICO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("TP_MOVIMENTO"))))
                        reg.tp_movimento = reader.GetString(reader.GetOrdinal("TP_MOVIMENTO"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_obsfiscaldentroestado"))))
                        reg.ds_obsfiscaldentroestado = reader.GetString(reader.GetOrdinal("ds_obsfiscaldentroestado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_obsfiscalforaestado"))))
                        reg.ds_obsfiscalforaestado = reader.GetString(reader.GetOrdinal("ds_obsfiscalforaestado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_obsfiscalinternacional"))))
                        reg.ds_obsfiscalinternacional = reader.GetString(reader.GetOrdinal("ds_obsfiscalinternacional"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("ds_historico"))))
                        reg.ds_historico = reader.GetString(reader.GetOrdinal("ds_historico"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_DadosAdic_DentroEstado"))))
                        reg.cd_dadosAdicionais_dentroestado = reader.GetString(reader.GetOrdinal("CD_DadosAdic_DentroEstado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_DadosAdic_ForaEstado"))))
                        reg.cd_dadosAdicionais_foraestado = reader.GetString(reader.GetOrdinal("CD_DadosAdic_ForaEstado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("CD_DadosAdic_Internacional"))))
                        reg.cd_dadosAdicionais_internacional = reader.GetString(reader.GetOrdinal("CD_DadosAdic_Internacional"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_DadosAdicDentroEstado"))))
                        reg.ds_dadosAdicionais_dentroestado = reader.GetString(reader.GetOrdinal("DS_DadosAdicDentroEstado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_DadosAdicForaEstado"))))
                        reg.ds_dadosAdicionais_foraestado = reader.GetString(reader.GetOrdinal("DS_DadosAdicForaEstado"));
                    if (!(reader.IsDBNull(reader.GetOrdinal("DS_DadosAdicInternacional"))))
                        reg.ds_dadosAdicionais_internacional = reader.GetString(reader.GetOrdinal("DS_DadosAdicInternacional"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_gerarspedpiscofins")))
                        reg.St_gerarspedpiscofins = reader.GetString(reader.GetOrdinal("st_gerarspedpiscofins"));
                    if (!reader.IsDBNull(reader.GetOrdinal("cd_centroresult")))
                        reg.Cd_centroresult = reader.GetString(reader.GetOrdinal("cd_centroresult"));
                    if (!reader.IsDBNull(reader.GetOrdinal("ds_centroresultado")))
                        reg.Ds_centroresultado = reader.GetString(reader.GetOrdinal("ds_centroresultado"));
                    if (!reader.IsDBNull(reader.GetOrdinal("st_vendaconsumidor")))
                        reg.St_vendaconsumidor = reader.GetString(reader.GetOrdinal("st_vendaconsumidor"));

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

        public string Gravar(TRegistro_CadMovimentacao val)
        {
            Hashtable hs = new Hashtable(13);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            hs.Add("@P_DS_MOVIMENTACAO", val.ds_movimentacao);
            hs.Add("@P_CD_OBSFISCAL_DENTROESTADO", val.cd_obsfiscal_dentroestado);
            hs.Add("@P_CD_OBSFISCAL_FORAESTADO", val.cd_obsfiscal_foraestado);
            hs.Add("@P_CD_OBSFISCAL_INTERNACIONAL", val.cd_obsfiscal_internacional);
            hs.Add("@P_CD_DADOSADIC_DENTROESTADO", val.cd_dadosAdicionais_dentroestado);
            hs.Add("@P_CD_DADOSADIC_FORAESTADO", val.cd_dadosAdicionais_foraestado);
            hs.Add("@P_CD_DADOSADIC_INTERNACIONAL", val.cd_dadosAdicionais_internacional);
            hs.Add("@P_CD_HISTORICO", val.cd_historico);
            hs.Add("@P_TP_MOVIMENTO", val.tp_movimento);
            hs.Add("@P_ST_GERARSPEDPISCOFINS", val.St_gerarspedpiscofins);
            hs.Add("@P_CD_CENTRORESULT", val.Cd_centroresult);
            hs.Add("@P_ST_VENDACONSUMIDOR", val.St_vendaconsumidor);

            return executarProc("IA_FIS_MOVIMENTACAO", hs);
        }

        public string Excluir(TRegistro_CadMovimentacao val)
        {
            Hashtable hs = new Hashtable(1);
            hs.Add("@P_CD_MOVIMENTACAO", val.Cd_movimentacao);
            return executarProc("EXCLUI_FIS_MOVIMENTACAO", hs);
        }

        public override DataTable Buscar(TpBusca[] vBusca, Int16 vTop)
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
    }
}
