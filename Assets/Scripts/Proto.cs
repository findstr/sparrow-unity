using System;
using System.Collections.Generic;

namespace proto {
	[Serializable]
	public struct auth_r {
		public string account;
		public string password;
	}

	[Serializable]
	public struct auth_a {
		public uint code;
	}

	[Serializable]
	public struct server {
		public uint id ;
		public string name ;
		public string opentime ;
		public string status ;

	}

	[Serializable]
	public struct servers_r {}

	[Serializable]
	public struct servers_a {
		public uint code;
		public server[] list;
	}

	[Serializable]
	public struct login_r {
		public uint server_id;
	}

	[Serializable]
	public struct login_a {
		public uint code;
		public ulong uid;
		public string name;
	}

	[Serializable]
	public struct create_r {
		public uint server_id;
		public string name;
	}

	[Serializable]
	public struct create_a {
		public uint code;
		public ulong uid;
		public string name;
	}
}
