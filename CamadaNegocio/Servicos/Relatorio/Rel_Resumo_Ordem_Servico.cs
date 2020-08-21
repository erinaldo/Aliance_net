using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Utils;
using CamadaDados.Servicos.Relatorio;

namespace CamadaNegocio.Servicos.Relatorio
{
    public static class TCN_Rel_Resumo_Ordem_Servico
    {
        public static DataTable Buscar_Resumo_Ordem_Servico(string vId_OS, string vCD_Empresa)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vId_OS.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_OS";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_OS;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Empresa;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            TCD_Rel_Resumo_Ordem_Servico qtb_Resumo_Ordem_Servico = new TCD_Rel_Resumo_Ordem_Servico("SqlCodeBusca_Resumo_Ordem_Servico");
            return qtb_Resumo_Ordem_Servico.Buscar(vBusca, 0, "");
        }
        
        public static DataTable Buscar_Resumo_Ordem_Servico_Evolucao(string vId_OS, string vCD_Empresa, bool vST_Evolucao)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vId_OS.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_OS";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_OS;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Empresa;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vST_Evolucao == true)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Evolucao";
                vBusca[vBusca.Length - 1].vVL_Busca = " 'C' ";
                vBusca[vBusca.Length - 1].vOperador = "<>";
            }

            TCD_Rel_Resumo_Ordem_Servico qtb_Resumo_Ordem_Servico_Evolucao = new TCD_Rel_Resumo_Ordem_Servico("SqlCodeBusca_Resumo_Ordem_Servico_Evolucao");
            return qtb_Resumo_Ordem_Servico_Evolucao.Buscar(vBusca, 0, "");
        }
     
        public static DataTable Buscar_Resumo_Ordem_Servico_Pecas_Servicos(string vId_OS, string vCD_Empresa, bool vST_Evolucao)
        {
            TpBusca[] vBusca = new TpBusca[0];
            if (vId_OS.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ID_OS";
                vBusca[vBusca.Length - 1].vVL_Busca = vId_OS;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vCD_Empresa.Trim() != "")
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.CD_Empresa";
                vBusca[vBusca.Length - 1].vVL_Busca = vCD_Empresa;
                vBusca[vBusca.Length - 1].vOperador = "=";
            }

            if (vST_Evolucao == true)
            {
                Array.Resize(ref vBusca, vBusca.Length + 1);
                vBusca[vBusca.Length - 1].vNM_Campo = "a.ST_Registro";
                vBusca[vBusca.Length - 1].vVL_Busca = " 'C' ";
                vBusca[vBusca.Length - 1].vOperador = "<>";
            }

            TCD_Rel_Resumo_Ordem_Servico qtb_Resumo_Ordem_Servico_Pecas_Servico = new TCD_Rel_Resumo_Ordem_Servico("SqlCodeBusca_Resumo_Ordem_Servico_Pecas_Servicos");
            return qtb_Resumo_Ordem_Servico_Pecas_Servico.Buscar(vBusca, 0, "");
        }
    }
}
