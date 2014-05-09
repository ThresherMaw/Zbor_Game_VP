using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Timers;

namespace Zbor
{
    public partial class Records : Form
    {
        List<User> users;
        public Records()
        {
            InitializeComponent();
            users = new List<User>();
            InicijalizacijaNaRekorderi();
            PopolnuvanjeLabeli();
        }
        private void InicijalizacijaNaRekorderi()
        {
            StreamReader r = new StreamReader("Rekord.txt");
            while (!r.EndOfStream)
            {
                string []tmp = r.ReadLine().Split(' ');
                users.Add(new User(tmp[0], Convert.ToInt32(tmp[1])));
            }
            r.Close();
        }
        private void PopolnuvanjeLabeli()
        {
            List<User> tmp = users;
            int max, n=tmp.Count;
            User pom;
            for (int i = 0; i < n; i++)
            {
                max=0;
                pom = new User("", 0);
                foreach (User current in tmp)
                {
                    if (max <= current.Score)
                    {
                        max = current.Score;
                        pom = current;
                    }
                }
                switch (i)
                {
                    case 0:
                    {
                        lblName1.Text = pom.Name;
                        lblScore1.Text = pom.Score.ToString();
                        break;
                    }
                    case 1:
                    {
                        lblName2.Text = pom.Name;
                        lblScore2.Text = pom.Score.ToString();
                        break;
                    }
                    case 2:
                    {
                        lblName3.Text = pom.Name;
                        lblScore3.Text = pom.Score.ToString();
                        break;
                    }
                    case 3:
                    {
                        lblName4.Text = pom.Name;
                        lblScore4.Text = pom.Score.ToString();
                        break;
                    }
                    case 4:
                    {
                        lblName5.Text = pom.Name;
                        lblScore5.Text = pom.Score.ToString();
                        break;
                    }
                }
                tmp.Remove(pom);
            }
        }
        private void btnZatvori_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public class User
        {
            public string Name { get; set; }
            public int Score { get; set; }
            public User(string _name, int _score)
            {
                Name = _name;
                Score = _score;
            }
            public override string ToString()
            {
                return Name + " " + Score.ToString();
            }
        }
    }
}
