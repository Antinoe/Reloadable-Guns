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
    public class BackupMagazine : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Clip Size by 30%\nIncreases Reload speed by 15%\n+6% Bullet damage");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 2, 50, 0);
            Item.rare = 4;
            Item.accessory = true;
            Item.defense = 2;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            //Item.GetGlobalItem<RGGlobalItem>().AmmoMax2 += 20;
            //player.GetModPlayer<RGPlayer>().AmmoAdd += 0.3f;
            //player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.15f;
			player.GetDamage(DamageClass.Ranged) += 0.06f;
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<Accessories.SpareAmmo>(), 1)
            .AddIngredient(ModContent.ItemType<Accessories.SleekGunBarrel>(), 1)
            .AddIngredient(ItemID.Shackle, 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}