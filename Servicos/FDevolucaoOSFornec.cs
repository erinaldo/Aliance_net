using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Servicos
{
    public partial class TFDevolucaoOSFornec : Form
    {
        public TFDevolucaoOSFornec()
        {
            InitializeComponent();
        }

        private bool ExisteOs(CamadaDados.Servicos.TRegistro_LanServico val)
        {
            if (bsOs.Count > 0)
            {
                for (int i = 0; i < bsOs.Count; i++)
                    if ((bsOs[i] as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa.Trim().Equals(val.Cd_empresa.Trim()) &&
                        (bsOs[i] as CamadaDados.Servicos.TRegistro_LanServico).Id_os.Equals(val.Id_os))
                        return true;
                return false;
            }
            else
                return false;
        }

        private CamadaDados.Servicos.TRegistro_LanServicoEvolucao InserirEvolucao()
        {
            using (TFLan_Evolucao_Ordem_Servico fEvolucao = new TFLan_Evolucao_Ordem_Servico())
            {
                fEvolucao.TP_Ordem = TP_Ordem.Text;
                //Buscar etapa envio equipamento para fornecedor
                object obj = new CamadaDados.Servicos.Cadastros.TCD_EtapaOrdem().BuscarEscalar(
                    new Utils.TpBusca[]
                    {
                        new Utils.TpBusca()
                        {
                            vNM_Campo = "isnull(a.st_envterceiro, 'N')",
                            vOperador = "=",
                            vVL_Busca = "'S'"
                        }
                    }, "a.id_etapa");
                if (obj != null)
                    fEvolucao.Etapa_atual = obj.ToString();
                if (fEvolucao.ShowDialog() == DialogResult.OK)
                    return fEvolucao.rEvolucao;
                else
                    return null;
            }
        }   

        private void afterGrava()
        {
            if (pDadosNfRetorno.validarCampoObrigatorio())
            {
                if (bsOs.Count > 0)
                {
                    if (MessageBox.Show("Confirma processamento retorno ordem serviço do fornecedor?", "Pergunta",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        //Buscar proxima etapa para as os
                        CamadaDados.Servicos.TRegistro_LanServicoEvolucao rEvolucao = this.InserirEvolucao();
                        if (rEvolucao == null)
                        {
                            MessageBox.Show("Obrigatorio informar proxima etapa para continuar processamento.",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        List<CamadaDados.Servicos.TRegistro_LanServico> lOs = new List<CamadaDados.Servicos.TRegistro_LanServico>();
                        for (int i = 0; i < bsOs.Count; i++)
                            lOs.Add(bsOs[i] as CamadaDados.Servicos.TRegistro_LanServico);
                        try
                        {
                            CamadaNegocio.Servicos.TCN_LanServico.DevolverOSFornecedor(lOs,
                                                                                       rEvolucao,
                                                                                       vl_frete.Value,
                                                                                       null);
                            MessageBox.Show("Ordens de serviço processadas com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Obrigatorio informar ordem serviço para processar retorno fornecedor.",
                        "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LocalizarOs()
        {
            if (pDadosNfRetorno.validarCampoObrigatorio())
            {
                using (TFLocalizarOsDevFornec fLocalizar = new TFLocalizarOsDevFornec())
                {
                    fLocalizar.Cd_empresa = cd_empresa.Text;
                    fLocalizar.Nm_empresa = nm_empresa.Text;
                    fLocalizar.Cd_fornecedor = cd_fornecedor.Text;
                    fLocalizar.Nm_fornecedor = nm_fornecedor.Text;
                    if (fLocalizar.ShowDialog() == DialogResult.OK)
                    {
                        fLocalizar.lOs.ForEach(p =>
                        {
                            //Verificar se a os ja existe na lista
                            if (!this.ExisteOs(p))
                                bsOs.Add(p);
                        });
                        bsOs.ResetBindings(true);
                    }
                }
            }
        }

        private void ExcluirOs()
        {
            if (bsOs.Current != null)
                if (MessageBox.Show("Confirma exclusão da ordem serviço selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                    bsOs.RemoveCurrent();
        }

        private void TFDevolucaoOSFornec_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOs);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDadosNfRetorno.set_FormatZero();
            lblConciliacao.BackColor = Utils.SettingsUtils.Default.COLOR_2;
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

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, "isnull(a.st_fornecedor, 'N')|=|'S'");
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "';isnull(a.st_fornecedor, 'N')|=|'S'"
                , new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.LocalizarOs();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirOs();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFDevolucaoOSFornec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F11))
                this.LocalizarOs();
            else if (e.KeyCode.Equals(Keys.F12))
                this.ExcluirOs();
        }

        private void BB_TPOrdem_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_TipoOrdem|Tipo Ordem|300;a.tp_Ordem|Código|90"
            , new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new CamadaDados.Servicos.Cadastros.TCD_TpOrdem(), string.Empty);
        }

        private void TP_Ordem_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.tp_Ordem|=|" + TP_Ordem.Text
             , new Componentes.EditDefault[] { TP_Ordem, DS_TPOrdem }, new CamadaDados.Servicos.Cadastros.TCD_TpOrdem());
        }

        private void TFDevolucaoOSFornec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOs);
        }
    }
}
