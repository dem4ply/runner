using UnityEngine;
using System;

namespace helper {
	public static class input {
		public static class esdf {

			public static float horizontal() {
				return Input.GetAxis( "horizontal" );
			}

			public static float vertical() {
				return Input.GetAxis( "vertical" );
			}

			public static Vector2 axis() {
				return new Vector2( horizontal(), vertical() );
			}

		}

		public static class buttons {

			public static class jump {

				public static bool down() {
					return Input.GetButtonDown( "jump" );
				}

			}

		}
	}
}
