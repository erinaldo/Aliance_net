using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.Fidelizacao;

namespace CamadaNegocio.Faturamento.Fidelizacao
{
    public class TCN_ProgFidelidade
    {
        public static TList_ProgFidelidade Buscar(string Cd_empresa,
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
            return new TCD_ProgFidelidade(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ProgFidelidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProgFidelidade qtb_prog = new TCD_ProgFidelidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_prog.CriarBanco_Dados(true);
                else qtb_prog.Banco_Dados = banco;
                string retorno = qtb_prog.Gravar(val);
                if (st_transacao)
                    qtb_prog.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_prog.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar programação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_prog.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProgFidelidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transcao = false;
            TCD_ProgFidelidade qtb_prog = new TCD_ProgFidelidade();
            try
            {
                if (banco == null)
                    st_transcao = qtb_prog.CriarBanco_Dados(true);
                else qtb_prog.Banco_Dados = banco;
                qtb_prog.Excluir(val);
                if (st_transcao)
                    qtb_prog.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transcao)
                    qtb_prog.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir programação: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transcao)
                    qtb_prog.deletarBanco_Dados();
            }
        }
    }

    public class TCN_PontosFidelidade
    {
        public static TList_PontosFidelidade Buscar(string Cd_empresa,
                                                    string Id_ponto,
                                                    string Cd_clifor,
                                                    string Placa,
                                                    string Cpf_cliente,
                                                    string Tp_data,
                                                    string Dt_ini,
                                                    string Dt_fin,
                                                    string Id_cupom,
                                                    string Nr_lanctofiscal,
                                                    string TP_Com_Sem_Saldo,
                                                    string St_cancelado,
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
            if (!string.IsNullOrEmpty(Id_ponto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ponto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ponto;
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Placa.Trim().Replace("-", string.Empty)))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "replace(a.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty) + "'";
            }
            if (!string.IsNullOrEmpty(Cpf_cliente))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cpf_cliente";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cpf_cliente.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("R") ? "a.dt_registro" : "a.dt_validade") + ")))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), " + (Tp_data.Trim().ToUpper().Equals("R") ? "a.dt_registro" : "a.dt_validade") + ")))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(TP_Com_Sem_Saldo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.qt_pontos - a.pontos_res";
                filtro[filtro.Length - 1].vOperador = TP_Com_Sem_Saldo.Trim().ToUpper().Equals("C") ? ">" : "=";
                filtro[filtro.Length - 1].vVL_Busca = "0";

                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "<>";
                filtro[filtro.Length - 1].vVL_Busca = "'C'";
            }
            if (!string.IsNullOrEmpty(St_cancelado))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_registro";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = St_cancelado;
            }
            return new TCD_PontosFidelidade(banco).Select(filtro, 0, string.Empty, string.Empty);
        }

        public static string Gravar(TRegistro_PontosFidelidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PontosFidelidade qtb_pontos = new TCD_PontosFidelidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pontos.CriarBanco_Dados(true);
                else qtb_pontos.Banco_Dados = banco;
                val.Id_pontostr = CamadaDados.TDataQuery.getPubVariavel(qtb_pontos.Gravar(val), "@P_ID_PONTO");
                if (st_transacao)
                    qtb_pontos.Banco_Dados.Commit_Tran();
                return val.Id_pontostr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pontos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pontos: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pontos.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_PontosFidelidade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_PontosFidelidade qtb_pontos = new TCD_PontosFidelidade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_pontos.CriarBanco_Dados(true);
                else qtb_pontos.Banco_Dados = banco;
                //Verificar se ja houve resgate para os pontos
                object obj = new TCD_ResgatePontos(qtb_pontos.Banco_Dados).BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + val.Cd_empresa.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_ponto",
                                        vOperador = "=",
                                        vVL_Busca = val.Id_pontostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.st_registro, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'C'"
                                    }
                                }, "1");
                if (obj != null)
                    if (string.IsNullOrEmpty(val.LoginCanc))
                        throw new Exception("Não é permitido cancelar pontos resgatados.");
                    else
                        new TCD_ValeResgate(qtb_pontos.Banco_Dados).Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_fat_resgatepontos x " +
                                                "where x.cd_empresa = a.cd_empresa " +
                                                "and x.id_vale = a.id_vale " +
                                                "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "' " +
                                                "and x.id_ponto = " + val.Id_pontostr + ")"
                                }
                            }, 0, string.Empty).ForEach(p =>
                                {
                                    p.Logincanc = val.LoginCanc;
                                    TCN_ValeResgate.Excluir(p, qtb_pontos.Banco_Dados);
                                });
                qtb_pontos.Excluir(val);
                if (st_transacao)
                    qtb_pontos.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_pontos.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_pontos.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ResgatePontos
    {
        public static TList_ResgatePontos Buscar(string Cd_empresa,
                                                 string Id_ponto,
                                                 string Login,
                                                 string Id_vale,
                                                 string Id_prevenda,
                                                 string Id_itemprevenda,
                                                 string Id_cupom,
                                                 string Id_lancto,
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
            if (!string.IsNullOrEmpty(Id_ponto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ponto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ponto;
            }
            if (!string.IsNullOrEmpty(Login))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.login";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Login.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_vale))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vale";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_vale;
            }
            if (!string.IsNullOrEmpty(Id_prevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_prevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_prevenda;
            }
            if (!string.IsNullOrEmpty(Id_itemprevenda))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_itemprevenda";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_itemprevenda;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            if (!string.IsNullOrEmpty(Id_lancto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lancto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lancto;
            }
            return new TCD_ResgatePontos(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ResgatePontos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ResgatePontos qtb_res = new TCD_ResgatePontos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_res.CriarBanco_Dados(true);
                else qtb_res.Banco_Dados = banco;
                val.Id_resgatestr = CamadaDados.TDataQuery.getPubVariavel(qtb_res.Gravar(val), "@P_ID_RESGATE");
                if (st_transacao)
                    qtb_res.Banco_Dados.Commit_Tran();
                return val.Id_resgatestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_res.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar resgate: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_res.deletarBanco_Dados();
            }
        }
        
        public static string Excluir(TRegistro_ResgatePontos val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ResgatePontos qtb_res = new TCD_ResgatePontos();
            try
            {
                if (banco == null)
                    st_transacao = qtb_res.CriarBanco_Dados(true);
                else qtb_res.Banco_Dados = banco;
                qtb_res.Excluir(val);
                if (st_transacao)
                    qtb_res.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_res.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir resgate: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_res.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ValeResgate
    {
        public static TList_ValeResgate Buscar(string Cd_empresa,
                                               string Id_vale,
                                               string Id_ponto,
                                               string Id_resgate,
                                               string St_impresso,
                                               string Placa,
                                               string CD_Clifor,
                                               string Dt_ini,
                                               string Dt_fin,
                                               string St_registro,
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
            if (!string.IsNullOrEmpty(Id_vale))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_vale";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_vale;
            }
            if (!string.IsNullOrEmpty(Id_ponto))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_ponto";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_ponto;
            }
            if (!string.IsNullOrEmpty(Id_resgate))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_resgate";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_resgate;
            }
            if (!string.IsNullOrEmpty(St_impresso))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_impresso, 'N')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_impresso.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Placa.Trim().Replace("-", string.Empty)))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "replace(a.placa, '-', '')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placa.Replace("-", string.Empty) + "'";
            }
            if(!string.IsNullOrWhiteSpace(CD_Clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + CD_Clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Dt_ini.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_cad)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_ini).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(Dt_fin.SoNumero()))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_cad)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(Dt_fin).ToString("yyyyMMdd") + "'";
            }
            if (!string.IsNullOrEmpty(St_registro))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_registro.Trim() + "'";
            }
            return new TCD_ValeResgate(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ValeResgate val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ValeResgate qtb_vale = new TCD_ValeResgate();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vale.CriarBanco_Dados(true);
                else qtb_vale.Banco_Dados = banco;
                val.Id_valestr = CamadaDados.TDataQuery.getPubVariavel(qtb_vale.Gravar(val), "@P_ID_VALE");
                val.lResgate.ForEach(p =>
                    {
                        p.Id_vale = val.Id_vale;
                        TCN_ResgatePontos.Gravar(p, qtb_vale.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_vale.Banco_Dados.Commit_Tran();
                return val.Id_valestr;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vale.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar vale: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vale.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ValeResgate val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ValeResgate qtb_vale = new TCD_ValeResgate();
            try
            {
                if (banco == null)
                    st_transacao = qtb_vale.CriarBanco_Dados(true);
                else qtb_vale.Banco_Dados = banco;
                val.St_registro = "C";
                qtb_vale.Gravar(val);
                TCN_ResgatePontos.Buscar(val.Cd_empresa,
                                         string.Empty,
                                         string.Empty,
                                         val.Id_valestr,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         qtb_vale.Banco_Dados).ForEach(p =>
                                             {
                                                 p.Logincanc = val.Logincanc;
                                                 p.St_registro = "C";
                                                 TCN_ResgatePontos.Gravar(p, qtb_vale.Banco_Dados);
                                             });
                if (st_transacao)
                    qtb_vale.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_vale.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir vale: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_vale.deletarBanco_Dados();
            }
        }
    }
}
