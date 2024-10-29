public abstract class Guerreiro {

    // Atributos
    private string nome;
    private int idade;
    private int danoAtaque;
    private double peso;
    protected int energia;
    private bool envenenado;
    // private Equipe equipeAtual;
    private List<Guerreiro> fila;

    // Construtor
    public Guerreiro(string nome, int idade, double peso, List<Guerreiro> fila) {
        this.nome = nome;
        this.idade = idade;
        this.peso = peso;
        this.fila = fila;
        this.energia = 100;
        this.envenenado = false;
        this.danoAtaque = 0;

        Console.WriteLine("{0} {1} criado", this, Nome);
        ImprimirGuerreiro();
    }

    // Propriedades get e set
    public string Nome {
        get { return nome; }
    }

    public int Idade {
        get { return idade; }
    }

    public double Peso {
        get { return peso; }
    }

    public bool Envenenado {
        get { return envenenado; }
        set { envenenado = value; }
    }

    public int DanoAtaque {
        get { return danoAtaque; }
        set { danoAtaque = value; }
    }

    // public Equipe EquipeAtual {
    //     get { return equipeAtual; }
    // }

    public List<Guerreiro> Fila {
        get { return fila; }
    }

    public virtual int Energia {
        get { return energia; }
        set { energia = value; }
    }

    // Métodos

    public virtual void Dano(int dano) {
        Energia -= dano;
    }

    public void Curar(int cura) {
        Energia += cura;
    }

    public bool EstaVivo() {
        return Energia > 0;
    }

    public void VerificarVeneno() {
        if (Envenenado) { 
            Dano(5); 
            Console.WriteLine("{0} está envenenado -> vida atual: {1}", Nome, Energia);
        }
    }

    public virtual void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round) {
        try {
            Guerreiro guerreiroInimigo = equipe2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} {1} atacou {2} {3} com dano de {4} -> vida restante: {5}", this, Nome, guerreiroInimigo.GetType(), guerreiroInimigo.Nome, DanoAtaque, guerreiroInimigo.Energia);
        } 
        catch {
            // Exceção silenciosa para tratamento de ataque inválido
        }
    }

    public void ImprimirGuerreiro() {
        Console.WriteLine("{0}: {1}, {2} anos, {3} kilos, energia {4}", this, Nome, Idade, Peso, Energia);
    }
}
