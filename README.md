# SISTEMA DE LOGIN E CADASTRO
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/devsuperior/sds1-wmazoni/blob/master/LICENSE) 

# Sobre o projeto


Esta aplicação full stack web, sistema de Login e Cadastro, foi desenvolvida por conta de um desafio desenvolvido pela empresa "" Onde foi solicitado um sistema de Login e registros de cadastros.

A aplicação consiste em dois CRUD-(Create, Read, Update and Delete) uma para o cadastro de usuários e outro de contatos. Nela exploramos a construção de telas como login, cadastro, edição, exclusão, redefinição de senhas e ações como alertas por email ao usuário via protocolos SMTP. O modelo e liguagem utilizada foi o ASP .NET CORE MVC-(Model, View and Controller).


## Layout web
![Web 1](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20PG%20Inicial%20ADM.png) 

### Layout - Login/Esqueceu a senha
![Login](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Login.png) ![Esqueceu Senha](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Redefinir%20senha.png) 

### Layout - Tela de Usuários
- Está tela só poderá ser vista apenas por usuários do tipo administrador.
- Ao cadastar qualquer usuário será enviado uma email de confirmação.

![Usu](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20PG%20Usuarios%20ADM.png) ![Usu Cadastrar](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20PG%20Usuarios%20Cadastro%20ADM.png) 
![Usu Editar](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20PG%20Usuarios%20Editar%20ADM.png) ![Usu Apagar](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20PG%20Usuarios%20Apagar%20ADM.png) 

### Layout - Tela de Contatos
- Está tela só poderá ser visto por qualquer usuário.

![Cont](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Contatos%20lista%20Filtro.png) ![Cont Cadastrar](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Contatos%20Criar.png) 
![Cont Editar](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Contatos%20Editar.png) ![Cont Apagar](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Contatos%20Apagar.png) 

### Layout - Tela de Alterar Senha
- Está tela só poderá ser visto por qualquer usuário e segue os seguintes parâmetros:
- Deve conter a senha atual correta;
- A nova senha deve ser diferente da senha anterior;
- O campo nova senha e confirmação de senha deve conter a mesma senha.

![Redefinir Senha](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Altear%20Senha.png) 


# Tecnologias utilizadas
## Back end
- C#
- ASP .NET CORE MVC
## Front end
- HTML / CSS / JS 
- BOOTSTRAP
- JQUERY
## Implantação em produção
- Banco de dados: SQL Server

# Como executar o projeto

## Back end
Pré-requisitos: .NET 6

```bash
# clonar repositório

# entrar na pasta do projeto back end
cd ControleDeCOntatos
# executar o projeto
dotnet run

```

## Banco de Dados
Pré-requisitos: SQL SERVER

```bash
# clonar repositório
git clone https://github.com/devsuperior/sds1-wmazoni
# entrar no arquivo appsttingns.json e reconfigurar a ConectionStrins e SMTP para sua realidade
"ConnectionStrings": {
    "DataBase": "Data Source=./;Initial Catalog=Db_CadastroContatos;Persist Security Info=True;User ID=sa;Password=********"
  },
  "SMTP": {
    "UserName": "meu email@hotmail",
    "Nome": "Oliveira Trade - Sistema de Contatos",
    "Host": "smtp-mail.outlook.com",
    "Senha": "senha do email",
    "Porta": 587
  },
# realizar migration e update no banco SQL Server
Add-Migration NOmeDaMIgracao -Context NomeDaTabela
Update-Database -Context NomeDaTabela
```

# Autor

Júlio César de Mesquita Camilo Martins

https://www.linkedin.com/in/dev-julio-c-martins/
