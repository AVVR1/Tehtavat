using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal struct Material
	{
		public Color Color { get; private set; }

		public Material(Color color)
		{
			Color = color;
		}

		public static readonly Material Empty = new Material(new Color(0,0,0,0));
		public static readonly Material Terrain = new Material(Color.Green); 
	}
}
