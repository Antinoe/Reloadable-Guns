using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns.Buffs
{
	public class FiringMoment : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Firing Moment");
			Description.SetDefault("Damage Boost for all guns.");
			Main.buffNoTimeDisplay[Type] = false;
			Main.debuff[Type] = false;
		}
		public override void Update(Player player, ref int buffIndex)
		{
			player.bulletDamage += ReloadableGunsConfig.Instance.firingMomentDamage;
			player.rocketDamage += ReloadableGunsConfig.Instance.firingMomentDamage;
		}
	}
}