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
Autor: Gian Ott
Erstelldatum: 22.04.2018, letzte Aktualisierung: 24.04.2018

## 2.2 Projekt Start- und Ende   
Projektstart: 18.04.2018   
Projektende: 24.04.2018 

## 2.3 Einleitung
Im ÜK Modul 318 wurde zur Festigung des Gelernten und zur Benotung eine Projektarbeit, inklusive Dokumentation in einer Einzelarbeit erstellt.
Das Projekt soll als Desktop Anwendung auf eine API zugreifen und anschliessend diverse Daten wie Verbindungen zwischen Stationen anzeigen.
Die Applikation ist zusammen mit der Dokumentation auf GitHub zu finden.

## 2.4 Dokumentation
Diese Dokumentation beinhaltet die Planung, die Umsetzung, und das Ergebnis mit einer Installationsanleitung.
Sie soll als Nachschlagewerk dienen und wurde für eine einfache Handhabung und Zugänglichkeit in einem Readme geschrieben. 

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
Mit C# und WPF werde ich nach MVVM arbeiten. Die komplette Logik werde ich in Models auslagern. 
Im xaml.cs sollen nur Funktionen die mit der View beziehungsweise den Controls stehen, aber keine Logik.

<a name="code"/>

## 3.1 Coderichtlinien
### 3.1.1 Namensgebung
* Variablen und Methoden werden nach camelCase benannt -> erster Buchstabe klein, Wortanfänge im Namen gross (string camelCase)
* Eigenschaften werden nach PascalCase benannt -> erster Buchstabe gross, Wortanfänge im Namen gross (string PascalCase)

### 3.1.2 Methoden, Schleifen, Verzweigungen, Try Catch
In C# kommen geschweifte Klammern grundsätzlich auf die nächste Zeile, weshalb ich dies bei Methoden, Schleifen und Verzweigungen einhalten werden.
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
Ich verzichte ausserdem bei IF Verzweigungen auf die Kurzschreibweise ohne geschweifte Klammern, werde aber bei bool Parameter
den ternären Operator (?:) anstatt if else brauchen.
```
getSomething(true ? true : false);
```

### 3.1.2 Kommentare
Ich kommentiere grundsätzlich jede Methode überhalb mit /**/, verzichte aber ansonsten auf Kommentare.
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

![Mockup Verbindungen](/img/StationMockup.JPG)

### 3.2.2 Abfahrtsplan
Abfahrtsplan ab einer Station

![Mockup Abfahrtsplan](/img/BoardMockup.JPG)
  
<a name="validation"/>

## 3.3 Validierung
* Stationen -> Es werden direkt bei der Eingabe Suchresultate angezeigt. Diese werden nach Wichtigkeit und Zusammenpassen sortiert angezeigt 
und können angeklickt werden. Wird ein Stationsname nicht fertig geschrieben wird der beste Match eingefügt, falls keiner zutrifft wird dies gemeldet.
Stationsnamen dürfeb nicht leer sein und die Abfahrts- und Ankunftsstation dürfen nicht gleich heissen.
* Datum ->

<a name="test"/>

## 3.3 Testfälle
### #1
```
GEGEBEN SEI   Ich bin auf der Ansichtsseite
WENN          nicht abgeschlossene Dörraufträge in der Datenbank erfasst sind
DANN          werden diese in einer Tabelle aufgelistet.
```
### #2
```
GEGEBEN SEI   Ich bin auf der Ansichtsseite
WENN          der Dörrauftrag noch nicht abgeschlossen ist und das Enddatum des Auftrages überschritten ist
DANN          wird bei der Frucht das Icon zu verdorben gewechselt.
```
### #3
```
GEGEBEN SEI   Ich bin auf der Ansichtsseite
WENN          ich einen Dörrauftrag erstelle möchte ("Dörrauftrag erfassen")
DANN          öffnet sich ein Eingabefenster um einen Benutzer zu efassen.
```
### #4
```
GEGEBEN SEI   Ich erfasse gerade einen neuen Dörrauftrag
WENN          ich die Angaben gemacht habe
DANN          können diese in der Datenbank gespeichert ("Auftrag erstellen") oder der Vorgang abgebrochen werden.
```

![Use Case](/img/Use Case.JPG)

<a name="activity"/>

## 3.5 Aktivitätendiagramm
* descriotion!
*
*

![Aktivitätendiagramm](/img/activity.JPG)

<a name="implementation"/>

# 4 Umsetzung

<a name="features"/>

## 4.1 Funktionen
*
*
*

<a name="bugs"/>

## 4.2 fehlende Funktionen und Bugs
*
*
*

<a name="screenshot"/>

## 4.2 Screenshot der Anwendung
### Verbindungen zwischen zwei Stationen
![Station](/img/station.jpg)

### Abfahrtsplan ab einer Station
![Board](/img/board.jpg)

<a name="report"/>

# 5 Testbericht
*
*
*

<a name="install"/>

# 6 Installation
*
*
*


