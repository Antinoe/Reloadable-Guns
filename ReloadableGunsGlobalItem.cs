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
using ReloadableGuns.Buffs;

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
				//useTime Chart.
				//1-8=insanely fast
				//9-20=very fast
				//21-25=fast
				//26-30=average
				//31-35=slow
				//36-45=very slow
				//46-55=extremely slow
				//56-100=snail
				
				if(Item.useTime <= 8) //Guns with insanely fast useTime.
				{
					AmmoAmount = (int)(Item.useTime * 20);
					AmmoAmountMax = (int)(Item.useTime * 20);
				}
				else if(Item.useTime <= 20) //Guns with very fast useTime.
				{
					AmmoAmount = (int)(Item.useTime * 1.15);
					AmmoAmountMax = (int)(Item.useTime * 1.15);
				}
				else if(Item.useTime <= 25) //Guns with fast useTime.
				{
					AmmoAmount = (int)(Item.useTime / 3);
					AmmoAmountMax = (int)(Item.useTime / 3);
				}
				else if(Item.useTime <= 30) //Guns with average useTime.
				{
					AmmoAmount = (int)(Item.useTime / 4);
					AmmoAmountMax = (int)(Item.useTime / 4);
				}
				else if(Item.useTime <= 35) //Guns with slow useTime.
				{
					AmmoAmount = (int)(Item.useTime / 5);
					AmmoAmountMax = (int)(Item.useTime / 5);
				}
				else if(Item.useTime <= 45) //Guns with very slow useTime.
				{
					AmmoAmount = (int)(Item.useTime / 10);
					AmmoAmountMax = (int)(Item.useTime / 10);
				}
				else if(Item.useTime <= 55) //Guns with extremely slow useTime.
				{
					AmmoAmount = (int)(Item.useTime / 10);
					AmmoAmountMax = (int)(Item.useTime / 10);
				}
				else if(Item.useTime <= 100) //Guns with snail useTime.
				{
					AmmoAmount = (int)(Item.useTime / 30);
					AmmoAmountMax = (int)(Item.useTime / 30);
				}
				
				/*if (ReloadableGunsConfigLists.Instance.ammo1.Contains(new ItemDefinition(Item.type)))
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
				}*/
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
					AmmoAmount--;
					if (Player.HasBuff(ModContent.BuffType<FiringMoment>()))
					{
						Player.ClearBuff(ModContent.BuffType<FiringMoment>());
					}
					if (ReloadableGunsConfigClient.Instance.enableScreenshake)
					{
						if (ReloadableGunsConfigLists.Instance.gunPistol.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunPistolM1911.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunRevolver.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunSMG.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileVeryWeak>(), 0, 0, Player.whoAmI);
						}
						if (ReloadableGunsConfigLists.Instance.gunLeverActionRifle.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunRifle.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileWeak>(), 0, 0, Player.whoAmI);
						}
						if (ReloadableGunsConfigLists.Instance.gunShotgun.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunBoomstick.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunMusket.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunLMG.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileModerate>(), 0, 0, Player.whoAmI);
						}
						if (ReloadableGunsConfigLists.Instance.gunSniper.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunGrenadeLauncher.Contains(new ItemDefinition(Item.type)) || ReloadableGunsConfigLists.Instance.gunRocketLauncher.Contains(new ItemDefinition(Item.type)))
						{
							Projectile.NewProjectile(Projectile.GetSource_None(), Player.Center, Vector2.Zero, ModContent.ProjectileType<ScreenshakeProjectileStrong>(), 0, 0, Player.whoAmI);
						}
					}
					return true;
				}
			}
			return base.CanUseItem(Item, Player);
		}
	}
}