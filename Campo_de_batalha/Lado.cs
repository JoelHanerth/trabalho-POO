using System.Globalization;

public class Lado{

    private List<Guerreiro>[] ListaLado = new List<Guerreiro>[Configuracoes.TAMANHO_FILA];

    public Lado(string endereco, int nLado){
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

                InstanciarGuerreiros(ListaLado[i],Guerreiro,nLado);
            }
        }
    }


    private void InstanciarGuerreiros(List<Guerreiro> ListaLado, string [] infGuerreiro, int nLado){
        // converte o tipo das variaveis
        int tipo = int.Parse(infGuerreiro[0]);
        string nome = infGuerreiro[1];
        int idade = int.Parse(infGuerreiro[2]);
        double peso = double.Parse(infGuerreiro[3], CultureInfo.InvariantCulture);
        

        if (nLado == 1){
            switch (tipo){
                case 1:
                    ListaLado.Add(new Ciclope(tipo, nome, idade, peso));
                    break;

                case 2:
                    ListaLado.Add(new Manticora(tipo, nome, idade, peso));
                    break;

                case 3:
                    ListaLado.Add(new Hidra(tipo, nome, idade, peso));
                    break;

            }
        }
        else{
            switch (tipo){
                case 2:
                    ListaLado.Add(new Satiro(tipo, nome, idade, peso));
                    break;
                case 3:
                    ListaLado.Add(new Argus(tipo, nome, idade, peso));
                    break;
                case 4:
                    ListaLado.Add(new Valquiria(tipo, nome, idade, peso));
                    break;

                case 5:
                    ListaLado.Add(new LoboDeFenris(tipo, nome, idade, peso));
                    break;
            }
        }
    }

    public void ImprimirLado(int n){
        Console.Write("\nLADO {0}",n);

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            Console.WriteLine("\nFila {0}",i+1);
            
                for (int k = 0; k < ListaLado[i].Count; k++){
                    ListaLado[i][k].ImprimirGuerreiro();    
                }
        }
    }


    public double SomaPeso(){
        double soma = 0;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            if (ListaLado[i].Count >0 && ListaLado[i]!= null){
                for (int k = 0; k < ListaLado[i].Count; k++){
                    soma += ListaLado[i][k].Peso;
                }
            }
        }
        return soma;
    }


    public Guerreiro? MaiorIdade()
    {
        Guerreiro? maior = null;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            for (int k = 0; k < ListaLado[i].Count; k++){
                if (maior == null){
                    maior = ListaLado[i][k];
                    continue;
                }

                // Atualiza maior se encontrar um Guerreiro mais velho
                if (maior.Idade < ListaLado[i][k].Idade){
                    maior = ListaLado[i][k];
                }
            }
        }
        return maior;
    }



// Indexador para permitir o acesso a ListaLado
    public List<Guerreiro> this[int index]
    {
        get { return ListaLado[index]; }
    }
}