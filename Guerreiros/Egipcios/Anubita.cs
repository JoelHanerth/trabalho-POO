public class Anubita: Nordicos{
    public Anubita(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        DanoAtaque = 15;
    }
        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){

        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);

        // ataca o ultimo guerreiro da fila
        Guerreiro guerreiroInimigo = equipe2[filaInimigo][equipe2[filaInimigo].Count - 1];
        guerreiroInimigo.Dano(DanoAtaque);
        Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", Nome, guerreiroInimigo.Nome, DanoAtaque,guerreiroInimigo.Energia);

    }
}