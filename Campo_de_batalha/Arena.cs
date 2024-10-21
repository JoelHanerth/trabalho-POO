public class Configuracoes
{
    public const int TAMANHO_FILA = 4;
}



public static class Arena{

    public static void moverParaFinalFila(Lado lado){
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


public class Lado{

    private List<Guerreiro>[] ListaLado = new List<Guerreiro>[Configuracoes.TAMANHO_FILA];

    public Lado(string endereco){
        
        // procura o endereço dos arquivos que estão naquela pasta
        string[] files = Directory.GetFiles(endereco);

        for (int i = 0; i < files.Length; i++) {
            // inicializa uma lista da posição dos vetores
            ListaLado[i] = new List<Guerreiro>();

            // retorna lista separada por linha
            string[] Guerreiros = File.ReadAllLines(files[i]);

            for (int k = 0; k < Guerreiros.Length; k++){
                // retorna lista das palavras daquela linha
                string[] Guerreiro = Guerreiros[k].Split(' ');

                // converte o tipo das variaveis
                int tipo = int.Parse(Guerreiro[0]);
                string nome = Guerreiro[1];
                int idade = int.Parse(Guerreiro[2]);
                double peso = double.Parse(Guerreiro[3]);
                

                switch (tipo){
                    case 0:
                        ListaLado[i].Add(new Valquiria(tipo, nome, idade, peso));
                        break;
                }
            }
        }
    }
// Indexador para permitir o acesso a ListaLado
    public List<Guerreiro> this[int index]
    {
        get { return ListaLado[index]; }
    }
}