public class Prometeano : Nordicos
{
    // Novos atributos para armazenar Lado e a fila do Prometeano
    private Equipe equipeAtual;
    private int filaAtual;
    private int energiaInicial;

    public Prometeano(int tipo, string nome, int idade, double peso) : base(tipo, nome, idade, peso)
    {
        DanoAtaque = 10;
        equipeAtual = null!;
        filaAtual = -1;
        energiaInicial = Energia;

    }


    public int EnergiaInicial {
        get { return energiaInicial; }
        set { energiaInicial = value; }
    }

    // Métodos para definir o lado e a fila onde o Prometeano está
    public void DefinirPosicao(Equipe equipe, int fila){
        equipeAtual = equipe;
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

    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round)
    {
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
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
        prometeano1.DefinirPosicao(equipeAtual, filaAtual);
        prometeano2.DefinirPosicao(equipeAtual, filaAtual);

        // Imprime informações dos novos Prometeanos
        prometeano1.ImprimirGuerreiro();
        prometeano2.ImprimirGuerreiro();

        // Adiciona os descendentes ao final da fila de guerreiros
        equipeAtual[filaAtual].Add(prometeano1);
        equipeAtual[filaAtual].Add(prometeano2);
    }
}
