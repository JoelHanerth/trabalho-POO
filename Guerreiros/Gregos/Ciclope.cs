public class Ciclope: Gregos{
    public Ciclope(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 35;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila, int filaInimigo,int round){
        
        base.Atacar(lado1, lado2, fila, filaInimigo, round);

        if (round == 1){
            // move o inimigo pro final da fila
            try{
                Guerreiro aux = lado2[filaInimigo][0];
                lado2[filaInimigo].RemoveAt(0);
                lado2[filaInimigo].Add(aux);
            }
            catch{}
            
        }
    }
}