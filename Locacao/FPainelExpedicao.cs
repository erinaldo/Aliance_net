using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Locacao
{
    public partial class TFPainelExpedicao : Form
    {
        private bool Rotacao = true;
        private int TamanhoGrade = 3;
        private int Velocidade = 15;
        private int ControleExposicao = 0;
        private string grid0Nome = string.Empty;
        private string grid1Nome = string.Empty;
        private string grid2Nome = string.Empty;
        private string grid3Nome = string.Empty;
        private Componentes.DataGridDefault dataGrid0 = new Componentes.DataGridDefault();
        private Componentes.DataGridDefault dataGrid1 = new Componentes.DataGridDefault();
        private Componentes.DataGridDefault dataGrid2 = new Componentes.DataGridDefault();
        private Componentes.DataGridDefault dataGrid3 = new Componentes.DataGridDefault();
        private string tpOrdem = string.Empty;
        private string tpOrdemP = string.Empty;
        private List<CamadaDados.Locacao.TRegistro_ItensLocacao> lItens = new List<CamadaDados.Locacao.TRegistro_ItensLocacao>();
        private CamadaDados.Locacao.TList_PainelExp _PainelExps = new CamadaDados.Locacao.TList_PainelExp();
        private CamadaDados.Servicos.TList_LanServico _LanServicos = new CamadaDados.Servicos.TList_LanServico();


        public TFPainelExpedicao()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            AtualizarTicket.Stop();

            //Buscar quantidade de lancamentos por status
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            Utils.Estruturas.CriarParametro(ref filtro, string.Empty, "(select 1 from TB_LOC_CfgLocacao x where a.cd_empresa = x.cd_empresa) ", "exists");
            Utils.Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'D'", "<>");
            Utils.Estruturas.CriarParametro(ref filtro, "isnull(a.st_registro, 'A')", "'C'", "<>");
            _PainelExps = new CamadaDados.Locacao.TCD_PainelExp().Select(filtro, 0, string.Empty);
            bsPainelExp.DataSource = _PainelExps;

            lItens = new CamadaDados.Locacao.TCD_ItensLocacao().Select(
            new Utils.TpBusca[]
            {
                new Utils.TpBusca()
                {
                    vNM_Campo = "a.dt_devolucao",
                    vOperador = "is",
                    vVL_Busca = "null"
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = string.Empty,
                    vOperador = "exists",
                    vVL_Busca = "(select 1 from tb_loc_locacao x " +
                                "where a.cd_empresa = x.cd_empresa " +
                                "and a.id_locacao = x.id_locacao " +
                                "and isnull(x.st_registro, 'A') <> 'C') "
                },
                new Utils.TpBusca()
                {
                    vNM_Campo = "loc.dt_locacao",
                    vOperador = ">",
                    vVL_Busca = "DATEADD(YEAR, -2, GETDATE())"
                }
            }, 0, string.Empty, true);

            Utils.TpBusca[] tpBusca = new Utils.TpBusca[0];
            Utils.Estruturas.CriarParametro(ref tpBusca, "a.st_os", "'AB'");
            _LanServicos = new CamadaDados.Servicos.TCD_LanServico().Select(tpBusca, 0, string.Empty, string.Empty);


            if (lItens.Count > 0)
            {
                # region Aguardando Expedicao
                CamadaDados.Locacao.TList_ItensLocacao lItensLoc = new CamadaDados.Locacao.TList_ItensLocacao();
                lbAgExpedicao.Text = lbAgExpedicao.Tag + " " + lItens.FindAll(p => string.IsNullOrEmpty(p.Dt_retiradastr) && p.Dt_locacao <= CamadaDados.UtilData.Data_Servidor().AddDays(2)).Count.ToString();
                lItens.FindAll(p => string.IsNullOrEmpty(p.Dt_retiradastr) && p.Dt_locacao <= CamadaDados.UtilData.Data_Servidor().AddDays(2)).OrderBy(x => x.Dt_locacao).ToList().ForEach(p =>
                {
                    if (lItensLoc.Count.Equals(0) || !lItensLoc.Exists(x => x.Ds_tabela.Equals(p.Nm_clifor)))
                    {
                        CamadaDados.Locacao.TRegistro_ItensLocacao r =
                            new CamadaDados.Locacao.TRegistro_ItensLocacao();
                        r.Ds_produto = p.Nm_clifor;
                        r.Dt_locacao = null;
                        r.Dt_locacaostr = string.Empty;
                        lItensLoc.Add(r);
                    }
                    lItensLoc.Add(p);
                });

                (bsPainelExp.Current as CamadaDados.Locacao.TRegistro_PainelExp).lAgExpedicao = lItensLoc;
                #endregion             

                #region Aguardando entrega
                lItensLoc = new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.dt_devolucao",
                            vOperador = "is",
                            vVL_Busca = "null"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_loc_locacao x " +
                                        "where a.cd_empresa = x.cd_empresa " +
                                        "and a.id_locacao = x.id_locacao " +
                                        "and isnull(x.st_registro, 'C') = 'P') "
                        }
                    }, 0, string.Empty, true);
                lbAgEntrega.Text = lbAgEntrega.Tag + " " + lItensLoc.Count.ToString();
                CamadaDados.Locacao.TList_ItensLocacao lItensAux = new CamadaDados.Locacao.TList_ItensLocacao();
                lItensLoc.OrderBy(i => i.Dt_locacao).ToList().ForEach(i =>
                {
                    //Cliente
                    CamadaDados.Locacao.TRegistro_ItensLocacao r = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Ds_produto = i.Nm_clifor;
                    r.Dt_locacao = null;
                    r.Dt_locacaostr = string.Empty;
                    lItensAux.Add(r);

                    //Motorista
                    object Nm_motorista = new CamadaDados.Locacao.TCD_ColetaEntrega().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.ID_Coleta = x.ID_Coleta " +
                                            "and x.cd_empresa = '" + i.Cd_empresa.Trim() + "'" +
                                            "and x.id_locacao = " + i.Id_locacaostr + ") "
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_mov",
                                vOperador = "=",
                                vVL_Busca = "'E'"
                            }
                        }, "c.nm_clifor");
                    if (Nm_motorista != null && !string.IsNullOrEmpty(Nm_motorista.ToString()))
                    {
                        CamadaDados.Locacao.TRegistro_ItensLocacao m =
                        new CamadaDados.Locacao.TRegistro_ItensLocacao();
                        m.Ds_produto = Nm_motorista.ToString();
                        m.Dt_locacao = null;
                        m.Dt_locacaostr = string.Empty;
                        lItensAux.Add(m);
                    }

                    //Patrimonio
                    lItensAux.Add(i);
                });
                (bsPainelExp.Current as CamadaDados.Locacao.TRegistro_PainelExp).lAgEntregaa = lItensAux;
                #endregion

                #region Em Entrega
                lItensLoc = new CamadaDados.Locacao.TList_ItensLocacao();
                lItensAux.ForEach(x =>
                {
                    lItens.ForEach(y =>
                    {
                        if (x.Id_locacao.Equals(y.Id_locacao) && y.St_entregabool)
                        {
                            y.St_entregabool = false;
                        }
                    });
                });
                lbEmEntrega.Text = lbEmEntrega.Tag + " " + lItens.FindAll(p => p.St_entregabool).Count.ToString();
                lItens.FindAll(p => p.St_entregabool).ForEach(p =>
                {
                    if (lItensLoc.Count.Equals(0) || !lItensLoc.Exists(x => x.Ds_tabela.Equals(p.Nm_clifor)))
                    {
                        CamadaDados.Locacao.TRegistro_ItensLocacao r = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                        r.Ds_produto = p.Nm_clifor;
                        r.Dt_locacao = null;
                        r.Dt_locacaostr = string.Empty;
                        lItensLoc.Add(r);

                        //Motorista
                        object Nm_motorista = new CamadaDados.Locacao.TCD_ColetaEntrega().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                "where a.cd_empresa = x.cd_empresa " +
                                                "and a.ID_Coleta = x.ID_Coleta " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "'" +
                                                "and x.id_locacao = " + p.Id_locacaostr + ") "
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'E'"
                                }
                            }, "c.nm_clifor");
                        if (Nm_motorista != null && !string.IsNullOrEmpty(Nm_motorista.ToString()))
                        {
                            CamadaDados.Locacao.TRegistro_ItensLocacao m =
                            new CamadaDados.Locacao.TRegistro_ItensLocacao();
                            m.Ds_produto = Nm_motorista.ToString();
                            m.Dt_locacao = null;
                            m.Dt_locacaostr = string.Empty;
                            lItensLoc.Add(m);
                        }
                    }
                    lItensLoc.Add(p);
                });
                (bsPainelExp.Current as CamadaDados.Locacao.TRegistro_PainelExp).lEmEntrega = lItensLoc;
                #endregion

                #region  Disponivel para coleta
                lItensLoc = new CamadaDados.Locacao.TList_ItensLocacao();
                lbDispColeta.Text = lbDispColeta.Tag + " " + lItens.FindAll(p => !string.IsNullOrEmpty(p.Dt_fechamentostr)).Count.ToString();
                lItens.FindAll(p => !string.IsNullOrEmpty(p.Dt_fechamentostr)).ForEach(p =>
                {
                    //Cliente
                    CamadaDados.Locacao.TRegistro_ItensLocacao r =
                        new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Ds_produto = p.Nm_clifor;
                    r.Dt_locacao = null;
                    r.Dt_locacaostr = string.Empty;
                    lItensLoc.Add(r);

                    //Patrimonio
                    lItensLoc.Add(p);
                });
                (bsPainelExp.Current as CamadaDados.Locacao.TRegistro_PainelExp).lDispColeta = lItensLoc;
                #endregion

                #region Aguardando coleta
                lItensLoc = new CamadaDados.Locacao.TCD_ItensLocacao().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "a.dt_devolucao",
                            vOperador = "is",
                            vVL_Busca = "null"
                        },
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_loc_locacao x " +
                                        "where a.cd_empresa = x.cd_empresa " +
                                        "and a.id_locacao = x.id_locacao " +
                                        "and isnull(x.st_registro, 'C') = 'R') "
                        }
                    }, 0, string.Empty, true);
                lbAgColeta.Text = lbAgColeta.Tag + " " + lItensLoc.Count.ToString();
                lItensAux = new CamadaDados.Locacao.TList_ItensLocacao();
                lItensLoc.ForEach(i =>
                {
                    //Cliente
                    CamadaDados.Locacao.TRegistro_ItensLocacao r =
                        new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Ds_produto = i.Nm_clifor;
                    r.Dt_locacao = null;
                    r.Dt_locacaostr = string.Empty;
                    lItensAux.Add(r);

                    //Motorista
                    object Nm_motorista = new CamadaDados.Locacao.TCD_ColetaEntrega().BuscarEscalar(
                        new Utils.TpBusca[]
                        {
                            new Utils.TpBusca()
                            {
                                vNM_Campo = string.Empty,
                                vOperador = "exists",
                                vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                            "where a.cd_empresa = x.cd_empresa " +
                                            "and a.ID_Coleta = x.ID_Coleta " +
                                            "and x.cd_empresa = '" + i.Cd_empresa.Trim() + "'" +
                                            "and x.id_locacao = " + i.Id_locacaostr + ") "
                            },
                            new Utils.TpBusca()
                            {
                                vNM_Campo = "a.tp_mov",
                                vOperador = "=",
                                vVL_Busca = "'C'"
                            }
                        }, "c.nm_clifor");
                    if (Nm_motorista != null && !string.IsNullOrEmpty(Nm_motorista.ToString()))
                    {
                        CamadaDados.Locacao.TRegistro_ItensLocacao m =
                        new CamadaDados.Locacao.TRegistro_ItensLocacao();
                        m.Ds_produto = Nm_motorista.ToString();
                        m.Dt_locacao = null;
                        m.Dt_locacaostr = string.Empty;
                        lItensAux.Add(m);
                    }

                    //Patrimonio
                    lItensAux.Add(i);
                });
                (bsPainelExp.Current as CamadaDados.Locacao.TRegistro_PainelExp).lAgColeta = lItensAux;
                #endregion

                #region Buscar Em Coleta
                lbEmColeta.Text = lbEmColeta.Tag + " " + lItens.FindAll(p => p.St_coletabool).Count.ToString();
                lItensLoc = new CamadaDados.Locacao.TList_ItensLocacao();
                lItens.FindAll(p => p.St_coletabool).ForEach(p =>
                {
                    if (lItensLoc.Count.Equals(0) || !lItensLoc.Exists(x => x.Ds_tabela.Equals(p.Nm_clifor)))
                    {
                        CamadaDados.Locacao.TRegistro_ItensLocacao r =
                            new CamadaDados.Locacao.TRegistro_ItensLocacao();
                        r.Ds_produto = p.Nm_clifor;
                        r.Dt_locacao = null;
                        r.Dt_locacaostr = string.Empty;
                        lItensLoc.Add(r);

                        //Motorista
                        object Nm_motorista = new CamadaDados.Locacao.TCD_ColetaEntrega().BuscarEscalar(
                            new Utils.TpBusca[]
                            {
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = string.Empty,
                                    vOperador = "exists",
                                    vVL_Busca = "(select 1 from TB_LOC_Vistoria_X_ColEnt x " +
                                                "where a.cd_empresa = x.cd_empresa " +
                                                "and a.ID_Coleta = x.ID_Coleta " +
                                                "and x.cd_empresa = '" + p.Cd_empresa.Trim() + "'" +
                                                "and x.id_locacao = " + p.Id_locacaostr + ") "
                                },
                                new Utils.TpBusca()
                                {
                                    vNM_Campo = "a.tp_mov",
                                    vOperador = "=",
                                    vVL_Busca = "'E'"
                                }
                            }, "c.nm_clifor");
                        if (Nm_motorista != null && !string.IsNullOrEmpty(Nm_motorista.ToString()))
                        {
                            CamadaDados.Locacao.TRegistro_ItensLocacao m =
                            new CamadaDados.Locacao.TRegistro_ItensLocacao();
                            m.Ds_produto = Nm_motorista.ToString();
                            m.Dt_locacao = null;
                            m.Dt_locacaostr = string.Empty;
                            lItensAux.Add(m);
                        }
                    }
                    lItensLoc.Add(p);
                });
                (bsPainelExp.Current as CamadaDados.Locacao.TRegistro_PainelExp).lEmColeta = lItensLoc;
                #endregion

                #region Manutenção Corretiva
                List<CamadaDados.Servicos.TRegistro_LanServico> _LanServicosC = _LanServicos.FindAll(p => p.Tp_ordemstr.Equals(tpOrdem)).ToList();
                lbManCorretiva.Text = lbManCorretiva.Tag + " " + _LanServicosC.Count;
                _LanServicosC.ForEach(l => 
                {
                    //Primeira linha
                    CamadaDados.Locacao.TRegistro_ItensLocacao r = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Id_locacaostr = string.Empty;
                    r.Dt_locacao = null;
                    r.Dt_locacaostr = string.Empty;
                    r.Ds_produto = l.Nr_patrimonio;
                    bsManutCorretiva.Add(r);

                    //Segunda linha
                    r = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Id_locacaostr = l.Id_osstr;
                    r.Ds_produto = l.DS_ProdutoOS;
                    r.Dt_locacao = l.Dt_abertura;
                    bsManutCorretiva.Add(r);
                });
                #endregion

                #region Manutenção Preventiva
                List<CamadaDados.Servicos.TRegistro_LanServico> _LanServicosP = _LanServicos.FindAll(p => p.Tp_ordem.Equals(tpOrdemP)).ToList(); ;
                lbManPreventiva.Text = lbManPreventiva.Tag + " " + _LanServicosP.Count;
                _LanServicosP.ForEach(l =>
                {
                    //Primeira linha
                    CamadaDados.Locacao.TRegistro_ItensLocacao r = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Id_locacaostr = string.Empty;
                    r.Dt_locacao = null;
                    r.Dt_locacaostr = string.Empty;
                    r.Ds_produto = l.Nr_patrimonio;
                    bsManutCorretiva.Add(r);

                    //Segunda linha
                    r = new CamadaDados.Locacao.TRegistro_ItensLocacao();
                    r.Id_locacaostr = l.Id_osstr;
                    r.Ds_produto = l.DS_ProdutoOS;
                    r.Dt_locacao = l.Dt_abertura;
                    bsManutCorretiva.Add(r);
                });
                #endregion

                bsPainelExp.ResetCurrentItem();
            }

            AtualizarTicket.Start();
        }

        private void dataGrid0_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                if (e.ColumnIndex.Equals(1))
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        if (grid0Nome.Equals("Aguard. Expedição"))
                        {
                            double c = CamadaDados.UtilData.Data_Servidor().Subtract(Convert.ToDateTime(e.Value.ToString())).TotalHours;
                            if (c > 5)
                            {
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                            }
                            else if (c > 1)
                            {
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.YellowGreen;
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                            }
                            else
                            {
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                            }
                        }
                        else if (grid0Nome.Equals("Disp. Coleta"))
                        {
                            if (!string.IsNullOrEmpty(e.Value.ToString()))
                            {
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                                dataGrid0.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                            }
                        }
                    }
                }
            }
        }

        private void dataGrid1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                dataGrid1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                if (e.ColumnIndex.Equals(1))
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        if (grid1Nome.Equals("Aguard. Entrega"))
                        {
                            dataGrid1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            dataGrid1.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                        else if (grid1Nome.Equals("Aguard. Coleta"))
                        {
                            dataGrid1.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            dataGrid1.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        private void dataGrid2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                dataGrid2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                if (e.ColumnIndex.Equals(1))
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        if (grid2Nome.Equals("Em Entrega"))
                        {
                            dataGrid2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                            dataGrid2.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                        else if (grid2Nome.Equals("Em Coleta"))
                        {
                            dataGrid2.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                            dataGrid2.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        private void dataGrid3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                dataGrid3.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                if (e.ColumnIndex.Equals(1))
                {
                    if (!string.IsNullOrEmpty(e.Value.ToString()))
                    {
                        double c = CamadaDados.UtilData.Data_Servidor().Subtract(Convert.ToDateTime(e.Value.ToString())).TotalHours;
                        if (c > 5)
                        {
                            dataGrid3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                            dataGrid3.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                        else if (c > 1)
                        {
                            dataGrid3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.YellowGreen;
                            dataGrid3.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                        else
                        {
                            dataGrid3.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
                            dataGrid3.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
                        }
                    }
                }
            }
        }

        private void recarregarTabLayoutStatusGrade()
        {
            #region dataGrid0
            DataGridViewTextBoxColumn idlocacaoDataGridViewTextBoxColumn0 = new DataGridViewTextBoxColumn();
            idlocacaoDataGridViewTextBoxColumn0.DataPropertyName = "Id_locacao";
            idlocacaoDataGridViewTextBoxColumn0.HeaderText = "Id. locação";
            idlocacaoDataGridViewTextBoxColumn0.Name = "idlocacaoDataGridViewTextBoxColumn0";
            idlocacaoDataGridViewTextBoxColumn0.ReadOnly = true;
            DataGridViewTextBoxColumn dtlocacaostrDataGridViewTextBoxColumn0 = new DataGridViewTextBoxColumn();
            dtlocacaostrDataGridViewTextBoxColumn0.DataPropertyName = "Dt_locacaostr";
            dtlocacaostrDataGridViewTextBoxColumn0.HeaderText = "Dt. Locação";
            dtlocacaostrDataGridViewTextBoxColumn0.Name = "dtlocacaostrDataGridViewTextBoxColumn0";
            dtlocacaostrDataGridViewTextBoxColumn0.ReadOnly = true;
            dtlocacaostrDataGridViewTextBoxColumn0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn0 = new DataGridViewTextBoxColumn();
            dsprodutoDataGridViewTextBoxColumn0.DataPropertyName = "Ds_produto";
            dsprodutoDataGridViewTextBoxColumn0.HeaderText = "Cliente / Motorista / Patrimônio";
            dsprodutoDataGridViewTextBoxColumn0.Name = "dsprodutoDataGridViewTextBoxColumn0";
            dsprodutoDataGridViewTextBoxColumn0.ReadOnly = true;
            dsprodutoDataGridViewTextBoxColumn0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn[] dataGridViewColumn0 = new DataGridViewColumn[] {idlocacaoDataGridViewTextBoxColumn0,
                                                                                 dtlocacaostrDataGridViewTextBoxColumn0,
                                                                                 dsprodutoDataGridViewTextBoxColumn0};
            dataGrid0.Dock = DockStyle.Fill;
            dataGrid0.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGrid0_CellFormatting);
            dataGrid0.Columns.Clear();
            dataGrid0.Columns.AddRange(dataGridViewColumn0);
            #endregion

            #region dataGrid1
            DataGridViewTextBoxColumn idlocacaoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            idlocacaoDataGridViewTextBoxColumn1.DataPropertyName = "Id_locacao";
            idlocacaoDataGridViewTextBoxColumn1.HeaderText = "Id. locação";
            idlocacaoDataGridViewTextBoxColumn1.Name = "idlocacaoDataGridViewTextBoxColumn1";
            idlocacaoDataGridViewTextBoxColumn1.ReadOnly = true;
            DataGridViewTextBoxColumn dtlocacaostrDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dtlocacaostrDataGridViewTextBoxColumn1.DataPropertyName = "Dt_locacaostr";
            dtlocacaostrDataGridViewTextBoxColumn1.HeaderText = "Dt. Locação";
            dtlocacaostrDataGridViewTextBoxColumn1.Name = "dtlocacaostrDataGridViewTextBoxColumn1";
            dtlocacaostrDataGridViewTextBoxColumn1.ReadOnly = true;
            dtlocacaostrDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dsprodutoDataGridViewTextBoxColumn1.DataPropertyName = "Ds_produto";
            dsprodutoDataGridViewTextBoxColumn1.HeaderText = "Cliente / Motorista / Patrimônio";
            dsprodutoDataGridViewTextBoxColumn1.Name = "dsprodutoDataGridViewTextBoxColumn1";
            dsprodutoDataGridViewTextBoxColumn1.ReadOnly = true;
            dsprodutoDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn[] dataGridViewColumn1 = new DataGridViewColumn[] {idlocacaoDataGridViewTextBoxColumn1,
                                                                                 dtlocacaostrDataGridViewTextBoxColumn1,
                                                                                 dsprodutoDataGridViewTextBoxColumn1};
            dataGrid1.Dock = DockStyle.Fill;
            dataGrid1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGrid1_CellFormatting);
            dataGrid1.Columns.Clear();
            dataGrid1.Columns.AddRange(dataGridViewColumn1);
            #endregion

            #region dataGrid2
            DataGridViewTextBoxColumn idlocacaoDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            idlocacaoDataGridViewTextBoxColumn2.DataPropertyName = "Id_locacao";
            idlocacaoDataGridViewTextBoxColumn2.HeaderText = "Id. locação";
            idlocacaoDataGridViewTextBoxColumn2.Name = "idlocacaoDataGridViewTextBoxColumn2";
            idlocacaoDataGridViewTextBoxColumn2.ReadOnly = true;
            DataGridViewTextBoxColumn dtlocacaostrDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dtlocacaostrDataGridViewTextBoxColumn2.DataPropertyName = "Dt_locacaostr";
            dtlocacaostrDataGridViewTextBoxColumn2.HeaderText = "Dt. Locação";
            dtlocacaostrDataGridViewTextBoxColumn2.Name = "dtlocacaostrDataGridViewTextBoxColumn2";
            dtlocacaostrDataGridViewTextBoxColumn2.ReadOnly = true;
            dtlocacaostrDataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dsprodutoDataGridViewTextBoxColumn2.DataPropertyName = "Ds_produto";
            dsprodutoDataGridViewTextBoxColumn2.HeaderText = "Cliente / Motorista / Patrimônio";
            dsprodutoDataGridViewTextBoxColumn2.Name = "dsprodutoDataGridViewTextBoxColumn2";
            dsprodutoDataGridViewTextBoxColumn2.ReadOnly = true;
            dsprodutoDataGridViewTextBoxColumn2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn[] dataGridViewColumn2 = new DataGridViewColumn[] {idlocacaoDataGridViewTextBoxColumn2,
                                                                                 dtlocacaostrDataGridViewTextBoxColumn2,
                                                                                 dsprodutoDataGridViewTextBoxColumn2};
            dataGrid2.Dock = DockStyle.Fill;
            dataGrid2.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGrid2_CellFormatting);
            dataGrid2.Columns.Clear();
            dataGrid2.Columns.AddRange(dataGridViewColumn2);
            #endregion

            #region dataGrid3
            DataGridViewTextBoxColumn idlocacaoDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            idlocacaoDataGridViewTextBoxColumn3.DataPropertyName = "Id_locacao";
            idlocacaoDataGridViewTextBoxColumn3.HeaderText = "Id. locação";
            idlocacaoDataGridViewTextBoxColumn3.Name = "idlocacaoDataGridViewTextBoxColumn3";
            idlocacaoDataGridViewTextBoxColumn3.ReadOnly = true;
            DataGridViewTextBoxColumn dtlocacaostrDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dtlocacaostrDataGridViewTextBoxColumn3.DataPropertyName = "Dt_locacaostr";
            dtlocacaostrDataGridViewTextBoxColumn3.HeaderText = "Dt. Locação";
            dtlocacaostrDataGridViewTextBoxColumn3.Name = "dtlocacaostrDataGridViewTextBoxColumn3";
            dtlocacaostrDataGridViewTextBoxColumn3.ReadOnly = true;
            dtlocacaostrDataGridViewTextBoxColumn3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewTextBoxColumn dsprodutoDataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dsprodutoDataGridViewTextBoxColumn3.DataPropertyName = "Ds_produto";
            dsprodutoDataGridViewTextBoxColumn3.HeaderText = "Cliente / Motorista / Patrimônio";
            dsprodutoDataGridViewTextBoxColumn3.Name = "dsprodutoDataGridViewTextBoxColumn3";
            dsprodutoDataGridViewTextBoxColumn3.ReadOnly = true;
            dsprodutoDataGridViewTextBoxColumn0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            DataGridViewColumn[] dataGridViewColumn3 = new DataGridViewColumn[] {idlocacaoDataGridViewTextBoxColumn3,
                                                                                 dtlocacaostrDataGridViewTextBoxColumn3,
                                                                                 dsprodutoDataGridViewTextBoxColumn3};
            dataGrid3.Dock = DockStyle.Fill;
            dataGrid3.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGrid3_CellFormatting);
            dataGrid3.Columns.Clear();
            dataGrid3.Columns.AddRange(dataGridViewColumn3);
            #endregion

            #region Legenda das colunas
            Label label0 = new Label();
            label0.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            label0.AutoSize = true;
            label0.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            label0.ForeColor = Color.DarkGreen;
            label0.Name = "label0";
            label0.TextAlign = ContentAlignment.MiddleCenter;
            Label label1 = new Label();
            label1.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            label1.ForeColor = Color.DarkGreen;
            label1.Name = "label1";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            Label label2 = new Label();
            label2.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            label2.ForeColor = Color.DarkGreen;
            label2.Name = "label2";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            Label label3 = new Label();
            label3.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
            label3.ForeColor = Color.DarkGreen;
            label3.Name = "label3";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            #endregion

            tlStatusGrade.Dock = DockStyle.Fill;
            tlStatusGrade.RowStyles.Clear();
            tlStatusGrade.ColumnStyles.Clear();
            tlStatusGrade.Controls.Clear();

            if (TamanhoGrade.Equals(1))
            {
                tlStatusGrade.RowCount = 2;
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 95F));
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
                tlStatusGrade.ColumnCount = 1;
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

                tlStatusGrade.Controls.Add(dataGrid0, 0, 0);
                tlStatusGrade.Controls.Add(label0, 0, 1);
            }
            else if (TamanhoGrade.Equals(2))
            {
                tlStatusGrade.RowCount = 2;
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 95F));
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
                tlStatusGrade.ColumnCount = 2;
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                tlStatusGrade.Controls.Add(dataGrid0, 0, 0);
                tlStatusGrade.Controls.Add(dataGrid1, 1, 0);
                tlStatusGrade.Controls.Add(label0, 0, 1);
                tlStatusGrade.Controls.Add(label1, 1, 1);
            }
            else if (TamanhoGrade.Equals(3))
            {
                tlStatusGrade.RowCount = 2;
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 95F));
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
                tlStatusGrade.ColumnCount = 3;
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33333F));

                tlStatusGrade.Controls.Add(dataGrid0, 0, 0);
                tlStatusGrade.Controls.Add(dataGrid1, 1, 0);
                tlStatusGrade.Controls.Add(dataGrid2, 2, 0);

                tlStatusGrade.Controls.Add(label0, 0, 1);
                tlStatusGrade.Controls.Add(label1, 1, 1);
                tlStatusGrade.Controls.Add(label2, 2, 1);
            }
            else if (TamanhoGrade.Equals(4))
            {
                tlStatusGrade.RowCount = 4;
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
                tlStatusGrade.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
                tlStatusGrade.ColumnCount = 2;
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                tlStatusGrade.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));

                tlStatusGrade.Controls.Add(dataGrid0, 0, 0);
                tlStatusGrade.Controls.Add(dataGrid1, 0, 2);
                tlStatusGrade.Controls.Add(dataGrid2, 1, 0);
                tlStatusGrade.Controls.Add(dataGrid3, 1, 2);
                tlStatusGrade.Controls.Add(label0, 0, 1);
                tlStatusGrade.Controls.Add(label1, 0, 3);
                tlStatusGrade.Controls.Add(label2, 1, 1);
                tlStatusGrade.Controls.Add(label3, 1, 3);
            }
        }

        private void atualizacaoStatusGrade()
        {
            AtualizarStatusGrade.Stop();

            switch (TamanhoGrade)
            {
                case 1:
                    #region 1 x 1
                    if (ControleExposicao.Equals(0))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgExpedicao;
                        (tlStatusGrade.Controls[1] as Label).Text = "Aguard. Expedição";
                        ControleExposicao = 1;
                    }
                    else if (ControleExposicao.Equals(1))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgEntrega;
                        (tlStatusGrade.Controls[1] as Label).Text = "Aguard. Entrega";
                        ControleExposicao = 2;
                    }
                    else if (ControleExposicao.Equals(2))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsEmEntrega;
                        (tlStatusGrade.Controls[1] as Label).Text = "Em Entrega";
                        ControleExposicao = 3;
                    }
                    else if (ControleExposicao.Equals(3))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsDispColeta;
                        (tlStatusGrade.Controls[1] as Label).Text = "Disp. p/ Coleta";
                        ControleExposicao = 4;
                    }
                    else if (ControleExposicao.Equals(4))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgColeta;
                        (tlStatusGrade.Controls[1] as Label).Text = "Aguard. Coleta";
                        ControleExposicao = 5;
                    }
                    else if (ControleExposicao.Equals(5))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsEmColeta;
                        (tlStatusGrade.Controls[1] as Label).Text = "Em Coleta";
                        ControleExposicao = 0;
                    }
                    #endregion
                    break;
                case 2:
                    #region L1 x C2
                    if (ControleExposicao.Equals(0))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgExpedicao;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsAgEntrega;
                        (tlStatusGrade.Controls[2] as Label).Text = "Aguard. Expedição";
                        (tlStatusGrade.Controls[3] as Label).Text = "Aguard. Entrega";
                        ControleExposicao = 1;
                    }
                    else if (ControleExposicao.Equals(1))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsEmEntrega;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsDispColeta;
                        (tlStatusGrade.Controls[2] as Label).Text = "Em Entrega";
                        (tlStatusGrade.Controls[3] as Label).Text = "Disp. p/ Coleta";
                        ControleExposicao = 2;
                    }
                    else if (ControleExposicao.Equals(2))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgColeta;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsEmColeta;
                        (tlStatusGrade.Controls[2] as Label).Text = "Aguard. Coleta";
                        (tlStatusGrade.Controls[3] as Label).Text = "Em Coleta";
                        ControleExposicao = 0;
                    }
                    #endregion
                    break;
                case 3:
                    #region L1 x C3
                    if (ControleExposicao.Equals(0))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgExpedicao;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsAgEntrega;
                        (tlStatusGrade.Controls[2] as Componentes.DataGridDefault).DataSource = bsEmEntrega;
                        (tlStatusGrade.Controls[3] as Label).Text = grid0Nome = "Aguard. Expedição";
                        (tlStatusGrade.Controls[4] as Label).Text = grid1Nome = "Aguard. Entrega";
                        (tlStatusGrade.Controls[5] as Label).Text = grid2Nome = "Em Entrega";
                        ControleExposicao = 1;
                    }
                    else if (ControleExposicao.Equals(1))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsDispColeta;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsAgColeta;
                        (tlStatusGrade.Controls[2] as Componentes.DataGridDefault).DataSource = bsEmColeta;
                        (tlStatusGrade.Controls[3] as Label).Text = grid0Nome = "Disp. Coleta";
                        (tlStatusGrade.Controls[4] as Label).Text = grid1Nome = "Aguard. Coleta";
                        (tlStatusGrade.Controls[5] as Label).Text = grid2Nome = "Em Coleta";
                        ControleExposicao = 2;
                    }
                    else if (ControleExposicao.Equals(2))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsManutCorretiva;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsManutPreventiva;
                        (tlStatusGrade.Controls[3] as Label).Text = grid0Nome = "Manut. Corretiva";
                        (tlStatusGrade.Controls[4] as Label).Text = grid1Nome = "Manut. Preventiva";
                        ControleExposicao = 0;
                    }
                    #endregion
                    break;
                case 4:
                    #region 2 x 2
                    if (ControleExposicao.Equals(0))
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgExpedicao;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsAgEntrega;
                        (tlStatusGrade.Controls[2] as Componentes.DataGridDefault).DataSource = bsEmEntrega;
                        (tlStatusGrade.Controls[3] as Componentes.DataGridDefault).DataSource = bsDispColeta;
                        (tlStatusGrade.Controls[4] as Label).Text = "Ag. Expedição";
                        (tlStatusGrade.Controls[5] as Label).Text = "Ag. Entrega";
                        (tlStatusGrade.Controls[6] as Label).Text = "Em Entrega";
                        (tlStatusGrade.Controls[7] as Label).Text = "Disp. Coleta";
                        ControleExposicao = 1;
                    }
                    else
                    {
                        (tlStatusGrade.Controls[0] as Componentes.DataGridDefault).DataSource = bsAgColeta;
                        (tlStatusGrade.Controls[1] as Componentes.DataGridDefault).DataSource = bsEmColeta;
                        (tlStatusGrade.Controls[2] as Componentes.DataGridDefault).DataSource = null;
                        (tlStatusGrade.Controls[3] as Componentes.DataGridDefault).DataSource = null;
                        (tlStatusGrade.Controls[4] as Label).Text = "Disp. Coleta";
                        (tlStatusGrade.Controls[5] as Label).Text = "Em Coleta";
                        (tlStatusGrade.Controls[6] as Label).Text = "";
                        (tlStatusGrade.Controls[7] as Label).Text = "";
                        ControleExposicao = 0;
                    }
                    #endregion
                    break;
            }
            tlStatusGrade.Refresh();

            AtualizarStatusGrade.Start();
        }

        private void TFPainelExpedicao_Load(object sender, EventArgs e)
        {
            object a = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(null, "a.TP_Ordem");
            object b = new CamadaDados.Locacao.Cadastros.TCD_CFGLocacao().BuscarEscalar(null, "a.TP_OrdemP");
            if (a == null || b == null)
            {
                MessageBox.Show("Obrigatório que tenha pré-cadastrado tipo de ordem corretiva e preventiva. Configuração Locação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            else
            {
                tpOrdem = a.ToString();
                tpOrdemP = b.ToString();
            }

            recarregarTabLayoutStatusGrade();
            afterBusca();
            atualizacaoStatusGrade();

            AtualizarStatusGrade.Interval = Velocidade * 1000;
            AtualizarStatusGrade.Enabled = true;
                        
        }

        private void bb_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gGeral_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e, DataGridView dataGrid)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 1)
                    if (string.IsNullOrEmpty((bsAgExpedicao[e.RowIndex] as CamadaDados.Locacao.TRegistro_ItensLocacao).Nr_Patrimonio))
                    {
                        dataGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        dataGrid.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
                    }
                    else
                    {
                        dataGrid.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        dataGrid.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
                    }
            }
        }

        private void AtualizarTicket_Tick(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void cbRotacao_CheckedChanged(object sender, EventArgs e)
        {
            Rotacao = !Rotacao;
            if (!Rotacao)
                AtualizarStatusGrade.Stop();
            else
                AtualizarStatusGrade.Start();
        }

        private void lbConfiguracao_Click(object sender, EventArgs e)
        {
            if (lbConfiguracao.Tag.Equals("O")) //open
            {
                tlMaster.RowStyles[0].Height = 16;
                lbConfiguracao.Text = "Configuração >";
                lbConfiguracao.Tag = "C";
                if (!cbRotacao.Checked)
                {
                    recarregarTabLayoutStatusGrade();
                    AtualizarTicket.Start();
                    AtualizarStatusGrade.Start();
                }
            }
            else //closed
            {
                tlMaster.RowStyles[0].Height = 68;
                lbConfiguracao.Text = "Configuração <";
                lbConfiguracao.Tag = "O";
                AtualizarTicket.Stop();
                AtualizarStatusGrade.Stop();
            }
        }

        private void rbVelocidade_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuinzeSeg.Checked)
                Velocidade = 15;
            else if (rbVinteSeg.Checked)
                Velocidade = 20;
            else if (rbTrintaSeg.Checked)
                Velocidade = 30;

            AtualizarStatusGrade.Interval = Velocidade * 1000;
        }

        private void rbTamanhoGrade_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUnico.Checked)
                TamanhoGrade = Convert.ToInt16(rbUnico.Tag);
            else if (rbDuasColunas.Checked)
                TamanhoGrade = Convert.ToInt16(rbDuasColunas.Tag);
            else if (rbTresColunas.Checked)
                TamanhoGrade = Convert.ToInt16(rbTresColunas.Tag);
            else if (rbQuadrado.Checked)
                TamanhoGrade = Convert.ToInt16(rbQuadrado.Tag);
            ControleExposicao = 0;
        }

        private void AtualizarStatusGrade_Tick(object sender, EventArgs e)
        {
            atualizacaoStatusGrade();
        }

    }
}
