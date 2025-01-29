using UnityEngine;

public class Smith : Npc
{
	public string[] dialogue;
	public string name = "Seppo";

	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, name);
		DialogueSystem.Instance.CreateDialogue();
	}
}
