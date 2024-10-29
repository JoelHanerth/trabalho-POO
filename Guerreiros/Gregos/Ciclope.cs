public class Ciclope: Gregos{
    public Ciclope( string nome, int idade, double peso, List<Guerreiro> fila) : base(nome,idade,peso, fila){
        DanoAtaque = 35;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo,int round){
        
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);

        if (round == 1){
            // move o inimigo pro final da fila
            try{
                Guerreiro aux = equipe2[filaInimigo][0];
                equipe2[filaInimigo].RemoveAt(0);
                equipe2[filaInimigo].Add(aux);
            }
            catch{}
            
        }
    }
}