/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.View.Login
{
    public partial class Auth : GComponent
    {
        public InputUser m_user;
        public InputPassword m_passwd;
        public GButton m_auth;
        public const string URL = "ui://daz1xfn4wn6z1";

        public static Auth CreateInstance()
        {
            return (Auth)UIPackage.CreateObject("Login", "Auth");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_user = (InputUser)GetChild("user");
            m_passwd = (InputPassword)GetChild("passwd");
            m_auth = (GButton)GetChild("auth");
        }
    }
}