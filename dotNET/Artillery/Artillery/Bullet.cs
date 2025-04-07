using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using Newtonsoft.Json;

namespace Artillery
{
	internal class Bullet
	{
		public Vector2 position;
		Vector2 bulletDir = new Vector2(0,0);
		public Color color = Color.White;
		public string name = "default_bullet";
		public float weight = 10;
		public float explosionForce = 10;
		public float size = 3;
		public double explosionTime;

		Vector2 gravity = new Vector2(0,9.8f);
		Vector2 velocity;
		Vector2 acceleration;

		public Bullet(Bullet prefab)
		{
			this.name = prefab.name;
			this.weight = prefab.weight;
			this.explosionForce = prefab.explosionForce;
			this.size = prefab.size;
		}

		public Bullet() { }

		public static Bullet JsonToBullet(string filename)
		{
			Bullet bullet = new Bullet();
			if (File.Exists(filename))
			{
				string text = File.ReadAllText(filename);
				try
				{
					bullet = JsonConvert.DeserializeObject<Bullet>(text);
				}
				catch (JsonReaderException exp)
				{
                    Console.WriteLine(exp.Message);
				}
			}
			return bullet;
		}

		public void Update()
		{
			float deltaTime = Raylib.GetFrameTime();
			acceleration = Vector2.Zero;

			acceleration += gravity * 30;

			velocity += acceleration * deltaTime;
			position += velocity * deltaTime;
		}

		public void Init(Vector2 startPos, Vector2 startDir, float speed)
		{
			position = startPos;
			bulletDir = startDir;
			velocity = startDir * (speed * 10) / weight;
		}

		public void Draw()
		{
			Raylib.DrawCircleV(position, size, Color.White);
		}
	}
}
