using System;
using System.Collections.Generic;
using System.Linq;

class EatList
{
    static List<(string item, int quantidade)> listaPedidos = new List<(string, int)>();
    static string mensagem = "Bom dia"; // Mensagem padrão

    static void Main(string[] args)
    {
        string input;
        Console.WriteLine("Bem-vindo ao EatList!");

        while (true)
        {
            Console.Write("> ");
            input = Console.ReadLine();
            var comando = input.Split(' ');

            switch (comando[0].ToLower())
            {
                case "add":
                    AdicionarItem(comando.Skip(1).ToArray());
                    break;
                case "rm":
                    RemoverItem(comando.Skip(1).ToArray());
                    break;
                case "grt":
                    SetMensagem(comando.Skip(1).ToArray());
                    break;
                case "print":
                    ImprimirPedido();
                    break;
                case "help":
                    MostrarHelp();
                    break;
                case "exit":
                    return;
                default:
                    Console.WriteLine("Comando não reconhecido! Digite 'help' para ver a lista de comandos.");
                    break;
            }
        }
    }

    static void AdicionarItem(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Você deve especificar o item a ser adicionado.");
            return;
        }

        string item = string.Join(" ", args.Take(args.Length - 1));
        int quantidade = 1;

        if (int.TryParse(args.Last(), out int qtd))
            quantidade = qtd;
        else
            item = string.Join(" ", args);

        var pedidoExistente = listaPedidos.FirstOrDefault(p => p.item == item);

        if (!string.IsNullOrEmpty(pedidoExistente.item))
        {
            listaPedidos.Remove(pedidoExistente);
            pedidoExistente.quantidade += quantidade;
            listaPedidos.Add(pedidoExistente);
        }
        else
        {
            listaPedidos.Add((item, quantidade));
        }

        Console.WriteLine($"{quantidade} x {item} adicionado(s) à lista.");
    }

    static void RemoverItem(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Você deve especificar o item a ser removido.");
            return;
        }

        string item = string.Join(" ", args.Take(args.Length - 1));
        int quantidade = 1;

        if (int.TryParse(args.Last(), out int qtd))
            quantidade = qtd;
        else
            item = string.Join(" ", args);

        var pedidoExistente = listaPedidos.FirstOrDefault(p => p.item == item);

        if (!string.IsNullOrEmpty(pedidoExistente.item))
        {
            listaPedidos.Remove(pedidoExistente);
            pedidoExistente.quantidade -= quantidade;

            if (pedidoExistente.quantidade > 0)
                listaPedidos.Add(pedidoExistente);

            Console.WriteLine($"{quantidade} x {item} removido(s) da lista.");
        }
        else
        {
            Console.WriteLine("Item não encontrado na lista.");
        }
    }

    static void SetMensagem(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Você deve especificar a mensagem (bom dia, boa tarde, boa noite).");
            return;
        }

        string timeMessage = string.Join(" ", args);
        mensagem = timeMessage;
        Console.WriteLine($"Mensagem definida para: {mensagem}");
    }

    static void ImprimirPedido()
    {
        Console.WriteLine($"{mensagem}, gostaria de pedir:");
        foreach (var pedido in listaPedidos)
        {
            Console.WriteLine($"- {pedido.item} (x{pedido.quantidade})");
        }
    }

    static void MostrarHelp()
    {
        Console.WriteLine("Comandos disponíveis:");
        Console.WriteLine("add <item> [quantidade]  - Adiciona um item à lista (opcionalmente com quantidade).");
        Console.WriteLine("rm <item> [quantidade]   - Remove um item da lista (opcionalmente com quantidade).");
        Console.WriteLine("grt <mensagem>           - Define a saudação (bom dia, boa tarde, boa noite).");
        Console.WriteLine("print                    - Imprime a saudação e a lista de pedidos.");
        Console.WriteLine("help                     - Mostra esta lista de comandos.");
        Console.WriteLine("exit                     - Encerra o programa.");
    }
}
