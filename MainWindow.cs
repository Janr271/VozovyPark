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

        bool uzivateleUpravitUzivatele = false;
        List<Uzivatele> uzivateleSeznamUzivatelu;
        bool vozidlaUpravitVozidlo = false;
        List<Vozidla> vozidlaSeznamVozidel;
        Uzivatele aktualniUzivatel; //Obsahuje informace o uživateli, který je aktuálně přihlášen do systému
        bool rezervaceUpravitRezervaci = false;

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
            if (sender == buttonUzivateleZpet)
            {
                uzivateleSeznamUzivatelu = null;
            }
            if (sender == buttonVozidlaZpet)
            {
                vozidlaSeznamVozidel = null;
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
                        treeView.Nodes.Add(listVozidel[index].Typ).Nodes.Add(listVozidel[index].Vyrobce).Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                    else if (listVozidel[index].Vyrobce != listVozidel[index - 1].Vyrobce)  // Pokud se změnil výrobce oproti předchozímu kolu, tak zapíše pouze následující vlastnosti
                    {
                        treeView.Nodes[indexTypu].Nodes.Add(listVozidel[index].Vyrobce).Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                    else if (listVozidel[index].Model != listVozidel[index - 1].Model)  // Pokud se změnil model oproti předchozímu kolu, tak zapíše pouze následující vlastnosti
                    {
                        treeView.Nodes[indexTypu].Nodes[indexVyrobce].Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                    else    // Pokud se změnila SPZ oproti předchozímu kolu, tak zapíše pouze novou SPZ
                    {
                        treeView.Nodes[indexTypu].Nodes[indexVyrobce].Nodes[indexModelu].Nodes.Add(listVozidel[index].SPZ).Tag = listVozidel[index].Id;
                    }

                }
                else    // Zapíše všechny vlastnosti prvního vozu v seznamu
                {
                    treeView.Nodes.Add(listVozidel[index].Typ).Nodes.Add(listVozidel[index].Vyrobce).Nodes.Add(listVozidel[index].Model).Nodes.Add(listVozidel[index].SPZ).Tag = listVozidel[index].Id;

                }
            }
        }

        // Zabezpečí, aby byl v checkedListBoxu vybraný pouze jeden prvek
        private void checkedListBox_OneCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && ((CheckedListBox)sender).CheckedItems.Count != 0)
            {
                CheckedListBox.CheckedIndexCollection vybrane = ((CheckedListBox)sender).CheckedIndices;
                for (int index = 0; index < vybrane.Count; index++)
                {
                    if (vybrane[index] != e.Index)
                    {
                        ((CheckedListBox)sender).SetItemChecked(vybrane[index], false);
                    }
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
                labelPosledniPrihlaseni.Text = "Naposledy přihlášen: " + aktualniUzivatel.PosledniPrihlaseni;
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
            uzivateleSeznamUzivatelu = SpravceDatabaze.NajitZaznam(new Uzivatele());
            listBoxUzivateleSeznamUzivatelu.Items.Clear();
            foreach (Uzivatele u in uzivateleSeznamUzivatelu)
            {
                listBoxUzivateleSeznamUzivatelu.Items.Add($"{u.Prijmeni.ToUpper()} {u.Jmeno}");
            }
        }

        // Odemyká a zamyká ovládací prvky pro úpravu a přídání uživatele do systému
        private void UzivateleOdemknoutZamknoutOvladani(object sender, EventArgs e)
        {
            bool pridatNeboUpravit = false;
            if (sender == buttonUzivatelePridatUzivatele | sender == buttonUzivateleUpravitUzivatele)
            {
                pridatNeboUpravit = true;

                if (sender == buttonUzivatelePridatUzivatele)
                {
                    uzivateleUpravitUzivatele = false;

                    textBoxUzivateleJmeno.Text = "";
                    textBoxUzivatelePrijmeni.Text = "";
                    textBoxUzivateleJmenoUzivatele.Text = "";
                    checkBoxUzivateleVynutitZmenuHesla.Checked = true;
                }
                else
                {
                    uzivateleUpravitUzivatele = true;

                    if (uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].Heslo != "")
                    {
                        checkBoxUzivateleVynutitZmenuHesla.Enabled = true;
                    }
                }
            }
            else
            {
                checkBoxUzivateleVynutitZmenuHesla.Enabled = false;
            }

            textBoxUzivateleJmeno.Enabled = pridatNeboUpravit;
            textBoxUzivatelePrijmeni.Enabled = pridatNeboUpravit;
            textBoxUzivateleJmenoUzivatele.Enabled = pridatNeboUpravit;
            buttonUzivatelePotvrditUzivatele.Enabled = pridatNeboUpravit;
            buttonUzivateleZrusitUzivatele.Enabled = pridatNeboUpravit;
            buttonUzivatelePridatUzivatele.Enabled = !pridatNeboUpravit;
            buttonUzivateleUpravitUzivatele.Enabled = !pridatNeboUpravit;
            buttonUzivateleOdebratUzivatele.Enabled = !pridatNeboUpravit;
            listBoxUzivateleSeznamUzivatelu.Enabled = !pridatNeboUpravit;
            buttonUzivateleZpet.Enabled = !pridatNeboUpravit;
        }

        // Přidá uživatele, případně upraví existujícího uživatele v databázi a načte znovu databázi
        private void ButtonUzivatelePotvrditUzivatele_Click(object sender, EventArgs e)
        {
            Uzivatele novyUzivatel = new Uzivatele(textBoxUzivateleJmeno.Text, textBoxUzivatelePrijmeni.Text,
                                                   textBoxUzivateleJmenoUzivatele.Text, "", DateTime.Now,
                                                   checkBoxUzivateleVynutitZmenuHesla.Checked, false);
            if (uzivateleUpravitUzivatele)
            {
                novyUzivatel.Id = uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].Id;
                novyUzivatel.PosledniPrihlaseni = uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].PosledniPrihlaseni;
                SpravceDatabaze.UpravitZaznam(novyUzivatel);
            }
            else
            {
                if (SpravceDatabaze.Prikaz.Query<Uzivatele>($"SELECT * FROM uzivatele WHERE uzivatelskeJmeno = \'{novyUzivatel.UzivatelskeJmeno}\'").Count == 0)
                {
                    SpravceDatabaze.PridatZaznam(novyUzivatel);
                    UzivateleOdemknoutZamknoutOvladani(sender, e);
                    UzivateleNacistDatabazi();
                }
                else
                {
                    Oznameni("Toto uživatelské jméno již existuje!");
                }

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
            labelUzivateleNaposledyPrihlasen.Text = "Naposledy přihlášen: " + uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].PosledniPrihlaseni;
            textBoxUzivateleJmeno.Text = uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].Jmeno;
            textBoxUzivatelePrijmeni.Text = uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].Prijmeni;
            textBoxUzivateleJmenoUzivatele.Text = uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].UzivatelskeJmeno;
            checkBoxUzivateleVynutitZmenuHesla.Checked = uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].NutnaZmenaHesla;
            buttonUzivateleUpravitUzivatele.Enabled = true;
            buttonUzivateleOdebratUzivatele.Enabled = true;
        }

        // Odebere uživatele z databáze
        private void ButtonUzivateleOdebratUzivatele_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit uživatele {uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].Jmeno} {uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex].Prijmeni}?"
                , "Odstranit uživatele",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                SpravceDatabaze.OdstranitZaznam(uzivateleSeznamUzivatelu[listBoxUzivateleSeznamUzivatelu.SelectedIndex]);
                UzivateleNacistDatabazi();
            }
        }

        // Generuje uživatelské jméno při vytvoření uživatele
        private void UzivateleGeneratorUzivatelskehoJmena(object sender, EventArgs e)
        {
            if (!uzivateleUpravitUzivatele & textBoxUzivateleJmeno.Text.Length != 0 && textBoxUzivatelePrijmeni.Text.Length != 0)
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
            vozidlaSeznamVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>("SELECT * FROM vozidla ORDER BY typ, vyrobce, model, spz");

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

            if (sender == buttonVozidlaPridatVozidlo | sender == buttonVozidlaUpravitVozidlo)
            {
                pridatNeboUpravit = true;
                if (sender == buttonVozidlaPridatVozidlo)
                {
                    maskedTextBoxVozidlaSPZ.Text = "";
                    textBoxVozidlaTyp.Text = "";
                    textBoxVozidlaVyrobce.Text = "";
                    textBoxVozidlaModel.Text = "";
                    numericUpDownVozidlaSpotreba.Value = 0;

                    vozidlaUpravitVozidlo = false;
                }
                else
                {
                    vozidlaUpravitVozidlo = true;
                }
            }

            maskedTextBoxVozidlaSPZ.Enabled = pridatNeboUpravit;
            listBoxVozidlaVyrobce.Enabled = pridatNeboUpravit;
            textBoxVozidlaVyrobce.Enabled = pridatNeboUpravit;
            listBoxVozidlaModel.Enabled = pridatNeboUpravit;
            textBoxVozidlaModel.Enabled = pridatNeboUpravit;
            listBoxVozidlaTyp.Enabled = pridatNeboUpravit;
            textBoxVozidlaTyp.Enabled = pridatNeboUpravit;
            buttonVozidlaPridatVyrobce.Enabled = pridatNeboUpravit;
            buttonVozidlaPridatModel.Enabled = pridatNeboUpravit;
            buttonVozidlaPridatTyp.Enabled = pridatNeboUpravit;
            numericUpDownVozidlaSpotreba.Enabled = pridatNeboUpravit;
            buttonVozidlaPotvrditVozidlo.Enabled = pridatNeboUpravit;
            buttonVozidlaZrusitVozidlo.Enabled = pridatNeboUpravit;
            buttonVozidlaPridatVozidlo.Enabled = !pridatNeboUpravit;
            buttonVozidlaUpravitVozidlo.Enabled = !pridatNeboUpravit;
            buttonVozidlaOdebratVozidlo.Enabled = !pridatNeboUpravit;
            buttonVozidlaServisniZaznamy.Enabled = !pridatNeboUpravit;
            treeViewVozidlaSeznamVozidel.Enabled = !pridatNeboUpravit;
            buttonVozidlaZpet.Enabled = !pridatNeboUpravit;
        }

        // Přidá vozidla, případně upraví existující vozidla v databázi a načte znovu databázi
        private void ButtonVozidlaPotvrditVozidlo_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxVozidlaSPZ.MaskCompleted
                && listBoxVozidlaVyrobce.SelectedIndex != -1
                && listBoxVozidlaModel.SelectedIndex != -1
                && listBoxVozidlaTyp.SelectedIndex != -1)
            {
                Vozidla noveVozidlo = new Vozidla(maskedTextBoxVozidlaSPZ.Text,
                                  listBoxVozidlaVyrobce.Items[listBoxVozidlaVyrobce.SelectedIndex].ToString(),
                                  listBoxVozidlaModel.Items[listBoxVozidlaModel.SelectedIndex].ToString(),
                                  listBoxVozidlaTyp.Items[listBoxVozidlaTyp.SelectedIndex].ToString(),
                                  numericUpDownVozidlaSpotreba.Value);

                if (SpravceDatabaze.Prikaz.Query<Vozidla>($"SELECT * FROM vozidla WHERE spz = \"{noveVozidlo.SPZ}\"").Count == 0)
                {
                    if (vozidlaUpravitVozidlo)
                    {
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
                buttonVozidlaUpravitVozidlo.Enabled = true;
                buttonVozidlaOdebratVozidlo.Enabled = true;
                buttonVozidlaServisniZaznamy.Enabled = true;
            }
            else
            {
                buttonVozidlaUpravitVozidlo.Enabled = false;
                buttonVozidlaOdebratVozidlo.Enabled = false;
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

        // Zabraňuje zadání speciálních znaků do SPZ
        private void textBoxVozidlaSPZ_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetterOrDigit(e.KeyChar) | char.IsControl(e.KeyChar) | char.IsWhiteSpace(e.KeyChar));
        }

        #endregion

        #region SpravaRezervaci

        // Odemyká a zamyká pomocné ovládací prvky
        private void RezervaceOdemknoutZamknoutFormular(object sender)
        {
            bool odemknout = false; // Určuje zda odemykáme nebo zamykáme formulář uživatelského rozhraní

            if (sender == buttonRezervacePridatRezervaci | sender == buttonRezervaceUpravit)
            {
                odemknout = true;
            }

            listViewRezervaceSeznamUzivatelu.Enabled = odemknout;
            textBoxRezervaceUzivatel.Enabled = odemknout;
            buttonRezervaceHledat.Enabled = odemknout;
            treeViewRezervaceSeznamVozidel.Enabled = odemknout;
            dateTimePickerRezervaceRezervaceOdDatum.Enabled = odemknout;
            dateTimePickerRezervaceRezervaceOdCas.Enabled = odemknout;
            dateTimePickerRezervaceRezervaceDoDatum.Enabled = odemknout;
            dateTimePickerRezervaceRezervaceDoCas.Enabled = odemknout;
            buttonRezervacePotvrdit.Enabled = odemknout;
            buttonRezervaceZrusit.Enabled = odemknout;

            checkBoxRezervaceZobrazitPredchozi.Enabled = !odemknout;
            treeViewRezervaceSeznamRezervaci.Enabled = !odemknout;
            radioButtonRezervacePodleUzivatelu.Enabled = !odemknout;
            radioButtonRezervacePodleVozidel.Enabled = !odemknout;
            buttonRezervacePridatRezervaci.Enabled = !odemknout;
            buttonRezervaceUpravit.Enabled = !odemknout;
            buttonRezervaceOdebratRezervaci.Enabled = !odemknout;
            buttonRezervaceZpet.Enabled = !odemknout;
            checkedListBoxRezervaceSeznamRezervaci.Enabled = !odemknout;
            checkedListBox_OneCheck(checkedListBoxRezervaceSeznamRezervaci, new ItemCheckEventArgs(-1, CheckState.Checked, CheckState.Checked));
        }

        // Načte všechny seznamy na panelu
        private void RezervaceNacistDatabazi()
        {
            // Vyčistí seznamy, kdyby zde zůstalo něco z minula
            treeViewRezervaceSeznamRezervaci.Nodes.Clear();
            listViewRezervaceSeznamUzivatelu.Items.Clear();
            treeViewRezervaceSeznamVozidel.Nodes.Clear();
            checkedListBoxRezervaceSeznamRezervaci.Items.Clear();

            // Zakáže úpravu a odstranění rezervace, která by mohla zůstat povolená
            checkedListBoxRezervaceSeznamRezervaci.Enabled = false;
            buttonRezervaceOdebratRezervaci.Enabled = false;
            buttonRezervaceUpravit.Enabled = false;

            // Načíst seznam z databáze
            List<Uzivatele> rezervaceSeznamUzivatelu = SpravceDatabaze.Prikaz.Query<Uzivatele>("SELECT id, jmeno, prijmeni FROM uzivatele ORDER BY prijmeni, jmeno");
            List<Vozidla> rezervaceSeznamVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>("SELECT * FROM vozidla ORDER BY typ, vyrobce, model, spz");
            List<Vozidla> rezervaceSeznamRezervovanychVozidel;
            if (checkBoxRezervaceZobrazitPredchozi.Checked)
            {
                rezervaceSeznamRezervovanychVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>("SELECT DISTINCT vozidla.id, typ, vyrobce, model, spz FROM vozidla, rezervace WHERE vozidla.id = rezervace.idVozidla ORDER BY typ, vyrobce, model, spz");
            }
            else
            {
                rezervaceSeznamRezervovanychVozidel = SpravceDatabaze.Prikaz.Query<Vozidla>($"SELECT DISTINCT vozidla.id, typ, vyrobce, model, spz FROM vozidla, rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND vozidla.id = rezervace.idVozidla ORDER BY typ, vyrobce, model, spz");
            }
             

            NaplnitTreeView(treeViewRezervaceSeznamVozidel, rezervaceSeznamVozidel);
            NaplnitTreeView(treeViewRezervaceSeznamRezervaci, rezervaceSeznamRezervovanychVozidel);

            foreach (Uzivatele u in rezervaceSeznamUzivatelu)
            {
                listViewRezervaceSeznamUzivatelu.Items.Add($"{u.Prijmeni.ToUpper()} {u.Jmeno}").Tag = u.Id;
            }
        }

        // Nastaví seznam rezervací po zvolení dotyčného vozidla
        private void treeViewRezervaceSeznamRezervaci_AfterSelect(object sender, TreeViewEventArgs e)
        {
           checkedListBoxRezervaceSeznamRezervaci.Items.Clear();

            if (treeViewRezervaceSeznamRezervaci.SelectedNode != null && treeViewRezervaceSeznamRezervaci.SelectedNode.Level == 3)
            {
                checkedListBoxRezervaceSeznamRezervaci.Enabled = true;

                List<Rezervace> rezervovaneCasy;

                if (checkBoxRezervaceZobrazitPredchozi.Checked)
                {
                    rezervovaneCasy = SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id, rezervaceOd, rezervaceDo FROM rezervace WHERE idVozidla = '{treeViewRezervaceSeznamRezervaci.SelectedNode.Tag}' ORDER BY rezervaceOd");
                }
                else
                {
                    rezervovaneCasy = SpravceDatabaze.Prikaz.Query<Rezervace>($"SELECT id, rezervaceOd, rezervaceDo FROM rezervace WHERE rezervace.rezervaceDo > '{DateTime.Now.Ticks}' AND idVozidla = '{treeViewRezervaceSeznamRezervaci.SelectedNode.Tag}' ORDER BY rezervaceOd");
                }
                
                foreach (Rezervace r in rezervovaneCasy)
                {
                    checkedListBoxRezervaceSeznamRezervaci.Items.Add(new CheckedListBoxItem($"{r.RezervaceOd} - {r.RezervaceDo}", r.Id));
                }
            }
            else
            {
                checkedListBoxRezervaceSeznamRezervaci.Enabled = false;
                buttonRezervaceUpravit.Enabled = false;
                buttonRezervaceOdebratRezervaci.Enabled = false;
            }
        }

        // Odemyká a zamyká možnosti a zobrazuje podrobnosti, pokud je vybrána nějaká rezervace
        private void listViewRezervaceSeznamRezervaci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkedListBoxRezervaceSeznamRezervaci.SelectedItems.Count != 0 && checkedListBoxRezervaceSeznamRezervaci.Enabled)
            {
                buttonRezervaceUpravit.Enabled = true;
                buttonRezervaceOdebratRezervaci.Enabled = true;



            }
            else
            {
                buttonRezervaceUpravit.Enabled = false;
                buttonRezervaceOdebratRezervaci.Enabled = false;
            }
        }

        // Připraví panel pro zápis nové rezervace
        private void buttonRezervacePridatRezervaci_Click(object sender, EventArgs e)
        {
            rezervaceUpravitRezervaci = false;
            RezervaceOdemknoutZamknoutFormular(sender);
        }

        // Připraví panel pro úpravu vybrané rezervace
        private void buttonRezervaceUpravit_Click(object sender, EventArgs e)
        {
            rezervaceUpravitRezervaci = true;
            RezervaceOdemknoutZamknoutFormular(sender);
        }

        // Odstraní vybranou rezervaci
        private void buttonRezervaceOdebratRezervaci_Click(object sender, EventArgs e)
        {
            Rezervace rezervace = SpravceDatabaze.Prikaz.Find<Rezervace>(((CheckedListBoxItem)checkedListBoxRezervaceSeznamRezervaci.SelectedItems[0]).Tag);
            DialogResult result = MessageBox.Show(
                $"Opravu chcete odstranit rezervaci {rezervace.RezervaceOd} - {rezervace.RezervaceDo}?",
                "Odstranit rezervaci",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

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

        // Uloží novou nebo upravenou rezervaci
        private void buttonRezervacePotvrdit_Click(object sender, EventArgs e)
        {

            Rezervace novaRezervace = new Rezervace();
            bool bezProblemu = true;

            if (listViewRezervaceSeznamUzivatelu.SelectedItems.Count != 0)
            {
                novaRezervace.IdUzivatele = (int)listViewRezervaceSeznamUzivatelu.SelectedItems[0].Tag;
            }
            else
            {
                bezProblemu = false;
                Oznameni("Nebyl vybrán uživatel!");
            }

            if (treeViewRezervaceSeznamVozidel.SelectedNode != null && treeViewRezervaceSeznamVozidel.SelectedNode.Level == 3)
            {
                novaRezervace.IdVozidla = (int)treeViewRezervaceSeznamVozidel.SelectedNode.Tag;
            }
            else
            {
                bezProblemu = false;
                Oznameni("Nebyla vybrána SPZ vozidla!");
            }

            DateTime casOd = dateTimePickerRezervaceRezervaceOdDatum.Value;
            if (dateTimePickerRezervaceRezervaceOdCas.Checked)
            {
                casOd = casOd.Date + dateTimePickerRezervaceRezervaceOdCas.Value.TimeOfDay;
            }
            else
            {
                casOd = casOd.Date + new DateTime(1, 1, 1, 0, 0, 0).TimeOfDay;
            }

            DateTime casDo = dateTimePickerRezervaceRezervaceDoDatum.Value;
            if (dateTimePickerRezervaceRezervaceDoCas.Checked)
            {
                casDo = casDo.Date + dateTimePickerRezervaceRezervaceDoCas.Value.TimeOfDay;
            }
            else
            {
                casDo = casDo.Date + new DateTime(1, 1, 1, 23, 59, 59).TimeOfDay;
            }

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

            if (bezProblemu)
            {
                if (rezervaceUpravitRezervaci)
                {
                    novaRezervace.Id = ((CheckedListBoxItem)checkedListBoxRezervaceSeznamRezervaci.CheckedItems[0]).Tag;
                    SpravceDatabaze.UpravitZaznam(novaRezervace);
                }
                else
                {
                    SpravceDatabaze.PridatZaznam(novaRezervace);
                }
                RezervaceOdemknoutZamknoutFormular(sender);
            }
        }

        // Zruší vytvoření nebo úpravu rezervace
        private void buttonRezervaceZrusit_Click(object sender, EventArgs e)
        {
            RezervaceOdemknoutZamknoutFormular(sender);
        }

        #endregion
    }

    // Třída, která do checkedListBoxu propašuje tag pro každý item
    public class CheckedListBoxItem
    {
        public CheckedListBoxItem(string text, int tag)
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
            return "uzivatele";
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

        // Připojí se k databázi, pokud neexistuje vytvoří ji a připraví účet administrátora
        public static bool Inicializovat()
        {
            bool databazeNeexistuje = !System.IO.File.Exists("database.db");
            _db = new SQLiteConnection("database.db");

            _db.CreateTable<Uzivatele>();
            _db.CreateTable<Vozidla>();
            _db.CreateTable<Rezervace>();
            _db.CreateTable<Naklady>();

            if (databazeNeexistuje)
            {
                _db.CreateTable<Uzivatele>();
                _db.CreateTable<Vozidla>();
                _db.CreateTable<Rezervace>();
                _db.CreateTable<Naklady>();

                Uzivatele admin = new Uzivatele("Admin", "", "admin", "admin", DateTime.Now, false, true);
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
        public static List<Uzivatele> NajitZaznam(object tabulka)
        {
            return _db.Query<Uzivatele>($"SELECT * FROM \'{tabulka}\'");
            //return _db.Query<object>($"SELECT * FROM \'{tabulka}\'");
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
