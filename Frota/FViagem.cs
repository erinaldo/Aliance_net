using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Faturamento.CTRC;

namespace Frota
{
    public partial class TFViagem : Form
    {
        public TFViagem()
        {
            InitializeComponent();

            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("PROGRAMADA", "P"));
            cbx.Add(new Utils.TDataCombo("EXECUTANDO", "E"));
            st_viagem.DataSource = cbx;
            st_viagem.DisplayMember = "Display";
            st_viagem.ValueMember = "Value";
        }

        private CamadaDados.Frota.TRegistro_Viagem rviagem;
        public CamadaDados.Frota.TRegistro_Viagem rViagem
        {
            get { return bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem; }
            set { rviagem = value; }
        }

        private void afterGrava()
        {
            if (pViagem.validarCampoObrigatorio())
            {
                //Verificar vencimento CNH do Motorista
                if ((Dt_prevretorno.Text.Trim() != "/  /") && (dt_vencimento_cnh.Text.Trim() != "/  /"))
                    if (DateTime.Parse(Dt_prevretorno.Text).Date >= DateTime.Parse(dt_vencimento_cnh.Text).Date)
                        if (MessageBox.Show("CNH do Motorista com data de vencimento durante o periodo de realização da viagem.\r\n" +
                                            "Deseja gravar a viagem mesmo assim?", "Pergunta", MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
                            return;
                //Verificar manutencao pendente para o veiculo
                CamadaDados.Frota.Cadastros.TList_ManutencaoVeiculo lManut =
                    CamadaNegocio.Frota.Cadastros.TCN_ManutencaoVeiculo.Buscar(Id_veiculo.Text,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               string.Empty,
                                                                               Dt_prevretorno.Text,
                                                                               decimal.Zero,
                                                                               km_prevfinal.Value,
                                                                               null);
                if (lManut.Count > 0)
                    using (TFListManutencao fManut = new TFListManutencao())
                    {
                        fManut.lManut = lManut;
                        if (fManut.ShowDialog() != DialogResult.OK)
                            return;
                    }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void InserirRota()
        {
            using (TFListRota fRotaf = new TFListRota())
            {
                if (fRotaf.ShowDialog() == DialogResult.OK)
                    if (fRotaf.lRotaf != null)
                    {
                        fRotaf.lRotaf.ForEach(p =>
                            {
                                if (!(bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lRota.Exists(v => v.Id_rota.Equals(p.Id_rota)))
                                    (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lRota.Add(p);
                            });
                        bsViagem.ResetCurrentItem();
                    }
            }
        }

        private void ExcluirRota()
        {
            if (bsRotaFrete.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão da rota selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                     MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lRotaDel.Add(bsRotaFrete.Current as CamadaDados.Frota.Cadastros.TRegistro_RotaFrete);
                    bsRotaFrete.RemoveCurrent();
                    bsViagem.ResetCurrentItem();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar uma rota para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);      
        }

        private void InserirFrete()
        {
            if (string.IsNullOrEmpty(cd_empresa.Text))
            {
                MessageBox.Show("Necessário informar a empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_empresa.Focus();
            } else
            {
                using (TFListFrete fFretef = new TFListFrete())
                {
                    fFretef.Cd_empresa = (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).Cd_empresa;
                    if (fFretef.ShowDialog() == DialogResult.OK)
                        if (fFretef.lFreteF != null)
                        {
                            fFretef.lFreteF.ForEach(p =>
                            {
                                if (!(bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lFrete.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) &&
                                                                                                                v.Nr_lanctoCTRC.Equals(p.Nr_lanctoCTRC)))
                                    (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lFrete.Add(p);
                            });
                            bsViagem.ResetCurrentItem();
                        }
                }
            }
        }

        private void ExcluirFrete()
        {
            if (bsCTRC.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do frete selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsViagem.Current as CamadaDados.Frota.TRegistro_Viagem).lFreteDel.Add(bsCTRC.Current as CamadaDados.Faturamento.CTRC.TRegistro_ConhecimentoFrete);
                    bsCTRC.RemoveCurrent();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar um frete para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BuscarSaldoCredito()
        {
            if ((!string.IsNullOrEmpty(cd_empresa.Text)) &&
                (!string.IsNullOrEmpty(Cd_motorista.Text)))
                vl_adtomot.Value =
                CamadaNegocio.Financeiro.Adiantamento.TCN_LanAdiantamento.Buscar(string.Empty,
                                                                                 cd_empresa.Text,
                                                                                 Cd_motorista.Text,
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
                                                                                 null).Sum(p => p.Vl_total_devolver);
        }

        private void TFViagem_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCTRC);
            Utils.ShapeGrid.RestoreShape(this, gRotaFrete);
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pViagem.set_FormatZero();
            if (rviagem != null)
                bsViagem.DataSource = new CamadaDados.Frota.TList_Viagem() { rviagem };
            else
                bsViagem.AddNew();
            km_inicial.ThousandsSeparator = false;
            km_prevfinal.ThousandsSeparator = false;
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                    new Componentes.EditDefault[] { cd_empresa, Nm_empresa });
            this.BuscarSaldoCredito();
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, Nm_empresa }, string.Empty);
            this.BuscarSaldoCredito();
        }

        private void Cd_motorista_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + Cd_motorista.Text.Trim() + "';" +
                            "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Cd_motorista, Nm_motorista, Id_veiculo, Ds_veiculo, placa, categoria_cnh },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarSaldoCredito();
            if (linha != null)
                dt_vencimento_cnh.Text = linha["dt_vencimento_cnh"].ToString();
        }

        private void bb_motorista_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Motorista|200;" +
                              "a.cd_clifor|Codigo|80;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "d.ds_veiculo|Veiculo|100;" +
                              "d.placa|Placa|80;" +
                              "a.categoria_cnh|Categoria CNH|80;" +
                              "a.dt_vencimento_cnh|Vencimento CNH|100";
            string vParam = "isnull(a.st_motorista, 'N')|=|'S';" +
                            "isnull(a.st_ativomot, 'N')|=|'S'";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Cd_motorista, Nm_motorista, Id_veiculo, Ds_veiculo, placa, categoria_cnh },
                                                                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(), vParam);
            this.BuscarSaldoCredito();
            if (linha != null)
                dt_vencimento_cnh.Text = linha["dt_vencimento_cnh"].ToString();
        }

        private void Id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|'" + Id_veiculo.Text.Trim() + "';" +
                               "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { Id_veiculo, Ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Codigo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { Id_veiculo, Ds_veiculo, placa },
                new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(),
               vParam);
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void TFViagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (e.Control && tbRotaFrete.SelectedTab.Equals(tbRota) && e.KeyCode.Equals(Keys.F10))
                this.InserirRota();
            else if (e.Control && tbRotaFrete.SelectedTab.Equals(tbFrete) && e.KeyCode.Equals(Keys.F10))
                this.InserirFrete();
            else if (e.Control && tbRotaFrete.SelectedTab.Equals(tbRota) && e.KeyCode.Equals(Keys.F12))
                this.ExcluirRota();
            else if (e.Control && tbRotaFrete.SelectedTab.Equals(tbFrete) && e.KeyCode.Equals(Keys.F12))
                this.ExcluirFrete();
        }

        private void ts_btn_InserirRota_Click(object sender, EventArgs e)
        {
            this.InserirRota();
        }

        private void ts_btn_DeletarRota_Click(object sender, EventArgs e)
        {
            this.ExcluirRota();
        }

        private void ts_btn_InserirFrete_Click(object sender, EventArgs e)
        {
            this.InserirFrete();
        }

        private void ts_btn_DeletarFrete_Click(object sender, EventArgs e)
        {
            this.ExcluirFrete();
        }

        private void TFViagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gRotaFrete);
            Utils.ShapeGrid.SaveShape(this, gRotaFrete);
        }

        private void Dt_viagem_Leave(object sender, EventArgs e)
        {
            if((Dt_viagem.Text.Trim() != "/  /") && (dt_vencimento_cnh.Text.Trim() != "/  /"))
                if (DateTime.Parse(Dt_viagem.Text).Date >= DateTime.Parse(dt_vencimento_cnh.Text).Date)
                {
                    MessageBox.Show("Motorista com a carteira de habilitação vencida para realizar viagem.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Dt_viagem.Clear();
                    Dt_viagem.Focus();
                }
        }
     }
 }

