<p align="center">
	<img src="https://github.com/gustmrg/dotnet-music-discover-api/blob/main/rest-api-icon-8.png" width="90" height="90" />
</p>
<h3 align="center">Music Discover</h3>

<p align="center">
	<img alt="License" src="https://img.shields.io/badge/license-MIT-%2304D361" />
</p>


## :trophy: Sobre o projeto

<p>Este projeto é uma <b>Web API construída com .NET 7.0</b> que aceita solicitações RESTful com a localização informada pelo usuário e retorna uma sugestão de playlist de músicas de acordo com a temperatura atual.
</p>

<p>As informações de localização, temperatura, músicas e playlists são obtidas através do <b>consumo das APIs externas da OpenWeather e Spotify.</b></p>

## :gear: Pré-requisitos

- .NET 7.0

## :file_folder: Rodando o aplicativo localmente

```bash
# Clone este repositório
$ git clone https://github.com/gustmrg/dotnet-music-discover-api.git

# Navegue até a pasta
$ cd dotnet-music-discover-api

# Execute a aplicação
$ dotnet run
```

:exclamation: Não esquecer de adicionar uma API Key para OpenWeather e credenciais para utilizar a API do Spotify no <b>appsettings.json</b>.

## :star: Features

- [x] Consumo de API externa do OpenWeather
- [ ] Consumo de API externa do Spotify
- [ ] Sugestão de músicas baseada na localização do usuário
- [ ] Sugestão de músicas baseada na temperatura da localização do usuário

## :rocket: Tecnologias

Este projeto foi desenvolvido com a(s) seguinte(s) tecnologia(s):

- .NET 7.0

## :blue_book: Bibliotecas

Este projeto utilizou:

- RestSharp
- Json.NET
- Swashbuckle/Swagger

## :page_with_curl: Licença

Esse projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE.md) para mais detalhes.

---
