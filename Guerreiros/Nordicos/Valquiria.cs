public class Valquiria: Nordicos{

    public Valquiria(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        danoAtaque = 20;
        recuperarVida = 20;
    }
        
    public override void Atacar(){
        Console.WriteLine("{0} atacou com dano de {1}", nome, danoAtaque);
    }
}