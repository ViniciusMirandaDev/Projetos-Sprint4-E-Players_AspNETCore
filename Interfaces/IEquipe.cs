using System.Collections.Generic;
using Projetos_Sprint4_E_Players_AspNETCore.Models;

namespace Projetos_Sprint4_E_Players_AspNETCore.Interfaces
{
    public interface IEquipe
    {
        void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int IdEquipe);
    }
}