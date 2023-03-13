# Api Cinema

Esta é uma api para um site de cinemma, responsável pelo cadastro de filmes, salas e sessões, assim como, suas respectivas visualizações.

## Endpoints

A seguir estão os endpoints disponíveis nesta API.

### Movie Endpoints

Método [GET]:
/Movies - Retorna um array com uma lista contendo todos os filmes, cada filme cadastrado apresentará um array contendo uma lista de sessões cadastradas com aquele filmeId.

Body da Requisição:
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
