
public class Configuracoes
{
    public const int TAMANHO_FILA = 4;
}


public static class Arena{

    private const int LADO1 = 0;
    private const int LADO2 = 1;


    private static int SortearFila(){
        Random random = new Random();
        int numeroSorteado = random.Next(0, 2);

        Console.WriteLine("NUMERO SORTEADO: {0}",numeroSorteado);
        return numeroSorteado;
    }

    private static void RemoverMortos(Lado lado){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
        // Remover todos os personagens com vida <= 0
        lado[i].RemoveAll(p => p.Energia <= 0);
        }
    }

    public static bool AlgumaListaTemElemento(Lado lado1){
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (lado1[i].Count > 0){ return true; }
        }
        return false;
    }




    // Método para comparar dois Guerreiros
    public static void MaisVelho(Lado lado1, Lado lado2){

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

    public static void MoverParaFinalFila(Lado lado){
        Guerreiro aux;
        for (int i = 0; i < 4; i++)
        {
            if (lado[i].Count > 0){
                aux = lado[i][0];
                lado[i].RemoveAt(0);
                lado[i].Add(aux);
            }          
            else{ Console.WriteLine("lista vazia"); }
        }
    } 


    private static void Ataques(Lado lado1, Lado lado2){
        // todos da primeira fila atacam
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            if (lado1[i].Count > 0){
                Guerreiro guerreiro = lado1[i][0];
                guerreiro.Atacar(lado1, lado2, i);
                RemoverMortos(lado2);
            }            
        }
    } 

    private static void Ringue(Lado lado1, Lado lado2){
 
        int primeiroAtaque = SortearFila();
        
        if (primeiroAtaque == LADO1){
            Ataques(lado1, lado2);
            Ataques(lado2, lado1);
        }
        else{
            Ataques(lado2, lado1);
            Ataques(lado1, lado2);
        }
      
    }

    public static void CampoBatalha(Lado lado1, Lado lado2){

        while (true){
            Ringue(lado1, lado2);
            RemoverMortos(lado1);
            RemoverMortos(lado2);

            MoverParaFinalFila(lado1);
            MoverParaFinalFila(lado2);

            if (!AlgumaListaTemElemento(lado1)){
                if (!AlgumaListaTemElemento(lado2)){
                    Console.WriteLine("EMPATE");
                    break;
                }
                else{
                    Console.WriteLine("Gregos e Nórdigos ganharam!");
                    break;
                }
            }

            if (!AlgumaListaTemElemento(lado2)){
                if (!AlgumaListaTemElemento(lado1)){
                    Console.WriteLine("EMPATE");
                    break;
                }
                else{
                    Console.WriteLine("Atlantes e Egípcios ganharam!");
                    break;
                }
            }
        }
        
    }

}




