using UnityEngine;
using System.Collections;

public class DisableMeshAtRuntime : MonoBehaviour {

	// Use this for initialization
	void Start () {
	GetComponent<Renderer>().enabled = false;
	}
	
}
