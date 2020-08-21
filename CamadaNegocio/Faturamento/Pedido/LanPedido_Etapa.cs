using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.Pedido;
using Utils;

namespace CamadaNegocio.Faturamento.Pedido
{
    public class TCN_EtapaPedido
    {
        public static TList_EtapaPedido Busca(string Id_etapa,
                                                string Nr_pedido,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            Array.Resize(ref vBusca, vBusca.Length + 1);
            vBusca[vBusca.Length - 1].vNM_Campo = "a.st_registro";
            vBusca[vBusca.Length - 1].vOperador = "<>";
            vBusca[vBusca.Length - 1].vVL_Busca = "'C'";
            if (Id_etapa.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_etapa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_etapa;
            }
            if (Nr_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_pedido";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Nr_pedido;
            }

            return new TCD_EtapaPedido(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_EtapaPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EtapaPedido cd = new TCD_EtapaPedido();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Gravar(val);
                //Excluir Processos
                val.lProcEtapaDel.ForEach(p=> TCN_ProcEtapa.Excluir(p, cd.Banco_Dados));
                //Gravar Processos
                val.lProcEtapa.ForEach(p =>
                    {
                        p.Nr_pedido = val.Nr_pedido;
                        TCN_ProcEtapa.Gravar(p, cd.Banco_Dados);
                    });
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
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

        public static string Excluir(TRegistro_EtapaPedido val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_EtapaPedido cd = new TCD_EtapaPedido();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
            //cd.Excluir(val);
                val.St_registro = "C";
                cd.Gravar(val);

                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }

    public class TCN_ProcEtapa
    {
        public static TList_ProcEtapa Busca(string Id_etapa,
                                                string Nr_pedido,
                                                string Id_processo,
                                                BancoDados.TObjetoBanco banco)
        {
            TpBusca[] vBusca = new TpBusca[0];

            if (Id_etapa.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_etapa";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_etapa;
            }
            if (Nr_pedido.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Nr_pedido";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Nr_pedido;
            }
            if (Id_processo.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.Id_processo";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_processo;
            }

            return new TCD_ProcEtapa(banco).Select(vBusca, 0, string.Empty);
        }

        public static string Gravar(TRegistro_ProcEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcEtapa cd = new TCD_ProcEtapa();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                string retorno = cd.Gravar(val);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar processo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Reabrir(TRegistro_ProcEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcEtapa cd = new TCD_ProcEtapa();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Dt_processostr = string.Empty;
                val.Login = Utils.Parametros.pubLogin;
                string retorno = cd.Gravar(val);
                //Verificar se etapa pode ser finalizada
                cd.executarSql("update TB_FAT_Pedido_Etapa set ST_Registro = 'A', DT_Fin = null, DT_Alt = GETDATE() " +
                                "FROM TB_FAT_Pedido_Etapa a " +
                                "where a.nr_pedido = " + val.Nr_pedidostr + " " +
                                "and a.id_etapa = " + val.Id_etapastr + " " +
                                "and exists(select 1 from TB_FAT_Pedido_ProcEtapa x " +
                                                 "where x.nr_pedido = a.nr_pedido " +
                                                 "and x.id_etapa = a.ID_Etapa " +
                                                 "and x.DT_Processo is null) " +
                    //Verificar se pedido pode ser reaberto
                               "update tb_fat_pedido set ST_Pedido = 'A', ST_Registro = 'A', DT_Alt = GETDATE() " +
                               "FROM TB_FAT_PEDIDO a " +
                               "where a.nr_pedido = " + val.Nr_pedidostr + " " +
                               "and exists(select 1 from TB_FAT_Pedido_Etapa x " +
                                                 "where x.Nr_Pedido = a.Nr_Pedido " +
                                                 "and ISNULL(x.ST_Registro, 'F') <> 'A' " +
                                                 "and isnull(x.ST_Registro, 'A') <> 'C') ", null);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar processo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
        public static string Finalizar(TRegistro_ProcEtapa val, TRegistro_Pedido rPed, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcEtapa cd = new TCD_ProcEtapa();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                val.Dt_processo = CamadaDados.UtilData.Data_Servidor();
                val.Login = Utils.Parametros.pubLogin;
                string retorno = cd.Gravar(val);
                //Verificar se etapa pode ser finalizada
                cd.executarSql("update TB_FAT_Pedido_Etapa set ST_Registro = 'F', DT_Fin = GETDATE(), DT_Alt = GETDATE() " +
                                "FROM TB_FAT_Pedido_Etapa a " +
                                "where a.nr_pedido = " + val.Nr_pedidostr + " " +
                                "and a.id_etapa = " + val.Id_etapastr + " " +
                                "and not exists(select 1 from TB_FAT_Pedido_ProcEtapa x " +
                                                 "where x.nr_pedido = a.nr_pedido " +
                                                 "and x.id_etapa = a.ID_Etapa " +
                                                 "and x.DT_Processo is null) " +
                                //Verificar se pedido pode ser fechado
                               "update tb_fat_pedido set ST_Pedido = 'F', ST_Registro = 'F', DT_Alt = GETDATE() " +
                               "FROM TB_FAT_PEDIDO a " +
                               "where a.nr_pedido = " + val.Nr_pedidostr + " " +
                               "and not exists(select 1 from TB_FAT_Pedido_Etapa x " +
                                                 "where x.Nr_Pedido = a.Nr_Pedido " +
                                                 "and ISNULL(x.ST_Registro, 'A') <> 'F' " +
                                                 "and isnull(x.ST_Registro, 'A') <> 'C') ", null);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar processo: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_ProcEtapa val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_ProcEtapa cd = new TCD_ProcEtapa();
            try
            {
                if (banco == null)
                    st_transacao = cd.CriarBanco_Dados(true);
                else
                    cd.Banco_Dados = banco;
                cd.Excluir(val);
                //Verificar se etapa pode ser finalizada
                cd.executarSql("update TB_FAT_Pedido_Etapa set ST_Registro = 'F', DT_Fin = GETDATE(), DT_Alt = GETDATE() " +
                                "FROM TB_FAT_Pedido_Etapa a " +
                                "where a.nr_pedido = " + val.Nr_pedidostr + " " +
                                "and a.id_etapa = " + val.Id_etapastr + " " +
                                "and not exists(select 1 from TB_FAT_Pedido_ProcEtapa x " +
                                                 "where x.nr_pedido = a.nr_pedido " +
                                                 "and x.id_etapa = a.ID_Etapa " +
                                                 "and x.DT_Processo is null) " +
                    //Verificar se pedido pode ser fechado
                               "update tb_fat_pedido set ST_Pedido = 'F', ST_Registro = 'F', DT_Alt = GETDATE() " +
                               "FROM TB_FAT_PEDIDO a " +
                               "where a.nr_pedido = " + val.Nr_pedidostr + " " +
                               "and not exists(select 1 from TB_FAT_Pedido_Etapa x " +
                                                 "where x.Nr_Pedido = a.Nr_Pedido " +
                                                 "and ISNULL(x.ST_Registro, 'A') <> 'F' " +
                                                 "and isnull(x.ST_Registro, 'A') <> 'C') ", null);
                if (st_transacao)
                    cd.Banco_Dados.Commit_Tran();


                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    cd.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (st_transacao)
                    cd.deletarBanco_Dados();
            }
        }
    }
}
