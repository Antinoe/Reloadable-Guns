using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace ReloadableGuns
{
    [Label("Server Config")]
    public class RGConfig : ModConfig
    {
        //This is here for the Config to work at all.
        public override ConfigScope Mode => ConfigScope.ServerSide;
		
        public static RGConfig Instance;
		
        [Header("General")]
		
        [Label("Reload Speed")]
        [Tooltip("How slowly Firearms reload.\n[Default: 120]")]
        [Slider]
        [DefaultValue(120)]
        [Range(10, 360)]
        [Increment(10)]
        public int reloadSpeed {get; set;}
		
        [Label("Firing Moment Buff Time")]
        [Tooltip("How long the Firing Moment buff lasts.\n[Default: 360]")]
        [Slider]
        [DefaultValue(360)]
        [Range(10, 360)]
        [Increment(10)]
        public int firingMomentBuffTime {get; set;}
		
        [Label("Firing Moment Buff Damage")]
        [Tooltip("Damage percentage increase for the Firing Moment buff.\n[Default: 3]")]
        [Slider]
        [DefaultValue(3f)]
        [Range(0.25f, 5f)]
        [Increment(0.25f)]
        public float firingMomentBuffDamage {get; set;}
		
        [Label("Firearm Damage")]
        [Tooltip("Damage percentage increase for Firearms.\n[Default: 0.15]\n(REQUIRES WORLD RELOAD)")]
        [Slider]
        [DefaultValue(0.15f)]
        [Range(0f, 2f)]
        [Increment(0.05f)]
        public float firearmDamage {get; set;}
		
        [Label("Rocket Damage")]
        [Tooltip("Damage percentage increase for Rocket-based Firearms.\n[Default: 0.50]\n(REQUIRES WORLD RELOAD)")]
        [Slider]
        [DefaultValue(0.50f)]
        [Range(0f, 2f)]
        [Increment(0.05f)]
        public float rocketDamage {get; set;}
		
        [Label("Firearm Ammo Capacity")]
        [Tooltip("(DOESN'T WORK YET)\nAmmo Capacity Multiplier for Firearms.\n[Default: 1x]\n(REQUIRES WORLD RELOAD)")]
        [Slider]
        [DefaultValue(1)]
        [Range(1, 5)]
        [Increment(1)]
        public int firearmAmmo {get; set;}
		
        [Label("Firearm Ammo Override")]
        [Tooltip("If true, Ammo Capacity for most firearms will be fixed values to balance them.\n[Default: On]")]
        [DefaultValue(true)]
        public bool firearmAmmoOverride {get; set;}
    }
}