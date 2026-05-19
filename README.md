# PI---GastroLink
Repositório criado para fins acadêmicos com o objetivo de apresentar uma POC


1. Visão Geral do Sistema
O GastroLink é uma plataforma de marketplace de dois lados que conecta estabelecimentos gastronômicos a influenciadores digitais de nicho. A aplicação é composta por dois subsistemas independentes que se comunicam via API REST:

Frontend: aplicação web mobile-first em HTML5, CSS3 e JavaScript puro.
Backend: API REST construída com ASP.NET Core (.NET 10) em C#, com autenticação JWT e banco de dados MySQL.

2. Stack Tecnológica

Camada
Tecnologia
Versão / Detalhe
Frontend
HTML5 + CSS3 + JavaScript
Vanilla — sem framework
Backend
ASP.NET Core Web API (C#)
.NET 10
Autenticação
JWT Bearer (HS256)
Microsoft.AspNetCore.Authentication.JwtBearer 10.0.7
ORM
Entity Framework Core + Pomelo MySQL
EF Core 9.0.0 / Pomelo 9.0.0
Banco de Dados
MySQL
utf8mb4, auto-increment
Documentação API
Swagger / Swashbuckle
Swashbuckle.AspNetCore 10.1.7
Versionamento
Git + GitHub
github.com/yasumiti-nakahara/PI---GastroLink


3. Modelo de Dados
3.1 Entidades

Entidade
Campos Principais
Relacionamentos
Usuario
Id, Nome, Email, Senha, Role
1:1 com Restaurante ou Influencer
Restaurante
Id, NomeRestaurante, Endereco, Categoria, FotoUrl
FK: UsuarioId → Usuarios
Influencer
Id, Instagram, TipoConteudo, Contato, FotoUrl
FK: UsuarioId → Usuarios
Proposta
Id, Seguidores, Descricao, Contato, Status
FK: InfluencerId, RestauranteId
Parceria
Id, DataParceria
FK: InfluencerId, RestauranteId


3.2 Fluxo de Status
A entidade Proposta possui um campo Status que transita entre os seguintes estados ao longo do ciclo de vida da parceria:

Pendente  →  Aceita  (cria registro em Parcerias automaticamente)
Pendente  →  Recusada  (proposta encerrada sem criação de parceria)

Uma proposta aceita ou recusada não pode ter seu status alterado novamente — a regra de negócio é validada no ParceriasController antes de qualquer modificação.

4. Endpoints da API
4.1 Autenticação — /api/auth

Método
Rota
Descrição
Auth
POST
/api/auth/register
Cadastra novo usuário
Não
POST
/api/auth/login
Autentica e retorna JWT
Não


Exemplo — Registro:
POST /api/auth/register
{
  "nome": "Lucas Mendes",
  "email": "lucas@gastrolink.com",
  "senha": "senha123",
  "role": "Influencer"
}

Exemplo — Resposta do Login:
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "message": "Login bem-sucedido."
}

4.2 Influencers — /api/influencers  (Role: Influencer)

Método
Rota
Descrição
GET
/api/influencers
Lista todos os influencers
GET
/api/influencers/{id}
Busca por ID
POST
/api/influencers
Cria perfil (vinculado ao usuário logado)
PUT
/api/influencers/{id}
Atualiza campos — todos opcionais (PATCH semântico)
DELETE
/api/influencers/{id}
Remove perfil


4.3 Restaurantes — /api/restaurantes  (Role: Restaurante)

Método
Rota
Descrição
GET
/api/restaurantes
Lista todos os restaurantes
GET
/api/restaurantes/{id}
Busca por ID
POST
/api/restaurantes
Cria perfil (vinculado ao usuário logado)
PUT
/api/restaurantes/{id}
Atualiza campos — todos opcionais
DELETE
/api/restaurantes/{id}
Remove perfil


4.4 Propostas — /api/propostas  (Role: Influencer)

Método
Rota
Descrição
GET
/api/propostas/{id}
Busca proposta por ID
POST
/api/propostas
Cria proposta — InfluencerId extraído do JWT


Exemplo — Criar proposta:
POST /api/propostas
Authorization: Bearer {token}
{
  "seguidores": "45000",
  "contato": "(11) 99999-0000",
  "descricao": "Reviews gastronômicos no Instagram e TikTok.",
  "restauranteId": 1
}

4.5 Parcerias — /api/parcerias  (Role: Restaurante)

Método
Rota
Descrição
POST
/api/parcerias/{propostaId}
Aceita proposta → cria Parceria automaticamente
PUT
/api/parcerias/recusar/{propostaId}
Recusa proposta → atualiza Status para Recusada


5. Como Executar o Projeto
5.1 Pré-requisitos

.NET 10 SDK
MySQL Server (local ou remoto)
Git

5.2 Configuração

1. Clonar o repositório
git clone https://github.com/yasumiti-nakahara/PI---GastroLink.git
cd PI---GastroLink/GastroLink_Api

2. Configurar secrets locais (nunca commitar no Git)
dotnet user-secrets set "ConnectionStrings:DefaultConnection"
  "Server=localhost;Database=gastrolink;User=root;Password=SUA_SENHA;"
dotnet user-secrets set "Jwt:Key"
  "gastrolink-chave-secreta-minimo-32-caracteres-2026"

3. Aplicar a migration
dotnet ef database update

4. Executar a API
dotnet run
# API: http://localhost:5170
# Swagger: http://localhost:5170/swagger

5. Abrir o frontend
Abra o arquivo index.html diretamente no navegador ou sirva com a extensão Live Server do VS Code.

6. Estrutura de Arquivos

PI---GastroLink/
│
├── GastroLink_Api/                  # Backend ASP.NET Core
│   ├── Controllers/
│   │   ├── AuthController.cs
│   │   ├── InfluencersController.cs
│   │   ├── RestaurantesController.cs
│   │   ├── PropostasController.cs
│   │   └── ParceriasController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── DTOs/
│   │   ├── Auth/        (LoginDto, RegisterDto)
│   │   ├── Influencer/  (Create, Read, Update)
│   │   ├── Restaurante/ (Create, Read, Update)
│   │   ├── Proposta/    (Create, Read)
│   │   └── Parceria/    (Read)
│   ├── Entities/
│   │   ├── Usuario.cs
│   │   ├── Restaurante.cs
│   │   ├── Influencer.cs
│   │   ├── Proposta.cs
│   │   └── Parceria.cs
│   ├── Migrations/
│   ├── Services/
│   │   └── TokenService.cs
│   └── Program.cs
│
└── PI---GastroLink/src/              # Frontend HTML/CSS/JS
    ├── index.html
    ├── login.html
    ├── restaurante.html
    └── css/
        └── style.css
