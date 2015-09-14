using UnityEngine;
using System.Collections;

namespace controller {

	public class Joystick : controller.Controller_base {

		public Vector2 axis_esdf = Vector2.zero;

		protected virtual void update_axis_esdf() {
			axis_esdf = helper.input.esdf.axis();
		}

		protected virtual void update_jump_button() {
			if ( helper.input.buttons.jump.down() )
				jump();
		}

		protected override void update_move_vector() {
			update_axis_esdf();
			_move_vector = axis_esdf;
			base.update_move_vector();
		}

		protected override void update_controller() {
			base.update_controller();
			update_jump_button();
		}

	}

}
