/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Login
{
    public partial class UI_InputUser : GComponent
    {
        public GTextInput m_text;
        public const string URL = "ui://daz1xfn4c7mp2";

        public static UI_InputUser CreateInstance()
        {
            return (UI_InputUser)UIPackage.CreateObject("Login", "InputUser");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_text = (GTextInput)GetChild("text");
        }
    }
}