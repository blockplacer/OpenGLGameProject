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
		public Camera GetCamera()
		{
			return camera;
		}

	}
	public class Camera
	{
		public static float yaw;

		public void setYaw()
		{
			yaw = OpenTK.Input.Mouse.GetCursorState().X;
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

		}
		public void walkBackwards(float distance)
		{
			// double yaw_ =  (Math.PI / 180) * yaw;


			Player.Position.X += distance * (float)Math.Sin((Math.PI / 180) * yaw);
			Player.Position.Z -= distance * (float)Math.Cos((Math.PI / 180) * yaw);
		}
		public void walkRight(float distance)
		{
			// double yaw_ =  (Math.PI / 180) * yaw;

			Player.Position.X -= distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);
			Player.Position.Z += distance * (float)Math.Cos((Math.PI / 180) * -yaw - 90); //
		}

		public void walkLeft(float distance)
		{
			Player.Position.X += distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);
			Player.Position.Z -= distance * (float)Math.Cos((Math.PI / 180) * -yaw - 90); // // // // // // // //

		}
		public void walk__(float distance)
		{

			Player.Position.Y += distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);

			Player.Position.Y -= 0.1f;
		}

	}

}
