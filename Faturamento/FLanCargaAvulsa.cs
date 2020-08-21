using CamadaDados.Faturamento.Entrega;
using CamadaDados.Faturamento.NotaFiscal;
using CamadaNegocio.Faturamento.Entrega;
using CamadaNegocio.Faturamento.NotaFiscal;
using FormBusca;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utils;

namespace Faturamento
{
    public partial class TFLanCargaAvulsa : Form
    {
        private bool Altera_Relatorio = false;
        public TFLanCargaAvulsa()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            string status = string.Empty;
            string virg = string.Empty;
            if (cbxAberto.Checked)
            {
                status = "'A'";
                virg = ",";
            }
            if (cbxEncerrado.Checked)
                status += virg + "'E'";
            bsCarga.DataSource =
                CamadaNegocio.Faturamento.Entrega.TCN_CargaAvulsa.Buscar(cbEmpresa.SelectedValue.ToString(),
                                                                         id_carga.Text,
                                                                         cd_motorista.Text,
                                                                         string.Empty,
                                                                         DT_Inicial.Text,
                                                                         DT_Final.Text,
                                                                         status,
                                                                         null);
            bsCarga.ResetCurrentItem();
            bsCarga_PositionChanged(this, new EventArgs());
        }

        private void afterNovo()
        {
            using (TFCargaAvulsa fCarga = new TFCargaAvulsa())
            {
                if (fCarga.ShowDialog() == DialogResult.OK)
                    if (fCarga.rCarga != null)
                        try
                        {
                            CamadaNegocio.Faturamento.Entrega.TCN_CargaAvulsa.Gravar(fCarga.rCarga, null);
                            MessageBox.Show("Carga gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                            if (MessageBox.Show("Deseja gerar a NF Remessa dos Itens da Carga?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                                == DialogResult.Yes)
                                GerarRemessa(fCarga.rCarga);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            }
        }

        private void afterAltera()
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as TRegistro_CargaAvulsa).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido alterar Carga Encerrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFCargaAvulsa fCarga = new TFCargaAvulsa())
                {
                    fCarga.rCarga = bsCarga.Current as TRegistro_CargaAvulsa;
                    if (fCarga.ShowDialog() == DialogResult.OK)
                        if (fCarga.rCarga != null)
                            try
                            {
                                TCN_CargaAvulsa.Gravar(fCarga.rCarga, null);
                                MessageBox.Show("Carga alterada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
            }
        }

        private void afterExclui()
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as TRegistro_CargaAvulsa).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido excluir Carga Encerrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsCarga.Current as TRegistro_CargaAvulsa).lItens.Exists(p=> p.Qtd_devolvida > 0))
                {
                    MessageBox.Show("Não é permitido excluir Carga que possui itens devolvidos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a exclusão da carga?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_CargaAvulsa.Excluir(bsCarga.Current as TRegistro_CargaAvulsa, null);
                        MessageBox.Show("Carga excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void DevCarga()
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as TRegistro_CargaAvulsa).St_registro.ToUpper().Equals("E"))
                {
                    MessageBox.Show("Não é permitido devolver Carga Encerrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                using (TFDevCarga fDev= new TFDevCarga())
                {
                    fDev.pCd_empresa = (bsCarga.Current as TRegistro_CargaAvulsa).Cd_empresa;
                    fDev.lItens = (bsCarga.Current as TRegistro_CargaAvulsa).lItens;
                    if (fDev.ShowDialog() == DialogResult.OK)
                        if (fDev.lItens != null)
                            try
                            {
                                TCN_ItensCargaAvulsa.DevCarga(fDev.lItens, null);
                                MessageBox.Show("Devolução de Carga efetuada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
        }

        private void GerarRemessa(TRegistro_CargaAvulsa rCarga)
        {
            CamadaDados.Diversos.TList_CfgEmpresa lCfgEmpresa =
                CamadaNegocio.Diversos.TCN_CfgEmpresa.Buscar(rCarga.Cd_empresa, null);
            if (lCfgEmpresa.Count.Equals(0))
            {
                MessageBox.Show("Não existe configuração parâmetro Empresa: " + rCarga.Cd_empresa, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CamadaDados.Faturamento.Pedido.TRegistro_Pedido rPed = null;
            try
            {
                Proc_Commoditties.TProcessaPedidoCargaAvulsa.GerarPedidoCarga(ref rPed,
                                                                             rCarga,
                                                                             lCfgEmpresa[0]);
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Grava_Pedido(rPed, null);
                //Buscar pedido
                rPed = CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Registro_Pedido(rPed.Nr_pedido.ToString(), null);
                //Buscar itens pedido
                CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Busca_Pedido_Itens(rPed, false, null);
                for (int i = 0; i < rCarga.lItens.Count; i++)
                    rPed.Pedido_Itens[i].lItensCargaAvulsa.Add(rCarga.lItens[i]);
                //Gerar Nota Fiscal
                TRegistro_LanFaturamento rFat =
                    Proc_Commoditties.TProcessaPedFaturar.ProcessaPedFaturar(rPed, false, decimal.Zero);
                //Gravar Nota Fiscal
                TCN_LanFaturamento.GravarFaturamento(rFat, null, null);
                using (srvNFE.TFGerenciarNFe fGerNfe = new srvNFE.TFGerenciarNFe())
                {
                    fGerNfe.rNfe = CamadaNegocio.Faturamento.NotaFiscal.TCN_LanFaturamento.BuscarNF(rFat.Cd_empresa,
                                                                                                    rFat.Nr_lanctofiscalstr,
                                                                                                    null);
                    fGerNfe.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                if (rPed != null)
                    CamadaNegocio.Faturamento.Pedido.TCN_Pedido.Deleta_Pedido(rPed, null);
                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TFLanCargaAvulsa_Load(object sender, EventArgs e)
        {
            pConsulta.set_FormatZero();
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanCargaAvulsa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                DevCarga();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bsCarga_PositionChanged(object sender, EventArgs e)
        {
            if (bsCarga.Current != null)
            {
                (bsCarga.Current as TRegistro_CargaAvulsa).lItens =
                    TCN_ItensCargaAvulsa.Buscar(
                        (bsCarga.Current as TRegistro_CargaAvulsa).Cd_empresa,
                        (bsCarga.Current as TRegistro_CargaAvulsa).Id_cargastr,
                        string.Empty,
                        string.Empty,
                        null);
                bsCarga.ResetCurrentItem();
            }
        }
        
        private void gCarga_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex.Equals(0))
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("ENCERRADA"))
                        gCarga.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else
                        gCarga.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_dev_Click(object sender, EventArgs e)
        {
            DevCarga();
        }

        private void miNfRemessa_Click(object sender, EventArgs e)
        {
            if (bsCarga.Current != null)
            {
                if ((bsCarga.Current as TRegistro_CargaAvulsa).lItens.Exists(p=> p.Nr_LanctoFiscalS != null))
                {
                    MessageBox.Show("Carga já possui NF Remessa emitida!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                GerarRemessa(bsCarga.Current as TRegistro_CargaAvulsa);
            }
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "d.ds_veiculo|Veiculo|100;" +
                              "d.placa|Placa|80;" +
                              "a.categoria_cnh|Categoria CNH|80;" +
                              "a.dt_vencimento_cnh|Vencimento CNH|100";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_motorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_motorista },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
    }
}
