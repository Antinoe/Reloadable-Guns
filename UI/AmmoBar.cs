﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Terraria.ModLoader;
using Terraria.ID;

namespace ReloadableGuns.UI
{
    internal class AmmoBar : UIState
    {
		private UIText text;
		private UIElement area;
		private UIImage barFrame;
		private Color gradientA;
		private Color gradientB;

		/*public override void OnInitialize()
		{
			area = new UIElement();
			area.Left.Set(-area.Width.Pixels - 650, 1f);
			area.Top.Set(30, 0f); 
			area.Width.Set(182, 0f); 
			area.Height.Set(60, 0f);

			barFrame = new UIImage(Request<Texture2D>("ReloadableGuns/UI/BarAmmo"));
			barFrame.Left.Set(22, 0f);
			barFrame.Top.Set(0, 0f);
			barFrame.Width.Set(138, 0f);
			barFrame.Height.Set(34, 0f);

			text = new UIText("0/0", 0.8f); 
			text.Width.Set(138, 0f);
			text.Height.Set(34, 0f);
			text.Top.Set(40, 0f);
			text.Left.Set(0, 0f);

			gradientA = Color.Yellow; 
			gradientB = Color.DarkOrange; 

			area.Append(text);
			area.Append(barFrame);
			Append(area);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			Item item = Main.LocalPlayer.HeldItem;
			//if (!(item.ranged = true && item.useAmmo == AmmoID.Bullet))
			if (RGConfig.Instance.ammoBarUI)
			{
				if (!(item.useAmmo == AmmoID.Bullet || item.useAmmo == AmmoID.Rocket))
					return;
				
				base.Draw(spriteBatch);
			}
		}

		protected override void DrawSelf(SpriteBatch spriteBatch)
		{
			base.DrawSelf(spriteBatch);

			Item item = Main.LocalPlayer.HeldItem;
			var modPlayer = Main.LocalPlayer.GetModPlayer<RGPlayer>();
			var globalItem = item.GetGlobalItem<RGGlobalItem>();
			float quotient = (float)globalItem.AmmoNum / globalItem.AmmoMax2;
			quotient = Utils.Clamp(quotient, 0f, 1f); 

			Rectangle hitbox = barFrame.GetInnerDimensions().ToRectangle();
			hitbox.X += 12;
			hitbox.Width -= 24;
			hitbox.Y += 8;
			hitbox.Height -= 16;

			int left = hitbox.Left;
			int right = hitbox.Right;
			int steps = (int)((right - left) * quotient);
			for (int i = 0; i < steps; i += 1)
			{
				float percent = (float)i / (right - left);
				spriteBatch.Draw(Main.magicPixel, new Rectangle(left + i, hitbox.Y, 1, hitbox.Height), Color.Lerp(gradientA, gradientB, percent));
			}
		}*/
		public override void Update(GameTime gameTime)
		{
			Item item = Main.LocalPlayer.HeldItem;
			if (!(item.useAmmo == AmmoID.Bullet || item.useAmmo == AmmoID.Rocket))
				return;

			var modPlayer = Main.LocalPlayer.GetModPlayer<RGPlayer>();
			var globalItem = item.GetGlobalItem<RGGlobalItem>();
			text.SetText($"Ammo: {globalItem.AmmoNum} / {globalItem.AmmoMax2}");
			base.Update(gameTime);
		}
	}
}