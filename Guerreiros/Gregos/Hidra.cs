public class Hidra: Gregos{
    private int danoAdicional = 5;
    // private int cura;
    public Hidra(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 50;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){
        
        base.Atacar(lado1, lado2, fila, filaInimigo, round);

        // caso ela tenha matado o guerreiro - aumenta o dano e se cura
        Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
        if (!guerreiroInimigo.EstaVivo()){
            DanoAtaque += danoAdicional;
            Curar(20);
        }

    }
}