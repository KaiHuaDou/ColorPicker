﻿using System;
using System.Windows.Media;

namespace ColorPicker.Models
{
    public static class HslConverter
    {
        /// <summary>
        ///     Converts RGB to HSL
        /// </summary>
        /// <param name="r">Red value</param>
        /// <param name="b">Blue value</param>
        /// <param name="g">Green value</param>
        /// <returns>Tuple with 3 values in order: h, s, l0</returns>
        public static Tuple<int, float, float> RgbToHsl(int r, int g, int b)
        {
            int h;
            float s, l;
            float dR = r / 255.0f;
            float dG = g / 255.0f;
            float dB = b / 255.0f;

            float min = Math.Min(Math.Min(dR, dG), dB);
            float max = Math.Max(Math.Max(dR, dG), dB);
            float delta = max - min;

            l = (max + min) / 2;

            if (delta == 0)
            {
                h = 0;
                s = 0.0f;
            }
            else
            {
                s = l <= 0.5 ? delta / (max + min) : delta / (2 - max - min);

                float hue;

                if (dR == max)
                    hue = (dG - dB) / 6 / delta;
                else if (dG == max)
                    hue = 1.0f / 3 + (dB - dR) / 6 / delta;
                else
                    hue = 2.0f / 3 + (dR - dG) / 6 / delta;

                if (hue < 0)
                    hue += 1;
                if (hue > 1)
                    hue -= 1;

                h = (int)(hue * 360);
            }

            return new Tuple<int, float, float>(h, s * 100, l * 100);
        }

        /// <summary>
        ///     Converts HSL color format to RGB
        /// </summary>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        /// <returns>RGB Color</returns>
        public static Color HslToRGB(int h, float s, float l)
        {
            s /= 100;
            l /= 100;
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (s == 0)
            {
                r = g = b = (byte)(l * 255);
            }
            else
            {
                float v1, v2;
                float hue = (float)h / 360;

                v2 = l < 0.5 ? l * (1 + s) : l + s - l * s;
                v1 = 2 * l - v2;

                r = (byte)(255 * HueToRGB(v1, v2, hue + 1.0f / 3));
                g = (byte)(255 * HueToRGB(v1, v2, hue));
                b = (byte)(255 * HueToRGB(v1, v2, hue - 1.0f / 3));
            }

            return Color.FromRgb(r, g, b);
        }

        private static float HueToRGB(float v1, float v2, float hue)
        {
            if (hue < 0)
                hue += 1;

            if (hue > 1)
                hue -= 1;

            if (6 * hue < 1)
                return v1 + (v2 - v1) * 6 * hue;

            if (2 * hue < 1)
                return v2;

            if (3 * hue < 2)
                return v1 + (v2 - v1) * (2.0f / 3 - hue) * 6;

            return v1;
        }
    }
}
