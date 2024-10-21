public abstract class Gregos: Guerreiro{
    public Gregos(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){

    }
    
    public override void Atacar(){}
    

    public override int Energia{
        get { return energia; }
        set {
            if (energia + value > 100){ energia = 100; }
            else{ energia = energia + value; }
        }
    }
}
