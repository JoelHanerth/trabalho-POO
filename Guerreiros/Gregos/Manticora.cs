public class Manticora: Gregos{
    private int danoAtaqueBase = 30;
    private int danoAtaqueProximo = 15;

    public Manticora( string nome, int idade, double peso,List<Guerreiro> fila) : base(nome,idade,peso, fila){
        DanoAtaque = danoAtaqueBase;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        for (int i = -1; i <= 1; i++)  {
            if (i == 0) { DanoAtaque = danoAtaqueBase; }
            else { DanoAtaque = danoAtaqueProximo; }

            base.Atacar(equipe1, equipe2, fila, filaInimigo+i, round);
        }


      
    }
}