public class Mumia: Egipcios{
    public Mumia( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
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
            equipe1[fila].Add(new MortoVivo(guerreiroInimigo.Nome, guerreiroInimigo.Idade, guerreiroInimigo.Peso, EquipeAtual, FilaAtual));
        }
    }

    private void Invocar(){
        for (int i = 0; i < 4; i++){
            EquipeAtual[FilaAtual].Add(new Anubita(Nome, 0, 60, EquipeAtual, FilaAtual));
        }
    }
}