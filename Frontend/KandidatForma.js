import { Kategorija } from "./Kategorija.js";
import { Kandidat } from "./Kandidat.js";

export class KandidatForma {
    constructor() {
        this.listaKandidata = [];
        this.listaKategorija = [];
    }

    crtaj(host) {

        //div dodaj kandidata
        let divDodaj = document.createElement("div");
        divDodaj.className = "kontrola";
        host.appendChild(divDodaj);
        this.crtajDivDodaj(divDodaj);

        //div tabela
        let divTabela = document.createElement("div");
        divTabela.className = "divTabela";
        host.appendChild(divTabela);
        this.crtajTabelu(divTabela);

        this.pribaviKategorije();
        this.pribaviKandidateBezKategorije();
    }

    crtajDivDodaj(host) {

        let div = document.createElement("div");
        div.className = "divKontrolaNaslov";
        let lbl = document.createElement("label");
        lbl.innerHTML = "Dodaj novog kandidata";
        lbl.className = "lblKontrola lblKontrolaNaslov";
        div.appendChild(lbl);
        host.appendChild(div);

        //div text i text box za Jmbg
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Jmbg:  &nbsp;&nbsp;&nbsp; ";

        let tbx = document.createElement("input");
        tbx.type = "string"; 
        tbx.className = "tbxKontrola";
        tbx.id = "tbxJmbgKontrola";

        div = document.createElement("div");
        div.className = "divKontrola";
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //Ime
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Ime: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
     
        tbx = document.createElement("input");
        tbx.type = "text"; 
        tbx.className = "tbxKontrola";
        tbx.id = "tbxImeKontrola";

        div = document.createElement("div");
        div.className = "divKontrola";
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //Prezime
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Prezime: ";

        tbx = document.createElement("input");
        tbx.type = "text"; 
        tbx.className = "tbxKontrola";
        tbx.id = "tbxPrezimeKontrola";

        div = document.createElement("div");
        div.className = "divKontrola";
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //dugme dodaj kandidata
        let divBtnDodaj = document.createElement("div");
        divBtnDodaj.className = "divKontrola";
        let btnDodaj = document.createElement("button");
        btnDodaj.className = "btnKontrola";
        btnDodaj.innerHTML = "Dodaj kandidata";
        btnDodaj.onclick = (ev) => { this.dodajKandidata(); }
        divBtnDodaj.appendChild(btnDodaj);
        host.appendChild(divBtnDodaj);

                //selekcija kategorija za upis
                let divKategorija = document.createElement("div");
                divKategorija.className = "divKontrola";
                host.appendChild(divKategorija);
        
                let lblKategorija = document.createElement("label");
                lblKategorija.className = "lblKontrola";
                lblKategorija.innerHTML = "Kategorija";
                divKategorija.appendChild(lblKategorija);
        
                let selKategorija = document.createElement("select");
                selKategorija.className = "selectKontrola";
                selKategorija.id = "selKategorija";
                divKategorija.appendChild(selKategorija);
        
                //upisi kandidata
                let divBtn = document.createElement("div");
                divBtn.className = "divKontrola";
        
                let btn = document.createElement("button");
                btn.innerHTML = "Upisi kandidata";
                btn.className = "btnKontrola";
                btn.onclick =  (ev) => { this.upisiKandidata(selKategorija.options[selKategorija.selectedIndex].value); };
                divBtn.appendChild(btn);
                host.appendChild(divBtn);
        
                //obrisi kandidata
                divBtn = document.createElement("div");
                divBtn.className = "divKontrola";
        
                btn = document.createElement("button");
                btn.innerHTML = "Izbrisi kandidata";
                btn.className = "btnKontrola";
                btn.onclick =  (ev) =>  this.obrisiKandidata();
                divBtn.appendChild(btn);
                host.appendChild(divBtn);
        
                //pretrazi kandidata bez kategorije
                lbl = document.createElement("label");
                lbl.className = "lblKontrola";
                lbl.innerHTML = "Jmbg: &nbsp;&nbsp;";
        
                tbx = document.createElement("input");
                tbx.type = "text"; 
                tbx.className = "tbxKontrola";
                tbx.id = "tbxJmbgPretraga";
        
                 div = document.createElement("div");
                div.className = "divKontrola";
                div.appendChild(lbl);
                div.appendChild(tbx);
                host.appendChild(div);
        
                //pretrazi preko jmbg kandidata bez kategorije
                divBtn = document.createElement("div");
                divBtn.className = "divKontrola";
        
                btn = document.createElement("button");
                btn.innerHTML = "Pretrazi ";
                btn.className = "btnKontrola";
                btn.onclick =   (ev) => this.pretraziKandidata();
                divBtn.appendChild(btn);
                host.appendChild(divBtn);
        
                //kada pretrazimo kandidata nakon prikazivanja moramo da vratimo stanje tabele
                divBtn = document.createElement("div");
                divBtn.className = "divKontrola";
        
                btn = document.createElement("button");
                btn.innerHTML = "Prikazi kandidate bez kategorije ";
                btn.className = "btnKontrola";
                btn.onclick =  (ev) => this.pribaviKandidateBezKategorije();
                divBtn.appendChild(btn);
                host.appendChild(divBtn);
    }

    //Tabela
    crtajTabelu(host) {
        let tabela = document.createElement("table");
        tabela.className = "tabela";
        tabela.id = "tabela"
        host.appendChild(tabela);

        this.zaglavljeTabele(tabela);
    }

    zaglavljeTabele(tabela) {
        //Napravi zaglavlje

        let red = document.createElement("tr");
        red.className = "zaglavlje"
        tabela.appendChild(red);

        //Jmbg

        let el = document.createElement("th");
        el.innerHTML = "Jmbg"
        red.appendChild(el);
  

        //Ime

        el = document.createElement("th");
        el.innerHTML = "Ime"
        red.appendChild(el);

        //Prezime

        el = document.createElement("th");
        el.innerHTML = "Prezime"
        red.appendChild(el);

        
    }

    updateTabelu() {
        let tabelaKandidata = document.getElementById("tabela");
        while ( tabelaKandidata.firstChild) {
            tabelaKandidata.removeChild(tabelaKandidata.firstChild);
        }
        //Brise se sve iza tabele, cak i zaglavlja pa moramo da ponovo dodamo
        this.zaglavljeTabele(tabelaKandidata);

        this.listaKandidata.forEach((kandidat) => {
            var red = document.createElement("tr");
            red.className = "redUTabeli";

            red.value = kandidat.ID;

            //Za selekciju, da vidmo koji je red selektovan
            red.addEventListener("click", () => {
                tabelaKandidata.childNodes.forEach(p => {
                    if (p.className != "zaglavlje") {
                        p.className = "redUTabeli";
                        p.id = "";
                    }
                });
                red.classList += " selektovanRed";
                red.id = "selektovanRed";
            });

            tabelaKandidata.appendChild(red);

            //Jmbg

            let jmbg = document.createElement("td");
            jmbg.innerHTML = kandidat.Jmbg;
            red.appendChild(jmbg);

            //Ime

            let ime = document.createElement("td");
            ime.innerHTML = kandidat.Ime;
            red.appendChild(ime);

            //Prezime

            let prezime = document.createElement("td");
            prezime.innerHTML = kandidat.Prezime;
            red.appendChild(prezime);

        });
    }

    //funkcije//
    dodajKandidata() {
        let Jmbg = document.getElementById("tbxJmbgKontrola").value;
        let Ime = document.getElementById("tbxImeKontrola").value;
        let Prezime = document.getElementById("tbxPrezimeKontrola").value;

        document.getElementById("tbxJmbgKontrola").value = "";
        document.getElementById("tbxImeKontrola").value = "";
        document.getElementById("tbxPrezimeKontrola").value = "";
        fetch("https://localhost:5001/Kandidat/DodajKandidata/" + Jmbg + "/" + Ime + "/" + Prezime, { method: "POST" }).then(p => {
            this.pribaviKandidateBezKategorije();
            if (!p.ok) {
                window.alert("Podaci o kandidatu nisu validni!");
            }
        });
    }

    pribaviKategorije() {
        let slAutoSkole = document.getElementById("selectAutoSkole");
        let autoskolaID = slAutoSkole.options[slAutoSkole.selectedIndex].value;
        this.listaKategorija.length = 0;

        fetch("https://localhost:5001/Kategorija/PreuzmiKategorije/" + autoskolaID).then(p => {
            p.json().then(kategorije => {
                kategorije.forEach(k => {
                    let kat = new Kategorija(k.kategorijaID, k.kategorijaNaziv, k.kategorijaCena, k.instruktorID);
                    this.listaKategorija.push(kat);
                });

                let selectKategorija = document.getElementById("selKategorija");
                let kategorija;
                this.listaKategorija.forEach(kat => {
                    kategorija = document.createElement("option");
                    kategorija.innerHTML = kat.Naziv;
                    kategorija.value = kat.ID;
                    selectKategorija.appendChild(kategorija);
                });
            });
        });
    }
    upisiKandidata(KategorijaID) {
        let red = document.getElementById("selektovanRed");
        if (red != null) {
            let KandidatID = red.value;
            fetch("https://localhost:5001/Polaze/UpisiKandidata/" + KandidatID + "/" + KategorijaID, { method: "POST" }).then(p => {
                this.pribaviKandidateBezKategorije();
                if (!p.ok) {
                    window.alert("Nije moguce upisati kandidata na kategoriji!");
                }
            });
        } else {
            window.alert("Selektuj kandidata!");
        }
    }

    obrisiKandidata() {
        if (confirm("Da li zelis da izbrises kandidata?")) {
            let red = document.getElementById("selektovanRed");
            if (red != null) {
                let KandidatID = red.value;
                fetch("https://localhost:5001/Kandidat/ObrisiKandidata/" + KandidatID, { method: "DELETE" }).then(p => {
                    this.pribaviKandidateBezKategorije();
                    if (!p.ok) {
                        window.alert("Nije moguce obrisati kandidata!");
                    }
                });
            } else {
                window.alert("Selektuj kandidata!");
            }
        }
    }

    pribaviKandidateBezKategorije() {
        this.listaKandidata.length = 0;
        fetch("https://localhost:5001/Polaze/VratiKandidateKojiNisuUpisani").then(p => p.json().then(kandidati => {
            kandidati.forEach(kandidat => {
                let ka = new Kandidat(kandidat.id, kandidat.jmbg, kandidat.ime, kandidat.prezime, -1, 0);
                this.listaKandidata.push(ka);
            });
            this.updateTabelu();
        }));
    }

    pretraziKandidata() {
        let jmbgKandidata = document.getElementById("tbxJmbgPretraga").value;
        if (jmbgKandidata.length === 0) {
            window.alert("Unesite jmbg kandidata za pretragu!");
        } else {
            fetch("https://localhost:5001/Kandidat/VratiKandidateNaOsnovuJmbg/" + jmbgKandidata).then(p => {
                if (!p.ok) {
                    window.alert("Nema takvog kandidata!");
                } else {
                    p.json().then(kandidati => {
                        this.listaKandidata.length = 0;
                        if (kandidati.length === 0)
                            window.alert("Nije pronadjen nijedan kandidat!");
                        kandidati.forEach(kandidat => {
                            this.listaKandidata.push(new Kandidat(kandidat.id, kandidat.jmbg, kandidat.ime, kandidat.prezime, -1, 0));
                            this.updateTabelu();
                        });
                    });
                }
            });
        }
    }
    
}