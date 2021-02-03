using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {

        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            Console.Clear();
            string opcaoUsuario;

            do
            {
                opcaoUsuario = ObterOpcaoUsuario().ToUpper();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        IncluirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        break;
                }

            } while (opcaoUsuario != "X");

            Console.WriteLine("Obrigada por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Write("Digite o código da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (listContas.Count > indiceConta)
            {
                Console.WriteLine("Código da conta é inválido!");
                return;
            }

            Console.Write("Digite o valor a ser depositado: ");
            double valor = double.Parse(Console.ReadLine());

            indiceConta -= 1;
            listContas[indiceConta].Depositar(valor);
        }

        private static void Sacar()
        {
            Console.Write("Digite o código da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            if (indiceConta > listContas.Count)
            {
                Console.WriteLine("Código da conta é inválido!");
                return;
            }

            Console.Write("Digite o valor a ser sacado: ");
            double valor = double.Parse(Console.ReadLine());

            indiceConta -= 1;
              listContas[indiceConta].Sacar(valor);
        }

        private static void Transferir()
        {
            Console.Write("Digite o código da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o código da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            if (indiceConta > listContas.Count)
            {
                Console.WriteLine("Código da conta é inválido!");
                return;
            }

            if (indiceContaDestino > listContas.Count)
            {
                Console.WriteLine("Código da conta de destino é inválido!");
                return;
            }

            Console.Write("Digite o valor a ser transferido: ");
            double valor = double.Parse(Console.ReadLine());

            indiceConta -= 1;
            indiceContaDestino -= 1;
            listContas[indiceConta].Transferir(valor, listContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            if (listContas.Count == 0)
            {
                System.Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }
            listContas.ForEach((c) => Console.WriteLine("#{0} {1}", listContas.IndexOf(c) + 1, c.ToString()));
        }

        private static void IncluirConta()
        {
            Console.WriteLine("Incluir nova conta");

            Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do titular: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double saldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor de credito: ");
            int credito = int.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)tipoConta, nome: nome, saldo: saldo, credito: credito);
            listContas.Add(novaConta);

            Console.WriteLine();
            ListarContas();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Incluir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
