using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed : MonoBehaviour
{
	public GameObject button1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTouchDown()
    {
        Debug.Log("on touch down feed");
        //transform.Find("Slime").gameObject.SetActive(false);
        //transform.Find("animal").gameObject.SetActive(true);
        //gameObject.GetComponent<BoxCollider>().enabled = false;
    }

    private void OnTriggerEnter (Collider other)
	{
		button1.SetActive(true);

	}
	private void OnTriggerExit (Collider other)
	{
		Debug.Log("exit");
		button1.SetActive(false);
	}
}
