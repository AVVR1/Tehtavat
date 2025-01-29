using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
	public static DialogueSystem Instance { get; private set; }
	private void Awake()
	{
		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public List<string> dialogueList;
	public void AddNewDialogue(string[] lines, string name)
	{
		foreach (string line in lines)
		{
			dialogueList.Add($"{name}: {line}");
		}
	}
	public void CreateDialogue()
	{
		foreach(string line in dialogueList)
		{
			print(line);
		}
	}
}
