Imports Ionic.Zip

Public Class Extraer

    Public Shared Sub Extraer(ByVal ZipAExtraer As String, ByVal DirectorioExtraccion As String)
        Try

            Using zip1 As ZipFile = ZipFile.Read(ZipAExtraer)
                Dim e As ZipEntry
                For Each e In zip1
                    e.Extract(DirectorioExtraccion, ExtractExistingFileAction.OverwriteSilently)
                Next
            End Using

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class