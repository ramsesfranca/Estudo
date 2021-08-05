using RF.Estudo.Domain.Core.Exceptions;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Enums;
using RF.Estudo.Domain.ValueObjects;
using Xunit;

namespace RF.Estudo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Produto(string.Empty, "Jogue o melhor e mais vendido game de corrida desta geração.", 100, new Dimensoes(1, 1, 1), TipoProduto.Outras, false, new Categoria("Alimentos", "Alimentos"))
            );

            Assert.Equal("O campo Nome do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Console Xbox One S 1TB", string.Empty, 100, new Dimensoes(1, 1, 1), TipoProduto.Outras, false, new Categoria("Alimentos", "Alimentos"))
            );

            Assert.Equal("O campo Descricao do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Console Xbox One S 1TB", "Jogue o melhor e mais vendido game de corrida desta geração.", 0, new Dimensoes(1, 1, 1), TipoProduto.Outras, false, new Categoria("Alimentos", "Alimentos"))
            );

            Assert.Equal("O campo Valor do produto não pode se menor igual a 0", ex.Message);

            //ex = Assert.Throws<DomainException>(() =>
            //    new Produto("Console Xbox One S 1TB", "Jogue o melhor e mais vendido game de corrida desta geração.", 100, new Dimensoes(1, 1, 1), TipoProduto.Outras, false, null)
            //);

            //Assert.Equal("A Categoria do produto não pode estar vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() =>
                new Produto("Console Xbox One S 1TB", "Jogue o melhor e mais vendido game de corrida desta geração.", 100, new Dimensoes(0, 1, 1), TipoProduto.Outras, false, new Categoria("Alimentos", "Alimentos"))
            );

            Assert.Equal("O campo Altura não pode ser menor ou igual a 0", ex.Message);
        }
    }
}
