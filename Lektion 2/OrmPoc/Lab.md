Labb - Lektion 2
================
Skapa databas med:
* Kunder
* Ordrar
* Produkter
* Fakturor

Ni skall kunna generera testdata för 10, 10 000 och 10 000 000 kunder med 10 ordrar per kund och 5 produkter per order.

Mät tiderna för de olika typerna av inserts som ni gör.

När ni genererar namn till kunderna får de inte vara i sekvens.

Ert system skall kunna genomföra köp
Ert system skall kunna fakturera köpa gjorde de senaste x dagarna för köp som ej är fakturerade.
Ert system skall kunna visa upp fakturor

Använda bara ado.net för att lösa uppgiften.

För insert av 10 000 000 rader googla gärna på batch insert. Analysera lämplig storlek på batcharna.

Bygg gärna hanteringen av testdatat som en separat applikation. Den kommer behövas under resten av kursen.

I denna labben får ni gärna börja fundera på ett standardiserat gränssnitt mot databasen, då motsvarande data kommer hämtas med flera olika tekniker och vi vill minimera omskrivningarna för detta.

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


