﻿Збор!
============
<h4> Почетен изглед </h4>
<img src = "http://imgur.com/M2Vogko.png" alt ="First look" />
---
<h4> Запознавање </h4>

<p>Инспирацијата за имплементирање на оваа игра со зборови е добиена од квизот на МТВ1 наречен „Круг на знаење“, конкретно играта (ја погодивте) „Збор“. При самото стартување на играта, може да се забележи дека таа, од една страна, не зазема голем визуелен простор, но од друга страна, е прилично функционална 2D игра за рекреација. 
<br />
<br />
Целосниот код е поделен во региони, со цел полесна навигација низ истиот. Воедно, поголемиот дел од кодот е проследен со коментари, со цел да се објасни намерата на линиите код по коментарот. Притоа, вклучени се три форми:самиот интерфејс на играта (<code>Zbor.cs</code>), листата на рекорди(<code>Records.cs</code>) и кратко упатство(<code>ZaZbor.cs</code>).
<br />
<br />
Начинот на играње на оваа игра е доста едноставен. Крајната цел на оваа игра е да се погоди случајно генерираниот збор со 5 букви од самата игра.
</p>
---
<h4> Упатство </h4>

<ul>
<li>Откако ќе се стартува играта, потребно е од страна на корисникот (играчот) да притисне ЕНТЕР (како што е прикажано на првата слика) за да се започне со играње. </li>
<li>Во играта има вградено бројач кој го претставува бонусот поени што се добиваат при еден погоден збор. Па така, по притискањето, овој бројач започнува да се намалува од 1000 (поени) па се до нула. </li>
<li>На десен клик се прикажува мени со три опции, при што може да се одбери тежина на генерираните зборови (нивоа: лесно/средно/тешко), кратко упатство за начинот на играње, како и опција за излез од играта. </li>
<li>Играта располага со архива од преку 2000 исклучиво македонски зборови (именки/придавки/глаголи) кои припаѓаат на едно од претходно наведените нивоа на тежина.</li>
<li>На почетокот се прикажуваат две букви кои се составен дел од зборот. По бирањето на зборот од архива, па се одлучува кои 2 букви од избраниот збор ќе се прикажат. Со доближување на курсорот до прикажаните букви се добива коментар дека тие се наоѓаат на точна позиција во зборот при што по внесувањето се обојуваат со светло сина боја. Од друга страна, доколку одредени букви кои играчот ги внесил, ги содржи генерираниот збор, но не се наоѓаат на правилната позиција, повторно се добива коментар, со спротивната порака и се обојуваат со кафеава боја. Тоа можеме да го забележиме од наредната слика. </li>
</ul>
<img src="http://imgur.com/RqQPmeN.png" alt ="Correct position"/>
---
<h4> Правила </h4>

<p>Правилата на играње се следните: <br/></p>
<ol>
<li>Играта може да се игра неограничен број на пати.</li>
<li>Играчот има максимум 5 обиди за да го погоди дадениот збор.</li>
<li>Полето за текст прифаќа <b>САМО</b> кирилични букви. (Мора да се пишува со македонска поддршка)</li>
<li>Доколку при напуштање на играта, играчот има доволно поени за да се запиши во листата на најдобрите 5, се дава прилика да се зачува неговиот успех или пак да го отфрли и да се обиди повторно наредниот пат кога ќе се врати.</li>
</ol>
---
<h4> Издвоени методи </h4>
<p><b>Играта во целост има голем број на методи, но овде ќе се спомнат само некои поважни:<b></p>
Методата <code>PrikaziTocniBukvi</code> ги прикажува сите точни (погодени) букви, кои се обојуваат со горе наведената боја и инстантно се запишуваат во наредната. Подетално методата е објаснета со следниот блок на код.
```
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

                        // Prikazi ja resenata bukva vo svetlo sina boja
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
```
Методата <code>OnFormClosing</code>, која се повикува при излез од играта, ги запишува освоените поени во листата на рекорди. Доколку корисникот има направено рекорд, при затворање на играта на копчето Close (X) се појавува форма за внесување на името на играчот со што би се запишал во листа на рекордери. Таа се содржи од 5 рекорди подредени по опаѓачки редослед. 
```
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            List<Records.User> users = new List<Records.User>();
            StreamReader r = new StreamReader("Rekord.txt");
            while (!r.EndOfStream) {
                string[] tmp = r.ReadLine().Split(' ');
                users.Add(new Records.User(tmp[0], Convert.ToInt32(tmp[1])));
            }
            r.Close();
            List<Records.User> res;
            foreach (Records.User current in users) 
            {
                if (current.Score < Poeni) 
                {
                    if (MessageBox.Show("Срушивте рекорд!\nДали сакате да го зачувате успехот?", "Рекорд!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes) 
                    {
                        string ime = Interaction.InputBox("Внесете име", "Рекорд!", string.Empty, -1, -1); 
                        users = users.OrderByDescending(x => x.Score).ToList();
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
                        foreach (Records.User curr in res){
                            if (k == 5) break;
                            w.WriteLine(curr);
                            k++;
                        }
                        w.Close();
                    }
                    break;
                }
            }
        }
```
Методата <code>definitionLink_LinkClicked</code> го прикажува значењето на зборот. Со клик на линкот - Што е [соодветен збор]? се пребарува online архивата со зборови за да се дознае нивното значење. Во делот „Упатство“ објаснет е пристапот до значењето на зборот, а во следниот блок е прикажан позадинскиот код на истото. 
```
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
```
---
<p>
По погодувањето на зборот, доколку играчот сака да продолжи со играње, односно нова рунда, потребно е само повторно да притисне ЕНТЕР, исто како на почетокот, и играта започнува одново.<br/>
<br/>
<img src="http://imgur.com/T2Gh49G.png" alt="Correct word"/>
<br/>
<br/>

<b>Важна напомена: Целиот изворен код е пишуван во Visual Studio 2012, па за отворање и преглед на истиот потребно е во системот да биди инсталирана таа или некоја понова верзија на VS.</b>

<br/>
<br/>
</p>
---
<p align="right">
<b>Изработено од:</b>
<br/>
Станоески Стефан 125040
<br/>
Ѓорѓиоски Филип 125013
</p>








