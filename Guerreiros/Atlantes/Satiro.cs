public class Satiro: Nordicos{
    public Satiro(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 10;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){

        // ataca todo mundo da fila
        for (int i = 0; i < lado2[filaInimigo].Count; i++)
        {
            base.Atacar(lado1, lado2, fila, i, round);
        }

    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Satiro: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}