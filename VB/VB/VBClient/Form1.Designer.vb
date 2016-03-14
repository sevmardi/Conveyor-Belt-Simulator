<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextError = New System.Windows.Forms.TextBox()
        Me.TxtIP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtRack = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtSlot = New System.Windows.Forms.TextBox()
        Me.ConnectBtn = New System.Windows.Forms.Button()
        Me.DisconnectBtn = New System.Windows.Forms.Button()
        Me.TxtMB = New System.Windows.Forms.TextBox()
        Me.RBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtSize = New System.Windows.Forms.TextBox()
        Me.RBtn = New System.Windows.Forms.Button()
        Me.WBtn = New System.Windows.Forms.Button()
        Me.WBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextError
        '
        Me.TextError.BackColor = System.Drawing.Color.White
        Me.TextError.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextError.ForeColor = System.Drawing.Color.Black
        Me.TextError.Location = New System.Drawing.Point(0, 263)
        Me.TextError.Name = "TextError"
        Me.TextError.ReadOnly = True
        Me.TextError.Size = New System.Drawing.Size(440, 20)
        Me.TextError.TabIndex = 0
        '
        'TxtIP
        '
        Me.TxtIP.Location = New System.Drawing.Point(12, 27)
        Me.TxtIP.Name = "TxtIP"
        Me.TxtIP.Size = New System.Drawing.Size(100, 20)
        Me.TxtIP.TabIndex = 1
        Me.TxtIP.Text = "192.168.2.2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "IP Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(122, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Rack"
        '
        'TxtRack
        '
        Me.TxtRack.Location = New System.Drawing.Point(122, 27)
        Me.TxtRack.Name = "TxtRack"
        Me.TxtRack.Size = New System.Drawing.Size(44, 20)
        Me.TxtRack.TabIndex = 2
        Me.TxtRack.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(178, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Slot"
        '
        'TxtSlot
        '
        Me.TxtSlot.Location = New System.Drawing.Point(178, 27)
        Me.TxtSlot.Name = "TxtSlot"
        Me.TxtSlot.Size = New System.Drawing.Size(44, 20)
        Me.TxtSlot.TabIndex = 3
        Me.TxtSlot.Text = "2"
        '
        'ConnectBtn
        '
        Me.ConnectBtn.Location = New System.Drawing.Point(12, 69)
        Me.ConnectBtn.Name = "ConnectBtn"
        Me.ConnectBtn.Size = New System.Drawing.Size(100, 23)
        Me.ConnectBtn.TabIndex = 4
        Me.ConnectBtn.Text = "Connect"
        Me.ConnectBtn.UseVisualStyleBackColor = True
        '
        'DisconnectBtn
        '
        Me.DisconnectBtn.Enabled = False
        Me.DisconnectBtn.Location = New System.Drawing.Point(122, 69)
        Me.DisconnectBtn.Name = "DisconnectBtn"
        Me.DisconnectBtn.Size = New System.Drawing.Size(100, 23)
        Me.DisconnectBtn.TabIndex = 8
        Me.DisconnectBtn.Text = "Disconnect"
        Me.DisconnectBtn.UseVisualStyleBackColor = True
        '
        'TxtMB
        '
        Me.TxtMB.Enabled = False
        Me.TxtMB.Location = New System.Drawing.Point(146, 112)
        Me.TxtMB.Name = "TxtMB"
        Me.TxtMB.Size = New System.Drawing.Size(45, 20)
        Me.TxtMB.TabIndex = 5
        Me.TxtMB.Text = "1"
        '
        'RBox
        '
        Me.RBox.BackColor = System.Drawing.Color.White
        Me.RBox.Enabled = False
        Me.RBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBox.ForeColor = System.Drawing.Color.Black
        Me.RBox.Location = New System.Drawing.Point(122, 138)
        Me.RBox.Multiline = True
        Me.RBox.Name = "RBox"
        Me.RBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.RBox.Size = New System.Drawing.Size(302, 55)
        Me.RBox.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(119, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "MB"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(196, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Size (Bytes)"
        '
        'TxtSize
        '
        Me.TxtSize.Enabled = False
        Me.TxtSize.Location = New System.Drawing.Point(264, 112)
        Me.TxtSize.Name = "TxtSize"
        Me.TxtSize.Size = New System.Drawing.Size(45, 20)
        Me.TxtSize.TabIndex = 6
        Me.TxtSize.Text = "1"
        '
        'RBtn
        '
        Me.RBtn.Enabled = False
        Me.RBtn.Location = New System.Drawing.Point(14, 138)
        Me.RBtn.Name = "RBtn"
        Me.RBtn.Size = New System.Drawing.Size(97, 23)
        Me.RBtn.TabIndex = 16
        Me.RBtn.Text = "MB Read"
        Me.RBtn.UseVisualStyleBackColor = True
        '
        'WBtn
        '
        Me.WBtn.Enabled = False
        Me.WBtn.Location = New System.Drawing.Point(15, 198)
        Me.WBtn.Name = "WBtn"
        Me.WBtn.Size = New System.Drawing.Size(97, 23)
        Me.WBtn.TabIndex = 18
        Me.WBtn.Text = "MB Write"
        Me.WBtn.UseVisualStyleBackColor = True
        '
        'WBox
        '
        Me.WBox.BackColor = System.Drawing.Color.White
        Me.WBox.Enabled = False
        Me.WBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WBox.ForeColor = System.Drawing.Color.Black
        Me.WBox.Location = New System.Drawing.Point(122, 199)
        Me.WBox.Multiline = True
        Me.WBox.Name = "WBox"
        Me.WBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.WBox.Size = New System.Drawing.Size(302, 55)
        Me.WBox.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(286, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "issasalimi@yahoo.com"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 283)
        Me.Controls.Add(Me.WBtn)
        Me.Controls.Add(Me.WBox)
        Me.Controls.Add(Me.RBtn)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtSize)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.RBox)
        Me.Controls.Add(Me.TxtMB)
        Me.Controls.Add(Me.DisconnectBtn)
        Me.Controls.Add(Me.ConnectBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtSlot)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtRack)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtIP)
        Me.Controls.Add(Me.TextError)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "MainForm"
        Me.Text = "VB.NET Simple Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextError As System.Windows.Forms.TextBox
    Friend WithEvents TxtIP As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtRack As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtSlot As System.Windows.Forms.TextBox
    Friend WithEvents ConnectBtn As System.Windows.Forms.Button
    Friend WithEvents DisconnectBtn As System.Windows.Forms.Button
    Friend WithEvents TxtMB As System.Windows.Forms.TextBox
    Friend WithEvents RBox As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtSize As System.Windows.Forms.TextBox
    Friend WithEvents RBtn As System.Windows.Forms.Button
    Friend WithEvents WBtn As System.Windows.Forms.Button
    Friend WithEvents WBox As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
