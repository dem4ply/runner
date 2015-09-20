using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Generic_object[] objects;
	public float min_time = 1f;
	public float max_time = 2f;

	protected BoxCollider2D _colider_2d;
	protected Transform _transform;

	void Awake() {
		_init_cache();
	}

	void Start () {
		spawn();
	}
	
	void spawn() {
		Generic_object obj = Objects_pool.instance.pop( objects[ Random.Range( 0, objects.Length ) ] );
		var max = _colider_2d.bounds.max;
		var min = _colider_2d.bounds.min;
		var pos = ( new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0 ) );
		obj.transform.position = pos;
		obj.gameObject.SetActive( true );
		Invoke( "spawn", Random.Range( min_time, max_time ) );
	}

	protected virtual void _init_cache() {
		_colider_2d = GetComponent<BoxCollider2D>();
		_transform = GetComponent<Transform>();
	}

}
