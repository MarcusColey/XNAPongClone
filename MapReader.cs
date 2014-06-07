using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Xml;

namespace BrickBreaker.Brothers
{
    public class MapReader
    {
        List<Brick> brickList;
        List<Texture2D> textureList;
        List<char> map;
        List<char> removeListMap;
        public SpriteManager spriteManager;
        Vector2 position;
        string stringMap;

        int xPos, yPos;

        public MapReader(Texture2D basicBrick, Texture2D superBrick, Texture2D megaBrick, SpriteManager spriteManager)
        {
            this.spriteManager = spriteManager;
            position = Vector2.Zero;

            map = new List<char>();
            removeListMap = new List<char>();

            textureList = new List<Texture2D>();
            textureList.Add(basicBrick);
            textureList.Add(superBrick);
            textureList.Add(megaBrick);

            //brickList = new List<Brick>();
            //brickList.Add(new Brick(basicBrick, Vector2.Zero, new Rectangle())); // Not used
            //brickList.Add(new BasicBrick(basicBrick, Vector2.Zero, new Rectangle(0, 0, basicBrick.Width, basicBrick.Height)));
            //brickList.Add(new BasicBrick(superBrick, Vector2.Zero, new Rectangle(0, 0, superBrick.Width, superBrick.Height)));
            //brickList.Add(new BasicBrick(megaBrick, Vector2.Zero, new Rectangle(0, 0, megaBrick.Width, megaBrick.Height)));

            ReadMap("Dinner");
        }

        public void ReadMap(string mapName)
        {
            using (XmlReader reader = XmlReader.Create("Map1.xml"))
            {
                reader.MoveToContent();
                reader.ReadToFollowing("Map");
                stringMap = reader.ReadInnerXml();
            }

            foreach (char character in stringMap)
            {
                map.Add(character);
                //charmap[0] = character;
            }

            foreach (char character in map)
            {
                if (character == ' ')
                    removeListMap.Add(character);
            }

            foreach (char character in removeListMap)
            {
                map.Remove(character);
            }

            removeListMap.RemoveRange(0, removeListMap.Count);

            LoadMap();
        }

        public void LoadMap()
        {
            int xSkip = 0;
            int yskip = 0;

            for (int i = 0; i < 5; i++)
            {
                yPos = (i * 30) + 100;

                for (int j = 0; j < 10; j++)
                {
                    xPos = (j * 40) + 150;

                    //if (map[j] == '[')
                        //xSkip++;
                    //else if (map[j] == '0')
                        //break;
                    if (map[j + xSkip] != '[' || map[j + xSkip] != ']' || map[j + xSkip] != '0')
                    {
                        //spriteManager.AddBrick(brickList[map[j + xSkip]

                        switch (map[j + xSkip])
                        {
                            case '0':
                                {
                                    //Vector2 pos = new Vector2(xPos, yPos);
                                    //spriteManager.AddBrick(new BasicBrick(textureList[0], pos, new Rectangle((int)pos.X, (int)pos.Y, textureList[0].Width, textureList[0].Height)));
                                    break;
                                }
                            case '1':
                                {
                                    Vector2 pos = new Vector2(xPos, yPos);
                                    spriteManager.AddBrick(new BasicBrick(textureList[0], pos, new Rectangle((int)pos.X, (int)pos.Y, textureList[0].Width, textureList[0].Height)));
                                    break;
                                }
                            case '2':
                                {
                                    Vector2 pos = new Vector2(xPos, yPos);
                                    spriteManager.AddBrick(new SuperBrick(textureList[1], pos, new Rectangle((int)pos.X, (int)pos.Y, textureList[0].Width, textureList[0].Height)));
                                    break;
                                }
                            case '3':
                                {
                                    Vector2 pos = new Vector2(xPos, yPos);
                                    spriteManager.AddBrick(new MegaBrick(textureList[2], pos, new Rectangle((int)pos.X, (int)pos.Y, textureList[0].Width, textureList[0].Height)));
                                    break;
                                }
                        }
                    }

                }

            }
        }
    }
}
