Set WshShell = CreateObject("WScript.Shell" ) 
If Not WScript.Arguments.Named.Exists("elevate") Then
  CreateObject("Shell.Application").ShellExecute WScript.FullName _
    , WScript.ScriptFullName & " /elevate", "", "runas", 1
  WScript.Quit
End If
WshShell.Run """C:\Users\Administrator\source\repos\CheckCamera\CheckCamera\bin\Release\net6.0-windows\CheckCamera.exe""", 0
Set WshShell = Nothing