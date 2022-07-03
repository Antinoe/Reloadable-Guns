using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReloadableGuns
{
    [Label("Client Config")]
    public class RGConfigClient : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ClientSide;
		
        public static RGConfigClient Instance;
		
        [Header("General")]
		
        [Label("Ammo Bar UI")]
        [Tooltip("(DOESN'T WORK YET)\nDisplays the Ammo HUD.\n[Default: Off]")]
        [DefaultValue(false)]
        public bool ammoBarUI {get; set;}
		
        [Header("Accessibility")]
		
        [Label("Dryfire Sound")]
        [Tooltip("If false, the Dryfire sound will not play.\n[Default: On]")]
        [DefaultValue(true)]
        public bool soundDryfire {get; set;}
    }
}