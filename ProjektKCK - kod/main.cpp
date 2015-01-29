#include <iostream>
#include <allegro5/allegro.h>
#include <allegro5/allegro_image.h>
#include <allegro5/allegro_font.h>
#include "Plansza.cpp"
#include "Lazik.cpp"
using namespace std;
int LiczbaWStringu(string x){
    int a=0;
    for(int i=0;i<x.length();i++){
        if(48<=x[i] && x[i]<=57){
            while(x[i]<=57 && 48<=x[i] && i<x.length()){
                a=10*a+(x[i]-'0');
                i++;
            }
            break;
        }
    }
    if ( a==0 ) a=1;
    return a;
}

bool CzyWystepuje( string & tekst, string szukanaFraza ) {
    size_t znalezionaPozycja = tekst.find( szukanaFraza );
    if( znalezionaPozycja == std::string::npos ) return 0;
    else return 1;
}

int Polecenie(string x) {
    if ( (CzyWystepuje(x, "przenies") || CzyWystepuje(x, "przesun")) && CzyWystepuje(x, "gore") ) return 9;
    else if( (CzyWystepuje(x, "przenies") || CzyWystepuje(x, "przesun")) && CzyWystepuje(x, "dol") ) return 10;
    else if( (CzyWystepuje(x, "przenies") || CzyWystepuje(x, "przesun")) && CzyWystepuje(x, "lewo") ) return 11;
    else if( (CzyWystepuje(x, "przenies") || CzyWystepuje(x, "przesun")) && CzyWystepuje(x, "prawo") ) return 12;
    else if(CzyWystepuje(x, "wyrzuc")) return 13;
    else if( CzyWystepuje(x, "lewo")==1 ) return 1;
    else if( CzyWystepuje(x, "prawo")==1 ) return 2;
    else if( CzyWystepuje(x, "gore")==1 ) return 3;
    else if( CzyWystepuje(x, "dol")==1 ) return 4;
    else if( CzyWystepuje(x, "flage")==1 ) {
        if ( CzyWystepuje(x,"wez") || CzyWystepuje(x,"zabierz") ) return 5;
        else if ( CzyWystepuje(x,"postaw") ) return 6;
    }
    else if( ( CzyWystepuje(x, "pobierz")==1 || CzyWystepuje(x,"wez") ) && CzyWystepuje(x,"mineral") ) return 7;
    else if( CzyWystepuje(x,"?") && CzyWystepuje(x,"mineral") ) return 8;
    else if (CzyWystepuje(x,"zniszcz") || CzyWystepuje(x,"rozwal")) return 14;
    else if (CzyWystepuje(x,"skanuj") ) return 15;
    else return 0;
}

bool czyFlaga(Lazik lazik) {
    if (!lazik.zwroc_flage()) {
            cout<<"Nie mam żadnej flagi.\n";
            return false;
    }
    return true;
}

 void polozFlage(int x, int y, Plansza& plansza, Lazik& lazik) {
     if (plansza.co_to(x, y) == 0 ) {
        if ( lazik.odloz_flage() ) {
        plansza.postaw_flage(x, y);
                cout<<"Wbiłem flagę.\n";
            } else cout<<"Przecież nie mam flagi.\n";
    } else cout<<"Tutaj jest minerał. Nie mogę wbić w niego flagi.\n";
}

int main() {

    al_init();
    al_init_image_addon();
    al_init_font_addon();

    Plansza plansza;

    ALLEGRO_FONT * font8 = al_create_builtin_font();
    //760, 540);

    ALLEGRO_DISPLAY *okno = al_create_display( 100+plansza.jaka_szerokosc()*50,150+plansza.jaka_dlugosc()*50);
    al_set_window_title( okno,"Łazik");

    Lazik lazik(plansza.jaka_szerokosc(),plansza.jaka_dlugosc());

    int czyDziala = 1, liczba, u;
    bool f;
    string a;
    cout << "Witaj! ";


    //prawo, lewo, góra, dół, weź flagę, postaw flagę, koniec
        al_clear_to_color(al_map_rgb( 220, 100, 60));
        al_draw_textf(font8, al_map_rgb(100,220,100), 20, 10, 0,"Minerał1: %3d", lazik.zwroc_min1() );
        al_draw_textf(font8, al_map_rgb(255,255,0), 20, 30, 0,"Minerał2: %3d", lazik.zwroc_min2() );
        al_draw_textf(font8, al_map_rgb(255,150,150), 20, 50, 0,"Minerał3: %3d", lazik.zwroc_min3() );
        al_draw_textf(font8, al_map_rgb(50,50,250), 20, 70, 0,"Minerał4: %3d", lazik.zwroc_min4() );

    while (czyDziala) {

       // al_clear_to_color(al_map_rgb( 220, 100, 60));

        //if (((lazik.zwroc_x() == 7) && (lazik.zwroc_y() == 1)) || ((lazik.zwroc_x() == 1) && (lazik.zwroc_y() == 2))) {
        //    cout << "jesteś w bazie ;)\n";
       // }

        plansza.wyswietl();
        lazik.wyswietl();
        al_flip_display();

        cout << "Co mam robić?\n> ";
        getline(cin, a);

        switch (Polecenie(a)) {
            case 0:
                cout << "Nie rozumiem";
                break;
            case 1:
              liczba = LiczbaWStringu(a);

              while (liczba--) {
                  if ( lazik.zwroc_x()-1>=0 && plansza.co_to( lazik.zwroc_x()-1,lazik.zwroc_y() )==5 ) {
                      cout<<"Na lewo jest kamień. Nie mogę tamtędy dalej pójść.\n";
                      break;
                  } else if (lazik.lewo()) { if ( !liczba ) cout<<"Wykonane.\n"; }
                  else {
                      cout<<"Nie mogę tam pójść.\n";
                      break;
                  }
              }
              break;

            case 2:
              liczba = LiczbaWStringu(a);
              while (liczba--) {
                  if ( lazik.zwroc_x()+1<plansza.jaka_szerokosc() && plansza.co_to( lazik.zwroc_x()+1,lazik.zwroc_y() )==5 ) {
                      cout<<"Na prawo jest kamień. Nie mogę tamtędy dalej pójść.\n";
                      break;
                  } else if (lazik.prawo()) { if ( !liczba ) cout<<"Wykonane.\n"; }
                  else {
                      cout<<"Nie mogę tam pójść.\n";
                      break;
                  }
              }
              break;

            case 3:
              liczba = LiczbaWStringu(a);
              while (liczba--) {
                  if ( lazik.zwroc_y()-1>=0 && plansza.co_to( lazik.zwroc_x(),lazik.zwroc_y()-1 )==5 ) {
                      cout<<"Z przodu jest kamień. Nie mogę tamtędy dalej pójść.\n";
                      break;
                  } else if (lazik.gora()) { if ( !liczba ) cout<<"Wykonane.\n"; }
                  else {
                      cout<<"Nie mogę tam pójść.\n";
                      break;
                  }
              }
              break;

            case 4:
              liczba = LiczbaWStringu(a);
              while (liczba--) {
                  if ( lazik.zwroc_y()+1<plansza.jaka_dlugosc() && plansza.co_to( lazik.zwroc_x(),lazik.zwroc_y()+1 )==5 ) {
                      cout<<"Z tyłu jest kamień. Nie mogę tamtędy dalej pójść.\n";
                      break;
                  } else if (lazik.dol()) { if ( !liczba ) cout<<"Wykonane.\n"; }
                  else {
                      cout<<"Nie mogę tam pójść.\n";
                      break;
                  }
              }
              break;

            case 5:
              if ( plansza.co_to( lazik.zwroc_x(),lazik.zwroc_y() ) == 6 ) {
                  if ( lazik.wez_flage() ) {
                      plansza.usun_flage(lazik.zwroc_x(),lazik.zwroc_y());
                      cout<<"Wziąłem flagę.\n";
                  } else cout<<"Mam już jedną flagę. Nie potrafię transportować ich więcej.\n";
              } else cout<<"Tu nie ma flagi. Nie mogę jej wziąć.\n";
              break;

            case 6:
              polozFlage(lazik.zwroc_x(), lazik.zwroc_y(), plansza, lazik);
              break;
            case 7:
                {

                int t = plansza.co_to( lazik.zwroc_x(),lazik.zwroc_y());
                switch (t) {
                    case 0:
                      cout<<"Tu nie ma żadnego minerału\n";
                      break;
                    case 1:
                      if ( lazik.zwieksz_min1() ) {
                            al_clear_to_color(al_map_rgb( 220, 100, 60));
                            al_draw_textf(font8, al_map_rgb(100,220,100), 20, 10, 0,"Minerał1: %3d", lazik.zwroc_min1() );
                            al_draw_textf(font8, al_map_rgb(255,255,0), 20, 30, 0,"Minerał2: %3d", lazik.zwroc_min2() );
                            al_draw_textf(font8, al_map_rgb(255,150,150), 20, 50, 0,"Minerał3: %3d", lazik.zwroc_min3() );
                            al_draw_textf(font8, al_map_rgb(50,50,250), 20, 70, 0,"Minerał4: %3d", lazik.zwroc_min4() );
                            cout<<"Teraz masz też próbkę minerału 1\n";
                      }
                      else cout<<"Już masz 3 próbki tego minerału\n";
                      break;
                    case 2:
                      if ( lazik.zwieksz_min2() ) {
                            al_clear_to_color(al_map_rgb( 220, 100, 60));
                            al_draw_textf(font8, al_map_rgb(100,220,100), 20, 10, 0,"Minerał1: %3d", lazik.zwroc_min1() );
                            al_draw_textf(font8, al_map_rgb(255,255,0), 20, 30, 0,"Minerał2: %3d", lazik.zwroc_min2() );
                            al_draw_textf(font8, al_map_rgb(255,150,150), 20, 50, 0,"Minerał3: %3d", lazik.zwroc_min3() );
                            al_draw_textf(font8, al_map_rgb(50,50,250), 20, 70, 0,"Minerał4: %3d", lazik.zwroc_min4() );
                            cout<<"Teraz masz też próbkę minerału 2\n";
                      } else cout<<"Już masz 3 próbki tego minerału\n";
                      break;
                    case 3:
                      if ( lazik.zwieksz_min3() ) {
                            al_clear_to_color(al_map_rgb( 220, 100, 60));
                            al_draw_textf(font8, al_map_rgb(100,220,100), 20, 10, 0,"Minerał1: %3d", lazik.zwroc_min1() );
                            al_draw_textf(font8, al_map_rgb(255,255,0), 20, 30, 0,"Minerał2: %3d", lazik.zwroc_min2() );
                            al_draw_textf(font8, al_map_rgb(255,150,150), 20, 50, 0,"Minerał3: %3d", lazik.zwroc_min3() );
                            al_draw_textf(font8, al_map_rgb(50,50,250), 20, 70, 0,"Minerał4: %3d", lazik.zwroc_min4() );
                            cout<<"Teraz masz też próbkę minerału 3\n";
                        }
                      else cout<<"Już masz 3 próbki tego minerału\n";
                      break;
                    case 4:
                      if ( lazik.zwieksz_min4() ) {
                            al_clear_to_color(al_map_rgb( 220, 100, 60));
                            al_draw_textf(font8, al_map_rgb(100,220,100), 20, 10, 0,"Minerał1: %3d", lazik.zwroc_min1() );
                            al_draw_textf(font8, al_map_rgb(255,255,0), 20, 30, 0,"Minerał2: %3d", lazik.zwroc_min2() );
                            al_draw_textf(font8, al_map_rgb(255,150,150), 20, 50, 0,"Minerał3: %3d", lazik.zwroc_min3() );
                            al_draw_textf(font8, al_map_rgb(50,50,250), 20, 70, 0,"Minerał4: %3d", lazik.zwroc_min4() );
                            cout << "Teraz masz też próbkę minerału 4\n";
                      }
                      else cout << "Już masz 3 próbki tego minerału\n";
                      break;
                  }
            }
              break;

            case 8:
              u = lazik.zwroc_min1() + lazik.zwroc_min2() + lazik.zwroc_min3() + lazik.zwroc_min4();
              f = 0;
              switch (u) {
                  case 0:
                    cout<<"Nie mam żadnego minerału\n";
                    break;
                  case 4:
                    cout<<"Mam wszystkie minerały.\n";
                    break;
                  default:
                    cout<<"Mam minerał ";
                    if ( lazik.zwroc_min1() ) {
                        cout<<"1";
                        f=1;
                    }
                    if ( lazik.zwroc_min2() ) {
                        if (f) cout<<" i 2";
                        else cout<<"2";
                        f=1;
                    }
                    if ( lazik.zwroc_min3() ) {
                        if (f) cout<<" i 3";
                        else cout<<"3";
                        f=1;
                    }
                    if ( lazik.zwroc_min4() ) {
                        if (f) cout<<" i 4";
                        else cout<<"4";
                    }
                    cout<<".\n";
              }

              break;
            case 9 : {
                int t = LiczbaWStringu(a);
                if (czyFlaga(lazik)) {
                    polozFlage(lazik.zwroc_x(), lazik.zwroc_y() - t, plansza, lazik);
                }
                }
                break;

            case 10 : {
                int t = LiczbaWStringu(a);
                if (czyFlaga(lazik)) {
                    polozFlage(lazik.zwroc_x(), lazik.zwroc_y() + t, plansza, lazik);
                }
                }
                break;
            case 11 : {
                int t = LiczbaWStringu(a);
                if (czyFlaga(lazik)) {
                    polozFlage(lazik.zwroc_x()-t, lazik.zwroc_y(), plansza, lazik);
                }
                }
                break;

            case 12 : {
                int t = LiczbaWStringu(a);
                if (czyFlaga(lazik)) {
                    polozFlage(lazik.zwroc_x()+t, lazik.zwroc_y(), plansza, lazik);
                }
                }
                break;

            case 13 : {
                lazik.zeruj();
                al_clear_to_color(al_map_rgb( 220, 100, 60));
                al_draw_textf(font8, al_map_rgb(100,220,100), 20, 10, 0,"Minerał1: %3d", lazik.zwroc_min1() );
                al_draw_textf(font8, al_map_rgb(255,255,0), 20, 30, 0,"Minerał2: %3d", lazik.zwroc_min2() );
                al_draw_textf(font8, al_map_rgb(255,150,150), 20, 50, 0,"Minerał3: %3d", lazik.zwroc_min3() );
                al_draw_textf(font8, al_map_rgb(50,50,250), 20, 70, 0,"Minerał4: %3d", lazik.zwroc_min4() );
                cout << "plecak opróżniony";
                break;
            }

            case 14 : {
                bool b = false;
                int x;
                int y;

                if (plansza.co_to(lazik.zwroc_x()+1, lazik.zwroc_y()) == 5) {
                        b = true;
                        x = lazik.zwroc_x()+1;
                        y = lazik.zwroc_y();
                }

                if (plansza.co_to(lazik.zwroc_x()-1, lazik.zwroc_y()) == 5) {
                        b = true;
                        x = lazik.zwroc_x()-1;
                        y = lazik.zwroc_y();
                }
                if (plansza.co_to(lazik.zwroc_x(), lazik.zwroc_y()+1) == 5) {
                        b = true;
                        x = lazik.zwroc_x();
                        y = lazik.zwroc_y()+1;
                }
                if (plansza.co_to(lazik.zwroc_x(), lazik.zwroc_y()-1) == 5) {
                        b = true;
                        x = lazik.zwroc_x();
                        y = lazik.zwroc_y()-1;

                }
                if (b) plansza.tab[x][y].stan = 0;
                break;
            }

            case 15 :
                if (((lazik.zwroc_x() == 7) && (lazik.zwroc_y() == 1)) || ((lazik.zwroc_x() == 1) && (lazik.zwroc_y() == 2))) {
                   u = lazik.zwroc_min1() + lazik.zwroc_min2() + lazik.zwroc_min3() + lazik.zwroc_min4();
                      f = 0;
                      switch (u) {
                          case 0:
                            cout<<"Nie mam żadnego minerału\n";
                            break;
                          case 4:
                            cout<<"Mam wszystkie minerały.\n";
                            break;
                          default:
                            cout<<"Mam minerał ";
                            if ( lazik.zwroc_min1() ) {
                                cout<<"Halit ";
                                f=1;
                            }
                            if ( lazik.zwroc_min2() ) {
                                if (f) cout<<" i Fluoryt";
                                else cout<<"Fluoryt";
                               f=1;
                            }
                            if ( lazik.zwroc_min3() ) {
                                if (f) cout<<" i Spinel";
                                else cout<<"Spinel";
                                f=1;
                            }
                            if ( lazik.zwroc_min4() ) {
                                if (f) cout<<" i Topaz";
                                else cout<<"Topaz";
                            }
                            cout<<".\n";
                        }
                    }else{
                        cout<<"Nie rozumiem.\n";
                    }
            break;




           default:
                cout<<"Nie rozumiem.\n";
           break;
        }
    }
    return 0;
}
