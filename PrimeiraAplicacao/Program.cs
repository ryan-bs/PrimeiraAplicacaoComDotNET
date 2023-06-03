//Primeira Aplicacao

//List<List<string>> citacoes = new List<List<string>>();
using System.Linq;

Dictionary<string, List<int>> citacoes = new Dictionary<string, List<int>>();
citacoes.Add("A persistência é o caminho do êxito.", new List<int> { 10, 5, 8, 8, 5});
citacoes.Add("A felicidade não é algo pronto. Ela vem das suas próprias ações.", new List<int>());

void WelcomeMessage()
{
    string welcomeMessage = "Olá, seja bem vindo a minha primeira aplicação em C#\n";
    Console.WriteLine(@"
█▀▀ █ █▀█ █▀ ▀█▀   ▄▀█ █▀█ █░░ █ █▀▀ ▄▀█ ▀█▀ █ █▀█ █▄░█
█▀░ █ █▀▄ ▄█ ░█░   █▀█ █▀▀ █▄▄ █ █▄▄ █▀█ ░█░ █ █▄█ █░▀█");
    Console.WriteLine("\n" + welcomeMessage);
}

void TituloOpcoes(string titulo)
{
    string asterisco = string.Empty.PadLeft(titulo.Length, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco);
}

int GetOptions()
{
    Console.Write("\nDigite sua opção: ");
    String opcao = Console.ReadLine()!;

    return int.Parse(opcao);
}

void SelectOption(int opcao)
{
    switch (opcao)
    {
        case 1:
            WriteQuote();
            break;
        case 2:
            ShowQuotes();
            break;
        case 3:
            RateQuotes();
            break;
        case 4:
            SeeRate();
            break;
        case 5:
            SimpleGame();
            break;
        case 6:
            SuperCarSell();
            break;
        case -1:
            Console.Clear();
            Console.WriteLine("\n\nOBRIGADO POR USAR A APLICAÇÃO!");
            break;

        default:
            Console.Clear();
            TituloOpcoes("OPÇÃO INVÁLIDA!");
            Console.WriteLine("\n\nSelecione outra opção...");
            Thread.Sleep(2500);
            Console.Clear();
            ShowOptions();
            break;
    }
}

void ShowOptions()
{
    WelcomeMessage();

    Console.WriteLine("\nEscolha uma das seguintes opções: ");
    Console.WriteLine("[1] para escrever uma citação.");
    Console.WriteLine("[2] para imprimir todas as citações.");
    Console.WriteLine("[3] para avaliar uma citação.");
    Console.WriteLine("[4] para saber quais foram as avaliações de uma citação e sua média.");
    Console.WriteLine("[5] para jogar um jogo.");
    Console.WriteLine("[6] para saber a média de vendas nos últimos anos de um determinado super carro.");
    Console.WriteLine("[-1] para sair");

    SelectOption(GetOptions());
}

void WriteQuote()
{
    Console.Clear();
    TituloOpcoes("ESCRAVA A CITAÇÃO");

    Console.Write("Citação: ");
    string citacao = Console.ReadLine()!;
    citacoes.Add(citacao, new List<int>());
    Console.WriteLine($"Sua {citacoes.Count}° citação foi salva com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
    ShowOptions();
}

void ShowQuotes()
{
    Console.Clear();
    TituloOpcoes("CITAÇÕES SALVAS");

    /*
    for (int i = 0; i < citacoes.Count; i++)
    {
        Console.WriteLine(citacoes[i][0]);
        Console.WriteLine($"Autor: {citacoes[i][1]}\n");
    }
    */
    
    int i = 0;
    foreach (string citacao in citacoes.Keys)
    {
        i += 1;
        Console.WriteLine($"{i}- {citacao}");
    }

    Console.WriteLine("\nPara retornar aperte qualquer botão...");
    Console.ReadKey();
    Console.Clear();
    ShowOptions();
}

void RateQuotes()
{
    Console.Clear();
    TituloOpcoes("AVALIE UMA DAS CITAÇÕES SALVAS");

    Console.Write("Qual citação deseja avaliar? ");
    int numeroDaCitacao = int.Parse(Console.ReadLine()!);

    if (numeroDaCitacao <= (citacoes.Count))
    {
        Console.Write("De uma avaliação de 0 a 10 para essa citação: ");
        int avaliacao = int.Parse(Console.ReadLine()!);
        string chave = citacoes.Keys.ElementAt(numeroDaCitacao - 1);
        citacoes[chave].Add(avaliacao);

        Console.WriteLine($"\nA citação:\n{chave}\nFoi avaliada com sucesso!");
        Console.WriteLine("\nAperte qualquer botão para retornar a opções...");
        Console.ReadKey();
        Console.Clear();
        ShowOptions();
    }
    else
    {
        Console.WriteLine("Essa citacao não existe.");
        Console.WriteLine("Aperte qualquer botão para selecionar outra citação: ");
        Console.ReadKey();
        Console.Clear();
        RateQuotes();
    }
    
}

void SeeRate()
{
    Console.Clear();
    TituloOpcoes("AVALIAÇÕES DAS CITAÇÕES");

    int i = 0;
    foreach(string citacao in citacoes.Keys)
    {
        i += 1;
        if (citacoes[citacao].Any())
        {
            string avaliacoes = string.Join(", ", citacoes[citacao]);
            Console.WriteLine($"\n{i}- {citacao}");
            Console.WriteLine($"As avaliações dessa citação são: {avaliacoes}.");
            Console.WriteLine($"MÉDIA: {citacoes[citacao].Average()}");
        } else
        {
            Console.WriteLine($"\n{i}- {citacao}");
            Console.WriteLine("ESSA CITAÇÃO NÃO POSSUI AVALIAÇÃO AINDA.");
        }
    }

    Console.Write("Aperte qualquer botão para retornar a opções: ");
    Console.ReadKey();
    Console.Clear();
    ShowOptions();
}

void SimpleGame()
{
    Console.Clear();
    TituloOpcoes("BEM VINDO AO JOGO DE ADIVINHE O NÚMERO!");
    Random random = new Random();
    int descubra = random.Next(0, 100);

    Console.Write("\nVocê deve descobrir o número misterioso! Tente acha-lo escrevendo números de 0 a 100." +
        "\nPrimeira tentativa: ");
    int numero = int.Parse(Console.ReadLine()!);

    while (numero != descubra)
    {
        if (numero > descubra)
        {
            Console.Write("\nSeu número é maior do que o misterioso." +
                "\nTente novamente: ");
            numero = int.Parse(Console.ReadLine()!);
        }
        else
        {
            Console.Write("\nSeu número é menor do que o misterioso." +
                "\nTente novamente: ");
            numero = int.Parse(Console.ReadLine()!);
        }
    }

    Console.WriteLine("\nPARABÉNS, você descobriu o número!\n" + descubra + " É a resposta certa :)");
}

void SuperCarSell()
{
    Console.Clear();
    TituloOpcoes("VENDA DE SUPER CARROS");
    
    Dictionary<string, List<int>> vendasCarros = new Dictionary<string, List<int>>
    {
        { "Bugatti Veyron", new List<int> { 10, 15, 12, 8, 5 } },
        { "Koenigsegg Agera RS", new List<int> { 2, 3, 5, 6, 7 } },
        { "Lamborghini Aventador", new List<int> { 20, 18, 22, 24, 16 } },
        { "Pagani Huayra", new List<int> { 4, 5, 6, 5, 4 } },
        { "Ferrari LaFerrari", new List<int> { 7, 6, 5, 8, 10 } }
    };

    Console.WriteLine("\nDos seguintes carros: ");
    foreach(string carro in vendasCarros.Keys)
    {
        Console.WriteLine($"{carro}");
    }
    Console.Write("\nEscreva o nome do carro que deseja saber a média de vendas: ");
    string nomeCarro = Console.ReadLine()!;

    if(vendasCarros.ContainsKey(nomeCarro))
    {
        Console.Clear();
        TituloOpcoes($"{nomeCarro}");
        string numeroDeVendasPorAno = string.Join(", ", vendasCarros[nomeCarro]);
        Console.WriteLine($"\nNos ultimos anos, esse carro foi vendido {numeroDeVendasPorAno} vezes respectivamente;");
        double mediaVendas = vendasCarros[nomeCarro].Average();
        Console.WriteLine($"\nSUA MÉDIA DE VENDAS FOI DE {mediaVendas}!");
    } else
    {
        Console.Clear();
        TituloOpcoes("O carro informado não se encontra na lista, por favor coloque outro nome.");
        Thread.Sleep(5000);
        Console.Clear();
        SuperCarSell();
    }
}


ShowOptions();

