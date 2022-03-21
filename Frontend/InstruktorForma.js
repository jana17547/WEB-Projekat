import { Instruktor } from "./Instruktor.js";

export class InstruktorForma {
    constructor() {
        this.listaInstruktora = [];
    }

    crtaj(host) {
        //div za dodavanje instruktora
        let divDodaj = document.createElement("div");
        divDodaj.className = "kontrola";
        host.appendChild(divDodaj);
        this.crtajDivDodaj(divDodaj);
        
        //div za tabelu
        let divTabela = document.createElement("div");
        divTabela.className = "divTabela";
        host.appendChild(divTabela);
        this.crtajTabelu(divTabela);

        this.vratiInstruktore();
    }

    crtajDivDodaj(host) {
        let div = document.createElement("div");
        div.className = "divKontrolaNaslov";
        let lbl = document.createElement("label");
        lbl.innerHTML = "Dodaj novog instruktora";
        lbl.className = "lblKontrolaNaslov"; 
        div.appendChild(lbl);
        host.appendChild(div);

        //Ime
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Ime:     &nbsp; &nbsp; &nbsp;";

        let tbx = document.createElement("input");
        tbx.type = "text";
        tbx.className = "tbxKontrola";
        tbx.id = "imeInstruktora";

        div = document.createElement("div");
        div.className = "divKontrola";
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //Prezime
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Prezime:";

        tbx = document.createElement("input");
        tbx.type = "text";
        tbx.className = "tbxKontrola";
        tbx.id = "prezimeInstruktora";

        div = document.createElement("div");
        div.className = "divKontrola";
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //Dodaj instruktora
        let divBtn = document.createElement("div");
        divBtn.className = "divKontrola";

        let btn = document.createElement("button");
        btn.innerHTML = "Dodaj instruktora";
        btn.className = "btnKontrola";
        btn.onclick = (ev) =>  this.dodajInstruktora();
        divBtn.appendChild(btn);
        host.appendChild(divBtn);


       divBtn = document.createElement("div");
       divBtn.className =  "divKontrola";

       btn = document.createElement("button");
       btn.innerHTML = "Izbrisi";
       btn.className = "btnKontrola";
       btn.onclick =  (e) => this.izbrisiInstruktora();
       divBtn.appendChild(btn);
       host.appendChild(divBtn);
    }


    crtajTabelu(divTabela) {
        let tabela = document.createElement("table");
        tabela.className = "tabela";
        tabela.id = "tabela"
        divTabela.appendChild(tabela);

        this.zaglavljeTabele(tabela);
    }

    zaglavljeTabele(tabela) {

        let red = document.createElement("tr");
        red.className = "zaglavlje"
        tabela.appendChild(red);

        //Ime

        let el = document.createElement("th");
        el.innerHTML = "Ime"
        red.appendChild(el);

        //Prezime

        el = document.createElement("th");
        el.innerHTML = "Prezime"
        red.appendChild(el);

        //Broj kategorija

        el = document.createElement("th");
        el.innerHTML = "Broj kategorija";
        red.appendChild(el);
    }

    updateTabelu() {
        let tabelaInstruktor = document.getElementById("tabela");
        while ( tabelaInstruktor.firstChild) {
            tabelaInstruktor.removeChild(tabelaInstruktor.firstChild);
        }

        //Brisemo celu tabelu pa dodajemo sve ponovo, inace ce prethodni sadrzaj da se nadoveze
        //dodajemo ponovo i zaglavlje
        this.zaglavljeTabele(tabelaInstruktor);

        this.listaInstruktora.forEach((instruktor) => {
            var red = document.createElement("tr");
            red.className = "redUTabeli";
            red.value = instruktor.ID;

            //Selekcija reda (koji red je selektovan)
            red.addEventListener("click", () => {
                tabelaInstruktor.childNodes.forEach(p => {
                    if (p.className != "zaglavlje") {
                        p.className = "redUTabeli";
                        p.id = "";
                    }
                });
                red.classList += " selektovanRed";
                red.id = "selektovanRed";
            });

            tabelaInstruktor.appendChild(red);
            //Ime

            let ime = document.createElement("td");
            ime.innerHTML = instruktor.Ime;
            red.appendChild(ime);

            //Prezime

            let prezime = document.createElement("td");
            prezime.innerHTML = instruktor.Prezime;
            red.appendChild(prezime);


            //Broj Kategorija

            let br = document.createElement("td");
            br.innerHTML = instruktor.brojKategorija;
            red.appendChild(br);
        });
   }

    //funkcije//

    dodajInstruktora() {
        let ime = document.getElementById("imeInstruktora").value;
        let prezime = document.getElementById("prezimeInstruktora").value;
        document.getElementById("imeInstruktora").value = "";
        document.getElementById("prezimeInstruktora").value = "";

        fetch("https://localhost:5001/Instruktor/DodajInstruktora/" + ime + "/" + prezime, { method: "POST" }).then(p => {
            if (!p.ok) {
                window.alert("Nije moguce dodati instruktora!");
            }
            this.vratiInstruktore();
        });
    }

    vratiInstruktore() {
        let slAutoSkole = document.getElementById("selectAutoSkole");
        let AutoskolaID = slAutoSkole.options[slAutoSkole.selectedIndex].value;
        this.listaInstruktora.length = 0;
        fetch("https://localhost:5001/Instruktor/VratiInstruktoreZaTrazenuAutoSkolu/" + AutoskolaID).then(p => {
            if (!p.ok) {
                window.alert("Nije moguce pribaviti instruktore!");
            } else {
                p.json().then(instruktori => {
                    instruktori.forEach(instruktor => {
                        this.listaInstruktora.push(new Instruktor(instruktor.id, instruktor.ime, instruktor.prezime, instruktor.brojKategorija));

                    });
                    this.updateTabelu();
                });
            }
        })
    }

    izbrisiInstruktora() {
        let InstruktorID = document.getElementById("selektovanRed").value;
        fetch("https://localhost:5001/Instruktor/IzbrisiInstruktora/" + InstruktorID, { method: "DELETE" }).then(p => {
            if (!p.ok) {
                alert("Nije moguce obrisati instruktora!");
            } else {
                this.vratiInstruktore();
            }
        });
    }

}