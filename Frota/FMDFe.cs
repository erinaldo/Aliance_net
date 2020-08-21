using System;
using System.Data;
using System.Windows.Forms;
using CamadaDados.Frota;

namespace Frota
{
    public partial class TFMDFe : Form
    {
        private TRegistro_MDFe rmdfe;
        public TRegistro_MDFe rMDFe
        {
            get
            {
                if (bsMDFe.Current != null)
                    return bsMDFe.Current as TRegistro_MDFe;
                else return null;
            }
            set { rmdfe = value; }
        }

        public TFMDFe()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("RODOVIARIO", "1"));
            cbx.Add(new Utils.TDataCombo("AEREO", "2"));
            cbx.Add(new Utils.TDataCombo("AQUAVIARIO", "3"));
            cbx.Add(new Utils.TDataCombo("FERROVIARIO", "4"));
            tp_modalidade.DataSource = cbx;
            tp_modalidade.DisplayMember = "Display";
            tp_modalidade.ValueMember = "Value";

            System.Collections.ArrayList cbx1 = new System.Collections.ArrayList();
            cbx1.Add(new Utils.TDataCombo("PRESTADOR SERVIÇO", "1"));
            cbx1.Add(new Utils.TDataCombo("CARGA PROPRIA", "2"));
            tp_emitente.DataSource = cbx1;
            tp_emitente.DisplayMember = "Display";
            tp_emitente.ValueMember = "Value";

            System.Collections.ArrayList cbx2 = new System.Collections.ArrayList();
            cbx2.Add(new Utils.TDataCombo("ETC", "1"));
            cbx2.Add(new Utils.TDataCombo("TAC", "2"));
            cbx2.Add(new Utils.TDataCombo("CTC", "3"));
            tp_transportador.DataSource = cbx2;
            tp_transportador.DisplayMember = "Display";
            tp_transportador.ValueMember = "Value";
        }

        private void afterGrava()
        {
            if (pDados.validarCampoObrigatorio())
            {
                if (bsDoc.Count.Equals(0))
                {
                    MessageBox.Show("Obrigatório informar documentos transportados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (bsVeic.Count.Equals(0))
                {
                    MessageBox.Show("Obrigatório informar veiculos utilizados no transporte.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (bsMot.Count.Equals(0))
                {
                    MessageBox.Show("Obrigatório informar motorista que irá realizar o transporte.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if(tp_emitente.SelectedIndex == 0 && (bsMDFe.Current as TRegistro_MDFe).lSeguro.Count.Equals(0))
                {
                    MessageBox.Show("Obrigatório informar seguro da carga para prestador de serviço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tpSeguro;
                    return;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private void TFMDFe_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            pDados.set_FormatZero();
            infAdFisco.CharacterCasing = CharacterCasing.Normal;
            infCpl.CharacterCasing = CharacterCasing.Normal;
            //Empresa
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
            //Serie
            cbSerie.DataSource = CamadaNegocio.Faturamento.Cadastros.TCN_CadSerieNF.Busca(string.Empty,
                                                                                          "58",
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          string.Empty,
                                                                                          null);
            cbSerie.DisplayMember = "ds_serienf";
            cbSerie.ValueMember = "nr_serie";
            if (rmdfe != null)
            {
                bsMDFe.DataSource = new TList_MDFe() { rmdfe };
                cbEmpresa.SelectedIndex = (cbEmpresa.DataSource as CamadaDados.Diversos.TList_CadEmpresa).FindIndex(p => p.Cd_empresa.Trim().Equals(rmdfe.Cd_empresa.Trim()));
                cbSerie.SelectedIndex = (cbSerie.DataSource as CamadaDados.Faturamento.Cadastros.TList_CadSerieNF).FindIndex(p => p.Nr_Serie.Trim().Equals(rmdfe.Nr_serie.Trim()));
                cbEmpresa.Enabled = false;
                cbSerie.Enabled = false;
                tp_emitente.Enabled = rmdfe.lDoc.Count.Equals(0);
                cd_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                bb_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
            }
            else
            {
                bsMDFe.AddNew();
                cbEmpresa.SelectedIndex = 0;
                cbSerie.SelectedIndex = 0;
            }
        }
        
        private void bb_ufcarrega_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|120;" +
                              "a.cd_uf|Cd. UF|60;" +
                              "a.uf|UF|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ufcarrega, ds_ufcarrega, sg_ufcarrega },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void cd_ufcarrega_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_ufcarrega.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ufcarrega, ds_ufcarrega, sg_ufcarrega },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }

        private void bb_ufdescarrega_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|120;" +
                              "a.cd_uf|Cd. UF|60;" +
                              "a.uf|UF|50";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ufdescarrega, ds_ufdescarrega, sg_ufdescarrega },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void cd_ufdescarrega_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_ufdescarrega.Text.Trim() + "'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ufdescarrega, ds_ufdescarrega, sg_ufdescarrega },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }

        private void bbAddMunCar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cd_ufcarrega.Text))
            {
                MessageBox.Show("Obrigatório selecionar MUNICIPIO DE CARREGAMENTO antes.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_ufcarrega.Focus();
                return;
            }
            string vColunas = "a.ds_cidade|Cidade|200;" +
                               "b.uf|UF|60;" +
                              "a.cd_cidade|Código|80";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
            if (linha != null)
            {
                if (!(bsMDFe.Current as TRegistro_MDFe).lMunCar.Exists(p => p.Cd_cidade.Trim().Equals(linha["cd_cidade"].ToString())))
                {
                    (bsMDFe.Current as TRegistro_MDFe).lMunCar.Add(new TRegistro_MDFe_MunCarrega() { Cd_cidade = linha["cd_cidade"].ToString(), Ds_cidade = linha["ds_cidade"].ToString() });
                    bsMDFe.ResetCurrentItem();
                }
            }
        }

        private void bbDelMunCar_Click(object sender, EventArgs e)
        {
            if(bsMunCar.Current != null)
                if (MessageBox.Show("Confirma exclusão cidade selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsMDFe.Current as TRegistro_MDFe).lMunCarDel.Add(bsMunCar.Current as TRegistro_MDFe_MunCarrega);
                    bsMunCar.RemoveCurrent();
                }
        }

        private void bbAddVeic_Click(object sender, EventArgs e)
        {
            using (TFListaVeic fVeic = new TFListaVeic())
            {
                if (fVeic.ShowDialog() == DialogResult.OK)
                    if (fVeic.lVeic != null)
                    {
                        fVeic.lVeic.ForEach(p =>
                        {
                            if (!(bsMDFe.Current as TRegistro_MDFe).lVeic.Exists(v => v.Id_veiculo.Equals(p.Id_veiculo)))
                                (bsMDFe.Current as TRegistro_MDFe).lVeic.Add(
                                    new TRegistro_MDFe_Veiculo()
                                    {
                                        Id_veiculo = p.Id_veiculo,
                                        Ds_veiculo = p.Ds_veiculo,
                                        Placa = p.placa
                                    });
                            //Buscar lista de veiculos filhos
                            CamadaNegocio.Frota.Cadastros.TCN_CadVeiculo.Buscar(string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                string.Empty,
                                                                                p.Id_veiculostr,
                                                                                "'A'",
                                                                                null).ForEach(v =>
                                                                                {
                                                                                    if (!(bsMDFe.Current as TRegistro_MDFe).lVeic.Exists(z => z.Id_veiculo.Equals(v.Id_veiculo)))
                                                                                        (bsMDFe.Current as TRegistro_MDFe).lVeic.Add(
                                                                                            new TRegistro_MDFe_Veiculo()
                                                                                            {
                                                                                                Id_veiculo = v.Id_veiculo,
                                                                                                Ds_veiculo = v.Ds_veiculo,
                                                                                                Placa = v.placa
                                                                                            });
                                                                                });
                        });
                        bsMDFe.ResetCurrentItem();
                    }
            }
        }

        private void bbDelVeic_Click(object sender, EventArgs e)
        {
            if(bsVeic.Current != null)
                if (MessageBox.Show("Confirma exclusão do veiculo?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsMDFe.Current as TRegistro_MDFe).lVeicDel.Add(bsVeic.Current as TRegistro_MDFe_Veiculo);
                    bsVeic.RemoveCurrent();
                }
        }

        private void bbAddMot_Click(object sender, EventArgs e)
        {
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BuscaClifor(null, "isnull(a.st_motorista, 'N')|=|'S'");
            if (linha != null)
                if (!(bsMDFe.Current as TRegistro_MDFe).lMot.Exists(p => p.Cd_motorista.Trim().Equals(linha["cd_clifor"].ToString())))
                {
                    (bsMDFe.Current as TRegistro_MDFe).lMot.Add(new TRegistro_MDFe_Motorista() { Cd_motorista = linha["cd_clifor"].ToString(), Nm_motorista = linha["nm_clifor"].ToString(), Cpf_motorista = linha["nr_cpf"].ToString() });
                    bsMDFe.ResetCurrentItem();
                }
        }

        private void bbDelMot_Click(object sender, EventArgs e)
        {
            if(bsMot.Current != null)
                if (MessageBox.Show("Confirma exclusão do motorista selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsMDFe.Current as TRegistro_MDFe).lMotDel.Add(bsMot.Current as TRegistro_MDFe_Motorista);
                    bsMot.RemoveCurrent();
                }
        }

        private void bbAddUf_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|100;" +
                              "a.cd_uf|Código|60;" +
                              "a.uf|UF|30";
            DataRowView linha = FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, null, new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
            if(linha != null)
                if (!(bsMDFe.Current as TRegistro_MDFe).lUfPerc.Exists(p => p.Cd_uf.Trim().Equals(linha["cd_uf"].ToString())))
                {
                    (bsMDFe.Current as TRegistro_MDFe).lUfPerc.Add(new TRegistro_MDFe_UfPercurso() { Cd_uf = linha["cd_uf"].ToString(), Ds_uf = linha["ds_uf"].ToString(), Sg_uf = linha["uf"].ToString() });
                    bsMDFe.ResetCurrentItem();
                }
        }

        private void bbDelUf_Click(object sender, EventArgs e)
        {
            if(bsUfPerc.Current != null)
                if (MessageBox.Show("Confirma exclusão da UF selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsMDFe.Current as TRegistro_MDFe).lUfPercDel.Add(bsUfPerc.Current as TRegistro_MDFe_UfPercurso);
                    bsUfPerc.RemoveCurrent();
                    tp_emitente.Enabled = bsDoc.Count.Equals(0);
                }
        }

        private void bbAddDoc_Click(object sender, EventArgs e)
        {
            if (tp_emitente.SelectedValue == null)
            {
                MessageBox.Show("Obrigaório selecionar emitente.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tp_emitente.Focus();
                return;
            }
            if (cbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Obrigatório informar empresa.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbEmpresa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cd_ufdescarrega.Text))
            {
                MessageBox.Show("Obrigatório informar estado descarga.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cd_ufdescarrega.Focus();
                return;
            }
            if (tp_emitente.SelectedValue.ToString().Equals("1"))//CTe
            {
                using (TFListaCTeMDFe fLista = new TFListaCTeMDFe())
                {
                    fLista.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                    if(fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lCte != null)
                        {
                            fLista.lCte.ForEach(p =>
                                {
                                    if (!(bsMDFe.Current as TRegistro_MDFe).lDoc.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) && v.Nr_lanctoctr.Value.Equals(p.Nr_lanctoCTRC.Value)))
                                        (bsMDFe.Current as TRegistro_MDFe).lDoc.Add(
                                            new TRegistro_MDFe_Documentos()
                                            {
                                                ChaveNFe = p.Chaveacesso,
                                                Dt_emissaoCTe = p.Dt_emissao,
                                                Nm_destinatarioCTe = p.Nm_destinatario,
                                                Nm_remetenteCTe = p.Nm_remetente,
                                                Nr_lanctoctr = p.Nr_lanctoCTRC,
                                                Nr_CTe = p.Nr_ctrc,
                                                rCte = p
                                            });
                                });
                            bsMDFe.ResetBindings(true);
                            tp_emitente.Enabled = bsDoc.Count.Equals(0);
                            cd_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                            bb_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                        }
                }
            }
            else//NFe
                using (TFListaNFeMDFe fLista = new TFListaNFeMDFe())
                {
                    fLista.pCd_empresa = cbEmpresa.SelectedValue.ToString();
                    if (fLista.ShowDialog() == DialogResult.OK)
                        if (fLista.lNFe != null)
                        {
                            fLista.lNFe.ForEach(p =>
                                {
                                    if (!(bsMDFe.Current as TRegistro_MDFe).lDoc.Exists(v => v.Cd_empresa.Trim().Equals(p.Cd_empresa.Trim()) && v.Nr_lanctofiscal.Value.Equals(p.Nr_lanctofiscal.Value)))
                                        (bsMDFe.Current as TRegistro_MDFe).lDoc.Add(
                                            new TRegistro_MDFe_Documentos()
                                            {
                                                ChaveNFe = p.Chave_acesso_nfe,
                                                Dt_emissaoNFe = p.Dt_emissao,
                                                Nm_cliforNFe = p.Nm_clifor,
                                                Nr_lanctofiscal = p.Nr_lanctofiscal,
                                                Nr_notafiscal = p.Nr_notafiscal,
                                                rFat = p
                                            });
                                });
                            bsMDFe.ResetBindings(true);
                            tp_emitente.Enabled = bsDoc.Count.Equals(0);
                            cd_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                            bb_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                        }
                }
        }

        private void bbDelDoc_Click(object sender, EventArgs e)
        {
            if(bsDoc.Current != null)
                if (MessageBox.Show("Confirma exclusão do documento selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsMDFe.Current as TRegistro_MDFe).lDocDel.Add(bsDoc.Current as TRegistro_MDFe_Documentos);
                    bsDoc.RemoveCurrent();
                    tp_emitente.Enabled = bsDoc.Count.Equals(0);
                    cd_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                    bb_ufdescarrega.Enabled = bsDoc.Count.Equals(0);
                }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            afterGrava();
        }

        private void TFMDFe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
        }

        private void cbSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bsMDFe.Current != null && cbSerie.SelectedItem != null)
                (bsMDFe.Current as TRegistro_MDFe).Cd_modelo = (cbSerie.SelectedItem as CamadaDados.Faturamento.Cadastros.TRegistro_CadSerieNF).CD_Modelo;
        }

        private void bbAddSeguro_Click(object sender, EventArgs e)
        {
            using (TFSeguroMDFe fSeguro = new TFSeguroMDFe())
            {
                if(fSeguro.ShowDialog() == DialogResult.OK)
                    if(fSeguro.rSeguro != null)
                    {
                        (bsMDFe.Current as TRegistro_MDFe).lSeguro.Add(fSeguro.rSeguro);
                        bsMDFe.ResetCurrentItem();
                    }
            }
        }

        private void bbDelSeguro_Click(object sender, EventArgs e)
        {
            if(bsSeguro.Current != null)
                if(MessageBox.Show("Confirma exclusão seguro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    (bsMDFe.Current as TRegistro_MDFe).lSeguroDel.Add(bsSeguro.Current as TRegistro_MDFe_Seguro);
                    bsSeguro.RemoveCurrent();
                }
        }

        private void bbAltSeguro_Click(object sender, EventArgs e)
        {
            if (bsSeguro.Current != null)
                using (TFSeguroMDFe fSeguro = new TFSeguroMDFe())
                {
                    TRegistro_MDFe_Seguro copia = new TRegistro_MDFe_Seguro();
                    copia.Cd_responsavel = (bsSeguro.Current as TRegistro_MDFe_Seguro).Cd_responsavel;
                    copia.Cd_seguradora = (bsSeguro.Current as TRegistro_MDFe_Seguro).Cd_seguradora;
                    copia.CnpjCpf_responsavel = (bsSeguro.Current as TRegistro_MDFe_Seguro).CnpjCpf_responsavel;
                    copia.Cnpj_seguradora = (bsSeguro.Current as TRegistro_MDFe_Seguro).Cnpj_seguradora;
                    copia.Nm_responsavel = (bsSeguro.Current as TRegistro_MDFe_Seguro).Nm_responsavel;
                    copia.Nm_seguradora = (bsSeguro.Current as TRegistro_MDFe_Seguro).Nm_seguradora;
                    copia.Nr_apolice = (bsSeguro.Current as TRegistro_MDFe_Seguro).Nr_apolice;
                    copia.Nr_averbacao = (bsSeguro.Current as TRegistro_MDFe_Seguro).Nr_averbacao;
                    copia.Tp_responsavel = (bsSeguro.Current as TRegistro_MDFe_Seguro).Tp_responsavel;
                    fSeguro.rSeguro = bsSeguro.Current as TRegistro_MDFe_Seguro;
                    if (fSeguro.ShowDialog() != DialogResult.OK)
                    {
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Cd_responsavel = copia.Cd_responsavel;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Cd_seguradora = copia.Cd_seguradora;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).CnpjCpf_responsavel = copia.CnpjCpf_responsavel;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Cnpj_seguradora = copia.Cnpj_seguradora;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Nm_responsavel = copia.Nm_responsavel;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Nm_seguradora = copia.Nm_seguradora;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Nr_apolice = copia.Nr_apolice;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Nr_averbacao = copia.Nr_averbacao;
                        (bsSeguro.Current as TRegistro_MDFe_Seguro).Tp_responsavel = copia.Tp_responsavel;
                    }
                    bsMDFe.ResetCurrentItem();
                }
            else MessageBox.Show("Obrigatório selecionar seguro para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
