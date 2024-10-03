/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.View.Login
{
    public partial class GameEnter : GComponent
    {
        public GButton m_enter;
        public ServerSelected m_select;
        public const string URL = "ui://daz1xfn4w39n7";

        public static GameEnter CreateInstance()
        {
            return (GameEnter)UIPackage.CreateObject("Login", "GameEnter");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_enter = (GButton)GetChild("enter");
            m_select = (ServerSelected)GetChild("select");
        }
    }
}