using System.Collections.Generic;
using System.IO;

namespace Projetos_Sprint4_E_Players_AspNETCore.Models
{
    public class EplayersBase
    {
        /// <summary>
        /// Cria a pasta e o arquivo caso não exista
        /// </summary>
        /// <param name="_path">Caminho do arquivo</param>
        public void CreateFolderAndFile(string _path){

            string folder   = _path.Split("/")[0];
            

            if(!Directory.Exists(folder)){
                Directory.CreateDirectory(folder);
            }

            if(!File.Exists(_path)){
                File.Create(_path).Close();
            }
        }

        /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <param name="PATH">Caminho do arquivo</param>
        /// <returns>Lista para ser lida no csv</returns>
        public List<string> ReadAllLinesCSV(string PATH){
            
            List<string> linhas = new List<string>();
            using(StreamReader file = new StreamReader(PATH))
            {
                string linha;
                while((linha = file.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        /// <summary>
        /// Reescreve o csv
        /// </summary>
        /// <param name="PATH">Caminho do arquivo</param>
        /// <param name="linhas">Linhas para reescrever o arquivo</param>
        public void RewriteCSV(string PATH, List<string> linhas)
        {
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach (var item in linhas)
                {
                    output.Write(item + "\n");
                }
            }
        }
    }
}