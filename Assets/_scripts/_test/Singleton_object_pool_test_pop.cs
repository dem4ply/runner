using UnityEngine;
using System.Collections;

public class Singleton_object_pool_test_pop: MonoBehaviour {

	public Generic_object to_prepare;
	public int prepare_number;

	protected void OnCollisionEnter2D() {
		//Objects_pool.instance.prepare_objects( to_prepare, prepare_number );
		var cosa = Objects_pool.instance.pop( to_prepare );
		cosa.transform.position = new Vector3( 4, 4, 0 );
		cosa.transform.parent = this.transform;
		cosa.gameObject.SetActive( true );
	}
}