using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadaNegocio.Fiscal.SPED_FISCAL
{
    public class GeradorSped
    {
        public static void GerarArquivo(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (System.IO.Directory.Exists(path))
                {
                    try
                    {
                        //CRIA O ARQUIVO
                        System.IO.FileInfo aFile = new System.IO.FileInfo(path);
                        //CRIA O STREAM DE ESCRITA
                        System.IO.StreamWriter ArquivoSPED = new System.IO.StreamWriter((System.IO.Stream)aFile.Create());
                    }
                    catch (Exception erro)
                    { throw new Exception(erro.Message); }
                }
                else
                    throw new Exception("Path Invalido.");
            }
            else
                throw new Exception("Path Invalido.");
        }

        public static void AdicionarText(string path, List<string[]> listLinha)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (System.IO.Directory.Exists(path))
                {
                    System.IO.StreamWriter ArquivoSPED = null;
                    try
                    {
                        //CRIA O ARQUIVO
                        System.IO.FileInfo aFile = new System.IO.FileInfo(path);
                        //CRIA O STREAM DE ESCRITA
                        ArquivoSPED = new System.IO.StreamWriter(path, true, Encoding.ASCII);
                        listLinha.ForEach(p => EscreverArquivo(p, ArquivoSPED));
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
                else
                    throw new Exception("Path Invalido.");
            }
            else
                throw new Exception("Path Invalido.");
        }

        private static void EscreverArquivo(string[] textoArray, System.IO.StreamWriter ArquivoSPED)
        {
            //ESCREVENDO O ARQUIVO
            for (int i = 0; i < textoArray.Length; i++)
                ArquivoSPED.Write("|" + trocaAcentuacao(textoArray[i]));

            ArquivoSPED.Write("|");
            ArquivoSPED.WriteLine("");
        }

        public static String trocaAcentuacao(String acentuada)
        {
            char[] acentuados = new char[] { 'ç', 'á', 'à', 'ã', 'â', 'ä', 'é', 'è', 'ê', 'ë', 'í', 'ì', 'î', 'ï', 'ó', 'ò', 'õ', 'ô', 'ö', 'ú', 'ù', 'û', 'ü' };
            char[] naoAcentuados = new char[] { 'c', 'a', 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u' };
            for (int i = 0; i < acentuados.Length; i++)
            {
                acentuada = acentuada.Replace(acentuados[i], naoAcentuados[i]);
                acentuada = acentuada.Replace(Char.ToUpper(acentuados[i]), Char.ToUpper(naoAcentuados[i]));
            }
            return acentuada;
        }
    }
}
