Labb - Lektion 2
================
Skapa databas med:
* Kunder
* Ordrar
* Produkter
* Fakturor

Ni skall kunna generera testdata f�r 10, 10 000 och 10 000 000 kunder med 10 ordrar per kund och 5 produkter per order.

<<<<<<< HEAD
N�r ni genererar namn till kunderna f�r de inte vara i sekvens.
=======
Mät tiderna för de olika typerna av inserts som ni gör.

När ni genererar namn till kunderna får de inte vara i sekvens.
>>>>>>> origin/master

Ert system skall kunna genomf�ra k�p
Ert system skall kunna fakturera k�pa gjorde de senaste x dagarna f�r k�p som ej �r fakturerade.
Ert system skall kunna visa upp fakturor

Anv�nda bara ado.net f�r att l�sa uppgiften.

<<<<<<< HEAD
F�r insert av 10 000 000 rader googla g�rna p� batch insert.
=======
För insert av 10 000 000 rader googla gärna på batch insert. Analysera lämplig storlek på batcharna.
>>>>>>> origin/master

Bygg g�rna hanteringen av testdatat som en separat applikation. Den kommer beh�vas under resten av kursen.

I denna labben f�r ni g�rna b�rja fundera p� ett standardiserat gr�nssnitt mot databasen, d� motsvarande data kommer h�mtas med flera olika tekniker och vi vill minimera omskrivningarna f�r detta.

En faktura skall innehålla datat som det var när ordern lades. Dvs om en kund ändrar adress, så skall adressen inte ändras i fakturan. Om en produkt ändrar pris, så skall priset inte ändras i fakturan.

2014-10-27
==========
Lägg till en kolumn i ordertabellen. Detta skall göras med tabellen är fylld med data. Dvs en ALTER TABLE. Utför på olika mängder data. 

Ändra på en eller flera kolumer i kundtabellen. Testa t ex att byta ut FirstName och LastName mot FullName. Detta skall kunna köras närs som helst. Dvs data att förändra skall kunna genereras inför varje körning.

Skapa en funktion för att höja priset på alla produkter med x procent.

Vid inserts av kunder och ordrar, testa med och utan forreign key constraint påslaget. Utför genom att ta bort FK, göra insert, och sedan lägga på den igen. Jämför skillnaden.

Medans faktureringsjobbet körs, så skall en annan process eller applikation lägga nya ordrar. Resultat? Påverkas tiderna?

Kör alla prestandatesterna både med Unicode på alla kollumnerna och utan. Jämför.

2014-10-29
==========
Era applikationer skall:
* Ta bort tabellerna. 
* ha en metod liknande AddOrder(Order order) där order innehåller x antal orderrader.
* ha en metod AddCustomer(Customer customer)
* BÅDE kunna skapa data mha bulkcopy och "vanliga" sql inserts.
* rapportera tidsåtgången för alla operationer. Att tömma tabeller, droppa tebeller, reflections osv skall inte ingå i mätningarna.
* 
Laborera med batchsizes. Är samma storlek på batchsize rätt både för 10 000 och 10 000 000 kunder?

10 000 000 stjäl för mycket tid. Behåll funktionaliteten, men använd hellre 1 000 000 när ni labbar.

Utöka applikationen till att kunna utföra samtliga uppgifter även via Stored Procedures och vyer. Vyer för läsningar och SPs för skrivningar.

2014-11-10
==========

Labben skall rapporteras i Fronter skriftligen senast 23:59 tisdag 11:e november.
I rapporten skall framgå:
* Tidsågång för alla de olika operationerna som labben omfattar. Både beräknat per rad och för hela batchen.
* Utförliga slutsatser om vilken teknik som bör användas i vilket scenarie.
* Alla olika varianterna skall användas. Bulk, plain sql, och stored procedures.

Koden behöver inte läggas in i fronter. Ni skall kunna presentera er lösning för klassen på onsdag.

2014-11-12
==========
Fokus idag: EF + Transaktioner
Bygg metodern ni byggt tidigare, AddOrder, AddCustomer, UpdateAllPrices(alltså funktionen tidigare för att ändra priser med en viss procent), CreateInvoice med EF.
Bygg en metod med valfri teknik som tar lång tid att exekvera och spänner över många rader i databasen. Den skall ta tillräckligt med tid för att ni i lugn och ro skall kunna köra metoderna ovan.

Utvärdera med och utan transaktioner. Testa att lägga transaktioner kring AddCustomer + AddOrder, Runt en stor insert (ej bulk)

Gör en SQL Trace på UpdateAllPrices och utvärdera.

Den som först lyckas skapa en deadlock får en kaffe från personalrummet.

Inför tentan
==============================
Publicera metoderna ovan via WCF.
Bygg en klient som hämtar en kund, ändrar på kunden och försöker spara den igen via wcf. Bygg backend med Entity Framework för detta. Det vi vill åt är att ett objekt tappar kontakten med sitt DbContext, och sedan kopplas in igen.

Ej obligatoriskt, men bonus är att bygga EF-funktionaliteten med nHibernate ist.

Ni kommer ha 15 minuter på er att redovisa. Bygg vidare på rapporten från förra inlämningen.

Ni skall beskriva er arkitektur inte bara med text, utan även med bilder av lämplig typ. Gör egen bedömning av lämplig typ.

Ge lämpliga scenarier för de olika dataaccessteknikerna. Beskriv deras svagheter och styrkor.

Hur bra är den SQL som genereras av EF? Hur bra är den SQL som genereras av nHibernate?

Vilka slutsatser har ni fragit kring användandet av transaktioner? Ge rekomendationer för transaktioner.

Vad kan ni ytterligare tipsa nybörjare inom dataaccess om?


