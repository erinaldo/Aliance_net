using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFLanAcertoMotorista : Form
    {
        public bool Altera_Relatorio = false;

        public TFLanAcertoMotorista()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_acerto.Clear();
            cd_empresa.Clear();
            cd_motorista.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFAcertoMotorista fAcerto = new TFAcertoMotorista())
            {
                if(fAcerto.ShowDialog() == DialogResult.OK)
                    if(fAcerto.rAcerto != null)
                        try
                        {
                            CamadaNegocio.Frota.TCN_AcertoMotorista.Gravar(fAcerto.rAcerto, null);
                            MessageBox.Show("Acerto gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_acerto.Text = fAcerto.rAcerto.Id_acertostr;
                            cd_empresa.Text = fAcerto.rAcerto.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void afterAltera()
        {
            if (bsAcerto.Current != null)
            {
                if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido alterar acerto PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFAcertoMotorista fAcerto = new TFAcertoMotorista())
                {
                    fAcerto.rAcerto = bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista;
                    if(fAcerto.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Frota.TCN_AcertoMotorista.Gravar(fAcerto.rAcerto, null);
                            MessageBox.Show("Acerto motorista alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_acerto.Text = fAcerto.rAcerto.Id_acertostr;
                            cd_empresa.Text = fAcerto.rAcerto.Cd_empresa;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsAcerto.Current != null)
            {
                if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Não é permitido excluir acerto PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma exclusão do acerto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_AcertoMotorista.Excluir(bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista, null);
                        MessageBox.Show("Acerto excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbProcessado.Checked)
                status += "'P'";
            bsAcerto.DataSource = CamadaNegocio.Frota.TCN_AcertoMotorista.Buscar(id_acerto.Text,
                                                                                 Id_viagem.Text,   
                                                                                 cd_empresa.Text,
                                                                                 cd_motorista.Text,
                                                                                 dt_ini.Text,
                                                                                 dt_fin.Text,
                                                                                 status,
                                                                                 null);

            bsAcerto_PositionChanged(this, new EventArgs());
        }

        private void Processar()
        {
            if (bsAcerto.Current != null)
            {
                if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).St_registro.Trim().ToUpper().Equals("P"))
                {
                    MessageBox.Show("Acerto ja se encontra PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma processamento do acerto?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Vl_sobradinheiro > decimal.Zero)
                    {
                        using (Financeiro.TFLanCaixa fCaixa = new Financeiro.TFLanCaixa())
                        {
                            fCaixa.Text = "CAIXA SOBRA DINHEIRO";
                            fCaixa.dsLanCaixa.AddNew();
                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_Empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa;
                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Nm_empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Nm_empresa;
                            //buscar cfg frota
                            CamadaDados.Frota.Cadastros.TList_CfgFrota lCfg =
                                CamadaNegocio.Frota.Cadastros.TCN_CfgFrota.Buscar((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  string.Empty,
                                                                                  null);
                            if(lCfg.Count > 0)
                                if (!string.IsNullOrEmpty(lCfg[0].Cd_contager))
                                {
                                    (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Cd_ContaGer = lCfg[0].Cd_contager;
                                    (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Ds_ContaGer = lCfg[0].Ds_contager;
                                    fCaixa.CD_ContaGer.Enabled = false;
                                    fCaixa.BB_ContaGer.Enabled = false;
                                }
                            fCaixa.RB_Receber.Checked = true;
                            fCaixa.RB_Pagar.Enabled = false;
                            fCaixa.RB_Receber.Enabled = false;
                            (fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa).Vl_RECEBER = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Vl_sobradinheiro;
                            fCaixa.VL_Receber.Enabled = false;
                            if (fCaixa.ShowDialog() == DialogResult.OK)
                                if (fCaixa.dsLanCaixa.Current != null)
                                {
                                    (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rCaixa = fCaixa.dsLanCaixa.Current as CamadaDados.Financeiro.Caixa.TRegistro_LanCaixa;
                                    if (MessageBox.Show("Deseja gerar credito com a sobra de dinheiro?", "Pergunta", MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                    {
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto = new CamadaDados.Financeiro.Adiantamento.TRegistro_LanAdiantamento();
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Cd_empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa;
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Cd_clifor = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_motorista;
                                        //endereco
                                        CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                            CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Cd_clifor,
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
                                                                                                      1,
                                                                                                      null);
                                        if (lEnd.Count > 0)
                                            (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.CD_Endereco = lEnd[0].Cd_endereco;
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Tp_movimento = "C";
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Dt_lancto = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rCaixa.Dt_lancto;
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Vl_adto = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rCaixa.Vl_RECEBER;
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.ST_ADTO = "A";
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.TP_Lancto = "R";
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rAdto.Cd_contager_qt = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rCaixa.Cd_ContaGer;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Obrigatorio informar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                            else
                            {
                                MessageBox.Show("Obrigatorio informar caixa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Vl_resultado < decimal.Zero)
                        using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                        {
                            fDup.Text = "DUPLICATA A PAGAR PARA O MOTORISTA";
                            //Empresa
                            fDup.vCd_empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa;
                            fDup.vNm_empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Nm_empresa;
                            fDup.cd_empresa.Enabled = false;
                            fDup.bb_empresa.Enabled = false;
                            //Cliente
                            fDup.vCd_clifor = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_motorista;
                            fDup.vNm_clifor = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Nm_motorista;
                            fDup.cd_clifor.Enabled = false;
                            fDup.bb_clifor.Enabled = false;
                            //endereco
                            CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                                CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(fDup.vCd_clifor,
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
                                                                                          1,
                                                                                          null);
                            if (lEnd.Count > 0)
                            {
                                fDup.vCd_endereco = lEnd[0].Cd_endereco;
                                fDup.vDs_endereco = lEnd[0].Ds_endereco;
                                fDup.cd_endereco.Enabled = false;
                                fDup.bb_endereco.Enabled = false;
                            }
                            fDup.vTp_mov = "P";
                            fDup.vVl_documento = Math.Abs((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Vl_resultado);
                            fDup.vl_documento_index.Enabled = false;
                            fDup.vNr_docto = "AC" + (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Id_acertostr;
                            fDup.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                            if (fDup.ShowDialog() == DialogResult.OK)
                            {
                                if (fDup.dsDuplicata.Count > 0)
                                    (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                            }
                            else
                            {
                                if (MessageBox.Show("Deseja Processar o Acerto sem gerar Financeiro!.", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                                    return;
                            }
                        }
                    (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFrete.ForEach(p =>
                        {
                            using (Financeiro.TFLanDuplicata fDup = new Financeiro.TFLanDuplicata())
                            {
                                fDup.Text = "DUPLICATA CARTA FRETE Nº" + p.Nr_cartafretestr;
                                //Empresa
                                fDup.vCd_empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa;
                                fDup.vNm_empresa = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Nm_empresa;
                                fDup.cd_empresa.Enabled = false;
                                fDup.bb_empresa.Enabled = false;
                                fDup.vTp_mov = "P";
                                fDup.vVl_documento = p.Vl_documento;
                                fDup.vl_documento_index.Enabled = false;
                                fDup.vNr_docto = "CARTAFRETE" + p.Nr_cartafretestr;
                                fDup.vDt_emissao = CamadaDados.UtilData.Data_Servidor().ToString("dd/MM/yyyy");
                                if (fDup.ShowDialog() == DialogResult.OK)
                                {
                                    if (fDup.dsDuplicata.Count > 0)
                                        p.rDup = fDup.dsDuplicata.Current as CamadaDados.Financeiro.Duplicata.TRegistro_LanDuplicata;
                                }
                                else
                                {
                                    if (MessageBox.Show("Deseja Processar o Acerto sem gerar Financeiro!.", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                                        return;
                                }
                            }
                        });
                    try
                    {
                        CamadaNegocio.Frota.TCN_AcertoMotorista.ProcessarAcerto(bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista, null);
                        MessageBox.Show("Acerto processado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_acerto.Text = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Id_acertostr;
                        cd_empresa.Text = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void EstornarProc()
        {
            if (bsAcerto.Current != null)
            {
                if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).St_registro.Trim().ToUpper().Equals("A"))
                {
                    MessageBox.Show("Acerto não se encontra PROCESSADO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(MessageBox.Show("Confirma estorno processamento do acerto?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.TCN_AcertoMotorista.EstornarProc(bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista, null);
                        MessageBox.Show("Processamento estornado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        id_acerto.Text = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Id_acertostr;
                        cd_empresa.Text = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void TFLanAcertoMotorista_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                     new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista }, "isnull(a.st_motorista, 'N')|=|'S';isnull(a.ST_AtivoMot, 'N')|=|'S'");
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                                                    "isnull(a.st_motorista, 'N')|=|'S';" +
                                                    "isnull(a.ST_AtivoMot, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_motorista },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsAcerto_PositionChanged(object sender, EventArgs e)
        {
            if(bsAcerto.Current != null)
            {
                //Buscar viagem
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem =
                    CamadaNegocio.Frota.TCN_Acerto_X_Viagem.BuscarViagem((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Id_acertostr,
                                                                         (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa,
                                                                         null);
                //Buscar carta frete
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFrete =
                    CamadaNegocio.Frota.TCN_CartaFrete.Buscar(string.Empty,
                                                              (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa,
                                                              string.Empty,
                                                              (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Id_acertostr,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              null);
                //Buscar cheque
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque =
                    CamadaNegocio.Frota.TCN_Acerto_X_Titulo.BuscarCheque((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Cd_empresa,
                                                                         (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Id_acertostr,
                                                                         null);
                bsAcerto.ResetCurrentItem();
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

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void gAcerto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                    if (e.Value.ToString().Trim().ToUpper().Equals("PROCESSADO"))
                        gAcerto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gAcerto.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
        }

        private void gAcerto_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gAcerto.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsAcerto.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Frota.TRegistro_AcertoMotorista());
            CamadaDados.Frota.TList_AcertoMotorista lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gAcerto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gAcerto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Frota.TList_AcertoMotorista(lP.Find(gAcerto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gAcerto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Frota.TList_AcertoMotorista(lP.Find(gAcerto.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gAcerto.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsAcerto.List as CamadaDados.Frota.TList_AcertoMotorista).Sort(lComparer);
            bsAcerto.ResetBindings(false);
            gAcerto.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void bb_processar_Click(object sender, EventArgs e)
        {
            this.Processar();
        }

        private void bb_estornar_Click(object sender, EventArgs e)
        {
            this.EstornarProc();
        }

        private void TFLanAcertoMotorista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.Processar();
            else if (e.KeyCode.Equals(Keys.F10))
                this.EstornarProc();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Altera_Relatorio = true;
            } 
        }

        private void relatorioPedidosSinteticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsAcerto.Current != null)
            {
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Frota.TList_AcertoMotorista() { bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = "TFRel_ExtratoAcerto";
                    Rel.Ident = "TFRel_ExtratoAcerto";
                    Rel.NM_Classe = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "EXTRATO ACERTO MOTORISTA";

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
                                           "EXTRATO ACERTO MOTORISTA",
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
                                               "EXTRATO ACERTO MOTORISTA",
                                               fImp.pDs_mensagem);
                }
            }
            else
                MessageBox.Show("Não existe Registros Para Imprimir o Relatório!");
        }
    }
}
