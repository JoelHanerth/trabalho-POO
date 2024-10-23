public abstract class Nordicos: Guerreiro{
    public Nordicos(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
    }
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo,int round){}
   
}