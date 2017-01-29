<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.paddlePlayer = New System.Windows.Forms.Label()
        Me.paddleAI = New System.Windows.Forms.Label()
        Me.goalPlayer = New System.Windows.Forms.Label()
        Me.goalAI = New System.Windows.Forms.Label()
        Me.barrierTop = New System.Windows.Forms.Label()
        Me.barrierBottom = New System.Windows.Forms.Label()
        Me.ball = New System.Windows.Forms.Label()
        Me.tmrMovePaddle = New System.Windows.Forms.Timer(Me.components)
        Me.lblGo = New System.Windows.Forms.Label()
        Me.tmrBall = New System.Windows.Forms.Timer(Me.components)
        Me.tmrAI = New System.Windows.Forms.Timer(Me.components)
        Me.lblScore = New System.Windows.Forms.Label()
        Me.lblLives = New System.Windows.Forms.Label()
        Me.lblNewGame = New System.Windows.Forms.Label()
        Me.lblExit = New System.Windows.Forms.Label()
        Me.lblCustomize = New System.Windows.Forms.Label()
        Me.clrCustomize = New System.Windows.Forms.ColorDialog()
        Me.tmrCustomize = New System.Windows.Forms.Timer(Me.components)
        Me.lblCustomPrompt = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblHighScore = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'paddlePlayer
        '
        Me.paddlePlayer.BackColor = System.Drawing.Color.White
        Me.paddlePlayer.Location = New System.Drawing.Point(50, 159)
        Me.paddlePlayer.Name = "paddlePlayer"
        Me.paddlePlayer.Size = New System.Drawing.Size(5, 50)
        Me.paddlePlayer.TabIndex = 0
        '
        'paddleAI
        '
        Me.paddleAI.BackColor = System.Drawing.Color.White
        Me.paddleAI.Location = New System.Drawing.Point(729, 159)
        Me.paddleAI.Name = "paddleAI"
        Me.paddleAI.Size = New System.Drawing.Size(5, 50)
        Me.paddleAI.TabIndex = 1
        '
        'goalPlayer
        '
        Me.goalPlayer.BackColor = System.Drawing.Color.Red
        Me.goalPlayer.Location = New System.Drawing.Point(25, 9)
        Me.goalPlayer.Name = "goalPlayer"
        Me.goalPlayer.Size = New System.Drawing.Size(5, 367)
        Me.goalPlayer.TabIndex = 2
        Me.goalPlayer.Text = "Label2"
        '
        'goalAI
        '
        Me.goalAI.BackColor = System.Drawing.Color.Lime
        Me.goalAI.Location = New System.Drawing.Point(754, 9)
        Me.goalAI.Name = "goalAI"
        Me.goalAI.Size = New System.Drawing.Size(5, 367)
        Me.goalAI.TabIndex = 4
        Me.goalAI.Text = "Label2"
        '
        'barrierTop
        '
        Me.barrierTop.BackColor = System.Drawing.Color.White
        Me.barrierTop.Location = New System.Drawing.Point(25, 4)
        Me.barrierTop.Name = "barrierTop"
        Me.barrierTop.Size = New System.Drawing.Size(734, 5)
        Me.barrierTop.TabIndex = 5
        '
        'barrierBottom
        '
        Me.barrierBottom.BackColor = System.Drawing.Color.White
        Me.barrierBottom.Location = New System.Drawing.Point(25, 371)
        Me.barrierBottom.Name = "barrierBottom"
        Me.barrierBottom.Size = New System.Drawing.Size(734, 5)
        Me.barrierBottom.TabIndex = 6
        '
        'ball
        '
        Me.ball.BackColor = System.Drawing.Color.White
        Me.ball.Location = New System.Drawing.Point(382, 182)
        Me.ball.Name = "ball"
        Me.ball.Size = New System.Drawing.Size(10, 10)
        Me.ball.TabIndex = 7
        '
        'tmrMovePaddle
        '
        Me.tmrMovePaddle.Interval = 30
        '
        'lblGo
        '
        Me.lblGo.AutoSize = True
        Me.lblGo.BackColor = System.Drawing.Color.Black
        Me.lblGo.Font = New System.Drawing.Font("Courier New", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGo.ForeColor = System.Drawing.Color.White
        Me.lblGo.Location = New System.Drawing.Point(358, 66)
        Me.lblGo.Name = "lblGo"
        Me.lblGo.Size = New System.Drawing.Size(59, 40)
        Me.lblGo.TabIndex = 8
        Me.lblGo.Text = "Go"
        '
        'tmrBall
        '
        Me.tmrBall.Interval = 35
        '
        'tmrAI
        '
        Me.tmrAI.Interval = 30
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.ForeColor = System.Drawing.Color.White
        Me.lblScore.Location = New System.Drawing.Point(25, 399)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(72, 16)
        Me.lblScore.TabIndex = 9
        Me.lblScore.Text = "Score: 0"
        '
        'lblLives
        '
        Me.lblLives.AutoSize = True
        Me.lblLives.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLives.ForeColor = System.Drawing.Color.White
        Me.lblLives.Location = New System.Drawing.Point(25, 428)
        Me.lblLives.Name = "lblLives"
        Me.lblLives.Size = New System.Drawing.Size(72, 16)
        Me.lblLives.TabIndex = 10
        Me.lblLives.Text = "Lives: 3"
        '
        'lblNewGame
        '
        Me.lblNewGame.AutoSize = True
        Me.lblNewGame.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewGame.ForeColor = System.Drawing.Color.White
        Me.lblNewGame.Location = New System.Drawing.Point(649, 399)
        Me.lblNewGame.Name = "lblNewGame"
        Me.lblNewGame.Size = New System.Drawing.Size(72, 16)
        Me.lblNewGame.TabIndex = 11
        Me.lblNewGame.Text = "New Game"
        '
        'lblExit
        '
        Me.lblExit.AutoSize = True
        Me.lblExit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExit.ForeColor = System.Drawing.Color.White
        Me.lblExit.Location = New System.Drawing.Point(649, 428)
        Me.lblExit.Name = "lblExit"
        Me.lblExit.Size = New System.Drawing.Size(40, 16)
        Me.lblExit.TabIndex = 12
        Me.lblExit.Text = "Exit"
        '
        'lblCustomize
        '
        Me.lblCustomize.AutoSize = True
        Me.lblCustomize.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomize.ForeColor = System.Drawing.Color.White
        Me.lblCustomize.Location = New System.Drawing.Point(337, 428)
        Me.lblCustomize.Name = "lblCustomize"
        Me.lblCustomize.Size = New System.Drawing.Size(80, 16)
        Me.lblCustomize.TabIndex = 13
        Me.lblCustomize.Text = "Customize"
        '
        'tmrCustomize
        '
        Me.tmrCustomize.Interval = 500
        '
        'lblCustomPrompt
        '
        Me.lblCustomPrompt.AutoSize = True
        Me.lblCustomPrompt.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCustomPrompt.ForeColor = System.Drawing.Color.Black
        Me.lblCustomPrompt.Location = New System.Drawing.Point(254, 444)
        Me.lblCustomPrompt.Name = "lblCustomPrompt"
        Me.lblCustomPrompt.Size = New System.Drawing.Size(256, 16)
        Me.lblCustomPrompt.TabIndex = 14
        Me.lblCustomPrompt.Text = "Change the color of your paddle"
        '
        'lblName
        '
        Me.lblName.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.White
        Me.lblName.Location = New System.Drawing.Point(305, 460)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(141, 23)
        Me.lblName.TabIndex = 15
        Me.lblName.Text = "Player"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHighScore
        '
        Me.lblHighScore.AutoSize = True
        Me.lblHighScore.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHighScore.ForeColor = System.Drawing.Color.White
        Me.lblHighScore.Location = New System.Drawing.Point(333, 399)
        Me.lblHighScore.Name = "lblHighScore"
        Me.lblHighScore.Size = New System.Drawing.Size(88, 16)
        Me.lblHighScore.TabIndex = 16
        Me.lblHighScore.Text = "High Score"
        Me.lblHighScore.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(784, 487)
        Me.Controls.Add(Me.lblHighScore)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblCustomPrompt)
        Me.Controls.Add(Me.lblCustomize)
        Me.Controls.Add(Me.lblExit)
        Me.Controls.Add(Me.lblNewGame)
        Me.Controls.Add(Me.lblLives)
        Me.Controls.Add(Me.lblScore)
        Me.Controls.Add(Me.lblGo)
        Me.Controls.Add(Me.ball)
        Me.Controls.Add(Me.barrierBottom)
        Me.Controls.Add(Me.barrierTop)
        Me.Controls.Add(Me.goalAI)
        Me.Controls.Add(Me.goalPlayer)
        Me.Controls.Add(Me.paddleAI)
        Me.Controls.Add(Me.paddlePlayer)
        Me.Name = "Form1"
        Me.Text = "Pong"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents paddlePlayer As System.Windows.Forms.Label
    Friend WithEvents paddleAI As System.Windows.Forms.Label
    Friend WithEvents goalPlayer As System.Windows.Forms.Label
    Friend WithEvents goalAI As System.Windows.Forms.Label
    Friend WithEvents barrierTop As System.Windows.Forms.Label
    Friend WithEvents barrierBottom As System.Windows.Forms.Label
    Friend WithEvents ball As System.Windows.Forms.Label
    Friend WithEvents tmrMovePaddle As System.Windows.Forms.Timer
    Friend WithEvents lblGo As System.Windows.Forms.Label
    Friend WithEvents tmrBall As System.Windows.Forms.Timer
    Friend WithEvents tmrAI As System.Windows.Forms.Timer
    Friend WithEvents lblScore As System.Windows.Forms.Label
    Friend WithEvents lblLives As System.Windows.Forms.Label
    Friend WithEvents lblNewGame As System.Windows.Forms.Label
    Friend WithEvents lblExit As System.Windows.Forms.Label
    Friend WithEvents lblCustomize As System.Windows.Forms.Label
    Friend WithEvents clrCustomize As System.Windows.Forms.ColorDialog
    Friend WithEvents tmrCustomize As System.Windows.Forms.Timer
    Friend WithEvents lblCustomPrompt As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblHighScore As System.Windows.Forms.Label

End Class
