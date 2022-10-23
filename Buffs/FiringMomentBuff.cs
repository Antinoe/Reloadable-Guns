/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns.Buffs
{
    public class FiringMomentBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firing Moment");
            Description.SetDefault("Damage boost for all firearms.");
            Main.buffNoTimeDisplay[Type] = false;
            Main.debuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.bulletDamage += RGConfig.Instance.firingMomentBuffDamage;
            player.rocketDamage += RGConfig.Instance.firingMomentBuffDamage;
        }
    }
}*/