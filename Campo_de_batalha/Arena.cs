
public class Configuracoes
{
    public const int TAMANHO_FILA = 4;
}


public class Arena{
    private const int LADO1 = 0;
    private const int LADO2 = 1;
    private static Guerreiro? ultimoAtacante = null, ultimoInimigo = null;

    private Lado lado1, lado2;

    public Arena(Lado lado1, Lado lado2){
        this.lado1 = lado1; //equipe
        this.lado2 = lado2;
    }

    public Lado Lado1{
        get { return lado1; }
    }

    public Lado Lado2{
        get { return lado2; }
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

    private void RemoverMortos(Lado lado){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            // EstaVivo
        // Remover todos os personagens com vida <= 0
        lado[i].RemoveAll(p => p.Energia <= 0);
        }
    }

    public bool TemGuerreiro(Lado lado1){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (lado1[i].Count > 0){ return true; }
        }
        return false;
    }




    // Método para comparar dois Guerreiros
    public void MaisVelho(){

        Guerreiro? velho1 = lado1.MaiorIdade();
        Guerreiro? velho2 = lado2.MaiorIdade();

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

    public void MoverParaFinalFila(Lado lado){
        Guerreiro aux;
        for (int i = 0; i < 4; i++)
        {
            if (lado[i].Count > 0){
                aux = lado[i][0];
                lado[i].RemoveAt(0);
                lado[i].Add(aux);
            }
        }
    } 

    // retorna o indice de quem eu devo atacar
    // devo atacar quem está na minha frente - caso não tenha ninguem, pule pra proxima fila que contenha alguem
    private int IndiceAtacado(Lado lado2, int fila){
         for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (lado2[fila].Count > 0){
                return fila;
            }
            else{
                fila+=1;
                if (fila >= Configuracoes.TAMANHO_FILA){
                    fila = 0;
                }
            }        
        }
        return -1;
    } 


    private  void Ataques(Lado lado1, Lado lado2, int round){
        // todos da primeira fila atacam
        for (int filaAtacante = 0; filaAtacante < Configuracoes.TAMANHO_FILA; filaAtacante++){

            // verica se tem alguem naquela fila para atacar
            if (lado1[filaAtacante].Count > 0 && TemGuerreiro(lado2)){
                // procura o inimigo que será atacado

                int filaInimigo = IndiceAtacado(lado2, filaAtacante);

                Guerreiro guerreiroAtacante = lado1[filaAtacante][0];
                Guerreiro guerreiroInimigo = lado2[filaInimigo][0];
                // salva os dados dos ultimos combatentes
                UltimoAtacante = guerreiroAtacante;
                UltimoInimigo = guerreiroInimigo;

                // verifica se é guerreiro de pedra
                // if (guerreiroAtacante.GetType == )

                // ataque
                guerreiroAtacante.Atacar(lado1, lado2, filaAtacante, filaInimigo, round);

                RemoverMortos(lado1);
                RemoverMortos(lado2);
            }            
        }
    } 

    private void Ringue(){
 
        int primeiroAtaque = SortearFila();
        
        if (primeiroAtaque == LADO1){
            Ataques(lado1, lado2, 1);
            Ataques(lado2, lado1, 2);
        }
        else{
            Ataques(lado2, lado1, 1);
            Ataques(lado1, lado2, 2);
        }
      
    }

    public void CampoBatalha(){

        while (true){
            Ringue();
            RemoverMortos(lado1);
            RemoverMortos(lado2);

            MoverParaFinalFila(lado1);
            MoverParaFinalFila(lado2);

            if (!TemGuerreiro(lado1) || !TemGuerreiro(lado2)){
                break;
            }
        }
        
    }

}




