using CamadaDados.Financeiro.Cartao;
using CamadaNegocio.Financeiro.Cartao;
using FormBusca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro
{
    public partial class TFLanCartaoPrePago : Form
    {
        public TFLanCartaoPrePago()
        {
            InitializeComponent();
        }
        

        private void afterNovo()
        {
            using (TFCarregarCartaoPrePago fCarregar = new TFCarregarCartaoPrePago())
            {
                if (fCarregar.ShowDialog() == DialogResult.OK)
                    if (fCarregar.rCarregar != null)
                        try
                        {
                            TCN_CarregarCartaoPre.Gravar(fCarregar.rCarregar, null);
                            MessageBox.Show("Cartão carregado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            afterBusca();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterBusca()
        {
            TpBusca[] filtro = new TpBusca[0];
            //Empresa
            if (cbEmpresa.SelectedValue != null)
                Estruturas.CriarParametro(ref filtro, "a.cd_empresa", "'" + cbEmpresa.SelectedValue.ToString() + "'");          
            if (tcDetalhes.SelectedTab.Equals(tpCartao))
            {
                //Cartão
                if (!string.IsNullOrEmpty(id_cartao.Text))
                    Estruturas.CriarParametro(ref filtro, "a.id_cartao", id_cartao.Text);
                bsSaldoCartaoPre.DataSource =
                    new TCD_CarregaCartaoPre().SelectSaldoCartao(filtro, 0, string.Empty, string.Empty);
            }
            else if (bsSaldoCartaoPre.Current != null)
            {
                //Cartão
                Estruturas.CriarParametro(ref filtro, "a.id_cartao", (bsSaldoCartaoPre.Current as TSaldoCartaoPre).Id_cartaostr);
                if ((!string.IsNullOrEmpty(DT_Inicial.Text.Trim())) && (DT_Inicial.Text.Trim() != "/  /"))
                    Estruturas.CriarParametro(ref filtro,
                                             "a.dt_lancto",
                                             "'" + DateTime.Parse(DT_Inicial.Text).ToString("yyyyMMdd HH:mm") + "'",
                                             ">=");
                if ((!string.IsNullOrEmpty(DT_Final.Text)) && (DT_Final.Text.Trim() != "/  /"))
                    Estruturas.CriarParametro(ref filtro,
                                             "a.dt_lancto",
                                             "'" + DateTime.Parse(DT_Final.Text).ToString("yyyyMMdd HH:mm") + "'",
                                             "<=");
                bsMovCartaoPre.DataSource =
                    new TCD_CarregaCartaoPre().SelectMovCartao(filtro, 0, string.Empty, string.Empty);
            }
        }

        private void afterExclui()
        {
            if (tcDetalhes.SelectedTab.Equals(tpLancto))
            {
                if ((bsMovCartaoPre.Current as TMovCartaoPre).Vl_credito.Equals(0))
                {
                    MessageBox.Show("Lançamento débito não pode ser excluído!\r\n" +
                                    "Registro deve ser excluído na origem do lançamento!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Confirma a exclusão do registro?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TRegistro_CarregaCartaoPre r = new TRegistro_CarregaCartaoPre();
                        r.Id_carga = (bsMovCartaoPre.Current as TMovCartaoPre).Id_carga;
                        r.Cd_empresa = (bsMovCartaoPre.Current as TMovCartaoPre).Cd_empresa;
                        r.Id_cartao = (bsMovCartaoPre.Current as TMovCartaoPre).Id_cartao;
                        r.Cd_contager = (bsMovCartaoPre.Current as TMovCartaoPre).Cd_contager;
                        r.Cd_lanctocaixa = (bsMovCartaoPre.Current as TMovCartaoPre).Cd_lanctocaixa;
                        TCN_CarregarCartaoPre.Excluir(r, null);
                        MessageBox.Show("Lançamento excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
            {
                MessageBox.Show("Selecione a aba LANÇAMENTOS para efetuar a exclusão!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tcDetalhes.SelectedTab = tpLancto;
            }
        }

        private void TFLanCartaoPrePago_Load(object sender, EventArgs e)
        {
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pConsulta.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new TpBusca[]
                                    {
                                        new TpBusca()
                                        {
                                            vNM_Campo = string.Empty,
                                            vOperador = "exists",
                                            vVL_Busca = "(select 1 from tb_div_usuario_x_empresa x " +
                                                        "where x.cd_empresa = a.cd_empresa " +
                                                        "and ((x.login = '" + Utils.Parametros.pubLogin.Trim() + "') or " +
                                                        "(exists(select 1 from tb_div_usuario_x_grupos y " +
                                                        "       where y.logingrp = x.login and y.loginusr = '" + Utils.Parametros.pubLogin.Trim() + "'))))"
                                        }
                                    }, 0, string.Empty);
            cbEmpresa.DisplayMember = "NM_Empresa";
            cbEmpresa.ValueMember = "CD_Empresa";
        }

        private void id_cartao_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_cartao|=|" + id_cartao.Text +
                            ";a.st_prepago |=| 'S'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito());
        }

        private void bb_cartao_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cartao|Cartão|200;" +
                              "a.nr_cartao|Nº Cartão|100;" +
                              "a.nomeusuario|Titular|100;" +
                              "a.id_cartao|Id. cartão|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_cartao },
                                    new CamadaDados.Financeiro.Cadastros.TCD_CadCartaoCredito(), "a.st_prepago|=|'S'");
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void bb_excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TFLanCartaoPrePago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void tcDetalhes_SelectedIndexChanged(object sender, EventArgs e)
        {
            afterBusca();
        }
    }
}
