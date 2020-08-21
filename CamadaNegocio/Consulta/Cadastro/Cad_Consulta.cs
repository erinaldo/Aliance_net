/*
 * Douglas Emanoel - 21/11/2008
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Consulta.Cadastro;
using Utils;
using System.Data;
using BancoDados;

namespace CamadaNegocio.Consulta.Cadastro
{
    public class TCN_Cad_Consulta
    {
        public static TList_Cad_Consulta Busca(decimal vID_Consulta, string Login, string vNM_Consulta, decimal vID_Report)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vID_Consulta > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_Consulta";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vID_Consulta.ToString() + "'";
            }
            if (Login.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Login";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Login + "'";
            }
            if (vNM_Consulta.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Consulta";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "'%" + vNM_Consulta + "%'";
            }
            if (vID_Report > 0)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "";
                vBusca[vBusca.Length - 1].vOperador = "EXISTS";
                vBusca[vBusca.Length - 1].vVL_Busca = "(SELECT 1 FROM TB_CON_Report_X_Consulta x WHERE x.ID_Consulta = a.ID_Consulta AND x.ID_Report = " + vID_Report + ")";
            }

            TCD_Cad_Consulta cd = new TCD_Cad_Consulta();
            return cd.Select(vBusca, 0, "");
        }

        public static string GravaConsulta(TRegistro_Cad_Consulta val, TObjetoBanco banco)
        {
            TCD_Cad_Consulta cd = new TCD_Cad_Consulta();
            if (banco != null)
                cd.Banco_Dados = banco;
            return cd.Grava(val);
        }

        public static string DeletaConsulta(TRegistro_Cad_Consulta val, TObjetoBanco banco)
        {

            bool st_transacao = false;
            TCD_Cad_Consulta CD_Consulta = new TCD_Cad_Consulta();
            TCD_Cad_Report_X_Consulta CD_Report_X_Consulta = new TCD_Cad_Report_X_Consulta();
            TCD_Cad_Filtro CD_Filtro = new TCD_Cad_Filtro();
            TCD_Cad_Campo_Amarracao CD_Campo_Amarracao = new TCD_Cad_Campo_Amarracao();
            TCD_Cad_Amarracoes CD_Amarracoes = new TCD_Cad_Amarracoes();
            TCD_Cad_Ordenacao CD_Ordenacao = new TCD_Cad_Ordenacao();
            TCD_Cad_Campo CD_Campo = new TCD_Cad_Campo();
            try
            {
                if (banco == null)
                {
                    CD_Consulta.CriarBanco_Dados(true);
                    st_transacao = true;
                }
                else
                {
                    CD_Consulta.Banco_Dados = banco;
                }

                //DELETAR CONSULTA
                /*string retorno = CD_Report_X_Consulta.DeletarReportPorConsulta(val.ID_Consulta);
                retorno = CD_Filtro.DeletaPorConsulta(val.ID_Consulta);
                retorno = CD_Ordenacao.DeletaPorConsulta(val.ID_Consulta);
                retorno = CD_Campo.DeletaTodos(val.ID_Consulta);

                //DELETA AS TABELAS AMARRADAS
                TList_Cad_Amarracoes listAmarracoes = TCN_Cad_Amarracoes.Busca(0, val.ID_Consulta);

                for (int i = 0; i < listAmarracoes.Count; i++)
                {
                    retorno = CD_Campo_Amarracao.DeletaPorAmarracoes(listAmarracoes[i].ID_Amarracoes);
                }

                retorno = CD_Amarracoes.DeletaPorConsulta(val.ID_Consulta);
                */
                //DELETE A CONSULTA
                string retorno = CD_Consulta.Deleta(val);
                
                if (st_transacao)
                    CD_Consulta.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch
            {
                if (st_transacao)
                    CD_Consulta.Banco_Dados.RollBack_Tran();
                return "";
            }
            finally
            {
                if (st_transacao)
                    CD_Consulta.deletarBanco_Dados();
            }
        }

        public static string BuscaStringSQL(TRegistro_Cad_Consulta Cad_Consulta, Boolean criarwhere)
        {
            //BUSCA AS TABELAS
            TList_Cad_Amarracoes listaTabelas = TCN_Cad_Amarracoes.Busca(0, Cad_Consulta.ID_Consulta);

            string SQLConsulta = "";
            StringBuilder SQL = new StringBuilder();

            if (listaTabelas.Count > 0)
            {
                SQL.AppendLine("SELECT ");
                try
                {
                    //BUSCA OS CAMPOS
                    TList_Cad_Campo listaCampo = TCN_Cad_Campo.Busca(0, Cad_Consulta.ID_Consulta, "");
                    string virgula = ", ";
                    SQLConsulta = "";
                    for (int i = 0; i < listaCampo.Count; i++)
                    {
                        SQLConsulta += listaCampo[i].Alias_Campo + "." + listaCampo[i].NM_Campo + virgula;
                        if ((i + 2) == listaCampo.Count)
                        {
                            virgula = "";
                        }
                    }
                    
                    if (listaCampo.Count > 0)
                    {
                        if (SQLConsulta.Trim() != "")
                        {
                            SQL.AppendLine(SQLConsulta);
                            SQLConsulta = "";
                        }
                    }
                    else
                    {
                        SQL.AppendLine(" 1 ");
                    }

                    //BUSCA A TABELA PRINCIPAL E SEPARA OS CAMPOS CERTOS
                    string from = "";
                    string join = "";
                    for (int i = 0; i < listaTabelas.Count; i++)
                    {
                        if (listaTabelas[i].ST_Principal.Trim() == "S")
                        {
                            from = "FROM " + listaTabelas[i].NM_Tabela;
                        }
                        else
                        {
                            TpBusca[] vBusca = new TpBusca[0];
                            Array.Resize(ref vBusca, vBusca.Length + 1);
                            vBusca[vBusca.Length - 1].vNM_Campo = "a.id_tipo_amarracao";
                            vBusca[vBusca.Length - 1].vOperador = "=";
                            vBusca[vBusca.Length - 1].vVL_Busca = "'" + listaTabelas[i].ID_Tipo_Amarracao + "'";

                            string tipoAmarracao = new TCD_Cad_TipoAmarracao().BuscarEscalar(vBusca, "a.sigla_amarracao").ToString();

                            if (tipoAmarracao != "")
                            {
                                TList_Cad_Campo_Amarracao listaCampoTabela = TCN_Cad_Campo_Amarracao.Busca(0, Cad_Consulta.ID_Consulta, 0, listaTabelas[i].ID_Amarracoes);

                                if (listaCampoTabela.Count > 0)
                                {
                                    join += tipoAmarracao + " " + listaTabelas[i].NM_Tabela + " on ";
                                }

                                //BUSCA OS CAMPOS DOS JOINS
                                string and = "";
                                for (int x = 0; x < listaCampoTabela.Count; x++)
                                {
                                    if ((x + 1) < listaCampoTabela.Count)
                                    {
                                        and = " AND ";
                                    }
                                    else
                                    {
                                        and = "";
                                    }
                                    join += listaCampoTabela[x].NM_Tabela_Base + "." + listaCampoTabela[x].Campo_Base;
                                    join += " = ";
                                    join += listaCampoTabela[x].NM_Tabela_Estrangeiro + "." + listaCampoTabela[x].Campo_Estrangeiro + " " + and;
                                }
                            }
                        }
                    }

                    //ADD OS JOIN PARA O SELECT
                    SQLConsulta += from + " " + join;
                    if (SQLConsulta.Trim() != "")
                    {
                        SQL.AppendLine(SQLConsulta);
                        SQLConsulta = "";
                    }

                    if (criarwhere)
                    {
                        //BUSCA OS FILTRO WHERE
                        TList_Cad_Filtro listaFiltro = TCN_Cad_Filtro.Busca(0, Cad_Consulta.ID_Consulta, "");

                        string cond = "WHERE ";
                        for (int i = 0; i < listaFiltro.Count; i++)
                        {
                            if (listaFiltro[i].ID_Operador > 0)
                            {
                                TpBusca[] vBuscaOperador = new TpBusca[0];
                                Array.Resize(ref vBuscaOperador, vBuscaOperador.Length + 1);
                                vBuscaOperador[vBuscaOperador.Length - 1].vNM_Campo = "a.id_operador";
                                vBuscaOperador[vBuscaOperador.Length - 1].vOperador = "=";
                                vBuscaOperador[vBuscaOperador.Length - 1].vVL_Busca = "'" + listaFiltro[i].ID_Operador + "'";

                                string operador = new TCD_Cad_Operador().BuscarEscalar(vBuscaOperador, "a.sigla_operador").ToString();

                                if (operador != "")
                                {
                                    TList_Cad_ParamClasse listaParam = TCN_Cad_ParamClasse.Buscar(listaFiltro[i].ID_ParamClasse, "", "", "", 0, null);

                                    if (operador.Trim().ToUpper() == "LIKE")
                                    {
                                        SQLConsulta += cond + " (" + listaFiltro[i].Alias_Campo + "." + listaFiltro[i].NM_Campo + operador + "'%" + listaParam[0].NM_CampoFormat +"%')";
                                    }
                                    else
                                    {
                                        SQLConsulta += cond + " (" + listaFiltro[i].Alias_Campo + "." + listaFiltro[i].NM_Campo + operador + "'" + listaParam[0].NM_CampoFormat + "')";
                                    }

                                    if ((i + 1) < listaFiltro.Count)
                                    {
                                        if (listaFiltro[(i + 1)].ST_Ligacao == "A")
                                        {
                                            cond = " AND ";
                                        }
                                        else
                                        {
                                            cond = " AND ";
                                        }
                                    }
                                    else
                                    {
                                        cond = " AND ";
                                    }
                                }
                            }
                        }

                        if (SQLConsulta.Trim() != "")
                        {
                            SQL.AppendLine(SQLConsulta);
                            SQLConsulta = "";
                        }
                    }

                    //BUSCA OS CAMPOS DE ORDENAÇÃO
                    TList_Cad_Ordenacao listaOrdenacao = TCN_Cad_Ordenacao.Busca(0, Cad_Consulta.ID_Consulta, "");

                    if (listaOrdenacao.Count > 0)
                    {
                        SQLConsulta += "ORDER BY ";
                    }

                    for (int i = 0; i < listaOrdenacao.Count; i++)
                    {
                        SQLConsulta += listaOrdenacao[i].Alias_Campo + "." + listaOrdenacao[i].NM_Campo + " ";
                        SQLConsulta += listaOrdenacao[i].TP_Ordenacao.Equals("A") ? "ASC" : "DESC";
                        SQLConsulta += "";
                    }

                    if (SQLConsulta.Trim() != "")
                    {
                        SQL.AppendLine(SQLConsulta);
                        SQLConsulta = "";
                    }
                }
                catch (Exception erro)
                {
                    throw new Exception(erro.Message);
                }
            }

            return SQL.ToString();
        }

        public static DataTable BuscarSQL(string SQL)
        {
            TCD_Cad_Consulta cd = new TCD_Cad_Consulta();
            return cd.BuscarSQL(SQL);
        }
    }
}
