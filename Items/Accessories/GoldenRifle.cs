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
    [AutoloadEquip(EquipType.HandsOff)]
    public class GoldenRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Clip Size by 22%\nIncreases Reload speed by 12%\nFirearm critical strikes replenish ammo\nIncreases view range for firearms\n10% increased Ranged damage and Critical Strike chance");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 6, 0, 0);
            Item.rare = 7;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            //player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.12f;
            //player.GetModPlayer<RGPlayer>().AmmoAdd += 0.22f;
            //player.GetModPlayer<RGPlayer>().CritBullet = true;
			player.GetDamage(DamageClass.Ranged) += 0.1f;
			player.GetCritChance(DamageClass.Ranged) += 10;
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<Accessories.GoldenGun>(), 1)
            .AddIngredient(ItemID.SniperScope, 1)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}