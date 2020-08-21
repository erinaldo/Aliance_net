using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;

namespace Proc_Commoditties
{
    public partial class TFDevolverOS : Form
    {
        public string Cd_clifortela
        {
            get
            {
                return cd_fornecedor.Text;
            }
        }
        public string Cd_clifor
        { get; set; }
        public string Nm_clifor
        { get; set; }
        public string Nr_pedido
        { get; set; }

        public List<CamadaDados.Servicos.TRegistro_LanServico> lOs
        {
            get
            {
                if (bsOs.Count > 0)
                    return (bsOs.DataSource as CamadaDados.Servicos.TList_LanServico).FindAll(p => p.St_Lote);
                else
                    return null;
            }
        }

        public TFDevolverOS()
        {
            InitializeComponent();
            this.Cd_clifor = string.Empty;
            this.Nm_clifor = string.Empty;
            this.Nr_pedido = string.Empty;
        }

        private void afterGrava()
        {
            if ((bsOs.DataSource as CamadaDados.Servicos.TList_LanServico).Exists(p => p.St_Lote))
            {
                using (Parametros.Diversos.TFRegraUsuario fUser = new Parametros.Diversos.TFRegraUsuario())
                {
                    fUser.Ds_regraespecial = "PERMITIR DEVOLUCAO ORDEM SERVICO";
                    if (fUser.ShowDialog() == DialogResult.OK)
                    {
                        (bsOs.DataSource as CamadaDados.Servicos.TList_LanServico).ForEach(p =>
                            {
                                if (p.St_Lote)
                                    p.Logindevolucao = fUser.Login;
                            });
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            else
                this.DialogResult = DialogResult.Cancel;
        }

        private void BuscarOs()
        {
            if (cd_fornecedor.Text.Trim() != string.Empty)
            {
                bsOs.DataSource = CamadaNegocio.Servicos.TCN_LanServico.Buscar(string.Empty,
                                                                               string.Empty,
                                                                               cd_fornecedor.Text,
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
                                                                               string.Empty,
                                                                               "'PR'",
                                                                               string.Empty,
                                                                               false,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               nr_pedido.Text,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               false,
                                                                               0,
                                                                               string.Empty, 
                                                                               string.Empty,
                                                                               null);
            }
            else
            {
                MessageBox.Show("Obrigatorio informar cliente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_fornecedor.Focus();
            }
        }

        private void TFDevolverOS_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gOs);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            cd_fornecedor.Text = this.Cd_clifor;
            nm_fornecedor.Text = this.Nm_clifor;
            nr_pedido.Text = this.Nr_pedido;
            cd_fornecedor.Enabled = this.Cd_clifor.Trim().Equals(string.Empty);
            bb_fornecedor.Enabled = this.Cd_clifor.Trim().Equals(string.Empty);
            nr_pedido.Enabled = this.Nr_pedido.Trim().Equals(string.Empty);
            if (cd_fornecedor.Text.Trim() != string.Empty)
                this.BuscarOs();
            pFiltro.BackColor = Utils.SettingsUtils.Default.COLOR_2;
        }

        private void bb_fornecedor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, string.Empty);
        }

        private void cd_fornecedor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_fornecedor.Text.Trim() + "'"
                , new Componentes.EditDefault[] { cd_fornecedor, nm_fornecedor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void gOs_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote)
                    (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote = false;
                else
                {
                    if ((bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios.Count.Equals(decimal.Zero))
                        (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios =
                            CamadaNegocio.Servicos.TCN_Acessorios.Buscar((bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).Id_os.ToString(),
                                                                         (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).Cd_empresa.Trim(),
                                                                         string.Empty,
                                                                         string.Empty,
                                                                         0,
                                                                         string.Empty,
                                                                         null);
                    if ((bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios.Count > decimal.Zero)
                        using ( Proc_Commoditties.TFConferenciaAcessorios fConf = new Proc_Commoditties.TFConferenciaAcessorios())
                        {
                            fConf.lAcessorios = (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).lAcessorios;
                            if (fConf.ShowDialog() == DialogResult.Cancel)
                            {
                                MessageBox.Show("Obrigatorio conferir lista de acessorios para devolver ordem serviço.",
                                                "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    (bsOs.Current as CamadaDados.Servicos.TRegistro_LanServico).St_Lote = true;
                }
                bsOs.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.BuscarOs();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFDevolverOS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.BuscarOs();
        }

        private void TFDevolverOS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gOs);
        }
    }
}
