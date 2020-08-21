using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Frota
{
    public partial class TFAcertoMotorista : Form
    {
        public string Cd_empresa
        { get; set; }
        public string Nm_empresa
        { get; set; }
        public string Cd_motorista
        { get; set; }
        public string Nm_motorista
        { get; set; }
        public string Id_viagem
        { get; set; }
        private bool St_adto = false;
        private CamadaDados.Frota.TRegistro_AcertoMotorista racerto;
        public CamadaDados.Frota.TRegistro_AcertoMotorista rAcerto
        {
            get
            {
                if (bsAcerto.Current != null)
                    return bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista;
                else
                    return null;
            }
            set { racerto = value; }
        }

        public TFAcertoMotorista()
        {
            InitializeComponent();
        }

        private void BuscarSaldoCredito()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_motorista.Text)))
            {
                string id_viagem = string.Empty;
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.ForEach(p => id_viagem += p.Id_viagemstr + ", ");
                if (St_adto)
                {
                    bsAdto.DataSource =
                    CamadaNegocio.Frota.TCN_AdtoViagem.BuscarAdto(cd_empresa.Text,
                                                                  !string.IsNullOrEmpty(id_viagem) ? id_viagem.Trim().TrimEnd(',') : string.Empty,
                                                                  null);
                }
                else
                {
                    bsAdto.DataSource =
                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                 cd_empresa.Text,
                                                                                 cd_motorista.Text,
                                                                                 string.Empty,
                                                                                 "'C'",
                                                                                 string.Empty,
                                                                                 decimal.Zero,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 decimal.Zero,
                                                                                 decimal.Zero,
                                                                                 false,
                                                                                 false,
                                                                                 true,
                                                                                 string.Empty,
                                                                                 false,
                                                                                 true,
                                                                                 string.Empty,
                                                                                 string.Empty,
                                                                                 0,
                                                                                 string.Empty,
                                                                                 null);
                }
                if(bsAdto.Count > 0)
                    vl_adiantamentos.Value = (bsAdto.List as CamadaDados.Financeiro.Adiantamento.TList_LanAdiantamento).Sum(p => p.Vl_total_devolver);
             
                bsOutrosAdto.DataSource =
                    CamadaNegocio.Frota.TCN_OutrasReceitas.Buscar(string.Empty,
                                                                  cd_empresa.Text,
                                                                  !string.IsNullOrEmpty(id_viagem) ? "(" + id_viagem.Trim().TrimEnd(',') + ")" : string.Empty,
                                                                  string.Empty,
                                                                  cd_motorista.Text,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  string.Empty,
                                                                  true,
                                                                  null);
                if(bsOutrosAdto.Count > 0)
                    vl_outrosadto.Value = (bsOutrosAdto.List as CamadaDados.Frota.TList_OutrasReceitas).Sum(p => p.Sd_devadtoViagem);
            }
        }

        private void TotalizarViagem()
        {
            vl_despesas.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.Sum(p => p.Vl_despM);
            vl_manutencao.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.Sum(p => p.Vl_manut);
            vl_infracoes.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.Sum(p => p.Vl_infracoes);
            vl_abastecimento.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.Sum(p => p.Vl_abastM);
            BuscarSaldoCredito();
        }

        private void afterGrava()
        {
            if (pCabec.validarCampoObrigatorio())
            {
                if ((bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Vl_cartafrete >
                    (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).Tot_despesas)
                {
                    MessageBox.Show("Valor da carta frete utilizada maior que o total de despesas.\r\n" +
                                    "Obrigatorio consumir o valor total da carta frete ou gerar credito com o saldo restante.", "Mensagem",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void TFAcertoMotorista_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pCabec.set_FormatZero();
            St_adto = CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVL_Bool("ST_ADTO_VIAGEM", string.Empty, null).Trim().ToUpper().Equals("S");
            if (racerto != null)
            {
                bsAcerto.DataSource = new CamadaDados.Frota.TList_AcertoMotorista() { racerto };
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_motorista.Enabled = false;
                bb_motorista.Enabled = false;
            }
            else
            {
                bsAcerto.AddNew();
                cd_empresa.Text = Cd_empresa;
                nm_empresa.Text = Nm_empresa;
                cd_motorista.Text = Cd_motorista;
                nm_motorista.Text = Nm_motorista;
                if (!string.IsNullOrEmpty(Id_viagem) && St_adto)
                {
                    bb_incluirViagem.Visible = false;
                    bb_excluirViagem.Visible = false;
                    (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem =
                        CamadaNegocio.Frota.TCN_Viagem.Buscar(Id_viagem,
                                                              cd_empresa.Text,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              string.Empty,
                                                              null);
                    bsAcerto.ResetCurrentItem();
                    TotalizarViagem();
                }
                this.BuscarSaldoCredito();
            }
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
            this.BuscarSaldoCredito();
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'", new Componentes.EditDefault[] { cd_empresa, nm_empresa });
            this.BuscarSaldoCredito();
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_motorista, nm_motorista }, "isnull(a.st_motorista, 'N')|=|'S';isnull(a.ST_AtivoMot, 'N')|=|'S'");
            this.BuscarSaldoCredito();
        }

        private void cd_motorista_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_motorista.Text.Trim() + "';" +
                                                    "isnull(a.st_motorista, 'N')|=|'S';" +
                                                    "isnull(a.ST_AtivoMot, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { cd_motorista, nm_motorista },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarSaldoCredito();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_excluirCF_Click(object sender, EventArgs e)
        {
            if (bsCartaFreteAcerto.Current != null)
            {
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFreteDel.Add(bsCartaFreteAcerto.Current as CamadaDados.Frota.TRegistro_CartaFrete);
                bsCartaFreteAcerto.RemoveCurrent();
                //Totalizar
                vl_cartafrete.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFrete.Sum(p => p.Vl_documento);
            }
        }

        private void bb_incluirCF_Click(object sender, EventArgs e)
        {
            if((!string.IsNullOrEmpty(cd_empresa.Text))
                && (!string.IsNullOrEmpty(cd_motorista.Text)))
                using (TFListaCartaFrete fLista = new TFListaCartaFrete())
                {
                    fLista.Cd_empresa = cd_empresa.Text;
                    fLista.Cd_motorista = cd_motorista.Text;
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lCarta != null)
                        {
                            fLista.lCarta.ForEach(p =>
                                {
                                    if (!(bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFrete.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                                                                                                                v.Nr_cartafrete.Equals(p.Nr_cartafrete)))
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFrete.Add(p);
                                });
                            bsAcerto.ResetCurrentItem();
                            //Totalizar
                            vl_cartafrete.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCartaFrete.Sum(p => p.Vl_documento);
                        }
                }
        }

        private void bb_excluirViagem_Click(object sender, EventArgs e)
        {
            if (bsViagemAcerto.Current != null)
            {
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagemDel.Add(bsViagemAcerto.Current as CamadaDados.Frota.TRegistro_Viagem);
                bsViagemAcerto.RemoveCurrent();
                this.TotalizarViagem();
            }
        }

        private void bb_incluirViagem_Click(object sender, EventArgs e)
        {
            if((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(cd_motorista.Text)))
                using (TFListaViagemMot fLista = new TFListaViagemMot())
                {
                    fLista.Cd_empresa = cd_empresa.Text;
                    fLista.Cd_motorista = cd_motorista.Text;
                    if(fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lViagem != null)
                        {
                            fLista.lViagem.ForEach(p =>
                                {
                                    if (!(bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                                                                                                            v.Id_viagem.Equals(p.Id_viagem)))
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lViagem.Add(p);
                                });
                            bsAcerto.ResetCurrentItem();
                            //Totalizar Viagem
                            this.TotalizarViagem();
                        }
                }
        }

        private void bb_addCheque_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cd_empresa.Text))
                using (Financeiro.TFLanTitulo fCheque = new Financeiro.TFLanTitulo())
                {
                    fCheque.Cd_empresa = cd_empresa.Text;
                    fCheque.CD_Empresa.Enabled = false;
                    fCheque.BB_Empresa.Enabled = false;
                    fCheque.Tp_titulo = "R";
                    fCheque.tp_titulo.Enabled = false;
                    if(fCheque.ShowDialog() == DialogResult.OK)
                        if(fCheque.BS_Titulo.Current != null)
                            try
                            {
                                (fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).St_lancarcaixa = true;
                                fCheque.BS_Titulo.ResetCurrentItem();
                                CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.GravarTitulo(fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo, null);
                                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque.Add(
                                    CamadaNegocio.Financeiro.Titulo.TCN_LanTitulo.Busca((fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_empresa,
                                                                                        (fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Nr_lanctocheque,
                                                                                        (fCheque.BS_Titulo.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo).Cd_banco,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        decimal.Zero,
                                                                                        decimal.Zero,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        false,
                                                                                        false,
                                                                                        false,
                                                                                        false,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        string.Empty,
                                                                                        1,
                                                                                        string.Empty,
                                                                                        null)[0]);
                                bsAcerto.ResetCurrentItem();
                                //Totalizar
                                vl_chtroco.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque.Sum(p => p.Vl_titulo);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_excluirCheque_Click(object sender, EventArgs e)
        {
            if (bsCheque.Current != null)
            {
                (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lChequeDel.Add(bsCheque.Current as CamadaDados.Financeiro.Titulo.TRegistro_LanTitulo);
                bsCheque.RemoveCurrent();
                //Totalizar
                vl_chtroco.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque.Sum(p => p.Vl_titulo);
            }
        }

        private void bb_incluirCheque_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(cd_empresa.Text))
                using (Proc_Commoditties.TFListaCheques fLista = new Proc_Commoditties.TFListaCheques())
                {
                    fLista.Cd_empresa = cd_empresa.Text;
                    fLista.Tp_mov = "R";
                    if(fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lCheque != null)
                        {
                            fLista.lCheque.ForEach(p =>
                                {
                                    if (!(bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                                                                                                        v.Cd_banco.Trim().Equals(p.Cd_banco.Trim()) &&
                                                                                                                        v.Nr_lanctocheque.Equals(p.Nr_lanctocheque)))
                                        (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque.Add(p);
                                });
                            bsAcerto.ResetCurrentItem();
                            //Totalizar
                            vl_chtroco.Value = (bsAcerto.Current as CamadaDados.Frota.TRegistro_AcertoMotorista).lCheque.Sum(p => p.Vl_titulo);
                        }
                }
        }

        private void TFAcertoMotorista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            afterDevolver();
        }

        private void afterDevolver()
        {
            if (bsOutrosAdto.Current != null)
            {
                if ((bsOutrosAdto.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Sd_devadtoViagem != decimal.Zero)
                    using (TFDevolucaoOutrasReceitas fdevolucao = new TFDevolucaoOutrasReceitas())
                    {
                        fdevolucao.preenche();
                        fdevolucao.vl_adtoViagem = (bsOutrosAdto.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Vl_adtoViagem;
                        if (fdevolucao.ShowDialog() == DialogResult.OK)
                            if (fdevolucao.rLancaixa != null)
                            {


                                CamadaNegocio.Financeiro.Caixa.TCN_LanCaixa.GravaLanCaixa(fdevolucao.rLancaixa, null);
                                CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas rdevolucao = new CamadaDados.Frota.Cadastros.TRegistro_DevOutrasReceitas();

                                rdevolucao.cd_contager = fdevolucao.rLancaixa.Cd_ContaGer;
                                rdevolucao.Id_lanctoCaixa = fdevolucao.rLancaixa.Cd_LanctoCaixa;
                                rdevolucao.Id_receita = (bsOutrosAdto.Current as CamadaDados.Frota.TRegistro_OutrasReceitas).Id_receita;

                                CamadaNegocio.Frota.Cadastros.TCN_DevOutrasReceitas.Gravar(rdevolucao, null);

                            }
                    }
                else
                    MessageBox.Show("Não há saldo devedor!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);


                BuscarSaldoCredito();
            }
        }//
    }
}
