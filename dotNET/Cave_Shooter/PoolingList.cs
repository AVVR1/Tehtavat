using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cave_Shooter
{
	internal class PoolingList<T>
	{
		public int activeIndex { get; private set; } = 0;

		public List<T> list = new List<T>();

		public List<T> GetActiveList()
		{
			return list.Skip(activeIndex).ToList();
		}

		public int GetIndex(T obj)
		{
			return list.IndexOf(obj);
		}

		public void AddObject(T obj)
		{
			list.Add(obj);
		}

		//Inactive bullets are at the beginning of the array
		/// <summary>
		/// Pools or unpools an item in the list, by activating or deactivating it.
		/// </summary>
		/// <param name="index">index of the object to pool</param>
		/// <param name="activate">whether to activate or deactivate</param>
		public T? SetActivity(int index, bool activate)
		{
			if (index >= list.Count)
				// Index out of range
				return default;
			if (activate)
			{
				// Activate
				T swap = list[index];
				T lastDeactive = list[activeIndex - 1];
				list[activeIndex - 1] = swap;
				list[index] = lastDeactive;
				
				activeIndex--;
				return list[activeIndex];
			}
			else
			{
				// Deactivate
				T swap = list[index];
				T firstActive = list[activeIndex];
				list[activeIndex] = swap;
				list[index] = firstActive;

				activeIndex++;
				return list[0];
			}
		}
	}
}
