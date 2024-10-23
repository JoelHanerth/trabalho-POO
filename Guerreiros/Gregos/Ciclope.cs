public class Ciclope: Gregos{
    public Ciclope(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 35;
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Ciclope: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
        
    public override void Atacar(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2, int fila, int filaInimigo,int round){
        
        // int filaAtacado = IndiceAtacado(lado2, fila);

        if (filaInimigo != -1){
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);
        }

        if (round == 1){
            // move o inimigo pro final da fila
            try{
                Guerreiro aux = lado2[fila][0];
                lado2[fila].RemoveAt(0);
                lado2[fila].Add(aux);
            }
            catch{}
            
        }
    }
}