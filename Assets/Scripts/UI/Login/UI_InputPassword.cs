/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.Login
{
    public partial class UI_InputPassword : GComponent
    {
        public GTextInput m_text;
        public const string URL = "ui://daz1xfn4c7mp3";

        public static UI_InputPassword CreateInstance()
        {
            return (UI_InputPassword)UIPackage.CreateObject("Login", "InputPassword");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_text = (GTextInput)GetChild("text");
        }
    }
}