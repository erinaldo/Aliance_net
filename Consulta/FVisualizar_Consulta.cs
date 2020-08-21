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

namespace Consulta
{
    public partial class TFVisualizar_Consulta : FormPadrao.FFormPadrao
    {
        public TFVisualizar_Consulta()
        {
            InitializeComponent();
        }

        public override void formatZero()
        {
            pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override int buscarRegistros()
        {
            if (tcCentral.SelectedIndex == 0)
            {
                TList_Cad_Consulta lista = TCN_Cad_Consulta.Busca((ID_Consulta.Text.Trim() != "") ? Convert.ToDecimal(ID_Consulta.Text) : 0,
                                                                  login.Text.Trim(),
                                                                  DS_Consulta.Text.Trim());

                if (lista != null)
                {
                    if (lista.Count > 0)
                    {
                        this.Lista = lista;
                        BS_Consulta.DataSource = lista;
                    }
                    else
                        if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                            BS_Consulta.Clear();
                    return lista.Count;
                }
            }

            return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                this.habilitarControls(true);
                this.limparControls();
                tcCentral.SelectedIndex = 0;

                //habilita os campos
                ID_Consulta.Enabled = true;
                CD_Clifor.Enabled = true;
                login.Enabled = true;
                DS_Consulta.Enabled = true;
                BB_Login.Enabled = true;
                BB_Clifor.Enabled = true;

                if (!ID_Consulta.Focus())
                    ID_Consulta.Focus();
            }
        }

        public override void afterBusca()
        {
            this.habilitarControls(false);

            //habilita os campos
            ID_Consulta.Enabled = true;
            CD_Clifor.Enabled = true;
            login.Enabled = true;
            DS_Consulta.Enabled = true;
            BB_Login.Enabled = true;
            BB_Clifor.Enabled = true;

            buscarRegistros();
        }

        #region "ABA 1 - CONSULTA"

            private void BB_Clifor_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.cd_clifor|Código Clifor|80;" +
                                   "c.nm_clifor|Nome Clifor|350;" +
                                   "a.login|Login|100;" +
                                   "b.nome_usuario|Nome Usuário|350",
                                   new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                   new TCD_Cad_UsuarioConsulta(), "");
            }

            private void CD_Clifor_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("a.cd_clifor|=|'" + CD_Clifor.Text + "'",
                                    new Componentes.EditDefault[] { CD_Clifor, NM_Clifor },
                                    new TCD_Cad_UsuarioConsulta());
            }

            private void BB_Login_Click(object sender, EventArgs e)
            {
                UtilPesquisa.BTN_BUSCA("a.cd_clifor|Código Clifor|80;" +
                                   "c.nm_clifor|Nome Clifor|350;" +
                                   "a.login|Login|100;" +
                                   "b.nome_usuario|Nome Usuário|350",
                                   new Componentes.EditDefault[] { login, ds_login },
                                   new TCD_Cad_UsuarioConsulta(), "a.cd_clifor|=|'" + CD_Clifor.Text + "'");

            }

            private void login_Leave(object sender, EventArgs e)
            {
                UtilPesquisa.EDIT_LEAVE("A.login|=|'" + login.Text + "';" +
                                    "a.CD_Clifor|=|'" + CD_Clifor.Text.Trim() + "'",
                                    new Componentes.EditDefault[] { login, ds_login },
                                    new TCD_Cad_UsuarioConsulta());
            }

        #endregion

        #region "ABA 2 - SQL"

            private void tabSQLConsulta_Enter(object sender, EventArgs e)
            {
                if (BS_Consulta.Current != null)
                {
                    try
                    {
                        if ((BS_Consulta.Current as TRegistro_Cad_Consulta).DS_SQL == "")
                        {
                            DS_SQL.Text = TCN_Cad_Consulta.BuscaStringSQL(BS_Consulta.Current as TRegistro_Cad_Consulta, false);
                        }
                        else
                        {
                            DS_SQL.Text = (BS_Consulta.Current as TRegistro_Cad_Consulta).DS_SQL;
                        }
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show("ERRO: " + erro.Message);
                    }
                }
                else
                {
                    tcCentral.SelectedIndex = 0;
                    MessageBox.Show("Atenção, é necessário informar um consulta");
                    ID_Consulta.Focus();
                }
            }

        #endregion

        #region "ABA 3 - VISUALIZAR"

            private void tabVisualizar_Enter(object sender, EventArgs e)
            {
                try
                {
                    if (BS_Consulta.Current != null)
                    {
                        if (Grid_Visualizador.Columns.Count > 0)
                            Grid_Visualizador.Columns.Clear();

                        if (Grid_Visualizador.Rows.Count > 0)
                            Grid_Visualizador.Rows.Clear();

                        if ((BS_Consulta.Current as TRegistro_Cad_Consulta).DS_SQL == "")
                        {
                            DS_SQL.Text = TCN_Cad_Consulta.BuscaStringSQL(BS_Consulta.Current as TRegistro_Cad_Consulta, false);
                        }
                        else
                        {
                            DS_SQL.Text = (BS_Consulta.Current as TRegistro_Cad_Consulta).DS_SQL;
                        }

                        if (DS_SQL.Text != "")
                        {
                            DataTable dataTable = TCN_Cad_Consulta.BuscarSQL(DS_SQL.Text);

                            for (int i = 0; i < dataTable.Columns.Count; i++)
                            {
                                DataGridViewTextBoxColumn coluna = new DataGridViewTextBoxColumn();
                                coluna.Name = dataTable.Columns[i].ColumnName;
                                coluna.HeaderText = dataTable.Columns[i].ColumnName;
                                coluna.DataPropertyName = dataTable.Columns[i].ColumnName;
                                coluna.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                                Grid_Visualizador.Columns.Add(coluna);
                            }

                            BS_Visualizador.DataSource = dataTable;
                            BS_Visualizador.ResetBindings(true);
                        }
                    }
                    else
                    {
                        tcCentral.SelectedIndex = 0;
                        MessageBox.Show("Atenção, é necessário informar um consulta");
                        ID_Consulta.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("ERRO: " + erro.Message);
                }
            }

        #endregion

    }
}
