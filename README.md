
![ByteCuisineBanner](https://github.com/Xenomimi/ByteCuisine/assets/59377533/9a2d87dd-d3fd-40bc-b46b-858cf76141a9)

# ByteCuisine

**Rewolucja w cyfrowym świecie kulinarnym**

ByteCuisine to innowacyjna platforma kulinarna, która umożliwia użytkownikom wyszukiwanie i organizowanie przepisów, dostosowując je do dostępnych składników i preferencji.

## Wymagania systemowe

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)  
- PostgreSQL
- Przeglądarka obsługująca WebAssembly

## Szybka instalacja i uruchomienie (VS Code)

1. **Klonowanie repozytorium**

   ```bash
   git clone https://github.com/Xenomimi/ByteCuisine.git
   cd ByteCuisine
   ```

2. **Instalacja zależności**

   ```bash
   cd ByteCuisine
   dotnet restore
   ```

3. **Migracja bazy danych**

   Upewnij się, że plik `appsettings.json` zawiera poprawne dane do połączenia z bazą, a następnie uruchom:

   ```bash
   dotnet ef database update
   ```
   lub
   ```bash
   update database
   ```

   Polecenie stworzy odpowiednią strukruę bazy danych.

4. **Zmiana klucza API**

   W celu poprawnego działania generatora przepisów wymagana jest zmiana klucza API znajdującego się w pliku `Client/Shared/ChiefAssistant.razor`.

   ```c#
      private static string apiKey = "__API_KEY___"
   ```

5. **Uruchomienie serwera**

   ```bash
   dotnet run
   ```

   Dzięki `DbInitializer.cs` podczasu uruchomienia do bazy zostaną dodane przykładowe dane.

5. **Dostęp do aplikacji**

   Po uruchomieniu serwera otwórz przeglądarkę i przejdź do:

   ```
   http://localhost:5114
   ```

## Struktura projektu

- **Client/** – Blazor WebAssembly (interfejs użytkownika).
- **Server/** – ASP.NET Core Web API (logika backendowa).
- **Shared/** – Wspólne modele i logika między klientem a serwerem.
- **ByteCuisine.sln** – Plik rozwiązania dla Visual Studio.


