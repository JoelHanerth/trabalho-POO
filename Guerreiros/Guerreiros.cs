
public abstract class Guerreiro {

    // atributos
    private string nome;
    private int idade, tipo;
    private int danoAtaque;
    private double peso;
    protected int energia;
    private int energiaInicial;
    

    private bool envenenado;

    // metodo construtor
    public Guerreiro(int tipo, string nome, int idade, double peso ) {
        this.tipo = tipo;
        this.nome = nome;
        this.idade = idade;
        this.peso = peso;
        this.energia = 100;
        this.energiaInicial = energia;
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

    public int EnergiaInicial {
        get { return energiaInicial; }
        set { energiaInicial = value; }
    }

    
    public virtual void Dano(int dano) {
        Energia -= dano;
    }

    public void Curar(int cura) {
        Energia += cura;
    }

    // verificar prometeano
    public bool EstaVivo(){
        if (Energia <= 0 ){ return false; }
        else { return true; }
    }


    public void VerificarVeneno(){
        // Se o guerreiro atacante está envenenado, ele sofre dano adicional
        if (Envenenado){ 
            Dano(5); 
            Console.WriteLine("{0} está envenenado -> vida atual: {1}", Nome, Energia);
        }
    }
      
    public virtual void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        try{
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} {1} atacou {2} {3} com dano de {4} -> vida restante: {5}", this ,Nome, guerreiroInimigo.GetType() ,guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);
        }
        catch{}
    }

    public void ImprimirGuerreiro(){
        Console.WriteLine("{0}: {1}, {2} anos, {3} kilos, energia {4}", this, Nome, Idade, Peso, Energia);
    }
}
