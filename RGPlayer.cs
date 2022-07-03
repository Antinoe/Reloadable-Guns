using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ReloadableGuns
{
    public class RGPlayer : ModPlayer
    {
		public static RGPlayer ModPlayer(Player Player)
		{
			return Player.GetModPlayer<RGPlayer>();
		}
		
		public float AmmoAdd;
		public float ReloadSpeed;
		public bool CritBullet;
		public override void ResetEffects()
        {
			Item Item = Player.HeldItem;
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				Item.GetGlobalItem<RGGlobalItem>().AmmoMax2 = (int)(Item.GetGlobalItem<RGGlobalItem>().AmmoMax * (1f + AmmoAdd));
			}
			ReloadSpeed = 0f;
			AmmoAdd = 0;
			CritBullet = false;
		}
		
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
			Item Item = Player.HeldItem;
            if (CritBullet == true && crit)
            {
				if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
                {
					Item.GetGlobalItem<RGGlobalItem>().AmmoNum += 1;
				}
            }
        }
		
        public override void DrawEffects(PlayerDrawSet drawInfo, ref float r, ref float g, ref float b, ref float a, ref bool fullBright)
		{
			if (Player.HasBuff(ModContent.BuffType<Buffs.FiringMomentBuff>()))
			{
				for (int i = 0; i < 1; i++)
				{
					Vector2 vector2 = Vector2.UnitY.RotatedByRandom(6.28318548202515) * new Vector2((float)Player.height, (float)Player.height) * 0.4f / 2f;
					int index = Dust.NewDust(Player.Center + vector2, 0, 0, DustID.GoldCoin, 0.0f, 0.0f, 240, new Color(), 0.05f);
					Main.dust[index].position = Player.Center + vector2;
					Main.dust[index].velocity = Vector2.Zero;
					Main.dust[index].noGravity = true;
				}
			}
		}
		
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (ReloadableGuns.ReloadGun.JustPressed)
			{
				Item Item = Player.HeldItem;
				if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
				{
					int time = (int)(RGConfig.Instance.reloadSpeed * (1f - ReloadSpeed));
					if (time <= 12)
					{
						time = 12;
					}
					Player.AddBuff(ModContent.BuffType<Buffs.ReloadBuff>(), time);
				}
			}
		}
    }
}