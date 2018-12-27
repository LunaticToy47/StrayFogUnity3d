using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
namespace ExcelLibrary.BinaryFileFormat
{
    public class ColorPalette
    {
        public Dictionary<int, Color> Palette = new Dictionary<int, Color>();

        public ColorPalette()
        {
            Palette.Add(0, Color.black);
            Palette.Add(1, Color.white);
            Palette.Add(2, Color.red);
            Palette.Add(3, Color.green);
            Palette.Add(4, Color.blue);
            Palette.Add(5, Color.yellow);
            Palette.Add(6, Color.magenta);
            Palette.Add(7, Color.cyan);
            // 0x08-0x3F: user-defined colour from the PALETTE record
            Palette.Add(0x1F, new Color(204, 204, 255));

            Palette.Add(0x40, new Color(255, 255, 255));
            Palette.Add(0x41, new Color(0, 0, 0));
            Palette.Add(0x43, new Color(100, 100, 100));//dialogue background colour
            Palette.Add(0x4D, new Color(0, 0, 0));//text colour for chart border lines
            Palette.Add(0x4E, new Color(240, 240, 240)); //background colour for chart areas
            Palette.Add(0x4F, Color.black); //Automatic colour for chart border lines
            Palette.Add(0x50, new Color(255, 255, 255));
            Palette.Add(0x51, new Color(0, 0, 0));
            Palette.Add(0x7FFF, new Color(0, 0, 0));
        }

        public Color this[int index]
        {
            get
            {
                if (Palette.ContainsKey(index))
                {
                    return Palette[index];
                }
                return Color.white;
            }
            set
            {
                Palette[index] = value;
            }
        }
    }
}
