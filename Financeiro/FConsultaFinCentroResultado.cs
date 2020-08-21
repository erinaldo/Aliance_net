using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FormBusca;
using CamadaNegocio.Financeiro.Duplicata;
using CamadaDados.Financeiro.Cadastros;
using CamadaDados.Financeiro.Duplicata;

namespace Financeiro
{
    public partial class TFConsultaFinCentroResultado : Form
    {
        public string Cd_empresa
        { get; set; }

        public TFConsultaFinCentroResultado()
        {
            InitializeComponent();
            this.Cd_empresa = string.Empty;
            tlpCentro.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
        }

        private void afterBusca()
        {
            if (tcCentral.SelectedTab.Equals(tpDuplicata))
            {
                if (string.IsNullOrEmpty(CD_Empresa.Text))
                {
                    MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CD_Empresa.Focus();
                    return;
                }
                bsDuplicata.DataSource = CamadaNegocio.Financeiro.Duplicata.TCN_LanDuplicata.BuscarFinRatearCResultado(CD_Empresa.Text,
                                                                                                                       cd_historico_busca.Text,
                                                                                                                       CD_Clifor.Text,
                                                                                                                       cd_moeda.Text,
                                                                                                                       cd_centroresult.Text,
                                                                                                                       Id_locacaoDup.Text,
                                                                                                                       RB_TpTitulo_Emitidos.Checked ? "P" : RB_TpTitulo_Recebidos.Checked ? "R" : string.Empty,
                                                                                                                       dt_ini.Text,
                                                                                                                       dt_fin.Text,
                                                                                                                       rbAlocado.Checked,
                                                                                                                       null);
                bsDuplicata_PositionChanged(this, new EventArgs());
                TotalizarDup();
            }
            else if (tcCentral.SelectedTab.Equals(tpCaixa))
            {
                if (string.IsNullOrEmpty(cd_empcaixa.Text))
                {
                    MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empcaixa.Focus();
                    return;
                }
                Utils.TpBusca[] filtro = new Utils.TpBusca[4];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_empcaixa.Text.Trim() + "'";
                //Tipo Movimento
                filtro[1].vNM_Campo = rbPagCaixa.Checked ? "a.vl_pagar" : "a.vl_receber";
                filtro[1].vOperador = ">";
                filtro[1].vVL_Busca = "0";
                //Nao estar em centro de resultado
                filtro[2].vNM_Campo = string.Empty;
                filtro[2].vOperador = "not exists";
                filtro[2].vVL_Busca = "(select 1 from tb_fin_caixa_x_ccusto x " +
                                      "where x.cd_contager = a.cd_contager " +
                                      "and x.cd_lanctocaixa = a.cd_lanctocaixa)";
                //Somente lancamento avulso
                filtro[3].vNM_Campo = "isnull(a.st_avulso, 'N')";
                filtro[3].vOperador = "=";
                filtro[3].vVL_Busca = "'S'";
                if(!string.IsNullOrEmpty(cd_contager.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_contager";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_contager.Text.Trim() + "'";
                }
                if(!string.IsNullOrEmpty(cd_histcaixa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_historico";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_histcaixa.Text.Trim() + "'";
                }
                if (dt_inicaixa.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inicaixa.Text).ToString("yyyyMMdd") + "'";
                }
                if(dt_fincaixa.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.dt_lancto";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fincaixa.Text).ToString("yyyyMMdd") + " 23:59:59'";
                }
                bsCaixa.DataSource = new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().Select(filtro, 0, string.Empty);
                this.TotalizarCaixa();
            }
            else if (tcCentral.SelectedTab.Equals(tpFrenteCaixa))
            {
                if (string.IsNullOrEmpty(cd_empPDV.Text))
                {
                    MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empPDV.Focus();
                    return;
                }
                Utils.TpBusca[] filtro = new Utils.TpBusca[3];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_empPDV.Text.Trim() + "'";
                //Nao pode estar cancelado
                filtro[1].vNM_Campo = "isnull(a.st_registro, 'A')";
                filtro[1].vOperador = "<>";
                filtro[1].vVL_Busca = "'C'";
                //Buscar Alocados ou não alocados
                filtro[3].vNM_Campo = string.Empty;
                filtro[3].vOperador = rbAlocadosFrenteC.Checked ? "exists" : "not exists";
                filtro[3].vVL_Busca = "(select 1 from TB_FIN_Cupom_X_CCusto x " +
                                        "inner join TB_FIN_CCustoLancto y " +
                                        "on x.Id_CCustoLan = y.Id_CCustoLan " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.id_cupom = a.id_vendarapida) ";
                if (dt_iniPDV.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_iniPDV.Text).ToString("yyyyMMdd") + "'";
                }
                if (dtfinPDV.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_emissao)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dtfinPDV.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(Cd_centroresultFrenteCaixa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FIN_Cupom_X_CCusto x " +
                                                          "inner join TB_FIN_CCustoLancto y " +
                                                          "on x.Id_CCustoLan = y.Id_CCustoLan " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and x.id_cupom = a.id_vendarapida " +
                                                          "and y.CD_CentroResult = '" + Cd_centroresultFrenteCaixa.Text.Trim() + "') ";
                }
                if (!string.IsNullOrEmpty(cd_cliforFrenteCaixa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.cd_clifor";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_cliforFrenteCaixa.Text.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(Id_locacaoFrenteCaixa.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_LOC_Locacao x " +
                                                          "inner join TB_LOC_Itens_X_PreVenda y " +
                                                          "on x.cd_empresa = y.cd_empresa " +
                                                          "and x.id_locacao = y.id_locacao " +
                                                          "inner join TB_PDV_PreVenda_X_VendaRapida h " +
                                                          "on h.cd_empresa = y.cd_empresa " +
                                                          "and h.id_prevenda = y.id_prevenda " +
                                                          "and h.ID_ItemPreVenda = y.ID_ItemPreVenda " +
                                                          "where h.cd_empresa = a.cd_empresa " +
                                                          "and h.id_cupom = a.id_vendarapida " +
                                                          "and x.id_locacao = " + Id_locacaoFrenteCaixa.Text + ") ";
                }
                bsCupomFiscal.DataSource = new CamadaDados.Faturamento.PDV.TCD_VendaRapida().Select(filtro, 0, string.Empty, string.Empty);
                TotalizarVenda();
            }
            else if (tcCentral.SelectedTab.Equals(tpFrota))
            {
                if (string.IsNullOrEmpty(cd_empresafrt.Text))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empresafrt.Focus();
                    return;
                }
                Utils.TpBusca[] filtro = new Utils.TpBusca[1];
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_empresafrt.Text.Trim() + "'";
                if (tcFrota.SelectedTab.Equals(tpDespesa))
                {
                    if (dt_inifrt.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_despesa)))";
                        filtro[filtro.Length - 1].vOperador = ">=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inifrt.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (dt_finfrt.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_despesa)))";
                        filtro[filtro.Length - 1].vOperador = "<=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_finfrt.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (st_semcresultado.Checked)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                        filtro[filtro.Length - 1].vOperador = "not exists";
                        filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_despviagem_x_ccusto x " +
                                                              "where x.cd_empresa = a.cd_empresa " +
                                                              "and x.id_viagem = a.id_viagem " +
                                                              "and x.id_landespesa = a.id_landespesa)";
                    }
                    bsDespesas.DataSource = new CamadaDados.Frota.TCD_DespesasViagem().Select(filtro, 0, string.Empty);
                    this.TotalizarDespesas();
                }
                else if (tcFrota.SelectedTab.Equals(tpManutencao))
                {
                    if (dt_inifrt.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_realizada)))";
                        filtro[filtro.Length - 1].vOperador = ">=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inifrt.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (dt_finfrt.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_realizada)))";
                        filtro[filtro.Length - 1].vOperador = "<=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_finfrt.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (st_semcresultado.Checked)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                        filtro[filtro.Length - 1].vOperador = "not exists";
                        filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_manutfrota_x_ccusto x " +
                                                              "where x.id_manutencao = a.id_manutencao " +
                                                              "and x.id_veiculo = a.id_veiculo)";
                    }
                    bsManutencao.DataSource = new CamadaDados.Frota.Cadastros.TCD_ManutencaoVeiculo().Select(filtro, 0, string.Empty);
                    this.TotalizarManutencao();
                }
                else if (tcFrota.SelectedTab.Equals(tpAbastecimento))
                {
                    if (dt_inifrt.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))";
                        filtro[filtro.Length - 1].vOperador = ">=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_inifrt.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (dt_finfrt.Text.Trim() != "/  /")
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.dt_abastecimento)))";
                        filtro[filtro.Length - 1].vOperador = "<=";
                        filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_finfrt.Text).ToString("yyyyMMdd") + "'";
                    }
                    if (st_semcresultado.Checked)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                        filtro[filtro.Length - 1].vOperador = "not exists";
                        filtro[filtro.Length - 1].vVL_Busca = "(select 1 from tb_fin_abastfrota_x_ccusto x " +
                                                              "where x.id_abastecimento = a.id_abastecimento)";
                    }
                    bsAbastecimento.DataSource = new CamadaDados.Frota.TCD_AbastVeiculo().Select(filtro, 0, string.Empty);
                    this.TotalizarAbastecimento();
                }
            }
            else if (tcCentral.SelectedTab.Equals(tpViagemFin))
            {
                if (string.IsNullOrEmpty(cd_empresaViagem.Text))
                {
                    MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empPDV.Focus();
                    return;
                }
                Utils.TpBusca[] filtro = new Utils.TpBusca[2];
                //Empresa
                filtro[0].vNM_Campo = "a.cd_empresa";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'" + cd_empresaViagem.Text.Trim() + "'";
                //Buscar Alocados ou não alocados
                filtro[1].vNM_Campo = string.Empty;
                filtro[1].vOperador = rbAlocadosViagem.Checked ? "exists" : "not exists";
                filtro[1].vVL_Busca = "(select 1 from TB_FIN_Viagem_X_CCusto x " +
                                        "inner join TB_FIN_CCustoLancto y " +
                                        "on x.Id_CCustoLan = y.Id_CCustoLan " +
                                        "where x.cd_empresa = a.cd_empresa " +
                                        "and x.ID_Viagem = a.ID_Viagem) ";
                if (dt_iniViagem.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Despesa)))";
                    filtro[filtro.Length - 1].vOperador = ">=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_iniViagem.Text).ToString("yyyyMMdd") + "'";
                }
                if (dt_finViagem.Text.Trim() != "/  /")
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), a.DT_Despesa)))";
                    filtro[filtro.Length - 1].vOperador = "<=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_finViagem.Text).ToString("yyyyMMdd") + "'";
                }
                if (!string.IsNullOrEmpty(cd_centroresultViagem.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = string.Empty;
                    filtro[filtro.Length - 1].vOperador = "exists";
                    filtro[filtro.Length - 1].vVL_Busca = "(select 1 from TB_FIN_Viagem_X_CCusto x " +
                                                          "inner join TB_FIN_CCustoLancto y " +
                                                          "on x.Id_CCustoLan = y.Id_CCustoLan " +
                                                          "where x.cd_empresa = a.cd_empresa " +
                                                          "and x.ID_Viagem = a.ID_Viagem " +
                                                          "and y.CD_CentroResult = '" + cd_centroresultViagem.Text.Trim() + "') ";
                }
                if (!string.IsNullOrEmpty(cd_funcionario.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "b.cd_funcionario";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = "'" + cd_funcionario.Text.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(id_viagem.Text))
                {
                    Array.Resize(ref filtro, filtro.Length + 1);
                    filtro[filtro.Length - 1].vNM_Campo = "a.id_viagem";
                    filtro[filtro.Length - 1].vOperador = "=";
                    filtro[filtro.Length - 1].vVL_Busca = id_viagem.Text;
                }
                bsDespesasViagemFin.DataSource = new CamadaDados.Financeiro.Viagem.TCD_DespesasViagem().Select(filtro, 0, string.Empty);
                this.TotalizarViagemFin();
            }
        }

        private void afterGrava()
        {
            if (tcCentral.SelectedTab.Equals(tpDuplicata))
            {
                if ( bsDuplicata.Current != null && 
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                         CD_Empresa.Text,
                                                                         null).Trim().ToUpper().Equals("S")) 
                    using (TFRateioCResultado a = new TFRateioCResultado())
                    {
                        try
                        {
                            a.Tp_mov = RB_TpTitulo_Emitidos.Checked ? "P" : "R";
                            a.vVl_Documento = (bsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento;
                            
                            if (DialogResult.OK == a.ShowDialog()) 
                            {
                                TCN_DuplicataXCCusto.ProcessarFinCResultado(
                                    (bsDuplicata.Current as TRegistro_LanDuplicata),
                                    a.lCResultado, null);
                                MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }  
            }
            else if (tcCentral.SelectedTab.Equals(tpCaixa))
            {
                if ((bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).Exists(p => p.St_conciliar) &&
                    CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                         cd_empcaixa.Text,
                                                                         null).Trim().ToUpper().Equals("S"))
                    if ((bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).Exists(p => p.St_conciliar && string.IsNullOrEmpty(p.Cd_centroresult)))
                        using (TFAlterarCResultado fAltera = new TFAlterarCResultado())
                        {
                            fAltera.St_novo = true;
                            fAltera.Tp_movimento = rbPagCaixa.Checked ? "DESPESA" : "RECEITA";
                            if (fAltera.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    //Processar Caixa X Centro Resultado
                                    CamadaNegocio.Financeiro.Caixa.TCN_Caixa_X_CCusto.ProcessarCaixaCResultado(
                                        (bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).FindAll(p => p.St_conciliar),
                                        fAltera.Cd_ccusto,
                                        null);
                                    MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    else
                        try
                        {
                            //Processar Caixa X Centro Resultado
                            CamadaNegocio.Financeiro.Caixa.TCN_Caixa_X_CCusto.ProcessarCaixaCResultado(
                                (bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).FindAll(p => p.St_conciliar),
                                string.Empty,
                                null);
                            MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
            else if (tcCentral.SelectedTab.Equals(tpFrenteCaixa))
            {
                if ((bsCupomFiscal.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).Exists(p => p.St_processar) &&
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             cd_empresafrt.Text,
                                                                             null).Trim().ToUpper().Equals("S"))
                    using (TFAlterarCResultado fAltera = new TFAlterarCResultado())
                    {
                        fAltera.St_novo = true;
                        fAltera.Tp_movimento = "DESPESA";
                        if (fAltera.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                //Processar Caixa X Centro Resultado
                                CamadaNegocio.Faturamento.PDV.TCN_Cupom_X_CCusto.ProcessarVendaCResultado(
                                    (bsCupomFiscal.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).FindAll(p => p.St_processar),
                                    fAltera.Cd_ccusto,
                                    null);
                                MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else
                            MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
            else if (tcCentral.SelectedTab.Equals(tpFrota))
            {
                if (tcFrota.SelectedTab.Equals(tpDespesa))
                {
                    if ((bsDespesas.List as CamadaDados.Frota.TList_DespesasViagem).Exists(p => p.St_processar) &&
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             cd_empresafrt.Text,
                                                                             null).Trim().ToUpper().Equals("S"))
                        using (TFAlterarCResultado fAltera = new TFAlterarCResultado())
                        {
                            fAltera.St_novo = true;
                            fAltera.Tp_movimento = "DESPESA";
                            if (fAltera.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    //Processar Caixa X Centro Resultado
                                    CamadaNegocio.Frota.TCN_DespViagem_X_CCusto.ProcessarDespCResultado(
                                        (bsDespesas.List as CamadaDados.Frota.TList_DespesasViagem).FindAll(p => p.St_processar),
                                        fAltera.Cd_ccusto,
                                        null);
                                    MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
                else if (tcFrota.SelectedTab.Equals(tpManutencao))
                {
                    if ((bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Exists(p => p.St_processar) &&
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             cd_empresafrt.Text,
                                                                             null).Trim().ToUpper().Equals("S"))
                        using (TFAlterarCResultado fAltera = new TFAlterarCResultado())
                        {
                            fAltera.St_novo = true;
                            fAltera.Tp_movimento = "DESPESA";
                            if (fAltera.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    //Processar Caixa X Centro Resultado
                                    CamadaNegocio.Frota.Cadastros.TCN_ManutFrota_X_CCusto.ProcessarManuCResultado(
                                        (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).FindAll(p => p.St_processar),
                                        fAltera.Cd_ccusto,
                                        null);
                                    MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
                else if (tcFrota.SelectedTab.Equals(tpAbastecimento))
                {
                    if ((bsAbastecimento.List as CamadaDados.Frota.TList_AbastVeiculo).Exists(p => p.St_processar) &&
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             cd_empresafrt.Text,
                                                                             null).Trim().ToUpper().Equals("S"))
                        using (TFAlterarCResultado fAltera = new TFAlterarCResultado())
                        {
                            fAltera.St_novo = true;
                            fAltera.Tp_movimento = "DESPESA";
                            if (fAltera.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    //Processar Caixa X Centro Resultado
                                    CamadaNegocio.Frota.TCN_AbastFrota_X_CCusto.ProcessarAbasCResultado(
                                        (bsAbastecimento.List as CamadaDados.Frota.TList_AbastVeiculo).FindAll(p => p.St_processar),
                                        fAltera.Cd_ccusto,
                                        null);
                                    MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                }
            }
            else if (tcCentral.SelectedTab.Equals(tpViagemFin))
            {
                if ((bsDespesasViagemFin.List as CamadaDados.Financeiro.Viagem.TList_DespesasViagem).Exists(p => p.St_processar) &&
                        CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("CRESULTADO_EMPRESA",
                                                                             cd_empresafrt.Text,
                                                                             null).Trim().ToUpper().Equals("S"))
                    using (TFAlterarCResultado fAltera = new TFAlterarCResultado())
                    {
                        fAltera.St_novo = true;
                        fAltera.Tp_movimento = "DESPESA";
                        if (fAltera.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                //Processar Despesas Viagem X Centro Resultado
                                CamadaNegocio.Financeiro.Viagem.TCN_Viagem_X_CCusto.ProcessarDespCResultado(
                                    (bsDespesasViagemFin.List as CamadaDados.Financeiro.Viagem.TList_DespesasViagem).FindAll(p => p.St_processar),
                                    fAltera.Cd_ccusto,
                                    null);
                                MessageBox.Show("Centro resultado alocado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                        else
                            MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
            }
        }

        private void TotalizarDup()
        {
            if (bsDuplicata.Count > 0)
            {
                vl_totaldup.Value = (bsDuplicata.List as TList_RegLanDuplicata).Sum(p => p.Vl_documento);
                vl_total_cresultado.Value = (bsDuplicata.List as TList_RegLanDuplicata).Where(p=> p.St_liquidar).Sum(p => p.Vl_documento);
            }
        }

        private void TotalizarCaixa()
        {
            if (bsCaixa.Count > 0)
            {
                tot_caixa.Value = (bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).Sum(p => p.Vl_PAGAR > decimal.Zero ? p.Vl_PAGAR : p.Vl_RECEBER);
                tot_cresultcaixa.Value = (bsCaixa.List as CamadaDados.Financeiro.Caixa.TList_LanCaixa).Where(p => p.St_conciliar).Sum(p => p.Vl_PAGAR > decimal.Zero ? p.Vl_PAGAR : p.Vl_RECEBER);
            }
        }

        private void TotalizarVenda()
        {
            if (bsCupomFiscal.Count > 0)
            {
                tot_venda.Value = (bsCupomFiscal.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).Sum(p => p.Vl_cupom);
                tot_crvenda.Value = (bsCupomFiscal.List as CamadaDados.Faturamento.PDV.TList_VendaRapida).Where(p => p.St_processar).Sum(p => p.Vl_cupom);
            }
        }

        private void TotalizarDespesas()
        {
            if (bsDespesas.Count > 0)
            {
                tot_despesas.Value = (bsDespesas.List as CamadaDados.Frota.TList_DespesasViagem).Sum(p => p.Vl_subtotal);
                tot_custodesp.Value = (bsDespesas.List as CamadaDados.Frota.TList_DespesasViagem).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void TotalizarManutencao()
        {
            if (bsManutencao.Count > 0)
            {
                tot_manutencao.Value = (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Sum(p => p.Vl_realizada);
                tot_customanut.Value = (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).Where(p => p.St_processar).Sum(p => p.Vl_realizada);
            }
        }

        private void TotalizarAbastecimento()
        {
            if (bsAbastecimento.Count > 0)
            {
                tot_abastecimentos.Value = (bsAbastecimento.List as CamadaDados.Frota.TList_AbastVeiculo).Sum(p => p.Vl_subtotal);
                tot_custoabast.Value = (bsAbastecimento.List as CamadaDados.Frota.TList_AbastVeiculo).Where(p => p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void TotalizarViagemFin()
        {
            if (bsAbastecimento.Count > 0)
            {
                tot_despesasViagemFin.Value = (bsDespesasViagemFin.List as CamadaDados.Financeiro.Viagem.TList_DespesasViagem).Sum(p => p.Vl_subtotal);
                tot_centroViagemFin.Value = (bsDespesasViagemFin.List as CamadaDados.Financeiro.Viagem.TList_DespesasViagem).Where(p=> p.St_processar).Sum(p => p.Vl_subtotal);
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "CD_Empresa|Cód. Empresa|100";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa },
                                new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor }, String.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Clifor },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_historico_busca_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            string vParamFixo = "a.TP_Mov|=|" + (RB_TpTitulo_Emitidos.Checked ? "'P'" : RB_TpTitulo_Recebidos.Checked ? "'R'" : "");
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico_busca },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), vParamFixo);
        }

        private void cd_historico_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_historico_busca.Text.Trim() + "';" +
                               "a.TP_Mov|=|" + (RB_TpTitulo_Emitidos.Checked ? "'P'" : RB_TpTitulo_Recebidos.Checked ? "'R'" : "");
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_historico_busca },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_moeda_Click(object sender, EventArgs e)
        {
            string vColunas = "DS_Moeda_Singular|Descrição Moeda|200;" +
                              "CD_Moeda|Cd. Moeda|80;" +
                              "Sigla|Sigla|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_moeda },
                                    new CamadaDados.Financeiro.Cadastros.TCD_Moeda(), string.Empty);
        }

        private void cd_moeda_Leave(object sender, EventArgs e)
        {
            string vColunas = "CD_Moeda|=|'" + cd_moeda.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_moeda }, new CamadaDados.Financeiro.Cadastros.TCD_Moeda());
        }

        private void TFConsultaFinCentroResultado_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gDuplicata);
            Utils.ShapeGrid.RestoreShape(this, gCaixa);
            Utils.ShapeGrid.RestoreShape(this, gCupomFiscal);
            Utils.ShapeGrid.RestoreShape(this, gDespesas);
            Utils.ShapeGrid.RestoreShape(this, gManutencao);
            Utils.ShapeGrid.RestoreShape(this, gAbastecimento);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            pFiltroCaixa.set_FormatZero();
            pFiltroFrota.set_FormatZero();
            panelDados1.set_FormatZero();
            pViagemDesp.set_FormatZero();
            CD_Empresa.Text = this.Cd_empresa;
            CD_Empresa.Enabled = string.IsNullOrEmpty(Cd_empresa);
            BB_Empresa.Enabled = string.IsNullOrEmpty(Cd_empresa);
            cd_empcaixa.Text = this.Cd_empresa;
            cd_empcaixa.Enabled = string.IsNullOrEmpty(Cd_empresa);
            bbEmpCaixa.Enabled = string.IsNullOrEmpty(Cd_empresa);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void cbMarcarTodos_Click(object sender, EventArgs e)
        { 
        }

        private void gDuplicata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFConsultaFinCentroResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bbEmpCaixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "CD_Empresa|Cód. Empresa|100";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empcaixa },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empcaixa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + cd_empcaixa.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empcaixa },
                                new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void cd_contager_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_ContaGer|=|'" + cd_contager.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_contager x " +
                              "where x.cd_contager = a.cd_contager " +
                              "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";

            if (!string.IsNullOrEmpty(cd_empcaixa.Text))
                vColunas += ";|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + cd_empcaixa.Text + "')|";

            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer());
        }

        private void bb_contager_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_contager|Conta|350;" +
                              "a.CD_ContaGer|Cód. Conta|100";

            string vCond = "|exists|(select 1 from tb_div_usuario_x_contager x " +
                           "where x.cd_contager = a.cd_contager " +
                           "and x.login = '" + Utils.Parametros.pubLogin.Trim() + "')";
            if (!string.IsNullOrEmpty(cd_empcaixa.Text))
                vCond = "|exists(select 1 from TB_Fin_ContaGer_X_Empresa k where k.CD_ContaGer = a.CD_ContaGer and k.cd_Empresa = '" + cd_empcaixa.Text + "' )|";

            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contager },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadContaGer(), vCond);
        }

        private void bb_histcaixa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.DS_Historico|Descrição Histórico|350;" +
                              "a.CD_Historico|Cód. Histórico|100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_histcaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), string.Empty);
        }

        private void cd_histcaixa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Historico|=|'" + cd_histcaixa.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_histcaixa },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void gCaixa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsCaixa.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).St_conciliar =
                        !(bsCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).St_conciliar;
                    bsCaixa.ResetCurrentItem();
                    this.TotalizarCaixa();
                }
        }

        private void cbTodosCaixa_Click(object sender, EventArgs e)
        {
            if (bsCaixa.Count > 0)
            {
                (bsCaixa.DataSource as CamadaDados.Financeiro.Caixa.TList_LanCaixa).ForEach(p => p.St_conciliar = cbTodosCaixa.Checked);
                bsCaixa.ResetBindings(true);
                this.TotalizarCaixa();
            }
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_empPDV_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empPDV }, string.Empty);
        }

        private void cd_empPDV_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empPDV.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empPDV });
        }

        private void gCupomFiscal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsCupomFiscal.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsCupomFiscal.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).St_processar =
                        !(bsCupomFiscal.Current as CamadaDados.Faturamento.PDV.TRegistro_VendaRapida).St_processar;
                    bsCupomFiscal.ResetCurrentItem();
                    TotalizarVenda();
                }
        }

        private void st_procdespesas_Click(object sender, EventArgs e)
        {
            if (bsDespesas.Count > 0)
            {
                (bsDespesas.List as CamadaDados.Frota.TList_DespesasViagem).ForEach(p => p.St_processar = st_procdespesas.Checked);
                bsDespesas.ResetBindings(true);
                TotalizarDespesas();
            }
        }

        private void gDespesas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsDespesas.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).St_processar =
                        !(bsDespesas.Current as CamadaDados.Frota.TRegistro_DespesasViagem).St_processar;
                    bsDespesas.ResetCurrentItem();
                    TotalizarDespesas();
                }
        }

        private void gManutencao_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsManutencao.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).St_processar =
                        !(bsManutencao.Current as CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo).St_processar;
                    bsManutencao.ResetCurrentItem();
                    TotalizarManutencao();
                }
        }

        private void st_todosManut_Click(object sender, EventArgs e)
        {
            if (bsManutencao.Count > 0)
            {
                (bsManutencao.List as CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo).ForEach(p => p.St_processar = st_todosManut.Checked);
                bsManutencao.ResetBindings(true);
                TotalizarManutencao();
            }
        }

        private void st_todasaabast_Click(object sender, EventArgs e)
        {
            if (bsAbastecimento.Count > 0)
            {
                (bsAbastecimento.List as CamadaDados.Frota.TList_AbastVeiculo).ForEach(p => p.St_processar = st_todasaabast.Checked);
                bsAbastecimento.ResetBindings(true);
                TotalizarAbastecimento();
            }
        }

        private void gAbastecimento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsAbastecimento.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).St_processar =
                        !(bsAbastecimento.Current as CamadaDados.Frota.TRegistro_AbastVeiculo).St_processar;
                    bsAbastecimento.ResetCurrentItem();
                    TotalizarAbastecimento();
                }
        }

        private void st_todasViagem_Click(object sender, EventArgs e)
        {
            if (bsDespesasViagemFin.Count > 0)
            {
                (bsDespesasViagemFin.List as CamadaDados.Financeiro.Viagem.TList_DespesasViagem).ForEach(p => p.St_processar = st_todasViagem.Checked);
                bsDespesasViagemFin.ResetBindings(true);
                TotalizarViagemFin();
            }
        }

        private void gDespesasViagemFin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bsDespesasViagemFin.Current != null)
                if (e.ColumnIndex == 0)
                {
                    (bsDespesasViagemFin.Current as CamadaDados.Financeiro.Viagem.TRegistro_DespesasViagem).St_processar =
                        !(bsDespesasViagemFin.Current as CamadaDados.Financeiro.Viagem.TRegistro_DespesasViagem).St_processar;
                    bsDespesasViagemFin.ResetCurrentItem();
                    TotalizarViagemFin();
                }
        }

        private void bb_empresafrt_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresafrt }, string.Empty);
        }

        private void cd_empresafrt_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresafrt.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_empresafrt });
        }

        private void TFConsultaFinCentroResultado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gDuplicata);
            Utils.ShapeGrid.SaveShape(this, gCaixa);
            Utils.ShapeGrid.SaveShape(this, gCupomFiscal);
            Utils.ShapeGrid.SaveShape(this, gDespesas);
            Utils.ShapeGrid.SaveShape(this, gManutencao);
            Utils.ShapeGrid.SaveShape(this, gAbastecimento);
        }

        private void cd_centroresult_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresult.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresult },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresult_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResultado fBusca = new TFBuscaCentroResultado())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_centroresult.Text = fBusca.Cd_centro;
            }
        }

        private void bb_centroResultFrenteCaixa_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResultado fBusca = new TFBuscaCentroResultado())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        Cd_centroresultFrenteCaixa.Text = fBusca.Cd_centro;
            }
        }

        private void Cd_centroresultFrenteCaixa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + Cd_centroresultFrenteCaixa.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_centroresultFrenteCaixa },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void cd_cliforFrenteCaixa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_cliforFrenteCaixa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_cliforFrenteCaixa },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_cliforFrentecaixa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_cliforFrenteCaixa }, string.Empty);
        }

        private void bsDuplicata_PositionChanged(object sender, EventArgs e)
        {
            if (bsDuplicata.Current != null)
            {
                (bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto =
                    TCN_DuplicataXCCusto.BuscarCusto((bsDuplicata.Current as TRegistro_LanDuplicata).Cd_empresa,
                                                     (bsDuplicata.Current as TRegistro_LanDuplicata).Nr_lancto.ToString(), 
                                                     null);
                string cond = string.Empty;
                if ((bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Count > 0)
                {
                    (bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto.ForEach(p =>
                    {
                        string cd_result = p.Cd_centroresult;
                        for (int i = 0; (p.Cd_centroresult.Length / 2) > i; i++)
                        {
                            if (i == 0 && cd_result.Length > 2)
                            {
                                if (string.IsNullOrEmpty(cond))
                                    cond = "'" + p.Cd_centroresult.Trim() + "'";
                                else
                                    cond += ", '" + p.Cd_centroresult.Trim() + "'";
                            }
                            else
                            {
                                cd_result = p.Cd_centroresult.Substring(0, (p.Cd_centroresult.Length - (i * 2)));
                                cond += ", '" + cd_result.Trim() + "'";
                            }
                        }

                    });
                    (bsDuplicata.Current as TRegistro_LanDuplicata).lCentroResult =
                        new TCD_CentroResultado().Select(
                            new Utils.TpBusca[]
                            {
                                    new Utils.TpBusca()
                                    {
                                        vNM_Campo = "a.CD_CentroResult",
                                        vOperador = "in",
                                        vVL_Busca = "(" + cond.Trim() + ")"
                                    }
                            }, 0, string.Empty);
                    (bsDuplicata.Current as TRegistro_LanDuplicata).lCentroResult.FindAll(p => p.St_sinteticobool.Equals(false)).ForEach(p =>
                    {
                        p.Valor = (bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto.Find(x => x.Cd_centroresult.Equals(p.Cd_centroresult)).Vl_lancto;
                        p.Pc_valor = Math.Round(p.Valor / ((bsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento / 100), 5);
                    });
                }
                bsDuplicata.ResetCurrentItem();
            }
        }

        private void rbAlocado_CheckedChanged(object sender, EventArgs e)
        {
            tlpCentro.ColumnStyles[1] = new ColumnStyle(SizeType.Percent, 42.52525F);
        }

        private void rbnaoAlocados_CheckedChanged(object sender, EventArgs e)
        {
            tlpCentro.ColumnStyles[1] = new ColumnStyle(SizeType.Absolute, 0);
        }

        private void bb_alterarccusto_Click(object sender, EventArgs e)
        {
            if (bsDuplicata.Current != null)
            {
                using (TFRateioCResultado fRateio = new TFRateioCResultado())
                {
                    (bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLanctoDel =
                        (bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto;
                    fRateio.vVl_Documento = (bsDuplicata.Current as TRegistro_LanDuplicata).Vl_documento_padrao;
                    fRateio.Tp_mov = (bsDuplicata.Current as TRegistro_LanDuplicata).Tp_mov;
                    fRateio.Dt_movimento = (bsDuplicata.Current as TRegistro_LanDuplicata).Dt_emissao;
                    fRateio.ShowDialog();
                    (bsDuplicata.Current as TRegistro_LanDuplicata).lCustoLancto = fRateio.lCResultado;
                    //Processar Duplicata X Centro Resultado
                    TCN_LanDuplicata.AlterarDuplicata(bsDuplicata.Current as TRegistro_LanDuplicata, null);
                    MessageBox.Show("Centro de Resultado alterado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsDuplicata_PositionChanged(this, new EventArgs());
                }
            }
        }

        private void gCentroResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsCentroresult[e.RowIndex] as TRegistro_CentroResultado).St_sinteticobool)
                    {
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                    }
                    else
                    {
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                        gCentroResult.Rows[e.RowIndex].DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular);
                    }
            }
        }

        private void cd_empresaViagem_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_Empresa|=|'" + CD_Empresa.Text + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresaViagem },
                                new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresaViagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Nm_Empresa|Empresa|350;" +
                  "CD_Empresa|Cód. Empresa|100";
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_empresaViagem },
                                    new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_funcionario_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_funcionario.Text.Trim() + "';" +
                               "ISNULL(a.st_funcionarios, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_funcionario }, new TCD_CadClifor());
        }

        private void bb_funcViagem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                             "a.cd_clifor|Codigo|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_funcionario }, new TCD_CadClifor(),
               "ISNULL(a.st_funcionarios, 'N')|=|'S'");
        }

        private void cd_centroresultViagem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_centroresultViagem.Text.Trim() + ";" +
                            "isnull(a.st_sintetico, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_centroresultViagem },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
        }

        private void bb_centroresultViagem_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResultado fBusca = new TFBuscaCentroResultado())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_centroresultViagem.Text = fBusca.Cd_centro;
            }
        }
    }
}
