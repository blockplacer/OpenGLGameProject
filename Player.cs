using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon
{
    public class Player
    {
       public static  Vector3 Position = new Vector3();
		// public Vector3 col_coords = new Vector3(0, 0, 0);
		public static Camera camera = new Camera();

		 
       public  int ChunkNumber;

		public Vector3 getPos()
		{
			return Position;
		}
		public void setY(float y)
		{
			Position.Y = y;
		}
		public void setX(float x)
		{
			Position.X = x;
		}
		public void setZ(float z)
		{
			Position.Z = z;
		}
		public Camera GetCamera()
		{
			return camera;
		}
		/*public Vector3 getColCoords()
		{
			return col_coords;
		}
		public void setColCoords(Vector3 colcoords)
		{
			col_coords = colcoords;
		}*/
	}
	public class Camera
	{
		public static float yaw;

		public void setYaw(float yawvl)
		{
			yaw += yawvl;
		}
		public float getYaw()
		{
			return yaw;
		}
		public void walkForward(float distance)
		{
			// double yaw_ =  (Math.PI / 180) * yaw;
			Player.Position.X -= distance * (float)Math.Sin((Math.PI / 180) * yaw);
			Player.Position.Z += distance * (float)Math.Cos((Math.PI / 180) * yaw);
			
			//Player.col_coords.Z ++;

		}
		public void walkBackwards(float distance)
		{
			// double yaw_ =  (Math.PI / 180) * yaw;


			Player.Position.X += distance * (float)Math.Sin((Math.PI / 180) * yaw);
			Player.Position.Z -= distance * (float)Math.Cos((Math.PI / 180) * yaw);
			//Player.col_coords.Z--;
		}
		public void walkRight(float distance)
		{
			// double yaw_ =  (Math.PI / 180) * yaw;

			Player.Position.X -= distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);
			Player.Position.Z += distance * (float)Math.Cos((Math.PI / 180) * -yaw - 90); //
			//Player.col_coords.X--;
		}

		public void walkLeft(float distance)
		{
			Player.Position.X += distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);
			Player.Position.Z -= distance * (float)Math.Cos((Math.PI / 180) * -yaw - 90); // // // // // // // //
			//Player.col_coords.X++;

		}
		public void walk__(float distance)
		{

			Player.Position.Y += distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);

			Player.Position.Y -= 0.1f;
		}

	}

}
