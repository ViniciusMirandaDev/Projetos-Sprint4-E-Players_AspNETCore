using System;
using System.Collections.Generic;
using System.IO;
using Projetos_Sprint4_E_Players_AspNETCore.Interfaces;

namespace Projetos_Sprint4_E_Players_AspNETCore.Models
{
    public class Noticias : EplayersBase, INoticias
    {
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }

        private const string PATH = "Database/noticias.csv";

        public Noticias()
        {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Cria a linha do csv
        /// </summary>
        /// <param name="n">Noticia a ser criada</param>
        public void Create(Noticias n)
        {
            string[] linhas = { PrepararLinha(n)} ; 
            File.AppendAllLines(PATH, linhas);
        }

         /// <summary>
         /// Prepara a linnha do csv
         /// </summary>
         /// <param name="n">Noticia a ser colocada no scv</param>
         /// <returns>Linha preparada</returns>
        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }

        /// <summary>
        /// Lê todas as linhas do csv
        /// </summary>
        /// <returns>Lista de noiticia lida</returns>
        public List<Noticias> ReadAll()
        {
            List<Noticias> noticia = new List<Noticias>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Noticias not = new Noticias();
                not.IdNoticia = Int32.Parse(linha[0]);
                not.Titulo= linha[1];
                not.Texto= linha[2];
                not.Imagem= linha[3];


                noticia.Add(not);
            }
            return noticia;
        }

        /// <summary>
        /// Linha do csv atualizada
        /// </summary>
        /// <param name="n">Noticia para ser atualizada</param>
        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n));
            RewriteCSV(PATH, linhas);
        }

         /// <summary>
        /// Exclui a noticia
        /// </summary>
        /// <param name="IdNoticia">Noticia que será excluida</param>
        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}