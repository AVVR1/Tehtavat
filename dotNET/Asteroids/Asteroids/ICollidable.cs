using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
	/// <summary>
	/// CIRCLE > RECTANGLE > ...
	/// </summary>
	public enum ColliderType { Circle, Rectangle }

	public interface ICollidable
	{
		public object hitbox { get; set; }

		public ColliderType colliderType { get; set; }

		public void OnCollide();
	}
}