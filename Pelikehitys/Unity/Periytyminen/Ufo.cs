public class Ufo : ActionItem
{
	public string[] dialogue;
	public string name = "Otus";
	public override void Interact()
	{
		DialogueSystem.Instance.AddNewDialogue(dialogue, name);
		DialogueSystem.Instance.CreateDialogue();
	}
}
