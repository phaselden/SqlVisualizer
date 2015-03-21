using System;
using System.Drawing;
using System.Windows.Forms;
using PoorMansTSqlFormatterLib;
using PoorMansTSqlFormatterLib.Formatters;

namespace SqlVisualizer
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		public void Initialize(string sql)
		{
			textTextBox.Text = sql;
		
			var formatter = GetFormatter(null);
			var htmlwrapper = new HtmlWrapper2(formatter);
			var fullFormatter = new SqlFormattingManager(htmlwrapper);
			var html = fullFormatter.Format(sql);

			webBrowser.AllowNavigation = false;
			webBrowser.DocumentText = html;
		}

		private TSqlStandardFormatter GetFormatter(string configString)
		{
			//defaults are as per the object, except disabling colorized/htmlified output
			var options = new TSqlStandardFormatterOptions(configString);
			options.HTMLColoring = true;
			options.ExpandCommaLists = false;
			options.ExpandInLists = false;
			options.IndentString = "    "; // The default is "/t", but that's too big in IE and IE doesn't support tab-size CSS
			
			return new TSqlStandardFormatter(options);			
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			Font = SystemFonts.MessageBoxFont;
		}
	}
}
