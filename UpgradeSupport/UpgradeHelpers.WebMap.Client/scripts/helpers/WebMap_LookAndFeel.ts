module WebMap.Client {
	export class Responsiveness {

		public static ProcessObjectForResponsiveness(object) {

			/* Step 1: Process its Dock Style*/
			//this.SetDockStyle(object);

		}

		private static SetDockStyle(object) {
			try {
				var model = object._value;
				var element = object.element;
				if (model.Visible) {
					switch (model.Dock) {
						case Enums.DockStyle.Top:
							this.SetDisplayToParent(element);
							element.css("width", "100%");
							break;
						case Enums.DockStyle.Bottom:
							this.SetDisplayToParent(element);
							element.css("width", "100%");
							break;
						case Enums.DockStyle.Left:
							this.SetDisplayToParent(element);
							element.css("height", "100%").css("position", "relative").css("left", "");
							break;
						case Enums.DockStyle.Right:
							this.SetDisplayToParent(element);
							element.css("height", "100%").css("position", "relative").css("left", "");
							break;
						case Enums.DockStyle.Fill:
							this.SetDisplayToParent(element);
							element.css("flex-grow", "1").css("width", "100%").css("height", "100%").css("position", "relative").css("left", "");
							break;
					}
				}
			} catch (e) {
			}
		}

		private static SetDisplayToParent(element) {
			var parent = element.parent();
			var displayType = parent.css("display");
			if (displayType == "flex")
				return;
			if (displayType != "none") {
				parent.css("display", "flex");
			}
		}
	}
	 
} 