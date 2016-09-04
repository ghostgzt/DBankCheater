
Imports System.Windows.Forms
Public Class IPSet
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim xks = ""
        If ListBox1.Items.Count <> 0 Then
            Dim r = MsgBox("是否要更新IP代理设置?", MsgBoxStyle.YesNo)
            If r = MsgBoxResult.Yes Then
                xks = ListBox1.Items(0).ToString.Trim
                For x = 1 To ListBox1.Items.Count - 1
                    xks = xks + "," + ListBox1.Items(x).ToString.Trim
                Next
k:              My.Computer.FileSystem.WriteAllText(My.Application.Info.DirectoryPath + "\ip.ini", xks, False)
                DCF.getreg()
                MsgBox("IP设置已更新！", MsgBoxStyle.Information)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
            End If
        Else
            Dim w = MsgBox("是否要撤销IP代理?", MsgBoxStyle.YesNo)
            If w = MsgBoxResult.Yes Then
                xks = ""
                GoTo k
            End If
        End If

    End Sub
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub 添加地址ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 添加地址ToolStripMenuItem.Click
        Me.TopMost = False
        Dim r = InputBox("请输入IP代理地址：", "")
        Me.TopMost = True
        If r.Trim <> "" Then
            ListBox1.Items.Remove(r.Trim)
            ListBox1.Items.Insert(0, r.Trim)
        End If
    End Sub
    Private Sub IPSet_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        IPLIB.Close()
    End Sub
    Private Sub IPSet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        If DCF.llx.Items.Count <> 0 Then
            For x = 0 To DCF.llx.Items.Count - 1
                ListBox1.Items.Add(DCF.llx.Items(x))
            Next
        End If
    End Sub
    Private Sub 上移ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 上移ToolStripMenuItem.Click
        DCF.SY(ListBox1)
    End Sub
    Private Sub 下移ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 下移ToolStripMenuItem.Click
        DCF.XY(ListBox1)
    End Sub
    Private Sub 恢复ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 恢复ToolStripMenuItem.Click
        DCF.getreg()
        IPSet_Load(Nothing, Nothing)
    End Sub
    Private Sub 删除地址ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 删除地址ToolStripMenuItem.Click
        For x = 0 To ListBox1.SelectedItems.Count - 1
            ListBox1.Items.Remove(ListBox1.SelectedItems(0))
        Next
    End Sub
    Private Sub 清空列表ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 清空列表ToolStripMenuItem.Click
        ListBox1.Items.Clear()
    End Sub
    Private Sub ContextMenuStrip1_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If ListBox1.Items.Count = 0 Then
            保存列表ToolStripMenuItem.Visible = False
        Else
            保存列表ToolStripMenuItem.Visible = True
        End If
        If ListBox1.SelectedItems.Count <> 0 Then
            上移ToolStripMenuItem.Visible = True
            下移ToolStripMenuItem.Visible = True
            ToolStripSeparator2.Visible = True
            删除地址ToolStripMenuItem.Visible = True
        Else
            上移ToolStripMenuItem.Visible = False
            下移ToolStripMenuItem.Visible = False
            ToolStripSeparator2.Visible = False
            删除地址ToolStripMenuItem.Visible = False
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ListBox1.Text.Trim <> "" Then
            Me.TopMost = False
            ProxyTest.TextBox1.Text = ListBox1.Text
            ProxyTest.ShowDialog()
            Me.TopMost = True
        End If
    End Sub
    Private Sub IP列表ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IP列表ToolStripMenuItem.Click
        On Error Resume Next
        IPLIB.Show()
        Me.Left = IPLIB.Left + IPLIB.Width
        Me.Top = IPLIB.Top
    End Sub
    Private Sub 读取列表ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 读取列表ToolStripMenuItem.Click
        On Error Resume Next
        With New OpenFileDialog
            .FileName = ""
            .Filter = "*.ipx|*.ipx"
            .ShowDialog()
            If .FileName <> "" Then
                Dim kxz = My.Computer.FileSystem.ReadAllText(.FileName)
                Dim xw = kxz.Split(";")
                ListBox1.Items.Clear()
                For x = 0 To xw.LongLength - 1
                    ListBox1.Items.Add(xw(x))
                Next
                MsgBox("已读取列表" + vbCrLf + .FileName, MsgBoxStyle.Information)
            End If
        End With
    End Sub
    Private Sub 保存列表ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 保存列表ToolStripMenuItem.Click
        On Error Resume Next
        With New SaveFileDialog
            .FileName = ""
            .Filter = "*.ipx|*.ipx"
            .ShowDialog()
            If .FileName <> "" Then
                Dim kxz = ListBox1.Items(0)
                For x = 1 To ListBox1.Items.Count - 1
                    kxz = kxz + ";" + ListBox1.Items(x).ToString.Trim
                Next
                My.Computer.FileSystem.WriteAllText(.FileName, kxz, False)
                MsgBox("已导出列表到" + vbCrLf + .FileName, MsgBoxStyle.Information)
            End If
        End With
    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Button1_Click(Nothing, Nothing)
    End Sub
End Class