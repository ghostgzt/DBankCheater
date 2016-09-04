Public Class IPLIB
    Public wk As New System.Net.WebClient
    Private Sub IPLIB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getlist("http://www.cnproxy.com/proxy1.html")
    End Sub
    Dim sde
    Dim sdx = "http://www.cnproxy.com/"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error Resume Next
        getlist("http://www.cnproxy.com/proxy1.html")
        ListBox1.SelectedIndex = 0
        'TextBox1.Text = (sde.Replace("<ul>", "#").Replace("</div>", "#").Split("#")(9)).Replace("<li><a href=" + """", "").Replace("""" + ">", "'").Replace("&nbsp;&nbsp;&nbsp;", "'").Replace("</a></li>", ";" + vbCrLf).Replace(" ", "").Replace("</ul>", "").Trim
    End Sub
    Dim scy
    Function getip(ByVal url As String)
        On Error Resume Next
        ListView1.Items.Clear()
        sde = wk.DownloadString(url)
        Dim s11 = sde.Replace("<table>", "^").Replace("</table>", "^").Split("^")(5).Replace("+z", "3").Replace("+m", "4").Replace("+k", "2").Replace("+l", "9").Replace("+d", "0").Replace("+b", "5").Replace("+i", "7").Replace("+w", "6").Replace("+r", "8").Replace("+c", "1").Replace("<tr><td width=" + """" + "140" + """" + ">IP:Port</td><td width=" + """" + "40" + """" + ">Type</td><td width=" + """" + "90" + """" + ">Speed</td><td width=" + """" + "160" + """" + "> Country/Area</td></tr>", "").Replace("<tr><td>", "").Replace("<SCRIPT type=text/javascript>document.write(" + """" + ":" + """", "'").Replace(")</SCRIPT></td><td>", "'").Replace("</td><td>", "'").Replace("</td></tr>", ";").Replace(vbLf, "")
        'MsgBox(TextBox1.Text.Split(";")(0).Split("'")(0))
        Dim scx = s11.Split(";")
        For x = 0 To scx.LongLength - 1
            Dim mbx = scx(x).Split("'")
            Dim tp = ListView1.Items.Add(mbx(0))
            For y = 1 To mbx.LongLength - 1
                tp.SubItems.Add(mbx(y))
            Next
        Next
        ListView1.Columns.Item(0).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns.Item(1).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns.Item(2).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns.Item(3).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
        ListView1.Columns.Item(4).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
    End Function
    Function getlist(ByVal url As String)
        On Error Resume Next
        sde = wk.DownloadString(url)
        ListBox1.Items.Clear()
        Dim s12 = (sde.Replace("<ul>", "#").Replace("</div>", "#").Split("#")(9)).Replace("<li><a href=" + """", "").Replace("""" + ">", "'").Replace("&nbsp;&nbsp;&nbsp;", "'").Replace("</a></li>", ";" + vbCrLf).Replace(" ", "").Replace("</ul>", "").Trim
        scy = s12.Split(";")
        For x = 0 To scy.LongLength - 1
            Dim mby = scy(x).Split("'")
            '  Dim tp = ListView1.Items.Add(mby(0))
            ListBox1.Items.Add(mby(1) + mby(2))
        Next
    End Function
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        getip(sdx + scy(ListBox1.SelectedIndex).Split("'")(0).ToString.Trim)
    End Sub
    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Button4_Click(Nothing, Nothing)
    End Sub
    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        changerstute()
        If ListView1.SelectedItems.Count <> 0 Then
            Label1.Text = "IP地址：" + ListView1.SelectedItems(0).SubItems(0).Text + ":" + ListView1.SelectedItems(0).SubItems(1).Text + vbCrLf + "地理位置：" + ListView1.SelectedItems(0).SubItems(4).Text
        End If
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If ListView1.SelectedItems.Count <> 0 Then
            ProxyTest.TextBox1.Text = ListView1.SelectedItems(0).SubItems(0).Text + ":" + ListView1.SelectedItems(0).SubItems(1).Text
            ProxyTest.ShowDialog()
        End If
    End Sub
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        On Error Resume Next
        If ListView1.SelectedItems.Count <> 0 Then
            My.Computer.Clipboard.SetText(ListView1.SelectedItems(0).SubItems(0).Text + ":" + ListView1.SelectedItems(0).SubItems(1).Text)
            MsgBox(ListView1.SelectedItems(0).SubItems(0).Text + ":" + ListView1.SelectedItems(0).SubItems(1).Text + vbCrLf + "已经复制到剪辑板！", MsgBoxStyle.Information)
        End If
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IPSet.Show()
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        On Error Resume Next
        For x = 0 To ListView1.SelectedItems.Count - 1
            Dim kx = ListView1.SelectedItems(x).SubItems(0).Text + ":" + ListView1.SelectedItems(x).SubItems(1).Text
            IPSet.ListBox1.Items.Remove(kx.ToString.Trim)
            IPSet.ListBox1.Items.Add(kx.ToString.Trim)
        Next
        MsgBox("已添加" + CStr(ListView1.SelectedItems.Count) + "个IP！", MsgBoxStyle.Information)
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        On Error Resume Next
        For x = 0 To ListView1.Items.Count - 1
            Dim kx = ListView1.Items(x).SubItems(0).Text + ":" + ListView1.Items(x).SubItems(1).Text
            IPSet.ListBox1.Items.Remove(kx.ToString.Trim)
            IPSet.ListBox1.Items.Add(kx.ToString.Trim)
        Next
        MsgBox("已添加" + CStr(ListView1.Items.Count) + "个IP！", MsgBoxStyle.Information)
    End Sub
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        changerstute()
    End Sub
    Function changerstute()
        On Error Resume Next
        Dim kx = False
        If ListView1.SelectedItems.Count = 0 Then
            kx = False
        Else
            kx = True
        End If
        添加全部ToolStripMenuItem.Visible = kx
        添加选中ToolStripMenuItem.Visible = kx
        复制IPToolStripMenuItem.Visible = kx
        测试IPToolStripMenuItem.Visible = kx
        ToolStripSeparator1.Visible = kx
        ToolStripSeparator2.Visible = kx
        Button2.Enabled = kx
        Button3.Enabled = kx
        Button4.Enabled = kx
        Button6.Enabled = kx
    End Function
    Private Sub 添加选中ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加选中ToolStripMenuItem.Click
        Button3_Click(Nothing, Nothing)
    End Sub
    Private Sub 添加全部ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加全部ToolStripMenuItem.Click
        Button2_Click(Nothing, Nothing)
    End Sub
    Private Sub 复制IPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 复制IPToolStripMenuItem.Click
        Button6_Click(Nothing, Nothing)
    End Sub
    Private Sub 测试IPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 测试IPToolStripMenuItem.Click
        Button4_Click(Nothing, Nothing)
    End Sub
    Private Sub 获取列表ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 获取列表ToolStripMenuItem.Click
        Button1_Click(Nothing, Nothing)
    End Sub
End Class