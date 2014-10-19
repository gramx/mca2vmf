using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValardMapFormatConverter
{
    static public class Helpers
    {
        static public void AppendTabs(ref int tier, ref StringBuilder sb)
        {
            for (int i = 0; i < tier; i++)
            {
                sb.Append("\t");
            }
        }

        static public void AppendTextRow(ref int tier, ref StringBuilder sb, string value)
        {
            AppendTabs(ref tier, ref sb);
            sb.Append(value);
            sb.Append(Environment.NewLine);
        }

        static public void AppendTextRow(ref int tier, ref StringBuilder sb, string name, string value)
        {
            AppendTabs(ref tier, ref sb);
            sb.Append("\"");
            sb.Append(name);
            sb.Append("\"\t\"");
            sb.Append(value);
            sb.Append("\"");
            sb.Append(Environment.NewLine);
        }

        static public void AppendBoolianRow(ref int tier, ref StringBuilder sb, string name, bool value)
        {
            AppendTabs(ref tier, ref sb);
            sb.Append("\"");
            sb.Append(name);
            sb.Append("\"\t");
            if (value)
            {
                sb.Append("\"1\"");
            }
            else
            {
                sb.Append("\"0\"");
            }
            sb.Append(Environment.NewLine);
        }
    }
}
