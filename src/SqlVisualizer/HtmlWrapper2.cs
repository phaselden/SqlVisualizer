using System;
using System.Xml;
using PoorMansTSqlFormatterLib;
using PoorMansTSqlFormatterLib.Interfaces;

namespace SqlVisualizer
{
	
	/// <summary>
	/// An updated copy of PoorMansTSqlFormatter HtmlPageWrapper class which had the style element in the body.
	/// </summary>
    public class HtmlWrapper2 : ISqlTreeFormatter
    {
	    readonly ISqlTreeFormatter _underlyingFormatter;

		public HtmlWrapper2(ISqlTreeFormatter underlyingFormatter)
        {
            if (underlyingFormatter == null)
                throw new ArgumentNullException("underlyingFormatter");

            _underlyingFormatter = underlyingFormatter;
        }

        private const string HTML_OUTER_PAGE =
@"<!DOCTYPE html>
<html>
<head>
	<style type=""text/css"">
		.SQLCode {{
			font-size: 13px;
			/*font-weight: bold;*/
			font-family: Consolas, monospace;
			white-space: pre;
			}}
		.SQLComment {{ color: #008000; }}		/* orig: #00AA00*/
		.SQLString {{ color: #FF0000; }}		/* orig: #AA0000*/
		.SQLFunction {{ color: #FF00FF; }}		/* orig: #AA00AA*/
		.SQLKeyword {{ color: #0000FF; }}		/* orig: #0000AA*/
		.SQLOperator {{ color: #808080; }}		/* orig: #777777*/
		.SQLErrorHighlight {{ background-color: #FFFF00; }}
	</style>
</head>
<body>
	<pre class=""SQLCode"">{0}</pre>
</body>
</html>
";

        public bool HTMLFormatted { get { return true; } }

        public string ErrorOutputPrefix { 
            get 
            { 
                return _underlyingFormatter.ErrorOutputPrefix; 
            } 
            set 
            {
                throw new NotSupportedException("Error output prefix should be set on the underlying formatter - it cannot be set on the Html Page Wrapper.");
            }
        }

        public string FormatSQLTree(XmlDocument sqlTree)
        {
            string formattedResult = _underlyingFormatter.FormatSQLTree(sqlTree);
            if (_underlyingFormatter.HTMLFormatted)
                return string.Format(HTML_OUTER_PAGE, formattedResult);
            else
                return string.Format(HTML_OUTER_PAGE, Utils.HtmlEncode(formattedResult));
        }
    }

}
