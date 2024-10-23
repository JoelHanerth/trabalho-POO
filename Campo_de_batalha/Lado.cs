using System.Globalization;

public static class Lado{

    

    public  static List<Guerreiro>[] ConstrutorLado(string endereco, int nLado){
        
        List<Guerreiro>[] vetorFila = new List<Guerreiro>[Configuracoes.TAMANHO_FILA];

        // procura o endereço dos arquivos que estão naquela pasta
        string[] files = Directory.GetFiles(endereco);

        for (int i = 0; i < files.Length; i++) {
            // inicializa uma lista da posição dos vetores
            vetorFila[i] = new List<Guerreiro>();

            // retorna lista separada por linha
            string[] Guerreiros = File.ReadAllLines(files[i]);

            for (int k = 0; k < Guerreiros.Length; k++){
                // retorna lista das palavras daquela linha
                string[] infGuerreiro = Guerreiros[k].Split(' ');

                InstanciarGuerreiros(vetorFila[i],infGuerreiro,nLado);
            }
        }
        return vetorFila;
    }


    private static void InstanciarGuerreiros(List<Guerreiro> fila, string [] infGuerreiro, int nLado){
        // converte o tipo das variaveis
        int tipo = int.Parse(infGuerreiro[0]);
        string nome = infGuerreiro[1];
        int idade = int.Parse(infGuerreiro[2]);
        double peso = double.Parse(infGuerreiro[3], CultureInfo.InvariantCulture);
        

        if (nLado == 1){
            switch (tipo){
                case 1:
                    fila.Add(new Ciclope(tipo, nome, idade, peso));
                    break;

                case 2:
                    fila.Add(new Manticora(tipo, nome, idade, peso));
                    break;

                case 3:
                    fila.Add(new Hidra(tipo, nome, idade, peso));
                    break;
                case 4:
                    fila.Add(new Valquiria(tipo, nome, idade, peso));
                    break;

            }
        }
        else{
            switch (tipo){
                case 2:
                    fila.Add(new Satiro(tipo, nome, idade, peso));
                    break;
                case 3:
                    fila.Add(new Argus(tipo, nome, idade, peso));
                    break;
                case 4: 
                    fila.Add(new Anubita(tipo, nome, idade, peso));
                    break;

                case 5:
                    fila.Add(new LoboDeFenris(tipo, nome, idade, peso));
                    break;
            }
        }
    }

    public static void ImprimirLado(List<Guerreiro>[] vetorFila, int n){
        Console.Write("\nLADO {0}",n);

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            Console.WriteLine("\nFila {0}",i+1);
            
                for (int k = 0; k < vetorFila[i].Count; k++){
                    vetorFila[i][k].ImprimirGuerreiro();    
                }
        }
    }


    public static double SomaPeso(List<Guerreiro>[] vetorFila){
        double soma = 0;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            if (vetorFila[i].Count >0 && vetorFila[i]!= null){
                for (int k = 0; k < vetorFila[i].Count; k++){
                    soma += vetorFila[i][k].Peso;
                }
            }
        }
        return soma;
    }


    public static Guerreiro? MaiorIdade(List<Guerreiro>[] vetorFila)
    {
        Guerreiro? maior = null;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            for (int k = 0; k < vetorFila[i].Count; k++){
                if (maior == null){
                    maior = vetorFila[i][k];
                    continue;
                }

                // Atualiza maior se encontrar um Guerreiro mais velho
                if (maior.Idade < vetorFila[i][k].Idade){
                    maior = vetorFila[i][k];
                }
            }
        }
        return maior;
    }



// // Indexador para permitir o acesso a ListaLado
//     public List<Guerreiro> this[int index]
//     {
//         get { return vetorFila[index]; }
//     }
}