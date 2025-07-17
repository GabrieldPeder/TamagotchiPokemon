# 🐾 Tamagotchi de Pokémon

![C#](https://img.shields.io/badge/C%23-blue?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-purple?style=for-the-badge&logo=dotnet&logoColor=white)
![GitHub license](https://img.shields.io/badge/license-MIT-green?style=for-the-badge)

## 📖 Sobre o Projeto

Este é um projeto de um jogo de console em C# estilo **Tamagotchi**, onde você pode adotar e cuidar de seus próprios Pokémons! A aplicação consome dados da [PokéAPI](https://pokeapi.co/) para obter informações detalhadas sobre as espécies, permitindo uma experiência interativa e dinâmica.

O projeto foi desenvolvido como parte do desafio **#7DaysOfCode de C#** da [Alura](https://www.alura.com.br/), cobrindo desde o consumo de APIs e tratamento de JSON até conceitos de arquitetura de software e boas práticas de programação.

## ✨ Funcionalidades

-   **🐾 Adoção de Mascotes:** Escolha entre uma seleção de Pokémons clássicos para adotar.
-   **📊 Visualização de Status:** Consulte as informações e características únicas de cada Pokémon, como altura, peso e habilidades.
-   **❤️ Interação e Cuidado:** Alimente, brinque e coloque seus mascotes para dormir, influenciando diretamente seus atributos de fome, humor e sono.
-   **🛡️ Arquitetura Robusta:** O código é estruturado para ser resiliente, com tratamento de erros de API e de entradas inválidas do usuário.

## 🚀 Tecnologias Utilizadas

O projeto foi construído com as seguintes tecnologias e bibliotecas:

-   **[C#](https://learn.microsoft.com/en-us/dotnet/csharp/)** e **[.NET](https://dotnet.microsoft.com/)**
-   **[RestSharp](https://restsharp.dev/)**: Para realizar as chamadas HTTP para a PokéAPI de forma simples e eficaz.
-   **[AutoMapper](https://automapper.org/)**: Para realizar o mapeamento entre os objetos de transferência de dados (DTOs) da API e os modelos de domínio do jogo.
-   **[PokéAPI](https://pokeapi.co/)**: A fonte de dados para todas as informações sobre os Pokémons.

## ⚙️ Como Executar

Para executar este projeto localmente, siga os passos abaixo:

**Pré-requisitos:**
* [.NET SDK](https://dotnet.microsoft.com/download) (versão 8.0 ou superior)
* [Git](https://git-scm.com/)

**Passo a passo:**

1.  **Clone o repositório:**
    ```bash
    git clone [https://github.com/GabrieldPeder/TamagotchiPokemon.git](https://github.com/GabrieldPeder/TamagotchiPokemon.git)
    ```

2.  **Navegue até a pasta do projeto:**
    ```bash
    cd TamagotchiPokemon
    ```

3.  **Restaure as dependências:**
    ```bash
    dotnet restore
    ```

4.  **Execute a aplicação:**
    ```bash
    dotnet run
    ```

## 🏗️ Estrutura do Projeto

A aplicação foi organizada seguindo uma arquitetura baseada em camadas, similar ao padrão MVC, para garantir a separação de responsabilidades:

-   `GameController.cs`: A camada de **Controller**, responsável por orquestrar o fluxo do jogo.
-   `PlayerInteraction.cs`: A camada de **View**, responsável por toda a interação com o usuário no console.
-   `PokemonService.cs`: A camada de **Service**, responsável pela comunicação com a PokéAPI.
-   `Mascote.cs`: O **Modelo de Domínio**, que representa o mascote dentro das regras do jogo.
-   `PokemonSpeciesDto.cs`: O **DTO (Data Transfer Object)**, que representa os dados exatamente como vêm da API.
-   `MappingProfile.cs`: O perfil de configuração do **AutoMapper**, que define como converter um DTO em um Modelo de Domínio.

## 👨‍💻 Autor

Feito com ❤️ por **Gabriel de Peder**.

[![GitHub](https://img.shields.io/badge/GitHub-100000?style=for-the-badge&logo=github&logoColor=white)](https://github.com/GabrieldPeder)

---
