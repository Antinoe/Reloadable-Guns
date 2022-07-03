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
    public class GoldenGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Clip Size by 20%\nIncreases Reload speed by 10%\nFirearm Critical Strikes replenish Clip Ammo\n+5% Bullet damage");
        }
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 28;
            Item.value = Item.buyPrice(0, 3, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            Item Item = player.HeldItem;
            player.GetModPlayer<RGPlayer>().ReloadSpeed += 0.1f;
            player.GetModPlayer<RGPlayer>().AmmoAdd += 0.2f;
            player.GetModPlayer<RGPlayer>().CritBullet = true;
			player.GetDamage(DamageClass.Ranged) += 0.05f;
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddIngredient(ModContent.ItemType<Accessories.SleekGunBarrel>(), 1)
            .AddIngredient(ModContent.ItemType<Accessories.EnchantedBulletCoating>(), 1)
            .AddIngredient(ItemID.HallowedBar, 8)
            .AddTile(TileID.TinkerersWorkbench)
            .Register();
        }
    }
}