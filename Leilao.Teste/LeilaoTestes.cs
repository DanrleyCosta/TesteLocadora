using System;
using Xunit;
using SistemaDeLeilao;

namespace Leilao.Teste
{
    public class LeilaoTestes
    {
        [Fact]
        public void LeilaoComTresClientes()
        {
            var leilao = new SistemaDeLeilao.Leilao("Van Gogh");

            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            var beltrano = new Interessada("Beltrano", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);
            leilao.RecebeLance(beltrano, 1400);

            leilao.TerminaPregao();

            var valorEsperado = 1400;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
            Assert.Equal(beltrano, leilao.Ganhador.Cliente);
        }
        [Fact]
        public void LeilaoComVariosLances()
        {
            // Arranje - entrada
            var leilao = new SistemaDeLeilao.Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 800);
            leilao.RecebeLance(maria, 900);
            leilao.RecebeLance(fulano, 1000);

            // Act - verifica o ganhador
            leilao.TerminaPregao();

            //Assert (Não precisamos saber qual e a expectativa)
            var valorEsperado = 1000;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        [Fact]
        public void LeilaoComApenasUmLance()
        {
            // Arranje - entrada
            var leilao = new SistemaDeLeilao.Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            leilao.RecebeLance(fulano, 800);

            // Act - verifica o ganhador
            leilao.TerminaPregao();

            //Assert (Não precisamos saber qual e a expectativa)
            var valorEsperado = 800;
            var valorObtido = leilao.Ganhador.Valor;
            Assert.Equal(valorEsperado, valorObtido);
        }

        //[Theory]
        //[InlineData] (1000, new double[] { 800, 900, 1000, 1200 })]
        //[InlineData] (1000, new double[] { 800, 900, 1000, 990 })]
        //[InlineData] (800, new double[] { 800 })]
        //public void LeilaoComVariosLancesRED(double valorEsperado, double[] ofertas)
        //{
        //    var leilao = new SistemaDeLeilao.Leilao("Van Gogh");
        //    var fulano = new Interessada("Fulano", leilao);
        
        //    foreach (var valor in ofertas)
        //    {
        //        leilao.RecebeLance(fulano, valor);
        //    }
        
        //    leilao.TerminaPregao();
        
        //    var valorObtido = leilao.Ganhador.Valor;
        //    Assert.Equal(valorEsperado, valorObtido);
        //}
    }
}
