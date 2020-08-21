using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Restaurante.Cadastro;
using CamadaNegocio.Restaurante.Cadastro;

namespace Restaurante.Cadastro
{
    public partial class FCadCFG : FormCadPadrao.FFormCadPadrao
    {
        public FCadCFG()
        {
            InitializeComponent();
        }

        private void FCadCFG_Load(object sender, EventArgs e)
        {
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("ROTATIVO", "0"));
            cbx.Add(new Utils.TDataCombo("MESA", "1"));
            cbx.Add(new Utils.TDataCombo("SEQUENCIAL", "2")); 
            comboBoxDefault1.DataSource = cbx;
            comboBoxDefault1.DisplayMember = "Display";
            comboBoxDefault1.ValueMember = "Value";
        }

        public override void formatZero()
        {
            this.pDados.set_FormatZero();
        }

        public override string gravarRegistro()
        {
            if ((bscfg.Current as TRegistro_Cfg).Tp_cartao.Equals("0"))
            {
                inicio.ST_Gravar = true;
                inicio.ST_NotNull = true;
                final.ST_Gravar = true;
                final.ST_NotNull = true;
                if ((bscfg.Current as TRegistro_Cfg).nr_cartaorotini > (bscfg.Current as TRegistro_Cfg).nr_cartaorotfin)
                {
                    MessageBox.Show("Faixa de inicio do cartão deve ser menor que a faixa final!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    inicio.Focus();
                    return string.Empty;
                }          
            }
            else
            {
                inicio.ST_Gravar = false;
                inicio.ST_NotNull = false;
                final.ST_Gravar = false;
                final.ST_NotNull = false;
                //chCartao.ST_NotNull = false;
                //chCartao.ST_Gravar = false;
            }
            if (pDados.validarCampoObrigatorio())
            {
                return TCN_CFG.Gravar(bscfg.Current as TRegistro_Cfg, null);
            }
            else
                return string.Empty;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == Utils.TTpModo.tm_Standby) || (vTP_Modo == Utils.TTpModo.tm_busca))
                bscfg.AddNew();
            base.afterNovo();
            if (!cd_empresa.Focus())
                cd_empresa.Focus();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            cd_empresa.Focus();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == Utils.TTpModo.tm_Insert)
                bscfg.RemoveCurrent();
        }

        public override int buscarRegistros()
        {
            TList_CFG lista = TCN_CFG.Buscar(cd_empresa.Text,null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bscfg.DataSource = lista;
                }
                else
                    if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
                    bscfg.Clear();
                return lista.Count;
            }
            else
                return 0;

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == Utils.TTpModo.tm_Standby) || (this.vTP_Modo == Utils.TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CFG.Excluir(bscfg.Current as TRegistro_Cfg, null);
                    bscfg.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);

        }

        private void TFCadCFGEmpreendimento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void bb_tabelapreco_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                "a.ds_tabelapreco|Tabela Preço|150;" +
                "a.cd_tabelapreco|Código|50",
                new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco(),
                string.Empty);
        }

        private void cd_tabelapreco_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "a.cd_tabelapreco|=|'" + cd_tabelapreco.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_tabelapreco, ds_tabelapreco },
                new CamadaDados.Diversos.TCD_CadTbPreco());
        }

        private void chCartao_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_clifor, nm_clifor }, string.Empty);
        }

        private void cd_clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_clifor.Text.Trim() + "'",
                new Componentes.EditDefault[] { cd_clifor, nm_clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            FormBusca.UtilPesquisa.BTN_BUSCA(
                "DS_CondFiscal|Tabela Preço|150;" +
                "Cd_condFiscal_clifor|Código|50",
                new Componentes.EditDefault[] { editDefault1, editDefault2 },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor(),
                string.Empty);
        }

        private void editDefault1_Leave(object sender, EventArgs e)
        {

            FormBusca.UtilPesquisa.EDIT_LEAVE(
                "Cd_condFiscal_clifor|=|'" + editDefault1.Text.Trim() + "'",
                new Componentes.EditDefault[] { editDefault1, editDefault2 },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.ds_local|local|150;" +
                               "a.cd_local|Código|50",
                               new Componentes.EditDefault[] { editDefault3, editDefault4},
                               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm(),
                               string.Empty);
        }

        private void editDefault3_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.cd_local|=|" + editDefault1.Text + "",
               new Componentes.EditDefault[] { editDefault3, editDefault4 },
               new CamadaDados.Estoque.Cadastros.TCD_CadLocalArm());
        }

        private void checkBoxDefault1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vparam = "a.st_motorista|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(
                               "a.DS_CARGO|local|150;" +
                               "a.id_CARGO|Código|50",
                               new Componentes.EditDefault[] { editDefault5, editDefault6 },
                               new CamadaDados.Diversos.TCD_CargoFuncionario(),
                                vparam);
        }

        private void editDefault5_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE(
               "a.id_CARGO|=|" + editDefault5.Text + ";a.st_motorista|=|'S'",
               new Componentes.EditDefault[] { editDefault5, editDefault6 },
              new CamadaDados.Diversos.TCD_CargoFuncionario());
        }

        private void comboBoxDefault1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDefault1.SelectedValue != null)
            { 
                    if (comboBoxDefault1.SelectedValue.Equals("0"))
                    {
                        inicio.Enabled = true;
                        final.Enabled = true;
                        inicio.ST_Gravar = true;
                        inicio.ST_NotNull = true;
                        final.ST_Gravar = true;
                        final.ST_NotNull = true;
                        mesa.Visible = true;
                        mesa.Checked = false;
                        abrircartao.Visible = true;
                        abrircartao.Checked = false;
                        mesa.Enabled = true;
                    }
                    else if (comboBoxDefault1.SelectedValue.Equals("1"))
                    {
                        mesa.Checked = true;
                        mesa.Enabled = false;
                        mesa.Visible = true;
                        abrircartao.Visible = false;
                        abrircartao.Checked = false;
                        inicio.Enabled = false;
                        final.Enabled = false;
                        inicio.ST_Gravar = false;
                        inicio.ST_NotNull = false;
                        final.ST_Gravar = false;
                        final.ST_NotNull = false;
                    }
                    else if (comboBoxDefault1.SelectedValue.Equals("2"))
                    {
                        mesa.Checked = false;
                        mesa.Visible = false;
                        abrircartao.Visible = false;
                        abrircartao.Checked = false;
                        inicio.Enabled = false;
                        final.Enabled = false;
                        inicio.ST_Gravar = false;
                        inicio.ST_NotNull = false;
                        final.ST_Gravar = false;
                        final.ST_NotNull = false;
                    }
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(
                new Componentes.EditDefault[] { cd_produtoboliche, nm_produtoboliche },
                "e.st_servico|=|'S'");
        }

        private void cd_produtoboliche_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(
                "a.cd_produto|=|'" + cd_produtoboliche.Text + "';" +
                "h.st_servico|=|'S'",
                new Componentes.EditDefault[] { cd_produtoboliche, nm_produtoboliche },
                new CamadaDados.Estoque.TCD_ConsultaProduto());
        }

        private void cd_sinuca_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVEProduto(
                "a.cd_produto|=|'" + cd_produtoboliche.Text + "';" +
                "h.st_servico|=|'S'",
                new Componentes.EditDefault[] { cd_sinuca, nm_sinuca },
                new CamadaDados.Estoque.TCD_ConsultaProduto());
        }

        private void bb_sinuca_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaProduto(
                new Componentes.EditDefault[] { cd_sinuca, nm_sinuca },
                "e.st_servico|=|'S'");
        }

        private void PathBdTorneira_TextChanged(object sender, EventArgs e)
        {
            PathBdTorneira.Text = PathBdTorneira.Text.Trim();
        }
    }
}
