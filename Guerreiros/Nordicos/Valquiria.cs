public class Valquiria: Nordicos{
    private int recuperarVida = 20;
    public Valquiria(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 20;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){

        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
        
        // cura quem está atras dela
        if (equipe1[fila].Count > 1){
            equipe1[fila][1].Curar(recuperarVida);
            Console.WriteLine("{0} curou {1} com {2} de vida-> vida atual: {3}", Nome, equipe1[fila][1].Nome, recuperarVida,equipe1[fila][1].Energia);
        }
    }

}