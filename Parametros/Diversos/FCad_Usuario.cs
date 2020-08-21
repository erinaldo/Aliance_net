using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Diversos;
using CamadaNegocio.Diversos;

namespace Parametros.Diversos
{
    public partial class TFCad_Usuario : Form
    {
        public TFCad_Usuario()
        {
            InitializeComponent();
        }

        private void LimparFiltros()
        {
            login.Clear();
            nome_usuario.Clear();
            cbGrupo.Checked = false;
            cbUsuario.Checked = false;
        }

        private void afterNovo()
        {
            using (TFUsuario fUser = new TFUsuario())
            {
                fUser.Text = "Novo Usuario";
                if(fUser.ShowDialog() == DialogResult.OK)
                    if(fUser.rUser != null)
                        try
                        {
                            TCN_CadUsuario.Gravar(fUser.rUser, null);
                            if(fUser.rUser.Tp_registro.Trim().ToUpper().Equals("U"))
                                try
                                {
                                    new BancoDados.TObjetoBanco().setaUsuarioSql(fUser.rUser.Login, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados);
                                }
                                catch
                                { }
                            MessageBox.Show("Usuario gravado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.LimparFiltros();
                            login.Text = fUser.rUser.Login;
                            this.afterBusca();

                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void afterAltera()
        {
            if (bsUsuario.Current != null)
                using (TFUsuario fUser = new TFUsuario())
                {
                    fUser.Text = "Alterado Usuario";
                    fUser.rUser = bsUsuario.Current as TRegistro_CadUsuario;
                    if(fUser.ShowDialog() == DialogResult.OK)
                        if(fUser.rUser != null)
                            try
                            {
                                TCN_CadUsuario.Gravar(fUser.rUser, null);
                                MessageBox.Show("Usuario alterado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    this.LimparFiltros();
                    this.afterBusca();
                }
            else
                MessageBox.Show("Obrigatorio selecionar usuario para alterar.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterExclui()
        {
            if (bsUsuario.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do usuario selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                    == DialogResult.Yes)
                    try
                    {
                        TCN_CadUsuario.Excluir(bsUsuario.Current as TRegistro_CadUsuario, null);
                        try
                        {
                            new BancoDados.TObjetoBanco().ExcluirUsuarioSql((bsUsuario.Current as TRegistro_CadUsuario).Login, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados);
                        }
                        catch { }
                        MessageBox.Show("Usuario excluido com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.LimparFiltros();
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else
                MessageBox.Show("Obrigatorio selecionar usuario para excluir.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void afterBusca()
        {
            string tp_registro = string.Empty;
            string virg = string.Empty;
            if (cbUsuario.Checked)
            {
                tp_registro = "'U'";
                virg = ",";
            }
            if (cbGrupo.Checked)
                tp_registro += virg + "'G'";
            bsUsuario.DataSource = TCN_CadUsuario.Busca(login.Text,
                                                        nome_usuario.Text,
                                                        tp_registro,
                                                        null);
            bsUsuario_PositionChanged(this, new EventArgs());
        }

        private void CopiarPerfil()
        {
            using (TFCopiarPerfil fCop = new TFCopiarPerfil())
            {
                if (bsUsuario.Current != null)
                    if ((bsUsuario.Current as TRegistro_CadUsuario).Tp_registro.Trim().ToUpper().Equals("U"))
                        fCop.pLogin = (bsUsuario.Current as TRegistro_CadUsuario).Login;
                if(fCop.ShowDialog() == DialogResult.OK)
                    try
                    {
                        fCop.rUser.Tp_registro = "U";//Usuario
                        if (!TCN_CadUsuario.CopiarPerfil(fCop.rUser, fCop.pLogin, null))
                            new BancoDados.TObjetoBanco().setaUsuarioSql(fCop.rUser.Login, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados);
                        this.LimparFiltros();
                        login.Text = fCop.rUser.Login;
                        this.afterBusca();
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void UserSql()
        {
            if (bsUsuario.Current != null)
                try
                {
                    (bsUsuario.List as CamadaDados.Diversos.TList_CadUsuario).
                        Where(p => p.Tp_registro.ToUpper().Equals("U")).ToList().ForEach(p =>
                            new BancoDados.TObjetoBanco().setaUsuarioSql(p.Login, Utils.Parametros.pubNM_Servidor, Utils.Parametros.pubNM_BancoDados));
                    MessageBox.Show("Usuários SQL criados com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.afterBusca();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            this.afterBusca();
        }

        private void TFCad_Usuario_Load(object sender, EventArgs e)
        {
            this.Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
        }

        private void BB_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bsUsuario_PositionChanged(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
            {
                //Buscar acesso usuario
                (bsUsuario.Current as TRegistro_CadUsuario).lAcesso =
                TCN_CadAcesso.Buscar((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                    string.Empty,
                                    false,
                                    string.Empty,
                                    0,
                                    "a.id_menu, c.nivel",
                                    null);
                //Buscar grupo menu
                (bsUsuario.Current as TRegistro_CadUsuario).lGrupo =
                TCN_CadUsuario_Grupo.Busca(string.Empty,
                                           (bsUsuario.Current as TRegistro_CadUsuario).Login,
                                           null);
                //Buscar Empresas
                (bsUsuario.Current as TRegistro_CadUsuario).lEmpresa =
                TCN_CadUsuario_Empresa.Busca(string.Empty,
                                             (bsUsuario.Current as TRegistro_CadUsuario).Login,
                                             null);
                //Buscar terminal
                (bsUsuario.Current as TRegistro_CadUsuario).lTerminal =
                TCN_CadUsuarioxTerminal.Busca(string.Empty,
                                              (bsUsuario.Current as TRegistro_CadUsuario).Login,
                                              null);
                //Tipo Pesagem
                (bsUsuario.Current as TRegistro_CadUsuario).lPesagem =
                TCN_CadUsuario_TipoPesagem.Busca((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                                 string.Empty,
                                                 null);
                //Tipo Pedido
                (bsUsuario.Current as TRegistro_CadUsuario).lPedido =
                TCN_CadUsuario_CFGPedido.Busca((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                               string.Empty,
                                               string.Empty,
                                               null);
                //Buscar Tipo Requisicao
                (bsUsuario.Current as TRegistro_CadUsuario).lTpRequisicao =
                    TCN_Usuario_TpRequisicao.Buscar((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                                    string.Empty,
                                                    null);
                //Buscar Tipo Duplicata
                (bsUsuario.Current as TRegistro_CadUsuario).lTpDuplicata =
                    TCN_Usuario_TpDuplicata.Buscar((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                                   string.Empty,
                                                   null);
                //Conta Gerencial
                (bsUsuario.Current as TRegistro_CadUsuario).lContaGer =
                TCN_Usuario_ContaGer.Buscar((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                            string.Empty,
                                            null);
                //Regra especial
                (bsUsuario.Current as TRegistro_CadUsuario).lRegra = 
                TCN_Usuario_RegraEspecial.Buscar((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                                 string.Empty,
                                                 string.Empty,
                                                 null);
                //etapa pedido
                (bsUsuario.Current as TRegistro_CadUsuario).lEtapaPed =
                CamadaNegocio.Diversos.TCN_CadUsuario_EtapaPed.Busca((bsUsuario.Current as TRegistro_CadUsuario).Login,
                                                 string.Empty,
                                                 null);

                Utils.TpBusca[] tps = new Utils.TpBusca[0];
                Utils.Estruturas.CriarParametro(ref tps, "", 
                    "(select 1 from tb_div_usuario_x_tpproduto xxx " +
                    "where a.tp_produto = xxx.tp_produto " +
                    "and xxx.login = '" + (bsUsuario.Current as TRegistro_CadUsuario).Login.Trim() + "')", "exists");
                (bsUsuario.Current as TRegistro_CadUsuario).lTpProduto = new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto().Select(tps, 0, string.Empty);

                bsUsuario.ResetCurrentItem();
            }
        }

        private void BB_Novo_Click(object sender, EventArgs e)
        {   
            this.afterNovo();
        }

        private void BB_Alterar_Click(object sender, EventArgs e)
        {
            this.afterAltera();
        }

        private void BB_Excluir_Click(object sender, EventArgs e)
        {
            this.afterExclui();
        }

        private void bbInserirAcesso_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
            {
                using (TFAcessoMenu fAcesso = new TFAcessoMenu())
                {
                    fAcesso.Login = (bsUsuario.Current as TRegistro_CadUsuario).Login;
                    fAcesso.ShowDialog();
                    this.LimparFiltros();
                    login.Text = (bsUsuario.Current as TRegistro_CadUsuario).Login;
                    this.afterBusca();
                }
            }
            else
                MessageBox.Show("Obrigatorio selecionar usuario para gravar acesso menu.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void TFCad_Usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F2))
                this.afterNovo();
            else if (e.KeyCode.Equals(Keys.F3))
                this.afterAltera();
            else if (e.KeyCode.Equals(Keys.F5))
                this.afterExclui();
            else if (e.KeyCode.Equals(Keys.F7))
                this.afterBusca();
            else if (e.KeyCode.Equals(Keys.F9))
                this.CopiarPerfil();
            else if (e.KeyCode.Equals(Keys.F10))
                this.UserSql();
        }

        private void bb_copiarPerfil_Click(object sender, EventArgs e)
        {
            this.CopiarPerfil();
        }

        private void bb_userSql_Click(object sender, EventArgs e)
        {
            this.UserSql();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
            {
                using (TFListGrupoMenu fGrupo = new TFListGrupoMenu())
                {
                    fGrupo.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fGrupo.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                            bsUsuario.ResetCurrentItem();
                        }
                }
            }
        }

        private void bbExcluirGrupo_Click(object sender, EventArgs e)
        {
            if (bsGrupo.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão do grupo selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lGrupoDel.Add(
                        bsGrupo.Current as CamadaDados.Diversos.TRegistro_CadUsuario_Grupo);
                    bsGrupo.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
            }
        }

        private void bbInserirEmpresa_Click(object sender, EventArgs e)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();
                        }
                }
            }
        }

        private void bbExcluirEmpresa_Click(object sender, EventArgs e)
        {
            if (bsEmpresa.Current != null)
            {
                if (MessageBox.Show("Confirma exclusão da empresa selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEmpresaDel.Add(
                        bsEmpresa.Current as CamadaDados.Diversos.TRegistro_CadUsuario_Empresa);
                    bsEmpresa.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
            }
        }

        private void bbInserirTerminal_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
            {
                using (TFListTerminal fTerminal = new TFListTerminal())
                {
                    fTerminal.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fTerminal.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();
                        }
                }
            }
        }

        private void bbExcluirTerminal_Click(object sender, EventArgs e)
        {
            if (bsTerminal.Current != null)
                if (MessageBox.Show("Confirma exclusão do terminal selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTerminalDel.Add(
                        bsTerminal.Current as CamadaDados.Diversos.TRegistro_CadUsuarioxTerminal);
                    bsTerminal.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bbInserirPesagem_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
                using (TFListTpPesagem fPesagem = new TFListTpPesagem())
                {
                    fPesagem.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fPesagem.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void bbExcluirPesagem_Click(object sender, EventArgs e)
        {
            if (bsPesagem.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPesagemDel.Add(
                        bsPesagem.Current as CamadaDados.Diversos.TRegistro_CadUsuario_TipoPesagem);
                    bsPesagem.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bbInserirTpPedido_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
                using (TFListCfgPedido fCfgPed = new TFListCfgPedido())
                {
                    fCfgPed.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fCfgPed.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void bbExcluirTpPedido_Click(object sender, EventArgs e)
        {
            if (bsPedido.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lPedidoDel.Add(
                        bsPedido.Current as CamadaDados.Diversos.TRegistro_CadUsuario_CFGPedido);
                    bsPedido.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bb_inserirtprequisicao_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
                using (TFListTpRequisicao fReq = new TFListTpRequisicao())
                {
                    fReq.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fReq.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void bb_excluirtprequisicao_Click(object sender, EventArgs e)
        {
            if (bsTpRequisicao.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpRequisicaoDel.Add(
                        bsTpRequisicao.Current as CamadaDados.Diversos.TRegistro_Usuario_TpRequisicao);
                    bsTpRequisicao.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bb_inserirtpduplicata_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
                using (TFListTpDuplicata fDup = new TFListTpDuplicata())
                {
                    fDup.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fDup.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();
                        }
                }
        }

        private void bb_excluirtpduplicata_Click(object sender, EventArgs e)
        {
            if (bsTpDuplicata.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lTpDupDel.Add(
                        bsTpDuplicata.Current as CamadaDados.Diversos.TRegistro_Usuario_TpDuplicata);
                    bsTpDuplicata.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bbInserirContaGer_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current != null)
                using (TFListContaGer fConta = new TFListContaGer())
                {
                    fConta.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                    if (fConta.ShowDialog() == DialogResult.OK)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                            bsUsuario.ResetCurrentItem();
                                

                        }
                }
        }

        private void bbExcluirContaGer_Click(object sender, EventArgs e)
        {
            if (bsContaGer.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lContaGerDel.Add(
                        bsContaGer.Current as CamadaDados.Diversos.TRegistro_Usuario_ContaGer);
                    bsContaGer.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bbEtapapedido_Click(object sender, EventArgs e)
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
                            TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                           
                            bsUsuario.ResetCurrentItem();

                        }
                }
        }

        private void bbexcuiretapa_Click(object sender, EventArgs e)
        {

            if (bsEtapaPed.Current != null)
                if (MessageBox.Show("Confirma exclusão do registro selecionado?", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lEtapaPedDel.Add(
                        bsEtapaPed.Current as CamadaDados.Faturamento.Cadastros.TRegistro_CadEtapa);
                    bsEtapaPed.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void bbExcluirRegra_Click(object sender, EventArgs e)
        {
            if (bsRegra.Current != null)
                if (MessageBox.Show("Confirma exclusão da regra selecionada?", "Pergunta", MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).lRegraDel.Add(
                        bsRegra.Current as CamadaDados.Diversos.TRegistro_Usuario_RegraEspecial);
                    bsRegra.RemoveCurrent();
                    TCN_CadUsuario.Gravar(bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario, null);
                }
        }

        private void toolStripButton26_Click(object sender, EventArgs e)
        {
            if (bsUsuario.Current == null)
                return;

            using (TFListTpProduto listTpProduto = new TFListTpProduto())
            {
                listTpProduto.Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login;
                if (listTpProduto.ShowDialog() == DialogResult.OK)
                {
                    if (listTpProduto.lTpProduto.Count > 0)
                    {
                        listTpProduto.lTpProduto.ForEach(r => 
                        {
                            new CamadaDados.Diversos.TCD_CadUsuario_TpProduto()
                                .Gravar(
                                    new TRegistro_CadUsuario_TpProduto()
                                    {
                                        Login = (bsUsuario.Current as CamadaDados.Diversos.TRegistro_CadUsuario).Login,
                                        Tp_Produto = r.TP_Produto
                                    });
                        });

                        Utils.TpBusca[] tps = new Utils.TpBusca[0];
                        Utils.Estruturas.CriarParametro(ref tps, "",
                            "(select 1 from tb_div_usuario_x_tpproduto xxx " +
                            "where a.tp_produto = xxx.tp_produto " +
                            "and xxx.login = '" + (bsUsuario.Current as TRegistro_CadUsuario).Login.Trim() + "')", "exists");
                        (bsUsuario.Current as TRegistro_CadUsuario).lTpProduto = new CamadaDados.Estoque.Cadastros.TCD_CadTpProduto().Select(tps, 0, string.Empty);
                        bsUsuario.ResetCurrentItem();
                    }
                }
            }
        }

        private void toolStripButton25_Click(object sender, EventArgs e)
        {
            if (bsTipoProduto.Current == null)
                return;

            new CamadaDados.Diversos.TCD_CadUsuario_TpProduto()
                .Deletar(
                    new TRegistro_CadUsuario_TpProduto()
                    {
                        Login = (bsUsuario.Current as TRegistro_CadUsuario).Login,
                        Tp_Produto = (bsTipoProduto.Current as CamadaDados.Estoque.Cadastros.TRegistro_CadTpProduto).TP_Produto
                    });
            bsTipoProduto.RemoveCurrent();
        }
    }
}
