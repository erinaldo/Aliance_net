using System;
using CamadaDados.Locacao;
using Utils;
using CamadaDados.Financeiro.Duplicata;

namespace CamadaNegocio.Locacao
{
    public class TCN_LocTerceiro
    {
        public static TList_LocTerceiro buscar(string Cd_empresa,
                                             string Id_locacao,
                                             string Nr_contrato,
                                             string Cd_fornecedor,
                                             string Nr_patrimonio,
                                             string Status,
                                             string Tp_modalidade,
                                             string vDt_ini,
                                             string vDt_fin,
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_fornecedor))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_fornecedor";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_fornecedor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_patrimonio))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from TB_LOC_ItensLocTerceiro x " +
                                                      "inner join tb_est_patrimonio y " +
                                                      "on x.cd_produto = y.CD_Patrimonio " +
                                                      "where a.CD_Empresa = x.CD_Empresa " +
                                                      "and a.ID_Locacao = x.ID_Locacao " +
                                                      "and y.nr_patrimonio = '" + Nr_patrimonio.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_locacao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Nr_contrato))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_contrato";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Nr_contrato;
            }
            if (!string.IsNullOrEmpty(Status))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "ISNULL(a.St_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + Status.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Tp_modalidade))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Tp_modalidade";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Tp_modalidade.Trim() + "'";
            }
            if ((!string.IsNullOrEmpty(vDt_ini)) && (vDt_ini.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_IniContrato";
                vBusca[vBusca.Length - 1].vOperador = ">=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
            }
            if ((!string.IsNullOrEmpty(vDt_fin)) && (vDt_fin.Trim() != "/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_IniContrato";
                vBusca[vBusca.Length - 1].vOperador = "<=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
            }
            return new TCD_LocTerceiro(banco).Select(vBusca, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_LocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LocTerceiro qtb_locacao = new TCD_LocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Itens
                val.Id_locstr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_LOC");
                val.lItensDel.ForEach(p => TCN_ItensLocTerceiro.Excluir(p, qtb_locacao.Banco_Dados));
                val.lItens.ForEach(p =>
                {
                    if (val.St_registro.ToUpper().Equals("E"))
                        p.Dt_fin = CamadaDados.UtilData.Data_Servidor();
                    p.Id_loc = val.Id_loc;
                    p.Cd_empresa = val.Cd_empresa;
                    TCN_ItensLocTerceiro.Gravar(p, qtb_locacao.Banco_Dados);
                });
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_locstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LocTerceiro qtb_loc = new TCD_LocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Exclusão Lógica
                val.St_registro = "C";
                qtb_loc.Gravar(val);
                val.lItens.ForEach(p => TCN_ItensLocTerceiro.Excluir(p, qtb_loc.Banco_Dados));
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static string GravaDuplicata(TRegistro_LocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LocTerceiro qtb_loc = new TCD_LocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_loc.CriarBanco_Dados(true);
                else
                    qtb_loc.Banco_Dados = banco;
                //Gravar Duplicata
                Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_loc.Banco_Dados);
                TCN_FatLocTerceiro.Gravar(new TRegistro_FatLocTerceiro()
                {
                    Id_loc = val.Id_loc,
                    Cd_empresa = val.Cd_empresa,
                    Nr_lancto = val.lDup[0].Nr_lancto
                }, qtb_loc.Banco_Dados);
                if (st_transacao)
                    qtb_loc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_loc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_loc.deletarBanco_Dados();
            }
        }

        public static string ReceberFin(TRegistro_Retirada val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Retirada qtb_locacao = new TCD_Retirada();
            try
            {
                if (banco == null)
                    st_transacao = qtb_locacao.CriarBanco_Dados(true);
                else
                    qtb_locacao.Banco_Dados = banco;
                //Buscar Historico
                object obj = new CamadaDados.Diversos.TCD_CfgEmpresa().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                        }
                    }, "a.cd_historico");
                if (obj == null ? true : string.IsNullOrEmpty(obj.ToString()))
                    throw new Exception("Configurar Histórico na CF.Empresa!");
                val.Login = Utils.Parametros.pubLogin;
                val.Dt_Retirada = CamadaDados.UtilData.Data_Servidor();
                val.Id_retiradastr = CamadaDados.TDataQuery.getPubVariavel(qtb_locacao.Gravar(val), "@P_ID_RETIRADA");
                if (st_transacao)
                    qtb_locacao.Banco_Dados.Commit_Tran();
                return val.Id_retiradastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_locacao.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar locacao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_locacao.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ItensLocTerceiro
    {
        public static TList_ItensLocTerceiro buscar(string Cd_empresa,
                                                string Id_loc,
                                                string St_registro,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_loc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_loc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_loc;
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "isnull(a.St_registro, 'A')";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }

            return new TCD_ItensLocTerceiro(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ItensLocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocTerceiro qtb_itens = new TCD_ItensLocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.Id_itemstr = CamadaDados.TDataQuery.getPubVariavel(qtb_itens.Gravar(val), "@P_ID_ITEM");
                //Gravar Produtos Item
                val.ProdutoItens.ForEach(x =>
                {
                    x.Cd_empresa = val.Cd_empresa;
                    x.Id_loc = val.Id_loc;
                    x.Id_item = val.Id_item;
                    TCN_ProdutoItens.Gravar(x, qtb_itens.Banco_Dados);
                });
                //Excluir Produtos Item
                val.ProdutoItensDel.ForEach(x => TCN_ProdutoItens.Excluir(x, qtb_itens.Banco_Dados));
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return val.Id_itemstr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ItensLocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ItensLocTerceiro qtb_itens = new TCD_ItensLocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ProdutoItens
    {
        public static TList_ProdutoItens Buscar(string Cd_empresa,
                                                string Id_loc,
                                                string Id_item,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrWhiteSpace(Cd_empresa))
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + Cd_empresa.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Id_loc))
                Estruturas.CriarParametro(ref filtro, "a.id_loc", Id_loc);
            if (!string.IsNullOrWhiteSpace(Id_item))
                Estruturas.CriarParametro(ref filtro, "a.id_item", Id_item);
            return new TCD_ProdutoItens(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ProdutoItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProdutoItens qtb_os = new TCD_ProdutoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProdutoItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProdutoItens qtb_os = new TCD_ProdutoItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_FatLocTerceiro
    {
        public static TList_FatLocTerceiro Buscar(string Id_locacao,
                                                       string Cd_empresa,
                                                       string Nr_lancto,
                                                       BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Id_locacao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_locacao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_locacao;
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lancto;
            }
            return new TCD_FatLocTerceiro(banco).Select(filtro, 0, string.Empty);
        }

        public static TList_RegLanDuplicata BuscarDup(string Cd_empresa,
                                                      string Id_locacao,
                                                      BancoDados.TObjetoBanco banco)
        {
            return new TCD_LanDuplicata(banco).Select(
                new TpBusca[]
                {
                    new TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = "exists",
                        vVL_Busca = "(select 1 from TB_LOC_FatLocTerceiro x " +
                                    "where x.cd_empresa = a.cd_empresa " +
                                    "and x.nr_lancto = a.nr_lancto " +
                                    "and x.cd_empresa = '" + Cd_empresa.Trim() + "' " +
                                    "and x.id_locacao = '" + Id_locacao.Trim() + "')"
                    }
                }, 0, string.Empty);
        }

        public static string Gravar(TRegistro_FatLocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FatLocTerceiro qtb_os = new TCD_FatLocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_FatLocTerceiro val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_FatLocTerceiro qtb_os = new TCD_FatLocTerceiro();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                qtb_os.Excluir(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AbastItens
    {
        public static TList_AbastItens buscar(string Cd_empresa,
                                              string Id_loc,
                                              string Id_item,
                                              string Id_carga,
                                              string Id_itemcarga,
                                              string Cd_patrimonio,
                                              string Cd_produto,
                                              string Dt_ini,
                                              string Dt_fin,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_loc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_loc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_loc;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_carga";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Id_itemcarga))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemcarga";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemcarga;
            }
            if (!string.IsNullOrWhiteSpace(Cd_patrimonio))
                Estruturas.CriarParametro(ref vBusca, "e.cd_patrimonio", "'" + Cd_patrimonio.Trim() + "'");
            if (!string.IsNullOrWhiteSpace(Cd_produto))
                Estruturas.CriarParametro(ref vBusca, "b.cd_produto", "'" + Cd_produto.Trim() + "'");
            if (Dt_ini.IsDateTime())
                Estruturas.CriarParametro(ref vBusca, "convert(datetime, floor(convert(decimal(30,10), a.DT_Abast)))",
                    "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'", ">=");
            if(Dt_fin.IsDateTime())
                Estruturas.CriarParametro(ref vBusca, "convert(datetime, floor(convert(decimal(30,10), a.DT_Abast)))",
                    "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'", "<=");
            return new TCD_AbastItens(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_AbastItens val,
                                    BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastItens qtb_itens = new TCD_AbastItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                
                qtb_itens.Gravar(val);

                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AbastItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastItens qtb_itens = new TCD_AbastItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static TList_AbastItens Gravar(TRegistro_AbastItens val,
                                              CamadaDados.Faturamento.Entrega.TList_ItensCargaAvulsa lItensCarga,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TList_AbastItens retorno = new TList_AbastItens();
            TCD_AbastItens qtb_abast = new TCD_AbastItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_abast.CriarBanco_Dados(true);
                else qtb_abast.Banco_Dados = banco;
                decimal total = val.Quantidade;
                decimal abast = decimal.Zero;
                foreach(CamadaDados.Faturamento.Entrega.TRegistro_ItensCargaAvulsa r in lItensCarga)
                {
                    if (abast < total)
                    {
                        decimal qtd = (total - abast) > r.Saldo ? r.Saldo : (total - abast);
                        val.Quantidade = qtd;
                        val.Id_carga = r.Id_carga;
                        val.Id_itemcarga = r.Id_item;
                        val.Cd_produto = r.Cd_produto;
                        val.Ds_produto = r.Ds_produto;
                        val.Sigla = r.Sigla;
                        Gravar(val, qtb_abast.Banco_Dados);
                        retorno.Add(val);
                        abast += qtd;
                    }
                    else break;
                }
                if (st_transacao)
                    qtb_abast.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_abast.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_abast.deletarBanco_Dados();
            }
        }
    }

    public class TCN_AbastItens_X_NFCeItens
    {
        public static TList_AbastItens_X_NFCeItens buscar(string Cd_empresa,
                                                string Id_loc,
                                                string Id_item,
                                                string Id_carga,
                                                string Id_itemcarga,
                                                string Id_cupom,
                                                string Id_lancto,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_loc))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_loc";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_loc;
            }
            if (!string.IsNullOrEmpty(Id_item))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_item";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_item;
            }
            if (!string.IsNullOrEmpty(Id_carga))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_carga";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_carga;
            }
            if (!string.IsNullOrEmpty(Id_itemcarga))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_itemcarga";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_itemcarga;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_cupom";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_lancto";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_lancto;
            }

            return new TCD_AbastItens_X_NFCeItens(banco).Select(vBusca, 0, string.Empty, false);
        }

        public static string Gravar(TRegistro_AbastItens_X_NFCeItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastItens_X_NFCeItens qtb_itens = new TCD_AbastItens_X_NFCeItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Gravar(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_AbastItens_X_NFCeItens val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_AbastItens_X_NFCeItens qtb_itens = new TCD_AbastItens_X_NFCeItens();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else
                    qtb_itens.Banco_Dados = banco;
                qtb_itens.Excluir(val);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir item: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }
    }
}
