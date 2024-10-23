public class HomemEscorpiao: Egipcios{
    public HomemEscorpiao(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 20;
    }
        
    public override void Atacar(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2, int fila, int filaInimigo, int round){

        // int filaAtacado = IndiceAtacado(lado2, fila);
        if (filaInimigo != -1){
            Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
            guerreiroInimigo.Dano(DanoAtaque);
            Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);

            guerreiroInimigo.Envenenado = true;
        }
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("HomemEscorpiao: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}