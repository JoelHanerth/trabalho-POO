public class Mumia: Egipcios{
    public Mumia( string nome, int idade, double peso, List<Guerreiro> fila) : base(nome,idade,peso, fila){
        DanoAtaque = 50;
    }

     public override void Dano(int dano){
        base.Dano(dano);
        if (!EstaVivo()){ Invocar(); }}


        
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);

        Guerreiro guerreiroInimigo = equipe2[filaInimigo][0];
        // caso tenha matado o inimigo, crie um morto vivo
        if (!guerreiroInimigo.EstaVivo()){
            // equipe1[fila].Insert(0, new MortoVivo(guerreiroInimigo.Nome, guerreiroInimigo.Idade, guerreiroInimigo.Peso, EquipeAtual, FilaAtual));
            Fila.Add(new MortoVivo(guerreiroInimigo.Nome, guerreiroInimigo.Idade, guerreiroInimigo.Peso, Fila));
        }
    }

    private void Invocar(){
        for (int i = 0; i < 4; i++){
            Fila.Add(new Anubita(Nome, 0, 60, Fila));
        }
    }
}