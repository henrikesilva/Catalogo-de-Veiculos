# Catalogo de Veiculos - CatVeic

Esse projeto foi desenvolvido com o objetivo de catalogar veiculos a venda.

A arquitetura foi pensada se baseando no DDD, porém não foram aplicadas todas as práticas recomendadas e/ou indicadas no desenvolvimento do mesmo, por conta do scopo para o qual foi sugerido o mesmo.

O banco de dados não tem migrations configurada, por tanto deverá ser criado executando o script direto no gerenciador de banco de dados de sua preferência, desde que o mesmo seja SQL Server.

## Autor
- Henrique da Silva Lima 
- Ano: 01/2023

## Requisitos de instalação
Para o correto funcionamento do sistema você deverá ter pré instalado 
- .Net 6 ou superior
- SQL Server
- Angular 15.1.1
- NodeJs a partir da versão v18.12.1
- Npm 8.19.2

As versões aqui indicadas são as mesmas utilizadas na criação do projeto. É indicado utilizar as mesmas para evitar a utilização de alguma ferramenta que possa estar desatualizado em versões posteriores ou ainda não oferecerem suporte em versões anteriores.

### Configuração do Banco de Dados
<img src="https://github.com/henrikesilva/Catalogo-de-Veiculos/blob/main/Banco%20de%20Dados/mer.png" title="hover text">

Para que o sistema funcione corretamente é necessário executar o script com o nome "Query Banco" localizado na pasta 'Banco de Dados' presente nesse repositório.

<a href="https://github.com/henrikesilva/Catalogo-de-Veiculos/blob/main/Banco%20de%20Dados/QUERY%20Banco.sql">Link script de banco de dados</a>

* É de extrema importância a criação do banco de dados para que os dados possam ser persistidos no sistema.


## Iniciando os projetos
### Instalando e iniciando o backend:
 - Após a criação do banco de dados você estará apto a utilizar a API presente nesse repositorio com o nome "CatalagoVeiculos";
 - Antes da primeira execução da API é necessaria a configuração da conexão com o banco de dados criado na etapa anterior.
    - Para isso você deve extrair a connection string de seu SQL Management Studio ou do seu banco na azure e informa-lo no arquivo "appsettings.development.json"
      - que pode ser encontrado na pasta "CatalogoVeiculos.API"  >> "AppSettings.Development.json";
      - Substitua o valor "Data Source=DESKTOP-GALLS95;Initial Catalog=CatalogoVeiculo;Integrated Security=True" por sua connectionString, mantendo o campo Connection do jeito que está.
    - ex: "Connection": "minha-string-aqui"

Após a substituição da Connection String você deverá estar apto a executar a API pela primeira vez.


### Instalando e iniciando o frontend:
- Para executar o frontend é necessário realizar a instalação do angular cli utilizando o comando a seguir:
  - Obs. Caso você tenha o angular cli instalado em sua maquina esse passo não é necessário
```
npm install -g @angular/cli
```

- Após instalar o angular cli, você deverá executar o comando a seguir para instalar as dependênciar do projeto:
- Esse passo pode levar um tempo
```
npm i
```

#### Iniciando o frontend:
- Instalada todas as dependências do projeto, o próximo passo é configurar a rota correta da API, pois ela pode estar executando em uma porta diferente da configurada por padrão.
- Para isso basta alterar o campo "apiBaseUrl" presente no arquivo nomeado de "ArquivoConfig.ts" que você encontrará no caminho abaixo:
- src > Models > ArquivoConfig.ts
- Após alterar esse campo para o endereço da sua API você estará apto a executar o frontend;
- Para inciar o frontend basta digitar o seguinte comando no seu terminal dentro da pasta do projto web
```
npm start
```

### Utilizando o sistema
- A ordem apresentando nesse documento é a indicada para o seu uso, pois caso contrario você não conseguira cadastrar todas as informações
- Recomendo que siga a ordem para garantir o funcionamento correto.

### Usuario Comum:
#### Tela Inicio
- O frontend irá carregar a página 'Inicio' sem autenticação, porém irá apresentar mensagens de alertas, caso você ainda não tenha nenhum veiculo cadastrado na base.
- Essa é a unica tela em que não é necessário estar logado no sistema.

#### Login

- O primeiro login pode ser realizado utilizando um usuario padrão de sistema;
- Esse usuário tem funções limitadas e DEVE ser usado apenas para que você possa cadastrar o seu usuário definitivo para uso.
  - Usuario: administrador
  - Senha: t3ste@123
- Após criar o seu login efetue o logon e entre com a sua conta criada;

### Usuario administrador:
#### Cadastrar Usuario
- Essa tela permite que você cadastre um novo usuario;
- Preencha todos os campos para que o cadastro funcione corretamente;

#### Gerenciar Usuarios
- A tela de gerenciamento de usuarios permite visualizar quais usuarios estão cadastrados e ativos;
- O botão com o simbolo da lixeira permite inativar um usuario cadastrado;
- O botão com um simbolo do lápis permite visualizar e atualizar/editar um usuario cadastrado;
- Para adicionar uma nova marca você deverá ir em Usuario >> Cadastrar

#### Cadastrar Marca
- Essa tela permite que você cadastre uma nova marca;
- Preencha todos os campos para que o cadastro funcione corretamente;

#### Gerenciar Marcas
- A tela de gerenciamento de marcas permite visualizar quais marcas estão cadastradas e ativas;
- O botão com o simbolo da lixeira permite inativar uma marca cadastrada;
- O botão com um simbolo do lápis permite visualizar e atualizar/editar uma marca cadastrada;
- Para adicionar uma nova marca você deverá ir em Marca >> Cadastrar

#### Cadastrar Modelo
- Essa tela permite que você cadastre uma novo modelo e reutilize no cadastro de N veiculos;
- Preencha todos os campos para que o cadastro funcione corretamente;

#### Gerenciar Modelo
- A tela de gerenciamento de modelos serve para mostrar quais modelos estão cadastrados e ativos/inativos;
- O botão com o simbolo da lixeira permite inativar um modelo cadastrado;
- O botão com um simbolo do lápis permite visualizar e atualizar/editar um modelo cadastrado;
- Para adicionar uma nova marca você deverá ir em Modelo > Cadastrar

#### Cadastrar Veiculo
- Essa tela permite que você cadastre uma novo veiculo;
- Preencha todos os campos para que o cadastro funcione corretamente;

#### Inicio (usuario administrador)
- A tela de gerenciamento de modelos serve para mostrar quais modelos estão cadastrados e ativos/inativos;
- O botão excluir da lixeira serve para inativar um veiculo cadastrado;
- O botão detalhes permute visualizar o veiculo e atualizar/editar esse veiculo cadastrado;
- Para adicionar uma nova marca você deverá ir em Modelo > Cadastrar

## Contribuição

A branch main está bloqueada para alterações, no entanto é possivel criar uma nova branch a partir dela e sugerir modificações ou ainda apresentar ideias e comentarios a respeito do sistema.
