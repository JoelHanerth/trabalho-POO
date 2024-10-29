public class LoboDeFenris: Nordicos{
    private int danoAdicional = 8;
    private int danoInicial = 40;
    public LoboDeFenris( string nome, int idade, double peso, List<Guerreiro> fila) : base(nome,idade,peso, fila){
        DanoAtaque = danoInicial; 
    }

    private int calcularDanoAtaqueAdicional(List<Guerreiro> equipe){
        int dano = 0;
        for (int i = 1; i < equipe.Count; i++){
            if (equipe[i].GetType() == typeof(LoboDeFenris)){
                dano += danoAdicional;
            }
            else{ break; }
        }
        Console.WriteLine("DANO ADICIONAL{0}",dano);
        return dano;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){   
        DanoAtaque = DanoAtaque + calcularDanoAtaqueAdicional(equipe1[fila]);
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
        DanoAtaque = danoInicial;
    }

}