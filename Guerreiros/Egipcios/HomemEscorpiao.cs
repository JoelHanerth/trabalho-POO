public class HomemEscorpiao: Egipcios{
    public HomemEscorpiao( string nome, int idade, double peso, List<Guerreiro> fila) : base(nome,idade,peso, fila){
        DanoAtaque = 20;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){

        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);

        // envenena o guerreiro atacado
        Guerreiro guerreiroInimigo = equipe2[filaInimigo][0];
        guerreiroInimigo.Envenenado = true;
    }
}