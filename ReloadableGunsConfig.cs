using System.Collections.Generic;
using System.ComponentModel;
using Terraria.ID;
using Terraria.ModLoader.Config;

namespace ReloadableGuns
{
	[Label("Client Config")]
	public class ReloadableGunsConfigClient : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		public static ReloadableGunsConfigClient Instance;
		
	[Header("General")]
		
		[Label("[i:StoneBlock] Enable Screenshake")]
		[Tooltip("If false, Screenshake will not occur from shooting guns.\n[Default: On]")]
		[DefaultValue(true)]
		public bool enableScreenshake {get; set;}
	}

	[Label("Server Config")]
	public class ReloadableGunsConfig : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static ReloadableGunsConfig Instance;
		
	[Header("General")]
		
		[Label("[i:MusketBall] Gun Damage")]
		[Tooltip("Damage percentage increase for Guns.\n[Default: 0.15]")]
		[Slider]
		[DefaultValue(0.15f)]
		[Range(0f, 5f)]
		[Increment(.05f)]
		public float gunDamage {get; set;}
		
		[Label("[i:RocketI] Rocket Damage")]
		[Tooltip("Damage percentage increase for Rockets.\n[Default: 0.50]")]
		[Slider]
		[DefaultValue(0.50f)]
		[Range(0f, 5f)]
		[Increment(.05f)]
		public float rocketDamage {get; set;}
		
		[Label("[i:EmptyBullet] Firing Moment")]
		[Tooltip("If false, the Firing Moment ability will not be granted upon Reloading.\n[Default: On]")]
		[DefaultValue(true)]
		public bool enableFiringMoment {get; set;}
		
		[Label("[i:EmptyBullet] Firing Moment Damage")]
		[Tooltip("Damage percentage increase for the Firing Moment ability.\n[Default: 3]")]
		[Slider]
		[DefaultValue(3f)]
		[Range(0f, 5f)]
		[Increment(.50f)]
		public float firingMomentDamage {get; set;}
		
	}

	[Label("Lists")]
	public class ReloadableGunsConfigLists : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ServerSide;
		public static ReloadableGunsConfigLists Instance;
		
	[Header("Gun Lists")]
		
		[Label("[i:Handgun] Pistol Whitelist")]
		public List<ItemDefinition> gunPistol = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Handgun),
				new ItemDefinition(ItemID.PhoenixBlaster)
			};
		
		[Label("[i:Handgun] M1911 Whitelist")]
		public List<ItemDefinition> gunPistolM1911 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:Revolver] Revolver Whitelist")]
		public List<ItemDefinition> gunRevolver = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Revolver),
				new ItemDefinition(ItemID.VenusMagnum)
			};
		
		[Label("[i:Shotgun] Shotgun Whitelist")]
		public List<ItemDefinition> gunShotgun = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Shotgun),
				new ItemDefinition(ItemID.OnyxBlaster)
			};
		
		[Label("[i:Boomstick] Boomstick Whitelist")]
		public List<ItemDefinition> gunBoomstick = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Boomstick)
			};
		
		[Label("[i:Uzi] SMG Whitelist")]
		public List<ItemDefinition> gunSMG = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Uzi)
			};
		
		[Label("[i:Musket] Musket Whitelist")]
		public List<ItemDefinition> gunMusket = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Musket)
			};
		
		[Label("[i:ChainGun] Lever-Action Rifle Whitelist")]
		public List<ItemDefinition> gunLeverActionRifle = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.RedRyder)
			};
		
		[Label("[i:ClockworkAssaultRifle] Rifle Whitelist")]
		public List<ItemDefinition> gunRifle = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.ClockworkAssaultRifle)
			};
		
		[Label("[i:SniperRifle] Sniper Whitelist")]
		public List<ItemDefinition> gunSniper = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.SniperRifle)
			};
		
		[Label("[i:ChainGun] LMG Whitelist")]
		public List<ItemDefinition> gunLMG = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Minishark),
				new ItemDefinition(ItemID.Megashark),
				new ItemDefinition(ItemID.Gatligator),
				new ItemDefinition(ItemID.ChainGun)
			};
		
		[Label("[i:GrenadeLauncher] Grenade Launcher Whitelist")]
		public List<ItemDefinition> gunGrenadeLauncher = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.GrenadeLauncher),
				new ItemDefinition(ItemID.ProximityMineLauncher)
			};
		
		[Label("[i:RocketLauncher] Rocket Launcher Whitelist")]
		public List<ItemDefinition> gunRocketLauncher = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.RocketLauncher),
				new ItemDefinition(ItemID.ElectrosphereLauncher)
			};
		
		[Label("[i:AlphabetStatue1] Ammo 1")]
		public List<ItemDefinition> ammo1 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.FlintlockPistol),
				new ItemDefinition(ItemID.Musket)
			};
		
		[Label("[i:AlphabetStatue2] Ammo 2")]
		public List<ItemDefinition> ammo2 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Boomstick)
			};
		
		[Label("[i:AlphabetStatue3] Ammo 3")]
		public List<ItemDefinition> ammo3 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1] Ammo 4")]
		public List<ItemDefinition> ammo4 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.QuadBarrelShotgun)
			};
		
		[Label("[i:AlphabetStatue1] Ammo 5")]
		public List<ItemDefinition> ammo5 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Shotgun),
				new ItemDefinition(ItemID.OnyxBlaster)
			};
		
		[Label("[i:AlphabetStatue6] Ammo 6")]
		public List<ItemDefinition> ammo6 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Revolver)
			};
		
		[Label("[i:AlphabetStatue7] Ammo 7")]
		public List<ItemDefinition> ammo7 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue8] Ammo 8")]
		public List<ItemDefinition> ammo8 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue9] Ammo 9")]
		public List<ItemDefinition> ammo9 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue0] Ammo 10")]
		public List<ItemDefinition> ammo10 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue1] Ammo 11")]
		public List<ItemDefinition> ammo11 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue2] Ammo 12")]
		public List<ItemDefinition> ammo12 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Handgun),
				new ItemDefinition(ItemID.PhoenixBlaster)
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue3] Ammo 13")]
		public List<ItemDefinition> ammo13 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue4] Ammo 14")]
		public List<ItemDefinition> ammo14 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue5] Ammo 15")]
		public List<ItemDefinition> ammo15 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue6] Ammo 16")]
		public List<ItemDefinition> ammo16 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue2][i:AlphabetStatue0] Ammo 20")]
		public List<ItemDefinition> ammo20 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue3][i:AlphabetStatue0] Ammo 30")]
		public List<ItemDefinition> ammo30 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.ClockworkAssaultRifle)
			};
		
		[Label("[i:AlphabetStatue4][i:AlphabetStatue0] Ammo 40")]
		public List<ItemDefinition> ammo40 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue5][i:AlphabetStatue0] Ammo 50")]
		public List<ItemDefinition> ammo50 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue6][i:AlphabetStatue0] Ammo 60")]
		public List<ItemDefinition> ammo60 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue7][i:AlphabetStatue0] Ammo 70")]
		public List<ItemDefinition> ammo70 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue8][i:AlphabetStatue0] Ammo 80")]
		public List<ItemDefinition> ammo80 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue9][i:AlphabetStatue0] Ammo 90")]
		public List<ItemDefinition> ammo90 = new List<ItemDefinition>
			{
			};
		
		[Label("[i:AlphabetStatue1][i:AlphabetStatue0][i:AlphabetStatue0] Ammo 100")]
		public List<ItemDefinition> ammo100 = new List<ItemDefinition>
			{
				new ItemDefinition(ItemID.Gatligator),
				new ItemDefinition(ItemID.ChainGun)
			};
		
	}
}