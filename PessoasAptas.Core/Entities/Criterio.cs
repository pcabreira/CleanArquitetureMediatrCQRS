using System.Collections.Generic;
using System.Drawing;

namespace PessoasAptas.Core.Entities
{
    public class Criterio : BaseEntity
    {
        public Criterio( string descricao)
        {
            Descricao = descricao;
        }

        public string Descricao { get; private set; }

        public List<PessoaCriterio> PessoaCriterios { get; private set; }
    }
}
