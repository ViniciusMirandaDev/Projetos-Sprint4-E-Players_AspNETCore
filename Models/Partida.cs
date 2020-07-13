using System;

namespace Projetos_Sprint4_E_Players_AspNETCore.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }
        public int IdEquipe1 { get; set; }
        public int IdEquipe2 { get; set; }
        public DateTime HorarioInicio { get; set; }
        
    }
}