using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {


	public List<GameObject> bundeve;
	public int oznacenaBundevaIdx;
	public float jacinaSile;
	public Text bodoviText;

	private Vector3 inicijalnaVelicina;
	private float uvecanjeOznacenog = 1.3f;
	private int bodovi = 0;

	private GameObject oznacenaBundeva {
		get {
			return bundeve[oznacenaBundevaIdx];
		}
	}

	// Use this for initialization
	void Start () {
		inicijalnaVelicina = oznacenaBundeva.transform.localScale;
		oznacenaBundeva.transform.localScale *= uvecanjeOznacenog;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("right")) {
			OznaciBundevu(true);
		}
		else if (Input.GetKeyDown("left")) {
			OznaciBundevu(false);
		}
		else if (Input.GetKeyDown("up")) {
			PrimjeniSilu();
		}
	}

	void OznaciBundevu (bool desno)
	{
		oznacenaBundeva.transform.localScale = inicijalnaVelicina;

		if (desno) {
			oznacenaBundevaIdx++;
		} else {
			oznacenaBundevaIdx--;
		}

		oznacenaBundevaIdx += bundeve.Count;
		oznacenaBundevaIdx %= bundeve.Count;

		oznacenaBundeva.transform.localScale *= uvecanjeOznacenog;
	}

	void PrimjeniSilu ()
	{
		//oznacenaBundeva.GetComponent<Rigidbody>().AddForce(Vector3.back * jacinaSile, ForceMode.Impulse);
		oznacenaBundeva.GetComponent<Rigidbody>().AddTorque(Vector3.left * jacinaSile, ForceMode.Impulse);
	}

	public void PovecajBodove ()
	{
		bodovi++;
		bodoviText.text = "Bodovi: " + bodovi;
	}
}
