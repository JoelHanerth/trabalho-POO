namespace trabalho_POO;

class Program
{

  static void ImprimirVendedor(List<Guerreiro>[] lado1, List<Guerreiro>[] lado2)
{
    bool temGuerreiroLado1 = Arena.TemGuerreiro(lado1);
    bool temGuerreiroLado2 = Arena.TemGuerreiro(lado2);

    if (!temGuerreiroLado1 && !temGuerreiroLado2)
    {
        Console.WriteLine("EMPATE");
        return;
    }

    if (temGuerreiroLado1)
    {
        Console.WriteLine("Atlantes e Egípcios ganharam!");
        ImprimirUltimosAtacantes("Gregos e Nórdigos");
    }
    else
    {
        Console.WriteLine("Gregos e Nórdigos ganharam!");
        ImprimirUltimosAtacantes("Atlantes e Egípcios");
    }
}

static void ImprimirUltimosAtacantes( string ladoVencedor)
{
    if (Arena.UltimoInimigo != null)
    {
        Console.Write($"O último a ser derrotado no lado dos {ladoVencedor} foi: ");
        Arena.UltimoInimigo.ImprimirGuerreiro();

        if (Arena.UltimoAtacante != null)
        {
            Console.WriteLine();
            Arena.UltimoAtacante.ImprimirGuerreiro();
            Console.Write($"transferiu o último ataque no ");
            Arena.UltimoInimigo.ImprimirGuerreiro();
        }
    }
}

    static void Main(string[] args)
    {
        // Lado lado1 = new Lado(@"C:\Users\adm\Documents\trabalho poo c#\trabalho-POO\arquivos guerreiros\lado1");
        // Lado lado2 = new Lado(@"C:\Users\adm\Documents\trabalho poo c#\trabalho-POO\arquivos guerreiros\lado2");
        List<Guerreiro>[] lado1 = Lado.ConstrutorLado(@"arquivos guerreiros\lado1", 1);
        List<Guerreiro>[] lado2 = Lado.ConstrutorLado(@"arquivos guerreiros\lado2", 2);

        // Lado lado1 = new Lado(@"arquivos guerreiros\lado1", 1);
        // Lado lado2 = new Lado(@"arquivos guerreiros\lado2", 2);

        Lado.ImprimirLado(lado1,1);
        Lado.ImprimirLado(lado2,2);

        // lado1.ImprimirLado(1);
        // lado2.ImprimirLado(2);

        double peso1 = Lado.SomaPeso(lado1);
        Console.WriteLine("Gregos e Nórdicos pesam {0}kg", peso1);
        double peso2 = Lado.SomaPeso(lado2);
        Console.WriteLine("Atlantes e Egípcios pesam {0}kg", peso2);

        Arena.MaisVelho(lado1,lado2);

        Arena.CampoBatalha(lado1, lado2);

        ImprimirVendedor(lado1, lado2);

        // lado1.ImprimirLado(1);
        // lado2.ImprimirLado(2);

        
      
    }
}
