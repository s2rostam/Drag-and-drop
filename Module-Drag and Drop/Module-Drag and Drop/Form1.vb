Public Class DragAndDrop
    Dim cur As Cursor = New Cursor(New IO.MemoryStream(My.Resources.H_MOVE))

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        ChangeCursor()
        PictureBox2.SendToBack()
        ToolStripStatusLabel1.Text = PictureBox1.Location.ToString()
    End Sub

    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        ChangeCursor()
        PictureBox1.SendToBack()
        ToolStripStatusLabel1.Text = PictureBox2.Location.ToString()
    End Sub

    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        ResetDefaultCursor()
    End Sub

    Private Sub PictureBox2_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseUp
        ResetDefaultCursor()
    End Sub

    Private Sub ChangeCursor()
        Me.Cursor = cur
    End Sub

    Private Sub ResetDefaultCursor()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Static mousePosX As Single, mousePosY As Single
        If (e.Button = 0) Then
            mousePosX = e.X
            mousePosY = e.Y
        Else
            PictureBox1.Left = PictureBox1.Left + (e.X - mousePosX)
            PictureBox1.Top = PictureBox1.Top + (e.Y - mousePosY)
            Dim intersect As Boolean = PictureBox1.Bounds.IntersectsWith(PictureBox2.Bounds)
            If (intersect) Then
                ToolStripStatusLabel1.Text = "PictureBox1: " + PictureBox1.Location.ToString + " || PictureBox1 is overlapping PictureBox2"
            Else
                ToolStripStatusLabel1.Text = "PictureBox1: " + PictureBox1.Location.ToString
            End If
        End If

    End Sub

    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        Static mX As Single, mY As Single
        If (e.Button = 0) Then
            mX = e.X
            mY = e.Y
        Else
            PictureBox2.Left = PictureBox2.Left + (e.X - mX)
            PictureBox2.Top = PictureBox2.Top + (e.Y - mY)
            Dim intersect As Boolean = PictureBox2.Bounds.IntersectsWith(PictureBox1.Bounds)
            If (intersect) Then
                ToolStripStatusLabel1.Text = "PictureBox2: " + PictureBox2.Location.ToString + " || PictureBox2 is overlapping PictureBox1"
            Else
                ToolStripStatusLabel1.Text = "PictureBox2: " + PictureBox2.Location.ToString
            End If
        End If
    End Sub

End Class
