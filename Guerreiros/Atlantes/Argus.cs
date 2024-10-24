public class Argus: Nordicos{
    public Argus(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 0;
        Energia = 60;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        DanoAtaque = lado2[filaInimigo][0].Energia; 
        base.Atacar(lado1, lado2, fila, filaInimigo, round);
    }
}