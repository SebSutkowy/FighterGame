using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace SchoolFighter
{
     class TileMap
    {
        

        public static Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();

        public TileMap()
        {

            for (int i = 0; i < 16; i++)
            {
                Debug.WriteLine(i);
                //tiles.Add(new Vector2((i % 3 * 100), (i / 3 * 100)), new Tile(100, new Vector2((i % 3 * 100), (i / 3 * 100)), Game1._pixelTemplate));
                if (i == 3)
                {
                   //tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));

                }
                if (i == 4)
                {
                    Debug.WriteLine($"{(i % 5) * 100},{(i / 5) * 100}");
                    tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));
                    
                }
                if (i == 5)
                {
                    tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));

                }
             
                if (i == 10)
                {
                    tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));

                }
                if (i == 12)
                {
                    tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));

                }
                if (i == 20)
                {
                    tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));

                }
                if (i == 22)
                {
                    tiles.Add(new Vector2(((i % 5) * 100), ((i / 5) * 100)), new Tile(100, new Vector2(((i % 5) * 100), ((i / 5) * 100)), Game1._pixelTemplate));

                }
                
               
                

                




            }
        }



        public void DrawTiles()
        {
            foreach (KeyValuePair<Vector2, Tile> tile in tiles)
            {
                tile.Value.Draw(Game1._spriteBatch);

            }

        }






    }
}
    

