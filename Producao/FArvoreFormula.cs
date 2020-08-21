using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Producao
{
    public partial class TFArvoreFormula : Form
    {
        public CamadaDados.Producao.Producao.TRegistro_FormulaApontamento rFormula
        { get; set; }

        public TFArvoreFormula()
        {
            InitializeComponent();
        }

        private void MontarArvore(CamadaDados.Producao.Producao.TList_FichaTec_MPrima lMPrima,
                                  TreeNode no)
        {
            lMPrima.ForEach(p =>
                {
                    if (p.Id_formulacao_mprima != null)
                    {
                        //Criar no na arvore
                        trvArvore.Nodes.Add(p.Ds_produto.Trim());
                        //Buscar lista de materia prima
                        CamadaDados.Producao.Producao.TList_FichaTec_MPrima aux =
                            CamadaNegocio.Producao.Producao.TCN_FichaTec_MPrima.Buscar(p.Cd_empresa,
                                                                                       p.Id_formulacao_mprimastr,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       string.Empty,
                                                                                       0,
                                                                                       string.Empty,
                                                                                       null);
                        MontarArvore(aux, trvArvore.Nodes[trvArvore.Nodes.Count - 1]);
                    }
                    else
                        //Criar novo no na arvore
                        if (no == null)
                            trvArvore.Nodes.Add(p.Ds_produto.Trim());
                        else
                            no.Nodes.Add(p.Ds_produto.Trim());
                });
        }

        private void TFArvoreFormula_Load(object sender, EventArgs e)
        {
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            if (rFormula != null)
            {
                bsFormulaApontamento.DataSource = rFormula;
                Text = "Arvore Formula Produção: " + rFormula.Ds_formula.Trim();
                //Montar arvore das materias primas
                MontarArvore(rFormula.LFichaTec_MPrima, null);
            }
        }
    }
}
