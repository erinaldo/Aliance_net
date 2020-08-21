using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Empreendimento;
using CamadaDados.Empreendimento.Cadastro;
using CamadaNegocio.Empreendimento.Cadastro;
using Utils;
using CamadaDados.Compra;
using CamadaNegocio.Compra;

namespace CamadaNegocio.Empreendimento
{
    public class TCN_CompraEmpreendimento
    {
        public static TList_CompraEmpreendimento Buscar(string Cd_empresa,
                                          string id_orcamento,
                                          string nr_versao,
                                          string id_atividade,
                                          string id_requisicao,
                                          BancoDados.TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_orcamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_orcamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_orcamento;
            }
            if (!string.IsNullOrEmpty(nr_versao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_versao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_versao.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_atividade))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_atividade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_atividade.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(id_requisicao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_requisicao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + id_requisicao.Trim() + "'";
            }
            return new TCD_CompraEmpreendimento(banco).Select(filtro, 0, string.Empty);
        }

        public static string GravarDireto(TRegistro_Orcamento orcamento,TList_FichaTec litens, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraEmpreendimento qtb_orc = new TCD_CompraEmpreendimento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                TList_CadCFGEmpreendimento lCfg = TCN_CadCFGEmpreendimento.Busca(string.Empty, string.Empty, qtb_orc.Banco_Dados);
                if (lCfg.Count.Equals(0)) { throw new Exception("Não existe cadastro CFG.Empreendimento."); }

                TList_FichaTec itensDireto = new TList_FichaTec();
                if (litens == null)
                    orcamento.lOrcProjeto.ForEach(o =>
                    {
                        o.lFicha.ForEach(p =>
                        {
                            if (p.St_fatdiretobool)
                                itensDireto.Add(p);
                        });
                    });
                else
                    litens.ForEach(p =>
                    {
                        itensDireto.Add(p);
                    });

                string ret = string.Empty;
                itensDireto.ForEach(p =>
                {
                    CamadaDados.Compra.Lancamento.TRegistro_Requisicao req = new CamadaDados.Compra.Lancamento.TRegistro_Requisicao();
                    req.Cd_empresa = orcamento.Cd_empresa;
                    req.Cd_produto = p.Cd_produto;
                    req.Ds_produto = p.Ds_produto;
                    req.Quantidade = p.quantidade_agregar == decimal.Zero? p.Quantidade : p.quantidade_agregar;
                    CamadaDados.Financeiro.Cadastros.TList_CadClifor lclifor = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                                        new Utils.TpBusca[]
                                        {
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = "isnull(a.st_registro, 'A')",
                                                vOperador = "<>",
                                                vVL_Busca = "'C'"
                                            },
                                            new Utils.TpBusca()
                                            {
                                                vNM_Campo = string.Empty,
                                                vOperador = "exists",
                                                vVL_Busca = "(select 1 from tb_cmp_usuariocompra x " +
                                                            "where x.cd_clifor_cmp = a.cd_clifor " +
                                                            "and isnull(x.st_requisitar, 'N') = 'S' " +
                                                            "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')"
                                            }
                                        }, 0, string.Empty);
                    if(lclifor.Count > 0)
                    {
                        req.Cd_clifor_comprador = lclifor[0].Cd_clifor;
                        req.Cd_clifor_requisitante = lclifor[0].Cd_clifor;
                    }
                    
                    req.St_requisicao = "AC";
                    req.Id_tprequisicaostr = p.St_fatdiretobool ? lCfg[0].tp_requisicaodir: lCfg[0].tp_requisicao;
                    //GRAVAR 
                    req.Id_requisicao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(
                        CamadaNegocio.Compra.Lancamento.TCN_Requisicao.GravarRequisicao(req, qtb_orc.Banco_Dados), "@P_ID_REQUISICAO"));

                    TRegistro_CompraEmpreendimento val = new TRegistro_CompraEmpreendimento();
                    val.Id_orcamentostr = p.Id_orcamentostr;
                    val.Id_registrostr = p.Id_registrostr;
                    val.Id_requisicao = req.Id_requisicao;
                    val.Nr_versao = p.Nr_versao;
                    val.Id_ficha = p.Id_ficha;
                    val.id_atividade = p.Id_projetostr;
                    val.Cd_empresa = p.Cd_empresa;
                    ret = qtb_orc.Gravar(val);
                    val.Id_requisicao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_REQUISICAO"));
                });


                //string ret = qtb_orc.Gravar(val);

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return ret;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar requisicao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }



        public static string Excluir(TRegistro_CompraEmpreendimento val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CompraEmpreendimento qtb_orc = new TCD_CompraEmpreendimento();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;

                qtb_orc.Excluir(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir requisicao: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
