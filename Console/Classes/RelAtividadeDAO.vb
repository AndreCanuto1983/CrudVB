    Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class RelAtividadeDAO
    Dim grade As DataSet
    Public Sub RelacaoAtividade(codigo As Long, periodo1 As DateTime, periodo2 As DateTime, tipoAtividade As Integer, situacao As Integer)
        Dim cx = New DBConnection
        Dim sql = "SELECT * FROM Console_Atividade WHERE Codigo = '" & codigo & "'"
        Try
            cx.open()
            Dim cmd = New SqlCommand(sql, cx.connection)
            Dim da = New SqlDataAdapter(cmd)
            Dim ds = New DataSet()
            Dim dt = New DataTable()
            da.Fill(ds)
            grade = ds
            cx.close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(vbCrLf & ex.Message)
        End Try

    End Sub
    Public Function DevolverGrade() As DataSet
        Return grade
    End Function

End Class
