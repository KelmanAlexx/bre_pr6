# АИС «Центр карьеры и трудоустройства» — интеграционный клиент

В комплекте подготовлены контракт OpenAPI 3.0.3 и клиентский модуль на C# (.NET 8).

## Состав

- `openapi.yaml` — контракт API для `GET /vacancies` и `POST /applications/submit`.
- `CareerCenter.Integration.sln` — решение Visual Studio.
- `CareerCenter.Client/Models` — DTO-модели запроса и ответа.
- `CareerCenter.Client/Services` — интерфейс и HTTP-клиент интеграционного шлюза.
- `CareerCenter.Client/UI` — пример контроллера презентационного слоя.
- `CareerCenter.Client.Tests` — модульный тест десериализации JSON.

## Запуск в Visual Studio

1. Откройте `CareerCenter.Integration.sln`.
2. Восстановите NuGet-пакеты.
3. Запустите тесты через меню **Тест → Выполнить все тесты** либо командой:

   ```bash
   dotnet test CareerCenter.Client.Tests/CareerCenter.Client.Tests.csproj
   ```

## Настройка адреса и авторизации

При создании `HttpClient` задайте `BaseAddress` с завершающим `/`, например:

```csharp
var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7042/api/v1/")
};
httpClient.DefaultRequestHeaders.Authorization =
    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "<access-token>");
```