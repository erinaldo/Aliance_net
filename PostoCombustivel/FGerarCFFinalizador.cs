using System;
using System.Linq;
using System.Windows.Forms;

namespace PostoCombustivel
{
    public partial class TFGerarCFFinalizador : Form
    {
        public string Cd_empresa
        { get; set; }

        public CamadaDados.Faturamento.PDV.TList_VendaRapida_Item lItens
        {
            get
            {
                if (bsItens.Count > 0)
                    return bsItens.List as CamadaDados.Faturamento.PDV.TList_VendaRapida_Item;
                else return null;
            }
        }

        public TFGerarCFFinalizador()
        {
            InitializeComponent();
        }

        private void afterBusca()
        {
            Utils.TpBusca[] filtro = new Utils.TpBusca[1];
            filtro[0].vNM_Campo = "cf.cd_empresa";
            filtro[0].vOperador = "=";
            filtro[0].vVL_Busca = "'" + Cd_empresa.Trim() + "'";
            if (dt_ini.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = ">=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_ini.Text).ToString("yyyyMMdd") + "'";
            }
            if (dt_fin.Text.Trim() != "/  /")
            {
                Array.Resize(ref filtro, filtro.Length + 1);
                filtro[filtro.Length - 1].vNM_Campo = "convert(datetime, floor(convert(decimal(30,10), cf.dt_emissao)))";
                filtro[filtro.Length - 1].vOperador = "<=";
                filtro[filtro.Length - 1].vVL_Busca = "'" + DateTime.Parse(dt_fin.Text).ToString("yyyyMMdd") + "'";
            }
            CamadaDados.Faturamento.PDV.TList_VendaRapida_Item lItens =
                    new CamadaDados.Faturamento.PDV.TCD_VendaRapida_Item().SelectCFFechamento(filtro);
            //Agrupar por produto
            bsGrupoProd.DataSource = lItens.GroupBy(p => p.Ds_produto,
                (aux, venda) =>
                new
                {
                    produto = aux,
                    quantidade = venda.Sum(x => x.Quantidade),
                    vl_subtotal = venda.Sum(x => x.Vl_subtotal),
                    vl_desconto = venda.Sum(x => x.Vl_desconto),
                    vl_liquido = venda.Sum(x => x.Vl_subtotalliquido)
                });
            //Totalizar
            tot_venda.Value = lItens.Sum(p => p.Vl_subtotal);
            tot_desconto.Value = lItens.Sum(p => p.Vl_desconto);
            tot_liquido.Value = lItens.Sum(p => p.Vl_subtotalliquido);

            bsItens.DataSource = lItens;
        }

        private void TFGerarCFFinalizador_Load(object sender, EventArgs e)
        {
            Utils.ShapeGrid.RestoreShape(this, gItens);
            Icon = Utils.ResourcesUtils.TecnoAliance_ICO;
            CD_Empresa.Text = Cd_empresa;
            dt_ini.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dt_fin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            afterBusca();
        }

        private void BB_Buscar_Click(object sender, EventArgs e)
        {
            afterBusca();
        }

        private void BB_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BB_Gravar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TFGerarCFFinalizador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.F4))
                DialogResult = DialogResult.OK;
            else if (e.KeyCode.Equals(Keys.F6))
                DialogResult = DialogResult.Cancel;
            else if (e.KeyCode.Equals(Keys.F7))
                afterBusca();
        }

        private void TFGerarCFFinalizador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Utils.ShapeGrid.SaveShape(this, gItens);
        }
    }
}
