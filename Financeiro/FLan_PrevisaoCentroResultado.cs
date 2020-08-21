using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFLan_PrevisaoCentroResultado : Form
    {
        private Utils.TTpModo vModo;

        public TFLan_PrevisaoCentroResultado()
        {
            InitializeComponent();
            vModo = Utils.TTpModo.tm_Standby;
        }

        private void UtilizarMedia()
        {
            st_base_janeiro.Checked = !st_utilizarmedia.Checked;
            st_base_fevereiro.Checked = !st_utilizarmedia.Checked;
            st_base_marco.Checked = !st_utilizarmedia.Checked;
            st_base_abril.Checked = !st_utilizarmedia.Checked;
            st_base_maio.Checked = !st_utilizarmedia.Checked;
            st_base_junho.Checked = !st_utilizarmedia.Checked;
            st_base_julho.Checked = !st_utilizarmedia.Checked;
            st_base_agosto.Checked = !st_utilizarmedia.Checked;
            st_base_setembro.Checked = !st_utilizarmedia.Checked;
            st_base_outubro.Checked = !st_utilizarmedia.Checked;
            st_base_novembro.Checked = !st_utilizarmedia.Checked;
            st_base_dezembro.Checked = !st_utilizarmedia.Checked;
            vl_janeiro.Enabled = (!st_base_janeiro.Checked) && (!st_utilizarmedia.Checked);
            vl_fevereiro.Enabled = (!st_base_fevereiro.Checked) && (!st_utilizarmedia.Checked);
            vl_marco.Enabled = (!st_base_marco.Checked) && (!st_utilizarmedia.Checked);
            vl_abril.Enabled = (!st_base_abril.Checked) && (!st_utilizarmedia.Checked);
            vl_maio.Enabled = (!st_base_maio.Checked) && (!st_utilizarmedia.Checked);
            vl_junho.Enabled = (!st_base_junho.Checked) && (!st_utilizarmedia.Checked);
            vl_julho.Enabled = (!st_base_julho.Checked) && (!st_utilizarmedia.Checked);
            vl_agosto.Enabled = (!st_base_agosto.Checked) && (!st_utilizarmedia.Checked);
            vl_setembro.Enabled = (!st_base_setembro.Checked) && (!st_utilizarmedia.Checked);
            vl_outubro.Enabled = (!st_base_outubro.Checked) && (!st_utilizarmedia.Checked);
            vl_novembro.Enabled = (!st_base_novembro.Checked) && (!st_utilizarmedia.Checked);
            vl_dezembro.Enabled = (!st_base_dezembro.Checked) && (!st_utilizarmedia.Checked);
            if (bsProvisaoMes.Count > 0)
            {
                //Janeiro
                vl_janeiro.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_janeiro) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_janeiro_Leave(this, new EventArgs());
                //Fevereiro
                vl_fevereiro.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_fevereiro) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_fevereiro_Leave(this, new EventArgs());
                //Marco
                vl_marco.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_marco) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_marco_Leave(this, new EventArgs());
                //Abril
                vl_abril.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_abril) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_abril_Leave(this, new EventArgs());
                //Maio
                vl_maio.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_maio) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_maio_Leave(this, new EventArgs());
                //Junho
                vl_junho.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_junho) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_junho_Leave(this, new EventArgs());
                //Julho
                vl_julho.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_julho) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_julho_Leave(this, new EventArgs());
                //Agosto
                vl_agosto.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_agosto) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_agosto_Leave(this, new EventArgs());
                //Setembro
                vl_setembro.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_setembro) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_setembro_Leave(this, new EventArgs());
                //Outubro
                vl_outubro.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_outubro) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_outubro_Leave(this, new EventArgs());
                //Novembro
                vl_novembro.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_novembro) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_novembro_Leave(this, new EventArgs());
                //Dezembro
                vl_dezembro.Value = (bsProvisaoMes.List as CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes).Average(p => p.Vl_real_dezembro) *
                    (pc_reajuste.Value > decimal.Zero ? (1 + (pc_reajuste.Value / 100)) : 1);
                vl_dezembro_Leave(this, new EventArgs());
            }
        }

        private void modoBotoes()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                BB_Novo.Visible = true;
                BB_Gravar.Visible = false;
                BB_Cancelar.Visible = false;
                BB_Buscar.Visible = true;
                if (!tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Add(tpNavegador);
                if (tcCentral.TabPages.Contains(tpPrevisao))
                    tcCentral.TabPages.Remove(tpPrevisao);
            }
            else if (vModo.Equals(Utils.TTpModo.tm_Insert) || vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                BB_Novo.Visible = false;
                BB_Gravar.Visible = true;
                BB_Cancelar.Visible = true;
                BB_Buscar.Visible = false;
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
                if (!tcCentral.TabPages.Contains(tpPrevisao))
                    tcCentral.TabPages.Add(tpPrevisao);
            }
        }

        private void buscarPrevisao()
        {
            if ((cd_empresa.Text.Trim() != string.Empty) &&
                (CD_GrupoCF.Text.Trim() != string.Empty))
            {
                CamadaDados.Financeiro.ProvisaoDRG.TList_ProvisaoMes lProvisao =
                    CamadaNegocio.Financeiro.ProvisaoDRG.TCN_ProvisaoMes.Buscar(cd_empresa.Text,
                                                                                CD_GrupoCF.Text,
                                                                                ano_referencia.Value.Year.ToString(),
                                                                                string.Empty,
                                                                                string.Empty);
                if(lProvisao.Count > 0)
                    if (MessageBox.Show("Ja existe previsão para a empresa " + cd_empresa.Text.Trim() + " - " + nm_empresa.Text.Trim() + ",\r\n" +
                                       "Centro de Resultado " + CD_GrupoCF.Text.Trim() + " - " + DS_CustoCF.Text.Trim() + ",\r\n" +
                                       "Ano " + ano_referencia.Value.Year.ToString() + ".\r\n" +
                                       "Deseja alterar previsões?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        vl_janeiro.Value = lProvisao[0].Vl_prev_janeiro;
                        vl_fevereiro.Value = lProvisao[0].Vl_prev_fevereiro;
                        vl_marco.Value = lProvisao[0].Vl_prev_marco;
                        vl_abril.Value = lProvisao[0].Vl_prev_abril;
                        vl_maio.Value = lProvisao[0].Vl_prev_maio;
                        vl_junho.Value = lProvisao[0].Vl_prev_junho;
                        vl_julho.Value = lProvisao[0].Vl_prev_julho;
                        vl_agosto.Value = lProvisao[0].Vl_prev_agosto;
                        vl_setembro.Value = lProvisao[0].Vl_prev_setembro;
                        vl_outubro.Value = lProvisao[0].Vl_prev_outubro;
                        vl_novembro.Value = lProvisao[0].Vl_prev_novembro;
                        vl_dezembro.Value = lProvisao[0].Vl_prev_dezembro;
                    }
                    else
                    {
                        pDados.LimparRegistro();
                        ano_referencia.Value = DateTime.Now;
                    }
            }
        }

        private void buscarRealizadoAnoAnterior()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(CD_GrupoCF.Text)))
            {
                string ano_anterior = string.Empty;
                string virgula = string.Empty;
                for (int i = 0; i < qtd_ano.Value; i++)
                {
                    ano_anterior += virgula + (ano_referencia.Value.Year - (i + 1)).ToString();
                    virgula = ",";
                }
                bsProvisaoMes.DataSource = CamadaNegocio.Financeiro.ProvisaoDRG.TCN_ProvisaoMes.Buscar(cd_empresa.Text,
                                                                                                       CD_GrupoCF.Text,
                                                                                                       ano_anterior,
                                                                                                       string.Empty,
                                                                                                       string.Empty);
                UtilizarMedia();
            }
        }

        private void calcularJaneiro()
        {
            //Janeiro
            if (st_base_janeiro.Checked)
                if (st_reajuste_janeiro.Checked && (pc_reajuste.Value > 0))
                    vl_janeiro.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_janeiro.Value = vl_base.Value;
            else
                if (st_reajuste_janeiro.Checked && (pc_reajuste.Value > 0))
                    vl_janeiro.Value += (vl_janeiro.Value * pc_reajuste.Value) / 100;
        }

        private void calcularFevereiro()
        {
            //Fevereiro
            if (st_base_fevereiro.Checked)
                if (st_reajuste_fevereiro.Checked && (pc_reajuste.Value > 0))
                    vl_fevereiro.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_fevereiro.Value = vl_base.Value;
            else
                if (st_reajuste_fevereiro.Checked && (pc_reajuste.Value > 0))
                    vl_fevereiro.Value += (vl_fevereiro.Value * pc_reajuste.Value) / 100;
        }

        private void calcularMarco()
        {
            //Marco
            if (st_base_marco.Checked)
                if (st_reajuste_marco.Checked && (pc_reajuste.Value > 0))
                    vl_marco.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_marco.Value = vl_base.Value;
            else
                if (st_reajuste_marco.Checked && (pc_reajuste.Value > 0))
                    vl_marco.Value += (vl_marco.Value * pc_reajuste.Value) / 100;
        }

        private void calcularAbril()
        {
            //Abril
            if (st_base_abril.Checked)
                if (st_reajuste_abril.Checked && (pc_reajuste.Value > 0))
                    vl_abril.Value = vl_abril.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_abril.Value = vl_base.Value;
            else
                if (st_reajuste_abril.Checked && (pc_reajuste.Value > 0))
                    vl_abril.Value += (vl_abril.Value * pc_reajuste.Value) / 100;
        }

        private void calcularMaio()
        {
            //Maio
            if (st_base_maio.Checked)
                if (st_reajuste_maio.Checked && (pc_reajuste.Value > 0))
                    vl_maio.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_maio.Value = vl_base.Value;
            else
                if (st_reajuste_maio.Checked && (pc_reajuste.Value > 0))
                    vl_maio.Value += (vl_maio.Value * pc_reajuste.Value) / 100;
        }

        private void calcularJunho()
        {
            //Junho
            if (st_base_junho.Checked)
                if (st_reajuste_junho.Checked && (pc_reajuste.Value > 0))
                    vl_junho.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_junho.Value = vl_base.Value;
            else
                if (st_reajuste_junho.Checked && (pc_reajuste.Value > 0))
                    vl_junho.Value += (vl_junho.Value * pc_reajuste.Value) / 100;
        }

        private void calcularJulho()
        {
            //Julho
            if (st_base_julho.Checked)
                if (st_reajuste_julho.Checked && (pc_reajuste.Value > 0))
                    vl_julho.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_julho.Value = vl_base.Value;
            else
                if (st_reajuste_julho.Checked && (pc_reajuste.Value > 0))
                    vl_julho.Value += (vl_julho.Value * pc_reajuste.Value) / 100;
        }

        private void calcularAgosto()
        {
            //Agosto
            if (st_base_agosto.Checked)
                if (st_reajuste_agosto.Checked && (pc_reajuste.Value > 0))
                    vl_agosto.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_agosto.Value = vl_base.Value;
            else
                if (st_reajuste_agosto.Checked && (pc_reajuste.Value > 0))
                    vl_agosto.Value += (vl_agosto.Value * pc_reajuste.Value) / 100;
        }

        private void calcularSetembro()
        {
            //Setembro
            if (st_base_setembro.Checked)
                if (st_reajuste_setembro.Checked && (pc_reajuste.Value > 0))
                    vl_setembro.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_setembro.Value = vl_base.Value;
            else
                if (st_reajuste_setembro.Checked && (pc_reajuste.Value > 0))
                    vl_setembro.Value += (vl_setembro.Value * pc_reajuste.Value) / 100;
        }

        private void calcularOutubro()
        {
            //Outubro
            if (st_base_outubro.Checked)
                if (st_reajuste_outubro.Checked && (pc_reajuste.Value > 0))
                    vl_outubro.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_outubro.Value = vl_base.Value;
            else
                if (st_reajuste_outubro.Checked && (pc_reajuste.Value > 0))
                    vl_outubro.Value += (vl_outubro.Value * pc_reajuste.Value) / 100;
        }

        private void calcularNovembro()
        {
            //Novembro
            if (st_base_novembro.Checked)
                if (st_reajuste_novembro.Checked && (pc_reajuste.Value > 0))
                    vl_novembro.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_novembro.Value = vl_base.Value;
            else
                if (st_reajuste_novembro.Checked && (pc_reajuste.Value > 0))
                    vl_novembro.Value += (vl_novembro.Value * pc_reajuste.Value) / 100;
        }

        private void calcularDezembro()
        {
            //Dezembro
            if (st_base_dezembro.Checked)
                if (st_reajuste_dezembro.Checked && (pc_reajuste.Value > 0))
                    vl_dezembro.Value = vl_base.Value + ((vl_base.Value * pc_reajuste.Value) / 100);
                else
                    vl_dezembro.Value = vl_base.Value;
            else
                if (st_reajuste_dezembro.Checked && (pc_reajuste.Value > 0))
                    vl_dezembro.Value += (vl_dezembro.Value * pc_reajuste.Value) / 100;
        }

        private void calcularValores()
        {
            calcularJaneiro();
            calcularFevereiro();
            calcularMarco();
            calcularAbril();
            calcularMaio();
            calcularJunho();
            calcularJulho();
            calcularAgosto();
            calcularSetembro();
            calcularOutubro();
            calcularNovembro();
            calcularDezembro();
        }

        private void afterNovo()
        {
            pDados.LimparRegistro();
            ano_referencia.Value = DateTime.Now;
            vModo = Utils.TTpModo.tm_Insert;
            modoBotoes();
        }

        private void afterGrava()
        {
            if (cd_empresa.Text.Trim().Equals(string.Empty))
            {
                MessageBox.Show("Obrigatorio informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(CD_GrupoCF.Text))
            {
                MessageBox.Show("Obrigatorio informar centro de resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_GrupoCF.Focus();
                return;
            }
            CamadaDados.Financeiro.ProvisaoDRG.TList_LanProvisaoDRG lProvisao = new CamadaDados.Financeiro.ProvisaoDRG.TList_LanProvisaoDRG();
            for (int i = 0; i < 12; i++)
            {
                CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG rProvisao = new CamadaDados.Financeiro.ProvisaoDRG.TRegistro_LanProvisaoDRG();
                rProvisao.Cd_empresa = cd_empresa.Text;
                rProvisao.Cd_centroresult = CD_GrupoCF.Text;
                rProvisao.Ano = ano_referencia.Value.Year;
                rProvisao.Mes = i + 1;
                switch (i)
                {
                    case 0:
                        {
                            rProvisao.Dia = diaJaneiro.Value;
                            rProvisao.Vl_previsto = vl_janeiro.Value;
                            break;
                        }
                    case 1:
                        {
                            rProvisao.Dia = diaFevereiro.Value;
                            rProvisao.Vl_previsto = vl_fevereiro.Value;
                            break;
                        }
                    case 2:
                        {
                            rProvisao.Dia = diaMarco.Value;
                            rProvisao.Vl_previsto = vl_marco.Value;
                            break;
                        }
                    case 3:
                        {
                            rProvisao.Dia = diaAbril.Value;
                            rProvisao.Vl_previsto = vl_abril.Value;
                            break;
                        }
                    case 4:
                        {
                            rProvisao.Dia = diaMaio.Value;
                            rProvisao.Vl_previsto = vl_maio.Value;
                            break;
                        }
                    case 5:
                        {
                            rProvisao.Dia = diaJunho.Value;
                            rProvisao.Vl_previsto = vl_junho.Value;
                            break;
                        }
                    case 6:
                        {
                            rProvisao.Dia = diaJulho.Value;
                            rProvisao.Vl_previsto = vl_julho.Value;
                            break;
                        }
                    case 7:
                        {
                            rProvisao.Dia = diaAgosto.Value;
                            rProvisao.Vl_previsto = vl_agosto.Value;
                            break;
                        }
                    case 8:
                        {
                            rProvisao.Dia = diaSetembro.Value;
                            rProvisao.Vl_previsto = vl_setembro.Value;
                            break;
                        }
                    case 9:
                        {
                            rProvisao.Dia = diaOutubro.Value;
                            rProvisao.Vl_previsto = vl_outubro.Value;
                            break;
                        }
                    case 10:
                        {
                            rProvisao.Dia = diaNovembro.Value;
                            rProvisao.Vl_previsto = vl_novembro.Value;
                            break;
                        }
                    case 11:
                        {
                            rProvisao.Dia = diaDezembro.Value;
                            rProvisao.Vl_previsto = vl_dezembro.Value;
                            break;
                        }
                }
                lProvisao.Add(rProvisao);
            }
            try
            {
                CamadaNegocio.Financeiro.ProvisaoDRG.TCN_LanProvisaoDRG.Gravar(lProvisao, null);
                MessageBox.Show("Provisao gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vModo = Utils.TTpModo.tm_Standby;
                modoBotoes();
                afterBusca();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void afterExclui()
        {
            using (TFExcluirPrevisaoDRG fDrg = new TFExcluirPrevisaoDRG())
            {
                fDrg.ShowDialog();
            }
        }

        private void afterCancela()
        {
            vModo = Utils.TTpModo.tm_Standby;
            modoBotoes();
        }

        private void afterBusca()
        {
            bsProvisao_busca.DataSource = CamadaNegocio.Financeiro.ProvisaoDRG.TCN_ProvisaoMes.Buscar(cd_empresa_busca.Text,
                                                                                                      cd_grupocf_busca.Text,
                                                                                                      string.Empty,
                                                                                                      anoIni.Value.Year.ToString(),
                                                                                                      anoFin.Value.Year.ToString());
        }
        
        private void TFLan_PrevisaoCentroResultado_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            pFiltro.set_FormatZero();
            modoBotoes();
        }

        private void bb_GrupoCF_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResult fBusca = new TFBuscaCentroResult())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        CD_GrupoCF.Text = fBusca.Cd_centro;
                        DS_CustoCF.Text = fBusca.Ds_centro;
                        tp_movimento.Text = fBusca.Tipo_registro;
                    }
            }
            buscarPrevisao();
            buscarRealizadoAnoAnterior();
        }

        private void CD_GrupoCF_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.CD_CentroResult|=|" + CD_GrupoCF.Text.Trim() + ";isnull(a.st_sintetico, 'N')|<>|'S'";
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_GrupoCF, DS_CustoCF },
                                    new TCD_CentroResultado());
            if (linha != null)
                tp_movimento.Text = linha["tp_registro"].ToString().Trim().ToUpper().Equals("R") ? "RECEITA" :
                    linha["tp_registro"].ToString().Trim().ToUpper().Equals("D") ? "DESPESA" : string.Empty;
            buscarPrevisao();
            buscarRealizadoAnoAnterior();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            buscarPrevisao();
            buscarRealizadoAnoAnterior();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            buscarPrevisao();
            buscarRealizadoAnoAnterior();
        }

        private void st_base_janeiro_CheckedChanged(object sender, EventArgs e)
        {
            vl_janeiro.Enabled = !st_base_janeiro.Checked;
            if (st_base_janeiro.Checked)
                st_utilizarmedia.Checked = false;
            calcularJaneiro();
        }

        private void st_base_fevereiro_CheckedChanged(object sender, EventArgs e)
        {
            vl_fevereiro.Enabled = !st_base_fevereiro.Checked;
            if (st_base_fevereiro.Checked)
                st_utilizarmedia.Checked = false;
            calcularFevereiro();
        }

        private void st_base_marco_CheckedChanged(object sender, EventArgs e)
        {
            vl_marco.Enabled = !st_base_marco.Checked;
            if (st_base_marco.Checked)
                st_utilizarmedia.Checked = false;
            calcularMarco();
        }

        private void st_base_abril_CheckedChanged(object sender, EventArgs e)
        {
            vl_abril.Enabled = !st_base_abril.Checked;
            if (st_base_abril.Checked)
                st_utilizarmedia.Checked = false;
            calcularAbril();
        }

        private void st_base_maio_CheckedChanged(object sender, EventArgs e)
        {
            vl_maio.Enabled = !st_base_maio.Checked;
            if (st_base_maio.Checked)
                st_utilizarmedia.Checked = false;
            calcularMaio();
        }

        private void st_base_junho_CheckedChanged(object sender, EventArgs e)
        {
            vl_junho.Enabled = !st_base_junho.Checked;
            if (st_base_junho.Checked)
                st_utilizarmedia.Checked = false;
            calcularJunho();
        }

        private void st_base_julho_CheckedChanged(object sender, EventArgs e)
        {
            vl_julho.Enabled = !st_base_julho.Checked;
            if (st_base_julho.Checked)
                st_utilizarmedia.Checked = false;
            calcularJulho();
        }

        private void st_base_agosto_CheckedChanged(object sender, EventArgs e)
        {
            vl_agosto.Enabled = !st_base_agosto.Checked;
            if (st_base_agosto.Checked)
                st_utilizarmedia.Checked = false;
            calcularAgosto();
        }

        private void st_base_setembro_CheckedChanged(object sender, EventArgs e)
        {
            vl_setembro.Enabled = !st_base_setembro.Checked;
            if (st_base_setembro.Checked)
                st_utilizarmedia.Checked = false;
            calcularSetembro();
        }

        private void st_base_outubro_CheckedChanged(object sender, EventArgs e)
        {
            vl_outubro.Enabled = !st_base_outubro.Checked;
            if (st_base_outubro.Checked)
                st_utilizarmedia.Checked = false;
            calcularOutubro();
        }

        private void st_base_novembro_CheckedChanged(object sender, EventArgs e)
        {
            vl_novembro.Enabled = !st_base_novembro.Checked;
            if (st_base_novembro.Checked)
                st_utilizarmedia.Checked = false;
            calcularNovembro();
        }

        private void st_base_dezembro_CheckedChanged(object sender, EventArgs e)
        {
            vl_dezembro.Enabled = !st_base_dezembro.Checked;
            if (st_base_dezembro.Checked)
                st_utilizarmedia.Checked = false;
            calcularDezembro();
        }

        private void vl_base_Leave(object sender, EventArgs e)
        {
            calcularValores();
        }

        private void pc_reajuste_Leave(object sender, EventArgs e)
        {
            calcularValores();
        }

        private void st_reajuste_janeiro_CheckedChanged(object sender, EventArgs e)
        {
            calcularJaneiro();
        }

        private void st_reajuste_fevereiro_CheckedChanged(object sender, EventArgs e)
        {
            calcularFevereiro();
        }

        private void st_reajuste_marco_CheckedChanged(object sender, EventArgs e)
        {
            calcularMarco();
        }

        private void st_reajuste_abril_CheckedChanged(object sender, EventArgs e)
        {
            calcularAbril();
        }

        private void st_reajuste_maio_CheckedChanged(object sender, EventArgs e)
        {
            calcularMaio();
        }

        private void st_reajuste_junho_CheckedChanged(object sender, EventArgs e)
        {
            calcularJunho();
        }

        private void st_reajuste_julho_CheckedChanged(object sender, EventArgs e)
        {
            calcularJulho();
        }

        private void st_reajuste_agosto_CheckedChanged(object sender, EventArgs e)
        {
            calcularAgosto();
        }

        private void st_reajuste_setembro_CheckedChanged(object sender, EventArgs e)
        {
            calcularSetembro();
        }

        private void st_reajuste_outubro_CheckedChanged(object sender, EventArgs e)
        {
            calcularOutubro();
        }

        private void st_reajuste_novembro_CheckedChanged(object sender, EventArgs e)
        {
            calcularNovembro();
        }

        private void st_reajuste_dezembro_CheckedChanged(object sender, EventArgs e)
        {
            calcularDezembro();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void vl_janeiro_Leave(object sender, EventArgs e)
        {
            calcularJaneiro();
        }

        private void vl_fevereiro_Leave(object sender, EventArgs e)
        {
            calcularFevereiro();
        }

        private void vl_marco_Leave(object sender, EventArgs e)
        {
            calcularMarco();
        }

        private void vl_abril_Leave(object sender, EventArgs e)
        {
            calcularAbril();
        }

        private void vl_maio_Leave(object sender, EventArgs e)
        {
            calcularMaio();
        }

        private void vl_junho_Leave(object sender, EventArgs e)
        {
            calcularJunho();
        }

        private void vl_julho_Leave(object sender, EventArgs e)
        {
            calcularJulho();
        }

        private void vl_agosto_Leave(object sender, EventArgs e)
        {
            calcularAgosto();
        }

        private void vl_setembro_Leave(object sender, EventArgs e)
        {
            calcularSetembro();
        }

        private void vl_outubro_Leave(object sender, EventArgs e)
        {
            calcularOutubro();
        }

        private void vl_novembro_Leave(object sender, EventArgs e)
        {
            calcularNovembro();
        }

        private void vl_dezembro_Leave(object sender, EventArgs e)
        {
            calcularDezembro();
        }

        private void st_utilizarmedia_CheckedChanged(object sender, EventArgs e)
        {
            UtilizarMedia();
        }

        private void ano_referencia_ValueChanged(object sender, EventArgs e)
        {
            buscarPrevisao();
            buscarRealizadoAnoAnterior();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            afterCancela();
        }

        private void bb_empresa_busca_Click(object sender, EventArgs e)
        {
            string vParam = "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cd.Empresa|80;UF|UF|80"
                , new Componentes.EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void cd_empresa_busca_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + cd_empresa_busca.Text.Trim() + "';" +
                              "|EXISTS|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { cd_empresa_busca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_grupocf_busca_Click(object sender, EventArgs e)
        {
            using (TFBuscaCentroResultado fBusca = new TFBuscaCentroResultado())
            {
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                        cd_grupocf_busca.Text = fBusca.Cd_centro;
            }
        }

        private void cd_grupocf_busca_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|" + cd_grupocf_busca.Text.Trim() + ";" +
                             "isnull(a.st_sintetico, 'N')|<>|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_grupocf_busca },
                                            new TCD_CentroResultado());
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void TFLan_PrevisaoCentroResultado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2) && BB_Novo.Visible)
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F4) && BB_Gravar.Visible)
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6) && BB_Cancelar.Visible)
                afterCancela();
            else if (e.KeyCode.Equals(Keys.F7) && BB_Buscar.Visible)
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F5) && BB_Excluir.Visible)
                afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void qtd_ano_ValueChanged(object sender, EventArgs e)
        {
            buscarRealizadoAnoAnterior();
        }

        private void diaFevereiro_Leave(object sender, EventArgs e)
        {
            if (!DateTime.IsLeapYear(ano_referencia.Value.Year) && diaFevereiro.Value.Equals(29))
                diaFevereiro.Value -= 1;
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }
    }
}
