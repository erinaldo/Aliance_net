using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Diversos;

namespace CamadaNegocio.Diversos
{
    public class TCN_CadTerminal
    {

        public static TList_CadTerminal Busca(string vCd_Terminal, 
                                              string vDs_Terminal,
                                              BancoDados.TObjetoBanco banco)
        {

            TpBusca[] vBusca = new TpBusca[0];
            if (!string.IsNullOrEmpty(vCd_Terminal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Cd_Terminal";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vCd_Terminal.Trim() + "'";

            }
            if (!string.IsNullOrEmpty(vDs_Terminal))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Ds_Terminal";
                vBusca[vBusca.Length - 1].vOperador = "like";
                vBusca[vBusca.Length - 1].vVL_Busca = "('%" + vDs_Terminal.Trim() + "%')";

            }

            return new TCD_CadTerminal(banco).Select(vBusca, 0, "");

        }
        public static string Grava_CadTerminal(TRegistro_CadTerminal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTerminal cd = new TCD_CadTerminal();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Grava(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar terminal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Deleta_CadTerminal(TRegistro_CadTerminal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_CadTerminal cd = new TCD_CadTerminal();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Deleta(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir terminal: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string ValidaTerminal(string Login)
        {
            //Buscar serie do HD
            string serial_hd = Utils.Estruturas.GetSerialHd();
            //Verificar se existe terminal com esta serie
            object cd_terminal = new TCD_CadTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.nr_serial",
                                            vOperador = "=",
                                            vVL_Busca = "'" + serial_hd.Trim() + "'"
                                        }
                                    }, "a.cd_terminal");
            if (cd_terminal == null)
                throw new Exception("Não existe terminal cadastrado no sistema para a serial: " + serial_hd.Trim());
            //Verificar se o usuario tem acesso a este terminal
            object obj_acesso = new TCD_CadUsuarioxTerminal().BuscarEscalar(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.login",
                                            vOperador = "=",
                                            vVL_Busca = "'" + Login.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_terminal",
                                            vOperador = "=",
                                            vVL_Busca = "'" + cd_terminal.ToString().Trim() + "'"
                                        }
                                    }, "1");
            if (obj_acesso == null)
                throw new Exception("Usuario não tem permissão para utilizar o terminal " + cd_terminal.ToString().Trim() + " que esta configurado para a serial " + serial_hd.Trim());
            //Validar chave de acesso para o terminal
            string chave_acesso = Utils.Estruturas.CalcChaveAcesso(serial_hd);
            object chave = new TCD_CadTerminal().BuscarEscalar(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_terminal",
                                        vOperador = "=",
                                        vVL_Busca = "'" + cd_terminal.ToString().Trim() + "'"
                                    }
                                }, "a.chave_acesso");
            if (chave == null)
                throw new Exception("Terminal sem chave de acesso configurada.\r\nNão é permitido logar com este terminal.");
            if (chave.ToString().Trim().ToUpper() != chave_acesso.Trim().ToUpper())
                throw new Exception("Chave de acesso do terminal " + cd_terminal.ToString().Trim() + " é invalida.\r\n" +
                                    "Entre em contato com o suporte para calcular nova chave.");
            return cd_terminal.ToString();
        }
    }
}
