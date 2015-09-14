using UnityEngine;
using System.Collections;

namespace controller.animator {
	public class Animator_unitchan : Animator_base{
		public float _speed = 0f;
		public float _direction = 0f;
		public bool _is_jumping = false;

		public float speed {
			get {
				return _speed;
			}
			set {
				_speed = Mathf.Abs( value );
				animator.SetFloat( "speed", _speed );
			}
		}

		public float direction {
			get {
				return _direction;
			}
			set {
				_direction = value;
				animator.SetFloat( "direction", _direction );
			}
		}

		public bool is_jumping {
			get {
				return _is_jumping;
			}
			set {
				_is_jumping = value;
				animator.SetBool( "is_jumping", _is_jumping );
			}
		}
	}
}