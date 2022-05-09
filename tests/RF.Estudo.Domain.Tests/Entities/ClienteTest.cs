using RF.Estudo.Domain.Core.Exceptions;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.ValueObjects;
using System;
using Xunit;

namespace RF.Estudo.Domain.Tests.Entities
{
    public class ClienteTest
    {
        [Fact]
        public void Cliente_Validar_ValidacoesDevemRetornarExceptions()
        {
            // Arrange & Act & Assert

            var ex = Assert.Throws<DomainException>(() =>
                new Cliente(string.Empty, "421981726", new Localizacao("Teste 1", "Teste 1", "Teste 1", "Teste 1"), new DateTime(2000, 1, 1), null));

            Assert.Equal("O campo Nome do Cliente não pode estar vazio", ex.Message);
        }
    }
}
