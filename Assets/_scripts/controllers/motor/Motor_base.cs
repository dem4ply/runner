using UnityEngine;
using System.Collections;

namespace controller.motor {
	public class Motor_base : MonoBehaviour {

		public float move_speed = 10f;
		public float jump_force = 10f;

		public Vector2 _move_vector = Vector2.zero;
		public bool _is_jump = false;
		public bool _is_grounded = false;

		public Rigidbody2D _rigidbody;
		public Transform _transform;

		public Vector2 move_vector {
			get {
				return _move_vector;
			}
			set {
				_move_vector = value;
			}
		}

		public bool is_jump {
			get {
				return _is_jump;
			}
			protected set {
				_is_jump = value;
			}
		}

		public bool is_not_jump {
			get {
				return !is_jump;
			}
		}

		public bool is_grounded {
			get {
				return _is_grounded;
			}
			protected set {
				_is_grounded = value;
			}
		}

		public bool is_not_grounded {
			get {
				return !is_grounded;
			}
		}

		public bool can_jump{
			get {
				return is_grounded;
			}
		}

		public bool is_jumping {
			get;
			set;
		}

		protected virtual void Awake() {
			_init_cache();
		}

		public virtual void jump() {
			is_jump = true;
		}

		protected virtual void FixedUpdate() {
			update_motion();
			update_jump();
			is_grounded = false;
		}

		protected virtual void update_motion() {
			Vector2 desire_move = _move_vector;

			if ( is_grounded ) {
				if ( desire_move.magnitude > 1f )
					desire_move.Normalize();

				desire_move *= move_speed;

				if ( desire_move.x > 0 )
					_transform.rotation = Quaternion.Euler( new Vector3( _transform.rotation.eulerAngles.x, 0, _transform.rotation.eulerAngles.z ) );
				else if ( desire_move.x < 0 )
					_transform.rotation = Quaternion.Euler( new Vector3( _transform.rotation.eulerAngles.x, 180, _transform.rotation.eulerAngles.z ) );

				_rigidbody.velocity = new Vector2( desire_move.x, _rigidbody.velocity.y );
			}
		}

		protected virtual void update_jump() {
			if ( is_jump && can_jump ) {
				is_jump = false;
				is_jumping = true;
				float desire_jump_force = _calculate_jump_vertical_speed();
				_rigidbody.velocity = new Vector2( _rigidbody.velocity.x, _rigidbody.velocity.y + desire_jump_force );
			}
		}

		protected float _calculate_jump_vertical_speed() {
			return Mathf.Sqrt( 2 * jump_force * Physics.gravity.magnitude );
		}

		protected void OnCollisionEnter2D() {
			is_jumping = false;
			is_grounded = true;
		}

		protected void OnCollisionStay2D() {
			is_grounded = true;
		}

		protected void OnCollisionExit2D() {
			is_grounded = false;
		}

		protected virtual void _init_cache() {
			_rigidbody = GetComponent<Rigidbody2D>();
			_transform = GetComponent<Transform>();
		}

	}
}