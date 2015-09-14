using UnityEngine;
using System.Collections;

namespace controller {
	public class Controller_base : MonoBehaviour {

		public motor.Motor_base _motor;

		public Vector2 _move_vector = Vector2.zero;

		protected virtual void Awake() {
			_init_cache();
		}

		protected virtual void Update() {
			update_controller();
		}

		protected virtual void update_controller() {
			update_move_vector();
		}

		protected virtual void update_move_vector() {
			_motor.move_vector = _move_vector;
		}

		protected virtual void jump() {
			_motor.jump();
		}

		protected virtual void _init_cache() {
			_motor = GetComponent<motor.Motor_base>();
		}

	}
}