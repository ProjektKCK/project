using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WMPLib;
using System.Runtime.InteropServices;

namespace Ekran
{
    public partial class Form1 : Form
    {
        private PictureBox[,] pictureBox; //Definowanie tabeli obrazów
        string zap,informacje;
        string[] zapytania;
        bool bossak = false, gra = false,skarpoz=false,tutorial,msg=false,potek=false,zap1=false;
        bool skarb = false, looted = false, lt = false, En = false, pozwyb = false, iquest=false;
        int i,j;
        int trapdmg = 5;
        int lvl = 1, exp = 0, gold = 0, dmg = 0, bron=0, gpot = 0, rpot = 0;
        int Hhpmax = 20,Hhp;
        int bhp=5,bdmg=0;
        int co,poziom,xskar,yskar,xmax,ymax;
        int[,] tut;
        string listter = System.IO.File.ReadAllText(@"Res\list.txt", Encoding.GetEncoding("Windows-1250"));
        string intro = System.IO.File.ReadAllText(@"Res\intro.txt", Encoding.GetEncoding("Windows-1250"));
        string pomoc = System.IO.File.ReadAllText(@"Res\pomoc.txt", Encoding.GetEncoding("Windows-1250"));
        /////////PLANSZE
        ////Poziom 0 aka tutorial/prolog
        public int[,] poziom0 = 
        {
             {1,  1,  1,  1,  1},
             {1,  10,  2,  4,  1},
             {1,  2,  2,  6,  9},
             {1,  2,  3,  2,  1},
             {1,  1,  1,  1,  1}
        };
        ////Poziom 1
        int[,] poziom1 =
        {
        {1,  1,  1,  1,  1,  1,  9,  1,  1,  1},
        {1,  11,  2,  2,  1,  2,  6,  2,  2,  1},
        {1,  2,  2,  2,  1,  5,  2,  2,  2,  1},
        {1,  2,  2,  3,  1,  2,  2,  2,  2,  1},
        {1,  1,  1,  2,  1,  5,  1,  1,  1,  1},
        {1,  10, 2,  2,  2,  7,  2,  2,  4,  1},
        {1,  1,  1,  1,  5,  1,  1,  1,  1,  1},
        {1,  2,  2,  2,  2,  1,  2,  2,  7,  1},
        {1,  2,  2,  2,  2,  2,  2,  2,  8,  1},
        {1,  1,  1,  1,  1,  1,  1,  1,  1,  1}
        };
        ////Poziom 2
        int[,] poziom2 =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,2,2,2,2,2,1,1},
            {1,1,2,2,1,1,1,2,1,1},
            {1,7,2,1,1,1,1,2,11,1},
            {1,1,2,1,1,5,1,1,1,1},
            {1,1,2,1,1,2,1,1,1,1},
            {1,2,2,2,2,2,2,2,1,1},
            {1,2,1,1,2,1,1,2,6,9},
            {1,5,1,1,10,1,2,2,1,1},
            {1,1,1,1,1,1,1,1,1,1}
        };
        ////Poziom 3
        int[,] poziom3 =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,11,1,1,1,1,1,1,1,1},
            {1,2,2,2,2,2,1,2,6,9},
            {1,1,1,2,1,2,1,2,1,1},
            {1,1,1,2,1,2,2,2,1,1},
            {1,2,2,2,1,1,1,2,4,1},
            {1,2,1,2,1,1,1,1,1,1},
            {1,10,1,2,2,2,5,2,8,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
        };
        ////Poziom 4
        int[,] poziom4 =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,2,2,2,1,1,2,2,3,1},
            {1,10,1,2,2,2,2,1,1,1},
            {1,1,1,2,1,1,2,2,11,1},
            {1,7,2,2,1,1,2,1,1,1},
            {1,1,1,1,1,1,2,2,2,1},
            {1,2,2,2,5,1,1,1,2,1},
            {1,2,1,2,1,1,1,1,2,1},
            {1,6,1,2,2,2,2,2,2,1},
            {1,9,1,1,1,1,1,1,1,1},
        };
        ////Poziom 5
        int[,] poziom5 =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,10,1,1,1,1,7,1,1,1},
            {1,2,2,2,5,1,2,7,1,1},
            {1,1,1,2,1,1,5,1,1,1},
            {1,1,1,2,1,2,2,2,2,1},
            {1,1,1,2,1,2,1,1,2,1},
            {1,5,2,2,2,2,1,1,2,1},
            {1,1,1,1,2,1,1,1,6,9},
            {1,1,1,1,11,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
        };
        ////Poziom 6
        int[,] poziom6=
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,2,2,2,2,2,2,1},
            {9,6,2,2,1,1,1,1,2,1},
            {1,1,1,1,1,1,2,5,2,1},
            {1,1,4,1,2,2,2,1,1,1},
            {1,2,2,2,2,1,1,1,7,1},
            {1,2,1,2,1,1,7,1,2,1},
            {1,10,1,2,5,2,2,5,2,1},
            {1,1,1,1,1,1,11,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
        };
        ////Poziom 7
        int[,] poziom7=
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,11,1,1,7,1,1,1,1,1},
            {1,2,1,1,2,1,1,1,10,1},
            {1,2,2,5,2,2,2,1,2,1},
            {1,2,1,1,1,1,2,2,2,1},
            {1,2,1,1,1,1,1,1,1,1},
            {1,2,2,2,2,2,1,2,8,1},
            {1,2,1,1,1,2,1,5,1,1},
            {1,2,2,6,1,2,2,2,1,1},
            {1,1,1,9,1,1,1,1,1,1},
        };
        ////Poziom 8
        int[,] poziom8 =
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,10,1,1,1,8,2,1},
            {1,1,1,2,4,1,1,1,5,1},
            {1,1,2,2,1,1,5,2,2,1},
            {1,1,2,1,1,1,2,1,1,1},
            {1,1,2,1,1,1,2,1,1,1},
            {1,11,2,2,2,2,2,1,1,1},
            {1,1,2,1,1,1,2,5,6,9},
            {1,1,5,2,7,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
        };
        ////Poziom 9
        int[,] poziom9=
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,7,2,1,1,1,2,2,2,1},
            {1,1,5,1,1,1,5,1,5,1},
            {1,1,2,1,1,1,2,1,2,1},
            {1,1,2,1,2,2,2,1,2,1},
            {1,1,2,2,2,1,2,1,8,1},
            {1,1,2,1,1,1,2,1,1,1},
            {1,10,2,1,1,1,2,2,11,1},
            {1,1,1,1,1,1,6,1,1,1},
            {1,1,1,1,1,1,9,1,1,1},
        };
        ////Poziom 10
        int[,] poziom10=
        {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,11,1,1,10,1,8,1},
            {1,1,1,2,1,2,2,1,2,1},
            {1,4,2,2,2,2,1,1,5,1},
            {1,1,2,1,1,1,1,1,2,1},
            {1,1,2,2,2,2,2,5,2,1},
            {1,1,2,1,2,1,1,1,7,1},
            {1,1,2,1,2,2,2,2,1,1},
            {1,1,5,1,1,1,1,6,1,1},
            {1,1,1,1,1,1,1,9,1,1},
        };
        public string odpo(int k)
        {
            switch (k)
            {
                case 0: return "System: Nic nie zrobisz gołymi rękoma.\r\n";
                case 1: return "System: Nie mogę tego zrobić.\r\n";
                case 2: return "System: Idziesz w ";
                case 3: return "System: Słyszysz jakiś mechanizm.\r\n";
                case 4: return "System: Nie masz z kim rozmawiać.\r\n";
                case 5: return "System: Nie ma w okolicy żadnej skrzyni.\r\n";
                case 6: return "System: Nie posiadasz aktualnie rzadnego listu.\r\n";
                case 7: return "System: Aktywowałeś pułapkę.\r\n";
                case 8: return "System: Nie masz z kim handlować.\r\n";
                default: return "System: Błąd polecenia.\r\n";
            }
        }
        private void NowyPoz()
        {
            poziom++;
            skarb = false;
            exp += 20;
            co = 2;
            skarpoz = false;
            pozwyb = false;
            sweep();
            rysuj();
            tutorial = false;
            bhp = 5 + (15 * poziom);
            bdmg = 0 + (5 * poziom);
            iquest = false;
        }
        private void wybor()
        {
            switch (poziom)
            {
                case 0: { tut = poziom0; tutorial = true; break; }
                case 1: { tut = poziom1; break; }
                case 2: { tut = poziom2; break; }
                case 3: { tut = poziom3; break; }
                case 4: { tut = poziom4; break; }
                case 5: { tut = poziom5; break; }
                case 6: { tut = poziom6; break; }
                case 7: { tut = poziom7; break; }
                case 8: { tut = poziom8; break; }
                case 9: { tut = poziom9; break; }
                case 10: { tut = poziom10; break; }
                default: {textBox2.Text = "Koniec";break; }
            }
            // Dopasowanie tabeli obrazów do wielkości planszy
            if (tut != null)
            {
                pictureBox = new PictureBox[tut.GetLength(0), tut.GetLength(1)];
            }
        }
        public void rysuj()
        {
            if (gra == true)
            {
                if (pozwyb == false)
                {
                    wybor();
                    pozwyb = true;
                }
                PotR.Image = System.Drawing.Image.FromFile("Res/wep/2.png");
                PotG.Image = System.Drawing.Image.FromFile("Res/wep/1.png");
                for (int y = 0; y < tut.GetLength(0); y++)
                {
                    for (int x = 0; x < tut.GetLength(1); x++)
                    {
                        if (pictureBox[x, y] == null)
                        {
                            pictureBox[x, y] = new PictureBox();
                            pictureBox[x, y].Left = 12 + (y * 36);
                            pictureBox[x, y].Top = 12 + (x * 36);
                            pictureBox[x, y].Width = 32;
                            pictureBox[x, y].Height = 32;
                            pictureBox[x, y].BackColor = Color.Gray;
                            this.Controls.Add(pictureBox[x, y]);
                        }
                        switch (tut[x, y])
                        {
                            case 1:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/1.png");
                                continue;
                            case 2:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/2.png");
                                continue;
                            case 3:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/3.png");
                                continue;
                            case 4:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/4.png");
                                continue;
                            case 5:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/5.png");
                                continue;
                            case 6:
                                if (tutorial == true) pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/6t.png");
                                else pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/6.png");
                                continue;
                            case 7:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/7.png");
                                continue;
                            case 8:
                                xskar = x;
                                yskar = y;
                                if (skarb == true) pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/8.png");
                                else pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/2.png");
                                continue;
                            case 9:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/9.png");
                                continue;
                            case 10:
                                j = x;
                                i = y;
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/10.png");
                                continue;
                            case 11:
                                pictureBox[x, y].Image = System.Drawing.Image.FromFile("Res/11.png");
                                continue;
                        }
                    }
                }
            }
        }
        public void sweep()
        {
            for (int y = 0; y < tut.GetLength(0); y++)
            {
                for (int x = 0; x < tut.GetLength(1); x++)
                {
                    pictureBox[x, y].Image = null;
                    pictureBox[x, y].Dispose();
                    this.Controls.Add(pictureBox[x, y]);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            rysuj();
            textBox2.Text = intro;
        }
        public void boss()
        {
            textBox2.Text += "System: Atakujesz przeciwnika za: " + dmg + " pkt obrażeń\r\n";
            bhp = bhp - dmg;
            if (bhp <= 0)
            {
                exp = exp + 40;
                gold = gold + 20 + (20 * poziom);
                if (poziom == 0) tut[2, 3] = 2;
                if (poziom == 1) tut[1, 6] = 2;
                if (poziom == 2) tut[7, 8] = 2;
                if (poziom == 3) tut[2, 8] = 2;
                if (poziom == 4) tut[8, 1] = 2;
                if (poziom == 5) tut[7, 8] = 2;
                rysuj();
            }
            else
            {
                if (bdmg >= 1)
                {
                    textBox2.Text += "System: Otrzymujesz " + bdmg + " pkt obrażeń";
                    Hhp = Hhp - bdmg;
                }
            }
        }
        public void Skarby()
        {
            if (tutorial == true)
            {
                tut[2, 2] = 8;
            }
            co = 2;
            if(skarb==false)textBox2.Text += odpo(3);
            skarb = true;
        }
        public void Rozmowa()
        {

            if (tutorial == true)
            {
                textBox2.Text += "";
                textBox2.Text += "Umierający mężczyzna: ..ughh..\r\n";
                textBox2.Text += "System: Mężczyzna umarł...\r\n";
                textBox2.Text += "System: Znajdujesz przy nim 25g\r\n";
                gold += 25;
                tut[1, 3] = 2;
                rysuj();
            }
            else
            {
                if(iquest == true)
                {
                    textBox2.Text +="Nieznajomy: Widzę że udało ci się znaleźć mój skarb. Pozwól że ci pomogę.\r\n";
                    textBox2.Text +="System: Nieznajomy zabiera ci z ręki jego skarb i wręcza ci 20g.\r\n";
                    textBox2.Text +="System: Spojrzałeś się na monety, po czym zauważyłeś że mężczyzna znikł.\r\n";
                    if (tut[j, i + 1] == 4) tut[j, i + 1] = 2;
                    if (tut[j, i - 1] == 4) tut[j, i - 1] = 2;
                    if (tut[j + 1, i] == 4) tut[j + 1, i] = 2;
                    if (tut[j - 1, i] == 4) tut[j - 1, i] = 2;
                    rysuj();
                }
                if(iquest == false && zap1==true) textBox2.Text +="Nieznajomy: Wiedze że jeszcze nie znalazłeś mojego skarbu.\r\n";
                if(iquest == false && zap1==false)
                {
                    textBox2.Text +="Nieznajomy: Witaj. Nie widziałeś przypadkiem mojego skarbu? Jeśli go znajdziesz przyjdź do mnie wynagrodze cię za to.\r\n";
                    zap1=true;
                }
            }
        }
        public void loot()
        {
            if (tutorial == true)
            {
                if (looted == false)
                {
                    textBox2.Text += "System: Otworzyłeś skrzynie\r\n";
                    textBox2.Text += "System: Do skrzyni był przyczepiony list \r\n";
                    lt = true;
                    textBox2.Text += "System: Włożyłeś go do kieszeni, możesz go zawsze przeczytać pisząc komendę 'list'\r\n";
                    textBox2.Text += "System: Dodatkowo znalazłeś: pochodnia (+5 obrażeń) oraz 20g\r\n";
                    dmg += 5;
                    gold += 20;

                    HOff.Image = System.Drawing.Image.FromFile("Res/wep/0.png");
                    HandOff.Text = "Pochodnia";
                    looted = true;
                    exp += 10;
                    tut[2, 2] = 2;
                    rysuj();
                }
            }
            else
            {
                textBox2.Text += "System: Znajdujesz 15g oraz 2 mikstury.\r\n";
                gold += 15;
                rpot++;
                gpot++;
                if (tut[j, i + 1] == 8) tut[j, i + 1] = 2;
                if (tut[j, i - 1] == 8) tut[j, i - 1] = 2;
                if (tut[j + 1, i] == 8) tut[j + 1, i] = 2;
                if (tut[j - 1, i] == 8) tut[j - 1, i] = 2;
                rysuj();
            }

        }
        public void trap()
        {
            textBox2.Text += odpo(7);
            co = 2;
            textBox2.Text += "System: Otrzymujesz " + trapdmg + " pkt obrarzeń.\r\n";
            Hhp = Hhp - trapdmg;
            hapeki.Value = Hhp;
            textBox3.Text = "Życie " + Hhp + "/" + Hhpmax;
        }
        public void Kup(string banan)
        {
            if (banan == "?")
            {
                textBox2.Text += "1. Zielona mikstura - 15g.\r\n";
                textBox2.Text += "2. Czerwona mikstura -35g.\r\n";
                textBox2.Text += "3. Lepsza broń - 50g.\r\n";
            }
            if (banan == "1")
            {
                if (gold >= 15)
                {
                    gpot++;
                    textBox2.Text += "Kupiec: Prosze.\r\n";
                    gold -= 15;
                }
            }
            if (banan == "2")
            {
                if (gold >= 30)
                {
                    rpot++;
                    textBox2.Text += "Kupiec: Prosze.\r\n";
                    gold -= 15;
                }
            }
            if (banan == "3")
            {
                if (gold >= 50)
                {
                    textBox2.Text += "Kupiec: Oto twoja nowa broń.\r\n";
                    bron++;
                    bronie();
                }
            }
            if (banan == null) 
            {
                textBox2.Text += "Kupiec: Witaj, czym mogę służyć?\r\n";
                textBox2.Text += "System: Aby wyświetlić pzedmioty kupca wpisz kup *\r\n";
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gra == true)
            {
                if (e.KeyCode == Keys.Down)
                {
                    if ((tut[j + 1, i] == 1) || (tut[j + 1, i] == 4) || (tut[j + 1, i] == 6) || (tut[j + 1, i] == 8) || (tut[j + 1, i] == 11)) textBox2.Text += odpo(1);
                    else
                    {
                        tut[j, i] = co;
                        j++;
                        co = tut[j, i];
                        tut[j, i] = 10;
                        textBox2.Text += odpo(2) + "dół. \r\n";
                        if (co == 3 && skarb == false) Skarby();
                        if (co == 9) NowyPoz();
                        if (co == 5) trap();
                        rysuj();
                    }
                    textBox2.SelectionStart = textBox2.Text.Length;
                    textBox2.ScrollToCaret();
                }
                if (e.KeyCode == Keys.Up)
                {
                    if ((tut[j - 1, i] == 1) || (tut[j - 1, i] == 4) || (tut[j - 1, i] == 6) || (tut[j - 1, i] == 8) || (tut[j - 1, i] == 11)) textBox2.Text += odpo(1);
                    else
                    {
                        tut[j, i] = co;
                        j--;
                        co = tut[j, i];
                        tut[j, i] = 10;
                        textBox2.Text += odpo(2) + "górę. \r\n";
                        if (co == 3 && skarb == false) Skarby();
                        if (co == 9) NowyPoz();
                        if (co == 5) trap();
                        rysuj();
                    }
                    textBox2.SelectionStart = textBox2.Text.Length;
                    textBox2.ScrollToCaret();
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if ((tut[j, i - 1] == 1) || (tut[j, i - 1] == 4) || (tut[j, i - 1] == 6) || (tut[j, i - 1] == 8) || (tut[j, i - 1] == 11)) textBox2.Text += odpo(1);
                else
                {
                    tut[j, i] = co;
                    i--;
                    co = tut[j, i];
                    tut[j, i] = 10;
                    textBox2.Text += odpo(2) + "lewo. \r\n";
                    if (co == 3 && skarb == false) Skarby();
                    if (co == 9) NowyPoz();
                    if (co == 5) trap();
                    rysuj();
                }
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.ScrollToCaret();
            }
            if (e.KeyCode == Keys.Right)
            {
                if ((tut[j, i + 1] == 1) || (tut[j, i + 1] == 4) || (tut[j, i + 1] == 6) || (tut[j, i + 1] == 8) || (tut[j, i + 1] == 11)) textBox2.Text += odpo(1);
                else
                {
                    tut[j, i] = co;
                    i++;
                    co = tut[j, i];
                    tut[j, i] = 10;
                    textBox2.Text += odpo(2) + "prawo. \r\n";
                    if (co == 3 && skarb == false) Skarby();
                    if (co == 9) NowyPoz();
                    if (co == 5) trap();
                    rysuj();
                }
                textBox2.SelectionStart = textBox2.Text.Length;
                textBox2.ScrollToCaret();
            }
            if (e.KeyCode == Keys.Enter)
            {
                En = true;
                zap = textBox1.Text;
                zap = zap.ToLower();
                string[] zapytania = zap.Split();
                textBox2.Text += "Gracz: " + textBox1.Text + "\r\n";
                textBox1.Text = "";
                e.Handled = true;
                e.SuppressKeyPress = true;
                if (zapytania[0] == "rozmowa")
                {
                    // NPC Check
                    if ((tut[j, i + 1] == 4) || (tut[j, i - 1] == 4) || (tut[j + 1, i] == 4) || (tut[j - 1, i] == 4)) Rozmowa();
                    else textBox2.Text += odpo(4);
                    msg = true;
                }
                if (zapytania[0] == "kup")
                {
                    if ((tut[j, i + 1] == 11) || (tut[j, i - 1] == 11) || (tut[j + 1, i] == 11) || (tut[j - 1, i] == 11)) Kup(zapytania[1]);
                    else textBox2.Text += odpo(8);
                    msg = true;
                }
                if (zapytania[0] == "czyść" || zapytania[0] == "czysc") { textBox2.Text = ""; msg = true; }
                if (zapytania[0] == "info")
                {
                    informacje = "Imie: Xin Poziom: " + lvl + " Doświadczenie: " + exp + " Złoto: " + gold + "\r\n";
                    textBox2.Text += informacje;
                    msg = true;
                }
                if (zapytania[0] == "atak" || zapytania[0] == "atakuj")
                {
                    if ((tut[j, i + 1] == 6) || (tut[j, i - 1] == 6) || (tut[j + 1, i] == 6) || (tut[j - 1, i] == 6)) boss();
                    else textBox2.Text += "System: Nie ma zadnego przeciwnika w okolicy\r\n";
                    msg = true;
                }
                if (zapytania[0] == "otwórz" || zapytania[0] == "otworz")
                {
                    if ((tut[j, i + 1] == 8) || (tut[j, i - 1] == 8) || (tut[j + 1, i] == 8) || (tut[j - 1, i] == 8)) loot();
                    else textBox2.Text += odpo(5);
                    msg = true;
                }
                if (zapytania[0] == "podnieś"|| zapytania[0] =="podnies")
                {
                    if (co == 7 && iquest == false)
                    {
                        iquest = true;
                        textBox2.Text += "System: Znalazłeś dziwny przedmiot, może ktoś go szuka?";
                        co = 2;
                    }
                    if (co == 7 && iquest == true) rpot++; Potred.Text = "" + rpot;
                    msg = true;
                }
                if (zapytania[0] == "użyj" || zapytania[0] == "uzyj")
                {
                    if (zapytania[1] == "1")
                    {
                        if (rpot > 0)
                        {
                            rpot--;
                            Hhp += 30;
                            if (Hhp > Hhpmax)
                            {
                                textBox2.Text += "System: Odnowiłeś " + (30 - (Hhp - Hhpmax)) + " pkt życia.\r\n";
                                Hhp = Hhpmax;
                            }
                            else textBox2.Text += "System: Odnowiłeś 30 pkt życia.\r\n";
                        }
                        else textBox2.Text += "System: Nieposiadasz czerwonych miksur.\r\n";
                        potek = true;
                    }
                    if (zapytania[1] == "2")
                    {
                        if (gpot > 0)
                        {
                            gpot--;
                            Hhp += 15;
                            if (Hhp > Hhpmax)
                            {
                                textBox2.Text += "System: Odnowiłeś " + (15 - (Hhp - Hhpmax)) + " pkt życia.\r\n";
                                Hhp = Hhpmax;
                            }
                            else textBox2.Text += "System: Odnowiłeś 15 pkt życia.\r\n";
                        }
                        else textBox2.Text += "System: Nieposiadasz zielonych miksur.\r\n";
                        potek = true;
                    }
                    if (potek == false) textBox2.Text += odpo(10);
                    msg = true;
                }
                if (zapytania[0] == "pomoc")
                {
                    textBox2.Text = "";
                    textBox2.Text += pomoc;
                    msg = true;
                }
                if (zapytania[0] == "list")
                {
                    if (lt == true)
                    {
                        textBox2.Text += listter;
                    }
                    else textBox2.Text += odpo(6);
                    msg = true;
                }
                if (En == true)
                {
                    textBox2.SelectionStart = textBox2.Text.Length;
                    textBox2.ScrollToCaret();
                }
                if (exp >= 100)
                {
                    exp = exp - 100;
                    lvl++;
                    dmg += 2;
                    textBox2.Text += "System: Gratulacje! Awansowałeś na " + lvl + " poziom. \r\n";
                    Hhpmax = Hhpmax + 10;
                    Hhp = Hhpmax;
                }
                textBox3.Text = "Życie " + Hhp + "/" + Hhpmax;
                hapeki.Maximum = Hhpmax;
                hapeki.Value = Hhp;
                kasa.Text = "Pieniądze: " + gold + "g";
                textBox4.Text = "Exp " + exp + "/100";
                expy.Value=exp;
                if (msg == false) textBox2.Text += odpo(15);
                msg = false;
                Potred.Text = "" + rpot;
                Potgreen.Text = "" + gpot;
                if (Hhp <= 0) koniec();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Startbutt_Click(object sender, EventArgs e)
        {
            Application.EnableVisualStyles();
            textBox1.Focus();
            co = 2;
            poziom = 0;
            gra=true;
            rysuj();
            textBox1.Text = textBox2.Text = "";
            hapeki.Visible = expy.Visible = true;
            PotR.Visible = PotG.Visible = true;
            HMain.Visible = HOff.Visible = true;
            HandMain.Visible = HandOff.Visible = true;
            OffH.Visible = MainH.Visible = kasa.Visible = Potgreen.Visible = Potred.Visible = true;
            hapeki.ForeColor = Color.Red;
            hapeki.Maximum = Hhpmax;
            Hhp = Hhpmax;
            hapeki.Value = Hhp;
            MainH.Text = "Prawa ręka";
            OffH.Text = " Lewa ręka";
            textBox3.Text = "Życie " + Hhp + "/" + Hhpmax;
            textBox4.Text = "Exp " + exp + "/100";
            HandMain.Text = HandOff.Text = "Nic";
            kasa.Text = "Pieniądze: " + gold + "g";
            Potred.Text = ""+rpot;
            Potgreen.Text = ""+gpot;
        }
        public void bronie()
        {
            HMain.Image = null;
            if (bron == 1)
            {
                dmg += 10;
                HandMain.Text = "Drewniany miecz";
                HMain.Image = System.Drawing.Image.FromFile("Res/wep/3.png");
            }
            if (bron == 2)
            {
                dmg += 10;
                HandMain.Text = "Tępy miecz";
                HMain.Image = System.Drawing.Image.FromFile("Res/wep/4.png");
            }
            if (bron == 3)
            {
                dmg += 10;
                HandMain.Text = "Naostrzony miecz";
                HMain.Image = System.Drawing.Image.FromFile("Res/wep/5.png");
            }
            if (bron == 4)
            {
                dmg += 10;
                HandMain.Text = "Szlachetny miecz";
                HMain.Image = System.Drawing.Image.FromFile("Res/wep/6.png");
            }
            if (bron == 5)
            {
                dmg += 10;
                HandMain.Text = "Krasnoludzki Topór";
                HMain.Image = System.Drawing.Image.FromFile("Res/wep/7.png");
            }
        }
        public void koniec()
        {
            System.Threading.Thread.Sleep(100);
            textBox2.Text += "System: Przeciwnik zadał ci śmiertelny cios";
            textBox2.Text = "Dziękujemy za grę. Mamy nadzieję, że podobała się ona tobie. Był to nasz 1 projekt grupowy";
            System.Threading.Thread.Sleep(5000);
            this.Close();
        }
    }
}
