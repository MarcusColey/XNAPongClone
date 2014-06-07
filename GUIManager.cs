using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace BrickBreaker.Brothers
{
    class GUIManager
    {
        SpriteBatch spriteBatch;
        List<GUIElement> elementList;
        Rectangle mouseBoundingBox;
        Screen senderScreen;

        public GUIManager(SpriteBatch spriteBatch, Screen senderScreen)
        {
            this.senderScreen = senderScreen;
            elementList = new List<GUIElement>();
            this.spriteBatch = spriteBatch;
            mouseBoundingBox = new Rectangle(0, 0, 1, 1);
        }

        public void AddGUIElement(GUIElement uiElement)
        {
            elementList.Add(uiElement);
        }

        public void RemoveAllGUIElements()
        {
            elementList.RemoveRange(0, elementList.Count);
        }

        public void UpdateUI()
        {
            mouseBoundingBox.X = Mouse.GetState().X;
            mouseBoundingBox.Y = Mouse.GetState().Y;

            foreach (GUIElement uiElement in elementList)
            {
                //uiElement.Draw(spriteBatch);
                uiElement.CheckBounds(mouseBoundingBox, senderScreen);
            }
        }

        public void DrawUI()
        {
            foreach(GUIElement uiElement in elementList)
            {
                uiElement.Draw(spriteBatch);
            }
        }
    }
}
