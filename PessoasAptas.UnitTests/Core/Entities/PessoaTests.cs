using PessoasAptas.Core.Entities;
using Xunit;

namespace PessoasAptas.UnitTests.Core.Entities
{
    public class PessoaTests
    {
        [Fact]
        public void TestIfPessoaStartWorks()
        {
            var pessoa = new Pessoa("Nome De Teste", 10);

            Assert.NotNull(pessoa.Nome);
            Assert.NotEmpty(pessoa.Nome);

            Assert.True(pessoa.Pontos.GetType() == typeof(int));
            Assert.False(pessoa.Pontos.GetType() == typeof(string));
        }
    }
}
