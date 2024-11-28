using System; // importa o namespace System,
              // que contém classes básicas do .NET Framework, como Console.

namespace CalculadoraBasica {
    internal class Program {
        static void Main(string[] args) { //  ponto de entrada do programa.
                                          //  a execução começa aqui.

            //Console.WriteLine("Hello, World!");

            string operacao = "";

            while (operacao.ToLower() != "exit") {
                ExibirMenu();
                operacao = Console.ReadLine(); //Lê a entrada do usuário e armazena na variável operacao.

                if (operacao.ToLower() == "exit")
                    break;

                if (!ValidarOpcaoMenu(operacao)) {
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção de 1 a 4.");
                    AguardarContinuacao();
                    continue;
                }

                decimal primeiroNumerador = LerDecimal("Digite o primeiro número:");
                decimal segundoNumerador = LerDecimal("Digite o segundo número:");
                decimal resultado = RealizarOperacao(operacao, primeiroNumerador, segundoNumerador);
            }


        }

        //FORA DO MAIN ESTARÃO OS METÓDOS AUXILIARES
        static void ExibirMenu() {
            Console.Clear();
            Console.WriteLine("Para fazer uma soma digite 1");
            Console.WriteLine("Para fazer uma subtração digite 2");
            Console.WriteLine("Para fazer uma multiplicação digite 3");
            Console.WriteLine("Para fazer uma divisão digite 4");
            Console.WriteLine("Para sair, digite 'exit'");
        }

        static bool ValidarOpcaoMenu(string opcao) { //Método ValidarOpcaoMenu que verifica
                                                     //se a entrada do usuário é um número inteiro entre 1 e 4.
                                                     // Tenta converter a string 'opcao' para um número inteiro.
                                                     // Se a conversão for bem-sucedida, 'numero' armazenará o valor convertido.
                                                     // Se a conversão falhar, 'numero' será 0.

            //bool conversaoBemSucedida = int.TryParse(opcao, out int numero);

            // Retorna 'true' se a conversão foi bem-sucedida e o número está entre 1 e 4.
            // Caso contrário, retorna 'false'.

            //return conversaoBemSucedida && numero >= 1 && numero <= 4;

            return int.TryParse(opcao, out int numero) && numero >= 1 && numero <= 4;
        }

        static void AguardarContinuacao() {
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }

        public static decimal LerDecimal(string mensagem) {
            // Exibe a mensagem solicitando o valor ao usuário.
            Console.WriteLine(mensagem);

            decimal valor;

            // Continua pedindo um valor até que um decimal válido seja inserido.
            while (!decimal.TryParse(Console.ReadLine(), out valor)) {
                // Exibe uma mensagem de erro se o valor inserido não puder ser convertido para decimal.
                Console.WriteLine("Valor inválido. " + mensagem);
            }

            // Retorna o valor decimal válido inserido pelo usuário.
            return valor;
        }


        public static decimal RealizarOperacao(string operacao, decimal primeiroNumerador, decimal segundoNumerador) {
            switch (operacao) {
                case "1": 
                    return primeiroNumerador + segundoNumerador;
                case "2":
                    return primeiroNumerador - segundoNumerador;
                case "3":
                    return primeiroNumerador * segundoNumerador;
                case "4":
                    if (primeiroNumerador == 0) {
                        Console.WriteLine("Não é possivel dividir por zero.");
                        return decimal.MinValue;
                    }
                    return primeiroNumerador / segundoNumerador;

                default:
                    return decimal.MinValue;
            }
        }
    
    }
}

