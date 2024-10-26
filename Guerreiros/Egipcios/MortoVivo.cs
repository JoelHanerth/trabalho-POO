public class MortoVivo: Mumia{
    public MortoVivo( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
        DanoAtaque = 5;
    }
      
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
    }
}