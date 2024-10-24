public class GiganteDePedra: Nordicos{
    public GiganteDePedra(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 30;
        Energia = 300;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){

        base.Atacar(lado1, lado2, fila, filaInimigo, round);      
    }

}