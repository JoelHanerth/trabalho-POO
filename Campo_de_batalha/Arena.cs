
public class Configuracoes{
    public const int TAMANHO_FILA = 4;
}

public class Arena{
    private const int EQUIPE1 = 0;
    private const int EQUIPE2 = 1;
    private static Guerreiro? ultimoAtacante = null, ultimoInimigo = null;

    private Equipe equipe1, equipe2;

    public Arena(Equipe equipe1, Equipe equipe2){
        this.equipe1 = equipe1;
        this.equipe2 = equipe2;
    }

    public Equipe Equipe1{
        get { return equipe1; }
    }

    public Equipe Equipe2{
        get { return equipe2; }
    }

    public static Guerreiro? UltimoAtacante{
        get { return ultimoAtacante; }
        set { ultimoAtacante = value; }
    }

    public static Guerreiro? UltimoInimigo{
        get { return ultimoInimigo; }
        set { ultimoInimigo = value; }
    }

    private int SortearFila(){
        Random random = new Random();
        int numeroSorteado = random.Next(0, 2);
        Console.WriteLine("NUMERO SORTEADO: {0}",numeroSorteado);
        return numeroSorteado;
    }

    private void RemoverMortos(Equipe equipe){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            equipe[i].RemoveAll(p => p.Energia <= 0);
        }
    }

    public bool TemGuerreiro(Equipe equipe){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            if (equipe[i].Count > 0){ return true; }
        }
        return false;
    }




    // Método para comparar dois Guerreiros
    public void MaisVelho(){
        Guerreiro? velho1 = equipe1.MaiorIdade();
        Guerreiro? velho2 = equipe2.MaiorIdade();

        // Verifica se o primeiro guerreiro é nulo
        if (velho1 == null && velho2 == null){
            Console.WriteLine("Não existem Guerreiros");
            return;
        }

        Console.WriteLine("\nMais velho: ");
        if (velho1 == null){
            velho2?.ImprimirGuerreiro();
            return;
        }
        if (velho2 == null){
            velho1.ImprimirGuerreiro();
            return;
        }

        Guerreiro maisVelho = velho1.Idade > velho2.Idade ? velho1 : velho2;    
        maisVelho.ImprimirGuerreiro();

    }

    public void MoverParaFinalFila(Equipe equipe){
        Guerreiro aux;
        for (int i = 0; i < 4; i++){
            if (equipe[i].Count > 0){
                aux = equipe[i][0];
                equipe[i].RemoveAt(0);
                equipe[i].Add(aux);
            }
        }
    } 

    // retorna o indice de quem eu devo atacar
    // devo atacar quem está na minha frente - caso não tenha ninguem, pule pra proxima fila que contenha alguem
    private int IndiceAtacado(Equipe equipe, int fila){
        int x = ObterUltimoGiganteDePedra(equipe);
        if (x != -1){ return x; }

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            if (equipe[fila].Count > 0){
                return fila;
            } else {
                fila = (fila + 1) % Configuracoes.TAMANHO_FILA;
            }
        }
        return -1;
    }

private int ObterUltimoGiganteDePedra(Equipe equipe) {
    for (int i = Configuracoes.TAMANHO_FILA - 1; i >= 0; i--) { 
        // Verifica se a fila tem guerreiros e se o primeiro é um Gigante de Pedra
        if (equipe[i].Count > 0 && equipe[i][0] is GiganteDePedra) {
            return i;
        }
    }
    return -1; // Retorna -1 se não encontrar nenhum Gigante de Pedra
}

// Reseta o estado dos Gigantes de Pedra no início da rodada
private void ResetarEstadoGigantes(Equipe equipe){
    for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
        if (equipe[i].Count >0 && equipe[i][0] is GiganteDePedra gigante){
            gigante.Atacou = false; // Reseta a marcação
        }
    }
}


private void Ataques(Equipe equipe1, Equipe equipe2, int round) {
    Console.WriteLine();
    

    // todos da primeira fila atacam
    for (int filaAtacante = 0; filaAtacante < Configuracoes.TAMANHO_FILA; filaAtacante++) {
        if (equipe1[filaAtacante].Count > 0 && TemGuerreiro(equipe2)) {
            
            int filaInimigo = IndiceAtacado(equipe2, filaAtacante);
            
            Guerreiro guerreiroAtacante = equipe1[filaAtacante][0];
            Guerreiro guerreiroInimigo = equipe2[filaInimigo][0];
            UltimoAtacante = guerreiroAtacante;
            UltimoInimigo = guerreiroInimigo;

            // Ataque e verificação de veneno
            guerreiroAtacante.Atacar(equipe1, equipe2, filaAtacante, filaInimigo, round);
            guerreiroAtacante.VerificarVeneno();

            // Remover mortos
            RemoverMortos(equipe1);
            RemoverMortos(equipe2);
        }
    }
    if (round == 2){ ResetarEstadoGigantes(equipe1); }
}



    private void Ringue(){
        int primeiroAtaque = SortearFila();
        if (primeiroAtaque == EQUIPE1){
            Ataques(equipe1, equipe2, 1);
            Ataques(equipe2, equipe1, 2);
        }
        else{
            Ataques(equipe2, equipe1, 1);
            Ataques(equipe1, equipe2, 2);
        }  
    }

    public void CampoBatalha(){
        while (true){
            Ringue();
            RemoverMortos(equipe1);
            RemoverMortos(equipe2);

            MoverParaFinalFila(equipe1);
            MoverParaFinalFila(equipe2);

            if (!TemGuerreiro(equipe1) || !TemGuerreiro(equipe2)){
                break;
            }
        }   
    }
}




