using UnityEngine;

public class Merchant : Npc
{
	public string[] dialogue;
	public string name = "Kaapo";

	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, name);
		DialogueSystem.Instance.CreateDialogue();
	}
}
