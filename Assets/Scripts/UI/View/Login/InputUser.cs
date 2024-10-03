/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.View.Login
{
    public partial class InputUser : GComponent
    {
        public GTextInput m_input;
        public const string URL = "ui://daz1xfn4c7mp2";

        public static InputUser CreateInstance()
        {
            return (InputUser)UIPackage.CreateObject("Login", "InputUser");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_input = (GTextInput)GetChild("input");
        }
    }
}