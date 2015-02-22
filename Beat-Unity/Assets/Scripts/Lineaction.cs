using UnityEngine;
using System.Collections;

public class Lineaction : MonoBehaviour {

	//raycast variables
	private bool ownerchosen = false;
	public int lineowner = 0;
	public int randomrot =0;

	//testcode
	public bool firstime = true;
	//testcode
	//line variables
	public GameObject centerarrow;
	public Material ownermat;
	public Material takermat;


	//centerarrow code
	//collection of rotations
	public float[] centerarrowrotation;
	//opponent speed coroutine wait time
	public float opspeed =0;
	//location in rotation array
	public int chosenrotationcounter =0;
	//original rotation of arrow
	private Quaternion originalrotation;



	// Use this for initialization
 void Start () {
 
		randomrot = Random.Range(0,centerarrowrotation.Length -1);

 	}
	
 
	void Update () {

	}

	public void hitbyray()

	{
		Debug.Log ("I was hit by a Ray");

		if(!ownerchosen)
		{		
		centerarrow = gameObject.transform.FindChild("linearrow").gameObject;
		originalrotation = centerarrow.transform.rotation;
		
		ownerchosen = true;
		
	 centerarrow.transform.Rotate(0,centerarrowrotation[randomrot],0);
 
			linebehavoir();
		}

	}


	public void linebehavoir()
	{


		RaycastHit hitout;

		if(Physics.Raycast(centerarrow.transform.position,centerarrow.transform.TransformDirection(Vector3.forward), out hitout))
		{
			print ("looking out there");

			if(hitout.transform.GetComponent<Lineaction>().lineowner == 0)
			{	
				hitout.transform.renderer.material = hitout.transform.GetComponent<Lineaction>().ownermat;
				hitout.transform.GetComponent<Lineaction>().lineowner = 2;
				hitout.transform.SendMessage ("hitbyray");
			}
			else
			{
				if(firstime){
				chosenrotationcounter = randomrot +1;
					firstime = false;
				}

			}
		
			if(chosenrotationcounter> centerarrowrotation.Length -1)
			{
				chosenrotationcounter = 0; 
			}
		}

		centerarrow.transform.Rotate(0,centerarrowrotation[chosenrotationcounter],0);
		StartCoroutine(Opponentspeed());

	}


	IEnumerator Opponentspeed()
	{
		yield return new WaitForSeconds (opspeed);
 
		chosenrotationcounter =  chosenrotationcounter +1;
		centerarrow.transform.rotation = originalrotation;
	 
		linebehavoir();

	}



}
