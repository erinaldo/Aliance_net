using System;
using System.Globalization;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using Utils;
using CamadaDados;

namespace Componentes
{
    public partial class PanelDados : Panel
    {
        private string vNM_ProcGravar;
        private string vNM_ProcDeletar;

        public string NM_ProcGravar { get { if (vNM_ProcGravar == null)return "";else return vNM_ProcGravar; } set { vNM_ProcGravar = value.ToUpper(); } }
        public string NM_ProcDeletar { get { if (vNM_ProcDeletar == null)return "";else return vNM_ProcDeletar; } set { vNM_ProcDeletar = value.ToUpper(); } }


        public PanelDados()
        {
            InitializeComponent();
        }

        public PanelDados(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private string MontarSqlFormatZero(Control value, string vir)
        {
            //string str = "(";
            string str = "";
            //string vir = "";
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox) ||
                    (value.Controls[i] is TableLayoutPanel))
                {
                    str += MontarSqlFormatZero(value.Controls[i], vir);
                    if (str != "")
                        vir = ",";
                }
                if (value.Controls[i] is EditDefault)
                {
                    str += vir + "'" + (value.Controls[i] as EditDefault).NM_CampoBusca + "'";
                    vir = ",";
                }
            }
            return str;
        }

        private void LimparCampos(Control value)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    //se o controle for um container chamar o metodo LimparCampos recursivamente
                    LimparCampos(value.Controls[i]);
                if(value.Controls[i] is EditDefault)
                {
                    if((value.Controls[i] as EditDefault).ST_LimpaCampo)
                        (value.Controls[i] as EditDefault).Clear();
                }
                else if (value.Controls[i] is EditMask)
                {
                    if ((value.Controls[i] as EditMask).ST_LimpaCampo)
                        (value.Controls[i] as EditMask).Clear();
                }
                else if (value.Controls[i] is EditFloat)
                {
                    if ((value.Controls[i] as EditFloat).ST_LimparCampo)
                        if ((value.Controls[i] as EditFloat).Minimum > 0)
                            (value.Controls[i] as EditFloat).Value = (value.Controls[i] as EditFloat).Minimum;
                        else
                            (value.Controls[i] as EditFloat).Value = 0;
                }
                else if (value.Controls[i] is CheckBoxDefault)
                {
                    if ((value.Controls[i] as CheckBoxDefault).ST_LimparCampo)
                        (value.Controls[i] as CheckBoxDefault).Checked = false;
                }
                else if (value.Controls[i] is RadioButtonDefault)
                    (value.Controls[i] as RadioButtonDefault).Checked = false;
            }
        }

        private void validarCampoObrigatorio(Control value)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if (((value.Controls[i] is PanelDados)) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    validarCampoObrigatorio(value.Controls[i]);
                if (value.Controls[i] is EditDefault)
                {
                    if ((value.Controls[i] as EditDefault).ST_Gravar &&
                        (value.Controls[i] as EditDefault).Visible)
                        if (((value.Controls[i] as EditDefault).ST_NotNull) && (string.IsNullOrEmpty((value.Controls[i] as EditDefault).Text)||
                            (((value.Controls[i] as EditDefault).ST_Int || (value.Controls[i] as EditDefault).ST_Float) && 
                            (value.Controls[i] as EditDefault).Text.Trim().Equals("0"))) &&
                            (!(value.Controls[i] as EditDefault).ST_AutoInc) && ((value.Controls[i] as EditDefault).Visible)&&
                            ((value.Controls[i] as EditDefault).Enabled))
                        {
                            (value.Controls[i] as EditDefault).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as EditDefault).NM_Campo + " Obrigatório!");
                        }
                }
                else if ((value.Controls[i] is EditMask))
                {
                    if ((value.Controls[i] as EditMask).ST_Gravar &&
                        (value.Controls[i] as EditMask).Visible)
                    {
                        if (value.Controls[i] is EditData)
                        {
                            if ((value.Controls[i] as EditData).ST_NotNull && (value.Controls[i] as EditData).Enabled)
                                try
                                {
                                    DateTime aux = Convert.ToDateTime((value.Controls[i] as EditData).Text);
                                    if(aux == new DateTime())
                                        throw new Exception("Campo " + (value.Controls[i] as EditData).NM_Campo + " Obrigatório!");
                                }
                                catch { throw new Exception("Campo " + (value.Controls[i] as EditData).NM_Campo + " Obrigatório!"); }
                        }
                        else
                        {
                            MaskFormat msk = (value.Controls[i] as EditMask).TextMaskFormat;
                            (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                            if (((value.Controls[i] as EditMask).ST_NotNull) && ((value.Controls[i] as EditMask).Text.Trim().Equals("")) &&
                                ((value.Controls[i] as EditMask).Visible)&&((value.Controls[i] as EditMask).Enabled))
                            {
                                (value.Controls[i] as EditMask).TextMaskFormat = msk;
                                (value.Controls[i] as EditMask).Focus();
                                throw new Exception("Campo " + (value.Controls[i] as EditMask).NM_Campo + " Obrigatório!");
                            }
                            (value.Controls[i] as EditMask).TextMaskFormat = msk;
                        }
                    }
                }
                else if (value.Controls[i] is RadioGroup)
                {
                    if ((value.Controls[i] as RadioGroup).ST_Gravar &&
                        (value.Controls[i] as RadioGroup).Visible)
                        if (((value.Controls[i] as RadioGroup).ST_NotNull) &&
                            ((value.Controls[i] as RadioGroup).NM_Valor == ""))
                        {
                            (value.Controls[i] as RadioGroup).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as RadioGroup).NM_Campo + " Obrigatório!");
                        }
                }
                else if (value.Controls[i] is ComboBoxDefault)
                {
                    if ((value.Controls[i] as ComboBoxDefault).ST_Gravar &&
                        (value.Controls[i] as ComboBoxDefault).Visible)
                        if (((value.Controls[i] as ComboBoxDefault).ST_NotNull) &&
                            ((value.Controls[i] as ComboBoxDefault).Text == ""))
                        {
                            (value.Controls[i] as ComboBoxDefault).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as ComboBoxDefault).NM_Campo + " Obrigatório!");
                        }
                }
                else if (value.Controls[i] is CheckBoxDefault)
                {
                    if ((value.Controls[i] as CheckBoxDefault).ST_Gravar &&
                        (value.Controls[i] as CheckBoxDefault).Visible)
                        if (((value.Controls[i] as CheckBoxDefault).ST_NotNull) &&
                            (!((value.Controls[i] as CheckBoxDefault).Checked)))
                        {
                            (value.Controls[i] as CheckBoxDefault).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as CheckBoxDefault).NM_Campo + " Obrigatório!");
                        }
                }
                else if (value.Controls[i] is EditFloat)
                {
                    if((value.Controls[i] as EditFloat).ST_Gravar &&
                        (value.Controls[i] as EditFloat).Visible)
                        if (((value.Controls[i] as EditFloat).ST_NotNull) && ((value.Controls[i] as EditFloat).Value <= 0) &&
                            (!(value.Controls[i] as EditFloat).ST_AutoInc) && ((value.Controls[i] as EditFloat).Visible)&&
                            ((value.Controls[i] as EditFloat).Enabled))
                        {
                            (value.Controls[i] as EditFloat).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as EditFloat).NM_Campo + " Obrigatório!");
                        }
                }
            }
        }

        private void MontarParametrosGravar(Control value, Hashtable hs)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if (((value.Controls[i] is PanelDados)) || //&& ((value.Controls[i] as PanelDados).NM_ProcGravar == "")
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    MontarParametrosGravar(value.Controls[i], hs);

                if (value.Controls[i] is EditDefault)
                {
                    if((value.Controls[i] as EditDefault).ST_Gravar)
                        if(((value.Controls[i] as EditDefault).ST_NotNull)&&((value.Controls[i] as EditDefault).Text == "")&&
                            (!(value.Controls[i] as EditDefault).ST_AutoInc)&&((value.Controls[i] as EditDefault).Visible))
                        {
                            (value.Controls[i] as EditDefault).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as EditDefault).NM_Campo + " Obrigatório!");
                        }
                        else if((value.Controls[i] as EditDefault).Text != "")
                            hs.Add((value.Controls[i] as EditDefault).NM_Param.Trim().ToUpper(),
                                    (value.Controls[i] as EditDefault).Text);
                }
                else if (value.Controls[i] is EditMask)
                {
                    if ((value.Controls[i] as EditMask).ST_Gravar)
                    {
                        (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        if (((value.Controls[i] as EditMask).ST_NotNull) && ((value.Controls[i] as EditMask).Text.Trim().Equals("")) &&
                            ((value.Controls[i] as EditMask).Visible))
                        {
                            (value.Controls[i] as EditMask).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as EditMask).NM_Campo + " Obrigatório!");
                        }
                        else // if ((value.Controls[i] as EditMask).Text.Trim() != "")
                        {
                            (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.IncludeLiterals;
                            hs.Add((value.Controls[i] as EditMask).NM_Param.Trim().ToUpper(),
                                    (value.Controls[i] as EditMask).Text.Trim());
                        }
                        (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.IncludeLiterals;
                    }
                }
                else if (value.Controls[i] is RadioGroup)
                {
                    if ((value.Controls[i] as RadioGroup).ST_Gravar)
                        if (((value.Controls[i] as RadioGroup).ST_NotNull) &&
                            ((value.Controls[i] as RadioGroup).NM_Valor == ""))
                        {
                            (value.Controls[i] as RadioGroup).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as RadioGroup).NM_Campo + " Obrigatório!");
                        }
                        else if ((value.Controls[i] as RadioGroup).NM_Valor != "")
                            hs.Add((value.Controls[i] as RadioGroup).NM_Param.Trim().ToUpper(),
                                    (value.Controls[i] as RadioGroup).NM_Valor);
                }
                else if (value.Controls[i] is ComboBoxDefault)
                {
                    if ((value.Controls[i] as ComboBoxDefault).ST_Gravar)
                        if (((value.Controls[i] as ComboBoxDefault).ST_NotNull) &&
                            ((value.Controls[i] as ComboBoxDefault).Text == ""))
                        {
                            (value.Controls[i] as ComboBoxDefault).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as ComboBoxDefault).NM_Campo + " Obrigatório!");
                        }
                        else if ((value.Controls[i] as ComboBoxDefault).Text != "")
                            hs.Add((value.Controls[i] as ComboBoxDefault).NM_Param.Trim().ToUpper(),
                                    (value.Controls[i] as ComboBoxDefault).Text);
                }
                else if (value.Controls[i] is CheckBoxDefault)
                {
                    if ((value.Controls[i] as CheckBoxDefault).ST_Gravar)
                        if (((value.Controls[i] as CheckBoxDefault).ST_NotNull) &&
                            (!((value.Controls[i] as CheckBoxDefault).Checked)))
                        {
                            (value.Controls[i] as CheckBoxDefault).Focus();
                            throw new Exception("Campo " + (value.Controls[i] as CheckBoxDefault).NM_Campo + " Obrigatório!");
                        }
                        else if ((value.Controls[i] as CheckBoxDefault).Checked)
                            hs.Add((value.Controls[i] as CheckBoxDefault).NM_Param.Trim().ToUpper(),
                                    (value.Controls[i] as CheckBoxDefault).Vl_True);
                        else
                            hs.Add((value.Controls[i] as CheckBoxDefault).NM_Param.Trim().ToUpper(),
                                    (value.Controls[i] as CheckBoxDefault).Vl_False);
                }
                else if (value.Controls[i] is EditFloat)
                {
                    if ((value.Controls[i] as EditFloat).ST_Gravar)
                        hs.Add((value.Controls[i] as EditFloat).NM_Param.Trim().ToUpper(),
                                (value.Controls[i] as EditFloat).Value.ToString(new CultureInfo("en-US", true)));
                }
            }
        }

        private void MontarParametrosDel(Control value, Hashtable hs)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    MontarParametrosDel(value.Controls[i], hs);

                if (value.Controls[i] is EditDefault)
                {
                    if ((value.Controls[i] as EditDefault).ST_PrimaryKey)
                        if ((value.Controls[i] as EditDefault).Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Campo " + (value.Controls[i] as EditDefault).NM_Campo + " Obrigatório!",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (value.Controls[i] as EditDefault).Focus();
                            throw new Exception("Campo Obrigatório!");
                        }
                        else
                            hs.Add((value.Controls[i] as EditDefault).NM_Param, (value.Controls[i] as EditDefault).Text);
                }
                else if (value.Controls[i] is EditFloat)
                {
                    if ((value.Controls[i] as EditFloat).ST_PrimaryKey)
                        if ((value.Controls[i] as EditFloat).Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Campo " + (value.Controls[i] as EditFloat).NM_Campo + " Obrigatório!",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (value.Controls[i] as EditFloat).Focus();
                            throw new Exception("Campo Obrigatório!");
                        }
                        else
                            hs.Add((value.Controls[i] as EditFloat).NM_Param, (value.Controls[i] as EditFloat).Text);
                }
                else if (value.Controls[i] is EditMask)
                {
                    if ((value.Controls[i] as EditMask).ST_PrimaryKey)
                    {
                        (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        if ((value.Controls[i] as EditMask).Text.Trim().Equals(""))
                        {
                            MessageBox.Show("Campo " + (value.Controls[i] as EditMask).NM_Campo + " Obrigatório!",
                                            "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (value.Controls[i] as EditMask).Focus();
                            throw new Exception("Campo Obrigatório!");
                        }
                        else
                        {
                            (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.IncludeLiterals;
                            hs.Add((value.Controls[i] as EditMask).NM_Param, (value.Controls[i] as EditMask).Text);
                        }
                        (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.IncludeLiterals;
                    }
                }
            }
        }

        private void ScrollRegistro(Control value, DataRow vDataTable)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    ScrollRegistro(value.Controls[i], vDataTable);

                if (value.Controls[i] is EditMask)
                {
                    if ((value.Controls[i] as EditMask).NM_Campo.Trim() != "")
                    {
                        if (value.Controls[i] is EditData)
                        {
                            try
                            {
                                DateTime dt = Convert.ToDateTime(vDataTable[(value.Controls[i] as EditMask).NM_Campo].ToString());
                                (value.Controls[i] as EditData).Text = dt.ToString("dd/MM/yyyy").Trim();
                            }
                            catch
                            {
                                (value.Controls[i] as EditMask).Text = "";
                            }
                        }
                        else if (value.Controls[i] is EditHora)
                        {
                            try
                            {
                                DateTime dt = Convert.ToDateTime(vDataTable[(value.Controls[i] as EditMask).NM_Campo].ToString());
                                (value.Controls[i] as EditMask).Text = dt.ToString("HH/mm/ss").Trim();
                            }
                            catch
                            {
                                (value.Controls[i] as EditMask).Text = "";
                            }
                        }
                        else
                            (value.Controls[i] as EditMask).Text = vDataTable[(value.Controls[i] as EditMask).NM_Campo].ToString().Trim();
                    }
                    else
                        if ((value.Controls[i] as EditMask).ST_LimpaCampo)
                            (value.Controls[i] as EditMask).Clear();
                }
                else if (value.Controls[i] is EditDefault)
                {
                    if ((value.Controls[i] as EditDefault).NM_Campo.Trim() != "")
                        (value.Controls[i] as EditDefault).Text = vDataTable[(value.Controls[i] as EditDefault).NM_Campo].ToString().Trim();
                    else if ((value.Controls[i] as EditDefault).ST_LimpaCampo)
                        (value.Controls[i] as EditDefault).Clear();                        
                }
                else if (value.Controls[i] is EditFloat)
                {
                    if ((value.Controls[i] as EditFloat).NM_Campo.Trim() != "")
                    {
                        try
                        {
                            (value.Controls[i] as EditFloat).Value = Convert.ToDecimal(vDataTable[(value.Controls[i] as EditFloat).NM_Campo].ToString().Trim());
                        }
                        catch
                        {
                            if ((value.Controls[i] as EditFloat).Minimum < 0)
                                (value.Controls[i] as EditFloat).Value = 0;
                            else
                                (value.Controls[i] as EditFloat).Value = (value.Controls[i] as EditFloat).Minimum;
                        }
                    }
                    else
                        (value.Controls[i] as EditFloat).Value = (value.Controls[i] as EditFloat).Minimum;
                }
                else if (value.Controls[i] is ComboBoxDefault)
                {
                    if ((value.Controls[i] as ComboBoxDefault).NM_Campo.Trim() != "")
                    {
                        (value.Controls[i] as ComboBoxDefault).SelectedValue =
                            vDataTable[(value.Controls[i] as ComboBoxDefault).NM_Campo].ToString().Trim();
                    }
                    else
                        (value.Controls[i] as ComboBoxDefault).SelectedIndex = -1;
                }
                else if (value.Controls[i] is CheckBoxDefault)
                {
                    if ((value.Controls[i] as CheckBoxDefault).NM_Campo.Trim() != "")
                        (value.Controls[i] as CheckBoxDefault).Checked =
                            ((value.Controls[i] as CheckBoxDefault).Vl_True == vDataTable[(value.Controls[i] as CheckBoxDefault).NM_Campo].ToString());
                }
                else if (value.Controls[i] is RadioGroup)
                {
                    if ((value.Controls[i] as RadioGroup).NM_Campo.Trim() != "")
                        (value.Controls[i] as RadioGroup).NM_Valor = vDataTable[(value.Controls[i] as RadioGroup).NM_Campo].ToString();
                }
            }
        }

        private void HabilitarCampos(Control value, bool val, TTpModo acao)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    HabilitarCampos(value.Controls[i], val, acao);
                if (value.Controls[i] is EditDefault)
                {
                    if (acao == TTpModo.tm_Edit)
                    {
                        if (!(value.Controls[i] as EditDefault).ST_Gravar)
                            (value.Controls[i] as EditDefault).Enabled = false;
                        else if ((value.Controls[i] as EditDefault).ST_PrimaryKey)
                            (value.Controls[i] as EditDefault).Enabled = false;
                        else
                            (value.Controls[i] as EditDefault).Enabled = val;
                    }
                    else
                    {
                        if (!(value.Controls[i] as EditDefault).ST_Gravar)
                            (value.Controls[i] as EditDefault).Enabled = false;
                        else if (((value.Controls[i] as EditDefault).ST_AutoInc) &&
                                ((value.Controls[i] as EditDefault).ST_DisableAuto))
                            (value.Controls[i] as EditDefault).Enabled = false;
                        else
                            (value.Controls[i] as EditDefault).Enabled = val;
                    }
                }
                else if (value.Controls[i] is EditMask)
                {
                    if (acao.Equals(TTpModo.tm_Edit))
                    {
                        if ((!(value.Controls[i] as EditMask).ST_Gravar) || ((value.Controls[i] as EditMask).ST_PrimaryKey))
                            (value.Controls[i] as EditMask).Enabled = false;
                        else
                            (value.Controls[i] as EditMask).Enabled = val;
                    }
                    else
                    {
                        if (!(value.Controls[i] as EditMask).ST_Gravar)
                            (value.Controls[i] as EditMask).Enabled = false;
                        else
                            (value.Controls[i] as EditMask).Enabled = val;
                    }
                }
                else if (value.Controls[i] is ComboBoxDefault)
                    if(!(value.Controls[i] as ComboBoxDefault).ST_Gravar)
                        (value.Controls[i] as ComboBoxDefault).Enabled = false;
                    else
                    (value.Controls[i] as ComboBoxDefault).Enabled = val;
                else if (value.Controls[i] is CheckBoxDefault)
                    if(!(value.Controls[i] as CheckBoxDefault).ST_Gravar)
                        (value.Controls[i] as CheckBoxDefault).Enabled = false;
                    else
                    (value.Controls[i] as CheckBoxDefault).Enabled = val;
                else if (value.Controls[i] is EditFloat)
                {
                    if (acao == TTpModo.tm_Edit)
                    {
                        if ((!(value.Controls[i] as EditFloat).ST_Gravar) || ((value.Controls[i] as EditFloat).ST_PrimaryKey))
                            (value.Controls[i] as EditFloat).Enabled = false;
                        else
                            (value.Controls[i] as EditFloat).Enabled = val;
                    }
                    else
                    {
                        if ((!(value.Controls[i] as EditFloat).ST_Gravar))
                            (value.Controls[i] as EditFloat).Enabled = false;
                        else if (((value.Controls[i] as EditFloat).ST_AutoInc) &&
                            ((value.Controls[i] as EditFloat).ST_DisableAuto))
                            (value.Controls[i] as EditFloat).Enabled = false;
                        else
                            (value.Controls[i] as EditFloat).Enabled = val;
                    }
                }
                else if (value.Controls[i] is Button)
                    (value.Controls[i] as Button).Enabled = val;
                else if (value.Controls[i] is RadioGroup)
                    (value.Controls[i] as RadioGroup).Enabled = val;
            }
        }

        private void SetFormatZero(Control value, CamadaDados.Diversos.TList_CadParamSys vParam)
        {
            for (Int16 i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox)||
                    (value.Controls[i] is TableLayoutPanel))
                    SetFormatZero(value.Controls[i], vParam);

                if (value.Controls[i] is EditDefault)
                {
                    vParam.ForEach(p =>
                    {
                        if ((value.Controls[i] as EditDefault).NM_CampoBusca != "")
                            if ((value.Controls[i] as EditDefault).NM_CampoBusca.Trim().ToUpper() ==
                                p.Nm_campo.Trim().ToUpper())
                            {
                                (value.Controls[i] as EditDefault).QTD_Zero = Convert.ToInt32(p.Tamanho);
                                if ((value.Controls[i] as EditDefault).ST_PrimaryKey)
                                    (value.Controls[i] as EditDefault).ST_AutoInc = p.St_autobool && (value.Controls[i] as EditDefault).ST_DisableAuto;
                            }
                    });
                }
            }
        }

        public string GravarRegistro()
        {
            Hashtable hs = new Hashtable();
            TDataQuery dados = new TDataQuery();
            try
            {
                this.MontarParametrosGravar(this, hs);
                return dados.executarProc(this.NM_ProcGravar, hs);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show("Código erro: " + ex.ErrorCode.ToString() + "\r\n" +
                                "Mensagem   : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            catch (System.ArgumentException ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
                
        public void LimparRegistro()
        {
            this.LimparCampos(this);
        }

        public void CarregarRegistro(DataRow vDataTable, TTpModo acao)
        {
            if ((acao == TTpModo.tm_Standby) || (acao == TTpModo.tm_busca))
                this.ScrollRegistro(this, vDataTable);
        }

        public void HabilitarControls(bool value, TTpModo acao)
        {
            this.HabilitarCampos(this, value, acao);
        }

        public void set_FormatZero()
        {
            string CamposBusca = this.MontarSqlFormatZero(this,"");
            if (CamposBusca != "")
            {
                this.SetFormatZero(this, 
                    new CamadaDados.Diversos.TCD_CadParamSys().Select(
                    new TpBusca[]
                    {
                        new TpBusca()
                        {
                            vNM_Campo = "a.nm_campo",
                            vOperador = "in",
                            vVL_Busca = "(" + CamposBusca.Trim() + ")"
                        }
                    }, 0, string.Empty));
            }
        }

        public bool ValidarCampos(Control value)
        {
            for (int i = 0; i < value.Controls.Count; i++)
            {
                if ((value.Controls[i] is PanelDados) ||
                    (value.Controls[i] is Panel) ||
                    (value.Controls[i] is RadioGroup) ||
                    (value.Controls[i] is GroupBox))
                    ValidarCampos(value.Controls[i]);
                if (value.Controls[i] is EditDefault)
                    if ((value.Controls[i] as EditDefault).Visible && 
                        (value.Controls[i] as EditDefault).ST_NotNull && 
                        string.IsNullOrEmpty((value.Controls[i] as EditDefault).Text))
                        return false;
                else if (value.Controls[i] is EditFloat)
                    if ((value.Controls[i] as EditFloat).Visible &&
                        (value.Controls[i] as EditFloat).ST_NotNull && 
                        string.IsNullOrEmpty((value.Controls[i] as EditFloat).Text))
                        return false;
                else if (value.Controls[i] is EditData)
                    if ((value.Controls[i] as EditData).Visible &&
                        (value.Controls[i] as EditData).ST_NotNull && 
                        string.IsNullOrEmpty((value.Controls[i] as EditData).Text))
                        return false;
                else if (value.Controls[i] is EditHora)
                    if ((value.Controls[i] as EditHora).Visible &&
                        (value.Controls[i] as EditHora).ST_NotNull && 
                        string.IsNullOrEmpty((value.Controls[i] as EditHora).Text))
                        return false;
                    else if (value.Controls[i] is EditMask)
                    {
                        (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        if ((value.Controls[i] as EditMask).Visible &&
                            (value.Controls[i] as EditMask).ST_NotNull && 
                            string.IsNullOrEmpty((value.Controls[i] as EditMask).Text))
                            return false;
                        (value.Controls[i] as EditMask).TextMaskFormat = MaskFormat.IncludeLiterals;
                    }
            }
            return true;
        }

        public bool validarCampoObrigatorio()
        {
            try
            {
                this.validarCampoObrigatorio(this);
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return false;
            }
        }

        public void prepararBusca(Control vPainel, ref TpBusca[] vBusca)
        {
            if (vBusca == null)
            { 
                vBusca = new TpBusca[0]; 
            }
            string str = "";
            for (int i = 0; i < vPainel.Controls.Count; i++)
            {
                if ((vPainel.Controls[i] is PanelDados) ||
                    (vPainel.Controls[i] is Panel) ||
                    (vPainel.Controls[i] is RadioGroup) ||
                    (vPainel.Controls[i] is GroupBox))
                    //Se for um container chama novamente o método prepararBusca - Recursividade
                    prepararBusca(vPainel.Controls[i], ref vBusca);
                //Prepara o parametro de busca com o componente CkeckedListBoxDefault
                if (vPainel.Controls[i] is CheckedListBoxDefault)
                {
                    if (((vPainel.Controls[i] as CheckedListBoxDefault).Vl_Busca != "") && 
                        ((vPainel.Controls[i] as CheckedListBoxDefault).ST_Gravar == true))
                    {
                        if ((vPainel.Controls[i] as CheckedListBoxDefault).NM_Alias.Trim() != "")
                        {
                            str = (vPainel.Controls[i] as CheckedListBoxDefault).NM_Alias.Trim() + "." +
                                (vPainel.Controls[i] as CheckedListBoxDefault).NM_Campo.Trim();
                            Array.Resize(ref vBusca, vBusca.Length + 1);
                            vBusca[vBusca.Length - 1].vNM_Campo = str;
                            vBusca[vBusca.Length - 1].vOperador = "IN";
                            vBusca[vBusca.Length - 1].vVL_Busca = "(" + (vPainel.Controls[i] as CheckedListBoxDefault).Vl_Busca + ")";
                        }
                    }
                }
                //Prepara o parametro de busca com o componente EditDefault
                else if (vPainel.Controls[i] is EditDefault)
                {
                    //Se o edit for multiline, não faz parte da busca.
                    if (!(vPainel.Controls[i] as EditDefault).Multiline)
                    {
                        if ((vPainel.Controls[i] as EditDefault).ST_Gravar)
                        {
                            if (((vPainel.Controls[i] as EditDefault).Text.Trim() != "") && 
                                ((vPainel.Controls[i] as EditDefault).NM_Campo.Trim() != ""))
                            {
                                if ((vPainel.Controls[i] as EditDefault).NM_Alias.Trim() != "")
                                    str = (vPainel.Controls[i] as EditDefault).NM_Alias.Trim() + "." +
                                            (vPainel.Controls[i] as EditDefault).NM_Campo.Trim();
                                else
                                    str = (vPainel.Controls[i] as EditDefault).NM_Campo.Trim();
                                Array.Resize(ref vBusca, vBusca.Length + 1);
                                vBusca[vBusca.Length - 1].vNM_Campo = str;
                                if ((vPainel.Controls[i] as EditDefault).ST_PrimaryKey)
                                {
                                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + (vPainel.Controls[i] as EditDefault).Text.Trim() + "'";
                                    vBusca[vBusca.Length - 1].vOperador = "=";
                                }
                                else
                                {
                                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + (vPainel.Controls[i] as EditDefault).Text.Trim() + "%'";
                                    vBusca[vBusca.Length - 1].vOperador = "like";
                                }
                            }
                        }
                    }
                }
                //Prepara o parametro de busca com o componente EditFloat
                else if (vPainel.Controls[i] is EditFloat)
                {
                    if ((vPainel.Controls[i] as EditFloat).ST_Gravar)
                    {
                        if (((vPainel.Controls[i] as EditFloat).Value > (vPainel.Controls[i] as EditFloat).Minimum) && 
                            ((vPainel.Controls[i] as EditFloat).Value > 0) &&
                            ((vPainel.Controls[i] as EditFloat).NM_Campo.Trim() != ""))
                        {
                            if ((vPainel.Controls[i] as EditFloat).NM_Alias.Trim() != "")
                                str = (vPainel.Controls[i] as EditFloat).NM_Alias.Trim() + "." +
                                        (vPainel.Controls[i] as EditFloat).NM_Campo.Trim();
                            else
                                str = (vPainel.Controls[i] as EditFloat).NM_Campo.Trim();
                            Array.Resize(ref vBusca, vBusca.Length + 1);
                            vBusca[vBusca.Length - 1].vNM_Campo = str;
                            vBusca[vBusca.Length - 1].vVL_Busca = (vPainel.Controls[i] as EditFloat).Value.ToString(new CultureInfo("en-US", true)); 
                            if ((vPainel.Controls[i] as EditFloat).Operador.Trim() != "")
                            { 
                                vBusca[vBusca.Length - 1].vOperador = (vPainel.Controls[i] as EditFloat).Operador; 
                            }
                            else
                            { 
                                vBusca[vBusca.Length - 1].vOperador = "="; 
                            }
                        }
                    }
                }
                //Prepara o parametro de busca com o componente EditMask
                else if (vPainel.Controls[i] is EditMask)
                {
                    if ((vPainel.Controls[i] as EditMask).ST_Gravar)
                    {
                        MaskFormat msk = (vPainel.Controls[i] as EditMask).TextMaskFormat;
                        (vPainel.Controls[i] as EditMask).TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                        if (((vPainel.Controls[i] as EditMask).Text.Trim() != "") && ((vPainel.Controls[i] as EditMask).NM_Campo.Trim() != ""))
                        {
                            (vPainel.Controls[i] as EditMask).TextMaskFormat = msk;
                            if ((vPainel.Controls[i] as EditMask).NM_Alias.Trim() != "")
                                str = (vPainel.Controls[i] as EditMask).NM_Alias.Trim() + "." +
                                        (vPainel.Controls[i] as EditMask).NM_Campo.Trim();
                            else
                                str = (vPainel.Controls[i] as EditMask).NM_Campo.Trim();


                            if ((vPainel.Controls[i] is EditData))
                            {
                                Array.Resize(ref vBusca, vBusca.Length + 1);
                                vBusca[vBusca.Length - 1].vNM_Campo = str;
                                try
                                {
                                    vBusca[vBusca.Length - 1].vVL_Busca = "'" + string.Format(new CultureInfo("en-US", true), Convert.ToDateTime((vPainel.Controls[i] as EditData).Text.Trim()).ToString("yyyyMMdd")) + "'";
                                }
                                catch { }
                                if ((vPainel.Controls[i] as EditData).Operador != "")
                                    vBusca[vBusca.Length - 1].vOperador = (vPainel.Controls[i] as EditData).Operador;
                                else
                                    vBusca[vBusca.Length - 1].vOperador = "=";
                            }
                            else if ((vPainel.Controls[i] is EditHora))
                            {
                                Array.Resize(ref vBusca, vBusca.Length + 1);
                                vBusca[vBusca.Length - 1].vNM_Campo = str;
                                vBusca[vBusca.Length - 1].vVL_Busca = "'" + (vPainel.Controls[i] as EditHora).Text.Trim() + "'";
                                if ((vPainel.Controls[i] as EditData).Operador != "")
                                { 
                                    vBusca[vBusca.Length - 1].vOperador = (vPainel.Controls[i] as EditData).Operador; 
                                }
                                else
                                { 
                                    vBusca[vBusca.Length - 1].vOperador = "="; 
                                }
                            }
                        }
                        (vPainel.Controls[i] as EditMask).TextMaskFormat = msk;
                    }
                }
                else if (vPainel.Controls[i] is ComboBoxDefault)
                {
                    if ((vPainel.Controls[i] as ComboBoxDefault).ST_Gravar)
                    {
                        if((vPainel.Controls[i] as ComboBoxDefault).SelectedValue != null)
                        {
                            if ((vPainel.Controls[i] as ComboBoxDefault).NM_Alias.Trim() != "")
                                str = (vPainel.Controls[i] as ComboBoxDefault).NM_Alias.Trim() + "." +
                                        (vPainel.Controls[i] as ComboBoxDefault).NM_Campo.Trim();
                            else
                                str = (vPainel.Controls[i] as ComboBoxDefault).NM_Campo.Trim();
                            Array.Resize(ref vBusca, vBusca.Length + 1);
                            vBusca[vBusca.Length - 1].vNM_Campo = str;
                            vBusca[vBusca.Length - 1].vVL_Busca = "'" + (vPainel.Controls[i] as ComboBoxDefault).SelectedValue.ToString().Trim() + "%'";
                            vBusca[vBusca.Length - 1].vOperador = "like";
                        }
                    }
                }
                else if (vPainel.Controls[i] is RadioGroup)
                {
                    if (((vPainel.Controls[i] as RadioGroup).ST_Gravar) && ((vPainel.Controls[i] as RadioGroup).NM_Valor != ""))
                    {
                        if ((vPainel.Controls[i] as RadioGroup).NM_Alias.Trim() != "")
                            str = (vPainel.Controls[i] as RadioGroup).NM_Alias.Trim() + "." +
                                    (vPainel.Controls[i] as RadioGroup).NM_Campo.Trim();
                        else
                            str = (vPainel.Controls[i] as RadioGroup).NM_Campo.Trim();
                        Array.Resize(ref vBusca, vBusca.Length + 1);
                        vBusca[vBusca.Length - 1].vNM_Campo = str;
                        vBusca[vBusca.Length - 1].vVL_Busca = "'" + (vPainel.Controls[i] as RadioGroup).NM_Valor + "'";
                        vBusca[vBusca.Length - 1].vOperador = "=";
                    }
                }
                else if (vPainel.Controls[i] is CheckBoxDefault)
                {
                    if ((vPainel.Controls[i] as CheckBoxDefault).ST_Gravar)
                    {
                        if ((vPainel.Controls[i] as CheckBoxDefault).Checked)
                        {
                            if ((vPainel.Controls[i] as CheckBoxDefault).NM_Alias.Trim() != "")
                                str = (vPainel.Controls[i] as CheckBoxDefault).NM_Alias.Trim() + "." +
                                        (vPainel.Controls[i] as CheckBoxDefault).NM_Campo.Trim();
                            else
                                str = (vPainel.Controls[i] as CheckBoxDefault).NM_Campo.Trim();
                            Array.Resize(ref vBusca, vBusca.Length + 1);
                            vBusca[vBusca.Length - 1].vNM_Campo = str;
                            vBusca[vBusca.Length - 1].vVL_Busca = "'" + (vPainel.Controls[i] as CheckBoxDefault).Vl_True + "'";
                            vBusca[vBusca.Length - 1].vOperador = "=";
                        }
                    }
                }
            }
        }
    }
}
