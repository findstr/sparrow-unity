/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.View.Login
{
    public partial class ServerSelected : GButton
    {
        public GTextField m_name;
        public const string URL = "ui://daz1xfn4s24he";

        public static ServerSelected CreateInstance()
        {
            return (ServerSelected)UIPackage.CreateObject("Login", "ServerSelected");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_name = (GTextField)GetChild("name");
        }
    }
}