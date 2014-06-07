using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading;

namespace BrickBreaker.Brothers
{
    class ScreenManager : GameComponent
    {
        List<Screen> screens;
        int current;

        public ScreenManager(Game game)
            : base(game)
        {
            screens = new List<Screen>();
        }

        public void AddScreen(Screen screen, Game game)
        {
            screen.Initialize();
            screens.Add(screen);
        }

        public void Initialize(int startingScreen)
        {
            current = startingScreen;
            Game.Components.Add(screens[startingScreen]);
        }

        public void ChangeScreens(int screenNumber)
        {
            // Forget the previous screen
            Game.Components.Remove(screens[current]);

            // Display the desired screen
            current = screenNumber;
            Game.Components.Add(screens[current]);
        }
    }
}
