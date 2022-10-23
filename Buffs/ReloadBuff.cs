/*using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;

namespace ReloadableGuns.Buffs
{
    public class ReloadBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Reloading");
            Description.SetDefault("");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = true;
        }
		
        public int SP = 5;
        public int Timer;
		
        public override void Update(Player Player, ref int buffIndex)
        {
            Player.delayUseItem = true;
            SP--;
            if (SP <= 0)
            {
                SP = 5;
            }
			
            Timer++;
            if (Timer == 10)
            {
				SoundEngine.PlaySound(ReloadClipOut, Player.position);
            }
            if (Timer == 40)
            {
				SoundEngine.PlaySound(ReloadClipIn, Player.position);
            }
            if (Timer == 80)
            {
				SoundEngine.PlaySound(ReloadCock, Player.position);
				Timer = -40;
            }
			
            if (Player.buffTime[buffIndex] <= 2)
            {
				Timer = 0;
				Item Item = Player.HeldItem;
				if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
				{
					var modPlayer = Main.LocalPlayer.GetModPlayer<RGPlayer>();
					Item.GetGlobalItem<RGGlobalItem>().AmmoNum = Item.GetGlobalItem<RGGlobalItem>().AmmoMax2;
					Player.AddBuff(ModContent.BuffType<FiringMomentBuff>(), RGConfig.Instance.firingMomentBuffTime);
				}
            }
        }
    }
}*/