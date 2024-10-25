public class Argus: Nordicos{
    public Argus(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 0;
        Energia = 60;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        DanoAtaque = equipe2[filaInimigo][0].Energia; 
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
    }
}