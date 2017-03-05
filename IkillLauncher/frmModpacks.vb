Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO

Public Class frmModpacks

    Friend WithEvents frmModpacks As System.Windows.Forms.Form

    Dim AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)

    Private Sub Esperar(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Dim Close_Off As Image = Image.FromFile(".\Art\Buttons\Close_Off.png")
    Dim Close_On As Image = Image.FromFile(".\Art\Buttons\Close_On.png")
    Dim Mini_Off As Image = Image.FromFile(".\Art\Buttons\Mini_Off.png")
    Dim Mini_On As Image = Image.FromFile(".\Art\Buttons\Mini_On.png")
    Dim Fond As Image = Image.FromFile(".\Art\aa.png")
    Dim Patras As Image = Image.FromFile(".\Art\ab.png")
    Dim imgu As Image = Image.FromFile(".\Art\ac.png")
    Dim pano As Image = Image.FromFile(".\Art\af.png")
    Dim Fondaco As Image = Image.FromFile(".\Art\fondo.jpg")
    Dim Scroll_Position As Int32 = 0
    Dim Button_Down_Is_Pressed As Boolean = False
    Dim Button_Up_Is_Pressed As Boolean = False
    Dim SmallChange As Int32 = 10
    Dim Largechange As Int32 = 90
    Dim Maximum As Int64 = 0
    Private Const widaco As Integer = 126 'Tamaño del picbox
    Dim altur As Integer = 77
    Dim WithEvents PicBox As PictureBox
    Dim ruta As String
    Dim xmx As String
    Dim xms As String
    Dim value As String = File.ReadAllText(".\Test.ini")
    Dim cuenta As Integer = Find_String_Occurrences(value, "2ç0k") - 1
    Dim cuenta2 As Integer = Find_String_Occurrences(value, "2ç0k")
    'Dim pcb As PictureBox
    Dim Document As HtmlDocument
    Dim WithEvents web_mod As WebBrowser
    Dim labelestado As Label
    Dim panelestado As Panel
    Dim WithEvents bottonclose As PictureBox
    Dim selectedHtmlElement_ID As String
    Dim selectedHtmlElement_NAME As String
    Dim pcb_() As PictureBox
    Dim deel As Integer
    Private Array_Size As Integer              'The number of PictureBox controls added to Panel container

    Dim _tamañon As Boolean, _size As Long

    Dim url As String = "http://dl.dropboxusercontent.com/s/2iin21gf8g629j9/upt.txt?dl=1"
    Dim texto As String = INI_Manager.Load_Value(".\Test.ini", "AppVer")

    Sub Updatear()
        Updater.Comprobar(url, ".\Temp\", texto)
    End Sub

    Dim WithEvents temer As New System.Windows.Forms.Timer With {.Interval = frmMain.secs, .Enabled = True}

    Private Sub Temer_Start(sender As Object, e As EventArgs) Handles temer.Tick
        Updatear()
    End Sub

    Private Function Find_String_Occurrences(ByVal Input_String As String, ByVal Search_String As String) As Integer

        Dim Input_String_Pos As Int32
        Dim Input_String_Count As Int32

        Do
            Input_String_Pos = Input_String.IndexOf(Search_String, Input_String_Pos)
            If Input_String_Pos <> -1 Then
                Input_String_Count += 1
                Input_String_Pos += Search_String.Length
            End If
        Loop Until Input_String_Pos = -1

        Return Input_String_Count

    End Function

    Private Sub picClose_MouseEnter(sender As Object, e As EventArgs) Handles picClose.MouseEnter
        sender.Image = Close_On
    End Sub

    Private Sub picClose_MouseLeave(sender As Object, e As EventArgs) Handles picClose.MouseLeave
        sender.Image = Close_Off
    End Sub

    Private Sub picClose_Click(sender As Object, e As EventArgs) Handles picClose.Click
        Me.Close()
    End Sub

    Private Sub picClose_Load(sender As Object, e As EventArgs)
        Me.TransparencyKey = BackColor
    End Sub

    Private Const WM_SYSCOMMAND As Integer = &H112&
    Private Const MOUSE_MOVE As Integer = &HF012&

    Private x As Integer
    Private y As Integer
    Private mover As Boolean
    Dim posY As Integer


    Private Sub frmModpacks_MouseDown( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then
            ' habilitar el flag
            mover = True
            ' guardar las coordenadas
            x = e.X
            y = e.Y
        End If
    End Sub

    Private Sub frmModpacks_MouseMove( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        If mover Then
            ' establecer la nueva posición
            Me.Location = New Point((Me.Left + e.X - x), (Me.Top + e.Y - y))
        End If

    End Sub

    Private Sub frmModpacks_MouseUp( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        ' reestablecer
        mover = False
    End Sub

    Private Sub picMini_MouseEnter(sender As Object, e As EventArgs) Handles picMini.MouseEnter
        sender.Image = Mini_Off
    End Sub

    Private Sub picMini_MouseLeave(sender As Object, e As EventArgs) Handles picMini.MouseLeave
        sender.Image = Mini_On
    End Sub

    Private Sub picMini_Click(sender As Object, e As EventArgs) Handles picMini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Timer2.Stop()
        frmMinecraft.Show()
        Me.Dispose()
    End Sub

    'Private Sub PCBCreate(ByVal pcb_num As Integer)
    '    Dim pcb As PictureBox
    '    pcb(pcb_num) = New PictureBox
    '    pcb.BackColor = Color.FromArgb(255, pcb_num * 3, pcb_num * 2, pcb_num)
    '    pcb.Height = 77
    '    pcb.Width = widaco
    '    pcb.Left = 36
    '    pcb.Top = 85 * pcb_num + 15
    '    'pcb.BackgroundImage = Image.FromFile(".\Art\im\" & pcb_num + 1 & ".png")
    '    pcb.Image = Image.FromFile(INI_Manager.Load_Value(".\Test.ini", "FuncImg-" & pcb_num))
    '    pcb.Tag = pcb_num
    '    Dim deel As Integer = Math.Abs(Int(Panel1.AutoScrollPosition.Y.ToString)) / altur
    '    pcb(deel).Width = 200
    '    Me.Controls.Add(pcb)
    '    pcb.Parent = Panel1
    '    AddHandler pcb.Click, AddressOf pcb_Click
    'End Sub

    Private Sub frmModpacks_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        web_mod = New WebBrowser
        web_mod.Navigate("http://ikillcraft.a0001.net/modpacks.php?pass=test")
        web_mod.Height = 300
        web_mod.Width = 395
        web_mod.Top = 150
        web_mod.Left = 177
        web_mod.Visible = False
        web_mod.ScrollBarsEnabled = False
        'AddHandler web_mod.DocumentCompleted, AddressOf WebBrowser_DocumentCompleted
        Me.Controls.Add(web_mod)

        labelestado = New Label
        labelestado.Width = 395
        labelestado.Height = 50
        labelestado.Top = 400
        labelestado.Left = 177
        labelestado.Visible = False
        labelestado.TextAlign = ContentAlignment.MiddleCenter
        Me.Controls.Add(labelestado)

        bottonclose = New PictureBox
        bottonclose.Width = 32
        bottonclose.Height = 32
        bottonclose.Top = 134
        bottonclose.Left = 556
        bottonclose.Image = Image.FromFile(".\Art\CloseButton.png")
        bottonclose.BackColor = Color.Transparent
        bottonclose.Visible = False
        AddHandler bottonclose.Click, AddressOf BottonClose_Click
        AddHandler bottonclose.MouseEnter, AddressOf BottonClose_MouseEnter
        AddHandler bottonclose.MouseLeave, AddressOf BottonClose_MouseLeave
        Me.Controls.Add(bottonclose)

        web_mod.BringToFront()
        bottonclose.BringToFront()
        labelestado.BringToFront()
        Panel1.SendToBack()

        PictureBox2.Image = Image.FromFile(".\Art\arrow_left.png")
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Visible = False
        Label4.BackgroundImage = Image.FromFile(".\Art\buttonparriba.png")
        Label5.BackgroundImage = Image.FromFile(".\Art\buttonpabajo.png")
        Label4.BackColor = Color.Transparent
        Label5.BackColor = Color.Transparent

        'PictureBox3.Image = Image.FromFile(".\Art\separador.png")
        'PictureBox3.BackColor = Color.Transparent

        TextBox1.Text = INI_Manager.Load_Value(".\Test.ini", "FuncNick")

        Panel1.AutoScroll = True
        Maximum = Panel1.VerticalScroll.Maximum
        Panel1.AutoScroll = False
        Panel1.VerticalScroll.Maximum = Maximum * cuenta
        'Panel1.VerticalScroll.Maximum = Maximum * 80
        Timer1.Interval = 50
        Panel1.BackColor = Color.FromArgb(150, 0, 0, 0)

        For Each PicBox As PictureBox In Panel1.Controls
            AddHandler PicBox.MouseHover, AddressOf Panel_MouseHover
        Next

        picClose.Image = Close_Off
        picMini.Image = Mini_On
        picMini.BackColor = Color.Transparent

        Label1.BackgroundImage = Patras
        Label1.BackColor = Color.Transparent

        If Directory.Exists(".\Minecraft\PackMods") = False Then ' si no existe la carpeta se crea
            Directory.CreateDirectory(".\Minecraft\PackMods")
        End If

        If Directory.Exists(".\Temp") = False Then ' si no existe la carpeta se crea
            Directory.CreateDirectory(".\Temp")
        End If

        If Not CheckBox1.Checked Then
            INI_Manager.Set_Value(".\Test.ini", "FuncNick", "")
        Else
            INI_Manager.Set_Value(".\Test.ini", "FuncNick", TextBox1.Text)
        End If

        Label3.BackColor = Color.Transparent 

        If ruta = String.Empty Then
            Label2.Enabled = False
            Label3.Text = "¡Tienes que seleccionar un ModPack " & vbCrLf & " antes de jugar!"
        Else
            Label3.Text = ""
        End If

        PictureBox1.BackgroundImage = imgu
        PictureBox1.BackColor = Color.Transparent
        CheckBox1.BackColor = Color.Transparent
        CheckBox1.BackgroundImage = Image.FromFile(".\Art\ad.png")
        Panel1.BackColor = Color.FromArgb(160, 85, 85, 85)

        TextBox1.AutoSize = False
        TextBox1.Height = 24

        Dim ancho As String = Me.Width
        Dim alto As String = Me.Height

        Dim bm_source As Bitmap = New Bitmap(Fondaco)
        Dim bm_dest As New Bitmap(CInt(ancho), CInt(alto))
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
        gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

        Me.BackgroundImage = bm_dest
        picClose.BackColor = Color.Transparent

        If cuenta2 > 0 Then
            'Dim i As Integer
            'For i = 0 To cuenta
            '    PCBCreate(i)
            'Next i

            Array_Size = cuenta2 'change this for the number of controls that will appear
            ReDim pcb_(Array_Size)

            For pcb_num = 0 To Array_Size
                Application.DoEvents()
                pcb_(pcb_num) = New PictureBox

                With pcb_(pcb_num)
                    .BackColor = Color.FromArgb(255, pcb_num * 3, pcb_num * 2, pcb_num)
                    .Height = 77
                    .Width = widaco
                    .Left = 36
                    .Top = 85 * pcb_num + 15
                    .BackgroundImage = Image.FromFile(".\Art\im\" & pcb_num + 1 & ".png")
                    .Image = Image.FromFile(INI_Manager.Load_Value(".\Test.ini", "FuncImg-" & pcb_num))
                    .Tag = pcb_num
                    'Added the following line to make sure the image correctly fills the PictureBox control for the "zoom" effect
                    .SizeMode = PictureBoxSizeMode.StretchImage
                    Me.Controls.Add(pcb_(pcb_num))
                    .Parent = Panel1
                End With

                AddHandler pcb_(pcb_num).Click, AddressOf pcb_Click
            Next

            deel = 2
            pcb_(deel).Width = 200

            Panel1.Visible = True
            Label4.Visible = True
            Label5.Visible = True
            Label3.Text = ""

        Else

            Panel1.Visible = False
            Label4.Visible = False
            Label5.Visible = False
            Label3.Text = "No tienes ningún ModPack instalado."
            Label3.Left = 147

        End If

        If INI_Manager.Load_Value(".\Test.ini", "Checked") = "check" Then
            CheckBox1.Checked = True
        ElseIf INI_Manager.Load_Value(".\Test.ini", "Checked") = "nocheck" Then
            CheckBox1.Checked = False
        End If

        'Dim totalscroll As Integer = Maximum * ContadorDeArchivos.Count

        'If Panel1.VerticalScroll.Value = totalscroll Then
        '    Label5.Enabled = False
        'End If

        'web_mod.Url = New Uri("file://" & Application.StartupPath & "\Art\fondo.html")
    End Sub

    Private Sub WebBrowser_DocumentCompleted(ByVal sender As System.Object, ByVal e As WebBrowserDocumentCompletedEventArgs) _
Handles web_mod.DocumentCompleted

        Document = sender.Document
        Try : RemoveHandler Document.Click, AddressOf Document_Click : Catch : End Try
        AddHandler Document.Click, New HtmlElementEventHandler(AddressOf Document_Click)

    End Sub

    Private Sub Document_Click(sender As Object, e As HtmlElementEventArgs)

        With web_mod.Document.GetElementFromPoint(e.ClientMousePosition)
            selectedHtmlElement_ID = .GetAttribute("id").ToLower
            selectedHtmlElement_NAME = .GetAttribute("name").ToLower
        End With

        Select Case Document.ActiveElement.Id.ToLower
            Case "global" : prueba()
            Case Else
        End Select

    End Sub

    Private Sub prueba()

        labelestado.Visible = True

        Try

            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            labelestado.Text = "Obteniendo y creando nuevas variables"
            Dim getname As String = selectedHtmlElement_NAME
            Dim prueba1 As String = web_mod.Document.GetElementById(getname & "-nombre").GetAttribute("Value")
            Dim prueba2 As String = web_mod.Document.GetElementById(getname & "-dwl").GetAttribute("Value")
            Dim prueba6 As String = web_mod.Document.GetElementById(getname & "-ver").GetAttribute("Value")
            Dim prueba7 As String = web_mod.Document.GetElementById(getname & "-name").GetAttribute("Value")
            Dim prueba8 As String = web_mod.Document.GetElementById(getname & "-desc").GetAttribute("Value")
            Dim prueba9 As String = web_mod.Document.GetElementById(getname & "-vermc").GetAttribute("Value")
            Dim prueba10 As String = web_mod.Document.GetElementById(getname & "-id").GetAttribute("Value")

            'MsgBox(prueba1)
            'MsgBox(prueba2)
            'MsgBox(prueba6)
            'MsgBox(prueba7)
            'MsgBox(prueba8)
            'MsgBox(prueba9)
            'MsgBox(prueba10)

            labelestado.Text = "Comprando si el archivo Run.bat existe"
            If Not File.Exists(".\Minecraft\PackMods\" & prueba7 & "\run.bat") Then

                labelestado.Text = "Leyendo Ini"
                Dim value As String = File.ReadAllText(".\Test.ini")
                labelestado.Text = "Contando similitudes"
                Dim cuenta As Integer = Find_String_Occurrences(value, "2ç0k")
                labelestado.Text = "Creando variable"
                Dim prueba3 As String = ".\Temp\modpack-" & cuenta & ".zip"

                labelestado.Text = "Comprobado si el archivo existe"
                If File.Exists(prueba3) Then
                    labelestado.Text = "Borrando archivo para evitar conflictos"
                    File.Delete(prueba3)
                End If
                labelestado.Text = "descargando Paquete de Mods: " & prueba1
                My.Computer.Network.DownloadFile(
            prueba2,
            ".\Temp\modpack-" & cuenta & ".zip")

                labelestado.Text = "Extrayendo Paquete de Mods: " & prueba1
                Extraer.Extraer(prueba3, ".\Minecraft\PackMods\" & prueba7 & "\")

                labelestado.Text = "Definiendo variable del Splash"
                Dim prueba4 As String = ".\Minecraft\PackMods\" & prueba7 & "\Splash.png"

                labelestado.Text = "Introduciendo nuevos datos en el INI"
                INI_Manager.Set_Value(".\Test.ini", "Contar" & cuenta, "2ç0k")
                INI_Manager.Set_Value(".\Test.ini", "FuncId-" & cuenta, prueba10)
                INI_Manager.Set_Value(".\Test.ini", "FuncNombre-" & cuenta, prueba1)
                INI_Manager.Set_Value(".\Test.ini", "FuncImg-" & cuenta, prueba4)

                labelestado.Text = "Creando variable"
                Dim prueba5 As String = ".\Minecraft\PackMods\" & prueba7 & "\run.bat"

                labelestado.Text = "Introduciendo nuevos datos en el INI"
                INI_Manager.Set_Value(".\Test.ini", "FuncDir-" & cuenta, prueba5)
                INI_Manager.Set_Value(".\Test.ini", "FuncVer-" & cuenta, prueba6)
                INI_Manager.Set_Value(".\Test.ini", "FuncName-" & cuenta, prueba7)
                INI_Manager.Set_Value(".\Test.ini", "FuncDesc-" & cuenta, prueba8)
                INI_Manager.Set_Value(".\Test.ini", "FuncMcVer-" & cuenta, prueba9)

                labelestado.Text = "Creando variables"
                Dim sRenglon As String = Nothing
                Dim strStreamW As Stream = Nothing
                Dim strStreamWriter As StreamWriter = Nothing
                Dim ContenidoArchivo As String = Nothing
                Dim PathArchivo As String
                Dim ObjItemtot As Integer
                Dim ObjItemtot2 As Integer

                Try

                    PathArchivo = prueba5
                    labelestado.Text = "Comprobando si el archivo existe"
                    If File.Exists(PathArchivo) Then
                        labelestado.Text = "Abriendo el archivo"
                        strStreamW = File.Open(PathArchivo, FileMode.Open)
                    Else
                        labelestado.Text = "Creando archivo"
                        strStreamW = File.Create(PathArchivo)
                    End If

                    labelestado.Text = "Definiendo variable"
                    Dim ObjItem As String
                    labelestado.Text = "Obteniendo Memoria RAM disponible"
                    ObjItem = Int(((My.Computer.Info.TotalPhysicalMemory) / 1048576))

                    labelestado.Text = "Definiendo tope de Memoria RAM a usar"
                    ObjItemtot = ObjItem / 3

                    ObjItemtot2 = ObjItem / 4

                    labelestado.Text = "Editando archivo"
                    strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                    labelestado.Text = "Introduciendo líneas de texto dentro del archivo"
                    strStreamWriter.WriteLine("@echo off")
                    strStreamWriter.WriteLine("set APPDATA=" & Application.StartupPath & "\Minecraft\PackMods\" & prueba7)
                    strStreamWriter.WriteLine("java  -Xincgc -Xmx%1m -Xms%2m -cp ""%APPDATA%\.minecraft\bin\minecraft.jar;%APPDATA%\.minecraft\bin\lwjgl.jar;%APPDATA%\.minecraft\bin\lwjgl_util.jar;%APPDATA%\.minecraft\bin\jinput.jar"" -Djava.library.path=""%APPDATA%\.minecraft\bin\natives"" net.minecraft.client.Minecraft %3")
                    strStreamWriter.WriteLine("break")

                    labelestado.Text = "Cerrando el editor"
                    strStreamWriter.Close()

                Catch ex As Exception
                    MsgBox("Error al Guardar la ingormacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                    strStreamWriter.Close()
                End Try

                labelestado.Text = "Introduciendo nuevos datos en el INI"
                INI_Manager.Set_Value(".\Test.ini", "Xmx-" & cuenta, ObjItemtot2)
                INI_Manager.Set_Value(".\Test.ini", "Xms-" & cuenta, ObjItemtot)

                labelestado.Text = "Borrando archivos temporales"
                File.Delete(prueba3)

                labelestado.Text = "¡" & prueba1 & " ha sido instalado correctamente!" & vbCrLf & "Muchas gracias por usar IkillLauncher"
                MsgBox("Debe reiniciar la app para que los cambios surtan efecto." & vbCrLf & "Pulse el botón ""Aceptar"" para continuar.")
                Application.Restart()
            Else
                MsgBox("Este ModPack ya lo tienes instalado!")
            End If


        Catch ex As Exception
            MsgBox(ex.Message & ex.ToString)
        End Try

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub pcb_Click(ByVal sender As Object, _
ByVal e As EventArgs)
        Dim pcb_num As Integer
        If CType(sender, PictureBox).Tag IsNot Nothing Then
            ' Check that button's Tag property contains a valid integer
            If Integer.TryParse(CType(sender, PictureBox).Tag.ToString, pcb_num) Then
                ' Now we have a valid button number to be used
                ruta = INI_Manager.Load_Value(".\Test.ini", "FuncDir-" & pcb_num)
                xmx = INI_Manager.Load_Value(".\Test.ini", "Xmx-" & pcb_num)
                xms = INI_Manager.Load_Value(".\Test.ini", "Xms-" & pcb_num)
                Dim nametron As String = INI_Manager.Load_Value(".\Test.ini", "FuncNombre-" & pcb_num)
                'Label2.Enabled = True
                Label3.Text = "Has seleccionado " & nametron
                Timer2.Start()
            End If
        End If

        'Shell("java -Xincgc -Xmx1024m -cp ""%appdata%\.likesoft\launcher\.minecraft\bin\minecraft.jar;%appdata%\.likesoft\launcher\.minecraft\bin\lwjgl.jar;%appdata%\.likesoft\launcher\.minecraft\bin\lwjgl_util.jar;%appdata%\.likesoft\launcher\.minecraft\bin\jinput.jar"" -Djava.library.path=""%appdata%\.likesoft\launcher\.minecraft\bin\natives"" net.minecraft.client.Minecraft " & TextBox1.Text, AppWinStyle.Hide)
    End Sub

    Private Sub Panel_MouseHover(sender As Object, e As EventArgs) Handles Panel1.MouseHover
        sender.select()
        sender.focus()
    End Sub

    'Private Sub pcb_ClickHandles(ByVal sender As Object, _
    '    ByVal e As EventArgs) _
    '    Handles PicBox.Click
    '    'MessageBox.Show("pcb_ClickHandles method", "Events Demonstration")
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)
        If Button_Down_Is_Pressed Then
            Scroll_Down(SmallChange)
        ElseIf Button_Up_Is_Pressed Then
            Scroll_Up(SmallChange)
        Else
            sender.stop()
        End If
    End Sub

    Private Sub Panel1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Panel1.Scroll
        For pcb_num = 0 To Array_Size
            'A 0 value for the Top property of each PictureBox control indicates it is at the top of Panel1.
            'As soon as the PictureBox scrolls above the top of Panel1, we want to zoom in on the next PictureBox.
            If pcb_(pcb_num).Top >= 0 Then
                altur = pcb_num + 2
                Exit For
            End If
        Next pcb_num

        pcb_(deel).Width = widaco
        pcb_(altur).width = 200
        deel = altur
    End Sub

    Private Sub Scroll_Up(ByVal Change As Int32)
        Scroll_Position -= Change
        Try
            Panel1.VerticalScroll.Value = Scroll_Position
        Catch
            Scroll_Position = 0
        End Try
    End Sub

    Private Sub Scroll_Down(ByVal Change As Int32)
        Scroll_Position += Change
        Try
            Panel1.VerticalScroll.Value = Scroll_Position
        Catch
            Scroll_Position -= Change
        End Try
    End Sub

    Private Sub Button_Down_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Button_Down_Is_Pressed = True
            Timer1.Start()
        End If
    End Sub

    Private Sub Button_Up_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Button_Up_Is_Pressed = True
            Timer1.Start()
        End If
    End Sub

    Private Sub Button_Down_MouseUp(sender As Object, e As MouseEventArgs)
        Button_Down_Is_Pressed = False
    End Sub

    Private Sub Button_Up_MouseUp(sender As Object, e As MouseEventArgs)
        Button_Up_Is_Pressed = False
    End Sub

    Private Sub Form_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Panel1.MouseWheel
        Select Case Math.Sign(e.Delta)
            Case Is > 0 : Scroll_Up(Largechange)
            Case Is < 0 : Scroll_Down(Largechange)
        End Select
    End Sub



    ' Versión alternativa:
    Dim PictureBoxes_Height As Int64 = altur ' La altura de cada picturebox

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Scroll_Position -= PictureBoxes_Height
        Try
            Panel1.VerticalScroll.Value = Scroll_Position
        Catch
            Panel1.VerticalScroll.Value = 1
            Scroll_Position += PictureBoxes_Height
        End Try
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Scroll_Position += PictureBoxes_Height
        Try
            Panel1.VerticalScroll.Value = Scroll_Position
        Catch

            Scroll_Position -= PictureBoxes_Height
        End Try
    End Sub
    ' Fin de versión alternativa

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        web_mod.Visible = True
        bottonclose.Visible = True
        web_mod.Navigate("http://ikillcraft.a0001.net/modpacks.php?pass=test")
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim pi As New ProcessStartInfo
        Dim p As New Process
        pi.FileName = ruta
        pi.Arguments = "" & xmx & " " & xms & " " & TextBox1.Text & ""
        'pi.WindowStyle = ProcessWindowStyle.Hidden
        p.StartInfo = pi
        p.Start()
        If ruta = Nothing Then
            MsgBox("Me parece que se te olvida algo. ;)")
        End If
        'Process.Start(ruta)
        'Shell(ruta, AppWinStyle.Hide)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        INI_Manager.Set_Value(".\Test.ini", "FuncNick", TextBox1.Text)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If TextBox1.Text = "" Then
            Label2.Enabled = False
        Else
            Label2.Enabled = True
        End If

        If CheckBox1.Checked Then
            INI_Manager.Set_Value(".\Test.ini", "Checked", "check")
        Else
            INI_Manager.Set_Value(".\Test.ini", "Checked", "nocheck")
        End If
    End Sub

    Private Sub BottonClose_MouseEnter(sender As Object, e As EventArgs) Handles bottonclose.MouseEnter
        bottonclose.Image = Image.FromFile(".\Art\CloseButton2.png")
    End Sub

    Private Sub BottonClose_MouseLeave(sender As Object, e As EventArgs) Handles bottonclose.MouseLeave
        bottonclose.Image = Image.FromFile(".\Art\CloseButton.png")
    End Sub

    Private Sub BottonClose_Click(sender As Object, e As EventArgs) Handles bottonclose.Click
        Esperar(1)
        bottonclose.Image = Image.FromFile(".\Art\CloseButton3.png")
        Esperar(100)
        bottonclose.Visible = False
        labelestado.Visible = False
        web_mod.Visible = False
    End Sub

    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    deel = Math.Abs(Int(Panel1.AutoScrollPosition.Y.ToString)) \ altur + 2
    '    MsgBox(deel)
    'End Sub
End Class