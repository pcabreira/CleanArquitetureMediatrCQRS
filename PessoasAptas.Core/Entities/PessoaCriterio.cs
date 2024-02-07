using System.Collections.Generic;
using System.Drawing;

namespace PessoasAptas.Core.Entities
{
    public class PessoaCriterio : BaseEntity
    {
        public PessoaCriterio(int idPessoa,
                              int idCriterio,
                              int valor)
        {
            IdPessoa = idPessoa;
            IdCriterio = idCriterio;
            Valor = valor;
        }

        public int IdPessoa { get; private set; }
        public int IdCriterio { get; private set; }
        public int Valor { get; private set; }

        public Pessoa Pessoa { get; private set; }
        public Criterio Criterio { get; private set; }
    }
}
