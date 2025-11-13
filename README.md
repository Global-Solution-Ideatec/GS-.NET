# IdeaTecAPI - Instruções de execução e testes

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
- Evite commitar credenciais reais; prefira variáveis de ambiente ou secrets.

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

Notas finais
- `Program.cs` foi ajustado para respeitar `ASPNETCORE_URLS` (útil em container). O fallback original para `localhost:5000/5001` foi mantido.
- `MappingProfile` foi atualizado com mapeamentos para `Empresa` e `LogAtividade`.

Se quiser, eu posso:
- Gerar um arquivo `.env` para uso com Docker Compose (não commitado) com as variáveis de conexão.
- Criar testes automatizados básicos (xUnit) para cobrir os controllers.

---
Arquivo gerado automaticamente em: `README.md`
