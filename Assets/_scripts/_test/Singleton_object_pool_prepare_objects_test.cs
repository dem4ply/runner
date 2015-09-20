using UnityEngine;
using System.Collections;

public class Singleton_object_pool_prepare_objects_test : MonoBehaviour {

	public Generic_object to_prepare;
	public int prepare_number;

	protected void OnCollisionEnter2D() {
		Objects_pool.instance.prepare_objects( to_prepare, prepare_number );
	}
} 
