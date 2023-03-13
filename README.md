# Api Cinema

Esta é uma api para um site de cinema, responsável pelo cadastro de filmes, salas e sessões, assim como, suas respectivas visualizações.

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
- Se um id não pertencente a nenhum filme for mencionado na rota, nada será retornado.

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
- Se um id não pertencente a nenhum filme for mencionado na rota, nada será retornado.
- Se o filme não tiver nenhuma sessão cadastrada, ele retornará um array vazio.

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
 Este endpoint permite atualizar os atributos de um filme com base no ID informado na rota. Os parâmetros fornecidos serão utilizados para atualizar o objeto correspondente.
