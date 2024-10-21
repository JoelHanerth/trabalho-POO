using System.Globalization;

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
                double peso = double.Parse(Guerreiro[3], CultureInfo.InvariantCulture);
                

                switch (tipo){
                    case 0:
                        ListaLado[i].Add(new Valquiria(tipo, nome, idade, peso));
                        break;
                }
            }
        }
    }

    public void ImprimirLado(int n){
        Console.WriteLine("LADO {0}",n);

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            Console.WriteLine("Fila {0}",i+1);
            for (int k = 0; k < ListaLado[i].Count; k++){
                ListaLado[i][k].ImprimirGuerreiro();    
            }    
        }
    }


    public void SomaPeso(int n){
        double soma = 0;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            for (int k = 0; k < ListaLado[i].Count; k++){
                soma += ListaLado[i][k].Peso;
            }    
        }
        Console.WriteLine("LADO {0} pesa {1}kg",n,soma);
    }


// Indexador para permitir o acesso a ListaLado
    public List<Guerreiro> this[int index]
    {
        get { return ListaLado[index]; }
    }
}