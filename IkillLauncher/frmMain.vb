Imports System
Imports System.Windows.Forms
Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Diagnostics
Imports System.Threading

Public Class frmMain

    Friend WithEvents frmMain As System.Windows.Forms.Form

    Dim AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)


    Dim Close_Off As Image = Image.FromFile(".\Art\Buttons\Close_Off.png")
    Dim Close_On As Image = Image.FromFile(".\Art\Buttons\Close_On.png")
    Dim Mini_Off As Image = Image.FromFile(".\Art\Buttons\Mini_Off.png")
    Dim Mini_On As Image = Image.FromFile(".\Art\Buttons\Mini_On.png")
    Dim Fondaco As Image = Image.FromFile(".\Art\fondo.jpg")
    Public Shared secs As Integer = 60000
    Dim texto As String
    'Dim credits As TextBox
    Dim credits As WebBrowser
    Dim WithEvents bottonclose As PictureBox
    Dim report As WebBrowser
    Dim WithEvents bottonclose2 As PictureBox

    Dim _tamañon As Boolean, _size As Long

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        frmSplash.ShowDialog()
        picClose.Image = Close_Off
        picMini.Image = Mini_On

        Dim File2 As String = ".\Test.ini"



        If Not File.Exists(File2) Then
            '            My.Computer.Network.DownloadFile(
            '"http://dl.dropboxusercontent.com/s/xsbmerfxsmf12af/Test.ini?dl=1",
            'File2)


            Dim sRenglon As String = Nothing
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Dim ContenidoArchivo As String = Nothing
            Dim PathArchivo As String

            PathArchivo = File2
            If File.Exists(PathArchivo) Then
                strStreamW = File.Open(PathArchivo, FileMode.Open)
            Else
                strStreamW = File.Create(PathArchivo)
            End If

            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

            strStreamWriter.WriteLine("FuncNick=")
            strStreamWriter.WriteLine("AppVer=1")
            strStreamWriter.WriteLine("Checked=nocheck")

            strStreamWriter.Close()
            'Esperar(50)
            'INI_Manager.Set_Value(".\Test.ini", "FuncNick", "")

        Else
            texto = INI_Manager.Load_Value(".\Test.ini", "AppVer")
            Updatear()
        End If

        Dim ancho As String = Me.Width
        Dim alto As String = Me.Height

        Dim bm_source As Bitmap = New Bitmap(Fondaco)
        Dim bm_dest As New Bitmap(CInt(ancho), CInt(alto))
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
        gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)
        Me.BackgroundImage = bm_dest

        PictureBox1.Image = Image.FromFile(".\Art\mineb.png")
        PictureBox2.Image = Image.FromFile(".\Art\terrab.png")
        PictureBox7.Image = Image.FromFile(".\Art\splash2.png")
        PictureBox8.Image = Image.FromFile(".\Art\barra1.png")
        PictureBox9.Image = Image.FromFile(".\Art\barra2.png")
        PictureBox10.Image = Image.FromFile(".\Art\juegos.png")
        PictureBox1.BackColor = Color.Transparent
        PictureBox2.BackColor = Color.Transparent
        PictureBox7.BackColor = Color.Transparent
        PictureBox8.BackColor = Color.Transparent
        PictureBox9.BackColor = Color.Transparent
        PictureBox10.BackColor = Color.Transparent
        picClose.BackColor = Color.Transparent
        picMini.BackColor = Color.Transparent

        Label1.BackgroundImage = Image.FromFile(".\Art\button.png")
        Label2.BackgroundImage = Image.FromFile(".\Art\button.png")
        Label3.BackgroundImage = Image.FromFile(".\Art\button.png")
        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label3.BackColor = Color.Transparent

        PictureBox8.Enabled = False
        PictureBox9.Enabled = False

        If PictureBox8.Enabled = False Then
            PictureBox8.Image = Image.FromFile(".\Art\barra1d.png")
        End If

        If PictureBox9.Enabled = False Then
            PictureBox9.Image = Image.FromFile(".\Art\barra2d.png")
        End If

        'credits = New TextBox
        credits = New WebBrowser
        credits.Width = 375
        credits.Height = 300
        credits.Top = 150
        credits.Left = 187
        'credits.Text = "caca culo pedo pis" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh" & vbCrLf & "ajhdsdjwh2"
        credits.Visible = False
        'credits.Multiline = True
        'credits.ReadOnly = True
        'credits.TextAlign = HorizontalAlignment.Center
        credits.ScrollBarsEnabled = False
        credits.Url = New Uri("http://ikillcraft.a0001.net/credits.php?pass=test")
        Me.Controls.Add(credits)

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

        credits.BringToFront()
        bottonclose.BringToFront()

        report = New WebBrowser
        report.Width = 580
        report.Height = 300
        report.Top = 150
        report.Left = 85
        report.Visible = False
        'report.ScrollBarsEnabled = False
        report.Url = New Uri("http://ikillcraft.a0001.net/bug-report.php?pass=test")
        Me.Controls.Add(report)

        bottonclose2 = New PictureBox
        bottonclose2.Width = 32
        bottonclose2.Height = 32
        bottonclose2.Top = 134
        bottonclose2.Left = 649
        bottonclose2.Image = Image.FromFile(".\Art\CloseButton.png")
        bottonclose2.BackColor = Color.Transparent
        bottonclose2.Visible = False
        AddHandler bottonclose2.Click, AddressOf BottonClose_Click2
        AddHandler bottonclose2.MouseEnter, AddressOf BottonClose_MouseEnter2
        AddHandler bottonclose2.MouseLeave, AddressOf BottonClose_MouseLeave2
        Me.Controls.Add(bottonclose2)

        report.BringToFront()
        bottonclose2.BringToFront()

        Label4.BackgroundImage = Image.FromFile(".\Art\button1.png")
        Label4.BackColor = Color.Transparent
        'Label5.BackColor = Color.Transparent

        'credits.SelectionStart = credits.Text.Length
        'credits.ScrollToCaret()

        'WebBrowser1.Url = New Uri("file://" & Application.StartupPath & "\Art\fondo.html")
    End Sub

    Private Sub BottonClose_Click(sender As Object, e As EventArgs) Handles bottonclose.Click
        Esperar(1)
        bottonclose.Image = Image.FromFile(".\Art\CloseButton3.png")
        Esperar(100)
        bottonclose.Visible = False
        credits.Visible = False
    End Sub

    Private Sub BottonClose_MouseEnter2(sender As Object, e As EventArgs) Handles bottonclose2.MouseEnter
        bottonclose.Image = Image.FromFile(".\Art\CloseButton2.png")
    End Sub

    Private Sub BottonClose_MouseLeave2(sender As Object, e As EventArgs) Handles bottonclose2.MouseLeave
        bottonclose.Image = Image.FromFile(".\Art\CloseButton.png")
    End Sub

    Private Sub BottonClose_Click2(sender As Object, e As EventArgs) Handles bottonclose2.Click
        Esperar(1)
        bottonclose2.Image = Image.FromFile(".\Art\CloseButton3.png")
        Esperar(100)
        bottonclose2.Visible = False
        report.Visible = False
    End Sub

    Private Sub BottonClose_MouseEnter(sender As Object, e As EventArgs) Handles bottonclose.MouseEnter
        bottonclose2.Image = Image.FromFile(".\Art\CloseButton2.png")
    End Sub

    Private Sub BottonClose_MouseLeave(sender As Object, e As EventArgs) Handles bottonclose.MouseLeave
        bottonclose2.Image = Image.FromFile(".\Art\CloseButton.png")
    End Sub

    Dim url As String = "http://dl.dropboxusercontent.com/s/2iin21gf8g629j9/upt.txt?dl=1"

    Sub Updatear()
        Updater.Comprobar(url, ".\Temp\", texto)
    End Sub

    Dim WithEvents temer As New System.Windows.Forms.Timer With {.Interval = secs, .Enabled = True}

    Private Sub Temer_Start(sender As Object, e As EventArgs) Handles temer.Tick
        Updatear()
    End Sub

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

    Private Sub frmMain_MouseDown( _
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

    Private Sub frmMain_MouseMove( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        If mover Then
            ' establecer la nueva posición
            Me.Location = New Point((Me.Left + e.X - x), (Me.Top + e.Y - y))
        End If

    End Sub

    Private Sub frmMain_MouseUp( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        ' reestablecer
        mover = False
    End Sub

    Private Sub Esperar(ByVal interval As Integer)
        Dim sw As New Stopwatch
        sw.Start()
        Do While sw.ElapsedMilliseconds < interval
            ' Allows UI to remain responsive
            Application.DoEvents()
        Loop
        sw.Stop()
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Esperar(1)
        PictureBox1.Image = Image.FromFile(".\Art\mineb2.png")
        Esperar(100)
        frmMinecraft.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        'PictureBox2.Image = Image.FromFile(".\Art\terrab2.png")
        MsgBox("Esta opción está aún en desarrollo.")
    End Sub

    'Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
    '    frmTerraria.Show()
    '    Me.Hide()
    'End Sub

    Private Sub picMini_MouseEnter(sender As Object, e As EventArgs) Handles picMini.MouseEnter
        sender.Image = Mini_Off
    End Sub

    Private Sub picMini_MouseLeave(sender As Object, e As EventArgs) Handles picMini.MouseLeave
        sender.Image = Mini_On
    End Sub

    Private Sub picMini_Click(sender As Object, e As EventArgs) Handles picMini.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Esperar(1)
        Label3.BackgroundImage = Image.FromFile(".\Art\buttond.png")
        Esperar(100)
        AboutBox1.Show()
        Esperar(125)
        Label3.BackgroundImage = Image.FromFile(".\Art\button.png")
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Esperar(1)
        Label3.BackgroundImage = Image.FromFile(".\Art\buttond.png")
        Esperar(100)
        credits.Visible = True
        bottonclose.Visible = True
        Esperar(125)
        Label3.BackgroundImage = Image.FromFile(".\Art\button.png")
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        MsgBox("Esta opción está aún en desarrollo.")
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Esperar(1)
        report.Url = New Uri("http://ikillcraft.a0001.net/bug-report.php?pass=test")
        Label4.BackgroundImage = Image.FromFile(".\Art\button1d.png")
        Esperar(100)
        report.Visible = True
        bottonclose2.Visible = True
        Esperar(125)
        Label4.BackgroundImage = Image.FromFile(".\Art\button1.png")
    End Sub
End Class