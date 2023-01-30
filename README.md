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
![GuestView](https://user-images.githubusercontent.com/92157132/215587923-8ebd7887-91e8-42f3-aeb9-f633356946bc.png)
# Użytkownik zalogowany
![LoggedUserAudioView](https://user-images.githubusercontent.com/92157132/215587982-0929d262-d403-46f2-a50b-20942a95a421.png)

Może robić to samo co użytkownik nie zalogowany oraz:

-Dodawać komentarze

-Likować posty

-Dodawać audio posty

-Edytować swoje audio posty

-Usuwać swoje audio posty

-Dodawać posty w zakładce aktualności i wykonywać na nich CRUD

# Użytkownik zalogowany jako administrator
![AdminPanelView](https://user-images.githubusercontent.com/92157132/215588108-bd5fb55b-ee4b-4082-96ed-8042caf78b95.png)
-Dostaje dostęp do Admin Panelu, z którego może wykonywać czynności CRUD na wszystkich postach

# Filtrowanie danych

Filtrowanie danych odbywa się za pomocą search bara, do którego wpisujemy tytuł posta jaki szukamy:
![Filtrowanie za pomocą tytułów](https://user-images.githubusercontent.com/92157132/215588461-4c16dff4-9f52-4fc2-83e8-276f99b9d618.png)

Filtrowanie postów w aktualnościach, może odbywać się również za pomocą tagów!
![Filtrowanie za pomocą tagów](https://user-images.githubusercontent.com/92157132/215588509-df26b216-9d3a-488c-bff6-aa65ccce9c83.png)


# Api
Aplikacja posiada REST api dla encji Audio

# Testy jednostkowe

Aplikacja posiada testy jednostkowe nawjażniejszych funkcji dla modelu Audio
