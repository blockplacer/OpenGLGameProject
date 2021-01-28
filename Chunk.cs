using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon
{
    class Chunk
    {
        public int object_use = 0;
        public Vector3[] chunkdata =  new  Vector3[88* 88* 88];
        public static Vector3 position;
        public int xvtnxd;
        public Vector3 upbounds = new Vector3(88,88,88);
        public Vector3 lowbounds = new Vector3(-1, 0 , -1 );
        public void setPosition(Vector3 pos)
        {
            position = pos;
        }
        public Vector3 getPos()
        {
            return position;
        }
        public void objinstert(Vector3 pos)
        {
            chunkdata[object_use] = pos;
            object_use++;
        }
        public void generate()
        {
            Random rnd = new Random();
            int[] rnd_vlues = new int[88];
            int[] rndvlgn = new int[88];
            for (int x = 0; x < 88; x++)
            {
                rnd_vlues[x] = rnd.Next(1, 8);
            }
            for (int x = 0; x < 88-3; x++)
            {
                rndvlgn[x] = (rnd_vlues[x] - rnd_vlues[x + 1])* (rnd_vlues[x+1] - rnd_vlues[x + 2]); 
            }
        

            
            for (int x = 0 ; x < 15; x++)
            {
                for (int y = 0; y < 15; y++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                       


                                                            if (Program.Sys.numBetween((int)z+(int)getPos().Z, (int)lowbounds.Z, (int)upbounds.Z))
                        {
                            if  (Program.Sys.numBetween((int)x+(int)getPos().X, (int)lowbounds.X, (int)upbounds.X))
                            {
                                if (Program.Sys.numBetween((int)y+(int)getPos().Y, (int)lowbounds.Y, (int)upbounds.Y))
                                {

                                    objinstert(new Vector3(x + (((int)Math.Sqrt(x -rndvlgn[x]))/8),  (((int)Math.Sqrt(y -rndvlgn[x])) / 1.1f), z + (((int)Math.Sqrt(z - rndvlgn[x])) / 8))); //y +
                                }
                            }


                        }
                    }
               
            }
        
        }
        }
    }
}
