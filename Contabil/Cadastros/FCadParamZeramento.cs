using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using FormBusca;
using System.Windows.Forms;
using CamadaNegocio.Contabil.Cadastro;
using Utils;
using CamadaDados.Contabil.Cadastro;

namespace Contabil.Cadastros
{
    public partial class TFCadParamZeramento : FormCadPadrao.FFormCadPadrao
    {
        public TFCadParamZeramento()
        {
            InitializeComponent();
        }

        private void bb_conta_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'S';" +
                            "a.nivelconta |=| 1";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cReceita, ds_contareceita, cd_classifreceita },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'S';" +
                            "a.nivelconta |=| 1";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cDespesa, ds_contadespesa, cd_classifdespesa },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'S';" +
                            "a.nivelconta |=| 1";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cLucro, ds_contalucro, cd_classiflucro },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'S';" +
                            "a.nivelconta |=| 1";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { contacusto, ds_contacusto, cd_classifcusto },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'A'";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { contaresultadoL, ds_contaresultadoL, cd_classifresultado },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cReceita_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cReceita.Text + ";a.tp_conta|=|'S';" + "a.nivelconta |=| 1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cReceita, ds_contareceita, cd_classifreceita },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void cDespesa_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cReceita.Text + ";a.tp_conta|=|'S';" + "a.nivelconta |=| 1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cDespesa, ds_contadespesa, cd_classifdespesa },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void cLucro_Leave(object sender, EventArgs e)
        {

            string vParam = "a.cd_conta_CTB|=|" + cReceita.Text + ";a.tp_conta|=|'S';" + "a.nivelconta |=| 1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cLucro, ds_contalucro, cd_classiflucro },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void contacusto_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cReceita.Text + ";a.tp_conta|=|'S';" + "a.nivelconta |=| 1";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { contacusto, ds_contacusto, cd_classifcusto },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void BTN_Empresa_Click(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.BTN_BuscaEmpresa(new Componentes.EditDefault[] { CD_Empresa, nm_empresa }, string.Empty);
        
        }

        private void CD_Empresa_Leave(object sender, EventArgs e)
        {
            FormBusca.UtilPesquisa.EDIT_LeaveEmpresa("a.cd_empresa|=|'" + CD_Empresa.Text.Trim() + "'", new Componentes.EditDefault[] { CD_Empresa, nm_empresa });
        
        }

        public override string gravarRegistro()
        {
            bsParamZera.ResetBindings(true);
            if (pDados.validarCampoObrigatorio())
                return TCN_Cad_CTB_ParamZeramento.Gravar((bsParamZera.Current as TRegistro_Cad_CTB_ParamZeramento), null);
            else
                return "";
        }

        public override int buscarRegistros()
        {
            TList_Cad_CTB_ParamZeramento lista = TCN_Cad_CTB_ParamZeramento.Buscar(CD_Empresa.Text,
                                                                                   cReceita.Text,
                                                                                   cDespesa.Text, 
                                                                                   cLucro.Text,
                                                                                   contacusto.Text,
                                                                                   string.Empty,
                                                                                   contaresultadoL.Text,
                                                                                   string.Empty,
                                                                                   null
                                                                                   );

            if (lista != null)
            {
                if (lista.Count > 0)
                {
                    this.Lista = lista;
                    bsParamZera.DataSource = lista;
                }
                else
                    if ((vTP_Modo == TTpModo.tm_Standby) || (vTP_Modo == TTpModo.tm_busca))
                        bsParamZera.Clear();
                return lista.Count;
            }
            else

                return 0;
        }

        public override void afterNovo()
        {
            if ((vTP_Modo == TTpModo.tm_busca) || (vTP_Modo == TTpModo.tm_Standby))
            {
                bsParamZera.AddNew();
                base.afterNovo();
                if (!CD_Empresa.Focus())
                    CD_Empresa.Focus();

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
                if (!CD_Empresa.Focus())
                    CD_Empresa.Focus();
            }

        }

        public override void excluirRegistro()
        {
            if ((this.vTP_Modo == TTpModo.tm_Standby) || (this.vTP_Modo == TTpModo.tm_busca))
            {
                if (MessageBox.Show("Confirma Exclusão do Registro?", "Mensagem",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) ==
                System.Windows.Forms.DialogResult.Yes)
                {
                    TCN_Cad_CTB_ParamZeramento.Excluir((bsParamZera.Current as TRegistro_Cad_CTB_ParamZeramento), null);
                    bsParamZera.RemoveCurrent();
                    pDados.LimparRegistro();
                    afterBusca();
                }
            }
        }

        private void TFCadParamZeramento_Load(object sender, EventArgs e)
        {
            pDados.set_FormatZero();
        }

        private void contaresultado_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + contaresultadoL.Text + ";a.tp_conta|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { contaresultadoL, ds_contaresultadoL, cd_classifresultado },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_cresultadoP_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'A'";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_cresultadoP, ds_cresultadoP, cd_classifResultadoP },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cd_cresultadoP_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + cd_cresultadoP.Text + ";a.tp_conta|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_cresultadoP, ds_cresultadoP, cd_classifResultadoP },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }

        private void bb_contaresultado_Click(object sender, EventArgs e)
        {
            string vParam = "a.tp_conta|=|'A'";
            string vColunas = "a.ds_contactb|Descrição|200;" +
                              "a.cd_Conta_ctb|ID|80;" +
                              "a.cd_classificacao|Classificação|80";
            UtilPesquisa.BTN_BUSCA(vColunas, new Componentes.EditDefault[] { cd_contaresultado, ds_contaresultado, cd_classifresult },
                                    new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas(), vParam);
        }

        private void cd_contaresultado_Leave(object sender, EventArgs e)
        {
            string vParam = "a.cd_conta_CTB|=|" + contaresultadoL.Text + ";a.tp_conta|=|'A'";
            FormBusca.UtilPesquisa.EDIT_LEAVE(vParam, new Componentes.EditDefault[] { cd_contaresultado, ds_contaresultado, cd_classifresult },
                new CamadaDados.Contabil.Cadastro.TCD_CadPlanoContas());
        }
    }
}
