Public Class ProxyTest
    Public ipx As String
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text <> "" Then
            Button2.Enabled = False
            ipx = TextBox1.Text
            Label2.Text = "正在查询..."
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Dim wck As New System.Net.WebClient
    Function ui(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs) As Long
        On Error GoTo x
        wck.Proxy = New System.Net.WebProxy(ipx)
        wck.Encoding = System.Text.Encoding.UTF8
        Dim sd = wck.DownloadString(New Uri("http://www.myip.cn/"))
        Dim xd = getinfo(sd, "o.src = ", """")
        '  MsgBox(xd)
        Dim sb As String = xd.Replace("http://www.myip.cn/map_city.php?ip=", "")
        MsgBox("IP地址：" + sb.Split("&")(0) + vbCrLf + "地理位置：" + sb.Split("=")(5), MsgBoxStyle.Information)
        Return Nothing
        Exit Function
x:      MsgBox("发生通信错误！", MsgBoxStyle.Information)
    End Function
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        BackgroundWorker1.CancelAsync()
        wck.Dispose()
        wck.CancelAsync()
        Close()
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ui(e.Argument, e.Result)
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Button2.Enabled = True
        Label2.Text = ""
    End Sub
    Function getinfo(ByVal txs As String, ByVal tsz As String, ByVal fgh As String)
        On Error Resume Next
        Dim x = 0 : Dim p = 0 : Dim y = 0 : Dim z = 0 : Dim sz = tsz
        Do
            If Mid(txs, x + 1, sz.Length) = sz Then
                p = 1
            End If
            x = x + 1
        Loop Until p = 1 Or x >= txs.Length - 1
        If p = 1 Then
            p = 0
            x = x + sz.Length - 1
            Do
                If Mid(txs, x + 1, 1) = fgh Then
                    p = 1
                    y = x
                End If
                x = x + 1
            Loop Until p = 1 Or x >= txs.Length - 1
        End If
        If p = 1 Then
            p = 0
            Do
                If Mid(txs, x + 1, 1) = fgh Then
                    p = 1
                    z = x
                End If
                x = x + 1
            Loop Until p = 1 Or x >= txs.Length - 1
        End If
        If x <> 0 And y <> 0 And z <> 0 Then
            Return txs.Substring(y + 1, z - y - 1)
        Else
            Return ""
        End If
    End Function
    Private Sub ProxyTest_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        wck.Dispose()
        wck.CancelAsync()
    End Sub
End Class