public abstract class Gregos: Guerreiro{
    public Gregos(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){

    }
    
    public override void Atacar(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2, int fila, int filaInimigo, int round){}
    

    public override int Energia{
        get { return energia; }
        set {
            if ( value > 100){ energia = 100; }
            else{ energia =  value; }
        }
    }
}
