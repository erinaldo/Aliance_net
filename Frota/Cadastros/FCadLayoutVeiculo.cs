using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota.Cadastros
{
    public partial class TFCadLayoutVeiculo : FormCadPadrao.FFormCadPadrao
    {
        public TFCadLayoutVeiculo()
        {
            InitializeComponent();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return CamadaNegocio.Frota.Cadastros.TCN_CadLayoutVeiculo.Gravar(
                    bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo, null);
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            CamadaDados.Frota.Cadastros.TList_CadLayoutVeiculo lista =
                CamadaNegocio.Frota.Cadastros.TCN_CadLayoutVeiculo.Buscar(id_layout.Text,
                                                                          null);


            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsCadLayoutVeiculo.DataSource = lista;
                    bsCadLayoutVeiculo_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                        bsCadLayoutVeiculo.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_busca) || (vTP_Modo == Utils.TTpModo.tm_Standby))
                bsCadLayoutVeiculo.AddNew();
            base.afterNovo();
            qt_rodas.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bsCadLayoutVeiculo.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == Utils.TTpModo.tm_Edit)
                qt_rodas.Focus();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Modelo?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    CamadaNegocio.Frota.Cadastros.TCN_CadLayoutVeiculo.Excluir(
                        bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo, null);
                    bsCadLayoutVeiculo.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void buscarImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bsCadLayoutVeiculo.Current != null) && ((vTP_Modo == Utils.TTpModo.tm_Insert) || (vTP_Modo == Utils.TTpModo.tm_Edit)))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo).Imagem = Image.FromFile(ofd.FileName);
                            bsCadLayoutVeiculo.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_excluirImagem_Click(object sender, EventArgs e)
        {
            if (bsCadLayoutVeiculo.Current != null)
            {
                (bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo).Imagem = null;
                (bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo).Img = null;
                bsCadLayoutVeiculo.ResetCurrentItem();
            }
        }

        private void ts_btn_Inserir_Click(object sender, EventArgs e)
        {
            using (TFCadConfLayout fConf = new TFCadConfLayout())
            {
                if (fConf.ShowDialog() == DialogResult.OK)
                    if (fConf.rLayout != null)
                        try
                        {
                            CamadaNegocio.Frota.Cadastros.TCN_CadConf_Layout.Gravar(
                                new CamadaDados.Frota.Cadastros.TRegistro_CadConf_Layout
                                {
                                    Id_layout = (bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo).Id_layout,
                                    DS_Posicao = fConf.rLayout.DS_Posicao,
                                    Coord_X_Sup = fConf.rLayout.Coord_X_Sup,
                                    Coord_Y_Sup = fConf.rLayout.Coord_Y_Sup,
                                    Coord_X_Inf = fConf.rLayout.Coord_X_Inf,
                                    Coord_Y_Inf = fConf.rLayout.Coord_Y_Inf
                                }, null);
                            MessageBox.Show("Configuração Layout gravada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

         private void ts_btn_Deletar_Click(object sender, EventArgs e)
        {
            if (bsCadLayoutVeiculo.Current != null)
                if (MessageBox.Show("Confirma a exclusão da configuração do layout?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Frota.Cadastros.TCN_CadConf_Layout.Excluir(bsConfLayout.Current as CamadaDados.Frota.Cadastros.TRegistro_CadConf_Layout, null);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bsCadLayoutVeiculo_PositionChanged(object sender, EventArgs e)
        {
            if (bsCadLayoutVeiculo.Current != null)
            {
                (bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo).lLayout =
                    CamadaNegocio.Frota.Cadastros.TCN_CadConf_Layout.Buscar((bsCadLayoutVeiculo.Current as CamadaDados.Frota.Cadastros.TRegistro_CadLayoutVeiculo).Id_layoutstr,
                                                                             string.Empty,
                                                                             null);
                bsCadLayoutVeiculo.ResetCurrentItem();
            }
        }

        private void TFCadLayoutVeiculo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.F10))
                ts_btn_Inserir_Click(this, new EventArgs());
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                ts_btn_Deletar_Click(this, new EventArgs());
        }
    }
}
