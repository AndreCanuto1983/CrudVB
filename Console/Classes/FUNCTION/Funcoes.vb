Imports Console.MDI
Imports Console.DBConnection
Imports System.Data.SqlClient
Imports Console

Public Class Funcoes

    Public Sub PreencherCombo(combo As ComboBox, tabela As String, colunaDescricao As String, colunaID As String)
        Dim cx = New DBConnection
        Dim sql = "SELECT * FROM " & tabela & " ORDER BY Codigo ASC"
        Try
            cx.open()
            Dim cmd = New SqlCommand(sql, cx.connection)
            Dim leitor As SqlDataReader = cmd.ExecuteReader
            Dim dt = New DataTable()
            dt.Load(leitor)
            Dim row As DataRow = dt.NewRow()
            row(colunaDescricao) = ""
            dt.Rows.InsertAt(row, 0) ' insiro o valor nulo na combo
            combo.DataSource = dt
            combo.ValueMember = colunaID
            combo.DisplayMember = colunaDescricao
            leitor.Close()
            cx.close()
        Catch ex As Exception
            MsgBox(vbCrLf & ex.Message)
        End Try
    End Sub
    Public Function ConverterPeriodo(periodo As ArrayList) As ArrayList
        periodo(0) = periodo(0) & " 00:00:00"
        periodo(1) = periodo(1) & " 23:59:59"
        Return periodo
    End Function

    Public Sub LetraMaiusculas(e As KeyPressEventArgs, campo As TextBox)
        If Char.IsLower(e.KeyChar) Then
            campo.SelectedText = Char.ToUpper(e.KeyChar)  'Converte o texto para caixa alta
            e.Handled = True
        End If
    End Sub

    Public Sub SoNumeros(e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        End If
    End Sub

    Public Sub SoLetras(e As KeyPressEventArgs)
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Public Sub SairTela(e As KeyEventArgs, tela As Form)
        If (e.KeyCode = Keys.Escape) Then
            e.Handled = True
            tela.Dispose()
        End If
    End Sub
    Public Sub TamanhoTela(nomeForm As Form)
        'Função para ajustar o form de acordo com a resolução da área de trabalho
        'Na própria tela passe por parâmetro (Me) ele reconhece e trata
        nomeForm.Width = My.Computer.Screen.WorkingArea.Width
        nomeForm.Height = My.Computer.Screen.WorkingArea.Height
    End Sub

    Public Sub Centraliza(Parent As Form, Child As Form)

        Child.StartPosition = FormStartPosition.CenterScreen
        Dim X As Decimal = (Parent.Width - Child.Width) / 2
        Dim y As Decimal = (Parent.Height - Child.Height) / 2
        Child.Location = New Point(X, y)

        'Child.WindowState = FormWindowState.Maximized
    End Sub

End Class

