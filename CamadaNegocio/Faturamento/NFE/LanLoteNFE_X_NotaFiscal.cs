using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Faturamento.NFE;

namespace CamadaNegocio.Faturamento.NFE
{
    public class TCN_LanLoteNFE_X_NotaFiscal
    {
        public static TList_LanLoteNFE_X_NotaFiscal Buscar(string id_lote,
                                                           string cd_empresa,
                                                           string nr_lanctofiscal,
                                                           string Status,
                                                           BancoDados.TObjetoBanco banco)
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if (!string.IsNullOrEmpty(id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = id_lote;
            }
            if (!string.IsNullOrEmpty(cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(nr_lanctofiscal))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_lanctofiscal";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = nr_lanctofiscal;
            }
            if (!string.IsNullOrEmpty(Status))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.status";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Status;
            }

            return new TCD_LanLoteNFE_X_NotaFiscal().Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_LanLoteNFE_X_NotaFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteNFE_X_NotaFiscal qtb_lote = new TCD_LanLoteNFE_X_NotaFiscal();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                string retorno = qtb_lote.Gravar(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static string Excluir(TRegistro_LanLoteNFE_X_NotaFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteNFE_X_NotaFiscal qtb_lote = new TCD_LanLoteNFE_X_NotaFiscal();
            try
            {
                if (st_transacao)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else
                    qtb_lote.Banco_Dados = banco;
                qtb_lote.Excluir(val);
                if (st_transacao)
                    qtb_lote.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_lote.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro excluir registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_lote.deletarBanco_Dados();
            }
        }

        public static void ReabrirNfeProcessar(TRegistro_LanLoteNFE_X_NotaFiscal val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteNFE_X_NotaFiscal qtb_nfe = new TCD_LanLoteNFE_X_NotaFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nfe.CriarBanco_Dados(true);
                else
                    qtb_nfe.Banco_Dados = banco;
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@P_EMPRESA", val.Cd_empresa);
                hs.Add("@P_LANCTO", val.Nr_lanctofiscal);
                qtb_nfe.executarSql("update tb_fat_notafiscal set chave_acesso_nfe = null, xml_nfe = null, dt_alt = getdate() " +
                                    "where cd_empresa = @P_EMPRESA and nr_lanctofiscal = @P_LANCTO", hs);
                qtb_nfe.Excluir(val);
                //Verificar se existe mais alguma nota amarrada ao lote
                object obj = qtb_nfe.BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.id_lote",
                                        vOperador = "=",
                                        vVL_Busca = val.Id_lote.ToString()
                                    }
                                }, "1");
                if (obj == null)
                    TCN_LanLoteNFE.Excluir(new TRegistro_LanLoteNFE()
                    {
                        Id_lote = val.Id_lote
                    }, qtb_nfe.Banco_Dados);
                if (st_transacao)
                    qtb_nfe.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reabrir NF-e processar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nfe.deletarBanco_Dados();
            }
        }

        public static void AtualizarDadosNFe(string Cd_empresa,
                                             string Id_lote,
                                             string Nr_lanctofiscal,
                                             string cStat,
                                             string xMotivo,
                                             string dhRecbto,
                                             string nProt,
                                             string digVal,
                                             string verAplic,
                                             BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanLoteNFE_X_NotaFiscal qtb_nfe = new TCD_LanLoteNFE_X_NotaFiscal();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nfe.CriarBanco_Dados(true);
                else qtb_nfe.Banco_Dados = banco;
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@P_EMPRESA", Cd_empresa);
                hs.Add("@P_LOTE", Id_lote);
                hs.Add("@P_LANCTOFISCAL", Nr_lanctofiscal);
                hs.Add("@P_DT_PROC", DateTime.Parse(dhRecbto));
                hs.Add("@P_STAT", cStat);
                hs.Add("@P_MOTIVO", xMotivo);
                hs.Add("@P_NPROT", nProt);
                hs.Add("@P_DIGVAL", digVal);
                hs.Add("@P_VERAPLIC", verAplic);

                qtb_nfe.executarSql("update tb_fat_lotenfe set status = 104, ds_mensagem = 'Lote processado', st_registro = 'P', DT_Recebimento = @P_DT_PROC, dt_alt = getdate() " +
                                     "where id_lote = @P_LOTE\r\n" +
                                     "update tb_fat_lotenfe_x_notafiscal set status = @P_STAT, ds_mensagem = @P_MOTIVO, " +
                                     "dt_processamento = @P_DT_PROC, nr_protocolo = @P_NPROT, digitoverificado = @P_DIGVAL, veraplic = @P_VERAPLIC, " +
                                     "dt_alt = getdate() where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE and nr_lanctofiscal = @P_LANCTOFISCAL", hs);
                if (st_transacao)
                    qtb_nfe.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nfe.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro atualizar dados NF-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nfe.deletarBanco_Dados();
            }
        }
    }
}
