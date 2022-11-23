# SISTEMA DE LOGIN E CADASTRO
[![NPM](https://img.shields.io/npm/l/react)](https://github.com/devsuperior/sds1-wmazoni/blob/master/LICENSE) 

# Sobre o projeto

https://wmazoni-sds1.netlify.app

Esta aplicação full stack web, sistema de Login e Cadastro, foi desenvolvida por conta de um desafio desenvolvido pela empresa "" Onde foi solicitado um sistema de Login e registros de cadastros.

A aplicação consiste em dois CRUD-(Create, Read, Update and Delete) uma para o cadastro de usuários e outro de contatos. Nela exploramos a construção de telas como login, cadastro, edição, exclusão, redefinição de senhas e ações como alertas por email ao usuário via protocolos SMTP. O modelo e liguagem utilizada foi o ASP .NET CORE MVC-(Model, View and Controller).


## Layout web
![Web 1](https://github.com/acenelio/assets/raw/main/sds1/web1.png) 

### Layout - Login/Esqueceu a senha
![Login](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Altear%20Senha.png) ![Esqueceu Senha](https://github.com/devjuliomesquita/ControleDeContatos/blob/master/ControleDeContatos/Acetss/OT%20-%20Altear%20Senha.png) 

### Layout - Tela de Usuários
- Está tela só poderá ser vista apenas por usuários do tipo administrador.
- Ao cadastar qualquer usuário será enviado uma email de confirmação.
![Usu](https://github.com/acenelio/assets/raw/main/sds1/web1.png) ![Usu Cadastrar](https://github.com/acenelio/assets/raw/main/sds1/web1.png) 
![Usu Editar](https://github.com/acenelio/assets/raw/main/sds1/web1.png) ![Usu Apagar](https://github.com/acenelio/assets/raw/main/sds1/web1.png) 

### Layout - Tela de Contatos
- Está tela só poderá ser visto por qualquer usuário.
![Cont](https://github.com/acenelio/assets/raw/main/sds1/web1.png) ![Cont Cadastrar](https://github.com/acenelio/assets/raw/main/sds1/web1.png) 
![Cont Editar](https://github.com/acenelio/assets/raw/main/sds1/web1.png) ![Cont Apagar](https://github.com/acenelio/assets/raw/main/sds1/web1.png) 

### Layout - Tela de Alterar Senha
- Está tela só poderá ser visto por qualquer usuário e segue os seguintes parâmetros:
-- Deve conter a senha atual correta;
-- A nova senha deve ser diferente da senha anterior;
-- O campo nova senha e confirmação de senha deve conter a mesma senha.
![Redefinir Senha](https://github.com/acenelio/assets/raw/main/sds1/web1.png) 


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
cd backend
# executar o projeto

```

## Banco de Dados
Pré-requisitos: SQL SERVER

```bash
# clonar repositório
git clone https://github.com/devsuperior/sds1-wmazoni
# entrar na pasta do projeto front end web
cd front-web
# instalar dependências
yarn install
# executar o projeto
yarn start
```

# Autor

Júlio César de Mesquita Camilo Martins

https://www.linkedin.com/in/dev-julio-c-martins/
