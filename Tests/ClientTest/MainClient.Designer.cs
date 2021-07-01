using System;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using GUISharp.Logging;
using GUISharp.Controls.Elements;

// sudo apt install libgdiplus

namespace Tests
{
	partial class MainClient
	{
		protected override void InitializeComponents()
		{
			this.ChangeSize(700, 700);
			this.ChangeLocation(10, 10);

			FlatElement test = new FlatElement(this);
			ButtonElement b = new ButtonElement(this);
			FlatElement fImage = new FlatElement(this);
			test.ChangeSize(240, 140);
			fImage.ChangeSize(240, 140);
			b.ChangeSize();
			test.ChangeLocation(10, 10);
			fImage.ChangeLocation(400, 400);
			b.ChangeLocation(270, 270);
			test.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 0x40));
			fImage.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.old_story_bold, 0x40));
			b.ChangeFont(this.FontManager.GetSprite(GUISharp.GUIObjects.Texts.GUISharp_Fonts.noto_sans_JP, 45));
			test.ChangeText("hello!");
			fImage.ChangeText("hello!");
			b.ChangeText("test button!");
			b.ChangeSize(2);
			b.ChangeBorder(GUISharp.WotoProvider.Enums.ButtonColors.NormalGrayWhiteSmoke);
			b.ChangeForeColor(Microsoft.Xna.Framework.Color.IndianRed);
			test.ChangeForeColor(Microsoft.Xna.Framework.Color.Red);
			fImage.ChangeForeColor(Microsoft.Xna.Framework.Color.Red);
			test.ChangeBackColor(Microsoft.Xna.Framework.Color.LightGoldenrodYellow);
			fImage.ChangeBackColor(Microsoft.Xna.Framework.Color.LightGoldenrodYellow);
			test.ChangeAlignmation(GUISharp.Controls.StringAlignmation.TopRight);
			fImage.ChangeAlignmation(GUISharp.Controls.StringAlignmation.TopRight);
			b.ChangeAlignmation(GUISharp.Controls.StringAlignmation.MiddleCenter);
			test.ChangePriority(ElementPriority.VeryLow);
			fImage.ChangePriority(ElementPriority.VeryHigh);
			b.ChangePriority(ElementPriority.VeryLow);
			test.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			fImage.ChangeMovements(ElementMovements.VerticalHorizontalMovements);
			//test.EnableOwnerMover();
			b.EnableMouseEnterEffect();



			Image image = new Bitmap(100, 100);
			Graphics g = Graphics.FromImage(image);
			g.DrawLine(new Pen(System.Drawing.Color.Aqua), new(1, 1), new(10, 10));
			g.Save();
			MemoryStream m = new MemoryStream();
			image.Save(m, System.Drawing.Imaging.ImageFormat.Png);

			test.Enable();
			test.Apply();
			test.Show();
			fImage.Enable();
			fImage.Apply();
			fImage.Show();
			//Texture2D image = Texture2D.FromFile(this.GetDevice(), "/home/mrwoto/Pictures/JPEG-scaled.jpg");
			//Texture2D imageT = Texture2D.FromFile(this.GetDevice(), "/home/mrwoto/Ali/Programming/profiles/aliwoto/aliwoto/resources/801872469010808873.gif");
			Texture2D imageT = Texture2D.FromStream(this.GetDevice(), m);
			fImage.ChangeImage(imageT);



			b.Enable();
			b.Show();
			b.Apply();
			b.Click += Button1_Click;
			AppLogger.Enabled = true;
			b.RightDown += (object sender, EventArgs e) =>
			{
				AppLogger.Log("RightDown");
			};
			b.RightClick += (object sender, EventArgs e) =>
			{
				AppLogger.Log("RightClick");
			};
			b.LeftClick += (object sender, EventArgs e) =>
			{
				AppLogger.Log("LeftClick");
			};
			
			this.ElementManager.AddRange(b, test, fImage);
			b.ClickAsync += (object sender, EventArgs e) =>
			{
				var s = Microsoft.Xna.Framework.Media.Song.FromUri("test", new("Egoist - Departures.mp3", UriKind.Relative));
				Microsoft.Xna.Framework.Media.MediaPlayer.Play(s);
			};
			
		}



		private void Button1_Click(object sender, EventArgs e)
		{
			AppLogger.Log("Click");
		}
	}
}