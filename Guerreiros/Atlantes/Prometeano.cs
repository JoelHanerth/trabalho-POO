public class Prometeano : Nordicos
{
    // Novos atributos para armazenar Lado e a fila do Prometeano
    private Lado ladoAtual;
    private int filaAtual;

    public Prometeano(int tipo, string nome, int idade, double peso) : base(tipo, nome, idade, peso)
    {
        DanoAtaque = 10;
        ladoAtual = null!;
        filaAtual = -1;
    }

    // Métodos para definir o lado e a fila onde o Prometeano está
    public void DefinirPosicao(Lado lado, int fila){
        ladoAtual = lado;
        filaAtual = fila;
    }

    public override void Dano(int dano)
    {
        base.Dano(dano);

        // Verifica se o Prometeano morreu e se ainda pode ser duplicado
        if (!EstaVivo() && EnergiaInicial > 1){
            Duplicar();
        }
    }

    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round)
    {
        base.Atacar(lado1, lado2, fila, filaInimigo, round);
    }

    public void Duplicar()
    {
        Console.WriteLine("Energia inicial do Prometeano: {0}", EnergiaInicial);

        // Cria dois descendentes do Prometeano original
        Prometeano prometeano1 = new Prometeano(1, Nome + "1", Idade, Peso);
        Prometeano prometeano2 = new Prometeano(1, Nome + "2", Idade, Peso);

        // Define a energia inicial e atual para 50% da energia original
        prometeano1.EnergiaInicial = EnergiaInicial / 2;
        prometeano2.EnergiaInicial = EnergiaInicial / 2;
        prometeano1.Energia = prometeano1.EnergiaInicial;
        prometeano2.Energia = prometeano2.EnergiaInicial;

        // Define a mesma posição (Lado e fila) para os descendentes
        prometeano1.DefinirPosicao(ladoAtual, filaAtual);
        prometeano2.DefinirPosicao(ladoAtual, filaAtual);

        // Imprime informações dos novos Prometeanos
        prometeano1.ImprimirGuerreiro();
        prometeano2.ImprimirGuerreiro();

        // Adiciona os descendentes ao final da fila de guerreiros
        ladoAtual[filaAtual].Add(prometeano1);
        ladoAtual[filaAtual].Add(prometeano2);
    }
}
