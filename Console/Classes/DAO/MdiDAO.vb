Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class MdiDAO
    Public Function getUsuario() 'este método pega o usuário logado
        Dim dbConnection = New DBConnection()
        Dim verificarMaquina = dbConnection.verificaPC()
        Dim sql = "SELECT * FROM Temp WHERE Maquina = '" & verificarMaquina & "'"
        
        Dim funcoesDao = New FuncoesDAO()
        Dim retorno As SqlDataReader
        retorno = funcoesDao.ConsultarDados(sql)
        Return retorno
    End Function

    Public Sub LimparTemp(maquina As String)
        Dim dbConnection = New DBConnection()
        Dim verificarMaquina = dbConnection.verificaPC()
        Dim sql = "DELETE FROM Temp WHERE Maquina = '" & verificarMaquina & "'"
        Dim funcoesDao = New FuncoesDAO()
        Try
            If (maquina = verificarMaquina) Then
                funcoesDao.ExcluirDados(sql)
            Else
                MessageBox.Show("ERRO!, máquina não confere com usuário logado!", "Cuidado!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
