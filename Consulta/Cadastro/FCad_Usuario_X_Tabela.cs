using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Utils;
using Querys;
using FormBusca;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using System.Collections;

namespace Consulta.Cadastro
{
    public partial class TFCad_Usuario_X_Tabela : FormCadPadrao.FFormCadPadrao
    {
        #region "CONSTANTES"
            public const int Posicao_Usuario_X_Tabela = 0;
            public const int Posicao_Consulta = 1;
            public bool cancela = false;
            public  TList_Cad_Usuario_X_Tabela listaUsuarioXTabela_GRAVAR;
            public  TList_Cad_Usuario_X_Tabela listaUsuarioXTabela_DELETAR;
        #endregion "CONSTANTES"

        #region "FUNCOES_FORMULARIO"

            public TFCad_Usuario_X_Tabela()
            {
                InitializeComponent();
                Array.Resize(ref this.vPanel, 2);


                this.vPanel.SetValue(pDados, 0);
                this.vPanel.SetValue(pConsulta, 1);


                listaUsuarioXTabela_GRAVAR = new TList_Cad_Usuario_X_Tabela();
                listaUsuarioXTabela_DELETAR = new TList_Cad_Usuario_X_Tabela();


                //checkedListBox.CheckOnClick = true;
                DTS = BS_UsuarioXTabela;
            }

            public override void habilitarControls(bool value)
            {
                pDados.HabilitarControls(value, this.vTP_Modo);
                if ((vTP_Modo.Equals(TTpModo.tm_Standby)) || ((vTP_Modo.Equals(TTpModo.tm_busca))))
                {
                    cb_Marcar.Enabled = false;
                    checkedListBox.Enabled = false;
                }
                else if ((vTP_Modo.Equals(TTpModo.tm_Insert)) || ((vTP_Modo.Equals(TTpModo.tm_Edit))))
                {
                    cb_Marcar.Enabled = true;
                    checkedListBox.Enabled = true;
                }

            }

            public override void formatZero()
            {
                pDados.set_FormatZero();
            }

        #endregion "FUNCOES_FORMULARIO"

        #region "EVENTOS_AFTER"

            public override void afterNovo()
            {
                if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
                {
                    tcCentral.SelectedIndex = Posicao_Usuario_X_Tabela;
                    BS_UsuarioXTabela.AddNew();
                    base.afterNovo();
                    this.aterar_Modo_Botoes(vTP_Modo);                


                    habilitarControls(true);                
                    Popula_CheckedList();
                    desmarcar_opcoes();
                    cd_clifor.Focus();
                }
            }

            public override void afterBusca() {
                
                if ((login.Text == "") && (cd_clifor.Text == ""))
                {
                    cd_clifor.Focus();
                    string mensagem = "Atenção é necessário selecionar  um Clifor e um login!";
                    MessageBox.Show(mensagem);
                    vTP_Modo = TTpModo.tm_Standby;
                    afterNovo();
                }



                else
                {
                    tcCentral.SelectedIndex = Posicao_Consulta;
                    base.afterBusca();
                    this.aterar_Modo_Botoes(vTP_Modo);
                }
            }

            public override void afterGrava()
            {
                base.afterGrava();
                habilitarControls(false);  
                this.aterar_Modo_Botoes(vTP_Modo);
            }

            public override void afterCancela()
            {
                tcCentral.SelectedIndex = Posicao_Usuario_X_Tabela;
                base.afterCancela();
                if (vTP_Modo == TTpModo.tm_Insert)
                {
                    if (BS_UsuarioXTabela.Count > 0)
                        BS_UsuarioXTabela.RemoveCurrent();
                }
                desmarcar_opcoes();
                habilitarControls(false);  
                this.aterar_Modo_Botoes(vTP_Modo);
            }

            public override void afterAltera()
            {

                base.afterAltera();
                habilitarControls(true);  
                if (vTP_Modo == TTpModo.tm_Edit)
                    checkedListBox.Focus();

                this.aterar_Modo_Botoes(vTP_Modo);
            }

        #endregion  "EVENTOS_AFTER"
        
        #region "FUNCOES_PERSISTENCIA"

            public override void excluirRegistro()
            {

            }

            public override string gravarRegistro()
            {

                if (pDados.validarCampoObrigatorio())
                {
                    string resultado1 = TCN_Cad_Usuario_X_Tabela.DeletaUsuario_X_Tabela(listaUsuarioXTabela_DELETAR, cd_clifor.Text, login.Text);
                    string resultado2 = TCN_Cad_Usuario_X_Tabela.GravaUsuario_X_Tabela(listaUsuarioXTabela_GRAVAR, cd_clifor.Text, login.Text);

                    string resultado = "  ";

                    if ((resultado2!=null)&&(resultado2.Length!=0))
                    {
                        resultado = resultado2;
                    }
                    else if ((resultado1 != null) && (resultado1.Length != 0))
                    {
                        resultado = resultado1;
                    }

                    return resultado;

                }
                else
                {
                    return "";
                }

               
            }

            public override int buscarRegistros()
            {
                listaUsuarioXTabela_GRAVAR.Clear();
                listaUsuarioXTabela_DELETAR.Clear();
                    

                TList_Cad_Usuario_X_Tabela lista =null;

                if ((login.Text != "") && (cd_clifor.Text != "")) 
                    lista = TCN_Cad_Usuario_X_Tabela.Busca(login.Text, Filtro.Text, "");

                if (lista != null)
                {
                    if (   lista.Count    > 0   )
                    {
                        this.Lista = lista;
                        BS_UsuarioXTabela.DataSource = Lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                            BS_UsuarioXTabela.Clear();
                   
                    return lista.Count;
                }
                else return 0;
            }

        #endregion "FUNCOES_PERSISTENCIA"

        #region "FUNCOES_CHAVE_ESTRANGEIRA"

            private void bb_Clifor_Click(object sender, EventArgs e)
            {
                    UtilPesquisa.BTN_BUSCA("a.cd_clifor|Código Clifor|80;"+
                                       "c.nm_clifor|Nome Clifor|350;"+
                                       "a.login|Login|100;"+
                                       "b.nome_usuario|Nome Usuário|350",
                                       new Componentes.EditDefault[] { cd_clifor, ds_clifor}, 
                                       new TCD_Cad_UsuarioConsulta(), "");

            }

            private void cd_clifor_Leave(object sender, EventArgs e)
            {


                UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + cd_clifor.Text + "'",
                                        new Componentes.EditDefault[] { cd_clifor, ds_clifor },
                                        new TCD_Cad_UsuarioConsulta());


            }

            private void bb_login_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.cd_clifor|Código Clifor|80;" +
                                       "c.nm_clifor|Nome Clifor|350;" +
                                       "a.login|Login|100;" +
                                       "b.nome_usuario|Nome Usuário|350",
                                       new Componentes.EditDefault[] {  login, ds_login },
                                       new TCD_Cad_UsuarioConsulta(), "a.cd_clifor|=|'" + cd_clifor.Text + "'");


                if(login.Text!="")
                    Marca_CheckedList();
            }

            private void login_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("A.login|=|'" + login.Text + "';"+
                                        "a.CD_Clifor|=|'"+cd_clifor.Text.Trim()+"'",
                                        new Componentes.EditDefault[] { login, ds_login },
                                        new TCD_Cad_UsuarioConsulta());

            }

        #endregion "FUNCOES_CHAVE_ESTRANGEIRA"

        #region "EVENTOS_COMPONENTES"

            private void cb_Marcar_CheckedChanged(object sender, EventArgs e)
            {
                listaUsuarioXTabela_GRAVAR.Clear();
                listaUsuarioXTabela_DELETAR.Clear();


                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    TRegistro_Cad_Usuario_X_Tabela registro = new TRegistro_Cad_Usuario_X_Tabela();
                    registro.Login = login.Text;
                    registro.NM_Tabela = checkedListBox.Items[i].ToString().Trim();



                    checkedListBox.SetItemChecked(i, cb_Marcar.Checked);
                    if (cb_Marcar.Checked)
                        listaUsuarioXTabela_GRAVAR.Add(registro);
                    else
                        listaUsuarioXTabela_DELETAR.Add(registro);
                }
            }

            private void checkedListBox_SelectedValueChanged(object sender, EventArgs e)
            {
                int i = checkedListBox.SelectedIndex;

                TRegistro_Cad_Usuario_X_Tabela registro = new TRegistro_Cad_Usuario_X_Tabela();
                registro.NM_Tabela = checkedListBox.Items[i].ToString().Trim();


                listaUsuarioXTabela_DELETAR = remover_registro_lista(listaUsuarioXTabela_DELETAR, registro);
                listaUsuarioXTabela_GRAVAR = remover_registro_lista(listaUsuarioXTabela_GRAVAR, registro);


                if (checkedListBox.GetItemChecked(i))
                {
                    listaUsuarioXTabela_GRAVAR.Add(registro);
                }
                else
                {
                    listaUsuarioXTabela_DELETAR.Add(registro);
                }
            }

            private void tpPadrao_Enter(object sender, EventArgs e)
            {
                this.aterar_Modo_Botoes(vTP_Modo);
                Marca_CheckedList();
            }

            private void tabConsulta_Enter(object sender, EventArgs e)
            {
                this.aterar_Modo_Botoes(vTP_Modo);
                afterBusca();
            }

        #endregion "EVENTOS_COMPONENTES"

        #region "FUNCOES_EXTRAS"

            public void Popula_CheckedList()
            {
                TList_Cad_Tabela listaTabela = TCN_Cad_Tabela.Busca();

                int i = 0;
                while (i < listaTabela.Count)
                {
                    checkedListBox.Items.Add(listaTabela[i].NM_Tabela.Trim());
                    i++;
                }
            }

            public void Marca_CheckedList()
            {
                if ((login.Text != "") && (cd_clifor.Text!=""))
                {
                    TList_Cad_Usuario_X_Tabela lista = TCN_Cad_Usuario_X_Tabela.Busca(login.Text, "", "");
                    int x = 0;

                    while (x < checkedListBox.Items.Count)
                    {
                        int y=0;

                        checkedListBox.SetItemChecked(x, false);

                        while (y < lista.Count){
                            TRegistro_Cad_Usuario_X_Tabela registro =lista[y];
                            if (registro.NM_Tabela.ToString().Trim().Equals(checkedListBox.Items[x].ToString().Trim()))
                            {
                                checkedListBox.SetItemChecked(x, true);
                                break;
                            }
                            y++;
                        }
                        x++;
                    }
                }
                listaUsuarioXTabela_GRAVAR.Clear();
                listaUsuarioXTabela_DELETAR.Clear();
                habilitarControls(false); 
            }

            public void aterar_Modo_Botoes(TTpModo x)
            {

                if (TTpModo.tm_Standby == x)
                {
                    if (tcCentral.SelectedIndex == Posicao_Usuario_X_Tabela)
                    {
                        this.modoBotoes(x, true, false, false, false, false, true, false);
                    }
                    else {
                        this.modoBotoes(x, true, false, false, false, false, true, false);
                    }
                }
                if (TTpModo.tm_Insert == x)
                {
                    if (tcCentral.SelectedIndex == Posicao_Usuario_X_Tabela)
                    {
                        this.modoBotoes(x, true, false, true, false, true, true, false);
                    }
                    else {
                        this.modoBotoes(x, true, false, false, false, true, true, false);
                    }
                }
                if (TTpModo.tm_busca == x)
                {
                    if (tcCentral.SelectedIndex == Posicao_Usuario_X_Tabela)
                    {
                        this.modoBotoes(x, true, true, false, false, false, true, false);
                    }
                    else {
                        this.modoBotoes(x, true, false, false, false, false, true, false);
                    }
                }
                if (TTpModo.tm_Edit == x)
                {
                    if (tcCentral.SelectedIndex == Posicao_Usuario_X_Tabela)
                    {
                        this.modoBotoes(x, false, false, true, false, true, false, false);
                    }
                    else {
                        this.modoBotoes(x, false, false, false, false, true, false, false);
                    }
                }
            }
        
            public void desmarcar_opcoes(){
                listaUsuarioXTabela_GRAVAR.Clear();
                listaUsuarioXTabela_DELETAR.Clear();


                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, false);
                }
            }

            public TList_Cad_Usuario_X_Tabela remover_registro_lista(TList_Cad_Usuario_X_Tabela listaUsuarioXTabela, TRegistro_Cad_Usuario_X_Tabela registro)
            {
                for (int x = 0; x < listaUsuarioXTabela.Count; x++)
                {
                    TRegistro_Cad_Usuario_X_Tabela registro_gravar = (listaUsuarioXTabela[x] as TRegistro_Cad_Usuario_X_Tabela);

                    if (
                        (registro_gravar.NM_Tabela == registro.NM_Tabela)
                        &&
                        (registro_gravar.Login == registro.Login)
                        )
                    {
                        listaUsuarioXTabela.RemoveAt(x);
                        break;
                    }
                }
                return listaUsuarioXTabela;
            }

        #endregion "FUNCOES_EXTRAS"
    }
}
