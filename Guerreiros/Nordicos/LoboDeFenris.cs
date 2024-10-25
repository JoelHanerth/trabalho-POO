public class LoboDeFenris: Nordicos{
    private int danoAdicional = 8;
    private int danoInicial = 40;
    public LoboDeFenris(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = danoInicial; 
    }

    private int calcularDanoAtaqueAdicional(Equipe equipe, int fila){
        int dano = 0;
        for (int i = 1; i < equipe[fila].Count; i++)
        {
            if (equipe[fila][i].Tipo == equipe[fila][0].Tipo){
                dano += danoAdicional;
            }
            else{
                break;
            }
        }
        Console.WriteLine("DANO ADICIONAL{0}",dano);
        return dano;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        
        DanoAtaque = DanoAtaque + calcularDanoAtaqueAdicional(equipe1, fila);
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
        DanoAtaque = danoInicial;
    }

}