using UnityEngine;
using System;

namespace helper {
	class vector3 {
		public static Vector3 clamp( Vector3 vector, Vector3 min, Vector3 max ){
			return new Vector3(
					Mathf.Clamp( vector.x, min.x, max.x ),
					Mathf.Clamp( vector.y, min.y, max.y ),
					Mathf.Clamp( vector.z, min.z, max.z )
				);
		}
	}
}
