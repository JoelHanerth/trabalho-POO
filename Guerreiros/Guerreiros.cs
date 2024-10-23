
public abstract class Guerreiro {

    // atributos
    private string nome;
    private int idade, tipo;
    private int danoAtaque;
    private double peso;
    protected int energia;

    private bool envenenado;

    // metodo construtor
    public Guerreiro(int tipo, string nome, int idade, double peso ) {
        this.tipo = tipo;
        this.nome = nome;
        this.idade = idade;
        this.peso = peso;
        this.energia = 100;
        this.envenenado = false;
        this.danoAtaque = 0;

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

    public bool Envenenado{
        get { return envenenado; }
        set { envenenado = value; }
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

    public bool EstaEnvenenado(){
        return Envenenado;
    }
    


    public abstract void ImprimirGuerreiro();
    public virtual void Atacar(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2, int fila, int filaInimigo, int round){
        if (filaInimigo != -1){
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);
        }
        
        if (EstaEnvenenado()){ 
            Dano(5); 
            Console.WriteLine("{0} está envenenado -> vida atual: {1}", Nome, Energia);
        }
        // verificar slime;
            
    }
}
