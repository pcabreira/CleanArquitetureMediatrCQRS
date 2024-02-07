using Moq;
using PessoasAptas.Application.Queries.GetAllPessoas;
using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PessoasAptas.UnitTests.Application.Queries
{
    public class GetAllPessoasCommandHandlerTests
    {
        [Fact]
        public async Task ThreePessoasExist_Executed_ReturnThreePessoaViewModels()
        {
            // Arrange
            var pessoas = new List<Pessoa>
            {
                new Pessoa("Nome Do Teste 1", 10),
                new Pessoa("Nome Do Teste 2", 20),
                new Pessoa("Nome Do Teste 3", 30)
            };

            var pessoaRepositoryMock = new Mock<IPessoaRepository>();
            pessoaRepositoryMock.Setup(pr => pr.GetAllAsync().Result).Returns(pessoas);

            var getAllPessoasQuery = new GetAllPessoasQuery();
            var getAllPessoasQueryHandler = new GetAllPessoasQueryHandler(pessoaRepositoryMock.Object);

            // Act
            var pessoaViewModelList = await getAllPessoasQueryHandler.Handle(getAllPessoasQuery, new CancellationToken());

            // Assert
            Assert.NotNull(pessoaViewModelList);
            Assert.NotEmpty(pessoaViewModelList);
            Assert.Equal(pessoas.Count, pessoaViewModelList.Count);

            pessoaRepositoryMock.Verify(pr => pr.GetAllAsync().Result, Times.Once);
        }
    }
}
