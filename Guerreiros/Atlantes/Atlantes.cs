public abstract class Atlantes: Guerreiro{
    public Atlantes(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
    }
    public override void Atacar(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2, int fila, int filaInimigo, int round){}
   
}