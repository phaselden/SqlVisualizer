using System;
using System.Diagnostics;
using Microsoft.VisualStudio.DebuggerVisualizers;
using SqlVisualizer;

[assembly: DebuggerVisualizer(typeof(SqlDebugger), typeof(VisualizerObjectSource),
Target = typeof(String),
Description = "SQL Visualizer")]
namespace SqlVisualizer
{
	public class SqlDebugger : DialogDebuggerVisualizer
    {
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{

			if (windowService == null)
				throw new ArgumentNullException("windowService");
			if (objectProvider == null)
				throw new ArgumentNullException("objectProvider");

			var data = objectProvider.GetObject();
			using (var displayForm = new MainForm())
			{
				displayForm.Initialize(data.ToString());
				windowService.ShowDialog(displayForm);				
			}
		}

		public static void TestShowVisualizer(object objectToVisualize)
		{
			VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(SqlDebugger));
			visualizerHost.ShowVisualizer();
		}
    }
}
