
namespace Model {

class Inst {
	static public Login Login;
	static public Player Player;
	static public void Init() {
	 	Login = new Login();
		Player = new Player();
	}
}
	
}