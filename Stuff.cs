using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon
{
    public static class Stuff
    {



		public static List<Vector3> vertices;
		public static List<Vector3> colors;
		public static List<Vector2> texcoords;


		public static void vertex(float x, float y, float z, Color col, List<Vector3> vert_list,List<Vector3> col_list)
		{
			vert_list.Add(new Vector3(x, y, z));
			col_list.Add(new Vector3(col.R, col.G, col.B));

		}
		public static void vertex(float x, float y, float z, List<Vector3> vert_list, List<Vector3> col_list)
		{
			vert_list.Add(new Vector3(x, y, z));
			col_list.Add(new Vector3(1, 1, 1));

		}
		public static List<Vector3> vertices_ = new List<Vector3>();
		public static List<Vector3> col_____ = new List<Vector3>();
		public static void blockobject(int x, int y, int z)
		{


			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, +0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));
			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, +0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			texcoords.Add(new Vector2(0.0f, 0.0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			texcoords.Add(new Vector2(1.0f, 0.0f));
			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			texcoords.Add(new Vector2(0.5f, 1.0f));

		}
		public static void block(int x, int y, int z)
		{


			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			vertices.Add(new Vector3(+0.5f + x, +0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			vertices.Add(new Vector3(-0.5f + x, +0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			vertices.Add(new Vector3(+0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			vertices.Add(new Vector3(-0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			vertices.Add(new Vector3(+0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			vertices.Add(new Vector3(0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			vertices.Add(new Vector3(0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			vertices.Add(new Vector3(-0.5f + x, +0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, 0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			vertices.Add(new Vector3(-0.5f + x, 0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(1f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(0.5f, 1f, 0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));

			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, -0.5f + z));
			colors.Add(new Vector3(-0.5f, 0f, 0f));
			vertices.Add(new Vector3(+0.5f + x, -0.5f + y, 0.5f + z));
			colors.Add(new Vector3(0f, 1f, 0f));
			vertices.Add(new Vector3(-0.5f + x, -0.5f + y, +0.5f + z));
			colors.Add(new Vector3(0f, 0f, 1f));
			vertices_ = vertices;
			col_____ = colors;
		}

	}
}
