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
    public partial class TFLanSeguros : Form
    {
        public TFLanSeguros()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            id_apolice.Clear();
            id_veiculo.Clear();
            dt_ini.Clear();
            dt_fin.Clear();
        }

        private void afterNovo()
        {
            using (TFCadSeguroVeiculo fSeguro = new TFCadSeguroVeiculo())
            {
                if(fSeguro.ShowDialog() == DialogResult.OK)
                    if(fSeguro.rSeguro != null)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_CadSeguroVeiculo.Gravar(fSeguro.rSeguro, null);
                            if(MessageBox.Show("Seguro gravado com sucesso.\r\n" +
                                                "Deseja gerar despesa para o seguro?", "Pergunta", 
                                                MessageBoxButtons.YesNo, 
                                                MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                                using(TFDespesaSeguro fDesp = new TFDespesaSeguro())
                                {
                                    fDesp.Vl_despesa = fSeguro.rSeguro.Vl_seguro;
                                    if (fDesp.ShowDialog() == DialogResult.OK)
                                    {
                                        try
                                        {
                                            CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Gravar(
                                                new CamadaDados.Frota.Cadastros.TRegistro_ManutencaoVeiculo()
                                                {
                                                    Id_veiculo = fSeguro.rSeguro.Id_veiculo,
                                                    Id_despesastr = fDesp.pId_despesa,
                                                    Cd_empresa = fDesp.pCd_empresa,
                                                    Dt_realizada = CamadaDados.UtilData.Data_Servidor(),
                                                    Vl_realizada = fSeguro.rSeguro.Vl_seguro,
                                                }, null);
                                            MessageBox.Show("Despesa gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        catch (Exception ex)
                                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                    }
                                }
                            this.LimparFiltros();
                            id_apolice.Text = fSeguro.rSeguro.Id_apolicestr;
                            id_veiculo.Text = fSeguro.rSeguro.Id_veiculostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsSeguro.Current != null)
                using (TFCadSeguroVeiculo fSeguro = new TFCadSeguroVeiculo())
                {
                    fSeguro.rSeguro = bsSeguro.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo;
                    if(fSeguro.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_CadSeguroVeiculo.Gravar(fSeguro.rSeguro, null);
                            MessageBox.Show("Seguro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            id_apolice.Text = fSeguro.rSeguro.Id_apolicestr;
                            id_veiculo.Text = fSeguro.rSeguro.Id_veiculostr;
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsSeguro.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.Cadastros.TCN_CadSeguroVeiculo.Excluir(bsSeguro.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo, null);
                        MessageBox.Show("Seguro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsSeguro.DataSource = CamadaNegocio.Frota.Cadastros.TCN_CadSeguroVeiculo.Buscar(id_veiculo.Text,
                                                                                            id_apolice.Text,
                                                                                            rbIni.Checked ? "I" : string.Empty,
                                                                                            dt_ini.Text,
                                                                                            dt_fin.Text,
                                                                                            null);
            bsSeguro_PositionChanged(this, new EventArgs());

        }

        private void TFLanSeguros_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bsSeguro_PositionChanged(object sender, EventArgs e)
        {
            if (bsSeguro.Current != null)
            {
                (bsSeguro.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo).lPremios =
                    CamadaNegocio.Frota.Cadastros.TCN_CadSeguroPremios.Buscar((bsSeguro.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo).Id_apolicestr,
                                                                              (bsSeguro.Current as CamadaDados.Frota.Cadastros.TRegistro_CadSeguroVeiculo).Id_veiculostr,
                                                                              string.Empty,
                                                                              null);
                bsSeguro.ResetCurrentItem();
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

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFLanSeguros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
