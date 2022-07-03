using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Utilities;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.Audio;
using ReloadableGuns;
using ReloadableGuns.UI;

namespace ReloadableGuns
{
    public class RGGlobalItem : GlobalItem
    {
        public int AmmoNum;
        public int AmmoMax;
        public int AmmoMax2;
        public override bool InstancePerEntity => true;
	
		//Sounds
		public static readonly SoundStyle Dryfire1 = new SoundStyle("ReloadableGuns/Sounds/Dryfire1");
	
        public override GlobalItem Clone(Item Item, Item ItemClone)
        {
            RGGlobalItem myClone = (RGGlobalItem)base.Clone(Item, ItemClone);
            myClone.AmmoNum = AmmoNum;
            myClone.AmmoMax = AmmoMax;
            myClone.AmmoMax2 = AmmoMax2;
            return myClone;
        }
		
		public override void ModifyTooltips(Item Item, List<TooltipLine> tooltips)
		{
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				//Failed Ammo Indicator
				//var line = new TooltipLine(Mod, "ReloadableGuns:AmmoIndicator", "Ammo: {globalItem.AmmoNum} / {globalItem.AmmoMax2}");
				//tooltips.Add(line);
			}
		}
		
        public override void SetDefaults(Item Item)
        {
			if (Item.useAmmo == AmmoID.Bullet)
            {
				Item.damage += (int)(Item.damage * RGConfig.Instance.firearmDamage);
			}
			if (Item.useAmmo == AmmoID.Rocket)
            {
				Item.damage += (int)(Item.damage * RGConfig.Instance.rocketDamage);
			}
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
            {
                //AmmoMax2 = (int)(1f * RGConfig.Instance.firearmAmmo);
				AmmoMax = (int)(1f * RGConfig.Instance.firearmAmmo);
				
				//Failed tests below.
                //AmmoNum = (int)(Item.useTime - 2);
                //AmmoMax = (int)(Item.useTime - 2);
				//AmmoNum = (1 / (Item.useTime - 2)) * 2;
				//AmmoMax = (1 / (Item.useTime - 2)) * 2;
				//int useTime = Item.useTime;
				//if(useTime < 3) useTime = 3;
				//AmmoNum = (int) (( 1 / (useTime - 2)) * 1.25f);
				//AmmoMax = (int) (( 1 / (useTime - 2)) * 1.25f);
				
				
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
					AmmoNum = (int)(Item.useTime * 20);
					AmmoMax = (int)(Item.useTime * 20);
				}
				else if(Item.useTime <= 20) //Guns with very fast useTime.
				{
					AmmoNum = (int)(Item.useTime * 1.15);
					AmmoMax = (int)(Item.useTime * 1.15);
				}
				else if(Item.useTime <= 25) //Guns with fast useTime.
				{
					AmmoNum = (int)(Item.useTime / 3);
					AmmoMax = (int)(Item.useTime / 3);
				}
				else if(Item.useTime <= 30) //Guns with average useTime.
				{
					AmmoNum = (int)(Item.useTime / 4);
					AmmoMax = (int)(Item.useTime / 4);
				}
				else if(Item.useTime <= 35) //Guns with slow useTime.
				{
					AmmoNum = (int)(Item.useTime / 5);
					AmmoMax = (int)(Item.useTime / 5);
				}
				else if(Item.useTime <= 45) //Guns with very slow useTime.
				{
					AmmoNum = (int)(Item.useTime / 10);
					AmmoMax = (int)(Item.useTime / 10);
				}
				else if(Item.useTime <= 55) //Guns with extremely slow useTime.
				{
					AmmoNum = (int)(Item.useTime / 10);
					AmmoMax = (int)(Item.useTime / 10);
				}
				else if(Item.useTime <= 100) //Guns with snail useTime.
				{
					AmmoNum = (int)(Item.useTime / 30);
					AmmoMax = (int)(Item.useTime / 30);
				}
				
				if (RGConfig.Instance.firearmAmmoOverride)
				{
				//Light
					if (Item.type == ItemID.Revolver || Item.type == ItemID.TheUndertaker || Item.type == ItemID.VenusMagnum)
					{
						AmmoNum = 6;
						AmmoMax = 6;
					}
					else if (Item.type == ItemID.FlintlockPistol)
					{
						AmmoNum = 3;
						AmmoMax = 3;
					}
					else if (Item.type == ItemID.Handgun)
					{
						AmmoNum = 16;
						AmmoMax = 16;
					}
					else if (Item.type == ItemID.Uzi)
					{
						AmmoNum = 30;
						AmmoMax = 30;
					}
				//Medium
					else if (Item.type == ItemID.Boomstick)
					{
						AmmoNum = 2;
						AmmoMax = 2;
					}
					else if(Item.type == ItemID.Shotgun)
					{
						AmmoNum = 5;
						AmmoMax = 5;
					}
					else if(Item.type == ItemID.QuadBarrelShotgun)
					{
						AmmoNum = 4;
						AmmoMax = 4;
					}
					else if(Item.type == ItemID.OnyxBlaster)
					{
						AmmoNum = 8;
						AmmoMax = 8;
					}
					else if(Item.type == ItemID.TacticalShotgun)
					{
						AmmoNum = 16;
						AmmoMax = 16;
					}
					else if (Item.type == ItemID.Musket)
					{
						AmmoNum = 3;
						AmmoMax = 3;
					}
					else if(Item.type == ItemID.RedRyder)
					{
						AmmoNum = 14;
						AmmoMax = 14;
					}
					else if(Item.type == ItemID.ClockworkAssaultRifle)
					{
						AmmoNum = 30;
						AmmoMax = 30;
					}
				//Heavy
					else if(Item.type == ItemID.Minishark)
					{
						AmmoNum = 60;
						AmmoMax = 60;
					}
					else if(Item.type == ItemID.Megashark)
					{
						AmmoNum = 60;
						AmmoMax = 60;
					}
					else if(Item.type == ItemID.Gatligator)
					{
						AmmoNum = 60;
						AmmoMax = 60;
					}
					else if(Item.type == ItemID.ChainGun)
					{
						AmmoNum = 120;
						AmmoMax = 120;
					}
					else if(Item.type == ItemID.SniperRifle)
					{
						AmmoNum = 5;
						AmmoMax = 5;
					}
					else if(Item.type == ItemID.GrenadeLauncher)
					{
						AmmoNum = 8;
						AmmoMax = 8;
					}
					else if(Item.type == ItemID.RocketLauncher)
					{
						AmmoNum = 5;
						AmmoMax = 5;
					}
				}
            }
        }
		
        public override bool CanUseItem(Item Item, Player player)
        {
            var modplayer = player.GetModPlayer<RGPlayer>();
            //if (Item.ranged = true && Item.useAmmo == AmmoID.Bullet)
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
            {
				if (AmmoNum <= 0) //If Ammo Number is 0, then play a Dryfire sound.
				{
					if (RGConfigClient.Instance.soundDryfire)
					{
						SoundEngine.PlaySound(Dryfire1, player.position);
					}
					return false;
				}
                else //If Ammo Number is greater than 0, then remove 1 Ammo and clear the Firing Moment Buff.
                {
                    AmmoNum--;
                    if (player.HasBuff(ModContent.BuffType<Buffs.FiringMomentBuff>()))
                    {
                        player.ClearBuff(ModContent.BuffType<Buffs.FiringMomentBuff>());
                    }
                    return true;
                }
            }
            if (player.HeldItem.IsAir)
            {
                return true;
            }
            return base.CanUseItem(Item, player);
        }
    }
}