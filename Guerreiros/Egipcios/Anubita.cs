public class Anubita: Nordicos{
    public Anubita(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 15;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){

        // int filaAtacado = IndiceAtacado(lado2, fila);
        if (filaInimigo != -1){
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);

            // ataca o ultimo guerreiro da fila
            guerreiroInimigo = lado2[filaInimigo][lado2[filaInimigo].Count - 1];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);
        }
        base.Atacar(lado1, lado2, fila, filaInimigo, round);
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("ARGUS: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}