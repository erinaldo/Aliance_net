using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utils;

namespace Producao
{
    public partial class TFApontamentoProducao : Form
    {
        public string Id_ordem
        { get; set; }

        public CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao rApontamento
        { get { return bsApontamentoProducao.Current as CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao; } }
        
        public TFApontamentoProducao()
        {
            InitializeComponent();
        }

        private void afterGrava()
        {
            if (pApontamento.validarCampoObrigatorio())
            {
                if (dt_apontamento.Focused)
                    dt_apontamento_Leave(this, new EventArgs());
                if (dt_validade.Focused)
                    dt_validade_Leave(this, new EventArgs());
                DialogResult = DialogResult.OK;
            }
        }

        private void CalcularDisponibilidade()
        {
            if (!string.IsNullOrEmpty(CD_Empresa.Text) && 
                !string.IsNullOrEmpty(id_ordem.Text))
            {
                bsMPrima.DataSource = CamadaNegocio.Producao.Producao.TCN_MPrima.MontarListaMPrimaOrdem(CD_Empresa.Text,
                                                                                                        id_ordem.Text,
                                                                                                        (bsApontamentoProducao.Current as CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao).Qtd_batch,
                                                                                                        null,
                                                                                                        null);
                VL_CustoMPD.Value = (bsMPrima.List as CamadaDados.Producao.Producao.TList_MPrima).Sum(p => p.Vl_custo);
                VL_CustoTotal.Value = VL_CustoMPD.Value;
            }
            
        }

        private void TFApontamentoProducao_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gMPrima);
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pApontamento.set_FormatZero();
            bsApontamentoProducao.AddNew();
            if (!string.IsNullOrEmpty(Id_ordem))
            {
                id_ordem.Text = Id_ordem;
                id_ordem_Leave(this, new EventArgs());
                id_ordem.Enabled = false;
                bb_ordem.Enabled = false;
                nr_loteproducao.Focus();
            }
            else
                id_ordem.Focus();
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.NM_empresa|Nome Empresa|300;a.CD_Empresa|Cód Empresa|100";
            string vParam = "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, 
                                             new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
            CalcularDisponibilidade();
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                                   "|EXISTS|(select 1 from Tb_div_usuario_X_empresa  x where x.cd_empresa = A.cd_empresa " +
                                   "and((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                   "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                   "        where y.logingrp = x.login " +
                                   "        and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_Empresa, NM_Empresa }, 
                                                new CamadaDados.Diversos.TCD_CadEmpresa());
            CalcularDisponibilidade();
        }
        
        private void bb_Loteproducao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_loteproducao|Lote Produção|200;" +
                              "a.nr_loteproducao|Nº Lote|80;" +
                              "a.cd_loteid|Cd. LoteId|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { nr_loteproducao, ds_loteproducao },
                                            new CamadaDados.Producao.Cadastros.TCD_CadLote(),
                                            "||convert(datetime, floor(convert(decimal(30,10), getdate()))) " +
                                            "between convert(datetime, floor(convert(decimal(30,10), dt_inivigencia))) " +
                                            "and convert(datetime, floor(convert(decimal(30,10), DT_FinVigencia))) ");
        }

        private void nr_loteproducao_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.nr_loteproducao|=|" + nr_loteproducao.Text + ";" +
                              "||convert(datetime, floor(convert(decimal(30,10), getdate()))) " +
                              "between convert(datetime, floor(convert(decimal(30,10), dt_inivigencia))) " +
                              "and convert(datetime, floor(convert(decimal(30,10), DT_FinVigencia))) ";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { nr_loteproducao, ds_loteproducao },
                                            new CamadaDados.Producao.Cadastros.TCD_CadLote());
        }

        private void bb_turno_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_turno|Turno|200;"+
                              "a.id_turno|Id. Turno|80";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_turno, ds_turno },
                                            new CamadaDados.Producao.Cadastros.TCD_Turno(), string.Empty);
        }

        private void id_turno_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_turno|=|" + id_turno.Text;
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_turno, ds_turno },
                                                new CamadaDados.Producao.Cadastros.TCD_Turno());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_ordem_Click(object sender, EventArgs e)
        {
            string vColunas = "a.Id_ordem|Id. Ordem|80;" +
                              "a.cd_empresa|Cd. Empresa|80;" +
                              "b.nm_empresa|Empresa|150;" +
                              "a.cd_produto|Cd. Produto|80;" +
                              "c.ds_produto|Produto|150;"+
                              "a.id_formulacao|Id. Formula|60;" +
                              "a.QTD_Batch|Qtd. Batch|50";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_ordem },
                                            new CamadaDados.Producao.Producao.TCD_OrdemProducao(), string.Empty);
            if (linha != null)
            {
                CD_Empresa.Text = linha["cd_empresa"].ToString();
                NM_Empresa.Text = linha["nm_empresa"].ToString();
                (bsApontamentoProducao.Current as CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao).Id_formulacaostr = linha["id_formulacao"].ToString();
                (bsApontamentoProducao.Current as CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao).Qtd_batch = decimal.Parse(linha["QTD_Batch"].ToString());
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                CalcularDisponibilidade();
            }
            else
            {
                CD_Empresa.Enabled = true;
                BB_Empresa.Enabled = true;
            }
        }

        private void id_ordem_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_ordem|=|" + id_ordem.Text;
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_ordem },
                                            new CamadaDados.Producao.Producao.TCD_OrdemProducao());
            if (linha != null)
            {
                CD_Empresa.Text = linha["cd_empresa"].ToString();
                NM_Empresa.Text = linha["nm_empresa"].ToString();
                (bsApontamentoProducao.Current as CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao).Id_formulacaostr = linha["id_formulacao"].ToString();
                (bsApontamentoProducao.Current as CamadaDados.Producao.Producao.TRegistro_ApontamentoProducao).Qtd_batch = decimal.Parse(linha["QTD_Batch"].ToString());
                CD_Empresa.Enabled = false;
                BB_Empresa.Enabled = false;
                CalcularDisponibilidade();
            }
            else
            {
                CD_Empresa.Enabled = true;
                BB_Empresa.Enabled = true;
            }
        }

        private void dt_apontamento_Leave(object sender, EventArgs e)
        {
            if (dt_apontamento.Text.SoNumero().Length.Equals(8))
                if (!string.IsNullOrEmpty(dt_validade.Text.SoNumero()) &&
                    dt_apontamento.Data > dt_validade.Data)
                {
                    MessageBox.Show("Dt.Apontamento não pode ser maior que data de validade!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_apontamento.Clear();
                    dt_apontamento.Focus();
                }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFApontamentoProducao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void TFApontamentoProducao_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gMPrima);
        }

        private void dt_validade_Leave(object sender, EventArgs e)
        {
            if (dt_validade.Text.SoNumero().Length.Equals(8))
                if (!string.IsNullOrEmpty(dt_apontamento.Text.SoNumero()) &&
                    dt_apontamento.Data >= dt_validade.Data)
                {
                    MessageBox.Show("Dt.Validade não pode ser menor ou igual que data de apontamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dt_validade.Clear();
                    dt_validade.Focus();
                }
        }
    }
}
