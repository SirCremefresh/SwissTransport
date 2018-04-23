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
* 01 Start- und Endstationen mittels Eingabefeld suchen
* 02 Die nächste vier bis fünf Verbindungen zwischen angegebener Start- und Endstationen sehen
* 03 Verbindungen ab einer bestimmten Station anzeigen

### 2.5.2 Priorität 2
* 04 Während der Eingabe einer Station bereits Suchresultate erhalten
* 05 Verbindungen an beliebigem Datum anuzeigen

### 2.5.3 Priorität 3
* 06 Ort einer Station anzeigen (Maps)
* 07 Stationen in meiner Nähe finden
* 08 Gefundene Resultate per Mail verschicken

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
Verbindungen (zwischen zwei Stationen) 
**TEXT**

![Mockup Verbindungen](/img/StationMockup.JPG)

### 3.2.2 Abfahrtsplan
Abfahrtsplan ab einer Station
**TEXT**

![Mockup Abfahrtsplan](/img/BoardMockup.JPG)
  
<a name="validation"/>

## 3.3 Validierung
* **Stationen** Es werden direkt bei der Eingabe Suchresultate angezeigt. Diese werden nach Wichtigkeit und Zusammenpassen sortiert angezeigt 
und können angeklickt werden. Wird ein Stationsname nicht fertig geschrieben wird der beste Match eingefügt, falls keiner zutrifft wird dies gemeldet.
Stationsnamen dürfeb nicht leer sein und die Abfahrts- und Ankunftsstation dürfen nicht gleich heissen.
* **Datum****TEXT**

<a name="test"/>

## 3.3 Testfälle
**#1**
```
GEGEBEN SEI   Ich bin auf der Ansichtsseite
WENN          nicht abgeschlossene Dörraufträge in der Datenbank erfasst sind
DANN          werden diese in einer Tabelle aufgelistet.
```
**#2**
```
GEGEBEN SEI   Ich bin auf der Ansichtsseite
WENN          der Dörrauftrag noch nicht abgeschlossen ist und das Enddatum des Auftrages überschritten ist
DANN          wird bei der Frucht das Icon zu verdorben gewechselt.
```
**#3**
```
GEGEBEN SEI   Ich bin auf der Ansichtsseite
WENN          ich einen Dörrauftrag erstelle möchte ("Dörrauftrag erfassen")
DANN          öffnet sich ein Eingabefenster um einen Benutzer zu efassen.
```

![Use Case](/img/Use Case.JPG)

<a name="activity"/>

## 3.5 Aktivitätendiagramm
**TEXT**

![Aktivitätendiagramm](/img/activity.JPG)

<a name="implementation"/>

# 4 Umsetzung

<a name="features"/>

## 4.1 Funktionen
### 4.1.1 Priorität 1
A01 ✔
A02 ✔
A03 ✔

### 4.1.2 Priorität 2
A04 ✔
A05 ✔

### 4.1.3 Priorität 3
A06 ✔

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
**TEXT**

![Station](/img/station.jpg)

### Abfahrtsplan ab einer Station
**TEXT**

![Board](/img/board.jpg)

<a name="report"/>

# 5 Testbericht
**TEXT**

<a name="install"/>

# 6 Installation
**TEXT**



