
public abstract class Guerreiro {

    // atributos
    protected string nome;
    protected int idade, tipo, energia;
    protected int danoAtaque, recuperarVida;
    protected double peso;

    // metodo construtor
    public Guerreiro(int tipo, string nome, int idade, double peso ) {
        this.nome = nome;
        this.idade = idade;
        this.peso = peso;
        this.tipo = tipo;
        this.energia = 100;

    }

    //get e set
    public string Nome{
        get { return nome; }
    }

    public int Idade {
        get { return idade; }
    }

    public double Peso {
        get { return peso; }
    }

    public int Tipo {
        get { return tipo; }
    }

    public virtual int Energia{
        get { return energia; }
        set{ energia = value; }
    }


    public void ImprimirGuerreiro() {
        Console.WriteLine("Tipo {0}: {1}, {2} anos, {3} kilos", Tipo, Nome, Idade, Peso);

    }

    public abstract void Atacar();
}
