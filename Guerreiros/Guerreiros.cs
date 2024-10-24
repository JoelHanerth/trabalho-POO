
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

    public void VerificarVeneno(){
        // Se o guerreiro atacante está envenenado, ele sofre dano adicional
        if (EstaEnvenenado()){ 
            Dano(5); 
            Console.WriteLine("{0} está envenenado -> vida atual: {1}", Nome, Energia);
        }
    }
    
    public void VerificarPrometeano(Guerreiro guerreiroInimigo, Lado lado, int filaInimigo){
        // por estar aqui, pode haver prometeanos que morreram e não foram dupilcados (porque tem ataques especificso dentro de cada tipo)
        if (!guerreiroInimigo.EstaVivo() && guerreiroInimigo is Prometeano && guerreiroInimigo.energiaInicial>1) {
            // devo criar duas copias do objeto mantico com metade da sua vida original
            ((Prometeano)guerreiroInimigo).Duplicar(lado, filaInimigo);
            Console.WriteLine("{0} foi duplicado!", guerreiroInimigo.Nome);
        }
    }

    
    public virtual void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        try{
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);

            // por estar aqui, pode haver prometeanos que morreram e não foram dupilcados (porque tem ataques especificso dentro de cada tipo)
            VerificarPrometeano(guerreiroInimigo, lado2, filaInimigo);
        }
        catch{}
        
    
    }

    public abstract void ImprimirGuerreiro();
}
