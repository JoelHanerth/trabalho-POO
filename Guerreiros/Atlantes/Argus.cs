public class Argus: Nordicos{
    public Argus(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 0;
        Energia = 60;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){

        // int filaAtacado = IndiceAtacado(lado2, fila);
        if (filaInimigo != -1){
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Energia = 0;
            Console.WriteLine("{0} atacou {1} com dano MÁXIMO -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);
        }
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("ARGUS: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}