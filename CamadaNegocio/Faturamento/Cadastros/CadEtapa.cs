using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BancoDados;
using Utils;
using CamadaDados.Faturamento.Cadastros;

namespace CamadaNegocio.Faturamento.Cadastros
{
    #region Etapa
    public class TCN_CadEtapa
    {
        public static TList_CadEtapa Busca(  string ID_Etapa,
                                              string DS_Etapa,
                                              string St_fecha,
                                              string Ordem,
                                              BancoDados.TObjetoBanco banco)
        {
        TpBusca[] vBusca = new TpBusca[0];


        if (!string.IsNullOrEmpty(ID_Etapa))
        {
            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Etapa";
            vBusca[vBusca.Length - 1].vOperador = "=";
            vBusca[vBusca.Length - 1].vVL_Busca = "'" + ID_Etapa.Trim() + "'";
        }
        if (!string.IsNullOrEmpty(DS_Etapa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Etapa";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DS_Etapa.Trim() + "%')";
            }
        if (!string.IsNullOrEmpty(St_fecha))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.St_fecha";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + St_fecha.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Ordem))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Ordem";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + Ordem.Trim() + "%')";
            }
           
            return new TCD_CadEtapa(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_CadEtapa val, BancoDados.TObjetoBanco banco)
        {
            TCD_CadEtapa cd = new TCD_CadEtapa();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                //Buscar ultimo numero da ordem
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadEtapa(cd.Banco_Dados).BuscarEscalar(null, "isnull(a.Ordem, 0)", string.Empty, "a.id_etapa desc", null);
                if (obj != null)
                    val.Ordem = Convert.ToDecimal(obj.ToString()) + 1;
                val.Id_etapastr = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_ID_ETAPA");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.Id_etapastr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar etapa: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void MoverRegistros(TRegistro_CadEtapa rOrig, TRegistro_CadEtapa rDest, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEtapa qtb_itens = new TCD_CadEtapa();
            try
            {
                if (banco == null)
                    st_transacao = qtb_itens.CriarBanco_Dados(true);
                else qtb_itens.Banco_Dados = banco;
                decimal classif = rOrig.Ordem;
                rOrig.Ordem = rDest.Ordem;
                qtb_itens.Grava(rOrig);
                rDest.Ordem = classif;
                qtb_itens.Grava(rDest);
                if (st_transacao)
                    qtb_itens.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_itens.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro mover registros: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_itens.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_CadEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadEtapa cd = new TCD_CadEtapa();
            try
            {

                
                object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadEtapa(cd.Banco_Dados).BuscarEscalar(
                    new TpBusca[]{
                        new TpBusca(){
                            vNM_Campo = "",
                            vOperador = "exists",
                            vVL_Busca = "(select b.ID_Etapa from TB_FAT_pedido_etapa b where a.id_etapa = b.id_etapa)"
                        },
                        new TpBusca(){
                            vNM_Campo = "a.id_etapa",
                            vOperador = "=",
                            vVL_Busca = val.Id_etapastr
                        }
                    }, "isnull(a.id_etapa, 0)", string.Empty, "a.id_etapa desc", null);
                if (obj == null)
                {
                    if (banco == null)
                        st_transacao = cd.CriarBanco_Dados(true);
                    else
                        cd.Banco_Dados = banco;
                    val.lprocesso.ForEach(p => TCN_CadProcessoEtapa.Excluir(p, cd.Banco_Dados));
                    cd.Deleta(val);
                    if (st_transacao)
                        cd.Banco_Dados.Commit_Tran();
                }
                else
                {
                    val.stRegistro = "C";
                    Gravar(val, null);
                }
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
    #endregion

    #region processoEtapa
    public class TCN_CadProcessoEtapa
    {
        public static TList_ProcessoEtapa Busca(string ID_Etapa,
                                              string ID_Processo,
                                              string DS_Processo,
                                              BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (!string.IsNullOrEmpty(ID_Etapa))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Etapa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ID_Etapa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(ID_Processo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_Processo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + ID_Processo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(DS_Processo))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.DS_Processo";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + DS_Processo.Trim() + "%')";
            }
            return new TCD_ProcessoEtapa(banco).Select(vBusca, 0, string.Empty);

        }

        public static string Gravar(TRegistro_ProcessoEtapa val, BancoDados.TObjetoBanco banco)
        {
            TCD_ProcessoEtapa cd = new TCD_ProcessoEtapa();
            bool st_transacao = false;
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.ID_Processostr = CamadaDados.TDataQuery.getPubVariavel(cd.Grava(val), "@P_ID_PROCESSO");
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return val.ID_Processostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static void Excluir(TRegistro_ProcessoEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcessoEtapa cd = new TCD_ProcessoEtapa();
            try
            { object obj = new CamadaDados.Faturamento.Cadastros.TCD_CadEtapa(cd.Banco_Dados).BuscarEscalar(
                    new TpBusca[]{
                        new TpBusca(){
                            vNM_Campo = "",
                            vOperador = "exists",
                            vVL_Busca = "(select b.ID_Etapa from TB_FAT_pedido_etapa b where a.id_etapa = b.id_etapa)"
                        },
                        new TpBusca(){
                            vNM_Campo = "a.id_etapa",
                            vOperador = "=",
                            vVL_Busca = val.Id_etapastr
                        }
                    }, "isnull(a.id_etapa, 0)", string.Empty, "a.id_etapa desc", null);
            if (obj == null)
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
            }
            else
            {
                val.stRegistro = "C";
                Gravar(val, null);

            }
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir serie: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
    #endregion
}
