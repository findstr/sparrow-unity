namespace proto {
	public struct auth_r {
		public string account;
		public string password;
	}

	public struct auth_a {
		public uint code;
	}

	public struct server {
		public uint id ;
		public string name ;
		public string opentime ;
		public string status ;
	}

	public struct servers_r {}

	public struct servers_a {
		public uint code;
		public server[] list;
	}

	public struct login_r {
		public uint server_id;
	}

	public struct login_a {
		public uint code;
		public ulong uid;
	}

	public struct create_r {
		public uint server_id;
		public string name;
	}

	public struct create_a {
		public uint code;
		public ulong uid;
	}
}
