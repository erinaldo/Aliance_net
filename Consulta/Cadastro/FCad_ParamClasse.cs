using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CamadaDados.Consulta.Cadastro;
using CamadaNegocio.Consulta.Cadastro;
using Utils;
using FormBusca;
using System.Collections;
using CamadaDados.Diversos;
using Componentes;
using System.Reflection;

namespace Consulta.Cadastro
{
    public partial class TFCad_ParamClasse : FormCadPadrao.FFormCadPadrao
    {
        public TFCad_ParamClasse()
        {
            InitializeComponent();

            ArrayList cbx = new ArrayList();
            cbx.Add(new Utils.TDataCombo("", ""));
            cbx.Add(new Utils.TDataCombo("CamadaDados.dll", "CamadaDados.dll"));
            cbx.Add(new Utils.TDataCombo("Querys.dll", "Querys.dll"));
            cbNMDLL.DataSource = cbx;
            cbNMDLL.DisplayMember = "Display";
            cbNMDLL.ValueMember = "Value";

            cbNMDLL.SelectedIndex = 0;
            NM_Param.CharacterCasing = CharacterCasing.Normal;
            Valor.CharacterCasing = CharacterCasing.Normal;
            Descricao.CharacterCasing = CharacterCasing.Normal;
            CodigoCMP.CharacterCasing = CharacterCasing.Normal;
            NomeCMP.CharacterCasing = CharacterCasing.Normal;
        }

        public override void formatZero()
        {
            //pDados.set_FormatZero();
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                (BS_ParamClasse.Current as TRegistro_Cad_ParamClasse).St_NullBool = cb_Null.Checked;
                (BS_ParamClasse.Current as TRegistro_Cad_ParamClasse).St_ObrigatorioBool = cb_STObrigatorio.Checked;
                BS_ParamClasse.ResetBindings(true);
                string retorno = TCN_Cad_ParamClasse.GravarParamClasse(BS_ParamClasse.Current as TRegistro_Cad_ParamClasse, null);
                HabilitaCampos(false);
                return retorno;
            }
            else
                return "";
        }

        public override int buscarRegistros()
        {
            cb_TP_Dado.Enabled = false;
            TList_Cad_ParamClasse lista = TCN_Cad_ParamClasse.Buscar((ID_ParamClasse.Text.Trim() != "") ? Convert.ToDecimal(ID_ParamClasse.Text) : 0,
                                                                     NM_Param.Text.Trim(),
                                                                     NM_CampoFormat.Text.Trim(),
                                                                     "",
                                                                     0, null);

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_ParamClasse.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_ParamClasse.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_ParamClasse.ResetBindings(true);
                BS_ParamClasse.AddNew();
                base.afterNovo();
                ID_ParamClasse.Enabled = false;
                NM_Param.Focus();
                cb_TP_Dado.Enabled = true;
                cb_NMClasse.Enabled = true;
                cbNMDLL.Enabled = true;
                cb_STObrigatorio.Enabled = true;
                cb_Null.Enabled = true;
                cb_TP_Dado_SelectedIndexChanged(null, null);
                HabilitaCampos(false);
                cb_TP_Dado.SelectedIndex = 0;
                if (!NM_Param.Focus())
                    NM_Param.Focus();
            }
        }

        public void HabilitaCampos(bool Habilitar)
        {
            for (int i = 0; i < groupBoxBusca.Controls.Count; i++)
            {
                if (groupBoxBusca.Controls[i] is EditDefault)
                {
                    groupBoxBusca.Controls[i].Enabled = Habilitar;
                }
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            cb_TP_Dado.Enabled = false;
            cb_NMClasse.Enabled = false;
            cbNMDLL.Enabled = false;
            cb_STObrigatorio.Enabled = false;
            cb_Null.Enabled = false;
            if (vTP_Modo == TTpModo.tm_Insert)
                BS_ParamClasse.RemoveCurrent();
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
            {
                NM_CampoFormat.Enabled = false;
                ID_ParamClasse.Enabled = false;
                cb_TP_Dado.Enabled = true;
                cb_NMClasse.Enabled = true;
                cbNMDLL.Enabled = true;
                cb_STObrigatorio.Enabled = true;
                cb_Null.Enabled = true;
                if (cb_NMClasse.Text.Trim() == "")
                {
                    HabilitaCampos(false);
                }
                else
                {
                    HabilitaCampos(true);
                }

                cb_TP_Dado_SelectedIndexChanged(null, null);
                
                NM_Param.Focus();
            }
        }

        public override void excluirRegistro()
        {
            if (grid_ParamClasse.RowCount > 0)
            {
                if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_Cad_ParamClasse.DeletarParamClasse(BS_ParamClasse.Current as TRegistro_Cad_ParamClasse, null);
                        BS_ParamClasse.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void cbNMDLL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BS_ParamClasse.Current != null && cbNMDLL.SelectedValue != null)
            {
                ArrayList CBoxClasses = new ArrayList();
                
                if (cbNMDLL.SelectedValue.ToString() != "")
                {
                    string dll = cbNMDLL.SelectedValue.ToString();
                    Assembly extAssembly = Assembly.LoadFrom(Utils.Parametros.pubPathAliance.Trim() +
                                                             System.IO.Path.DirectorySeparatorChar.ToString() +
                                                             cbNMDLL.SelectedValue.ToString());

                    var tipoArray = from c in extAssembly.GetTypes()
                                    where (c.Name.Contains("TCD") || c.Name.Contains("TDat"))
                                    orderby c.Name ascending
                                    select c;

                    foreach (Type tp in tipoArray)
                    {
                        CBoxClasses.Add(new Utils.TDataCombo(tp.Name.ToString().Trim(), tp.FullName.ToString().Trim()));
                    }

                    HabilitaCampos(true);
                    cb_NMClasse.DataSource = CBoxClasses;
                    if (CBoxClasses.Count > 0)
                    {
                        cb_NMClasse.DisplayMember = "Display";
                        cb_NMClasse.ValueMember = "Value";
                        cb_NMClasse.SelectedIndex = 0;
                    }

                    cbNMDLL.SelectedValue = dll;
                }
                else
                {
                    cb_NMClasse.DataSource = CBoxClasses;
                    HabilitaCampos(false);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (Valor.Text.Trim() == "")
            {
                MessageBox.Show("Atenção é necessário informar o valor");
                Valor.Focus();
            }
            else if (Descricao.Text.Trim() == "")
            {
                MessageBox.Show("Atenção é necessário informar a descrição");
                Descricao.Focus();
            }
            else
            {
                if (RadioCheckGroup.Text == "" && cb_TP_Dado.Text == "CHECKBOX")
                {
                    RadioCheckGroup.AppendText(Valor.Text + ":" + Descricao.Text + ";");
                }
                else if (cb_TP_Dado.Text == "RADIO")
                {
                    RadioCheckGroup.AppendText(Valor.Text + ":" + Descricao.Text + ";");
                }

                Valor.Focus();
            }
        }

        private void cb_TP_Dado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((vTP_Modo == TTpModo.tm_Edit) || (vTP_Modo == TTpModo.tm_Insert))
            {
                if (cb_TP_Dado.Text == "RADIO")
                {
                    Valor.Enabled = true;
                    Descricao.Enabled = true;
                    RadioCheckGroup.Enabled = true;
                    Add.Enabled = true;
                    bb_Limpar.Enabled = true;
                    RadioCheckGroup.ReadOnly = true;
                    RadioCheckGroup.Size = new Size(400, 40);
                    Valor.Focus();
                }
                else if (cb_TP_Dado.Text == "CHECKBOX")
                {
                    Valor.Enabled = false;
                    Descricao.Enabled = false;
                    RadioCheckGroup.Enabled = true;
                    RadioCheckGroup.ReadOnly = false;
                    Add.Enabled = false;
                    bb_Limpar.Enabled = false;
                    RadioCheckGroup.Size = new Size(200, 20);
                    RadioCheckGroup.Focus();
                }
                else
                {
                    Valor.Enabled = false;
                    Valor.Text = "";
                    Descricao.Enabled = false;
                    Descricao.Text = "";
                    RadioCheckGroup.Enabled = false;
                    RadioCheckGroup.ReadOnly = true;
                    RadioCheckGroup.Size = new Size(400, 40);
                    RadioCheckGroup.Text = "";
                    Add.Enabled = false;
                    bb_Limpar.Enabled = false;
                    groupBoxBusca.Focus();
                }

                //(BS_ParamClasse.Current as TRegistro_Cad_ParamClasse).TP_Dado = cb_TP_Dado.Text;
                //BS_ParamClasse.ResetBindings(true);
            }
        }

        private void bb_Limpar_Click(object sender, EventArgs e)
        {
            RadioCheckGroup.Text = "";
        }

        private void labelNMParam_Click(object sender, EventArgs e)
        {

        }

        private void TFCad_ParamClasse_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, grid_ParamClasse);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCad_ParamClasse_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, grid_ParamClasse);
        }
    }
}

