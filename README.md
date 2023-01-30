# Aplikacja jako strona do dodawania plików audio z okładkami, oraz postów o naszej aktywności
Niezalogowani użytkownicy mogą tylko przeglądać audio posty, zalogowani mogą dodawać, edytować, usuwać własne audio posty jak i aktualności,
administrator może usuwać wszystkie audio posty.

# Pierwsze uruchomienie
W pliku appsettings.json trzeba ustawić ContextConnection adekwatny dla naszej bazy danych. 
Wykonujemy migrację a następnie aktualizujemy baze danych.

Role administratora można nadać za pomocą SSMS,
Dodajemy do tabeli AspNetUserRoles id roli oraz id użytkownika

# Użytkownik nie zalogowany
Taki użytkownik może jedynie przeglądać posty w zakładce Audio

# Użytkownik zalogowany
może robić to samo co użytkownik nie zalogowany oraz:

-Dodawać komentarze

-Likować posty

-Dodawać audio posty

-Edytować swoje audio posty

-Usuwać swoje audio posty

-Dodawać posty w zakładce aktualności i wykonywać na nich CRUD

# Użytkownik zalogowany jako administrator

-Dostaje dostęp do Admin Panelu, z którego może wykonywać czynności CRUD na wszystkich postach

# Api
Aplikacja posiada REST api dla encji Audio

# Testy jednostkowe

Aplikacja posiada testy jednostkowe nawjażniejszych funkcji dla modelu Audio
