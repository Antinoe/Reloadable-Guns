using System; //For Math functions to work.
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
using Terraria.Audio;
using Terraria.GameContent;
using ReLogic.Utilities;
using Terraria.GameInput; //This allows the ``ProcessTriggers`` Method to work.
using Terraria.ModLoader.Config;
using ReloadableGuns.Buffs;

namespace ReloadableGuns
{
	public class ReloadableGunsPlayer : ModPlayer
	{
		public bool reloading = false;
		public int reloadTimer = 0;
		public int DryFireTimer;
		public int screenShakeTimerVeryWeak;
		public int screenShakeTimerWeak;
		public int screenShakeTimerModerate;
		public int screenShakeTimerStrong;

		public override void ResetEffects()
		{
			//reloading = false;
			//reloadTimer = 0;
		}

		public override void PostUpdateMiscEffects()
		{
			Player player = Main.LocalPlayer;
			Item Item = Player.HeldItem;
			//var rgi = Item.GetGlobalItem<ReloadableGunsGlobalItem>();
			//^ We can't use this Variable because it causes a "[Mod]GlobalItem does not exist in this item" error when nothing is selected.

			//Screenshake
			if (screenShakeTimerVeryWeak > 0)
			{
				screenShakeTimerVeryWeak--;
			}
			if (screenShakeTimerWeak > 0)
			{
				screenShakeTimerWeak--;
			}
			if (screenShakeTimerModerate > 0)
			{
				screenShakeTimerModerate--;
			}
			if (screenShakeTimerStrong > 0)
			{
				screenShakeTimerStrong--;
			}
			if (reloading)
			{
				Player.delayUseItem = true;
			}
			if (reloadTimer > 0)
			{
				reloadTimer--;
			}
			if (DryFireTimer > 0)
			{
				DryFireTimer--;
			}
			if (reloadTimer == 1)
			{
				Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount = Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax;
				reloading = false;
				if (ReloadableGunsConfig.Instance.enableFiringMoment)
				{
					Player.AddBuff(ModContent.BuffType<FiringMoment>(), ReloadableGunsConfig.Instance.firingMomentTime);
				}
			}
			//Pistol
			if (ReloadableGunsConfigLists.Instance.gunPistol.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 74)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount == Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						reloadTimer = 0;
						reloading = false;
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Guns.PistolMagOut, Player.position);
					}
				}
				if (reloadTimer == 30)
				{
					SoundEngine.PlaySound(Sounds.Guns.PistolMagIn, Player.position);
				}
				if (reloadTimer == 10)
				{
					SoundEngine.PlaySound(Sounds.Guns.PistolSlideForward, Player.position);
				}
			}
			//M1911
			if (ReloadableGunsConfigLists.Instance.gunPistolM1911.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 119)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount == Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						reloadTimer = 0;
						reloading = false;
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Guns.Colt45MagOut, Player.position);
					}
				}
				if (reloadTimer == 60)
				{
					SoundEngine.PlaySound(Sounds.Guns.Colt45Futz, Player.position);
				}
				if (reloadTimer == 30)
				{
					SoundEngine.PlaySound(Sounds.Guns.Colt45MagIn, Player.position);
				}
				if (reloadTimer == 1)
				{
					SoundEngine.PlaySound(Sounds.Guns.Colt45SlideForward, Player.position);
				}
			}
			//Shotgun
			if (ReloadableGunsConfigLists.Instance.gunShotgun.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 14)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount < Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						SoundEngine.PlaySound(Sounds.Guns.ShotgunShellLoad, Player.position);
						reloadTimer += 30;
						Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount++;
						//Main.NewText("Loading shell in..");
					}
				}
				if (reloadTimer == 10)
				{
					SoundEngine.PlaySound(Sounds.Guns.ShotgunPumpBackward, Player.position);
				}
				if (reloadTimer == 1)
				{
					SoundEngine.PlaySound(Sounds.Guns.ShotgunPumpForward, Player.position);
					//Main.NewText("Finished reloading shotgun.");
				}
			}
			//Boomstick
			if (ReloadableGunsConfigLists.Instance.gunBoomstick.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 49)
				{
					Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount = 0;
					SoundEngine.PlaySound(Sounds.Guns.BoomstickOpen, Player.position);
					SoundEngine.PlaySound(Sounds.Guns.BoomstickShellEject, Player.position);
					SoundEngine.PlaySound(Sounds.Guns.BoomstickTube, Player.position);
				}
				if (reloadTimer == 10)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount < Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						SoundEngine.PlaySound(Sounds.Guns.BoomstickLoad, Player.position);
						SoundEngine.PlaySound(Sounds.Guns.BoomstickShellLoad, Player.position);
						SoundEngine.PlaySound(Sounds.Guns.BoomstickClick, Player.position);
						reloadTimer += 30;
						Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount++;
					}
				}
				if (reloadTimer == 1)
				{
					SoundEngine.PlaySound(Sounds.Guns.BoomstickClose, Player.position);
				}
			}
			//Rifle
			if (ReloadableGunsConfigLists.Instance.gunRifle.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 119)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount == Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						reloadTimer = 0;
						reloading = false;
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Guns.RifleMagOut, Player.position);
					}
				}
				if (reloadTimer == 60)
				{
					SoundEngine.PlaySound(Sounds.Guns.RifleMagIn, Player.position);
				}
				if (reloadTimer == 10)
				{
					SoundEngine.PlaySound(Sounds.Guns.RifleCharge, Player.position);
				}
			}
			//Sniper
			if (ReloadableGunsConfigLists.Instance.gunSniper.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 89)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount == Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						reloadTimer = 0;
						reloading = false;
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Guns.SniperMagOut, Player.position);
					}
				}
				if (reloadTimer == 40)
				{
					SoundEngine.PlaySound(Sounds.Guns.SniperFutz, Player.position);
				}
				if (reloadTimer == 20)
				{
					SoundEngine.PlaySound(Sounds.Guns.SniperMagIn, Player.position);
				}
			}
			//Rocket Launcher
			if (ReloadableGunsConfigLists.Instance.gunRocketLauncher.Contains(new ItemDefinition(Item.type)))
			{
				if (reloadTimer == 39)
				{
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount == Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						reloadTimer = 0;
						reloading = false;
					}
					else
					{
						SoundEngine.PlaySound(Sounds.Guns.RPGFutz, Player.position);
					}
				}
				if (reloadTimer == 20)
				{
					SoundEngine.PlaySound(Sounds.Guns.RPGSlide, Player.position);
				}
				if (reloadTimer == 5)
				{
					SoundEngine.PlaySound(Sounds.Guns.RPGLatch, Player.position);
					if (Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount < Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmountMax)
					{
						reloadTimer += 60;
						Item.GetGlobalItem<ReloadableGunsGlobalItem>().AmmoAmount++;
					}
				}
			}
			if (Player.HeldItem.IsAir)
			{
				reloadTimer = 0;
				reloading = false;
			}
		}

		public override void ModifyScreenPosition() //Screenshake
		{
			if (screenShakeTimerVeryWeak > 0)
			{
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.10f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.10f);
			}
			if (screenShakeTimerWeak > 0)
			{
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.50f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 1.50f);
			}
			if (screenShakeTimerModerate > 0)
			{
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 2.00f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 2.00f);
			}
			if (screenShakeTimerStrong > 0)
			{
				Main.screenPosition.X += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 4.00f);
				Main.screenPosition.Y += (float)Math.Round(Main.rand.Next((int)(0f - 1), (int)1) * 4.00f);
			}
		}

		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			Player player = Main.LocalPlayer;
			if (ReloadableGuns.ReloadGun.JustPressed && reloadTimer <= 0 && Player.itemAnimation <= 0)
			{
				Item Item = Player.HeldItem;
				reloading = true;
				if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
				{
					reloadTimer = 60;
					if (ReloadableGunsConfigLists.Instance.gunPistol.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 75;
					}
					if (ReloadableGunsConfigLists.Instance.gunPistolM1911.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 120;
					}
					if (ReloadableGunsConfigLists.Instance.gunShotgun.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 15;
					}
					if (ReloadableGunsConfigLists.Instance.gunBoomstick.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 50;
					}
					if (ReloadableGunsConfigLists.Instance.gunRifle.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 120;
					}
					if (ReloadableGunsConfigLists.Instance.gunSniper.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 90;
					}
					if (ReloadableGunsConfigLists.Instance.gunRocketLauncher.Contains(new ItemDefinition(Item.type)))
					{
						reloadTimer = 40;
					}
				}
			}
		}
		public override void PostUpdate()
		{
			if (reloading)
			{
				Player.bodyFrame.Y = Player.bodyFrame.Height * 10;
			}
		}
	}
}