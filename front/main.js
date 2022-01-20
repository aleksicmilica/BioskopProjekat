import { Bioskop } from "./Bioskop.js";
import {Film} from "./Film.js";

fetch("https://localhost:5001/Bioskop/Bioskopi").then(p => {
    if (p.ok) {
        p.json().then(
            bioskopi => {
                bioskopi.forEach(element => {
                    var divb = document.createElement("div");
                    divb.className = "izborBioskopa";
                    divb.innerHTML = element.naziv;
                    document.body.appendChild(divb);

                    divb.onclick = (ev) => {
                        let listaFilmova = [];
                        element.filmovi.forEach( obj => {
                            let f = new Film(null,obj.film.naziv,obj.film.id);
                            listaFilmova.push(f);
                        });

                        var b = new Bioskop(element.id, element.naziv, listaFilmova);
                        var pozadina = document.body.querySelector(".pozadina");
                        if (pozadina !== null){
                            var rod = pozadina.parentNode;
                            rod.removeChild(pozadina);
                        }
                        var izborBioskopa = document.body.querySelectorAll(".izborBioskopa");
                        
                        izborBioskopa.forEach(element => {
                            let rod = element.parentNode;
                            rod.removeChild(element);
                        });
                        pozadina = document.createElement("div");
                        pozadina.className="pozadina";
                        document.body.appendChild(pozadina);
                        b.crtajBioskop(pozadina);

                    };
                });
            }
        );
    }
});

