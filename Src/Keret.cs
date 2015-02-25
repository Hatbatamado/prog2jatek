using System;
using OE.Prog2.Jatek.Jatekter;
using OE.Prog2.Jatek.Szabalyok;
using OE.Prog2.Jatek.Megjelenites;
using OE.Prog2.Jatek.Automatizmus;

namespace OE.Prog2.Jatek.Keret
{
    class Keret
    {
        private const int PALYA_MERET_X = 21; //a pálya maximális mérete x irányba (21)
        private const int PALYA_MERET_Y = 11; //a pálya maximális mérete y irányba (11)
        private const int KINCSEK_SZAMA = 10; //a pályán lévő kincsek száma (10)
        private JatekTer ter; //pályatér 
        private Random R = new Random(); //véletlen szám kincsekhez
        private JatekElem[] segedelem; //segéd tömb, különböző véletlen kincs pozíciókhoz
        private bool jatekVege = false; //csak akkor lesz igaz, ha vége a játéknak
        private OrajelGenerator generator;
        private int megtalaltKincsek = 0; //ez fogja számolni, hogy hány kincset vettek már fel

        private void PalyaGeneralas()
        {
            for (int i = 0; i < PALYA_MERET_X; i++) //vízszintes falak
            {
                new Fal(i, 0, ref ter);
                new Fal(i, PALYA_MERET_Y, ref ter);
            }
            
            for (int i = 0; i < PALYA_MERET_Y; i++) //függőleges falak
            {
                new Fal(0, i, ref ter);
                new Fal(PALYA_MERET_X, i, ref ter);
            }

            new Fal(PALYA_MERET_X, PALYA_MERET_Y, ref ter); //kimaradt kocka rajzoláshoz

            //Véletlenszerűen szórjon szét KINCSEK_SZAMA darab kincset a pályán belül, ügyelve arra,
            //hogy egy helyre nem fér el egynél több Kincs objektum
            //(az 1,1 pozíciót is hagyjuk szabadon, innen indul majd a játékos).
            int db = 0;
            int ujx, ujy;
            bool jatekos;
            do
            {
                ujx = R.Next(PALYA_MERET_X - 1) + 1; //véletlen X koordináta
                ujy = R.Next(PALYA_MERET_Y - 1) + 1; //véletlen Y koordináta
                segedelem = ter.MegadottHelyenLevok(ujx, ujy); //megnézzük van-e elem új koordinátákon
                jatekos = ujx == 1 && ujy == 1; //nem lehet az új koordináta (1,1)

                //ha nincs az új koordinátán még kincs és
                //nem is (1,1)  koordináta akkor adjuk hozzá az új kincset
                Kincs ujkincs;
                if (segedelem.Length == 0 && !jatekos) 
                {
                    ujkincs = new Kincs(ujx, ujy, ref ter);
                    ujkincs.KincsFelvetel += KincsFelvetelTortent;
                    db++;
                }
            }
            while (db != (KINCSEK_SZAMA));
        }

        //hozza létre a PalyaTer objektumot a maximális mérettel, majd hívja meg a PalyaGeneralas metódust
        public Keret()
        {
            generator = new OrajelGenerator();
            ter = new JatekTer(PALYA_MERET_X, PALYA_MERET_Y);
            PalyaGeneralas();
        }

        //Létrehoz egy játékost „Béla” néven az 1,1 pozícióba a játéktérben
        //Egy ciklus addig fusson, amíg a jatekVege metódus nem vált igazra.
        //A cikluson belül kérjen be egy billentyűleütést, és ha ez egy kurzor gomb volt,
        //akkor mozgassa Bélát ebbe az irányba, ha az Esc billentyű, akkor pedig lépjen ki.
        public void Futtatas()
        {
            KonzolosEredmenyAblak konzolered = new KonzolosEredmenyAblak(0, 12, 5);
            Jatekos jatekos = new Jatekos("Béla", 1, 1, ref ter);
            GepiJatekos geplany = new GepiJatekos("Kati", 13, 5, ref ter);
            GonoszGepiJatekos gepfiu = new GonoszGepiJatekos("Laci", 13, 8, ref ter);
            KonzolosMegjelenito konzolmeg = new KonzolosMegjelenito(ter, 0, 0);
            KonzolosMegjelenito konzolBela = new KonzolosMegjelenito(jatekos, 25, 0);
            
            jatekos.JatekosValtozas += JatekosValtozasTortent;
            //konzolered.JatekosFeliratkozas(gepfiu);  //miért a gépet nézzük?
            konzolered.JatekosFeliratkozas(jatekos); //a játékos eredményeit kellene kiírni....
            generator.Felvetel(geplany);
            generator.Felvetel(gepfiu);
            generator.Felvetel(konzolmeg);
            generator.Felvetel(konzolBela);
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.LeftArrow) jatekos.Megy(-1, 0);
                if (key.Key == ConsoleKey.RightArrow) jatekos.Megy(1, 0);
                if (key.Key == ConsoleKey.UpArrow) jatekos.Megy(0, -1);
                if (key.Key == ConsoleKey.DownArrow) jatekos.Megy(0, 1);
                if (key.Key == ConsoleKey.Escape) jatekVege = true;
            } while (!jatekVege);
        }

        //a KincsFelvetelKezelo delegáltnak megfelelő paraméterekkel rendelkezzen
        private void KincsFelvetelTortent(ref Kincs kincs, ref Jatekos jatekos)
        {
            //Növelje a megtalaltKincsek változó értékét
            megtalaltKincsek++;

            //Ha ez elérte a KINCSEK_SZAMA konstans értéket, akkor a jatekVege változo értéke legyen igaz
            if (megtalaltKincsek == KINCSEK_SZAMA)
                jatekVege = true;
        }

        //a JatekosValtozasKezelo delegáltnak megfelelő paraméterekkel rendelkezzen
        private void JatekosValtozasTortent(ref Jatekos jatekos, int ujpontszam, int ujeletero)
        {
            //Amennyiben a paraméterként kapott életerő 0, akkor állítsa a jatekVege változót igazra
            if (ujeletero == 0)
                jatekVege = true;
        }
    }
}
