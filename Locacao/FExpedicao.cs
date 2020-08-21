using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CamadaDados.Locacao.Cadastros;
using Utils;

namespace Locacao
{
    public partial class TFExpedicao : Form
    {
        public bool Altera_Relatorio = false;
        private bool St_gravar = true;
        private TRegistro_CFGLocacao rCfg;

        /// <summary>
        /// status, tipo movimentacao, E - ENTREGA, C - COLETA
        /// </summary>
        public string pTp_Mov
        { get; set; }
        public CamadaDados.Locacao.TRegistro_Locacao rLoc
        { get; set; }
        private CamadaDados.Locacao.TList_ImagensVistoria lImagens
        { get; set; }
        public CamadaDados.Locacao.TRegistro_ColetaEntrega rColEnt
        { get; set; }

        public TFExpedicao()
        {
            InitializeComponent();
            Height = Screen.PrimaryScreen.Bounds.Height - (Screen.PrimaryScreen.Bounds.Height / 10) * 1;
            Width = Screen.PrimaryScreen.Bounds.Width - (Screen.PrimaryScreen.Bounds.Width / 10) * 1;
        }

        private void afterGrava()
        {
            if (bsItens.Count > 0)
            {
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => !p.St_processar) &&
                    pTp_Mov.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Selecione um item para entrega!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (pTp_Mov.ToUpper().Equals("C") &&
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.St_processar &&
                        (p.Tp_tabela.Equals("0") ||
                         p.Tp_tabela.Equals("1")) &&
                         p.QTDItem.Equals(decimal.Zero)))
                {
                    MessageBox.Show("Necessário informar QTD de itens!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.St_processar) && pTp_Mov.ToUpper().Equals("E"))
                {
                    bool st_bloquear = false;
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Where(p => p.St_processar).ToList().ForEach(p =>
                    {
                        //Validar usabilidade de cada item selecionado/ manutencao
                        if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                             new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.DT_Finalizada",
                                        vOperador = "is",
                                        vVL_Busca = "null"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.CD_ProdutoOS",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(a.ST_OS, 'A')",
                                        vOperador = "<>",
                                        vVL_Busca = "'CA'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                    "where x.cd_patrimonio = a.CD_ProdutoOS " +
                                                    "and x.quantidade > 1 ) "
                                    }
                                }, "1") != null)
                        {
                            MessageBox.Show("Item com Nº" +
                                    p.Nr_Patrimonio + "-" +
                                    p.Ds_produto +
                                    " não está disponivel por motivo de MANUTENÇÃO!",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            st_bloquear = true;
                        }

                        //Validar usabilidade de cada item selecionado/ disponibilidade por outras locações
                        if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                            new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from VTB_LOC_LOCACAO x " +
                                                        "where a.cd_empresa = x.cd_empresa " +
                                                        "and a.id_locacao = x.ID_Locacao " +
                                                        "and x.Status in ('DEVOLUCAO EXPIRADA', 'ENTREGUE', 'ENTREGA PARCIAL')) "
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.DT_Devolucao",
                                            vOperador = "is",
                                            vVL_Busca = "null"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "isnull(loc.st_registro, '0')",
                                            vOperador = "<>",
                                            vVL_Busca = "'8'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = "a.cd_produto",
                                            vOperador = "=",
                                            vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                        },
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "not exists",
                                            vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                        "where x.cd_patrimonio = a.cd_produto " +
                                                        "and x.quantidade > 1 ) "
                                        }
                                    }, "1") != null)
                        {
                            MessageBox.Show("Item com Nº" +
                                    p.Nr_Patrimonio + "-" +
                                    p.Ds_produto +
                                    " não está disponivel!",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            st_bloquear = true;
                        }

                        //Verificar se Dt.Locação na Entrega é menor devolução realizada anteriormente
                        if (new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                                 new TpBusca[]
                                {
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.DT_Devolucao",
                                        vOperador = ">=",
                                        vVL_Busca = "'" + Convert.ToDateTime(p.Dt_locacao).ToString("yyyyMMdd HH:mm:ss") + "' or ' or a.DT_Devolucao is null"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "isnull(loc.st_registro, '0')",
                                        vOperador = "<>",
                                        vVL_Busca = "'8'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.cd_produto",
                                        vOperador = "=",
                                        vVL_Busca = "'" + p.Cd_produto.Trim() + "'"
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = "a.id_locacao",
                                        vOperador = "<>",
                                        vVL_Busca = p.Id_locacaostr
                                    },
                                    new TpBusca()
                                    {
                                        vNM_Campo = string.Empty,
                                        vOperador = "not exists",
                                        vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                                    "where x.cd_patrimonio = a.cd_produto " +
                                                    "and x.quantidade > 1 ) "
                                    }
                                }, "1") != null)
                        {
                            MessageBox.Show("Necessário alterar Dt.Locação do Item com Nº" +
                                    p.Nr_Patrimonio + "-" +
                                    p.Ds_produto + "!",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            st_bloquear = true;
                        }

                        //Validar se patrimônio selecionado possui manutenção preventiva
                        ///summary
                        ///caso o patrimônio locado tenha tabela de preço mensal, e manutenção preventiva expirada, cancela-se 
                        ///todo a evolução e abre-se automaticamente a ordem de serviço.
                        #region
                        TpBusca[] tpBuscas = new TpBusca[0];
                        Estruturas.CriarParametro(ref tpBuscas, "a.CD_ProdutoOS", "'" + p.Cd_produto + "'");
                        Estruturas.CriarParametro(ref tpBuscas, "a.ST_OS", "('FE', 'PR')", "in");
                        object dtEncerramento = new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(tpBuscas, "MAX(a.DT_Finalizada)");
                        if (dtEncerramento != null && !string.IsNullOrEmpty(dtEncerramento.ToString()))
                        {
                            tpBuscas = new TpBusca[0];
                            Estruturas.CriarParametro(ref tpBuscas, "a.NR_Patrimonio", "'" + p.Nr_Patrimonio + "'");
                            object vl_manuPorHoras = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "isnull(a.ManutHora, 0)");
                            object vl_manuPorDia = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "isnull(a.ManutDia, 0)");
                            TimeSpan intervalo = CamadaDados.UtilData.Data_Servidor().Subtract(Convert.ToDateTime(dtEncerramento.ToString()));

                            bool messege = false;
                            if (decimal.Parse(vl_manuPorHoras.ToString()) == decimal.Zero ? false : intervalo.TotalHours > Convert.ToDouble(vl_manuPorHoras))
                                messege = true;
                            else if (decimal.Parse(vl_manuPorDia.ToString()) == decimal.Zero ? false : intervalo.TotalDays > Convert.ToDouble(vl_manuPorDia))
                                messege = true;

                            if (messege)
                            {
                                MessageBox.Show("O produto de código: " + p.Cd_produto + " \n" +
                                    "Descrição: " + p.Ds_produto + " \n" +
                                    "Necessita de manutenção preventiva.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //Validar se patrimônio possui tabela de preço mensal
                                if (p.Tp_tabela.Equals("4"))
                                {
                                    using (FLocOrdemServico fNovaOrdem = new FLocOrdemServico())
                                    {
                                        CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                                        rOs.Cd_empresa = rCfg.Cd_empresa;
                                        rOs.Nm_empresa = rCfg.Nm_empresa;
                                        rOs.Tp_ordem = rCfg.Tp_ordemp;
                                        rOs.Ds_tipoordem = rCfg.Ds_tipoordem;
                                        rOs.CD_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                                        rOs.DS_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                                        rOs.Nr_patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                        rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                                        rOs.St_prioridade = "1";
                                        rOs.Ds_observacoesgerais = "MANUTENÇÃO PREVENTIVA ITEM PATRIMÔNNIO " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                        rOs.St_os = "AB";

                                        //Etapa de abertura
                                        CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                                                    new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                                        new TpBusca[]
                                                {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                }
                                                }, 1, string.Empty);
                                        if (lEtapa.Count > 0)
                                            rOs.lEvolucao.Add(
                                                new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                                {
                                                    Dt_inicio = rOs.Dt_abertura,
                                                    Id_etapa = lEtapa[0].Id_etapa,
                                                    Ds_evolucao = "ETAPA ABERTURA DA OS",
                                                    St_envterceiro = lEtapa[0].St_envterceirobool,
                                                    St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                                    St_iniciarOS = lEtapa[0].St_iniciarOSbool
                                                });
                                        else
                                            throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                                        fNovaOrdem.lanServico = rOs;
                                        if (fNovaOrdem.ShowDialog() == DialogResult.OK)
                                        {
                                            if (fNovaOrdem.lanServico != null)
                                            {
                                                CamadaNegocio.Servicos.TCN_LanServico.Gravar(fNovaOrdem.lanServico, null);
                                                MessageBox.Show("Ordem de serviço gerada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("O produto de código: " + p.Cd_produto + " \n" +
                                                    "Descrição: " + p.Ds_produto + " \n" +
                                                    "O produto possui tabela de preço com cobrança mensal. \n" +
                                                    "É obrigatório gerar manutenção preventiva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            st_bloquear = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            tpBuscas = new TpBusca[0];
                            Estruturas.CriarParametro(ref tpBuscas, "d.NR_Patrimonio", "'" + p.Nr_Patrimonio + "'");
                            object qtdHoras = new CamadaDados.Estoque.Cadastros.TCD_CadProduto().BuscarEscalar(tpBuscas, "d.Qtd_horas");
                            if (qtdHoras != null && !string.IsNullOrEmpty(qtdHoras.ToString()))
                            {
                                object vl_manuPorHoras = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutHora");
                                object vl_manuPorDia = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(tpBuscas, "a.ManutDia");
                                decimal intervalo = p.Qtd_horasAtual - Convert.ToDecimal(qtdHoras);

                                bool messege = false;
                                if (vl_manuPorHoras != null && intervalo > Convert.ToDecimal(vl_manuPorHoras))
                                    messege = true;
                                else if (vl_manuPorDia != null && (intervalo/24) > Convert.ToDecimal(vl_manuPorDia))
                                    messege = true;

                                if (messege)
                                {
                                    MessageBox.Show("O produto de código: " + p.Cd_produto + " \n" +
                                        "Descrição: " + p.Ds_produto + " \n" +
                                        "Necessita de manutenção preventiva.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    //Validar se patrimônio possui tabela de preço mensal
                                    if (p.Tp_tabela.Equals("4"))
                                    {
                                        using (FLocOrdemServico fNovaOrdem = new FLocOrdemServico())
                                        {
                                            CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                                            rOs.Cd_empresa = rCfg.Cd_empresa;
                                            rOs.Nm_empresa = rCfg.Nm_empresa;
                                            rOs.Tp_ordem = rCfg.Tp_ordemp;
                                            rOs.Ds_tipoordem = rCfg.Ds_tipoordem;
                                            rOs.CD_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                                            rOs.DS_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto;
                                            rOs.Nr_patrimonio = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                            rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                                            rOs.St_prioridade = "1";
                                            rOs.Ds_observacoesgerais = "MANUTENÇÃO PREVENTIVA ITEM PATRIMÔNNIO " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                                            rOs.St_os = "AB";

                                            //Etapa de abertura
                                            CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                                                        new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                                            new TpBusca[]
                                                    {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                }
                                                    }, 1, string.Empty);
                                            if (lEtapa.Count > 0)
                                                rOs.lEvolucao.Add(
                                                    new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                                                    {
                                                        Dt_inicio = rOs.Dt_abertura,
                                                        Id_etapa = lEtapa[0].Id_etapa,
                                                        Ds_evolucao = "ETAPA ABERTURA DA OS",
                                                        St_envterceiro = lEtapa[0].St_envterceirobool,
                                                        St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                                                        St_iniciarOS = lEtapa[0].St_iniciarOSbool
                                                    });
                                            else
                                                throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                                            fNovaOrdem.lanServico = rOs;
                                            if (fNovaOrdem.ShowDialog() == DialogResult.OK)
                                            {
                                                if (fNovaOrdem.lanServico != null)
                                                {
                                                    CamadaNegocio.Servicos.TCN_LanServico.Gravar(fNovaOrdem.lanServico, null);
                                                    MessageBox.Show("Ordem de serviço gerada com sucesso.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("O produto de código: " + p.Cd_produto + " \n" +
                                                        "Descrição: " + p.Ds_produto + " \n" +
                                                        "O produto possui tabela de preço com cobrança mensal. \n" +
                                                        "É obrigatório gerar manutenção preventiva.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                st_bloquear = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                    });
                    if (st_bloquear)
                        return;
                }

                if (rColEnt == null && pTp_Mov.ToUpper().Equals("E"))
                {
                    rColEnt = new CamadaDados.Locacao.TRegistro_ColetaEntrega();
                    rColEnt.Dt_colent = CamadaDados.UtilData.Data_Servidor();
                    rColEnt.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                    rColEnt.Tp_mov = pTp_Mov;

                    //Montar Vistoria
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p => p.St_processar).ForEach(p =>
                        rColEnt.lVistoria.Add(new CamadaDados.Locacao.TRegistro_Vistoria()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_locacao = p.Id_locacao,
                            Id_itemloc = p.Id_itemloc,
                            Login = Utils.Parametros.pubLogin,
                            Id_osstr = p.Id_os,
                            Tp_mov = pTp_Mov.ToUpper().Equals("E") ? "S" : "E",
                            Dt_vistoria = CamadaDados.UtilData.Data_Servidor(),
                            St_registro = "F"
                        }));

                    //Validar se tp. frete por empresa ou cliente
                    if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete.Equals("E"))
                    {
                        using (TFInformarVeiculo fInforme = new TFInformarVeiculo())
                        {
                            fInforme.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                            fInforme.IdLocacao = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr;
                            if (fInforme.ShowDialog() == DialogResult.OK)
                            {
                                rColEnt.Id_veiculostr = fInforme.pId_veiculo;
                                rColEnt.Cd_motorista = fInforme.pCd_motorista;
                                rColEnt.Ds_obs = fInforme.pObs;
                            }
                            else
                            {
                                MessageBox.Show("Para evoluir está etapa é obrigatório infomar veículo/ motorista.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                rColEnt = null;
                                return;
                            }
                        }
                    }
                    else
                    {
                        //Se  cliente vir Buscar marcar como entregue
                        rColEnt.Dt_retorno = CamadaDados.UtilData.Data_Servidor();
                    }
                }
                else
                {
                    //Buscar Coleta Entrega
                    CamadaDados.Locacao.TList_ColetaEntrega lColEnt =
                                    new CamadaDados.Locacao.TCD_ColetaEntrega().Select(
                                        new TpBusca[]
                                            {
                                                new TpBusca()
                                                {
                                                    vNM_Campo = string.Empty,
                                                    vOperador = "exists",
                                                    vVL_Busca = "(SELECT 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                                "where x.CD_Empresa = a.CD_Empresa " +
                                                                "and x.ID_Coleta = a.ID_Coleta " +
                                                                "and x.CD_Empresa = '" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "' " +
                                                                "and x.ID_Locacao = " + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr + " " +
                                                                "and a.TP_Mov = 'C' " +
                                                                "and a.DT_RETORNO is null) "
                                                }
                                            }, 1, string.Empty);
                    if (lColEnt.Count > 0)
                        rColEnt = lColEnt[0];
                    else
                        rColEnt = new CamadaDados.Locacao.TRegistro_ColetaEntrega();
                    rColEnt.Dt_retorno = CamadaDados.UtilData.Data_Servidor();
                    rColEnt.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                    rColEnt.Tp_mov = pTp_Mov;
                    //Montar Vistoria
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p => p.St_processar).ForEach(p =>
                        rColEnt.lVistoria.Add(new CamadaDados.Locacao.TRegistro_Vistoria()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Id_locacao = p.Id_locacao,
                            Id_itemloc = p.Id_itemloc,
                            Login = Utils.Parametros.pubLogin,
                            Id_osstr = p.Id_os,
                            Tp_mov = pTp_Mov.ToUpper().Equals("E") ? "S" : "E",
                            Dt_vistoria = CamadaDados.UtilData.Data_Servidor(),
                            St_registro = "F"
                        }));
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p => p.St_processar).ForEach(p =>
                            rColEnt.lVistoria.ForEach(x =>
                            {
                                if (x.Id_itemlocstr.Equals(p.Id_itemlocstr))
                                    x.Id_osstr = p.Id_os;
                            }));
                }
                //Adicionar Imagens
                if (lImagens.Count > 0)
                    rColEnt.lVistoria.ForEach(p =>
                        lImagens.ForEach(y =>
                        {
                            if (p.Id_itemlocstr.Equals(y.Id_itemlocstr))
                                p.lImagens.Add(new CamadaDados.Locacao.TRegistro_ImagensVistoria()
                                {
                                    Cd_empresa = y.Cd_empresa,
                                    Id_locacao = y.Id_locacao,
                                    Id_itemloc = y.Id_itemloc,
                                    Imagem = y.Imagem,
                                    Ds_obs = y.Ds_obs,
                                    Id_vistoria = p.Id_vistoria
                                });
                        }));
                try
                {
                    //Atualizar Vl.Baixa Acessorios
                    //Buscar Vl_Baixa
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                    {
                        object obj = new CamadaDados.Locacao.TCD_ItensLocacao().BuscarEscalar(
                                    new TpBusca[]
                                        {
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.cd_empresa",
                                                vOperador = "=",
                                                vVL_Busca = "'" + p.Cd_empresa.Trim() + "'"
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_locacao",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_locacaostr
                                            },
                                            new TpBusca()
                                            {
                                                vNM_Campo = "a.id_itemloc",
                                                vOperador = "=",
                                                vVL_Busca = p.Id_itemlocstr
                                            }
                                        }, "isnull(a.Vl_Baixa, 0)");
                        if (obj != null && !string.IsNullOrEmpty(obj.ToString()))
                            p.Vl_Baixa = Convert.ToDecimal(obj.ToString());
                        //Se nenhum item
                        p.lAcessorio.ForEach(x =>
                        {
                            if (x.QTD_Gasta.Equals(0))
                                x.QTD_Devolvida = x.Quantidade;
                        });
                    });
                    NovaLocacao();
                    if (St_gravar)
                    {
                        CamadaNegocio.Locacao.TCN_ColetaEntrega.Gravar(rColEnt, bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao, null);
                        MessageBox.Show(pTp_Mov.ToUpper().Equals("E") ? "Etapa evoluída com sucesso!" : "Itens Devolvidos com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Não existem itens para serem gravados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarProduto(CamadaDados.Servicos.TRegistro_LanServico rOs)
        {
            TpBusca[] filtro = new TpBusca[2];
            filtro[0].vNM_Campo = string.Empty;
            filtro[0].vOperador = "not exists";
            filtro[0].vVL_Busca = "(SELECT 1 FROM VTB_LOC_ItensLocacao x " +
                                   "inner join TB_LOC_Locacao loc " +
                                   "on x.cd_empresa = loc.cd_empresa " +
                                   "and x.id_locacao = loc.id_locacao " +
                                   "where a.cd_produto = x.cd_produto " +
                                   "and(loc.dt_locacao >= GETDATE() " +
                                   " or ISNULL(x.DT_Devolucao, case when x.DT_PrevDev < GETDATE() then GETDATE() ELSE x.DT_PrevDev end) >= GETDATE()) " +
                                   "and (loc.dt_locacao <= '" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") +
                                   "' or ISNULL(x.DT_Devolucao, case when x.DT_PrevDev < GETDATE() then GETDATE() ELSE x.DT_PrevDev end) <= '" +
                                   Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "') " +
                                   "and (isnull(loc.st_registro, '0') <> '8')) and " +
                                   "not exists(SELECT 1 FROM VTB_OSE_SERVICO y " +
                                   "           where a.cd_produto = y.CD_ProdutoOS " +
                                   "           and(y.DT_Abertura >= GETDATE() " +
                                   "           or ISNULL(y.DT_Finalizada, case when y.dt_previsao < GETDATE() OR y.dt_previsao is null then GETDATE() ELSE y.dt_previsao end) >= GETDATE()) " +
                                   "           and (y.DT_Abertura <= " +
                                   "           case when GETDATE() >= '" +
                                                        Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' " +
                                   "                    then GETDATE() ELSE '" + Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' end " +
                                   "           or ISNULL(y.DT_Finalizada, case when y.dt_previsao < GETDATE() then GETDATE() ELSE y.dt_previsao end) <= " +
                                   "                    case when GETDATE() >= '" +
                                                        Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm:ss") + "' " +
                                   "                    then GETDATE() else '" +
                                                        Convert.ToDateTime((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdevstr).ToString("yyyyMMdd HH:mm: ss") + "' end) " +
                                   "and (isnull(y.ST_OS, 'A') <> 'CA')) ";
            filtro[1].vNM_Campo = "a.cd_grupo";
            filtro[1].vOperador = "=";
            filtro[1].vVL_Busca = "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_grupo.Trim() + "'";

            CamadaDados.Estoque.Cadastros.TRegistro_CadProduto rProd = null;

            rProd = FormBusca.UtilPesquisa.BuscarProduto(string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             string.Empty,
                                                             null,
                                                             filtro);

            if (rProd != null)
            {
                //Buscar Preço
                object preco =
                    new CamadaDados.Locacao.Cadastros.TCD_CadPrecoItens().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.cd_produto",
                                vOperador = "=",
                                vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.ID_Tabela",
                                vOperador = "=",
                                vVL_Busca = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_tabelastr
                            }
                        }, "a.Vl_preco");
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).rOs = rOs != null ? rOs : null;
                CamadaDados.Locacao.TRegistro_ItensLocacao rItem = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                rItem.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                rItem.Id_locacao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacao;
                rItem.Cd_produto = rProd.CD_Produto;
                rItem.Id_tabela = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_tabela;
                rItem.Quantidade = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade;
                rItem.QTDItem = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).QTDItem;
                rItem.Vl_unitario = preco == null || string.IsNullOrEmpty(preco.ToString()) ? (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_unitario : Convert.ToDecimal(preco.ToString());
                rItem.Vl_desconto = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_desconto;
                rItem.Vl_frete = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Vl_frete;
                rItem.Dt_retirada = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_retirada;
                rItem.Dt_prevdev = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_prevdev;
                rItem.Dt_devolucao = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_devolucao;
                rItem.Dt_fechamento = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Dt_fechamento;
                rItem.St_registro = "A";
                //Verificar se patrimonio possui controle de horas
                object obj = new CamadaDados.Estoque.Cadastros.TCD_CadPatrimonio().BuscarEscalar(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_controlehora, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        },
                        new TpBusca()
                        {
                             vNM_Campo = "a.CD_Patrimonio",
                            vOperador = "=",
                            vVL_Busca = "'" + rProd.CD_Produto.Trim() + "'"
                        }
                    }, "a.qtd_horas");
                if (obj == null ? false : Convert.ToDecimal(obj.ToString()) > decimal.Zero)
                {
                    //Informar Quantidade
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Ds_label = "QTD.Horas";
                        fQtde.Vl_default = Convert.ToDecimal(obj.ToString());
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            if (fQtde.Quantidade > decimal.Zero)
                            {
                                rItem.St_controlehorabool = true;
                                rItem.Qtd_horasAtual = fQtde.Quantidade;
                                rItem.Qtd_horasRetirada = fQtde.Quantidade;
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                }
                CamadaNegocio.Locacao.TCN_ItensLocacao.TrocaItem(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao, rItem, null);
                MessageBox.Show("Troca efetuada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto = rProd.CD_Produto;
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Ds_produto = rProd.DS_Produto;
            }
        }

        private void NovaLocacao()
        {
            if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => !p.St_processar) ||
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.Qtd_Patrimonio > 1 &&
                                                                                                 p.SaldoDevolver > 0) &&
                pTp_Mov.Trim().ToUpper().Equals("C"))
            {
                using (TFNovaLocacao fLocacao = new TFNovaLocacao())
                {
                    fLocacao.pCd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                    fLocacao.pNm_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_empresa;
                    fLocacao.pCd_cliente = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_clifor;
                    fLocacao.pNm_cliente = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_clifor;
                    fLocacao.pCd_endereco = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_endereco;
                    fLocacao.pDs_endereco = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Ds_endereco;
                    fLocacao.pCd_vendedor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_vendedor;
                    fLocacao.pNm_vendedor = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_vendedor;
                    //adicionar 60 segundos para locação ser registrada depois da devolução deste patrimonio
                    fLocacao.pDt_locacao = CamadaDados.UtilData.Data_Servidor().AddSeconds(60).ToString("dd/MM/yyyy HH:mm");
                    fLocacao.pTp_frete = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Tp_frete;
                    fLocacao.pVl_frete = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Vl_frete;
                    fLocacao.pId_pessoa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_pessoastr;
                    fLocacao.pNm_pessoa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_pessoa;
                    fLocacao.pResponsavel = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Nm_responsavel;
                    fLocacao.pDs_obs = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Ds_obs;
                    CamadaDados.Locacao.TList_ItensLocacao lItens = new CamadaDados.Locacao.TList_ItensLocacao();
                    //Itens não devolvidos
                    if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => !p.St_processar))
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p => !p.St_processar).ForEach(p =>
                            {
                                lItens.Add(new CamadaDados.Locacao.TRegistro_ItensLocacao()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_produto = p.Cd_produto,
                                    Nr_Patrimonio = p.Nr_Patrimonio,
                                    Ds_produto = p.Ds_produto,
                                    Id_tabela = p.Id_tabela,
                                    Ds_tabela = p.Ds_tabela,
                                    Cd_grupo = p.Cd_grupo,
                                    Ds_grupo = p.Ds_grupo,
                                    Qtd_Patrimonio = p.Qtd_Patrimonio,
                                    QTDItem = p.SaldoDevolver,
                                    Vl_unitario = p.Vl_unitario,
                                    Vl_desconto = p.Vl_desconto,
                                    Qtd_horasRetirada = p.Qtd_horasDevolucao,
                                    //adicionar 80 segundos para locação ser registrada depois da devolução deste patrimonio
                                    Dt_retirada = CamadaDados.UtilData.Data_Servidor().AddSeconds(80)
                                });
                            });
                    //Itens devolvidos parcialmente
                    if ((bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.Exists(p => p.St_processar && p.SaldoDevolver > decimal.Zero && p.QTDItem > 1))
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p => p.St_processar && p.SaldoDevolver > decimal.Zero && p.QTDItem > 1).ForEach(p =>
                            {
                                lItens.Add(new CamadaDados.Locacao.TRegistro_ItensLocacao()
                                {
                                    Cd_empresa = p.Cd_empresa,
                                    Cd_produto = p.Cd_produto,
                                    Nr_Patrimonio = p.Nr_Patrimonio,
                                    Ds_produto = p.Ds_produto,
                                    Id_tabela = p.Id_tabela,
                                    Ds_tabela = p.Ds_tabela,
                                    Cd_grupo = p.Cd_grupo,
                                    Ds_grupo = p.Ds_grupo,
                                    Qtd_Patrimonio = p.Qtd_Patrimonio,
                                    QTDItem = p.SaldoDevolver,
                                    Vl_unitario = p.Vl_unitario,
                                    Vl_desconto = p.Vl_desconto,
                                    Qtd_horasRetirada = p.Qtd_horasDevolucao,
                                    //adicionar 80 segundos para locação ser registrada depois da devolução deste patrimonio
                                    Dt_retirada = CamadaDados.UtilData.Data_Servidor().AddSeconds(80)
                                });
                            });
                    if (lItens.Count > decimal.Zero)
                    {
                        //Devolver Todos os itens 
                        (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                        {
                            p.St_processar = true;
                            if (p.QTDItem > 1)
                                p.Qtd_devolver = p.QTDItem;
                        });
                        DialogResult dialog = InputBox("Pergunta", "Devolução realizada parcialmente, escolha uma das opções abaixo pra prosseguir:");
                        if (dialog == DialogResult.Yes)
                        {
                            fLocacao.lItens = lItens;
                            if (fLocacao.ShowDialog() == DialogResult.OK)
                                if (fLocacao.rLocacao != null)
                                    try
                                    {
                                        CamadaNegocio.Locacao.TCN_Locacao.Gravar(fLocacao.rLocacao, null);
                                        PrintOrdemLocacao(fLocacao.rLocacao);
                                        St_gravar = true;
                                    }
                                    catch (Exception ex)
                                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                                else
                                {
                                    MessageBox.Show("Obrigatório gravar nova locação para confirmar devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    St_gravar = false;
                                }
                            else
                            {
                                MessageBox.Show("Obrigatório gravar nova locação para confirmar devolução!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                St_gravar = false;
                            }
                        }
                        else if (dialog == DialogResult.No)
                        {
                            //Marcar Itens a serem baixados
                            (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                                p.St_baixa = lItens.Exists(x => x.Cd_produto.Equals(p.Cd_produto)));
                            St_gravar = true;
                        }
                        else
                        {
                            MessageBox.Show("Obrigatório informar uma das opções!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            St_gravar = false;
                        }
                    }
                }
            }
        }

        private void PrintOrdemLocacao(CamadaDados.Locacao.TRegistro_Locacao val)
        {
            if (bsLocacao.Current != null)
            {
                if (val.St_registro.Trim().Equals("8"))
                {
                    MessageBox.Show("Não é permitido Imprimir contrato de locação CANCELADA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs_valor = new BindingSource();
                    bs_valor.DataSource = new CamadaDados.Locacao.TList_Locacao() { val };
                    Rel.DTS_Relatorio = bs_valor;
                    Rel.Ident = "TFLanLocacao_OrdemLoc";
                    Rel.NM_Classe = "TFLanLocacao_OrdemLoc";
                    Rel.Modulo = "LOC";
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "ORDEM LOCAÇÃO";
                    //Valor extenso VL.Patrimonio
                    string vl_patrimonio =
                        new Extenso().ValorExtenso(val.lItens.Sum(p => p.Vl_patrimonio), "Real", "Reais");
                    decimal tot_patrimonio = val.lItens.Sum(p => p.Vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("VL_PATRIMONIO", vl_patrimonio);
                    Rel.Parametros_Relatorio.Add("TOT_PATRIMONIO", tot_patrimonio.ToString("N2", new System.Globalization.CultureInfo("pt-BR")));

                    //Chave Acesso
                    val.ChaveAcesso = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr.FormatStringEsquerda(44, '0');
                    //Buscar clifor da empresa
                    BindingSource bs_cliforemp = new BindingSource();
                    bs_cliforemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadClifor().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x "+
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_CliforEmp", bs_cliforemp);
                    //Buscar Endereco Empresa
                    BindingSource bs_endemp = new BindingSource();
                    bs_endemp.DataSource = new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco().Select(
                        new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_div_empresa x " +
                                                "where x.cd_clifor = a.cd_clifor "+
                                                "and x.cd_endereco = a.cd_endereco "+
                                                "and x.cd_empresa = '" + val.Cd_empresa.Trim() + "')"
                                }
                            }, 0, string.Empty);
                    Rel.Adiciona_DataSource("DTS_EndEmp", bs_endemp);
                    //Buscar Cliente da Locacao
                    BindingSource bs_CliforLocacao = new BindingSource();
                    bs_CliforLocacao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Busca_Clifor(val.Cd_clifor,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                false,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                string.Empty,
                                                                                                                0,
                                                                                                                null);
                    Rel.Adiciona_DataSource("DTS_CliforLocacao", bs_CliforLocacao);
                    //Buscar Endereco do Clifor
                    BindingSource bs_endClifor = new BindingSource();
                    bs_endClifor.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(val.Cd_clifor,
                                                                                                        val.Cd_endereco,
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
                                                                                                        0,
                                                                                                        null);
                    Rel.Adiciona_DataSource("DTS_endClifor", bs_endClifor);
                    //Buscar dados Empresa
                    CamadaDados.Diversos.TList_CadEmpresa lEmpresa =
                        CamadaNegocio.Diversos.TCN_CadEmpresa.Busca(val.Cd_empresa,
                                                                    string.Empty,
                                                                    string.Empty,
                                                                    null);
                    if (lEmpresa.Count > 0)
                        if (lEmpresa[0].Img != null)
                            Rel.Parametros_Relatorio.Add("IMAGEM_RELATORIO", lEmpresa[0].Img);

                    if (Altera_Relatorio)
                    {
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ORDEM LOCAÇÃO",
                                           fImp.pDs_mensagem);
                        Altera_Relatorio = false;
                    }
                    else
                        if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                        Rel.Gera_Relatorio(string.Empty,
                                           fImp.pSt_imprimir,
                                           fImp.pSt_visualizar,
                                           fImp.pSt_enviaremail,
                                           fImp.pSt_exportPdf,
                                           fImp.Path_exportPdf,
                                           fImp.pDestinatarios,
                                           null,
                                           "ORDEM LOCAÇÃO",
                                           fImp.pDs_mensagem);
                }


            }
            else
                MessageBox.Show("Obrigatório selecionar locação para imprimir contrato.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void VisualizarHist()
        {
            using (TFHistorico fHist = new TFHistorico())
            {
                fHist.pDs_mensagem = (bsHistorico.Current as CamadaDados.Locacao.TRegistro_Historico).Ds_historico;
                fHist.St_visualizar = true;
                fHist.ShowDialog();
            }
        }

        private void TFExpedicao_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            if (rLoc != null)
            {
                //Buscar Histórico
                rLoc.lHist =
                CamadaNegocio.Locacao.TCN_Historico.buscar(rLoc.Cd_empresa,
                                                           rLoc.Id_locacaostr,
                                                           string.Empty,
                                                           null);
                if (rLoc.lHist.Count > 0)
                    tlpItens.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 400);
                else
                    tlpItens.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
                bsLocacao.DataSource = new CamadaDados.Locacao.TList_Locacao() { rLoc };
                if (pTp_Mov.ToUpper().Equals("C"))
                {
                    //Buscar Itens disponiveis para devolucao
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens =
                        new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_locacao",
                                    vOperador = "=",
                                    vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.dt_devolucao",
                                    vOperador = "is",
                                    vVL_Busca = "null or ((isnull(a.qtditem - a.Qtd_devolvida, 0) > 0)) "
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.ST_Registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 0, string.Empty, false);
                }
                else
                {
                    bb_baixaAcessorio.Visible = false;
                    bb_qtd.Visible = false;
                    //Buscar Itens disponiveis para entrega
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens =
                        new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                            new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "a.cd_empresa",
                                    vOperador = "=",
                                    vVL_Busca = "'" + (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa.Trim() + "'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.id_locacao",
                                    vOperador = "=",
                                    vVL_Busca = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacaostr
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "a.dt_retirada",
                                    vOperador = "is",
                                    vVL_Busca = "null"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.ST_Registro, 'A')",
                                    vOperador = "<>",
                                    vVL_Busca = "'C'"
                                }
                            }, 0, string.Empty, false);
                }
                if (bsItens.Current != null)
                {
                    //Buscar Acessorios
                    (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p =>
                        p.lAcessorio = CamadaNegocio.Locacao.TCN_AcessoriosItem.buscar(p.Cd_empresa,
                                                                                       p.Id_locacaostr,
                                                                                       p.Id_itemlocstr,
                                                                                       string.Empty,
                                                                                       null));
                }
                lImagens = new CamadaDados.Locacao.TList_ImagensVistoria();
            }

            TList_CFGLocacao lCfg = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar(string.Empty, string.Empty, null);
            if (lCfg == null || lCfg.Count.Equals(0))
            {
                MessageBox.Show("Não existe CFG.Locação para empresa", "Mensagem",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                rCfg = lCfg[0];
            }

            bsLocacao.ResetCurrentItem();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cbTodos_Click(object sender, EventArgs e)
        {
            if (bsItens.Count > 0)
            {
                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.ForEach(p => p.St_processar = cbTodos.Checked);
                bsItens.ResetBindings(true);
            }
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFExpedicao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar =
                    !(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar;
                if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar)
                {
                    //Verificar se patrimonio possui controle de horas
                    if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_controlehorabool)
                    {
                        //Informar Quantidade
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "QTD.Horas";
                            fQtde.Vl_default = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasAtual;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (fQtde.Quantidade > decimal.Zero)
                                {
                                    if (pTp_Mov.Trim().ToUpper().Equals("E"))
                                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasRetirada = fQtde.Quantidade;
                                    else
                                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasDevolucao = fQtde.Quantidade;
                                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasAtual = fQtde.Quantidade;
                                    //se controle for por horas e tabela preço for hora calcular pelo horimetro.
                                    if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Tp_tabela.Equals("2") &&
                                        pTp_Mov.Trim().ToUpper().Equals("C"))
                                    {
                                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade =
                                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasDevolucao -
                                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_horasRetirada;
                                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).BaseCalc =
                                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Quantidade;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar quantidade de horas para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    //Verificar se patrimonio possui QUANTIDADE
                    if ((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_Patrimonio > 1 && pTp_Mov.Trim().ToUpper().Equals("C"))
                    {
                        //Informar Quantidade
                        using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                        {
                            fQtde.Ds_label = "QTD.Devolver";
                            fQtde.Vl_default = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).SaldoDevolver;
                            if (fQtde.ShowDialog() == DialogResult.OK)
                            {
                                if (fQtde.Quantidade > (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).SaldoDevolver)
                                {
                                    MessageBox.Show("Quantidade informada maior que saldo à devolver!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar = false;
                                }
                                if (fQtde.Quantidade > decimal.Zero)
                                {
                                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_devolver = fQtde.Quantidade;
                                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Qtd_devolvida += fQtde.Quantidade;
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatório informar quantidade para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar = false;
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Obrigatório informar quantidade para patrimônio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar = false;
                                return;
                            }
                        }
                    }
                }
                bsItens.ResetCurrentItem();
            }
        }

        private void btn_InserirFotos_Click(object sender, EventArgs e)
        {
            try
            {
                if (bsItens.Current != null)
                {
                    if (!(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar)
                    {
                        MessageBox.Show("Necessário marcar o item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    InputBox ibp = new InputBox();
                    ibp.Text = "Descrição Imagem";
                    string ds = ibp.ShowDialog();
                    if (string.IsNullOrEmpty(ds))
                    {
                        MessageBox.Show("Obrigatório informar Descrição da imagem!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            lImagens.Add(new CamadaDados.Locacao.TRegistro_ImagensVistoria()
                            {
                                Id_locacaostr = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr,
                                Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa,
                                Id_itemlocstr = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_itemlocstr,
                                Ds_obs = ds,
                                Imagem = Image.FromFile(ofd.FileName)
                            });
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btn_manutecao_Click(object sender, EventArgs e)
        {
            if (bsItens.Current != null)
            {
                if (new CamadaDados.Servicos.TCD_LanServico().BuscarEscalar(
                        new TpBusca[]
                        {
                            new TpBusca()
                            {
                                vNM_Campo = "a.CD_ProdutoOS",
                                vOperador = "=",
                                vVL_Busca = "'" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto.Trim() + "'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "a.dt_finalizada",
                                vOperador = "is",
                                vVL_Busca = "null"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = "isnull(a.st_os, 'AB')",
                                vOperador = "<>",
                                vVL_Busca = "'CA'"
                            },
                            new TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "not exists",
                                vVL_Busca = "(select 1 from TB_EST_Patrimonio x " +
                                            "where x.cd_patrimonio = a.CD_ProdutoOS " +
                                            "and x.quantidade > 1 ) "
                            }
                        }, "1") != null)
                {
                    MessageBox.Show("Existem manutenções não finalizadas para este Patrimônio!\r\n" +
                                    "Consulte a tela de Ordem de serviço e verifique para continuar!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).St_processar)
                {
                    MessageBox.Show("Necessário marcar o item!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CamadaDados.Locacao.Cadastros.TRegistro_CFGLocacao rCfg = new CamadaDados.Locacao.Cadastros.TRegistro_CFGLocacao();
                rCfg = CamadaNegocio.Locacao.Cadastros.TCN_CFGLocacao.buscar((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa, string.Empty, null)[0];
                if (rCfg == null)
                {
                    MessageBox.Show("Não existe CFG.Locação para empresa Nº" + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa.Trim(), "Mensagem",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CamadaDados.Servicos.TRegistro_LanServico rOs = new CamadaDados.Servicos.TRegistro_LanServico();
                rOs.Cd_empresa = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa;
                rOs.Tp_ordem = rCfg.Tp_ordem;
                rOs.CD_ProdutoOS = (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_produto;
                rOs.Dt_abertura = CamadaDados.UtilData.Data_Servidor();
                rOs.St_prioridade = "1";
                rOs.Ds_observacoesgerais = "MANUTENÇÃO ITEM PATRIMÔNNIO " + (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio;
                rOs.St_os = "AB";

                //Etapa de abertura
                CamadaDados.Servicos.Cadastros.TList_EtapaOrdem lEtapa =
                            new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().Select(
                                new TpBusca[]
                            {
                                new TpBusca()
                                {
                                    vNM_Campo = "isnull(a.st_iniciarOS, 'N')",
                                    vOperador = "=",
                                    vVL_Busca = "'S'"
                                },
                                new TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from tb_ose_tpordem_x_etapa x "+
                                                "where x.id_etapa = a.id_etapa "+
                                                "and x.tp_ordem = " + rCfg.Tp_ordemstr + ")"
                                }
                            }, 1, string.Empty);
                if (lEtapa.Count > 0)
                    rOs.lEvolucao.Add(
                        new CamadaDados.Servicos.TRegistro_LanServicoEvolucao()
                        {
                            Dt_inicio = rOs.Dt_abertura,
                            Id_etapa = lEtapa[0].Id_etapa,
                            Ds_evolucao = "ETAPA ABERTURA DA OS",
                            St_envterceiro = lEtapa[0].St_envterceirobool,
                            St_finalizarOS = lEtapa[0].St_finalizarOSbool,
                            St_iniciarOS = lEtapa[0].St_iniciarOSbool
                        });
                else
                    throw new Exception("Não existe etapa de ABERTURA configurada para o tipo de ordem " + rCfg.Tp_ordemstr);

                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lItens.FindAll(p => p.St_processar).ForEach(p => p.Id_os = rOs.Id_osstr);
                if (bsItens.Count.Equals(0) ? true : MessageBox.Show("Deseja substituir o item desta Locação?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                       == DialogResult.Yes)
                    try
                    {
                        BuscarProduto(rOs);
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_qtd_Click(object sender, EventArgs e)
        {
            if (bsAcessorios.Current != null)
                if ((bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo > decimal.Zero)
                {
                    //Inserir QTD 
                    using (Componentes.TFQuantidade fQtde = new Componentes.TFQuantidade())
                    {
                        fQtde.Vl_default = (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo;
                        fQtde.Ds_label = "Quantidade";
                        fQtde.St_permitirValorZero = true;
                        if (fQtde.ShowDialog() == DialogResult.OK)
                        {
                            //Calcular Qtd.Gasta
                            (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).QTD_Gasta =
                                (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo - fQtde.Quantidade;
                            (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).QTD_Devolvida = fQtde.Quantidade;
                            bsAcessorios.ResetCurrentItem();
                        }
                    }
                }
                else MessageBox.Show("Acessório sem saldo para devolver.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_baixaAcessorio_Click(object sender, EventArgs e)
        {
            if (bsAcessorios.Current != null)
                if ((bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo > decimal.Zero)
                {
                    try
                    {
                        using (Componentes.TFQuantidade fQtd = new Componentes.TFQuantidade())
                        {
                            fQtd.Text = "QTD. Baixa";
                            fQtd.Vl_default = (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_saldo;
                            if (fQtd.ShowDialog() == DialogResult.OK)
                                if (fQtd.Quantidade > decimal.Zero)
                                    (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Qtd_baixa =
                                        fQtd.Quantidade;
                                else
                                {
                                    MessageBox.Show("Obrigatório informar QTD.Baixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Obrigatório informar QTD.Baixa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        InputBox ibp = new InputBox();
                        ibp.Text = "Motivo Baixa";
                        string motivo = ibp.ShowDialog();
                        if (string.IsNullOrEmpty(motivo))
                        {
                            MessageBox.Show("Obrigatório informar motivo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        (bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem).Obs = motivo;
                        CamadaNegocio.Locacao.TCN_AcessoriosItem.BaixarAcessorios(bsAcessorios.Current as CamadaDados.Locacao.TRegistro_AcessoriosItem, null);
                        MessageBox.Show("Acessório baixado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).lAcessorio =
                            CamadaNegocio.Locacao.TCN_AcessoriosItem.buscar((bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Cd_empresa,
                                                                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_locacaostr,
                                                                            (bsItens.Current as CamadaDados.Locacao.TRegistro_ItensLocacao).Id_itemlocstr,
                                                                            string.Empty,
                                                                            null);
                        bsItens.ResetCurrentItem();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else MessageBox.Show("Acessório sem saldo para baixar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gAcessorios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("BAIXADO"))
                        gAcessorios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gAcessorios.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        public static DialogResult InputBox(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            Button buttonIncluir = new Button();
            Button buttonRelacionar = new Button();

            form.Text = title;
            label.Text = promptText;
            label.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);

            buttonIncluir.Text = "NOVA LOCAÇÃO";
            buttonRelacionar.Text = "BAIXAR PATRIMÕNIO";
            buttonIncluir.DialogResult = DialogResult.Yes;
            buttonRelacionar.DialogResult = DialogResult.No;

            label.SetBounds(9, 20, 372, 13);
            buttonIncluir.SetBounds(0, 55, 150, 35);
            buttonRelacionar.SetBounds(160, 55, 150, 35);
            buttonIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            buttonRelacionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);

            label.AutoSize = true;
            buttonIncluir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonRelacionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonIncluir, buttonRelacionar });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.CancelButton = buttonIncluir;
            form.CancelButton = buttonRelacionar;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            if (bsLocacao.Current != null)
                using (TFHistorico fHist = new TFHistorico())
                {
                    if (fHist.ShowDialog() == DialogResult.OK)
                        if (!string.IsNullOrEmpty(fHist.pDs_mensagem))
                            try
                            {
                                CamadaDados.Locacao.TRegistro_Historico rHist =
                                    new CamadaDados.Locacao.TRegistro_Historico();
                                rHist.Cd_empresa = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Cd_empresa;
                                rHist.Id_locacao = (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).Id_locacao;
                                rHist.Login = Utils.Parametros.pubLogin;
                                rHist.Dt_historico = CamadaDados.UtilData.Data_Servidor();
                                rHist.Ds_historico = fHist.pDs_mensagem;
                                CamadaNegocio.Locacao.TCN_Historico.Gravar(rHist, null);
                                MessageBox.Show("Histórico gravado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsLocacao.Current as CamadaDados.Locacao.TRegistro_Locacao).lHist.Add(rHist);
                                bsLocacao.ResetCurrentItem();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_visualizar_Click(object sender, EventArgs e)
        {
            VisualizarHist();
        }

        private void gHist_DoubleClick(object sender, EventArgs e)
        {
            VisualizarHist();
        }
    }
}
