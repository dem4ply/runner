using UnityEngine;
using System.Collections;

public class Camera_follow : MonoBehaviour {

	public Transform follow;

	protected Transform _transform;

	// Update is called once per frame
	void Awake() {
		_init_cache();
	}

	void LateUpdate () {
		_transform.position = new Vector3( follow.position.x, follow.position.y, _transform.position.z );
	}

	void _init_cache() {
		_transform = GetComponent<Transform>();
	}
}
