public class Valquiria: Nordicos{
    private int recuperarVida = 20;
    public Valquiria(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 20;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){

        base.Atacar(lado1, lado2, fila, filaInimigo, round);
        
        // cura quem está atras dela
        if (lado1[fila].Count > 1){
            lado1[fila][1].Curar(recuperarVida);
            Console.WriteLine("{0} curou {1} com {2} de vida-> vida atual: {3}", Nome, lado1[fila][1].Nome, recuperarVida,lado1[fila][1].Energia);
        }
    }

}