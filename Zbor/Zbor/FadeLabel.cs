using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Zbor
{
    //Klasa od internet za polnenje na keliite so bukvi vo gridot i kreiranje mapa na boi od RGB
    public class FadeLabel : Label
    {
        private Color _fadeFromBackColor = DefaultBackColor;

        public Color FadeFromBackColor
        {
            get { return _fadeFromBackColor; }
            set
            {
                _fadeFromBackColor = value;
                BackColor = value;
            }
        }

        private Color _fadeFromForeColor = DefaultForeColor;
        public Color FadeFromForeColor
        {
            get { return _fadeFromForeColor; }
            set
            {
                _fadeFromForeColor = value;
                ForeColor = value;
            }
        }

        private Color _fadeToForeColor = DefaultForeColor;

        public Color FadeToForeColor
        {
            get { return _fadeToForeColor; }
            set
            {
                _fadeToForeColor = value;
            }
        }

        private Color _fadeToBackColor = DefaultBackColor;

        public Color FadeToBackColor
        {
            get { return _fadeToBackColor; }
            set
            {
                _fadeToBackColor = value;
            }
        }

        private int _fadeDuration = 2000;

        public int FadeDuration
        {
            get { return _fadeDuration; }
            set
            {
                _fadeDuration = value;
            }
        }

        private int _maxTransitions = 64;

        public int MaxTransitions
        {
            get { return _maxTransitions; }
            set
            {
                _maxTransitions = value;
            }
        }


        private int FadeTimerInterval
        {
            get
            {
                int interval = (int)((float)FadeDuration / (float)MaxTransitions);
                return interval == 0 ? 1 : interval;
            }
        }

        private Timer FadeTimer = new Timer();
        private int CurrentTransition = 0;
        private delegate void PerformActivityCallback();
        private Color[] BackColorMap;
        private Color[] ForeColorMap;

        public FadeLabel()
            : base()
        {
            FadeFromBackColor = Label.DefaultBackColor;
            ForeColor = Label.DefaultBackColor;
            FadeTimer.Tick += new EventHandler(fadeTimer_Tick);
        }

        void fadeTimer_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                PerformActivityCallback d = new PerformActivityCallback(FadeControl);
                this.Invoke(d);
            }
            else
            {
                FadeControl();
            }
        }


        private void FadeControl()
        {
            BackColor = BackColorMap[CurrentTransition];
            ForeColor = ForeColorMap[CurrentTransition];
            CurrentTransition++;

            if (CurrentTransition == MaxTransitions)
            {
                FadeTimer.Stop();
            }
        }


        public void Fade()
        {
            CreateColorMaps();
            CurrentTransition = 0;
            FadeTimer.Interval = FadeTimerInterval;
            FadeTimer.Start();
        }

        public void StopFading()
        {
            FadeTimer.Stop();
        }

        public void Reset()
        {
            ForeColor = FadeFromForeColor;
            BackColor = FadeFromBackColor;
        }


        private void CreateColorMaps()
        {
            float aDelta, rDelta, gDelta, bDelta;
            int a, r, g, b;
            BackColorMap = new Color[MaxTransitions];
            ForeColorMap = new Color[MaxTransitions];

            aDelta = (FadeToBackColor.A - FadeFromBackColor.A) / (float)MaxTransitions;
            rDelta = (FadeToBackColor.R - FadeFromBackColor.R) / (float)MaxTransitions;
            gDelta = (FadeToBackColor.G - FadeFromBackColor.G) / (float)MaxTransitions;
            bDelta = (FadeToBackColor.B - FadeFromBackColor.B) / (float)MaxTransitions;

            BackColorMap[0] = FadeFromBackColor;
            for (int i = 1; i < MaxTransitions; i++)
            {
                a = (int)(BackColorMap[i - 1].A + aDelta);
                r = (int)(BackColorMap[i - 1].R + rDelta);
                g = (int)(BackColorMap[i - 1].G + gDelta);
                b = (int)(BackColorMap[i - 1].B + bDelta);

                if (a < 0 || a > 255) a = FadeToBackColor.A;
                if (r < 0 || r > 255) r = FadeToBackColor.R;
                if (g < 0 || g > 255) g = FadeToBackColor.G;
                if (b < 0 || b > 255) b = FadeToBackColor.B;

                BackColorMap[i] = Color.FromArgb(a, r, g, b);
            }

            aDelta = (FadeToForeColor.A - FadeFromForeColor.A) / (float)MaxTransitions;
            rDelta = (FadeToForeColor.R - FadeFromForeColor.R) / (float)MaxTransitions;
            gDelta = (FadeToForeColor.G - FadeFromForeColor.G) / (float)MaxTransitions;
            bDelta = (FadeToForeColor.B - FadeFromForeColor.B) / (float)MaxTransitions;
            ForeColorMap[0] = FadeFromForeColor;
            for (int i = 1; i < MaxTransitions; i++)
            {
                a = (int)(ForeColorMap[i - 1].A + aDelta);
                r = (int)(ForeColorMap[i - 1].R + rDelta);
                g = (int)(ForeColorMap[i - 1].G + gDelta);
                b = (int)(ForeColorMap[i - 1].B + bDelta);

                if (a < 0 || a > 255) a = FadeToForeColor.A;
                if (r < 0 || r > 255) r = FadeToForeColor.R;
                if (g < 0 || g > 255) g = FadeToForeColor.G;
                if (b < 0 || b > 255) b = FadeToForeColor.B;

                ForeColorMap[i] = Color.FromArgb(a, r, g, b);
            }
        }
    }
}
