public class Prometeano: Nordicos{
    
    public Prometeano(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 10;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        base.Atacar(lado1, lado2, fila, filaInimigo, round);    
    }


    

    public void Duplicar(Lado lado, int fila){

        Console.WriteLine("INCIAL{0}",EnergiaInicial);

        Prometeano prometeano1 = new Prometeano(1, Nome+"1", Idade, Peso);
        Prometeano prometeano2 = new Prometeano(1, Nome+"2", Idade, Peso);

        prometeano1.EnergiaInicial = EnergiaInicial / 2;
        prometeano2.EnergiaInicial = EnergiaInicial / 2;

        prometeano1.Energia = prometeano1.EnergiaInicial;
        prometeano2.Energia = prometeano2.EnergiaInicial;

        prometeano1.ImprimirGuerreiro();
        prometeano2.ImprimirGuerreiro();


        lado[fila].Add(prometeano1);
        lado[fila].Add(prometeano2);
    }



    public override void ImprimirGuerreiro(){
        Console.WriteLine("Prometeano: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}