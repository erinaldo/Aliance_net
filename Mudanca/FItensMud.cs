using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mudanca
{
    public partial class TFItensMud : Form
    {
        public CamadaDados.Mudanca.TList_LanItensMud plItensMud
        { get; set; }
        public CamadaDados.Mudanca.TList_LanItensMud lItensDel
        { get; set; }
        public List<CamadaDados.Mudanca.TRegistro_LanItensMud> lItens
        {
            get
            {
                if (bsItensMud.Count > 0)
                    return (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).FindAll(p => p.St_processar);
                else
                    return null;
            }
        }

        public TFItensMud()
        {
            InitializeComponent();
            this.lItensDel = new CamadaDados.Mudanca.TList_LanItensMud();
        }

        private void afterGrava()
        {
            if (bsItensMud.Count > 0)
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Não existem Itens selecionados!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            List<CamadaDados.Mudanca.TRegistro_LanItensMud> lItensMud = new List<CamadaDados.Mudanca.TRegistro_LanItensMud>();
            CamadaDados.Mudanca.Cadastros.TList_CadItens  lCadItens =
               CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Buscar(string.Empty, string.Empty, string.Empty, string.Empty, null);
            lCadItens.ForEach(p =>
                {
                    CamadaDados.Mudanca.TRegistro_LanItensMud rItens = new CamadaDados.Mudanca.TRegistro_LanItensMud();
                    rItens.Id_item = p.Id_item;
                    rItens.Ds_item = p.Ds_item;
                    rItens.Id_itempai = p.Id_itempai;
                    rItens.Classificacao = p.Classificacao;
                    rItens.MetragemCub = p.MetragemCub;
                    rItens.St_sintetico = p.St_sinteticobool;
                    if(lItensMud != null)
                        if (plItensMud.Exists(v => v.Id_item.Equals(rItens.Id_item)))
                        {
                            rItens.St_processar = true;
                            rItens.Cd_empresa = plItensMud.Find(v => v.Id_item.Equals(rItens.Id_item)).Cd_empresa;
                            rItens.Id_mudanca = plItensMud.Find(v => v.Id_item.Equals(rItens.Id_item)).Id_mudanca;
                            rItens.Quantidade = plItensMud.Find(v => v.Id_item.Equals(rItens.Id_item)).Quantidade;
                            rItens.Vl_seguro = plItensMud.Find(v => v.Id_item.Equals(rItens.Id_item)).Vl_seguro;
                        }
                    lItensMud.Add(rItens);
                });
            bsItensMud.DataSource = lItensMud;
            bsItensMud.ResetCurrentItem();
            tot_mtcubico.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
            tot_vlseguro.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
        }
        
        private void TFItensMud_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            this.afterBusca();
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFItensMud_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
        }

        private void gItens_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico)
                {
                    MessageBox.Show("Não é permitido incluir item SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_processar =
                         !(bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_processar;
                //Informar Quantidade e Vl.Seguro
                if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_processar)
                {
                    using (TFItensValores fValor = new TFItensValores())
                    {
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero)
                            {
                                (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Quantidade = fValor.Quantidade;
                                (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Vl_seguro = fValor.Vl_seguro;
                            }
                    }
                    if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Quantidade.Equals(decimal.Zero))
                        (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_processar = false;

                    bsItensMud.ResetCurrentItem();
                    tot_mtcubico.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_vlseguro.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
                else
                {
                    if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_mudanca.HasValue)
                        lItensDel.Add(bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud);
                    (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Quantidade = decimal.Zero;
                    (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Vl_seguro = decimal.Zero;
                    bsItensMud.ResetCurrentItem();
                    tot_mtcubico.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_vlseguro.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
            }
        }

        private void gItens_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 0)
                    if ((bsItensMud[e.RowIndex] as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico.Equals(true))
                    {
                        gItens.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                        gItens.Rows[e.RowIndex].DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
                    }
            }
        }

        private void gItens_DoubleClick(object sender, EventArgs e)
        {
            if(bsItensMud.Current != null)
                if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_processar)
                {
                    using (TFItensValores fValor = new TFItensValores())
                    {
                        fValor.Quantidade = (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Quantidade;
                        fValor.Vl_seguro = (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Vl_seguro;
                        if (fValor.ShowDialog() == DialogResult.OK)
                            if (fValor.Quantidade > decimal.Zero)
                            {
                                (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Quantidade = fValor.Quantidade;
                                (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Vl_seguro = fValor.Vl_seguro;
                            }
                    }
                    if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Quantidade.Equals(decimal.Zero))
                        (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_processar = false;

                    bsItensMud.ResetCurrentItem();
                    tot_mtcubico.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_metragemCub).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                    tot_vlseguro.Text = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Sum(p => p.Tot_seguro).ToString("N2", new System.Globalization.CultureInfo("pt-BR"));
                }
        }

        private void tsmNovo_Click(object sender, EventArgs e)
        {
            if (bsItensMud.Current != null)
                using (TFCadItensResumido fRes = new TFCadItensResumido())
                {
                    if(fRes.ShowDialog() == DialogResult.OK)
                        try
                        {
                            CamadaDados.Mudanca.Cadastros.TRegistro_CadItens rItem = new CamadaDados.Mudanca.Cadastros.TRegistro_CadItens();
                            rItem.Id_itempai = (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico ?
                                                    (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_item :
                                                    (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_itempai;
                            rItem.Classificacao = (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Classificacao;
                            rItem.Ds_item = fRes.Ds_item;
                            rItem.MetragemCub = fRes.MetragemCubica;
                            CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Gravar(rItem, null);
                            MessageBox.Show("Item gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).Add(
                                new CamadaDados.Mudanca.TRegistro_LanItensMud()
                                {
                                    Id_item = rItem.Id_item,
                                    Ds_item = rItem.Ds_item,
                                    Id_itempai = rItem.Id_itempai,
                                    Classificacao = rItem.Classificacao,
                                    MetragemCub = rItem.MetragemCub,
                                    St_sintetico = rItem.St_sinteticobool
                                });
                            bsItensMud.DataSource = (bsItensMud.List as List<CamadaDados.Mudanca.TRegistro_LanItensMud>).OrderBy(p => p.Classificacao).ToList();
                            bsItensMud.ResetCurrentItem();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void ds_itemBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow linha = gItens.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pds_item"].Value.ToString().Contains(ds_itemBusca.Text)).First();
                if (linha != null)
                {
                    gItens.Rows[linha.Index].Selected = true;
                    bsItensMud.Position = linha.Index;
                }
            }
            catch { }
        }

        private void excluirItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(bsItensMud.Current != null)
                if(MessageBox.Show("Confirma exclusão do item selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Excluir(
                            new CamadaDados.Mudanca.Cadastros.TRegistro_CadItens() { Id_item = (bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_item }, null);
                        MessageBox.Show("Item excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void moverParaCimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItensMud.Current != null)
            {
                if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico)
                {
                    MessageBox.Show("Não é permitido mover registro SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsItensMud[bsItensMud.Position - 1] as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico)
                {
                    MessageBox.Show("Não é permitido mover primeiro registro do grupo para CIMA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaDados.Mudanca.Cadastros.TRegistro_CadItens rItem =
                    CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Buscar((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_itemstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    CamadaDados.Mudanca.Cadastros.TRegistro_CadItens rItemAnt =
                        CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Buscar((bsItensMud[bsItensMud.Position - 1] as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_itemstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];

                    CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.MoverRegistros(rItem, rItemAnt, null);
                    this.afterBusca();
                    bsItensMud.MovePrevious();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void moverParaBaixoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bsItensMud.Current != null)
            {
                if ((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico)
                {
                    MessageBox.Show("Não é permitido mover registro SINTÉTICO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((bsItensMud[bsItensMud.Position + 1] as CamadaDados.Mudanca.TRegistro_LanItensMud).St_sintetico)
                {
                    MessageBox.Show("Não é permitido mover ultimo registro do grupo para BAIXO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    CamadaDados.Mudanca.Cadastros.TRegistro_CadItens rItem =
                    CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Buscar((bsItensMud.Current as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_itemstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    CamadaDados.Mudanca.Cadastros.TRegistro_CadItens rItemAnt =
                        CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.Buscar((bsItensMud[bsItensMud.Position + 1] as CamadaDados.Mudanca.TRegistro_LanItensMud).Id_itemstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];

                    CamadaNegocio.Mudanca.Cadastros.TCN_CadItens.MoverRegistros(rItem, rItemAnt, null);
                    this.afterBusca();
                    bsItensMud.MoveNext();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
