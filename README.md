# DiscoMania
Projeto que adiciona discos baseados no spotify e realiza a venda

# Primeiros passos.
* Rodar o arquivo ScriptDeCriacaBanco.sql em um banco MS SQL SERVER.
* Esse banco terá que estar configurado para receber chamadas TCP/IP.
* Configurar a connection string do appsettings.json, para conectar a esse banco, passando também a porta do banco.
* Abrir o cmd e direcionar para pasta que os arquivos foram baixados.
* Executar o comando **docker-compose -f docker-compose.yml up -d --build**
* Abrir o browse no **http://localhost:9091/swagger/index.html**

# Do Programa
*  **--Disco--**
* Para adicionar os discos via Spotify (os 50 primeiros de cada um dos gêneros) executar o **/api/Disco/AdicionarDiscoSpotify**
* Se quiser adicionar o disco unitariamente, utilizar o **/api/Disco** deixando o id = 0, para adicionar.
* Pesquisar pelos filtros Album, Artista ou Gênero, utilizar o **/api/Disco/GetDiscosByFilter** (a pesquisa é paginada)
* Pesquisar Disco pelo Id, utilize **/api/Disco/{id}**
* **--Venda--**
* Para adicionar venda completa, utilizar o **/api/Venda/InserirVendaCompleta**
* Para adicionar apenas a venda, utilizar o **/api/Venda/InserirVenda** (lembrando que para adicionar os discos a essa venda será feita na api de DiscoVenda)
* Pesquisa pelo Id: **/api/Venda/{id}
* Pesquisa da Venda completa: **/api/Venda/GetVendaCompletaId/{id}
* Pesquisa paginada com data início e data fim: **/api/Venda/GetVendaByFilter**
*  **--DiscoVenda--**
* Adiciona o disco a uma venda: **/api/DiscoVenda**
* Pesquisa o CashBack pelo gênero: **/api/DiscoVenda/{genero}** 0:POP, 1:MPB, 2:rock e 3:Clássico

# Azure Devops

Durante o desenvolvimento eu utilizei o Azure Devops como repositório e estava configurando o pipeline para ter um CI/CD na Azure, mas não houve tempo hábil para isso, e por usar como repositório, os commits foram todos lá e não aqui no github.
