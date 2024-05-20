using System;

namespace SistemaDeLeilao
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arranje - entrada
            var leilao = new Leilao("Van Gogh");
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

            if (valorEsperado == valorObtido)
            {
                Console.WriteLine("TESTE OK");
            }
            else
            {
                Console.WriteLine("TESTE FALHOU");
            }
            Console.ReadKey();
        }
    }
}
