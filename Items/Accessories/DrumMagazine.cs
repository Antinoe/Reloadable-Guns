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
    public class DrumMagazine : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Clip Size by 100%\nIncreases Reload speed by 50%");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = 5000;
            Item.rare = 1;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 1f;
            player.GetModPlayer<RGPlayer>().ReloadSpeed -= 0.5f;
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<Accessories.SpareAmmo>(), 1)
            .AddRecipeGroup(RecipeGroupID.IronBar, 5)
            .AddTile(TileID.Anvils)
            .Register();
        }
    }
}