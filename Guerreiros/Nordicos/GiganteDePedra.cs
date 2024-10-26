public class GiganteDePedra : Nordicos{
    public bool Atacou { get; set; } = false; // Marca se o gigante atacou

    public GiganteDePedra( string nome, int idade, double peso, Equipe equipe, int fila) : base(nome,idade,peso, equipe, fila){
        DanoAtaque = 30;
        Energia = 300;
    }
    
    public override void Atacar(Equipe equipe1, Equipe equipe2, int fila, int filaInimigo, int round){
        // Atacante só pode atacar se não tiver sido atacado na rodada anterior
        Atacou = true; // Marca que o gigante atacou
        base.Atacar(equipe1, equipe2, fila, filaInimigo, round);
    }
}
