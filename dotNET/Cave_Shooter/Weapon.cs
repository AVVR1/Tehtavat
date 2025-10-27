using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Weapon
	{
		private string? name;
		private int bulletCount;
		private float reloadTime;
		private float recoil;
		private float knockback;
		private Sound sound;
		private Bullet? bullet;
	}
}
