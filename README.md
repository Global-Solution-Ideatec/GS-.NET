# IdeaTecAPI - Instruções de execução e testes

Integrantes:
**Carlos Eduardo Pacheco - RM557323**
**João Pedro Amorim - RM559213**
**Pedro Augusto Ladeira - RM558514**


Este README descreve como executar o projeto localmente e via Docker, além de exemplos para testar os endpoints (Swagger / cURL).

Pre-requisitos
- .NET 8 SDK instalado
- Docker (opcional, para testes com Oracle em container)

Executar localmente (sem Docker)

1. Restaurar e compilar:
```powershell
cd "c:\Users\cadup\Documents\Aulas fiap\Fiap 2025\GS\.Net\IdeaTecAPI"
dotnet restore
dotnet build -c Release
dotnet run --project .\IdeaTecAPI.csproj
```

2. Abrir Swagger UI
- Local: http://localhost:5000 (HTTP) ou https://localhost:5001 (HTTPS)
- A aplicação serve Swagger na raiz (`/`) por configuração.

Executar com Docker Compose (Oracle XE + API)

1. Subir containers:
```powershell
cd "c:\Users\cadup\Documents\Aulas fiap\Fiap 2025\GS\.Net\IdeaTecAPI"
docker-compose up --build
```

2. Verificar containers:
```powershell
docker ps
```

3. Swagger via container:
- Abra http://localhost:8080

Observações sobre connection strings
- `appsettings.json` está configurado para o Oracle da FIAP com `SID=ord` (host `oracle.fiap.com.br`).
- O `docker-compose.yml` usa uma connection string diferente para o Oracle XE do container (`Data Source=oracle-db:1521/XEPDB1`) — isso é intencional para testes locais.

API Key (exemplo)
- A API suporta um header `X-API-KEY` para autenticação simples. Um valor de exemplo está configurado no `appsettings.json` como:

Uso de `.env` (recomendado)
- Copie o arquivo de exemplo para criar seu `.env` local:

```powershell
cp .env.example .env
# No PowerShell use: Copy-Item .env.example .env
```

- Abra `.env` e ajuste `CONNECTION_STRING`, `API_KEY` e `ORACLE_PASSWORD` conforme seu ambiente.
- Ao executar `docker-compose up --build`, o `docker-compose` irá carregar automaticamente as variáveis do `.env` e a API usará `ApiKey` a partir dessas variáveis.
- **Não** comite o arquivo `.env` no repositório (adicione ao `.gitignore` se necessário).
```
SAMPLE_API_KEY_12345
```

- Para usar no Swagger UI: clique em **Authorize**, insira o valor da chave no campo `X-API-KEY` e confirme. O Swagger enviará o header automaticamente nas requisições.

Endpoints e testes rápidos (exemplos cURL)

- Listar usuários (GET):
```powershell
curl http://localhost:5000/api/Usuarios
```

- Criar usuário (POST) — exemplo JSON (ajuste campos conforme `UsuarioCreateDTO`):
```powershell
curl -H "Content-Type: application/json" -d "{ \"Nome\": \"Aluno\", \"Email\": \"aluno@exemplo.com\" }" http://localhost:5000/api/Usuarios -Method POST
```

- Teste via Swagger UI: abra a UI e execute os endpoints diretamente.

Controllers criados/validados
- `UsuariosController` — já existente, implementa GET/POST/PUT/DELETE usando DTOs.
- `TarefasController` — já existente, implementa GET/POST/PUT/DELETE usando DTOs.
- `CheckinsController`, `RecomendacoesController`, `HabilidadesController` — já existentes e corretos.
- `EmpresasController` e `LogAtividadesController` — adicionados neste commit, implementam CRUD e usam DTOs + AutoMapper.

**Link para video no youtube:**
_https://youtu.be/j1U0auIki6s_

---

