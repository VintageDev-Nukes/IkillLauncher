Imports System
Imports System.IO
Imports System.Collections
Imports Ionic.Zip

Public Class frmModPacks_Web

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


    Private Sub frmModpacks_Web_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Visible = False
        Label1.Visible = False
        WebBrowser1.Navigate("http://ikillcraft.a0001.net/modpacks.php?pass=test")
    End Sub

    Dim Document As HtmlDocument

    Private Sub WebBrowser_DocumentCompleted(ByVal sender As System.Object, ByVal e As WebBrowserDocumentCompletedEventArgs) _
    Handles WebBrowser1.DocumentCompleted

        Document = sender.Document
        AddHandler Document.Click, New HtmlElementEventHandler(AddressOf Document_Click)

    End Sub

    Private Sub Document_Click(sender As Object, e As HtmlElementEventArgs)

        Select Case Document.ActiveElement.Id.ToLower
            Case "global" : prueba()
            Case Else
        End Select

    End Sub

    Sub prueba()

        Try

            Panel1.Visible = True
            Label1.Visible = True

            With Label1

                Windows.Forms.Cursor.Current = Cursors.WaitCursor

                .Text = "Obteniendo y creando nuevas variables"
                Dim getname As String = WebBrowser1.Document.GetElementById("formu").GetAttribute("Name")
                Dim prueba1 As String = WebBrowser1.Document.GetElementById(getname & "-nombre").GetAttribute("Value")
                Dim prueba2 As String = WebBrowser1.Document.GetElementById(getname & "-dwl").GetAttribute("Value")
                Dim prueba6 As String = WebBrowser1.Document.GetElementById(getname & "-ver").GetAttribute("Value")
                Dim prueba7 As String = WebBrowser1.Document.GetElementById(getname & "-name").GetAttribute("Value")
                Dim prueba8 As String = WebBrowser1.Document.GetElementById(getname & "-desc").GetAttribute("Value")
                Dim prueba9 As String = WebBrowser1.Document.GetElementById(getname & "-vermc").GetAttribute("Value")
                Dim prueba10 As String = WebBrowser1.Document.GetElementById(getname & "-id").GetAttribute("Value")

                .Text = "Comprando si el archivo Run.bat existe"
                If Not File.Exists(".\Modpacks\" & prueba1 & "\run.bat") Then

                    .Text = "Leyendo Ini"
                    Dim value As String = File.ReadAllText(".\Test.ini")
                    .Text = "Contando similitudes"
                    Dim cuenta As Integer = Find_String_Occurrences(value, "2ç0k")
                    .Text = "Creando variable"
                    Dim prueba3 As String = ".\Temp\modpack-" & cuenta & ".zip"

                    .Text = "Comprobado si el archivo existe"
                    If File.Exists(prueba3) Then
                        .Text = "Borrando archivo para evitar conflictos"
                        File.Delete(prueba3)
                    End If
                    .Text = "descargando Paquete de Mods: " & prueba1
                    My.Computer.Network.DownloadFile(
                prueba2,
                ".\Temp\modpack-" & cuenta & ".zip")

                    .Text = "Extrayendo Paquete de Mods: " & prueba1
                    Extraer.Extraer(prueba3, ".\Minecraft\PackMods\" & prueba1 & "\")

                    .Text = "Definiendo variable del Splash"
                    Dim prueba4 As String = ".\Minecraft\PackMods\" & prueba1 & "\Splash.png"

                    .Text = "Introduciendo nuevos datos en el INI"
                    INI_Manager.Set_Value(".\Test.ini", "Contar" & cuenta, "2ç0k")
                    INI_Manager.Set_Value(".\Test.ini", "FuncId-" & cuenta, prueba10)
                    INI_Manager.Set_Value(".\Test.ini", "FuncNombre-" & cuenta, prueba1)
                    INI_Manager.Set_Value(".\Test.ini", "FuncImg-" & cuenta, prueba4)

                    .Text = "Creando variable"
                    Dim prueba5 As String = ".\Minecraft\PackMods\" & prueba1 & "\run.bat"

                    .Text = "Introduciendo nuevos datos en el INI"
                    INI_Manager.Set_Value(".\Test.ini", "FuncDir-" & cuenta, prueba5)
                    INI_Manager.Set_Value(".\Test.ini", "FuncVer-" & cuenta, prueba6)
                    INI_Manager.Set_Value(".\Test.ini", "FuncName-" & cuenta, prueba7)
                    INI_Manager.Set_Value(".\Test.ini", "FuncDesc-" & cuenta, prueba8)
                    INI_Manager.Set_Value(".\Test.ini", "FuncMcVer-" & cuenta, prueba9)

                    .Text = "Creando variables"
                    Dim sRenglon As String = Nothing
                    Dim strStreamW As Stream = Nothing
                    Dim strStreamWriter As StreamWriter = Nothing
                    Dim ContenidoArchivo As String = Nothing
                    Dim PathArchivo As String
                    Dim ObjItemtot As Integer
                    Dim ObjItemtot2 As Integer

                    Try

                        PathArchivo = prueba5
                        .Text = "Comprobando si el archivo existe"
                        If File.Exists(PathArchivo) Then
                            .Text = "Abriendo el archivo"
                            strStreamW = File.Open(PathArchivo, FileMode.Open)
                        Else
                            .Text = "Creando archivo"
                            strStreamW = File.Create(PathArchivo)
                        End If

                        .Text = "Definiendo variable"
                        Dim ObjItem As String
                        .Text = "Obteniendo Memoria RAM disponible"
                        ObjItem = Int(((My.Computer.Info.TotalPhysicalMemory) / 1048576))

                        .Text = "Definiendo tope de Memoria RAM a usar"
                        ObjItemtot = ObjItem / 3

                        ObjItemtot2 = ObjItem / 4

                        .Text = "Editando archivo"
                        strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)

                        .Text = "Introduciendo líneas de texto dentro del archivo"
                        strStreamWriter.WriteLine("@echo off")
                        strStreamWriter.WriteLine("set APPDATA=" & Application.StartupPath & "\PackMods\" & prueba1)
                        strStreamWriter.WriteLine("java  -Xincgc -Xmx%1m -Xms%2m -cp ""%APPDATA%\.minecraft\bin\minecraft.jar;%APPDATA%\.minecraft\bin\lwjgl.jar;%APPDATA%\.minecraft\bin\lwjgl_util.jar;%APPDATA%\.minecraft\bin\jinput.jar"" -Djava.library.path=""%APPDATA%\.minecraft\bin\natives"" net.minecraft.client.Minecraft %3")
                        strStreamWriter.WriteLine("break")

                        .Text = "Cerrando el editor"
                        strStreamWriter.Close()

                    Catch ex As Exception
                        MsgBox("Error al Guardar la ingormacion en el archivo. " & ex.ToString, MsgBoxStyle.Critical, Application.ProductName)
                        strStreamWriter.Close()
                    End Try

                    .Text = "Introduciendo nuevos datos en el INI"
                    INI_Manager.Set_Value(".\Test.ini", "Xmx-" & cuenta, ObjItemtot2)
                    INI_Manager.Set_Value(".\Test.ini", "Xms-" & cuenta, ObjItemtot)

                    .Text = "Borrando archivos temporales"
                    File.Delete(prueba3)

                    .Text = "¡" & prueba1 & " ha sido instalado correctamente!" & vbCrLf & "Muchas gracias por usar IkillLauncher"
                Else
                    MsgBox("Este ModPack ya lo tienes instalado!")
                End If

            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub
End Class