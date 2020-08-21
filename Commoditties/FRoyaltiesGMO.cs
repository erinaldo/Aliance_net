using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Commoditties
{
    public partial class TFRoyaltiesGMO : Form
    {
        public CamadaDados.Graos.TRegistro_LanRoyaltiesGMO rRoyalties
        {
            get
            {
                if (bsRoyaltiesGMO.Current != null)
                    return bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO;
                else
                    return null;
            }
        }

        public TFRoyaltiesGMO()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void BB_Pedido_Click(object sender, EventArgs e)
        {
            string vParamFixo = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa);" +
                                "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                                "where x.cfg_pedido = cfgped.cfg_pedido " +
                                "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                                "isnull(a.st_registro, 'A')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BuscaContratoGRO(new Componentes.EditDefault[] { nr_contrato, CD_Empresa, NM_Empresa, CD_Clifor, NM_Clifor, CD_Produto, DS_Produto }, vParamFixo);
        }

        private void NR_Pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.nr_contrato|=|" + nr_contrato.Text + ";" +
                            "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.login = '" + Utils.Parametros.pubLogin.Trim() + "' and x.cd_empresa = a.cd_empresa);" +
                            "|EXISTS|(select 1 from tb_div_usuario_x_cfgpedido x " +
                            "where x.cfg_pedido = cfgped.cfg_pedido " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))));" +
                            "isnull(a.st_registro, 'A')|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { nr_contrato, CD_Empresa, NM_Empresa, CD_Clifor, NM_Clifor, CD_Produto, DS_Produto }, new CamadaDados.Graos.TCD_CadContrato());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFRoyaltiesGMO_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.pDados.set_FormatZero();
            bsRoyaltiesGMO.AddNew();
            (bsRoyaltiesGMO.Current as CamadaDados.Graos.TRegistro_LanRoyaltiesGMO).Tp_gmo = "D";
            bsRoyaltiesGMO.ResetCurrentItem();
        }

        private void TFRoyaltiesGMO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }
    }
}
