using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadaDados.Fazenda.Lancamento;
using Utils;
using BancoDados;
using CamadaDados.Financeiro.CCustoLan;
using CamadaNegocio.Financeiro.CCustoLan;

namespace CamadaNegocio.Fazenda.Lancamento
{
    public class TCN_LanAtividade
    {
        public static TList_LanAtividade Busca (string vCD_Empresa,
                                                string vCD_Fazenda,
                                                string vCD_Talhao,
                                                string Id_atividade,
                                                string vAnoSafra,
                                                string Cd_produto,
                                                string vDT_Inicial,
                                                string vDT_Final,
                                                BancoDados.TObjetoBanco banco
            )
        {

            TpBusca[] vBusca = new TpBusca[0];

           if (vCD_Empresa.Trim() != string.Empty)
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
               vBusca[vBusca.Length - 1].vOperador = "exists";
               vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_faz_fazenda x " +
                                                     "where a.cd_fazenda = x.cd_fazenda " +
                                                     "and x.cd_empresa = '" + vCD_Empresa.Trim() + "')";
           }else
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
               vBusca[vBusca.Length - 1].vOperador = "EXISTS";
               vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x where x.cd_empresa = b.cd_empresa " +
                                                      "and x.login = 'MASTER' or  exists " +
                                                      "(select 1 from tb_div_usuario_x_grupos y " +
                                                      "where y.logingrp = x.login and y.loginusr = 'MASTER')) ";
            
           }
            

            if (vCD_Fazenda.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Fazenda";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Fazenda.Trim();
            }
            if (vCD_Talhao.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Talhao";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Talhao.Trim();
            }
            if (vAnoSafra.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.AnoSafra";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = "'" + vAnoSafra.Trim() + "'";
            }
            if (Id_atividade.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.id_atividade";
                vBusca[vBusca.Length - 1].vOperador = "=";
                vBusca[vBusca.Length - 1].vVL_Busca = Id_atividade;
            }
            if (Cd_produto.Trim() != string.Empty)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_faz_lanatividade_item x " +
                                                      "where x.id_lanctoativ = a.id_lanctoativ " +
                                                      "and x.cd_produto = '" + Cd_produto.Trim() + "')";
            }

            if ((vDT_Inicial != "") && (vDT_Inicial.Trim()!="/  /") )

               {
                    Array.Resize(ref vBusca, vBusca.Length + 1);
                    vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                    vBusca[vBusca.Length - 1].vOperador = "exists";
                    vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_faz_lanatividade_item x " +
                                                          "where x.id_lanctoativ = a.id_lanctoativ " +
                                                          "and x.dt_custo >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Inicial).ToString("yyyyMMdd")) + " 00:00:00'";
                }

            if ((vDT_Final != "") && (vDT_Final.Trim()!="/  /"))
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = string.Empty;
                vBusca[vBusca.Length - 1].vOperador = "exists";
                vBusca[vBusca.Length - 1].vVL_Busca = "(select 1 from tb_faz_lanatividade_item x " +
                                                          "where x.id_lanctoativ = a.id_lanctoativ " +
                                                          "and x.dt_custo <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(vDT_Final).ToString("yyyyMMdd")) + " 23:59:59'";
            }

            return new TCD_LanAtividade(banco).Select(vBusca, 0, string.Empty);
        }

        public static string GravaLanAtividade(TRegistro_LanAtividade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAtividade qtb_ativ = new TCD_LanAtividade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ativ.CriarBanco_Dados(true);
                else
                    qtb_ativ.Banco_Dados = banco;
                //Gravar lanatividade
                string retorno = qtb_ativ.GravaLanAtividade(val);
                //Pegando o codigo que foi criado lanatividade
                val.Id_lanctoativ = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_LANCTOATIV"));
                //Gravar itens da atividade
                val.Litens.ForEach(p =>
                    {
                        p.Id_lanctoativ = val.Id_lanctoativ;
                        TCN_LanAtividade_Item.GravaLanAtividadeItem(p, qtb_ativ.Banco_Dados);
                    });
                //Deletar itens da lista para deletar
                val.LitensDel.ForEach(p => TCN_LanAtividade_Item.DeletaLanAtividadeItem(p, qtb_ativ.Banco_Dados));
                if (st_transacao)
                    qtb_ativ.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ativ.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ativ.deletarBanco_Dados();
            }
        }

        public static string DeletaLanAtividade(TRegistro_LanAtividade val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanAtividade qtb_ativ = new TCD_LanAtividade();
            try
            {
                if (banco == null)
                    st_transacao = qtb_ativ.CriarBanco_Dados(true);
                else
                    qtb_ativ.Banco_Dados = banco;
                //Deletar itens
                val.Litens.ForEach(p => TCN_LanAtividade_Item.DeletaLanAtividadeItem(p, qtb_ativ.Banco_Dados));
                //Deletar itens lista del
                val.LitensDel.ForEach(p => TCN_LanAtividade_Item.DeletaLanAtividadeItem(p, qtb_ativ.Banco_Dados));
                //Deletar atividade
                qtb_ativ.DeletaLanAtividade(val);
                if (st_transacao)
                    qtb_ativ.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_ativ.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_ativ.deletarBanco_Dados();
            }
        }
    }
}
