using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Contabil;
using CamadaNegocio.Contabil;
using Utils;

namespace Contabil
{
    public partial class TFLan_Patrimonio : FormPadrao.FFormPadrao
    {
        public TFLan_Patrimonio()
        {
            InitializeComponent();
            BB_Alterar.Dispose();
        }

        private void btn_Patrimonio_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_Patrimonio|Patrimônio|350;a.ID_Patrimonio|Cód. Patrimônio|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_Patrimonio, DS_Patrimonio },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPatrimonio(), "");
        }

        private void ID_Patrimonio_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_Patrimonio|=|'" + ID_Patrimonio.Text + "'",
            new Componentes.EditDefault[] { ID_Patrimonio, DS_Patrimonio }, new CamadaDados.Contabil.Cadastro.TCD_CadPatrimonio());
        }

        private void btn_GrupoPatrim_Click(object sender, EventArgs e)
        {
            string vColunas = "A.DS_GrupoPatrim|Grupo Patrimônio|350;a.ID_GrupoPatrim|Cód. Grupo Patrimônio|150";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { ID_GrupoPatrim, DS_GrupoPatrim },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadGrupoPatrimonio(), "");
        }

        private void ID_GrupoPatrim_Leave(object sender, EventArgs e)
        {
            UtilPesquisa.EDIT_LEAVE("a.ID_GrupoPatrim|=|'" + ID_GrupoPatrim.Text + "'",
                        new Componentes.EditDefault[] { ID_GrupoPatrim, DS_GrupoPatrim }, new CamadaDados.Contabil.Cadastro.TCD_CadGrupoPatrimonio());
        }

        public override void habilitarControls(bool value)
        {
            pnl_Cabecalho.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            try
            {
                if (rb_Todos.Checked == true)
                {
                    if (VL_Lancto.Text == "")
                    {
                        throw new Exception("Nececssário Informar o Valor de Lancamento do Patrimônio");
                    }

                    if ((DT_Lancto.Text == "") || (DT_Lancto.Text == "  /  /"))
                    {
                        throw new Exception("Necessário Informar a Data de Lancamento dos Patrimônios");
                    }

                    TFLan_TodosPatrimonios Lan_TodosPatrimonios = new TFLan_TodosPatrimonios();
                    Lan_TodosPatrimonios.DT_Patrimonios = TCN_LanPatrimonio.Busca_TodosPatrimonios(DT_Lancto.Text, "");

                    if (Lan_TodosPatrimonios.DT_Patrimonios.Rows.Count <= 0)
                    {
                        throw new Exception("Não Existe Patrimônios para serem Lançados com a Data Inferior a: " + DT_Lancto.Text);
                    }

                    if (Lan_TodosPatrimonios.ShowDialog() == DialogResult.OK)
                    {

                        TList_LanPatrimonio List_Patrimonio = new TList_LanPatrimonio();
                        for (int x = 0; x < Lan_TodosPatrimonios.DT_Patrimonios.Rows.Count; x++)
                        {
                            TRegistro_LanPatrimonio reg_LanPatrimonio = new TRegistro_LanPatrimonio();
                            reg_LanPatrimonio.ID_Patrimonio = Convert.ToDecimal(Lan_TodosPatrimonios.DT_Patrimonios.Rows[x]["ID_Patrimonio"].ToString());
                            reg_LanPatrimonio.DT_Lancto_String =  DT_Lancto.Text;
                            reg_LanPatrimonio.VL_Lancto = Convert.ToDecimal(Lan_TodosPatrimonios.DT_Patrimonios.Rows[x]["VL_Lancto"].ToString());
                            reg_LanPatrimonio.TP_Lancto = "P";
                            List_Patrimonio.Add(reg_LanPatrimonio);
                        }

                        TCN_LanPatrimonio.Grava_LanPatrimonio_Lista((List_Patrimonio), null);                                
                        Lan_TodosPatrimonios.Dispose();
                    }
                    else
                    {
                        Lan_TodosPatrimonios.Dispose();
                        throw new Exception("Lancamento de Todos os Patrimônios Cancelados.");
                    }

                    MessageBox.Show("Lançamento de Todos os Patrimônios realizado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (rb_Individual.Checked == true)
                    {
                        if (ID_Patrimonio.Text == "")
                        {
                            throw new Exception("Nececssário Informar o Patrimônio");
                        }

                        if (VL_Lancto.Text == "")
                        {
                            throw new Exception("Nececssário Informar o Valor de Lancamento do Patrimônio");
                        }

                        if ((DT_Lancto.Text == "") && (DT_Lancto.Text == "  /  /   "))
                        {
                            throw new Exception("Necessário Informar o Valor de Lancamento do Patrimônio");
                        }

                        TCN_LanPatrimonio.Grava_LanPatrimonio((BS_LanPatrimonio.Current as TRegistro_LanPatrimonio), null);
                        MessageBox.Show("Lançamento do Patrimônio \r\n " + ID_Patrimonio.Text + " - " + DS_Patrimonio.Text + " \r\n realizado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        if (rb_Grupo.Checked == true)
                        {

                            if (ID_GrupoPatrim.Text == "")
                            {
                                throw new Exception("Nececssário Informar o Grupo Patrimônio");
                            }

                            if (VL_Lancto.Text == "")
                            {
                                throw new Exception("Nececssário Informar o Valor de Lancamento do Patrimônio");
                            }

                            if ((DT_Lancto.Text == "") && (DT_Lancto.Text == "  /  /   "))
                            {
                                throw new Exception("Necessário Informar a Data de Lancamento dos Patrimônios");
                            }


                            TFLan_TodosPatrimonios Lan_TodosPatrimonios = new TFLan_TodosPatrimonios();
                            Lan_TodosPatrimonios.DT_Patrimonios = TCN_LanPatrimonio.Busca_TodosPatrimonios(DT_Lancto.Text, ID_GrupoPatrim.Text);

                            if (Lan_TodosPatrimonios.DT_Patrimonios.Rows.Count <= 0)
                            {
                                throw new Exception("Não Existe Patrimônios para serem Lançados com a Data Inferior a: " + DT_Lancto.Text + 
                                                    "\r\n Grupo Patrimônio:" + ID_GrupoPatrim.Text.Trim() + " - " + DS_GrupoPatrim.Text.Trim());
                            }

                            if (Lan_TodosPatrimonios.ShowDialog() == DialogResult.OK)
                            {

                                TList_LanPatrimonio List_Patrimonio = new TList_LanPatrimonio();
                                for (int x = 0; x < Lan_TodosPatrimonios.DT_Patrimonios.Rows.Count; x++)
                                {
                                    TRegistro_LanPatrimonio reg_LanPatrimonio = new TRegistro_LanPatrimonio();
                                    reg_LanPatrimonio.ID_Patrimonio = Convert.ToDecimal(Lan_TodosPatrimonios.DT_Patrimonios.Rows[x]["ID_Patrimonio"].ToString());
                                    reg_LanPatrimonio.DT_Lancto_String = DT_Lancto.Text;
                                    reg_LanPatrimonio.VL_Lancto = Convert.ToDecimal(Lan_TodosPatrimonios.DT_Patrimonios.Rows[x]["VL_Lancto"].ToString());
                                    reg_LanPatrimonio.TP_Lancto = "P";
                                    List_Patrimonio.Add(reg_LanPatrimonio);
                                }

                                TCN_LanPatrimonio.Grava_LanPatrimonio_Lista((List_Patrimonio), null);
                                Lan_TodosPatrimonios.Dispose();
                            }
                            else
                            {
                                Lan_TodosPatrimonios.Dispose();
                                throw new Exception("Lançamento de Todos os Patrimônios Cancelados.");
                            }
                            

                            MessageBox.Show("Lançamento dos Patrimônios do Grupo: \r\n " + ID_GrupoPatrim.Text + " - " + DS_GrupoPatrim.Text + " \r\n realizado com Sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        } 
                    }
                }
                
                afterBusca();
            }
            catch(Exception e)
            {
                MessageBox.Show("Erro ao Lançar Patrimônio \r\n" + e.Message.ToString(), "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                
            }

            return "";

        }

        public override int buscarRegistros()
        {
            TList_LanPatrimonio lista = TCN_LanPatrimonio.Busca(ID_Patrimonio.Text, "", "", "", "", false, false, 0, "");

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_LanPatrimonio.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_LanPatrimonio.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                BS_LanPatrimonio.Clear();
                BS_LanPatrimonio.AddNew();
                base.afterNovo();
                rb_Todos.Focus();
                ID_Patrimonio.Text = "";
                DS_Patrimonio.Text = "";
                ID_GrupoPatrim.Text = "";
                DS_GrupoPatrim.Text = "";

                ID_Patrimonio.Enabled = false;
                btn_Patrimonio.Enabled = false;
                DS_Patrimonio.Enabled = false;
                ID_GrupoPatrim.Enabled = false;
                btn_GrupoPatrim.Enabled = false;
                DS_GrupoPatrim.Enabled = false;

                rbPerca.Checked = true;
                rbRealivacao.Enabled = false;
                rbVenda.Enabled = false;
                rbDeteriorizacao.Enabled = false;

                VL_Lancto.Value = 0;
                VL_Lancto.Enabled = false;
            }

        }

        public override void afterCancela()
        {
            base.afterCancela();

        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (this.vTP_Modo == TTpModo.tm_Edit) 
            {
                if (!ID_Patrimonio.Focus())
                    ID_GrupoPatrim.Focus();

                RG_TPLancto.Enabled = false;
                DT_Lancto.Enabled = false;
                ID_Patrimonio.Enabled = false;
                btn_Patrimonio.Enabled = false;
                DS_Patrimonio.Enabled = false;

                ID_GrupoPatrim.Enabled = false;
                btn_GrupoPatrim.Enabled = false;
                DS_GrupoPatrim.Enabled = false;


            }


        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if ((BS_LanPatrimonio != null) && (BS_LanPatrimonio.Count > 0))
                {
                    if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                    System.Windows.Forms.DialogResult.Yes)
                    {
                        TCN_LanPatrimonio.Deleta_LanPatrimonio((BS_LanPatrimonio.Current as TRegistro_LanPatrimonio), null);
                        BS_LanPatrimonio.RemoveCurrent();
                        pnl_Cabecalho.LimparRegistro();
                        afterBusca();
                    }
                }
            }
        }

        private void rb_Todos_CheckedChanged(object sender, EventArgs e)
        {
            if(rb_Todos.Checked == true)
            {
                ID_Patrimonio.Text = "";
                DS_Patrimonio.Text = "";
                ID_GrupoPatrim.Text = "";
                DS_GrupoPatrim.Text = "";

                ID_Patrimonio.Enabled = false;
                btn_Patrimonio.Enabled = false;
                DS_Patrimonio.Enabled = false;
                ID_GrupoPatrim.Enabled = false;
                btn_GrupoPatrim.Enabled = false;
                DS_GrupoPatrim.Enabled = false;

                rbPerca.Checked = true;
                rbRealivacao.Enabled = false;
                rbVenda.Enabled = false;
                rbDeteriorizacao.Enabled = false;

                VL_Lancto.Value = 0;
                VL_Lancto.Enabled = false;
                
            }

        }

        private void rb_Individual_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Individual.Checked == true)
            {
                ID_Patrimonio.Text = "";
                DS_Patrimonio.Text = "";
                ID_GrupoPatrim.Text = "";
                DS_GrupoPatrim.Text = "";

                ID_Patrimonio.Enabled = true;
                btn_Patrimonio.Enabled = true;
                DS_Patrimonio.Enabled = false;
                ID_GrupoPatrim.Enabled = false;
                btn_GrupoPatrim.Enabled = false;
                DS_GrupoPatrim.Enabled = false;

                rbPerca.Enabled = true;
                rbRealivacao.Enabled = true;
                rbVenda.Enabled = true;
                rbDeteriorizacao.Enabled = true;

                VL_Lancto.Enabled = true;
                
            }
        }

        private void rb_Grupo_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Grupo.Checked == true)
            {
                ID_Patrimonio.Text = "";
                DS_Patrimonio.Text = "";
                ID_GrupoPatrim.Text = "";
                DS_GrupoPatrim.Text = "";

                ID_Patrimonio.Enabled = false;
                btn_Patrimonio.Enabled = false;
                DS_Patrimonio.Enabled = false;
                ID_GrupoPatrim.Enabled = true;
                btn_GrupoPatrim.Enabled = true;
                DS_GrupoPatrim.Enabled = false;


                rbPerca.Checked = true;
                rbRealivacao.Enabled = false;
                rbVenda.Enabled = false;
                rbDeteriorizacao.Enabled = false;

                VL_Lancto.Value = 0;
                VL_Lancto.Enabled = false;

            }
        }

        private void TFLan_Patrimonio_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gPatrimonio);
            panelDados1.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            panelDados2.BackColor = Utils.SettingsUtils.Default.COLOR_1;
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFLan_Patrimonio_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gPatrimonio);
        }


    }
}
