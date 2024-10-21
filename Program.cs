namespace trabalho_POO;

class Program
{
    static void Main(string[] args)
    {
        Lado lado1 = new Lado(@"C:\Users\adm\Documents\trabalho poo c#\trabalho-POO\arquivos guerreiros\lado1");
        Lado lado2 = new Lado(@"C:\Users\adm\Documents\trabalho poo c#\trabalho-POO\arquivos guerreiros\lado2");

        lado1.ImprimirLado(1);
        lado2.ImprimirLado(2);

        lado1.SomaPeso(1);
        lado2.SomaPeso(2);




    //     for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
    //         for (int k = 0; k < lado1[i].Count; k++){
    //             lado1[i][k].ImprimirGuerreiro();    
    //         }    
    //     }

    //     lado1[0][0].Atacar();

    //     Arena.MoverParaFinalFila(lado1);

    //     for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
    //         for (int k = 0; k < lado1[i].Count; k++){
    //             lado1[i][k].ImprimirGuerreiro();    
    //         }   
    //     }
    }
}
