using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VozovyPark
{

    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            //Inicializace volání tlačítek, se kterými má designer duševní problémy
            buttonZmenaZrusitHeslo.Click += (sender, e) => PrechodPanelu(sender, panelZmenaHesla, panelUzivatelHome, panelAdminHome);
            buttonUHomeOdhlasitUzivatele.Click += (sender, e) => PrechodPanelu(sender, panelUzivatelHome, panelLogin);
            buttonUHomeZmenaHeslaUzivatele.Click += (sender, e) => PrechodPanelu(sender, panelUzivatelHome, panelZmenaHesla);
            buttonUHomePridatRezervaci.Click += (sender, e) => PrechodPanelu(sender, panelUzivatelHome, panelUzivatelRezervace);
            buttonUHomeUpravitRezervaci.Click += (sender, e) => PrechodPanelu(sender, panelUzivatelHome, panelUzivatelRezervace);
            buttonURezervacePotvrditRezervaci.Click += (sender, e) => PrechodPanelu(sender, panelUzivatelRezervace, panelUzivatelHome);
            buttonURezervaceZrusitRezervaci.Click += (sender, e) => PrechodPanelu(sender, panelUzivatelRezervace, panelUzivatelHome);
            buttonAHomeOdhlasitAdmina.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelLogin);
            buttonAHomeZmenaHeslaAdmina.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelZmenaHesla);
            buttonAHomeSpravaUzivatelu.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelSpravaUzivatelu);
            buttonAHomeSpravaVozidel.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelSpravaVozidel);
            buttonAHomeSpravaRezervaci.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelSpravaRezervaci);
            buttonUzivateleZpet.Click += (sender, e) => PrechodPanelu(sender, panelSpravaUzivatelu, panelAdminHome);
            buttonVozidlaZpet.Click += (sender, e) => PrechodPanelu(sender, panelSpravaVozidel, panelAdminHome);
            buttonVozidlaServisniZaznamy.Click += (sender, e) => PrechodPanelu(sender, panelSpravaVozidel, panelServisVozidla);
            buttonRezervaceZpet.Click += (sender, e) => PrechodPanelu(sender, panelSpravaRezervaci, panelAdminHome);
            buttonServisZpet.Click += (sender, e) => PrechodPanelu(sender, panelServisVozidla, panelSpravaVozidel);
        }

        //Obsahuje informace o uživateli, který je aktuálně přihlášen do systému
        Uzivatele aktualniUzivatel; 

        // Timer, který ovládá dobu vyditelnosti systémových oznámení
        private void TimerOznameni_Tick(object sender, EventArgs e)
        {
            timerOznameni.Enabled = false;
            labelOznameni.Visible = false;
        }

        private void Oznameni(string textOznameni)
        {
            timerOznameni.Enabled = true;
            labelOznameni.Text = textOznameni;
            labelOznameni.Visible = true;
        }

        // Zobrazí přihlašovací panel a inicializuje připojení k databázi při startu programu
        private void MainWindow_Load(object sender, EventArgs e)
        {
            panelLogin.Visible = true;
            SpravceDatabaze.Inicializovat();
        }

        // Spracovává žádosti o výměnu viditelných panelů
        private void PrechodPanelu(object sender, Panel zavrit, Panel otevrit, Panel otevritAdmin = null)
        {
            // Zavře starý panel
            zavrit.Visible = false;

            // Odstraní osobní informace ze zavřeného panelu
            foreach (TextBox t in zavrit.Controls.OfType<TextBox>())
            {
                t.Text = "";
            }
            foreach (ListBox l in zavrit.Controls.OfType<ListBox>())
            {
                l.Items.Clear();
            }

            // Provede úpravy zavřeného panelu podle volajícího
            if (sender == buttonZmenaPotvrditHeslo | sender == buttonZmenaZrusitHeslo)
            {
                buttonZmenaZrusitHeslo.Visible = false;
            }
            if (sender == buttonUHomeOdhlasitUzivatele | sender == buttonAHomeOdhlasitAdmina)
            {
                // Vynuluje texty s posledním přihlášením při odhlášení uživatele

                labelPosledniPrihlaseni.Text = "Naposledy přihlášen:";
                labelPosledniPrihlaseni.Visible = false;
                labelPrihlasenyUzivatel.Text = "Uživatel:";
                labelPrihlasenyUzivatel.Visible = false;

                aktualniUzivatel.PosledniPrihlaseni = aktualniUzivatel.AktualniPrihlaseni;
                SpravceDatabaze.UpravitZaznam(aktualniUzivatel);
                aktualniUzivatel = null;
            }
            if (sender == buttonUHomeZmenaHeslaUzivatele | sender == buttonAHomeZmenaHeslaAdmina)
            {
                buttonZmenaZrusitHeslo.Visible = true;
            }
            if (sender == buttonUHomePridatRezervaci)
            {
                labelURezervaceUpravitRezervaci.Text = "Přidat rezervaci";
            }
            if (sender == buttonURezervacePotvrditRezervaci | sender == buttonURezervaceZrusitRezervaci)
            {
                labelURezervaceUpravitRezervaci.Text = "Upravit rezervaci";
            }
            if (sender == buttonAHomeSpravaUzivatelu)
            {
                UzivateleNacistDatabazi();
            }
            if (sender == buttonAHomeSpravaVozidel)
            {
                VozidlaNacistDatabazi();
            }
            if (sender == buttonAHomeSpravaRezervaci)
            {
                RezervaceNacistDatabazi();
            }

            // Otevře nový panel, případně panel administrátora, pokud je specifikován
            if (otevritAdmin != null && aktualniUzivatel.Administrator == true)
            {
                otevritAdmin.Visible = true;
            }
            else
            {
                otevrit.Visible = true;
            }

            // Zavře oznámení, které by mohlo být zobrazeno
            TimerOznameni_Tick(sender, EventArgs.Empty);

            // Zobrazí informace o přihlášeném uživateli a oznámení vždy na vrchu
            labelPrihlasenyUzivatel.BringToFront();
            labelPosledniPrihlaseni.BringToFront();
            labelOznameni.BringToFront();
        }

        // Naplnit seznam typu TreeView hierarchicky daty z listu vozidel
        private void NaplnitTreeView(TreeView treeView, List<Vozidla> listVozidel)
        {
            for (int index = 0; index < listVozidel.Count(); index++)
            {
                if (index != 0) // Pokud se nejedná o první vozidlo
                {

                    int indexTypu = treeView.Nodes.Count - 1;   // Zjistí aktuální index typu vozidla
                    int indexVyrobce = treeView.Nodes[indexTypu].Nodes.Count - 1;   // Zjistí aktuální index výrobce vozidla
                    int indexModelu = treeView.Nodes[indexTypu].Nodes[indexVyrobce].Nodes.Count - 1;   // Zjistí aktuální index modelu vozidla

                    if (listVozidel[index].Typ != listVozidel[index - 1].Typ)   // Pokud se změnil typ oproti předchozímu kolu, tak zapíše celou řadu
                    {
                        treeView.Nodes.Add(listVozidel[index].Typ).Nodes.Add(listVozidel[index].Vyrobce).Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].Id.ToString(), listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                    else if (listVozidel[index].Vyrobce != listVozidel[index - 1].Vyrobce)  // Pokud se změnil výrobce oproti předchozímu kolu, tak zapíše pouze následující vlastnosti
                    {
                        treeView.Nodes[indexTypu].Nodes.Add(listVozidel[index].Vyrobce).Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].Id.ToString(), listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                    else if (listVozidel[index].Model != listVozidel[index - 1].Model)  // Pokud se změnil model oproti předchozímu kolu, tak zapíše pouze následující vlastnosti
                    {
                        treeView.Nodes[indexTypu].Nodes[indexVyrobce].Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].Id.ToString(), listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                    else    // Pokud se změnila SPZ oproti předchozímu kolu, tak zapíše pouze novou SPZ
                    {
                        treeView.Nodes[indexTypu].Nodes[indexVyrobce].Nodes[indexModelu].Nodes.Add(listVozidel[index].Id.ToString(), listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                }
                else    // Zapíše všechny vlastnosti prvního vozu v seznamu
                {
                    treeView.Nodes.Add(listVozidel[index].Typ).Nodes.Add(listVozidel[index].Vyrobce).Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].Id.ToString(), listVozidel[index].SPZ).Tag = listVozidel[index].Id;

                }
            }
        }
      

        #region Login

        // Rozhoduje jestli uživatel na kterého se přihlašujeme existuje, či nikoliv
        private void ButtonLoginPotvrdit_Click(object sender, EventArgs e)
        {
            // Pošle žádost o nalezení uživatele do databáze
            List<Uzivatele> nalezeniUzivatele = SpravceDatabaze.Prihlasit(textBoxLoginUzivatelskeJmeno.Text, textBoxLoginHeslo.Text);
            if (nalezeniUzivatele.Count > 0)
            {
                // Pokud je uživatel nalezen, nastaví proměnou aktualniUzivatel na aktuálně přihlášeného uživatele
                aktualniUzivatel = nalezeniUzivatele[0];

                // Zaznamená datum a čas posledního přihlášení
                aktualniUzivatel.AktualniPrihlaseni = DateTime.Now;

                // Zobrazí informace o přihlášeném uživateli
                if(aktualniUzivatel.PosledniPrihlaseni != new DateTime(1, 1, 1))
                {
                    labelPosledniPrihlaseni.Text = "Naposledy přihlášen: " + aktualniUzivatel.PosledniPrihlaseni;
                }
                else
                {
                    labelPosledniPrihlaseni.Text = "Naposledy přihlášen: " + aktualniUzivatel.AktualniPrihlaseni;
                }
                labelPrihlasenyUzivatel.Text = "Uživatel: " + aktualniUzivatel.UzivatelskeJmeno;
                labelPosledniPrihlaseni.Visible = true;
                labelPrihlasenyUzivatel.Visible = true;


                // Pokud je u uživatele vyžadována změna hesla, otevře panel pro změnu hesla.
                // V opačném připadě otevře domovskou obrazovku uživatele nebo administrátora
                if (aktualniUzivatel.NutnaZmenaHesla)
                {
                    PrechodPanelu(sender, panelLogin, panelZmenaHesla);
                }
                else
                {
                    PrechodPanelu(sender, panelLogin, panelUzivatelHome, panelAdminHome);
                }

            }
            else
            {
                // Pokud uživatel není v databázi nalezen, zobrazí chybovou hlášku a vyresetuje pole pro heslo
                Oznameni("Špatné uživatelské jméno nebo heslo!");
                textBoxLoginHeslo.Text = "";
            }

        }

        // Vyhodnocuje splnění podmínek pro nové heslo uživatele při změně hesla
        private void ButtonZmenaPotvrditHeslo_Click(object sender, EventArgs e)
        {
            // Kontroluje délku hesla a zda neobsahuje mezeru
            if (textBoxZmenaNoveHeslo.Text.Length >= 5 & !textBoxZmenaNoveHeslo.Text.Any(Char.IsWhiteSpace))
            {
                // Kontroluje shodu hesla s potvrzením hesla
                if (textBoxZmenaNoveHeslo.Text == textBoxZmenaPotvrditHeslo.Text)
                {
                    // Pokud je heslo delší než 5 a rovná se potvrzení hesla, tak se zapíše do profilu uživatele
                    aktualniUzivatel.Heslo = textBoxZmenaNoveHeslo.Text;
                    aktualniUzivatel.NutnaZmenaHesla = false;

                    // Uživatel je následně přesunut na domovskou obrazovku
                    PrechodPanelu(sender, panelZmenaHesla, panelUzivatelHome, panelAdminHome);
                }
                else
                {
                    // V případě, že nejsou dodrženy podmínky pro heslo, tak jsou zobrazeny chybové hlášky
                    Oznameni("Hesla se neshodují!");
                }
            }
            else
            {
                Oznameni("Heslo musí mít alespoň 5 pozic a bez mezer!");
            }

        }
        #endregion

        #region SpravaUzivatelu

        // Načte seznam uživatelů z databáze při otevření panelu
        private void UzivateleNacistDatabazi()
        {
            //Vymaže seznam,aby nevznikly duplikátní hodnoty
            listBoxUzivateleSeznamUzivatelu.Items.Clear();

            // Najde uživatele v databází a zapíše je do listu
            foreach (Uzivatele u in SpravceDatabaze.SeznamUzivatelu())
            {
                listBoxUzivateleSeznamUzivatelu.Items.Add(new ListBoxItem(u.ToString(), u.Id));
            }

            // Pokud je vlistu alespoň jeden záznam, tak vybere první záznam
            if (listBoxUzivateleSeznamUzivatelu.Items.Count != 0)
            {
                listBoxUzivateleSeznamUzivatelu.SelectedIndex = 0;
            }
        }

        // Odemyká a zamyká ovládací prvky pro úpravu a přídání uživatele do systému
        private void UzivateleOdemknoutZamknoutOvladani(object sender, EventArgs e)
        {
            // Určuje, zda se má detail odemknout nebo zamknout
            bool odemknout = false;

            if (sender == buttonUzivatelePridat | sender == buttonUzivateleUpravit)
            {
                odemknout = true;
            }
            else
            {
                buttonUzivatelePotvrdit.Text = "Potvrdit";
            }

            // Odemkne a zamkne prvky, aby nevznikly zakázané stavy
            groupBoxUzivateleDetail.Enabled = odemknout;
            buttonUzivatelePridat.Enabled = !odemknout;
            buttonUzivateleUpravit.Enabled = !odemknout;
            buttonUzivateleOdebrat.Enabled = !odemknout;
            listBoxUzivateleSeznamUzivatelu.Enabled = !odemknout;
            buttonUzivateleZpet.Enabled = !odemknout;

            if (sender == buttonUzivatelePridat)
            {
                // Vyresetuje detail, aby uživateli nepřekážely předchozí hodnoty
                textBoxUzivateleJmeno.Text = "";
                textBoxUzivatelePrijmeni.Text = "";
                textBoxUzivateleJmenoUzivatele.Text = "";
                checkBoxUzivateleVynutitZmenuHesla.Checked = true;
                checkBoxUzivateleVynutitZmenuHesla.Enabled = false;

                // Nastaví tlačítko, aby bylo poznat, zda dochází k úpravě či přidání a uloží tuto informaci do vlastnosti Tag
                buttonUzivatelePotvrdit.Text = "Přidat";
                buttonUzivatelePotvrdit.Tag = false;
            }
            else
            {
                // Nastaví tlačítko, aby bylo poznat, zda dochází k úpravě či přidání a uloží tuto informaci do vlastnosti Tag
                buttonUzivatelePotvrdit.Text = "Upravit";
                buttonUzivatelePotvrdit.Tag = true;

                // Pokud se uživatel ještě nepřihlásil, tak nedovolí zrušit vynucení změny hesla
                if (SpravceDatabaze.Prikaz.Find<Uzivatele>(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag).PosledniPrihlaseni == new DateTime(1, 1, 1))
                {
                    checkBoxUzivateleVynutitZmenuHesla.Enabled = false;
                }

            }
        }

        // Přidá uživatele, případně upraví existujícího uživatele v databázi a načte znovu databázi
        private void ButtonUzivatelePotvrditUzivatele_Click(object sender, EventArgs e)
        {
            // Určuje, zda všechny operace proběhly bez chyb
            bool povedloSe = true;

            // Připraví strukturu nového uživatele a načte původního uživatele při úpravě
            Uzivatele novyUzivatel = new Uzivatele();
            Uzivatele puvodniUzivatel = new Uzivatele();

            // Kontroluje a ukládá jméno
            if (textBoxUzivateleJmeno.Text.Length > 0)
            {
                novyUzivatel.Jmeno = textBoxUzivateleJmeno.Text;
            }
            else
            {
                povedloSe = false;
                Oznameni("Není vyplněno jméno!");
            }

            // Kontroluje a ukládá příjmení
            if (checkBoxUzivateleAdministrator.Checked || textBoxUzivatelePrijmeni.Text.Length > 0)
            {
                novyUzivatel.Prijmeni = textBoxUzivatelePrijmeni.Text;
            }
            else
            {
                povedloSe = false;
                Oznameni("Není vyplněno příjmení!");
            }

            // Kontroluje a ukládá uživatelské jméno
            if (textBoxUzivateleJmenoUzivatele.Text.Length > 0)
            {
                novyUzivatel.UzivatelskeJmeno = textBoxUzivateleJmenoUzivatele.Text;
            }
            else
            {
                povedloSe = false;
                Oznameni("Není vyplněno uživatelské jméno!");
            }

            // Pokud probíhá úprava uživatele
            if ((bool)buttonUzivatelePotvrdit.Tag)
            {
                // Načte z databáze uživatele před úpravou
                puvodniUzivatel = SpravceDatabaze.Prikaz.Find<Uzivatele>(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag);

                // Kontroluje zda již neexistuje toto uživatelské jméno
                if (SpravceDatabaze.Prikaz.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE id != '{puvodniUzivatel.Id}' AND uzivatelskeJmeno = '{novyUzivatel.UzivatelskeJmeno}'").Count != 0)
                {
                    povedloSe = false;
                    Oznameni("Toto uživatelské jméno již existuje!");
                }

                // Kontroluje zda není odstraňován poslední administrátor
                if (checkBoxUzivateleAdministrator.Checked != true && SpravceDatabaze.Prikaz.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE id != '{puvodniUzivatel.Id}' AND administrator = true").Count == 0)
                {
                    povedloSe = false;
                    Oznameni("Odstraňujete posledního administrátora!");
                }
            }
            else
            {
                // Kontroluje zda již neexistuje toto uživatelské jméno
                if (SpravceDatabaze.Prikaz.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE uzivatelskeJmeno = '{novyUzivatel.UzivatelskeJmeno}'").Count != 0)
                {
                    povedloSe = false;
                    Oznameni("Toto uživatelské jméno již existuje!");
                }
            }

            // Pokud vše proběhlo bez problémů
            if (povedloSe)
            {
                // Přečte, zda je uživatel Administrátor
                novyUzivatel.Administrator = checkBoxUzivateleAdministrator.Checked;

                    if ((bool)buttonUzivatelePotvrdit.Tag)
                    {
                        // Pokud jde o úpravu, tak zkopíruje neměnné hodnoty a aktualizuje záznam
                        novyUzivatel.Id = puvodniUzivatel.Id;
                        novyUzivatel.PosledniPrihlaseni = puvodniUzivatel.PosledniPrihlaseni;
                        novyUzivatel.Heslo = puvodniUzivatel.Heslo;
                        novyUzivatel.NutnaZmenaHesla = checkBoxUzivateleVynutitZmenuHesla.Checked;

                        SpravceDatabaze.UpravitZaznam(novyUzivatel);
                    }
                    else
                    {
                        // Pokud jde o přidání, tak nastaví neměnné hodnoty a přidá záznam
                        novyUzivatel.NutnaZmenaHesla = true;
                        novyUzivatel.PosledniPrihlaseni = new DateTime(1, 1, 1);
                        novyUzivatel.Heslo = "";

                        SpravceDatabaze.PridatZaznam(novyUzivatel);
                    }

                    // Zamkne detail a aktualizuje seznam
                    UzivateleOdemknoutZamknoutOvladani(sender, e);
                    UzivateleNacistDatabazi();
            }

        }

        // Zruší úpravu / přídání uživatele do systému
        private void ButtonUzivateleZrusitUzivatele_Click(object sender, EventArgs e)
        {
            UzivateleOdemknoutZamknoutOvladani(sender, e);
            ListBoxUzivateleSeznamUzivatelu_SelectedIndexChanged(sender, e);
        }

        // Zobrazuje podrobnosti o uživateli pokud je zvolen v seznamu
        private void ListBoxUzivateleSeznamUzivatelu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUzivateleSeznamUzivatelu.SelectedIndex != -1)
            {
                // Načte uživatele z databáze
                Uzivatele uzivatel = SpravceDatabaze.Prikaz.Find<Uzivatele>(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag);
                
                // Zobrazí poslední přihlášení uživatele
                if (uzivatel.PosledniPrihlaseni != new DateTime(1, 1, 1))
                {
                    labelUzivateleNaposledyPrihlasen.Text = "Naposledy přihlášen: " + uzivatel.PosledniPrihlaseni;
                }
                else
                {
                    labelUzivateleNaposledyPrihlasen.Text = "Naposledy přihlášen: Uživatel zatím nebyl přihlášen";
                }
                // Zobrazí další podrobnosti uživatele
                textBoxUzivateleJmeno.Text = uzivatel.Jmeno;
                textBoxUzivatelePrijmeni.Text = uzivatel.Prijmeni;
                textBoxUzivateleJmenoUzivatele.Text = uzivatel.UzivatelskeJmeno;
                checkBoxUzivateleVynutitZmenuHesla.Checked = uzivatel.NutnaZmenaHesla;
                checkBoxUzivateleAdministrator.Checked = uzivatel.Administrator;

                // Povolí tlačítka pro práci se záznamem
                buttonUzivateleUpravit.Enabled = true;
                buttonUzivateleOdebrat.Enabled = true;
            }
            else
            {
                // Zakáže tlačítka pro práci se záznamem
                buttonUzivateleUpravit.Enabled = false;
                buttonUzivateleOdebrat.Enabled = false;
            }
        }

        // Odebere uživatele z databáze
        private void ButtonUzivateleOdebratUzivatele_Click(object sender, EventArgs e)
        {
            // Najde uživatele v databázi
            Uzivatele uzivatel = SpravceDatabaze.Prikaz.Find<Uzivatele>(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag);

            // Zkontroluje, zda nechceme odstranit posledního administrátora
            if (uzivatel.Administrator && SpravceDatabaze.Prikaz.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE administrator = 'true' AND id != '{uzivatel.Id}'").Count == 0)
            {
                Oznameni("Odstraňujete posledního administrátora!");
            }
            else
            {
                // Vyžádá si potvrzení odstranění od uživatele
                DialogResult result = MessageBox.Show(
                         $"Opravu chcete odstranit uživatele {uzivatel.Jmeno} {uzivatel.Prijmeni}?"
                         , "Odstranit uživatele",
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Information);

                // Pokud uživatel potvrdí odstranění, odstraní záznam a aktualizuje seznam
                if (result == DialogResult.Yes)
                {
                    SpravceDatabaze.OdstranitZaznam(uzivatel);
                    UzivateleNacistDatabazi();
                }
            }
        }

        // Generuje uživatelské jméno při vytvoření uživatele
        private void UzivateleGeneratorUzivatelskehoJmena(object sender, EventArgs e)
        {
            if (!(bool)buttonUzivatelePotvrdit.Tag & textBoxUzivateleJmeno.Text.Length != 0 && textBoxUzivatelePrijmeni.Text.Length != 0)
            {
                string text = textBoxUzivateleJmeno.Text.ToLower() + "." + textBoxUzivatelePrijmeni.Text.ToLower();
                text = text.Normalize(NormalizationForm.FormD);
                IEnumerable<char> chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark & !char.IsWhiteSpace(c));
                textBoxUzivateleJmenoUzivatele.Text = new string(chars.ToArray()).Normalize(NormalizationForm.FormC);
            }
        }

        #endregion

        #region SpravaVozidel

        // Načte seznam vozidel z databáze při otevření panelu
        private void VozidlaNacistDatabazi()
        {
            // Vyčistí seznamy, kdyby zde zůstalo něco z minula
            treeViewVozidlaSeznamVozidel.Nodes.Clear();
            listBoxVozidlaTyp.Items.Clear();
            listBoxVozidlaVyrobce.Items.Clear();
            listBoxVozidlaModel.Items.Clear();

            // Načíst seznam z databáze
            List<Vozidla> vozidlaSeznamVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>("SELECT * FROM vozidla ORDER BY typ, vyrobce, model, spz");

            NaplnitTreeView(treeViewVozidlaSeznamVozidel, vozidlaSeznamVozidel); // Naplní TreeView seznamem

            // Naplní seznamy sloužící k editaci nebo vytvoření nového vozidla
            foreach (Vozidla v in vozidlaSeznamVozidel)
            {
                if (listBoxVozidlaTyp.Items.IndexOf(v.Typ) == -1)
                {
                    listBoxVozidlaTyp.Items.Add(v.Typ);
                }

                if (listBoxVozidlaVyrobce.Items.IndexOf(v.Vyrobce) == -1)
                {
                    listBoxVozidlaVyrobce.Items.Add(v.Vyrobce);
                }

                if (listBoxVozidlaModel.Items.IndexOf(v.Model) == -1)
                {
                    listBoxVozidlaModel.Items.Add(v.Model);
                }
            }

        }

        // Odemyká a zamyká ovládací prvky pro úpravu a přídání vozidla do systému
        private void VozidlaOdemknoutZamknoutOvladani(object sender, EventArgs e)
        {
            bool pridatNeboUpravit = false;

            if (sender == buttonVozidlaPridat | sender == buttonVozidlaUpravit)
            {
                pridatNeboUpravit = true;
                if (sender == buttonVozidlaPridat)
                {
                    maskedTextBoxVozidlaSPZ.Text = "";
                    textBoxVozidlaTyp.Text = "";
                    textBoxVozidlaVyrobce.Text = "";
                    textBoxVozidlaModel.Text = "";
                    numericUpDownVozidlaSpotreba.Value = 0;

                    // Nastaví tlačítko, aby bylo poznat, že dochází k přidání
                    buttonVozidlaPotvrdit.Text = "Přidat";
                    buttonVozidlaPotvrdit.Tag = false;
                }
                else
                {
                    // Nastaví tlačítko, aby bylo poznat, že dochází k úpravě 
                    buttonVozidlaPotvrdit.Text = "Upravit";
                    buttonVozidlaPotvrdit.Tag = true;
                }
            }
            else
            {
                buttonVozidlaPotvrdit.Text = "Potvrdit";
            }

            groupBoxVozidlaDetail.Enabled = pridatNeboUpravit;
            buttonVozidlaPridat.Enabled = !pridatNeboUpravit;
            buttonVozidlaUpravit.Enabled = !pridatNeboUpravit;
            buttonVozidlaOdebrat.Enabled = !pridatNeboUpravit;
            buttonVozidlaServisniZaznamy.Enabled = !pridatNeboUpravit;
            treeViewVozidlaSeznamVozidel.Enabled = !pridatNeboUpravit;
            buttonVozidlaZpet.Enabled = !pridatNeboUpravit;
        }

        // Přidá vozidla, případně upraví existující vozidla v databázi a načte znovu databázi
        private void ButtonVozidlaPotvrditVozidlo_Click(object sender, EventArgs e)
        {
            bool povedloSe = true;
            Vozidla noveVozidlo = new Vozidla();

            // Zkontroluje a uloží SPZ
            if (maskedTextBoxVozidlaSPZ.MaskCompleted)
            {
                noveVozidlo.SPZ = maskedTextBoxVozidlaSPZ.Text;
            }
            else
            {
                povedloSe = false;
                Oznameni("Nebyla vyplněna SPZ!");
            }

            // Zkontroluje a uloží výrobce vozidla
            if (listBoxVozidlaVyrobce.SelectedIndex != -1)
            {
                noveVozidlo.Vyrobce = listBoxVozidlaVyrobce.SelectedItem.ToString();
            }
            else
            {
                povedloSe = false;
                Oznameni("Nebyl vybrán výrobce!");
            }

            // Zkontroluje a uloží model vozidla
            if (listBoxVozidlaModel.SelectedIndex != -1)
            {
                noveVozidlo.Model = listBoxVozidlaModel.SelectedItem.ToString();
            }
            else
            {
                povedloSe = false;
                Oznameni("Nebyl vybrán model!");
            }

            // Zkontroluje a uloží typ vozidla
            if (listBoxVozidlaTyp.SelectedIndex != -1)
            {
                noveVozidlo.Typ = listBoxVozidlaTyp.SelectedItem.ToString();
            }
            else
            {
                povedloSe = false;
                Oznameni("Nebyl vybrán typ!");
            }

            // Pokud vše proběhlo v pořádku, tak načte spotřebu a pokusí se vozidlo uložit
            if (povedloSe)
            {
                noveVozidlo.Spotreba = numericUpDownVozidlaSpotreba.Value;

                if (SpravceDatabaze.Prikaz.Query<Vozidla>($"SELECT * FROM vozidla WHERE spz = \"{noveVozidlo.SPZ}\"").Count == 0)
                {
                    if ((bool)buttonVozidlaPotvrdit.Tag)
                    {
                        // Pokud se vozidlo pouze upravuje, tak se ještě nastaví id vozidla
                        noveVozidlo.Id = (int)treeViewVozidlaSeznamVozidel.SelectedNode.Tag;
                        SpravceDatabaze.UpravitZaznam(noveVozidlo);
                    }
                    else
                    {
                        SpravceDatabaze.PridatZaznam(noveVozidlo);
                    }
                    VozidlaOdemknoutZamknoutOvladani(sender, e);
                    VozidlaNacistDatabazi();
                }
                else
                {
                    Oznameni("Vozidlo s touto SPZ již existuje!");
                }

            }

        }

        // Zruší úpravu / přídání vozidlo do systému
        private void ButtonVozidlaZrusitVozidlo_Click(object sender, EventArgs e)
        {
            VozidlaOdemknoutZamknoutOvladani(sender, e);
            TreeViewVozidlaSeznamVozidel_AfterSelect(sender, e);
        }

        // Zobrazuje podrobnosti o vozidle pokud je zvoleno v seznamu
        private void TreeViewVozidlaSeznamVozidel_AfterSelect(object sender, EventArgs e)
        {
            if (treeViewVozidlaSeznamVozidel.SelectedNode != null && treeViewVozidlaSeznamVozidel.SelectedNode.Level == 3)
            {
                Vozidla vozidlo = SpravceDatabaze.Prikaz.Query<Vozidla>($"SELECT * FROM vozidla WHERE id = '{treeViewVozidlaSeznamVozidel.SelectedNode.Tag}'")[0];
                listBoxVozidlaVyrobce.SelectedIndex = listBoxVozidlaVyrobce.Items.IndexOf(vozidlo.Vyrobce);
                listBoxVozidlaModel.SelectedIndex = listBoxVozidlaModel.Items.IndexOf(vozidlo.Model);
                listBoxVozidlaTyp.SelectedIndex = listBoxVozidlaTyp.Items.IndexOf(vozidlo.Typ);
                maskedTextBoxVozidlaSPZ.Text = vozidlo.SPZ;
                numericUpDownVozidlaSpotreba.Value = vozidlo.Spotreba;
                buttonVozidlaUpravit.Enabled = true;
                buttonVozidlaOdebrat.Enabled = true;
                buttonVozidlaServisniZaznamy.Enabled = true;
            }
            else
            {
                buttonVozidlaUpravit.Enabled = false;
                buttonVozidlaOdebrat.Enabled = false;
                buttonVozidlaServisniZaznamy.Enabled = false;
            }
        }

        // Odebere vozidlo z databáze
        private void ButtonVozidlaOdebratVozidlo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit vozidlo {treeViewVozidlaSeznamVozidel.SelectedNode.Text}?"
                , "Odstranit vozidlo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                //SpravceDatabaze.OdstranitZaznam(SpravceDatabaze.Prikaz.Query<Vozidla>($"SELECT * FROM vozidla WHERE id=\'{treeViewVozidlaSeznamVozidel.SelectedNode.Tag}\'")[0]);
                SpravceDatabaze.Prikaz.Delete<Vozidla>(treeViewVozidlaSeznamVozidel.SelectedNode.Tag);
                VozidlaNacistDatabazi();
            }
        }

        //Přidá možnost do seznamu
        private void ButtonVozidlaPridatMoznost_Click(object sender, EventArgs e)
        {
            if (sender == buttonVozidlaPridatTyp)
            {
                listBoxVozidlaTyp.Items.Add(textBoxVozidlaTyp.Text);
                listBoxVozidlaTyp.SelectedIndex = listBoxVozidlaTyp.Items.Count - 1;
            }
            if (sender == buttonVozidlaPridatVyrobce)
            {
                listBoxVozidlaVyrobce.Items.Add(textBoxVozidlaVyrobce.Text);
                listBoxVozidlaVyrobce.SelectedIndex = listBoxVozidlaVyrobce.Items.Count - 1;
            }
            if (sender == buttonVozidlaPridatModel)
            {
                listBoxVozidlaModel.Items.Add(textBoxVozidlaModel.Text);
                listBoxVozidlaModel.SelectedIndex = listBoxVozidlaModel.Items.Count - 1;
            }
        }

        #endregion

        #region SpravaRezervaci

        // Načte všechny seznamy na panelu
        private void RezervaceNacistDatabazi()
        {
            groupBoxRezervaceDetail.Enabled = false;
            // Vyčistí seznamy, kdyby zde zůstalo něco z minula
            treeViewRezervaceSeznamRezervaci.Nodes.Clear();
            listBoxRezervaceSeznamUzivatelu.Items.Clear();
            treeViewRezervaceSeznamVozidel.Nodes.Clear();
            listBoxRezervaceSeznamRezervaci.Items.Clear();

            // Načíst seznam z databáze
            List<Uzivatele> rezervaceSeznamUzivatelu = SpravceDatabaze.Prikaz.Query<Uzivatele>("SELECT id, jmeno, prijmeni FROM uzivatele ORDER BY prijmeni, jmeno");
            List<Vozidla> rezervaceSeznamVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>("SELECT * FROM vozidla ORDER BY typ, vyrobce, model, spz");

            //Načte do hlavního seznamu vozidla nebo uživatele
            if (radioButtonRezervacePodleVozidel.Checked)
            {
                List<Vozidla> rezervaceSeznamRezervovanychVozidel;
                if (checkBoxRezervaceZobrazitPredchozi.Checked)
                {
                    rezervaceSeznamRezervovanychVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>("SELECT DISTINCT vozidla.id, typ, vyrobce, model, spz FROM vozidla, rezervace WHERE vozidla.id = rezervace.idVozidla ORDER BY typ, vyrobce, model, spz");
                }
                else
                {
                    rezervaceSeznamRezervovanychVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>($"SELECT DISTINCT vozidla.id, typ, vyrobce, model, spz FROM vozidla, rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND vozidla.id = rezervace.idVozidla ORDER BY typ, vyrobce, model, spz");
                }

                // Naplnit seznam
                NaplnitTreeView(treeViewRezervaceSeznamRezervaci, rezervaceSeznamRezervovanychVozidel);
            }
            else
            {
                List<Uzivatele> rezervaceSeznamUziveteluSRezervaci;
                if (checkBoxRezervaceZobrazitPredchozi.Checked)
                {
                    rezervaceSeznamUziveteluSRezervaci = SpravceDatabaze.Prikaz.Query<Uzivatele>("SELECT DISTINCT uzivatele.id, jmeno, prijmeni, administrator FROM uzivatele, rezervace WHERE uzivatele.id = rezervace.idUzivatele ORDER BY administrator, prijmeni, jmeno");
                }
                else
                {
                    rezervaceSeznamUziveteluSRezervaci = SpravceDatabaze.Prikaz.Query<Uzivatele>($"SELECT DISTINCT uzivatele.id, jmeno, prijmeni, administrator FROM uzivatele, rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND uzivatele.id = rezervace.idUzivatele ORDER BY administrator, prijmeni, jmeno");
                }

                // Naplní seznam uživateli
                treeViewRezervaceSeznamRezervaci.Nodes.Add("Administrátor");
                treeViewRezervaceSeznamRezervaci.Nodes.Add("Uživatel");

                foreach (Uzivatele u in rezervaceSeznamUziveteluSRezervaci)
                {
                    if (u.Administrator)
                    {
                        treeViewRezervaceSeznamRezervaci.Nodes[0].Nodes.Add(u.ToString()).Tag = u.Id;
                    }
                    else
                    {
                        treeViewRezervaceSeznamRezervaci.Nodes[1].Nodes.Add(u.ToString()).Tag = u.Id;
                    }
                }
            }

            // Naplnit seznamy
            NaplnitTreeView(treeViewRezervaceSeznamVozidel, rezervaceSeznamVozidel);

            foreach (Uzivatele u in rezervaceSeznamUzivatelu)
            {
                listBoxRezervaceSeznamUzivatelu.Items.Add(new ListBoxItem(u.ToString(), u.Id));
            }

            // Vybere první prvek listu
            if (treeViewRezervaceSeznamRezervaci.Nodes.Count != 0)
            {
                treeViewRezervaceSeznamRezervaci.SelectedNode = treeViewRezervaceSeznamRezervaci.Nodes[0];
            }
        }

        // Odemyká a zamyká detail rezervace
        private void RezervaceOdemknoutZamknoutFormular(object sender)
        {
            // Určuje zda odemykáme nebo zamykáme formulář uživatelského rozhraní
            bool odemknout = false; 

            if (sender == buttonRezervacePridat | sender == buttonRezervaceUpravit)
            {
                odemknout = true;

                if (sender == buttonRezervacePridat)
                {
                    // Nastaví tlačítko, aby bylo poznat, že dochází k přidání
                    buttonRezervacePotvrdit.Text = "Přidat";
                    buttonRezervacePotvrdit.Tag = false;
                }
                else
                {
                    // Nastaví tlačítko, aby bylo poznat, že dochází k úpravě
                    buttonRezervacePotvrdit.Text = "Upravit";
                    buttonRezervacePotvrdit.Tag = true;
                }
            }
            else
            {
                buttonRezervacePotvrdit.Text = "Potvrdit";
            }

            // Odemkne pole detailu
            groupBoxRezervaceDetail.Enabled = odemknout;
            textBoxRezervaceUzivatel.Text = "";

            // Zamkne hlavní seznamy, které by mohly rušit
            checkBoxRezervaceZobrazitPredchozi.Enabled = !odemknout;
            treeViewRezervaceSeznamRezervaci.Enabled = !odemknout;
            radioButtonRezervacePodleUzivatelu.Enabled = !odemknout;
            radioButtonRezervacePodleVozidel.Enabled = !odemknout;
            buttonRezervacePridat.Enabled = !odemknout;
            buttonRezervaceZpet.Enabled = !odemknout;
            listBoxRezervaceSeznamRezervaci.Enabled = !odemknout;
            // Zavolá listBox aby zamkl případně odemkl přidružená tlačítka
            listBoxRezervaceSeznamRezervaci_SelectedIndexChanged(sender, EventArgs.Empty);
        }

        // Nastaví seznam rezervací po zvolení dotyčného vozidla
        private void treeViewRezervaceSeznamRezervaci_AfterSelect(object sender, EventArgs e)
        {
            // Vymaže sezam rezervací aby nevznikly duplikátní
            listBoxRezervaceSeznamRezervaci.Items.Clear();

            // Zkontoroluje zda je vybrané opravdu jedno vozidlo a načte jeho informace
            if (treeViewRezervaceSeznamRezervaci.SelectedNode != null && ((treeViewRezervaceSeznamRezervaci.SelectedNode.Level == 3 && radioButtonRezervacePodleVozidel.Checked) || treeViewRezervaceSeznamRezervaci.SelectedNode.Level == 1 && radioButtonRezervacePodleUzivatelu.Checked))
            {
                // Povolí seznam rezervací a přidružené ovládání
                listBoxRezervaceSeznamRezervaci.Enabled = true;

                List<Rezervace> rezervovaneCasy;

                if (radioButtonRezervacePodleVozidel.Checked)
                {
                    // Načte buď aktuální rezervace nebo všechny rezervace podle vozidel
                    if (checkBoxRezervaceZobrazitPredchozi.Checked)
                    {
                        rezervovaneCasy = SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id, rezervaceOd, rezervaceDo FROM rezervace WHERE idVozidla = '{treeViewRezervaceSeznamRezervaci.SelectedNode.Tag}' ORDER BY rezervaceOd");
                    }
                    else
                    {
                        rezervovaneCasy = SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id, rezervaceOd, rezervaceDo FROM rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND idVozidla = '{treeViewRezervaceSeznamRezervaci.SelectedNode.Tag}' ORDER BY rezervaceOd");
                    }
                }
                else
                {
                    // Načte buď aktuální rezervace nebo všechny rezervace podle uživatelů
                    if (checkBoxRezervaceZobrazitPredchozi.Checked)
                    {
                        rezervovaneCasy = SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id, rezervaceOd, rezervaceDo FROM rezervace WHERE idUzivatele = '{treeViewRezervaceSeznamRezervaci.SelectedNode.Tag}' ORDER BY rezervaceOd");
                    }
                    else
                    {
                        rezervovaneCasy = SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id, rezervaceOd, rezervaceDo FROM rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND idUzivatele = '{treeViewRezervaceSeznamRezervaci.SelectedNode.Tag}' ORDER BY rezervaceOd");
                    }
                }

                // Naplní seznam daty
                foreach (Rezervace r in rezervovaneCasy)
                {
                    listBoxRezervaceSeznamRezervaci.Items.Add(new ListBoxItem($"{r.RezervaceOd.ToShortDateString()} - {r.RezervaceDo.ToShortDateString()}", r.Id));
                }

                // Vybere první hodnotu a povolí přidružené ovládání
                listBoxRezervaceSeznamRezervaci.SelectedIndex = 0;
            }
            else
            {
                // Pokud nebylo zvoleno jedno vozidlo zakáže seznam rezervací a přidružené ovládání
                listBoxRezervaceSeznamRezervaci.Enabled = false;
                listBoxRezervaceSeznamRezervaci_SelectedIndexChanged(sender, e);
            }
        }

        // Odemyká a zamyká možnosti a zobrazuje podrobnosti, pokud je vybrána nějaká rezervace
        private void listBoxRezervaceSeznamRezervaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxRezervaceSeznamRezervaci.SelectedIndex != -1 && listBoxRezervaceSeznamRezervaci.Enabled)
            {
                // Načte si z databáze všechny potřebné informace
                Rezervace rezervace = SpravceDatabaze.Prikaz.Find<Rezervace>(((ListBoxItem)listBoxRezervaceSeznamRezervaci.SelectedItem).Tag);
                Uzivatele uzivatel = SpravceDatabaze.Prikaz.Find<Uzivatele>(rezervace.IdUzivatele);
                Vozidla vozidlo = SpravceDatabaze.Prikaz.Find<Vozidla>(rezervace.IdVozidla);

                //Nastaví údaje do polí s detaily
                listBoxRezervaceSeznamUzivatelu.SelectedIndex = listBoxRezervaceSeznamUzivatelu.FindStringExact(uzivatel.ToString());
                treeViewRezervaceSeznamVozidel.SelectedNode = treeViewRezervaceSeznamVozidel.Nodes.Find(vozidlo.Id.ToString(), true)[0];
                dateTimePickerRezervaceRezervaceOdDatum.Value = rezervace.RezervaceOd;
                dateTimePickerRezervaceRezervaceDoDatum.Value = rezervace.RezervaceDo;
                dateTimePickerRezervaceRezervaceOdCas.Value = rezervace.RezervaceOd;
                dateTimePickerRezervaceRezervaceDoCas.Value = rezervace.RezervaceDo;

                // Pokud je čas jiný než default, tak zaškrtne custom čas
                if (rezervace.RezervaceOd.TimeOfDay != new DateTime(1, 1, 1, 0, 0, 0).TimeOfDay)
                {
                    dateTimePickerRezervaceRezervaceOdCas.Checked = true;

                }
                else
                {
                    dateTimePickerRezervaceRezervaceOdCas.Checked = false;
                }
                if (rezervace.RezervaceDo.TimeOfDay != new DateTime(1, 1, 1, 23, 59, 59).TimeOfDay)
                {
                    dateTimePickerRezervaceRezervaceDoCas.Checked = true;

                }
                else
                {
                    dateTimePickerRezervaceRezervaceDoCas.Checked = false;
                }

                //Odemkne doprovodná tlačítka
                buttonRezervaceUpravit.Enabled = true;
                buttonRezervaceOdebrat.Enabled = true;
            }
            else
            {
                // Zamkne dobrovolná tlačítka, pokud není vybraná rezervace
                buttonRezervaceUpravit.Enabled = false;
                buttonRezervaceOdebrat.Enabled = false;
            }
        }

        // Připraví panel pro zápis nové rezervace
        private void buttonRezervacePridatRezervaci_Click(object sender, EventArgs e)
        {
            RezervaceOdemknoutZamknoutFormular(sender);

            // Vyresetuje hodnoty detailu
            listBoxRezervaceSeznamUzivatelu.SelectedItem = null;
            treeViewRezervaceSeznamVozidel.SelectedNode = null;
            dateTimePickerRezervaceRezervaceOdDatum.Value = DateTime.Now;
            dateTimePickerRezervaceRezervaceOdCas.Value = DateTime.Now;
            dateTimePickerRezervaceRezervaceOdCas.Checked = false;
            dateTimePickerRezervaceRezervaceDoDatum.Value = DateTime.Now;
            dateTimePickerRezervaceRezervaceDoCas.Value = DateTime.Now;
            dateTimePickerRezervaceRezervaceDoCas.Checked = false;
        }

        // Připraví panel pro úpravu vybrané rezervace
        private void buttonRezervaceUpravit_Click(object sender, EventArgs e)
        {
            RezervaceOdemknoutZamknoutFormular(sender);
        }

        // Odstraní vybranou rezervaci
        private void buttonRezervaceOdebratRezervaci_Click(object sender, EventArgs e)
        {
            // Načte zvolenou rezervaci a zobrazí výzvu k potvrzení operace
            Rezervace rezervace = SpravceDatabaze.Prikaz.Find<Rezervace>(((ListBoxItem)listBoxRezervaceSeznamRezervaci.SelectedItem).Tag);
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit rezervaci {rezervace.RezervaceOd} - {rezervace.RezervaceDo}?",
                "Odstranit rezervaci",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            // Pokud uživatel operaci potvrdí, tak rezervaci odstraní
            if (result == DialogResult.Yes)
            {
                SpravceDatabaze.Prikaz.Delete<Rezervace>(rezervace.Id);
                RezervaceNacistDatabazi();
            }
        }

        // V případě změny rozsahu zobrazení rezervací aktualizuje seznamy
        private void checkBoxRezervaceZobrazitPredchozi_CheckedChanged(object sender, EventArgs e)
        {
            RezervaceNacistDatabazi();
        }
        // V případě změny řazení rezervací aktualizuje seznamy
        private void radioButtonRezervacePodleVozidel_CheckedChanged(object sender, EventArgs e)
        {
            RezervaceNacistDatabazi();
        }

        // Zařizuje vyhledávání uživatelů
        private void textBoxRezervaceUzivatel_TextChanged(object sender, EventArgs e)
        {
            int index = listBoxRezervaceSeznamUzivatelu.FindString(textBoxRezervaceUzivatel.Text);

            if (index != -1)
            {
                listBoxRezervaceSeznamUzivatelu.SelectedIndex = index;
            }
            else
            {
                Oznameni("Uživatel nebyl nalezen!");
            }
        }

        // Uloží novou nebo upravenou rezervaci
        private void buttonRezervacePotvrdit_Click(object sender, EventArgs e)
        {

            Rezervace novaRezervace = new Rezervace();
            bool bezProblemu = true;

            // Kontrola a načtení vybraného uživatele
            if (listBoxRezervaceSeznamUzivatelu.SelectedItems.Count != 0)
            {
                novaRezervace.IdUzivatele = ((ListBoxItem)listBoxRezervaceSeznamUzivatelu.SelectedItem).Tag;
            }
            else
            {
                bezProblemu = false;
                Oznameni("Nebyl vybrán uživatel!");
            }

            // Kontrola a načtení vybraného vozidla
            if (treeViewRezervaceSeznamVozidel.SelectedNode != null && treeViewRezervaceSeznamVozidel.SelectedNode.Level == 3)
            {
                novaRezervace.IdVozidla = (int)treeViewRezervaceSeznamVozidel.SelectedNode.Tag;
            }
            else
            {
                bezProblemu = false;
                Oznameni("Nebyla vybrána SPZ vozidla!");
            }

            // Načtení data a případného času začátku rezervace
            DateTime casOd = dateTimePickerRezervaceRezervaceOdDatum.Value;
            if (dateTimePickerRezervaceRezervaceOdCas.Checked)
            {
                casOd = casOd.Date + dateTimePickerRezervaceRezervaceOdCas.Value.TimeOfDay;
            }
            else
            {
                casOd = casOd.Date + new DateTime(1, 1, 1, 0, 0, 0).TimeOfDay;
            }

            // Načtení data a případného času konce rezervace
            DateTime casDo = dateTimePickerRezervaceRezervaceDoDatum.Value;
            if (dateTimePickerRezervaceRezervaceDoCas.Checked)
            {
                casDo = casDo.Date + dateTimePickerRezervaceRezervaceDoCas.Value.TimeOfDay;
            }
            else
            {
                casDo = casDo.Date + new DateTime(1, 1, 1, 23, 59, 59).TimeOfDay;
            }

            // Kontrola, zda je rezervace validní
            if (casOd < casDo)
            {
                novaRezervace.RezervaceOd = casOd;
                novaRezervace.RezervaceDo = casDo;
            }
            else
            {
                bezProblemu = false;
                Oznameni("Rezervace končí dříve než začíná!");
            }

            // Pokud nebyly nalezeny problémy při načítání hodnot, tak zkontroluje, zda se rezervace nepřekrývá a uloží rezervaci
            if (bezProblemu)
            {
                // Pokud jde o úpravu
                if ((bool)buttonRezervacePotvrdit.Tag)
                {
                    novaRezervace.Id = ((ListBoxItem)listBoxRezervaceSeznamRezervaci.SelectedItem).Tag;
                    if (SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id FROM rezervace WHERE idVozidla = '{novaRezervace.IdVozidla}' AND id != '{novaRezervace.Id}' AND rezervaceDo >= '{novaRezervace.RezervaceOd.Ticks}' AND rezervaceOd <='{novaRezervace.RezervaceDo.Ticks}'").Count == 0)
                    {
                        SpravceDatabaze.UpravitZaznam(novaRezervace);
                    }
                    else
                    {
                        Oznameni("Vozidlo je v tomto termínu již zarezervované!");
                    }
                }
                else
                {
                    if (SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id FROM rezervace WHERE idVozidla = '{novaRezervace.IdVozidla}' AND rezervaceDo >= '{novaRezervace.RezervaceOd.Ticks}' AND rezervaceOd <='{novaRezervace.RezervaceDo.Ticks}'").Count == 0)
                    {
                        SpravceDatabaze.PridatZaznam(novaRezervace);
                    }
                    else
                    {
                        Oznameni("Vozidlo je v tomto termínu již zarezervované!");
                    }
                }

                // Poté zamkne detail a aktualizuje hodnoty v seznamech
                RezervaceOdemknoutZamknoutFormular(sender);
                RezervaceNacistDatabazi();
            }
        }

        // Zruší vytvoření nebo úpravu rezervace
        private void buttonRezervaceZrusit_Click(object sender, EventArgs e)
        {
            RezervaceOdemknoutZamknoutFormular(sender);
            treeViewRezervaceSeznamRezervaci_AfterSelect(sender, e);
        }

        #endregion
    }

    // Třída, která do ListBoxu propašuje tag pro každý item
    class ListBoxItem
    {
        public ListBoxItem(string text, int tag)
        {
            this.Text = text;
            this.Tag = tag;
        }
        public int Tag;
        public string Text;
        public override string ToString() { return Text; }
    }

    #region Databaze

    [Table("uzivatele")]
    public class Uzivatele
    {

        public Uzivatele() { }
        public Uzivatele(string jmeno, string primeni,
                         string uzivatelskeJmeno, string heslo,
                         DateTime posledniPrihlaseni, bool nutnaZmenaHesla, bool admin)
        {
            this.Jmeno = jmeno;
            this.Prijmeni = primeni;
            this.UzivatelskeJmeno = uzivatelskeJmeno;
            this.Heslo = heslo;
            this.PosledniPrihlaseni = posledniPrihlaseni;
            this.NutnaZmenaHesla = nutnaZmenaHesla;
            this.Administrator = admin;
        }
        
        public override string ToString()
        {
            if (Prijmeni == "")
            {
                return Jmeno;
            }
            else
            {
                return $"{Prijmeni.ToUpper()} {Jmeno}";
            }
        }

        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("jmeno")]
        public string Jmeno { get; set; }
        [Column("prijmeni")]
        public string Prijmeni { get; set; }
        [Unique]
        [Column("uzivatelskeJmeno")]
        public string UzivatelskeJmeno { get; set; }
        [Column("heslo")]
        public string Heslo { get; set; }
        [Ignore]
        public DateTime AktualniPrihlaseni { get; set; }
        [Column("posledniPrihlaseni")]
        public DateTime PosledniPrihlaseni { get; set; }
        [Column("nutnaZmenaHesla")]
        public bool NutnaZmenaHesla { get; set; }

        [Column("administrator")]
        public bool Administrator { get; set; }
    }
    [Table("vozidla")]
    public class Vozidla
    {
        public Vozidla() { }
        public Vozidla(string spz, string vyrobce,
                         string model, string typ,
                         decimal spotreba)
        {
            this.SPZ = spz;
            this.Vyrobce = vyrobce;
            this.Model = model;
            this.Typ = typ;
            this.Spotreba = spotreba;

        }
        public override string ToString()
        {
            return "vozidla";
        }

        [Column("id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("spz")]
        [Unique]
        public string SPZ { get; set; }
        [Column("vyrobce")]
        public string Vyrobce { get; set; }
        [Column("model")]
        public string Model { get; set; }
        [Column("typ")]
        public string Typ { get; set; }
        [Column("spotreba")]
        public decimal Spotreba { get; set; }
    }
    [Table("rezervace")]
    public class Rezervace
    {
        public override string ToString()
        {
            return "rezervace";
        }

        [Column("id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("idVozidla")]
        [Indexed]

        public int IdVozidla { get; set; }
        [Column("idUzivatele")]
        [Indexed]
        public int IdUzivatele { get; set; }
        [Column("rezervaceOd")]
        public DateTime RezervaceOd { get; set; }
        [Column("rezervaceDo")]
        public DateTime RezervaceDo { get; set; }
    }
    [Table("naklady")]
    public class Naklady
    {
        public override string ToString()
        {
            return "naklady";
        }

        [Column("idVozidla")]
        [Indexed]
        public int IdVozidla { get; set; }
        [Column("cisloFaktury")]
        public string CisloFaktury { get; set; }
        [Column("datum")]
        public DateTime Datum { get; set; }
        [Column("cena")]
        public decimal Cena { get; set; }
        [Column("seznamUkonu")]
        public string SeznamUkonu { get; set; }
    }

    public static class SpravceDatabaze
    {
        private static SQLiteConnection _db;

        // Připojí se k databázi
        public static bool Inicializovat()
        {
            bool databazeNeexistuje = !System.IO.File.Exists("database.db");
            _db = new SQLiteConnection("database.db");

            // Přidá do databáze tabulky
            _db.CreateTable<Uzivatele>();
            _db.CreateTable<Vozidla>();
            _db.CreateTable<Rezervace>();
            _db.CreateTable<Naklady>();

            // Pokud neexistuje vytvoří ji a připraví účet administrátora
            if (databazeNeexistuje)
            {
                Uzivatele admin = new Uzivatele("Admin", "", "admin", "admin", new DateTime(1,1,1), false, true);
                _db.Insert(admin);
            }

            return true;
        }

        // Pošle dotaz o přihlášení uživatele do databáze
        public static List<Uzivatele> Prihlasit(string uzivatelskeJmeno, string heslo)
        {
            return _db.Query<Uzivatele>($"SELECT * FROM uzivatele WHERE uzivatelskeJmeno = \'{uzivatelskeJmeno}\' AND heslo = \'{heslo}\'");
        }

        // Přidá záznam do databáze
        public static void PridatZaznam(object zaznam)
        {
            _db.Insert(zaznam);
        }

        // Upraví záznam v databázi
        public static void UpravitZaznam(object zaznam)
        {
            _db.Update(zaznam);
        }

        // Najde záznam v databázi
        public static List<Uzivatele> SeznamUzivatelu()
        {
            return _db.Query<Uzivatele>("SELECT id, jmeno, prijmeni FROM uzivatele ORDER BY prijmeni, jmeno");
        }

        // Odstraní záznam v databázi
        public static void OdstranitZaznam(object klic)
        {
            _db.Delete(klic);
        }

        public static SQLiteConnection Prikaz { get { return _db; } set { } }
    }

    #endregion
}
