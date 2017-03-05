' CustomFont.vb

    Imports System.Drawing
    Imports System.Drawing.Text
    Imports System.Runtime.InteropServices

Public NotInheritable Class CustomFont
    Implements IDisposable

    Dim MyFont As New CustomFont(My.Resources.Capture_it)
    Dim MyFont2 As New CustomFont(My.Resources.minecraft)
    Dim MyFont3 As New CustomFont(My.Resources.minecraft_z2font)

    'Private Sub Main_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
    '    MyFont.Dispose()
    'End Sub

    Private fontCollection As New PrivateFontCollection()
    Private fontPtr As IntPtr

    ''' <summary>
    ''' Creates a new custom font using the specified font data.
    ''' </summary>
    ''' <param name="fontData">The font data representing the font.</param>
    Public Sub New(ByVal fontData() As Byte)
        'Create a pointer to the font data and copy the
        'font data into the location in memory pointed to
        fontPtr = Marshal.AllocHGlobal(fontData.Length)
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length)

        'Add the font to the shared collection of fonts:
        fontCollection.AddMemoryFont(fontPtr, fontData.Length)
    End Sub

    'Free the font in unmanaged memory, dispose of
    'the font collection and suppress finalization
    Public Sub Dispose() Implements IDisposable.Dispose
        Marshal.FreeHGlobal(fontPtr)
        fontCollection.Dispose()

        GC.SuppressFinalize(Me)
    End Sub

    'Free the font in unmanaged memory
    Protected Overrides Sub Finalize()
        Marshal.FreeHGlobal(fontPtr)
    End Sub

    Public ReadOnly Property Font() As FontFamily
        Get
            Return fontCollection.Families(0)
        End Get
    End Property

End Class
