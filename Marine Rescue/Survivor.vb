﻿Public Class Survivor

    'Attributes

    Public pic_tmp_survivor As PictureBox
    Public dirx, diry As Integer
    Dim vsource_images() As String = {"images\Castaway_F.png", "images\Castaway_M.png"}
    Dim rnd As Random = New Random()

    'Construct
    Public Sub New()

        Console.WriteLine("Instancia de Survivor, realizada correctamente")
        diry = 10
        dirx = 10

    End Sub

    'Methods

    'Generator 
    Public Sub Survivor_Generator(castawaycount)


        'Survivor Properties
        pic_tmp_survivor = New PictureBox()
        pic_tmp_survivor.Size = New Size(50, 50)
        pic_tmp_survivor.Location = New Point(rnd.Next(Marine_Rescue.pan_sea.Width - pic_tmp_survivor.Width - 10), rnd.Next((Marine_Rescue.pan_sea.Height - 150) - pic_tmp_survivor.Height - 35))
        pic_tmp_survivor.Image = Image.FromFile(vsource_images(rnd.Next(0, 2)))
        pic_tmp_survivor.BackColor = System.Drawing.Color.Transparent
        pic_tmp_survivor.SizeMode = PictureBoxSizeMode.StretchImage
        pic_tmp_survivor.Name = "castaway" & castawaycount
        'Add survivor to sea
        Marine_Rescue.pan_sea.Controls.Add(pic_tmp_survivor)

    End Sub

    'Survivor Movement 
    Public Sub Survivor_Movement()

        'Current Coordinate
        Dim x, y As Integer
        x = pic_tmp_survivor.Location.X
        y = pic_tmp_survivor.Location.Y

        'When Survivors go to Up
        If y <= 0 Then

            y = 0
            diry = -diry

        End If

        'When Survivors go to Down
        If y >= Marine_Rescue.pan_sea.Height - pic_tmp_survivor.Height Then

            y = Marine_Rescue.pan_sea.Height - pic_tmp_survivor.Height
            diry = -diry

        End If

        'When Survivors go to Left
        If x <= 0 Then 'Or Marine_Rescue.ship.pic_tmp_cg_ship.Bounds.IntersectsWith(pic_tmp_survivor.Bounds)

            x = 0
            dirx = -dirx

        End If

        'When Survivors go to Right
        If x >= Marine_Rescue.pan_sea.Width - pic_tmp_survivor.Width Then

            x = Marine_Rescue.pan_sea.Width - pic_tmp_survivor.Width
            dirx = -dirx

        End If

        'Survivors Movement
        pic_tmp_survivor.Location = New Point(x + dirx, y + diry)

    End Sub

    'Increment speed force of all Survivors
    Public Sub Suvivor_IncrementSpeed()
        diry += 10
        dirx += 10
    End Sub

    'Principle of action and reaction for all Survivors
    Public Sub Survivor_Rebound()
        dirx = -dirx
        diry = -diry
    End Sub




End Class