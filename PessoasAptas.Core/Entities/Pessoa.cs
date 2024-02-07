using System.Collections.Generic;

namespace PessoasAptas.Core.Entities
{
    public class Pessoa : BaseEntity
    {
        public Pessoa(string nome,
                      int pontos)
        {
            Nome = nome;
            Pontos = pontos;
        }

        public string Nome { get; private set; }
        public int Pontos { get; private set; }

        public List<PessoaCriterio> PessoaCriterios { get; private set; }

        public void Update(int pontos)
        {
            Pontos = pontos;
        }
    }
}
