using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using Utils;
using CamadaDados.Servicos.Cadastros;
using CamadaDados.Servicos;
using CamadaNegocio.Servicos;
using CamadaNegocio.Servicos.Cadastros;

namespace Servicos
{
    public partial class TFLan_Evolucao_Ordem_Servico : Form
    {
        public TFLan_Evolucao_Ordem_Servico()
        {
            InitializeComponent();
            St_altera = false;
            TP_Ordem = string.Empty;
            Etapa_atual = string.Empty;
        }

        public bool St_altera
        { get; set; }

        private CamadaDados.Servicos.TRegistro_LanServicoEvolucao revolucao;
        public CamadaDados.Servicos.TRegistro_LanServicoEvolucao rEvolucao
        {
            get
            {
                if (BS_Evolucao.Current != null)
                    return (BS_Evolucao.Current as CamadaDados.Servicos.TRegistro_LanServicoEvolucao);
                else
                    return null;
            }
            set
            {revolucao = value;}
        }

        public string TP_Ordem
        { get; set; }

        public string Etapa_atual
        { get; set; }


        private void BuscarEndereco()
        {
            if (!string.IsNullOrEmpty(cd_cliforOficina.Text))
            {
                CamadaDados.Financeiro.Cadastros.TList_CadEndereco lEnd =
                    CamadaNegocio.Financeiro.Cadastros.TCN_CadEndereco.Buscar(cd_cliforOficina.Text,
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
                                                                              1,
                                                                              null);
                if (lEnd.Count > 0)
                {
                    CD_Endereco.Text = lEnd[0].Cd_endereco;
                    DS_Endereco.Text = lEnd[0].Ds_endereco;
                }
            }
        }

        private void ID_Tecnico_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveClifor("a.cd_clifor|=|'" + ID_Tecnico.Text.Trim() + "';isnull(a.st_tecnico, 'N')|=|'S';isnull(a.ST_Funcionarios, 'N')|=|'S'",
                                                    new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao },
                                                    new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
        }

        private void FLan_Evolucao_Ordem_Servico_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
            pnl_Evolucao.set_FormatZero();
            panelDados6.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            this.Icon = ResourcesUtils.TecnoAliance_ICO;
            //Busca lista de etapas disponiveis
            TpBusca[] filtro = new TpBusca[1];
            if (string.IsNullOrEmpty(Etapa_atual) || St_altera)
            {
                filtro[0].vNM_Campo = "isnull(c.st_iniciaros, 'N')";
                filtro[0].vOperador = "=";
                filtro[0].vVL_Busca = "'S'";
            }
            else
            {
                filtro[0].vNM_Campo = string.Empty;
                filtro[0].vOperador = "exists";
                filtro[0].vVL_Busca = "(select 1 from TB_OSE_ProximaEtapa x " +
                                      "			where x.ID_ProximaEtapa = a.ID_Etapa " +
                                      "			and x.ID_Etapa = " + Etapa_atual.Trim() + ")";
            }
            Estruturas.CriarParametro(ref filtro, "a.tp_ordem", "'" + TP_Ordem + "'");

            cbEtapa.DataSource = new TCD_TpOrdem_X_Etapa().Select(filtro, 0, string.Empty);
            cbEtapa.DisplayMember = "Ds_etapa";
            cbEtapa.ValueMember = "Id_etapa";
            //Criar novo registro se nao estiver alterando
            if (!St_altera)
            {
                BS_Evolucao.AddNew();
                if ((cbEtapa.DataSource as TList_TpOrdem_X_Etapa).Count.Equals(1))
                {
                    cbEtapa.SelectedIndex = 0;
                    ID_Tecnico.Focus();
                }
                else cbEtapa.Focus();
            }
            else
            {
                BS_Evolucao.DataSource = new CamadaDados.Servicos.TList_LanServicoEvolucao() { revolucao };
                ID_Tecnico.Focus();
            }
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            if (pnl_Evolucao.validarCampoObrigatorio())
            {
                if (cbEtapa.SelectedValue == null)
                {
                    MessageBox.Show("Obrigatorio selecionar ETAPA.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((cbEtapa.SelectedItem as TRegistro_TpOrdem_X_Etapa).St_envterceirobool)
                {
                    if (string.IsNullOrEmpty(cd_cliforOficina.Text))
                    {
                        MessageBox.Show("Obrigatorio informar Oficina!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(CD_Endereco.Text))
                    {
                        MessageBox.Show("Obrigatorio informar Endereço Oficina!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FLan_Evolucao_Ordem_Servico_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.F6):
                    {
                        BB_Cancelar_Click(sender, new EventArgs()); break;
                    }
                case (Keys.F4):
                    {
                        BB_Gravar_Click(sender, new EventArgs()); break;
                    };
            }
        }

        private void BB_Tecnico_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaClifor(new Componentes.EditDefault[] { ID_Tecnico, DS_Funcao }, "isnull(a.st_tecnico, 'N')|=|'S';isnull(a.ST_Funcionarios, 'N')|=|'S'");
        }
       
        private void cd_cliforOficina_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_clifor|=|'" + cd_cliforOficina.Text.Trim() + "';" +
                                "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                                            new CamadaDados.Financeiro.Cadastros.TCD_CadClifor());
            this.BuscarEndereco();
        }

        private void bb_Oficina_Click(object sender, EventArgs e)
        {
            string vColunas = "a.nm_clifor|Oficina|200;" +
                               "a.cd_clifor|Codigo|80";
            string vParam = "isnull(a.st_registro, 'C')|=|'A'";
            FormBusca.UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cliforOficina, nm_cliforOficina },
                new CamadaDados.Financeiro.Cadastros.TCD_CadClifor(),
                vParam);
            this.BuscarEndereco();
        }

        private void CD_Endereco_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_cliforOficina.Text))
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_endereco|=|'" + CD_Endereco.Text + "';a.cd_clifor|=|'" + cd_cliforOficina.Text + "'"
                   , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco());
            }
        }

        private void BB_Endereco_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cd_cliforOficina.Text))
            {
                UtilPesquisa.BTN_BUSCA("a.ds_endereco|Endereco|150;a.cd_endereco|Código Endereço|80;b.DS_Cidade|Cidade|250;UF|Estado|150"
                    , new Componentes.EditDefault[] { CD_Endereco, DS_Endereco }, new CamadaDados.Financeiro.Cadastros.TCD_CadEndereco(), "a.cd_clifor|=|'" + cd_cliforOficina.Text + "'");
            }
        }

        private void bbAddOficina_Click(object sender, EventArgs e)
        {
            using (Financeiro.Cadastros.TFCadCliforResumido fClifor = new Financeiro.Cadastros.TFCadCliforResumido())
            {
                if (fClifor.ShowDialog() == DialogResult.OK)
                    try
                    {
                        CamadaNegocio.Financeiro.Cadastros.TCN_CadClifor.Gravar(fClifor.rClifor, null);
                        MessageBox.Show("Cliente gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cd_cliforOficina.Text = fClifor.rClifor.Cd_clifor;
                        nm_cliforOficina.Text = fClifor.rClifor.Nm_clifor;
                        this.BuscarEndereco();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }
    }
}
