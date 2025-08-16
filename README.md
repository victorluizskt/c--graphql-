# DOCUMENTATION.md

## Visão Geral

Este projeto é uma API ASP.NET Core com suporte a GraphQL e REST, utilizando SQLite como banco de dados. Ele permite consultar e cadastrar autores e livros.

## Estrutura de Pastas

- **Controllers/**: Controllers REST (ex: WeatherForecast).
- **Database/**: Classes de acesso ao banco de dados.
- **GraphQL/**: Tipos e resolvers GraphQL (`Query`, `Mutation`).
- **Model/**: Modelos de dados (`Author`, `Book`).

## Endpoints

### REST

- `GET /weatherforecast`: Retorna previsões do tempo fictícias.

### GraphQL

- `/graphql`: Endpoint para queries e mutations GraphQL.

#### Exemplos de Queries

- Buscar autor por ID:
  ```graphql
  query {
    authorById(id: "ID_DO_AUTOR") {
      id
      name
    }
  }
  ```

- Listar todos os livros:
  ```graphql
  query {
    allBooks {
      id
      title
      author {
        id
        name
      }
    }
  }
  ```

#### Exemplos de Mutations

- Adicionar autor:
  ```graphql
  mutation {
    addAuthor(name: "Nome do Autor") {
      id
      name
    }
  }
  ```

- Adicionar livro:
  ```graphql
  mutation {
    addBook(title: "Título do Livro", id: "ID_DO_AUTOR") {
      id
      title
      author {
        id
      }
    }
  }
  ```

## Banco de Dados

- Utiliza SQLite (`db.sql`).
- Tabelas: `authors`, `book1`.

## Como rodar

1. Instale o .NET 9.
2. Execute:
   ```sh
   dotnet run
   ```
3. Acesse o endpoint REST ou GraphQL conforme desejado.

## Docker

- Build da imagem via `Dockerfile`.
- Compose disponível em `compose.yaml`.

## Dependências

- Dapper
- HotChocolate.AspNetCore
- Microsoft.Data.Sqlite
- Microsoft.EntityFrameworkCore

## Observações

- O projeto está configurado para ambiente de desenvolvimento.
- Para produção, ajuste variáveis e configurações conforme necessário.
