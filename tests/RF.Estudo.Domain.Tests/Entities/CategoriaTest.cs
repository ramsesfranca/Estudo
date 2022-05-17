using RF.Estudo.Domain.Core.Exceptions;
using RF.Estudo.Domain.Entities;
using Xunit;

namespace RF.Estudo.Domain.Tests.Entities
{
    public class CategoriaTest
    {
        [Fact]
        public void Categoria_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Categoria(string.Empty, "Games")
            );

            Assert.Equal("O campo Nome da categoria não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Categoria("Games", string.Empty)
            );

            Assert.Equal("O campo Descrição da categoria não pode estar vazio", ex.Message);
        }
    }
}
