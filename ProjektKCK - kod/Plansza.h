#ifndef PLANSZA_H_INCLUDED
#define PLANSZA_H_INCLUDED
#include "Pole.cpp"

class Plansza {

  public:
    Plansza();
    ~Plansza();
    void wyswietl();

	int jaka_szerokosc() { return szerokosc; }
	int jaka_dlugosc() { return dlugosc; }

	int co_to(int i,int j) { return tab[i][j].stan; }//

    void usun_flage(int a,int b) { tab[a][b].stan=0; }
    void postaw_flage(int a,int b) { tab[a][b].stan=6; }
	Pole **tab;

  protected:
	int szerokosc;
	int dlugosc;

	ALLEGRO_BITMAP *obraz0 = al_load_bitmap("mars.jpg");
	ALLEGRO_BITMAP *obraz1 = al_load_bitmap("1.png");
	ALLEGRO_BITMAP *obraz2 = al_load_bitmap("2.png");
	ALLEGRO_BITMAP *obraz3 = al_load_bitmap("3.png");
	ALLEGRO_BITMAP *obraz4 = al_load_bitmap("4.png");
	ALLEGRO_BITMAP *obraz5 = al_load_bitmap("kamien.png");
	ALLEGRO_BITMAP *obraz6 = al_load_bitmap("flaga.png");
    ALLEGRO_BITMAP *obraz7 = al_load_bitmap("baza.png");
};

#endif // PLANSZA_H_INCLUDED
