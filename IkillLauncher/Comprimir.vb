Imports Ionic.Zip

Public Class Comprimir

    Public Shared Sub Comprimir(ByVal NombreDirectorio, ByVal NombreGuardar)
        Using zip As ZipFile = New ZipFile()
            zip.AddDirectory(NombreDirectorio)
            zip.Save(NombreGuardar)
        End Using
    End Sub

End Class