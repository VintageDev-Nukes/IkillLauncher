Public Class frmMinecraft

    Friend WithEvents frmMinecraft As System.Windows.Forms.Form

    Dim AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)


    Dim Close_Off As Image = Image.FromFile(".\Art\Buttons\Close_Off.png")
    Dim Close_On As Image = Image.FromFile(".\Art\Buttons\Close_On.png")
    Dim Mini_Off As Image = Image.FromFile(".\Art\Buttons\Mini_Off.png")
    Dim Mini_On As Image = Image.FromFile(".\Art\Buttons\Mini_On.png")
    Dim Fond As Image = Image.FromFile(".\Art\aa.png")
    Dim Patras As Image = Image.FromFile(".\Art\ab.png")
    Dim Fondaco As Image = Image.FromFile(".\Art\fondo.jpg")

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

    Private Sub frmMinecraft_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        picClose.Image = Close_Off
        picMini.Image = Mini_On
        picMini.BackColor = Color.Transparent

        Label1.BackgroundImage = Patras
        Label1.BackColor = Color.Transparent

        Label2.BackgroundImage = Fond
        Label2.BackColor = Color.Transparent
        Label3.BackgroundImage = Fond
        Label3.BackColor = Color.Transparent
        Label4.BackgroundImage = Fond
        Label4.BackColor = Color.Transparent
        Label5.BackgroundImage = Fond
        Label5.BackColor = Color.Transparent
        Label6.BackgroundImage = Fond
        Label6.BackColor = Color.Transparent
        Label7.BackgroundImage = Fond
        Label7.BackColor = Color.Transparent
        Label8.BackgroundImage = Fond
        Label8.BackColor = Color.Transparent
        Label9.BackgroundImage = Fond
        Label9.BackColor = Color.Transparent

        Dim ancho As String = Me.Width
        Dim alto As String = Me.Height

        Dim bm_source As Bitmap = New Bitmap(Fondaco)
        Dim bm_dest As New Bitmap(CInt(ancho), CInt(alto))
        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)
        gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + 1, bm_dest.Height + 1)

        Me.BackgroundImage = bm_dest
        picClose.BackColor = Color.Transparent

            'WebBrowser1.Url = New Uri("file://" & Application.StartupPath & "\Art\fondo.html")
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

    Private Sub frmMinecraft_MouseDown( _
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

    Private Sub frmMinecraft_MouseMove( _
        ByVal sender As Object, _
        ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove

        If mover Then
            ' establecer la nueva posición
            Me.Location = New Point((Me.Left + e.X - x), (Me.Top + e.Y - y))
        End If

    End Sub

    Private Sub frmMinecraft_MouseUp( _
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        frmMain.PictureBox1.Image = Image.FromFile(".\Art\mineb.png")
        frmMain.Show()
        Me.Dispose()
    End Sub

    Private Sub frmMain_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Application.Exit()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        frmModpacks.Show()
        Me.Dispose()
    End Sub
End Class