# RoleTop Mvc  

![RoleTop](https://user-images.githubusercontent.com/54954718/77608567-6398e580-6efc-11ea-88ab-274adddf5a46.png)

## Sobre o Projeto :blue_book:
Um site de eventos onde o usuario pode visualizar os eventos que ocorreram e ainda mais como :  
**Pagina principal**
+ *Imagens do salão*
+ *Infraestrutura*
+ *FAQ* 
+ *Orçamentos*
+ *Serviços* 
+ *Localização*
+ *Calendario* 
#### Funcionalidades
+ Usuario
  + Cadastro de usuario
  + Login de Usuario
  + Logout de Usuario
  + Atualização de perfil do usuario
+ Evento
  + Cadastro de evento
  + Listagem de evento para um usuario especifico
  + Remover evento
+ Suporte
  + Enviar mensagens diretamente para o adm
+ Pagamento
## Configurações de ambiente :clipboard:
####  Instalaçôes
 * Pacotes SDKs  
  >[.Net Core 2.1.4](https://dotnet.microsoft.com/download/dotnet-core/2.1)
#### Editor
 * Utilisei apenas o [Visual Studio Code](https://code.visualstudio.com/)
#### Extensões utilizadas no VSCode
* Auto-Using for C#
* Better Comments
* Bracket Pair Colorizer 2
* C#
* C# Colors
* C# Extensions
* C# FixFormat
* C# Snnipets
* C# XML Documentation Comments
* eppz!
* indent-rainbow

## Linguagens
* C#
* CSS3
* HTML5


## MVC(*Models Views Controllers*) :books:
### 1. Controllers
* AbstractController
* AdmController
* CadastroController
* ClienteController
* HomeController
* UsuarioController

### 2. Repositories
* ClienteRepository
* EventoRepository
* RepositoryBase
* ServicosRepository
* SuporteRepository

### 3. Models
> *Os model estão divididos em dois tipos, os Models Comuns e os ViewModels(serve para enviar informações para as views).*

:bookmark: **Models**
* Cliente
* Evento
* Pagamento
* Servicos
* Suporte

:bookmark: **ViewModels**
* AdmViewModel
* BaseViewModel
* DashboardViewModel
* EventoViewModel
* MensagemViewModel
* PagamentoViewModel
* ServicoViewModel

### 4. Views
> *As views são divididas em pastas, e dentro de cada pasta estão as views relacionadas.*

:file_folder: **Adm**
* Aprovados
* Historico
* Index
* Pendentes
* Recusados
* Usuarios
* UsuariosBan

:file_folder: **Cadastro**
* Index

:file_folder: **Cliente**
* Login

:file_folder: **Home**
* Index

:file_folder: **Usuario**
* EventoCadastro
* Eventos
* Index
* InfoAlterar
* Informacoes
* InfoSenha
* Pagamento
* Suporte

:file_folder: Shared
> *Pasta onde fica as views de Sucesso,falha e as padrões do html como header, navs e o layout principal das views.*
* _HeaderUserHome
* _Layout
* _NavAdmPages
* _NavHomePages
* _NavUserPages
* Error
* Sucesso

## Contatos :phone:
* WhatsApp - **11 940313232**
* Email - isrraaoliveira@gmail.com
* [LinkedIn](https://www.linkedin.com/in/israel-oliveira-73880b18b/)
* [Instagram](https://www.instagram.com/israel_peichim/)
* [Facebook](https://www.facebook.com/israel.peichim)


## Licença  :closed_lock_with_key:
Esse projeto está licenciado sob a licença MIT - consulte o arquivo [LICENSE](https://github.com/israaoliver/RoleTopMVC/blob/master/LICENSE) para mais detalhes.










