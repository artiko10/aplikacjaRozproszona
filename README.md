# aplikacjaRozproszona
Projekt informatyczny, stworzony na potrzeby zajęć: „Programowanie zaawansowane” wykonany przez: Artura Gómułkę, Konrada Cieślaka i Magdalenę Kur.

Jako przykład systemu rozproszonego napisany został „czat” używający SuperSimple TCP/IP klient serwer w języku C#.

Aby uruchomić program należy:

1. Ściągnąć wszystkie dostępne komponenty

2. Pobrane komponenty odpalić w edytorze kodu np. Visual Studio Code

3. Należy dodać serwer. By tego dokonać klikamy prawym przyciskiem myszy w zakładce eksplorator rozwiązań na: serwer i wybieramy: debuguj -> uruchom nowe wystapienie

4. Następnie dodajemy klientów, którzy będą użytkownikami naszego czatu. By tego dokonać należy kliknąć prawym przyciskiem myszy w zakładce eksplorator rozwiązań na: DistributedApp i wybrać: debuguj -> uruchom nowe wystapienie. Czynność należy powtórzyć tyle razy ilu chcemy mieć klientów.

5. By klienci mogli zacząć korzystać z czatu, najpierw trzeba podłączyć serwer klikając przycisk „connect” w oknie serwera.

6. By połączyć klienta z czatem należy w oknie klienta nacisnąć przycisk „connect”.

7. Możemy zacząć konwersację poprzez wpisywanie treści wiadomości w oknie i zatwierdzanie ich przyciskiem.

Po naciśnięciu przycisku „stop” w oknie serwera zostaje wyłączona możliwość połączenia się kolejnych klientów z serwerem, a tym samym nie możliwe jest ich aktywne uczestnictwo w rozmowie na czacie (dotychczasowe połączenia zostają nienaruszone i możliwa jest komunikacja).

W oknie serwera jest możliwość monitorowania dołączających się klientów po ich adresach, śledzenia wymienianych przez nich wiadomości oraz istnieje możliwość wysyłania wiadomości bezpośrednio z serwera do użytkowników.

 
