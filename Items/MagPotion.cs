using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReloadableGuns.Items
{
    public class MagPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases Firearm Reload speed by 35%\nTHIS ITEM IS CURRENTLY NON-FUNCTIONAL.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 26;
            Item.useStyle = 7;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useTurn = true;
            Item.UseSound = SoundID.Item3;
            Item.maxStack = 30;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(silver: 2);
            //Item.buffType = ModContent.BuffType<Buffs.MagBuff>(); //Specify an existing buff to be applied when used.
            Item.buffTime = 25200; //The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
        }
        public override void AddRecipes()
        {
			CreateRecipe(1)
            .AddIngredient(ItemID.MusketBall, 5)
            .AddIngredient(ItemID.Lens, 1)
            .AddIngredient(ItemID.BottledWater, 1)
            .AddTile(TileID.Bottles)
            .Register();
        }
    }
}