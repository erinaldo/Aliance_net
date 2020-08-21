using System;
using System.Collections.Generic;
using System.Linq;
using Utils;
using BancoDados;
using CamadaDados.Servicos;
using CamadaDados.Servicos.Cadastros;
using CamadaNegocio.Servicos.Cadastros;
using CamadaNegocio.Faturamento.Pedido;
using CamadaDados.Faturamento.Pedido;
using System.Data;

namespace CamadaNegocio.Servicos
{
    public class TCN_LanServico
    {
        public static TList_LanServico Buscar(string Nr_serial,
                                              string Cd_empresa,
                                              string Cd_clifor,
                                              string Nm_clifor,
                                              string Cd_produtoOS,
                                              string Nr_patrimonio,
                                              string Placaveiculo,
                                              string Id_os,
                                              string Ds_servico,
                                              string Nr_osorigem,
                                              string Id_tecnico,
                                              string Id_etapaatual,
                                              string Id_etapa,
                                              string Cd_fornecedor,
                                              string Tp_data,
                                              string Dt_ini,
                                              string Dt_fin,
                                              string St_os,
                                              string St_prioridade,
                                              bool St_EquipamentoComNf,
                                              string Nr_pedidoremessa,
                                              string Nr_pedidolote,
                                              string Nr_pedidointegra,
                                              bool St_loteaberto,
                                              bool St_loteprocessado,
                                              bool St_expirada,
                                              bool St_retirar,
                                              bool St_buscarDetalhes,
                                              int vTop,
                                              string vNm_campo,
                                              string vOrder,
                                              TObjetoBanco banco,
                                              string Tp_Ordem = "")
        {
            TpBusca[] filtro = new TpBusca[0];
            if (!string.IsNullOrEmpty(Nr_serial))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_serial";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_serial.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_empresa))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_empresa";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Cd_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_clifor.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nm_clifor))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nm_clifor";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Nm_clifor.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Cd_produtoOS))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.cd_produtoos";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Cd_produtoOS.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Nr_patrimonio))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_est_patrimonio x " +
                                                      "where a.CD_ProdutoOS = x.CD_Patrimonio " +
                                                      "and x.nr_patrimonio = '" + Nr_patrimonio.Trim() + "')";
            }
            if (!string.IsNullOrEmpty(Placaveiculo))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.placaveiculo";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Placaveiculo.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_os))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.id_os";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + Id_os + ")";
            }
            if (!string.IsNullOrEmpty(Ds_servico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_servico";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "'%" + Ds_servico.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(Nr_osorigem))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_osorigem";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + Nr_osorigem.Trim() + "'";
            }
            if (!string.IsNullOrEmpty(Id_tecnico))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_pecas x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_os = a.id_os " +
                                                      "and x.cd_tecnico = '" + Id_tecnico + "') or " +
                                                      "(exists(SELECT 1 FROM TB_OSE_Atividades y " +
                                                      "where y.CD_Empresa = a.CD_Empresa " +
                                                      "and y.ID_OS = a.ID_OS " +
                                                      "and y.cd_tecnico = '" + Id_tecnico + "'))";
            }
            if (Id_etapaatual.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "(select top 1 x.ID_Etapa from TB_OSE_Evolucao x " +
                                                      "where x.CD_Empresa = a.CD_Empresa " +
                                                      "and x.ID_OS = a.ID_OS " +
                                                      "order by x.DT_Inicio desc)";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Id_etapaatual;
            }
            if (Id_etapa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                                      "where a.id_os = x.id_os " +
                                                      "and a.cd_empresa = x.cd_empresa " +
                                                      "and x.id_etapa = '" + Id_etapa.Trim() + "')";
            }
            if (Cd_fornecedor.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                                      "inner join tb_ose_lote y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_lote = y.id_lote " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_os = a.id_os " +
                                                      "and y.cd_fornecedor = '" + Cd_fornecedor.Trim() + "')";
            }
            if ((Dt_ini.Trim() != string.Empty) && (Dt_ini.Trim() != "/  /"))
            {
                if (Tp_data.Trim().ToUpper().Equals("F"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                                          "inner join tb_ose_etapaordem y " +
                                                          "on x.id_etapa = y.id_etapa " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and x.id_os = a.id_os " +
                                                          "and isnull(y.st_finalizarOS, 'N') = 'S' " +
                                                          "and x.dt_final >= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00')";
                }
                else
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("P") ? "a.dt_encerramento" : Tp_data.Trim().ToUpper().Equals("D") ? "a.dt_devolucao" : "a.dt_abertura";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_ini).ToString("yyyyMMdd")) + " 00:00:00'";
                }
            }
            if ((Dt_fin.Trim() != string.Empty) && (Dt_fin.Trim() != "/  /"))
            {
                if (Tp_data.Trim().ToUpper().Equals("F"))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_evolucao x " +
                                                          "inner join tb_ose_etapaordem y " +
                                                          "on x.id_etapa = y.id_etapa " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and x.id_os = a.id_os " +
                                                          "and isnull(y.st_finalizarOS, 'N') = 'S' " +
                                                          "and x.dt_final <= '" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59')";
                }
                else
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = Tp_data.Trim().ToUpper().Equals("P") ? "a.dt_encerramento" : Tp_data.Trim().ToUpper().Equals("D") ? "a.dt_devolucao" : "a.dt_abertura";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + string.Format(new System.Globalization.CultureInfo("en-US", true), Convert.ToDateTime(Dt_fin).ToString("yyyyMMdd")) + " 23:59:59'";
                }
            }
            if (St_os.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_os";
                filtro[filtro.Length - 1].vOperador = "in";
                filtro[filtro.Length - 1].vVL_Busca = "(" + St_os.Trim() + ")";
            }
            if (St_prioridade.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_prioridade";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + St_prioridade.Trim() + "'";
            }
            if (St_EquipamentoComNf)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.st_equipamentocomnf";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = "'S'";
            }
            if (Nr_pedidoremessa.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_servico_x_pedidoitem x " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_os = a.id_os " +
                                                      "and x.nr_pedido = " + Nr_pedidoremessa.Trim() + " " +
                                                      "and x.tp_pedido = 'RM')";
            }
            if (Nr_pedidolote.Trim() != string.Empty)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                                      "inner join tb_ose_lote y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_lote = y.id_lote " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_os = a.id_os " +
                                                      "and y.nr_pedido = " + Nr_pedidolote.Trim() + ")";
            }
            if (!string.IsNullOrEmpty(Nr_pedidointegra))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.nr_pedidointegra";
                filtro[filtro.Length - 1].vOperador = "=";
                filtro[filtro.Length - 1].vVL_Busca = Nr_pedidointegra.Trim();
            }
            if (St_loteaberto || St_loteprocessado)
            {
                string st_lote = string.Empty;
                string virg = string.Empty;
                if (St_loteaberto)
                {
                    st_lote = "'A'";
                    virg = ",";
                }
                if (St_loteprocessado)
                    st_lote += virg + "'P'";
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = "exists";
                filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                                      "inner join tb_ose_lote y " +
                                                      "on x.cd_empresa = y.cd_empresa " +
                                                      "and x.id_lote = y.id_lote " +
                                                      "where x.cd_empresa = a.cd_empresa " +
                                                      "and x.id_os = a.id_os " +
                                                      "and isnull(y.st_registro, 'A') in (" + st_lote.Trim() + "))";
            }
            if (St_expirada)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(isnull(a.st_os, 'AB') = 'AB') and (isnull(a.dt_previsao, getdate()) < getdate())";
            }
            if (St_retirar)
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                filtro[filtro.Length - 1].vOperador = string.Empty;
                filtro[filtro.Length - 1].vVL_Busca = "(isnull(a.st_os, 'FE') = 'FE') and ((DATEADD(day, a.dias_retirar, a.dt_finalizada)) < getdate())";
            }
            if (!string.IsNullOrEmpty(Tp_Ordem))
                Estruturas.CriarParametro(ref filtro, "a.Tp_Ordem", "'" + Tp_Ordem + "'");

            TList_LanServico lOS = new TCD_LanServico(banco).Select(filtro, vTop, vNm_campo, vOrder);
            if (St_buscarDetalhes)
                lOS.ForEach(p =>
                    {
                        //Buscar acessorios
                        p.lAcessorios = TCN_Acessorios.Buscar(p.Id_osstr,
                                                              p.Cd_empresa,
                                                              string.Empty,
                                                              string.Empty,
                                                              0,
                                                              string.Empty,
                                                              banco);
                        //Buscar pecas
                        p.lPecas = TCN_LanServicoPecas.Buscar(p.Id_osstr,
                                                              p.Cd_empresa,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              decimal.Zero,
                                                              decimal.Zero,
                                                              decimal.Zero,
                                                              decimal.Zero,
                                                              decimal.Zero,
                                                              string.Empty,
                                                              string.Empty,
                                                              false,
                                                              0,
                                                              banco);
                        //Historico
                        p.lHistorico = TCN_Historico.Buscar(p.Id_osstr,
                                                            p.Cd_empresa,
                                                            string.Empty,
                                                            string.Empty,
                                                            banco);
                        //Evolucao
                        p.lEvolucao = TCN_LanServicoEvolucao.Buscar(p.Id_osstr,
                                                                    p.Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    false,
                                                                    0,
                                                                    banco);
                        //Fotos
                        p.lImagens = TCN_Imagens.Buscar(p.Id_osstr,
                                                        p.Cd_empresa,
                                                        banco);
                    });
            return lOS;
        }

        public static string Gravar(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_servico = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                //Se veiculo nao tiver cadastrado, cadastrar.
                if (!string.IsNullOrEmpty(val.Placaveiculo))
                    if (new TCD_VeiculoCliente(qtb_servico.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_clifor",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Cd_clifor.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.placaveiculo",
                                vOperador = "=",
                                vVL_Busca = "'" + val.Placaveiculo.Trim() + "'"
                            }
                        }, "1") == null)
                        TCN_VeiculoCliente.Gravar(new TRegistro_VeiculoCliente()
                        {
                            Cd_clifor = val.Cd_clifor,
                            Ds_marca = val.Ds_marca,
                            Ds_observacao = val.Ds_obsVeiculo,
                            Ds_veiculo = val.Ds_veiculo,
                            Placaveiculo = val.Placaveiculo
                        }, qtb_servico.Banco_Dados);
                //Gravar ordem servico
                string retorno = qtb_servico.Gravar(val);
                val.Id_os = Convert.ToDecimal(CamadaDados.TDataQuery.getPubVariavel(retorno, "@P_ID_OS"));

                //Deletar Acessorios OS
                val.lAcessoriosDel.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_os = val.Id_os;
                        TCN_Acessorios.DeletarAcessorios(p, qtb_servico.Banco_Dados);
                    });
                //Gravar Acessorios OS
                val.lAcessorios.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_os = val.Id_os;
                        TCN_Acessorios.GravarAcessorios(p, qtb_servico.Banco_Dados);
                    });
                //Deletar evolucao OS
                val.lEvolucaoDel.ForEach(p => TCN_LanServicoEvolucao.Excluir(p, qtb_servico.Banco_Dados));
                //Gravar evolucao OS
                val.lEvolucao.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_os = val.Id_os;
                        TCN_LanServicoEvolucao.Gravar(p, qtb_servico.Banco_Dados);
                        if (p.St_envterceiro)
                        {
                            //Buscar Almoxarifado
                            CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox =
                                new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(qtb_servico.Banco_Dados).Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                        "where x.id_almox = a.id_almox " +
                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                                        }
                                    }, 0, string.Empty);
                            if (lAlmox.Count.Equals(decimal.Zero))
                                throw new Exception("Não existe almoxarifado cadastrado para empresa " + val.Cd_empresa.Trim());
                            val.lPecas.Where(x => x.St_servicobool.Equals(false)).ToList().ForEach(x =>
                             {
                                 //Verificar se produto já teve saida
                                 if (new CamadaDados.Servicos.TCD_LanPecasEnvTerceiro(qtb_servico.Banco_Dados).BuscarEscalar(
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
                                            vNM_Campo = "a.id_os",
                                            vOperador = "=",
                                            vVL_Busca = val.Id_osstr
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + x.Cd_produto.Trim() + "'"
                                        },
                                      }, "1") == null)
                                 {
                                     CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();
                                     //Buscar Saldo Almoxarifado
                                     decimal saldo = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(val.Cd_empresa,
                                                                                                                               lAlmox[0].Id_almoxString,
                                                                                                                               x.Cd_produto,
                                                                                                                               qtb_servico.Banco_Dados);
                                     if (saldo < x.Quantidade)
                                         throw new Exception("Não existe saldo suficiente para gravar movimentação.\r\n" +
                                              "Item: " + x.Cd_produto.Trim() + "-" + x.Ds_produto + "\r\n" +
                                              "Saldo Atual: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                                              "Qtde Requerida: " + x.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")));


                                     //Buscar Vl.Custo Almoxarifado
                                     rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa,
                                                                                                                               lAlmox[0].Id_almoxString,
                                                                                                                               x.Cd_produto,
                                                                                                                               qtb_servico.Banco_Dados);
                                     rMov.Id_almoxstr = lAlmox[0].Id_almoxString;
                                     rMov.Quantidade = x.Quantidade;
                                     rMov.Vl_subtotal = rMov.Quantidade * rMov.Vl_unitario;
                                     rMov.Ds_observacao = "PRODUTO RETIRADO PARA ENVIO DE PEÇAS PARA TERCEIROS";
                                     rMov.Cd_empresa = val.Cd_empresa;
                                     rMov.Tp_movimento = "S";
                                     rMov.Cd_produto = x.Cd_produto;
                                     rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                                     rMov.St_registro = "A";
                                     rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                                     //Gravar Almoxarifado
                                     CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_servico.Banco_Dados);
                                     //Gravar Pecas Envio Terceiro
                                     CamadaNegocio.Servicos.TCN_LanPecasEnvTerceiro.Gravar(
                                          new TRegistro_LanPecasEnvTerceiro()
                                          {
                                              Id_os = val.Id_os,
                                              Cd_empresa = val.Cd_empresa,
                                              Id_evolucao = p.Id_evolucao,
                                              Cd_produto = x.Cd_produto,
                                              Quantidade = x.Quantidade,
                                              Id_MovAmxS = rMov.Id_movimento
                                          }, qtb_servico.Banco_Dados);
                                 }
                             });
                        }
                    });
                //Deletar Pecas/Servicos OS
                val.Deleta_lPecas.Where(p => p.Id_peca.HasValue).ToList().ForEach(p =>
                     {
                         p.Cd_empresa = val.Cd_empresa;
                         p.Id_os = val.Id_os;
                         //p.Id_evolucao = val.lEvolucao.
                         TCN_LanServicoPecas.Excluir(p, qtb_servico.Banco_Dados);
                     });
                //Gravar Pecas OS
                decimal? id_evolucao = null;
                if (val.lEvolucao.Count > 0)
                    if (val.lEvolucao.OrderByDescending(p => p.Dt_inicio).First() != null)
                        id_evolucao = val.lEvolucao.OrderByDescending(p => p.Dt_inicio).First().Id_evolucao;
                val.lPecas.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_os = val.Id_os;
                        p.Id_evolucao = p.Id_evolucao.HasValue ? p.Id_evolucao : id_evolucao;
                        TCN_LanServicoPecas.Gravar(p, qtb_servico.Banco_Dados);
                    });
                //Deletar Pecas/Servicos OS
                val.Deleta_lServico.Where(p => p.Id_peca.HasValue).ToList().ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_os = val.Id_os;
                    //p.Id_evolucao = val.lEvolucao.
                    TCN_LanServicoPecas.Excluir(p, qtb_servico.Banco_Dados);
                });
                //Gravar Servicos OS
                decimal? ID_evolucao = null;
                if (val.lEvolucao.Count > 0)
                    if (val.lEvolucao.OrderByDescending(p => p.Dt_inicio).First() != null)
                        ID_evolucao = val.lEvolucao.OrderByDescending(p => p.Dt_inicio).First().Id_evolucao;
                val.lServico.ForEach(p =>
                {
                    p.Cd_empresa = val.Cd_empresa;
                    p.Id_os = val.Id_os;
                    p.Id_evolucao = p.Id_evolucao.HasValue ? p.Id_evolucao : ID_evolucao;
                    TCN_LanServicoPecas.Gravar(p, qtb_servico.Banco_Dados);
                });
                //Excluir Fotos OS
                val.lImagensDel.ForEach(p => TCN_Imagens.Excluir(p, qtb_servico.Banco_Dados));
                //Gravar Fotos OS
                val.lImagens.ForEach(p =>
                    {
                        p.Cd_empresa = val.Cd_empresa;
                        p.Id_os = val.Id_os;
                        TCN_Imagens.Gravar(p, qtb_servico.Banco_Dados);
                    });
                //Gravar Historico OS
                val.lHistorico.ForEach(p =>
                    {
                        if (!p.Id_os.HasValue)
                        {
                            p.Id_os = val.Id_os;
                            p.Cd_empresa = val.Cd_empresa;
                            p.Dt_historico = CamadaDados.UtilData.Data_Servidor(qtb_servico.Banco_Dados);
                            p.Login = Utils.Parametros.pubLogin;
                            TCN_Historico.Gravar(p, qtb_servico.Banco_Dados);
                        }
                    });
                //Amarrar OS a um lote de envio
                if (val.rLoteServico != null)
                {
                    val.rLoteServico.Id_os = val.Id_os;
                    TCN_Lote_X_Servicos.GravarLote_X_Servicos(val.rLoteServico, qtb_servico.Banco_Dados);
                }
                //Verificar se a OS tem pedido de Remessa
                if (val.lPedido.Exists(p => p.Tp_pedido.Trim().ToUpper().Equals("RM")))
                {
                    string ret_pedido = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(val.lPedido.Find(p => p.Tp_pedido.Trim().ToUpper().Equals("RM")), qtb_servico.Banco_Dados);
                    //Gravar servico x pedido item
                    val.lPedido.Find(p => p.Tp_pedido.Trim().ToUpper().Equals("RM")).Pedido_Itens.ForEach(v =>
                        {
                            if (v.Cd_produto.Trim().Equals(val.CD_ProdutoOS.Trim()))
                                TCN_Servico_X_PedidoItem.Gravar(new TRegistro_Servico_X_PedidoItem()
                                {
                                    Cd_empresa = val.Cd_empresa,
                                    Id_os = val.Id_os,
                                    Nr_pedido = Convert.ToDecimal(ret_pedido),
                                    Cd_produto = v.Cd_produto,
                                    Id_pedidoitem = v.Id_pedidoitem,
                                    Tp_pedido = "RM" //Pedido de remessa para conserto
                                }, qtb_servico.Banco_Dados);
                        });
                }
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static string GravaDuplicata(TRegistro_LanServico val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                //Gravar Duplicata
                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.lDup, false, qtb_os.Banco_Dados);
                TCN_LanServico_X_Duplicata.Gravar(new TRegistro_LanServico_X_Duplicata()
                {
                    Id_os = val.Id_os,
                    Cd_empresa = val.Cd_empresa,
                    Nr_lancto = val.lDup[0].Nr_lancto
                }, qtb_os.Banco_Dados);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro Gravar registro: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string Alterar(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                string retorno = qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro alterar ordem serviço: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static string cancelar(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_servico = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                //Verificar se a ordem de servico esta amarrada a um lote de envio para terceiro
                TList_LoteOS lLote = new CamadaDados.Servicos.TCD_LoteOS().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_lote_x_servico x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_lote = a.id_lote " +
                                        "and x.cd_empresa = '"+val.Cd_empresa.Trim() + "'" +
                                        "and x.id_os = "+val.Id_os.ToString() + ")"
                        }
                    }, 0, string.Empty);
                if (lLote.Count > 0)
                    lLote.ForEach(p =>
                        {
                            if (p.St_registro.Trim().ToUpper().Equals("A"))
                            {
                                //Desamarrar ordem de servico do lote
                                TCN_Lote_X_Servicos.DeletarLote_X_Servicos(
                                    new TRegistro_Lote_X_Servicos()
                                    {
                                        Cd_empresa = val.Cd_empresa,
                                        Id_os = val.Id_os,
                                        Id_lote = p.Id_lote
                                    }, qtb_servico.Banco_Dados);
                            }
                            else if (p.St_registro.Trim().ToUpper().Equals("P"))
                                throw new Exception("A ordem de serviço encontra-se amarrada ao lote de envio para terceiro <" + p.Id_lotestr + " que esta processado.");
                        });
                //Excluir pecas
                val.lPecas.ForEach(p => TCN_LanServicoPecas.Excluir(p, qtb_servico.Banco_Dados));
                //Excluir Servicos
                val.lServico.ForEach(p => TCN_LanServicoPecas.Excluir(p, qtb_servico.Banco_Dados));
                //Excluir Evolucao
                val.lEvolucao.ForEach(p => TCN_LanServicoEvolucao.Excluir(p, qtb_servico.Banco_Dados));
                //Excluir historico
                val.lHistorico.ForEach(p => TCN_Historico.Excluir(p, qtb_servico.Banco_Dados));
                //Excluir duplicata
                //Verificar se usuario tem permissão para excluir duplicata
                if (Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Parametros.pubLogin.Trim().ToUpper(), "PERMITIR EXCLUSAO DE DOCUMENTO FINANCEIRO", banco))
                {
                    //Verificar se o usuario tem acesso a tela de duplicata
                    if ((CamadaNegocio.Diversos.TCN_CadAcesso.BuscarDetalhesAcesso(Utils.Parametros.pubLogin, "Financeiro.TFLanContas") == null) &&
                        (!Utils.Parametros.pubLogin.Trim().ToUpper().Equals("MASTER")) &&
                        (!Utils.Parametros.pubLogin.Trim().ToUpper().Equals("DESENV")))
                        throw new Exception("Não é permitido cancelar uma nota fiscal com movimentação financeira.\r\n" +
                                            "Para cancelar a nota fiscal é necessário cancelar primeiro o financeiro.");
                    else
                    {
                        TCN_LanServico_X_Duplicata.BuscarDup(val.Cd_empresa, val.Id_osstr, qtb_servico.Banco_Dados).ForEach(p =>
                        {
                            TCN_LanServico_X_Duplicata.Excluir(new TRegistro_LanServico_X_Duplicata()
                            {
                                Id_os = val.Id_os,
                                Cd_empresa = val.Cd_empresa,
                                Nr_lancto = val.lDup[0].Nr_lancto
                            }, qtb_servico.Banco_Dados);
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_servico.Banco_Dados);
                        });
                    }
                }
                else
                    throw new Exception("Usuário não tem permissão para cancelar Duplicata!");
                //Verificar se OS teve Agendamento
                new TCD_Agendamento(qtb_servico.Banco_Dados).Select(
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
                            vNM_Campo = "a.id_os",
                            vOperador = "=",
                            vVL_Busca = val.Id_osstr
                        }
                    }, 0, string.Empty, string.Empty).ForEach(p =>
                        {
                            p.Id_os = null;
                            p.St_registro = "A";
                            TCN_Agendamento.Gravar(p, qtb_servico.Banco_Dados);
                        });

                //Excluir ordem servico
                // qtb_servico.Excluir(val)
                //Cancelar ordem servico
                val.St_os = "CA";
                qtb_servico.Gravar(val);
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
                return "OK";
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro cancelar servico: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static void ProcessarServico(List<TRegistro_LanServico> lOS,
                                            List<CamadaDados.Faturamento.Pedido.TRegistro_Pedido> lPed,
                                            BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_servico = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                if (lPed != null)
                {
                    //Pedido garantia
                    if (lPed.Exists(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("GR"))))
                    {
                        //Gravar pedido garantia
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(lPed.Find(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("GR"))), qtb_servico.Banco_Dados);
                        //Amarrar pedido as OS
                        lPed.Find(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("GR"))).Pedido_Itens.ForEach(p => p.lPecaOS.ForEach(v =>
                             TCN_Servico_X_PedidoItem.Gravar(new TRegistro_Servico_X_PedidoItem()
                             {
                                 Cd_empresa = v.Cd_empresa,
                                 Cd_produto = p.Cd_produto,
                                 Id_os = v.Id_os,
                                 Id_pedidoitem = p.Id_pedidoitem,
                                 Nr_pedido = p.Nr_pedido,
                                 Tp_pedido = "GR"
                             }, qtb_servico.Banco_Dados)));
                    }
                    //Pedido servico
                    if (lPed.Exists(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("SV"))))
                    {
                        //Gravar pedido servico
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(lPed.Find(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("SV"))), qtb_servico.Banco_Dados);
                        //Amarrar pedido as OS
                        lPed.Find(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("SV"))).Pedido_Itens.ForEach(p => p.lPecaOS.ForEach(v =>
                             TCN_Servico_X_PedidoItem.Gravar(new TRegistro_Servico_X_PedidoItem()
                             {
                                 Cd_empresa = v.Cd_empresa,
                                 Cd_produto = p.Cd_produto,
                                 Id_os = v.Id_os,
                                 Id_pedidoitem = p.Id_pedidoitem,
                                 Nr_pedido = p.Nr_pedido,
                                 Tp_pedido = "SV"
                             }, qtb_servico.Banco_Dados)));
                    }
                    //Pedido Peca
                    if (lPed.Exists(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("IT"))))
                    {
                        //Gravar pedido item
                        CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(lPed.Find(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("IT"))), qtb_servico.Banco_Dados);
                        //Amarrar pedido as OS
                        lPed.Find(p => p.Pedido_Itens.Exists(v => v.Tp_pedOS.Trim().ToUpper().Equals("IT"))).Pedido_Itens.ForEach(p => p.lPecaOS.ForEach(v =>
                             TCN_Servico_X_PedidoItem.Gravar(new TRegistro_Servico_X_PedidoItem()
                             {
                                 Cd_empresa = v.Cd_empresa,
                                 Cd_produto = p.Cd_produto,
                                 Id_os = v.Id_os,
                                 Id_pedidoitem = p.Id_pedidoitem,
                                 Nr_pedido = p.Nr_pedido,
                                 Tp_pedido = "IT"
                             }, qtb_servico.Banco_Dados)));
                    }
                }

                //Alterar status das OS para processada
                lOS.ForEach(p =>
                    {
                        //Processar comissao
                        TCN_LanServicoPecas.Buscar(p.Id_osstr,
                                                   p.Cd_empresa,
                                                   string.Empty,
                                                   string.Empty,
                                                   string.Empty,
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   decimal.Zero,
                                                   string.Empty,
                                                   string.Empty,
                                                   false,
                                                   0,
                                                   qtb_servico.Banco_Dados).FindAll(v => !v.St_atendimentogarantiabool).ForEach(v => ProcessarComissao(v, qtb_servico.Banco_Dados));
                        p.St_os = "PR"; //Processada
                        p.Dt_encerramento = CamadaDados.UtilData.Data_Servidor();
                        qtb_servico.Gravar(p);
                    });
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static void EstornarServico(TRegistro_LanServico rOs, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_servico = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                //Cancelar pedidos da OS
                TCN_Servico_X_PedidoItem.BuscarPedidos(rOs.Cd_empresa, rOs.Id_osstr, qtb_servico.Banco_Dados).ForEach(p => CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(p, qtb_servico.Banco_Dados));
                //Cancelar Pré-Venda
                Faturamento.PDV.TCN_PreVenda.Excluir(
                    new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_servico.Banco_Dados).Select(
                        new TpBusca[]
                        {
                            new TpBusca
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from tb_ose_pecas_x_prevenda x " +
                                            "where x.cd_empresa = a.cd_empresa " +
                                            "and x.id_prevenda = a.id_prevenda " +
                                            "and x.cd_empresa = '" + rOs.Cd_empresa.Trim() + "' " +
                                            "and x.id_os = " + rOs.Id_osstr + ")"

                            }
                        }, 0, string.Empty, string.Empty), qtb_servico.Banco_Dados);
                //Excluir Servico X OS
                TCN_Servico_X_PedidoItem.Buscar(rOs.Id_osstr,
                                                rOs.Cd_empresa,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                0,
                                                string.Empty,
                                                qtb_servico.Banco_Dados).ForEach(p => TCN_Servico_X_PedidoItem.Excluir(p, qtb_servico.Banco_Dados));
                //Excluir Comissao
                CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                  rOs.Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  rOs.Id_osstr,
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
                                                                                             string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  qtb_servico.Banco_Dados).ForEach(p => CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_servico.Banco_Dados));
                //Alterar status da os para finalizada
                rOs.St_os = "FE";
                Gravar(rOs, qtb_servico.Banco_Dados);
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static void ProcessarOSPreVenda(TRegistro_LanServico val,
                                               CamadaDados.Faturamento.PDV.TRegistro_PreVenda rPreVenda,
                                               CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPedGarantia,
                                               BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                //Gravar Pre Venda
                if (rPreVenda != null)
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Gravar(rPreVenda, qtb_os.Banco_Dados);
                //Gravar pedido garantia
                if (rPedGarantia != null)
                {
                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPedGarantia, qtb_os.Banco_Dados);
                    //Amarrar pedido as OS
                    rPedGarantia.Pedido_Itens.ForEach(p => p.lPecaOS.ForEach(v =>
                        TCN_Servico_X_PedidoItem.Gravar(new TRegistro_Servico_X_PedidoItem()
                        {
                            Cd_empresa = v.Cd_empresa,
                            Cd_produto = p.Cd_produto,
                            Id_os = v.Id_os,
                            Id_pedidoitem = p.Id_pedidoitem,
                            Nr_pedido = p.Nr_pedido,
                            Tp_pedido = "GR"
                        }, qtb_os.Banco_Dados)));
                }
                //Processar comissao 
                val.lPecas.FindAll(p => !p.St_atendimentogarantiabool).ForEach(p => ProcessarComissao(p, qtb_os.Banco_Dados));
                val.lServico.ForEach(p =>
                    {
                        //Estoque Ficha Tecnica
                        p.lFichaTecOS.ForEach(v =>
                            {
                                //Gravar Estoque
                                string ret_est =
                                CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(
                                    new CamadaDados.Estoque.TRegistro_LanEstoque()
                                    {
                                        Cd_empresa = rPreVenda.Cd_empresa,
                                        Cd_produto = v.Cd_item,
                                        Cd_local = v.Cd_local,
                                        Dt_lancto = rPreVenda.Dt_emissao,
                                        Tp_movimento = "S",
                                        Qtd_entrada = decimal.Zero,
                                        Qtd_saida = v.Quantidade,
                                        Tp_lancto = "N",
                                        St_registro = "A"
                                    }, qtb_os.Banco_Dados);
                                //Gravar Ficha X Estoque
                                TCN_FichaTec_X_Estoque.Gravar(
                                    new TRegistro_FichaTec_X_Estoque()
                                    {
                                        Id_os = v.Id_os,
                                        Cd_empresa = v.Cd_empresa,
                                        Id_peca = v.Id_peca,
                                        Cd_item = v.Cd_item,
                                        Id_lanctoestoque = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_est, "@@P_ID_LANCTOESTOQUE"))
                                    }, qtb_os.Banco_Dados);
                            });
                        ProcessarComissao(p, qtb_os.Banco_Dados);
                    });
                //Alterar status OS para PROCESSADA
                val.St_os = "PR";//Processada
                val.Dt_encerramento = CamadaDados.UtilData.Data_Servidor(qtb_os.Banco_Dados);
                qtb_os.Gravar(val);

                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static void EstornarOSPreVenda(TRegistro_LanServico rOs, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else qtb_os.Banco_Dados = banco;
                //Cancelar pedidos da OS
                TCN_Servico_X_PedidoItem.BuscarPedidos(rOs.Cd_empresa, rOs.Id_osstr, qtb_os.Banco_Dados).ForEach(p => CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(p, qtb_os.Banco_Dados));
                //Excluir Servico X OS
                TCN_Servico_X_PedidoItem.Buscar(rOs.Id_osstr,
                                                rOs.Cd_empresa,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                0,
                                                string.Empty,
                                                qtb_os.Banco_Dados).ForEach(p => TCN_Servico_X_PedidoItem.Excluir(p, qtb_os.Banco_Dados));
                //Excluir Comissao
                CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                  rOs.Cd_empresa,
                                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  rOs.Id_osstr,
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
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  qtb_os.Banco_Dados).ForEach(p => CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_os.Banco_Dados));
                //Cancelar Estoque Ficha Tecnica
                new CamadaDados.Estoque.TCD_LanEstoque(qtb_os.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_fichatec_x_estoque x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.cd_item = a.cd_produto " +
                                        "and x.id_lanctoestoque = a.id_lanctoestoque " +
                                        "and x.cd_empresa = '" + rOs.Cd_empresa.Trim() + "' " +
                                        "and x.id_os = " + rOs.Id_osstr + ")"
                        }
                    }, 0, string.Empty, string.Empty, string.Empty).ForEach(p => CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(p, qtb_os.Banco_Dados));
                //Cancelar Pre-Venda
                new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_os.Banco_Dados).Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo= string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_pecas_x_prevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda " +
                                        "and x.cd_empresa = '" + rOs.Cd_empresa.Trim() + "' " +
                                        "and x.id_os = " + rOs.Id_osstr + ")"
                        }
                    }, 0, string.Empty, string.Empty).ForEach(p =>
                        {
                            //Buscar Venda Faturada para Prevenda
                            new CamadaDados.Faturamento.PDV.TCD_VendaRapida(qtb_os.Banco_Dados).Select(
                                new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_pdv_prevenda_x_vendarapida x " +
                                                    "where x.cd_empresa = a.cd_empresa " +
                                                    "and x.id_cupom = a.id_vendarapida " +
                                                    "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "'" +
                                                    "and x.id_prevenda = " + p.Id_prevendastr + ")"
                                    }
                                }, 0, string.Empty, string.Empty).ForEach(v => Faturamento.PDV.TCN_VendaRapida.ExcluirVendaRapida(new List<CamadaDados.Faturamento.PDV.TRegistro_VendaRapida>() { v }, qtb_os.Banco_Dados));
                            Faturamento.PDV.TCN_PreVenda.Excluir(new List<CamadaDados.Faturamento.PDV.TRegistro_PreVenda>() { p }, qtb_os.Banco_Dados);
                        });
                //Alterar status da os para finalizada
                rOs.St_os = "FE";
                Gravar(rOs, qtb_os.Banco_Dados);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static void ProcessarOSOficina(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else qtb_os.Banco_Dados = banco;
                //Gravar duplicata
                CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.GravarDuplicata(val.lDup[0], false, qtb_os.Banco_Dados);
                //Gravar duplicata x os
                TCN_LanServico_X_Duplicata.Gravar(new TRegistro_LanServico_X_Duplicata()
                {
                    Cd_empresa = val.Cd_empresa,
                    Id_os = val.Id_os,
                    Nr_lancto = val.lDup[0].Nr_lancto
                }, qtb_os.Banco_Dados);
                //Baixar estoque OS
                if (new TCD_TpOrdem(qtb_os.Banco_Dados).BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.tp_ordem",
                            vOperador = "=",
                            vVL_Busca = val.Tp_ordemstr
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_procestoque, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "1") != null)
                    val.lPecas.FindAll(p => !p.St_servicobool).ForEach(p =>
                         {
                             string ret_estoque =
                             CamadaNegocio.Estoque.TCN_LanEstoque.GravarEstoque(new CamadaDados.Estoque.TRegistro_LanEstoque()
                             {
                                 Cd_empresa = p.Cd_empresa,
                                 Cd_produto = p.Cd_produto,
                                 Cd_local = p.Cd_local,
                                 Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_os.Banco_Dados),
                                 Tp_movimento = "S",
                                 Qtd_entrada = decimal.Zero,
                                 Qtd_saida = p.Quantidade,
                                 Vl_unitario = p.Vl_unitario,
                                 Vl_subtotal = p.Vl_subtotal,
                                 Tp_lancto = "N",
                                 St_registro = "A"
                             }, qtb_os.Banco_Dados);
                             TCN_OSEEstoque.Gravar(new TRegistro_OSEEstoque()
                             {
                                 Cd_empresa = p.Cd_empresa,
                                 Id_os = p.Id_os,
                                 Id_peca = p.Id_peca,
                                 Cd_produto = p.Cd_produto,
                                 Id_lanctoestoque = decimal.Parse(CamadaDados.TDataQuery.getPubVariavel(ret_estoque, "@@P_ID_LANCTOESTOQUE"))
                             }, qtb_os.Banco_Dados);
                         });
                //Alterar status OS para PROCESSADA
                val.St_os = "PR";//Processada
                val.Dt_encerramento = CamadaDados.UtilData.Data_Servidor(qtb_os.Banco_Dados);
                qtb_os.Gravar(val);

                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static void ProcessarOSPatrimonio(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else qtb_os.Banco_Dados = banco;

                CamadaNegocio.Servicos.TCN_LanPecasEnvTerceiro.Buscar(val.Id_osstr,
                                                                      val.Cd_empresa,
                                                                      string.Empty,
                                                                      string.Empty,
                                                                      qtb_os.Banco_Dados).ForEach(p =>
                  {
                      CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();

                      //Buscar Almoxarifado
                      CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox =
                      new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(qtb_os.Banco_Dados).Select(
                           new Utils.TpBusca[]
                            {
                                        new Utils.TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                        "where x.id_almox = a.id_almox " +
                                                        "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                                        }
                            }, 0, string.Empty);
                      if (lAlmox.Count > 0)
                          rMov.Id_almoxstr = lAlmox[0].Id_almoxString;
                      else
                          throw new Exception("Não existe almoxarifado cadastrado para empresa " + val.Cd_empresa.Trim());
                      
                      //Buscar Vl.Custo Almoxarifado
                      rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa,
                                                                                                           rMov.Id_almoxstr,
                                                                                                           p.Cd_produto,
                                                                                                           qtb_os.Banco_Dados);
                      rMov.Quantidade = p.Quantidade;
                      rMov.Vl_subtotal = rMov.Quantidade * rMov.Vl_unitario;
                      rMov.Ds_observacao = "PRODUTO DEVOLVIDO DE UM ENVIO DE PEÇAS PARA TERCEIROS";
                      rMov.Cd_empresa = val.Cd_empresa;
                      rMov.Tp_movimento = "E";
                      rMov.Cd_produto = p.Cd_produto;
                      rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                      rMov.St_registro = "A";
                      rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                      //Gravar Almoxarifado
                      CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_os.Banco_Dados);
                      //Gravar Pecas Envio Terceiro
                      CamadaNegocio.Servicos.TCN_LanPecasEnvTerceiro.Gravar(
                      new TRegistro_LanPecasEnvTerceiro()
                      {
                          Id_os = val.Id_os,
                          Cd_empresa = val.Cd_empresa,
                          Id_evolucao = p.Id_evolucao,
                          Cd_produto = p.Cd_produto,
                          Quantidade = p.Quantidade,
                          Id_MovAmxE = rMov.Id_movimento
                      }, qtb_os.Banco_Dados);
                  });
                //Baixar estoque de Pecas do Almoxarifado
                val.lPecas.FindAll(p => !p.St_servicobool).ForEach(p =>
                {
                    CamadaDados.Almoxarifado.TRegistro_Movimentacao rMov = new CamadaDados.Almoxarifado.TRegistro_Movimentacao();

                    //Buscar Almoxarifado
                    CamadaDados.Almoxarifado.TList_CadAlmoxarifado lAlmox =
                        new CamadaDados.Almoxarifado.TCD_CadAlmoxarifado(qtb_os.Banco_Dados).Select(
                             new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "exists",
                                        vVL_Busca = "(select 1 from tb_amx_almox_x_empresa x " +
                                                    "where x.id_almox = a.id_almox " +
                                                    "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                                    }
                                }, 0, string.Empty);
                    if (lAlmox.Count > 0)
                        rMov.Id_almoxstr = lAlmox[0].Id_almoxString;
                    else
                        throw new Exception("Não existe almoxarifado cadastrado para empresa " + val.Cd_empresa.Trim());
                    //Buscar Saldo Almoxarifado
                    decimal saldo = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.ConsultaSaldoAlmox(val.Cd_empresa,
                                                                                                             rMov.Id_almoxstr,
                                                                                                             p.Cd_produto,
                                                                                                             qtb_os.Banco_Dados);
                    if (saldo < p.Quantidade)
                        throw new Exception("Não existe saldo suficiente para gravar movimentação.\r\n" +
                             "Item: " + p.Cd_produto.Trim() + "\r\n" +
                             "Saldo Atual: " + saldo.ToString("N3", new System.Globalization.CultureInfo("pt-BR")) + "\r\n" +
                             "Qtde Requerida: " + p.Quantidade.ToString("N3", new System.Globalization.CultureInfo("pt-BR")));


                    //Buscar Vl.Custo Almoxarifado
                    rMov.Vl_unitario = CamadaNegocio.Almoxarifado.TCN_SaldoAlmoxarifado.Vl_Custo_Almox_Prod(val.Cd_empresa,
                                                                                                             rMov.Id_almoxstr,
                                                                                                             p.Cd_produto,
                                                                                                             qtb_os.Banco_Dados);
                    rMov.Quantidade = p.Quantidade;
                    rMov.Vl_subtotal = rMov.Quantidade * rMov.Vl_unitario;
                    rMov.Ds_observacao = "PRODUTO CONSUMIDO NA ORDEM DE SERVIÇO Nº" + val.Id_osstr;
                    rMov.Cd_empresa = val.Cd_empresa;
                    rMov.Tp_movimento = "S";
                    rMov.Cd_produto = p.Cd_produto;
                    rMov.LoginAlmoxarife = Utils.Parametros.pubLogin;
                    rMov.St_registro = "A";
                    rMov.Dt_movimento = CamadaDados.UtilData.Data_Servidor();
                    //Gravar Almoxarifado
                    CamadaNegocio.Almoxarifado.TCN_Movimentacao.Gravar(rMov, qtb_os.Banco_Dados);
                    //Gravar Almoxarifado X OS
                    CamadaNegocio.Servicos.TCN_LanAlmoxarifado.Gravar(
                        new CamadaDados.Servicos.TRegistro_LanAlmoxarifado()
                        {
                            Id_os = val.Id_os,
                            Cd_empresa = val.Cd_empresa,
                            Id_peca = p.Id_peca,
                            Id_Movimento = rMov.Id_movimento
                        }, qtb_os.Banco_Dados);
                });
                //Alterar status OS para PROCESSADA
                val.St_os = "PR";//Processada
                val.Dt_encerramento = CamadaDados.UtilData.Data_Servidor(qtb_os.Banco_Dados);
                qtb_os.Gravar(val);
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static void EstornarProcessarOSOficina(TRegistro_LanServico rOs, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_servico = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_servico.CriarBanco_Dados(true);
                else
                    qtb_servico.Banco_Dados = banco;
                //Verificar se os gerou duplicata
                CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata lDup =
                TCN_LanServico_X_Duplicata.BuscarDup(rOs.Cd_empresa, rOs.Id_osstr, qtb_servico.Banco_Dados);
                if (lDup.Count > 0)
                {
                    //Cancelar duplicata
                    lDup.ForEach(p =>
                        {
                            TCN_LanServico_X_Duplicata.Excluir(new TRegistro_LanServico_X_Duplicata()
                            {
                                Cd_empresa = rOs.Cd_empresa,
                                Id_os = rOs.Id_os,
                                Nr_lancto = p.Nr_lancto
                            }, qtb_servico.Banco_Dados);
                            CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.CancelarDuplicata(p, qtb_servico.Banco_Dados);
                        });
                    //Cancelar estoque
                    CamadaNegocio.Servicos.TCN_OSEEstoque.Buscar(rOs.Cd_empresa,
                                                                 rOs.Id_osstr,
                                                                 string.Empty,
                                                                 qtb_servico.Banco_Dados).ForEach(p =>
                                                                     {
                                                                         CamadaNegocio.Estoque.TCN_LanEstoque.CancelarEstoque(
                                                                             CamadaNegocio.Estoque.TCN_LanEstoque.Busca(p.Cd_empresa,
                                                                                                                        p.Cd_produto,
                                                                                                                        string.Empty,
                                                                                                                        string.Empty,
                                                                                                                        string.Empty,
                                                                                                                        p.Id_lanctoestoquestr,
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
                                                                                                                        qtb_servico.Banco_Dados)[0], qtb_servico.Banco_Dados);
                                                                         TCN_OSEEstoque.Excluir(p, qtb_servico.Banco_Dados);
                                                                     });
                    if (new CamadaDados.Faturamento.NotaFiscal.TCD_LanFaturamento_Item(qtb_servico.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_OSE_Servico_X_PedidoItem x " +
                                            "where x.nr_pedido = a.nr_pedido " +
                                            "and x.cd_produto = a.cd_produto " +
                                            "and x.id_pedidoitem = a.id_pedidoitem " +
                                            "and isnull(nf.st_registro, 'A') <> 'C' " +
                                            "and x.cd_empresa = '" + rOs.Cd_empresa.Trim() + "' " +
                                            "and x.id_os = " + rOs.Id_osstr + ")"
                            }
                        }, "1") != null)
                        throw new Exception("Para estornar PROCESSAMENTO da OS, necessario antes cancelar NF.");
                    TList_Pedido lPed = TCN_Servico_X_PedidoItem.BuscarPedidos(rOs.Cd_empresa, rOs.Id_osstr, qtb_servico.Banco_Dados);
                    //TCN_Servico_X_PedidoItem.Buscar(rOs.Id_osstr,
                    //                                rOs.Cd_empresa,
                    //                                string.Empty,
                    //                                string.Empty,
                    //                                string.Empty,
                    //                                string.Empty,
                    //                                0,
                    //                                string.Empty,
                    //                                qtb_servico.Banco_Dados).ForEach(p => TCN_Servico_X_PedidoItem.Excluir(p, qtb_servico.Banco_Dados));
                    lPed.ForEach(p => TCN_Pedido.Deleta_Pedido(p, qtb_servico.Banco_Dados));
                }
                else
                {
                    //Verificar se a pre venda nao se encontra faturada
                    if (new CamadaDados.Faturamento.PDV.TCD_PreVenda_X_VendaRapida(qtb_servico.Banco_Dados).BuscarEscalar(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_pecas_x_prevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda " +
                                        "and x.id_itemprevenda = a.id_itemprevenda " +
                                        "and x.cd_empresa = '" + rOs.Cd_empresa.Trim() + "' " +
                                        "and x.id_os = " + rOs.Id_osstr + ")"
                        }
                    }, "1") != null)
                        throw new Exception("Não é permitido estornar processamento de OS com Pré Venda ja FATURADA.");
                    //Buscar Pre Venda
                    CamadaDados.Faturamento.PDV.TList_PreVenda lPreVenda =
                    new CamadaDados.Faturamento.PDV.TCD_PreVenda(qtb_servico.Banco_Dados).Select(
                        new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_ose_pecas_x_prevenda x " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_prevenda = a.id_prevenda " +
                                        "and x.cd_empresa = '" + rOs.Cd_empresa.Trim() + "' " +
                                        "and x.id_os = " + rOs.Id_osstr + ")"
                        }
                    }, 0, string.Empty, string.Empty);
                    lPreVenda.ForEach(p => p.lItens = CamadaNegocio.Faturamento.PDV.TCN_ItensPreVenda.Buscar(p.Cd_empresa,
                                                                                                             p.Id_prevendastr,
                                                                                                             string.Empty,
                                                                                                             string.Empty,
                                                                                                             false,
                                                                                                             qtb_servico.Banco_Dados));
                    CamadaNegocio.Faturamento.PDV.TCN_PreVenda.Excluir(lPreVenda, qtb_servico.Banco_Dados);
                    //Excluir Comissao
                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Buscar(string.Empty,
                                                                                      rOs.Cd_empresa,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      rOs.Id_osstr,
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
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      string.Empty,
                                                                                      qtb_servico.Banco_Dados).ForEach(p => CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Excluir(p, qtb_servico.Banco_Dados));
                }
                //Alterar status da os para finalizada
                rOs.St_os = "FE";
                Gravar(rOs, qtb_servico.Banco_Dados);
                if (st_transacao)
                    qtb_servico.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_servico.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro estornar processamento OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_servico.deletarBanco_Dados();
            }
        }

        public static void DevolverOS(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                //Gravar lista de acessorios
                val.lAcessorios.ForEach(p => TCN_Acessorios.GravarAcessorios(p, qtb_os.Banco_Dados));
                //Alterar status da OS para DV - Devolvida
                val.St_os = "DV";
                val.Dt_devolucao = CamadaDados.UtilData.Data_Servidor();
                qtb_os.Gravar(val);
                if (banco == null)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver OS: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static void DevolverOS(List<TRegistro_LanServico> val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                val.ForEach(p => DevolverOS(p, qtb_os.Banco_Dados));
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception(ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static void DevolverOSFornecedor(List<TRegistro_LanServico> lOs,
                                                TRegistro_LanServicoEvolucao rEvolucao,
                                                decimal Vl_frete,
                                                BancoDados.TObjetoBanco banco)
        {
            if (lOs.Count.Equals(0))
                throw new Exception("Não existe ordem serviço selecionada para devolver.");
            if (rEvolucao == null)
                throw new Exception("Não existe proxima etapa.");
            bool st_transacao = false;
            TCD_LanServico qtb_os = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_os.CriarBanco_Dados(true);
                else
                    qtb_os.Banco_Dados = banco;
                decimal vl_freterateado = decimal.Zero;
                CamadaDados.Servicos.Cadastros.TList_OSE_ParamOS lParam = null;
                if (Vl_frete > 0)
                {
                    vl_freterateado = Math.Round(Vl_frete / lOs.Count, 2);
                    //Buscar produto frete
                    lParam = CamadaNegocio.Servicos.Cadastros.TCN_OSE_ParamOS.Buscar(lOs[0].Tp_ordemstr,
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
                                                                                    qtb_os.Banco_Dados);
                    if (lParam.Count.Equals(0))
                        throw new Exception("Não existe configuração para o tipo de ordem " + lOs[0].Tp_ordemstr);
                    if (lParam[0].Cd_produtofrete.Trim().Equals(string.Empty))
                        throw new Exception("Não existe produto frete configurado para o tipo de ordem " + lOs[0].Tp_ordemstr);
                }
                object obj = new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().BuscarEscalar(
                            new TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.id_etapa",
                                    vOperador = "=",
                                    vVL_Busca = rEvolucao.Id_etapastr
                                }
                            }, "isnull(a.St_FinalizarOs, 'N')");
                //Gravar etapa servico nas Os e ratear valor do frete
                lOs.ForEach(p =>
                    {
                        p.lEvolucao.ForEach(v =>
                            {
                                v.St_evolucao = "E";
                                v.Dt_final = CamadaDados.UtilData.Data_Servidor();
                            });
                        if (obj != null)
                            if (obj.ToString().Trim().Equals("S"))
                            {
                                p.St_os = "FE";
                                p.Dt_finalizada = CamadaDados.UtilData.Data_Servidor();
                                rEvolucao.St_evolucao = "E";
                                rEvolucao.Dt_final = CamadaDados.UtilData.Data_Servidor();
                            }
                        p.lEvolucao.Add(rEvolucao);
                        if (vl_freterateado > 0)
                        {
                            p.lPecas = CamadaNegocio.Servicos.TCN_LanServicoPecas.Buscar(p.Id_osstr,
                                                                                         p.Cd_empresa,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         decimal.Zero,
                                                                                         string.Empty,
                                                                                         string.Empty,
                                                                                         true,
                                                                                         0,
                                                                                         qtb_os.Banco_Dados);
                            if (p.lPecas.Exists(v => v.Cd_produto.Trim().Equals(lParam[0].Cd_produtofrete.Trim())))
                                p.lPecas.Find(v => v.Cd_produto.Trim().Equals(lParam[0].Cd_produtofrete.Trim())).Vl_unitario =
                                    ((p.lPecas.Find(v => v.Cd_produto.Trim().Equals(lParam[0].Cd_produtofrete.Trim())).Vl_subtotal + vl_freterateado) /
                                        p.lPecas.Find(v => v.Cd_produto.Trim().Equals(lParam[0].Cd_produtofrete.Trim())).Quantidade);
                            else
                                p.lPecas.Add(new TRegistro_LanServicosPecas()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_local = string.Empty,
                                    Cd_produto = lParam[0].Cd_produtofrete,
                                    Cd_unidproduto = string.Empty,
                                    Id_os = p.Id_os,
                                    Quantidade = 1,
                                    Vl_unitario = vl_freterateado
                                });
                        }
                        Gravar(p, qtb_os.Banco_Dados);
                    });
                if (st_transacao)
                    qtb_os.Banco_Dados.Commit_Tran();
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_os.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro devolver ordem serviço fornecedor: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_os.deletarBanco_Dados();
            }
        }

        public static bool SequenciaManual(TRegistro_LanServico val, BancoDados.TObjetoBanco banco)
        {
            TList_OSE_ParamOS lParam = TCN_OSE_ParamOS.Buscar(val.Tp_ordemstr,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              0,
                                                              string.Empty,
                                                              banco);
            if (lParam.Count > 0)
                return lParam[0].St_sequenciamanualbool;
            else
                return false;
        }

        public static void RateiaDescontoItens(TRegistro_LanServico val, bool St_perc)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.lPecas.Sum(p => p.Vl_subtotal);
                if (!St_perc)
                    val.Pc_desconto = Math.Round(decimal.Divide(decimal.Multiply(val.Vl_desconto, 100), tot_subtotal), 5, MidpointRounding.AwayFromZero);
                val.lPecas.ForEach(p =>
                {
                    p.Vl_desconto = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(val.Pc_desconto, 100)), 2, MidpointRounding.AwayFromZero);
                    p.Vl_SubTotalLiq = p.Vl_subtotal + p.Vl_acrescimo - p.Vl_desconto;
                    p.Pc_desconto = val.Pc_desconto;
                });
                if (!St_perc && val.Vl_desconto != val.lPecas.Sum(p => p.Vl_desconto))
                {
                    val.lPecas[val.lPecas.Count - 1].Vl_desconto += val.Vl_desconto - val.lPecas.Sum(p => p.Vl_desconto);
                    val.lPecas[val.lPecas.Count - 1].Vl_SubTotalLiq = val.lPecas[val.lPecas.Count - 1].Vl_subtotal + val.lPecas[val.lPecas.Count - 1].Vl_acrescimo - val.lPecas[val.lPecas.Count - 1].Vl_desconto;
                }
            }
        }

        public static void RateiaAcrescimoItens(TRegistro_LanServico val, bool St_perc)
        {
            if (val != null)
            {
                decimal tot_subtotal = val.lPecas.Sum(p => p.Vl_subtotal);
                if (!St_perc)
                    val.Pc_acrescimo = Math.Round(decimal.Divide(decimal.Multiply(val.Vl_desconto, 100), tot_subtotal), 5, MidpointRounding.AwayFromZero);
                val.lPecas.ForEach(p =>
                {
                    p.Vl_acrescimo = Math.Round(decimal.Multiply(p.Vl_subtotal, decimal.Divide(val.Pc_acrescimo, 100)), 2, MidpointRounding.AwayFromZero);
                    p.Vl_SubTotalLiq = p.Vl_subtotal + p.Vl_acrescimo - p.Vl_desconto;
                    p.Pc_acrescimo = val.Pc_acrescimo;
                });
                if (!St_perc && val.Vl_acrescimo != val.lPecas.Sum(p => p.Vl_acrescimo))
                {
                    val.lPecas[val.lPecas.Count - 1].Vl_acrescimo += val.Vl_acrescimo - val.lPecas.Sum(p => p.Vl_acrescimo);
                    val.lPecas[val.lPecas.Count - 1].Vl_SubTotalLiq = val.lPecas[val.lPecas.Count - 1].Vl_subtotal + val.lPecas[val.lPecas.Count - 1].Vl_acrescimo - val.lPecas[val.lPecas.Count - 1].Vl_desconto;
                }
            }
        }

        public static void ProcessarComissao(TRegistro_LanServicosPecas val, BancoDados.TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServicosPecas qtb_item = new TCD_LanServicosPecas();
            try
            {
                if (banco == null)
                    st_transacao = qtb_item.CriarBanco_Dados(true);
                else
                    qtb_item.Banco_Dados = banco;
                if (!string.IsNullOrEmpty(val.Cd_tecnico))
                {
                    decimal vl_basecalc = val.Vl_SubTotalLiq;
                    decimal pc_comissao = decimal.Zero;
                    string tp_comissao = "P";
                    decimal vl_comissao = CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.CalcularComissao(val.Cd_empresa,
                                                                                                                      val.Cd_tecnico,
                                                                                                                      string.Empty,
                                                                                                                      string.Empty,
                                                                                                                      val.Cd_produto,
                                                                                                                      val.Quantidade,
                                                                                                                      ref vl_basecalc,
                                                                                                                      ref pc_comissao,
                                                                                                                      ref tp_comissao,
                                                                                                                      qtb_item.Banco_Dados);
                    //Gravar fechamento comissao
                    CamadaNegocio.Faturamento.Comissao.TCN_Fechamento_Comissao.Gravar(
                        new CamadaDados.Faturamento.Comissao.TRegistro_Fechamento_Comissao()
                        {
                            Cd_empresa = val.Cd_empresa,
                            Cd_vendedor = val.Cd_tecnico,
                            Dt_lancto = CamadaDados.UtilData.Data_Servidor(qtb_item.Banco_Dados),
                            Id_os = val.Id_os,
                            Id_peca = val.Id_peca,
                            Tp_comissao = tp_comissao,
                            Pc_comissao = pc_comissao,
                            Vl_basecalc = vl_basecalc,
                            Vl_comissao = vl_comissao
                        }, qtb_item.Banco_Dados);
                    if (st_transacao)
                        qtb_item.Banco_Dados.Commit_Tran();
                }
            }
            catch (Exception ex)
            {
                if (banco == null)
                    qtb_item.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro processar comissão: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_item.deletarBanco_Dados();
            }
        }

        public static string FinalizarAtividade(TRegistro_LanServico val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qt_fin = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qt_fin.CriarBanco_Dados(true);
                else
                    qt_fin.Banco_Dados = banco;
                val.lEvolucao.ForEach(p =>
                    {
                        p.lAtividadeDel.ForEach(v => TCN_LanAtividades.Excluir(v, qt_fin.Banco_Dados));
                        p.lAtividade.ForEach(v => TCN_LanAtividades.Gravar(v, qt_fin.Banco_Dados));
                        if (p.lAtividade.Count > 0)
                        {
                            //Verificar se etapa está concluida
                            if (new CamadaDados.Servicos.TCD_LanAtividades(qt_fin.Banco_Dados).BuscarEscalar(
                                new Utils.TpBusca[]
                                {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.st_registro",
                                        vOperador = "=",
                                        vVL_Busca = "'P'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.ID_EVOLUCAO",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Id_evolucaostr.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.ID_OS",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Id_osstr.Trim() + "'"
                                    },
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.cd_empresa",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                    }
                                }, string.Empty) == null)
                            {
                                p.St_evolucao = "E";
                                p.Dt_final = CamadaDados.UtilData.Data_Servidor();
                                CamadaNegocio.Servicos.TCN_LanServicoEvolucao.Gravar(p, qt_fin.Banco_Dados);
                            };
                        }
                    });
                //Verificar se Todas Etapas estão Concluídas e finalizar Projeto
                if (val.lEvolucao.Exists(p => p.St_evolucao.ToUpper().Equals("A")))
                    val.St_os = "AB";
                else
                {
                    val.St_os = "FE";
                    val.Dt_finalizada = CamadaDados.UtilData.Data_Servidor();
                }
                string retorno = qt_fin.Gravar(val);
                if (st_transacao)
                    qt_fin.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qt_fin.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar atividade: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qt_fin.deletarBanco_Dados();
            }
        }

        public static string ReabrirAtividade(TRegistro_LanServico val, TObjetoBanco banco)
        {
            bool st_transacao = false;
            TCD_LanServico qtb_reabrir = new TCD_LanServico();
            try
            {
                if (banco == null)
                    st_transacao = qtb_reabrir.CriarBanco_Dados(true);
                else
                    qtb_reabrir.Banco_Dados = banco;
                val.lEvolucao.ForEach(p =>
                    {
                        //Deletar Atividades Etapa
                        p.lAtividadeDel.ForEach(v => TCN_LanAtividades.Excluir(v, qtb_reabrir.Banco_Dados));
                        //Gravar Atividade Etapa
                        p.lAtividade.ForEach(v =>
                        {
                            v.Id_os = p.Id_os;
                            v.Cd_empresa = p.Cd_empresa;
                            v.Id_evolucao = p.Id_evolucao;
                            if (string.IsNullOrEmpty(v.Login))
                                v.Login = Utils.Parametros.pubLogin;
                            TCN_LanAtividades.Gravar(v, qtb_reabrir.Banco_Dados);
                        });
                        //Verificar se etapa está concluida
                        if (new CamadaDados.Servicos.TCD_LanAtividades(qtb_reabrir.Banco_Dados).BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.st_registro",
                                    vOperador = "=",
                                    vVL_Busca = "'P'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ID_EVOLUCAO",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Id_evolucaostr.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.ID_OS",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Id_osstr.Trim() + "'"
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                }
                            }, string.Empty) != null)
                        {
                            p.St_evolucao = "A";
                            p.Dt_final = null;
                        };
                    });
                if (!val.St_os.ToUpper().Equals("AB"))
                {
                    val.St_os = "AB";
                    val.Dt_finalizada = null;
                }
                //Gravar evolucao
                string retorno = qtb_reabrir.Gravar(val);
                if (st_transacao)
                    qtb_reabrir.Banco_Dados.Commit_Tran();
                return retorno;
            }
            catch (Exception ex)
            {
                if (st_transacao)
                    qtb_reabrir.Banco_Dados.RollBack_Tran();
                throw new Exception("Erro gravar evolução: " + ex.Message.Trim());
            }
            finally
            {
                if (st_transacao)
                    qtb_reabrir.deletarBanco_Dados();
            }
        }
    }
}





