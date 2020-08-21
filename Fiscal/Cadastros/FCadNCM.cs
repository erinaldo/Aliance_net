using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FormBusca;
using CamadaDados.Fiscal;
using CamadaNegocio.Fiscal;
using Utils;


namespace Fiscal.Cadastros
{
    public partial class TFCadNCM : FormCadPadrao.FFormCadPadrao
    {
        public TFCadNCM()
        {
           
            InitializeComponent();
            pDados.set_FormatZero();
            
            DTS = BS_NCM;
        }

        public override void habilitarControls(bool value)
        {
            pDados.HabilitarControls(value, this.vTP_Modo);
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
            {
                Pc_Aliquota.Value.ToString();
                string retorno = TCN_CadNCM.GravarNCM(BS_NCM.Current as TRegistro_CadNCM);
                NCM.Text = (BS_NCM.Current as TRegistro_CadNCM).NCM.Trim();
                return retorno;
            }
            else
                return string.Empty;
        }

        public override int buscarRegistros()
        {

            TList_CadNCM lista = TCN_CadNCM.Busca(NCM.Text, 
                                                  Ds_NCM.Text, 
                                                  Pc_Aliquota.Value);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    BS_NCM.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        BS_NCM.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterAltera()
        {
            base.afterAltera();
            if (vTP_Modo == TTpModo.tm_Edit)
                Ds_NCM.Focus();
        }

        public override void afterNovo()
        {
            if ((this.vTP_Modo == TTpModo.tm_busca) || (this.vTP_Modo == TTpModo.tm_Standby))
            {
                BS_NCM.AddNew();
                base.afterNovo();
            }
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (this.vTP_Modo == TTpModo.tm_Insert)
                BS_NCM.RemoveCurrent();
        }

        public override void afterExclui()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_CadNCM.DeletarNCM((BS_NCM.Current as TRegistro_CadNCM));
                    BS_NCM.RemoveCurrent();
                    pDados.LimparRegistro();     
                    afterBusca();
                }
            }
        }
        
        private void TFCadNCM_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gCadastro);
            if (!string.IsNullOrEmpty(Utils.Parametros.pubCultura))
                Idioma.TIdioma.AjustaCultura(this);
        }

        private void TFCadNCM_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gCadastro);
        }

        private void NCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || //Letras
                char.IsSymbol(e.KeyChar) || //Símbolos
                char.IsWhiteSpace(e.KeyChar) || //Espaço
                char.IsPunctuation(e.KeyChar)) //Pontuação
                e.Handled = true;
        }

        private void bbCorrigirProjeto_Click(object sender, EventArgs e)
        {
            using(Parametros.Diversos.FExlNcm exl = new Parametros.Diversos.FExlNcm())
            {
                if (exl.ShowDialog() == DialogResult.OK)
                    afterBusca();
            }
        }
        
        private void bbSincronizar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TRegistro_CadNCM> lista = ServiceRest.DataService.BuscarNCMRest();
                if (lista != null)
                {
                    lista.ForEach(p => TCN_CadNCM.GravarNCM(p));
                    MessageBox.Show("Cadastro sincronizado com sucesso.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    afterBusca();
                }
            }
            catch (Exception ex)
            { MessageBox.Show("Erro: " + ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
