using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {
		public StoryStrings[] StoryLines;
}

[System.Serializable]
public class StoryStrings {
	public string[] StoryText;
}