using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Barcoder.WPF.Encoders;

namespace Barcoder.WPF
{
	/// <summary>
	/// Interaction logic for Barcode.xaml
	/// </summary>
	public partial class Barcode : UserControl
	{
		public enum BarcodeEncoding
		{
			Code39, Code128
		}

		private BarcodeEncoding _encoding;
		[Description("Encoding to encode the code"), Category("Barcode Settings")]
		public BarcodeEncoding Encoding
		{
			get
			{
				return _encoding;
			}
			set
			{
				_encoding = value;
				Draw();
			}
		}

		private string _code;
		[Description("Code to encode"), Category("Barcode Settings")]
		public string Code
		{
			get
			{
				return _code;
			}
			set
			{
				_code = value;
				Draw();
			}
		}

		private float _spacing;
		[Description("Spacing and width setting. (5 is recommended for CODE39)"), Category("Barcode Settings")]
		public float Spacing
		{
			get
			{
				return _spacing;
			}
			set
			{
				_spacing = value;
				Draw();
			}
		}

		private Brush _color;
		[Description("Color of the barcode lines"), Category("Barcode Settings")]
		public Brush Color
		{
			get
			{
				return _color;
			}
			set
			{
				_color = value;
				Draw();
			}
		}

		private float barcodeLength;

		public void Draw()
		{
			BarcodeCanvas.Children.Clear();
			switch (Encoding)
			{
				case BarcodeEncoding.Code39:
					barcodeLength = Code39.Draw(ref BarcodeCanvas, Code, Color, 0, 0, Spacing, float.Parse(this.Height.ToString()));
					break;
				case BarcodeEncoding.Code128:
					barcodeLength = Code128.Draw(ref BarcodeCanvas, Code, Color, Spacing, float.Parse(this.Height.ToString()));
					break;
				default:
					break;
			}
			this.Width = barcodeLength;
		}

		public Barcode()
		{
			InitializeComponent();

			barcodeLength = 5;
			Spacing = 2;
			Code = "Hello";
			Color = Brushes.Black;
		}

		private void Init(object sender, EventArgs e)
		{
			Draw();
		}

		private void Barcode_Loaded(object sender, RoutedEventArgs e)
		{
			Draw();
		}

		private void Barcode_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			this.Width = barcodeLength;
			Draw();
			e.Handled = true;
		}
	}
}
