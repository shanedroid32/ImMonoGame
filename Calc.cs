using System.Drawing;
using Num = System.Numerics;

namespace ImMonoGame
{
    public class Calc
    {
        public static byte HexToByte(char c) => (byte)"0123456789ABCDEF".IndexOf(char.ToUpper(c));
        public static Color ColorFromHex(string hex)
        {
            double num1 = (double)((int)HexToByte(hex[0]) * 16 + (int)HexToByte(hex[1])) / (double)byte.MaxValue;
            float num2 = (float)((int)HexToByte(hex[2]) * 16 + (int)HexToByte(hex[3])) / (float)byte.MaxValue;
            float num3 = (float)((int)HexToByte(hex[4]) * 16 + (int)HexToByte(hex[5])) / (float)byte.MaxValue;
            //double num4 = (double)num2;
            //double num5 = (double)num3;
            var color = Color.FromArgb((int)num1, (int)num2, (int)num3);
            return color;
        }

        public static Num.Vector4 ColorToHex(Color color)
        {
            return new Num.Vector4(color.R / 255, color.G / 255, color.B / 255, 1f);
        }
    }
}
