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
    [AutoloadEquip(EquipType.Waist)]
    public class ShroomiteMagazine : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Clip Size by 40%\nIncreases Reload speed by 20%\n+10% Bullet damage");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = 8;
            Item.accessory = true;
            Item.defense = 3;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            //Item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.4f;
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.2f;
			player.GetDamage(DamageClass.Ranged) += 0.1f;
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<Accessories.BackupMagazine>(), 1)
            .AddIngredient(ItemID.ShroomiteBar, 6)
            .AddTile(TileID.MythrilAnvil)
            .Register();
        }
    }
}