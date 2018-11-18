Imports System.Data
Imports System.Data.SqlClient
Public Class Login
    Private Sub btnEntrar_Click(sender As Object, e As EventArgs) Handles btnEntrar.Click
        Dim login As New LoginDAO()
        login.DevolverLogin(txtUsuario, txtSenha, lblVersao)
    End Sub

    Private Sub Login_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub txtUsuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUsuario.KeyPress
        Dim funcoes As New Funcoes
        funcoes.SoLetras(e)
        funcoes.LetraMaiusculas(e, txtUsuario)  'Converte o texto para caixa alta
    End Sub

    Private Sub txtSenha_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSenha.KeyPress
        Dim funcoes As New Funcoes
        funcoes.SoNumeros(e)
    End Sub
End Class
