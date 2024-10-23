namespace trabalho_POO;

class Program
{

  static void ImprimirVendedor(Lado lado1, Lado lado2)
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
        ImprimirUltimosAtacantes(lado2, "Gregos e Nórdigos");
    }
    else
    {
        Console.WriteLine("Gregos e Nórdigos ganharam!");
        ImprimirUltimosAtacantes(lado1, "Atlantes e Egípcios");
    }
}

static void ImprimirUltimosAtacantes(Lado ladoPerdedor, string ladoVencedor)
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

        Lado lado1 = new Lado(@"arquivos guerreiros\lado1", 1);
        Lado lado2 = new Lado(@"arquivos guerreiros\lado2", 2);

        lado1.ImprimirLado(1);
        lado2.ImprimirLado(2);

        double peso1 = lado1.SomaPeso();
        Console.WriteLine("Gregos e Nórdicos pesam {0}kg", peso1);
        double peso2 = lado2.SomaPeso();
        Console.WriteLine("Atlantes e Egípcios pesam {0}kg", peso2);

        Arena.MaisVelho(lado1,lado2);

        Arena.CampoBatalha(lado1, lado2);

        ImprimirVendedor(lado1, lado2);

        // lado1.ImprimirLado(1);
        // lado2.ImprimirLado(2);

        
      
    }
}
