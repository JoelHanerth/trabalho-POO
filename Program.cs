namespace trabalho_POO;
class Program
{
    static void Main(string[] args)
    {
        string endereco = @"C:\Users\adm\Documents\trabalho c#\TrabalhoC-\arquivos";
        Lado lado1 = new Lado(endereco);

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            for (int k = 0; k < lado1[i].Count; k++){
                lado1[i][k].ImprimirGuerreiro();    
            }    
        }

        lado1[0][0].Atacar();

        Arena.MoverParaFinalFila(lado1);

        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++){
            for (int k = 0; k < lado1[i].Count; k++){
                lado1[i][k].ImprimirGuerreiro();    
            }   
        }
    }
}
