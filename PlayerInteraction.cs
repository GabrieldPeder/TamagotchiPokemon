using System;
using System.Collections.Generic;

// Camada View: A única que pode ler ou escrever no Console.
public class PlayerInteraction
{
    public string BoasVindas()
    {
        Console.WriteLine("***************************************************");
        Console.WriteLine("* *");
        Console.WriteLine("* Bem-vindo ao Jogo de Adoção de Mascotes!     *");
        Console.WriteLine("* *");
        Console.WriteLine("***************************************************\n");
        Console.Write("Por favor, digite o seu nome: ");
        string nomeJogador = Console.ReadLine() ?? "Jogador";
        Console.WriteLine($"\nOlá, {nomeJogador}! Vamos começar.\n");
        return nomeJogador;
    }

    public string ExibirMenuPrincipal()
    {
        Console.WriteLine("\n----------------------------------");
        Console.WriteLine("Menu Principal:");
        Console.WriteLine("1. Adotar um mascote");
        Console.WriteLine("2. Interagir com seus mascotes");
        Console.WriteLine("3. Sair do jogo");
        Console.Write("Opção: ");
        return Console.ReadLine() ?? "";
    }

    public string ObterEspecieParaAdocao()
    {
        Console.WriteLine("\n--- Menu de Adoção ---");
        Console.WriteLine("Espécies disponíveis: Bulbasaur, Charmander, Squirtle, Pikachu");
        Console.Write("\nDigite o nome da espécie que você deseja ver (ou 'voltar' para sair): ");
        return Console.ReadLine()?.ToLower() ?? "";
    }

    public void ExibirDetalhesDoMascote(Mascote mascote)
    {
        Console.WriteLine($"\n--------- Características do {mascote.Name?.ToUpper()} ---------");
        Console.WriteLine($"Altura: {mascote.Height * 10} cm | Peso: {mascote.Weight / 10.0} kg");
        Console.WriteLine("Habilidades:");
        mascote.Abilities?.ForEach(a => Console.WriteLine($"- {a.Ability?.Name}"));
        Console.WriteLine("------------------------------------------");
    }

    public bool ConfirmarAdocao(Mascote mascote)
    {
        Console.Write($"\nDeseja adotar o {mascote.Name}? (s/n): ");
        string resposta = Console.ReadLine()?.ToLower() ?? "n";
        return resposta == "s";
    }

    public Mascote? SelecionarMascote(List<Mascote> mascotes)
    {
        Console.WriteLine("\n--- Interagir com Mascotes ---");
        if (mascotes.Count == 0)
        {
            ExibirMensagemDeErro("Você ainda não adotou nenhum mascote!");
            return null;
        }

        Console.WriteLine("Com qual mascote você gostaria de interagir?");
        for (int i = 0; i < mascotes.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {mascotes[i].Name}");
        }
        Console.Write("Escolha um número (ou digite '0' para voltar): ");

        if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= mascotes.Count)
        {
            return mascotes[escolha - 1];
        }

        if (escolha == 0) return null; // Permite ao usuário voltar

        ExibirMensagemDeErro("Seleção inválida. Por favor, escolha um número da lista.");
        return null;
    }

    public string ExibirMenuDeInteracao(Mascote mascote)
    {
        Console.WriteLine($"\n--- O que fazer com {mascote.Name?.ToUpper()}? ---");
        Console.WriteLine("Status Atual:");
        Console.WriteLine($"- Alimentação: {mascote.Alimentacao}/10");
        Console.WriteLine($"- Humor:       {mascote.Humor}/10");
        Console.WriteLine($"- Sono:        {mascote.Sono}/10");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Ações:");
        Console.WriteLine("1. Alimentar");
        Console.WriteLine("2. Brincar");
        Console.WriteLine("3. Colocar para dormir");
        Console.WriteLine("4. Voltar ao menu principal");
        Console.Write("Ação: ");
        return Console.ReadLine() ?? "";
    }

    public void ExibirMensagemDeSucesso(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public void ExibirMensagemDeErro(string mensagem)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(mensagem);
        Console.ResetColor();
    }

    public void Despedida(string nomeJogador)
    {
        Console.WriteLine($"\nAté a próxima, {nomeJogador}!");
    }
}