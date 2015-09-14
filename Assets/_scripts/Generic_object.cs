using UnityEngine;
using System.Collections;

public class Generic_object : MonoBehaviour {

	public string name_object = "";
	public int id = 0;

	public override int GetHashCode() {
		return id;
	}
}