using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ReloadableGuns;

namespace ReloadableGuns
{
	class AmmoDisplay : InfoDisplay
	{
		public override void SetStaticDefaults()
		{
			InfoName.SetDefault("Ammo Display");
		}

		public override bool Active()
		{
			return Main.LocalPlayer.GetModPlayer<AmmoDisplayPlayer>().showAmmoDisplay;
		}

		public override string DisplayValue()
		{
			Player Player = Main.LocalPlayer;
			Item Item = Player.inventory[Player.selectedItem];
			var rgp = Main.LocalPlayer.GetModPlayer<ReloadableGunsPlayer>();
			var rgi = Item.GetGlobalItem<ReloadableGunsGlobalItem>();
			return rgi.AmmoAmount > 0 ? $"Ammo: {rgi.AmmoAmount} / {rgi.AmmoAmountMax}" : "No Ammo";
			if (Item.useAmmo != AmmoID.Bullet) return "Not a gun";
		}
	}

	public class AmmoDisplayPlayer : ModPlayer
	{
		public bool showAmmoDisplay;
		public override void ResetEffects()
		{
			showAmmoDisplay = false;
		}
		public override void PostUpdateMiscEffects()
		{
			Player Player = Main.LocalPlayer;
			Item Item = Player.HeldItem;
			if (Item.useAmmo == AmmoID.Bullet || Item.useAmmo == AmmoID.Rocket)
			{
				showAmmoDisplay = true;
			}
		}
	}
}