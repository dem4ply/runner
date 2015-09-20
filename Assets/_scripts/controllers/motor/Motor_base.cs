using UnityEngine;
using System.Collections;

namespace controller.motor {
	public class Motor_base : MonoBehaviour {

		public float move_speed = 10f;
		public float move_speed_in_air = 10f;
		public float jump_force = 10f;
		public int air_jumps = 1;

		public Transform ground_checker;
		public float ground_radius;
		public LayerMask what_is_ground;

		public Vector2 _move_vector = Vector2.zero;
		public bool _is_jump = false;
		public bool _is_grounded = false;
		public int _remaining_air_jumps = 0;

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

		public bool is_facing_rigth {
			get;
			set;
		}

		public bool is_facing_left {
			get {
				return !is_facing_rigth;
			}
			set {
				is_facing_rigth = !value;
			}
		}

		public bool can_air_jump {
			get {
				return is_not_grounded && remaining_air_jumps > 0;
			}
		}
		public int remaining_air_jumps {
			get {
				return _remaining_air_jumps;
			}
			set {
				_remaining_air_jumps = value;
			}
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
			update_grounded();
		}

		protected virtual void update_motion() {
			Vector2 desire_move = _move_vector;
			if ( desire_move.magnitude > 1f )
				desire_move.Normalize();

			if ( is_grounded ) {
				desire_move *= move_speed;
			}
			else {
				desire_move *= move_speed_in_air;
			}
			//se va a mover a la derecha y esta mirando a la izquierda
			//se va a mover a la izquierda y esta mirando a la derecha
			if ( ( desire_move.x > 0 && is_facing_left ) || ( desire_move.x < 0 && is_facing_rigth ) ){
				_flip();
			}

			_rigidbody.velocity = new Vector2( desire_move.x, _rigidbody.velocity.y );
		}

		protected virtual void update_jump() {
			if ( is_jump && can_jump ) {
				is_jump = false;
				is_jumping = true;
				float desire_jump_force = _calculate_jump_vertical_speed();
				_rigidbody.velocity = new Vector2( _rigidbody.velocity.x, _rigidbody.velocity.y + desire_jump_force );
			}
			else if ( is_jump && can_air_jump ){
				is_jump = false;
				--remaining_air_jumps;
				float desire_jump_force = _calculate_jump_vertical_speed();
				_rigidbody.velocity = new Vector2( _rigidbody.velocity.x, desire_jump_force );
			}
		}

		protected virtual void update_grounded() {
			is_grounded = Physics2D.OverlapCircle( ground_checker.position, ground_radius, what_is_ground );
			if ( is_grounded ) {
				remaining_air_jumps = air_jumps;
			}
		}

		protected float _calculate_jump_vertical_speed() {
			return Mathf.Sqrt( 2 * jump_force * Physics.gravity.magnitude );
		}

		protected virtual void _flip() {
			if ( is_facing_left ) {
				_transform.rotation = Quaternion.Euler( new Vector3( _transform.rotation.eulerAngles.x, 0, _transform.rotation.eulerAngles.z ) );
				is_facing_rigth = true;
			}
			else {
				_transform.rotation = Quaternion.Euler( new Vector3( _transform.rotation.eulerAngles.x, 180, _transform.rotation.eulerAngles.z ) );
				is_facing_left = true;
			}
		}

		protected virtual void _init_cache() {
			_rigidbody = GetComponent<Rigidbody2D>();
			_transform = GetComponent<Transform>();
		}

	}
}