using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Contabil.Cadastro;

namespace FormBusca
{
    public partial class TFBuscarContasContabeis : Form
    {
        public Utils.TpBusca[] pFiltro
        { get; set; }
        public TRegistro_CadPlanoContas rConta
        { get; set; }
        private int index = 1;

        public TFBuscarContasContabeis()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (BS_CadPlanoContas.Current != null)
            {
                if ((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Tp_conta.ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido selecionar conta SINTÉTICA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                rConta = BS_CadPlanoContas.Current as TRegistro_CadPlanoContas;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void OrganizarContas(TRegistro_CadPlanoContas val)
        {
            if (BS_CadPlanoContas.Current != null)
            {
                if (val != null)
                {
                    if (val.Tp_conta.Equals("S"))
                    {
                        List<TRegistro_CadPlanoContas> lContas =
                        CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Buscar(string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               val.Cd_conta_ctbstr,
                                                                               null).OrderBy(x => x.Ds_contactb).ToList();
                        if (!lContas.Exists(x => x.Tp_conta.Equals("S")))
                        {
                            for (int i = 0; lContas.Count > i; i++)
                            {
                                string sequencia = (i + 1).ToString().PadLeft(3, '0');
                                lContas[i].Cd_classificacao = val.Cd_classificacao.ToString().Trim() + "." + sequencia;
                                CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.MoverRegistros(lContas[i], lContas[i], null);
                            }
                            this.BuscarContaCtb();
                        }
                    }
                }
                else
                    (BS_CadPlanoContas.DataSource as TList_CadPlanoContas).ForEach(p =>
                        {
                            if (p.Tp_conta.Equals("S"))
                            {
                                List<TRegistro_CadPlanoContas> lContas =
                                CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Buscar(string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       p.Cd_conta_ctbstr,
                                                                                       null).OrderBy(x=> x.Ds_contactb).ToList();
                                if (!lContas.Exists(x => x.Tp_conta.Equals("S")))
                                {
                                    for (int i = 0; lContas.Count > i; i++)
                                    {
                                        string sequencia = (i + 1).ToString().PadLeft(3, '0');
                                        lContas[i].Cd_classificacao = p.Cd_classificacao.ToString().Trim() + "." + sequencia;
                                        CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.MoverRegistros(lContas[i], lContas[i], null);
                                    }
                                    this.BuscarContaCtb();
                                }
                            }
                        });
            }
        }

        private void BuscarContaCtb()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[0];
            if(pFiltro != null)
                if(pFiltro.Length > 0)
                    for (int i = 0; i < pFiltro.Length; i++)
                    {
                        Array.Resize(ref filtro, filtro.Length + 1);
                        filtro[filtro.Length - 1].vNM_Campo = pFiltro[i].vNM_Campo;
                        filtro[filtro.Length - 1].vOperador = pFiltro[i].vOperador;
                        filtro[filtro.Length - 1].vVL_Busca = pFiltro[i].vVL_Busca;
                    }
            if (!string.IsNullOrEmpty(ds_conta.Text))
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "a.ds_contactb";
                filtro[filtro.Length - 1].vOperador = "like";
                filtro[filtro.Length - 1].vVL_Busca = "('%" + ds_conta.Text.Trim() + "%') or " +
                                                        "exists (select 1 from TB_CTB_PlanoContas x " +
                                                        "where x.cd_conta_CTB = a.CD_Conta_CTBPai " +
                                                        "and x.DS_ContaCTB like '%" + ds_conta.Text.Trim() + "%')";
            }
            BS_CadPlanoContas.DataSource = new TCD_CadPlanoContas().Select(filtro, 0, string.Empty, "a.cd_classificacao asc");
        }

        private void BuscarIndexContaCtb()
        {
            try
            {
                if (BS_CadPlanoContas.Current != null)
                {
                    var linha = g_CadPlanocontas.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pDs_contactb"].Value.ToString().Contains(ds_conta.Text)).ToList();
                    if (linha != null)
                    {
                        if (index + 1 < linha.Count)
                            index++;
                        else
                            index = 0;
                        var p = linha[index];
                        g_CadPlanocontas.Rows[p.Index].Selected = true;
                        BS_CadPlanoContas.Position = p.Index;
                        lbSequencia.Text = (index + 1).ToString() + " de " + linha.Count;
                    }
                }
            }
            catch { }
        }

        private void MoverBaixo()
        {
            if (BS_CadPlanoContas.Current != null)
            {
                if ((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido mover registro conta SINTÉTICA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_CadPlanoContas[BS_CadPlanoContas.Position + 1] as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido mover ultimo registro do grupo para BAIXO.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TRegistro_CadPlanoContas rItem =
                    CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Buscar((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Cd_conta_ctbstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    TRegistro_CadPlanoContas rItemAnt =
                        CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Buscar((BS_CadPlanoContas[BS_CadPlanoContas.Position + 1] as TRegistro_CadPlanoContas).Cd_conta_ctbstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.MoverRegistros(rItem, rItemAnt, null);
                    this.BuscarContaCtb();
                    BS_CadPlanoContas.MoveNext();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void MoverCima()
        {
            if (BS_CadPlanoContas.Current != null)
            {
                if ((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido mover conta SINTÉTICA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((BS_CadPlanoContas[BS_CadPlanoContas.Position - 1] as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S"))
                {
                    MessageBox.Show("Não é permitido mover primeiro registro do grupo para CIMA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    TRegistro_CadPlanoContas rItem =
                    CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Buscar((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Cd_conta_ctbstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    TRegistro_CadPlanoContas rItemAnt =
                        CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Buscar((BS_CadPlanoContas[BS_CadPlanoContas.Position - 1] as TRegistro_CadPlanoContas).Cd_conta_ctbstr,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        string.Empty,
                                                                        null)[0];
                    CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.MoverRegistros(rItem, rItemAnt, null);
                    this.BuscarContaCtb();
                    BS_CadPlanoContas.MovePrevious();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void ds_conta_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow linha = g_CadPlanocontas.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pDs_contactb"].Value.ToString().Contains(ds_conta.Text)).First();
                if (linha != null)
                {
                    g_CadPlanocontas.Rows[linha.Index].Selected = true;
                    BS_CadPlanoContas.Position = linha.Index;
                    decimal result = g_CadPlanocontas.Rows.Cast<DataGridViewRow>().Where(p => p.Cells["pDs_contactb"].Value.ToString().Contains(ds_conta.Text)).Count();
                    if (result == 0)
                    {
                        lbResultados.Text = "NENHUM RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result == 1)
                    {
                        lbResultados.Text = result.ToString() + " RESULTADO ENCONTRADO";
                        index = 0;
                    }
                    else if (result > 1)
                    {
                        lbResultados.Text = result.ToString() + " RESULTADOS ENCONTRADOS";
                        index = 0;
                    }
                    lbSequencia.Text = (index + 1).ToString() + " de " + result.ToString();

                }
            }
            catch { }
        }

        private void g_CadPlanocontas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
            {
                if (e.ColumnIndex == 3)
                    if ((BS_CadPlanoContas[e.RowIndex] as TRegistro_CadPlanoContas).Tp_conta.Equals("S"))
                        g_CadPlanocontas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Blue;
                    else g_CadPlanocontas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void TFBuscarContasContabeis_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            this.BuscarContaCtb();
            ds_conta.Focus();
        }

        private void TFBuscarContasContabeis_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.Down))
                this.BuscarIndexContaCtb();
        }

        private void g_CadPlanocontas_DoubleClick(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void novaContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TFPlanoContas fPlano = new TFPlanoContas())
            {
                if (BS_CadPlanoContas.Current != null)
                {
                    if ((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S"))
                        fPlano.pCd_contapai = (BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Cd_conta_ctbstr;
                    else fPlano.pCd_contapai = (BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Cd_conta_ctbpaistr;
                }
                if(fPlano.ShowDialog() == DialogResult.OK)
                    if(fPlano.rPlano != null)
                        try
                        {
                            CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Gravar(fPlano.rPlano, null);
                            MessageBox.Show("Conta Contabil gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.BuscarContaCtb();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void excluirContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BS_CadPlanoContas.Current != null)
                if (MessageBox.Show("Confirma exclusão da conta selecionado?" +
                    ((BS_CadPlanoContas.Current as TRegistro_CadPlanoContas).Tp_conta.Trim().ToUpper().Equals("S") ?
                    "\r\nObs.: Conta Sintética, será cancelada automaticamente todas as contas filhas." : string.Empty),
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        CamadaNegocio.Contabil.Cadastro.TCN_PlanoContas.Excluir(BS_CadPlanoContas.Current as TRegistro_CadPlanoContas, null);
                        MessageBox.Show("Conta excluida com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.BuscarContaCtb();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void moverParaCimaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MoverCima();
        }

        private void moverParaBaixoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MoverBaixo();
        }

        private void bb_movbaixo_Click(object sender, EventArgs e)
        {
            this.MoverBaixo();
        }

        private void bb_movcima_Click(object sender, EventArgs e)
        {
            this.MoverCima();
        }

        private void bb_alfabetica_Click(object sender, EventArgs e)
        {
            this.OrganizarContas(null);
        }

        private void ordemAlfabéticaGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OrganizarContas(BS_CadPlanoContas.Current as CamadaDados.Contabil.Cadastro.TRegistro_CadPlanoContas);
        }
    }
}
