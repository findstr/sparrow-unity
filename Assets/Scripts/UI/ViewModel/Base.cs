using FairyGUI;

namespace UI {
namespace ViewModel {

public abstract class Base {
	public abstract GComponent View();
	public virtual void OnClose() {}
}	

}
}
