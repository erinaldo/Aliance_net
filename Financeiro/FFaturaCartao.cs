using System;
using System.Data;
using System.Windows.Forms;
using FormBusca;

namespace Financeiro
{
    public partial class TFFaturaCartao : Form
    {
        public string Tp_fatura
        { get; set; }
        public string Cd_empresa
        { get; set; }
        public string Tp_movimento
        { get; set; }
        public DateTime? Dt_fatura
        { get; set; }
        public decimal Vl_nominal
        { get; set; }
        public decimal Vl_juro
        { get; set; }
        public string D_C
        { get; set; }

        public CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFatura
        {
            get
            {
                if (bsFaturaCartao.Count > 0)
                {
                    CamadaDados.Financeiro.Cartao.TList_FaturaCartao lFat = new CamadaDados.Financeiro.Cartao.TList_FaturaCartao();
                    for (int i = 0; i < bsFaturaCartao.Count; i++)
                        lFat.Add(bsFaturaCartao[i] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao);
                    return lFat;
                }
                else
                    return null;
            }
        }

        public TFFaturaCartao()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PAGAR", "P"));
            cbx1.Add(new Utils.TDataCombo("RECEBER", "R"));
            tp_movimento.DataSource = cbx1;
            tp_movimento.DisplayMember = "Display";
            tp_movimento.ValueMember = "Value";

            Cd_empresa = string.Empty;
            Tp_movimento = string.Empty;
            Tp_fatura = string.Empty;
            Dt_fatura = null;
            Vl_nominal = decimal.Zero;
            Vl_juro = decimal.Zero;
            D_C = string.Empty;
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bsBandeiraCartao.Current == null)
                {
                    MessageBox.Show("Obrigatório informar bandeira cartão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (bsMaquina.Current == null ? true : !(bsMaquina.List as CamadaDados.Financeiro.Cadastros.TList_CadMaquinaCartao).Exists(p => p.St_processar))
                {
                    MessageBox.Show("Obrigatório selecionar maquina cartão.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (bsParcelas.Count > 1)
                {
                    for (int i = 0; i < bsParcelas.Count; i++)
                        if (i == 0)
                        {
                            (bsFaturaCartao[i] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_bandeira = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).ID_Bandeira;
                            (bsFaturaCartao[i] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Ds_bandeira = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).DS_Bandeira;
                            (bsFaturaCartao[i] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Vl_nominal = (bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_parcela;
                            (bsFaturaCartao[i] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Vl_juro = (bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_juro;
                            (bsFaturaCartao[i] as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_maquinastr = (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).Id_maquinastr;
                        }
                        else
                            bsFaturaCartao.Add(new CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao()
                            {
                                Cd_empresa = CD_Empresa.Text,
                                Tp_movimento = tp_movimento.SelectedValue != null ? tp_movimento.SelectedValue.ToString() : string.Empty,
                                Id_bandeirastr = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).Id_bandeirastr,
                                Ds_bandeira = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).DS_Bandeira,
                                Id_maquinastr = (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).Id_maquinastr,
                                Id_cartaostr = id_cartao.Text,
                                Nr_cartao = nr_cartao.Text,
                                Nomeusuario = nomeusuario.Text,
                                Dt_fatura = (bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TParcelas).Dt_vencimento,
                                Vl_nominal = (bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_parcela,
                                Vl_juro = (bsParcelas[i] as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_juro
                            });
                }
                else
                {
                    (bsFaturaCartao.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_bandeira = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).ID_Bandeira;
                    (bsFaturaCartao.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Ds_bandeira = (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).DS_Bandeira;
                    (bsFaturaCartao.Current as CamadaDados.Financeiro.Cartao.TRegistro_FaturaCartao).Id_maquinastr = (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).Id_maquinastr;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFFaturaCartao_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gBandeiraCartao);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            bsFaturaCartao.AddNew();
            CD_Empresa.Text = Cd_empresa;
            dt_fatura.Text = Dt_fatura.HasValue ? Dt_fatura.Value.ToString("dd/MM/yyyy") : string.Empty;
            vl_nominal.Value = Vl_nominal;
            vl_juro.Value = Vl_juro;
            vl_nominal.Enabled = Vl_nominal.Equals(decimal.Zero);
            vl_juro.Enabled = Vl_juro.Equals(decimal.Zero);
            tp_movimento.Enabled = string.IsNullOrEmpty(Tp_movimento);
            tp_movimento.SelectedValue = Tp_movimento;
            //Buscar bandeira cartao
            bsBandeiraCartao.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_Cad_BandeiraCartao.Buscar(string.Empty,
                                                                                                           string.Empty,
                                                                                                           D_C,
                                                                                                           0,
                                                                                                           string.Empty,
                                                                                                           null);

            //Buscar Maquina Cartao
            bsMaquina.DataSource = CamadaNegocio.Financeiro.Cadastros.TCN_CadMaquinaCartao.Buscar(string.Empty, string.Empty, null);
            if (bsMaquina.List.Count.Equals(1))
            {
                (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar = true;
                bsMaquina.ResetCurrentItem();
            }
        }

        private void BB_Empresa_Click(object sender, EventArgs e)
        {
            string vParam = "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                            "where x.cd_empresa = a.cd_empresa " +
                            "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                            "(exists(select 1 from tb_div_usuario_x_grupos y " +
                            "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.BTN_BUSCA("a.NM_Empresa|Nome Empresa|150;a.CD_EMPRESA|Código|80"
                , new Componentes.EditDefault[] { CD_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa(), vParam);
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            string vColunas = "a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "';" +
                              "|exists|(select 1 from tb_div_usuario_x_empresa x " +
                              "where x.cd_empresa = a.cd_empresa " +
                              "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                              "(exists(select 1 from tb_div_usuario_x_grupos y " +
                              "         where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { CD_Empresa }, new CamadaDados.Diversos.TCD_CadEmpresa());
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cartao|Cartão|200;" +
                              "a.nr_cartao|Nº Cartão|100;" +
                              "a.nomeusuario|Titular|100;" +
                              "a.id_cartao|Id. cartão|80";
            string vParam = string.Empty;
            if (bsBandeiraCartao.Current != null)
                vParam += "a.id_bandeira|=|" + (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).Id_bandeirastr;
            DataRowView linha = UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_cartao, nr_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito(), vParam);
            if (linha != null)
                nomeusuario.Text = linha["nomeusuario"].ToString();
        }

        private void BB_Clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.NM_Clifor|Nome|150;a.CD_clifor|Código|100;NR_CGC|CNPJ|100;NR_CPF|CPF|100"
                , new Componentes.EditDefault[] { CD_Clifor, nomeusuario }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), string.Empty);
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            DataRow linha = UtilPesquisa.EDIT_LEAVE("a.CD_clifor|=|'" + CD_Clifor.Text.Trim() + "'"
               , new Componentes.EditDefault[] { CD_Clifor, nomeusuario }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void TFFaturaCartao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void qtd_parcelas_Leave(object sender, EventArgs e)
        {
            if (vl_nominal.Value.Equals(0))
            {
                MessageBox.Show("Necessario informar valor fatura.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                qtd_parcelas.Value = qtd_parcelas.Minimum;
                if (!vl_nominal.Focus())
                    qtd_parcelas.Focus();
            }
            //Calcular parcelas
            bsParcelas.DataSource = CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.CalcularParcelas(vl_nominal.Value,
                                                                                                         vl_juro.Value,
                                                                                                         dt_fatura.Data,
                                                                                                         qtd_parcelas.Value,
                                                                                                         decimal.Zero);
            if (qtd_parcelas.Value > 1)
                Height = 635;
            else
                Height = 460;
        }

        private void bsParcelas_PositionChanged(object sender, EventArgs e)
        {
            vl_parcela.Enabled = !bsParcelas.Position.Equals(bsParcelas.Count - 1);
        }

        private void dt_parcela_Leave(object sender, EventArgs e)
        {
            CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.ValidarDtEmissao(bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas,
                                                                                 dt_fatura.Data,
                                                                                 decimal.Zero,
                                                                                 bsParcelas.Position);
            bsParcelas.ResetBindings(true);
        }

        private void vl_parcela_Leave(object sender, EventArgs e)
        {
            (bsParcelas.Current as CamadaDados.Financeiro.Duplicata.TParcelas).Vl_parcela = vl_parcela.Value;
            CamadaNegocio.Financeiro.Duplicata.TLanCalcParcelas.reajustaValorParcela(bsParcelas.List as CamadaDados.Financeiro.Duplicata.TList_Parcelas,
                                                                                     vl_nominal.Value,
                                                                                     bsParcelas.Position);
            bsParcelas.ResetBindings(true);
        }

        private void id_cartao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cartao|=|" + id_cartao.Text;

            if (bsBandeiraCartao.Current != null)
                vParam += ";a.id_bandeira|=|" + (bsBandeiraCartao.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Cad_BandeiraCartao).Id_bandeirastr;
            DataRow linha = UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_cartao, nr_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito());
            if (linha != null)
                nomeusuario.Text = linha["nomeusuario"].ToString();
        }

        private void TFFaturaCartao_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gBandeiraCartao);
        }

        private void gMaquina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (!(bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar)
                {
                    (bsMaquina.List as CamadaDados.Financeiro.Cadastros.TList_CadMaquinaCartao).ForEach(p => p.St_processar = false);
                    gMaquina.Refresh();
                }
                (bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar = !(bsMaquina.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadMaquinaCartao).St_processar;
                bsMaquina.ResetCurrentItem();
            }
        }

        private void gMaquina_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Tab))
                nr_autorizacao.Focus();
        }
    }
}
