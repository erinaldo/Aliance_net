using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using System.Data;
using CamadaDados.Financeiro.Relatorio;
using System.Collections;

namespace CamadaNegocio.Financeiro.Relatorio
{
   public static class TCN_Rel_Transacoes_Caixa
    {
       public static DataTable Buscar(string vDataInicial,
                                      string vDataFinal,
                                      string vCD_Empresa,
                                      string vCD_ContaGer,
                                      string vCCD_Custo,
                                      string vCD_Historico,
                                      bool vST_Titulos_Pendentes,
                                      bool vST_Stornos,
                                      short vTop,
                                      string vNM_Campo,
                                      string vGroup,
                                      string vOrder,
                                      Hashtable vParametros
           )
       
       {

           TpBusca[] vBusca = new TpBusca[0];

           if ((vDataInicial.Trim() != "/  /") && (vDataFinal.Trim() != "/  /"))
           {
                   Array.Resize(ref vBusca, vBusca.Length + 1);
                   vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto"; ;
                   vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDataInicial + "' and '" + vDataFinal + "'";
                   vBusca[vBusca.Length - 1].vOperador = "between";
           }

           if (vCD_Empresa.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_empresa"; ;
               vBusca[vBusca.Length - 1].vVL_Busca = vCD_Empresa;
               vBusca[vBusca.Length - 1].vOperador = "=";
           }

           /*  if (vCCD_Custo.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_custo"; ;
               vBusca[vBusca.Length - 1].vVL_Busca = vCCD_Custo;
               vBusca[vBusca.Length - 1].vOperador = "=";
           }*/

           if (vCD_ContaGer.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contager"; ;
               vBusca[vBusca.Length - 1].vVL_Busca = vCD_ContaGer;
               vBusca[vBusca.Length - 1].vOperador = "=";
           }

           if (vCD_Historico.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_historico"; ;
               vBusca[vBusca.Length - 1].vVL_Busca = vCD_Historico;
               vBusca[vBusca.Length - 1].vOperador = "=";
           }

           TCD_Rel_Transacoes_Caixa qtb_Transacoes_Caixa = new TCD_Rel_Transacoes_Caixa();
           return qtb_Transacoes_Caixa.Buscar(vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros);
       }

       public static DataTable Buscar_Saldo_Anterior(string vDataInicial,
                                                     string vCD_ContaGer,
                                                     short vTop,
                                                     string vNM_Campo,
                                                     string vGroup,
                                                     string vOrder,
                                                     Hashtable vParametros
          )
       {

           TpBusca[] vBusca = new TpBusca[0];

           if (vDataInicial.Trim() != "/  /") 
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.DT_Lancto"; ;
               vBusca[vBusca.Length - 1].vVL_Busca = "'" + vDataInicial + "'";
               vBusca[vBusca.Length - 1].vOperador = "<";
           }
                      
           if (vCD_ContaGer.Trim() != "")
           {
               Array.Resize(ref vBusca, vBusca.Length + 1);
               vBusca[vBusca.Length - 1].vNM_Campo = "a.cd_contager"; ;
               vBusca[vBusca.Length - 1].vVL_Busca = vCD_ContaGer;
               vBusca[vBusca.Length - 1].vOperador = "=";
           }


           TCD_Rel_Transacoes_Caixa qtb_Saldo_Anterior = new TCD_Rel_Transacoes_Caixa("SqlCodeBusca_Saldo_Anterior");
           return qtb_Saldo_Anterior.Buscar(vBusca, vTop, vNM_Campo, vGroup, vOrder, vParametros);
       }


        }
}
