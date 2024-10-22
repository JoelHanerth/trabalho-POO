public class Valquiria: Nordicos{
    private int recuperarVida = 20;
    public Valquiria(int tipo, string nome, int idade, double peso ): base(tipo, nome,idade,peso){
        danoAtaque = 20;
    }
        
    public override void Atacar(Lado lado1, Lado lado2, int fila){
        int filaOriginal = fila;

        // ataca quem está na frente dela
        // caso não tenha ninguem, ela deve atacar quem está do lado
        for (int i = 0; i < Configuracoes.TAMANHO_FILA; i++)
        {
            if (lado2[fila].Count > 0){
                lado2[fila][0].Energia-=danoAtaque;
                Console.WriteLine("{0} atacou {1} com dano de {2} -> vida restante: {3}", nome, lado2[fila][0].Nome, danoAtaque,lado2[fila][0].Energia);
                break;
            }
            else{
                fila+=1;
                if (fila >= Configuracoes.TAMANHO_FILA){
                    fila = 0;
                }
            }        
        }
        
        // cura quem está atras dela
        if (lado1[filaOriginal].Count > 1){
            lado1[filaOriginal][1].Energia += recuperarVida;
            Console.WriteLine("{0} curou {1} com {2} de vida-> vida atual: {3}", nome, lado1[filaOriginal][1].Nome, recuperarVida,lado1[filaOriginal][1].Energia);
            
        }

    }

    public override void ImprimirGuerreiro(){
        Console.WriteLine("Valquiria: {0}, {1} anos, {2} kilos, energia {3}", Nome, Idade, Peso, Energia);
    }
}