
namespace VozovyPark
{
    partial class MainWindow
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.labelLoginNazevPanelu = new System.Windows.Forms.Label();
            this.labelLoginUzivatelskeJmeno = new System.Windows.Forms.Label();
            this.textBoxLoginUzivatelskeJmeno = new System.Windows.Forms.TextBox();
            this.labelLoginHeslo = new System.Windows.Forms.Label();
            this.textBoxLoginHeslo = new System.Windows.Forms.TextBox();
            this.buttonLoginPotvrdit = new System.Windows.Forms.Button();
            this.labelOznameni = new System.Windows.Forms.Label();
            this.panelUzivatelHome = new System.Windows.Forms.Panel();
            this.labelUHomePrehledRezervaci = new System.Windows.Forms.Label();
            this.labelUHomeAktualniRezervace = new System.Windows.Forms.Label();
            this.listBoxUHomeSeznamRezervaci = new System.Windows.Forms.ListBox();
            this.buttonUHomeUpravitRezervaci = new System.Windows.Forms.Button();
            this.buttonUHomePridatRezervaci = new System.Windows.Forms.Button();
            this.buttonUHomeOdhlasitUzivatele = new System.Windows.Forms.Button();
            this.buttonUHomeZmenaHeslaUzivatele = new System.Windows.Forms.Button();
            this.panelZmenaHesla = new System.Windows.Forms.Panel();
            this.labelZmenaZmenaHesla = new System.Windows.Forms.Label();
            this.labelZmenaNoveHeslo = new System.Windows.Forms.Label();
            this.textBoxZmenaNoveHeslo = new System.Windows.Forms.TextBox();
            this.labelZmenaPotvrdteHeslo = new System.Windows.Forms.Label();
            this.textBoxZmenaPotvrditHeslo = new System.Windows.Forms.TextBox();
            this.buttonZmenaZrusitHeslo = new System.Windows.Forms.Button();
            this.buttonZmenaPotvrditHeslo = new System.Windows.Forms.Button();
            this.timerOznameni = new System.Windows.Forms.Timer(this.components);
            this.panelUzivatelRezervace = new System.Windows.Forms.Panel();
            this.labelURezervaceUpravitRezervaci = new System.Windows.Forms.Label();
            this.labelURezervaceRezervaceOd = new System.Windows.Forms.Label();
            this.dateTimePickerURezervaceRezervaceOdDatum = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerURezervaceRezervaceOdCas = new System.Windows.Forms.DateTimePicker();
            this.labelURezervaceRezervaceDo = new System.Windows.Forms.Label();
            this.dateTimePickerURezervaceRezervaceDoDatum = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerURezervaceRezervaceDoCas = new System.Windows.Forms.DateTimePicker();
            this.labelURezervaceVozidlo = new System.Windows.Forms.Label();
            this.listBoxURezervaceSeznamAutomobilu = new System.Windows.Forms.ListBox();
            this.labelURezervaceObsazeneTerminy = new System.Windows.Forms.Label();
            this.listBoxURezervaceSeznamObsazenychTerminu = new System.Windows.Forms.ListBox();
            this.buttonURezervaceZrusitRezervaci = new System.Windows.Forms.Button();
            this.buttonURezervacePotvrditRezervaci = new System.Windows.Forms.Button();
            this.panelAdminHome = new System.Windows.Forms.Panel();
            this.labelAHomeRezervaciVSystemu = new System.Windows.Forms.Label();
            this.labelAHomeCelkemVozidel = new System.Windows.Forms.Label();
            this.labelAHomeUzivateluVSystemu = new System.Windows.Forms.Label();
            this.labelAHomeSpravaSystemu = new System.Windows.Forms.Label();
            this.buttonAHomeSpravaVozidel = new System.Windows.Forms.Button();
            this.buttonAHomeSpravaUzivatelu = new System.Windows.Forms.Button();
            this.buttonAHomeSpravaRezervaci = new System.Windows.Forms.Button();
            this.buttonAHomeOdhlasitAdmina = new System.Windows.Forms.Button();
            this.buttonAHomeZmenaHeslaAdmina = new System.Windows.Forms.Button();
            this.labelPosledniPrihlaseni = new System.Windows.Forms.Label();
            this.panelSpravaUzivatelu = new System.Windows.Forms.Panel();
            this.buttonUzivateleZpet = new System.Windows.Forms.Button();
            this.labelUzivateleSpravaUzivatelu = new System.Windows.Forms.Label();
            this.labelUzivateleSeznamUzivatelu = new System.Windows.Forms.Label();
            this.listBoxUzivateleSeznamUzivatelu = new System.Windows.Forms.ListBox();
            this.buttonUzivateleUpravitUzivatele = new System.Windows.Forms.Button();
            this.buttonUzivatelePridatUzivatele = new System.Windows.Forms.Button();
            this.buttonUzivateleOdebratUzivatele = new System.Windows.Forms.Button();
            this.labelUzivateleNaposledyPrihlasen = new System.Windows.Forms.Label();
            this.labelUzivateleJmeno = new System.Windows.Forms.Label();
            this.textBoxUzivateleJmeno = new System.Windows.Forms.TextBox();
            this.labelUzivatelePrijmeni = new System.Windows.Forms.Label();
            this.textBoxUzivatelePrijmeni = new System.Windows.Forms.TextBox();
            this.labelUzivateleJmenoUzivatele = new System.Windows.Forms.Label();
            this.textBoxUzivateleJmenoUzivatele = new System.Windows.Forms.TextBox();
            this.checkBoxUzivateleVynutitZmenuHesla = new System.Windows.Forms.CheckBox();
            this.buttonUzivateleZrusitUzivatele = new System.Windows.Forms.Button();
            this.buttonUzivatelePotvrditUzivatele = new System.Windows.Forms.Button();
            this.panelSpravaVozidel = new System.Windows.Forms.Panel();
            this.buttonVozidlaZpet = new System.Windows.Forms.Button();
            this.labelVozidlaSpravaVozidel = new System.Windows.Forms.Label();
            this.labelVozidlaSeznamVozidel = new System.Windows.Forms.Label();
            this.treeViewVozidlaSeznamVozidel = new System.Windows.Forms.TreeView();
            this.buttonVozidlaUpravitVozidlo = new System.Windows.Forms.Button();
            this.buttonVozidlaPridatVozidlo = new System.Windows.Forms.Button();
            this.buttonVozidlaOdebratVozidlo = new System.Windows.Forms.Button();
            this.buttonVozidlaServisniZaznamy = new System.Windows.Forms.Button();
            this.labelVozidlaSPZ = new System.Windows.Forms.Label();
            this.textBoxVozidlaSPZ = new System.Windows.Forms.TextBox();
            this.labelVozidlaVyrobce = new System.Windows.Forms.Label();
            this.listBoxVozidlaVyrobce = new System.Windows.Forms.ListBox();
            this.textBoxVozidlaVyrobce = new System.Windows.Forms.TextBox();
            this.buttonVozidlaPridatVyrobce = new System.Windows.Forms.Button();
            this.labelVozidlaModel = new System.Windows.Forms.Label();
            this.listBoxVozidlaModel = new System.Windows.Forms.ListBox();
            this.textBoxVozidlaModel = new System.Windows.Forms.TextBox();
            this.buttonVozidlaPridatModel = new System.Windows.Forms.Button();
            this.labelVozidlaTyp = new System.Windows.Forms.Label();
            this.listBoxVozidlaTyp = new System.Windows.Forms.ListBox();
            this.textBoxVozidlaTyp = new System.Windows.Forms.TextBox();
            this.buttonVozidlaPridatTyp = new System.Windows.Forms.Button();
            this.labelVozidlaSpotreba = new System.Windows.Forms.Label();
            this.numericUpDownVozidlaSpotreba = new System.Windows.Forms.NumericUpDown();
            this.buttonVozidlaZrusitVozidlo = new System.Windows.Forms.Button();
            this.buttonVozidlaPotvrditVozidlo = new System.Windows.Forms.Button();
            this.panelSpravaRezervaci = new System.Windows.Forms.Panel();
            this.treeViewRezervaceSeznamVozidel = new System.Windows.Forms.TreeView();
            this.treeViewRezervaceSeznamRezervaci = new System.Windows.Forms.TreeView();
            this.buttonRezervaceZpet = new System.Windows.Forms.Button();
            this.labelRezervaceRezervaci = new System.Windows.Forms.Label();
            this.labelRezervaceSeznamRezervaci = new System.Windows.Forms.Label();
            this.checkBoxRezervaceZobrazitPredchozi = new System.Windows.Forms.CheckBox();
            this.radioButtonRezervacePodleVozidel = new System.Windows.Forms.RadioButton();
            this.radioButtonRezervacePodleUzivatelu = new System.Windows.Forms.RadioButton();
            this.buttonRezervacePridatRezervaci = new System.Windows.Forms.Button();
            this.buttonRezervaceUpravit = new System.Windows.Forms.Button();
            this.buttonRezervaceOdebratRezervaci = new System.Windows.Forms.Button();
            this.labelRezervaceUzivatel = new System.Windows.Forms.Label();
            this.listBoxRezervaceSeznamUzivatelu = new System.Windows.Forms.ListBox();
            this.textBoxRezervaceUzivatel = new System.Windows.Forms.TextBox();
            this.buttonRezervaceHledat = new System.Windows.Forms.Button();
            this.labeRezervaceVozidlo = new System.Windows.Forms.Label();
            this.labelRezervaceRezervaceOd = new System.Windows.Forms.Label();
            this.dateTimePickerRezervaceRezervaceOdDatum = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRezervaceRezervaceOdCas = new System.Windows.Forms.DateTimePicker();
            this.labelRezervaceRezervaceDo = new System.Windows.Forms.Label();
            this.dateTimePickerRezervaceRezervaceDoDatum = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerRezervaceRezervaceDoCas = new System.Windows.Forms.DateTimePicker();
            this.buttonRezervaceZrusit = new System.Windows.Forms.Button();
            this.buttonRezervacePotvrdit = new System.Windows.Forms.Button();
            this.panelServisVozidla = new System.Windows.Forms.Panel();
            this.buttonServisZpet = new System.Windows.Forms.Button();
            this.labelServisVozidla = new System.Windows.Forms.Label();
            this.labelServisSeznamOprav = new System.Windows.Forms.Label();
            this.listBoxServisSeznamOprav = new System.Windows.Forms.ListBox();
            this.buttonServisUpravit = new System.Windows.Forms.Button();
            this.buttonServisPridat = new System.Windows.Forms.Button();
            this.buttonServisOdebrat = new System.Windows.Forms.Button();
            this.labelServisCisloFaktury = new System.Windows.Forms.Label();
            this.textBoxServisCisloFaktury = new System.Windows.Forms.TextBox();
            this.labelServisDatum = new System.Windows.Forms.Label();
            this.dateTimePickerServisDatum = new System.Windows.Forms.DateTimePicker();
            this.labelServisCena = new System.Windows.Forms.Label();
            this.numericUpDownServisCena = new System.Windows.Forms.NumericUpDown();
            this.labelServisMena = new System.Windows.Forms.Label();
            this.labelServisSeznamUkonu = new System.Windows.Forms.Label();
            this.listBoxServisSeznamUkonu = new System.Windows.Forms.ListBox();
            this.textBoxServisUkon = new System.Windows.Forms.TextBox();
            this.buttonServisPridatUkon = new System.Windows.Forms.Button();
            this.buttonServisZrusit = new System.Windows.Forms.Button();
            this.buttonServisPotvrdit = new System.Windows.Forms.Button();
            this.labelPrihlasenyUzivatel = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.panelUzivatelHome.SuspendLayout();
            this.panelZmenaHesla.SuspendLayout();
            this.panelUzivatelRezervace.SuspendLayout();
            this.panelAdminHome.SuspendLayout();
            this.panelSpravaUzivatelu.SuspendLayout();
            this.panelSpravaVozidel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVozidlaSpotreba)).BeginInit();
            this.panelSpravaRezervaci.SuspendLayout();
            this.panelServisVozidla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServisCena)).BeginInit();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.labelLoginNazevPanelu);
            this.panelLogin.Controls.Add(this.labelLoginUzivatelskeJmeno);
            this.panelLogin.Controls.Add(this.textBoxLoginUzivatelskeJmeno);
            this.panelLogin.Controls.Add(this.labelLoginHeslo);
            this.panelLogin.Controls.Add(this.textBoxLoginHeslo);
            this.panelLogin.Controls.Add(this.buttonLoginPotvrdit);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(984, 561);
            this.panelLogin.TabIndex = 0;
            this.panelLogin.Visible = false;
            // 
            // labelLoginNazevPanelu
            // 
            this.labelLoginNazevPanelu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLoginNazevPanelu.AutoSize = true;
            this.labelLoginNazevPanelu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLoginNazevPanelu.Location = new System.Drawing.Point(326, 145);
            this.labelLoginNazevPanelu.Name = "labelLoginNazevPanelu";
            this.labelLoginNazevPanelu.Size = new System.Drawing.Size(289, 37);
            this.labelLoginNazevPanelu.TabIndex = 0;
            this.labelLoginNazevPanelu.Text = "Přihlašte se prosím";
            // 
            // labelLoginUzivatelskeJmeno
            // 
            this.labelLoginUzivatelskeJmeno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLoginUzivatelskeJmeno.AutoSize = true;
            this.labelLoginUzivatelskeJmeno.Location = new System.Drawing.Point(338, 236);
            this.labelLoginUzivatelskeJmeno.Name = "labelLoginUzivatelskeJmeno";
            this.labelLoginUzivatelskeJmeno.Size = new System.Drawing.Size(133, 18);
            this.labelLoginUzivatelskeJmeno.TabIndex = 0;
            this.labelLoginUzivatelskeJmeno.Text = "Uživatelské jméno:";
            // 
            // textBoxLoginUzivatelskeJmeno
            // 
            this.textBoxLoginUzivatelskeJmeno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLoginUzivatelskeJmeno.Location = new System.Drawing.Point(341, 257);
            this.textBoxLoginUzivatelskeJmeno.MaxLength = 64;
            this.textBoxLoginUzivatelskeJmeno.Name = "textBoxLoginUzivatelskeJmeno";
            this.textBoxLoginUzivatelskeJmeno.Size = new System.Drawing.Size(253, 24);
            this.textBoxLoginUzivatelskeJmeno.TabIndex = 1;
            // 
            // labelLoginHeslo
            // 
            this.labelLoginHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLoginHeslo.AutoSize = true;
            this.labelLoginHeslo.Location = new System.Drawing.Point(338, 302);
            this.labelLoginHeslo.Name = "labelLoginHeslo";
            this.labelLoginHeslo.Size = new System.Drawing.Size(51, 18);
            this.labelLoginHeslo.TabIndex = 0;
            this.labelLoginHeslo.Text = "Heslo:";
            // 
            // textBoxLoginHeslo
            // 
            this.textBoxLoginHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLoginHeslo.Location = new System.Drawing.Point(341, 323);
            this.textBoxLoginHeslo.MaxLength = 64;
            this.textBoxLoginHeslo.Name = "textBoxLoginHeslo";
            this.textBoxLoginHeslo.PasswordChar = '•';
            this.textBoxLoginHeslo.Size = new System.Drawing.Size(253, 24);
            this.textBoxLoginHeslo.TabIndex = 2;
            // 
            // buttonLoginPotvrdit
            // 
            this.buttonLoginPotvrdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLoginPotvrdit.Location = new System.Drawing.Point(519, 386);
            this.buttonLoginPotvrdit.Name = "buttonLoginPotvrdit";
            this.buttonLoginPotvrdit.Size = new System.Drawing.Size(75, 25);
            this.buttonLoginPotvrdit.TabIndex = 3;
            this.buttonLoginPotvrdit.Text = "Potvrdit";
            this.buttonLoginPotvrdit.UseVisualStyleBackColor = true;
            this.buttonLoginPotvrdit.Click += new System.EventHandler(this.ButtonLoginPotvrdit_Click);
            // 
            // labelOznameni
            // 
            this.labelOznameni.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelOznameni.AutoSize = true;
            this.labelOznameni.BackColor = System.Drawing.Color.Red;
            this.labelOznameni.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelOznameni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelOznameni.Location = new System.Drawing.Point(320, 0);
            this.labelOznameni.Margin = new System.Windows.Forms.Padding(0);
            this.labelOznameni.Name = "labelOznameni";
            this.labelOznameni.Padding = new System.Windows.Forms.Padding(5);
            this.labelOznameni.Size = new System.Drawing.Size(129, 28);
            this.labelOznameni.TabIndex = 0;
            this.labelOznameni.Text = "labelOznameni";
            this.labelOznameni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelOznameni.Visible = false;
            // 
            // panelUzivatelHome
            // 
            this.panelUzivatelHome.Controls.Add(this.labelUHomePrehledRezervaci);
            this.panelUzivatelHome.Controls.Add(this.labelUHomeAktualniRezervace);
            this.panelUzivatelHome.Controls.Add(this.listBoxUHomeSeznamRezervaci);
            this.panelUzivatelHome.Controls.Add(this.buttonUHomeUpravitRezervaci);
            this.panelUzivatelHome.Controls.Add(this.buttonUHomePridatRezervaci);
            this.panelUzivatelHome.Controls.Add(this.buttonUHomeOdhlasitUzivatele);
            this.panelUzivatelHome.Controls.Add(this.buttonUHomeZmenaHeslaUzivatele);
            this.panelUzivatelHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUzivatelHome.Location = new System.Drawing.Point(0, 0);
            this.panelUzivatelHome.Name = "panelUzivatelHome";
            this.panelUzivatelHome.Size = new System.Drawing.Size(984, 561);
            this.panelUzivatelHome.TabIndex = 0;
            this.panelUzivatelHome.Visible = false;
            // 
            // labelUHomePrehledRezervaci
            // 
            this.labelUHomePrehledRezervaci.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelUHomePrehledRezervaci.AutoSize = true;
            this.labelUHomePrehledRezervaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUHomePrehledRezervaci.Location = new System.Drawing.Point(340, 80);
            this.labelUHomePrehledRezervaci.Name = "labelUHomePrehledRezervaci";
            this.labelUHomePrehledRezervaci.Size = new System.Drawing.Size(263, 37);
            this.labelUHomePrehledRezervaci.TabIndex = 0;
            this.labelUHomePrehledRezervaci.Text = "Přehled rezervací";
            // 
            // labelUHomeAktualniRezervace
            // 
            this.labelUHomeAktualniRezervace.AutoSize = true;
            this.labelUHomeAktualniRezervace.Location = new System.Drawing.Point(292, 159);
            this.labelUHomeAktualniRezervace.Name = "labelUHomeAktualniRezervace";
            this.labelUHomeAktualniRezervace.Size = new System.Drawing.Size(132, 18);
            this.labelUHomeAktualniRezervace.TabIndex = 0;
            this.labelUHomeAktualniRezervace.Text = "Aktuální rezervace:";
            // 
            // listBoxUHomeSeznamRezervaci
            // 
            this.listBoxUHomeSeznamRezervaci.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxUHomeSeznamRezervaci.FormattingEnabled = true;
            this.listBoxUHomeSeznamRezervaci.ItemHeight = 18;
            this.listBoxUHomeSeznamRezervaci.Location = new System.Drawing.Point(295, 185);
            this.listBoxUHomeSeznamRezervaci.MinimumSize = new System.Drawing.Size(300, 4);
            this.listBoxUHomeSeznamRezervaci.Name = "listBoxUHomeSeznamRezervaci";
            this.listBoxUHomeSeznamRezervaci.Size = new System.Drawing.Size(350, 256);
            this.listBoxUHomeSeznamRezervaci.TabIndex = 1;
            // 
            // buttonUHomeUpravitRezervaci
            // 
            this.buttonUHomeUpravitRezervaci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUHomeUpravitRezervaci.Enabled = false;
            this.buttonUHomeUpravitRezervaci.Location = new System.Drawing.Point(389, 456);
            this.buttonUHomeUpravitRezervaci.Name = "buttonUHomeUpravitRezervaci";
            this.buttonUHomeUpravitRezervaci.Size = new System.Drawing.Size(130, 25);
            this.buttonUHomeUpravitRezervaci.TabIndex = 3;
            this.buttonUHomeUpravitRezervaci.Text = "Upravit rezervaci";
            this.buttonUHomeUpravitRezervaci.UseVisualStyleBackColor = true;
            // 
            // buttonUHomePridatRezervaci
            // 
            this.buttonUHomePridatRezervaci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUHomePridatRezervaci.Location = new System.Drawing.Point(525, 456);
            this.buttonUHomePridatRezervaci.Name = "buttonUHomePridatRezervaci";
            this.buttonUHomePridatRezervaci.Size = new System.Drawing.Size(120, 25);
            this.buttonUHomePridatRezervaci.TabIndex = 2;
            this.buttonUHomePridatRezervaci.Text = "Přidat rezervaci";
            this.buttonUHomePridatRezervaci.UseVisualStyleBackColor = true;
            // 
            // buttonUHomeOdhlasitUzivatele
            // 
            this.buttonUHomeOdhlasitUzivatele.Location = new System.Drawing.Point(12, 12);
            this.buttonUHomeOdhlasitUzivatele.Name = "buttonUHomeOdhlasitUzivatele";
            this.buttonUHomeOdhlasitUzivatele.Size = new System.Drawing.Size(105, 25);
            this.buttonUHomeOdhlasitUzivatele.TabIndex = 4;
            this.buttonUHomeOdhlasitUzivatele.Text = "Odhlásit se";
            this.buttonUHomeOdhlasitUzivatele.UseVisualStyleBackColor = true;
            // 
            // buttonUHomeZmenaHeslaUzivatele
            // 
            this.buttonUHomeZmenaHeslaUzivatele.Location = new System.Drawing.Point(12, 43);
            this.buttonUHomeZmenaHeslaUzivatele.Name = "buttonUHomeZmenaHeslaUzivatele";
            this.buttonUHomeZmenaHeslaUzivatele.Size = new System.Drawing.Size(105, 25);
            this.buttonUHomeZmenaHeslaUzivatele.TabIndex = 5;
            this.buttonUHomeZmenaHeslaUzivatele.Text = "Změnit heslo";
            this.buttonUHomeZmenaHeslaUzivatele.UseVisualStyleBackColor = true;
            // 
            // panelZmenaHesla
            // 
            this.panelZmenaHesla.Controls.Add(this.labelZmenaZmenaHesla);
            this.panelZmenaHesla.Controls.Add(this.labelZmenaNoveHeslo);
            this.panelZmenaHesla.Controls.Add(this.textBoxZmenaNoveHeslo);
            this.panelZmenaHesla.Controls.Add(this.labelZmenaPotvrdteHeslo);
            this.panelZmenaHesla.Controls.Add(this.textBoxZmenaPotvrditHeslo);
            this.panelZmenaHesla.Controls.Add(this.buttonZmenaZrusitHeslo);
            this.panelZmenaHesla.Controls.Add(this.buttonZmenaPotvrditHeslo);
            this.panelZmenaHesla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelZmenaHesla.Location = new System.Drawing.Point(0, 0);
            this.panelZmenaHesla.Name = "panelZmenaHesla";
            this.panelZmenaHesla.Size = new System.Drawing.Size(984, 561);
            this.panelZmenaHesla.TabIndex = 0;
            this.panelZmenaHesla.Visible = false;
            // 
            // labelZmenaZmenaHesla
            // 
            this.labelZmenaZmenaHesla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelZmenaZmenaHesla.AutoSize = true;
            this.labelZmenaZmenaHesla.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelZmenaZmenaHesla.Location = new System.Drawing.Point(274, 145);
            this.labelZmenaZmenaHesla.Name = "labelZmenaZmenaHesla";
            this.labelZmenaZmenaHesla.Size = new System.Drawing.Size(418, 37);
            this.labelZmenaZmenaHesla.TabIndex = 0;
            this.labelZmenaZmenaHesla.Text = "Je vyžadována změna hesla";
            // 
            // labelZmenaNoveHeslo
            // 
            this.labelZmenaNoveHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelZmenaNoveHeslo.AutoSize = true;
            this.labelZmenaNoveHeslo.Location = new System.Drawing.Point(345, 236);
            this.labelZmenaNoveHeslo.Name = "labelZmenaNoveHeslo";
            this.labelZmenaNoveHeslo.Size = new System.Drawing.Size(87, 18);
            this.labelZmenaNoveHeslo.TabIndex = 0;
            this.labelZmenaNoveHeslo.Text = "Nové heslo:";
            // 
            // textBoxZmenaNoveHeslo
            // 
            this.textBoxZmenaNoveHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxZmenaNoveHeslo.Location = new System.Drawing.Point(348, 257);
            this.textBoxZmenaNoveHeslo.MaxLength = 64;
            this.textBoxZmenaNoveHeslo.Name = "textBoxZmenaNoveHeslo";
            this.textBoxZmenaNoveHeslo.PasswordChar = '•';
            this.textBoxZmenaNoveHeslo.Size = new System.Drawing.Size(253, 24);
            this.textBoxZmenaNoveHeslo.TabIndex = 1;
            // 
            // labelZmenaPotvrdteHeslo
            // 
            this.labelZmenaPotvrdteHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelZmenaPotvrdteHeslo.AutoSize = true;
            this.labelZmenaPotvrdteHeslo.Location = new System.Drawing.Point(345, 302);
            this.labelZmenaPotvrdteHeslo.Name = "labelZmenaPotvrdteHeslo";
            this.labelZmenaPotvrdteHeslo.Size = new System.Drawing.Size(109, 18);
            this.labelZmenaPotvrdteHeslo.TabIndex = 0;
            this.labelZmenaPotvrdteHeslo.Text = "Potvrďte heslo:";
            // 
            // textBoxZmenaPotvrditHeslo
            // 
            this.textBoxZmenaPotvrditHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxZmenaPotvrditHeslo.Location = new System.Drawing.Point(348, 323);
            this.textBoxZmenaPotvrditHeslo.MaxLength = 64;
            this.textBoxZmenaPotvrditHeslo.Name = "textBoxZmenaPotvrditHeslo";
            this.textBoxZmenaPotvrditHeslo.PasswordChar = '•';
            this.textBoxZmenaPotvrditHeslo.Size = new System.Drawing.Size(253, 24);
            this.textBoxZmenaPotvrditHeslo.TabIndex = 2;
            // 
            // buttonZmenaZrusitHeslo
            // 
            this.buttonZmenaZrusitHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonZmenaZrusitHeslo.Location = new System.Drawing.Point(445, 386);
            this.buttonZmenaZrusitHeslo.Name = "buttonZmenaZrusitHeslo";
            this.buttonZmenaZrusitHeslo.Size = new System.Drawing.Size(75, 25);
            this.buttonZmenaZrusitHeslo.TabIndex = 4;
            this.buttonZmenaZrusitHeslo.Text = "Zrušit";
            this.buttonZmenaZrusitHeslo.UseVisualStyleBackColor = true;
            this.buttonZmenaZrusitHeslo.Visible = false;
            // 
            // buttonZmenaPotvrditHeslo
            // 
            this.buttonZmenaPotvrditHeslo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonZmenaPotvrditHeslo.Location = new System.Drawing.Point(526, 386);
            this.buttonZmenaPotvrditHeslo.Name = "buttonZmenaPotvrditHeslo";
            this.buttonZmenaPotvrditHeslo.Size = new System.Drawing.Size(75, 25);
            this.buttonZmenaPotvrditHeslo.TabIndex = 3;
            this.buttonZmenaPotvrditHeslo.Text = "Potvrdit";
            this.buttonZmenaPotvrditHeslo.UseVisualStyleBackColor = true;
            this.buttonZmenaPotvrditHeslo.Click += new System.EventHandler(this.ButtonZmenaPotvrditHeslo_Click);
            // 
            // timerOznameni
            // 
            this.timerOznameni.Interval = 3000;
            this.timerOznameni.Tick += new System.EventHandler(this.TimerOznameni_Tick);
            // 
            // panelUzivatelRezervace
            // 
            this.panelUzivatelRezervace.Controls.Add(this.labelURezervaceUpravitRezervaci);
            this.panelUzivatelRezervace.Controls.Add(this.labelURezervaceRezervaceOd);
            this.panelUzivatelRezervace.Controls.Add(this.dateTimePickerURezervaceRezervaceOdDatum);
            this.panelUzivatelRezervace.Controls.Add(this.dateTimePickerURezervaceRezervaceOdCas);
            this.panelUzivatelRezervace.Controls.Add(this.labelURezervaceRezervaceDo);
            this.panelUzivatelRezervace.Controls.Add(this.dateTimePickerURezervaceRezervaceDoDatum);
            this.panelUzivatelRezervace.Controls.Add(this.dateTimePickerURezervaceRezervaceDoCas);
            this.panelUzivatelRezervace.Controls.Add(this.labelURezervaceVozidlo);
            this.panelUzivatelRezervace.Controls.Add(this.listBoxURezervaceSeznamAutomobilu);
            this.panelUzivatelRezervace.Controls.Add(this.labelURezervaceObsazeneTerminy);
            this.panelUzivatelRezervace.Controls.Add(this.listBoxURezervaceSeznamObsazenychTerminu);
            this.panelUzivatelRezervace.Controls.Add(this.buttonURezervaceZrusitRezervaci);
            this.panelUzivatelRezervace.Controls.Add(this.buttonURezervacePotvrditRezervaci);
            this.panelUzivatelRezervace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUzivatelRezervace.Location = new System.Drawing.Point(0, 0);
            this.panelUzivatelRezervace.Name = "panelUzivatelRezervace";
            this.panelUzivatelRezervace.Size = new System.Drawing.Size(984, 561);
            this.panelUzivatelRezervace.TabIndex = 0;
            this.panelUzivatelRezervace.Visible = false;
            // 
            // labelURezervaceUpravitRezervaci
            // 
            this.labelURezervaceUpravitRezervaci.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelURezervaceUpravitRezervaci.AutoSize = true;
            this.labelURezervaceUpravitRezervaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelURezervaceUpravitRezervaci.Location = new System.Drawing.Point(341, 43);
            this.labelURezervaceUpravitRezervaci.Name = "labelURezervaceUpravitRezervaci";
            this.labelURezervaceUpravitRezervaci.Size = new System.Drawing.Size(255, 37);
            this.labelURezervaceUpravitRezervaci.TabIndex = 0;
            this.labelURezervaceUpravitRezervaci.Text = "Upravit rezervaci";
            // 
            // labelURezervaceRezervaceOd
            // 
            this.labelURezervaceRezervaceOd.AutoSize = true;
            this.labelURezervaceRezervaceOd.Location = new System.Drawing.Point(50, 164);
            this.labelURezervaceRezervaceOd.Name = "labelURezervaceRezervaceOd";
            this.labelURezervaceRezervaceOd.Size = new System.Drawing.Size(104, 18);
            this.labelURezervaceRezervaceOd.TabIndex = 0;
            this.labelURezervaceRezervaceOd.Text = "Rezervace od:";
            // 
            // dateTimePickerURezervaceRezervaceOdDatum
            // 
            this.dateTimePickerURezervaceRezervaceOdDatum.Location = new System.Drawing.Point(53, 185);
            this.dateTimePickerURezervaceRezervaceOdDatum.Name = "dateTimePickerURezervaceRezervaceOdDatum";
            this.dateTimePickerURezervaceRezervaceOdDatum.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerURezervaceRezervaceOdDatum.TabIndex = 1;
            // 
            // dateTimePickerURezervaceRezervaceOdCas
            // 
            this.dateTimePickerURezervaceRezervaceOdCas.Checked = false;
            this.dateTimePickerURezervaceRezervaceOdCas.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerURezervaceRezervaceOdCas.Location = new System.Drawing.Point(53, 215);
            this.dateTimePickerURezervaceRezervaceOdCas.Name = "dateTimePickerURezervaceRezervaceOdCas";
            this.dateTimePickerURezervaceRezervaceOdCas.ShowCheckBox = true;
            this.dateTimePickerURezervaceRezervaceOdCas.ShowUpDown = true;
            this.dateTimePickerURezervaceRezervaceOdCas.Size = new System.Drawing.Size(101, 24);
            this.dateTimePickerURezervaceRezervaceOdCas.TabIndex = 2;
            // 
            // labelURezervaceRezervaceDo
            // 
            this.labelURezervaceRezervaceDo.AutoSize = true;
            this.labelURezervaceRezervaceDo.Location = new System.Drawing.Point(50, 263);
            this.labelURezervaceRezervaceDo.Name = "labelURezervaceRezervaceDo";
            this.labelURezervaceRezervaceDo.Size = new System.Drawing.Size(104, 18);
            this.labelURezervaceRezervaceDo.TabIndex = 0;
            this.labelURezervaceRezervaceDo.Text = "Rezervace do:";
            // 
            // dateTimePickerURezervaceRezervaceDoDatum
            // 
            this.dateTimePickerURezervaceRezervaceDoDatum.Location = new System.Drawing.Point(53, 284);
            this.dateTimePickerURezervaceRezervaceDoDatum.Name = "dateTimePickerURezervaceRezervaceDoDatum";
            this.dateTimePickerURezervaceRezervaceDoDatum.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerURezervaceRezervaceDoDatum.TabIndex = 3;
            // 
            // dateTimePickerURezervaceRezervaceDoCas
            // 
            this.dateTimePickerURezervaceRezervaceDoCas.Checked = false;
            this.dateTimePickerURezervaceRezervaceDoCas.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerURezervaceRezervaceDoCas.Location = new System.Drawing.Point(53, 321);
            this.dateTimePickerURezervaceRezervaceDoCas.Name = "dateTimePickerURezervaceRezervaceDoCas";
            this.dateTimePickerURezervaceRezervaceDoCas.ShowCheckBox = true;
            this.dateTimePickerURezervaceRezervaceDoCas.ShowUpDown = true;
            this.dateTimePickerURezervaceRezervaceDoCas.Size = new System.Drawing.Size(101, 24);
            this.dateTimePickerURezervaceRezervaceDoCas.TabIndex = 4;
            // 
            // labelURezervaceVozidlo
            // 
            this.labelURezervaceVozidlo.AutoSize = true;
            this.labelURezervaceVozidlo.Location = new System.Drawing.Point(278, 159);
            this.labelURezervaceVozidlo.Name = "labelURezervaceVozidlo";
            this.labelURezervaceVozidlo.Size = new System.Drawing.Size(61, 18);
            this.labelURezervaceVozidlo.TabIndex = 0;
            this.labelURezervaceVozidlo.Text = "Vozidlo:";
            // 
            // listBoxURezervaceSeznamAutomobilu
            // 
            this.listBoxURezervaceSeznamAutomobilu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxURezervaceSeznamAutomobilu.FormattingEnabled = true;
            this.listBoxURezervaceSeznamAutomobilu.ItemHeight = 18;
            this.listBoxURezervaceSeznamAutomobilu.Location = new System.Drawing.Point(281, 185);
            this.listBoxURezervaceSeznamAutomobilu.MinimumSize = new System.Drawing.Size(300, 4);
            this.listBoxURezervaceSeznamAutomobilu.Name = "listBoxURezervaceSeznamAutomobilu";
            this.listBoxURezervaceSeznamAutomobilu.Size = new System.Drawing.Size(300, 256);
            this.listBoxURezervaceSeznamAutomobilu.TabIndex = 5;
            // 
            // labelURezervaceObsazeneTerminy
            // 
            this.labelURezervaceObsazeneTerminy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelURezervaceObsazeneTerminy.AutoSize = true;
            this.labelURezervaceObsazeneTerminy.Location = new System.Drawing.Point(604, 159);
            this.labelURezervaceObsazeneTerminy.Name = "labelURezervaceObsazeneTerminy";
            this.labelURezervaceObsazeneTerminy.Size = new System.Drawing.Size(152, 18);
            this.labelURezervaceObsazeneTerminy.TabIndex = 0;
            this.labelURezervaceObsazeneTerminy.Text = "Již obsazené termíny:";
            // 
            // listBoxURezervaceSeznamObsazenychTerminu
            // 
            this.listBoxURezervaceSeznamObsazenychTerminu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxURezervaceSeznamObsazenychTerminu.FormattingEnabled = true;
            this.listBoxURezervaceSeznamObsazenychTerminu.ItemHeight = 18;
            this.listBoxURezervaceSeznamObsazenychTerminu.Location = new System.Drawing.Point(607, 185);
            this.listBoxURezervaceSeznamObsazenychTerminu.MinimumSize = new System.Drawing.Size(300, 4);
            this.listBoxURezervaceSeznamObsazenychTerminu.Name = "listBoxURezervaceSeznamObsazenychTerminu";
            this.listBoxURezervaceSeznamObsazenychTerminu.Size = new System.Drawing.Size(300, 256);
            this.listBoxURezervaceSeznamObsazenychTerminu.TabIndex = 6;
            // 
            // buttonURezervaceZrusitRezervaci
            // 
            this.buttonURezervaceZrusitRezervaci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonURezervaceZrusitRezervaci.Location = new System.Drawing.Point(425, 456);
            this.buttonURezervaceZrusitRezervaci.Name = "buttonURezervaceZrusitRezervaci";
            this.buttonURezervaceZrusitRezervaci.Size = new System.Drawing.Size(75, 25);
            this.buttonURezervaceZrusitRezervaci.TabIndex = 8;
            this.buttonURezervaceZrusitRezervaci.Text = "Zrušit";
            this.buttonURezervaceZrusitRezervaci.UseVisualStyleBackColor = true;
            // 
            // buttonURezervacePotvrditRezervaci
            // 
            this.buttonURezervacePotvrditRezervaci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonURezervacePotvrditRezervaci.Location = new System.Drawing.Point(506, 456);
            this.buttonURezervacePotvrditRezervaci.Name = "buttonURezervacePotvrditRezervaci";
            this.buttonURezervacePotvrditRezervaci.Size = new System.Drawing.Size(75, 25);
            this.buttonURezervacePotvrditRezervaci.TabIndex = 7;
            this.buttonURezervacePotvrditRezervaci.Text = "Potvrdit";
            this.buttonURezervacePotvrditRezervaci.UseVisualStyleBackColor = true;
            // 
            // panelAdminHome
            // 
            this.panelAdminHome.Controls.Add(this.labelAHomeRezervaciVSystemu);
            this.panelAdminHome.Controls.Add(this.labelAHomeCelkemVozidel);
            this.panelAdminHome.Controls.Add(this.labelAHomeUzivateluVSystemu);
            this.panelAdminHome.Controls.Add(this.labelAHomeSpravaSystemu);
            this.panelAdminHome.Controls.Add(this.buttonAHomeSpravaVozidel);
            this.panelAdminHome.Controls.Add(this.buttonAHomeSpravaUzivatelu);
            this.panelAdminHome.Controls.Add(this.buttonAHomeSpravaRezervaci);
            this.panelAdminHome.Controls.Add(this.buttonAHomeOdhlasitAdmina);
            this.panelAdminHome.Controls.Add(this.buttonAHomeZmenaHeslaAdmina);
            this.panelAdminHome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdminHome.Location = new System.Drawing.Point(0, 0);
            this.panelAdminHome.Name = "panelAdminHome";
            this.panelAdminHome.Size = new System.Drawing.Size(984, 561);
            this.panelAdminHome.TabIndex = 0;
            this.panelAdminHome.Visible = false;
            // 
            // labelAHomeRezervaciVSystemu
            // 
            this.labelAHomeRezervaciVSystemu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAHomeRezervaciVSystemu.AutoSize = true;
            this.labelAHomeRezervaciVSystemu.Location = new System.Drawing.Point(281, 295);
            this.labelAHomeRezervaciVSystemu.Name = "labelAHomeRezervaciVSystemu";
            this.labelAHomeRezervaciVSystemu.Size = new System.Drawing.Size(149, 18);
            this.labelAHomeRezervaciVSystemu.TabIndex = 0;
            this.labelAHomeRezervaciVSystemu.Text = "Rezervací v systému:";
            // 
            // labelAHomeCelkemVozidel
            // 
            this.labelAHomeCelkemVozidel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAHomeCelkemVozidel.AutoSize = true;
            this.labelAHomeCelkemVozidel.Location = new System.Drawing.Point(281, 249);
            this.labelAHomeCelkemVozidel.Name = "labelAHomeCelkemVozidel";
            this.labelAHomeCelkemVozidel.Size = new System.Drawing.Size(131, 18);
            this.labelAHomeCelkemVozidel.TabIndex = 0;
            this.labelAHomeCelkemVozidel.Text = "Vozidel v systému:";
            // 
            // labelAHomeUzivateluVSystemu
            // 
            this.labelAHomeUzivateluVSystemu.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelAHomeUzivateluVSystemu.AutoSize = true;
            this.labelAHomeUzivateluVSystemu.Location = new System.Drawing.Point(281, 207);
            this.labelAHomeUzivateluVSystemu.Name = "labelAHomeUzivateluVSystemu";
            this.labelAHomeUzivateluVSystemu.Size = new System.Drawing.Size(143, 18);
            this.labelAHomeUzivateluVSystemu.TabIndex = 0;
            this.labelAHomeUzivateluVSystemu.Text = "Uživatelů v systému:";
            // 
            // labelAHomeSpravaSystemu
            // 
            this.labelAHomeSpravaSystemu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelAHomeSpravaSystemu.AutoSize = true;
            this.labelAHomeSpravaSystemu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAHomeSpravaSystemu.Location = new System.Drawing.Point(340, 80);
            this.labelAHomeSpravaSystemu.Name = "labelAHomeSpravaSystemu";
            this.labelAHomeSpravaSystemu.Size = new System.Drawing.Size(245, 37);
            this.labelAHomeSpravaSystemu.TabIndex = 0;
            this.labelAHomeSpravaSystemu.Text = "Správa systému";
            // 
            // buttonAHomeSpravaVozidel
            // 
            this.buttonAHomeSpravaVozidel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAHomeSpravaVozidel.Location = new System.Drawing.Point(501, 246);
            this.buttonAHomeSpravaVozidel.Name = "buttonAHomeSpravaVozidel";
            this.buttonAHomeSpravaVozidel.Size = new System.Drawing.Size(130, 25);
            this.buttonAHomeSpravaVozidel.TabIndex = 2;
            this.buttonAHomeSpravaVozidel.Text = "Správa vozidel";
            this.buttonAHomeSpravaVozidel.UseVisualStyleBackColor = true;
            // 
            // buttonAHomeSpravaUzivatelu
            // 
            this.buttonAHomeSpravaUzivatelu.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAHomeSpravaUzivatelu.Location = new System.Drawing.Point(501, 204);
            this.buttonAHomeSpravaUzivatelu.Name = "buttonAHomeSpravaUzivatelu";
            this.buttonAHomeSpravaUzivatelu.Size = new System.Drawing.Size(130, 25);
            this.buttonAHomeSpravaUzivatelu.TabIndex = 1;
            this.buttonAHomeSpravaUzivatelu.Text = "Správa uživatelů";
            this.buttonAHomeSpravaUzivatelu.UseVisualStyleBackColor = true;
            // 
            // buttonAHomeSpravaRezervaci
            // 
            this.buttonAHomeSpravaRezervaci.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonAHomeSpravaRezervaci.Location = new System.Drawing.Point(501, 292);
            this.buttonAHomeSpravaRezervaci.Name = "buttonAHomeSpravaRezervaci";
            this.buttonAHomeSpravaRezervaci.Size = new System.Drawing.Size(130, 25);
            this.buttonAHomeSpravaRezervaci.TabIndex = 3;
            this.buttonAHomeSpravaRezervaci.Text = "Správa rezervací";
            this.buttonAHomeSpravaRezervaci.UseVisualStyleBackColor = true;
            // 
            // buttonAHomeOdhlasitAdmina
            // 
            this.buttonAHomeOdhlasitAdmina.Location = new System.Drawing.Point(12, 12);
            this.buttonAHomeOdhlasitAdmina.Name = "buttonAHomeOdhlasitAdmina";
            this.buttonAHomeOdhlasitAdmina.Size = new System.Drawing.Size(105, 25);
            this.buttonAHomeOdhlasitAdmina.TabIndex = 4;
            this.buttonAHomeOdhlasitAdmina.Text = "Odhlásit se";
            this.buttonAHomeOdhlasitAdmina.UseVisualStyleBackColor = true;
            // 
            // buttonAHomeZmenaHeslaAdmina
            // 
            this.buttonAHomeZmenaHeslaAdmina.Location = new System.Drawing.Point(12, 43);
            this.buttonAHomeZmenaHeslaAdmina.Name = "buttonAHomeZmenaHeslaAdmina";
            this.buttonAHomeZmenaHeslaAdmina.Size = new System.Drawing.Size(105, 25);
            this.buttonAHomeZmenaHeslaAdmina.TabIndex = 5;
            this.buttonAHomeZmenaHeslaAdmina.Text = "Změnit heslo";
            this.buttonAHomeZmenaHeslaAdmina.UseVisualStyleBackColor = true;
            // 
            // labelPosledniPrihlaseni
            // 
            this.labelPosledniPrihlaseni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPosledniPrihlaseni.AutoSize = true;
            this.labelPosledniPrihlaseni.Location = new System.Drawing.Point(700, 10);
            this.labelPosledniPrihlaseni.Name = "labelPosledniPrihlaseni";
            this.labelPosledniPrihlaseni.Size = new System.Drawing.Size(145, 18);
            this.labelPosledniPrihlaseni.TabIndex = 0;
            this.labelPosledniPrihlaseni.Text = "Naposledy přihlášen:";
            this.labelPosledniPrihlaseni.Visible = false;
            // 
            // panelSpravaUzivatelu
            // 
            this.panelSpravaUzivatelu.Controls.Add(this.buttonUzivateleZpet);
            this.panelSpravaUzivatelu.Controls.Add(this.labelUzivateleSpravaUzivatelu);
            this.panelSpravaUzivatelu.Controls.Add(this.labelUzivateleSeznamUzivatelu);
            this.panelSpravaUzivatelu.Controls.Add(this.listBoxUzivateleSeznamUzivatelu);
            this.panelSpravaUzivatelu.Controls.Add(this.buttonUzivateleUpravitUzivatele);
            this.panelSpravaUzivatelu.Controls.Add(this.buttonUzivatelePridatUzivatele);
            this.panelSpravaUzivatelu.Controls.Add(this.buttonUzivateleOdebratUzivatele);
            this.panelSpravaUzivatelu.Controls.Add(this.labelUzivateleNaposledyPrihlasen);
            this.panelSpravaUzivatelu.Controls.Add(this.labelUzivateleJmeno);
            this.panelSpravaUzivatelu.Controls.Add(this.textBoxUzivateleJmeno);
            this.panelSpravaUzivatelu.Controls.Add(this.labelUzivatelePrijmeni);
            this.panelSpravaUzivatelu.Controls.Add(this.textBoxUzivatelePrijmeni);
            this.panelSpravaUzivatelu.Controls.Add(this.labelUzivateleJmenoUzivatele);
            this.panelSpravaUzivatelu.Controls.Add(this.textBoxUzivateleJmenoUzivatele);
            this.panelSpravaUzivatelu.Controls.Add(this.checkBoxUzivateleVynutitZmenuHesla);
            this.panelSpravaUzivatelu.Controls.Add(this.buttonUzivateleZrusitUzivatele);
            this.panelSpravaUzivatelu.Controls.Add(this.buttonUzivatelePotvrditUzivatele);
            this.panelSpravaUzivatelu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSpravaUzivatelu.Location = new System.Drawing.Point(0, 0);
            this.panelSpravaUzivatelu.Name = "panelSpravaUzivatelu";
            this.panelSpravaUzivatelu.Size = new System.Drawing.Size(984, 561);
            this.panelSpravaUzivatelu.TabIndex = 0;
            this.panelSpravaUzivatelu.Visible = false;
            // 
            // buttonUzivateleZpet
            // 
            this.buttonUzivateleZpet.Location = new System.Drawing.Point(12, 12);
            this.buttonUzivateleZpet.Name = "buttonUzivateleZpet";
            this.buttonUzivateleZpet.Size = new System.Drawing.Size(75, 25);
            this.buttonUzivateleZpet.TabIndex = 11;
            this.buttonUzivateleZpet.Text = "Zpět";
            this.buttonUzivateleZpet.UseVisualStyleBackColor = true;
            // 
            // labelUzivateleSpravaUzivatelu
            // 
            this.labelUzivateleSpravaUzivatelu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelUzivateleSpravaUzivatelu.AutoSize = true;
            this.labelUzivateleSpravaUzivatelu.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUzivateleSpravaUzivatelu.Location = new System.Drawing.Point(341, 43);
            this.labelUzivateleSpravaUzivatelu.Name = "labelUzivateleSpravaUzivatelu";
            this.labelUzivateleSpravaUzivatelu.Size = new System.Drawing.Size(252, 37);
            this.labelUzivateleSpravaUzivatelu.TabIndex = 0;
            this.labelUzivateleSpravaUzivatelu.Text = "Správa uživatelů";
            // 
            // labelUzivateleSeznamUzivatelu
            // 
            this.labelUzivateleSeznamUzivatelu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUzivateleSeznamUzivatelu.AutoSize = true;
            this.labelUzivateleSeznamUzivatelu.Location = new System.Drawing.Point(159, 159);
            this.labelUzivateleSeznamUzivatelu.Name = "labelUzivateleSeznamUzivatelu";
            this.labelUzivateleSeznamUzivatelu.Size = new System.Drawing.Size(128, 18);
            this.labelUzivateleSeznamUzivatelu.TabIndex = 0;
            this.labelUzivateleSeznamUzivatelu.Text = "Seznam uživatelů:";
            // 
            // listBoxUzivateleSeznamUzivatelu
            // 
            this.listBoxUzivateleSeznamUzivatelu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxUzivateleSeznamUzivatelu.FormattingEnabled = true;
            this.listBoxUzivateleSeznamUzivatelu.ItemHeight = 18;
            this.listBoxUzivateleSeznamUzivatelu.Location = new System.Drawing.Point(162, 185);
            this.listBoxUzivateleSeznamUzivatelu.Name = "listBoxUzivateleSeznamUzivatelu";
            this.listBoxUzivateleSeznamUzivatelu.Size = new System.Drawing.Size(277, 292);
            this.listBoxUzivateleSeznamUzivatelu.TabIndex = 1;
            this.listBoxUzivateleSeznamUzivatelu.SelectedIndexChanged += new System.EventHandler(this.ListBoxUzivateleSeznamUzivatelu_SelectedIndexChanged);
            // 
            // buttonUzivateleUpravitUzivatele
            // 
            this.buttonUzivateleUpravitUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUzivateleUpravitUzivatele.Enabled = false;
            this.buttonUzivateleUpravitUzivatele.Location = new System.Drawing.Point(162, 483);
            this.buttonUzivateleUpravitUzivatele.Name = "buttonUzivateleUpravitUzivatele";
            this.buttonUzivateleUpravitUzivatele.Size = new System.Drawing.Size(135, 25);
            this.buttonUzivateleUpravitUzivatele.TabIndex = 3;
            this.buttonUzivateleUpravitUzivatele.Text = "Upravit uživatele";
            this.buttonUzivateleUpravitUzivatele.UseVisualStyleBackColor = true;
            this.buttonUzivateleUpravitUzivatele.Click += new System.EventHandler(this.UzivateleOdemknoutZamknoutOvladani);
            // 
            // buttonUzivatelePridatUzivatele
            // 
            this.buttonUzivatelePridatUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUzivatelePridatUzivatele.Location = new System.Drawing.Point(304, 483);
            this.buttonUzivatelePridatUzivatele.Name = "buttonUzivatelePridatUzivatele";
            this.buttonUzivatelePridatUzivatele.Size = new System.Drawing.Size(135, 25);
            this.buttonUzivatelePridatUzivatele.TabIndex = 2;
            this.buttonUzivatelePridatUzivatele.Text = "Přidat uživatele";
            this.buttonUzivatelePridatUzivatele.UseVisualStyleBackColor = true;
            this.buttonUzivatelePridatUzivatele.Click += new System.EventHandler(this.UzivateleOdemknoutZamknoutOvladani);
            // 
            // buttonUzivateleOdebratUzivatele
            // 
            this.buttonUzivateleOdebratUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUzivateleOdebratUzivatele.Enabled = false;
            this.buttonUzivateleOdebratUzivatele.Location = new System.Drawing.Point(162, 514);
            this.buttonUzivateleOdebratUzivatele.Name = "buttonUzivateleOdebratUzivatele";
            this.buttonUzivateleOdebratUzivatele.Size = new System.Drawing.Size(135, 25);
            this.buttonUzivateleOdebratUzivatele.TabIndex = 4;
            this.buttonUzivateleOdebratUzivatele.Text = "Odebrat uživatele";
            this.buttonUzivateleOdebratUzivatele.UseVisualStyleBackColor = true;
            this.buttonUzivateleOdebratUzivatele.Click += new System.EventHandler(this.ButtonUzivateleOdebratUzivatele_Click);
            // 
            // labelUzivateleNaposledyPrihlasen
            // 
            this.labelUzivateleNaposledyPrihlasen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUzivateleNaposledyPrihlasen.AutoSize = true;
            this.labelUzivateleNaposledyPrihlasen.Location = new System.Drawing.Point(603, 191);
            this.labelUzivateleNaposledyPrihlasen.Name = "labelUzivateleNaposledyPrihlasen";
            this.labelUzivateleNaposledyPrihlasen.Size = new System.Drawing.Size(145, 18);
            this.labelUzivateleNaposledyPrihlasen.TabIndex = 0;
            this.labelUzivateleNaposledyPrihlasen.Text = "Naposledy přihlášen:";
            // 
            // labelUzivateleJmeno
            // 
            this.labelUzivateleJmeno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUzivateleJmeno.AutoSize = true;
            this.labelUzivateleJmeno.Location = new System.Drawing.Point(603, 220);
            this.labelUzivateleJmeno.Name = "labelUzivateleJmeno";
            this.labelUzivateleJmeno.Size = new System.Drawing.Size(58, 18);
            this.labelUzivateleJmeno.TabIndex = 0;
            this.labelUzivateleJmeno.Text = "Jméno:";
            // 
            // textBoxUzivateleJmeno
            // 
            this.textBoxUzivateleJmeno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUzivateleJmeno.Enabled = false;
            this.textBoxUzivateleJmeno.Location = new System.Drawing.Point(673, 217);
            this.textBoxUzivateleJmeno.MaxLength = 64;
            this.textBoxUzivateleJmeno.Name = "textBoxUzivateleJmeno";
            this.textBoxUzivateleJmeno.Size = new System.Drawing.Size(170, 24);
            this.textBoxUzivateleJmeno.TabIndex = 5;
            this.textBoxUzivateleJmeno.TextChanged += new System.EventHandler(this.UzivateleGeneratorUzivatelskehoJmena);
            // 
            // labelUzivatelePrijmeni
            // 
            this.labelUzivatelePrijmeni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUzivatelePrijmeni.AutoSize = true;
            this.labelUzivatelePrijmeni.Location = new System.Drawing.Point(596, 250);
            this.labelUzivatelePrijmeni.Name = "labelUzivatelePrijmeni";
            this.labelUzivatelePrijmeni.Size = new System.Drawing.Size(65, 18);
            this.labelUzivatelePrijmeni.TabIndex = 0;
            this.labelUzivatelePrijmeni.Text = "Příjmení:";
            // 
            // textBoxUzivatelePrijmeni
            // 
            this.textBoxUzivatelePrijmeni.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUzivatelePrijmeni.Enabled = false;
            this.textBoxUzivatelePrijmeni.Location = new System.Drawing.Point(673, 247);
            this.textBoxUzivatelePrijmeni.MaxLength = 64;
            this.textBoxUzivatelePrijmeni.Name = "textBoxUzivatelePrijmeni";
            this.textBoxUzivatelePrijmeni.Size = new System.Drawing.Size(170, 24);
            this.textBoxUzivatelePrijmeni.TabIndex = 6;
            this.textBoxUzivatelePrijmeni.TextChanged += new System.EventHandler(this.UzivateleGeneratorUzivatelskehoJmena);
            // 
            // labelUzivateleJmenoUzivatele
            // 
            this.labelUzivateleJmenoUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelUzivateleJmenoUzivatele.AutoSize = true;
            this.labelUzivateleJmenoUzivatele.Location = new System.Drawing.Point(528, 280);
            this.labelUzivateleJmenoUzivatele.Name = "labelUzivateleJmenoUzivatele";
            this.labelUzivateleJmenoUzivatele.Size = new System.Drawing.Size(133, 18);
            this.labelUzivateleJmenoUzivatele.TabIndex = 0;
            this.labelUzivateleJmenoUzivatele.Text = "Uživatelské jméno:";
            // 
            // textBoxUzivateleJmenoUzivatele
            // 
            this.textBoxUzivateleJmenoUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUzivateleJmenoUzivatele.Enabled = false;
            this.textBoxUzivateleJmenoUzivatele.Location = new System.Drawing.Point(673, 277);
            this.textBoxUzivateleJmenoUzivatele.MaxLength = 64;
            this.textBoxUzivateleJmenoUzivatele.Name = "textBoxUzivateleJmenoUzivatele";
            this.textBoxUzivateleJmenoUzivatele.Size = new System.Drawing.Size(170, 24);
            this.textBoxUzivateleJmenoUzivatele.TabIndex = 7;
            // 
            // checkBoxUzivateleVynutitZmenuHesla
            // 
            this.checkBoxUzivateleVynutitZmenuHesla.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxUzivateleVynutitZmenuHesla.AutoSize = true;
            this.checkBoxUzivateleVynutitZmenuHesla.Enabled = false;
            this.checkBoxUzivateleVynutitZmenuHesla.Location = new System.Drawing.Point(673, 316);
            this.checkBoxUzivateleVynutitZmenuHesla.Name = "checkBoxUzivateleVynutitZmenuHesla";
            this.checkBoxUzivateleVynutitZmenuHesla.Size = new System.Drawing.Size(158, 22);
            this.checkBoxUzivateleVynutitZmenuHesla.TabIndex = 8;
            this.checkBoxUzivateleVynutitZmenuHesla.Text = "Vynutit změnu hesla";
            this.checkBoxUzivateleVynutitZmenuHesla.UseVisualStyleBackColor = true;
            // 
            // buttonUzivateleZrusitUzivatele
            // 
            this.buttonUzivateleZrusitUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUzivateleZrusitUzivatele.Enabled = false;
            this.buttonUzivateleZrusitUzivatele.Location = new System.Drawing.Point(690, 386);
            this.buttonUzivateleZrusitUzivatele.Name = "buttonUzivateleZrusitUzivatele";
            this.buttonUzivateleZrusitUzivatele.Size = new System.Drawing.Size(75, 25);
            this.buttonUzivateleZrusitUzivatele.TabIndex = 10;
            this.buttonUzivateleZrusitUzivatele.Text = "Zrušit";
            this.buttonUzivateleZrusitUzivatele.UseVisualStyleBackColor = true;
            this.buttonUzivateleZrusitUzivatele.Click += new System.EventHandler(this.ButtonUzivateleZrusitUzivatele_Click);
            // 
            // buttonUzivatelePotvrditUzivatele
            // 
            this.buttonUzivatelePotvrditUzivatele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUzivatelePotvrditUzivatele.Enabled = false;
            this.buttonUzivatelePotvrditUzivatele.Location = new System.Drawing.Point(771, 386);
            this.buttonUzivatelePotvrditUzivatele.Name = "buttonUzivatelePotvrditUzivatele";
            this.buttonUzivatelePotvrditUzivatele.Size = new System.Drawing.Size(75, 25);
            this.buttonUzivatelePotvrditUzivatele.TabIndex = 9;
            this.buttonUzivatelePotvrditUzivatele.Text = "Potvrdit";
            this.buttonUzivatelePotvrditUzivatele.UseVisualStyleBackColor = true;
            this.buttonUzivatelePotvrditUzivatele.Click += new System.EventHandler(this.ButtonUzivatelePotvrditUzivatele_Click);
            // 
            // panelSpravaVozidel
            // 
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaZpet);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaSpravaVozidel);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaSeznamVozidel);
            this.panelSpravaVozidel.Controls.Add(this.treeViewVozidlaSeznamVozidel);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaUpravitVozidlo);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaPridatVozidlo);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaOdebratVozidlo);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaServisniZaznamy);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaSPZ);
            this.panelSpravaVozidel.Controls.Add(this.textBoxVozidlaSPZ);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaVyrobce);
            this.panelSpravaVozidel.Controls.Add(this.listBoxVozidlaVyrobce);
            this.panelSpravaVozidel.Controls.Add(this.textBoxVozidlaVyrobce);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaPridatVyrobce);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaModel);
            this.panelSpravaVozidel.Controls.Add(this.listBoxVozidlaModel);
            this.panelSpravaVozidel.Controls.Add(this.textBoxVozidlaModel);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaPridatModel);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaTyp);
            this.panelSpravaVozidel.Controls.Add(this.listBoxVozidlaTyp);
            this.panelSpravaVozidel.Controls.Add(this.textBoxVozidlaTyp);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaPridatTyp);
            this.panelSpravaVozidel.Controls.Add(this.labelVozidlaSpotreba);
            this.panelSpravaVozidel.Controls.Add(this.numericUpDownVozidlaSpotreba);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaZrusitVozidlo);
            this.panelSpravaVozidel.Controls.Add(this.buttonVozidlaPotvrditVozidlo);
            this.panelSpravaVozidel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSpravaVozidel.Location = new System.Drawing.Point(0, 0);
            this.panelSpravaVozidel.Name = "panelSpravaVozidel";
            this.panelSpravaVozidel.Size = new System.Drawing.Size(984, 561);
            this.panelSpravaVozidel.TabIndex = 0;
            this.panelSpravaVozidel.Visible = false;
            // 
            // buttonVozidlaZpet
            // 
            this.buttonVozidlaZpet.Location = new System.Drawing.Point(12, 12);
            this.buttonVozidlaZpet.Name = "buttonVozidlaZpet";
            this.buttonVozidlaZpet.Size = new System.Drawing.Size(75, 25);
            this.buttonVozidlaZpet.TabIndex = 19;
            this.buttonVozidlaZpet.Text = "Zpět";
            this.buttonVozidlaZpet.UseVisualStyleBackColor = true;
            // 
            // labelVozidlaSpravaVozidel
            // 
            this.labelVozidlaSpravaVozidel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelVozidlaSpravaVozidel.AutoSize = true;
            this.labelVozidlaSpravaVozidel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelVozidlaSpravaVozidel.Location = new System.Drawing.Point(341, 43);
            this.labelVozidlaSpravaVozidel.Name = "labelVozidlaSpravaVozidel";
            this.labelVozidlaSpravaVozidel.Size = new System.Drawing.Size(225, 37);
            this.labelVozidlaSpravaVozidel.TabIndex = 0;
            this.labelVozidlaSpravaVozidel.Text = "Správa vozidel";
            // 
            // labelVozidlaSeznamVozidel
            // 
            this.labelVozidlaSeznamVozidel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVozidlaSeznamVozidel.AutoSize = true;
            this.labelVozidlaSeznamVozidel.Location = new System.Drawing.Point(103, 147);
            this.labelVozidlaSeznamVozidel.Name = "labelVozidlaSeznamVozidel";
            this.labelVozidlaSeznamVozidel.Size = new System.Drawing.Size(117, 18);
            this.labelVozidlaSeznamVozidel.TabIndex = 0;
            this.labelVozidlaSeznamVozidel.Text = "Seznam vozidel:";
            // 
            // treeViewVozidlaSeznamVozidel
            // 
            this.treeViewVozidlaSeznamVozidel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.treeViewVozidlaSeznamVozidel.FullRowSelect = true;
            this.treeViewVozidlaSeznamVozidel.HideSelection = false;
            this.treeViewVozidlaSeznamVozidel.Location = new System.Drawing.Point(106, 173);
            this.treeViewVozidlaSeznamVozidel.Name = "treeViewVozidlaSeznamVozidel";
            this.treeViewVozidlaSeznamVozidel.Size = new System.Drawing.Size(277, 292);
            this.treeViewVozidlaSeznamVozidel.TabIndex = 1;
            this.treeViewVozidlaSeznamVozidel.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewVozidlaSeznamVozidel_AfterSelect);
            // 
            // buttonVozidlaUpravitVozidlo
            // 
            this.buttonVozidlaUpravitVozidlo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaUpravitVozidlo.Enabled = false;
            this.buttonVozidlaUpravitVozidlo.Location = new System.Drawing.Point(106, 478);
            this.buttonVozidlaUpravitVozidlo.Name = "buttonVozidlaUpravitVozidlo";
            this.buttonVozidlaUpravitVozidlo.Size = new System.Drawing.Size(135, 25);
            this.buttonVozidlaUpravitVozidlo.TabIndex = 3;
            this.buttonVozidlaUpravitVozidlo.Text = "Upravit vozidlo";
            this.buttonVozidlaUpravitVozidlo.UseVisualStyleBackColor = true;
            this.buttonVozidlaUpravitVozidlo.Click += new System.EventHandler(this.VozidlaOdemknoutZamknoutOvladani);
            // 
            // buttonVozidlaPridatVozidlo
            // 
            this.buttonVozidlaPridatVozidlo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaPridatVozidlo.Location = new System.Drawing.Point(248, 478);
            this.buttonVozidlaPridatVozidlo.Name = "buttonVozidlaPridatVozidlo";
            this.buttonVozidlaPridatVozidlo.Size = new System.Drawing.Size(135, 25);
            this.buttonVozidlaPridatVozidlo.TabIndex = 2;
            this.buttonVozidlaPridatVozidlo.Text = "Přidat vozidlo";
            this.buttonVozidlaPridatVozidlo.UseVisualStyleBackColor = true;
            this.buttonVozidlaPridatVozidlo.Click += new System.EventHandler(this.VozidlaOdemknoutZamknoutOvladani);
            // 
            // buttonVozidlaOdebratVozidlo
            // 
            this.buttonVozidlaOdebratVozidlo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaOdebratVozidlo.Enabled = false;
            this.buttonVozidlaOdebratVozidlo.Location = new System.Drawing.Point(106, 509);
            this.buttonVozidlaOdebratVozidlo.Name = "buttonVozidlaOdebratVozidlo";
            this.buttonVozidlaOdebratVozidlo.Size = new System.Drawing.Size(135, 25);
            this.buttonVozidlaOdebratVozidlo.TabIndex = 5;
            this.buttonVozidlaOdebratVozidlo.Text = "Odebrat vozidlo";
            this.buttonVozidlaOdebratVozidlo.UseVisualStyleBackColor = true;
            this.buttonVozidlaOdebratVozidlo.Click += new System.EventHandler(this.ButtonVozidlaOdebratVozidlo_Click);
            // 
            // buttonVozidlaServisniZaznamy
            // 
            this.buttonVozidlaServisniZaznamy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaServisniZaznamy.Enabled = false;
            this.buttonVozidlaServisniZaznamy.Location = new System.Drawing.Point(248, 509);
            this.buttonVozidlaServisniZaznamy.Name = "buttonVozidlaServisniZaznamy";
            this.buttonVozidlaServisniZaznamy.Size = new System.Drawing.Size(135, 25);
            this.buttonVozidlaServisniZaznamy.TabIndex = 4;
            this.buttonVozidlaServisniZaznamy.Text = "Servisní záznamy";
            this.buttonVozidlaServisniZaznamy.UseVisualStyleBackColor = true;
            // 
            // labelVozidlaSPZ
            // 
            this.labelVozidlaSPZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVozidlaSPZ.AutoSize = true;
            this.labelVozidlaSPZ.Location = new System.Drawing.Point(550, 147);
            this.labelVozidlaSPZ.Name = "labelVozidlaSPZ";
            this.labelVozidlaSPZ.Size = new System.Drawing.Size(41, 18);
            this.labelVozidlaSPZ.TabIndex = 0;
            this.labelVozidlaSPZ.Text = "SPZ:";
            // 
            // textBoxVozidlaSPZ
            // 
            this.textBoxVozidlaSPZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVozidlaSPZ.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxVozidlaSPZ.Enabled = false;
            this.textBoxVozidlaSPZ.Location = new System.Drawing.Point(595, 144);
            this.textBoxVozidlaSPZ.MaxLength = 8;
            this.textBoxVozidlaSPZ.Name = "textBoxVozidlaSPZ";
            this.textBoxVozidlaSPZ.Size = new System.Drawing.Size(170, 24);
            this.textBoxVozidlaSPZ.TabIndex = 16;
            this.textBoxVozidlaSPZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVozidlaSPZ_KeyPress);
            // 
            // labelVozidlaVyrobce
            // 
            this.labelVozidlaVyrobce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVozidlaVyrobce.AutoSize = true;
            this.labelVozidlaVyrobce.Location = new System.Drawing.Point(524, 179);
            this.labelVozidlaVyrobce.Name = "labelVozidlaVyrobce";
            this.labelVozidlaVyrobce.Size = new System.Drawing.Size(66, 18);
            this.labelVozidlaVyrobce.TabIndex = 0;
            this.labelVozidlaVyrobce.Text = "Výrobce:";
            // 
            // listBoxVozidlaVyrobce
            // 
            this.listBoxVozidlaVyrobce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxVozidlaVyrobce.Enabled = false;
            this.listBoxVozidlaVyrobce.FormattingEnabled = true;
            this.listBoxVozidlaVyrobce.ItemHeight = 18;
            this.listBoxVozidlaVyrobce.Location = new System.Drawing.Point(593, 179);
            this.listBoxVozidlaVyrobce.Name = "listBoxVozidlaVyrobce";
            this.listBoxVozidlaVyrobce.Size = new System.Drawing.Size(170, 58);
            this.listBoxVozidlaVyrobce.TabIndex = 7;
            // 
            // textBoxVozidlaVyrobce
            // 
            this.textBoxVozidlaVyrobce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVozidlaVyrobce.Enabled = false;
            this.textBoxVozidlaVyrobce.Location = new System.Drawing.Point(595, 243);
            this.textBoxVozidlaVyrobce.MaxLength = 64;
            this.textBoxVozidlaVyrobce.Name = "textBoxVozidlaVyrobce";
            this.textBoxVozidlaVyrobce.Size = new System.Drawing.Size(170, 24);
            this.textBoxVozidlaVyrobce.TabIndex = 8;
            // 
            // buttonVozidlaPridatVyrobce
            // 
            this.buttonVozidlaPridatVyrobce.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaPridatVyrobce.Enabled = false;
            this.buttonVozidlaPridatVyrobce.Location = new System.Drawing.Point(771, 243);
            this.buttonVozidlaPridatVyrobce.Name = "buttonVozidlaPridatVyrobce";
            this.buttonVozidlaPridatVyrobce.Size = new System.Drawing.Size(75, 25);
            this.buttonVozidlaPridatVyrobce.TabIndex = 9;
            this.buttonVozidlaPridatVyrobce.Text = "Přidat";
            this.buttonVozidlaPridatVyrobce.UseVisualStyleBackColor = true;
            this.buttonVozidlaPridatVyrobce.Click += new System.EventHandler(this.ButtonVozidlaPridatMoznost_Click);
            // 
            // labelVozidlaModel
            // 
            this.labelVozidlaModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVozidlaModel.AutoSize = true;
            this.labelVozidlaModel.Location = new System.Drawing.Point(536, 286);
            this.labelVozidlaModel.Name = "labelVozidlaModel";
            this.labelVozidlaModel.Size = new System.Drawing.Size(53, 18);
            this.labelVozidlaModel.TabIndex = 0;
            this.labelVozidlaModel.Text = "Model:";
            // 
            // listBoxVozidlaModel
            // 
            this.listBoxVozidlaModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxVozidlaModel.Enabled = false;
            this.listBoxVozidlaModel.FormattingEnabled = true;
            this.listBoxVozidlaModel.ItemHeight = 18;
            this.listBoxVozidlaModel.Location = new System.Drawing.Point(593, 281);
            this.listBoxVozidlaModel.Name = "listBoxVozidlaModel";
            this.listBoxVozidlaModel.Size = new System.Drawing.Size(170, 58);
            this.listBoxVozidlaModel.TabIndex = 10;
            // 
            // textBoxVozidlaModel
            // 
            this.textBoxVozidlaModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVozidlaModel.Enabled = false;
            this.textBoxVozidlaModel.Location = new System.Drawing.Point(593, 345);
            this.textBoxVozidlaModel.MaxLength = 64;
            this.textBoxVozidlaModel.Name = "textBoxVozidlaModel";
            this.textBoxVozidlaModel.Size = new System.Drawing.Size(170, 24);
            this.textBoxVozidlaModel.TabIndex = 11;
            // 
            // buttonVozidlaPridatModel
            // 
            this.buttonVozidlaPridatModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaPridatModel.Enabled = false;
            this.buttonVozidlaPridatModel.Location = new System.Drawing.Point(771, 344);
            this.buttonVozidlaPridatModel.Name = "buttonVozidlaPridatModel";
            this.buttonVozidlaPridatModel.Size = new System.Drawing.Size(75, 25);
            this.buttonVozidlaPridatModel.TabIndex = 12;
            this.buttonVozidlaPridatModel.Text = "Přidat";
            this.buttonVozidlaPridatModel.UseVisualStyleBackColor = true;
            this.buttonVozidlaPridatModel.Click += new System.EventHandler(this.ButtonVozidlaPridatMoznost_Click);
            // 
            // labelVozidlaTyp
            // 
            this.labelVozidlaTyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVozidlaTyp.AutoSize = true;
            this.labelVozidlaTyp.Location = new System.Drawing.Point(551, 387);
            this.labelVozidlaTyp.Name = "labelVozidlaTyp";
            this.labelVozidlaTyp.Size = new System.Drawing.Size(36, 18);
            this.labelVozidlaTyp.TabIndex = 0;
            this.labelVozidlaTyp.Text = "Typ:";
            // 
            // listBoxVozidlaTyp
            // 
            this.listBoxVozidlaTyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxVozidlaTyp.Enabled = false;
            this.listBoxVozidlaTyp.FormattingEnabled = true;
            this.listBoxVozidlaTyp.ItemHeight = 18;
            this.listBoxVozidlaTyp.Location = new System.Drawing.Point(593, 384);
            this.listBoxVozidlaTyp.Name = "listBoxVozidlaTyp";
            this.listBoxVozidlaTyp.Size = new System.Drawing.Size(170, 58);
            this.listBoxVozidlaTyp.TabIndex = 13;
            // 
            // textBoxVozidlaTyp
            // 
            this.textBoxVozidlaTyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxVozidlaTyp.Enabled = false;
            this.textBoxVozidlaTyp.Location = new System.Drawing.Point(593, 448);
            this.textBoxVozidlaTyp.MaxLength = 64;
            this.textBoxVozidlaTyp.Name = "textBoxVozidlaTyp";
            this.textBoxVozidlaTyp.Size = new System.Drawing.Size(170, 24);
            this.textBoxVozidlaTyp.TabIndex = 14;
            // 
            // buttonVozidlaPridatTyp
            // 
            this.buttonVozidlaPridatTyp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaPridatTyp.Enabled = false;
            this.buttonVozidlaPridatTyp.Location = new System.Drawing.Point(771, 448);
            this.buttonVozidlaPridatTyp.Name = "buttonVozidlaPridatTyp";
            this.buttonVozidlaPridatTyp.Size = new System.Drawing.Size(75, 25);
            this.buttonVozidlaPridatTyp.TabIndex = 15;
            this.buttonVozidlaPridatTyp.Text = "Přidat";
            this.buttonVozidlaPridatTyp.UseVisualStyleBackColor = true;
            this.buttonVozidlaPridatTyp.Click += new System.EventHandler(this.ButtonVozidlaPridatMoznost_Click);
            // 
            // labelVozidlaSpotreba
            // 
            this.labelVozidlaSpotreba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVozidlaSpotreba.AutoSize = true;
            this.labelVozidlaSpotreba.Location = new System.Drawing.Point(444, 482);
            this.labelVozidlaSpotreba.Name = "labelVozidlaSpotreba";
            this.labelVozidlaSpotreba.Size = new System.Drawing.Size(145, 18);
            this.labelVozidlaSpotreba.TabIndex = 0;
            this.labelVozidlaSpotreba.Text = "Spotřeba na 100 km:";
            // 
            // numericUpDownVozidlaSpotreba
            // 
            this.numericUpDownVozidlaSpotreba.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownVozidlaSpotreba.DecimalPlaces = 2;
            this.numericUpDownVozidlaSpotreba.Enabled = false;
            this.numericUpDownVozidlaSpotreba.Location = new System.Drawing.Point(595, 479);
            this.numericUpDownVozidlaSpotreba.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownVozidlaSpotreba.Name = "numericUpDownVozidlaSpotreba";
            this.numericUpDownVozidlaSpotreba.Size = new System.Drawing.Size(168, 24);
            this.numericUpDownVozidlaSpotreba.TabIndex = 16;
            // 
            // buttonVozidlaZrusitVozidlo
            // 
            this.buttonVozidlaZrusitVozidlo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaZrusitVozidlo.Enabled = false;
            this.buttonVozidlaZrusitVozidlo.Location = new System.Drawing.Point(607, 509);
            this.buttonVozidlaZrusitVozidlo.Name = "buttonVozidlaZrusitVozidlo";
            this.buttonVozidlaZrusitVozidlo.Size = new System.Drawing.Size(75, 25);
            this.buttonVozidlaZrusitVozidlo.TabIndex = 18;
            this.buttonVozidlaZrusitVozidlo.Text = "Zrušit";
            this.buttonVozidlaZrusitVozidlo.UseVisualStyleBackColor = true;
            this.buttonVozidlaZrusitVozidlo.Click += new System.EventHandler(this.ButtonVozidlaZrusitVozidlo_Click);
            // 
            // buttonVozidlaPotvrditVozidlo
            // 
            this.buttonVozidlaPotvrditVozidlo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonVozidlaPotvrditVozidlo.Enabled = false;
            this.buttonVozidlaPotvrditVozidlo.Location = new System.Drawing.Point(688, 509);
            this.buttonVozidlaPotvrditVozidlo.Name = "buttonVozidlaPotvrditVozidlo";
            this.buttonVozidlaPotvrditVozidlo.Size = new System.Drawing.Size(75, 25);
            this.buttonVozidlaPotvrditVozidlo.TabIndex = 17;
            this.buttonVozidlaPotvrditVozidlo.Text = "Potvrdit";
            this.buttonVozidlaPotvrditVozidlo.UseVisualStyleBackColor = true;
            this.buttonVozidlaPotvrditVozidlo.Click += new System.EventHandler(this.ButtonVozidlaPotvrditVozidlo_Click);
            // 
            // panelSpravaRezervaci
            // 
            this.panelSpravaRezervaci.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSpravaRezervaci.Controls.Add(this.treeViewRezervaceSeznamVozidel);
            this.panelSpravaRezervaci.Controls.Add(this.treeViewRezervaceSeznamRezervaci);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervaceZpet);
            this.panelSpravaRezervaci.Controls.Add(this.labelRezervaceRezervaci);
            this.panelSpravaRezervaci.Controls.Add(this.labelRezervaceSeznamRezervaci);
            this.panelSpravaRezervaci.Controls.Add(this.checkBoxRezervaceZobrazitPredchozi);
            this.panelSpravaRezervaci.Controls.Add(this.radioButtonRezervacePodleVozidel);
            this.panelSpravaRezervaci.Controls.Add(this.radioButtonRezervacePodleUzivatelu);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervacePridatRezervaci);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervaceUpravit);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervaceOdebratRezervaci);
            this.panelSpravaRezervaci.Controls.Add(this.labelRezervaceUzivatel);
            this.panelSpravaRezervaci.Controls.Add(this.listBoxRezervaceSeznamUzivatelu);
            this.panelSpravaRezervaci.Controls.Add(this.textBoxRezervaceUzivatel);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervaceHledat);
            this.panelSpravaRezervaci.Controls.Add(this.labeRezervaceVozidlo);
            this.panelSpravaRezervaci.Controls.Add(this.labelRezervaceRezervaceOd);
            this.panelSpravaRezervaci.Controls.Add(this.dateTimePickerRezervaceRezervaceOdDatum);
            this.panelSpravaRezervaci.Controls.Add(this.dateTimePickerRezervaceRezervaceOdCas);
            this.panelSpravaRezervaci.Controls.Add(this.labelRezervaceRezervaceDo);
            this.panelSpravaRezervaci.Controls.Add(this.dateTimePickerRezervaceRezervaceDoDatum);
            this.panelSpravaRezervaci.Controls.Add(this.dateTimePickerRezervaceRezervaceDoCas);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervaceZrusit);
            this.panelSpravaRezervaci.Controls.Add(this.buttonRezervacePotvrdit);
            this.panelSpravaRezervaci.Location = new System.Drawing.Point(0, 0);
            this.panelSpravaRezervaci.Name = "panelSpravaRezervaci";
            this.panelSpravaRezervaci.Size = new System.Drawing.Size(984, 561);
            this.panelSpravaRezervaci.TabIndex = 0;
            this.panelSpravaRezervaci.Visible = false;
            // 
            // treeViewRezervaceSeznamVozidel
            // 
            this.treeViewRezervaceSeznamVozidel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.treeViewRezervaceSeznamVozidel.Enabled = false;
            this.treeViewRezervaceSeznamVozidel.FullRowSelect = true;
            this.treeViewRezervaceSeznamVozidel.HideSelection = false;
            this.treeViewRezervaceSeznamVozidel.Location = new System.Drawing.Point(389, 300);
            this.treeViewRezervaceSeznamVozidel.Name = "treeViewRezervaceSeznamVozidel";
            this.treeViewRezervaceSeznamVozidel.Size = new System.Drawing.Size(277, 220);
            this.treeViewRezervaceSeznamVozidel.TabIndex = 11;
            // 
            // treeViewRezervaceSeznamRezervaci
            // 
            this.treeViewRezervaceSeznamRezervaci.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.treeViewRezervaceSeznamRezervaci.FullRowSelect = true;
            this.treeViewRezervaceSeznamRezervaci.HideSelection = false;
            this.treeViewRezervaceSeznamRezervaci.Location = new System.Drawing.Point(58, 168);
            this.treeViewRezervaceSeznamRezervaci.Name = "treeViewRezervaceSeznamRezervaci";
            this.treeViewRezervaceSeznamRezervaci.Size = new System.Drawing.Size(277, 256);
            this.treeViewRezervaceSeznamRezervaci.TabIndex = 2;
            // 
            // buttonRezervaceZpet
            // 
            this.buttonRezervaceZpet.Location = new System.Drawing.Point(12, 12);
            this.buttonRezervaceZpet.Name = "buttonRezervaceZpet";
            this.buttonRezervaceZpet.Size = new System.Drawing.Size(75, 25);
            this.buttonRezervaceZpet.TabIndex = 15;
            this.buttonRezervaceZpet.Text = "Zpět";
            this.buttonRezervaceZpet.UseVisualStyleBackColor = true;
            // 
            // labelRezervaceRezervaci
            // 
            this.labelRezervaceRezervaci.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelRezervaceRezervaci.AutoSize = true;
            this.labelRezervaceRezervaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRezervaceRezervaci.Location = new System.Drawing.Point(341, 43);
            this.labelRezervaceRezervaci.Name = "labelRezervaceRezervaci";
            this.labelRezervaceRezervaci.Size = new System.Drawing.Size(255, 37);
            this.labelRezervaceRezervaci.TabIndex = 0;
            this.labelRezervaceRezervaci.Text = "Správa rezervací";
            // 
            // labelRezervaceSeznamRezervaci
            // 
            this.labelRezervaceSeznamRezervaci.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRezervaceSeznamRezervaci.AutoSize = true;
            this.labelRezervaceSeznamRezervaci.Location = new System.Drawing.Point(55, 143);
            this.labelRezervaceSeznamRezervaci.Name = "labelRezervaceSeznamRezervaci";
            this.labelRezervaceSeznamRezervaci.Size = new System.Drawing.Size(131, 18);
            this.labelRezervaceSeznamRezervaci.TabIndex = 0;
            this.labelRezervaceSeznamRezervaci.Text = "Seznam rezervací:";
            // 
            // checkBoxRezervaceZobrazitPredchozi
            // 
            this.checkBoxRezervaceZobrazitPredchozi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxRezervaceZobrazitPredchozi.AutoSize = true;
            this.checkBoxRezervaceZobrazitPredchozi.Location = new System.Drawing.Point(192, 142);
            this.checkBoxRezervaceZobrazitPredchozi.Name = "checkBoxRezervaceZobrazitPredchozi";
            this.checkBoxRezervaceZobrazitPredchozi.Size = new System.Drawing.Size(150, 22);
            this.checkBoxRezervaceZobrazitPredchozi.TabIndex = 1;
            this.checkBoxRezervaceZobrazitPredchozi.Text = "Zobrazit předchozí";
            this.checkBoxRezervaceZobrazitPredchozi.UseVisualStyleBackColor = true;
            this.checkBoxRezervaceZobrazitPredchozi.CheckedChanged += new System.EventHandler(this.checkBoxRezervaceZobrazitPredchozi_CheckedChanged);
            // 
            // radioButtonRezervacePodleVozidel
            // 
            this.radioButtonRezervacePodleVozidel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonRezervacePodleVozidel.AutoSize = true;
            this.radioButtonRezervacePodleVozidel.Checked = true;
            this.radioButtonRezervacePodleVozidel.Location = new System.Drawing.Point(58, 435);
            this.radioButtonRezervacePodleVozidel.Name = "radioButtonRezervacePodleVozidel";
            this.radioButtonRezervacePodleVozidel.Size = new System.Drawing.Size(114, 22);
            this.radioButtonRezervacePodleVozidel.TabIndex = 3;
            this.radioButtonRezervacePodleVozidel.TabStop = true;
            this.radioButtonRezervacePodleVozidel.Text = "Podle vozidel";
            this.radioButtonRezervacePodleVozidel.UseVisualStyleBackColor = true;
            // 
            // radioButtonRezervacePodleUzivatelu
            // 
            this.radioButtonRezervacePodleUzivatelu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioButtonRezervacePodleUzivatelu.AutoSize = true;
            this.radioButtonRezervacePodleUzivatelu.Location = new System.Drawing.Point(58, 466);
            this.radioButtonRezervacePodleUzivatelu.Name = "radioButtonRezervacePodleUzivatelu";
            this.radioButtonRezervacePodleUzivatelu.Size = new System.Drawing.Size(125, 22);
            this.radioButtonRezervacePodleUzivatelu.TabIndex = 4;
            this.radioButtonRezervacePodleUzivatelu.Text = "Podle uživatelů";
            this.radioButtonRezervacePodleUzivatelu.UseVisualStyleBackColor = true;
            // 
            // buttonRezervacePridatRezervaci
            // 
            this.buttonRezervacePridatRezervaci.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRezervacePridatRezervaci.Location = new System.Drawing.Point(200, 434);
            this.buttonRezervacePridatRezervaci.Name = "buttonRezervacePridatRezervaci";
            this.buttonRezervacePridatRezervaci.Size = new System.Drawing.Size(135, 25);
            this.buttonRezervacePridatRezervaci.TabIndex = 5;
            this.buttonRezervacePridatRezervaci.Text = "Přidat rezervaci";
            this.buttonRezervacePridatRezervaci.UseVisualStyleBackColor = true;
            this.buttonRezervacePridatRezervaci.Click += new System.EventHandler(this.buttonRezervacePridatRezervaci_Click);
            // 
            // buttonRezervaceUpravit
            // 
            this.buttonRezervaceUpravit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRezervaceUpravit.Enabled = false;
            this.buttonRezervaceUpravit.Location = new System.Drawing.Point(200, 465);
            this.buttonRezervaceUpravit.Name = "buttonRezervaceUpravit";
            this.buttonRezervaceUpravit.Size = new System.Drawing.Size(135, 25);
            this.buttonRezervaceUpravit.TabIndex = 6;
            this.buttonRezervaceUpravit.Text = "Upravit rezervaci";
            this.buttonRezervaceUpravit.UseVisualStyleBackColor = true;
            this.buttonRezervaceUpravit.Click += new System.EventHandler(this.buttonRezervaceUpravit_Click);
            // 
            // buttonRezervaceOdebratRezervaci
            // 
            this.buttonRezervaceOdebratRezervaci.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRezervaceOdebratRezervaci.Enabled = false;
            this.buttonRezervaceOdebratRezervaci.Location = new System.Drawing.Point(200, 496);
            this.buttonRezervaceOdebratRezervaci.Name = "buttonRezervaceOdebratRezervaci";
            this.buttonRezervaceOdebratRezervaci.Size = new System.Drawing.Size(135, 25);
            this.buttonRezervaceOdebratRezervaci.TabIndex = 7;
            this.buttonRezervaceOdebratRezervaci.Text = "Odebrat rezervaci";
            this.buttonRezervaceOdebratRezervaci.UseVisualStyleBackColor = true;
            this.buttonRezervaceOdebratRezervaci.Click += new System.EventHandler(this.buttonRezervaceOdebratRezervaci_Click);
            // 
            // labelRezervaceUzivatel
            // 
            this.labelRezervaceUzivatel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRezervaceUzivatel.AutoSize = true;
            this.labelRezervaceUzivatel.Location = new System.Drawing.Point(386, 108);
            this.labelRezervaceUzivatel.Name = "labelRezervaceUzivatel";
            this.labelRezervaceUzivatel.Size = new System.Drawing.Size(64, 18);
            this.labelRezervaceUzivatel.TabIndex = 0;
            this.labelRezervaceUzivatel.Text = "Uživatel:";
            // 
            // listBoxRezervaceSeznamUzivatelu
            // 
            this.listBoxRezervaceSeznamUzivatelu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxRezervaceSeznamUzivatelu.Enabled = false;
            this.listBoxRezervaceSeznamUzivatelu.FormattingEnabled = true;
            this.listBoxRezervaceSeznamUzivatelu.ItemHeight = 18;
            this.listBoxRezervaceSeznamUzivatelu.Location = new System.Drawing.Point(389, 129);
            this.listBoxRezervaceSeznamUzivatelu.Name = "listBoxRezervaceSeznamUzivatelu";
            this.listBoxRezervaceSeznamUzivatelu.Size = new System.Drawing.Size(277, 94);
            this.listBoxRezervaceSeznamUzivatelu.TabIndex = 8;
            // 
            // textBoxRezervaceUzivatel
            // 
            this.textBoxRezervaceUzivatel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRezervaceUzivatel.Enabled = false;
            this.textBoxRezervaceUzivatel.Location = new System.Drawing.Point(389, 227);
            this.textBoxRezervaceUzivatel.MaxLength = 64;
            this.textBoxRezervaceUzivatel.Name = "textBoxRezervaceUzivatel";
            this.textBoxRezervaceUzivatel.Size = new System.Drawing.Size(198, 24);
            this.textBoxRezervaceUzivatel.TabIndex = 9;
            // 
            // buttonRezervaceHledat
            // 
            this.buttonRezervaceHledat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRezervaceHledat.Enabled = false;
            this.buttonRezervaceHledat.Location = new System.Drawing.Point(591, 227);
            this.buttonRezervaceHledat.Name = "buttonRezervaceHledat";
            this.buttonRezervaceHledat.Size = new System.Drawing.Size(75, 25);
            this.buttonRezervaceHledat.TabIndex = 10;
            this.buttonRezervaceHledat.Text = "Hledat";
            this.buttonRezervaceHledat.UseVisualStyleBackColor = true;
            // 
            // labeRezervaceVozidlo
            // 
            this.labeRezervaceVozidlo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labeRezervaceVozidlo.AutoSize = true;
            this.labeRezervaceVozidlo.Location = new System.Drawing.Point(392, 279);
            this.labeRezervaceVozidlo.Name = "labeRezervaceVozidlo";
            this.labeRezervaceVozidlo.Size = new System.Drawing.Size(61, 18);
            this.labeRezervaceVozidlo.TabIndex = 0;
            this.labeRezervaceVozidlo.Text = "Vozidlo:";
            // 
            // labelRezervaceRezervaceOd
            // 
            this.labelRezervaceRezervaceOd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRezervaceRezervaceOd.AutoSize = true;
            this.labelRezervaceRezervaceOd.Location = new System.Drawing.Point(704, 107);
            this.labelRezervaceRezervaceOd.Name = "labelRezervaceRezervaceOd";
            this.labelRezervaceRezervaceOd.Size = new System.Drawing.Size(104, 18);
            this.labelRezervaceRezervaceOd.TabIndex = 0;
            this.labelRezervaceRezervaceOd.Text = "Rezervace od:";
            // 
            // dateTimePickerRezervaceRezervaceOdDatum
            // 
            this.dateTimePickerRezervaceRezervaceOdDatum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerRezervaceRezervaceOdDatum.Enabled = false;
            this.dateTimePickerRezervaceRezervaceOdDatum.Location = new System.Drawing.Point(707, 128);
            this.dateTimePickerRezervaceRezervaceOdDatum.Name = "dateTimePickerRezervaceRezervaceOdDatum";
            this.dateTimePickerRezervaceRezervaceOdDatum.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerRezervaceRezervaceOdDatum.TabIndex = 12;
            // 
            // dateTimePickerRezervaceRezervaceOdCas
            // 
            this.dateTimePickerRezervaceRezervaceOdCas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerRezervaceRezervaceOdCas.Checked = false;
            this.dateTimePickerRezervaceRezervaceOdCas.Enabled = false;
            this.dateTimePickerRezervaceRezervaceOdCas.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerRezervaceRezervaceOdCas.Location = new System.Drawing.Point(707, 158);
            this.dateTimePickerRezervaceRezervaceOdCas.Name = "dateTimePickerRezervaceRezervaceOdCas";
            this.dateTimePickerRezervaceRezervaceOdCas.ShowCheckBox = true;
            this.dateTimePickerRezervaceRezervaceOdCas.ShowUpDown = true;
            this.dateTimePickerRezervaceRezervaceOdCas.Size = new System.Drawing.Size(101, 24);
            this.dateTimePickerRezervaceRezervaceOdCas.TabIndex = 13;
            // 
            // labelRezervaceRezervaceDo
            // 
            this.labelRezervaceRezervaceDo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRezervaceRezervaceDo.AutoSize = true;
            this.labelRezervaceRezervaceDo.Location = new System.Drawing.Point(704, 206);
            this.labelRezervaceRezervaceDo.Name = "labelRezervaceRezervaceDo";
            this.labelRezervaceRezervaceDo.Size = new System.Drawing.Size(104, 18);
            this.labelRezervaceRezervaceDo.TabIndex = 0;
            this.labelRezervaceRezervaceDo.Text = "Rezervace do:";
            // 
            // dateTimePickerRezervaceRezervaceDoDatum
            // 
            this.dateTimePickerRezervaceRezervaceDoDatum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerRezervaceRezervaceDoDatum.Enabled = false;
            this.dateTimePickerRezervaceRezervaceDoDatum.Location = new System.Drawing.Point(707, 227);
            this.dateTimePickerRezervaceRezervaceDoDatum.Name = "dateTimePickerRezervaceRezervaceDoDatum";
            this.dateTimePickerRezervaceRezervaceDoDatum.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerRezervaceRezervaceDoDatum.TabIndex = 14;
            // 
            // dateTimePickerRezervaceRezervaceDoCas
            // 
            this.dateTimePickerRezervaceRezervaceDoCas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerRezervaceRezervaceDoCas.Checked = false;
            this.dateTimePickerRezervaceRezervaceDoCas.Enabled = false;
            this.dateTimePickerRezervaceRezervaceDoCas.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerRezervaceRezervaceDoCas.Location = new System.Drawing.Point(707, 264);
            this.dateTimePickerRezervaceRezervaceDoCas.Name = "dateTimePickerRezervaceRezervaceDoCas";
            this.dateTimePickerRezervaceRezervaceDoCas.ShowCheckBox = true;
            this.dateTimePickerRezervaceRezervaceDoCas.ShowUpDown = true;
            this.dateTimePickerRezervaceRezervaceDoCas.Size = new System.Drawing.Size(101, 24);
            this.dateTimePickerRezervaceRezervaceDoCas.TabIndex = 15;
            // 
            // buttonRezervaceZrusit
            // 
            this.buttonRezervaceZrusit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRezervaceZrusit.Enabled = false;
            this.buttonRezervaceZrusit.Location = new System.Drawing.Point(707, 304);
            this.buttonRezervaceZrusit.Name = "buttonRezervaceZrusit";
            this.buttonRezervaceZrusit.Size = new System.Drawing.Size(75, 25);
            this.buttonRezervaceZrusit.TabIndex = 17;
            this.buttonRezervaceZrusit.Text = "Zrušit";
            this.buttonRezervaceZrusit.UseVisualStyleBackColor = true;
            this.buttonRezervaceZrusit.Click += new System.EventHandler(this.buttonRezervaceZrusit_Click);
            // 
            // buttonRezervacePotvrdit
            // 
            this.buttonRezervacePotvrdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRezervacePotvrdit.Enabled = false;
            this.buttonRezervacePotvrdit.Location = new System.Drawing.Point(788, 304);
            this.buttonRezervacePotvrdit.Name = "buttonRezervacePotvrdit";
            this.buttonRezervacePotvrdit.Size = new System.Drawing.Size(75, 25);
            this.buttonRezervacePotvrdit.TabIndex = 16;
            this.buttonRezervacePotvrdit.Text = "Potvrdit";
            this.buttonRezervacePotvrdit.UseVisualStyleBackColor = true;
            this.buttonRezervacePotvrdit.Click += new System.EventHandler(this.buttonRezervacePotvrdit_Click);
            // 
            // panelServisVozidla
            // 
            this.panelServisVozidla.Controls.Add(this.buttonServisZpet);
            this.panelServisVozidla.Controls.Add(this.labelServisVozidla);
            this.panelServisVozidla.Controls.Add(this.labelServisSeznamOprav);
            this.panelServisVozidla.Controls.Add(this.listBoxServisSeznamOprav);
            this.panelServisVozidla.Controls.Add(this.buttonServisUpravit);
            this.panelServisVozidla.Controls.Add(this.buttonServisPridat);
            this.panelServisVozidla.Controls.Add(this.buttonServisOdebrat);
            this.panelServisVozidla.Controls.Add(this.labelServisCisloFaktury);
            this.panelServisVozidla.Controls.Add(this.textBoxServisCisloFaktury);
            this.panelServisVozidla.Controls.Add(this.labelServisDatum);
            this.panelServisVozidla.Controls.Add(this.dateTimePickerServisDatum);
            this.panelServisVozidla.Controls.Add(this.labelServisCena);
            this.panelServisVozidla.Controls.Add(this.numericUpDownServisCena);
            this.panelServisVozidla.Controls.Add(this.labelServisMena);
            this.panelServisVozidla.Controls.Add(this.labelServisSeznamUkonu);
            this.panelServisVozidla.Controls.Add(this.listBoxServisSeznamUkonu);
            this.panelServisVozidla.Controls.Add(this.textBoxServisUkon);
            this.panelServisVozidla.Controls.Add(this.buttonServisPridatUkon);
            this.panelServisVozidla.Controls.Add(this.buttonServisZrusit);
            this.panelServisVozidla.Controls.Add(this.buttonServisPotvrdit);
            this.panelServisVozidla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelServisVozidla.Location = new System.Drawing.Point(0, 0);
            this.panelServisVozidla.Name = "panelServisVozidla";
            this.panelServisVozidla.Size = new System.Drawing.Size(984, 561);
            this.panelServisVozidla.TabIndex = 0;
            this.panelServisVozidla.Visible = false;
            // 
            // buttonServisZpet
            // 
            this.buttonServisZpet.Location = new System.Drawing.Point(12, 12);
            this.buttonServisZpet.Name = "buttonServisZpet";
            this.buttonServisZpet.Size = new System.Drawing.Size(75, 25);
            this.buttonServisZpet.TabIndex = 13;
            this.buttonServisZpet.Text = "Zpět";
            this.buttonServisZpet.UseVisualStyleBackColor = true;
            // 
            // labelServisVozidla
            // 
            this.labelServisVozidla.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelServisVozidla.AutoSize = true;
            this.labelServisVozidla.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelServisVozidla.Location = new System.Drawing.Point(341, 43);
            this.labelServisVozidla.Name = "labelServisVozidla";
            this.labelServisVozidla.Size = new System.Drawing.Size(212, 37);
            this.labelServisVozidla.TabIndex = 0;
            this.labelServisVozidla.Text = "Servis vozidla";
            // 
            // labelServisSeznamOprav
            // 
            this.labelServisSeznamOprav.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServisSeznamOprav.AutoSize = true;
            this.labelServisSeznamOprav.Location = new System.Drawing.Point(103, 115);
            this.labelServisSeznamOprav.Name = "labelServisSeznamOprav";
            this.labelServisSeznamOprav.Size = new System.Drawing.Size(108, 18);
            this.labelServisSeznamOprav.TabIndex = 0;
            this.labelServisSeznamOprav.Text = "Seznam oprav:";
            // 
            // listBoxServisSeznamOprav
            // 
            this.listBoxServisSeznamOprav.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxServisSeznamOprav.FormattingEnabled = true;
            this.listBoxServisSeznamOprav.ItemHeight = 18;
            this.listBoxServisSeznamOprav.Location = new System.Drawing.Point(106, 136);
            this.listBoxServisSeznamOprav.Name = "listBoxServisSeznamOprav";
            this.listBoxServisSeznamOprav.Size = new System.Drawing.Size(277, 292);
            this.listBoxServisSeznamOprav.TabIndex = 1;
            // 
            // buttonServisUpravit
            // 
            this.buttonServisUpravit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonServisUpravit.Enabled = false;
            this.buttonServisUpravit.Location = new System.Drawing.Point(106, 446);
            this.buttonServisUpravit.Name = "buttonServisUpravit";
            this.buttonServisUpravit.Size = new System.Drawing.Size(135, 25);
            this.buttonServisUpravit.TabIndex = 3;
            this.buttonServisUpravit.Text = "Upravit záznam";
            this.buttonServisUpravit.UseVisualStyleBackColor = true;
            // 
            // buttonServisPridat
            // 
            this.buttonServisPridat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonServisPridat.Location = new System.Drawing.Point(248, 446);
            this.buttonServisPridat.Name = "buttonServisPridat";
            this.buttonServisPridat.Size = new System.Drawing.Size(135, 25);
            this.buttonServisPridat.TabIndex = 2;
            this.buttonServisPridat.Text = "Přidat záznam";
            this.buttonServisPridat.UseVisualStyleBackColor = true;
            // 
            // buttonServisOdebrat
            // 
            this.buttonServisOdebrat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonServisOdebrat.Enabled = false;
            this.buttonServisOdebrat.Location = new System.Drawing.Point(106, 477);
            this.buttonServisOdebrat.Name = "buttonServisOdebrat";
            this.buttonServisOdebrat.Size = new System.Drawing.Size(135, 25);
            this.buttonServisOdebrat.TabIndex = 4;
            this.buttonServisOdebrat.Text = "Odebrat záznam";
            this.buttonServisOdebrat.UseVisualStyleBackColor = true;
            // 
            // labelServisCisloFaktury
            // 
            this.labelServisCisloFaktury.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServisCisloFaktury.AutoSize = true;
            this.labelServisCisloFaktury.Location = new System.Drawing.Point(480, 138);
            this.labelServisCisloFaktury.Name = "labelServisCisloFaktury";
            this.labelServisCisloFaktury.Size = new System.Drawing.Size(94, 18);
            this.labelServisCisloFaktury.TabIndex = 0;
            this.labelServisCisloFaktury.Text = "Číslo faktury:";
            // 
            // textBoxServisCisloFaktury
            // 
            this.textBoxServisCisloFaktury.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxServisCisloFaktury.Enabled = false;
            this.textBoxServisCisloFaktury.Location = new System.Drawing.Point(582, 135);
            this.textBoxServisCisloFaktury.MaxLength = 64;
            this.textBoxServisCisloFaktury.Name = "textBoxServisCisloFaktury";
            this.textBoxServisCisloFaktury.Size = new System.Drawing.Size(200, 24);
            this.textBoxServisCisloFaktury.TabIndex = 5;
            // 
            // labelServisDatum
            // 
            this.labelServisDatum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServisDatum.AutoSize = true;
            this.labelServisDatum.Location = new System.Drawing.Point(452, 170);
            this.labelServisDatum.Name = "labelServisDatum";
            this.labelServisDatum.Size = new System.Drawing.Size(124, 18);
            this.labelServisDatum.TabIndex = 0;
            this.labelServisDatum.Text = "Datum provedení:";
            // 
            // dateTimePickerServisDatum
            // 
            this.dateTimePickerServisDatum.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerServisDatum.Enabled = false;
            this.dateTimePickerServisDatum.Location = new System.Drawing.Point(582, 165);
            this.dateTimePickerServisDatum.Name = "dateTimePickerServisDatum";
            this.dateTimePickerServisDatum.Size = new System.Drawing.Size(200, 24);
            this.dateTimePickerServisDatum.TabIndex = 6;
            // 
            // labelServisCena
            // 
            this.labelServisCena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServisCena.AutoSize = true;
            this.labelServisCena.Location = new System.Drawing.Point(529, 198);
            this.labelServisCena.Name = "labelServisCena";
            this.labelServisCena.Size = new System.Drawing.Size(47, 18);
            this.labelServisCena.TabIndex = 0;
            this.labelServisCena.Text = "Cena:";
            // 
            // numericUpDownServisCena
            // 
            this.numericUpDownServisCena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownServisCena.DecimalPlaces = 2;
            this.numericUpDownServisCena.Enabled = false;
            this.numericUpDownServisCena.Location = new System.Drawing.Point(582, 195);
            this.numericUpDownServisCena.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownServisCena.Name = "numericUpDownServisCena";
            this.numericUpDownServisCena.Size = new System.Drawing.Size(200, 24);
            this.numericUpDownServisCena.TabIndex = 7;
            // 
            // labelServisMena
            // 
            this.labelServisMena.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServisMena.AutoSize = true;
            this.labelServisMena.Location = new System.Drawing.Point(788, 198);
            this.labelServisMena.Name = "labelServisMena";
            this.labelServisMena.Size = new System.Drawing.Size(28, 18);
            this.labelServisMena.TabIndex = 0;
            this.labelServisMena.Text = "kč.";
            // 
            // labelServisSeznamUkonu
            // 
            this.labelServisSeznamUkonu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelServisSeznamUkonu.AutoSize = true;
            this.labelServisSeznamUkonu.Location = new System.Drawing.Point(464, 230);
            this.labelServisSeznamUkonu.Name = "labelServisSeznamUkonu";
            this.labelServisSeznamUkonu.Size = new System.Drawing.Size(112, 18);
            this.labelServisSeznamUkonu.TabIndex = 0;
            this.labelServisSeznamUkonu.Text = "Seznam úkonů:";
            // 
            // listBoxServisSeznamUkonu
            // 
            this.listBoxServisSeznamUkonu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBoxServisSeznamUkonu.Enabled = false;
            this.listBoxServisSeznamUkonu.FormattingEnabled = true;
            this.listBoxServisSeznamUkonu.ItemHeight = 18;
            this.listBoxServisSeznamUkonu.Location = new System.Drawing.Point(582, 225);
            this.listBoxServisSeznamUkonu.Name = "listBoxServisSeznamUkonu";
            this.listBoxServisSeznamUkonu.Size = new System.Drawing.Size(200, 130);
            this.listBoxServisSeznamUkonu.TabIndex = 8;
            // 
            // textBoxServisUkon
            // 
            this.textBoxServisUkon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxServisUkon.Enabled = false;
            this.textBoxServisUkon.Location = new System.Drawing.Point(582, 361);
            this.textBoxServisUkon.MaxLength = 64;
            this.textBoxServisUkon.Name = "textBoxServisUkon";
            this.textBoxServisUkon.Size = new System.Drawing.Size(200, 24);
            this.textBoxServisUkon.TabIndex = 9;
            // 
            // buttonServisPridatUkon
            // 
            this.buttonServisPridatUkon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonServisPridatUkon.Enabled = false;
            this.buttonServisPridatUkon.Location = new System.Drawing.Point(788, 360);
            this.buttonServisPridatUkon.Name = "buttonServisPridatUkon";
            this.buttonServisPridatUkon.Size = new System.Drawing.Size(75, 25);
            this.buttonServisPridatUkon.TabIndex = 10;
            this.buttonServisPridatUkon.Text = "Přidat";
            this.buttonServisPridatUkon.UseVisualStyleBackColor = true;
            // 
            // buttonServisZrusit
            // 
            this.buttonServisZrusit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonServisZrusit.Enabled = false;
            this.buttonServisZrusit.Location = new System.Drawing.Point(580, 395);
            this.buttonServisZrusit.Name = "buttonServisZrusit";
            this.buttonServisZrusit.Size = new System.Drawing.Size(75, 25);
            this.buttonServisZrusit.TabIndex = 12;
            this.buttonServisZrusit.Text = "Zrušit";
            this.buttonServisZrusit.UseVisualStyleBackColor = true;
            // 
            // buttonServisPotvrdit
            // 
            this.buttonServisPotvrdit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonServisPotvrdit.Enabled = false;
            this.buttonServisPotvrdit.Location = new System.Drawing.Point(661, 395);
            this.buttonServisPotvrdit.Name = "buttonServisPotvrdit";
            this.buttonServisPotvrdit.Size = new System.Drawing.Size(75, 25);
            this.buttonServisPotvrdit.TabIndex = 11;
            this.buttonServisPotvrdit.Text = "Potvrdit";
            this.buttonServisPotvrdit.UseVisualStyleBackColor = true;
            // 
            // labelPrihlasenyUzivatel
            // 
            this.labelPrihlasenyUzivatel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPrihlasenyUzivatel.AutoSize = true;
            this.labelPrihlasenyUzivatel.Location = new System.Drawing.Point(781, 35);
            this.labelPrihlasenyUzivatel.Name = "labelPrihlasenyUzivatel";
            this.labelPrihlasenyUzivatel.Size = new System.Drawing.Size(64, 18);
            this.labelPrihlasenyUzivatel.TabIndex = 0;
            this.labelPrihlasenyUzivatel.Text = "Uživatel:";
            this.labelPrihlasenyUzivatel.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.labelPosledniPrihlaseni);
            this.Controls.Add(this.labelPrihlasenyUzivatel);
            this.Controls.Add(this.labelOznameni);
            this.Controls.Add(this.panelSpravaVozidel);
            this.Controls.Add(this.panelSpravaRezervaci);
            this.Controls.Add(this.panelLogin);
            this.Controls.Add(this.panelZmenaHesla);
            this.Controls.Add(this.panelUzivatelRezervace);
            this.Controls.Add(this.panelUzivatelHome);
            this.Controls.Add(this.panelAdminHome);
            this.Controls.Add(this.panelSpravaUzivatelu);
            this.Controls.Add(this.panelServisVozidla);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainWindow";
            this.Text = "Správa vozového parku";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelUzivatelHome.ResumeLayout(false);
            this.panelUzivatelHome.PerformLayout();
            this.panelZmenaHesla.ResumeLayout(false);
            this.panelZmenaHesla.PerformLayout();
            this.panelUzivatelRezervace.ResumeLayout(false);
            this.panelUzivatelRezervace.PerformLayout();
            this.panelAdminHome.ResumeLayout(false);
            this.panelAdminHome.PerformLayout();
            this.panelSpravaUzivatelu.ResumeLayout(false);
            this.panelSpravaUzivatelu.PerformLayout();
            this.panelSpravaVozidel.ResumeLayout(false);
            this.panelSpravaVozidel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownVozidlaSpotreba)).EndInit();
            this.panelSpravaRezervaci.ResumeLayout(false);
            this.panelSpravaRezervaci.PerformLayout();
            this.panelServisVozidla.ResumeLayout(false);
            this.panelServisVozidla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownServisCena)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 

        #endregion
        
    

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label labelLoginHeslo;
        private System.Windows.Forms.TextBox textBoxLoginHeslo;
        private System.Windows.Forms.Label labelLoginUzivatelskeJmeno;
        private System.Windows.Forms.TextBox textBoxLoginUzivatelskeJmeno;
        private System.Windows.Forms.Label labelLoginNazevPanelu;
        private System.Windows.Forms.Button buttonLoginPotvrdit;
        private System.Windows.Forms.Label labelOznameni;
        private System.Windows.Forms.Timer timerOznameni;
        private System.Windows.Forms.Panel panelZmenaHesla;
        private System.Windows.Forms.Button buttonZmenaPotvrditHeslo;
        private System.Windows.Forms.Label labelZmenaNoveHeslo;
        private System.Windows.Forms.TextBox textBoxZmenaNoveHeslo;
        private System.Windows.Forms.Label labelZmenaZmenaHesla;
        private System.Windows.Forms.Label labelZmenaPotvrdteHeslo;
        private System.Windows.Forms.TextBox textBoxZmenaPotvrditHeslo;
        private System.Windows.Forms.Panel panelUzivatelHome;
        private System.Windows.Forms.Button buttonUHomePridatRezervaci;
        private System.Windows.Forms.ListBox listBoxUHomeSeznamRezervaci;
        private System.Windows.Forms.Button buttonUHomeZmenaHeslaUzivatele;
        private System.Windows.Forms.Button buttonUHomeOdhlasitUzivatele;
        private System.Windows.Forms.Label labelUHomeAktualniRezervace;
        private System.Windows.Forms.Label labelUHomePrehledRezervaci;
        private System.Windows.Forms.Button buttonUHomeUpravitRezervaci;
        private System.Windows.Forms.Button buttonZmenaZrusitHeslo;
        private System.Windows.Forms.Label labelURezervaceObsazeneTerminy;
        private System.Windows.Forms.ListBox listBoxURezervaceSeznamObsazenychTerminu;
        private System.Windows.Forms.Label labelURezervaceRezervaceDo;
        private System.Windows.Forms.DateTimePicker dateTimePickerURezervaceRezervaceDoDatum;
        private System.Windows.Forms.Label labelURezervaceRezervaceOd;
        private System.Windows.Forms.Label labelURezervaceUpravitRezervaci;
        private System.Windows.Forms.Label labelURezervaceVozidlo;
        private System.Windows.Forms.ListBox listBoxURezervaceSeznamAutomobilu;
        private System.Windows.Forms.Button buttonURezervaceZrusitRezervaci;
        private System.Windows.Forms.Button buttonURezervacePotvrditRezervaci;
        private System.Windows.Forms.DateTimePicker dateTimePickerURezervaceRezervaceOdDatum;
        private System.Windows.Forms.DateTimePicker dateTimePickerURezervaceRezervaceDoCas;
        private System.Windows.Forms.Panel panelUzivatelRezervace;
        private System.Windows.Forms.DateTimePicker dateTimePickerURezervaceRezervaceOdCas;
        private System.Windows.Forms.Panel panelAdminHome;
        private System.Windows.Forms.Button buttonAHomeSpravaVozidel;
        private System.Windows.Forms.Label labelAHomeSpravaSystemu;
        private System.Windows.Forms.Button buttonAHomeSpravaUzivatelu;
        private System.Windows.Forms.Button buttonAHomeSpravaRezervaci;
        private System.Windows.Forms.Button buttonAHomeOdhlasitAdmina;
        private System.Windows.Forms.Button buttonAHomeZmenaHeslaAdmina;
        private System.Windows.Forms.Label labelAHomeRezervaciVSystemu;
        private System.Windows.Forms.Label labelAHomeCelkemVozidel;
        private System.Windows.Forms.Label labelAHomeUzivateluVSystemu;
        private System.Windows.Forms.Label labelPosledniPrihlaseni;
        private System.Windows.Forms.Panel panelSpravaUzivatelu;
        private System.Windows.Forms.TextBox textBoxUzivatelePrijmeni;
        private System.Windows.Forms.Label labelUzivatelePrijmeni;
        private System.Windows.Forms.TextBox textBoxUzivateleJmeno;
        private System.Windows.Forms.Button buttonUzivateleOdebratUzivatele;
        private System.Windows.Forms.Button buttonUzivateleUpravitUzivatele;
        private System.Windows.Forms.Label labelUzivateleSpravaUzivatelu;
        private System.Windows.Forms.Label labelUzivateleJmeno;
        private System.Windows.Forms.Label labelUzivateleSeznamUzivatelu;
        private System.Windows.Forms.ListBox listBoxUzivateleSeznamUzivatelu;
        private System.Windows.Forms.Button buttonUzivatelePotvrditUzivatele;
        private System.Windows.Forms.Button buttonUzivatelePridatUzivatele;
        private System.Windows.Forms.Button buttonUzivateleZrusitUzivatele;
        private System.Windows.Forms.Label labelUzivateleNaposledyPrihlasen;
        private System.Windows.Forms.TextBox textBoxUzivateleJmenoUzivatele;
        private System.Windows.Forms.Label labelUzivateleJmenoUzivatele;
        private System.Windows.Forms.Button buttonUzivateleZpet;
        private System.Windows.Forms.Panel panelSpravaVozidel;
        private System.Windows.Forms.NumericUpDown numericUpDownVozidlaSpotreba;
        private System.Windows.Forms.Label labelVozidlaSpotreba;
        private System.Windows.Forms.Button buttonVozidlaZpet;
        private System.Windows.Forms.Label labelVozidlaSpravaVozidel;
        private System.Windows.Forms.Label labelVozidlaSeznamVozidel;
        private System.Windows.Forms.Button buttonVozidlaUpravitVozidlo;
        private System.Windows.Forms.Button buttonVozidlaPridatVozidlo;
        private System.Windows.Forms.Button buttonVozidlaOdebratVozidlo;
        private System.Windows.Forms.Label labelVozidlaVyrobce;
        private System.Windows.Forms.TextBox textBoxVozidlaVyrobce;
        private System.Windows.Forms.Label labelVozidlaModel;
        private System.Windows.Forms.Label labelVozidlaTyp;
        private System.Windows.Forms.TextBox textBoxVozidlaTyp;
        private System.Windows.Forms.Button buttonVozidlaZrusitVozidlo;
        private System.Windows.Forms.Button buttonVozidlaPotvrditVozidlo;
        private System.Windows.Forms.Label labelVozidlaSPZ;
        private System.Windows.Forms.TextBox textBoxVozidlaSPZ;
        private System.Windows.Forms.Button buttonVozidlaPridatTyp;
        private System.Windows.Forms.ListBox listBoxVozidlaTyp;
        private System.Windows.Forms.Button buttonVozidlaPridatModel;
        private System.Windows.Forms.ListBox listBoxVozidlaModel;
        private System.Windows.Forms.Button buttonVozidlaPridatVyrobce;
        private System.Windows.Forms.ListBox listBoxVozidlaVyrobce;
        private System.Windows.Forms.TextBox textBoxVozidlaModel;
        private System.Windows.Forms.Button buttonVozidlaServisniZaznamy;
        private System.Windows.Forms.Panel panelSpravaRezervaci;
        private System.Windows.Forms.Button buttonRezervaceZpet;
        private System.Windows.Forms.Label labelRezervaceRezervaci;
        private System.Windows.Forms.Label labelRezervaceSeznamRezervaci;
        private System.Windows.Forms.CheckBox checkBoxRezervaceZobrazitPredchozi;
        private System.Windows.Forms.RadioButton radioButtonRezervacePodleVozidel;
        private System.Windows.Forms.RadioButton radioButtonRezervacePodleUzivatelu;
        private System.Windows.Forms.Button buttonRezervacePridatRezervaci;
        private System.Windows.Forms.Button buttonRezervaceUpravit;
        private System.Windows.Forms.Button buttonRezervaceOdebratRezervaci;
        private System.Windows.Forms.Label labelRezervaceUzivatel;
        private System.Windows.Forms.ListBox listBoxRezervaceSeznamUzivatelu;
        private System.Windows.Forms.TextBox textBoxRezervaceUzivatel;
        private System.Windows.Forms.Button buttonRezervaceHledat;
        private System.Windows.Forms.Label labeRezervaceVozidlo;
        private System.Windows.Forms.Label labelRezervaceRezervaceOd;
        private System.Windows.Forms.DateTimePicker dateTimePickerRezervaceRezervaceOdDatum;
        private System.Windows.Forms.DateTimePicker dateTimePickerRezervaceRezervaceOdCas;
        private System.Windows.Forms.Label labelRezervaceRezervaceDo;
        private System.Windows.Forms.DateTimePicker dateTimePickerRezervaceRezervaceDoDatum;
        private System.Windows.Forms.DateTimePicker dateTimePickerRezervaceRezervaceDoCas;
        private System.Windows.Forms.Button buttonRezervaceZrusit;
        private System.Windows.Forms.Button buttonRezervacePotvrdit;
        private System.Windows.Forms.Panel panelServisVozidla;
        private System.Windows.Forms.Label labelServisMena;
        private System.Windows.Forms.NumericUpDown numericUpDownServisCena;
        private System.Windows.Forms.DateTimePicker dateTimePickerServisDatum;
        private System.Windows.Forms.Button buttonServisZpet;
        private System.Windows.Forms.Label labelServisVozidla;
        private System.Windows.Forms.Label labelServisSeznamOprav;
        private System.Windows.Forms.ListBox listBoxServisSeznamOprav;
        private System.Windows.Forms.Button buttonServisUpravit;
        private System.Windows.Forms.Button buttonServisPridat;
        private System.Windows.Forms.Button buttonServisOdebrat;
        private System.Windows.Forms.Label labelServisCisloFaktury;
        private System.Windows.Forms.TextBox textBoxServisCisloFaktury;
        private System.Windows.Forms.Label labelServisDatum;
        private System.Windows.Forms.Label labelServisCena;
        private System.Windows.Forms.Label labelServisSeznamUkonu;
        private System.Windows.Forms.ListBox listBoxServisSeznamUkonu;
        private System.Windows.Forms.TextBox textBoxServisUkon;
        private System.Windows.Forms.Button buttonServisPridatUkon;
        private System.Windows.Forms.Button buttonServisZrusit;
        private System.Windows.Forms.Button buttonServisPotvrdit;
        private System.Windows.Forms.CheckBox checkBoxUzivateleVynutitZmenuHesla;
        private System.Windows.Forms.TreeView treeViewVozidlaSeznamVozidel;
        private System.Windows.Forms.Label labelPrihlasenyUzivatel;
        private System.Windows.Forms.TreeView treeViewRezervaceSeznamRezervaci;
        private System.Windows.Forms.TreeView treeViewRezervaceSeznamVozidel;
    }
}

