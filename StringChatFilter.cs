using System;
using System.Text.RegularExpressions;
 
namespace Plus.Utilities
{
    static class StringCharFilter
    {
        /// <summary>
        /// Échappe les caractères utilisés pour injecter des caractères spéciaux à partir d'une entrée utilisateur.
        /// </summary>
        /// <param name="str">La chaîne / le texte à échapper.</param>
        /// <param name="allowBreaks">Autoriser l'utilisation des sauts de ligne (\r\n).</param>
        /// <returns></returns>
        public static string Escape(string str, bool allowBreaks = false)
        {
            str = str.Trim();
            str = str.Replace(Convert.ToChar(1), ' ');
            str = str.Replace(Convert.ToChar(2), ' ');
            str = str.Replace(Convert.ToChar(3), ' ');
            str = str.Replace(Convert.ToChar(9), ' ');
 
            if (!allowBreaks)
            {
                str = str.Replace(Convert.ToChar(10), ' ');
                str = str.Replace(Convert.ToChar(13), ' ');
            }
 
           str = Regex.Replace(str, "<(.|\\n)*?>", string.Empty);
 
            return str;
        }
 
        public static string EscapeJSONString(string str)
        {
            return str.Replace("\"", "\\\"");
        }
    }
}
