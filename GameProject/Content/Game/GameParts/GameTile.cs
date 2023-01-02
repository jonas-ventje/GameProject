using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject.Content.Game.GameParts
{
    internal class GameTile : GameObject
    {

        private int id;

        public int Id
        {
            get => id;
        }

        public GameTile(ContentManager content, int id, int x, int y)
            //always draw from the right lower corner
            : base(content.Load<Texture2D>("./images/tileset"), Vector2.Zero, new Frame(Rectangle.Empty))
        {
            this.id = id;
            position = new Vector2(x, y + 128 - LoadGameObject(id).BoundingBox.Height);
            frame = LoadGameObject(id);
            //water is passable
            if (id == 27 || id == 28 || id == 29 || id == 30) Passable = true;

            //other texture for crates or ladders
            if (id == 1)
                texture = content.Load<Texture2D>("./images/crate");
            if (id == 29 || id == 30)
                texture = content.Load<Texture2D>("./images/ladder");
        }

        private Frame LoadGameObject(int id)
        {
            switch (id)
            {
                case 1:
                    //crate
                    throw new System.IndexOutOfRangeException();
                case 2:
                    //objectname crystal
                    return new Frame(new Rectangle(101, 384, 97, 78), false);
                case 3:
                    //objectname icebox
                    return new Frame(new Rectangle(198, 384, 101, 101));
                case 4:
                    //objectname igloo
                    return new Frame(new Rectangle(299, 384, 511, 201), false);
                case 5:
                    //objectname sign_1
                    return new Frame(new Rectangle(0, 585, 87, 94), false);
                case 6:
                    //objectname sign_2
                    return new Frame(new Rectangle(87, 585, 87, 93), false);
                case 7:
                    //objectname snowman
                    return new Frame(new Rectangle(174, 585, 193, 210), false);
                case 8:
                    //objectname stone
                    return new Frame(new Rectangle(367, 585, 124, 78), false);
                case 9:
                    //objectname tree_1
                    return new Frame(new Rectangle(768, 0, 364, 280), false);
                case 10:
                    //objectname tree_2
                    return new Frame(new Rectangle(810, 280, 228, 280), false);
                case 11:
                    //tilename 1
                    return new Frame(new Rectangle(0, 0, 128, 128));
                case 12:
                    //tilename 2
                    return new Frame(new Rectangle(512, 128, 128, 128));
                case 13:
                    //tilename 3
                    return new Frame(new Rectangle(640, 128, 128, 128));
                case 14:
                    //tilename 4
                    return new Frame(new Rectangle(0, 256, 128, 128));
                case 15:
                    //tilename 5
                    return new Frame(new Rectangle(128, 256, 128, 128));
                case 16:
                    //tilename 6
                    return new Frame(new Rectangle(256, 256, 128, 128));
                case 17:
                    //tilename 7
                    return new Frame(new Rectangle(384, 256, 128, 128));
                case 18:
                    //tilename 8
                    return new Frame(new Rectangle(512, 256, 128, 128));
                case 19:
                    //tilename 9
                    return new Frame(new Rectangle(640, 256, 128, 128));
                case 20:
                    //tilename 10
                    return new Frame(new Rectangle(128, 0, 128, 128));
                case 21:
                    //tilename 11
                    return new Frame(new Rectangle(256, 0, 128, 128));
                case 22:
                    //tilename 12
                    return new Frame(new Rectangle(384, 0, 128, 128));
                case 23:
                    //tilename 13
                    return new Frame(new Rectangle(512, 0, 128, 128));
                case 24:
                    //tilename 14
                    return new Frame(new Rectangle(640, 0, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92));
                case 25:
                    //tilename 15
                    return new Frame(new Rectangle(0, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92));
                case 26:
                    //tilename 16
                    return new Frame(new Rectangle(128, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92));
                case 27:
                    //tilename 17
                    return new Frame(new Rectangle(256, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 29, 128, 128));
                case 28:
                    //tilename 18
                    return new Frame(new Rectangle(384, 128, 128, 128));
                case 29:
                    //tilename ladder_1
                    return new Frame(new Rectangle(0, 0, 128, 128));
                case 30:
                    //tilename ladder_2
                    return new Frame(new Rectangle(128, 0, 128, 128));
                case 31:


                default:
                    throw new System.IndexOutOfRangeException();
            }
        }
    }
}