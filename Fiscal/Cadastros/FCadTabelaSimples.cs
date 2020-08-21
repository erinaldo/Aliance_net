using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fiscal.Cadastros
{
    public partial class TFCadTabelaSimples : Form
    {
        public TFCadTabelaSimples()
        {
            InitializeComponent();
        }

        private void afterNovo()
        {
            using (TFTabSimples fTab = new TFTabSimples())
            {
                if(fTab.ShowDialog() == DialogResult.OK)
                    if(fTab.rTab != null)
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_TabSimples.Gravar(fTab.rTab, null);
                            MessageBox.Show("Tabela gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if(bsTabSimples.Current != null)
                using (TFTabSimples fTab = new TFTabSimples())
                {
                    fTab.rTab = bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples;
                    if(fTab.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_TabSimples.Gravar(fTab.rTab, null);
                            MessageBox.Show("Tabela alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
        }

        private void afterExclui()
        {
            if(bsTabSimples.Current != null)
                if(MessageBox.Show("Confirma exclusão tabela selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_TabSimples.Excluir(bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples, null);
                        MessageBox.Show("Tabela excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void afterBusca()
        {
            bsTabSimples.DataSource = CamadaNegocio.Fiscal.TCN_TabSimples.Buscar(id_tabela.Text,
                                                                                 string.Empty,
                                                                                 null);
            bsTabSimples_PositionChanged(this, new EventArgs());
        }

        private void InserirItem()
        {
            if(bsTabSimples.Current != null)
                using (TFAliquotaSimples fAliq = new TFAliquotaSimples())
                {
                    if(fAliq.ShowDialog() == DialogResult.OK)
                        if(fAliq.rAliq != null)
                            try
                            {
                                fAliq.rAliq.Id_tabela = (bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples).Id_tabela;
                                CamadaNegocio.Fiscal.TCN_AliquotaSimples.Gravar(fAliq.rAliq, null);
                                MessageBox.Show("Aliquota incluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void AlterarItem()
        {
            if(bsAliq.Current != null)
                using (TFAliquotaSimples fAliq = new TFAliquotaSimples())
                {
                    fAliq.rAliq = bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples;
                    if(fAliq.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaNegocio.Fiscal.TCN_AliquotaSimples.Gravar(fAliq.rAliq, null);
                            MessageBox.Show("Aliquota alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.afterBusca();
                }
        }

        private void ExcluirItem()
        {
            if(bsAliq.Current != null)
                if(MessageBox.Show("Confirma exclusão aliquota selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Fiscal.TCN_AliquotaSimples.Excluir(bsAliq.Current as CamadaDados.Fiscal.TRegistro_AliquotaSimples, null);
                        bsAliq.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TFCadTabelaSimples_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bb_tabela_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabela|Tabela Simples|200;" +
                              "a.id_tabela|Código|60";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tabela },
                new CamadaDados.Fiscal.TCD_TabSimples(), string.Empty);
        }

        private void id_tabela_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tabela|=|" + id_tabela.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tabela },
                new CamadaDados.Fiscal.TCD_TabSimples());
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void bsTabSimples_PositionChanged(object sender, EventArgs e)
        {
            if (bsTabSimples.Current != null)
            {
                (bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples).lAliq =
                    CamadaNegocio.Fiscal.TCN_AliquotaSimples.Buscar((bsTabSimples.Current as CamadaDados.Fiscal.TRegistro_TabSimples).Id_tabelastr,
                                                                    string.Empty,
                                                                    null);
                bsTabSimples.ResetCurrentItem();
            }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void TFCadTabelaSimples_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarItem();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirItem();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirItem();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirItem();
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarItem();
        }
    }
}
