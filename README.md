Збор!
============
    public partial class Zbor : Form
    {
        #region Za zborovite
        
        private int redenBrojZbor;
        private List<string> listaZborovi = new List<string>();
        
        #endregion

        #region Za pominatite obidi
        
        private int redenBrojPosledenZbor;
        private List<string> listaIstorija = new List<string>();
        
        #endregion

        #region Za korisnickiot interfejs
        
        private Font bold = new Font("Georgia", 12F, FontStyle.Bold);
        private Font regular = new Font("Georgia", 12F, FontStyle.Regular);
        
        #endregion

        #region Hendlanje na zborovite
        
        private bool ValidenZbor(string word)
        {
            if (!listaZborovi.Contains(EasyPrefix + word) &&
                !listaZborovi.Contains(MediumPrefix + word) &&
                !listaZborovi.Contains(HardPrefix + word))
            {
                return false;
            }
            return true;
        }
        private bool SeSofpagjaTezinskoNivo(string word, DifficultyLevel difficultyLevel)
        {
            if (word.StartsWith(EasyPrefix) && difficultyLevel == DifficultyLevel.Easy)
            {
                return true;
            }
            if (word.StartsWith(MediumPrefix) && difficultyLevel == DifficultyLevel.Medium)
            {
                return true;
            }
            if (word.StartsWith(HardPrefix) && difficultyLevel == DifficultyLevel.Hard)
            {
                return true;
            }
            return false;
        }

        #endregion

        #region Nacin na boduvanje
        
        int Poeni;
        System.Timers.Timer bonusTimer = new System.Timers.Timer();
        int bonusPoeni;
        delegate void PerformActivityCallback();
        const int maxBonusPoeni = 1000;
        const int BonusTimerInterval = 100;
        Color[] ColorMap = new Color[100];
        float ColorMapIndexFactor = 0.1F;
        
        #endregion

        #region Procesiranje na bukvite vo zborovite
        
        private const int dolzinaZbor = 5;
        private bool[] tocniBukvi = new bool[dolzinaZbor];
        private bool[] bukviVoZbor = new bool[dolzinaZbor];
        
        #endregion

        #region Podatoci za igrata
        
        public int momentalnaSostojba;

        static class GameState
        {
            public const int posledenObid = 4;
            public const int prvObid = 0;
            public const int maximumObidi = 5;
            public const int zborVoFokus = 6;
            public const int startenIzgled = -1;
        }
        
        #endregion

        #region Tezina na igrata
        
        enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard
        }
        private DifficultyLevel tezinaNaIgra = DifficultyLevel.Easy;

        private const string EasyPrefix = "e:";
        private const string MediumPrefix = "m:";
        private const string HardPrefix = "h:";
        System.Timers.Timer ekstraBukvaTimer = new System.Timers.Timer();
        const int ekstraBukvaTimerInterval = 60000;
        bool dadenaEkstraBukva = false;
        
        #endregion

        #region Za momentalniot zbor koj se pogagja
        
        private int randomPos1;
        private int randomPos2;
        private string zborZaPogagjanje
        {
            get
            {
                return _zborZaPogagjanje;
            }
        }
        private string _zborZaPogagjanje;
        
        #endregion

        #region Metodi na igrata
        
        private void prikaziZbor()
        {
            momentalnaSostojba = GameState.startenIzgled;
            string Zbor = "Збор!";
            for (int i = 0; i < dolzinaZbor; i++)
            {
                FadeLabel fl = initLayout.Controls[i] as FadeLabel;
                fl.Text = Zbor[i] + "";
                fl.Font = bold;
                fl.FadeFromBackColor = Label.DefaultBackColor;
                fl.FadeFromForeColor = Label.DefaultBackColor;
                if (i == 4)
                    fl.FadeToBackColor = Color.Orange;
                else
                    fl.FadeToBackColor = Color.CornflowerBlue;
                fl.FadeToForeColor = Color.WhiteSmoke;
                fl.FadeDuration = 1000;
                fl.Fade();
            }
            txtGuess.Text = "Притиснете ЕНТЕР";
            txtGuess.SelectionStart = txtGuess.Text.Length;
            txtGuess.SelectionLength = 0;
        }
        private void ZapocniIgra()
        {
            Random r = new Random(DateTime.Now.Millisecond);

            // Odreduva koi 2 bukvi vi gi dava za pocetok
            randomPos1 = r.Next(0, dolzinaZbor);
            randomPos2 = r.Next(0, dolzinaZbor - 1);
            if (randomPos2 == randomPos1)
            {
                randomPos2++;
            }

            // zema random zbor i proveruva dali tezinata e soodvetna
            redenBrojZbor = r.Next(0, listaZborovi.Count);
            while (!SeSofpagjaTezinskoNivo(listaZborovi[redenBrojZbor], tezinaNaIgra))
            {
                redenBrojZbor = r.Next(0, listaZborovi.Count);
            }
            _zborZaPogagjanje = listaZborovi[redenBrojZbor].Substring(2);

            // Se resetira gridot i se vmetnuva noviot zbor
            ResetirajTabela();

            initLayout.Controls[randomPos1].Text = zborZaPogagjanje[randomPos1] + "";
            initLayout.Controls[randomPos2].Text = zborZaPogagjanje[randomPos2] + "";

            // setira informacii na hover za dadenite bukvi
            SetLetterToolTip(initLayout.Controls[randomPos1], true);
            SetLetterToolTip(initLayout.Controls[randomPos2], true);

            // Oznaci gi prvite 2 bukvi
            FadeLabel fl = initLayout.Controls[randomPos1] as FadeLabel;
            fl.FadeToForeColor = Color.White;
            fl.FadeToBackColor = Color.CornflowerBlue;
            fl.Font = bold;
            fl.FadeDuration = fl.MaxTransitions;
            fl.Fade();
            fl = initLayout.Controls[randomPos2] as FadeLabel;
            fl.FadeToForeColor = Color.White;
            fl.FadeToBackColor = Color.CornflowerBlue;
            fl.Font = bold;
            fl.FadeDuration = fl.MaxTransitions;
            fl.Fade();

            momentalnaSostojba = GameState.prvObid;
            txtGuess.Text = "";

            // Isprazni ja istorijata
            listaIstorija.Clear();
            listaIstorija.Add(txtGuess.Text);
            redenBrojPosledenZbor = 1;

            // zapameti gi pocetnite 2 bukvi kako vekje pogodeni
            tocniBukvi[randomPos1] = tocniBukvi[randomPos2] = true;

            definitionLink.Visible = false;

            // postavi gi bonus poenite i tajmerot
            bonusPoeni = maxBonusPoeni;
            bonusTimer.Start();

            // Resetiraj tajmer za ekstra bukva
            dadenaEkstraBukva = false;

            // Resetiraj ja bojata na tekst-boxot
            txtGuess.ForeColor = TextBox.DefaultForeColor;
        }
        private void InicijalizacijaNaZborovi()
        {
            StreamReader r = new StreamReader("Zbor.txt");
            while (!r.EndOfStream)
            {
                listaZborovi.Add(r.ReadLine());
            }
            r.Close();
        }
        
        #endregion

        #region Oznacuvanje na bukvite
        
        private void PrikaziBukviNaPogresnaPozicija()
        {
            // Ako vnesenata bukva ja ima vo zborot, no ne na toa mesto,
            // istata da se oznaci vo crveno
            int labelPosition = 0;
            for (int i = 0; i < dolzinaZbor; i++)
            {
                if (bukviVoZbor[i] && txtGuess.Text[i] == zborZaPogagjanje[i])
                {
                    continue;
                }
                for (int j = 0; j < dolzinaZbor; j++)
                {
                    if (txtGuess.Text[i] == zborZaPogagjanje[j])
                    {
                        if (!bukviVoZbor[j])
                        {
                            bukviVoZbor[j] = true;
                            labelPosition = momentalnaSostojba * dolzinaZbor + i;
                            FadeLabel fl = layout.Controls[labelPosition] as FadeLabel;
                            fl.FadeToBackColor = Color.RosyBrown;
                            fl.FadeToForeColor = Color.WhiteSmoke;
                            fl.FadeFromForeColor = Label.DefaultBackColor;
                            fl.FadeFromBackColor = Label.DefaultBackColor;
                            fl.Fade();
                            layout.Controls[labelPosition].Font = bold;
                            SetLetterToolTip(layout.Controls[labelPosition], false);
                            break;
                        }
                        else if (zborZaPogagjanje.Substring(j + 1).IndexOf(txtGuess.Text[i]) >= 0)
                        {
                            continue;
                        }
                        else
                            break;
                    }
                }
            }
        }
        private void PrikaziTocniBukvi()
        {
            // Od site bukvi, proveri koi se vekje pogodeni
            int labelPosition = 0;
            lock (tocniBukvi)
            {
                for (int i = 0; i < dolzinaZbor; i++)
                {
                    labelPosition = momentalnaSostojba * dolzinaZbor + i;

                    // Prikazi go tocno vneseniot zbor na tocna pozicija
                    layout.Controls[labelPosition].Text = txtGuess.Text[i] + "";

                    // Ako se sovpagja bukva
                    if (txtGuess.Text[i] == zborZaPogagjanje[i])
                    {
                        // Oznaci ja za resena
                        tocniBukvi[i] = true;

                        // Prikazi ja resenata bukva vo zeleno
                        FadeLabel fl = layout.Controls[labelPosition] as FadeLabel;
                        fl.FadeFromForeColor = Label.DefaultBackColor;
                        fl.FadeFromBackColor = Label.DefaultBackColor;
                        fl.FadeToBackColor = Color.Aqua;
                        fl.FadeFromForeColor = Label.DefaultForeColor;
                        fl.Fade();
                        layout.Controls[labelPosition].Font = bold;
                        SetLetterToolTip(layout.Controls[labelPosition], true);
                    }

                    // Prikazi gi site tocno vneseni bukvi vo naredniot red
                    if (momentalnaSostojba < GameState.posledenObid && tocniBukvi[i])
                    {
                        layout.Controls[labelPosition + dolzinaZbor].Text = zborZaPogagjanje[i] + "";
                        SetLetterToolTip(layout.Controls[labelPosition + dolzinaZbor], true);
                    }

                    // Oznaci samo ako se bukvite isti
                    bukviVoZbor[i] = (txtGuess.Text[i] == zborZaPogagjanje[i]);
                }
            }
        }
       
        #endregion

        #region Konstruktor
        
        public Zbor()
        {
            InitializeComponent();
            InitiailizeForm();
            InicijalizacijaNaZborovi();
            prikaziZbor();            
        }
        
        #endregion

        #region hendleri za kopcinja od tastatura
        
        private void ProcessNormalKeys(object sender, KeyPressEventArgs e)
        {
            // Gi hendlame site signali
            e.Handled = true;

            // Resetiraj istorijat na prv indeks
            redenBrojPosledenZbor = listaIstorija.Count;

            // Ako sme momentalni na starting screen
            // Cekame na enter za da zapocneme so igra
            if (momentalnaSostojba == GameState.startenIzgled)
            {
                if (e.KeyChar != (char)Keys.Enter)
                    return;
                else
                {
                    ZapocniIgra();
                    return;
                }
            }

            // Ako ednas se stisne Escape, prikazi go zborot
            // Ako dva pati se stisne Escape, izlezi
            if (e.KeyChar == (char)Keys.Escape)
            {
                if (momentalnaSostojba == GameState.zborVoFokus)
                {
                    this.Close();
                    return;
                }
                else
                {
                    dadenaEkstraBukva = true;
                    ekstraBukvaTimer.Stop();
                    OsveziSoPenali();
                    PrikaziOriginalenZbor();
                    return;
                }
            }

            // Ako se pritisne (') da se prikaze zborot koj go gagjame vo guess 
            if (e.KeyChar == '7')
            {
                txtGuess.Text = zborZaPogagjanje;
                return;
            }

            // Ako nema povekje obidi, ne mu dozvoluvaj na korisnikot da pravi nisto
            // dodeka ne pritisne Enter
            if (momentalnaSostojba > GameState.posledenObid && (e.KeyChar != (char)Keys.Enter))
            {
                txtGuess.ForeColor = Color.Gray;
                txtGuess.Text = "Притисни ЕНТЕР";
                return;
            }

            // Ako e pritisnato enter bez vnesen zbor, ili pak se pritisne Backspace
            // ednostavno vrati se nazad
            if ((e.KeyChar == (char)Keys.Enter && txtGuess.Text.Length != dolzinaZbor && momentalnaSostojba < GameState.maximumObidi) || e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            // Ignoriraj gi alfabetskite bukvi i site znaci
            if ((e.KeyChar.CompareTo(' ') >= 0 && e.KeyChar.CompareTo('~') <= 0) && e.KeyChar != (char)Keys.Enter)
            {
                return;
            }
            // Ako korisnikot pritisne nekoe kopce
            // a ima uste obidi
            if (txtGuess.Text.Length == dolzinaZbor && momentalnaSostojba < GameState.maximumObidi)
            {
                // Ako ne e pritisnato enter, vrati se
                if (e.KeyChar != (char)Keys.Enter && txtGuess.SelectionLength == 0)
                {
                    return;
                }
                if (txtGuess.SelectionLength != 0)
                {
                    e.Handled = false;
                    return;
                }
                
                    // zacuvaj vo istorijat

                    // Ako vneseniot zbor ne e pogoden
                    // dodadi go vo istorijat
                    //potencijal za samogeneriracka arhiva??
                    if (listaIstorija[redenBrojPosledenZbor - 1] != txtGuess.Text)
                    {
                        listaIstorija.Add(txtGuess.Text);
                        redenBrojPosledenZbor = listaIstorija.Count;
                    }

                // Prikazuva tocni bukvi
                PrikaziTocniBukvi();

                // Prikazuva bukvi vo zborot, no ne na tocna pozicija
                PrikaziBukviNaPogresnaPozicija();

                // Zgolemi go brojacot za obidi
                momentalnaSostojba++;

                // Ako e zborot tocen, prikazi go toa
                // I zapocni ja igrata nanovo
                if (txtGuess.Text == zborZaPogagjanje)
                {
                    txtGuess.Text = "Точно!";
                    for (int i = 0; i < dolzinaZbor && momentalnaSostojba < GameState.maximumObidi; i++)
                    {
                        layout.Controls[momentalnaSostojba * dolzinaZbor + i].Text = "";
                    }
                    definitionLink.Text = "Што значи '" + zborZaPogagjanje + "'?";
                    definitionLink.Visible = true;

                    OsveziPoeni();

                    momentalnaSostojba = GameState.zborVoFokus;
                    ekstraBukvaTimer.Stop();
                    return;
                }

                // isfrli go momentalniot vlez
                txtGuess.Text = "";
                ekstraBukvaTimer.Start();
                return;
            }
            else if (momentalnaSostojba == GameState.maximumObidi)
            {
                OsveziSoPenali();
                // Ako site obidi se iskoristeni, posle enter
                // prikazi go tocniot zbor
                PrikaziOriginalenZbor();

                return;
            }
            else if (momentalnaSostojba > GameState.maximumObidi)
            {
                // Zapocni nova igra
                ZapocniIgra();
                return;
            }
            e.Handled = false;
        }
        private void ProcessPreviewKeys(object sender, PreviewKeyDownEventArgs e)
        {
            // Proverka dali sme vo igra
            if (momentalnaSostojba<GameState.prvObid || momentalnaSostojba > GameState.posledenObid)
                return;

            // Ako e pritisnato nagore/nadolu,  
            // zemi informacii od istorijat
            if (e.KeyCode == Keys.Up)
            {
                redenBrojPosledenZbor = (listaIstorija.Count + redenBrojPosledenZbor - 1) % listaIstorija.Count;
                txtGuess.Text = listaIstorija[redenBrojPosledenZbor];
                txtGuess.SelectionStart = txtGuess.Text.Length;
                return;
            }
            if (e.KeyCode == Keys.Down)
            {
                redenBrojPosledenZbor = (redenBrojPosledenZbor + 1) % listaIstorija.Count;
                txtGuess.Text = listaIstorija[redenBrojPosledenZbor];
                txtGuess.SelectionStart = txtGuess.Text.Length;
                return;
            }
        }
        private void guess_KeyUp(object sender, KeyEventArgs e)
        {
            if (!dadenaEkstraBukva && momentalnaSostojba > GameState.prvObid)
            {
                ekstraBukvaTimer.Stop();
                ekstraBukvaTimer.Start();
            }
        }
        
        #endregion

        #region korisnicki interfejs, informacii na hover
        
        private void SetLetterToolTip(Control control, bool? isPositionCorrect)
        {
            if (null == isPositionCorrect)
            {
                letterTip.SetToolTip(control, null);
                return;
            }

            string message;
            if (isPositionCorrect.Value)
            {
                message = string.Format("'{0}' е на точна позиција", control.Text);
            }
            else
            {
                message = string.Format("'{0}' е на друго место во зборот", control.Text);
            }
            letterTip.SetToolTip(control, message);
        }

        private void InitiailizeForm()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Zbor));
            layout.Controls.Clear();
            
            // postavi go gridot
            for (int x = 0; x < dolzinaZbor * dolzinaZbor; x++)
            {
                FadeLabel l = new FadeLabel();
                l.Width = 27;
                l.Text = "";
                l.FadeDuration = 50;
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.BackColor = ControlPaint.LightLight(Label.DefaultBackColor);
                l.Margin = new Padding(0);
                l.Padding = new Padding(0);
                l.FadeFromBackColor = Label.DefaultBackColor;
                l.FadeFromForeColor = Label.DefaultBackColor;
                l.Font = regular;
                layout.Controls.Add(l);
            }

            // Se postavuva kontejnerot
            for (int x = 0; x < dolzinaZbor; x++)
            {
                FadeLabel l = new FadeLabel();
                l.Width = 26;
                l.Text = "";
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.BackColor = ControlPaint.LightLight(Label.DefaultBackColor);
                l.Margin = new Padding(1, 0, 1, 0);
                l.Font = regular;
                initLayout.Controls.Add(l);
            }

            // Kontekstualno meni
            ContextMenuStrip = contextMenuStrip;

            // Bonus tajmer hendler
            bonusTimer.Elapsed += new ElapsedEventHandler(DekrementirajBonus);
            bonusTimer.Interval = BonusTimerInterval;

            // Ekstra bukva tajmer hendler
            ekstraBukvaTimer.Elapsed += new ElapsedEventHandler(DisplayHelpLetter);
            ekstraBukvaTimer.Interval = ekstraBukvaTimerInterval;

            // Formira mapa na boi so RGB
            int ColorMapFactor = (int)(255F / (float)ColorMap.Length);
            for (int i = 0; i < ColorMap.Length; i++)
            {
                ColorMap[i] = Color.FromArgb(
                    255 - i * ColorMapFactor,
                    0,
                    20 + i * ColorMapFactor);
            }
        }

        void DisplayHelpLetter(object sender, ElapsedEventArgs e)
        {
            // Pretstavuvanje na bukva vo gridot (thread safe)
            if (dadenaEkstraBukva || momentalnaSostojba == GameState.prvObid || momentalnaSostojba >= GameState.maximumObidi) return;
            try
            {
                if (this.InvokeRequired)
                {
                    PerformActivityCallback d = new PerformActivityCallback(DisplayLetter);
                    this.Invoke(d);
                }
                else
                {
                    DisplayLetter();
                }
            }
            catch (ObjectDisposedException) { }
        }

        private void DisplayLetter()
        {
            if (dadenaEkstraBukva) return;
            // Se odlucuva koja bukva kje se prikaze
            Random r = new Random(DateTime.Now.Millisecond);
            int solvedLetters = 0;
            lock (tocniBukvi)
            {
                for (int i = 0; i < dolzinaZbor; i++)
                    if (tocniBukvi[i]) solvedLetters++;
                if (solvedLetters < 4)
                {
                    int checkIndex = r.Next(0, dolzinaZbor);
                    for (int i = 0; i < dolzinaZbor; i++)
                    {
                        if (!tocniBukvi[checkIndex])
                        {
                            tocniBukvi[checkIndex] = true;
                            FadeLabel fl = initLayout.Controls[checkIndex] as FadeLabel;
                            initLayout.Controls[checkIndex].Text = zborZaPogagjanje[checkIndex] + "";
                            initLayout.Controls[checkIndex].Font = bold;
                            fl.FadeFromForeColor = Label.DefaultBackColor;
                            fl.FadeFromBackColor = Label.DefaultBackColor;
                            fl.FadeToBackColor = Color.Orange;
                            fl.FadeToForeColor = Label.DefaultForeColor;
                            fl.Fade();                          

                            SetLetterToolTip(initLayout.Controls[checkIndex], true);
                            if (momentalnaSostojba > GameState.prvObid && momentalnaSostojba <= GameState.posledenObid)
                            {
                                layout.Controls[momentalnaSostojba * dolzinaZbor + checkIndex].Text = zborZaPogagjanje[checkIndex] + "";
                                SetLetterToolTip(layout.Controls[momentalnaSostojba * dolzinaZbor + checkIndex], true);
                            }
                            break;
                        }
                        checkIndex = (checkIndex + 1) % dolzinaZbor;
                    }
                }
            }
            dadenaEkstraBukva = true;
            ekstraBukvaTimer.Stop();
        }

        private void ResetirajTabela()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Zbor));
            for (int x = 0; x < dolzinaZbor; x++)
            {
                // Iscisti gi markiranite polinja i bukvi
                tocniBukvi[x] = bukviVoZbor[x] = false;

                // se cistat osnovnite polinja na koi treba da se postavi noviot zbor
                FadeLabel fl = initLayout.Controls[x] as FadeLabel;
                fl.Text = "";
                fl.ForeColor = Label.DefaultBackColor;
                fl.BackColor = Label.DefaultBackColor;
                fl.FadeToBackColor = Label.DefaultBackColor;
                fl.FadeToForeColor = Label.DefaultBackColor;
                fl.Font = regular;
                fl.Fade();

                // se prazni gridot
                for (int y = 0; y < dolzinaZbor; y++)
                {
                    FadeLabel l = layout.Controls[x * dolzinaZbor + y] as FadeLabel;
                    l.Text = "";
                    l.ForeColor = Label.DefaultForeColor;
                    l.BackColor = Label.DefaultBackColor;
                    l.FadeToBackColor = Label.DefaultBackColor;
                    l.FadeToForeColor = Label.DefaultForeColor;
                    l.Fade();
                    l.Font = regular;
                    SetLetterToolTip(l, null);
                }
            }
        }

        private void IzlezOdIgra(object sender, EventArgs e)
        {
            List<Records.User> users = new List<Records.User>();
            StreamReader r = new StreamReader("Rekord.txt");
            while (!r.EndOfStream)
            {
                string[] tmp = r.ReadLine().Split(' ');
                users.Add(new Records.User(tmp[0], Convert.ToInt32(tmp[1])));
            }
            r.Close();
            List<Records.User> res;
            foreach (Records.User current in users)
            {
                if (current.Score < Poeni)
                {
                    if (MessageBox.Show("Срушивте рекорд!\nДали сакате да го зачувате успехот?", "Рекорд!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        string ime = Interaction.InputBox("Внесете име", "Рекорд!", string.Empty, -1, -1);
                        users = users.OrderByDescending(x=>x.Score).ToList();
                        Records.User pom = new Records.User(ime, Poeni);
                        res = new List<Records.User>();
                        bool isPassed = false;
                        foreach (Records.User here in users)
                        {
                            if ((pom.Score > here.Score) && !isPassed)
                            {
                                res.Add(pom);
                                res.Add(here);
                                isPassed = true;
                            }
                            else
                            {
                                res.Add(here);
                            }
                        }
                        res = res.OrderByDescending(x => x.Score).ToList();
                        StreamWriter w = new StreamWriter("Rekord.txt");
                        int k = 0;
                        foreach (Records.User curr in res)
                        {
                            if (k == 5) break;
                            w.WriteLine(curr);
                            k++;
                        }
                        w.Close();
                    }
                    break;
                }
            }
            this.Close();
        }

        private void ChangeDifficultyLevel(object sender, EventArgs e)
        {
            // Koe nivo e odbrano, takva tezina da se dade
            string option = ((ToolStripMenuItem)sender).Tag as string;
            DifficultyLevel newLevel = DifficultyLevel.Easy;
            switch (option)
            {
                case "Easy":
                    newLevel = DifficultyLevel.Easy;
                    break;
                case "Medium":
                    newLevel = DifficultyLevel.Medium;
                    break;
                case "Hard":
                    newLevel = DifficultyLevel.Hard;
                    break;
            }

            // Ako e odbrana nova tezina, restartiraj ja igrata
            if (tezinaNaIgra != newLevel)
            {
                tezinaNaIgra = newLevel;

                // Proveri go nivoto na tezina
                easyToolStripMenuItem.Checked = (tezinaNaIgra == DifficultyLevel.Easy);
                mediumToolStripMenuItem.Checked = (tezinaNaIgra == DifficultyLevel.Medium);
                hardToolStripMenuItem.Checked = (tezinaNaIgra == DifficultyLevel.Hard);

                ZapocniIgra();
            }
        }
        private void PrikaziZaZbor(object sender, EventArgs e)
        {
            ZaZbor aboutZbor = new ZaZbor();
            aboutZbor.ShowDialog(this);
        }
        private void definitionLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (definitionLink.Text == "Што е Збор! ?")
                {
                    PrikaziZaZbor(sender, e);
                    return;
                }
                string WordnetDefinitionUrl = @"http://www.makedonski.info/search/" + zborZaPogagjanje;
                string GoogleDefinitionUrl = @"http://www.makedonski.info/search/" + zborZaPogagjanje;
                System.Diagnostics.Process.Start(WordnetDefinitionUrl);
            }
            catch { }
            finally
            {
                txtGuess.Focus();
            }
        }
        private void PrikaziOriginalenZbor()
        {
            txtGuess.ForeColor = TextBox.DefaultForeColor;
            txtGuess.Text = "Зборот беше: " + zborZaPogagjanje;
            definitionLink.Text = "Што значи '" + zborZaPogagjanje + "'?";
            definitionLink.Visible = true;
            momentalnaSostojba = GameState.zborVoFokus;
            bonusTimer.Stop();
        }
        
        #endregion

        #region Hendlanje na poenite
        
        private void OsveziSoPenali()
        {
            Poeni -= (int)(Poeni * 0.10);
            Poeni = Poeni < 0 ? 0 : Poeni;
            lblScore.Text = string.Format("{0:#,###,###;0 поени;0 поени}", Poeni);
        }
        private void OsveziPoeni()
        {
            // Osvezi i prikazi
            Poeni += (GameState.maximumObidi - momentalnaSostojba + 1) * 100 + bonusPoeni;
            lblScore.Text = string.Format("{0:#,###,###}", Poeni);
            
            // Zapri go bonus tajmerot
            bonusTimer.Stop();
        }
        void DekrementirajBonus(object sender, ElapsedEventArgs e)
        {
            bonusPoeni--;
            if (bonusPoeni == 0)
            {
                bonusTimer.Stop();
            }
            // Setiraj go bonusot (thread safe)
            try
            {
                if (this.InvokeRequired)
                {
                    PerformActivityCallback d = new PerformActivityCallback(PostaviBonus);
                    this.Invoke(d);
                }
                else
                {
                    PostaviBonus();
                }
            }
            catch (ObjectDisposedException) { }
        }
        void PostaviBonus()
        {
            bonusScoreLabel.Text = string.Format("{0:000}", bonusPoeni);

            // Postavi ja bojata na tekstot da se menuva
            // od zelena kon crvena kako sto se namaluva vrednosta
            bonusScoreLabel.ForeColor = ColorMap[(int)(bonusPoeni * ColorMapIndexFactor)];
        }
        
        #endregion

        #region otvoranje na lista so rekordi
        private void btnRecords_Click(object sender, EventArgs e)
        {
            Records x = new Records();
            x.ShowDialog();
            x.Close();
        }
        #endregion
    }
