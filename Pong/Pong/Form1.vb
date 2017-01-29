'Only labels are used on Form1 because any controls other than labels would take the focus off of the form, disrupting the keydown methods
Imports System.IO
Public Class Form1
    Dim paddleup As Boolean = False 'Stores paddle direction
    Dim ballLeftRight As Integer = 0 'Stores change in x
    Dim ballUpDown As Integer = 0 'Stores change in y
    Dim playerPaddleY As Integer = 159 'Finds upper-most y-value of player paddle.  Initialized to starting position.
    Dim AIPaddleY As Integer = 159 'Finds upper-most y-value of AI paddle.  Initialized to starting position.
    Dim ballY As Integer = 182 'Finds upper-most y-value of ball.  Initialized to starting position.
    Dim score As Integer = 0 'Initializes player's score to 0
    Dim lives As Integer = 3 'Initializes player's lives to 3
    Dim playerName As String = "Player" 'Initializes player's name to the default: "Player"
    Dim integerArray(11) As Integer 'Array of high scores
    Dim stringArray(11) As String 'Array of high score names
    Dim playedGame As Boolean = False 'Keeps track of whether or not the user has completed a game or not

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        'Determines which key the user is pressing and sets the paddle to the appropriate direction
        If e.KeyCode = Keys.Up Then
            paddleup = True
            tmrMovePaddle.Start()
        ElseIf e.KeyCode = Keys.Down Then
            paddleup = False
            tmrMovePaddle.Start()
        End If
    End Sub

    Private Sub tmrMovePaddle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMovePaddle.Tick
        'Timer used to move the actual paddle
        playerPaddleY = paddlePlayer.Location.Y 'Finds new location
        If paddleup = True And playerPaddleY >= 9 Then
            paddlePlayer.Top = paddlePlayer.Top - 5
        ElseIf paddleup = False And playerPaddleY <= 321 Then
            paddlePlayer.Top = paddlePlayer.Top + 5
        End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        tmrMovePaddle.Stop()
    End Sub

    Private Sub lblGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblGo.Click
        'Hides "button" and begins the game.  Sets the initial direction of the ball and begins the ball and AI timer.
        lblGo.Visible = False
        lblGo.Enabled = False
        tmrBall.Start()
        tmrAI.Start()
        Randomize() 'Randomizes the starting angle of the ball
        ballUpDown = RandomIntNumber(-5, 5)
        ballLeftRight = RandomIntNumber(-5, 5)
        If ballLeftRight >= 0 Then
            ballLeftRight = 5
        Else
            ballLeftRight = -5
        End If
    End Sub

    Private Sub tmrBall_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBall.Tick
        ballY = ball.Location.Y
        ball.Left = ball.Left + ballLeftRight 'Moves the ball left or right depending on stored value
        ball.Top = ball.Top + ballUpDown 'Moves the ball up or down depending on the stored value
        If ball.Bounds.IntersectsWith(paddlePlayer.Bounds) Then 'Determines where the ball hit on the paddle and calculates the proper return angle
            If ballY <= playerPaddleY + 10 Then
                ballLeftRight = 5
                ballUpDown = -10
            ElseIf ballY <= playerPaddleY + 23 And ballY > playerPaddleY + 10 Then
                ballLeftRight = 5
                ballUpDown = -5
            ElseIf ballY <= playerPaddleY + 27 And ballY > playerPaddleY + 23 Then
                ballLeftRight = 5
                ballUpDown = 0
            ElseIf ballY <= playerPaddleY + 40 And ballY > playerPaddleY + 27 Then
                ballLeftRight = 5
                ballUpDown = 5
            ElseIf ballY <= playerPaddleY + 50 And ballY > playerPaddleY + 40 Then
                ballLeftRight = 5
                ballUpDown = 10
            End If
        ElseIf ball.Bounds.IntersectsWith(paddleAI.Bounds) Then 'Determines where the ball hit on the paddle and calculates the proper return angle
            If ballY <= AIPaddleY + 10 Then
                ballLeftRight = -5
                ballUpDown = -10
            ElseIf ballY <= AIPaddleY + 23 And ballY > AIPaddleY + 10 Then
                ballLeftRight = -5
                ballUpDown = -5
            ElseIf ballY <= AIPaddleY + 27 And ballY > AIPaddleY + 23 Then
                ballLeftRight = -5
                ballUpDown = 0
            ElseIf ballY <= AIPaddleY + 40 And ballY > AIPaddleY + 27 Then
                ballLeftRight = -5
                ballUpDown = 5
            ElseIf ballY <= AIPaddleY + 50 And ballY > AIPaddleY + 40 Then
                ballLeftRight = -5
                ballUpDown = 10
            End If
        ElseIf ball.Bounds.IntersectsWith(barrierTop.Bounds) Or ball.Bounds.IntersectsWith(barrierBottom.Bounds) Then 'Ricochets ball off of barriers
            ballUpDown = -ballUpDown
        ElseIf ball.Bounds.IntersectsWith(goalAI.Bounds) Then 'Calls reset method and adds a point to the player
            score = score + 1
            lblScore.Text = "Score: " & score
            Call reset()
        ElseIf ball.Bounds.IntersectsWith(goalPlayer.Bounds) Then 'Calls reset method and reduces life of the player
            lives = lives - 1
            lblLives.Text = "Lives: " & lives
            Call reset()
        End If
    End Sub

    'After a score or a new game, resets the paddles and ball to their original places and restores the function of lblGo
    Public Sub reset()
        ball.Location = New Point(382, 182)
        paddlePlayer.Location = New Point(50, 159)
        paddleAI.Location = New Point(729, 159)
        playerPaddleY = 159
        AIPaddleY = 159
        lblGo.Visible = True
        lblGo.Enabled = True
        ballLeftRight = 0
        ballUpDown = 0
        tmrBall.Stop()
        tmrAI.Stop()

        If lives = 1 Then
            lblLives.ForeColor = Color.Red
        ElseIf lives = 0 Then 'If the player loses, the score, lives and timer intervals reset
            playedGame = True
            Form2.txtHighScores.Text = Nothing
            MessageBox.Show("You lost with a score of: " & score) 'Displays final score
            Dim counter As Integer = 0

            Dim fs2 As New FileStream("High Scores.txt", FileMode.Append, FileAccess.Write) 'Adds player's score to the list
            Dim textFile2 As New StreamWriter(fs2)
            textFile2.WriteLine(playerName & " " & score)
            textFile2.Close()
            fs2.Close()

            Dim fs1 As New FileStream("High Scores.txt", FileMode.Open, FileAccess.Read) 'Takes player names into stringArray
            Dim textFile1 As New StreamReader(fs1)
            Do While textFile1.Peek > -1 And counter < 11
                stringArray(counter) = textFile1.ReadLine()
                counter += 1
            Loop

            fs1.Close()
            textFile1.Close()

            counter = 0
            Do While counter < 11 'Takes score value located after the space and separates it from the name of the player
                integerArray(counter) = Int(Val(stringArray(counter).Substring(stringArray(counter).IndexOf(" ") + 1)))
                stringArray(counter) = stringArray(counter).Substring(0, stringArray(counter).IndexOf(" "))
                counter += 1
            Loop

            BubbleSort(integerArray, stringArray) 'Sorts scores

            Dim fs3 As New FileStream("High Scores.txt", FileMode.Create, FileAccess.Write)
            Dim textFile3 As New StreamWriter(fs3)

            counter = 0
            Do While counter < 10 'Rewrites sorted scores into text file
                textFile3.WriteLine(stringArray(counter) & " " & integerArray(counter))
                Form2.txtHighScores.Text &= counter + 1 & ". " & stringArray(counter) & " " & integerArray(counter) & vbCrLf
                counter += 1
            Loop
            textFile3.Close()
            fs3.Close()

            score = 0
            lives = 3
            lblLives.Text = "Lives: 3"
            lblScore.Text = "Score: 0"
            lblLives.ForeColor = Color.White
            tmrAI.Interval = 50
            tmrBall.Interval = 50
        End If

        'Increases difficulty by reducing timer interval
        tmrAI.Interval = tmrAI.Interval - (score * 2)
        tmrBall.Interval = tmrBall.Interval - (score * 2)

    End Sub

    'AI follows the ball by comparing its own paddle's y value to that of the ball's
    Private Sub tmrAI_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAI.Tick
        AIPaddleY = paddleAI.Location.Y
        If ballY + 17 < AIPaddleY + 25 And AIPaddleY >= 9 Then
            paddleAI.Top = paddleAI.Top - 5
        ElseIf ballY + 17 > AIPaddleY + 25 And AIPaddleY <= 321 Then
            paddleAI.Top = paddleAI.Top + 5
        End If
    End Sub

    Private Sub lblGo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGo.MouseHover
        lblGo.ForeColor = Color.Red
    End Sub

    Private Sub lblGo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblGo.MouseLeave
        lblGo.ForeColor = Color.White
    End Sub

    Private Sub lblNewGame_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNewGame.MouseHover
        lblNewGame.ForeColor = Color.Red
    End Sub

    Private Sub lblNewGame_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblNewGame.MouseLeave
        lblNewGame.ForeColor = Color.White
    End Sub

    'Resets lives, score and timer intervals back to initial
    Private Sub lblNewGame_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblNewGame.Click
        lives = 3
        score = 0
        lblLives.Text = "Lives: 3"
        lblScore.Text = "Score: 0"
        tmrAI.Interval = 50
        tmrBall.Interval = 50
        lblLives.ForeColor = Color.White
        Call reset()
    End Sub

    Private Sub lblExit_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExit.MouseHover
        lblExit.ForeColor = Color.Red
    End Sub

    Private Sub lblExit_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblExit.MouseLeave
        lblExit.ForeColor = Color.White
    End Sub

    Private Sub lblExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblExit.Click
        End
    End Sub

    'Opens a color dialog and changes the player's paddle to the color selected
    Private Sub lblCustomize_Click(sender As System.Object, e As System.EventArgs) Handles lblCustomize.Click
        clrCustomize.ShowDialog()
        paddlePlayer.BackColor = clrCustomize.Color
    End Sub

    Private Sub lblCustomize_MouseHover(sender As Object, e As System.EventArgs) Handles lblCustomize.MouseHover
        lblCustomize.ForeColor = Color.Yellow
        tmrCustomize.Start()
        lblCustomPrompt.ForeColor = Color.White
    End Sub

    'Vanity timer to change color of customization button
    Private Sub tmrCustomize_Tick(sender As System.Object, e As System.EventArgs) Handles tmrCustomize.Tick
        If lblCustomize.ForeColor = Color.Yellow Then
            lblCustomize.ForeColor = Color.Pink
        ElseIf lblCustomize.ForeColor = Color.Pink Then
            lblCustomize.ForeColor = Color.Blue
        ElseIf lblCustomize.ForeColor = Color.Blue Then
            lblCustomize.ForeColor = Color.Lime
        ElseIf lblCustomize.ForeColor = Color.Lime Then
            lblCustomize.ForeColor = Color.Purple
        ElseIf lblCustomize.ForeColor = Color.Purple Then
            lblCustomize.ForeColor = Color.Yellow
        End If
    End Sub

    Private Sub lblCustomize_MouseLeave(sender As Object, e As System.EventArgs) Handles lblCustomize.MouseLeave
        tmrCustomize.Stop()
        lblCustomize.ForeColor = Color.White
        lblCustomPrompt.ForeColor = Color.Black
    End Sub

    'Allows the player to change their name to be displayed in the score list
    'Name cannot begin with a number and cannot contain a space
    Private Sub lblName_Click(sender As System.Object, e As System.EventArgs) Handles lblName.Click
        playerName = InputBox("Enter your name (It may not begin with a number or contain a space):")
        Do While playerName.Substring(0, 1) = "0" Or playerName.Substring(0, 1) = "1" Or playerName.Substring(0, 1) = "2" Or playerName.Substring(0, 1) = "3" Or playerName.Substring(0, 1) = "4" Or playerName.Substring(0, 1) = "5" Or playerName.Substring(0, 1) = "6" Or playerName.Substring(0, 1) = "7" Or playerName.Substring(0, 1) = "8" Or playerName.Substring(0, 1) = "9" Or playerName.IndexOf(" ") > -1
            playerName = InputBox("Enter your name (It may not begin with a number or contain a space):")
        Loop
        lblName.Text = playerName
    End Sub

    Private Sub lblName_MouseHover(sender As Object, e As System.EventArgs) Handles lblName.MouseHover
        lblName.ForeColor = Color.Cyan
    End Sub

    Private Sub lblName_MouseLeave(sender As Object, e As System.EventArgs) Handles lblName.MouseLeave
        lblName.ForeColor = Color.White
    End Sub

    Private Sub lblHighScore_MouseHover(sender As Object, e As System.EventArgs) Handles lblHighScore.MouseHover
        lblHighScore.ForeColor = Color.Red
    End Sub

    Private Sub lblHighScore_MouseLeave(sender As Object, e As System.EventArgs) Handles lblHighScore.MouseLeave
        lblHighScore.ForeColor = Color.White
    End Sub

    'Displays high scores in Form2
    Private Sub lblHighScore_Click(sender As System.Object, e As System.EventArgs) Handles lblHighScore.Click
        If playedGame = False Then 'If a game has never been played, the high scores from all past games are displayed
            Dim counter = 0
            Dim fs1 As New FileStream("High Scores.txt", FileMode.Open, FileAccess.Read)
            Dim textFile1 As New StreamReader(fs1)
            Do While textFile1.Peek > -1 And counter < 11
                stringArray(counter) = textFile1.ReadLine()
                counter += 1
            Loop

            fs1.Close()
            textFile1.Close()

            counter = 0
            Do While counter < 10
                integerArray(counter) = Int(Val(stringArray(counter).Substring(stringArray(counter).IndexOf(" ") + 1)))
                stringArray(counter) = stringArray(counter).Substring(0, stringArray(counter).IndexOf(" "))
                counter += 1
            Loop

            BubbleSort(integerArray, stringArray)

            Dim fs3 As New FileStream("High Scores.txt", FileMode.Create, FileAccess.Write)
            Dim textFile3 As New StreamWriter(fs3)

            counter = 0
            Do While counter < 10
                textFile3.WriteLine(stringArray(counter) & " " & integerArray(counter))
                Form2.txtHighScores.Text &= counter + 1 & ". " & stringArray(counter) & " " & integerArray(counter) & vbCrLf
                counter += 1
            Loop
            textFile3.Close()
            fs3.Close()
        End If
        
        Form2.Visible = True
    End Sub

    'Used to sort the high scores while keeping them in line with the associated name
    Sub BubbleSort(ByRef intArray() As Integer, ByRef strArray() As String)
        Dim temp As Integer
        Dim tempS As String
        Dim swapRequired As Boolean = True

        Do While swapRequired
            swapRequired = False
            For testItem As Integer = 0 To intArray.Length - 2
                If intArray(testItem) < intArray(testItem + 1) Then
                    temp = intArray(testItem)
                    tempS = strArray(testItem)
                    intArray(testItem) = intArray(testItem + 1)
                    strArray(testItem) = strArray(testItem + 1)
                    intArray(testItem + 1) = temp
                    strArray(testItem + 1) = tempS
                    swapRequired = True
                End If
            Next testItem
        Loop
    End Sub

    'Function that returns a random integer
    Function RandomIntNumber(ByVal low As Integer, ByVal high As Integer) As Integer
        Return Int(Rnd() * (high - low) + low)
    End Function

    'Changes score to entered value
    Private Sub lblScore_Click(sender As System.Object, e As System.EventArgs) Handles lblScore.Click
        Try
            score = InputBox("Enter a score")
        Catch ex As Exception
            MessageBox.Show("The score must be an integer")
        End Try
        lblScore.Text = "Score: " & score
    End Sub

    Private Sub lblScore_MouseHover(sender As Object, e As System.EventArgs) Handles lblScore.MouseHover
        lblScore.ForeColor = Color.Red
    End Sub

    Private Sub lblScore_MouseLeave(sender As Object, e As System.EventArgs) Handles lblScore.MouseLeave
        lblScore.ForeColor = Color.White
    End Sub
End Class
