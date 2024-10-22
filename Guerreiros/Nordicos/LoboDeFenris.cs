public class LoboDeFenris: Nordicos{
    private int danoAdicional = 8;
    public LoboDeFenris(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        danoAtaque = 40; 
    }

    private int calcularDanoAtaqueAdicional(Lado lado1, int fila){
        int dano = 0;
        for (int i = 1; i < lado1[fila].Count; i++)
        {
            if (lado1[fila][i].Tipo == lado1[fila][0].Tipo){
                dano += danoAdicional;
            }
            else{
                break;
            }
        }
        Console.WriteLine("DANO ADICIONAL{0}",dano);
        return dano;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila){
        int filaOriginal = fila;
        // ataca quem está na frente dela
        // caso não tenha ninguem, ela deve atacar quem está do lado
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (lado2[fila].Count > 0){
                int dano = danoAtaque+calcularDanoAtaqueAdicional(lado1, filaOriginal);
                lado2[fila][0].Energia-=dano;
                // lado2[fila][0].Energia = lado2[fila][0].Energia - (danoAtaque+calcularDanoAtaqueAdicional(lado1, filaOriginal));
                Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", nome, lado2[fila][0].Nome, dano,lado2[fila][0].Energia);
                break;
            }
            else{
                fila+=1;
                if (fila >= Configuracoes.TAMANHO_FILA){
                    fila = 0;
                }
            }        
        }
    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Lobo de Fenris: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}