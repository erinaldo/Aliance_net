using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using FormBusca;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCadEmpresa : FormCadPadrao.FFormCadPadrao
    {
        public string Modelo_OS = string.Empty;
        public string Modelo_Entrega = string.Empty;
        public string Modelo_Garantia = string.Empty;
        public string Modelo_Laudo = string.Empty;
        public string Modelo_Acompanhamento = string.Empty;
        public TFCadEmpresa()
        {
            InitializeComponent();
            DTS = BS_CadEmpresa;
            ArrayList cbx = new ArrayList();
            cbx.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx.Add(new TDataCombo("SIMPLES NACIONAL", "1"));
            cbx.Add(new TDataCombo("SIMPLES NACIONAL - EXCESSO DE SUBLIMITE DE RECEITA BRUTA", "2"));
            cbx.Add(new TDataCombo("REGIME NORMAL", "3"));
            tp_regimetributario.DataSource = cbx;
            tp_regimetributario.DisplayMember = "Display";
            tp_regimetributario.ValueMember = "Value";

            ArrayList cbx1 = new ArrayList();
            cbx1.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx1.Add(new TDataCombo("MICROEMPRESA MUNICIPAL", "1"));
            cbx1.Add(new TDataCombo("ESTIMATIVA", "2"));
            cbx1.Add(new TDataCombo("SOCIEDADE DE PROFISSIONAIS", "3"));
            cbx1.Add(new TDataCombo("COOPERATIVA", "4"));
            cbx1.Add(new TDataCombo("MICROEMPRESARIO INDIVIDUAL", "5"));
            cbx1.Add(new TDataCombo("MICROEMPRESARIO E EMPRESA DE PEQUENO PORTE", "6"));
            tp_regimetribmunicipal.DataSource = cbx1;
            tp_regimetribmunicipal.ValueMember = "Value";
            tp_regimetribmunicipal.DisplayMember = "Display";
                        
            ArrayList cbx3 = new ArrayList();
            cbx3.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx3.Add(new TDataCombo("PERFIL A", "A"));
            cbx3.Add(new TDataCombo("PERFIL B", "B"));
            cbx3.Add(new TDataCombo("PERFIL C", "C"));
            tp_perfilfiscal.DataSource = cbx3;
            tp_perfilfiscal.DisplayMember = "Display";
            tp_perfilfiscal.ValueMember = "Value";

            ArrayList cbx4 = new ArrayList();
            cbx4.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx4.Add(new TDataCombo("INDUSTRIAL", "0"));
            cbx4.Add(new TDataCombo("OUTROS", "1"));
            tp_atividadefiscal.DataSource = cbx4;
            tp_atividadefiscal.DisplayMember = "Display";
            tp_atividadefiscal.ValueMember = "Value";

            ArrayList cbx5 = new ArrayList();
            cbx5.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx5.Add(new TDataCombo("LUCRO REAL", "1"));
            cbx5.Add(new TDataCombo("LUCRO PRESUMIDO", "2"));
            cbx5.Add(new TDataCombo("LUCRO ARBITRADO", "3"));
            cbx5.Add(new TDataCombo("ESTIMATIVA MENSAL", "4"));
            tp_basetributacaonormal.DataSource = cbx5;
            tp_basetributacaonormal.DisplayMember = "Display";
            tp_basetributacaonormal.ValueMember = "Value";

            ArrayList cbx6 = new ArrayList();
            cbx6.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx6.Add(new TDataCombo("MICRO EMPRESA", "1"));
            cbx6.Add(new TDataCombo("EMPRESA PEQUENO PORTE", "2"));
            tp_empresasimples.DataSource = cbx6;
            tp_empresasimples.DisplayMember = "Display";
            tp_empresasimples.ValueMember = "Value";

            ArrayList cbx7 = new ArrayList();
            cbx7.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx7.Add(new TDataCombo("INDUSTRIAL OU EQUIPARADO", "0"));
            cbx7.Add(new TDataCombo("PRESTADOR DE SERVIÇOS", "1"));
            cbx7.Add(new TDataCombo("ATIVIDADE DE COMERCIO", "2"));
            cbx7.Add(new TDataCombo("ATIVIDADE FINANCEIRA", "3"));
            cbx7.Add(new TDataCombo("ATIVIDADE IMOBILIARIA", "4"));
            cbx7.Add(new TDataCombo("OUTROS", "9"));
            tp_atividadespedpiscofins.DataSource = cbx7;
            tp_atividadespedpiscofins.DisplayMember = "Display";
            tp_atividadespedpiscofins.ValueMember = "Value";

            ArrayList cbx8 = new ArrayList();
            cbx8.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx8.Add(new TDataCombo("SOCIEDADE EMPRESARIAL", "00"));
            cbx8.Add(new TDataCombo("SOCIEDADE COOPERATIVA", "01"));
            cbx8.Add(new TDataCombo("ENTIDADE SUJEITA AO PIS COM BASE NA FOLHA DE PAGAMENTO", "02"));
            tp_naturezaPJ.DataSource = cbx8;
            tp_naturezaPJ.DisplayMember = "Display";
            tp_naturezaPJ.ValueMember = "Value";

            ArrayList cbx9 = new ArrayList();
            cbx9.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx9.Add(new TDataCombo("NÃO CUMULATIVO", "1"));
            cbx9.Add(new TDataCombo("CUMULATIVO", "2"));
            cbx9.Add(new TDataCombo("NÃO CUMULATIVO E CUMULATIVO", "3"));
            tp_incidtributaria.DataSource = cbx9;
            tp_incidtributaria.DisplayMember = "Display";
            tp_incidtributaria.ValueMember = "Value";

            ArrayList cbx10 = new ArrayList();
            cbx10.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx10.Add(new TDataCombo("APROPRIAÇÃO DIRETA", "1"));
            cbx10.Add(new TDataCombo("RATEIO PROPORCIONAL", "2"));
            tp_apropcredito.DataSource = cbx10;
            tp_apropcredito.DisplayMember = "Display";
            tp_apropcredito.ValueMember = "Value";

            ArrayList cbx11 = new ArrayList();
            cbx11.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx11.Add(new TDataCombo("ALIQUOTA BASICA", "1"));
            cbx11.Add(new TDataCombo("ALIQUOTA ESPECIFICA", "2"));
            tp_contribuicao.DataSource = cbx11;
            tp_contribuicao.DisplayMember = "Display";
            tp_contribuicao.ValueMember = "Value";

            ArrayList cbx12 = new ArrayList();
            cbx12.Add(new TDataCombo("<NENHUM>", string.Empty));
            cbx12.Add(new TDataCombo("REGIME CAIXA", "1"));
            cbx12.Add(new TDataCombo("REGIME COMPETENCIA CONSOLIDADA", "2"));
            cbx12.Add(new TDataCombo("REGIME COMPETENCIA DETALHADA", "3"));
            tp_regimecumulativo.DataSource = cbx12;
            tp_regimecumulativo.DisplayMember = "Display";
            tp_regimecumulativo.ValueMember = "Value";
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (!string.IsNullOrEmpty(Modelo_OS))
            {
                if (ArquivoEmUso(Modelo_OS))
                {
                    MessageBox.Show("Arquivo Modelo OS em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_OS =
                    System.IO.File.ReadAllBytes(Modelo_OS);
                }
            }
            if (!string.IsNullOrEmpty(Modelo_Entrega))
            {
                if (ArquivoEmUso(Modelo_Entrega))
                {
                    MessageBox.Show("Arquivo Modelo Entrega em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Entrega =
                    System.IO.File.ReadAllBytes(Modelo_Entrega);
                }
            }
            if (!string.IsNullOrEmpty(Modelo_Garantia))
            {
                if (ArquivoEmUso(Modelo_Garantia))
                {
                    MessageBox.Show("Arquivo Modelo Garantia em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Garantia =
                    System.IO.File.ReadAllBytes(Modelo_Garantia);
                }
            }
            if (!string.IsNullOrEmpty(Modelo_Laudo))
            {
                if (ArquivoEmUso(Modelo_Laudo))
                {
                    MessageBox.Show("Arquivo Modelo Laudo em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Laudo =
                    System.IO.File.ReadAllBytes(Modelo_Laudo);
                }
            }
            if (!string.IsNullOrEmpty(Modelo_Acompanhamento))
            {
                if (ArquivoEmUso(Modelo_Acompanhamento))
                {
                    MessageBox.Show("Arquivo Modelo Acompanhamento em uso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return string.Empty;
                }
                else
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Acompanhamento =
                    System.IO.File.ReadAllBytes(Modelo_Acompanhamento);
                }
            }
            if (pDados.validarCampoObrigatorio())
            {
                Modelo_OS = string.Empty;
                Modelo_Entrega= string.Empty;
                Modelo_Garantia = string.Empty;
                Modelo_Laudo = string.Empty;
                Modelo_Acompanhamento = string.Empty;
                return TCN_CadEmpresa.Gravar((BS_CadEmpresa.Current as TRegistro_CadEmpresa), null);
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {
            TList_CadEmpresa lista = TCN_CadEmpresa.Busca(CD_Empresa.Text, NM_Empresa.Text, "", null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_CadEmpresa.DataSource = lista;
                    BS_CadEmpresa_PositionChanged(this, new EventArgs());
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_CadEmpresa.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_CadEmpresa.AddNew();
                base.afterNovo();
                pParametros.HabilitarControls(true, this.vTP_Modo);
                pDocumentos.HabilitarControls(true, this.vTP_Modo);
                if (!(CD_Empresa.Focus()))
                    NM_Empresa.Focus();
                buscarlogo.Enabled = true;
                bb_excluirLogo.Enabled = true;
            }
        }

        public override void afterCancela()
        {

            bb_visualiazarAcamp.Enabled = false;
            bb_visualizarGarantia.Enabled = false;
            bb_visualizarLaudo.Enabled = false;
            bb_visualizarOS.Enabled = false;
            bb_visualizarEntrega.Enabled = false;

            bb_loadEntrega.Enabled = false;
            bb_loadGarantia.Enabled = false;
            bb_loadLaudo.Enabled = false;
            bb_loadOS.Enabled = false;
            bb_loadAcomp.Enabled = false;
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_CadEmpresa.RemoveCurrent();
            buscarlogo.Enabled = false;
            bb_excluirLogo.Enabled = false;
            Modelo_OS = string.Empty;
            Modelo_Entrega = string.Empty;
            Modelo_Garantia = string.Empty;
            Modelo_Laudo = string.Empty;
            Modelo_Acompanhamento = string.Empty;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            pParametros.HabilitarControls(true, this.vTP_Modo);
            pDocumentos.HabilitarControls(true, this.vTP_Modo);
            NM_Empresa.Focus();
            buscarlogo.Enabled = true;
            bb_excluirLogo.Enabled = true;
        }

        public override void afterExclui()
        {
            try
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_CadEmpresa.Excluir((BS_CadEmpresa.Current as TRegistro_CadEmpresa), null);
                        BS_CadEmpresa.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("" + e.Message);
            }
        }

         public bool ArquivoEmUso(string caminhoArquivo)
        {
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenWrite(caminhoArquivo);
                fs.Close();
                return false;
            }
            catch (System.IO.IOException ex)
            {
                return true;
            }
        }

        public void InserirSocio()
        {
            if((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (BS_CadEmpresa.Current != null))
                using (TFSociosEmpresa fSocio = new TFSociosEmpresa())
                {
                    if(fSocio.ShowDialog() == DialogResult.OK)
                        if (fSocio.rSocio != null)
                        {
                            if ((BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios.Exists(p => p.Cd_clifor.Trim().Equals(fSocio.rSocio.Cd_clifor.Trim())))
                            {
                                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios.Find(p => p.Cd_clifor.Trim().Equals(fSocio.rSocio.Cd_clifor.Trim())).Ds_funcao = fSocio.rSocio.Ds_funcao;
                                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios.Find(p => p.Cd_clifor.Trim().Equals(fSocio.rSocio.Cd_clifor.Trim())).Dt_inclusao = fSocio.rSocio.Dt_inclusao;
                                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios.Find(p => p.Cd_clifor.Trim().Equals(fSocio.rSocio.Cd_clifor.Trim())).Dt_saida = fSocio.rSocio.Dt_saida;
                                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios.Find(p => p.Cd_clifor.Trim().Equals(fSocio.rSocio.Cd_clifor.Trim())).St_responsavel = fSocio.rSocio.St_responsavel;
                            }
                            else
                                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios.Add(fSocio.rSocio);
                            BS_CadEmpresa.ResetCurrentItem();
                        }
                }
        }

        public void AlterarSocio()
        {
            if ((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (bsSocios.Current != null))
                using (TFSociosEmpresa fSocio = new TFSociosEmpresa())
                {
                    string funcao = (bsSocios.Current as TRegistro_SociosEmpresa).Ds_funcao;
                    DateTime? dt_inc = (bsSocios.Current as TRegistro_SociosEmpresa).Dt_inclusao;
                    DateTime? dt_sai = (bsSocios.Current as TRegistro_SociosEmpresa).Dt_saida;
                    string st_res = (bsSocios.Current as TRegistro_SociosEmpresa).St_responsavel;
                    fSocio.rSocio = bsSocios.Current as TRegistro_SociosEmpresa;
                    if (fSocio.ShowDialog() != DialogResult.OK)
                    {
                        (bsSocios.Current as TRegistro_SociosEmpresa).Ds_funcao = funcao;
                        (bsSocios.Current as TRegistro_SociosEmpresa).Dt_inclusao = dt_inc;
                        (bsSocios.Current as TRegistro_SociosEmpresa).Dt_saida = dt_sai;
                        (bsSocios.Current as TRegistro_SociosEmpresa).St_responsavel = st_res;
                    }
                    BS_CadEmpresa.ResetCurrentItem();
                }
        }

        public void ExcluirSocio()
        {
            if((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (bsSocios.Current != null))
                if (MessageBox.Show("Confirma exclusão do registro selecionado?",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSociosDel.Add(bsSocios.Current as TRegistro_SociosEmpresa);
                    bsSocios.RemoveCurrent();
                }
        }

        private void InserirInsc()
        {
            if((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (BS_CadEmpresa.Current != null))
                using(TFInscSubstEmpresa fInsc = new TFInscSubstEmpresa())
                {
                    if(fInsc.ShowDialog() == DialogResult.OK)
                        if(fInsc.rInsc != null)
                        {
                            if((BS_CadEmpresa.Current as TRegistro_CadEmpresa).lInsc.Exists(p=> p.Cd_uf.Trim().Equals(fInsc.rInsc.Cd_uf.Trim())))
                                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lInsc.Find(p=> p.Cd_uf.Trim().Equals(fInsc.rInsc.Cd_uf.Trim())).Insc_estadual_subst = fInsc.rInsc.Insc_estadual_subst;
                            else (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lInsc.Add(fInsc.rInsc);
                            BS_CadEmpresa.ResetCurrentItem();
                        }
                }
        }

        private void AlterarInsc()
        {
            if((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (bsInsc.Current != null))
                using (TFInscSubstEmpresa fInsc = new TFInscSubstEmpresa())
                {
                    string insc = (bsInsc.Current as TRegistro_InscSubstEmpresa).Insc_estadual_subst;
                    if (fInsc.ShowDialog() != DialogResult.OK)
                        (bsSocios.Current as TRegistro_InscSubstEmpresa).Insc_estadual_subst = insc;
                    BS_CadEmpresa.ResetCurrentItem();
                }
        }

        private void ExcluirInsc()
        {
            if((vTP_Modo.Equals(TTpModo.tm_Insert) || vTP_Modo.Equals(TTpModo.tm_Edit)) &&
                (bsInsc.Current != null))
                if (MessageBox.Show("Confirma exclusão do registro selecionado?",
                    "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lInscDel.Add(bsInsc.Current as TRegistro_InscSubstEmpresa);
                    bsInsc.RemoveCurrent();
                }
        }

        private void bb_clifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor, Nm_Clifor }, string.Empty);           
        }

        private void CD_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'"
                , new Componentes.EditDefault[] { CD_Clifor, Nm_Clifor }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());            
        }

        private void BB_Contador_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { CD_Clifor_Contador, NM_CliforContador }, "a.tp_pessoa|=|'F'");         
        }

        private void CD_Clifor_Contador_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor_Contador.Text + "';a.tp_pessoa|=|'F'"
                , new Componentes.EditDefault[] { CD_Clifor_Contador, NM_CliforContador }, new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }
        
        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80"
                            , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'"+CD_Clifor.Text+"'");            
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'"+CD_Endereco.Text+"';a.cd_clifor|=|'"+CD_Clifor.Text+"'"
                , new Componentes.EditDefault[] { CD_Endereco,DS_Endereco },new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());

        }
        
        private void CD_Clifor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CD_Clifor.Text))
            {
                CD_Endereco.Clear();
                DS_Endereco.Clear();
            }
        }

        private void empresa_Matriz_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.cd_empresa_matriz|Codigo|100;nm_empresa_matriz|Empresa|350", new Componentes.EditDefault[] { cd_empresa_Matriz, nm_empresa_Matriz }, new TCD_CadEmpresa(), "");
        }

        private void TFCadEmpresa_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pParametros.set_FormatZero();
            pDocumentos.set_FormatZero();
        }

        private void bucar_logo_Click(object sender, EventArgs e)
        {
            try
            {
                if ((BS_CadEmpresa.Current != null) && ((vTP_Modo == TTpModo.tm_Insert) || (vTP_Modo == TTpModo.tm_Edit)))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "IMAGENS|*.jpg";
                    if (ofd.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(ofd.FileName))
                        {
                            (BS_CadEmpresa.Current as TRegistro_CadEmpresa).LogoEmpresa = Image.FromFile(ofd.FileName);
                            BS_CadEmpresa.ResetCurrentItem();
                        }
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro localizar imagem: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void bb_escritorio_contabil_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { cd_escritorio_contabil, nm_escritorio_contabil }, "a.tp_pessoa|=|'J'");
        }

        private void cd_escritorio_contabil_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + cd_escritorio_contabil.Text.Trim() + "';a.tp_pessoa|=|'J'",
                                            new Componentes.EditDefault[] { cd_escritorio_contabil, nm_escritorio_contabil },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void BB_Alterar_Item_Click(object sender, EventArgs e)
        {
            this.AlterarSocio();
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirSocio();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirSocio();
        }

        private void TFCadEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirSocio();
            else if (e.Control && e.KeyCode.Equals(Keys.F11))
                this.AlterarSocio();
            else if (e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirSocio();
        }

        private void BS_CadEmpresa_PositionChanged(object sender, EventArgs e)
        {
            if (BS_CadEmpresa.Current != null)
            {
                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lSocios =
                    TCN_SociosEmpresa.Buscar((BS_CadEmpresa.Current as TRegistro_CadEmpresa).Cd_empresa,
                                             string.Empty,
                                             null);
                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).lInsc =
                    TCN_InscSubstEmpresa.Buscar((BS_CadEmpresa.Current as TRegistro_CadEmpresa).Cd_empresa,
                                                string.Empty,
                                                null);
                BS_CadEmpresa.ResetCurrentItem();
            }
        }

        private void bb_excluirLogo_Click(object sender, EventArgs e)
        {
            if (BS_CadEmpresa.Current != null)
            {
                (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Img = null;
                BS_CadEmpresa.ResetCurrentItem();
            }
        }

        private void bb_inserirInsc_Click(object sender, EventArgs e)
        {
            this.InserirInsc();
        }

        private void bb_alterarInsc_Click(object sender, EventArgs e)
        {
            this.AlterarInsc();
        }

        private void bb_excluirInsc_Click(object sender, EventArgs e)
        {
            this.ExcluirInsc();
        }

        private void bb_tabela_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_tabela|Tabela Simples|200;" +
                              "a.id_tabela|Código|50";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_tabela, ds_tabela },
                new CamadaDados.Fiscal.TCD_TabSimples(), string.Empty);
        }

        private void id_tabela_Leave(object sender, EventArgs e)
        {
            string vParam = "a.id_tabela|=|" + id_tabela.Text;
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_tabela, ds_tabela },
                new CamadaDados.Fiscal.TCD_TabSimples());
        }

        private void bb_aliquota_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_tabela.Text))
            {
                string vColunas = "a.ds_aliquota|Descrição Aliquota|200;" +
                                  "a.id_aliquota|Código|50;" +
                                  "a.pc_aliquota|% Aliquota|50";
                UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { id_aliquota, ds_aliquota, pc_aliquota },
                    new CamadaDados.Fiscal.TCD_AliquotaSimples(), "a.id_tabela|=|" + id_tabela.Text);
            }
            else MessageBox.Show("Obrigatório selecionar tabela antes.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void id_aliquota_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id_tabela.Text))
            {
                string vParam = "a.id_tabela|=|" + id_tabela.Text + ";" +
                                "a.id_aliquota|=|" + id_aliquota.Text;
                UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { id_aliquota, ds_aliquota, pc_aliquota },
                    new CamadaDados.Fiscal.TCD_AliquotaSimples());
            }
            else MessageBox.Show("Obrigatório selecionar tabela antes.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bb_loadOS_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_OS =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarOS_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_OS;
            string extensao = ".docx"; // retornar do banco tbm
            Modelo_OS = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                Modelo_OS,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(Modelo_OS); 
        }

        private void bb_loadEntrega_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Entrega =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarEntrega_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Entrega;
            string extensao = ".docx"; // retornar do banco tbm
            Modelo_Entrega = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                Modelo_Entrega,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(Modelo_Entrega); 
        }

        private void bb_loadGarantia_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Garantia =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarGarantia_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Garantia;
            string extensao = ".docx"; // retornar do banco tbm
            Modelo_Garantia = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                Modelo_Garantia,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(Modelo_Garantia); 
        }

        private void bb_loadLaudo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Laudo =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualizarLaudo_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Laudo;
            string extensao = ".docx"; // retornar do banco tbm
            Modelo_Laudo = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                Modelo_Laudo,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(Modelo_Laudo); 
        }

        private void bb_loadAcomp_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
                if (System.IO.File.Exists(ofd.FileName))
                {
                    (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Acompanhamento =
                        System.IO.File.ReadAllBytes(ofd.FileName);
                }
        }

        private void bb_visualiazarAcamp_Click(object sender, EventArgs e)
        {
            byte[] arquivoBuffer = (BS_CadEmpresa.Current as TRegistro_CadEmpresa).Modelo_Acompanhamento;
            string extensao = ".docx"; // retornar do banco tbm
            Modelo_Acompanhamento = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

            System.IO.File.WriteAllBytes(
                Modelo_Acompanhamento,
                arquivoBuffer);

            // para abrir o arquivo para o usuario
            System.Diagnostics.Process.Start(Modelo_Acompanhamento); 
        }
                
        private void bb_ufexpCRC_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Estado|200;" +
                              "a.uf|UF|30;" +
                              "a.cd_uf|Código|50";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_ufexpCRC, ds_ufexpCRC },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void cd_ufexpCRC_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + cd_ufexpCRC.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_ufexpCRC, ds_ufexpCRC },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }
    }
}

