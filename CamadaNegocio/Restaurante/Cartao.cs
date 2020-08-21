using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CamadaDados.Restaurante;
using Utils;
 

namespace CamadaNegocio.Restaurante
{

    public class TCN_Cartao
    {
        public static TList_Cartao Buscar(string Cd_empresa,
                                          string id_cartao,
                                          string nr_cartao,
                                          string cd_clifor,
                                          string dt_abertura,
                                          string dt_fechamento,
                                          string st_registro,
                                          string nr_nfce,
                                          string st_nfce,// 0 = todos //1 = com cupom // 2 sem cupom
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
            if (!string.IsNullOrEmpty(nr_nfce))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + nr_nfce.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(st_nfce))
            {
                if (st_nfce.Equals("1"))
                {//1 = com cupom
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                    filtro[filtro.Length - 1].vOperador = "is not null";
                }
                else if(st_nfce.Equals("2"))
                {// 2 sem cupom
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.nr_nfce";
                    filtro[filtro.Length - 1].vOperador = "is null";
                } // 0 = todos 
            } 
            if (!string.IsNullOrEmpty(id_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_cartao;// + " or ( b.id_orc = '" + Id_orcamento + "')";
            }
            if (!string.IsNullOrEmpty(nr_cartao))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_cartao";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_cartao;
            }
            if (!string.IsNullOrEmpty(cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_clifor.Trim() + "'";
            }
            //if (!string.IsNullOrEmpty(dt_abertura.SoNumero()))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abertura)))";
            //    filtro[filtro.Length - 1].vOperador = ">=";
            //    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_abertura).ToString("yyyyMMdd") + "'";
            //}
            if (!string.IsNullOrEmpty(dt_abertura.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abertura)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_abertura).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(dt_fechamento.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_fechamento)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fechamento).ToString("yyyyMMdd") + "'";
            }
            //if (!string.IsNullOrEmpty(dt_fechamento.SoNumero()))
            //{
            //    Array.Resize(ref filtro, filtro.Length + 1);
            //    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_fechamento)))";
            //    filtro[filtro.Length - 1].vOperador = "<=";
            //    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fechamento).ToString("yyyyMMdd") + "'";
            //}
            if (!string.IsNullOrEmpty(st_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + st_registro.Trim() + "'";
            }
            return new TCD_Cartao(banco).Select(filtro, 0, string.Empty,string.Empty);
        }

        public static string Gravar(TRegistro_Cartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cartao qtb_orc = new TCD_Cartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                

                string ret = qtb_orc.Gravar(val);
                val.id_cartao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_CARTAO"));
                if (!string.IsNullOrWhiteSpace(val.Cd_Clifor) &&
                    !string.IsNullOrEmpty(val.Nm_Clifor))
                {
                    //Verificar se nome do cliente foi alterado
                    CamadaDados.Restaurante.Cadastro.TRegistro_Clifor rClifor =
                        new CamadaDados.Restaurante.Cadastro.TCD_Clifor(qtb_orc.Banco_Dados).Select(
                        new TpBusca[] { new TpBusca { vNM_Campo = "a.cd_clifor", vOperador = "=", vVL_Busca = "'" + val.Cd_Clifor.Trim() + "'" } }, 1, string.Empty)[0];
                    if (rClifor.Nm_clifor.Trim().ToUpper() != val.Nm_Clifor.Trim().ToUpper())
                    {
                        rClifor.Nm_clifor = val.Nm_Clifor;
                        Cadastro.TCN_CliFor.Gravar(rClifor, qtb_orc.Banco_Dados);
                    }
                }
                val.lPreVenda.ForEach(p =>
                { 
                    p.Cd_empresa = val.Cd_empresa;
                    p.id_cartao = val.id_cartao; 
                    TCN_PreVenda.Gravar(p, qtb_orc.Banco_Dados);
                    
                });

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_cartao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar CARTAO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string GravarDelivery(TRegistro_Cartao val, CamadaDados.Restaurante.Cadastro.TRegistro_Clifor cli, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cartao qtb_orc = new TCD_Cartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                val.Cd_Clifor = CamadaNegocio.Restaurante.Cadastro.TCN_CliFor.Gravar(cli, qtb_orc.Banco_Dados); 
                
                string ret = qtb_orc.Gravar(val);
                val.id_cartao = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(ret, "@P_ID_CARTAO"));
                val.lPreVenda.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.id_cartao = val.id_cartao;
                    TCN_PreVenda.Gravar(p, qtb_orc.Banco_Dados);
                });

                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_cartao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar CARTAO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
         
        public static string Excluir(TRegistro_Cartao val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;

            TCD_Cartao qtb_orc = new TCD_Cartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Excluir PreVenda
                val.lPreVenda.ForEach(p => TCN_PreVenda.Excluir(p, qtb_orc.Banco_Dados));
                val.St_registro = "C";
                qtb_orc.Gravar(val);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir CARTAO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }

        public static string FecharCartao(TRegistro_Cartao val,
                                          CamadaDados.Faturamento.PDV.TRegistro_VendaRapida rVenda,
                                          ThreadEspera tEspera,
                                          BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Cartao qtb_orc = new TCD_Cartao();
            try
            {
                if (banco == null)
                    st_transacao = qtb_orc.CriarBanco_Dados(true);
                else qtb_orc.Banco_Dados = banco;
                //Gravar Venda
                Faturamento.PDV.TCN_VendaRapida.GravarVendaRapida(rVenda,
                                                                  null,
                                                                  null,
                                                                  qtb_orc.Banco_Dados);
                //Fechar Cartão
                val.St_registro = "F";
                val.Dt_fechamento = CamadaDados.UtilData.Data_Servidor(qtb_orc.Banco_Dados);
                Gravar(val, qtb_orc.Banco_Dados);
                if (st_transacao)
                    qtb_orc.Banco_Dados.Commit_Tran();
                return val.id_cartao.ToString();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_orc.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar CARTAO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_orc.deletarBanco_Dados();
            }
        }
    }
}
