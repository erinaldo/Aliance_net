using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Frota.Cadastros;

namespace Frota
{
    public partial class TFDespComposta : Form
    {
        public string vCd_empresa = string.Empty;
        public string vNm_empresa = string.Empty;
        public string vId_veiculo = string.Empty;
        public string vDs_veiculo = string.Empty;
        public bool st_consumointerno = false;

        private TList_ManutencaoVeiculo lmanutencao;
        public TList_ManutencaoVeiculo lManutencao
        {
            get { return lmanutencao; }
            set { lmanutencao = value; }
        }

        private CamadaDados.Financeiro.Cadastros.TList_CadClifor lFornec
        { get; set; }
        private CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor rCliforEmit
        { get; set; }


        public TFDespComposta()
        {
            InitializeComponent();
            lmanutencao = new TList_ManutencaoVeiculo();
            bsDespesaComposta.DataSource = lmanutencao;
        }

        //todo: desenvolver o controle de click, botoes por atalho (F4 e F6)

        #region Métodos Despesa Composta

        private void NovaDespesaComposta()
        {
            if (pManutencao.validarCampoObrigatorio())
            {
                lmanutencao.Add(new TRegistro_ManutencaoVeiculo
                {
                    Id_veiculostr = id_veiculo.Text,
                    Ds_veiculo = ds_veiculo.Text,
                    Placa = placa.Text,
                    Cd_empresa = cd_empresa.Text,
                    Nm_empresa = nm_empresa.Text,
                    Id_despesastr = id_despesa.Text,
                    Ds_despesa = ds_despesa.Text,
                    Cd_cliforResponsavel = cd_cliforResponsavel.Text,
                    Nm_cliforresponsavel = nm_cliforResponsavel.Text,
                    Cd_cliforOficina = cd_cliforOficina.Text,
                    Nm_cliforOficina = nm_cliforOficina.Text,
                    Nr_notafiscal = nr_notafiscal.Text,
                    Dt_realizadastr = dt_realizada.Text,
                    KM_realizada = decimal.Parse(km_realizada.Text),
                    Vl_realizada = decimal.Parse(vl_realizado.Text),
                    Ds_observacao = ds_observacao.Text
                });
                //bsDespesaComposta.AddNew();
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Id_veiculostr = id_veiculo.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_veiculo = ds_veiculo.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Placa = placa.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_empresa = cd_empresa.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_empresa = nm_empresa.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Id_despesastr = id_despesa.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_despesa = ds_despesa.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforResponsavel = cd_cliforResponsavel.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforresponsavel = nm_cliforResponsavel.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforOficina = cd_cliforOficina.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforOficina = nm_cliforOficina.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nr_notafiscal = nr_notafiscal.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Dt_realizadastr = dt_realizada.Text;
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).KM_realizada = decimal.Parse(km_realizada.Text);
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Vl_realizada = decimal.Parse(vl_realizado.Text);
                //(bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_observacao = ds_observacao.Text;
                bsDespesaComposta.ResetBindings(true);
                pManutencao.LimparRegistro();
                this.validaObrigatoriedade();
                id_veiculo.Focus();
            }
            totalizador();
        }

        private void AlterarDespesaComposta()
        {
            id_veiculo.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Id_veiculostr;
            ds_veiculo.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_veiculo;
            placa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Placa;
            cd_empresa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_empresa;
            nm_empresa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_empresa;
            id_despesa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Id_despesastr;
            ds_despesa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_despesa;
            cd_cliforResponsavel.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforResponsavel;
            nm_cliforResponsavel.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforresponsavel;
            cd_cliforOficina.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforOficina;
            nm_cliforOficina.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforOficina;
            nr_notafiscal.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nr_notafiscal;
            dt_realizada.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Dt_realizadastr;
            km_realizada.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).KM_realizada.ToString();
            vl_realizado.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Vl_realizada.ToString();
            ds_observacao.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_observacao;
        }

        private void validaObrigatoriedade()
        {
            if (bsDespesaComposta.Count > 0)
            {
                cd_empresa.Enabled = false;
                bb_empresa.Enabled = false;
                cd_cliforOficina.Enabled = false;
                bb_Oficina.Enabled = false;
                bbAddOficina.Enabled = false;
                cd_empresa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_empresa;
                nm_empresa.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_empresa;
                cd_cliforOficina.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforOficina;
                nm_cliforOficina.Text = (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforOficina;
            }
            else
            {
                cd_empresa.Enabled = true;
                bb_empresa.Enabled = true;
                cd_cliforOficina.Enabled = true;
                bb_Oficina.Enabled = true;
                bbAddOficina.Enabled = true;
            }
        }

        #endregion

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void bb_excluir_despeca_Click(object sender, EventArgs e)
        {
            if (bsDespesaComposta.Current != null)
            {
                bsDespesaComposta.RemoveCurrent();
                this.validaObrigatoriedade();
            }
            else
                MessageBox.Show("Não exite registro corrente selecionado para efetuar a exclusão.", "Menssagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            totalizador();
        }

        private void bb_nova_despesa_Click(object sender, EventArgs e)
        {
            this.NovaDespesaComposta();
        }

        private void afterGrava()
        {
            if (bsDespesaComposta.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Não foi possível gravar as despesas, pois não existe nenhuma listada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void id_veiculo_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_veiculo|=|" + id_veiculo.Text + ";" +
                            "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo());
        }

        private void bb_veiculo_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_veiculo|Veiculo|200;" +
                              "a.id_veiculo|Id. Veiculo|80;" +
                              "a.placa|Placa|80";
            string vParam = "isnull(a.st_registro, 'A')|<>|'I'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_veiculo, ds_veiculo, placa },
                                            new CamadaDados.Frota.Cadastros.TCD_CadVeiculo(), vParam);
        }

        private void cd_empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + cd_empresa.Text.Trim() + "'",
                                                   new Componentes.EditDefault[] { cd_empresa, nm_empresa });
        }

        private void bb_empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { cd_empresa, nm_empresa }, string.Empty);
        }

        private void id_despesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_despesa|=|'" + id_despesa.Text.Trim() + "';" +
                            "a.tp_despesa|IN|('MV', 'MI', 'DV')";
            DataRow linha = FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                 new CamadaDados.Frota.Cadastros.TCD_Despesa());

            #region copiado de fmanutencao n utilizado
            //if (linha != null)
            //{
            //    vl_realizado.Enabled = !linha["TP_DESPESA"].ToString().Equals("MI");
            //    st_consumointerno = linha["TP_DESPESA"].ToString().Equals("MI");
            //}
            //if (st_consumointerno && !string.IsNullOrEmpty(cd_empresa.Text))
            //{
            //    //Buscar Clifor Empresa
            //    CamadaDados.Diversos.TList_CadEmpresa lEmp = null;
            //    lEmp = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
            //        new Utils.TpBusca[]
            //        {
            //           new Utils.TpBusca()
            //           {
            //               vNM_Campo = "a.cd_empresa",
            //               vOperador = "=",
            //               vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
            //           }
            //        }, 1, string.Empty);
            //    if (lEmp != null)
            //    {
            //        cd_cliforOficina.Text = lEmp[0].Cd_clifor;
            //        nm_cliforOficina.Text = lEmp[0].Nm_clifor;
            //    }
            //    //Marcar como Realizada
            //    dt_realizada.Text = CamadaDados.UtilData.Data_Servidor().ToString();
            //    //Habilitar retirada Almoxarifado
            //    tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 285);
            //    this.Size = new Size(865, 600);
            //}
            //else
            //{
            //    tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
            //    this.Size = new Size(865, 334);
            //}
            #endregion
        }

        private void bb_despesa_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_despesa|Despesa|200;" +
                              "a.id_despesa|Codigo|80";
            string vParam = "a.tp_despesa|IN|('MV', 'MI', 'DV')";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_despesa, ds_despesa },
                 new CamadaDados.Frota.Cadastros.TCD_Despesa(), vParam);

            #region copiado fmanutencao n utilizado
            //if (linha != null)
            //{
            //    vl_realizado.Enabled = !linha["TP_DESPESA"].ToString().Equals("MI");
            //    st_consumointerno = linha["TP_DESPESA"].ToString().Equals("MI");
            //}
            //if (st_consumointerno && !string.IsNullOrEmpty(cd_empresa.Text))
            //{
            //    //Buscar Clifor Empresa
            //    CamadaDados.Diversos.TList_CadEmpresa lEmp = null;
            //    lEmp = new CamadaDados.Diversos.TCD_CadEmpresa().Select(
            //        new Utils.TpBusca[]
            //        {
            //           new Utils.TpBusca()
            //           {
            //               vNM_Campo = "a.cd_empresa",
            //               vOperador = "=",
            //               vVL_Busca = "'" + cd_empresa.Text.Trim() + "'"
            //           }
            //        }, 1, string.Empty);
            //    if (lEmp != null)
            //    {
            //        cd_cliforOficina.Text = lEmp[0].Cd_clifor;
            //        nm_cliforOficina.Text = lEmp[0].Nm_clifor;
            //    }
            //    //Marcar como Realizada
            //    dt_realizada.Text = CamadaDados.UtilData.Data_Servidor().ToString();
            //    //Habilitar retirada Almoxarifado
            //    tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 260);
            //    this.Size = new Size(865, 600);
            //}
            //else
            //{
            //    tlpManut.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
            //    this.Size = new Size(865, 334);
            //}
            #endregion
        }

        private void bbAddDespesa_Click(object sender, EventArgs e)
        {
            Utils.InputBox ibp = new Utils.InputBox();
            ibp.Text = "Descrição Despesa";
            string despesa = ibp.ShowDialog();
            if (!string.IsNullOrEmpty(despesa))
                try
                {
                    CamadaDados.Frota.Cadastros.TRegistro_Despesa rDesp = new CamadaDados.Frota.Cadastros.TRegistro_Despesa();
                    rDesp.Ds_despesa = despesa;
                    rDesp.Tp_despesa = "MV";
                    CamadaNegocio.Frota.Cadastros.TCN_Despesa.Gravar(rDesp, null);
                    id_despesa.Text = rDesp.Id_despesastr;
                    ds_despesa.Text = rDesp.Ds_despesa;
                    vl_realizado.Enabled = true;
                    cd_cliforResponsavel.Focus();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            else MessageBox.Show("Obrigatório informar descrição despesa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cd_cliforResponsavel_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforResponsavel.Text.Trim() + "';" +
                               "isnull(a.st_funcionarios, 'N')|=|'S';" +
                               "isnull(a.ST_FuncAtivo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_Responsavel_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Responsavel|200;" +
                               "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_funcionarios, 'N')|=|'S';" +
                             "isnull(a.ST_FuncAtivo, 'N')|=|'S'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforResponsavel, nm_cliforResponsavel },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                vParam);
        }

        private void bbAddResponsavel_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_cliforResponsavel.Text = fClifor.rClifor.Cd_clifor;
                        nm_cliforResponsavel.Text = fClifor.rClifor.Nm_clifor;
                        cd_cliforOficina.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void cd_cliforOficina_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforOficina.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void bb_Oficina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Oficina|200;" +
                               "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                vParam);
        }

        private void bbAddOficina_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (rCliforEmit != null)
                    fClifor.rClifor = rCliforEmit;
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_cliforOficina.Text = fClifor.rClifor.Cd_clifor;
                        nm_cliforOficina.Text = fClifor.rClifor.Nm_clifor;
                        nr_notafiscal.Focus();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bb_alterar_despesa_Click(object sender, EventArgs e)
        {
            if (bsDespesaComposta.Current != null)
            {
                this.AlterarDespesaComposta();
                bsDespesaComposta.RemoveCurrent();
                this.validaObrigatoriedade();
            }
            else
                MessageBox.Show("Não existe registro corrente selecionado para efetuar a alteração.", "Menssagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_gravar_despesa_Click(object sender, EventArgs e)
        {
            if (pManutencao.validarCampoObrigatorio())
            {
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Id_veiculostr = id_veiculo.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_veiculo = ds_veiculo.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Placa = placa.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_empresa = cd_empresa.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_empresa = nm_empresa.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Id_despesastr = id_despesa.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_despesa = ds_despesa.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforResponsavel = cd_cliforResponsavel.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforresponsavel = nm_cliforResponsavel.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Cd_cliforOficina = cd_cliforOficina.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nm_cliforOficina = nm_cliforOficina.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Nr_notafiscal = nr_notafiscal.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Dt_realizadastr = dt_realizada.Text;
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).KM_realizada = decimal.Parse(km_realizada.Text);
                (bsDespesaComposta.Current as TRegistro_ManutencaoVeiculo).Ds_observacao = ds_observacao.Text;
                pManutencao.LimparRegistro();
                this.validaObrigatoriedade();
                id_veiculo.Focus();
            }
        }

        private void totalizador()
        {
            tot_valor.Value = (bsDespesaComposta.List as IEnumerable<TRegistro_ManutencaoVeiculo>).Sum(p => p.Vl_realizada);
        }

    }
}
