using System.Globalization;

public class Equipe{
    private List<Guerreiro>[] vetorFila = new List<Guerreiro>[Configuracoes.TAMANHO_FILA];

    public Equipe(string endereco, int nLado){
        // procura o endereço dos arquivos que estão naquela pasta
        string[] files = Directory.GetFiles(endereco);

        for (int i = 0; i < files.Length; i++){
            // inicializa uma lista da posição dos vetores
            vetorFila[i] = new List<Guerreiro>();

            // retorna lista separada por linha
            string[] Guerreiros = File.ReadAllLines(files[i]);

            for (int k = 0; k < Guerreiros.Length; k++){
                // retorna lista das palavras daquela linha
                string[] infGuerreiro = Guerreiros[k].Split(' ');

                InstanciarGuerreiros(vetorFila[i], infGuerreiro, nLado, i); // Passe a fila (i) também
            }
        }
    }

    // Adicionado parâmetro "filaAtual" para saber em qual fila o guerreiro está
private void InstanciarGuerreiros(List<Guerreiro> fila, string[] infGuerreiro, int nLado, int filaAtual){
    // converte o tipo das variáveis
    int tipo = int.Parse(infGuerreiro[0]);
    string nome = infGuerreiro[1];
    int idade = int.Parse(infGuerreiro[2]);
    double peso = double.Parse(infGuerreiro[3], CultureInfo.InvariantCulture);


    if (nLado == 1){
        switch (tipo){
            case 1:
                fila.Add(new Ciclope(nome, idade, peso, fila));
                break;

            case 2:
                fila.Add(new Manticora(nome, idade, peso, fila));
                break;

            case 3:
                fila.Add(new Hidra(nome, idade, peso, fila));
                break;

            case 4:
                fila.Add(new Valquiria(nome, idade, peso, fila));
                break;

            case 5:
                fila.Add(new LoboDeFenris(nome, idade, peso, fila));
                break;
            
            case 6:
                fila.Add(new GiganteDePedra(nome, idade, peso, fila));
                break;
        }
    }
    else{
        switch (tipo){
            case 1:
                fila.Add(new Prometeano(nome, idade, peso, fila));
                break;
            case 2:
                fila.Add(new Satiro(nome, idade, peso, fila));
                break;
            case 3:
                fila.Add(new Argus(nome, idade, peso, fila));
                break;
            case 4:
                fila.Add(new Anubita(nome, idade, peso, fila));
                break;
            case 5:
                fila.Add(new HomemEscorpiao(nome, idade, peso, fila));
                break;

            case 6:
                fila.Add(new Mumia(nome, idade, peso, fila));
                break;
        }
    }  
}

    public void ImprimirEquipe(int n)
    {
        Console.Write("\nLADO {0}", n);

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            Console.WriteLine("\nFila {0}", i + 1);

            for (int k = 0; k < vetorFila[i].Count; k++)
            {
                vetorFila[i][k].ImprimirGuerreiro();
            }
        }
    }

    public double SomaPeso()
    {
        double soma = 0;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (vetorFila[i].Count > 0 && vetorFila[i] != null)
            {
                for (int k = 0; k < vetorFila[i].Count; k++)
                {
                    soma += vetorFila[i][k].Peso;
                }
            }
        }
        return soma;
    }

    public Guerreiro? MaiorIdade()
    {
        Guerreiro? maior = null;

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            for (int k = 0; k < vetorFila[i].Count; k++)
            {
                if (maior == null)
                {
                    maior = vetorFila[i][k];
                    continue;
                }

                // Atualiza maior se encontrar um Guerreiro mais velho
                if (maior.Idade < vetorFila[i][k].Idade)
                {
                    maior = vetorFila[i][k];
                }
            }
        }
        return maior;
    }

    // Indexador para permitir o acesso ao vetorFila
    public List<Guerreiro> this[int index]
    {
        get { return vetorFila[index]; }
    }
}
