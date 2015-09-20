using UnityEngine;
using System.Collections;

public class Destroy_spawner : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D colider ) {
		Generic_object obj = colider.GetComponent<Generic_object>();
		if ( obj != null ) {
			Objects_pool.instance.push( obj );
		}

	}

}
