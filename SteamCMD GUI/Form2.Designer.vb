<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.ButtonTwitter = New System.Windows.Forms.Button()
        Me.ButtonSteam = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonTwitter
        '
        Me.ButtonTwitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonTwitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonTwitter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonTwitter.FlatAppearance.BorderSize = 0
        Me.ButtonTwitter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonTwitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonTwitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTwitter.Image = CType(resources.GetObject("ButtonTwitter.Image"), System.Drawing.Image)
        Me.ButtonTwitter.Location = New System.Drawing.Point(159, 50)
        Me.ButtonTwitter.Name = "ButtonTwitter"
        Me.ButtonTwitter.Size = New System.Drawing.Size(33, 33)
        Me.ButtonTwitter.TabIndex = 15
        Me.ButtonTwitter.TabStop = False
        Me.ButtonTwitter.UseVisualStyleBackColor = False
        '
        'ButtonSteam
        '
        Me.ButtonSteam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSteam.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSteam.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.ButtonSteam.FlatAppearance.BorderSize = 0
        Me.ButtonSteam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.ButtonSteam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.ButtonSteam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSteam.Image = CType(resources.GetObject("ButtonSteam.Image"), System.Drawing.Image)
        Me.ButtonSteam.Location = New System.Drawing.Point(120, 50)
        Me.ButtonSteam.Name = "ButtonSteam"
        Me.ButtonSteam.Size = New System.Drawing.Size(33, 33)
        Me.ButtonSteam.TabIndex = 14
        Me.ButtonSteam.TabStop = False
        Me.ButtonSteam.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(222, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "- v1.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(118, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "by Dio Joestar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(121, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(118, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 15)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "SteamCMD GUI"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 100)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(198, 32)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 121)
        Me.Controls.Add(Me.ButtonTwitter)
        Me.Controls.Add(Me.ButtonSteam)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(312, 159)
        Me.MinimumSize = New System.Drawing.Size(312, 159)
        Me.Name = "Form2"
        Me.Text = "SteamCMD GUI"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonTwitter As System.Windows.Forms.Button
    Friend WithEvents ButtonSteam As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
End Class
