Imports System.Data.SqlClient

Public Class FuncoesDAO
    ' Função utilizada para inserir um novo registro na base de dados
    ' Deve receber uma string sql como parametro
    Public Sub InserirDados(stringSQL As String)
        Dim dbConennction As New DBConnection()
        Try
            dbConennction.open()
            dbConennction.executeQuery(stringSQL)
            dbConennction.close()
            'Excluido está msg pois está impactando na inserção da temp
            'MsgBox("Dados inseridos com Sucesso!" & vbCrLf) 
        Catch ex As Exception
            MsgBox("Erro ao inserir Dados" & vbCrLf & ex.Message & Err.Number & Err.Description)
        End Try
    End Sub
    ' Função deve ser utilizada para alterar os dados de um registro na base de dados
    ' Deve receber uma string sql como parametro
    Public Sub AlterarDados(stringSQL As String)
        Dim dbConennction As New DBConnection()
        Try
            dbConennction.open()
            dbConennction.executeQuery(stringSQL)
            dbConennction.close()
            MsgBox("Dado(os) alterado(os) com Sucesso!" & vbCrLf)
        Catch ex As Exception
            MsgBox("Erro ao alterar Dado(os)" & vbCrLf & ex.Message & Err.Number & Err.Description)
        End Try
    End Sub

    Public Sub ExcluirDados(stringSQL As String)
        Dim dbConennction As New DBConnection()
        Try
            dbConennction.open()
            dbConennction.executeQuery(stringSQL)
            dbConennction.close()
            'Excluido está msg pois está impactando na exclusão da temp
            'MsgBox("Dado(os) excluido(os) com Sucesso!" & vbCrLf)
        Catch ex As Exception
            MsgBox("Erro ao excluir os Dado(os)" & vbCrLf & ex.Message & Err.Number & Err.Description)
        End Try
    End Sub

    Public Function GerarGrade(sql As String) As DataSet 'Retorna DataSet
        Dim cx = New DBConnection
        Dim grade As DataSet
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
        Return grade
    End Function

    Public Function GerarGradeDT(sql As String) As DataTable 'Retorna DataTable
        Dim cx = New DBConnection
        Dim grade As DataTable
        Try
            cx.open()
            Dim cmd = New SqlCommand(sql, cx.connection)
            Dim da = New SqlDataAdapter(cmd)
            Dim ds = New DataSet()
            Dim dt = New DataTable()
            da.Fill(dt)
            grade = dt
            cx.close()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox(vbCrLf & ex.Message)
        End Try
        If (grade.Rows.Count > 0) Then 'se for verdadeiro ele retorna a grade
            Return grade
        Else
            'Não faço nada pois ele vai voltar para o catch da tela onde será exibido a mensagem ja tratada
        End If
    End Function

    'Função utilizada para consultar dados de uma determinada tabela, deve receber a String Sql pronta e retornará um DataReader
    Public Function ConsultarDados(query As String) As SqlDataReader
        Dim cx = New DBConnection
        Dim cmd = New SqlCommand
        Dim resultado As SqlDataReader
        Try
            cx.open()
            cmd.CommandText = query
            cmd.Connection = cx.connection

            Dim dr As SqlDataReader = cmd.ExecuteReader
            If dr.Read Then
                resultado = dr
                cmd.Dispose()
            End If
        Catch ex As Exception
            MsgBox(vbCrLf & ex.Message)
        End Try

        Return resultado
        cx.close()
    End Function


End Class
