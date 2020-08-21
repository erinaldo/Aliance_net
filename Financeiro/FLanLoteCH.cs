using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFLanLoteCH : Form
    {
        Utils.TTpModo vModo;
        public TFLanLoteCH()
        {
            InitializeComponent();
            vModo = Utils.TTpModo.tm_Standby;
        }

        private void HabilitarCampos(bool value)
        {
            pDados.HabilitarControls(value, this.vModo);
            cd_empresa.Enabled = value && this.vModo.Equals(Utils.TTpModo.tm_Insert);
            bb_empresa.Enabled = value && this.vModo.Equals(Utils.TTpModo.tm_Insert);
        }

        private void HabilitarPages()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby) || vModo.Equals(Utils.TTpModo.tm_busca))
            {
                if (!tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Add(tpNavegador);
                if (tcCentral.TabPages.Contains(tpLote))
                    tcCentral.TabPages.Remove(tpLote);
            }
            else
            {
                if (tcCentral.TabPages.Contains(tpNavegador))
                    tcCentral.TabPages.Remove(tpNavegador);
                if (!tcCentral.TabPages.Contains(tpLote))
                    tcCentral.TabPages.Add(tpLote);
            }
        }

        private void afterNovo()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby) || vModo.Equals(Utils.TTpModo.tm_busca))
            {
                vModo = Utils.TTpModo.tm_Insert;
                bsLote.AddNew();
                this.HabilitarPages();
                this.HabilitarCampos(true);
                cd_empresa.Focus();
            }
        }

        private void afterGrava()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Insert) || vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (cd_empresa.Text.Trim().Equals(string.Empty))
                {
                    MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_empresa.Focus();
                    return;
                }
                try
                {
                    CamadaNegocio.Financeiro.Titulo.TCN_LoteCH.GravarLoteCH(bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH, null);
                    MessageBox.Show("Lote gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vModo = Utils.TTpModo.tm_Standby;
                    this.afterBusca();
                    this.HabilitarCampos(false);
                    this.HabilitarPages();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro gravar lote: " + ex.Message);
                }
            }
        }

        private void afterAltera()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
                if (bsLote.Current != null)
                    if ((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).St_registro.Trim().ToUpper().Equals("A"))
                    {
                        vModo = Utils.TTpModo.tm_Edit;
                        this.HabilitarCampos(true);
                        this.HabilitarPages();
                        ds_lote.Focus();
                    }
                    else
                        MessageBox.Show("Não é permitido alterar lote enviado ou processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                string st_reg = string.Empty;
                string virg = string.Empty;
                if (CB_Abertas.Checked)
                {
                    st_reg += virg + "'A'";
                    virg = ",";
                }
                if (cbEnviado.Checked)
                {
                    st_reg += virg + "'E'";
                    virg = ",";
                }
                if (cbProcessado.Checked)
                {
                    st_reg += virg + "'P'";
                    virg = ",";
                }
                bsLote.DataSource = CamadaNegocio.Financeiro.Titulo.TCN_LoteCH.Buscar(id_lotebusca.Text,
                                                                                      cd_empresabusca.Text,
                                                                                      (rbDtLote.Checked ? DT_Inicial.Text : string.Empty),
                                                                                      (rbDtLote.Checked ? DT_Final.Text:string.Empty),
                                                                                      ds_lotebusca.Text,
                                                                                      (rbDtProcessamento.Checked ? DT_Inicial.Text: string.Empty),
                                                                                      (rbDtProcessamento.Checked ? DT_Final.Text: string.Empty),
                                                                                      st_reg,
                                                                                      nr_cheque.Text,
                                                                                      0,
                                                                                      string.Empty,
                                                                                      null
                                                                                      );
                bsLote_PositionChanged(this, new EventArgs());
            }
        }

        private void afterExclui()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (bsLote.Current != null)
                {
                    if ((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).St_registro.Trim().ToUpper().Equals("P"))
                    {
                        MessageBox.Show("Não é permitido excluir lote processado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    string msg = string.Empty;
                    if ((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).St_registro.Trim().ToUpper().Equals("E"))
                        msg = "Lote com status ENVIADO para o banco.\r\n";
                    if (MessageBox.Show(msg.Trim() + "Confirma exclusão do registro?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        try
                        {
                            CamadaNegocio.Financeiro.Titulo.TCN_LoteCH.DeletarLoteCH(bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH, null);
                            this.afterBusca();
                            MessageBox.Show("Lote excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe lote selecionado para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterCancela()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Insert) || vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (vModo.Equals(Utils.TTpModo.tm_Insert))
                    bsLote.RemoveCurrent();
                vModo = Utils.TTpModo.tm_Standby;
                this.HabilitarCampos(false);
                this.HabilitarPages();
            }
        }

        private void EnviarLoteBanco()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (bsLote.Current != null)
                {
                    if((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).St_registro.Trim().ToUpper() != "A")
                    {
                        MessageBox.Show("Permitido enviar somente lote com status <ABERTO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma envio do lote para o banco?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        using (TFLanContaDescCheque fConta = new TFLanContaDescCheque())
                        {
                            fConta.Cd_empresa = (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Cd_empresa;
                            fConta.Nm_empresa = (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Nm_empresa;
                            if (fConta.ShowDialog() == DialogResult.OK)
                            {
                                (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Cd_contager = fConta.Cd_contager;
                                (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Dt_enviolote = fConta.Dt_enviolote;
                                try
                                {
                                    CamadaNegocio.Financeiro.Titulo.TCN_LoteCH.EnviarLoteCH(bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH, null);
                                    MessageBox.Show("Lote enviado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim());
                                }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar conta gerencial e data para enviar lote.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe lote selecionado para enviar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ProcessarLote()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (bsLote.Current != null)
                {
                    if ((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).St_registro.Trim().ToUpper() != "E")
                    {
                        MessageBox.Show("Permitido processar somente lote com status <ENVIADO>.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Confirma processamento do lote?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                        == DialogResult.Yes)
                    {
                        using (TFLanProcessarLoteCheque fProc = new TFLanProcessarLoteCheque())
                        {
                            fProc.lCheques = (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques;
                            if (fProc.ShowDialog() == DialogResult.OK)
                            {
                                (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Dt_processamento = fProc.Dt_processamento;
                                (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Vl_credito = fProc.Vl_credito;
                                (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Vl_taxa = fProc.Vl_taxa;
                                try
                                {
                                    CamadaNegocio.Financeiro.Titulo.TCN_LoteCH.ProcessarLoteCH(bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH, null);
                                    MessageBox.Show("Lote processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.afterBusca();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim());
                                }
                            }
                            else
                                MessageBox.Show("Obrigatorio informar data e valor do credito para processar lote.",
                                    "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe lote selecionado para processar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LocalizarCheque()
        {
            if (this.vModo.Equals(Utils.TTpModo.tm_Insert) || this.vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (bsLote.Current != null)
                    using (TFLocalizarChequesDescontar fLocalizar = new TFLocalizarChequesDescontar())
                    {
                        if (fLocalizar.ShowDialog() == DialogResult.OK)
                        {
                            fLocalizar.lCheques.ForEach(p =>
                            {
                                //Verificar se o cheque ja existe na lista
                                if (!(bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                                                                                                             v.Cd_banco.Trim().Equals(p.Cd_banco.Trim()) &&
                                                                                                                             v.Nr_lanctocheque.Equals(p.Nr_lanctocheque)))
                                    (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques.Add(p);
                            });
                            bsLote.ResetCurrentItem();
                            if (bsLote.Current != null)
                            {
                                Vl_TotalTitulo.Value = (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques.Sum(p => p.Vl_titulo);
                                vl_totalchequebusca.Value = Vl_TotalTitulo.Value;
                            }
                        }
                    }
                else
                    MessageBox.Show("Não existe lote para amarrar cheque.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Só é permitido inserir cheque \r\n" +
                                "na inclusão de um novo lote ou na alteração de um lote existente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExcluirCheque()
        {
            if (this.vModo.Equals(Utils.TTpModo.tm_Insert) || this.vModo.Equals(Utils.TTpModo.tm_Edit))
            {
                if (bsLote.Current != null)
                {
                    if (!(bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).St_registro.Trim().ToUpper().Equals("A"))
                    {
                        MessageBox.Show("Não é permitido excluir ordem serviço de um lote com status diferente de <ABERTO>.",
                                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (bsCheques.Current == null)
                    {
                        MessageBox.Show("Obrigatorio selecionar cheque para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (MessageBox.Show("Cheque selecionado: " + (bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_cheque.Trim() +
                                        "\r\n\r\nConfirma exclusão?", "Pergunta", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Adicionar item na lista a ser excluido
                        (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lChequesesc.Add(
                            bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
                        //Excluir item do grid
                        (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques.Remove(
                            bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
                        bsLote.ResetCurrentItem();
                        if (bsLote.Current != null)
                        {
                            Vl_TotalTitulo.Value = (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques.Sum(p => p.Vl_titulo);
                            vl_totalchequebusca.Value = Vl_TotalTitulo.Value;
                        }
                    }
                }
                else
                    MessageBox.Show("Não existe cheque selecionado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Só é permitido excluir cheque \r\n" +
                                "na inclusão de um novo lote ou na alteração de um lote existente.",
                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFLanLoteCH_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCheques);
            Utils.ShapeGrid.RestoreShape(this, gLote);
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltroData.BackColor = Utils.SettingsUtils.Default.COLOR_2;
            pFiltroValor.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            pFiltros.set_FormatZero();
            pDados.set_FormatZero();
            this.HabilitarPages();
        }

        private void bb_empresabusca_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresabusca }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresabusca_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresabusca.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresabusca }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100"
                          , new Componentes.EditDefault[] { cd_empresa, nm_empresa }
                          , new CamadaDados.Diversos.TCD_CadEmpresa(),
                          "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                          "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                          "(exists(select 1 from tb_div_usuario_x_grupos y " +
                          "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))");
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "';" +
                                  "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                  "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                  "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                  "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
              , new Componentes.EditDefault[] { cd_empresa, nm_empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void bsLote_PositionChanged(object sender, EventArgs e)
        {
            if (bsLote.Current != null)
                if ((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Id_lote != 0)
                {
                    //Buscar Cheques do lote
                    (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques =
                        CamadaNegocio.Financeiro.Titulo.TCN_LoteCH_X_Titulo.BuscarCheques((bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).Id_lote.ToString(),
                                                                                          null);
                    bsLote.ResetCurrentItem();
                    if (bsLote.Current != null)
                    {
                        Vl_TotalTitulo.Value = (bsLote.Current as CamadaDados.Financeiro.Titulo.TRegistro_LoteCH).lCheques.Sum(p => p.Vl_titulo);
                        vl_totalchequebusca.Value = Vl_TotalTitulo.Value;
                    }
                }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.afterCancela();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetalhes.SelectedTab.Equals(tpCheques) && (bsCheques.Current != null) && (bsCaixa.Count < 1))
            {
                (bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).lCaixa =
                    new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x "+
                                        "where x.cd_contager = a.cd_contager "+
                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa "+
                                        "and x.cd_empresa = '"+(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_empresa.Trim()+"' "+
                                        "and x.nr_lanctocheque = "+(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_lanctocheque.ToString()+" "+
                                        "and x.cd_banco = '"+(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_banco.Trim()+"')"
                        }
                    }, 0, string.Empty);
                bsCheques.ResetCurrentItem();
            }
        }

        private void TFLanLoteCH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F6))
                this.afterCancela();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.EnviarLoteBanco();
            else if (e.KeyCode.Equals(Keys.F10))
                this.ProcessarLote();
            else if (e.Control && e.KeyCode.Equals(Keys.F11) && btn_Inserir_Item.Enabled)
                this.LocalizarCheque();
            else if (e.Control && e.KeyCode.Equals(Keys.F12) && btn_Deleta_Item.Enabled)
                this.ExcluirCheque();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.LocalizarCheque();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirCheque();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_EnviarLote_Click(object sender, EventArgs e)
        {
            this.EnviarLoteBanco();
        }

        private void BB_ProcLote_Click(object sender, EventArgs e)
        {
            this.ProcessarLote();
        }

        private void gLote_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENVIADO"))
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Maroon;
                    }
                    else if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Blue;
                    }
                    else
                    {
                        DataGridViewRow linha = gLote.Rows[e.RowIndex];
                        linha.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
        }

        private void tcDetalhesCheque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDetalhes.SelectedTab.Equals(tpCheques) && (bsCheques.Current != null) && (bsCaixa.Count < 1))
            {
                (bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).lCaixa =
                    new CamadaDados.Financeiro.Caixa.TCD_LanCaixa().Select(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = string.Empty,
                            vOperador = "exists",
                            vVL_Busca = "(select 1 from tb_fin_titulo_x_caixa x "+
                                        "where x.cd_contager = a.cd_contager "+
                                        "and x.cd_lanctocaixa = a.cd_lanctocaixa "+
                                        "and x.cd_empresa = '"+(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_empresa.Trim()+"' "+
                                        "and x.nr_lanctocheque = "+(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_lanctocheque.ToString()+" "+
                                        "and x.cd_banco = '"+(bsCheques.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_banco.Trim()+"')"
                        }
                    }, 0, string.Empty);
                bsCheques.ResetCurrentItem();
            }
        }

        private void TFLanLoteCH_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCheques);
            Utils.ShapeGrid.SaveShape(this, gLote);
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
