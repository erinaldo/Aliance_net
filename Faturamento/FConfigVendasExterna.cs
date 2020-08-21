using System;
using System.Windows.Forms;
using CamadaDados.Faturamento.Cadastros;

namespace Faturamento
{
    public partial class TFConfigVendasExterna : Form
    {
        private TRegistro_CFGVendasExterna _rcfg;
        public TRegistro_CFGVendasExterna rCfg
        {
            get
            {
                if (bsCfgVendasExterna.Current != null)
                    return bsCfgVendasExterna.Current as TRegistro_CFGVendasExterna;
                else return null;
            }
            set { _rcfg = value; }
        }
        public TFConfigVendasExterna()
        {
            InitializeComponent();
        }
        
        public void afterGrava()
        {
            if(string.IsNullOrEmpty(CD_Empresa.Text))
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CD_Empresa.Focus();
                return;
            }
            if(string.IsNullOrEmpty(login.Text))
            {
                MessageBox.Show("Obrigatório informar login.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login.Focus();
                return;
            }
            if(string.IsNullOrEmpty(senha.Text))
            {
                MessageBox.Show("Obrigatório informar senha.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                senha.Focus();
                return;
            }
            if(string.IsNullOrEmpty(licenca.Text))
            {
                MessageBox.Show("Obrigatório informar licença.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                licenca.Focus();
                return;
            }
            if(string.IsNullOrEmpty(Integracao.Text))
            {
                MessageBox.Show("Obrigatório informar código integração.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Integracao.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void TFConfigVendasExterna_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            login.CharacterCasing = CharacterCasing.Normal;
            senha.CharacterCasing = CharacterCasing.Normal;
            if (_rcfg != null)
            {
                bsCfgVendasExterna.DataSource = new TList_CFGVendasExterna { _rcfg };
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
            }
            else bsCfgVendasExterna.AddNew();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, string.Empty);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, NM_Empresa });
        }

        private void bbLicenca_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(login.Text))
            {
                MessageBox.Show("Obrigatório informar login para obter licença.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login.Focus();
                return;
            }
            if(string.IsNullOrEmpty(senha.Text))
            {
                MessageBox.Show("Obrigatório informar senha para obter licença.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                senha.Focus();
                return;
            }
            licenca.Text = ServiceRest.DataService.BuscarLicenca(login.Text, senha.Text);
        }

        private void bbIntegracao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(login.Text))
            {
                MessageBox.Show("Obrigatório informar login para obter licença.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login.Focus();
                return;
            }
            if (string.IsNullOrEmpty(senha.Text))
            {
                MessageBox.Show("Obrigatório informar senha para obter licença.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                senha.Focus();
                return;
            }
            if(string.IsNullOrEmpty(licenca.Text))
            {
                MessageBox.Show("Obrigatório informar codigo da licença.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                licenca.Focus();
                return;
            }
            Integracao.Text = ServiceRest.DataService.BuscarIntegracao(login.Text, senha.Text, licenca.Text);
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFConfigVendasExterna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void bb_tpduplicata_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpduplicata|Tipo Duplicata|200;" +
                               "a.tp_duplicata|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata(), "a.tp_mov|=|'R'");
        }

        private void tp_duplicata_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_duplicata|=|'" + tp_duplicata.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_duplicata, ds_tpduplicata },
                new CamadaDados.Financeiro.Cadastros.TCD_CadTpDuplicata());
        }

        private void bb_tpdocto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tpdocto|Tipo Documento|200;" +
                              "a.tp_docto|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup(), string.Empty);
        }

        private void tp_docto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.tp_docto|=|" + tp_docto.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { tp_docto, ds_tpdocto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadTpDoctoDup());
        }

        private void bb_condpgto_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_condpgto|Condição Pagamento|200;" +
                              "a.cd_condpgto|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), "a.qt_parcelas|=|1");
        }

        private void cd_condpgto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_condpgto|=|'" + cd_condpgto.Text.Trim() + "';" +
                            "a.qt_parcelas|=|1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_condpgto, ds_condpgto },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto());
        }

        private void bbHistorico_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_historico|Histórico|200;" +
                              "a.cd_historico|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_historico, ds_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico(), "a.tp_mov|=|'R'");
        }

        private void cd_historico_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_historico|=|'" + cd_historico.Text.Trim() + "';" +
                            "a.tp_mov|=|'R'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_historico, ds_historico },
                new CamadaDados.Financeiro.Cadastros.TCD_CadHistorico());
        }

        private void bb_config_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_config|Configuração Boleto|200;" +
                              "a.id_config|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_config, ds_config },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco(), string.Empty);
        }

        private void id_config_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_config|=|" + id_config.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_config, ds_config },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCFGBanco());
        }

        private void bbCfgPedido_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Ds_TipoPedido|Tipo Pedido|200;" +
                              "a.CFG_Pedido|Código|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                new TCD_CadCFGPedido(), "a.tp_movimento|=|'S'");
        }

        private void cfg_pedido_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cfg_pedido|=|'" + cfg_pedido.Text.Trim() + "';a.tp_movimento|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cfg_pedido, ds_tipopedido },
                new TCD_CadCFGPedido());
        }
    }
}
