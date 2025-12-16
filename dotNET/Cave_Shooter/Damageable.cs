using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class Damageable
	{
		private IHealth? iHealth;

		internal float maxHealth;
		internal float health;
		internal bool isDead;

		public void TakeDamage(float amount)
		{
			if (health - amount > 0)
			{
				health -= amount;
				(this as IHealth)?.OnHurt();
			}
			else if (!isDead)
			{
				health = 0;
				(this as IHealth)?.OnDeath();
				isDead = true;
			}
		}
	}
}
