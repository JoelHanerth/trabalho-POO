public abstract class Gregos: Guerreiro{
    public Gregos( string nome, int idade, double peso, List<Guerreiro> fila) : base(nome,idade,peso, fila){

    }

    public override int Energia{
        get { return energia; }
        set {
            if ( value > 100){ energia = 100; }
            else{ energia =  value; }
        }
    }
}
