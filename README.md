![](/git/image.png)
# API Dziennika Elektronicznego
Projekt API Dziennika Elektronicznego stworzony w celach edukacyjnych

# Wymagania
`` SQL Server >2016``
<br />
``.NET Core 6``

# Schemat graficzny bazy danych
![](/git/baza2.png)

# Funkcje
- ``Uwierzytelnianie użytkowników wraz z ich pobieraniem``
- ``Autoryzacja rolami``
- ``Zarządzanie rolami (CURD)``
- ``Zarządzanie lekcjami (CURD)``
- ``Zarządzanie ocenami (CURD)``
- ``Zarządzanie klasami (CURD)``
- ``Zarządzanie pochwałami (CURD)``
- ``Zarządzanie obecnościami (CURD)``
<br />

# Problemy (Do zrobienia)
- ``Nauczyciel może wstawić ocene na przedmiocie którego nie uczy``
# Domyślne dane logowania
### Admin
`` Login: admin@admin.com``
<br />
`` Hasło: admin``
<br />

# Baza danych
### Konfiguracja
Aby nie wystąpił błąd przy połączeniu z bazą danych należy podmienić dane potrzebne do połączenia w pliku ``appsettings.json`` przy linij ``9``
### Dodawanie 
Aby dodać baze z migracij użyj polecenia update-database w menadżerze pakietów
#### Przykład
> PM> update-database