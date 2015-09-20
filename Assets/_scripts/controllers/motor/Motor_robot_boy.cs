using UnityEngine;
using System.Collections;

namespace controller.motor {
	public class Motor_robot_boy : Motor_base {

		public animator.Animator_robot_boy _animator;

		protected override void update_motion() {
			base.update_motion();
			_animator.speed = _rigidbody.velocity.x;
			_animator.vertical_speed = _rigidbody.velocity.y;
		}

		protected override void update_jump() {
			base.update_jump();
			//_animator.is_jumping = is_jumping;
		}

		protected override void update_grounded() {
			base.update_grounded();
			_animator.is_grounded = is_grounded;
		}

		protected override void _init_cache() {
			base._init_cache();
			_animator = GetComponentInChildren<animator.Animator_robot_boy>();
		}

	}
}