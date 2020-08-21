using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados.Graos;
using CamadaDados.Estoque;
using System.Data;

namespace CamadaNegocio.Graos
{
    public class TCN_LanPesagemGMO
    {
        public static TList_LanPesagemGMO Buscar(string Id_lanctoGMO,
                                                 string Cd_empresa,
                                                 string Id_ticket,
                                                 string Tp_pesagem,
                                                 TObjetoBanco banco)
        {
            TpBusca[] filtro = new TpBusca[0];

            if (!string.IsNullOrEmpty(Id_lanctoGMO))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_LanctoGMO";
                filtro[filtro.Length - 1].vVL_Busca = Id_lanctoGMO;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Id_ticket))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ID_Ticket";
                filtro[filtro.Length - 1].vVL_Busca = Id_ticket;
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.CD_Empresa";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            if (!string.IsNullOrEmpty(Tp_pesagem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.TP_Pesagem";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Tp_pesagem.Trim() + "'";
                filtro[filtro.Length - 1].vOperador = "=";
            }

            return new TCD_LanPesagemGMO(banco).Select(filtro, 0, string.Empty);
        }

        public static CamadaDados.Balanca.TList_RegLanPesagemGraos BuscarPesagem(string Id_lanctoGMO,
                                                                                 BancoDados.TObjetoBanco banco)
        {
            return new CamadaDados.Balanca.TCD_LanPesagemGraos(banco).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_gro_pesagemGMO x " + 
                                        "where x.cd_empresa = a.cd_empresa " + 
                                        "and x.id_ticket = a.id_ticket " +
                                        "and x.tp_pesagem = a.tp_pesagem " +
                                        "and x.id_lanctoGMO = " + Id_lanctoGMO + ")"
                        }
                    }, string.Empty, string.Empty, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanPesagemGMO vPesagemGMO, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPesagemGMO qtb_LanPesagemGMO = new TCD_LanPesagemGMO();
            try
            {
                if (banco == null)
                    st_transacao = qtb_LanPesagemGMO.CriarBanco_Dados(true);
                else
                    qtb_LanPesagemGMO.Banco_Dados = banco;
                string r_LanPesagemGMO = qtb_LanPesagemGMO.Grava(vPesagemGMO);
                if (st_transacao)
                    qtb_LanPesagemGMO.Banco_Dados.Commit_Tran();
                return r_LanPesagemGMO;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_LanPesagemGMO.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar pesagem GMO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_LanPesagemGMO.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanPesagemGMO val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanPesagemGMO Qtb_LanPesagemGMO = new TCD_LanPesagemGMO();
            try
            {
                if (banco == null)
                    st_transacao = Qtb_LanPesagemGMO.CriarBanco_Dados(true);
                else
                    Qtb_LanPesagemGMO.Banco_Dados = banco;
                Qtb_LanPesagemGMO.Deleta(val);
                if (st_transacao)
                    Qtb_LanPesagemGMO.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    Qtb_LanPesagemGMO.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir pesagem GMO: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    Qtb_LanPesagemGMO.deletarBanco_Dados();
            }
        }
    }
}
