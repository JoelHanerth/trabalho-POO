public class Hidra: Gregos{
    private int danoAdicional = 5;
    // private int cura;
    public Hidra( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
        DanoAtaque = 50;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);

        // caso ela tenha matado o guerreiro - aumenta o dano e se cura
        Guerreiro guerreiroInimigo = equipe2[filaInimigo][0];
        if (!guerreiroInimigo.EstaVivo()){
            DanoAtaque += danoAdicional;
            Curar(20);
        }

    }
}