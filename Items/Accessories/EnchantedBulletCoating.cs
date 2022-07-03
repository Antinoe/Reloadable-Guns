using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReloadableGuns.Items.Accessories
{
    public class EnchantedBulletCoating : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Firearm Critical Strikes replenish Clip Ammo");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 2, 0, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            //Item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().CritBullet = true;
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddRecipeGroup("IronBar", 10)
            .AddIngredient(ItemID.FallenStar, 3)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}