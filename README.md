# RHTech

Desenvolvi um crud para Candidatos e Empresas num sistema fictício de recrutamento e seleção de candidatos.
Utilizei Arquitetura Clean, .net 6.0, Razor + jquery no front.
Utilizei um template html5 para incrementar o front-end.

## RhTech.Core.Application
   Onde implementa regras da aplicação nos services. Aqui também ficam os Validadores, Helpers, Mappings, ViewModels.

## RhTech.Core.Domain
   Onde ficam as regras do negócio, interfaces do repository e entidades de banco de dados.

## RhTech.Infra.Data   
   Acesso a dados. Aqui fica o RhTechDbContext responsável por mapear nosso banco de dados. Fiz uma implementação genérica para funcionalidades de crud que são herdadas por cada repository.

# Configurando a solução

1. Criar um Banco de Dados chamado RhTech  no SQL Server

2. Atualizar a connection string no appsettings

3. No Gerenciador de Console do NUGET: Executar o comando migration update-database (RHTech.Webapplication como projeto inicial)

4. Executar a solução
   
