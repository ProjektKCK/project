#include "Plansza.h"
#include <fstream>
using namespace std;

Plansza::Plansza() {
    fstream plik;
    plik.open("plansza.txt", ios_base::in);

    if(plik.good()) {
        plik >> szerokosc;
        plik >> dlugosc;

        tab = new Pole *[szerokosc];
        for (int i=0;i<szerokosc;i++) tab[i] = new Pole [dlugosc];

        string dane;
        getline(plik,dane);

        for (int i=0;i<dlugosc;i++) {

            getline(plik,dane);
            for (int j=0;j<szerokosc;j++) tab[j][i].stan = (int)(dane[j]-'0');

        }

        plik.close();
    }
}


Plansza::~Plansza() {

    for (int i=0;i<szerokosc;i++) delete [] tab[i];
    delete [] tab;

}


void Plansza::wyswietl() {
        for (int i=0;i<szerokosc;i++) for (int j=0;j<dlugosc;j++) switch (tab[i][j].stan) {
            case 0:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                break;
            case 1:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz1,50+i*50, 100+j*50,0);
                break;
            case 2:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz2,50+i*50, 100+j*50,0);
                break;
            case 3:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz3,50+i*50, 100+j*50,0);
                break;
            case 4:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz4,50+i*50, 100+j*50,0);
                break;
            case 5:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz5,50+i*50, 100+j*50,0);
                break;
            case 6:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz6,50+i*50, 100+j*50,0);
                break;
            case 7:
                al_draw_bitmap (obraz0,50+i*50, 100+j*50,0);
                al_draw_bitmap (obraz7,50+i*50, 100+j*50,0);
                break;

        }
    }
