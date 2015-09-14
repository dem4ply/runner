using UnityEngine;
using System.Collections;

namespace controller.motor {
	public class Motor_unitchan : Motor_base {

		public animator.Animator_unitchan _animator;

		protected override void update_motion() {
			base.update_motion();
			_animator.speed = _rigidbody.velocity.x;
		}

		protected override void update_jump() {
			base.update_jump();
			_animator.is_jumping = is_jumping;
		}

		protected override void _init_cache() {
			base._init_cache();
			_animator = GetComponentInChildren<animator.Animator_unitchan>();
		}

	}
}