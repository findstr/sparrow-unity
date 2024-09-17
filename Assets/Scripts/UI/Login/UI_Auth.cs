/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Login
{
    public partial class UI_Auth : GComponent
    {
        public UI_InputUser m_user;
        public UI_InputPassword m_passwd;
        public GButton m_auth;
        public const string URL = "ui://daz1xfn4wn6z1";

        public static UI_Auth CreateInstance()
        {
            return (UI_Auth)UIPackage.CreateObject("Login", "Auth");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_user = (UI_InputUser)GetChild("user");
            m_passwd = (UI_InputPassword)GetChild("passwd");
            m_auth = (GButton)GetChild("auth");
        }
    }
}