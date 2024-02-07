using Moq;
using PessoasAptas.Application.Commands.CreatePessoa;
using PessoasAptas.Core.Entities;
using PessoasAptas.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace PessoasAptas.UnitTests.Application.Commands
{
    public class CreatePessoaCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnPessoaId()
        {
            // Arrange
            var pessoaRepository = new Mock<IPessoaRepository>();

            var createPessoaCommand = new CreatePessoaCommand
            {
                Nome = "Nome de Teste",
                Pontos = 10
            };

            var createPessoaCommandHandler = new CreatePessoaCommandHandler(pessoaRepository.Object);

            // Act
            var id = await createPessoaCommandHandler.Handle(createPessoaCommand, new CancellationToken());

            // Assert
            Assert.True(id >= 0);

            pessoaRepository.Verify(pr => pr.AddAsync(It.IsAny<Pessoa>()), Times.Once);
        }
    }
}
