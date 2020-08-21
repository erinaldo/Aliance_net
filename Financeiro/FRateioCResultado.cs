using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Financeiro.Cadastros;

namespace Financeiro
{
    public partial class TFRateioCResultado : Form
    {
        private Utils.TTpModo vModo;
        public string Tp_mov
        { get; set; }
        public decimal vVl_Documento
        { get; set; }
        public string Cd_centroresult
        { get; set; }
        public DateTime? Dt_movimento
        { get; set; }

        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCResultadoDel
        { get; set; }
        private CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lcresultado;
        public CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto lCResultado
        {
            get
            {
                if (bsCResultado.Count > 0)
                    return bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto;
                else
                    return null;
            }
            set { lcresultado = value; }
        }

        public TFRateioCResultado()
        {
            InitializeComponent();
            this.vModo = Utils.TTpModo.tm_Standby;
            this.Tp_mov = string.Empty;
            this.vVl_Documento = decimal.Zero;
            this.Cd_centroresult = string.Empty;
            this.lcresultado = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
            this.lCResultadoDel = new CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto();
        }

        private void afterNovo()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Standby))
            {
                if (vl_saldovalor.Value > 0)
                {
                    bsCResultado.AddNew();
                    (bsCResultado.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Vl_lancto = vl_saldovalor.Value;
                    (bsCResultado.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto).Dt_lancto = Dt_movimento;
                    bsCResultado.ResetCurrentItem();
                    cd_ccusto.Enabled = true;
                    bb_ccusto.Enabled = true;
                    nr_orcamento.Enabled = true;
                    bb_orcamento.Enabled = true;
                    vl_rateiocc.Enabled = true;
                    pc_rateiocc.Enabled = true;
                    dt_lancto.Enabled = true;
                    cd_ccusto.Focus();
                    vModo = Utils.TTpModo.tm_Insert;
                }
                else
                    MessageBox.Show("Não existe mais saldo para ratear por centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void afterGrava()
        {
            if (vModo.Equals(Utils.TTpModo.tm_Insert))
            {
                if (string.IsNullOrEmpty(dt_lancto.Text.Trim()) || dt_lancto.Text.Trim().Equals("/  /"))
                {
                    MessageBox.Show("Obrigatorio informar data do centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_lancto.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cd_ccusto.Text))
                {
                    MessageBox.Show("Obrigatorio informar centro resultado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cd_ccusto.Focus();
                    return;
                }
                if (vl_rateiocc.Value <= 0)
                {
                    MessageBox.Show("Obrigatorio informar valor rateio.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vl_rateiocc.Focus();
                    return;
                }
                if(vl_rateiocc.Focused)
                {
                    if (vl_rateiocc.Value > vl_saldovalor.Value)
                    {
                        MessageBox.Show("Valor rateio não pode ser maior que saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        vl_rateiocc.Value = vl_saldovalor.Value;
                        vl_rateiocc.Focus();
                        return;
                    }
                }
                if(pc_rateiocc.Focused)
                {
                    if (pc_rateiocc.Value > (100 - pc_total.Value))
                    {
                        MessageBox.Show("Percentual rateio não pode ser maior que saldo percentual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        pc_rateiocc.Value = 100 - pc_total.Value;
                        vl_rateiocc.Value = vl_documento.Value * pc_rateiocc.Value / 100;
                        pc_rateiocc.Focus();
                        return;
                    }
                }
                cd_ccusto.Enabled = false;
                bb_ccusto.Enabled = false;
                nr_orcamento.Enabled = false;
                bb_orcamento.Enabled = false;
                vl_rateiocc.Enabled = false;
                pc_rateiocc.Enabled = false;
                dt_lancto.Enabled = false;
                vModo = Utils.TTpModo.tm_Standby;
                vl_total.Value = (bsCResultado.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Sum(p => p.Vl_lancto);
            }
        }

        private void afterExclui()
        {
            if (bsCResultado.Current != null)
            {
                if (vModo.Equals(Utils.TTpModo.tm_Standby))
                {
                    lCResultadoDel.Add(bsCResultado.Current as CamadaDados.Financeiro.CCustoLan.TRegistro_LanCCustoLancto);
                    
                }
                vModo = Utils.TTpModo.tm_Standby;
                bsCResultado.RemoveCurrent();
                cd_ccusto.Enabled = false;
                bb_ccusto.Enabled = false;
                nr_orcamento.Enabled = false;
                bb_orcamento.Enabled = false;
                vl_rateiocc.Enabled = false;
                pc_rateiocc.Enabled = false;
                dt_lancto.Enabled = false;
                vl_total.Value = (bsCResultado.List as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Sum(p => p.Vl_lancto);
            }
            else
                MessageBox.Show("Necessario selecionar rateio para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PopulaMenus()
        {
            trvCResultado.Nodes.Clear();
            //Buscar Centro Resultado
            TList_CentroResultado lCentroResult =
                string.IsNullOrEmpty(Cd_centroresult) ?
                CamadaNegocio.Financeiro.Cadastros.TCN_CentroResultado.Buscar(string.Empty,
                                                                              string.Empty,
                                                                              string.Empty,
                                                                              null) :
                new TCD_CentroResultado().Select(
                new Utils.TpBusca[]
                {
                    new Utils.TpBusca()
                    {
                        vNM_Campo = string.Empty,
                        vOperador = string.Empty,
                        vVL_Busca = "(a.cd_centroresult = '" + Cd_centroresult.Trim() + "' or a.cd_centroresult_pai = '" + Cd_centroresult.Trim() + "')"
                    }
                }, 0, string.Empty);
            //BUSCA TODOS OS MENUS PAIS
            List<TRegistro_CentroResultado> lItensPai = lCentroResult.FindAll(p => string.IsNullOrEmpty(p.Cd_centroresult_pai) && p.Nivel.Equals(1)).OrderBy(r => r.Cd_centroresult_pai).ToList();
            if (lItensPai.Count > 0)
            {
                lItensPai.ForEach(p =>
                    {
                        TreeNode no = new TreeNode(p.Ds_centroresultado.Trim());
                        no.Name = p.Cd_centroresult.Trim();
                        no.Tag = p.St_sintetico;
                        if(p.St_sinteticobool)
                            no.ForeColor = Color.Red;
                        trvCResultado.Nodes.AddRange(new TreeNode[] { no });
                        //Buscar todos os registro filhos
                        List<TRegistro_CentroResultado> lItensFilho = lCentroResult.FindAll(v => v.Cd_centroresult_pai.Trim().Equals(p.Cd_centroresult.Trim())).OrderBy(r => r.Ds_centroresultado.Trim()).ToList();
                        if (lItensFilho.Count > 0)
                        {
                            AddCamposTree(lItensFilho, trvCResultado.Nodes);
                            VerificaExisteFilhos(lItensFilho, lCentroResult);
                        }
                    });
            }
            if (cbxExpandir.SelectedIndex.Equals(0))
                trvCResultado.ExpandAll();
            trvCResultado.SelectedNode = trvCResultado.Nodes[0];
        }

        public void AddCamposTree(List<TRegistro_CentroResultado> listaMenu, TreeNodeCollection Node)
        {
            for (int k = 0; k < Node.Count; k++)
            {
                TreeNode noMenuPai = Node[k];
                for (int q = 0; q < listaMenu.Count; q++)
                {
                    if (!string.IsNullOrEmpty(listaMenu[q].Cd_centroresult_pai))
                        if (noMenuPai.Name.ToString().Trim().Equals(listaMenu[q].Cd_centroresult_pai.Trim()))
                        {
                            TreeNode noMenu = new TreeNode(listaMenu[q].Ds_centroresultado.Trim());
                            noMenu.Name = listaMenu[q].Cd_centroresult.Trim();
                            noMenu.Tag = listaMenu[q].St_sintetico;
                            if (listaMenu[q].St_sinteticobool)
                                noMenu.ForeColor = Color.Red;
                            Node[k].Nodes.AddRange(new TreeNode[] { noMenu });
                            if (listaMenu[q].Nivel.Equals(2) && cbxExpandir.SelectedIndex.Equals(1))
                                Node[k].ExpandAll();
                        }
                }

                if (Node[k].Nodes.Count > 0)
                    AddCamposTree(listaMenu, Node[k].Nodes);
            }
        }

        public void VerificaExisteFilhos(List<TRegistro_CentroResultado> ItemsFilhosMenus, TList_CentroResultado listaMenu)
        {
            for (int i = 0; i < ItemsFilhosMenus.Count; i++)
            {
                List<TRegistro_CentroResultado> ItemsFilhos = listaMenu.FindAll(c => (c.Cd_centroresult_pai.Trim().Equals(ItemsFilhosMenus[i].Cd_centroresult.Trim())));

                if (ItemsFilhos.Count > 0)
                {
                    AddCamposTree(ItemsFilhos, trvCResultado.Nodes);
                    VerificaExisteFilhos(ItemsFilhos, listaMenu);
                }
            }
        }

        private void TFRateioCResultado_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, dataGridDefault1);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            vl_documento.Value = this.vVl_Documento;
            bsCResultado.DataSource = lcresultado;
            if (!string.IsNullOrEmpty(Financeiro.Properties.Settings.Default.ST_EXPANDIR.ToString()))
                cbxExpandir.SelectedIndex = Financeiro.Properties.Settings.Default.ST_EXPANDIR;
            else
                cbxExpandir.SelectedIndex = 0;
            this.PopulaMenus();
        }

        private void bb_ccusto_Click(object sender, EventArgs e)
        {
            using (FormBusca.TFBuscaCentroResult fBusca = new FormBusca.TFBuscaCentroResult())
            {
                string vParam = string.Empty;
                if (this.Tp_mov.Trim().ToUpper().Equals("P"))
                    vParam += "'D' or (a.tp_registro = 'R' and isnull(a.st_deducao, 'N') = 'S')";
                else vParam += "'R' or (a.tp_registro = 'D' and isnull(a.st_deducao, 'N') = 'S')";
                fBusca.Tp_registro = vParam;
                if (fBusca.ShowDialog() == DialogResult.OK)
                    if (!string.IsNullOrEmpty(fBusca.Cd_centro))
                    {
                        cd_ccusto.Text = fBusca.Cd_centro;
                        ds_ccusto.Text = fBusca.Ds_centro;
                    }
            }
            if(bsCResultado.Count > 0)
                if ((bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Exists(p => p.Cd_centroresult.Trim().Equals(cd_ccusto.Text.Trim())))
                    bsCResultado.Position = (bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).IndexOf(
                                            (bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Find(p => p.Cd_centroresult.Trim().Equals(cd_ccusto.Text.Trim())));
        }

        private void cd_ccusto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_centroresult|=|'" + cd_ccusto.Text.Trim() + "';" +
                            "isnull(a.st_sintetico, 'N')|<>|'S';";
            if (this.Tp_mov.Trim().ToUpper().Equals("P"))
                vParam += "||(a.tp_registro = 'D') or (a.tp_registro = 'R' and isnull(a.st_deducao, 'N') = 'S')";
            else vParam += "||(a.tp_registro = 'R') or (a.tp_registro = 'D' and isnull(a.st_deducao, 'N') = 'S')";

            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ccusto, ds_ccusto },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CentroResultado());
            if (bsCResultado.Count > 0)
                if ((bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Exists(p => p.Cd_centroresult.Trim().Equals(cd_ccusto.Text.Trim())))
                    bsCResultado.Position = (bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).IndexOf(
                                            (bsCResultado.DataSource as CamadaDados.Financeiro.CCustoLan.TList_LanCCustoLancto).Find(p => p.Cd_centroresult.Trim().Equals(cd_ccusto.Text.Trim())));
        }
        
        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            if(bsCResultado.Current != null)
            {

                if (string.IsNullOrEmpty(dt_lancto.Text.Trim()) || dt_lancto.Text.Trim().Equals("/  /"))
                {
                    if(MessageBox.Show("Centro de resultado sem data,\ndeseja prosseguir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                    { 
                        dt_lancto.Focus();
                        return;
                    }
                }

            }
            DialogResult = DialogResult.OK;
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.afterNovo();
        }

        private void vl_documento_ValueChanged(object sender, EventArgs e)
        {
            vl_saldovalor.Value = vl_documento.Value - vl_total.Value;
            if (vl_documento.Value > 0)
                pc_total.Value = vl_total.Value * 100 / vl_documento.Value;
        }

        private void vl_total_ValueChanged(object sender, EventArgs e)
        {
            vl_saldovalor.Value = vl_documento.Value - vl_total.Value;
            if (vl_documento.Value > 0)
                pc_total.Value = vl_total.Value * 100 / vl_documento.Value;
        }

        private void vl_rateiocc_Leave(object sender, EventArgs e)
        {
            if (vl_rateiocc.Value > vl_saldovalor.Value)
            {
                MessageBox.Show("Valor rateio não pode ser maior que saldo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                vl_rateiocc.Value = vl_saldovalor.Value;
                vl_rateiocc.Focus();
            }
            if (vl_documento.Value > 0)
                pc_rateiocc.Value = vl_rateiocc.Value * 100 / vl_documento.Value;
        }

        private void pc_rateiocc_Leave(object sender, EventArgs e)
        {
            if (pc_rateiocc.Value > (100 - pc_total.Value))
            {
                MessageBox.Show("Percentual rateio não pode ser maior que saldo percentual.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pc_rateiocc.Value = 100 - pc_total.Value;
                pc_rateiocc.Focus();
            }
            vl_rateiocc.Value = vl_documento.Value * pc_rateiocc.Value / 100;
        }

        private void trvCResultado_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
                if (e.Node.Tag.ToString().Trim().ToUpper() != "S")
                {
                    this.afterNovo();
                    cd_ccusto.Text = e.Node.Name;
                    cd_ccusto_Leave(this, new EventArgs());
                }
        }

        private void bb_orcamento_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NR_Orcamento|Nº Orçamento|80;" +
                              "a.NM_Clifor|Cliente|150;" +
                              "a.DT_Orcamento|Dt. Orçamento|100";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_orcamento },
                new CamadaDados.Faturamento.Orcamento.TCD_Orcamento(), "isnull(a.st_registro, 'AB')|<>|'CA'");
        }

        private void nr_orcamento_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LEAVE("a.nr_orcamento|=|" + nr_orcamento.Text + ";isnull(a.st_registro, 'AB')|<>|'CA'",
                new Componentes.EditDefault[] { nr_orcamento },
                new CamadaDados.Faturamento.Orcamento.TCD_Orcamento());
        }

        private void bbAddCResultado_Click(object sender, EventArgs e)
        {
            using (TFAddCResultado fAdd = new TFAddCResultado())
            {
                if(fAdd.ShowDialog() == DialogResult.OK)
                    if(fAdd.rCResult != null)
                        try
                        {
                            CamadaNegocio.Financeiro.Cadastros.TCN_CentroResultado.Gravar(fAdd.rCResult, null);
                            MessageBox.Show("Centro Resultado Gravado com Sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.PopulaMenus();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cbxExpandir_SelectedIndexChanged(object sender, EventArgs e)
        {
            Financeiro.Properties.Settings.Default.ST_EXPANDIR = cbxExpandir.SelectedIndex;
            Financeiro.Properties.Settings.Default.Save();
            this.PopulaMenus();
        }

        private void TFRateioCResultado_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vl_saldovalor.Value > decimal.Zero)
            {
                if (MessageBox.Show("Ainda existe saldo para ratear por centro de resultado.\r\n" +
                                        "Deseja gravar com saldo a ratear?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    e.Cancel = true;
            }
        }
    }
}
