using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Barcoder.WPF.Encoders
{
	class Code
	{
		public char Key { get; set; }
		public string Pattern { get; set; }
		public int Value { get; set; }

		public Code(char key, string pattern, int val)
		{
			Key = key;
			Pattern = pattern;
			Value = val;
		}
	}

	public static class Code128
	{
		static List<Code> Codes;

		static Code128()
		{
			Codes = new List<Code>()
			{
				// Special chars
				new Code(' ', "wwnwwnnwwnn", 0),
				new Code('!', "wwnnwwnwwnn", 1),
				new Code('"', "wwnnwwnnwwn", 2),
				new Code('#', "wnnwnnwwnnn", 3),
				new Code('$', "wnnwnnnwwnn", 4),
				new Code('%', "wnnnwnnwwnn", 5),
				new Code('&', "wnnwwnnwnnn", 6),
				new Code('\'',"wnnwwnnnwnn", 7),
				new Code('(', "wnnnwwnnwnn", 8),
				new Code(')', "wwnnwnnwnnn", 9),
				new Code('*', "wwnnwnnnwnn", 10),
				new Code('+', "wwnnnwnnwnn", 11),
				new Code(',', "wnwwnnwwwnn", 12),
				new Code('-', "wnnwwnwwwnn", 13),
				new Code('.', "wnnwwnnwwwn", 14),
				new Code('/', "wnwwwnnwwnn", 15),

				// Numbers
				new Code('0', "wnnwwwnwwnn", 16),
				new Code('1', "wnnwwwnnwwn", 17),
				new Code('2', "wwnnwwwnnwn", 18),
				new Code('3', "wwnnwnwwwnn", 19),
				new Code('4', "wwnnwnnwwwn", 20),
				new Code('5', "wwnwwwnnwnn", 21),
				new Code('6', "wwnnwwwnwnn", 22),
				new Code('7', "wwwnwwnwwwn", 23),
				new Code('8', "wwwnwnnwwnn", 24),
				new Code('9', "wwwnnwnwwnn", 25),

				// Other special chars
				new Code(':', "wwwnnwnnwwn", 26),
				new Code(';', "wwwnwwnnwnn", 27),
				new Code('<', "wwwnnwwnwnn", 28),
				new Code('=', "wwwnnwwnnwn", 29),
				new Code('>', "wwnwwnwwnnn", 30),
				new Code('?', "wwnwwnnnwwn", 31),
				new Code('@', "wwnnnwwnwwn", 32),

				// Uppercase Letters
				new Code('A', "wnwnnnwwnnn", 33),
				new Code('B', "wnnnwnwwnnn", 34),
				new Code('C', "wnnnwnnnwwn", 35),
				new Code('D', "wnwwnnnwnnn", 36),
				new Code('E', "wnnnwwnwnnn", 37),
				new Code('F', "wnnnwwnnnwn", 38),
				new Code('G', "wwnwnnnwnnn", 39),
				new Code('H', "wwnnnwnwnnn", 40),
				new Code('I', "wwnnnwnnnwn", 41),
				new Code('J', "wnwwnwwwnnn", 42),
				new Code('K', "wnwwnnnwwwn", 43),
				new Code('L', "wnnnwwnwwwn", 44),
				new Code('M', "wnwwwnwwnnn", 45),
				new Code('N', "wnwwwnnnwwn", 46),
				new Code('O', "wnnnwwwnwwn", 47),
				new Code('P', "wwwnwwwnwwn", 48),
				new Code('Q', "wwnwnnnwwwn", 49),
				new Code('R', "wwnnnwnwwwn", 50),
				new Code('S', "wwnwwwnwnnn", 51),
				new Code('T', "wwnwwwnnnwn", 52),
				new Code('U', "wwnwwwnwwwn", 53),
				new Code('V', "wwwnwnwwnnn", 54),
				new Code('W', "wwwnwnnnwwn", 55),
				new Code('X', "wwwnnnwnwwn", 56),
				new Code('Y', "wwwnwwnwnnn", 57),
				new Code('Z', "wwwnwwnnnwn", 58),

				// Other special chars
				new Code('[', "wwwnnnwwnwn", 59),
				new Code('\\', "wwwnwwwwnwn", 60),
				new Code(']', "wwnnwnnnnwn", 61),
				new Code('^', "wwwwnnnwnwn", 62),
				new Code('_', "wnwnnwwnnnn", 63),
				new Code('`', "wnwnnnnwwnn", 64),

				// Lowercase Letters
				new Code('a', "wnnwnwwnnnn", 65),
				new Code('b', "wnnwnnnnwwn", 66),
				new Code('c', "wnnnnwnwwnn", 67),
				new Code('d', "wnnnnwnnwwn", 68),
				new Code('e', "wnwwnnwnnnn", 69),
				new Code('f', "wnwwnnnnwnn", 70),
				new Code('g', "wnnwwnwnnnn", 71),
				new Code('h', "wnnwwnnnnwn", 72),
				new Code('i', "wnnnnwwnwnn", 73),
				new Code('j', "wnnnnwwnnwn", 74),
				new Code('k', "wwnnnnwnnwn", 75),
				new Code('l', "wwnnwnwnnnn", 76),
				new Code('m', "wwwwnwwwnwn", 77),
				new Code('n', "wwnnnnwnwnn", 78),
				new Code('o', "wnnnwwwwnwn", 79),
				new Code('p', "wnwnnwwwwnn", 80),
				new Code('q', "wnnwnwwwwnn", 81),
				new Code('r', "wnnwnnwwwwn", 82),
				new Code('s', "wnwwwwnnwnn", 83),
				new Code('t', "wnnwwwwnwnn", 84),
				new Code('u', "wnnwwwwnnwn", 85),
				new Code('v', "wwwwnwnnwnn", 86),
				new Code('w', "wwwwnnwnwnn", 87),
				new Code('x', "wwwwnnwnnwn", 88),
				new Code('y', "wwnwwnwwwwn", 89),
				new Code('z', "wwnwwwwnwwn", 90),

				// Other special chars
				new Code('{', "wwwwnwwnwwn", 91),
				new Code('|', "wnwnwwwwnnn", 92),
				new Code('}', "wnwnnnwwwwn", 93),
				new Code('~', "wnnnwnwwwwn", 94),

				// Extra special chars
				new Code((char)195, "wnwwwwnwnnn", 95), // DEL
				new Code((char)196, "wnwwwwnnnwn", 96), // FNC 3
				new Code((char)197, "wwwwnwnwnnn", 97), // FNC 2
				new Code((char)198, "wwwwnwnnnwn", 98), // Shift A
				new Code((char)199, "wnwwwnwwwwn", 99), // Code C
				new Code((char)200, "wnwwwwnwwwn", 100), // FNC 4
				new Code((char)201, "wwwnwnwwwwn", 101), // Code A
				new Code((char)202, "wwwwnwnwwwn", 102), // FNC 1
				new Code((char)203, "wwnwnnnnwnn", 103), // Start Code A
				new Code((char)204, "wwnwnnwnnnn", 104), // Start Code B
				new Code((char)205, "wwnwnnwwwnn", 105), // Start Code C
			};
		}

		public static float Draw(ref Canvas canvas, string code, Brush color, float spacing = 5, float height = 20)
		{
			if (string.IsNullOrWhiteSpace(code)) return 0;

			string StartCode = "wwnwnnwnnnn";
			string StopCode =  "wwnnnwwwnwnww";

			int _sum = 104;
			
			float x = 0, y = 0;
			float lineWidth = spacing;

			// Draw start code B
			string seq = StartCode;

			for (int bar = 0; bar < 11; bar++)
			{
				if (seq[bar] == 'w')
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

			// Draw the text at the origin.
			for (int i = 0; i < code.Length; i++)
			{
				char ch = code[i];

				// Find the matching character in code list
				Code _c = Codes.Find(_code => _code.Key == ch);
				// Get the code's pattern
				seq = _c.Pattern;
				// Add the character's value to the sum
				_sum += _c.Value * (i+1);

				for (int bar = 0; bar < 11; bar++)
				{
					if (seq[bar] == 'w')
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
			}

			// Draw checksum
			int modded = _sum % 103;
			// Find the checksum character by modded sum
			Code c = Codes.Find(_code => _code.Value == modded);
			seq = c.Pattern;
			for (int bar = 0; bar < 11; bar++)
			{
				if (seq[bar] == 'w')
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

			// Draw stop code
			seq = StopCode;
			for (int bar = 0; bar < 13; bar++)
			{
				if (seq[bar] == 'w')
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

			return x;
		}
	}
}
