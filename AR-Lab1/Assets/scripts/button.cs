using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class button : MonoBehaviour {
	public Button yourButton;
	public GameObject buttonGO;
	public GameObject slime;
	public GameObject animal;
	public GameObject parent;
	public AudioSource myFx;
	public AudioClip clickFx;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		animal.SetActive(true);
		slime.SetActive(false);
		buttonGO.SetActive(false);
		parent.GetComponent<BoxCollider>().enabled = false;
	}

	public void ClickSound()
	{
		myFx.PlayOneShot (clickFx);
	}
}