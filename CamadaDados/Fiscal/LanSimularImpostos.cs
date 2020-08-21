using CamadaDados.Faturamento.NotaFiscal;
using System.Collections.Generic;

namespace CamadaDados.Fiscal
{
    #region Classe Produto Simular
    public class TList_ProdutoSimular : List<TRegistro_ProdutoSimular>
    { }

    
    public class TRegistro_ProdutoSimular
    {
        
        public string Cd_produto
        { get; set; }
        
        public string Ds_produto
        { get; set; }
        
        public string Cd_condfiscal_produto
        { get; set; }
        
        public string Ds_condfiscal_produto
        { get; set; }
        public string Ncm
        { get; set; }
        public string Sg_unidade
        { get; set; }
        
        public decimal Quantidade
        { get; set; }
        
        public decimal Vl_unitario
        { get; set; }
        public decimal Vl_subtotal
        { get { return Quantidade * Vl_unitario; } }
        
        public TList_ImpostosNF lImpProduto
        { get; set; }

        public TRegistro_ProdutoSimular()
        {
            Cd_produto = string.Empty;
            Ds_produto = string.Empty;
            Cd_condfiscal_produto = string.Empty;
            Ds_condfiscal_produto = string.Empty;
            Sg_unidade = string.Empty;
            Ncm = string.Empty;
            Quantidade = decimal.Zero;
            Vl_unitario = decimal.Zero;
            lImpProduto = new TList_ImpostosNF();
        }
    }
    #endregion

    #region Classe Resumo Imposto
    public class TList_ResumoImposto : List<TRegistro_ResumoImposto>
    { }

    
    public class TRegistro_ResumoImposto
    {
        
        public string Cd_imposto
        { get; set; }
        
        public string Ds_imposto
        { get; set; }
        
        public decimal Vl_imposto
        { get; set; }
        
        public decimal Vl_impostoretido
        { get; set; }
        public decimal Vl_impostosubstrib
        { get; set; }
        public decimal Vl_difsubst
        { get; set; }
        
        public string St_totalnota
        { get; set; }

        public TRegistro_ResumoImposto()
        {
            Cd_imposto = string.Empty;
            Ds_imposto = string.Empty;
            Vl_imposto = decimal.Zero;
            Vl_impostoretido = decimal.Zero;
            Vl_impostosubstrib = decimal.Zero;
            Vl_difsubst = decimal.Zero;
            St_totalnota = string.Empty;
        }
    }
    #endregion
}
