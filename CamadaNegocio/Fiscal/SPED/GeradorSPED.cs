using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;
using BancoDados;
using CamadaDados;
using CamadaDados.Fiscal;
using System.IO; 

namespace SPED.ProcessarSPED
{
    public class GeradorSPED
    {
        public void GerarArquivo(string path, List<string[]> listLinha)
        {
            StreamWriter ArquivoSPED = null;

            try
            {
                //CRIA O ARQUIVO
                FileInfo aFile = new FileInfo(path);

                //CRIA O STREAM DE ESCRITA
                ArquivoSPED = new StreamWriter((Stream)aFile.Create());

                for (int i = 0; i < listLinha.Count; i++)
                {
                    EscreverArquivo(listLinha[i], ArquivoSPED);
                }
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                //LIBERA O ARQUIVO DA MEMORIA
                if (ArquivoSPED != null)
                {
                    ArquivoSPED.Flush();
                    ArquivoSPED.Close();
                }
            }
        }

        private void EscreverArquivo(string[] textoArray, StreamWriter ArquivoSPED)
        {
            //ESCREVENDO O ARQUIVO
            for (int i = 0; i < textoArray.Length; i++)
                ArquivoSPED.Write("|" + textoArray[i]);

            ArquivoSPED.WriteLine("");
        }
    }


}
