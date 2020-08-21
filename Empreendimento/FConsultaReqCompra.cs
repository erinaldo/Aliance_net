using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;
using CamadaDados.Empreendimento;
using CamadaNegocio.Empreendimento;


namespace Empreendimento
{
    public partial class FConsultaReqCompra : Form
    {
        public FConsultaReqCompra()
        {
            InitializeComponent();
        }

        private void bbBuscar_Click(object sender, EventArgs e)
        {
            TpBusca[] filtro = new TpBusca[0];
            Array.Resize(ref filtro, filtro.Length + 1);
            filtro[filtro.Length - 1].vOperador = "not exists ";
            filtro[filtro.Length - 1].vVL_Busca = " (select 1 from TB_EMP_CompraEmpreendimento x " +
                                                  "where a.id_orcamento = x.id_orcamento and a.nr_versao = x.nr_versao " +
                                                  "and a.ID_Atividade = x.ID_Atividade and a.ID_Ficha = x.ID_Ficha " +
                                                  "and a.ID_Registro = x.ID_Registro and a.cd_empresa = x.cd_empresa) ";
            bsFicha.DataSource = new TCD_FichaTec().Select(filtro, 0, string.Empty);
        }
    }
}
