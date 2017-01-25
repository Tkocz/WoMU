# Webb- och mobilutveckling
##Laboration 1: Shoppingsajt med ASP.NET MVC5
###Syfte
Laborationen behandlar design och programmering av ett dynamiskt webbgränssnitt
via ASP.NET MVC 5 och ADO.NET eller LINQ för SQL.
###Uppgift
Att skapa en webbapplikation som hanterar ett mycket enkelt köpsystem.
###Kravspecifikation
Beskrivet i en databas finns ett antal varor som går att köpa. Via ett webbgränssnitt
skall man kunna se vilka varor som finns, lägga till valfritt antal av dessa till sin
varukorg, se vilka varor som finns i varukorgen, samt checka ut varukorgen och
skicka en order. Man skall kunna handla direkt utan att vara inloggad eller
identifierad på något annat sätt, personuppgifter anges först vid utcheckning. Man
skall även kunna se förslag på varor som har beställts (av andra användare)
samtidigt med någon av de varor man själv har i sin varukorg. När man checkat ut
varukorgen, skall denna sparas i databasen tillsammans med kundinformation, och
därefter rensas varukorgen. Vid utcheckning skall kunden få ett orderID. Samma
orderID skall kunna anges på huvudsidan för att få en sammanställning av ordern.
