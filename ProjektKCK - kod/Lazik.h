#ifndef LAZIK_H_INCLUDED
#define LAZIK_H_INCLUDED


class Lazik {

  public:
    Lazik( int i, int j ) { x_max=i; y_max=j; }
    void wyswietl() { al_draw_bitmap (obraz,50+x*50, 100+y*50,0); }
    bool prawo() { if (x==x_max-1) return false; x++; return true; }
    bool lewo() { if (x==0) return false; x--; return true; }
    bool gora() { if (y==0) return false; y--; return true; }
    bool dol() { if (y==y_max-1) return false; y++; return true; }


    int zwroc_min1() { return min1; }
    int zwroc_min2() { return min2; }
    int zwroc_min3() { return min3; }
    int zwroc_min4() { return min4; }

    int zwroc_x() { return x; }
    int zwroc_y() { return y; }

    bool zwieksz_min1() { if(min1 > 2) return false; min1++; return true; }
    bool zwieksz_min2() { if(min2 > 2) return false; min2++; return true; }
    bool zwieksz_min3() { if(min3 > 2) return false; min3++; return true; }
    bool zwieksz_min4() { if(min4 > 2) return false; min4++; return true; }

    bool wez_flage() { if (flaga) return false; flaga=true; return true; }
    bool odloz_flage() { if (!flaga) return false; flaga=false; return true; }
    bool zwroc_flage() { return flaga; }

    void zeruj() {
        min1 = 0;
        min2 = 0;
        min3 = 0;
        min4 = 0;
    }

  protected:
    ALLEGRO_BITMAP *obraz = al_load_bitmap("lazik.png");
    int x = 0;
    int y = 0;
    int x_max;
    int y_max;
    int min1=0,min2=0,min3=0,min4=0;
    bool flaga=0;

};


#endif // LAZIK_H_INCLUDED
