using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns.Items.Accessories
{
    public class SpareAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Clip Size by 10%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 2, 0, 0);
            Item.rare = 1;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            //Item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.1f;
        }
    }
}