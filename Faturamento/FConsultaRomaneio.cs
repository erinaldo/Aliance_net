using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Faturamento
{
    public partial class TFConsultaRomaneio : Form
    {
        public string pCd_empresa
        { get; set; }
        public string pId_prevenda
        { get; set; }
        public string pNr_pedido
        { get; set; }

        public TFConsultaRomaneio()
        {
            InitializeComponent();
        }

        private void TFConsultaRomaneio_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_empresa.Text = pCd_empresa;
            id_prevenda.Text = pId_prevenda;
            nr_pedido.Text = pNr_pedido;
            if((!string.IsNullOrEmpty(pCd_empresa)) ||
                (!string.IsNullOrEmpty(pId_prevenda)) ||
                (!string.IsNullOrEmpty(pNr_pedido)))
                this.afterBusca();
        }

        private void afterBusca()
        {
            bsRomaneio.DataSource = CamadaNegocio.Faturamento.Entrega.TCN_RomaneioEntrega.Buscar(cd_empresa.Text,
                                                                                                 id_romaneio.Text,
                                                                                                 nm_cliente.Text,
                                                                                                 id_prevenda.Text,
                                                                                                 nr_pedido.Text,
                                                                                                 rbRomaneio.Checked ? "R" : string.Empty,
                                                                                                 dt_ini.Text,
                                                                                                 dt_fin.Text,
                                                                                                 null);
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa }, string.Empty);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa });
        }

        private void bb_cliente_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { nm_cliente }, string.Empty);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void bsRomaneio_PositionChanged(object sender, EventArgs e)
        {
            if (bsRomaneio.Current != null)
            {
                (bsRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).lItens =
                    CamadaNegocio.Faturamento.Entrega.TCN_ItensRomaneio.Buscar((bsRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).Cd_empresa,
                                                                               (bsRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).Id_romaneiostr,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               null);
                bsItensCarga.DataSource = CamadaNegocio.Faturamento.Entrega.TCN_ItensCarga.Buscar((bsRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).Cd_empresa,
                                                                                                  string.Empty,
                                                                                                  (bsRomaneio.Current as CamadaDados.Faturamento.Entrega.TRegistro_RomaneioEntrega).Id_romaneiostr,
                                                                                                  string.Empty,
                                                                                                  string.Empty,
                                                                                                  null);
                bsRomaneio.ResetCurrentItem();
            }
            else
                bsItensCarga.Clear();
        }

        private void TFConsultaRomaneio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }
    }
}
