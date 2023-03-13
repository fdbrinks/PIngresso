# Api Cinema

Esta é uma api para um site de cinema, responsável pelo cadastro de filmes, salas e sessões, assim como, suas respectivas visualizações.

## Estrutura da API
O código foi arquitetado seguindo o padrão MVC, o que o organiza da seguinte maneira:

### Controller
### Service
### Repository
### Database
### View
### Input


## Endpoints

A seguir estão os endpoints disponíveis nesta API.

### Movie Endpoints

#### Método [GET]: /Movies
Este endpoint retorna um array com uma lista contendo todos os filmes cadastrados. Cada filme apresentará um array contendo uma lista de sessões cadastradas com aquele filmeId.

##### Body da Requisição:
[
  {
    "id": "FilmeId",
    "title": "Título do filme",
    "age": "Classificação Indicativa do filme",
    "length": "Duração em minutos do filme",
    "genre": "Gênero do filme",
    "imageUrl": "Url da imagem do filme",
    "sessions": [
      {
        "date": "Dia e mês da sessão",
        "hour": "Horário da sessão",
        "dub": "Se a sessão é legendado ou dublado",
        "d3": "Se a sessão é 3D ou não"
      }
    ]
  }
]

#### Método [GET]: /Movies/{id}
Este endpoint retorna um filme com id específico mencionado na rota da requisição. O filme apresentará um array contendo uma lista de sessões cadastradas com aquele filmeId.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhum filme, nenhum resultado será retornado.

##### Body da Requisição:
[
  {
    "id": "FilmeId",
    "title": "Título do filme",
    "age": "Classificação Indicativa do filme",
    "length": "Duração em minutos do filme",
    "genre": "Gênero do filme",
    "imageUrl": "Url da imagem do filme",
    "sessions": [
      {
        "date": "Dia e mês da sessão",
        "hour": "Horário da sessão",
        "dub": "Se a sessão é legendado ou dublado",
        "d3": "Se a sessão é 3D ou não"
      }
    ]
  }
]

#### Método [GET]: /Movies/{id]/find-sessions
Este endpoint retorna um array com uma lista de sessões que contém o FilmeId mencionado na rota e possuem no atributo "date" o mesmo valor informado na query do pedido.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhum filme, nenhum resultado será retornado.
- Se o filme em questão não tiver nenhuma sessão cadastrada, será retornado um array vazio.

##### Body da Requisição:
[
  {
    "date": "Dia e mês da sessão",
    "hour": "Horário da sessão",
    "dub": "Se a sessão é legendado ou dublado",
    "d3": "Se a sessão é 3D ou não"
  }
]

#### Método [POST]: /Movies
Este endpoint recebe os parâmetros do filme que será cadastrado e depois retorna o objeto criado.

##### Validação
- Para Cadastrar um filme não é necessário informar um id pois este é gerado automaticamente pelo Entity Framework.
- Não é possível cadastrar uma filme se já existir um filme cadastrado com o mesmo "title". Variações do title sem utilizações de caractéres especiais são permitidas. Exemplo: Avatar/Avatar 2 (permitido). Avatar/ avatar. (não permitido).
- Não é possível cadastrar um filme se todos os campos não estiverem devidamente preenchidos.
  
 ##### Body da Requisição:
 {
    "id": "FilmeId",
    "title": "Título do filme",
    "age": "Classificação Indicativa do filme",
    "length": "Duração em minutos do filme",
    "genre": "Gênero do filme",
    "imageUrl": "Url da imagem do filme",
 }
 
 #### Método [PUT]: /Movies/{id}
 Este endpoint permite atualizar os atributos de um filme com base no ID informado na rota. Os parâmetros fornecidos serão utilizados para atualizar o objeto correspondente e após será sertornado o objeto atualizado.
 
##### Validação
- Caso o ID mencionado na rota não pertença a nenhum filme, nenhum resultado será atualizado.
- Não é possível cadastrar um filme se todos os campos não estiverem devidamente preenchidos.

##### Body da Requisição:
{
    "id": "FilmeId",
    "title": "Título do filme",
    "age": "Classificação Indicativa do filme",
    "length": "Duração em minutos do filme",
    "genre": "Gênero do filme",
    "imageUrl": "Url da imagem do filme",
 }
 
#### Método [DELETE]: /Movies/{id}
Este endpoint permite deletar um filme om base no ID informado na rota.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhum filme, nenhum resultado será deletado.

### Room Endpoints

#### Método [GET]: /Rooms
Este endpoint retorna um array com uma lista contendo todas as salas cadastrados. Cada sala apresentará um array contendo uma lista de sessões cadastradas com aquele roomId.

##### Body da Requisição:
[
  {
    "id": "RoomId",
    "identification": "Identificação da sala",
    "screen": "Tamanho da tela da sala",
    "sessions": [
      {
        "date": "Dia e mês da sessão",
        "hour": "Horário da sessão",
        "dub": "Se a sessão é legendado ou dublado",
        "d3": "Se a sessão é 3D ou não"
      }
    ]
  }
]

#### Método [GET]: /Rooms/{id}
Este endpoint retorna uma sala com id específico mencionado na rota da requisição. A sala apresentará um array contendo uma lista de sessões cadastradas com aquele roomId.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhuma sala, nenhum resultado será retornado.

##### Body da Requisição:
[
  {
    "id": "RoomId",
    "identification": "Identificação da sala",
    "screen": "Tamanho da tela da sala",
    "sessions": [
      {
        "date": "Dia e mês da sessão",
        "hour": "Horário da sessão",
        "dub": "Se a sessão é legendado ou dublado",
        "d3": "Se a sessão é 3D ou não"
      }
    ]
  }
]

#### Método [POST]: /Rooms
Este endpoint recebe os parâmetros da sala que será cadastrada e depois retorna o objeto criado.

##### Validação
- Para Cadastrar um sala não é necessário informar um id pois este é gerado automaticamente pelo Entity Framework.
- Não é possível cadastrar uma sala se já existir um sala cadastrada com a mesma "identification". Variações da identification sem utilizações de caractéres especiais são permitidas. Exemplo: A1/A1B (permitido). A1/ a1. (não permitido).
- Não é possível cadastrar uma sala se todos os campos não estiverem devidamente preenchidos.
  
 ##### Body da Requisição:
 {
    "id": "RoomId",
    "identification": "Identificação da sala",
    "screen": "Tamanho da tela da sala",
 }
 
 #### Método [PUT]: /Rooms/{id}
 Este endpoint permite atualizar os atributos de uma sala com base no ID informado na rota. Os parâmetros fornecidos serão utilizados para atualizar o objeto correspondente e após será sertornado o objeto atualizado.
 
##### Validação
- Caso o ID mencionado na rota não pertença a nenhuma sala, nenhum resultado será atualizado.
- Não é possível cadastrar uma sala se todos os campos não estiverem devidamente preenchidos.

##### Body da Requisição:
{
    "id": "RoomId",
    "identification": "Identificação da sala",
    "screen": "Tamanho da tela da sala",
 }
 
#### Método [DELETE]: /Rooms/{id}
Este endpoint permite deletar uma sala com base no ID informado na rota.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhuma sala, nenhum resultado será deletado.

### Session Endpoints

#### Método [GET]: /Sessions
Este endpoint retorna um array com uma lista contendo todas as sessões cadastradas.

##### Body da Requisição:
[
  {
    "id": "SessionId",
    "date": "Dia e mês da sessão",
    "hour": "Horário da sessão",
    "dub": "Se a sessão é legendado ou dublado",
    "d3": "Se a sessão é 3D ou não"
    "movieId": "FilmeId",
    "movie": {
          "id": "FilmeId",
          "title": "Título do filme",
          "age": "Classificação Indicativa do filme",
          "length": "Duração em minutos do filme",
          "genre": "Gênero do filme",
          "imageUrl": "Url da imagem do filme",
             },
    "roomId": "RoomId",
    "room": {      
          "identification": "Identificação da sala",
          "screen": "Tamanho da tela da sala",
            }
  }
]

#### Método [GET]: /Sessions/{id}
Este endpoint retorna uma sessão com id específico mencionado na rota da requisição.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhuma sessão, nenhum resultado será retornado.

##### Body da Requisição:
[
  {
    "id": "SessionId",
    "date": "Dia e mês da sessão",
    "hour": "Horário da sessão",
    "dub": "Se a sessão é legendado ou dublado",
    "d3": "Se a sessão é 3D ou não"
    "movieId": "FilmeId",
    "movie": {
          "id": "FilmeId",
          "title": "Título do filme",
          "age": "Classificação Indicativa do filme",
          "length": "Duração em minutos do filme",
          "genre": "Gênero do filme",
          "imageUrl": "Url da imagem do filme",
             },
    "roomId": "RoomId",
    "room": {      
          "identification": "Identificação da sala",
          "screen": "Tamanho da tela da sala",
            }
  }
]

#### Método [POST]: /Sessions
Este endpoint recebe os parâmetros da sessão que será cadastrada e depois retorna o objeto criado.

##### Validação
- Para Cadastrar uma sessão não é necessário informar um id pois este é gerado automaticamente pelo Entity Framework.
- Não é possível cadastrar uma sessão se já existir uma sessão cadastrada com a mesmo "date", "hour" e "room", se algum desses atributos for diferente é permitido criar.
- Não é possível cadastrar uma sessão se todos os campos não estiverem devidamente preenchidos.
  
 ##### Body da Requisição:
 {
    "id": "SessionId",
    "date": "Dia e mês da sessão",
    "hour": "Horário da sessão",
    "dub": "Se a sessão é legendado ou dublado",
    "d3": "Se a sessão é 3D ou não"
    "movieId": "FilmeId",
    "roomID": "RoomID",
 }
 
 #### Método [PUT]: /Sessions/{id}
 Este endpoint permite atualizar os atributos de uma sessão com base no ID informado na rota. Os parâmetros fornecidos serão utilizados para atualizar o objeto correspondente e após será sertornado o objeto atualizado.
 
##### Validação
- Caso o ID mencionado na rota não pertença a nenhuma sessão, nenhum resultado será atualizado.
- Não é possível cadastrar uma sessão se todos os campos não estiverem devidamente preenchidos.

##### Body da Requisição:
 {
    "id": "SessionId",
    "date": "Dia e mês da sessão",
    "hour": "Horário da sessão",
    "dub": "Se a sessão é legendado ou dublado",
    "d3": "Se a sessão é 3D ou não"
    "movieId": "FilmeId",
    "roomID": "RoomID",
 }
 
#### Método [DELETE]: /Sessions/{id}
Este endpoint permite deletar uma sessão com base no ID informado na rota.

##### Validação
- Caso o ID mencionado na rota não pertença a nenhuma sessão, nenhum resultado será deletado.
