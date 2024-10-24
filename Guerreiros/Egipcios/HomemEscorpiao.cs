public class HomemEscorpiao: Egipcios{
    public HomemEscorpiao(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 20;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo, int round){

        base.Atacar(lado1, lado2, fila, filaInimigo, round);

        // envenena o guerreiro atacado
        Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
        guerreiroInimigo.Envenenado = true;
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("HomemEscorpiao: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}