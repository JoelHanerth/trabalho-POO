public class Satiro: Nordicos{
    public Satiro(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 10;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int round){

        int filaAtacado = IndiceAtacado(lado2, fila);
        if (filaAtacado != -1){
            for (int i = 0; i < lado2[filaAtacado].Count; i++)
            {
                Guerreiro guerreiroInimigo = lado2[filaAtacado][i];
                guerreiroInimigo.Dano(DanoAtaque);
                Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);
            }
            
        }
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Satiro: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}