using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionTest : MonoBehaviour
{
	[SerializeField] private Transform camera;
	private void Update()
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 100))
		{
			if (Mouse.current.leftButton.wasPressedThisFrame)
			{
				GameObject interactableObject = hit.collider.gameObject;
				if (interactableObject.GetComponent<Interactable>())
				{
					interactableObject.GetComponent<Interactable>().Interact();
				}
			}
		}
	}
}
