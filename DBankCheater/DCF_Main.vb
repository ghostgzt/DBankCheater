Public Class DCF
    Dim WithEvents wc As New Net.WebClient()
    Dim path = ""
    Public inc As Integer
    Public xinc As Integer
    Public ruri As String
    Public rpath As String
    Public lx As New ListBox
    Public xi As String
    Public ct As Integer
    Public llx As New ListBox
    Public xcc = 0
    Public ip As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        Panel1.Enabled = False
        If TextBox1.Text = "" Then
            If ListBox1.Items.Count <> 0 Then
                If ListBox1.SelectedItems.Count <> 0 Then
                    TextBox1.Text = ListBox1.SelectedItems(0).ToString.Trim
                Else
                    ListBox1.SelectedIndices.Add(0)
                End If
            Else
                GoTo s
            End If
        End If
        TextBox2.Text = ""
        Dim url = TextBox1.Text
        If TextBox3.Text.Trim <> "" Then
            path = TextBox3.Text + "\" + xi
        Else
            GoTo s1
        End If
        MkDir(TextBox3.Text)
        Dim sd = ""
        sd = wc.DownloadString(New Uri(url))
        TextBox1.Enabled = False : TextBox2.Enabled = False : TextBox3.Enabled = False
        TextBox2.Text = getdurl(sd)
        TextBox1.Enabled = True : TextBox2.Enabled = True : TextBox3.Enabled = True
        Panel1.Enabled = True
        Exit Sub
s:      Button3_Click(Nothing, Nothing) : Panel1.Enabled = True
        Exit Sub
s1:     Button8_Click(Nothing, Nothing) : Panel1.Enabled = True
    End Sub
    Function getdurl(ByVal curi As String)
        On Error Resume Next
        Return getinfo(curi, """" + "downloadurl" + """" + ":", """").ToString.Replace("/", "").Replace("\", "/")
    End Function
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
    Function getdown(ByVal xurl As String, ByVal ipx As String)
        On Error Resume Next
        Shell(My.Application.Info.DirectoryPath + "\Downloader.exe" + " " + xurl.Trim + " " + CStr(NumericUpDown2.Value).Trim + " " + ipx, AppWinStyle.Hide, True, NumericUpDown2.Value * 1000)
    End Function
    Public sfzt = 0
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error Resume Next
        If Button2.Text = "刷次" Then
            sfzt = 0
            If My.Computer.FileSystem.DirectoryExists(TextBox3.Text) = True Then
                If ListBox1.Items.Count <> 0 Then
                    ListBox1.SelectedItems.Clear()
                    TextBox1.Text = ""
                    TextBox2.Text = ""
                    ruri = ""
                    If TextBox3.Text.Trim <> "" Then
                        rpath = TextBox3.Text + "\" + xi
                    Else
                        GoTo s1
                    End If
                    MkDir(TextBox3.Text)
                    lx.Items.Clear()
                    For c = 0 To ListBox1.Items.Count - 1
                        lx.Items.Add(ListBox1.Items(c).ToString.Trim)
                    Next
                    Timer1.Enabled = True
                    Me.Text = "DBank Cheater - 已刷 " + CStr(inc) + " 次"
                    NotifyIcon1.Text = "DBank Cheater - " + xi + " - 已刷 " + CStr(inc) + " 次"
                    ct = NumericUpDown2.Value
                    savereg()
                    Button9.Enabled = True
                    Panel1.Enabled = False
                    Button2.Text = "暂停"
                    xcc = 0
                    BackgroundWorker1.RunWorkerAsync()
                Else
                    Button3_Click(Nothing, Nothing)
                    Panel1.Enabled = True
                End If
            Else
                Button8_Click(Nothing, Nothing)
            End If
        Else
            If Button2.Text = "暂停" Then
                sfzt = 1
                Button2.Text = "继续"
            Else
                sfzt = 0
                Button2.Text = "暂停"
            End If
        End If
        Exit Sub
s1:     Button8_Click(Nothing, Nothing) : Panel1.Enabled = True : Button9.Enabled = False
    End Sub
    Function getdatename()
        Return Date.Now.ToString.Trim.Replace(":", "_").Replace("/", "").Replace("\", "").Replace(" ", "")
    End Function
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        With New FolderBrowserDialog
            .Description = "请输入缓存目录路径："
            .ShowNewFolderButton = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                TextBox3.Text = .SelectedPath
            End If
        End With
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim r = InputBox("请输入华为网盘外链：", "DBank Cheater").Trim
        If r <> "" Then
            ListBox1.Items.Remove(r)
            ListBox1.Items.Add(r)
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        If ListBox1.Text <> "" Then
            For x = 0 To ListBox1.SelectedIndices.Count - 1
                ListBox1.Items.Remove(ListBox1.SelectedItems(0))
            Next
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        ListBox1.Items.Clear()
        TextBox1.Text = ""
        TextBox2.Text = ""
    End Sub
    Function SY(ByVal lls As ListBox)
        On Error Resume Next
        Dim qian As String
        Dim huo As String
        If lls.Items.IndexOf(lls.SelectedItems(0)) > 0 Then
            huo = lls.SelectedItems(0)
            Dim t = lls.SelectedItems(0)
            qian = lls.Items(lls.Items.IndexOf(t) - 1)
            lls.Items(lls.Items.IndexOf(t)) = qian
            t = lls.SelectedItems(0)
            lls.Items(lls.Items.IndexOf(t)) = huo
            lls.ClearSelected()
            lls.SetSelected(lls.Items.IndexOf(t) - 1, True)
        End If
    End Function
    Function XY(ByVal lls As ListBox)
        On Error Resume Next
        Dim qian As String
        Dim huo As String
        If lls.Items.IndexOf(lls.SelectedItems(0)) < lls.Items.Count - 1 Then
            huo = lls.SelectedItems(0)
            Dim t = lls.SelectedItems(0)
            qian = lls.Items(lls.Items.IndexOf(t) + 1)
            lls.Items(lls.Items.IndexOf(t) + 1) = huo
            t = lls.SelectedItems(0)
            lls.Items(lls.Items.IndexOf(t)) = qian
            lls.ClearSelected()
            lls.SetSelected(lls.Items.IndexOf(t), True)
        End If
    End Function
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SY(ListBox1)
    End Sub
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        XY(ListBox1)
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        On Error Resume Next
        TextBox1.Text = ""
        TextBox2.Text = ""
        If ListBox1.SelectedItems.Count <> 0 Then
            Button4.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            删除ToolStripMenuItem.Enabled = True
            上移ToolStripMenuItem.Enabled = True
            下移ToolStripMenuItem.Enabled = True
            TextBox1.Text = ListBox1.SelectedItems(0).ToString.Trim
        Else
            Button4.Enabled = False
            Button6.Enabled = False
            Button7.Enabled = False
            删除ToolStripMenuItem.Enabled = False
            上移ToolStripMenuItem.Enabled = False
            下移ToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If TextBox1.Text.Trim <> "" Then
            WebBrowser1.Url = New Uri(TextBox1.Text)
            TabControl1.SelectedIndex = 1
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ui(e.Argument, e.Result)
    End Sub
    Public xii As String
    Function ui(ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As System.ComponentModel.DoWorkEventArgs) As Long
        On Error Resume Next
        inc = 0
        xinc = 0
        Dim js As Integer = 0
        For x = 1 To NumericUpDown1.Value
c:          ip = ""
            ip = llx.Items(js).ToString.Trim
            For y = 0 To ListBox1.Items.Count - 1
                If sfzt = 1 Then
                    MsgBox("已暂停刷次！", MsgBoxStyle.Information)
                End If
                While sfzt = 1
                End While
                'If sfzt = 1 Then
                '    Dim r = MsgBox("刷次已暂停！" + vbCrLf + "现在恢复还是停止?", vbYesNo)
                '    If r = MsgBoxResult.No Then
                '        xcc = 1
                '        wc.Dispose()

                '        GoTo x
                '    End If
                'End If
                If xcc = 1 Then
                    GoTo x
                End If
                ruri = lx.Items(y).ToString.Trim
                Dim sd = ""
                Dim wck As New System.Net.WebClient
                If ip.Trim <> "" Then
                    wck.Proxy = New System.Net.WebProxy(ip.Trim)
                End If
                sd = wck.DownloadString(New Uri(ruri))
                Dim xk = getdurl(sd)
                If xk.ToString.Trim = "" Then
                    js = js + 1
                    If js > llx.Items.Count - 1 Then
                        js = 0
                    End If
                    GoTo c
                End If
                xii = xk
                getdown(xk, ip)
                xinc = y
            Next
            js = js + 1
            If js > llx.Items.Count - 1 Then
                js = 0
            End If
            My.Computer.FileSystem.WriteAllText(rpath + ".log", "DBank Cheater - " + xi + vbCrLf + "Date：" + CStr(Date.Now) + vbCrLf + "IP：" + ip + vbCrLf + "已经刷次 " + CStr(x) + " 次" + vbCrLf, True)
            inc = x
        Next
x:
    End Function
    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        On Error Resume Next
        Timer1.Enabled = False
        ProgressBar1.Value = 100
        Dim r2 As String = CStr(NumericUpDown1.Value)
        While (r2).Trim.Length < 3
            r2 = "0" + r2
        End While
        Label4.Text = "(" + r2 + "/" + r2 + ")"
        Me.Text = "DBank Cheater"
        Button2.Text = "刷次"
        NotifyIcon1.Text = "DBank Cheater - " + xi
        TextBox4.Text = "已完成刷次" + CStr(inc) + "次！"
        MsgBox("已完成刷次" + CStr(inc) + "次！", MsgBoxStyle.Information)
        Panel1.Enabled = True
        Button9.Enabled = False
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim xips As String = ""
        On Error Resume Next
        If ip.Trim <> "" Then
            xips = " - " + "IP:" + ip
        End If
        Me.Text = "DBank Cheater - 已刷 " + CStr(inc) + " 次" + xips
        NotifyIcon1.Text = "DBank Cheater - " + xi + " - 已刷 " + CStr(inc) + " 次" + xips
        If xii.Trim <> TextBox4.Text.Trim Then
            TextBox4.Text = xii
        End If
        Dim r1 As String = CStr(inc)
        Dim r2 As String = CStr(NumericUpDown1.Value)
        While (r1).Trim.Length < 3
            r1 = "0" + r1
        End While
        While (r2).Trim.Length < 3
            r2 = "0" + r2
        End While
        Label4.Text = "(" + r1 + "/" + r2 + ")"
        If ProgressBar1.Value <= 100 Then
            ProgressBar1.Value = CInt((inc / NumericUpDown1.Value) * 100)
        Else
            ProgressBar1.Value = 100
        End If
    End Sub
    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        On Error Resume Next
        If MsgBox("是否确定要停止刷次?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            xcc = 1
            wc.Dispose()
            Panel1.Enabled = True
            Shell(My.Application.Info.DirectoryPath + "\DBankCheater.exe", AppWinStyle.NormalFocus, False)
            Close()
        End If
    End Sub
    Private Sub DCF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If xcc = 0 Then
            Dim r = MsgBox("是否要退出DBank Cheater?" + vbCrLf + "Y - 退出" + vbCrLf + "N - 最小化" + vbCrLf + "C - 取消", MsgBoxStyle.YesNoCancel)
            If r = MsgBoxResult.Yes Then
                e.Cancel = False
o:              NotifyIcon1.Icon = Nothing
                savereg()
            Else
                If r = MsgBoxResult.No Then
                    e.Cancel = True
                    NotifyIcon1_MouseDoubleClick(Nothing, Nothing)
                Else
                    e.Cancel = True
                End If
            End If
        Else
            GoTo o
        End If
    End Sub
    Private Sub DCF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        xi = getdatename()
        getreg()
        MkDir(TextBox3.Text)
        NotifyIcon1.Icon = Me.Icon
        WebBrowser1.Url = New Uri("http://www.dbank.com/")
        If Command.Trim <> "" Then
            Button2_Click(Nothing, Nothing)
            NotifyIcon1_MouseDoubleClick(Nothing, Nothing)
        End If
    End Sub
    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        If TextBox2.Text.Trim <> "" Then
            WebBrowser1.Url = New Uri(TextBox2.Text)
            TabControl1.SelectedIndex = 1
        End If
    End Sub
    Private Sub 添加ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加ToolStripMenuItem.Click
        Button3_Click(Nothing, Nothing)
    End Sub
    Private Sub 删除ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除ToolStripMenuItem.Click
        Button4_Click(Nothing, Nothing)
    End Sub
    Private Sub 清空ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清空ToolStripMenuItem.Click
        Button5_Click(Nothing, Nothing)
    End Sub
    Private Sub 上移ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上移ToolStripMenuItem.Click
        SY(ListBox1)
    End Sub
    Private Sub 下移ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 下移ToolStripMenuItem.Click
        XY(ListBox1)
    End Sub
    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If Me.Visible = True Then
            Me.Visible = False
            With NotifyIcon1
                .BalloonTipIcon = ToolTipIcon.Info
                .BalloonTipText = "DBank Cheater被最小化到这里！"
                .BalloonTipTitle = "Gentle Tips"
                .ShowBalloonTip(500)
            End With
        Else
            Me.Visible = True
        End If
    End Sub
    Function getreg()
        On Error Resume Next
        Dim xt = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\" + "cache.ini")
        TextBox3.Text = xt
        Dim xx = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\" + "time.ini")
        NumericUpDown1.Value = CInt(xx)
        Dim yy = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\" + "interval.ini")
        NumericUpDown2.Value = CInt(yy)
        ListBox1.Items.Clear()
        Dim xq = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\" + "link.ini")
        Dim gx = xq.Split(",")
        For x = 0 To gx.LongLength - 1
            ListBox1.Items.Remove(gx(x))
            ListBox1.Items.Add(gx(x))
        Next
        ListBox1.Items.Remove("")
        llx.Items.Clear()
        Dim xqx = My.Computer.FileSystem.ReadAllText(My.Application.Info.DirectoryPath + "\" + "ip.ini")
        Dim gxx = xqx.Split(",")
        For x = 0 To gxx.LongLength - 1
            '     MsgBox(gxx(x))
            llx.Items.Remove(gxx(x))
            llx.Items.Add(gxx(x))
        Next
        llx.Items.Remove("")
    End Function
    Function savereg()
        On Error Resume Next
        If TextBox3.Text.Trim <> "" Then
            My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\" + "cache.ini", TextBox3.Text.Trim, False)
        End If
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\" + "time.ini", CStr(NumericUpDown1.Value).Trim, False)
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\" + "interval.ini", CStr(NumericUpDown2.Value).Trim, False)
        Dim xg As String = ""
        ListBox1.Items.Remove("")
        If ListBox1.Items.Count <> 0 Then
            For x = 0 To ListBox1.Items.Count - 1
                If xg = "" Then
                    xg = ListBox1.Items(x).ToString.Trim
                Else
                    xg = xg + "," + ListBox1.Items(x).ToString.Trim
                End If
            Next
        End If
        My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\" + "link.ini", xg, False)
    End Function
    Private Sub 显示隐藏ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 显示隐藏ToolStripMenuItem.Click
        NotifyIcon1_MouseDoubleClick(Nothing, Nothing)
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        On Error Resume Next
        'Shell("notepad " + My.Application.Info.DirectoryPath + "\ip.ini", AppWinStyle.NormalFocus, False)
        Me.Hide()
        IPSet.ShowDialog()
        Me.Show()
    End Sub

    
End Class