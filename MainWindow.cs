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
            buttonAHomeOdhlasitAdmina.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelLogin);
            buttonAHomeZmenaHeslaAdmina.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelZmenaHesla);
            buttonAHomeSpravaUzivatelu.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelSpravaUzivatelu);
            buttonAHomeSpravaVozidel.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelSpravaVozidel);
            buttonAHomeSpravaRezervaci.Click += (sender, e) => PrechodPanelu(sender, panelAdminHome, panelSpravaRezervaci);
            buttonUzivateleZpet.Click += (sender, e) => PrechodPanelu(sender, panelSpravaUzivatelu, panelAdminHome);
            buttonVozidlaZpet.Click += (sender, e) => PrechodPanelu(sender, panelSpravaVozidel, panelAdminHome);
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
            foreach (TreeView t in zavrit.Controls.OfType<TreeView>())
            {
                t.Nodes.Clear();
            }

            // Provede úpravy zavřeného panelu podle volajícího
            if (sender == buttonLoginPotvrdit & otevrit == panelZmenaHesla)
            {
                buttonZmenaZrusitHeslo.Visible = false;
            }
            if (sender == buttonZmenaPotvrditHeslo)
            {
                buttonZmenaZrusitHeslo.Visible = true;
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
            if (sender == buttonUHomePridat)
            {
                labelURezervaceUpravitRezervaci.Text = "Přidat rezervaci";
            }
            if (sender == buttonUHomeUpravit)
            {
                labelURezervaceUpravitRezervaci.Text = "Upravit rezervaci";
            }
            if (sender == buttonAHomeSpravaUzivatelu)
            {
                UzivateleNacistDatabazi();
            }
            if (sender == buttonAHomeSpravaVozidel || sender == buttonServisZpet)
            {
                VozidlaNacistDatabazi();
            }
            if (sender == buttonAHomeSpravaRezervaci)
            {
                RezervaceNacistDatabazi();
            }
            if (sender == buttonVozidlaServisniZaznamy)
            {
                ServisNacistZaznamy();
            }
            if (otevrit == panelAdminHome || otevritAdmin == panelAdminHome)
            {
                AHomeAktualizovatStatistiky();
            }
            if (otevrit == panelUzivatelHome && aktualniUzivatel.Administrator == false)
            {
                UHomeNacistDatabazi();
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
                if (aktualniUzivatel.PosledniPrihlaseni != new DateTime(1, 1, 1))
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

        #region AHome
        // Aktualizuje statisktiky systému
        private void AHomeAktualizovatStatistiky()
        {
            // Zjistí hodnoty a zapíše je do nápisů
            labelAHomeCelkemUzivatelu.Text = "Uživatelů v systému: " + SpravceDatabaze.SeznamUzivatelu(false).Count;

            labelAHomeCelkemVozidel.Text = "Vozidel v systému: " + SpravceDatabaze.SeznamVozidel(false).Count;

            labelAHomeCelkemRezervaci.Text = "Rezervací v systému: " + SpravceDatabaze.SeznamRezervaci().Count;

        }
        #endregion

        #region UHome

        // Načte databázi a vypíše ji do listu
        private void UHomeNacistDatabazi()
        {
            // Vyčistí seznamy, kdyby zde zůstalo něco z minula
            listBoxUHomeSeznamRezervaci.Items.Clear();

            // Načíst seznam z databáze
            List<Rezervace> uHomeSeznamRezervaci = SpravceDatabaze.RezervaceUzivateleVozidla(aktualniUzivatel.Id, true);
            foreach (Rezervace r in uHomeSeznamRezervaci)
            {
                listBoxUHomeSeznamRezervaci.Items.Add(new ListBoxItem($"{SpravceDatabaze.NajitVozidlo(r.IdVozidla).SPZ} [{r.RezervaceOd.ToShortDateString()} - {r.RezervaceDo.ToShortDateString()}]", r.Id));
            }

            // Vybere první položku z listu
            if (listBoxUHomeSeznamRezervaci.Items.Count != 0)
            {
                listBoxUHomeSeznamRezervaci.SelectedIndex = 0;
            }
            else
            {
                listBoxUHomeSeznamRezervaci_SelectedIndexChanged(listBoxUHomeSeznamRezervaci, EventArgs.Empty);
            }
        }

        // Nastaví fromulář pro přidání rezervace a otevře formulář
        private void buttonUHomePridat_Click(object sender, EventArgs e)
        {
            // Otevře nový formulář
            PrechodPanelu(sender, panelUzivatelHome, panelUzivatelRezervace);
            // Nastaví kvůli přehlednosti tlačítko
            buttonURezervacePotvrdit.Text = "Přidat";
            buttonURezervacePotvrdit.Tag = false;
            // Zavolá načtení listů druhého fromuláře
            URezervaceNacistFormular();
        }

        // Nastaví fromulář pro úpravu rezervace a otevře formulář
        private void buttonUHomeUpravit_Click(object sender, EventArgs e)
        {
            // Předá idRezervace, která se upravuje druhému formuláři
            labelURezervaceUpravitRezervaci.Tag = ((ListBoxItem)listBoxUHomeSeznamRezervaci.SelectedItem).Tag;

            // Otevře nový formulář
            PrechodPanelu(sender, panelUzivatelHome, panelUzivatelRezervace);
            // Nastaví kvůli přehlednosti tlačítko
            buttonURezervacePotvrdit.Text = "Upravit";
            buttonURezervacePotvrdit.Tag = true;
            // Zavolá načtení listů druhého fromuláře
            URezervaceNacistFormular();
        }

        // Odebere rezervaci z databáze
        private void buttonUHomeOdebrat_Click(object sender, EventArgs e)
        {
            // Načte zvolenou rezervaci a zobrazí výzvu k potvrzení operace
            Rezervace rezervace = SpravceDatabaze.NajitRezervaci(((ListBoxItem)listBoxUHomeSeznamRezervaci.SelectedItem).Tag);
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit rezervaci {rezervace.RezervaceOd} - {rezervace.RezervaceDo}?",
                "Odstranit rezervaci",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            // Pokud uživatel operaci potvrdí, tak rezervaci odstraní
            if (result == DialogResult.Yes)
            {
                SpravceDatabaze.OdstranitZaznam<Rezervace>(rezervace.Id);
                UHomeNacistDatabazi();
            }
        }

        // Povoluje nebo zakazuje navazující ovládací prvky
        private void listBoxUHomeSeznamRezervaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxUHomeSeznamRezervaci.SelectedItem != null)
            {
                buttonUHomeUpravit.Enabled = true;
                buttonUHomeOdebrat.Enabled = true;
            }
            else
            {
                buttonUHomeUpravit.Enabled = false;
                buttonUHomeOdebrat.Enabled = false;
            }
        }
        #endregion

        #region URezervace

        private void URezervaceNacistFormular()
        {
            // Vymaže seznam, aby nevznikly duplicitní hodnoty
            treeViewURezervaceSeznamVozidel.Nodes.Clear();

            // Naplní treeView vozidly
            NaplnitTreeView(treeViewURezervaceSeznamVozidel, SpravceDatabaze.SeznamVozidel(true));
            treeViewURezervaceSeznamVozidel_AfterSelect(treeViewURezervaceSeznamVozidel, EventArgs.Empty);

            // Pokud je zapnuta úprava rezervace
            if ((bool)buttonURezervacePotvrdit.Tag)
            {
                // Načte rezervaci z databáze
                Rezervace rezervace = SpravceDatabaze.NajitRezervaci((int)labelURezervaceUpravitRezervaci.Tag);
                Vozidla vozidlo = SpravceDatabaze.NajitVozidlo(rezervace.IdVozidla);

                // Zobrazí hodnoty na ovládacích prvcích
                dateTimePickerURezervaceRezervaceOdDatum.Value = rezervace.RezervaceOd;
                dateTimePickerURezervaceRezervaceOdCas.Value = rezervace.RezervaceOd;
                dateTimePickerURezervaceRezervaceOdCas.Checked = false;
                dateTimePickerURezervaceRezervaceDoDatum.Value = rezervace.RezervaceDo;
                dateTimePickerURezervaceRezervaceDoCas.Value = rezervace.RezervaceDo;
                dateTimePickerURezervaceRezervaceDoCas.Checked = false;

                // Pokud není defaultní čas, tak zaškrtne pole s časem
                if (rezervace.RezervaceOd.TimeOfDay != new DateTime(1, 1, 1, 0, 0, 0).TimeOfDay)
                {
                    dateTimePickerURezervaceRezervaceOdCas.Checked = true;
                }

                if (rezervace.RezervaceDo.TimeOfDay != new DateTime(1, 1, 1, 23, 59, 59).TimeOfDay)
                {
                    dateTimePickerURezervaceRezervaceDoCas.Checked = true;
                }

                // Zvolí auto v seznamu
                treeViewURezervaceSeznamVozidel.SelectedNode = treeViewURezervaceSeznamVozidel.Nodes.Find(vozidlo.Id.ToString(), true)[0];

            }
            else
            {
                // Zobrazí hodnoty na ovládacích prvcích
                dateTimePickerURezervaceRezervaceOdDatum.Value = DateTime.Now;
                dateTimePickerURezervaceRezervaceOdCas.Value = DateTime.Now;
                dateTimePickerURezervaceRezervaceOdCas.Checked = false;
                dateTimePickerURezervaceRezervaceDoDatum.Value = DateTime.Now;
                dateTimePickerURezervaceRezervaceDoCas.Value = DateTime.Now;
                dateTimePickerURezervaceRezervaceDoCas.Checked = false;
            }
        }
        private void treeViewURezervaceSeznamVozidel_AfterSelect(object sender, EventArgs e)
        {
            // Vymaže seznam, aby nevznikly duplicitní hodnoty
            listBoxURezervaceSeznamTerminu.Items.Clear();

            if (treeViewURezervaceSeznamVozidel.SelectedNode != null && treeViewURezervaceSeznamVozidel.SelectedNode.Level == 3)
            {
                List<Rezervace> seznamRezervaci;

                // Načte list rezervaci pro vybrané vozidlo
                if ((bool)buttonURezervacePotvrdit.Tag)
                {
                    seznamRezervaci = SpravceDatabaze.OstatniRezervaceVozidla((int)treeViewURezervaceSeznamVozidel.SelectedNode.Tag, (int)labelURezervaceUpravitRezervaci.Tag);
                }
                else
                {
                    seznamRezervaci = SpravceDatabaze.RezervaceUzivateleVozidla((int)treeViewURezervaceSeznamVozidel.SelectedNode.Tag, false, true);
                }

                // Zapíše rezervace do seznamu
                foreach (Rezervace r in seznamRezervaci)
                {
                    listBoxURezervaceSeznamTerminu.Items.Add($"{r.RezervaceOd.ToShortDateString()} - {r.RezervaceDo.ToShortDateString()}");
                }
            }
        }

        private void buttonURezervacePotvrdit_Click(object sender, EventArgs e)
        {
            bool bezProblemu = true;
            Rezervace novaRezervace = new Rezervace();

            // Kontrola a načtení vybraného vozidla
            if (treeViewURezervaceSeznamVozidel.SelectedNode != null && treeViewURezervaceSeznamVozidel.SelectedNode.Level == 3)
            {
                if ((int)treeViewURezervaceSeznamVozidel.SelectedNode.Tag != 1)
                {
                    novaRezervace.IdVozidla = (int)treeViewURezervaceSeznamVozidel.SelectedNode.Tag;
                }
                else
                {
                    bezProblemu = false;
                    Oznameni("Není možné vybrat odebrané vozidlo!");
                }           
            }
            else
            {
                bezProblemu = false;
                Oznameni("Nebyla vybrána SPZ vozidla!");
            }

            // Načtení data a případného času začátku rezervace
            DateTime casOd = dateTimePickerURezervaceRezervaceOdDatum.Value;
            if (dateTimePickerURezervaceRezervaceOdCas.Checked)
            {
                casOd = casOd.Date + dateTimePickerURezervaceRezervaceOdCas.Value.TimeOfDay;
            }
            else
            {
                casOd = casOd.Date + new DateTime(1, 1, 1, 0, 0, 0).TimeOfDay;
            }

            // Načtení data a případného času konce rezervace
            DateTime casDo = dateTimePickerURezervaceRezervaceDoDatum.Value;
            if (dateTimePickerURezervaceRezervaceDoCas.Checked)
            {
                casDo = casDo.Date + dateTimePickerURezervaceRezervaceDoCas.Value.TimeOfDay;
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
                novaRezervace.IdUzivatele = aktualniUzivatel.Id;
                // Pokud jde o úpravu
                if ((bool)buttonURezervacePotvrdit.Tag)
                {
                    novaRezervace.Id = (int)labelURezervaceUpravitRezervaci.Tag;
                    if (SpravceDatabaze.OveritDostupnost(novaRezervace))
                    {
                        SpravceDatabaze.UpravitZaznam(novaRezervace);

                        // Poté se vrátí zpět
                        PrechodPanelu(sender, panelUzivatelRezervace, panelUzivatelHome);
                    }
                    else
                    {
                        Oznameni("Vozidlo je v tomto termínu již zarezervované!");
                    }
                }
                else
                {
                    if (SpravceDatabaze.OveritDostupnost(novaRezervace))
                    {
                        SpravceDatabaze.PridatZaznam(novaRezervace);

                        // Poté se vrátí zpět
                        PrechodPanelu(sender, panelUzivatelRezervace, panelUzivatelHome);
                    }
                    else
                    {
                        Oznameni("Vozidlo je v tomto termínu již zarezervované!");
                    }
                }
            }
        }

        private void buttonURezervaceZrusit_Click(object sender, EventArgs e)
        {
            // Vrátí se zpět
            PrechodPanelu(sender, panelUzivatelRezervace, panelUzivatelHome);
        }
        #endregion

        #region SpravaUzivatelu

        // Načte seznam uživatelů z databáze při otevření panelu
        private void UzivateleNacistDatabazi()
        {
            //Vymaže seznam,aby nevznikly duplikátní hodnoty
            listBoxUzivateleSeznamUzivatelu.Items.Clear();

            // Najde uživatele v databází a zapíše je do listu
            foreach (Uzivatele u in SpravceDatabaze.SeznamUzivatelu(false))
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
                if (SpravceDatabaze.NajitUzivatele(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag).PosledniPrihlaseni == new DateTime(1, 1, 1))
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
                puvodniUzivatel = SpravceDatabaze.NajitUzivatele(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag);
                novyUzivatel.Id = puvodniUzivatel.Id;
                // Kontroluje zda již neexistuje toto uživatelské jméno
                if (!SpravceDatabaze.OveritDostupnost(novyUzivatel))
                {
                    povedloSe = false;
                    Oznameni("Toto uživatelské jméno již existuje!");
                }

                // Kontroluje zda není odstraňován poslední administrátor
                if (checkBoxUzivateleAdministrator.Checked != true && !SpravceDatabaze.JineAdminUcty(novyUzivatel))
                {
                    povedloSe = false;
                    Oznameni("Odstraňujete posledního administrátora!");
                }
            }
            else
            {
                // Kontroluje zda již neexistuje toto uživatelské jméno
                if (!SpravceDatabaze.OveritDostupnost(novyUzivatel))
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
                Uzivatele uzivatel = SpravceDatabaze.NajitUzivatele(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag);

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
            Uzivatele uzivatel = SpravceDatabaze.NajitUzivatele(((ListBoxItem)listBoxUzivateleSeznamUzivatelu.SelectedItem).Tag);

            // Zkontroluje, zda nechceme odstranit posledního administrátora
            if (uzivatel.Administrator && !SpravceDatabaze.JineAdminUcty(uzivatel))
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
                    SpravceDatabaze.OdstranitZaznam<Uzivatele>(uzivatel.Id);
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
            List<Vozidla> vozidlaSeznamVozidel = SpravceDatabaze.SeznamVozidel(false);

            NaplnitTreeView(treeViewVozidlaSeznamVozidel, vozidlaSeznamVozidel); // Naplní TreeView seznamem
            TreeViewVozidlaSeznamVozidel_AfterSelect(treeViewURezervaceSeznamVozidel, EventArgs.Empty);

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

                if ((bool)buttonVozidlaPotvrdit.Tag)
                {
                    // Pokud se vozidlo pouze upravuje, tak se ještě nastaví id vozidla
                    noveVozidlo.Id = (int)treeViewVozidlaSeznamVozidel.SelectedNode.Tag;

                    // Zkontroluje, za již vozidlo s touto SPZ neexistuje
                    if (SpravceDatabaze.OveritDostupnost(noveVozidlo))
                    {
                        // Pokud se vozidlo pouze upravuje, tak se ještě nastaví id vozidla
                        SpravceDatabaze.UpravitZaznam(noveVozidlo);
                        VozidlaOdemknoutZamknoutOvladani(sender, e);
                        VozidlaNacistDatabazi();
                    }
                    else
                    {
                        Oznameni("Vozidlo s touto SPZ již existuje!");
                    }
                }
                else
                {
                    // Zkontroluje, za již vozidlo s touto SPZ neexistuje
                    if (SpravceDatabaze.OveritDostupnost(noveVozidlo))
                    {

                        SpravceDatabaze.PridatZaznam(noveVozidlo);
                        VozidlaOdemknoutZamknoutOvladani(sender, e);
                        VozidlaNacistDatabazi();
                    }
                    else
                    {
                        Oznameni("Vozidlo s touto SPZ již existuje!");
                    }

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
                // Najde vozidlo v databázi a zobrazí k němu podrobnosti
                Vozidla vozidlo = SpravceDatabaze.NajitVozidlo((int)treeViewVozidlaSeznamVozidel.SelectedNode.Tag);
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

        // Otevře formulář se servisními záznamy
        private void buttonVozidlaServisniZaznamy_Click(object sender, EventArgs e)
        {
            labelServisVozidla.Tag = treeViewVozidlaSeznamVozidel.SelectedNode.Tag;
            PrechodPanelu(sender, panelSpravaVozidel, panelServisVozidla);
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
                SpravceDatabaze.OdstranitZaznam<Vozidla>((int)treeViewVozidlaSeznamVozidel.SelectedNode.Tag);
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
                textBoxVozidlaTyp.Text = "";
            }
            if (sender == buttonVozidlaPridatVyrobce)
            {
                listBoxVozidlaVyrobce.Items.Add(textBoxVozidlaVyrobce.Text);
                listBoxVozidlaVyrobce.SelectedIndex = listBoxVozidlaVyrobce.Items.Count - 1;
                textBoxVozidlaVyrobce.Text = "";
            }
            if (sender == buttonVozidlaPridatModel)
            {
                listBoxVozidlaModel.Items.Add(textBoxVozidlaModel.Text);
                listBoxVozidlaModel.SelectedIndex = listBoxVozidlaModel.Items.Count - 1;
                textBoxVozidlaModel.Text = "";
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
            List<Uzivatele> rezervaceSeznamUzivatelu = SpravceDatabaze.SeznamUzivatelu(true);
            List<Vozidla> rezervaceSeznamVozidel = SpravceDatabaze.SeznamVozidel(true);

            //Načte do hlavního seznamu vozidla nebo uživatele
            if (radioButtonRezervacePodleVozidel.Checked)
            {
                List<Vozidla> rezervaceSeznamRezervovanychVozidel = SpravceDatabaze.ListRezervovanychVozidel(checkBoxRezervaceZobrazitPredchozi.Checked);

                // Naplnit seznam
                NaplnitTreeView(treeViewRezervaceSeznamRezervaci, rezervaceSeznamRezervovanychVozidel);
            }
            else
            {
                List<Uzivatele> rezervaceSeznamUziveteluSRezervaci = SpravceDatabaze.ListRezervovanychUzivatelu(checkBoxRezervaceZobrazitPredchozi.Checked);

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
            treeViewRezervaceSeznamRezervaci_AfterSelect(treeViewRezervaceSeznamRezervaci, EventArgs.Empty);

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

                // Načte časy rezervace pro vybraný záznam
                List<Rezervace> rezervovaneCasy = SpravceDatabaze.RezervaceUzivateleVozidla((int)treeViewRezervaceSeznamRezervaci.SelectedNode.Tag, radioButtonRezervacePodleUzivatelu.Checked, checkBoxRezervaceZobrazitPredchozi.Checked);

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
                Rezervace rezervace = SpravceDatabaze.NajitRezervaci(((ListBoxItem)listBoxRezervaceSeznamRezervaci.SelectedItem).Tag);
                Uzivatele uzivatel = SpravceDatabaze.NajitUzivatele(rezervace.IdUzivatele);
                Vozidla vozidlo = SpravceDatabaze.NajitVozidlo(rezervace.IdVozidla);

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
            Rezervace rezervace = SpravceDatabaze.NajitRezervaci(((ListBoxItem)listBoxRezervaceSeznamRezervaci.SelectedItem).Tag);
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit rezervaci {rezervace.RezervaceOd} - {rezervace.RezervaceDo}?",
                "Odstranit rezervaci",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            // Pokud uživatel operaci potvrdí, tak rezervaci odstraní
            if (result == DialogResult.Yes)
            {
                SpravceDatabaze.OdstranitZaznam<Rezervace>(rezervace.Id);
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
                if((int)treeViewRezervaceSeznamVozidel.SelectedNode.Tag != 1)
                {
                    novaRezervace.IdVozidla = (int)treeViewRezervaceSeznamVozidel.SelectedNode.Tag;
                }
                else
                {
                    bezProblemu = false;
                    Oznameni("Není možné vybrat odebrané vozidlo!");
                }
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
                    if (SpravceDatabaze.OveritDostupnost(novaRezervace))
                    {
                        SpravceDatabaze.UpravitZaznam(novaRezervace);
                        // Poté zamkne detail a aktualizuje hodnoty v seznamech
                        RezervaceOdemknoutZamknoutFormular(sender);
                        RezervaceNacistDatabazi();
                    }
                    else
                    {
                        Oznameni("Vozidlo je v tomto termínu již zarezervované!");
                    }
                }
                else
                {
                    if (SpravceDatabaze.OveritDostupnost(novaRezervace))
                    {
                        SpravceDatabaze.PridatZaznam(novaRezervace);
                        // Poté zamkne detail a aktualizuje hodnoty v seznamech
                        RezervaceOdemknoutZamknoutFormular(sender);
                        RezervaceNacistDatabazi();
                    }
                    else
                    {
                        Oznameni("Vozidlo je v tomto termínu již zarezervované!");
                    }
                }
            }
        }

        // Zruší vytvoření nebo úpravu rezervace
        private void buttonRezervaceZrusit_Click(object sender, EventArgs e)
        {
            RezervaceOdemknoutZamknoutFormular(sender);
            treeViewRezervaceSeznamRezervaci_AfterSelect(sender, e);
        }

        #endregion

        #region ServisVozidla

        // Načte z databáze servisní záznamy vozidla a zobrazí je
        private void ServisNacistZaznamy()
        {
            // Vymaže seznam, aby v něm nezůstaly neaktuální hodnoty
            listBoxServisSeznamOprav.Items.Clear();
            if (labelServisVozidla.Tag != null)
            {
                // Najde záznamy v databázi
                List<Naklady> naklady = SpravceDatabaze.SeznamNakladu((int)labelServisVozidla.Tag);

                // Zapíše záznamy do listu
                foreach (Naklady n in naklady)
                {
                    listBoxServisSeznamOprav.Items.Add(new ListBoxItem(n.CisloFaktury, n.Id));
                }

                // Vybere první hodnotu seznamu, nebo vyvolá zakázání navazujících uživatelskách prvků
                if (listBoxServisSeznamOprav.Items.Count != 0)
                {
                    listBoxServisSeznamOprav.SelectedIndex = 0;
                }
                else
                {
                    listBoxServisSeznamOprav_SelectedIndexChanged(listBoxServisSeznamOprav, EventArgs.Empty);
                }
            }
        }
        // Odemyká nebo zamiká detail zvolených nákladů
        private void ServisOdemknoutZamknoutDetail(object sender)
        {
            bool odemknout = false;

            // Pokud je volající tlačítko upravit nebo přidat, tak odemkne detail
            if (sender == buttonServisUpravit || sender == buttonServisPridat)
            {
                odemknout = true;

                // Nastaví kůvli lepší přehlednosti text na tlačítku potvrdit
                if (sender == buttonServisUpravit)
                {
                    buttonServisPotvrdit.Text = "Upravit";
                    buttonServisPotvrdit.Tag = true;
                }
                else
                {
                    buttonServisPotvrdit.Text = "Přidat";
                    buttonServisPotvrdit.Tag = false;
                }
            }
            else
            {
                buttonServisPotvrdit.Text = "Potvrdit";
            }

            // Odemkne nebo zamkne prvky
            groupBoxServisDetail.Enabled = odemknout;
            listBoxServisSeznamOprav.Enabled = !odemknout;
            buttonServisPridat.Enabled = !odemknout;
            buttonServisUpravit.Enabled = !odemknout;
            buttonServisOdebrat.Enabled = !odemknout;
            buttonServisZpet.Enabled = !odemknout;
        }

        private void listBoxServisSeznamOprav_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxServisSeznamUkonu.Items.Clear();

            // Pokud je zvolen prvek, tak povolí navazující prvky a zobrazí detail
            if (listBoxServisSeznamOprav.SelectedItem != null)
            {
                buttonServisUpravit.Enabled = true;
                buttonServisOdebrat.Enabled = true;

                // Načte detail zvolených nákladů
                Naklady naklady = SpravceDatabaze.NajitNaklady(((ListBoxItem)listBoxServisSeznamOprav.SelectedItem).Tag);

                textBoxServisCisloFaktury.Text = naklady.CisloFaktury;
                dateTimePickerServisDatum.Value = naklady.Datum;
                numericUpDownServisCena.Value = naklady.Cena;
                char[] separator = { '\n' };
                foreach (string ukon in naklady.SeznamUkonu.Split(separator, StringSplitOptions.RemoveEmptyEntries))
                {
                    listBoxServisSeznamUkonu.Items.Add(ukon);
                }
                textBoxServisUkon.Text = "";
            }
            else
            {
                // Zablokuje navazující ovládací prvky a vymaže detail
                buttonServisUpravit.Enabled = false;
                buttonServisOdebrat.Enabled = false;

                textBoxServisCisloFaktury.Text = "";
                dateTimePickerServisDatum.Value = DateTime.Now;
                numericUpDownServisCena.Value = 0;
            }
        }

        private void buttonServisPridatUkon_Click(object sender, EventArgs e)
        {
            // Přidá do seznamu úkon, pokud není prázdný
            if (textBoxServisUkon.Text != "")
            {
                listBoxServisSeznamUkonu.Items.Add(textBoxServisUkon.Text);
                textBoxServisUkon.Text = "";
            }
            else
            {
                Oznameni("Úkon je prázdný!");
            }
        }

        private void buttonServisOdebratUkon_Click(object sender, EventArgs e)
        {
            // Odebere úkon ze seznamu, pokud je vybrán
            if (listBoxServisSeznamUkonu.SelectedIndex != -1)
            {
                listBoxServisSeznamUkonu.Items.RemoveAt(listBoxServisSeznamUkonu.SelectedIndex);
            }
            else
            {
                Oznameni("Nebyl vybrán žádný úkon k odstranění!");
            }
        }

        private void buttonServisPotvrdit_Click(object sender, EventArgs e)
        {
            bool povedloSe = true;
            Naklady noveNaklady = new Naklady();

            // Zkontroluje a přidá číslo faktury
            if (textBoxServisCisloFaktury.Text != "")
            {
                noveNaklady.CisloFaktury = textBoxServisCisloFaktury.Text;
            }
            else
            {
                povedloSe = false;
                Oznameni("Nebylo zadáno číslo faktury!");
            }

            // Zkontroluje a přidá seznam úkonů
            if (listBoxServisSeznamUkonu.Items.Count != 0)
            {
                StringBuilder b = new StringBuilder();
                foreach (object o in listBoxServisSeznamUkonu.Items)
                {
                    b.Append(o.ToString() + "\n");
                }
                noveNaklady.SeznamUkonu = b.ToString();
            }
            else
            {
                povedloSe = false;
                Oznameni("Nebyly zadány žádné úkony!");
            }

            // Pokud se vše povedlo
            if (povedloSe)
            {
                noveNaklady.Datum = dateTimePickerServisDatum.Value;
                noveNaklady.Cena = numericUpDownServisCena.Value;
                noveNaklady.IdVozidla = (int)labelServisVozidla.Tag;

                // Pokud je vybrána úprava nákladů
                if ((bool)buttonServisPotvrdit.Tag)
                {
                    noveNaklady.Id = ((ListBoxItem)listBoxServisSeznamOprav.SelectedItem).Tag;

                    SpravceDatabaze.UpravitZaznam(noveNaklady);
                }
                else
                {
                    SpravceDatabaze.PridatZaznam(noveNaklady);
                }

                // Zamkne detail a aktualizuje seznam
                ServisOdemknoutZamknoutDetail(sender);
                ServisNacistZaznamy();
            }
        }

        private void buttonServisZrusit_Click(object sender, EventArgs e)
        {
            ServisOdemknoutZamknoutDetail(sender);
        }

        // Odemkne detail a vymažeho při přidání nákladů
        private void buttonServisPridat_Click(object sender, EventArgs e)
        {
            ServisOdemknoutZamknoutDetail(sender);

            textBoxServisCisloFaktury.Text = "";
            dateTimePickerServisDatum.Value = DateTime.Now;
            numericUpDownServisCena.Value = 0;
            listBoxServisSeznamUkonu.Items.Clear();
        }

        // Odemkne dtail při úpravě nákladů
        private void buttonServisUpravit_Click(object sender, EventArgs e)
        {
            ServisOdemknoutZamknoutDetail(sender);
        }

        // Odebere zvolené náklady
        private void buttonServisOdebrat_Click(object sender, EventArgs e)
        {
            // Načte zvolené náklady a zobrazí výzvu k potvrzení operace
            Naklady naklady = SpravceDatabaze.NajitNaklady(((ListBoxItem)listBoxServisSeznamOprav.SelectedItem).Tag);
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit fakturu {naklady.CisloFaktury}?",
                "Odstranit rezervaci",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            // Pokud uživatel operaci potvrdí, tak náklady odstraní
            if (result == DialogResult.Yes)
            {
                SpravceDatabaze.OdstranitZaznam<Naklady>(naklady.Id);
                ServisNacistZaznamy();
            }
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
        public Uzivatele(string jmeno,
                         string primeni,
                         string uzivatelskeJmeno,
                         string heslo,
                         DateTime posledniPrihlaseni,
                         bool nutnaZmenaHesla,
                         bool admin,
                         bool odebrany)
        {
            this.Jmeno = jmeno;
            this.Prijmeni = primeni;
            this.UzivatelskeJmeno = uzivatelskeJmeno;
            this.Heslo = heslo;
            this.PosledniPrihlaseni = posledniPrihlaseni;
            this.NutnaZmenaHesla = nutnaZmenaHesla;
            this.Administrator = admin;
            this.Odebrany = odebrany;
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
        [Column("odebrany")]
        public bool Odebrany { get; set; }
    }


    [Table("vozidla")]
    public class Vozidla
    {
        public Vozidla() { }
        public Vozidla(string spz,
                       string vyrobce,
                       string model,
                       string typ,
                       decimal spotreba,
                       bool odebrano)
        {
            this.SPZ = spz;
            this.Vyrobce = vyrobce;
            this.Model = model;
            this.Typ = typ;
            this.Spotreba = spotreba;
            this.Odebrano = odebrano;

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
        [Column("odebrano")]
        public bool Odebrano { get; set; }
    }

    [Table("rezervace")]
    public class Rezervace
    {
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
        [Column("nedostupne")]
        public bool Nedostupne { get; set; }
    }

    [Table("naklady")]
    public class Naklady
    {
        [Column("id")]
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
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
            var options =new SQLiteConnectionString("database.db", true,key: "Super1Tajne2Heslo3K4Moji5Nejoblibenejsi6Databazi7");
            _db = new SQLiteConnection(options);

            // Přidá do databáze tabulky
            _db.CreateTable<Uzivatele>();
            _db.CreateTable<Vozidla>();
            _db.CreateTable<Rezervace>();
            _db.CreateTable<Naklady>();

            // Pokud neexistuje vytvoří ji a připraví defaultní účty
            if (databazeNeexistuje)
            {
                _db.Insert(new Uzivatele("Admin", "", "admin", "admin", new DateTime(1, 1, 1), false, true, false));
                _db.Insert(new Uzivatele("[Odebraný uživatel]", "", "", "", new DateTime(1, 1, 1), false, false, true));
                _db.Insert(new Vozidla("[Odebrané vozidlo]", "[Odebraný výrobce]", "[Odebraný model]", "[Odebraný typ]", 0, true));
            }

            return true;
        }

        // Ověří přihlášení v databázi
        public static List<Uzivatele> Prihlasit(string uzivatelskeJmeno, string heslo)
        {
            return _db.Query<Uzivatele>($"SELECT * FROM uzivatele WHERE odebrany != true AND uzivatelskeJmeno = '{uzivatelskeJmeno}' AND heslo = '{heslo}'");
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

        // Najde uživatele podle id
        public static Uzivatele NajitUzivatele(int id)
        {
            return _db.Find<Uzivatele>(id);
        }

        // Najde vozidlo podle id
        public static Vozidla NajitVozidlo(int id)
        {
            return _db.Find<Vozidla>(id);
        }

        // Najde rezervaci podle id
        public static Rezervace NajitRezervaci(int id)
        {
            return _db.Find<Rezervace>(id);
        }

        // Najde náklady podle id
        public static Naklady NajitNaklady(int id)
        {
            return _db.Find<Naklady>(id);
        }

        // Najde seznam uživatelů v databázi
        public static List<Uzivatele> SeznamUzivatelu(bool odstraneni)
        {
            if (odstraneni)
            {
                return _db.Query<Uzivatele>("SELECT id, jmeno, prijmeni FROM uzivatele ORDER BY prijmeni, jmeno");
            }
            else
            {
                return _db.Query<Uzivatele>("SELECT id, jmeno, prijmeni FROM uzivatele WHERE odebrany != true ORDER BY prijmeni, jmeno");
            }

        }

        // Najde seznam vozidel v databázi
        public static List<Vozidla> SeznamVozidel(bool odstranene)
        {
            if (odstranene)
            {
                return _db.Query<Vozidla>("SELECT id, typ, vyrobce, model, spz FROM vozidla ORDER BY typ, vyrobce, model, spz");
            }
            else
            {
                return _db.Query<Vozidla>("SELECT id, typ, vyrobce, model, spz FROM vozidla WHERE odebrano != true ORDER BY typ, vyrobce, model, spz");
            }
        }

        // Najde seznam rezervaci v databázi
        public static List<Rezervace> SeznamRezervaci()
        {
            return _db.Query<Rezervace>("SELECT * FROM rezervace WHERE nedostupne != true ORDER BY rezervaceOd");
        }

        // Najde seznam nákladů na specifikované vozidlo v databázi
        public static List<Naklady> SeznamNakladu(int idVozidla)
        {
            return _db.Query<Naklady>($"SELECT id, cisloFaktury FROM naklady WHERE idVozidla = '{idVozidla}' ORDER BY cisloFaktury");
        }

        // Zjistí, zda existují jiné admin účty než zadaný účet
        public static bool JineAdminUcty(Uzivatele uzivatel)
        {
            return _db.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE administrator = true AND id != '{uzivatel.Id}'").Count != 0;
        }

        // Najde rezervace zvoleného uživatele nebo vozidla
        public static List<Rezervace> RezervaceUzivateleVozidla(int id, bool podleUzivatele, bool zobrazitPredchozi = false)
        {
            if (podleUzivatele)
            {
                if (zobrazitPredchozi)
                {
                    return _db.Query<Rezervace>($"SELECT * FROM rezervace WHERE idUzivatele = '{id}' ORDER BY rezervaceOd");
                }
                else
                {
                    return _db.Query<Rezervace>($"SELECT * FROM rezervace WHERE idUzivatele = '{id}' AND rezervaceDo > '{DateTime.Now.Ticks}' ORDER BY rezervaceOd");
                }
            }
            else
            {
                if (zobrazitPredchozi)
                {
                    return _db.Query<Rezervace>($"SELECT * FROM rezervace WHERE idVozidla = '{id}' ORDER BY rezervaceOd");
                }
                else
                {
                    return _db.Query<Rezervace>($"SELECT * FROM rezervace WHERE idVozidla = '{id}' AND rezervaceDo > '{DateTime.Now.Ticks}' ORDER BY rezervaceOd");
                }
            }
        }

        // Najde seznam ostatnich rezervaci vozidla
        public static List<Rezervace> OstatniRezervaceVozidla(int idVozidla, int idRezervace)
        {
            return _db.Query<Rezervace>($"SELECT rezervaceOd, rezervaceDo FROM rezervace WHERE idVozidla = '{idVozidla}' AND id != '{idRezervace}' AND rezervaceDo > '{DateTime.Now.Ticks}' ORDER BY rezervaceOd"); ;
        }

        // Najde uzivatele s rezervacemi
        public static List<Uzivatele> ListRezervovanychUzivatelu(bool zobrazitPredchozi = false)
        {
            if (zobrazitPredchozi)
            {
                return _db.Query<Uzivatele>($"SELECT DISTINCT uzivatele.id, jmeno, prijmeni, administrator FROM uzivatele, rezervace WHERE uzivatele.id = rezervace.idUzivatele ORDER BY administrator, prijmeni, jmeno");
            }
            else
            {
                return _db.Query<Uzivatele>($"SELECT DISTINCT uzivatele.id, jmeno, prijmeni, administrator FROM uzivatele, rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND uzivatele.id = rezervace.idUzivatele ORDER BY administrator, prijmeni, jmeno");
            }

        }

        // Najde zarezervovaná vozidla
        public static List<Vozidla> ListRezervovanychVozidel(bool zobrazitPredchozi = false)
        {
            if (zobrazitPredchozi)
            {
                return _db.Query<Vozidla>($"SELECT DISTINCT vozidla.id, typ, vyrobce, model, spz FROM vozidla, rezervace WHERE vozidla.id = rezervace.idVozidla ORDER BY typ, vyrobce, model, spz");
            }
            else
            {
                return _db.Query<Vozidla>($"SELECT DISTINCT vozidla.id, typ, vyrobce, model, spz FROM vozidla, rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND vozidla.id = rezervace.idVozidla ORDER BY typ, vyrobce, model, spz");
            }
        }

        // Vyhodotí, zda se rezervace nepřekrývá s jinou
        public static bool OveritDostupnost(Rezervace rezervace)
        {
            // Kontroluje jestli je vyplněno Id
            if (rezervace.Id != 0)
            {
                return _db.Query<Rezervace>($"SELECT id FROM rezervace WHERE idVozidla = '{rezervace.IdVozidla}' AND id != '{rezervace.Id}' AND rezervaceDo >= '{rezervace.RezervaceOd.Ticks}' AND rezervaceOd <='{rezervace.RezervaceDo.Ticks}'").Count == 0;
            }
            else
            {
                return _db.Query<Rezervace>($"SELECT id FROM rezervace WHERE idVozidla = '{rezervace.IdVozidla}' AND rezervaceDo >= '{rezervace.RezervaceOd.Ticks}' AND rezervaceOd <='{rezervace.RezervaceDo.Ticks}'").Count == 0;
            }
        }

        // Vyhodnotí, zda již neexistuje jiný uživatel se stejným uživatelským jménem
        public static bool OveritDostupnost(Uzivatele uzivatel)
        {
            if (uzivatel.Id != 0)
            {
                return _db.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE id != '{uzivatel.Id}' AND uzivatelskeJmeno = '{uzivatel.UzivatelskeJmeno}'").Count == 0;
            }
            else
            {
                return _db.Query<Uzivatele>($"SELECT id FROM uzivatele WHERE uzivatelskeJmeno = '{uzivatel.UzivatelskeJmeno}'").Count == 0;
            }
        }

        // Vyhodnotí, zda již neexistuje jiné vozidlo se stejnou SPZ
        public static bool OveritDostupnost(Vozidla vozidlo)
        {
            if (vozidlo.Id != 0)
            {
                return _db.Query<Vozidla>($"SELECT * FROM vozidla WHERE id != '{vozidlo.Id}' AND spz = '{vozidlo.SPZ}'").Count == 0;
            }
            else
            {
                return _db.Query<Vozidla>($"SELECT * FROM vozidla WHERE spz = '{vozidlo.SPZ}'").Count == 0;
            }
        }


        // Odstraní záznam v databázi
        public static void OdstranitZaznam<Typ>(int id)
        {
            // Pokud odebírá uživatele, tak převede jeho staré rezervace na ghosta a nové smaže
            if (typeof(Typ) == typeof(Uzivatele))
            {
                // Načte list rezervaci uzivatele
                List<Rezervace> rezervaceUzivatele = _db.Query<Rezervace>($"SELECT * FROM rezervace WHERE idUzivatele = '{id}'");

                for (int index = 0; index < rezervaceUzivatele.Count; index++)
                {
                    if (rezervaceUzivatele[index].RezervaceOd > DateTime.Now)
                    {
                        // Pokud rezervace ještě neproběhla, tak je smazána
                        _db.Delete<Typ>(rezervaceUzivatele[index].Id);
                    }
                    else
                    {
                        // Pokud rezervace proběhla, tak je přesunuta na ghost uživatele
                        rezervaceUzivatele[index].IdUzivatele = _db.Query<Uzivatele>("SELECT id FROM uzivatele WHERE odebrany = true")[0].Id;
                        _db.Update(rezervaceUzivatele[index]);
                    }
                }
            }
            else if (typeof(Typ) == typeof(Vozidla))
            {
                // Načte list rezervaci daného vozidla
                List<Rezervace> rezervaceVozidla = _db.Query<Rezervace>($"SELECT * FROM rezervace WHERE idVozidla = '{id}'");

                for (int index = 0; index < rezervaceVozidla.Count; index++)
                {

                    // Rezervace je přepsána na ghost vozidlo
                    rezervaceVozidla[index].IdVozidla = _db.Query<Vozidla>("SELECT id FROM vozidla WHERE odebrano = true")[0].Id;
                    _db.Update(rezervaceVozidla[index]);
                }
            }

            // Záznam je nakonec odstraněn
            _db.Delete<Typ>(id);
        }
    }

    #endregion
}
