using System;

namespace OE.Prog2.Jatek.Automatizmus
{
    interface IVisszajatszhato
    {
        void Vegrehajt();
    }
    class IdoFuggoLancoltLista<T> : IAutomatikusanMukodo where T : IVisszajatszhato
    {
        enum UzemmodTipus { Varakozas, Rogzites, Visszajatszas };
        private UzemmodTipus uzemmod = UzemmodTipus.Varakozas;
        private int ido;
        private ListaElem fej;
        private ListaElem utolso;
        private ListaElem aktualis;

        class ListaElem
        {
            public int ido;
            public T tartalom;
            public ListaElem kovetkezo;
        }

        public void RogzitesInditas()
        {
            uzemmod = UzemmodTipus.Rogzites;
            fej = null;
            utolso = null;
            ido = 0;
        }

        public void Rogzit(T elem)
        {
            if (uzemmod == UzemmodTipus.Rogzites)
            {
                ListaElem uj = new ListaElem();
                uj.ido = ido;
                uj.tartalom = elem;
                utolso = uj;
            }
        }

        public void IdozitettBejaras()
        {
            aktualis = fej;
            ido = 0;
            uzemmod = UzemmodTipus.Visszajatszas;
            Mukodik();
        }

        public void Mukodik()
        {
            ido++;
            if (uzemmod == UzemmodTipus.Visszajatszas)
            {
                if (aktualis.kovetkezo != null || aktualis.ido < ido)
                {
                    aktualis = aktualis.kovetkezo;
                    aktualis.tartalom.Vegrehajt();
                }
                else
                    uzemmod = UzemmodTipus.Varakozas;
            }
        }

        public int MukodesIntervallum
        {
            get { return 1; }
        }
    }
}
