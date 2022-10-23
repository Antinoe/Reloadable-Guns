using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using ReloadableGuns;

namespace MetroidMod.Common
{
	public class GunItemLayer : PlayerDrawLayer
	{
		public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.HeldItem);
		public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) =>
			drawInfo.drawPlayer.inventory[drawInfo.drawPlayer.selectedItem].type == drawInfo.drawPlayer.inventory[drawInfo.drawPlayer.selectedItem].type;
		protected override void Draw(ref PlayerDrawSet drawInfo)
		{
			Player Player = drawInfo.drawPlayer;
			Item Item = Player.inventory[Player.selectedItem];
            var rgp = Player.GetModPlayer<ReloadableGunsPlayer>();
			if (!rgp.reloading)
			{
				return;
			}
			if (drawInfo.shadow != 0f || Player.frozen || ((Player.itemAnimation <= 0 || Item.useStyle == 0) && (Item.holdStyle <= 0 || Player.pulley)) || Item.type <= 0 || Player.dead || Item.noUseGraphic || (Player.wet && Item.noWet))
			{
				return;
			}

			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				Texture2D Texture = Terraria.GameContent.TextureAssets.Item[Item.type].Value;
				Color currentColor = Lighting.GetColor((int)((double)drawInfo.Position.X + (double)Player.width * 0.5) / 16, (int)(((double)drawInfo.Position.Y + (double)Player.height * 0.5) / 16.0));

				int num80 = 10;
				Vector2 vector7 = new(Texture.Width / 2, Texture.Height / 2);
				Vector2 vector8 = new(24f / 2, Texture.Height / 2);
				num80 = (int)vector8.X;
				vector7.Y = vector8.Y;
				Vector2 origin4 = new(-num80, Texture.Height / 2);
				if (Player.direction == -1)
				{
					origin4 = new Vector2(Texture.Width + num80, Texture.Height / 2);
				}
				DrawData Item2 = new(Texture, new Vector2((int)(drawInfo.ItemLocation.X - Main.screenPosition.X + vector7.X), (int)(drawInfo.ItemLocation.Y - Main.screenPosition.Y + vector7.Y)), new Rectangle(0, 0, Texture.Width, Texture.Height), drawInfo.colorArmorBody, Player.itemRotation, origin4, Item.scale, drawInfo.itemEffect, 0);
				Item2.shader = drawInfo.cBody;
				drawInfo.DrawDataCache.Add(Item2);
			}
		}
	}
	public class GunLayer : PlayerDrawLayer
	{
		public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.HandOnAcc);
		public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) =>
			drawInfo.drawPlayer.inventory[drawInfo.drawPlayer.selectedItem].type == drawInfo.drawPlayer.inventory[drawInfo.drawPlayer.selectedItem].type;
		protected override void Draw(ref PlayerDrawSet drawInfo)
		{
			Player Player = drawInfo.drawPlayer;
			Item Item = Player.inventory[Player.selectedItem];
            var rgp = Player.GetModPlayer<ReloadableGunsPlayer>();
			if (!rgp.reloading)
			{
				return;
			}
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				Texture2D Texture = Terraria.GameContent.TextureAssets.Item[Item.type].Value;
				if (Texture != null)
				{
					Vector2 origin = new(14f, (float)((int)(Texture.Height / 2)));
					if (Player.direction == -1)
					{
						origin.X = Texture.Width - 14;
					}
					Vector2 pos = new(0f, 0f);
					float rot = 0f;
					float rotate = 0.45f;
					float posX = 4f;
					float posY = 4f;
					rot = rotate * Player.direction * Player.gravDir;
					pos.X += ((float)Player.bodyFrame.Width * 0.5f) + posX * Player.direction;
					pos.Y += ((float)Player.bodyFrame.Height * 0.5f) + 4f + posY * Player.gravDir;

					SpriteEffects effects = SpriteEffects.None;
					if (Player.direction == -1)
					{
						effects = SpriteEffects.FlipHorizontally;
					}
					if (Player.gravDir == -1f)
					{
						effects |= SpriteEffects.FlipVertically;
						pos.Y -= 2;
					}
					Color color = Lighting.GetColor((int)((double)drawInfo.Position.X + (double)Player.width * 0.5) / 16, (int)((double)drawInfo.Position.Y + (double)Player.height * 0.5) / 16);

					DrawData item = new(Texture, new Vector2((float)((int)(drawInfo.Position.X - Main.screenPosition.X - (float)(Player.bodyFrame.Width / 2) + (float)(Player.width / 2))), (float)((int)(drawInfo.Position.Y - Main.screenPosition.Y + (float)Player.height - (float)Player.bodyFrame.Height + 4f))) + new Vector2((float)((int)pos.X), (float)((int)pos.Y)), new Rectangle?(new Rectangle(0, 0, Texture.Width, Texture.Height)), drawInfo.colorArmorBody, rot, origin, Item.scale, effects, 0);
					item.shader = drawInfo.cBody;
					drawInfo.DrawDataCache.Add(item);
				}
			}
		}
	}
}