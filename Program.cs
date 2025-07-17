using System.Threading.Tasks;

// O ponto de entrada da aplicação.
// Sua única responsabilidade é criar e iniciar o Controller.
class Program
{
    static async Task Main(string[] args)
    {
        var gameController = new GameController();
        await gameController.Jogar();
    }
}