using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThingSpeakDotNetLibrary
{
    static public class QueryStringBuilder
    {
        static public String Build(List<KeyValuePair<String, Object>> parameters)
        {
            String result = String.Empty;
            if (parameters.Count > 0)
            {
                // Add first element (with leading question mark instead of ampersand)
                result = "?" + BuildParameterString(parameters[0]);
                for (int i = 1; i < parameters.Count; ++i)
                {
                    if (parameters[i].Value != null)
                    {
                        result += "&" + BuildParameterString(parameters[i]);
                    }
                }
            }
            return result;
        }

        static String BuildParameterString(KeyValuePair<String, Object> parameter)
        {
            // TODO add parameter verification (it should not contain spaces and other special characters not allowed in URL)
            String value;
            if (parameter.Value is DateTime)
            {
                value = ((DateTime)(parameter.Value)).ToUniversalTime().ToString("o", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                value = parameter.Value.ToString();
            }
            return parameter.Key + "=" + value;
        }
    }
}
