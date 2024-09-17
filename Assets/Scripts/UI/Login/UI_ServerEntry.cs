/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Login
{
    public partial class UI_ServerEntry : GComponent
    {
        public GTextField m_name;
        public const string URL = "ui://daz1xfn4w39nc";

        public static UI_ServerEntry CreateInstance()
        {
            return (UI_ServerEntry)UIPackage.CreateObject("Login", "ServerEntry");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_name = (GTextField)GetChild("name");
        }
    }
}