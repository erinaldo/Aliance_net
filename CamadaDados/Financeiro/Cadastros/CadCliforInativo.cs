using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data.SqlClient;
using System.Collections;
using System.Data;

namespace CamadaDados.Financeiro.Cadastros
{
    public class TList_CadCliforInativo : List<TRegistro_CadCliforInativo>
    {}

    
    public class TRegistro_CadCliforInativo
        {
            private decimal? id_inativo;
            
            public decimal? ID_Inativo
            {
                get { return id_inativo; }
                set
                {
                    id_inativo = value;
                    id_inativostr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
            private string id_inativostr;
            
            public string Id_inativostr
            {
                get { return id_inativostr; }
                set
                {
                    id_inativostr = value;
                    try
                    {
                        id_inativo = Convert.ToDecimal(value);
                    }
                    catch
                    { id_inativo = null; }
                }
            }
            
            public string DS_Motivo
            { get; set; }
            
            public string CD_Clifor
            {get; set;}
            
            public decimal ID_Motivo
            { get; set; }
            
            public string Login
            { get; set; }
            
            public string DS_Complemento
            { get; set; }
            private DateTime? dt_contato;
            
            public DateTime? DT_Contato
            {
                get { return dt_contato; }
                set 
                {
                    dt_contato = value;
                    dt_contatostr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
            private string dt_contatostr;
            
            public string Dt_contatostr 
            {
                get { return dt_contatostr; }
                set
                {
                    dt_contatostr = value;
                    try
                    {
                        dt_contato = Convert.ToDateTime(value);
                    }
                    catch
                    { dt_contato = null; }
                }
            }
            
            public string NM_Contato 
            { get; set; }
            
            public string DS_Observacao 
            { get; set; }
            
            private DateTime? dt_prevcompra;
            
            public DateTime? DT_PrevCompra
            {
                get { return dt_prevcompra; }
                set
                {
                    dt_prevcompra = value;
                    dt_prevcomprastr = value.HasValue ? value.Value.ToString() : string.Empty;
                }
            }
            private string dt_prevcomprastr;
            
            public string Dt_prevcomprastr
            {
                get { return dt_prevcomprastr; }
                set
                {
                    dt_prevcomprastr = value;
                    try
                    {
                        dt_prevcompra = Convert.ToDateTime(value);
                    }
                    catch
                    { dt_prevcompra = null; }
                }
            }
                
            public decimal QT_DiasInativo 
            { get; set; }
            
    
            public TRegistro_CadCliforInativo()
            {
                this.ID_Inativo = null;
                this.id_inativostr = string.Empty;
                this.CD_Clifor = string.Empty;
                this.ID_Motivo = decimal.Zero;
                this.Login = string.Empty;
                this.DS_Complemento = string.Empty;
                this.DT_Contato = null;
                this.dt_contatostr = string.Empty;
                this.NM_Contato = string.Empty;
                this.DS_Observacao = string.Empty;
                this.DT_PrevCompra = null;
                this.Dt_prevcomprastr = string.Empty;
                this.QT_DiasInativo = decimal.Zero;
            }
        }

    public class TCD_CadCliforInativo : TDataQuery
        {
            public TCD_CadCliforInativo()
            { }

            public TCD_CadCliforInativo(BancoDados.TObjetoBanco banco)
            { this.Banco_Dados = banco; }

            private string SqlCodeBusca(TpBusca[] vBusca, Int16 vTop, string vNM_Campo)
            {
                string cond = " "; string strTop;
                int i;
                strTop = " ";

                if (vTop > 0)
                    strTop = "TOP " + Convert.ToString(vTop);

                StringBuilder sql = new StringBuilder();
                if (vNM_Campo.Trim().Equals(""))
                {
                    sql.AppendLine("SELECT "+ strTop +" a.ID_Inativo, a.CD_Clifor, a.ID_Motivo, a.Login,");
                    sql.AppendLine("a.DS_Complemento, a.DT_Contato, a.NM_Contato,");
                    sql.AppendLine("a.DS_Observacao, a.DT_PrevCompra, a.QT_DiasInativo,");
                    sql.AppendLine("DT_Cad, DT_Alt");
                    sql.AppendLine("FROM TB_FIN_CliforInativo a");
                    sql.AppendLine("INNER JOIN TB_FIN_Clifor b");
                    sql.AppendLine("ON a.CD_Clifor = b.CD_Clifor");
                    sql.AppendLine("INNER JOIN TB_FIN_MotivoInativo c");
                    sql.AppendLine("ON a.ID_Motivo = c.ID_Motivo");
                    sql.AppendLine("INNER JOIN TB_DIV_Usuario d");
                    sql.AppendLine("ON a.Login = d.Login");
                }
                else
                    sql.AppendLine("Select " + strTop + " " + vNM_Campo + " ");

                sql.AppendLine("from tb_fin_cliforinativo ");

                cond = " where ";

                if (vBusca != null)
                    for (i = 0; i < (vBusca.Length); i++)
                    {
                        sql.AppendLine(cond + "(" + vBusca[i].vNM_Campo + " " + vBusca[i].vOperador + " " + vBusca[i].vVL_Busca + ")");
                        cond = " and ";
                    }
                return sql.ToString();
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, string.Empty), null);
            }

            public override DataTable Buscar(TpBusca[] vBusca, short vTop, string vNM_Campo)
            {
                return this.ExecutarBusca(this.SqlCodeBusca(vBusca, vTop, vNM_Campo), null);
            }

            public override object BuscarEscalar(TpBusca[] vBusca, string vNM_Campo)
            {
                return this.ExecutarBuscaEscalar(this.SqlCodeBusca(vBusca, 1, vNM_Campo), null);
            }

            public TList_CadCliforInativo Select(TpBusca[] vBusca, Int32 vTop, string vNM_Campo)
            {
                TList_CadCliforInativo lista = new TList_CadCliforInativo();
                SqlDataReader reader;
                bool podeFecharBco = false;
                if (Banco_Dados == null)
                {
                    this.CriarBanco_Dados(false);
                    podeFecharBco = true;
                }
                reader = this.ExecutarBusca(this.SqlCodeBusca(vBusca, Convert.ToInt16(vTop), vNM_Campo));
                try
                {
                    while (reader.Read())
                    {
                        TRegistro_CadCliforInativo reg = new TRegistro_CadCliforInativo();
                        if (!(reader.IsDBNull(reader.GetOrdinal("ID_Inativo"))))
                            reg.ID_Inativo = reader.GetDecimal(reader.GetOrdinal("ID_Inativo"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("CD_Clifor"))))
                            reg.CD_Clifor = reader.GetString(reader.GetOrdinal("CD_Clifor"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("ID_Motivo"))))
                            reg.ID_Motivo = reader.GetDecimal(reader.GetOrdinal("ID_Motivo"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("Login"))))
                            reg.Login = reader.GetString(reader.GetOrdinal("Login"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DS_Complemento"))))
                            reg.DS_Complemento = reader.GetString(reader.GetOrdinal("DS_Complemento"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_Contato"))))
                            reg.DT_Contato = reader.GetDateTime(reader.GetOrdinal("DT_Contato"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("NM_Contato"))))
                            reg.NM_Contato = reader.GetString(reader.GetOrdinal("NM_Contato"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DS_Observacao"))))
                            reg.DS_Observacao= reader.GetString(reader.GetOrdinal("DS_Observacao"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("DT_PrevCompra"))))
                            reg.DT_PrevCompra = reader.GetDateTime(reader.GetOrdinal("DT_PrevCompra"));
                        if (!(reader.IsDBNull(reader.GetOrdinal("QT_DiasInativo"))))
                            reg.QT_DiasInativo = reader.GetDecimal(reader.GetOrdinal("QT_DiasInativo"));

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

            public string GravarCliforInativo(TRegistro_CadCliforInativo val)
            {
                Hashtable hs = new Hashtable(10);
                hs.Add("@P_ID_INATIVO", val.ID_Inativo);
                hs.Add("@P_CD_CLIFOR", val.CD_Clifor);
                hs.Add("@P_ID_MOTIVO", val.ID_Motivo);
                hs.Add("@P_LOGIN", val.Login);
                hs.Add("@P_DS_COMPLEMENTO", val.DS_Complemento);
                hs.Add("@P_DT_CONTATO", val.DT_Contato);
                hs.Add("@P_NM_CONTATO", val.NM_Contato);
                hs.Add("@P_DS_OBSERVACAO", val.DS_Observacao);
                hs.Add("@P_DT_PREVCOMPRA", val.DT_PrevCompra);
                hs.Add("@P_QT_DIASINATIVO", val.QT_DiasInativo);

                return this.executarProc("IA_FIN_CLIFORINATIVO", hs);
            }

            public string DeletarCliforInativo(TRegistro_CadCliforInativo val)
            {
                Hashtable hs = new Hashtable(1);
                hs.Add("@P_ID_INATIVO", val.ID_Inativo);

                return this.executarProc("EXCLUI_FIN_CLIFORINATIVO", hs);
            }
        }

}
