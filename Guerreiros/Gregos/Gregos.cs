public abstract class Gregos: Guerreiro{
    public Gregos( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){

    }

    public override int Energia{
        get { return energia; }
        set {
            if ( value > 100){ energia = 100; }
            else{ energia =  value; }
        }
    }
}
