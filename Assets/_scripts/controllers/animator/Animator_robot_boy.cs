using UnityEngine;
using System.Collections;

namespace controller.animator {
	public class Animator_robot_boy : Animator_base{
		public float _speed = 0f;
		public float _vertical_speed = 0f;
		public float _direction = 0f;
		public bool _is_grounded = false;

		public float speed {
			get {
				return _speed;
			}
			set {
				_speed = Mathf.Abs( value );
				animator.SetFloat( "speed", _speed );
			}
		}

		public float vertical_speed {
			get {
				return _vertical_speed;
			}
			set {
				_vertical_speed = value;
				animator.SetFloat( "vertical_speed", _vertical_speed );
			}
		}

		public bool is_grounded {
			get {
				return _is_grounded;
			}
			set {
				_is_grounded = value;
				animator.SetBool( "is_grounded", _is_grounded );
			}
		}
	}
}