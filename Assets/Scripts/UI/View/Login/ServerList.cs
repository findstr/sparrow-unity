/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using FairyGUI;
using FairyGUI.Utils;

namespace UI.View.Login
{
    public partial class ServerList : GComponent
    {
        public GList m_list;
        public const string URL = "ui://daz1xfn4w39nb";

        public static ServerList CreateInstance()
        {
            return (ServerList)UIPackage.CreateObject("Login", "ServerList");
        }

        public override void ConstructFromXML(XML xml)
        {
            base.ConstructFromXML(xml);

            m_list = (GList)GetChild("list");
        }
    }
}