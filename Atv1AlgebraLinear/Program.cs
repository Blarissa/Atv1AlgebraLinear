using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //Matriz da questão
        var matriz1 = new int[,] {
            {0, 1, 1, 1, 1 },
            {1, 0, 1, 1, 0 },
            {0, 1, 0, 1, 0 },
            {0, 0, 1, 0, 1 },
            {0, 0, 0, 1, 0 }
        };

        //Matriz1 elevada por 2
        var matriz2 = PotenciaDeMatriz(matriz1, 2);

        //Matriz1 elevada por 3
        var matriz3 = PotenciaDeMatriz(matriz1, 3);

        var opcao1 = -1;        

        while (opcao1 != 0) {
            Console.WriteLine(
                "Menu Principal\n" +
                "1 - Todas as conexões diretas\n" +
                "2 - Todas as conexões com no máximo uma retransmissão\n" +
                "3 - Todas as conexões com no máximo duas retransmissões\n" +
                "4 - Conexões diretas entre 2 torres\n" +
                "5 - Conexões com no máximo uma retransmissão entre 2 torres\n" +
                "6 - Conexões com no máximo uma retransmissão entre 2 torres\n" +
                "0 - Sair\n");

            opcao1 = int.Parse(Console.ReadLine());

            var conexoes = 0;
            int t1, t2 = 0;
            switch (opcao1)
            {
                case 1:
                    RetornaOpcoes(matriz1);                    
                    break;

                case 2:
                    RetornaOpcoes(matriz2);
                    break;

                case 3:
                    RetornaOpcoes(matriz3);
                    break;

                case 4:                   
                    SelecionandoTorres(out t1, out t2);
                    conexoes = Conexoes(t1, t2, matriz1);

                    if (conexoes == 0)
                        Console.WriteLine($"Não existe conexões entre torre {t1} e torre {t2}\n");
                    else                    
                        Console.WriteLine($"Conexões entre torre {t1} e torre {t2}: {conexoes}\n");                                        

                    break;

                case 5:
                    SelecionandoTorres(out t1, out t2);
                    conexoes = Conexoes(t1, t2, matriz2);

                    int numVertices = matriz2.GetLength(0);

                    int[] caminho = new int[numVertices];
                    bool[] verticesVisitados = new bool[numVertices];

                    caminho[0] = 0;
                    verticesVisitados[0] = true;

                    if (conexoes == 0)
                        Console.WriteLine($"Não existe conexões entre torre {t1} e torre {t2}\n");
                    else                    
                        Console.WriteLine($"Conexões entre torre {t1} e torre {t2}: {conexoes}\n");                        
                    
                    
                    break; 

                case 6:
                    SelecionandoTorres(out t1, out t2);
                    conexoes = Conexoes(t1, t2, matriz3);

                    if (conexoes == 0)
                        Console.WriteLine($"Não existe conexões entre torre {t1} e torre {t2}\n");
                    else
                        Console.WriteLine($"Conexões entre torre {t1} e torre {t2}: {conexoes}\n");

                    break;
            }
        }
    }

    //Pergunta as torres que vão ser usadas
    private static void SelecionandoTorres(out int t1, out int t2)
    {
        Console.WriteLine("Digite o número da primeira torre: ");
        t1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Digite o número da segunda torre: ");
        t2 = int.Parse(Console.ReadLine());
    }

    //Retorna as opções de comunicação
    private static void RetornaOpcoes(int[,] matriz)
    {
        Console.WriteLine($"\nTorre | Torre | Conexões");
        
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                var conexoes = Conexoes(i, j, matriz);                
                Console.WriteLine($"{i,-6}|{j,-7}|{conexoes,-6}");
            }
        }

        Console.WriteLine();
    }

    //Retona o número de conexões(opções de comunicação) entre duas torres
    private static int Conexoes(int v1, int v2, int[,] matriz)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                if (i == v1 - 1 && j == v2 - 1)
                    return matriz[i, j];
            }
        }

        return 0;
    }

    //Realiza a multiplicação entre 2 matrizes
    public static int[,] Multiplicacao(int[,] matriz1, int[,] matriz2)
    {
        var resultado = new int[matriz1.GetLength(0), matriz2.GetLength(1)];
        var soma = 0;

        for (int linha = 0; linha < matriz1.GetLength(0); linha++)
        {
            for (int coluna = 0; coluna < matriz2.GetLength(0); coluna++)
            {
                for (int i = 0; i < matriz1.GetLength(1); i++)
                {
                    soma += matriz1[linha, i] * matriz2[i, coluna];
                }

                resultado[linha, coluna] = soma;
                soma = 0;
            }
        }

        return resultado;
    }

    //Retornar potência de uma matriz
    public static int[,] PotenciaDeMatriz(int[,] matriz, int n)
    {
        var aux = matriz;

        for (int i = 0; i < n - 1; i++)
        {
            aux = Multiplicacao(aux, matriz);
        }

        return aux;
    }   
    
}