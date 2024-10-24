public class Manticora: Gregos{
    private int danoAtaqueBase = 30;
    private int danoAtaqueProximo = 15;

    public Manticora(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = danoAtaqueBase;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        // base.Atacar(lado1, lado2, fila, filaInimigo, round);
        // ataca as pessoas da frente e do lado
        for (int i = -1; i <= 1; i++)  
        {
            if (i == 0) { DanoAtaque = danoAtaqueBase; }
            else { DanoAtaque = danoAtaqueProximo; }

            base.Atacar(lado1, lado2, fila, filaInimigo+i, round);
        }


      
    }
}