public class Prometeano : Atlantes
{
    // Novos atributos para armazenar Lado e a fila do Prometeano
    private int energiaInicial;

    public Prometeano( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
        DanoAtaque = 10;
        energiaInicial = Energia;
    }

    public int EnergiaInicial {
        get { return energiaInicial; }
        set { energiaInicial = value; }
    }
    

    

    public override void Dano(int dano){
        base.Dano(dano);

        // Verifica se o Prometeano morreu e se ainda pode ser duplicado
        if (!EstaVivo() && EnergiaInicial > 1){
            Duplicar();
        }
    }

    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
    }

    public void Duplicar(){
        Console.WriteLine("Energia inicial do Prometeano: {0}", EnergiaInicial);

        // Cria dois descendentes do Prometeano original
        Prometeano prometeano1 = new Prometeano(Nome + "1", Idade, Peso, EquipeAtual, FilaAtual);
        Prometeano prometeano2 = new Prometeano(Nome + "2", Idade, Peso, EquipeAtual, FilaAtual);

        // Define a energia inicial e atual para 50% da energia original
        prometeano1.EnergiaInicial = EnergiaInicial / 2;
        prometeano2.EnergiaInicial = EnergiaInicial / 2;
        prometeano1.Energia = prometeano1.EnergiaInicial;
        prometeano2.Energia = prometeano2.EnergiaInicial;


        // Imprime informações dos novos Prometeanos
        prometeano1.ImprimirGuerreiro();
        prometeano2.ImprimirGuerreiro();

        // Adiciona os descendentes ao final da fila de guerreiros
        EquipeAtual[FilaAtual].Add(prometeano1);
        EquipeAtual[FilaAtual].Add(prometeano2);
    }
}
