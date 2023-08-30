# RHTech

Desenvolvi um crud para Candidatos e Empresas num sistema fictício de recrutamento e seleção de candidatos.
Utilizei Arquitetura Clean, .net 6.0, Razor + jquery no front.

# RhTech.Core.Application
   Onde implementa regras da aplicação. Validadores, Helpers, Mappings, ViewModels.

# RhTech.Core.Domain
   Onde ficam as regras do negócio e entidades de banco de dados.

# Configurando a solução

1. Criar um Banco de Dados chamado RhTech  no SQL Server

2. Atualizar a connection string no appsettings

3. No Gerenciador de Console do NUGET: Executar o comando migration update-database (RHTech.Webapplication como projeto inicial)

4. Executar a solução
   
