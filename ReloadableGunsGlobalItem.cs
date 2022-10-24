using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.ModLoader.Config;
using ReloadableGuns.Projectiles;

namespace ReloadableGuns
{
	public class ReloadableGunsGlobalItem : GlobalItem
	{
		public int AmmoAmount;
		public int AmmoAmountMax;
		public override bool InstancePerEntity => true;

		public override GlobalItem Clone(Item Item, Item ItemClone)
		{
			ReloadableGunsGlobalItem myClone = (ReloadableGunsGlobalItem)base.Clone(Item, ItemClone);
			myClone.AmmoAmount = AmmoAmount;
			myClone.AmmoAmountMax = AmmoAmountMax;
			return myClone;
		}
		public override void SetDefaults(Item Item)
		{
			if (Item.useAmmo == AmmoID.Bullet)
			{
				Item.damage += (int)(Item.damage * ReloadableGunsConfig.Instance.gunDamage);
			}
			if (Item.useAmmo == AmmoID.Rocket)
			{
				Item.damage += (int)(Item.damage * ReloadableGunsConfig.Instance.rocketDamage);
			}
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				AmmoAmount = 10;
				AmmoAmountMax = 10;
				if (ReloadableGunsConfigLists.Instance.ammo1.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 1;
					AmmoAmountMax = 1;
				}
				if (ReloadableGunsConfigLists.Instance.ammo2.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 2;
					AmmoAmountMax = 2;
				}
				if (ReloadableGunsConfigLists.Instance.ammo3.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 3;
					AmmoAmountMax = 3;
				}
				if (ReloadableGunsConfigLists.Instance.ammo4.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 4;
					AmmoAmountMax = 4;
				}
				if (ReloadableGunsConfigLists.Instance.ammo5.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 5;
					AmmoAmountMax = 5;
				}
				if (ReloadableGunsConfigLists.Instance.ammo6.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 6;
					AmmoAmountMax = 6;
				}
				if (ReloadableGunsConfigLists.Instance.ammo7.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 7;
					AmmoAmountMax = 7;
				}
				if (ReloadableGunsConfigLists.Instance.ammo8.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 8;
					AmmoAmountMax = 8;
				}
				if (ReloadableGunsConfigLists.Instance.ammo9.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 9;
					AmmoAmountMax = 9;
				}
				if (ReloadableGunsConfigLists.Instance.ammo10.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 10;
					AmmoAmountMax = 10;
				}
				if (ReloadableGunsConfigLists.Instance.ammo11.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 11;
					AmmoAmountMax = 11;
				}
				if (ReloadableGunsConfigLists.Instance.ammo12.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 12;
					AmmoAmountMax = 12;
				}
				if (ReloadableGunsConfigLists.Instance.ammo13.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 13;
					AmmoAmountMax = 13;
				}
				if (ReloadableGunsConfigLists.Instance.ammo14.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 14;
					AmmoAmountMax = 14;
				}
				if (ReloadableGunsConfigLists.Instance.ammo15.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 15;
					AmmoAmountMax = 15;
				}
				if (ReloadableGunsConfigLists.Instance.ammo16.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 16;
					AmmoAmountMax = 16;
				}
				if (ReloadableGunsConfigLists.Instance.ammo20.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 20;
					AmmoAmountMax = 20;
				}
				if (ReloadableGunsConfigLists.Instance.ammo30.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 30;
					AmmoAmountMax = 30;
				}
				if (ReloadableGunsConfigLists.Instance.ammo40.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 40;
					AmmoAmountMax = 40;
				}
				if (ReloadableGunsConfigLists.Instance.ammo50.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 50;
					AmmoAmountMax = 50;
				}
				if (ReloadableGunsConfigLists.Instance.ammo60.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 60;
					AmmoAmountMax = 60;
				}
				if (ReloadableGunsConfigLists.Instance.ammo70.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 70;
					AmmoAmountMax = 70;
				}
				if (ReloadableGunsConfigLists.Instance.ammo80.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 80;
					AmmoAmountMax = 80;
				}
				if (ReloadableGunsConfigLists.Instance.ammo90.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 90;
					AmmoAmountMax = 90;
				}
				if (ReloadableGunsConfigLists.Instance.ammo100.Contains(new ItemDefinition(Item.type)))
				{
					AmmoAmount = 100;
					AmmoAmountMax = 100;
				}
			}
		}
		public override bool CanUseItem(Item Item, Player Player)
		{
			var rgp = Player.GetModPlayer<ReloadableGunsPlayer>();
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				//No Ammo
				if (AmmoAmount <= 0)
				{
					if (rgp.DryFireTimer <= 0)
					{
						if (ReloadableGunsConfigLists.Instance.gunPistol.Contains(new ItemDefinition(Item.type)))
						{
							SoundEngine.PlaySound(Sounds.Guns.PistolDryFire, Player.position);
						}
						if (ReloadableGunsConfigLists.Instance.gunPistolM1911.Contains(new ItemDefinition(Item.type)))
						{
							SoundEngine.PlaySound(Sounds.Guns.PistolDryFire, Player.position);
						}
						if (ReloadableGunsConfigLists.Instance.gunShotgun.Contains(new ItemDefinition(Item.type)))
						{
							SoundEngine.PlaySound(Sounds.Guns.ShotgunDryFire, Player.position);
						}
						if (ReloadableGunsConfigLists.Instance.gunSniper.Contains(new ItemDefinition(Item.type)))
						{
							SoundEngine.PlaySound(Sounds.Guns.SniperDryFire, Player.position);
						}
						rgp.DryFireTimer = 20;
					}
					return false;
				}
				//Ammo
				else
				{
					if (ReloadableGunsConfigClient.Instance.enableScreenshake)
					{
						if (ReloadableGunsConfigLists.Instance.gunPistol.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunPistolM1911.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunRevolver.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunSMG.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileVeryWeak>(), 0, 0, Player.whoAmI);
						}
						if (ReloadableGunsConfigLists.Instance.gunShotgun.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunBoomstick.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunMusket.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunLeverActionRifle.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunRifle.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunLMG.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, Player.whoAmI);
						}
						if (ReloadableGunsConfigLists.Instance.gunSniper.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunGrenadeLauncher.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunRocketLauncher.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileStrong>(), 0, 0, Player.whoAmI);
						}
					}
					AmmoAmount--;
					return true;
				}
			}
			return base.CanUseItem(Item, Player);
		}
	}
}