using System;
using System.Collections.Generic;
using Utils;
using System.Text;
using CamadaDados.Diversos;


namespace CamadaNegocio.Diversos
{
    public class TCN_CadUsuario
    {
        public static bool ExpirarSenha(string vLogin)
        {
            if (vLogin.Trim() != string.Empty)
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "login";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + vLogin.Trim() + "'";
                TList_CadUsuario user = new TCD_CadUsuario().Select(filtro, 1, string.Empty);
                if (user.Count > 0)
                    if (user[0].St_ExpirarSenha.Trim().ToUpper().Equals("S"))
                        return user[0].Dt_altsenha.Value.AddDays(Convert.ToDouble(user[0].Qt_DiasExpirar)) <= DateTime.Today;
                    else
                        return false;
                else
                    return false;
            }
            else
                return false;
        }

        public static bool verificarAlterarSenha(string vLogin)
        {
            if (vLogin.Trim() != string.Empty)
            {
                TpBusca[] filtro = new TpBusca[1];
                filtro[0].vNM_Campo = "login";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + vLogin.Trim() + "'";
                TList_CadUsuario user = new TCD_CadUsuario().Select(filtro, 1, string.Empty);
                if(user.Count > 0)
                {
                    if (user[0].St_AlterarSenha != null)
                    {
                        if (user[0].St_AlterarSenha.Equals("S"))

                            return true;
                        else
                            return false;
                    }
                    
                    else
                        return false;
                }
                else return false;
                
            }
            else
                return false;
        }

        public static TList_CadUsuario Busca(string vLogin, 
                                             string vNM_Usuario, 
                                             string vTp_registro, 
                                             BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vLogin))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "LOGIN";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vLogin.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }

            if (!string.IsNullOrEmpty(vNM_Usuario))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "NOME_USUARIO";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vNM_Usuario.Trim() + "%')";
                vBusca[vBusca.Length - 1].vOperador = "like";
            }
            if (!string.IsNullOrEmpty(vTp_registro))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "tp_registro";
                vBusca[vBusca.Length - 1].vOperador = "in";
                vBusca[vBusca.Length - 1].vVL_Busca = "(" + vTp_registro.Trim() + ")";
            }

            return new TCD_CadUsuario(banco).Select(vBusca, 0, "");
        }

        public static string Gravar(TRegistro_CadUsuario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario qtb_user = new TCD_CadUsuario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                string retorno = qtb_user.GravaUsuario(val);
                //Grupo Usuario
                val.lGrupoDel.ForEach(p => TCN_CadUsuario_Grupo.Excluir(p, qtb_user.Banco_Dados));
                val.lGrupo.ForEach(p =>
                    {
                        p.LoginUsr = val.Login;
                        TCN_CadUsuario_Grupo.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Empresa
                val.lEmpresaDel.ForEach(p => TCN_CadUsuario_Empresa.Excluir(p, qtb_user.Banco_Dados));
                val.lEmpresa.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_CadUsuario_Empresa.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Terminal
                val.lTerminalDel.ForEach(p => TCN_CadUsuarioxTerminal.Excluir(p, qtb_user.Banco_Dados));
                val.lTerminal.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_CadUsuarioxTerminal.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Tipo Pesagem
                val.lPesagemDel.ForEach(p => TCN_CadUsuario_TipoPesagem.Excluir(p, qtb_user.Banco_Dados));
                val.lPesagem.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_CadUsuario_TipoPesagem.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Tipo Pedido
                val.lPedidoDel.ForEach(p=> TCN_CadUsuario_CFGPedido.Excluir(p, qtb_user.Banco_Dados));
                val.lPedido.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_CadUsuario_CFGPedido.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Conta Gerencial
                val.lContaGerDel.ForEach(p => TCN_Usuario_ContaGer.Excluir(p, qtb_user.Banco_Dados));
                val.lContaGer.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_Usuario_ContaGer.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Tipo Requisicao
                val.lTpRequisicaoDel.ForEach(p => TCN_Usuario_TpRequisicao.Excluir(p, qtb_user.Banco_Dados));
                val.lTpRequisicao.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_Usuario_TpRequisicao.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Tipo Duplicata
                val.lTpDupDel.ForEach(p => TCN_Usuario_TpDuplicata.Excluir(p, qtb_user.Banco_Dados));
                val.lTpDuplicata.ForEach(p =>
                    {
                        p.Login = val.Login;
                        TCN_Usuario_TpDuplicata.Gravar(p, qtb_user.Banco_Dados);
                    });
                //Regra especial
                val.lRegraDel.ForEach(p => TCN_Usuario_RegraEspecial.Excluir(p, qtb_user.Banco_Dados));
                val.lRegra.ForEach(p =>
                {
                    p.Login = val.Login;
                    TCN_Usuario_RegraEspecial.Gravar(p, qtb_user.Banco_Dados);
                }); 
                //Etapa pedido
                val.lEtapaPedDel.ForEach(p => CamadaNegocio.Diversos.TCN_CadUsuario_EtapaPed.Excluir(p, qtb_user.Banco_Dados));
                val.lEtapaPed.ForEach(p =>
                {
                    p.Login = val.Login;
                    CamadaNegocio.Diversos.TCN_CadUsuario_EtapaPed.Gravar(p, qtb_user.Banco_Dados);
                });
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar usuario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_CadUsuario val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario qtb_user = new TCD_CadUsuario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                val.St_Registro = "C";
                Gravar(val, qtb_user.Banco_Dados);
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir usuario: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }

        public static bool CopiarPerfil(TRegistro_CadUsuario val,
                                        string LoginPerfil,
                                        BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadUsuario qtb_user = new TCD_CadUsuario();
            try
            {
                if (banco == null)
                    st_transacao = qtb_user.CriarBanco_Dados(true);
                else
                    qtb_user.Banco_Dados = banco;
                //Verificar se o login destino ja existe no sistema
                bool st_existe = qtb_user.BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.login",
                                            vOperador = "=",
                                            vVL_Busca = "'" + val.Login.Trim() + "'"
                                        }
                                    }, "1") != null;
                //Gravar Login
                qtb_user.GravaUsuario(val);
                //Copiar acesso usuario
                if (st_existe)
                    qtb_user.executarSql("delete tb_div_acesso where login = '" + val.Login.Trim() + "'", null);
                TCN_CadAcesso.Buscar(LoginPerfil,
                                     string.Empty,
                                     false,
                                     string.Empty,
                                     0,
                                     string.Empty,
                                     qtb_user.Banco_Dados).ForEach(p =>
                                             TCN_CadAcesso.GravarAcesso(new TRegistro_CadAcesso()
                                             {
                                                 Altera = p.Altera,
                                                 Exclui = p.Exclui,
                                                 Id_menu = p.Id_menu,
                                                 Inclui = p.Inclui,
                                                 Login = val.Login
                                             }, qtb_user.Banco_Dados));
                //Copiar grupo menu
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_Grupos where loginUSR = '" + val.Login.Trim() + "'", null);
                TCN_CadUsuario_Grupo.Busca(string.Empty,
                                           LoginPerfil,
                                           qtb_user.Banco_Dados).ForEach(p =>
                                               TCN_CadUsuario_Grupo.Gravar(new TRegistro_CadUsuario_Grupo()
                                               {
                                                   LoginGrp = p.LoginGrp,
                                                   LoginUsr = val.Login
                                               }, qtb_user.Banco_Dados));
                //Copiar empresas
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_Empresa where login = '" + val.Login.Trim() + "'", null);
                TCN_CadUsuario_Empresa.Busca(string.Empty,
                                             LoginPerfil,
                                             qtb_user.Banco_Dados).ForEach(p =>
                                                 TCN_CadUsuario_Empresa.Gravar(new TRegistro_CadUsuario_Empresa()
                                                 {
                                                     CD_Empresa = p.CD_Empresa,
                                                     Login = val.Login
                                                 }, qtb_user.Banco_Dados));
                //Copiar terminal
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_Terminal where login = '" + val.Login.Trim() + "'", null);
                TCN_CadUsuarioxTerminal.Busca(string.Empty,
                                              LoginPerfil,
                                              qtb_user.Banco_Dados).ForEach(p =>
                                                  TCN_CadUsuarioxTerminal.Gravar(new TRegistro_CadUsuarioxTerminal()
                                                  {
                                                      Cd_Terminal = p.Cd_Terminal,
                                                      Login = val.Login
                                                  }, qtb_user.Banco_Dados));
                //Copiar tipo pesagem
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_TpPesagem where login = '" + val.Login.Trim() + "'", null);
                TCN_CadUsuario_TipoPesagem.Busca(LoginPerfil,
                                                 string.Empty,
                                                 qtb_user.Banco_Dados).ForEach(p =>
                                                     TCN_CadUsuario_TipoPesagem.Gravar(new TRegistro_CadUsuario_TipoPesagem()
                                                     {
                                                         Login = val.Login,
                                                         Tp_pesagem = p.Tp_pesagem
                                                     }, qtb_user.Banco_Dados));
                //Copiar tipo pedido
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_CFGPedido where login = '" + val.Login.Trim() + "'", null);
                TCN_CadUsuario_CFGPedido.Busca(LoginPerfil,
                                               string.Empty,
                                               string.Empty,
                                               qtb_user.Banco_Dados).ForEach(p =>
                                                   TCN_CadUsuario_CFGPedido.Gravar(new TRegistro_CadUsuario_CFGPedido()
                                                   {
                                                       Cfg_pedido = p.Cfg_pedido,
                                                       Login = val.Login
                                                   }, qtb_user.Banco_Dados));
                //Copiar tipo requisicao
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_TpRequisicao where login = '" + val.Login.Trim() + "'", null);
                TCN_Usuario_TpRequisicao.Buscar(LoginPerfil,
                                                string.Empty,
                                                qtb_user.Banco_Dados).ForEach(p =>
                                                    TCN_Usuario_TpRequisicao.Gravar(new TRegistro_Usuario_TpRequisicao()
                                                    {
                                                        Id_tprequisicao = p.Id_tprequisicao,
                                                        Login = val.Login
                                                    }, qtb_user.Banco_Dados));
                //Copiar tipo duplicata
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_TpDuplicata where login = '" + val.Login.Trim() + "'", null);
                TCN_Usuario_TpDuplicata.Buscar(LoginPerfil,
                                               string.Empty,
                                               qtb_user.Banco_Dados).ForEach(p =>
                                                   TCN_Usuario_TpDuplicata.Gravar(new TRegistro_Usuario_TpDuplicata()
                                                   {
                                                       Login = val.Login,
                                                       Tp_duplicata = p.Tp_duplicata
                                                   }, qtb_user.Banco_Dados));
                //Copiar conta gerencial
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_ContaGer where login = '" + val.Login.Trim() + "'", null);
                TCN_Usuario_ContaGer.Buscar(LoginPerfil,
                                            string.Empty,
                                            qtb_user.Banco_Dados).ForEach(p =>
                                                TCN_Usuario_ContaGer.Gravar(new TRegistro_Usuario_ContaGer()
                                                {
                                                    Cd_contager = p.Cd_contager,
                                                    Login = val.Login
                                                }, qtb_user.Banco_Dados));
                //Copiar regra especial
                if (st_existe)
                    qtb_user.executarSql("delete TB_DIV_Usuario_X_RegraEspecial where login = '" + val.Login.Trim() + "'", null);
                TCN_Usuario_RegraEspecial.Buscar(LoginPerfil,
                                                 string.Empty,
                                                 string.Empty,
                                                 qtb_user.Banco_Dados).ForEach(p =>
                                                     TCN_Usuario_RegraEspecial.Gravar(new TRegistro_Usuario_RegraEspecial()
                                                     {
                                                         Login = val.Login,
                                                         Ds_regra = p.Ds_regra
                                                     }, qtb_user.Banco_Dados));
                if (st_transacao)
                    qtb_user.Banco_Dados.Commit_Tran();
                return st_existe;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_user.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro copiar perfil: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_user.deletarBanco_Dados();
            }
        }

        public static bool ValidarUsuario(string Login,
                                          string Senha)
        {
            bool retorno = false;
            if ((!string.IsNullOrEmpty(Login)) &&
                (!string.IsNullOrEmpty(Senha)))
            {
                if ((Login.Trim().ToUpper().Equals("MASTER") && new BancoDados.TObjetoBanco().ValidarSenhaMaster(Senha)) ||
                    (Login.Trim().ToUpper().Equals("DESENV") && new BancoDados.TObjetoBanco().ValidarSenhaDesenv(Senha)))
                    return true;
                //Verificar se login existe no banco
                if (new TCD_CadUsuario().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "login",
                                        vOperador = "=",
                                        vVL_Busca = "'" + Login.Trim() + "'"
                                    }
                                }, "1") == null)
                    throw new Exception("Usuario <" + Login.Trim() + "> não existe no sistema.");
                //Verificar validade de senha
                if (new TCD_CadUsuario().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "login",
                                vOperador = "=",
                                vVL_Busca = "'" + Login.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "senha",
                                vOperador = "=",
                                vVL_Busca = "'" + Senha.Trim() + "'"
                            }
                        }, "1") == null)
                    throw new Exception("Senha invalida para o usuario <" + Login.Trim() + ">.");
                retorno = true;
            }
            return retorno;
        }
    }
}
