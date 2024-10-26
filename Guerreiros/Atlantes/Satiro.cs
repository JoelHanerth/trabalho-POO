public class Satiro: Atlantes{
    public Satiro( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
        DanoAtaque = 10;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        // ataca todo mundo da fila
        for (int i = 0; i < equipe2[filaInimigo].Count; i++){
            base.Atacar(equipe1, equipe2, fila, i, round);
        }
    }
}