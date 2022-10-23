using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace ReloadableGuns
{
    class ReloadableGuns : Mod
    {
		public static ModKeybind ReloadGun;
		public static ModKeybind UnloadGun;
		
        public override void Load()
        {
            ReloadGun = KeybindLoader.RegisterKeybind(this, "ReloadGun", "R");
            UnloadGun = KeybindLoader.RegisterKeybind(this, "UnloadGun", "U");
		}
		
        public override void Unload()
        {
            ReloadGun = null;
            UnloadGun = null;
		}
    }
}