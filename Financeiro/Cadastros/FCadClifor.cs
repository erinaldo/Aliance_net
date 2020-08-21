using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CamadaNegocio.Financeiro.Cadastros;
using FormBusca;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadClifor : Form
    {
        private bool Altera_Relatorio = false;

        public bool St_permiteCadResumido
        { get; set; }

        public TFCadClifor()
        {
            InitializeComponent();
            St_permiteCadResumido = false;
        }

        private void afterNovo()
        {
            if(CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null) && St_permiteCadResumido)
                using (TFCadCliforResumido fClifor = new TFCadCliforResumido())
                {
                    if(fClifor.ShowDialog() == DialogResult.OK)
                        if(fClifor.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            else
                using (TFClifor fClifor = new TFClifor())
                {
                    if(fClifor.ShowDialog() == DialogResult.OK)
                        if (fClifor.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                CD_Clifor.Text = fClifor.rClifor.Cd_clifor;
                                afterBusca();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                }
        }

        private void afterAltera()
        {
            if (bsClifor.Current != null)
            {
                if (CamadaNegocio.ConfigGer.TCN_CadParamGer.BuscaVlBool("ST_CADCLFOR_RESUMIDO", null) && St_permiteCadResumido)

                    using (TFCadCliforResumido fClifor = new TFCadCliforResumido())
                {
                    fClifor.Text = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_renovarcadastro ? "Renovando Cadastro Cliente/Fornecedor" : "Alterando Cliente/Fornecedor";
                    fClifor.rClifor = bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor;
                    if (fClifor.ShowDialog() == DialogResult.OK)
                    {
                        if (fClifor.rClifor != null)
                        {
                            try
                            {
                                if (fClifor.rClifor.St_renovarcadastro)
                                {
                                    fClifor.rClifor.Dt_renovacaocadastro = CamadaDados.UtilData.Data_Servidor();
                                    fClifor.rClifor.Loginrenovacao = Utils.Parametros.pubLogin;
                                }
                                TCN_CadClifor.Gravar(fClifor.rClifor, null);
                                
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    CD_Clifor.Text = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                    afterBusca();
                }
                else
                    using (TFClifor fClifor = new TFClifor())
                    {
                        fClifor.Text = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_renovarcadastro ? "Renovando Cadastro Cliente/Fornecedor" : "Alterando Cliente/Fornecedor";
                        fClifor.rClifor = bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor;
                        if (fClifor.ShowDialog() == DialogResult.OK)
                        {
                            if (fClifor.rClifor != null)
                            {
                                try
                                {
                                    if (fClifor.rClifor.St_renovarcadastro)
                                    {
                                        fClifor.rClifor.Dt_renovacaocadastro = CamadaDados.UtilData.Data_Servidor();
                                        fClifor.rClifor.Loginrenovacao = Utils.Parametros.pubLogin;
                                    }
                                    TCN_CadClifor.Gravar(fClifor.rClifor, null);

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        CD_Clifor.Text = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                        afterBusca();
                    }
            }
            else
                MessageBox.Show("Obrigatorio selecionar clifor para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsClifor.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do registro?\r\n" +
                                   "Se o clifor possuir movimentação o mesmo não sera excluido, somente desativado.",
                                   "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadClifor.Excluir(bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor, null);
                        CD_Clifor.Text = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar clifor para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void afterBusca()
        {
            string cond = string.Empty;
            string virg = string.Empty;
            if (cbFisica.Checked)
            {
                cond = "'F'";
                virg = ",";
            }
            if (cbJuridica.Checked)
                cond += virg + "'J'";
            bsClifor.DataSource = TCN_CadClifor.Busca_Clifor(CD_Clifor.Text,
                                                             NM_Clifor.Text,
                                                             NM_Fantasia.Text,
                                                             NR_CGC.Text,
                                                             NR_CPF.Text,
                                                             cond,
                                                             ID_CategoriaClifor.Text,
                                                             Cd_CondFiscal_Clifor.Text,
                                                             ID_Regiao.Text,
                                                             string.Empty,
                                                             st_cadastrosrenovar.Checked,
                                                             Cep.Text,
                                                             cd_cidade.Text,
                                                             CD_UF.Text,
                                                             dt_ini.Text,
                                                             dt_fin.Text,
                                                             st_registro.Checked ? "'C'" : "'A'",
                                                             0,
                                                             null);
            bsClifor_PositionChanged(this, new EventArgs());
        }

        private void afterPrint()
        {
            if (bsClifor.Count > 0)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsClifor;
                    Rel.Nome_Relatorio = this.Name;
                    Rel.NM_Classe = this.Name;
                    Rel.Ident = this.Name;
                    Rel.Modulo = this.Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "RELATORIO " + this.Text.Trim();
                     

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
                                           "RELATORIO " + Text.Trim(),
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
                                               "RELATORIO " + Text.Trim(),
                                               fImp.pDs_mensagem);
                }
        }

        private void PrintFichaCadastral()
        {
            if (bsClifor.Current != null)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadClifor() { bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor };
                    Rel.DTS_Relatorio = bs;
                    Rel.Nome_Relatorio = "REL_FICHACADASTRO_CLIFOR";
                    Rel.NM_Classe = "REL_FICHACADASTRO_CLIFOR";
                    Rel.Ident = "REL_FICHACADASTRO_CLIFOR";
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "FICHA CADASTRO CLIENTE/FORNEC.";

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
                                           "FICHA CADASTRO CLIENTE/FORNEC.",
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
                                               "FICHA CADASTRO CLIENTE/FORNEC.",
                                               fImp.pDs_mensagem);
                }
            else
            {
                if (MessageBox.Show("Deseja Imprimir a Ficha Cadastral em branco?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                    {
                        FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                        Rel.Altera_Relatorio = Altera_Relatorio;
                        BindingSource bs = new BindingSource();
                        bs.DataSource = new CamadaDados.Financeiro.Cadastros.TList_CadClifor() { bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor };
                        Rel.DTS_Relatorio = bs;
                        Rel.Nome_Relatorio = "REL_FICHACADASTRO_CLIFOR_BRANCO";
                        Rel.NM_Classe = Name;
                        Rel.Ident = "REL_FICHACADASTRO_CLIFOR_BRANCO";
                        Rel.Modulo = Tag.ToString().Substring(0, 3);
                        fImp.St_enabled_enviaremail = true;
                        fImp.pCd_clifor = string.Empty;
                        fImp.pMensagem = "FICHA CADASTRO CLIENTE/FORNEC.";

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
                                               "FICHA CADASTRO CLIENTE/FORNEC.",
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
                                                   "FICHA CADASTRO CLIENTE/FORNEC.",
                                                   fImp.pDs_mensagem);
                    }
                }
            }
        }

        private void ConfigVendedor()
        {
            if(bsClifor.Current != null)
                using (TFCadCFGVendedor fCfgVendedor = new TFCadCFGVendedor())
                {
                    fCfgVendedor.Cd_vendedor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                    fCfgVendedor.Nm_vendedor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Nm_clifor;
                    fCfgVendedor.ShowDialog();
                }
        }

        private void analiseCred()
        {
            if (bsClifor.Current != null)
                using (TFAnaliseCredito fAnalise = new TFAnaliseCredito())
                {
                    fAnalise.rClifor = bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor;
                    if (fAnalise.ShowDialog() == DialogResult.OK)
                        if (fAnalise.rClifor != null)
                            try
                            {
                                TCN_CadClifor.Gravar(fAnalise.rClifor, null);
                                MessageBox.Show("Análise crédito realizada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CD_Clifor.Text = fAnalise.rClifor.Cd_clifor;
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void InserirEndereco()
        {
            if(bsClifor.Current != null)
                using (TFEndereco fEnd = new TFEndereco())
                {
                    fEnd.Tp_pessoa = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa;
                    if(fEnd.ShowDialog() == DialogResult.OK)
                        if (fEnd.rEnd != null)
                        {
                            fEnd.rEnd.Cd_clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                            try
                            {
                                TCN_CadEndereco.Gravar(fEnd.rEnd, null);
                                MessageBox.Show("Endereço gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
        }

        private void AlterarEndereco()
        {
            if(bsEndereco.Current != null)
                using (TFEndereco fEnd = new TFEndereco())
                {
                    fEnd.rEnd = bsEndereco.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco;
                    fEnd.Tp_pessoa = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa;
                    if(fEnd.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_CadEndereco.Gravar(fEnd.rEnd, null);
                            MessageBox.Show("Endereço alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
        }

        private void ExcluirEndereco()
        {
            if (bsEndereco.Count.Equals(1))
            {
                MessageBox.Show("Não é permitido clifor sem endereço.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(MessageBox.Show("Confirma exclusão do endereço selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                == DialogResult.Yes)
                try
                {
                    TCN_CadEndereco.Excluir(bsEndereco.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadEndereco, null);
                    MessageBox.Show("Endereço excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bsEndereco.RemoveCurrent();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InserirContato()
        {
            if(bsClifor.Current != null)
                if ((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("J"))
                    using (TFContatos fContato = new TFContatos())
                    {
                        if(fContato.ShowDialog() == DialogResult.OK)
                            if(fContato.rContato != null)
                                try
                                {
                                    fContato.rContato.Cd_CliFor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                                    TCN_CadContatoCliFor.Gravar(fContato.rContato, null);
                                    MessageBox.Show("Contato gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
                else
                    using (TFContatoPF fContatoPF = new TFContatoPF())
                    {
                        if(fContatoPF.ShowDialog() == DialogResult.OK)
                            if(fContatoPF.rContato != null)
                                try
                                {
                                    fContatoPF.rContato.Cd_CliFor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                                    TCN_CadContatoCliFor.Gravar(fContatoPF.rContato, null);
                                    MessageBox.Show("Contato gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    afterBusca();
                                }
                                catch (Exception ex)
                                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    }
        }

        private void AlterarContato()
        {
            if(bsContato.Current != null)
                if((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("J"))
                    using (TFContatos fContato = new TFContatos())
                    {
                        fContato.rContato = bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor;
                        if(fContato.ShowDialog() == DialogResult.OK)
                            try
                            {
                                TCN_CadContatoCliFor.Gravar(fContato.rContato, null);
                                MessageBox.Show("Contato alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        afterBusca();
                    }
                else
                    using (TFContatoPF fContato = new TFContatoPF())
                    {
                        fContato.rContato = bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor;
                        if(fContato.ShowDialog() == DialogResult.OK)
                            try
                            {
                                TCN_CadContatoCliFor.Gravar(fContato.rContato, null);
                                MessageBox.Show("Contato alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                        afterBusca();
                    }
        }

        private void ExcluirContato()
        {
            if(bsContato.Current != null)
                if(MessageBox.Show("Confirma exclusão do contato selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_CadContatoCliFor.Excluir(bsContato.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadContatoCliFor, null);
                        MessageBox.Show("Contato excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsContato.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InserirDadosBancarios()
        {
            if(bsClifor.Current != null)
                using (TFDadosBanc fDados = new TFDadosBanc())
                {
                    if(fDados.ShowDialog() == DialogResult.OK)
                        if(fDados.rDados != null)
                            try
                            {
                                fDados.rDados.CD_Clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                                TCN_CadDados_Bancarios_Clifor.Gravar(fDados.rDados, null);
                                MessageBox.Show("Dados bancarios gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void ExcluirDadosBancarios()
        {
            if(bsDados.Current != null)
                if(MessageBox.Show("Confirma exclusão dos dados bancarios selecionados?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_CadDados_Bancarios_Clifor.Excluir(bsDados.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadDados_Bancarios_Clifor, null);
                        MessageBox.Show("Dados bancarios excluidos com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsDados.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void InserirReferencia()
        {
            if(bsClifor.Current != null)
                using (TFReferencia fRef = new TFReferencia())
                {
                    if(fRef.ShowDialog() == DialogResult.OK)
                        if(fRef.rReferencia != null)
                            try
                            {
                                fRef.rReferencia.Cd_CliFor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                                TCN_CadReferenciaClifor.Gravar(fRef.rReferencia, null);
                                MessageBox.Show("Referência gravada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                afterBusca();
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void AlterarReferencia()
        {
            if(bsReferencia.Current != null)
                using (TFReferencia fRef = new TFReferencia())
                {
                    fRef.rReferencia = bsReferencia.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadReferenciaCliFor;
                    if(fRef.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_CadReferenciaClifor.Gravar(fRef.rReferencia, null);
                            MessageBox.Show("Referência alterada com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    afterBusca();
                }
        }

        private void ExcluirRefencia()
        {
            if(bsReferencia.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_CadReferenciaClifor.Excluir(bsReferencia.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadReferenciaCliFor, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsReferencia.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {
            afterNovo();
        }

        private void TFCadClifor_Load(object sender, EventArgs e)
        {
            ShapeGrid.RestoreShape(this, gClifor);
            ShapeGrid.RestoreShape(this, gEndereco);
            ShapeGrid.RestoreShape(this, gContato);
            ShapeGrid.RestoreShape(this, gDados);
            pTP_Clifor.BackColor = SettingsUtils.Default.COLOR_1;
            Icon = ResourcesUtils.TecnoAliance_ICO;
            pFiltro.set_FormatZero();
            bb_analiseCred.Visible = CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CONFIGURAR ANALISE CREDITO", null);
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            afterExclui();
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BB_CategoriaClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("a.DS_CategoriaClifor|Categoria Clifor|200;a.ID_CategoriaClifor|Cód. Categoria Clifor|100",
                new Componentes.EditDefault[] { ID_CategoriaClifor }, 
                new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor(), string.Empty);
        }

        private void ID_CategoriaClifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_CategoriaClifor|=|'" + ID_CategoriaClifor.Text + "'",
              new Componentes.EditDefault[] { ID_CategoriaClifor }, 
              new CamadaDados.Financeiro.Cadastros.TCD_CadCategoriaCliFor());
        }

        private void bb_FiscalClifor_Click(object sender, EventArgs e)
        {
            UtilPesquisa.BTN_BUSCA("DS_CondFiscal|Descrição|200;CD_CondFiscal_Clifor|Cód. Fiscal|100"
              , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor },
              new CamadaDados.Fiscal.TCD_CadConFiscalClifor(), string.Empty);
        }

        private void Cd_CondFiscal_Clifor_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("CD_CondFiscal_Clifor|=|'" + Cd_CondFiscal_Clifor.Text + "'"
                , new Componentes.EditDefault[] { Cd_CondFiscal_Clifor },
                new CamadaDados.Fiscal.TCD_CadConFiscalClifor());
        }

        private void ID_Regiao_Leave(object sender, EventArgs e)
        {
            string vColunas = ID_Regiao.NM_CampoBusca + "|=|'" + ID_Regiao.Text + "'";
            UtilPesquisa.EDIT_LEAVE(vColunas, new Componentes.EditDefault[] { ID_Regiao },
                                    new CamadaDados.Diversos.TCD_CadRegiaoVenda());
        }

        private void bb_regiaoVenda_Click(object sender, EventArgs e)
        {
            string vColunas = "NM_Regiao| Região Venda|350;" +
                               "ID_Regiao|Cód. Região Venda |100";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Regiao },
                                    new CamadaDados.Diversos.TCD_CadRegiaoVenda(), string.Empty);
        }

        private void bsClifor_PositionChanged(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                //Ativar botao config vendedor
                bb_confvendedor.Visible = ((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_vendedor ||
                                           (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_tecnico ||
                                           (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_representante ||
                                           (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).St_operadorcx) &&
                                            CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CONFIGURAR VENDEDOR", null);

                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lEndereco =
                    TCN_CadEndereco.Buscar((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
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
                                           string.Empty,
                                           string.Empty,
                                           0,
                                           null);
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lContato =
                    TCN_CadContatoCliFor.Buscar(string.Empty,
                                                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                string.Empty,
                                                false,
                                                false,
                                                false,
                                                string.Empty,
                                                0,
                                                null);
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lDadosBanc =
                    TCN_CadDados_Bancarios_Clifor.Busca((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                        string.Empty,
                                                        string.Empty,
                                                        string.Empty,
                                                        null);
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lReferencia =
                    TCN_CadReferenciaClifor.Busca((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                  string.Empty,
                                                  string.Empty,
                                                  string.Empty,
                                                  null);
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lPessoas =
                    TCN_PessoasAutorizadas.Buscar((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                  string.Empty,
                                                  string.Empty,
                                                  string.Empty,
                                                  string.Empty,
                                                  null);

                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lAnexo =
                   TCN_AnexoClifor.Buscar((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                          string.Empty,
                                          null);
                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lTabPreco =
                    TCN_Clifor_X_TabPreco.Buscar((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                 string.Empty,
                                                 null);

                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lConfPagto =
                    TCN_Clifor_X_CondPgto.Buscar((bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                                 string.Empty,
                                                 null);
                bsClifor.ResetCurrentItem();

                //Colunas do Grid Contatos
                clTP_Contato.Visible = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("J");
                clTipo_relaciomento.Visible = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("F");
                clDt_nascimento.Visible = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("F");
                clSt_envemailaniversariobool.Visible = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("F");
                clSt_receberOSbool.Visible = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Tp_pessoa.Trim().ToUpper().Equals("J");
            }
        }

        private void llbPesquisa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (llbPesquisa.Tag.ToString().Trim().Equals("N"))
            {
                //Mudar para modo completo
                llbPesquisa.Text = "<<<Pesquisa Normal";
                tlpCentral.RowStyles[0].Height = 105;
                llbPesquisa.Tag = "C";
            }
            else
            {
                //Mudar para modo normal
                llbPesquisa.Text = "Pesquisa Avançada>>>";
                tlpCentral.RowStyles[0].Height = 55;
                llbPesquisa.Tag = "N";
                NR_CGC.Clear();
                NR_CPF.Clear();
                NM_Fantasia.Clear();
                ID_CategoriaClifor.Clear();
                ID_Regiao.Clear();
                Cd_CondFiscal_Clifor.Clear();
                st_registro.Checked = false;
            }
        }

        private void TFCadClifor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
            else if (e.KeyCode.Equals(Keys.F9) && bb_confvendedor.Visible)
                ConfigVendedor();
            else if (e.KeyCode.Equals(Keys.F10))
                PrintFichaCadastral();
            else if (e.KeyCode.Equals(Keys.F11))
                afterPrint();
            else if (e.KeyCode.Equals(Keys.F12))
                analiseCred();
            else if (e.Control && e.KeyCode.Equals(Keys.P))
            {
                Altera_Relatorio = true;
                MessageBox.Show("Execute o relatorio que deseja alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gClifor_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gClifor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gClifor.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void bb_confvendedor_Click(object sender, EventArgs e)
        {
            ConfigVendedor();
        }

        private void BB_Imprimir_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void miListaClifor_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void miFichaCadastro_Click(object sender, EventArgs e)
        {
            PrintFichaCadastral();
        }

        private void TFCadClifor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShapeGrid.SaveShape(this, gClifor);
            ShapeGrid.SaveShape(this, gEndereco);
            ShapeGrid.SaveShape(this, gContato);
            ShapeGrid.SaveShape(this, gDados);
        }

        private void f10FichaCadastralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintFichaCadastral();
        }

        private void f11ListagemDeClientesFornecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            afterPrint();
        }

        private void bb_analiseCred_Click(object sender, EventArgs e)
        {
            analiseCred();
        }

        private void gClifor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (gClifor.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                return;
            if (bsClifor.Count < 1)
                return;
            PropertyDescriptorCollection lP = TypeDescriptor.GetProperties(new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor());
            CamadaDados.Financeiro.Cadastros.TList_CadClifor lComparer;
            SortOrder direcao = SortOrder.None;
            if ((gClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.None) ||
                (gClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == SortOrder.Descending))
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadClifor(lP.Find(gClifor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Ascending);
                foreach (DataGridViewColumn c in gClifor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Ascending;
            }
            else
            {
                lComparer = new CamadaDados.Financeiro.Cadastros.TList_CadClifor(lP.Find(gClifor.Columns[e.ColumnIndex].DataPropertyName, true), SortOrder.Descending);
                foreach (DataGridViewColumn c in gClifor.Columns)
                    c.HeaderCell.SortGlyphDirection = SortOrder.None;
                direcao = SortOrder.Descending;
            }
            (bsClifor.List as CamadaDados.Financeiro.Cadastros.TList_CadClifor).Sort(lComparer);
            bsClifor.ResetBindings(false);
            gClifor.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = direcao;
        }

        private void ts_btn_Inserir_Endereco_Click(object sender, EventArgs e)
        {
            InserirEndereco();
        }

        private void ts_btn_Alterar_Endereco_Click(object sender, EventArgs e)
        {
            AlterarEndereco();
        }

        private void ts_btn_Deletar_Endereco_Click(object sender, EventArgs e)
        {
            ExcluirEndereco();
        }

        private void ts_btn_Inserir_Contato_Click(object sender, EventArgs e)
        {
            InserirContato();
        }

        private void ts_btn_Alterar_Contato_Click(object sender, EventArgs e)
        {
            AlterarContato();
        }

        private void ts_btn_Deletar_Contato_Click(object sender, EventArgs e)
        {
            ExcluirContato();
        }

        private void ts_btn_Inserir_Dados_Bancarios_Click(object sender, EventArgs e)
        {
            InserirDadosBancarios();
        }

        private void ts_btn_Deletar_Dados_Bancarios_Click(object sender, EventArgs e)
        {
            ExcluirDadosBancarios();
        }

        private void btn_inserirReferencia_Click(object sender, EventArgs e)
        {
            InserirReferencia();
        }

        private void btn_alterarReferencia_Click(object sender, EventArgs e)
        {
            AlterarReferencia();
        }

        private void btn_excluirReferencia_Click(object sender, EventArgs e)
        {
            ExcluirRefencia();
        }

        private void bb_addPessoa_Click(object sender, EventArgs e)
        {
            if(bsClifor.Current != null)
                using (TFPessoasAutorizadas fPessoa = new TFPessoasAutorizadas())
                {
                    if(fPessoa.ShowDialog() == DialogResult.OK)
                        if(fPessoa.rPessoa != null)
                            try
                            {
                                fPessoa.rPessoa.Cd_clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                                TCN_PessoasAutorizadas.Gravar(fPessoa.rPessoa, null);
                                MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).lPessoas.Add(fPessoa.rPessoa);
                                bsClifor_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
        }

        private void bb_AltPessoas_Click(object sender, EventArgs e)
        {
            if (bsPessoas.Current != null)
                if ((bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).St_registro.Trim().ToUpper().Equals("C"))
                    (bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas).St_registro = "A";
                using (TFPessoasAutorizadas fPessoas = new TFPessoasAutorizadas())
                {
                    fPessoas.rPessoa = bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas;
                    if(fPessoas.ShowDialog() == DialogResult.OK)
                        try
                        {
                            TCN_PessoasAutorizadas.Gravar(fPessoas.rPessoa, null);
                            MessageBox.Show("Registro alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    bsClifor_PositionChanged(this, new EventArgs());
                }
        }

        private void bb_ExcluirPessoas_Click(object sender, EventArgs e)
        {
            if(bsPessoas.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {

                        TCN_PessoasAutorizadas.Excluir(bsPessoas.Current as CamadaDados.Financeiro.Cadastros.TRegistro_PessoasAutorizadas, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsClifor_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }


        private void bb_NovoAnexo_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                using (OpenFileDialog file = new OpenFileDialog())
                {
                    if (file.ShowDialog() == DialogResult.OK)
                        if (System.IO.File.Exists(file.FileName))
                        {
                            CamadaDados.Financeiro.Cadastros.TRegistro_AnexoClifor rAnexo = 
                                new CamadaDados.Financeiro.Cadastros.TRegistro_AnexoClifor();
                            rAnexo.Imagem_anexo = System.IO.File.ReadAllBytes(file.FileName);
                            rAnexo.Ext_Anexo = System.IO.Path.GetExtension(file.FileName);
                            InputBox ibp = new InputBox();
                            ibp.Text = "Descrição Anexo";
                            string ds = ibp.ShowDialog();
                            if (string.IsNullOrEmpty(ds))
                            {
                                MessageBox.Show("Obrigatório informar Descrição do Anexo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            try
                            {
                                rAnexo.Ds_anexo = ds;
                                rAnexo.Cd_clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor;
                                TCN_AnexoClifor.Gravar(rAnexo, null);
                                MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bsClifor_PositionChanged(this, new EventArgs());
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                        }
                }
            }
        }

        private void bb_ExcluirAnexo_Click(object sender, EventArgs e)
        {
            if (bsAnexoClifor.Current != null)
                if (MessageBox.Show("Deseja excluir esse Anexo?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_AnexoClifor.Excluir(bsAnexoClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_AnexoClifor, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsClifor_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void gPessoas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value != null)
                if (e.ColumnIndex == 0)
                {
                    if (e.Value.ToString().Trim().ToUpper().Equals("CANCELADO"))
                        gPessoas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    else
                        gPessoas.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                }
        }

        private void gAnexo_DoubleClick(object sender, EventArgs e)
        {
            if (bsAnexoClifor.Current != null)
            {
                if (!string.IsNullOrEmpty((bsAnexoClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_AnexoClifor).Ext_Anexo))
                {
                    byte[] arquivoBuffer = (bsAnexoClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_AnexoClifor).Imagem_anexo;
                    string extensao = (bsAnexoClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_AnexoClifor).Ext_Anexo; // retornar do banco tbm

                    string path = System.IO.Path.ChangeExtension(System.IO.Path.GetTempFileName(), extensao);

                    System.IO.File.WriteAllBytes(
                        path,
                        arquivoBuffer);

                    // para abrir o arquivo para o usuario
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        private void bbAddTabPreco_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                string vParam = "|not exists|(select 1 from tb_fin_clifor_x_tabpreco x where x.cd_tabelapreco = a.cd_tabelapreco and x.cd_clifor = '" +
                                (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor.Trim() + "')";
                DataRowView linha = UtilPesquisa.BTN_BUSCA("a.ds_tabelapreco|Tabela Preço|150;a.cd_tabelapreco|Código|60", null, new CamadaDados.Diversos.TCD_CadTbPreco(), vParam);
                if (linha != null)
                    try
                    {
                        TCN_Clifor_X_TabPreco.Gravar(new CamadaDados.Financeiro.Cadastros.TRegistro_Clifor_X_TabPreco()
                        {
                            Cd_clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                            Cd_tabelapreco = linha["cd_tabelapreco"].ToString()
                        }, null);
                        MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsClifor_PositionChanged(this, new EventArgs());
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void bbDelTabPreco_Click(object sender, EventArgs e)
        {
            if(bsTabPreco.Current != null)
                if(MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    try
                    {
                        TCN_Clifor_X_TabPreco.Excluir(bsTabPreco.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Clifor_X_TabPreco, null);
                        MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bsTabPreco.RemoveCurrent();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void cd_cidade_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_cidade|=|'" + cd_cidade.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cidade },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade());
        }

        private void bb_cidade_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_cidade|Cidade|150;" +
                              "a.cd_cidade|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cidade },
                new CamadaDados.Financeiro.Cadastros.TCD_CadCidade(), string.Empty);
        }

        private void CD_UF_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_uf|=|'" + CD_UF.Text.Trim() + "'";
            UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { CD_UF },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf());
        }

        private void BB_UF_Click(object sender, EventArgs e)
        {
            string vColunas = "a.ds_uf|Cidade|150;" +
                              "a.uf|UF|60;" +
                             "a.cd_uf|Código|60";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { CD_UF },
                new CamadaDados.Financeiro.Cadastros.TCD_CadUf(), string.Empty);
        }

        private void bbImprimirEndereco_Click(object sender, EventArgs e)
        {
            if (bsEndereco.Count > 0)
                using (FormRelPadrao.TFGerenciadorImpressao fImp = new FormRelPadrao.TFGerenciadorImpressao())
                {
                    FormRelPadrao.Relatorio Rel = new FormRelPadrao.Relatorio();
                    Rel.Altera_Relatorio = Altera_Relatorio;
                    Rel.DTS_Relatorio = bsEndereco;
                    Rel.Nome_Relatorio = "Impressão de endereço do cliente";
                    Rel.NM_Classe = "FImpressaoEnderecoClifor";
                    Rel.Modulo = Tag.ToString().Substring(0, 3);
                    fImp.St_enabled_enviaremail = true;
                    fImp.pCd_clifor = string.Empty;
                    fImp.pMensagem = "Impressão " + Text.Trim();

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
                                           "Impressão " + Text.Trim(),
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
                                               "Impressão " + Text.Trim(),
                                               fImp.pDs_mensagem);
                }
        }

        private void bb_novoCondPagto_Click(object sender, EventArgs e)
        {
            if (bsClifor.Current != null)
            {
                if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CONFIGURAR ANALISE CREDITO", null))
                {
                    string vParam = "|not exists|(select 1 from TB_FIN_Clifor_X_CondPgto x where x.CD_CondPGTO = a.CD_CondPGTO and x.cd_clifor = '" +
                                    (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor.Trim() + "')";
                    DataRowView linha = UtilPesquisa.BTN_BUSCA("a.DS_CondPGTO|Descrição|150;a.CD_CondPGTO|Código|60", null, new CamadaDados.Financeiro.Cadastros.TCD_CadCondPgto(), vParam);
                    if (linha != null)
                        try
                        {
                            TCN_Clifor_X_CondPgto.Gravar(new CamadaDados.Financeiro.Cadastros.TRegistro_Clifor_X_CondPgto()
                            {
                                Cd_clifor = (bsClifor.Current as CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor).Cd_clifor,
                                CD_CondPGTO = linha["CD_CondPGTO"].ToString()
                            }, null);
                            MessageBox.Show("Registro gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsClifor_PositionChanged(this, new EventArgs());
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                    MessageBox.Show("Usuário não tem acesso a ANÁLISE DE CRÉDITO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void bb_excluiCondPagto_Click(object sender, EventArgs e)
        {
            if (bsCondpagto.Current != null)
            {
                if (CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.ValidaRegra(Utils.Parametros.pubLogin, "PERMITIR CONFIGURAR ANALISE CREDITO", null))
                {
                    if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        try
                        {
                            TCN_Clifor_X_CondPgto.Excluir(bsCondpagto.Current as CamadaDados.Financeiro.Cadastros.TRegistro_Clifor_X_CondPgto, null);
                            MessageBox.Show("Registro excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bsCondpagto.RemoveCurrent();
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }
                else
                    MessageBox.Show("Usuário não tem acesso a ANÁLISE DE CRÉDITO!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
