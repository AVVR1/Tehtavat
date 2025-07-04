﻿using ClassLibrary1;
using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	public static class CollisionManager
	{
		public static List<ICollidable> collidables;

		static CollisionManager()
		{
			collidables = new List<ICollidable>();
		}

		/// <summary>
		/// Returns a tuple of the two collidables, ordered by their colliderType.
		/// <br></br>The colliders come out in the same order they are created.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static (ICollidable, ICollidable) Normalize(ICollidable a, ICollidable b)
		{
			(ICollidable,ICollidable) tuple = a.colliderType <= b.colliderType ? (a, b) : (b, a);
			return (tuple.Item1, tuple.Item2);
		}

		public static void CheckCollisions()
		{
			for (int i = collidables.Count -1; i >= 0; i--)
			{
				for (int j = i -1; j >= 0; j--)
				{
					if (i >= collidables.Count && i != 0)
					{
						i = collidables.Count - 1;
					}
					if (j >= i && j != 0)
					{
						j = i - 1;
					}
					if (i >= collidables.Count)
					{
						break;
					}
					if (j >= i)
					{
						Console.BackgroundColor = ConsoleColor.Red;
						break;
					}
					ICollidable c1 = collidables[i];
					ICollidable c2 = collidables[j];
					(c1, c2) = Normalize(c1, c2);

					Movable m1 = (Movable)c1;
					Movable m2 = (Movable)c2;

					switch (c1.colliderType, c2.colliderType)
					{
						case (ColliderType.Circle, ColliderType.Circle):
							if (Raylib.CheckCollisionCircles(m1.position, (float)c1.hitbox, m2.position, (float)c2.hitbox))
							{
								c1.OnCollide(c2);
								c2.OnCollide(c1);
							}
						break;
						case (ColliderType.Circle, ColliderType.Rectangle):
							if (Class1.CheckCollisionCircleRecPro(m1.position, (float)c1.hitbox, new Rectangle(m2.position, (Vector2)c2.hitbox), m2.rotation))
							{
								c1.OnCollide(c2);
								c2.OnCollide(c1);
							}
						break;
						case (ColliderType.Rectangle,ColliderType.Rectangle):
							if (Raylib.CheckCollisionRecs(new Rectangle(m1.position, (Vector2)c1.hitbox), new Rectangle(m2.position, (Vector2)c2.hitbox)))
							{
								c1.OnCollide(c2);
								c2.OnCollide(c1);
							}
						break;
					}
				}
			}
		}
	}
}
