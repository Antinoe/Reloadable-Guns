using System.Collections.Generic;
using Microsoft.Xna.Framework;
using ReloadableGuns.UI;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace ReloadableGuns
{
	public class ReloadableGuns : Mod
	{
		public static ModKeybind ReloadGun;
        //private UserInterface _exampleResourceBarUserInterface;
        //internal AmmoBar AmmoBar;
        public override void Load()
        {
            ReloadGun = KeybindLoader.RegisterKeybind(this, "Reload", "R");

            /*if (!Main.dedServ)
            {
                AmmoBar = new AmmoBar();
                _exampleResourceBarUserInterface = new UserInterface();
                _exampleResourceBarUserInterface.SetState(AmmoBar);
            }*/
        }
		//UI is temporarily removed.
        /*public override void UpdateUI(GameTime gameTime)
        {
            _exampleResourceBarUserInterface?.Update(gameTime);
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            int resourceBarIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Resource Bars"));
            if (resourceBarIndex != -1)
            {
                layers.Insert(resourceBarIndex, new LegacyGameInterfaceLayer(
                    "ExampleMod: Example Resource Bar",
                    delegate {
                        _exampleResourceBarUserInterface.Draw(Main.spriteBatch, new GameTime());
                        return true;
                    },
                    InterfaceScaleType.UI)
                );
            }
        }*/
        public override void Unload()
        {
            ReloadGun = null;
        }
    }
}