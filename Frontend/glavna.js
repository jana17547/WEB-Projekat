import { AutoSkola } from "./AutoSkola.js";
import { InstruktorForma } from "./InstruktorForma.js";
import { KandidatForma } from "./KandidatForma.js";
import { KategorijaForma } from "./KategorijaForma.js";


let listaAutoSkola = [];

PocetnaStrana();
preuzmiAutoSkole();

function PocetnaStrana() {
    //kreiranje strane
    let pocetnaPrikaz = document.createElement("div");
    pocetnaPrikaz.className = "pocetnaPrikaz";
    document.body.appendChild(pocetnaPrikaz);

    //prvi bar
    let barNaslov = document.createElement("div");
    barNaslov.className = "barNaslov";
    pocetnaPrikaz.appendChild(barNaslov);

    //div za naslov
    let naslovDiv = document.createElement("div");
    naslovDiv.className = "divNaslov";
   
    //labela za naslov
    let naslov = document.createElement("label");
    naslov.innerHTML = "";
    naslov.className = "lblNaslov";

    //smestamo to u pocetni div
    naslovDiv.appendChild(naslov);
    barNaslov.appendChild(naslovDiv);

    //div selekcija autoskola
    let selAutoSkole = document.createElement("div");
    selAutoSkole.className = "divKontrola";
    barNaslov.appendChild(selAutoSkole);

    let divLblAutoSkole = document.createElement("div"); //div za lbl Auto Skola
    divLblAutoSkole.className = "divKontrolaNaslov";
    let lblAutoSkole = document.createElement("label");  //label AutoSkola
    lblAutoSkole.innerHTML = "Auto Skola "
    lblAutoSkole.className = "lblKontrolaNaslov";
    divLblAutoSkole.appendChild(lblAutoSkole);
    selAutoSkole.appendChild(divLblAutoSkole); //u div selekcija autoskola

    //dugme select 
    let selectAutoSkole = document.createElement("select");
    selectAutoSkole.className = "selectKontrola";
    selectAutoSkole.id = "selectAutoSkole";
    selectAutoSkole.onchange = (ev) => {
        let sel = document.getElementById("selectEl");
        switch (sel.selectedIndex) {
            case 0:
                Kategorije();
                break;
            case 1:
                Kandidati();
                break;
            default:
                Instruktori();
                break;
        }

    }
    selAutoSkole.appendChild(selectAutoSkole);

    //---------
    let navigacija = document.createElement("div");
    navigacija.className = "navigacija";
    barNaslov.appendChild(navigacija);
    kreairajNavigaciju(navigacija);

    let sredina = document.createElement("div");
    sredina.className = "sredina";
    pocetnaPrikaz.appendChild(sredina);



    let sadrzaj = document.createElement("div");
    sadrzaj.className = "sadrzaj";
    sadrzaj.id = "sadrzaj";
    sredina.appendChild(sadrzaj);
 
 }

function kreairajNavigaciju(nav) {
    let selekcija = document.createElement("select");
    selekcija.className = "selectKontrola";
    selekcija.id = "selectEl"

    let op = document.createElement("option");
    op.value = 1;
    op.innerHTML = "Kategorije";
    selekcija.appendChild(op);

    op = document.createElement("option");
    op.value = 2;
    op.innerHTML = "Kandidati";
    selekcija.appendChild(op);

    op = document.createElement("option");
    op.value = 3;
    op.innerHTML = "Instruktori";
    selekcija.appendChild(op);

    selekcija.onchange = (e) => {
        switch (selekcija.selectedIndex) {
            case 0:
                Kategorije();
                break;
            case 1:
                Kandidati();
                break;
            default:
                Instruktori();
                break;
        }
    };
    nav.appendChild(selekcija);
}

function Instruktori() {
    let sadrzaj = document.getElementById("sadrzaj");
    while (sadrzaj.firstChild) {
        sadrzaj.removeChild(sadrzaj.firstChild);
    }

    let instForma = new InstruktorForma();
    instForma.crtaj(sadrzaj); //crtamo formu instruktor
}

function Kategorije() {
    let sadrzaj = document.getElementById("sadrzaj"); 
    while (sadrzaj.firstChild) {
        sadrzaj.removeChild(sadrzaj.firstChild);
    }
    

    let katForma = new KategorijaForma();
    katForma.crtaj(sadrzaj);  //crtamo formu kategorija
}

function Kandidati() {
    let sadrzaj = document.getElementById("sadrzaj");
    while (sadrzaj.firstChild) {
        sadrzaj.removeChild(sadrzaj.firstChild);
    }

    let kandidatForma = new KandidatForma();
    kandidatForma.crtaj(sadrzaj); //crtamo formu kandidat
}



function upisiAutoSkole() {
    let slAutoSkole = document.getElementById("selectAutoSkole");

    listaAutoSkola.forEach(autosk => {
        let autoskola = document.createElement("option");
        autoskola.innerHTML = autosk.Ime;
        autoskola.value = autosk.ID;
        slAutoSkole.appendChild(autoskola);
    })
}
function preuzmiAutoSkole() {
    fetch("https://localhost:5001/Autoskola/PreuzmiAutoskole").then(s => {
        if (!s.ok) {
            window.alert("Nije moguce prikazati autoskole!");
        } else {
            s.json().then(autoskole => {
                autoskole.forEach(autoskola => {
                    let autosk = new AutoSkola(autoskola.id, autoskola.ime, autoskola.tip);
                    listaAutoSkola.push(autosk);

                });
                upisiAutoSkole();
                Kategorije();
            });
        }
    });
}


    