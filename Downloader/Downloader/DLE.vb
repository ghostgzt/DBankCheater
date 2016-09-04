Public Class DMain
    Private Sub DMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim wcx = New System.Net.WebClient

        ''Dim MyClient As System.Net.WebProxy =

        ''MyClient.BypassProxyOnLocal = False

        ''MyClient.Credentials = New Net.NetworkCredential("xxx", "xxx")
        'wcx.Proxy = New System.Net.WebProxy("203.42.246.231:80")
        'Dim xd = wcx.DownloadString(New Uri("http://www.myip.cn/"))
        'MsgBox(xd)
        'My.Computer.FileSystem.WriteAllText("c:\12.txt", xd, False)
        On Error Resume Next
        Dim xk = My.Application.CommandLineArgs
        If xk.Count > 0 Then
            If xk(0).Trim <> "" Then
                '    MsgBox(xk(0))
                If xk.Count = 3 Then
                    getdown(xk(0), xk(2))
                Else
                    getdown(xk(0), "")
                End If
            End If
            If xk(1).Trim <> "" Then
                Timer1.Interval = CInt(xk(1)) * 1000
            End If
        Else
            End
        End If
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        End
    End Sub
    Function getdown(ByVal xurl As String, ByVal ip As String)
        On Error Resume Next
        Dim wc = New System.Net.WebClient
        If ip.Trim <> "" Then
            wc.Proxy = New System.Net.WebProxy(ip)
        End If
        wc.DownloadDataAsync(New Uri(xurl))
        ' End
        Timer1.Enabled = True
    End Function
End Class