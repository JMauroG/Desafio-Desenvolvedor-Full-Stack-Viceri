# Desafio-Desenvolvedor-Full-Stack-Viceri

## Sobre
- Me baseando no template do Milan Jovanovic, utilizei a Arquitetura limpa em conjunto com CQRS e DDD. Mesmo tendo o conhecimeento que são padrões que podiam gerar uma carga de complexidade a uma ideia simples, optei por segui los tendo em mente que:
  - Buscava facilidade na manutenção da aplicação e na criação dos testes unitários , sedno assim utilizei a arquitetura limpa
  - Inicialmente planejava utilizar uma base de dados para leitura e outra para escrita, e isso "justificaria" a ideia do CQRS.
- Para a base de dados preferi por utilizar o EF junto a SQL Server tendo em vista a simplicidade de configurar um container no docker.
- A interface gráfica foi desenvolvida em Angular, utilizando Angular Material.

- link para o template -> https://www.milanjovanovic.tech/pragmatic-clean-architecture?utm_source=ca-template

## Como usar

### BACKEND
- Primeiro, devemos rodar o docker-compose.yml na raiz do projeto com o comando ```docker-compose up```
- Em seguida executar a migration para montar as tabelas
- Agora podemos rodar o projeto
  - Obs.: o Swagger ficará exposto na seguinte url -> https://localhost:5001/swagger/index.html

### FRONTEND
- Abra a pasta do projeto no powershell ou cmd
- Em seguida, deve-se utilizar o comando  ```npm i```
  - Caso não possua CLI do Angular, é necessário executar o comando ```npm i @angular/cli```
- Ao final, é só executar o comando ```ng s``` e a aplicação ficará disponível na url http://localhost:4200
