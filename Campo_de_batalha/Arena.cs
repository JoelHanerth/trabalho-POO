
public class Configuracoes
{
    public const int TAMANHO_FILA = 4;
}


public static class Arena{

    private const int LADO1 = 0;
    private const int LADO2 = 1;

    private static Guerreiro? ultimoAtacante = null, ultimoInimigo = null;

    public static Guerreiro? UltimoAtacante{
        get { return ultimoAtacante; }
        set { ultimoAtacante = value; }
    }

    public static Guerreiro? UltimoInimigo{
        get { return ultimoInimigo; }
        set { ultimoInimigo = value; }
    }



    private static int SortearFila(){
        Random random = new Random();
        int numeroSorteado = random.Next(0, 2);

        Console.WriteLine("NUMERO SORTEADO: {0}",numeroSorteado);
        return numeroSorteado;
    }

    private static void RemoverMortos(List<Guerreiro>[] lado){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
        // Remover todos os personagens com vida <= 0
        lado[i].RemoveAll(p => p.Energia <= 0);
        }
    }

    public static bool TemGuerreiro(List<Guerreiro>[] lado1){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (lado1[i].Count > 0){ return true; }
        }
        return false;
    }




    // Método para comparar dois Guerreiros
    public static void MaisVelho(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2){

        Guerreiro? velho1 = Lado.MaiorIdade(lado1);
        Guerreiro? velho2 = Lado.MaiorIdade(lado2);

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

    public static void MoverParaFinalFila(List<Guerreiro>[] lado){
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
    private static int IndiceAtacado(List<Guerreiro>[] lado2, int fila){
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


    private static void Ataques(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2, int round){
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

                // ataque
                guerreiroAtacante.Atacar(lado1, lado2, filaAtacante, filaInimigo, round);
                guerreiroAtacante.EstaEnvenenado();
                RemoverMortos(lado2);
            }            
        }
    } 

    private static void Ringue(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2){
 
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

    public static void CampoBatalha(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2){

        while (true){
            Ringue(lado1, lado2);
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




