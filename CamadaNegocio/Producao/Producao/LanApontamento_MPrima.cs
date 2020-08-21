using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Producao.Producao;

namespace CamadaNegocio.Producao.Producao
{
    public class TCN_Apontamento_MPrima
    {
        public static TList_Apontamento_MPrima Buscar(string Id_apontamento,
                                                      BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(Id_apontamento))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_apontamento";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_apontamento;
            }
            return new TCD_Apontamento_MPrima(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Apontamento_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Apontamento_MPrima qtb_apont = new TCD_Apontamento_MPrima();
            try
            {
                if (banco == null)
                    st_transacao = qtb_apont.CriarBanco_Dados(true);
                else
                    qtb_apont.Banco_Dados = banco;
                string retorno = qtb_apont.Gravar(val);
                if (st_transacao)
                    qtb_apont.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_apont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar materia prima apontamento: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_apont.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_Apontamento_MPrima val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Apontamento_MPrima qtb_apont = new TCD_Apontamento_MPrima();
            try
            {
                if(banco == null)
                    st_transacao = qtb_apont.CriarBanco_Dados(true);
                else
                    qtb_apont.Banco_Dados = banco;
                //Excluir materia prima
                qtb_apont.Excluir(val);
                //Verificar se era um subconjunto
                if (val.Id_apontamentomprima != null)
                {
                    //Buscar apontamento materia prima
                    TRegistro_ApontamentoProducao rApontamento = TCN_ApontamentoProducao.Buscar(val.Id_apontamentomprima.Value.ToString(),
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            string.Empty,
                                                                                            1,
                                                                                            string.Empty,
                                                                                            qtb_apont.Banco_Dados)[0];
                    rApontamento.LApontamentoEstoque = TCN_Apontamento_Estoque.Buscar(rApontamento.Id_apontamentostr,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      qtb_apont.Banco_Dados);
                    rApontamento.LCustoFixo = TCN_Apontamento_CustoFixo.Buscar(rApontamento.Id_apontamentostr,
                                                                               string.Empty,
                                                                               0,
                                                                               string.Empty,
                                                                               qtb_apont.Banco_Dados);
                    //Buscar Materia Prima Apontamento
                    rApontamento.lMPrimaApontamento = Buscar(rApontamento.Id_apontamentostr, qtb_apont.Banco_Dados);
                    //Buscar custo fixo apontamento
                    rApontamento.LCustoFixo = TCN_Apontamento_CustoFixo.Buscar(rApontamento.Id_apontamentostr,
                                                                               string.Empty,
                                                                               0,
                                                                               string.Empty,
                                                                               qtb_apont.Banco_Dados);
                    //Chamar metodo excluir apontamento
                    TCN_ApontamentoProducao.Deletar(rApontamento, qtb_apont.Banco_Dados);
                }
                if(st_transacao)
                    qtb_apont.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch(Exception ex)
            {
                if(st_transacao)
                    qtb_apont.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir materia prima apontamento: "+ex.Message.Trim());
            }
            finally
            {
                if(st_transacao)
                    qtb_apont.deletarBanco_Dados();
            }
        }
    }
}
