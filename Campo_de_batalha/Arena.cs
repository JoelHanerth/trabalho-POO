
public class Configuracoes
{
    public const int TAMANHO_FILA = 4;
}



public static class Arena{

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
    
}


public class Ataques{
    
}




