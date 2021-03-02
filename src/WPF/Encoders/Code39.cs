using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Barcoder.WPF.Encoders
{
	public static class Code39
	{
		/// <summary>
		/// Dictionary of the CODE39 algorithm
		/// </summary>
		static Dictionary<char, string> Code39_Values;

		static Code39()
		{
			Code39_Values = new Dictionary<char, string>
			{
				{ '0', "nnnwwnwnn" },
				{ '1', "wnnwnnnnw" },
				{ '2', "nnwwnnnnw" },
				{ '3', "wnwwnnnnn" },
				{ '4', "nnnwwnnnw" },
				{ '5', "wnnwwnnnn" },
				{ '6', "nnwwwnnnn" },
				{ '7', "nnnwnnwnw" },
				{ '8', "wnnwnnwnn" },
				{ '9', "nnwwnnwnn" },
				{ 'A', "wnnnnwnnw" },
				{ 'B', "nnwnnwnnw" },
				{ 'C', "wnwnnwnnn" },
				{ 'D', "nnnnwwnnw" },
				{ 'E', "wnnnwwnnn" },
				{ 'F', "nnwnwwnnn" },
				{ 'G', "nnnnnwwnw" },
				{ 'H', "wnnnnwwnn" },
				{ 'I', "nnwnnwwnn" },
				{ 'J', "nnnnwwwnn" },
				{ 'K', "wnnnnnnww" },
				{ 'L', "nnwnnnnww" },
				{ 'M', "wnwnnnnwn" },
				{ 'N', "nnnnwnnww" },
				{ 'O', "wnnnwnnwn" },
				{ 'P', "nnwnwnnwn" },
				{ 'Q', "nnnnnnwww" },
				{ 'R', "wnnnnnwwn" },
				{ 'S', "nnwnnnwwn" },
				{ 'T', "nnnnwnwwn" },
				{ 'U', "wwnnnnnnw" },
				{ 'V', "nwwnnnnnw" },
				{ 'W', "wwwnnnnnn" },
				{ 'X', "nwnnwnnnw" },
				{ 'Y', "wwnnwnnnn" },
				{ 'Z', "nwwnwnnnn" },
				{ '-', "nwnnnnwnw" },
				{ '.', "wwnnnnwnn" },
				{ ' ', "nwwnnnwnn" },
				{ '*', "nwnnwnwnn" },
				{ '$', "nwnwnwnnn" },
				{ '/', "nwnwnnnwn" },
				{ '+', "nwnnnwnwn" },
				{ '%', "nnnwnwnwn" }
			};
		}

		/// <summary>
		/// Draws the barcode to referenced Canvas object.
		/// </summary>
		/// <param name="canvas">Canvas to draw the barcode to</param>
		/// <param name="code">Code to encode</param>
		/// <param name="color">Brush color of barcode</param>
		/// <param name="x">Initial x location</param>
		/// <param name="y">Initial y location</param>
		/// <param name="spacing">Spacing of each rectangle (minimum 5 recommended)</param>
		/// <param name="height">Height of the barcode</param>
		/// <returns>Width of the drawen barcode</returns>
		public static float Draw(ref Canvas canvas, string code, Brush color, float x, float y, float spacing = 5, float height = 20)
		{
			if (code == null) return 0;

			float wide = spacing;
			float narrow = spacing / 3;
			float gap = narrow;

			// Draw the text at the origin.
			code = '*' + code.ToUpper() + '*';
			for (int i = 0; i < code.Length; i++)
			{
				char ch = code[i];

				string seq = Code39_Values[ch];
				float lineWidth;
				for (int bar = 0; bar < 9; bar++)
				{
					if (seq[bar] == 'n')
					{
						lineWidth = narrow;
					}
					else
					{
						lineWidth = wide;
					}
					if (bar % 2 == 0)
					{
						var r = new Rectangle();
						r.Width = lineWidth;
						r.Height = height;
						r.Fill = color;
						Canvas.SetLeft(r, x);
						Canvas.SetTop(r, y);
						canvas.Children.Add(r);
					}
					x += lineWidth;
				}
				x += gap;
			}

			return x;
		}
	}
}
