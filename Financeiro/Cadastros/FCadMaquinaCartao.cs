using CamadaDados.Financeiro.Cadastros;
using CamadaNegocio.Financeiro.Cadastros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utils;

namespace Financeiro.Cadastros
{
    public partial class TFCadMaquinaCartao : FormCadPadrao.FFormCadPadrao
    {
        public TFCadMaquinaCartao()
        {
            InitializeComponent();
        }

        public override int buscarRegistros()
        {
            TList_CadMaquinaCartao lista = TCN_CadMaquinaCartao.Buscar(ID_Maquina.Text, DS_Maquina.Text, null);
            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsMaquinaCartao.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || ((vTP_Modo == TTpModo.tm_busca)))
                    bsMaquinaCartao.Clear();
                return lista.Count;
            }
            else
                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsMaquinaCartao.AddNew();
                base.afterNovo();
                if (!ID_Maquina.Focus())
                    DS_Maquina.Focus();
            }
        }

        public override void afterAltera()
        {
            base.afterAltera();
        }

        public override void afterCancela()
        {
            base.afterCancela();
            if (vTP_Modo == TTpModo.tm_Insert)
                bsMaquinaCartao.RemoveCurrent();
        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    try
                    {
                        TCN_CadMaquinaCartao.Deletar(bsMaquinaCartao.Current as TRegistro_CadMaquinaCartao, null);
                        bsMaquinaCartao.RemoveCurrent();
                        pDados.LimparRegistro();
                        afterBusca();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.Trim(), "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        public override string gravarRegistro()
        {
            if (pDados.validarCampoObrigatorio())
                return TCN_CadMaquinaCartao.Gravar(bsMaquinaCartao.Current as TRegistro_CadMaquinaCartao, null);
            else
                return string.Empty;
        }
    }
}
