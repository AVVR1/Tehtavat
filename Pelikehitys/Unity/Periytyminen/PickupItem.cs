using UnityEngine;

public class PickupItem : Interactable
{
	public override void Interact()
	{
		print("Ker‰‰ minut!");
		Destroy(gameObject, 2f);
	}
}
