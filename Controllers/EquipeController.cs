using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projetos_Sprint4_E_Players_AspNETCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Projetos_Sprint4_E_Players_AspNETCore.Controllers
{
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.ReadAll();
            return View();
        }
        /// <summary>
        /// Cadastra o Formulário
        /// </summary>
        /// <param name="form">Formulário</param>
        /// <returns>Retorna o Formulário na index de Equipe</returns>
        public IActionResult Cadastrar(IFormCollection form){
            
            Equipe equipe   = new Equipe();
            equipe.IdEquipe = Int32.Parse(form["IdEquipe"]); 
            equipe.Nome     = form["Nome"];
            equipe.Imagem   = form["Imagem"];

            equipeModel.Create(equipe);

            ViewBag.Equipes = equipeModel.ReadAll();
            return LocalRedirect("~/Equipe"); 

            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                equipe.Imagem   = file.FileName;
            }
            else
            {
                equipe.Imagem   = "padrao.png";
            }
            // Upload Final

            equipeModel.Create(equipe);
            ViewBag.Equipes = equipeModel.ReadAll();

            return LocalRedirect("~/Equipe");
        }
        
        [Route("[controller]/{id}")]

        public IActionResult Excluir(int id){
            equipeModel.Delete(id);
            return LocalRedirect("~/Equipe");
        }
    }
}
