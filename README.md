# Projeto Tasks - V1

## O intúito do projeto é facilitar a organização do usuário de uma maneira dinâmica e fácil de ser utilizada
<br>

## Rotas de Usuário
---

Cadastrar-se
---
#### Faz o cadastro do usuário no sistema.
```JSON
{
    "rote": "/user/SingUp",
    "verb": "POST",
    "requiresAuthentication": false,
    "bodyRequest": {
        "name": "string",
        "lastName": "string",
        "email": "string",
        "password": "string"
    },
    "responseJSON": {
        "Userid": 0
    },
    "statusCodeSuccess": "201 (Created)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business: 
- O campo de email não deve se repetir no sistema;
- Quando um login é criado, ele não tem acesso as outras rotas. Para poder ter o acesso, o usuário deve ativar sua conta utilizando as rotas "/user/SendActivationEmail" e "/user/ActivateAccount/";
- A senha deve ser gravada no banco utilizando uma criptografia de hash.

<br>

Enviar E-mail de ativação
---
#### Após o usuário ser cadastrado, essa rota deve ser utilizada para enviar um código de ativação no e-mail do usuário.
```JSON
{
    "rote": "/user/SendActivationEmail",
    "verb": "PUT",
    "requiresAuthentication": false,
    "bodyRequest": {
        "email": "string",
    },
    "responseJSON": {
        "UserId": 0
    },
    "statusCodeSuccess": "200 (OK)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business:
- Deve ser enviado um e-mail para usuário ativar sua conta. O e-mail enviado irá conter uma chave de ativação, que o usuário podera utilzar na rota "/user/ActivateAccount/..." para ativar sua conta.

<br>

Ativar conta
---
#### Após criar um cadastro, o email deve ser validado para a conta ser ativada. O usuário deve enviar o código de ativação que foi enviado no e-mail do prório nesta rota, para ativar sua conta.
```JSON
{
    "rote": "/user/ActivateAccount/{UserId:int}/{key:int}",
    "verb": "GET",
    "requiresAuthentication": false,
    "bodyRequest": {},
    "responseJSON": {},
    "statusCodeSuccess": "200 (OK)",
    "statusCodeError": "400 (Bad Request)"
}
```

<br>

Login
---
#### Faz a autenticação do usuário, retornando um Access Token e um Refresh Token. 
#### O Access Token deve ser utilizado para acessar outras rotas, quanto ao Refresh Token, deve ser utilizado para conseguir um novo Access Token quando o mesmo expirar.
```JSON
{
    "rote": "/user/Login",
    "verb": "POST",
    "requiresAuthentication": false,
    "bodyRequest": {
        "email": "string",
        "password": "string"
    },
    "responseJSON": {
        "accessToken": "string",
        "refreshToken": "string",
    },
    "statusCodeSuccess": "200 (OK)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business:
- As credenciais devem ser válidas;
- A conta do usuário deve estar ativada.

<br>

Refresh Token
---
#### Gera um novo Access Token / Refresh Token.
```JSON
{
    "rote": "/user/RefreshToken",
    "verb": "PUT",
    "requiresAuthentication": true,
    "bodyRequest": {
        "refreshToken": "string",
        "accessToken": "string"
    },
    "responseJSON": {
        "accessToken": "string",
        "refreshToken": "string"
    },
    "statusCodeSuccess": "200 (OK)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business:
- O campo de expiração do RefreshToken não pode ter sido excedido.
- O Refresh Token deve ser do mesmo usuário do Access Token

<br>

Revoke Token
---
#### Limpa o Refresh Token do registro do usuário, fazendo com que o Refresh Token não possa gerar um novo Access Token.
```JSON
{
    "rote": "/user/RevokeToken",
    "verb": "PUT",
    "requiresAuthentication": true,
    "bodyRequest": {},
    "responseJSON": {},
    "statusCodeSuccess": "200 (Ok)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business:
- Deve ser limpado o Refresh Token do usuário contido no Access Token.

<br>

## Rotas do Workspace
---

Criar Workspace
---
#### Cria um Workspace, onde ficaram os Buckets e Tasks do usuário.
```JSON
{
    "rote": "/Workspace",
    "verb": "POST",
    "requiresAuthentication": true,
    "bodyRequest": {
        "workspace": "string",
        "ownerId": 0
    },
    "responseJSON": {},
    "statusCodeSuccess": "200 (Ok)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business: 
- Quando é criado um Workspace, deve ser adicionado o criador do Workspace como integrante do mesmo;
- Apenas os integrantes do Workspace podem ter acesso a ele.

<br>

Listar Workspaces do usuário
---
#### Lista os Workspaces que o usuário participa.
```JSON
{
    "rote": "/Workspace",
    "verb": "GET",
    "requiresAuthentication": true,
    "bodyRequest": {},
    "queryParams": {
        "showInactive": false,
        "page": 0,
        "limit": 0
    },
    "responseJSON": {
        "collection": [
            {
                "id": 0,
                "workspace": "string",
                "inactive": false
            }
        ],
        "total": 0
    },
    "statusCodeSuccess": "200 (Ok)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business: 
- Os Workspaces só podem ser mostrados para os integrantes do mesmo.

<br>

Buscar Workspace
---
#### Busca o Worspace selecionado pelo usuário.
```JSON
{
    "rote": "/Workspace/{idWorkspace:int}",
    "verb": "GET",
    "requiresAuthentication": true,
    "bodyRequest": {},
    "responseJSON": {
        "workspace": "string",
        "bucket": [
            {
                "id": 0,
                "bucket": "string",
                "position": 0,
                "inactive": false
            }
        ]
    },
    "statusCodeSuccess": "200 (Ok)",
    "statusCodeError": "404 (Not Found)"
}
```
Business:
- Apenas os integrantes do workspace podem consulta-lo

<br>

Alterar Workspace
---
#### Altera os valores do Workspace especificado.
```JSON
{
    "rote": "/Workspace/{idWorkspace:int}",
    "verb": "PUT",
    "requiresAuthentication": true,
    "bodyRequest": {
        "workspace": "string"
    },
    "responseJSON": {},
    "statusCodeSuccess": "200 (Ok)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business: 
- Apenas os integrantes do Workspace podem altera-lo.

<br>

Ativar/Inativar Workspace
---
#### Ativa ou inativa o Workspace dependendo da atual situação do mesmo.
```JSON
{
    "rote": "/Workspace/{idWorkspace:int}/ExclusaoLogica",
    "verb": "PUT",
    "requiresAuthentication": true,
    "bodyRequest": {},
    "responseJSON": {
        "inactive": false
    },
    "statusCodeSuccess": "200 (Ok)",
    "statusCodeError": "400 (Bad Request)"
}
```
Business: 
- Quando um Workspace for inativado, deve inativar também todos os Buckets e Tasks referente a ele;
- Quando um Workspace for ativado, deve ativar também todos os Buckets e Tasks que foram inativados, porém apenas os que foram inativados pela inativação do Workspace.


Adicionar membro a equipe
Desc: Manda um e-mail para um usuário para que ele entre na equipe
Business: 
O usuário não pode estar na equipe quando a solicitação for enviada
Remover membro da equipe
Desc: Remove um membro de uma determinada equipe
Business: 
O membro só pode ser removido pelo owner do Workspace
Todas as tarefas do membro removido devem ser desanexadas dele
Listar membros da equipe
Desc: Lista os membros da equipe
Business:
Apenas os membros da equipe podem listar os membros da equipe
Criar Bucket
Desc: Adiciona um Bucket ao determinado Workspace, o bucket é uma forma de organizar as tarefas do usuário e é onde serão adicionados as Tasks
Business: 
Os buckets devem ter uma ordem
Devem estar anexadas a um Workspace
Listar Buckets 
Desc: Lista os Buckets de um determinado Workspace
Business:
Os buckets devem ser listados apenas por um determinado Workspace
Os buckets só podem ser listados por um integrante do Workspace
Devem ser listados também as Tasks do Bucket
Alterar Bucket
Desc: Altera os valores do bucket
Business: 
Apenas os integrantes do Workspace podem alterar o Bucket
Inativar Bucket
Desc: Inativa ou ativa o Bucket dependendo da atual situação do mesmo
Business: 
Quando um Bucket for inativado, todos as Tasks devem ser inativadas também
Criar Task
Desc: Cria uma Task em um Bucket
Business: 
A Task deve ter obrigatoriamente um Bucket
Listar Tasks
Desc: Lista as tasks de um determinado Workspace
Business:
As Tasks só podem ser listadas por integrantes do Workspace
Criar status
Desc: Cria um status para um determinado workspace
Listar Status
Desc: Lista os Status
Alterar status
Desc: Altera os status criados pelos usuário
Inativar/Ativar Status
Desc: Altera a situação de ativação do status dependendo da situação atual
Business:
Quando o status for inativado, todos as tasks que estão com esse status marcados devem ser alterados para algum status default do sistema.
Alterar status da Task
Desc: Altera o status de uma Task
Business:
O status só pode ser alterado por um membro do Workspace
Alterar Task
Desc: Altera os valores da Task 
Business: 
Apenas os integrantes do Workspace podem alterar a Task
Anexar membro a Task
Desc: Anexa um membro a uma determinada Task
Business: 
Apenas os membros do Workspace podem ser anexados
Remover membro a Task
Desc: Remove um membro a uma determinada Task
Business: 
Apenas os membros do Workspace podem ser anexados
Inativar/Ativar Task
Desc: Inativa ou ativa a Task dependendo da atual situação do mesmo
Business:
Apenas os integrantes do Workspace podem inativar/ativar a Task
Quando inativado, todas Checklists referentes a ele devem ser inativadas
Quando ativado, todas Checklists referentes a ele devem ser reativadas
Quando ativadas, deve, ser adicionadas ao primeiro Bucket do Workspace, caso não exista Bucket, deve ser criado um para ser adicionado
Adicionar Etiqueta a Task
Desc: Adiciona uma etiqueta a Task
Business: 
Apenas os integrantes do Workspace podem adicionar uma etiqueta
Remover Etiqueta da Task
Desc: Adiciona uma etiqueta a Task
Business: 
Apenas os integrantes do Workspace podem remover uma etiqueta
Criar Etiqueta para o Workspace
Desc: Cria uma etiqueta para ser usada nas Tasks do Workspace
Business: 
Apenas os integrantes do Workspace podem criar uma etiqueta
Deletar Etiqueta do o Workspace
Desc: Deleta uma etiqueta para ser usada nas Tasks do Workspace
Business: 
Apenas os integrantes do Workspace podem deletar uma etiqueta
Upload anexo da Task
Desc: Adiciona um anexo a Task
Deletar anexo da Task
Desc: Deleta o anexo da Task
Download anexo
Desc: Faz o download do anexo 
Listar anexo
Desc: Lista os anexos
Adicionar Checklist
Desc: Adiciona uma Checklist a uma Task
Business: 
Apenas os integrantes do Workspace podem criar um Checklist
Listar Checklist
Desc: Lista os Checklists 
Business: 
Apenas os integrantes do Workspace podem criar um Checklist
Alterar Checklist
Desc: Altera os valores do Checklist
Business: 
Apenas os integrantes do Workspace podem alterar um Checklist
Deletar Checklist
Desc: Deleta um Checklist de uma tarefa
Business:
Apenas os integrantes do Workspace podem alterar um Checklist
Quando deletado, todos os itens devem ser deletados também
Adicionar Item ao Checklist
Desc: Adiciona um Item ao Checklist
Business:
Apenas os membros do Workspace podem adicionar um item ao Checklist
Remover Item de um Checklist
Desc: Remove um Item de uma Checklist
Business: 
Apenas os membros do Workspace podem adicionar um item ao Checklist
Alterar estado do Item
Desc: Conclui ou reseta o status do Item
 Business: 
Apenas os membros do Workspace podem adicionar um item ao Checklist
