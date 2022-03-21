import { Kategorija } from "./Kategorija.js";
import { Kandidat } from "./Kandidat.js";
import { Instruktor } from "./Instruktor.js";

export class KategorijaForma {
    constructor() {
        this.listaKategorija = [];
        this.listaInstruktora = [];
        this.listaKandidata = [];
        this.instruktor = new Instruktor(-1, "", "", 0); //za info deo instruktora
    }

    crtaj(host) {

        let kontrola = document.createElement("div");
        kontrola.classList += "kontrola";
        host.appendChild(kontrola);

        this.dodajKontrolu(kontrola);

        let divTabela = document.createElement("div");
        divTabela.classList += "divTabela";
        host.appendChild(divTabela);

        this.dodajTabelu(divTabela);

        let info = document.createElement("div");
        info.className = "kontrola";
        host.appendChild(info);

        this.pribaviKategorije();
    }

    dodajKontrolu(host) { 

        let kategorijaSelectDiv = document.createElement("div");
        kategorijaSelectDiv.classList += "divKontrola";
        host.appendChild(kategorijaSelectDiv);

        let lblKategorija = document.createElement("label");
        lblKategorija.innerHTML = "Kategorija";
        lblKategorija.classList += "lblKontrola";
        kategorijaSelectDiv.appendChild(lblKategorija);


        let selectKategorije = document.createElement("select");
        selectKategorije.className += "selectKontrola";
        selectKategorije.id = "selectKategorija";

        selectKategorije.onchange = (ev) => {
            let kategorijaID = selectKategorije.options[selectKategorije.selectedIndex].value;
            this.nadjiKandidateUpisaneNaKategoriji(kategorijaID);
            this.updateInfoKategorija();
        }
        kategorijaSelectDiv.appendChild(selectKategorije);

        //div cena kategorije
        let div = document.createElement("div");
        div.className = "divKontrola";

        let lbl1 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl1.innerHTML = "Cena : ";
        div.appendChild(lbl1);

        let lbl2 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl2.id = "lblCenaKat";
        div.appendChild(lbl2);
        host.appendChild(div);

        //label Instruktor
        div = document.createElement("div");
        div.className = "divKontrolaNaslov";
        let lbl = document.createElement("label");
        lbl.innerHTML = "Instruktor";
        lbl.className = "lblKontrolaNaslov";
        div.appendChild(lbl);
        host.appendChild(div);

        // ime insruktora
        div = document.createElement("div");
        div.className = "divKontrola"

        lbl1 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl1.innerHTML = "Ime: ";
        div.appendChild(lbl1);

        lbl2 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl2.id = "imeInstruktor";
        div.appendChild(lbl2);
        host.appendChild(div);

        //prezime instruktora
        div = document.createElement("div");
        div.className = "divKontrola"

        lbl1 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl1.innerHTML = "Prezime: ";
        div.appendChild(lbl1);

        lbl2 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl2.id = "prezimeInstruktor";
        div.appendChild(lbl2);
        host.appendChild(div);

        selectKategorije = document.getElementById("selectKategorija");

        div = document.createElement("div");
        div.className = "divKontrolaNaslov";
        lbl = document.createElement("label");
        lbl.innerHTML = "Kategorija";
        lbl.className = "lblKontrola lblKontrolaNaslov"; 
        div.appendChild(lbl);
        host.appendChild(div);

        //Naziv kategorije
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Naziv: ";

        let tbx = document.createElement("input");
        tbx.type = "text";
        tbx.className = "tbxKontrola";
        tbx.id = "kategorijaNaziv";

        div = document.createElement("div");
        div.className = ("divKontrola");
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //Cena
        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Cena: ";

        tbx = document.createElement("input");
        tbx.type = "number";
        tbx.className = "tbxKontrola";
        tbx.id = "kategorijaCena";

        div = document.createElement("div");
        div.className = ("divKontrola");
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);


        //Instruktor
        let divSelInstruktor = document.createElement("div");
        divSelInstruktor.className = "divKontrola";

        let lblSelInstruktor = document.createElement("label");
        lblSelInstruktor.className = "lblKontrola";
        lblSelInstruktor.innerHTML = "Instruktor";
        divSelInstruktor.appendChild(lblSelInstruktor);

        let selInstruktor = document.createElement("select");
        selInstruktor.className = "selectKontrola";
        selInstruktor.id = "selectInstruktor";
        divSelInstruktor.appendChild(selInstruktor);

        host.appendChild(divSelInstruktor);

        //dodaj kategoriju i promeni instruktora
        div = document.createElement("div");
        div.className = "divKontrola";

        let btn1 = document.createElement("button");
        btn1.className = "btnKontrola";
        btn1.innerHTML = "Dodaj kategoriju";

        btn1.onclick = (e) => this.dodajKategoriju();
        div.appendChild(btn1);
        host.appendChild(div);

        //promeni instruktora
        div = document.createElement("div");
        div.className = "divKontrola";

        let btn2 = document.createElement("button");
        btn2.className = "btnKontrola";
        btn2.innerHTML = "Promeni instruktora";
        btn2.onclick = (e) => this.promeniInstruktora(selectKategorije.options[selectKategorije.selectedIndex].value);
        div.appendChild(btn2);
        host.appendChild(div);

        //izmeni cenu
        lbl1 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl1.innerHTML = "Promeni cenu kategorije";
        host.appendChild(lbl1);

        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Cena: ";

        tbx = document.createElement("input");
        tbx.type = "number";
        tbx.className = "tbxKontrola";
        tbx.id = "NovaCenaKategorije";

        div = document.createElement("div");
        div.className = ("divKontrola");
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //zameni cenu button
        let divZameni = document.createElement("div");
        divZameni.className = "divKontrola";

        btn1 = document.createElement("button");
        btn1.innerHTML = "Zameni cenu";
        btn1.className = "btnKontrola";
        btn1.onclick = (e) =>  this.zameniCenu();
        divZameni.appendChild(btn1);
        host.appendChild(divZameni);

        //izbrisi kategoriju
        let divBtn = document.createElement("div");
        divBtn.className = "divKontrola";

        let btn = document.createElement("button");
        btn.innerHTML = "Izbrisi kategoriju";
        btn.className = "btnKontrola";
        btn.onclick = (e) => this.izbrisiKategoriju(selectKategorije.options[selectKategorije.selectedIndex].value);
        divBtn.appendChild(btn);
        host.appendChild(divBtn);

        //Kandidat
        div = document.createElement("div");
        div.className = "divKontrolaNaslov";
        lbl = document.createElement("label");
        lbl.innerHTML = "Kandidat";
        lbl.className = "lblKontrolaNaslov";
        div.appendChild(lbl);
        host.appendChild(div);

        //Poeni
        lbl1 = document.createElement("label");
        lbl1.className = "lblKontrola";
        lbl1.innerHTML = "Upisi poene kandidatu";
        host.appendChild(lbl1);

        lbl = document.createElement("label");
        lbl.className = "lblKontrola";
        lbl.innerHTML = "Poeni: ";

        tbx = document.createElement("input");
        tbx.type = "number";
        tbx.className = "tbxKontrola";
        tbx.id = "poeniUpis";

        div = document.createElement("div");
        div.className = ("divKontrola");
        div.appendChild(lbl);
        div.appendChild(tbx);
        host.appendChild(div);

        //Upisi poene
        divBtn = document.createElement("div");
        divBtn.className = "divKontrola";

        btn = document.createElement("button");
        btn.innerHTML = "Upisi poene";
        btn.className = "btnKontrola";
        btn.onclick = (ev) => this.upisiPoeneKandidatu(selectKategorije.options[selectKategorije.selectedIndex].value);
        divBtn.appendChild(btn);
        host.appendChild(divBtn);

        //ispisi kandidata sa kategorije
        divBtn = document.createElement("div");
        divBtn.className = "divKontrola";

        btn = document.createElement("button");
        btn.innerHTML = "Ispisi sa kategorije";
        btn.className = "btnKontrola";
        btn.onclick = (ev) => this.ispisiKandidata(selectKategorije.options[selectKategorije.selectedIndex].value);
        divBtn.appendChild(btn);
        host.appendChild(divBtn);

        this.pribaviInstruktore();
    }

    dodajInfoInstruktor() {
        let ime = document.getElementById("imeInstruktor");
        ime.innerHTML = this.instruktor.Ime;

        let prezime = document.getElementById("prezimeInstruktor");
        prezime.innerHTML = this.instruktor.Prezime;
    }

    updateInfoKategorija() {
        let lblCena = document.getElementById("lblCenaKat");
        let selectKategorija = document.getElementById("selectKategorija");
        let index = selectKategorija.selectedIndex;
        let kategorija = this.listaKategorija[index];
        lblCena.innerHTML = kategorija.Cena;
    }

    dodajTabelu(divTabela) {
        let tabela = document.createElement("table");

        tabela.className = "tabela";
        tabela.id = "tabela";
        divTabela.appendChild(tabela);

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

        //Poeni

        el = document.createElement("th");
        el.innerHTML = "Poeni"
        red.appendChild(el);

    }

    updateTabelu() {
        let tabelaKandidata = document.getElementById("tabela");
        while (tabelaKandidata.firstChild) {
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
                    if (p.className != "zaglavlje")
                        p.className = "redUTabeli";
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

            //Poeni

            let poeni = document.createElement("td");
            if (kandidat.Poeni === 0) {
                poeni.innerHTML = "Nije polozio!";
            } else {
                poeni.innerHTML = kandidat.Poeni;
            }
            red.appendChild(poeni);


        });
    }

    //funkcije//
    izbrisiKategoriju(KategorijaID) {
        if (confirm("Stvarno zelis da obrises ovu kategoriju?")) {
            fetch("https://localhost:5001/Kategorija/ObrisiKategoriju/" + KategorijaID, { method: "DELETE" }).then(p => {
                if (!p.ok) {
                    window.alert("Nije moguce obrisati kategoriju!");
                }
                this.pribaviKategorije();
            });
        }
    }
    dodajKategoriju() {
        let slAutoSkole = document.getElementById("selectAutoSkole");
        let autoskolaID = slAutoSkole.options[slAutoSkole.selectedIndex].value;

        let selInstruktor = document.getElementById("selectInstruktor");
        let InstruktorID = selInstruktor.options[selInstruktor.selectedIndex].value;

        let Naziv = document.getElementById("kategorijaNaziv");
        let Cena = document.getElementById("kategorijaCena");



        fetch("https://localhost:5001/Kategorija/DodajKategoriju/" + Naziv.value + "/" + Cena.value + "/" + autoskolaID + "/" + InstruktorID, { method: "POST" }).then(p => {
            if (!p.ok) {
                window.alert("Nije moguce dodati kategoriju!");
            }
            this.pribaviKategorije();
            Naziv.value = "";
            Cena.value = "";
        });

    }

    zameniCenu() {
        let tbxCena = document.getElementById("NovaCenaKategorije");
        let Cena = tbxCena.value;
        tbxCena.value = "";
        let selKategorija = document.getElementById("selectKategorija");
        let KategorijaID = selKategorija.options[selKategorija.selectedIndex].value;

        fetch("https://localhost:5001/Kategorija/ZameniCenu/" + KategorijaID + "/" + Cena, { method: "PUT" }).then(p => {
            this.pribaviKategorije();
            if (!p.ok) {
                window.alert("Nije moguce zameniti cenu!");
            }
        });
    }
    pribaviInstruktore() {
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
                    let selInstruktor = document.getElementById("selectInstruktor");
                    while ( selInstruktor.firstChild) {
                        selInstruktor.removeChild(selInstruktor.firstChild);
                    }
                    this.listaInstruktora.forEach(instruktor => {
                        let iop = document.createElement("option");
                        iop.innerHTML = instruktor.Ime + " " + instruktor.Prezime;
                        iop.value = instruktor.ID;
                        selInstruktor.appendChild(iop);
                    });
                });
            }
        });
    }


    promeniInstruktora(KategorijaID) {
        let selInstruktor = document.getElementById("selectInstruktor");
        let InstruktorID = selInstruktor.options[selInstruktor.selectedIndex].value;

        fetch("https://localhost:5001/Kategorija/PromeniInstruktora/" + KategorijaID + "/" + InstruktorID, { method: "PUT" }).then(p => {
            if (!p.ok) {
                window.alert("Nijem moguce zameniti instruktora!");
            }
            this.pribaviKategorije();
        });
    }

    upisiPoeneKandidatu(KategorijaID) {     
        let kandidatID = document.getElementById("selektovanRed");
        let poeni = document.getElementById("poeniUpis");
        if (kandidatID != null) {
            fetch("https://localhost:5001/Polaze/UpisiPoene/" + kandidatID.value + "/" + KategorijaID + "/" + poeni.value, { method: 'PUT' })
                .then(p => {
                    if (!p.ok) {
                        window.alert("Nije moguce upisati poene kandidatu!");
                    }
                    this.nadjiKandidateUpisaneNaKategoriji(KategorijaID);
                    poeni.value = "";
                });
        } else {
            window.alert("Selektuj kandidata prvo!");
        }
    }
    pribaviKategorije() {
        let slAutoSkole = document.getElementById("selectAutoSkole");
        let autoskolaID = slAutoSkole.options[slAutoSkole.selectedIndex].value;
        this.listaKategorija.length = 0;

        fetch("https://localhost:5001/Kategorija/PreuzmiKategorije/" + autoskolaID).then(p => {
            p.json().then(kategorije => {
                if (!p.ok) {
                    window.alert("Nije moguce pribaviti kategorije!");
                } else {
                    kategorije.forEach(k => {
                        let kat = new Kategorija(k.kategorijaID, k.kategorijaNaziv, k.kategorijaCena, k.instruktorID);
                        this.listaKategorija.push(kat);
                    });

                    this.updateListuKategorija();
                    this.updateInfo();
                }
            });
        });

    }
    nadjiKandidateUpisaneNaKategoriji(idKategorije) {
        this.listaKandidata.length = 0;
        fetch("https://localhost:5001/Polaze/PreuzmiKandidateUpisaneNaKategoriji/" + idKategorije).then(p => {
            p.json().then(kandidati => {
                if (!p.ok) {
                    window.alert("Nije moguce pribaviti kandidate!");
                } else {
                    kandidati.forEach(kandidat => {
                        let ka = new Kandidat(kandidat.kandidatID, kandidat.jmbg, kandidat.ime, kandidat.prezime, idKategorije, kandidat.poeni);
                        this.listaKandidata.push(ka);
                    });
                    this.updateTabelu();
                    this.updateInfo();
                }
            });
        });

    }

    ispisiKandidata(kategorijaID) {  
        let kandidatID = document.getElementById("selektovanRed");
        if (kandidatID != null) {
            if (confirm("Da li stvarno zelis da ispises kandidata?")) {
                fetch("https://localhost:5001/Polaze/IspisiKandidataSaKategorije/" + kandidatID.value + "/" + kategorijaID, { method: 'DELETE' })
                    .then(p => {
                        if (!p.ok) {
                            window.alert("Nije moguce ispisati kandidata!");
                        }
                        this.nadjiKandidateUpisaneNaKategoriji(kategorijaID);
                    });
            }
        } else {
            window.alert("Selektuj kandidata prvo!");
        }
    }
    updateInfo() {
        let selectKategorija = document.getElementById("selectKategorija");
        let index = selectKategorija.selectedIndex;
        let kategorija = this.listaKategorija[index];

        fetch("https://localhost:5001/Instruktor/VratiInstruktora/" + kategorija.InstruktorID).then(p => {
            if (!p.ok) {
                window.alert("Nije moguce pribaviti instruktora!");
            } else {
                p.json().then(inst => {
                    this.instruktor.ID = inst.id;
                    this.instruktor.Ime = inst.ime;
                    this.instruktor.Prezime = inst.prezime;
                    this.dodajInfoInstruktor();
                });
            }
        });

    }
    updateListuKategorija() {
        let selectKategorija = document.getElementById("selectKategorija");
        while ( selectKategorija.firstChild) {
            selectKategorija.removeChild(selectKategorija.firstChild);
        }

        let kategorija;
        this.listaKategorija.forEach(kat => {
            kategorija = document.createElement("option");
            kategorija.innerHTML = kat.Naziv;
            kategorija.value = kat.ID;
            selectKategorija.appendChild(kategorija);
        });
        this.nadjiKandidateUpisaneNaKategoriji(selectKategorija.options[selectKategorija.selectedIndex].value);
        this.updateInfoKategorija();
        this.updateInfo();
    }

}