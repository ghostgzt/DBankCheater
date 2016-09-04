<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPSet
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IPSet))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.添加地址ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IP列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.读取列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.保存列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.上移ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.下移ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.恢复ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.删除地址ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.清空列表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(95, 268)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 27)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 21)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "确定"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 21)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "取消"
        '
        'ListBox1
        '
        Me.ListBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 12
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBox1.Size = New System.Drawing.Size(253, 256)
        Me.ListBox1.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.添加地址ToolStripMenuItem, Me.IP列表ToolStripMenuItem, Me.ToolStripSeparator1, Me.读取列表ToolStripMenuItem, Me.保存列表ToolStripMenuItem, Me.ToolStripSeparator4, Me.上移ToolStripMenuItem, Me.下移ToolStripMenuItem, Me.ToolStripSeparator2, Me.恢复ToolStripMenuItem, Me.ToolStripSeparator3, Me.删除地址ToolStripMenuItem, Me.清空列表ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 226)
        '
        '添加地址ToolStripMenuItem
        '
        Me.添加地址ToolStripMenuItem.Name = "添加地址ToolStripMenuItem"
        Me.添加地址ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.添加地址ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.添加地址ToolStripMenuItem.Text = "添加地址"
        '
        'IP列表ToolStripMenuItem
        '
        Me.IP列表ToolStripMenuItem.Name = "IP列表ToolStripMenuItem"
        Me.IP列表ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.IP列表ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.IP列表ToolStripMenuItem.Text = "IP列表"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(161, 6)
        '
        '读取列表ToolStripMenuItem
        '
        Me.读取列表ToolStripMenuItem.Name = "读取列表ToolStripMenuItem"
        Me.读取列表ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.读取列表ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.读取列表ToolStripMenuItem.Text = "读取列表"
        '
        '保存列表ToolStripMenuItem
        '
        Me.保存列表ToolStripMenuItem.Name = "保存列表ToolStripMenuItem"
        Me.保存列表ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.保存列表ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.保存列表ToolStripMenuItem.Text = "保存列表"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(161, 6)
        '
        '上移ToolStripMenuItem
        '
        Me.上移ToolStripMenuItem.Name = "上移ToolStripMenuItem"
        Me.上移ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.上移ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.上移ToolStripMenuItem.Text = "上移"
        '
        '下移ToolStripMenuItem
        '
        Me.下移ToolStripMenuItem.Name = "下移ToolStripMenuItem"
        Me.下移ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.下移ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.下移ToolStripMenuItem.Text = "下移"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(161, 6)
        '
        '恢复ToolStripMenuItem
        '
        Me.恢复ToolStripMenuItem.Name = "恢复ToolStripMenuItem"
        Me.恢复ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.恢复ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.恢复ToolStripMenuItem.Text = "恢复"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(161, 6)
        '
        '删除地址ToolStripMenuItem
        '
        Me.删除地址ToolStripMenuItem.Name = "删除地址ToolStripMenuItem"
        Me.删除地址ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.删除地址ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.删除地址ToolStripMenuItem.Text = "删除地址"
        '
        '清空列表ToolStripMenuItem
        '
        Me.清空列表ToolStripMenuItem.Name = "清空列表ToolStripMenuItem"
        Me.清空列表ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.K), System.Windows.Forms.Keys)
        Me.清空列表ToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.清空列表ToolStripMenuItem.Text = "清空列表"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 270)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "测试"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'IPSet
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(253, 306)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "IPSet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IP代理"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 添加地址ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 上移ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 下移ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 恢复ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents 删除地址ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 清空列表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents IP列表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 读取列表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 保存列表ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator

End Class
