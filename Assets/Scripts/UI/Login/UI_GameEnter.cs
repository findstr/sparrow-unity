/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Login
{
    public partial class UI_GameEnter : GComponent
    {
        public GComponent m_selected;
        public GButton m_enter;
        public const string URL = "ui://daz1xfn4w39n7";

        public static UI_GameEnter CreateInstance()
        {
            return (UI_GameEnter)UIPackage.CreateObject("Login", "GameEnter");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_selected = (GComponent)GetChild("selected");
            m_enter = (GButton)GetChild("enter");
        }
    }
}