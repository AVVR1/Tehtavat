using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class BulletManager
	{
		public PoolingList<Bullet> bulletPool = new PoolingList<Bullet>();
		private Map currentMap;

		public BulletManager(Map currentMap)
		{
			this.currentMap = currentMap;
		}

		public void NewBullet(Vector2 position, Vector2 direction)
		{
			Bullet? bullet;
			if (bulletPool.activeIndex <= 0)
			{
				bullet = new Bullet(position, direction * 10);
				bulletPool.AddObject(bullet);
			}
			else
			{
				bullet = bulletPool.SetActivity(0, true);
				bullet.position = position;
				bullet.velocity = direction;
			}
		}

		public void UpdateBullets()
		{
			foreach (Bullet bullet in bulletPool.GetActiveList())
			{
				Console.WriteLine(bulletPool.GetIndex(bullet));
				bullet.Update();
				if (Map.IsSameColor(currentMap.GetImageColor(bullet.position), Material.Terrain.Color, 0))
				{
					// Bullet collision
					bulletPool.SetActivity(bulletPool.GetIndex(bullet), false);
					currentMap.MapDrawCircle(bullet.position, bullet.explosionRadius, Material.Empty.Color);
					currentMap.UpdateTexture();
				}
			}
		}

		public void DrawBullets()
		{
			foreach (Bullet bullet in bulletPool.GetActiveList())
			{
				bullet.Draw();
			}
		}
	}
}
