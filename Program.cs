
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;

namespace Brickon
{
	public class Program : GameWindow
	{
		//<3

		List<Vector3> vecbuffer;
		//Consider this more or less a pointer to your model for now
		private int vao;
		//Consider this a pointer to the buffer responsible for vertex positions
		private int vbov;
		//Consider this a pointer to the buffer responsible for vertex colors
		private int vbc;

		private int vbt;

		Player player = new Player();//new Vector3(1, 1, 1);


		List<Vector3> blocks = new List<Vector3>();
		//private Shader shader;
		//should use debrecated stuff beacuse its easier keyboard doesnt work so going to rite that letter b
		/*		string vertexShaderSource = @"
	#version 330 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec3 col;

//we have to pass the vertex color to the fragment so
out vec3 vertexColor;
uniform mat4 view;
uniform mat4 model;
uniform mat4 projection;
void main(void)
{
    vertexColor = col;
 gl_Position = projection* view*model *vec4(pos, 1.0)  ;//* view *  model

    //gl_Position = vec4(pos, 1.0)*model*view*projection;
}


";
		string fragmentShaderSource = @"
		#version 330

in vec3 vertexColor;
out vec4 outputColor;
uniform float timedata;
float rand(vec2 co){
    return fract(sin(dot(co.xy ,vec2(11.9898,78.233))) * 43758.5453);
}

void main()
{
    outputColor = vec4(vertexColor.x,cos(vertexColor.y+timedata),vertexColor.z, 1.0);//+timedata
}


";*/
		/*		

				string vertexShaderSource = @"
	#version 330 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec3 col;

//we have to pass the vertex color to the fragment so
out vec3 vertexColor;
uniform mat4 view;
uniform mat4 model;
uniform mat4 projection;
out vec3 frag_position;
void main(void)
{
    vertexColor = col;
frag_position = vec3(model * vec4(vec3(pos), 1.0f));
 gl_Position = projection* view*model *vec4(pos, 1.0)  ;//* view *  model

    //gl_Position = vec4(pos, 1.0)*model*view*projection;
}


";
		string fragmentShaderSource = @"
		#version 330

in vec3 vertexColor;
out vec4 outputColor;
uniform float timedata;
in vec3 frag_position;
float rand(vec2 co){
    return fract(sin(dot(co.xy ,vec2(11.9898,78.233))) * 43758.5453);
}

void main()
{

float dist = distance(vec3(0,1,frag_position.z), frag_position);
  float attenuation =  max((1.0f / (dist * dist)), 0.25f) ;

    outputColor = vec4(vec3(attenuation/rand(vec2(gl_FragCoord.x,gl_FragCoord.y)/vec2(111,111))/33.3*distance(frag_position.z/30,gl_FragCoord.z/3)), 1.0);//+timedata vertexColor.x,cos(vertexColor.y+timedata),vertexColor.z
}


";
*/
		string vertexShaderSource = @"
	#version 330 core

layout(location = 0) in vec3 pos;
layout(location = 1) in vec3 col;
layout(location = 2) in vec2 tex;
//we have to pass the vertex color to the fragment so
out vec3 vertexColor;
out vec2 texCoords;
uniform mat4 view;
uniform mat4 model;
uniform mat4 projection;
out vec3 frag_Position;
void main(void)
{
    vertexColor = col;
frag_Position = vec3(model * vec4(pos, 1.0f));
 gl_Position = projection* view*model *vec4(pos, 1.0)  ;//* view *  model

texCoords = tex;
    //gl_Position = vec4(pos, 1.0)*model*view*projection;
}


";
		string fragmentShaderSource = @"
		#version 330

in vec3 vertexColor;
in vec2 texCoords;
out vec4 outputColor;
uniform float timedata;

uniform sampler2D texture1;
in vec3 frag_Position;
float rand(vec2 co){
    return fract(sin(dot(co.xy ,vec2(11.9898,78.233))) * 43758.5453);
}

void main()
{
float t = clamp(timedata / 6., 0., 1.);

 float dist = distance(vec3(0,1,1), frag_Position);

vec2 texCoord = vec2(gl_FragCoord.w/15.1+texCoords.x,gl_FragCoord.z*3+texCoords.y);

float attenuation =  max((8.0f / (dist * dist)), 0.25f) ;
    outputColor = texture(texture1,texCoord)*clamp(distance(frag_Position.z/30,gl_FragCoord.z/3),attenuation*3,888.0)  ;//*vec4(vertexColor.x,cos(vertexColor.y+timedata),vertexColor.z, 1.0);//+timedata;//
}";

		int texture;
		
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			GL.Viewport(0, 0, Width, Height);
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			Environment.Exit(420);
		}

		float time;

		protected override void OnLoad(EventArgs e)
		{
			//Ignore this
			base.OnLoad(e);
			
			//Set clear color
			GL.ClearColor(Color4.CornflowerBlue);

			//blocks.Add(new Vector3(888888, 88888, 888888));



			//Create the vao and vbos, don't worry about it now


			//Initialize the shader there
			//The file names for the respective shader program components
			//shader = new Shader("vertex.vert", "fragment.frag");
			//Bind the shader to set up some array pointers
			//shader.Use();
			//Bind the vertex array to set the shader pointers

			//Files.Binary(Files.BinaryString(vertexShaderSource), "SHAD.BIN");

			vertexShaderSource = Files.FileToString("SHAD.BIN");
			
			ShaderGen(vertexShaderSource, fragmentShaderSource, new Vector3(0, 0, -5), out shader);
			texture = Textures.Tex(new Bitmap("grass.png"));
			Console.WriteLine(vertexShaderSource);
			Stuff.vertices = new List<Vector3>();
			Stuff.colors = new List<Vector3>();
			Stuff.texcoords = new List<Vector2>();
			Random rnd = new Random();
			/**/

			chunks.Add(new Chunk());


			Chunk chunk = new Chunk();

			chunk.generate();

			chunk.setPosition(new Vector3(1, 1, 1));
			chunks.Add(chunk);

			vertexGen(vao, vbov, vbc,vbt, out vao, out vbov, out vbc,out vbt);

			MouseMove += mouseMovement;
			//Task.Run(vbo);

			//Why create the buffer there when you can do it on render and load the cpu every frame for creating the triangle
		}


		


		Matrix4 model;

		public void vertexGen( int vao___, int vbov___, int vbc___,int vbt,out int vao_,out int vbov_, out int vbc_,out int vbt_)
		{
			vao___ = GL.GenVertexArray();
			vbov___ = GL.GenBuffer();
			vbc___ = GL.GenBuffer();
			vbt = GL.GenBuffer();
			GL.BindVertexArray(vao___);
			//No clue what I did exactly but array locations might be hardcoded in the shader
			GL.EnableVertexAttribArray(0);
			GL.EnableVertexAttribArray(1);
			GL.EnableVertexAttribArray(2);
			//Set some info for the shader to know how big each buffer, how many bytes each element take, their offset, etc their kind
			//Bind the buffer we want to be used in the "slot" we specify in the next call
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbov___);
			//We have a vector 3 for the positions so 3 floats, not normalized, the stride is 3 because we don't store anything else in this buffer and offset 0 because we start from start
			GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);//vertices.Count
																									 //Same but for the colors
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbc___);
			GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);//colors.Count
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbt);
			GL.VertexAttribPointer(2, 3, VertexAttribPointerType.Float, false, 2 * sizeof(float), 0);//colors.Count
			vao_ = vao___;
			vbov_ = vbov___;
			vbc_ = vbc___;
			vbt_ = vbt;
		}
		Matrix4 view;
		public void ShaderGen(string vertshad,string fragshad,Vector3 position,out int shader)
		{ int fragmentShadInf, vertexShadInf, shaderProgramHandle;
			
			vertexShadInf = GL.CreateShader(ShaderType.VertexShader);
			fragmentShadInf = GL.CreateShader(ShaderType.FragmentShader);
			
			GL.ShaderSource(vertexShadInf, vertshad);
			GL.ShaderSource(fragmentShadInf, fragshad);

			GL.CompileShader(vertexShadInf);
			GL.CompileShader(fragmentShadInf);

			

			// Create program
			shaderProgramHandle = GL.CreateProgram();
			
			GL.AttachShader(shaderProgramHandle, vertexShadInf);
			GL.AttachShader(shaderProgramHandle, fragmentShadInf);

			GL.LinkProgram(shaderProgramHandle);

			


			GL.UseProgram(shaderProgramHandle);


			model = Matrix4.Identity * Matrix4.CreateTranslation(position);

			
			

			Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians( 45f), Width / (float)Height, 0.1f, 100.0f);

			
			int modelloc = GL.GetUniformLocation(shaderProgramHandle, "model");
			int projectloc = GL.GetUniformLocation(shaderProgramHandle, "projection");
			int texLoc = GL.GetUniformLocation(shaderProgramHandle, "texture1");
			GL.UniformMatrix4(modelloc, false, ref model);
			
			
			GL.UniformMatrix4(projectloc, false, ref projection);

			GL.Uniform1(texLoc, texture);

			shader = shaderProgramHandle;

			

		}
		
		public void transform(float x,float y,float z,in int shader,out int shader_)
		{
			model = Matrix4.Identity * Matrix4.CreateTranslation(x+player.getPos().X, y+player.getPos().Y, z+player.getPos().Z);
			int modelloc = GL.GetUniformLocation(shader, "model");
			GL.UniformMatrix4(modelloc, false, ref model);
			shader_ = shader;
		}
		public void vbogen(int vbov,int vb,int vbt)
		{



			GL.BindVertexArray(0);

			//Some bad equivalent to GL.End
			//Bind the buffer which to be used
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbov);
			//Send data to bound buffer in the specified "slot"
			//The kind of buffer, The size of the array i(the array length * size of an element), The data(because we had a list we convert it to an array), Buffer Usage, doesn't matter that much nowadays
			GL.BufferData(BufferTarget.ArrayBuffer, Stuff.vertices.Count * Vector3.SizeInBytes, Stuff.vertices.ToArray(), BufferUsageHint.DynamicDraw);//StaticDraw
																																//Same thing but for colors
			GL.BindBuffer(BufferTarget.ArrayBuffer, vb);
			GL.BufferData(BufferTarget.ArrayBuffer, Stuff.colors.Count * Vector3.SizeInBytes, Stuff.colors.ToArray(), BufferUsageHint.DynamicDraw);//StaticDraw
			GL.BindBuffer(BufferTarget.ArrayBuffer, vbt);
			GL.BufferData(BufferTarget.ArrayBuffer, Stuff.texcoords.Count * Vector2.SizeInBytes, Stuff.texcoords.ToArray(), BufferUsageHint.DynamicDraw);//StaticDraw

		}



		int shader;

		int dt;

		bool upd;
		Chunk chunk = new Chunk();
		List<Chunk> chunks = new List<Chunk>();

		float y_direction = -353;

		protected override void OnRenderFrame(FrameEventArgs e)
		{
			//Ignore this too
			base.OnRenderFrame(e);
			//Mouse.SetPosition(Width / 1, Height / 1);
			//Clear the window
			GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			GL.Enable(EnableCap.DepthTest);
			int timeloc = GL.GetUniformLocation(shader, "timedata");
			GL.Uniform1(timeloc, time);
			dt = (int)e.Time;

		
			
			view = Matrix4.CreateTranslation(new Vector3(0, 0, 0)) * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(player.GetCamera().getYaw())) * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(y_direction)); //3;
			int vl = GL.GetUniformLocation(shader, "view");
			GL.UniformMatrix4(vl, false, ref view);

			
			player.ChunkNumber = 1;
				if(upd == true)
			{
				Stuff.vertices = new List<Vector3>();
			Stuff.colors = new List<Vector3>();
			Stuff.texcoords = new List<Vector2>();

			}
			//List<Vector3> chunkdata = new List<Vector3>(chunks[player.ChunkNumber].chunkdata);
			/*if (chunkdata.Contains(new Vector3((int)player.getPos().X, (int)player.getPos().Y, (int)player.getPos().Z)))
			{
				Console.WriteLine("detection");
				collision = true;
			}else
			{
				collision = false;
			}*/
			/*for (int x = 1; x < 88; x++)
			{

	for (int y = 0; y < 11; y++)
	/*{
					blockobject(x- (int)MathHelper.DegreesToRadians((int)time * 8888 / 18 - x / x*1.1f) * x / 83, 1, (int)MathHelper.DegreesToRadians((int)time*8888/18*x)  );/////  + new Random().Next(1, 5)  -8 )*x/838+(x/888 838/
																																															   // for (int z = 0; z < 33; z++)
																																															   // {
																																															   //blockobject(x - (int)time * 8888 / 18, 1, (int)MathHelper.DegreesToRadians((int)time * 8888 / 18) * x / 18);
				}
	//}/**//**/
			/*//**/

			//




			/*


			}*/

			if (upd == true)
			{
				for (int i = 0; i < chunks[player.ChunkNumber].object_use; i++)
			{

				Stuff.blockobject((int)chunks[player.ChunkNumber].chunkdata[i].X+(int)chunks[player.ChunkNumber].getPos().X, (int)chunks[player.ChunkNumber].chunkdata[i].Y+(int)chunks[player.ChunkNumber].getPos().Y, (int)chunks[player.ChunkNumber].chunkdata[i].Z+(int)chunks[player.ChunkNumber].getPos().Z);
	
			}
			}
 

			Console.WriteLine(Stuff.vertices.Count);
			//Console.WriteLine(Files.HexString("test"));
			vbogen(vbov, vbc, vbt);

			GL.BindVertexArray(vao);
			//Finally we DrawArrays to draw
			//We draw triangles, we start from 0 and we have0 3 vertices
			//model = Matrix4.Identity * Matrix4.CreateTranslation(1, 0, -5);

			transform(0, 0, -5, shader, out shader);
			GL.DrawArrays(PrimitiveType.Triangles, 0, Stuff.vertices.Count);


			time += 0.1f;
			SwapBuffers();
		}
		bool object_inst;

		bool IsClose(float a, float b, float tolerance)
		{
			return Math.Abs(a - b) < tolerance;
		}
		
		void mouseMovement(object sender, MouseMoveEventArgs e)
		{

			player.GetCamera().setYaw(e.XDelta);
			//y_direction = ;
			if(Sys.numBetween(Mouse.GetState().Y, -100, 111))
			{
				//if(y_direction<358)
				//{
					y_direction =   Mouse.GetState().Y  ;
				//}
			}
			Console.WriteLine(Mouse.GetState().Y);
												//player.GetCamera().setYaw(e);
		}
		protected override async void OnUpdateFrame(FrameEventArgs e)
		{
			var input = Keyboard.GetState();
			if (this.Focused == true)
			{
				
				if (input.IsKeyDown(Key.Escape))
				{
					Exit();
				}
				if (input.IsKeyDown(Key.W))
				{

					bool collision = false;

					for (int i = 0; i < chunks[player.ChunkNumber].object_use; i++)
					{


						/*		if (
						(-player.getPos().X <= 1.0f + (int)chunks[player.ChunkNumber].chunkdata[i].X && 0.5f + -player.getPos().X >= (int)chunks[player.ChunkNumber].chunkdata[i].X) &&
						(-player.getPos().Y <= 1.0f + (int)chunks[player.ChunkNumber].chunkdata[i].Y+1 && 0.5f + -player.getPos().Y >= (int)chunks[player.ChunkNumber].chunkdata[i].Y+1) &&
						(-player.getPos().Z <= 1.0f + (int)chunks[player.ChunkNumber].chunkdata[i].Z-5 && 0.5f + -player.getPos().Z >= (int)chunks[player.ChunkNumber].chunkdata[i].Z-5)
					   )
							collision = true;
							*/

						if ((Sys.numBetween(-player.getPos().X, chunks[player.ChunkNumber].chunkdata[i].X, chunks[player.ChunkNumber].chunkdata[i].X + 1.5f))
							&& (Sys.numBetween(-player.getPos().Z, chunks[player.ChunkNumber].chunkdata[i].Z-5, chunks[player.ChunkNumber].chunkdata[i].Z-5 + 1.8f))&&
							(-player.getPos().Y <= 1.0f + (int)chunks[player.ChunkNumber].chunkdata[i].Y + 1 && 0.5f + -player.getPos().Y >= (int)chunks[player.ChunkNumber].chunkdata[i].Y + 1)
							)
						{
							//if(Sys.numBetween(-player.getPos().Y,(int)chunks[player.ChunkNumber].chunkdata[i].Y-1, (int)chunks[player.ChunkNumber].chunkdata[i].Y-1 + 0.5f))
							//{
								collision = true;
							//}
						}
						

						//if(Sys.numBetween(-player.getPos().Y, chunks[player.ChunkNumber].chunkdata[i].Y, chunks[player.ChunkNumber].chunkdata[i].Y))





						/*	if (CollisionDetection.collisionDetectionBox(new Vector3(player.getPos().X, player.getPos().Y+1, player.getPos().Z), new Vector3(2+chunks[player.ChunkNumber].chunkdata[i].X, 0-chunks[player.ChunkNumber].chunkdata[i].Y, 0+-chunks[player.ChunkNumber].chunkdata[i].Z),new Vector3(chunks[player.ChunkNumber].chunkdata[i].X,  chunks[player.ChunkNumber].chunkdata[i].Y,chunks[player.ChunkNumber].chunkdata[i].Z))
								)
							{*/

						//player.GetCamera().walkBackwards(8 * (float)e.Time*new Random().Next(1,8));
						//break;
						//System.out.println("Player is colliding!!!");
						/*		}

								//
							}*/


					}

							//player.setColCoords(new Vector3(player.getColCoords().X, player.getColCoords().Y,player.getColCoords().Z + 1));

							if (collision == false)
					player.GetCamera().walkForward(8 * (float)e.Time);
					
				}

				if (input.IsKeyDown(Key.S))
				{
					player.GetCamera().walkBackwards(8 * (float)e.Time);

				}

				if (input.IsKeyDown(Key.D))
				{
					player.GetCamera().walkRight(8 * (float)e.Time);
				}

				if (input.IsKeyDown(Key.A))
				{
					player.GetCamera().walkLeft(8 * (float)e.Time);

				}

				if (input.IsKeyDown(Key.E))
				{
					player.setY(player.getPos().Y - 0.1f);

				}
				if (input.IsKeyDown(Key.V))
				{

					player.setY(player.getPos().Y + 0.1f);

				}
				if (input.IsKeyDown(Key.Space))
				{
					for (int xj = 0; xj < 9; xj++)
					{
						player.setY(player.getPos().Y - 0.1f * (float)e.Time);
						await Sys.waitFunction(1);
					}
				}
				if (input.IsKeyDown(Key.Y))
				{
					List<Vector3> chunkdata = new List<Vector3>(chunks[player.ChunkNumber].chunkdata);
					if (!chunkdata.Contains(new Vector3((int)-player.getPos().X, (int)-player.getPos().Y, (int)-player.getPos().Z + 5)))
					{
						upd = true;
						

						for (int x = 0; x < 1; x++)
                        {
							/*			if (x >= -chunks[player.ChunkNumber].upbounds.Z && x <= 8888)
										{
											Console.WriteLine(chunks[player.ChunkNumber].upbounds+":"+x);
										}*/
							if (!chunkdata.Contains(new Vector3((int)-player.getPos().X, (int)-player.getPos().Y, (int)-player.getPos().Z + 5+x)))
							{
								if (Sys.numBetween((int)-player.getPos().Z +x, (int)chunks[player.ChunkNumber].lowbounds.Z ,(int)chunks[player.ChunkNumber].upbounds.Z))
							{
								if(Sys.numBetween((int)-player.getPos().X ,(int)chunks[player.ChunkNumber].lowbounds.X , (int)chunks[player.ChunkNumber].upbounds.X)){
									if (Sys.numBetween((int)-player.getPos().Y , (int)chunks[player.ChunkNumber].lowbounds.Y ,(int)chunks[player.ChunkNumber].upbounds.Y))
									{
										chunks[player.ChunkNumber].chunkdata[chunks[player.ChunkNumber].object_use] = new Vector3((int)-player.getPos().X, (int)-player.getPos().Y, (int)-player.getPos().Z + 5+x);
							chunks[player.ChunkNumber].object_use++;
									}
								}


							}
							}
						}
						await Sys.waitFunction(88);
						upd = false;

					}
				}
				if (input.IsKeyDown(Key.H))
				{
					object_inst = true;
					if (object_inst == true)
					{
						for (int x = 0; x < blocks.Count; x++)
						{
							for (int i = (int)-player.getPos().Z; i < (int)-player.getPos().Z + 8; i++)
							{
								if ((int)blocks[x].X == (int)-player.getPos().X)
								{

									if ((int)blocks[x].Z == i)
									{
										if (!Stuff.vertices.Contains(new Vector3(+0.5f + player.getPos().X, +0.5f + -player.getPos().Y, -0.5f + i - 1)))
										{

											blocks.Add(new Vector3(x - (int)player.GetCamera().getYaw() / 18, 1, (int)MathHelper.DegreesToRadians((int)player.GetCamera().getYaw() * 8888 / 18) * i / 18));
										}
									}
								}

							}


						}

					}
					object_inst = false;
				}
				base.OnUpdateFrame(e);
			}

		}
		
		public static class Sys
		{

			public static async Task waitFunction(int time)
			{
				await Task.Delay(time);
			}

			public static bool numBetween(int number, int min, int max)
			{
				bool returnnum;
				if ((number - max) * (number - min) <= 0)
				{
					returnnum = true;
				}
				else
				{ returnnum = false; }

				return returnnum;
			}
			public static bool numBetween(float number, float min, float max)
			{
				bool returnnum;
				if ((number - max) * (number - min) <= 0)
				{
					returnnum = true;
				}
				else
				{ returnnum = false; }

				return returnnum;
			}

		}

		[STAThread]
		public static void Main()
		{
			using (Program example = new Program())
			{
				example.VSync = VSyncMode.On;
				
				example.Run();
			}
		}

	}
}