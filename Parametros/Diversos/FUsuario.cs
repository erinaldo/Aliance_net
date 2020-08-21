using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Parametros.Diversos
{
    public partial class TFUsuario : Form
    {
        private CamadaDados.Diversos.TRegistro_CadUsuario ruser;
        public CamadaDados.Diversos.TRegistro_CadUsuario rUser
        {
            get
            {
                if (bsUsuario.Current != null)
                    return bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario;
                else
                    return null;
            }
            set { ruser = value; }
        }

        public TFUsuario()
        {
            InitializeComponent();
            System.Collections.ArrayList cbx = new System.Collections.ArrayList();
            cbx.Add(new Utils.TDataCombo("USUARIO", "U"));
            cbx.Add(new Utils.TDataCombo("GRUPO", "G"));

            tp_registro.DataSource = cbx;
            tp_registro.ValueMember = "Value";
            tp_registro.DisplayMember = "Display";
        }

        private void afterGrava()
        {
            if (pUsuario.validarCampoObrigatorio())
                this.DialogResult = DialogResult.OK;
        }

        private void InserirGrupo()
        {
            if (bsUsuario.Current != null)
            {
                using (TFListGrupoMenu fGrupo = new TFListGrupoMenu())
                {
                    fGrupo.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fGrupo.ShowDialog() == DialogResult.OK)
                        if (fGrupo.lGrupo != null)
                        {
                            fGrupo.lGrupo.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lGrupo.Exists(v => v.LoginGrp.Trim().Equals(p.Login.Trim())))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lGrupo.Add(new CamadaDados.Diversos.TRegistro_CadUsuario_Grupo()
                                            {
                                                LoginGrp = p.Login,
                                                Nome_grupo = p.Nome_usuario
                                            });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
            }
        }

        private void ExcluirGrupo()
        {
            if (bsGrupo.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do grupo selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lGrupoDel.Add(
                        bsGrupo.Current as CamadaDados.Diversos.TRegistro_CadUsuario_Grupo);
                    bsGrupo.RemoveCurrent();
                }
            }
        }

        private void InserirEmpresa()
        {
            if (bsUsuario.Current != null)
            {
                using (TFListEmpresas fEmpresa = new TFListEmpresas())
                {
                    fEmpresa.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fEmpresa.ShowDialog() == DialogResult.OK)
                        if (fEmpresa.lEmpresa != null)
                        {
                            fEmpresa.lEmpresa.ForEach(p =>
                            {
                                if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEmpresa.Exists(v => v.CD_Empresa.Trim().Equals(p.Cd_empresa.Trim())))
                                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEmpresa.Add(new CamadaDados.Diversos.TRegistro_CadUsuario_Empresa()
                                        {
                                            CD_Empresa = p.Cd_empresa,
                                            NM_Empresa = p.Nm_empresa
                                        });
                            });
                            bsUsuario.ResetCurrentItem();
                        }
                }
            }
        }

        private void ExcluirEmpresa()
        {
            if (bsEmpresa.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão da empresa selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEmpresaDel.Add(
                        bsEmpresa.Current as CamadaDados.Diversos.TRegistro_CadUsuario_Empresa);
                    bsEmpresa.RemoveCurrent();
                }
            }
        }

        private void InserirTerminal()
        {
            if (bsUsuario.Current != null)
            {
                using (TFListTerminal fTerminal = new TFListTerminal())
                {
                    fTerminal.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fTerminal.ShowDialog() == DialogResult.OK)
                        if (fTerminal.lTerminal != null)
                        {
                            fTerminal.lTerminal.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTerminal.Exists(v => v.Cd_Terminal.Trim().Equals(p.Cd_Terminal.Trim())))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTerminal.Add(new CamadaDados.Diversos.TRegistro_CadUsuarioxTerminal()
                                        {
                                            Cd_Terminal = p.Cd_Terminal,
                                            Ds_terminal = p.Ds_Terminal
                                        });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
            }
        }

        private void ExcluirTerminal()
        {
            if(bsTerminal.Current != null)
                if (MessageBox.Show("Confirma exclusão do terminal selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTerminalDel.Add(
                        bsTerminal.Current as CamadaDados.Diversos.TRegistro_CadUsuarioxTerminal);
                    bsTerminal.RemoveCurrent();
                }
        }

        private void InserirTpPesagem()
        {
            if(bsUsuario.Current != null)
                using (TFListTpPesagem fPesagem = new TFListTpPesagem())
                {
                    fPesagem.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fPesagem.ShowDialog() == DialogResult.OK)
                        if (fPesagem.lPesagem != null)
                        {
                            fPesagem.lPesagem.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPesagem.Exists(v => v.Tp_pesagem.Trim().Equals(p.Tp_pesagem.Trim())))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPesagem.Add(new CamadaDados.Diversos.TRegistro_CadUsuario_TipoPesagem()
                                        {
                                            Tp_pesagem = p.Tp_pesagem,
                                            Nm_tppesagem = p.Nm_tppesagem
                                        });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void ExcluirTpPesagem()
        {
            if(bsPesagem.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPesagemDel.Add(
                        bsPesagem.Current as CamadaDados.Diversos.TRegistro_CadUsuario_TipoPesagem);
                    bsPesagem.RemoveCurrent();
                }
        }

        private void InserirTpPedido()
        {
            if(bsUsuario.Current != null)
                using (TFListCfgPedido fCfgPed = new TFListCfgPedido())
                {
                    fCfgPed.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fCfgPed.ShowDialog() == DialogResult.OK)
                        if (fCfgPed.lPedido != null)
                        {
                            fCfgPed.lPedido.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPedido.Exists(v => v.Cfg_pedido.Trim().Equals(p.Cfg_pedido.Trim())))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPedido.Add(new CamadaDados.Diversos.TRegistro_CadUsuario_CFGPedido()
                                        {
                                            Cfg_pedido = p.Cfg_pedido,
                                            DS_Cfg_pedido = p.Ds_tipopedido
                                        });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void ExcluirTpPedido()
        {
            if(bsPedido.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPedidoDel.Add(
                        bsPedido.Current as CamadaDados.Diversos.TRegistro_CadUsuario_CFGPedido);
                    bsPedido.RemoveCurrent();
                }
        }

        private void InserirContaGer()
        {
            if(bsUsuario.Current != null)
                using (TFListContaGer fConta = new TFListContaGer())
                {
                    fConta.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fConta.ShowDialog() == DialogResult.OK)
                        if (fConta.lContaGer != null)
                        {
                            fConta.lContaGer.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lContaGer.Exists(v => v.Cd_contager.Trim().Equals(p.Cd_contager.Trim())))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lContaGer.Add(new CamadaDados.Diversos.TRegistro_Usuario_ContaGer()
                                        {
                                            Cd_contager = p.Cd_contager,
                                            Ds_contager = p.Ds_contager
                                        });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void ExcluirContaGer()
        {
            if(bsContaGer.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lContaGerDel.Add(
                        bsContaGer.Current as CamadaDados.Diversos.TRegistro_Usuario_ContaGer);
                    bsContaGer.RemoveCurrent();
                }
        }

        private void ExcluirEtapaPedido()
        {
            if (bsEtapaped.Current != null)
                if (MessageBox.Show("Confirma exclusão da Etapa selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEtapaPed.Add(
                        bsEtapaped.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa);
                    bsRegra.RemoveCurrent();
                }
        }
        private void ExcluirRegra()
        {
            if(bsRegra.Current != null)
                if (MessageBox.Show("Confirma exclusão da regra selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lRegraDel.Add(
                        bsRegra.Current as CamadaDados.Diversos.TRegistro_Usuario_RegraEspecial);
                    bsRegra.RemoveCurrent();
                }
        }

        private void InserirTpRequisicao()
        {
            if(bsUsuario.Current != null)
                using (TFListTpRequisicao fReq = new TFListTpRequisicao())
                {
                    fReq.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fReq.ShowDialog() == DialogResult.OK)
                        if (fReq.lTpRequisicao != null)
                        {
                            fReq.lTpRequisicao.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpRequisicao.Exists(v => v.Id_tprequisicao.Equals(p.Id_tprequisicao)))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpRequisicao.Add(
                                            new CamadaDados.Diversos.TRegistro_Usuario_TpRequisicao()
                                            {
                                                Id_tprequisicao = p.Id_tprequisicao,
                                                Ds_tprequisicao = p.Ds_tprequisicao
                                            });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void ExcluirTpRequisicao()
        {
            if(bsTpRequisicao.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpRequisicaoDel.Add(
                        bsTpRequisicao.Current as CamadaDados.Diversos.TRegistro_Usuario_TpRequisicao);
                    bsTpRequisicao.RemoveCurrent();
                }
        }

        private void InserirTpDuplicata()
        {
            if(bsUsuario.Current != null)
                using (TFListTpDuplicata fDup = new TFListTpDuplicata())
                {
                    fDup.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if(fDup.ShowDialog() == DialogResult.OK)
                        if (fDup.lTpDuplicata != null)
                        {
                            fDup.lTpDuplicata.ForEach(p =>
                                {
                                    if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpDuplicata.Exists(v => v.Tp_duplicata.Equals(p.Tp_duplicata)))
                                        (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpDuplicata.Add(
                                            new CamadaDados.Diversos.TRegistro_Usuario_TpDuplicata()
                                            {
                                                Tp_duplicata = p.Tp_duplicata,
                                                Ds_tpduplicata = p.Ds_tpduplicata
                                            });
                                });
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void ExcluirTpDuplicata()
        {
            if(bsTpDuplicata.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpDupDel.Add(
                        bsTpDuplicata.Current as CamadaDados.Diversos.TRegistro_Usuario_TpDuplicata);
                    bsTpDuplicata.RemoveCurrent();
                }
        }

        private void bb_cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void bb_inutilizar_Click(object sender, EventArgs e)
        {
            this.afterGrava();
        }

        private void TFUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                this.afterGrava();
            else if (e.KeyCode.Equals(Keys.F6))
                this.DialogResult = DialogResult.Cancel;
            else if (tcCentral.SelectedTab.Equals(tpGrupo) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirGrupo();
            else if (tcCentral.SelectedTab.Equals(tpGrupo) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirGrupo();
            else if (tcCentral.SelectedTab.Equals(tpEmpresa) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirEmpresa();
            else if (tcCentral.SelectedTab.Equals(tpEmpresa) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirEmpresa();
            else if (tcCentral.SelectedTab.Equals(tpTerminal) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTerminal();
            else if (tcCentral.SelectedTab.Equals(tpTerminal) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTerminal();
            else if (tcCentral.SelectedTab.Equals(tpPesagem) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTpPesagem();
            else if (tcCentral.SelectedTab.Equals(tpPesagem) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTpPesagem();
            else if (tcCentral.SelectedTab.Equals(tpPedido) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTpPedido();
            else if (tcCentral.SelectedTab.Equals(tpPedido) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTpPedido();
            else if (tcCentral.SelectedTab.Equals(tpContaGer) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirContaGer();
            else if (tcCentral.SelectedTab.Equals(tpContaGer) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirContaGer();
            else if (tcCentral.SelectedTab.Equals(tpRegra) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirRegra();
            else if (tcCentral.SelectedTab.Equals(tpRequisicao) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTpRequisicao();
            else if (tcCentral.SelectedTab.Equals(tpRequisicao) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTpRequisicao();
            else if (tcCentral.SelectedTab.Equals(tpDuplicata) && e.Control && e.KeyCode.Equals(Keys.F10))
                this.InserirTpDuplicata();
            else if (tcCentral.SelectedTab.Equals(tpDuplicata) && e.Control && e.KeyCode.Equals(Keys.F12))
                this.ExcluirTpDuplicata();
        }

        private void TFUsuario_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (ruser != null)
            {
                bsUsuario.DataSource = new CamadaDados.Diversos.TList_CadUsuario() { ruser };
                Login.Enabled = false;
                tp_registro.Enabled = false;
                if (!Senha.Focus())
                    Nome_Usuario.Focus();
            }
            else
            {
                bsUsuario.AddNew();
                Login.Focus();
            }
        }

        private void btn_Inserir_Item_Click(object sender, EventArgs e)
        {
            this.InserirGrupo();
        }

        private void btn_Deleta_Item_Click(object sender, EventArgs e)
        {
            this.ExcluirGrupo();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.InserirEmpresa();
        }

        private void bbExcluirEmpresa_Click(object sender, EventArgs e)
        {
            this.ExcluirEmpresa();
        }

        private void bbInserirTerminal_Click(object sender, EventArgs e)
        {
            this.InserirTerminal();
        }

        private void bbExcluirTerminal_Click(object sender, EventArgs e)
        {
            this.ExcluirTerminal();
        }

        private void bbInserirPesagem_Click(object sender, EventArgs e)
        {
            this.InserirTpPesagem();
        }

        private void bbExcluirPesagem_Click(object sender, EventArgs e)
        {
            this.ExcluirTpPesagem();
        }

        private void bbInserirTpPedido_Click(object sender, EventArgs e)
        {
            this.InserirTpPedido();
        }

        private void bbExcluirTpPedido_Click(object sender, EventArgs e)
        {
            this.ExcluirTpPedido();
        }

        private void bbInserirContaGer_Click(object sender, EventArgs e)
        {
            this.InserirContaGer();
        }

        private void bbExcluirContaGer_Click(object sender, EventArgs e)
        {
            this.ExcluirContaGer();
        }

        private void bbExcluirRegra_Click(object sender, EventArgs e)
        {
            this.ExcluirRegra();
        }

        private void Login_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Login.Text))
            {
                CamadaDados.Diversos.TList_CadUsuario lUser =
                    CamadaNegocio.Diversos.TCN_CadUsuario.Busca(Login.Text,
                                                                string.Empty,
                                                                string.Empty,
                                                                null);
                if (lUser.Count > 0)
                {
                    //Buscar acesso usuario
                    lUser[0].lAcesso =
                    CamadaNegocio.Diversos.TCN_CadAcesso.Buscar(lUser[0].Login,
                                                               string.Empty,
                                                               false,
                                                               string.Empty,
                                                               0,
                                                               "a.id_menu, c.nivel",
                                                               null);
                    //Buscar grupo menu
                    lUser[0].lGrupo =
                    CamadaNegocio.Diversos.TCN_CadUsuario_Grupo.Busca(string.Empty,
                                                                      lUser[0].Login,
                                                                      null);
                    //Buscar Empresas
                    lUser[0].lEmpresa =
                    CamadaNegocio.Diversos.TCN_CadUsuario_Empresa.Busca(string.Empty,
                                                                        lUser[0].Login,
                                                                        null);
                    //Buscar terminal
                    lUser[0].lTerminal =
                    CamadaNegocio.Diversos.TCN_CadUsuarioxTerminal.Busca(string.Empty,
                                                                         lUser[0].Login,
                                                                         null);
                    //Tipo Pesagem
                    lUser[0].lPesagem =
                    CamadaNegocio.Diversos.TCN_CadUsuario_TipoPesagem.Busca(lUser[0].Login,
                                                                            string.Empty,
                                                                            null);
                    //Tipo Pedido
                    lUser[0].lPedido =
                    CamadaNegocio.Diversos.TCN_CadUsuario_CFGPedido.Busca(lUser[0].Login,
                                                                          string.Empty,
                                               string.Empty,
                                                                          null);
                    //Conta Gerencial
                    lUser[0].lContaGer =
                    CamadaNegocio.Diversos.TCN_Usuario_ContaGer.Buscar(lUser[0].Login,
                                                                       string.Empty,
                                                                       null);
                    //Tipo Requisicao
                    lUser[0].lTpRequisicao =
                        CamadaNegocio.Diversos.TCN_Usuario_TpRequisicao.Buscar(lUser[0].Login,
                                                                               string.Empty,
                                                                               null);
                    //Tipo Duplicata
                    lUser[0].lTpDuplicata =
                        CamadaNegocio.Diversos.TCN_Usuario_TpDuplicata.Buscar(lUser[0].Login,
                                                                              string.Empty,
                                                                              null);
                    //Regra especial
                    lUser[0].lRegra =
                    CamadaNegocio.Diversos.TCN_Usuario_RegraEspecial.Buscar(lUser[0].Login,
                                                                            string.Empty,
                                                                            string.Empty,
                                                                            null);
                    //etapa pedido
                    lUser[0].lEtapaPed =
                    CamadaNegocio.Diversos.TCN_CadUsuario_EtapaPed.Busca(lUser[0].Login,
                                                                            string.Empty,
                                                                            null);
                    this.Text = "Alterado Usuario";
                    bsUsuario.Clear();
                    bsUsuario.DataSource = lUser;
                    Login.Enabled = false;
                    tp_registro.Enabled = false;
                    if (!Senha.Focus())
                        Nome_Usuario.Focus();
                }
            }
        }

        private void bb_inserirtprequisicao_Click(object sender, EventArgs e)
        {
            this.InserirTpRequisicao();
        }

        private void bb_excluirtprequisicao_Click(object sender, EventArgs e)
        {
            this.ExcluirTpRequisicao();
        }

        private void bb_inserirtpduplicata_Click(object sender, EventArgs e)
        {
            this.InserirTpDuplicata();
        }

        private void bb_excluirtpduplicata_Click(object sender, EventArgs e)
        {
            this.ExcluirTpDuplicata();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
                using (TFCadUsuario_EtapaPed fetapa = new TFCadUsuario_EtapaPed())
                {
                    fetapa.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fetapa.ShowDialog() == DialogResult.OK)
                        if (fetapa.lEtapaPed != null)
                        {
                            fetapa.lEtapaPed.ForEach(p =>
                            {
                                if (!(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEtapaPed.Exists(v => v.Id_etapa.Equals(p.Id_etapa)))
                                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEtapaPed.Add(new CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa()
                                    {
                                        Id_etapa = p.Id_etapa,
                                        DS_Etapa = p.DS_Etapa
                                    });
                            });
                            bsUsuario.ResetCurrentItem();
                            
                        }
                }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (bsEtapaped.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEtapaPedDel.Add(
                        bsEtapaped.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa);
                    bsEtapaped.RemoveCurrent();
                }
        }
    }
}
