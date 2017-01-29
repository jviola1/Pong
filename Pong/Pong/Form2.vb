Imports System.IO

Public Class Form2

    'Exits the program
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    'Resets the scores back to the original, stock scores
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim fs1 As New FileStream("High Scores.txt", FileMode.Create, FileAccess.Write)
        Dim textFile1 As New StreamWriter(fs1)

        textFile1.WriteLine("Stock 30")
        textFile1.WriteLine("Stock 1")
        textFile1.WriteLine("Stock 2")
        textFile1.WriteLine("Stock 3")
        textFile1.WriteLine("Stock 4")
        textFile1.WriteLine("Stock 5")
        textFile1.WriteLine("Stock 0")
        textFile1.WriteLine("Stock 10")
        textFile1.WriteLine("Stock 15")
        textFile1.WriteLine("Stock 8")

        textFile1.Close()
        fs1.Close()

        txtHighScores.Text = "1. Stock 30" & vbCrLf & "2. Stock 15" & vbCrLf & "3. Stock 10" & vbCrLf & "4. Stock 8" & vbCrLf & "5. Stock 5" & vbCrLf & "6. Stock 4" & vbCrLf & "7. Stock 3" & vbCrLf & "8. Stock 2" & vbCrLf & "9. Stock 1" & vbCrLf & "10. Stock 0" & vbCrLf
    End Sub
End Class