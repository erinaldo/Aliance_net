using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using CamadaDados.Faturamento.NFCe;

namespace CamadaNegocio.Faturamento.NFCe
{
    public class TCN_Lote_X_NFCe
    {
        public static TList_Lote_X_NFCe Buscar(string Cd_empresa,
                                               string Id_lote,
                                               string Id_cupom,
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
            if (!string.IsNullOrEmpty(Id_lote))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_lote";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_lote;
            }
            if (!string.IsNullOrEmpty(Id_cupom))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_cupom";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_cupom;
            }
            return new TCD_Lote_X_NFCe(banco).Select(filtro, 0, string.Empty);
        }

        public static string Gravar(TRegistro_Lote_X_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_NFCe qtb_lote = new TCD_Lote_X_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
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

        public static string Excluir(TRegistro_Lote_X_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_NFCe qtb_lote = new TCD_Lote_X_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_lote.CriarBanco_Dados(true);
                else qtb_lote.Banco_Dados = banco;
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

        public static void ReabrirNFCeProcessar(TRegistro_Lote_X_NFCe val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_NFCe qtb_nfce = new TCD_Lote_X_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nfce.CriarBanco_Dados(true);
                else
                    qtb_nfce.Banco_Dados = banco;
                qtb_nfce.executarSql("delete tb_pdv_xml_nfce " +
                                     "where cd_empresa = '" + val.Cd_empresa.Trim()  + "' and id_nfce = " + val.Id_cupomstr  + "\r\n" +
                                     "delete tb_fat_lote_x_nfce where cd_empresa = '" + val.Cd_empresa.Trim() + "' and id_lote = " + val.Id_lotestr + " and id_cupom = " + val.Id_cupomstr + "\r\n" +
                                     "if not exists(select 1 from tb_fat_lote_x_nfce x where x.id_lote = " + val.Id_lotestr + ")\r\n" +
                                     "delete tb_fat_lotenfce where id_lote = " + val.Id_lotestr, null);
                if (st_transacao)
                    qtb_nfce.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nfce.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro reabrir NFC-e processar: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nfce.deletarBanco_Dados();
            }
        }

        public static void AtualizarDadosNFCe(string Cd_empresa,
                                              string Id_lote,
                                              string Id_cupom,
                                              string cStat,
                                              string xMotivo,
                                              string dhRecbto,
                                              string nProt,
                                              string digVal,
                                              string verAplic,
                                              BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_Lote_X_NFCe qtb_nfce = new TCD_Lote_X_NFCe();
            try
            {
                if (banco == null)
                    st_transacao = qtb_nfce.CriarBanco_Dados(true);
                else qtb_nfce.Banco_Dados = banco;
                System.Collections.Hashtable hs = new System.Collections.Hashtable();
                hs.Add("@P_EMPRESA", Cd_empresa);
                hs.Add("@P_LOTE", Id_lote);
                hs.Add("@P_ID_CUPOM", Id_cupom);
                hs.Add("@P_DT_PROC", DateTime.Parse(dhRecbto));
                hs.Add("@P_STAT", cStat);
                hs.Add("@P_MOTIVO", xMotivo);
                hs.Add("@P_NPROT", nProt);
                hs.Add("@P_DIGVAL", digVal);
                hs.Add("@P_VERAPLIC", verAplic);

                qtb_nfce.executarSql("update tb_fat_lotenfce set status = 104, ds_mensagem = 'Lote processado', st_registro = 'P', DT_Recebimento = @P_DT_PROC, dt_alt = getdate() " +
                                     "where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE\r\n" +
                                     "update tb_fat_lote_x_nfce set status = @P_STAT, ds_mensagem = @P_MOTIVO, " +
                                     "dt_processamento = @P_DT_PROC, nr_protocolo = @P_NPROT, digval = @P_DIGVAL, veraplic = @P_VERAPLIC, " +
                                     "dt_alt = getdate() where cd_empresa = @P_EMPRESA and id_lote = @P_LOTE and id_cupom = @P_ID_CUPOM\r\n" +
                                     "if exists(select 1 from tb_pdv_nfce where cd_empresa = @P_EMPRESA and id_nfce = @P_ID_CUPOM and id_contingencia is null)\r\n" +
                                     "update tb_pdv_nfce set dt_emissao = @P_DT_PROC, DT_ALT = getdate() where cd_empresa = @P_EMPRESA and id_nfce = @P_ID_CUPOM", hs);
                if (st_transacao)
                    qtb_nfce.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_nfce.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro atualizar dados NFC-e: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_nfce.deletarBanco_Dados();
            }
        }
    }
}
