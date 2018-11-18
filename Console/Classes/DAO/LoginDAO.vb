Imports System.Data
Imports System.Data.SqlClient
Public Class LoginDAO
    Dim _usuario = String.Empty
    Public Sub DevolverLogin(txtUsuario As TextBox, txtSenha As TextBox, versao As Label)
        Dim login As New Login()
        If (txtUsuario.Text = "") Then
            MessageBox.Show("Informe o usuário!")
            txtUsuario.Focus()
        ElseIf (txtSenha.Text = "") Then
            MessageBox.Show("Informe a senha!")
            txtSenha.Focus()
        Else
            Try
                Dim usuario = txtUsuario.Text
                Dim senha = txtSenha.Text
                Dim sql = "SELECT l.Codigo, l.Usuario, l.Senha, fs.Situacao, p.Perfil FROM Funcionario_Login l "
                sql = sql & "LEFT JOIN Funcionario_Perfil p ON l.Perfil = p.Codigo "
                sql = sql & "LEFT JOIN Funcionario_Situacao fs ON l.Situacao = fs.Codigo  "
                sql = sql & "WHERE l.Usuario = '" & usuario & "' AND l.Senha = '" & senha & "'"

                Dim funcoesDao = New FuncoesDAO
                Dim retorno As SqlDataReader
                retorno = funcoesDao.ConsultarDados(sql)

                Dim _senha = String.Empty
                Dim _codigo = String.Empty
                Dim _situacao = String.Empty
                Dim _perfil = String.Empty
                _codigo = retorno("Codigo")
                _usuario = retorno("Usuario")
                _senha = retorno("Senha")
                _situacao = retorno("Situacao")
                _perfil = retorno("Perfil")
                Dim verificarPc = New DBConnection()
                Dim maquina = verificarPc.verificaPC()

                If (_usuario = usuario And _senha = senha) Then
                    Dim query = "INSERT INTO Temp(Codigo, Usuario, Situacao, Perfil, Maquina, Versao)"
                    query = query & "VALUES('" & _codigo & "','" & _usuario & "','" & _situacao & "','" & _perfil & "',"
                    query = query & "'" & maquina & "','" & versao.Text & "')"

                    funcoesDao.InserirDados(query)
                    Dim mdi = New MDI()
                    mdi.ShowDialog()
                    login.Dispose()
                End If
            Catch ex As Exception
                MessageBox.Show("Registro inexistente!")
                login.txtUsuario.Text = String.Empty
                login.txtSenha.Text = String.Empty
                login.txtUsuario.Focus()
            End Try
        End If
    End Sub
End Class
