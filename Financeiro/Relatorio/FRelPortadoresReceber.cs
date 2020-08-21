using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro.Relatorio
{
    public partial class TFRelPortadoresReceber : Form
    {
        private bool Altera_Relatorio = false;
        public TFRelPortadoresReceber()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new TDataCombo("SEGUNDA-FEIRA", "1"));
            cbx.Add(new TDataCombo("TERÇA-FEIRA", "2"));
            cbx.Add(new TDataCombo("QUARTA-FEIRA", "3"));
            cbx.Add(new TDataCombo("QUINTA-FEIRA", "4"));
            cbx.Add(new TDataCombo("SEXTA-FEIRA", "5"));
            cbx.Add(new TDataCombo("SÁBADO", "6"));
            cbx.Add(new TDataCombo("DOMINGO", "7"));
            cbxInicioSemana.DataSource = cbx;
            cbxInicioSemana.DisplayMember = "Display";
            cbxInicioSemana.ValueMember = "Value";
        }

        private void LimparFiltros()
        {
            dt_ini.Text = string.Empty;
            dt_fin.Text = string.Empty;
        }

        private void GerarRelatorio()
        { 
            if (string.IsNullOrEmpty(dt_ini.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar Dt.Inicio!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (string.IsNullOrEmpty(dt_fin.Text.SoNumero()))
            {
                MessageBox.Show("Obrigatório informar Dt.Final!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbxInicioSemana.SelectedValue == null)
            {
                MessageBox.Show("Informe o Início da Semana!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Informe a Empresa!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            CamadaDados.Financeiro.Relatorios.TList_PortadorReceber lPort = 
                new CamadaDados.Financeiro.Relatorios.TList_PortadorReceber();
            //Buscar Cheque
                new CamadaDados.Financeiro.Relatorios.TCD_PortadorReceber().SelectChequesReceber(
                    new Utils.TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "x.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "x.dt_vencto",
                            vOperador = "between",
                            vVL_Busca = "'" + Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd").Trim()  + "'" + " and " +
                                        "'" + Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd").Trim() + "'"
                        }
                    }, cbxInicioSemana.SelectedValue.ToString()).ForEach(p =>
                        lPort.Add(new CamadaDados.Financeiro.Relatorios.TRegistro_PortadorReceber()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nm_empresa = p.Nm_empresa,
                            Periodo_Inicial = p.Periodo.Equals("0") ? lPort.FindLast(x=> x.Portador.Equals("CHEQUE")).Periodo_Inicial.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[0]),
                            Periodo_Final = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("CHEQUE")).Periodo_Final.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[1]),
                            Portador = "CHEQUE",
                            Valor = p.Valor
                        }));


            //Buscar Cartão
                new CamadaDados.Financeiro.Relatorios.TCD_PortadorReceber().SelectCartaoReceber(
                    new Utils.TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "x.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "x.dt_vencto",
                            vOperador = "between",
                            vVL_Busca = "'" + Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd").Trim()  + "'" + " and " +
                                        "'" + Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd").Trim() + "'"
                        }
                    }, cbxInicioSemana.SelectedValue.ToString()).ForEach(p =>
                        lPort.Add(new CamadaDados.Financeiro.Relatorios.TRegistro_PortadorReceber()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nm_empresa = p.Nm_empresa,
                            Periodo_Inicial = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("CARTÃO")).Periodo_Inicial.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[0]),
                            Periodo_Final = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("CARTÃO")).Periodo_Final.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[1]),
                            Portador = "CARTÃO",
                            Valor = p.Valor
                        }));

            //Buscar Duplicata
                new CamadaDados.Financeiro.Relatorios.TCD_PortadorReceber().SelectDuplicataReceber(
                    new Utils.TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "x.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "x.dt_vencto",
                            vOperador = "between",
                            vVL_Busca = "'" + Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd").Trim()  + "'" + " and " +
                                        "'" + Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd").Trim() + "'"
                        }
                    }, cbxInicioSemana.SelectedValue.ToString()).ForEach(p =>
                        lPort.Add(new CamadaDados.Financeiro.Relatorios.TRegistro_PortadorReceber()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nm_empresa = p.Nm_empresa,
                            Periodo_Inicial = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("DUPLICATA")).Periodo_Inicial.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[0]),
                            Periodo_Final = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("DUPLICATA")).Periodo_Final.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[1]),
                            Portador = "DUPLICATA",
                            Valor = p.Valor
                        }));

            //Buscar Boleto
                new CamadaDados.Financeiro.Relatorios.TCD_PortadorReceber().SelectBoletoReceber(
                    new Utils.TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "x.cd_empresa",
                            vOperador = "=",
                            vVL_Busca = "'" + cbEmpresa.SelectedValue.ToString().Trim() + "'"
                        },
                        new TpBusca()
                        {
                            vNM_Campo = "y.dt_vencto",
                            vOperador = "between",
                            vVL_Busca = "'" + Convert.ToDateTime(dt_ini.Text).ToString("yyyyMMdd").Trim()  + "'" + " and " +
                                        "'" + Convert.ToDateTime(dt_fin.Text).ToString("yyyyMMdd").Trim() + "'"
                        }
                    }, cbxInicioSemana.SelectedValue.ToString()).ForEach(p =>
                        lPort.Add(new CamadaDados.Financeiro.Relatorios.TRegistro_PortadorReceber()
                        {
                            Cd_empresa = p.Cd_empresa,
                            Nm_empresa = p.Nm_empresa,
                            Periodo_Inicial = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("BOLETO")).Periodo_Inicial.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[0]),
                            Periodo_Final = p.Periodo.Equals("0") ? lPort.FindLast(x => x.Portador.Equals("BOLETO")).Periodo_Final.Value.AddDays(-7) : Convert.ToDateTime(p.Periodo.Split(new char[] { ',' })[1]),
                            Portador = "BOLETO",
                            Valor = p.Valor
                        }));

            BindingSource bsPortador = new BindingSource();
            bsPortador.DataSource = lPort.OrderBy(p => p.Periodo_Inicial);


            using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
            {
                FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                Rel.Altera_Relatorio = Altera_Relatorio;
                Rel.Nome_Relatorio = this.Name;
                Rel.NM_Classe = this.Name;
                Rel.Modulo = "FIN";
                Rel.DTS_Relatorio = bsPortador;
                fImp.St_enabled_enviaremail = true;
                fImp.pCd_clifor = string.Empty;
                fImp.pMensagem = "RELATORIO DE TOTAL PORTADORES A RECEBER";
                if (Altera_Relatorio)
                {
                    Rel.Gera_Relatorio(string.Empty,
                                       fImp.pSt_imprimir,
                                       fImp.pSt_visualizar,
                                       fImp.pSt_enviaremail,
                                       fImp.pSt_exportPdf,
                                       fImp.Path_exportPdf,
                                       fImp.pDestinatarios,
                                       null,
                                       "RELATORIO DE TOTAL PORTADORES A RECEBER",
                                       fImp.pDs_mensagem);
                    Altera_Relatorio = false;
                }
                else
                    if ((fImp.ShowDialog() == DialogResult.OK) || (fImp.pSt_enviaremail))
                    Rel.Gera_Relatorio(string.Empty,
                                            fImp.pSt_imprimir,
                                            fImp.pSt_visualizar,
                                            fImp.pSt_enviaremail,
                                            fImp.pSt_exportPdf,
                                            fImp.Path_exportPdf,
                                            fImp.pDestinatarios,
                                            null,
                                            "RELATORIO DE TOTAL PORTADORES A RECEBER",
                                            fImp.pDs_mensagem);
            }
        }

        private void TFRelPortadoresReceber_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Financeiro.Properties.Settings.Default.ST_INISEMANA))
                cbxInicioSemana.SelectedValue = Financeiro.Properties.Settings.Default.ST_INISEMANA;
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            //Buscar Empresa
            cbEmpresa.DataSource = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
                                    new Utils.TpBusca[]
                                    {
                                        new Utils.TpBusca()
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

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            this.GerarRelatorio();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TFRelPortadoresReceber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.LimparFiltros();
            else if (e.KeyCode.Equals(Keys.F8))
                this.GerarRelatorio();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                this.Altera_Relatorio = true;
                MessageBox.Show("Selecione o relatorio para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbxInicioSemana_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxInicioSemana.DisplayMember == "Display" && cbxInicioSemana.ValueMember == "Value")
            {
                Financeiro.Properties.Settings.Default.ST_INISEMANA = cbxInicioSemana.SelectedValue.ToString();
                Financeiro.Properties.Settings.Default.Save();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            this.LimparFiltros();
        }
    }
}
