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

        public void Create(Noticias n)
        {
            string[] linhas = { PrepararLinha(n)} ; 
            File.AppendAllLines(PATH, linhas);
        }

        private string PrepararLinha(Noticias n)
        {
            return $"{n.IdNoticia};{n.Titulo};{n.Texto};{n.Imagem}";
        }


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

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add( PrepararLinha(n));
            RewriteCSV(PATH, linhas);
        }

        public void Delete(int IdNoticia)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdNoticia.ToString());
            RewriteCSV(PATH, linhas);
        }
    }
}