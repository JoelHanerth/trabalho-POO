public abstract class Nordicos: Guerreiro{
    private static int contadorNordigos = 0;
    public Nordicos(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        contadorNordigos ++;
    }
    public override void Atacar(Lado lado1, Lado lado2, int fila){}
   
}