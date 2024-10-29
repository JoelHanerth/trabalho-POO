namespace trabalho_POO;

class Program
{

    static void Main(string[] args){

        Arena arena = new Arena(@"arquivos guerreiros\lado1", @"arquivos guerreiros\lado2");
        arena.Equipe1.ImprimirEquipe(1);
        arena.Equipe2.ImprimirEquipe(2);

        Console.WriteLine("\nGregos e Nórdicos pesam {0:F2}kg", arena.Equipe1.SomaPeso());
        Console.WriteLine("Atlantes e Egípcios pesam {0:F2}kg", arena.Equipe2.SomaPeso());

        arena.CampoBatalha();
        arena.ImprimirVendedor();

        arena.Equipe1.ImprimirEquipe(1);
        arena.Equipe2.ImprimirEquipe(2);   
    }
}
