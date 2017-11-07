using UnityEngine;
using System.Collections;

public class Prompt : MonoBehaviour { //NOTE: this class inherits from MonoBehaviour, which allows it to be added to a game object as a component (and edited in the inspector)
	public bool useTimer;
	public bool TimerForceChoice = false;
	public int TimerForceOptionInt;
	public bool hideTimer = false;
	public bool useInsecure;
	public bool noPointer = false;
	public float time;
	public string promptString; //the text to display for this prompt
	public PromptOption[] promptOptions; //the list of options associated with this prompt. this is an array of a custom class, which is our key to creating arbitrarily deep data structures
}
	
[System.Serializable] //this tells Unity to let instances of this class be modifiable via the Unity Inspector
	public class PromptOption { //NOTE: this class does NOT inherit from monobehaviour; it is just a custom data structure
	public string optionString; //the text to display for this option
	public Font fontFace;
	public TextAnchor alignment;
	public Prompt optionPrompt; //the prompt to display when this option is chosen by the user
	public int nextLinesInt;
	public int startingInt;
	public AudioClip sound;
	public Sprite picture;
	public string[] grantedKeys = new string[] {}; //a list of string keys that this option will grant, when selected
	public string[] requiredKeys = new string[] {}; //a list of string keys that this option requires in order to appear
	public string[] forbiddenKeys = new string[] {}; //this option will not appear if any of these string keys are owned
}