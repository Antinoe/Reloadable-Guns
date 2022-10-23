using Terraria.Audio;

namespace ReloadableGuns
{
	public static partial class Sounds
	{
		public static class Guns
		{
			public static readonly SoundStyle PistolDryFire = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/PistolDryFire")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle PistolMagOut = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/PistolMagOut")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle PistolMagIn = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/PistolMagIn")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle PistolSlideForward = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/PistolSlideForward")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle PistolSlideBack = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/PistolSlideBack")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle Colt45MagOut = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/Colt45/Colt45MagOut")
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle Colt45Futz = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/Colt45/Colt45Futz")
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle Colt45MagIn = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/Colt45/Colt45MagIn")
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle Colt45SlideForward = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Pistols/Colt45/Colt45SlideForward")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle ShotgunDryFire = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/ShotgunDryFire")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle ShotgunPumpBackward = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/ShotgunPumpBackward")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle ShotgunPumpForward = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/ShotgunPumpForward")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle ShotgunShellLoad = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/ShotgunShellLoad", 6)
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickShellLoad = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickShellLoad", 4)
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickLoad = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickLoad", 4)
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickClick = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickClick", 3)
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickShellEject = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickShellEject", 2)
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickTube = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickTube", 4)
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickOpen = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickOpen", 2)
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle BoomstickClose = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Shotguns/Boomstick/BoomstickClose")
			{
				Volume = 0.35f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RifleMagOut = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Rifles/RifleMagOut")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RifleMagIn = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Rifles/RifleMagIn")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RifleCharge = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Rifles/RifleCharge")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SniperDryFire = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Snipers/SniperDryFire")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SniperMagOut = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Snipers/SniperMagOut")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SniperFutz = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Snipers/SniperFutz")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle SniperMagIn = new($"{nameof(ReloadableGuns)}/Assets/Sounds/Snipers/SniperMagIn")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RPGFutz = new($"{nameof(ReloadableGuns)}/Assets/Sounds/RocketLaunchers/RPG/RPGFutz")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RPGSlide = new($"{nameof(ReloadableGuns)}/Assets/Sounds/RocketLaunchers/RPG/RPGSlide")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			public static readonly SoundStyle RPGLatch = new($"{nameof(ReloadableGuns)}/Assets/Sounds/RocketLaunchers/RPG/RPGLatch")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				MaxInstances = 12
			};
			/*public static readonly SoundStyle LoopedSound = new($"{nameof(ReloadableGuns)}/Assets/Sounds/LoopedSound")
			{
				Volume = 0.50f,
				PitchVariance = 0.15f,
				IsLooped = true,
				MaxInstances = 12
			};*/
		}
	}
}