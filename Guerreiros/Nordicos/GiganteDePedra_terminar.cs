public class GiganteDePedra: Nordicos{
    public GiganteDePedra(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 30;
        Energia = 300;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){

        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);      
    }

}