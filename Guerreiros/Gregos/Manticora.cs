public class Manticora: Gregos{
    private int danoAtaqueProximo = 15;
    public Manticora(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 30;
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Manticorea: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        
        // int filaAtacado = IndiceAtacado(lado2, fila);

        if (filaInimigo != -1){
            
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);

            try{
                guerreiroInimigo = lado2[filaInimigo-1][0];
                guerreiroInimigo.Dano(danoAtaqueProximo);
                Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, danoAtaqueProximo,guerreiroInimigo.Energia);
            }catch{}

            try{
                guerreiroInimigo = lado2[filaInimigo-1][0];
                guerreiroInimigo.Dano(danoAtaqueProximo);
                Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, danoAtaqueProximo,guerreiroInimigo.Energia);
            }catch{}

            
        }
        base.Atacar(lado1, lado2, fila, filaInimigo, round);
    }
}