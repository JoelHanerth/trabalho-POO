namespace trabalho_POO;

class Program
{
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

        lado1.ImprimirLado(1);
        lado2.ImprimirLado(2);
      



    }
}
