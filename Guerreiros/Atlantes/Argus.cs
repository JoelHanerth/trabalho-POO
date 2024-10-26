public class Argus: Atlantes{
    public Argus( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
        Energia = 60;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        DanoAtaque = equipe2[filaInimigo][0].Energia; //toda a vida do adversario
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
    }
}