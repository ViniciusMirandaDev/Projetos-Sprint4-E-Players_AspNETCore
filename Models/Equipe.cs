using System;
using System.Collections.Generic;
using System.IO;
using Projetos_Sprint4_E_Players_AspNETCore.Interfaces;

namespace Projetos_Sprint4_E_Players_AspNETCore.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem  { get; set; }

        private const string PATH = "Database/equipe.csv";

        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }

        /// <summary>
        /// Gera uma nova equipe
        /// </summary>
        /// <param name="e">Nova equipe a ser criada</param>
        public void Create(Equipe e)
        {
            string[] linhas = { PrepararLinha(e)} ; 
            File.AppendAllLines(PATH, linhas);
        }

        /// <summary>
        /// Prepara a linha do csv
        /// </summary>
        /// <param name="e">Nova equipe a ser criada</param>
        /// <returns>Linha do csv formatada</returns>
        private string PrepararLinha(Equipe e)
        {
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }

        /// <summary>
        /// Exclui uma equipe
        /// </summary>
        /// <param name="IdEquipe">Equipe que será excluida</param>
        public void Delete(int IdEquipe)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        /// <summary>
        /// Lê a a lista do csv e organiza as informações
        /// </summary>
        /// <returns>Lista equipes</returns>
        public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        /// <summary>
        /// Atualiza o nosso csv
        /// </summary>
        /// <param name="e">Equipe a ser atualizada</param>
        public void Update(Equipe e)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(y => y.Split(";")[0] == e.IdEquipe.ToString());
            linhas.Add( PrepararLinha(e));
            RewriteCSV(PATH, linhas);
        }
    }
}