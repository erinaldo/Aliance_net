using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Financeiro.Cadastros
{
    public partial class TFCadCFGImpCheque : Form
    {
        public string Cd_banco
        { get; set; }

        public TFCadCFGImpCheque()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFCfgImpCheque fCfg = new TFCfgImpCheque())
            {
                if (fCfg.ShowDialog() == DialogResult.OK)
                    if (fCfg.rCfg != null)
                        try
                        {
                            fCfg.rCfg.Cd_banco = Cd_banco;
                            CamadaNegocio.Financeiro.Cadastros.TCN_CFGImpCheque.Gravar(fCfg.rCfg, null);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsCfgImpCheque.Current != null)
                using (TFCfgImpCheque fCfg = new TFCfgImpCheque())
                {
                    fCfg.rCfg = bsCfgImpCheque.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGImpCheque;
                    if(fCfg.ShowDialog() == DialogResult.OK)
                        if(fCfg.rCfg != null)
                            try
                            {
                                CamadaNegocio.Financeiro.Cadastros.TCN_CFGImpCheque.Gravar(fCfg.rCfg, null);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void afterExclui()
        {
            if(bsCfgImpCheque.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CFGImpCheque.Excluir(bsCfgImpCheque.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CFGImpCheque, null);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            if (!string.IsNullOrEmpty(Cd_banco))
                bsCfgImpCheque.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CFGImpCheque.Buscar(Cd_banco, 
                                                                                                       decimal.Zero,
                                                                                                       decimal.Zero,
                                                                                                       null);
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFCadCFGImpCheque_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.afterBusca();
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

        private void TFCadCFGImpCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
        }

        private void TFCadCFGImpCheque_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, dataGridDefault1);
        }
    }
}
