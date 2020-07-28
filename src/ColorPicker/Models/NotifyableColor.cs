﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace ColorPicker.Models
{
    public class NotifyableColor : NotifyableObject
    {
        public byte A
        {
            get => _a;
            set
            {
                _a = value;
                ColorChanged?.Invoke(this, EventArgs.Empty);
                RaisePropertyChanged("A");
            }
        }

        public byte R
        {
            get => _r;
            set
            {
                _r = value;
                ColorChanged?.Invoke(this, EventArgs.Empty);
                RaisePropertyChanged("R");
            }
        }

        public byte G
        {
            get => _g;
            set
            {
                _g = value;
                ColorChanged?.Invoke(this, EventArgs.Empty);
                RaisePropertyChanged("G");
            }
        }

        public byte B
        {
            get => _b;
            set
            {
                _b = value;
                ColorChanged?.Invoke(this, EventArgs.Empty);
                RaisePropertyChanged("B");
            }
        }

        private byte _a;

        private byte _b;


        private byte _g;

        private byte _r;

        public NotifyableColor(Color color)
        {
            A = color.A;
            R = color.R;
            G = color.G;
            B = color.B;
        }

        public NotifyableColor() { }

        public event EventHandler ColorChanged;

        public void SetArgb(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }
    }
}
