Imports System.Net
Imports System.IO
Imports System.Diagnostics

Public Class Updater

    Public Shared Sub Comprobar(ByVal url As String, ByVal directorio As String, ByVal texto As String)
        Dim patha As String = directorio & "upt.txt"
        Dim patha2 As String = directorio & "Update.zip"
        Dim patha3 As String = directorio & "upt.exe"

        If File.Exists(patha) Then
            File.Delete(patha)
        End If

        If File.Exists(patha2) Then
            File.Delete(patha2)
        End If

        If File.Exists(patha3) Then
            File.Delete(patha3)
        End If

        If Not File.Exists(patha) Then
            My.Computer.Network.DownloadFile(
        url,
        patha)
        End If

        If File.Exists(patha) Then

            Dim lines As String() = File.ReadAllLines(patha)

            If Not lines(0) = texto Then
                If MsgBox("¡Atención! Su Launcher está desactualizado." & vbCrLf & "Pulse ""Sí"" para continuar con la instalación. O ""No"" para descartar cambios.", MsgBoxStyle.YesNo, "¡Atención! Su launcher está desactualizado...") = MsgBoxResult.Yes Then
                    My.Computer.Network.DownloadFile(
            lines(1),
            patha2)
                    Extraer.Extraer(patha2, directorio)
                    Dim psi As New ProcessStartInfo()
                    psi.UseShellExecute = True
                    psi.FileName = patha3
                    Process.Start(psi)
                    Application.Exit()
                End If
            End If

        End If
    End Sub

End Class