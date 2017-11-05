#Pitanje 1:
Izvođenje programa trajalo je 5.0014441 sekundi.
#Pitanje 2:
Na jednoj.
#Pitanje 3:
Izvođenje programa trajalo je 1.0047989 sekundi.
#Pitanje 4:
Na 5 dretvi.
#Pitanje 5:
Ako više dretvi paralelno čita neku varijablu onda više njih može pročitati istu vrijednost.
Npr. Ako imamo dvije dretve, prva čita 0, druga bi trebala pročitati 1 
(uz pretpostavku da je jedini posao dretve povećati vrijednost varijable za 1)
no ona može pročitati 0, povećati iznos na 1 i prva i druga dretva će u istu varijablu zapisati istu vrijednost (1).
Rezultat te operacije bio bi 1, a očekivali smo 2. Zato koristimo monitore i semafore.