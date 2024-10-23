public class LoboDeFenris: Nordicos{
    private int danoAdicional = 8;
    public LoboDeFenris(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 40; 
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
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int round){

        int filaAtacado = IndiceAtacado(lado2, fila);

        if (filaAtacado != -1){
            Guerreiro guerreiroInimigo = lado2[filaAtacado][0];
            // calcula ataque adiconal
            int dano = DanoAtaque+calcularDanoAtaqueAdicional(lado1, fila);
            guerreiroInimigo.Dano(dano);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, dano,guerreiroInimigo.Energia);
        }
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Lobo de Fenris: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}