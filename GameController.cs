using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class GameController
{
    // Seus campos privados (não mudam)
    private readonly PlayerInteraction _view;
    private readonly PokemonService _pokemonService;
    private readonly List<Mascote> _mascotesAdotados;
    private readonly IMapper _mapper;
    private string _nomeJogador;

    // Seu construtor (não muda)
    public GameController()
    {
        _view = new PlayerInteraction();
        _pokemonService = new PokemonService();
        _mascotesAdotados = new List<Mascote>();
        _nomeJogador = "Jogador";

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = config.CreateMapper();
    }

    public async Task Jogar()
    {
        _nomeJogador = _view.BoasVindas();

        bool sair = false;
        while (!sair)
        {
            // --- INÍCIO DO ESCUDO TRY-CATCH ---
            // Protege o loop principal de quebrar por erros inesperados
            try
            {
                string opcao = _view.ExibirMenuPrincipal().Trim();
                switch (opcao)
                {
                    case "1":
                        await ProcessarAdocao();
                        break;
                    case "2":
                        ProcessarInteracao();
                        break;
                    case "3":
                        sair = true;
                        _view.Despedida(_nomeJogador);
                        break;
                    default:
                        // Mensagem de erro para entradas inválidas no menu
                        _view.ExibirMensagemDeErro("Opção inválida! Por favor, digite 1, 2 ou 3.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Se qualquer erro inesperado acontecer, ele será capturado aqui
                // em vez de quebrar o programa.
                _view.ExibirMensagemDeErro("\nOcorreu um erro inesperado no sistema. O jogo continuará do menu principal.");
                
                // Para você (desenvolvedor), é útil ver os detalhes do erro no console.
                Console.WriteLine($"\n--- DETALHES DO ERRO (PARA DEBUG) ---\n{ex.Message}\n-------------------------------------\n");
            }
            // --- FIM DO ESCUDO TRY-CATCH ---
        }
    }

    private async Task ProcessarAdocao()
    {
        string especieEscolhida = _view.ObterEspecieParaAdocao();
        if (especieEscolhida.ToLower() == "voltar") return;

        PokemonSpeciesDto? especieDto = await _pokemonService.BuscarEspeciePorNome(especieEscolhida);
        
        if (especieDto != null)
        {
            Mascote novoMascote = _mapper.Map<Mascote>(especieDto);
            _view.ExibirDetalhesDoMascote(novoMascote);
            
            if (_view.ConfirmarAdocao(novoMascote))
            {
                _mascotesAdotados.Add(novoMascote);
                _view.ExibirMensagemDeSucesso($"\nParabéns! Você adotou um {novoMascote.Name}!");
            }
        }
        else
        {
            // --- MENSAGEM DE ERRO MELHORADA ---
            // Cobre os casos de "não encontrado" e "API indisponível"
            _view.ExibirMensagemDeErro("\nEspécie não encontrada ou o serviço está indisponível no momento. Tente novamente mais tarde.");
        }
    }

    // O método ProcessarInteracao não precisou de mudanças na lógica de erros,
    // pois a validação já era feita na View e no início do método.
    private void ProcessarInteracao()
    {
        Mascote? mascoteEscolhido = _view.SelecionarMascote(_mascotesAdotados);
        if (mascoteEscolhido == null) return;

        bool voltar = false;
        while (!voltar)
        {
            string acao = _view.ExibirMenuDeInteracao(mascoteEscolhido);
            switch (acao)
            {
                case "1":
                    mascoteEscolhido.Alimentar();
                    _view.ExibirMensagemDeSucesso($"{mascoteEscolhido.Name} foi alimentado!");
                    break;
                case "2":
                    mascoteEscolhido.Brincar();
                    _view.ExibirMensagemDeSucesso($"Você brincou com {mascoteEscolhido.Name}!");
                    break;
                case "3":
                    mascoteEscolhido.Dormir();
                    _view.ExibirMensagemDeSucesso($"{mascoteEscolhido.Name} foi dormir um pouco.");
                    break;
                case "4":
                    voltar = true;
                    break;
                default:
                    _view.ExibirMensagemDeErro("Ação inválida!");
                    break;
            }
        }
    }
}