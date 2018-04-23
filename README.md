# M318 SwissTransport
## 1 Inhaltsverzeichnis
* [2 Projekt Informationen](#information) 
* [3 Konzeptionierung](#concept)  
  * [3.1 Coderichtlinie](#code) 
  * [3.2 Mockup](#mockup)  
  * [3.3 Validierung](#validation)  
  * [3.4 Testfälle](#test)  
  * [3.5 Aktivitätendiagramm](#activity) 
* [4 Umsetzung](#implementation)  
  * [4.1 Funktionen](#features)  
  * [4.2 fehlede Funktionen und Bugs](#bugs)  
  * [4.3 Screenshot](#screenshot) 
* [5 Testbericht](#report)
* [6 Installation](#install)  

<a name="information"/>

# 2 Projekt Informationen
## 2.1 Autor und Dokument
* Autor: **Gian Ott**
* Erstelldatum: **22.04.2018**
* letzte Aktualisierung: **24.04.2018**

## 2.2 Projekt
* Projektstart: **18.04.2018**   
* Projektende: **24.04.2018** 
* Der Source sowie die Dokumentation sinf auf GitHub unter **https://github.com/Nichtgian/SwissTransport**

## 2.3 Einleitung
Im ÜK Modul 318 wurde zur Festigung des Gelernten und zur Bewertung eine Projektarbeit, inklusive Dokumentation in einer Einzelarbeit erstellt.
Das Projekt soll als Desktop Anwendung auf eine API zugreifen und anschliessend diverse Daten wie Verbindungen zwischen Stationen anzeigen.
Die Applikation ist zusammen mit der Dokumentation auf GitHub zu finden.

## 2.4 Dokumentation
Diese Dokumentation beinhaltet die Planung, die Umsetzung, und das Endergebnis zusammen mit Testfällen und einer Installationsanleitung.
Sie soll als Nachschlagewerk dienen und wurde für eine einfache Handhabung und Zugänglichkeit im .md (Readme) Format geschrieben. 

## 2.5 Anforderungen
### 2.5.1 Priorität 1
- [x] 01 Start- und Endstationen mittels Eingabefeld suchen
- [x] 02 Die nächste vier bis fünf Verbindungen zwischen angegebener Start- und Endstationen sehen
- [x] 03 Verbindungen ab einer bestimmten Station anzeigen

### 2.5.2 Priorität 2
- [x] 04 Während der Eingabe einer Station bereits Suchresultate erhalten
- [x] 05 Verbindungen an beliebigem Datum anuzeigen

### 2.5.3 Priorität 3
- [x] 06 Ort einer Station anzeigen (Maps)
- [ ] 07 Stationen in meiner Nähe finden
- [ ] 08 Gefundene Resultate per Mail verschicken

<a name="concept"/>

# 3 Konzeptionierung
Mit C# und WPF werde ich nach dem MVVM Modell arbeiten. Die komplette Logik werde ich in Models auslagern, 
wodurch keine Logik im Code behind von Views und Pages steht und diese nur Events von Controls entgegennehmen. 

<a name="code"/>

## 3.1 Coderichtlinien
### 3.1.1 Namensgebung
* **Variablen und Methoden** werden nach **camelCase** benannt -> erster Buchstabe klein, Wortanfänge im Namen gross (string camelCase)
* **Eigenschaften** werden nach **PascalCase** benannt -> erster Buchstabe gross, Wortanfänge im Namen gross (string PascalCase)

### 3.1.2 Methoden, Schleifen, Verzweigungen, Try Catch
In C# kommen geschweifte Klammern grundsätzlich auf die **nächste Zeile**, weshalb ich dies bei Methoden, Schleifen und Verzweigungen einhalten werden.
```
if (true)
{
    true = false;
}
else
{
    false = true;
}
```
Ich **verzichte auf die Kurzschreibweise** ohne geschweifte Klammern bei bei IF Verzweigungen, werde aber bei bool Parameter
den **ternären Operator** ( ? : ) anstatt if else brauchen.
```
getSomething(true ? true : false);
```

### 3.1.2 Kommentare
Ich kommentiere grundsätzlich **jede Methode oberhalb** mit /* */, verzichte ansonsten auf Kommentare.
```
/*returns station from input*/
public void getStation(string input)
{
    return api.getStation(input);
}
```

<a name="mockup"/>

## 3.2 Mockup
### 3.2.1 Verbindungen
Es können zwei Stationen oder Orte (Von und Nach) angegeben werden. 
Standartmässig wird das aktuelle Datum und Zeit eingefüllt, jedoch kann das Abfahrtsdatum und die Abfahrtszeit beliebig angegeben werden.
Wird nach Verbindungen gesucht, werden von der API die nächsten Verbindungen anhand der Eingaben zurückgegeben, welche in die Liste gefüllt werden. 
Es werden pro Verbindung die Vonstation und Abfahrtszeit sowie der Nachstation und Ankunftszeit angezeigt. 
Wird ein Listenelement angewählt, erscheint ein neues Fenster mit mehr Details (Vonstation, genaue Abfahrtszeit sowie dem Gleis, 
die Reisezeit und die Nachstation mit genauer Ankunftszeit und Gleis). Bei Falschen Angaben erscheint eine Nachricht, welche die Fehlerhaften
angaben zurückmeldet.

In der Menüleiste kann auf die Abfahrtsplans Seite gewechselt werden.

![Mockup Verbindungen](/img/StationMockup.JPG)

### 3.2.2 Abfahrtsplan
Es kann eine Station angegeben werden. Mit Abfahrtsplan anzeigen werden alle Abfahrten von der Station ausgehend in die Liste gefüll.
Es werden der Name, seine Zugskategorie, die Gleisnummer und die Ankunftsstation angezeigt. 
Mit Stationsort anzeigen wird Google Maps in einem Browserfenster an der angegebenen Station geöffnet.

In der Menüleiste kann auf die Verbindungen Seite gewechselt werden.  

![Mockup Abfahrtsplan](/img/BoardMockup.JPG)
  
<a name="validation"/>

## 3.3 Validierung
* **Stationen** Es werden direkt bei der Eingabe Suchresultate in einem Dropdown angezeigt. Diese Resultate werden nach Wichtigkeit und Zusammenpassen sortiert angezeigt 
und können angeklickt werden, was zum verfollständigen der Eingabe führt. Wurde ein Stationsname bei einer Verbindungs- oder Abfahrtsplanssuche fertig geschrieben, 
wird nach einem Match gesucht und eingefügt. Falls keiner gefunden wurde wird dies gemeldet.
Stationsnamen dürfen nicht leer und bei der Verbindungsseite die Abfahrts- und Ankunftsstation nicht gleich sein.

* **Datum** Das Datum wird nach dem aktuellen Datum standartmässig ausgefüllt. Wird nach einer Verbindung gesucht, darf das Datum nicht leer sein
und es muss ein gültiges Datum sein, ansonsten wird dies in einem Fenster mitgeteilt.

* **Zeit** Die Zeit wird nach der aktuellen Zeit standartmässig ausgefüllt. Wird nach einer Verbindung gesucht, darf die Zeit nicht leer sein
und es muss eine gültige Zeit sein, ansonsten wird dies in einem Fenster mitgeteilt.

<a name="test"/>

## 3.3 Testfälle
**#1**
```
GEGEBEN SEI   Ich bin auf der Verbindungsseite
WENN          ich eine Station (Von oder Nach) eintippe
DANN          wird ein Liste als Dropdown mit passenden Stationen angezeigt.
```
**#2**
```
GEGEBEN SEI   Ich bin auf der Verbindungsseite
WENN          nach Verbindungen suche
DANN          werden anhand der Angaben (Stationen und Datum/Zeit) die nächsten Verbindungen in eine Liste gefüllt.
```
**#3**
```
GEGEBEN SEI   Ich bin auf der Verbindungsseite
WENN          ich in der Menüleiste auf Abfahrtsplan drücke
DANN          wird die Abfahrtsplansseite geladen.
```
**#4**
```
GEGEBEN SEI   Ich bin auf der Abfahrtsplansseite
WENN          ich auf Abfahrtsplan anzeigen drücke 
DANN          werden anhand der eingegebener Station die gefundenen Abfahrten in eine Liste gefüllt.
```
**#5**
```
GEGEBEN SEI   Ich bin auf der Abfahrtsplansseite
WENN          ich auf Stationsort anzeigen drücke 
DANN          wird Google Maps in einem Browserfenster bei der angegebener Station geöffnet.
```

### 3.3.1 Use Case
Unsere Anwendung wird von Reisenden benutzt. Diese können nach Stationen suchen, aktuelle oder zukünftige Verbindungen zwischen
zwei Stationen anzeigen und einen Abfahrtsplan von einer Station aus ausgehend anzeigen lassen.

![Use Case](/img/UseCase.JPG)

<a name="activity"/>

## 3.5 Aktivitätendiagramm
Der grobe Ablauf (alle Priorität 1 Anforderungen) der Anwendung ist in diesem Aktivitätenprogramm zusammengefasst.

![Aktivitätendiagramm](/img/activity.JPG)

<a name="implementation"/>

# 4 Umsetzung

<a name="features"/>

## 4.1 Funktionen
| Anforderung | Priorität | Status | Beschreibung                      |
| ----------- | --------- | ------ | --------------------------------- | 
| A01         | 1         | ✔      | Während der Eingabe einer Station werden Vorschläge in einem Dropdown angezeigt | 
| A02         | 1         | ✔      | Verbindungsseite: Mit Verbindung suchen werden die nächsten Verbindungen anhand der Angaben gesucht und angezeigt | 
| A03         | 1         | ✔      | Abfahrtsplansseite: Mit Abfahrtsplan anzeigen werden die nächste Abfahrten ab der eingegebenen Station gesucht und angezeigt | 
| A04         | 2         | ✔      | Während der Eingabe einer Station werden Vorschläge in einem Dropdown angezeigt | 
| A05         | 2         | ✔      | Es kann ein beliebiges Datum und oder Zeit zur Verbindungssuche angegeben werden, standartmässig aktuelle Zeit |
| A06         | 3         | ✔      | Mit Stationsort anzeigen wird Maps in einem Browserfenster an der angegebener Station geöffnet |  

✔ Status -> Funktion fehlerfrei implementiert

<a name="bugs"/>

## 4.2 fehlende Funktionen und Bugs
### 4.2.1 Fehlende oder nur teilweise fertige Funktionen
| Anforderung | Priorität | Status | Beschreibung                      |
| ----------- | --------- | ------ | --------------------------------- | 
| A07         | 3         | 🔶      | Es können keine Stationen in der Nähe des Standorts gefunden werden | 
| A08         | 3         | 🔶      | Resultate können nicht per Email verschickt werden | 

🔶 Status -> Funktion nicht implementiert

🐛 Status -> Funktion nur teilweise implementiert

❌ Status -> Funktion führt zu Fehler

### 4.2.2 Bugs und Fehler
Zurzeit sind alle Bugs behoben und **keine** weiteren Fehler bekannt.

<a name="screenshot"/>

## 4.2 Screenshot der Anwendung
### Verbindungen zwischen zwei Stationen

![Station](/img/station.JPG)

### Abfahrtsplan ab einer Station

![Board](/img/board.JPG)

<a name="report"/>

# 5 Testbericht
**TEXT**

<a name="install"/>

# 6 Installation
**TEXT**



