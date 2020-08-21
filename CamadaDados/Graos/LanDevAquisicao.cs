using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaDados.Graos
{
    public class TList_DevAquisicao : List<TRegistro_DevAquisicao>
    { }
    
    public class TRegistro_DevAquisicao
    {
        private DateTime? dt_lancto;
        public DateTime? Dt_lancto
        {
            get { return dt_lancto; }
            set
            {
                dt_lancto = value;
                dt_lanctostr = value.HasValue ? value.Value.ToString("dd/MM/yyyy") : string.Empty;
            }
        }
        private string dt_lanctostr;
        public string Dt_lanctostr
        {
            get { return dt_lanctostr; }
            set
            {
                dt_lanctostr = value;
                try
                {
                    dt_lancto = Convert.ToDateTime(value);
                }
                catch
                { dt_lancto = null; }
            }
        }
        public decimal Quantidade
        { get; set; }
        public decimal Vl_unit_origem
        { get; set; }
        public decimal Vl_unit_destino
        { get; set; }
        public decimal Vl_subtotal_origem
        { get; set; }
        public decimal Vl_subtotal_destino
        { get; set; }
        public TList_Transf_X_Contrato Contrato_devolucao
        { get; set; }
        public TList_Transf_X_Contrato Contrato_compra
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TList_LanFat_ComplementoDevolucao Devolucao
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfOrigem
        { get; set; }
        public CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento rNfDestino
        { get; set; }
        public CamadaDados.Graos.TRegistro_CadContrato Contrato_Origem
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Reg_Clifor_Origem
        { get; set; }
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto Reg_Produto_Origem
        { get; set; }
        public CamadaDados.Diversos.TRegistro_CadEmpresa Reg_Empresa_Origem
        { get; set; }
        public CamadaDados.Graos.TRegistro_CadContrato Contrato_Destino
        { get; set; }
        public CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor Reg_Clifor_Destino
        { get; set; }
        public CamadaDados.Estoque.Cadastros.TRegistro_CadProduto Reg_Produto_Destino
        { get; set; }
        public CamadaDados.Diversos.TRegistro_CadEmpresa Reg_Empresa_Destino
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata Duplicata_Origem
        { get; set; }
        public CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata Duplicata_Destino
        { get; set; }

        public TRegistro_DevAquisicao()
        {
            this.dt_lancto = DateTime.Now;
            this.dt_lanctostr = DateTime.Now.ToString("dd/MM/yyyy");
            this.Quantidade = decimal.Zero;
            this.Vl_unit_origem = decimal.Zero;
            this.Vl_unit_destino = decimal.Zero;
            this.Vl_subtotal_origem = decimal.Zero;
            this.Vl_subtotal_destino = decimal.Zero;
            this.Contrato_compra = new TList_Transf_X_Contrato();
            this.Contrato_devolucao = new TList_Transf_X_Contrato();
            this.Devolucao = new CamadaDados.Faturamento.NotaFiscal.TList_LanFat_ComplementoDevolucao();
            this.rNfDestino = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
            this.rNfOrigem = new CamadaDados.Faturamento.NotaFiscal.TRegistro_LanFaturamento();
            this.Contrato_Origem = new TRegistro_CadContrato();
            this.Reg_Clifor_Origem = new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor();
            this.Reg_Produto_Origem = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
            this.Reg_Empresa_Origem = new CamadaDados.Diversos.TRegistro_CadEmpresa();
            this.Contrato_Destino = new TRegistro_CadContrato();
            this.Reg_Clifor_Destino = new CamadaDados.Financeiro.Cadastros.TRegistro_CadClifor();
            this.Reg_Produto_Destino = new CamadaDados.Estoque.Cadastros.TRegistro_CadProduto();
            this.Reg_Empresa_Destino = new CamadaDados.Diversos.TRegistro_CadEmpresa();
            this.Duplicata_Origem = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
            this.Duplicata_Destino = new CamadaDados.Financeiro.Duplicata.TList_RegLanDuplicata();
        }
    }
}
