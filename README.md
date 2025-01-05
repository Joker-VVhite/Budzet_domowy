

1. Krótki opis projektu 

Opis działania projektu – System Zarządzania Finansami Osobistymi 

System Zarządzania Finansami Osobistymi to aplikacja internetowa stworzona w technologii ASP.NET Core 8.0, która umożliwia użytkownikom zarządzanie swoimi finansami. Główne funkcje systemu obejmują rejestrowanie przychodów i wydatków, przypisywanie transakcji do odpowiednich kategorii (np. jedzenie, transport, rozrywka), monitorowanie budżetów oraz analizę danych finansowych za pomocą interaktywnych wykresów i raportów. 

  Dzięki przejrzystemu interfejsowi i analizie wizualnej, aplikacja wspiera świadome podejmowanie decyzji finansowych i pomaga w osiąganiu celów oszczędnościowych. 

 

2. Kluczowe funkcjonalności: 

 Zarządzanie przychodami i wydatkami. 

 Kategoryzacja transakcji (np. jedzenie, transport, rozrywka). 

 Wykresy analizy finansowej (kołowe). 

 Monitorowanie oszczędności i budżetów. 

 

 

3. Technologie:  

Backend: ASP.NET Core 8.0 

Baza danych: MS SQL Server w wersji lokalnej SQL Server LocalDB. 

Frontend:  MVC. 

 

4. Struktura projektu:  

Modele: Transakcje, Kategorie, Budżety, Osoby. 

Kontrolery: Strona startowa, Zarządzanie transakcjami, Dashboard finansowy. 

Widoki: Dashboard finansowy, szczegóły transakcji, Osoby, Kategorie. 

Metody w kontrolerach: Tworzenie, Szczegóły, Aktualizacja, Usuwanie,  

 

5. Instrukcja uruchomienia programu 

Wystarczy pobrać repozytorium z githuba, i włączyć przez visual studio 2022 (Link do repo: https://github.com/Joker-VVhite/Budzet_domowy.git). 

Następnie przed uruchomieniem programu należy przez Menadżer pakietów NuGet -> Konsola menadżera pakietów wpisać dwa polecenia: Add-Migration Init oraz Update-Database 

W zakładce “Kategorie” dodajemy kilka kategorii, w zakładce “Członkowie rodziny” dodajemy imiona i nazwiska osób z rodziny, po tym możemy zacząć dodawać transakcje. 

Uwaga: aplikacji jest pojęcie typ Transakcji: Wpłata/Wypłata: 

Wpłata oznacza wpłacenie pieniędzy do budżetu domowego 

Wypłata oznacza wypłacenie pieniędzy z budżetu domowego 

 

6. Najciekawsze funkcjonalności 

Aplikacja po dodaniu transakcji, automatycznie oblicza główny budżet.  

Wydatki są ukazane na wykresie w zakładce “Twój budżet” według danej kategorii, można je filtrować poprzez kliknięcie w którąś z nich nad wykresem kołowym. 
