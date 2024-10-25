namespace trabalho_POO;

class Program
{

  static void ImprimirVendedor(Arena arena)
{
    bool temGuerreiroEquipe1 = arena.TemGuerreiro(arena.Equipe1);
    bool temGuerreiroEquipe2 = arena.TemGuerreiro(arena.Equipe2);

    if (!temGuerreiroEquipe1 && !temGuerreiroEquipe2)
    {
        Console.WriteLine("EMPATE");
        return;
    }

    if (temGuerreiroEquipe1)
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

static void ImprimirUltimosAtacantes( string equipeVencedora){
    if (Arena.UltimoInimigo != null){
        Console.Write($"O último a ser derrotado no lado dos {equipeVencedora} foi: ");
        Arena.UltimoInimigo.ImprimirGuerreiro();

        if (Arena.UltimoAtacante != null){
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
        Equipe equipe1 = new Equipe(@"arquivos guerreiros\lado1", 1);
        Equipe equipe2 = new Equipe(@"arquivos guerreiros\lado2", 2);

        // Lado lado1 = new Lado(@"arquivos guerreiros\lado1", 1);
        // Lado lado2 = new Lado(@"arquivos guerreiros\lado2", 2);

        equipe1.ImprimirEquipe(1);
        equipe2.ImprimirEquipe(2);

        // lado1.ImprimirLado(1);
        // lado2.ImprimirLado(2);

        Console.WriteLine("Gregos e Nórdicos pesam {0}kg", equipe1.SomaPeso());
        Console.WriteLine("Atlantes e Egípcios pesam {0}kg", equipe2.SomaPeso());


        Arena arena = new Arena(equipe1, equipe2);
        arena.CampoBatalha();

        // criar lista;
        // arena.addlado()

        // arena.MaisVelho();

        // Arena.MaisVelho(lado1,lado2);

        // Arena.CampoBatalha(lado1, lado2);

        ImprimirVendedor(arena);

        equipe1.ImprimirEquipe(1);
        equipe2.ImprimirEquipe(2);

        
      
    }
}
