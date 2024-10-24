public class LoboDeFenris: Nordicos{
    private int danoAdicional = 8;
    private int danoInicial = 40;
    public LoboDeFenris(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = danoInicial; 
    }

    private int calcularDanoAtaqueAdicional(Lado lado1, int fila){
        int dano = 0;
        for (int i = 1; i < lado1[fila].Count; i++)
        {
            if (lado1[fila][i].Tipo == lado1[fila][0].Tipo){
                dano += danoAdicional;
            }
            else{
                break;
            }
        }
        Console.WriteLine("DANO ADICIONAL{0}",dano);
        return dano;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        
        DanoAtaque = DanoAtaque + calcularDanoAtaqueAdicional(lado1, fila);
        base.Atacar(lado1, lado2, fila, filaInimigo, round);
        DanoAtaque = danoInicial;
    }

}