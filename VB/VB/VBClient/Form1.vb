Imports System
Imports Snap7

Public Class MainForm

    Dim Buffer(65536) As Byte
    Dim Client As Snap7.S7Client

    Private Sub ShowResult(ByVal Result As Integer)

        TextError.Text = Client.ErrorText(Result)
    End Sub

    Public Sub New()

        InitializeComponent()

        Client = New S7Client

        If IntPtr.Size = 4 Then
            Text = Text + " - Running 32 bit Code"
        Else
            Text = Text + " - Running 64 bit Code"
        End If

    End Sub

    Private Sub ConnectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConnectBtn.Click
        Dim Result As Integer
        Dim Rack As Integer = System.Convert.ToInt32(TxtRack.Text)
        Dim Slot As Integer = System.Convert.ToInt32(TxtSlot.Text)
        Result = Client.ConnectTo(TxtIP.Text, Rack, Slot)
        ShowResult(Result)
        If Result = 0 Then
            TxtIP.Enabled = False
            TxtRack.Enabled = False
            TxtSlot.Enabled = False
            ConnectBtn.Enabled = False
            DisconnectBtn.Enabled = True
            TxtMB.Enabled = True
            TxtSize.Enabled = True
            RBtn.Enabled = True
            RBox.Enabled = True
            WBtn.Enabled = True
            WBox.Enabled = True
        End If
    End Sub

    Private Sub DisconnectBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisconnectBtn.Click
        Client.Disconnect()
        TxtIP.Enabled = True
        TxtRack.Enabled = True
        TxtSlot.Enabled = True
        ConnectBtn.Enabled = True
        DisconnectBtn.Enabled = False
        TxtMB.Enabled = False
        TxtSize.Enabled = False
        RBtn.Enabled = False
        RBox.Enabled = False
        WBtn.Enabled = False
        WBox.Enabled = False
    End Sub

    Private Sub RBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBtn.Click

        Dim MB As Integer
        Dim Size As Integer
        Dim Result As Integer
        Dim c, y As Integer
        Dim s As String
        '
        RBox.Text = ""
        MB = System.Convert.ToInt32(TxtMB.Text)
        Size = System.Convert.ToInt32(TxtSize.Text)

        Result = Client.MBRead(0, Size, Buffer)
        ShowResult(Result)

        If Result = 0 Then
            y = 0
            For c = 0 To Size - 1
                s = Hex$(Buffer(c))
                If s.Length = 1 Then
                    s = "0" + s
                End If
                RBox.Text = RBox.Text + "0x" + s + " "
                y = y + 1
                If y = 8 Then
                    y = 0
                    RBox.Text = RBox.Text + Chr(13) + Chr(10)
                End If
            Next
        End If
    End Sub
    Private Sub WBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WBtn.Click

        Dim MB As Integer
        Dim Size1 As Integer
        Dim Result1 As Integer
        Dim c1, y1 As Integer
        Dim s1 As String
        '
        WBox.Text = ""
        MB = System.Convert.ToInt32(TxtMB.Text)
        Size1 = System.Convert.ToInt32(TxtSize.Text)

        Result1 = Client.MBWrite(0, Size1, Buffer)
        ShowResult(Result1)

        If Result1 = 0 Then
            y1 = 0
            For c1 = 0 To Size1 - 1
                s1 = Hex$(Buffer(c1))
                If s1.Length = 1 Then
                    s1 = "0" + s1
                End If
                WBox.Text = WBox.Text + "0x" + s1 + " "
                y1 = y1 + 1
                If y1 = 8 Then
                    y1 = 0
                    WBox.Text = WBox.Text + Chr(13) + Chr(10)
                End If
            Next
        End If
    End Sub
    Private Sub TxtDB_TextChanged(sender As Object, e As EventArgs) Handles TxtMB.TextChanged

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
