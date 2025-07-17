using System;
using System.Collections.Generic;

// Modelo de Domínio: representa o mascote no nosso jogo.
public class Mascote
{
    // Propriedades que serão mapeadas do DTO
    public string? Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<PokemonAbility>? Abilities { get; set; }

    // Propriedades e lógica específicas do nosso jogo
    public int Alimentacao { get; private set; }
    public int Humor { get; private set; }
    public int Sono { get; private set; }

    public Mascote()
    {
        Random random = new Random();
        Alimentacao = random.Next(3, 8);
        Humor = random.Next(3, 8);
        Sono = random.Next(3, 8);
    }
    
    // --- VERIFIQUE ESTES MÉTODOS ---

    /// <summary>
    /// Alimenta o mascote, aumentando sua saciedade, mas deixando-o com um pouco de sono.
    /// </summary>
    public void Alimentar()
    {
        // Esta ação NÃO MUDA O HUMOR diretamente.
        Alimentacao = Math.Min(10, Alimentacao + 2); // Aumenta a alimentação, no máximo 10.
        Sono = Math.Max(0, Sono - 1);               // Cansa um pouco.
    }

    /// <summary>
    /// Brinca com o mascote, aumentando muito seu humor, mas gasta energia e dá fome.
    /// </summary>
    public void Brincar()
    {
        // ESTA AÇÃO DEVE MUDAR O HUMOR!
        Humor = Math.Min(10, Humor + 3);          // Aumenta muito o humor.
        Alimentacao = Math.Max(0, Alimentacao - 1); // Gasta energia e dá fome.
        Sono = Math.Max(0, Sono - 1);               // Cansa um pouco.
    }

    /// <summary>
    /// Coloca o mascote para dormir, recuperando seu sono e melhorando um pouco o humor.
    /// </summary>
    public void Dormir()
    {
        // E ESTA AÇÃO TAMBÉM!
        Sono = Math.Min(10, Sono + 4);            // Recupera bastante o sono.
        Humor = Math.Min(10, Humor + 1);          // Acorda um pouco mais feliz.
    }
}

// As classes PokemonAbility e AbilityDetail não precisam de alteração
public class PokemonAbility
{
    public AbilityDetail? Ability { get; set; }
}
public class AbilityDetail
{
    public string? Name { get; set; }
}