using UnityEngine;
using System.Collections;

public class Lineactivator : MonoBehaviour {

 
	
	// Update is called once per frame
	void Update () {
	

		if(Input.GetKeyDown(KeyCode.Space))
		{
			activator();
		}

	}

	public void activator()

	{
		RaycastHit hitout;

		if(Physics.Raycast(transform.position,Vector3.forward, out hitout))
		{

			if( hitout.transform.gameObject.transform.renderer.material.name == "notchosenmat (Instance)")
			{
			
				hitout.transform.renderer.material = hitout.transform.GetComponent<Lineaction>().ownermat;
				hitout.transform.GetComponent<Lineaction>().lineowner = 2;
			}

			hitout.transform.SendMessage ("hitbyray");
		}

	}
}
