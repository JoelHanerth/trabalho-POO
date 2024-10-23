
public abstract class Guerreiro {

    // atributos
    private string nome;
    private int idade, tipo;
    protected int energia;
    private int danoAtaque;
    private double peso;

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


    public int DanoAtaque{
        get { return danoAtaque; }
        set { danoAtaque = value; }
    }

    public virtual int Energia{
        get { return energia; }
        set{ energia = value; }
    }

    public void Dano(int dano) {
        Energia -= dano;
    }

    public void Curar(int cura) {
        Energia += cura;
    }

    public bool EstaVivo(){
        if (Energia <= 0 ){ return false; }
        else { return true; }
    }

    


    public abstract void ImprimirGuerreiro();
    public abstract void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round);
}
