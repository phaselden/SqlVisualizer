# SqlVisualizer Version 0.01
Debugging Visualizer for Visual Studio. Use on any string (containing SQL) to see reformatted and colorized SQL.

Reformats and colorizes any string as SQL when debugging. Obviously this only makes sense if the string contains SQL.

## License and Credits

This visualizer uses Poor Man's T-SQL Formatter. https://github.com/TaoK/PoorMansTSqlFormatter and http://architectshack.com/PoorMansTSqlFormatter.ashx

This library is released under the GNU Affero GPL v3: http://www.gnu.org/licenses/agpl.txt. This is mainly because it's the same one used by Poor Man's T-SQL Formatter.   

## Installation for Visual Studio 2013

**Note** *The source no longer works with VS2013. In order to get it to work, change the references to the  Microsoft.VisualStudio.DebuggerVisualizers assembly back to the 12.0 version.* 

Copy `SqlVisualizer.dll` and `PoorMansTSqlFormatterLib35.dll` to:
`C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Packages\Debugger\Visualizers`

## Installation for Visual Studio 2015

Copy `SqlVisualizer.dll` and `PoorMansTSqlFormatterLib35.dll` to:
`C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Packages\Debugger\Visualizers`
