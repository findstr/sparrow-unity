/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.View.Login
{
    public partial class InputPassword : GComponent
    {
        public GTextInput m_input;
        public const string URL = "ui://daz1xfn4c7mp3";

        public static InputPassword CreateInstance()
        {
            return (InputPassword)UIPackage.CreateObject("Login", "InputPassword");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_input = (GTextInput)GetChild("input");
        }
    }
}