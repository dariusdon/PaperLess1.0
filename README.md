Aplicație PaperLess2.0(Versiunea 1)
Scopul aplicatiei: Inregistrarea livrarilor de raw-material din RM Warehouse in Mixing
Device: 
Calculatoare Hala6 + Rm2
Scanere: Disponibile in ambele locatii 
Aplicația va fi accesată web și va salva datele în MSSQL 
1.	Aplicația:
Va fi formata din 2 părți:
A.	Login pe ecran (background); doua casute pentru introducerea numelui si parolei pentru fiecare operator desemnat. 
 
Username-ul va fi numele de familie al fiecarui operator
Parola va fi codul lor PIN. După introducere cod PIN se va afișa formularul.
![image](https://user-images.githubusercontent.com/62428663/162194581-b943ae12-40ee-463b-8daa-586afdfaaa3f.png)


B.	Formular:
	Numele , data & schimbul operatorului(automat)
	Înregistrarea consumurilor:  material & coletaj(greutate x nr paleti) 
	pentru introducerea materialelor - se va scana cu scannerul manual codul de bare de pe etichete dar si posibilitatea introducerii lor manuale
	introducerea manuala a materialelor se va realiza sub forma : „CA64013012”  (adica o interdictie astfel incat sa nu existe spatiu intre litere si cifre, chiar daca operatorul incearca asta)
	pentru coletaj – datele se vor introduce manual
	Tip eroare la scanare 
 	datele se vor introduce manual doar acolo unde este cazul
	Stare ambalaj returnabil, tip ambalaj returnabil & cantitate
  datele se vor introduce manual doar acolo unde este cazul
	Loc dedicat pentru semnatura celor doi operatori (depozit & mixing)
2.	Raport:
Draft:
 ![image](https://user-images.githubusercontent.com/62428663/162194588-1cd28e5b-8cf7-407b-85e0-3519a864156c.png)


Pe langa aplicația propriu-zisa, avem nevoie si de un raport (cu datele generate din aplicație) care va permite urmatoarele:
- posibilitatea descarcarii unei baze de date cu flexibilitate asupra perioadei de timp (baza de date la nivel de zi/saptamana/luna etc)(la nivel de zi in versiunea 1)
-in prima faza(baza de date a operatorilor) – raport per schimb( 2 rapoarte(RaportH6 + RaportRM2) )
- in cadrul tool-ului :
	      
  sortarea datelor (in functie de coloanele din raport)
	filtrarea in functie de anumiti parametrii
	modificarea valorilor de pe fiecare inregistrare ( de ex: butoane <<ca in poza de mai sus>> in dreptul fiecarui rand care va deschide un formular de modificare) – buton Edit la inceputul taelului
	prin editare se realizeaza un update al bazei de date
  trimiterea mail-uri la final de schimb(un buton care sa inchida schimbul, si sa trimita un mail automat cu situatia catre superiori)
	parametrii standard pentru materiale sa se adauge automat din fisierul „G:\Plant_Operations\PO_Public\ParametriiMateriale\Parametrii.xlxs”

