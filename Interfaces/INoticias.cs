using System.Collections.Generic;
using Projetos_Sprint4_E_Players_AspNETCore.Models;

namespace Projetos_Sprint4_E_Players_AspNETCore.Interfaces
{
    public interface INoticias
    {
        void Create(Noticias n);

        List<Noticias> ReadAll();

        void Update(Noticias n);

        void Delete(int IdNoticia);
    }
}