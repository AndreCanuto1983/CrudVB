Imports Console.DBConnection


Public Class CadAtividadeDAO

    Private tipoAtividade As Integer
    Private descricaoAtividade As String
    Private decDetalhadaAtividade As String
    Private situacaoAtividade As Integer

    Public Sub cadastrarAtividade(tpAtividade As Integer, descAtividade As String, descDetAtividade As String, stAtividade As Integer)

        Dim dbConennction As New DBConnection()
        Dim sql As String

        Try
            dbConennction.open()

            sql = "INSERT INTO Console_Atividade (Tipo_Atividade,Desc_Atividade, Desc_Detalhada_Atividade, Situacao, Data_Cadastro, Usuario_Responsavel)"
            sql = sql & " VALUES( " & tpAtividade & " ,'" & descAtividade & "','" & descDetAtividade & "'," & stAtividade & ", GETDATE(), 2)"

            dbConennction.executeQuery(sql)

            dbConennction.close()
            MsgBox("Atividade cadastrada com Sucesso!" & vbCrLf)
        Catch ex As Exception
            MsgBox("Erro ao Cadastrar Atividade" & vbCrLf & ex.Message)
        End Try
    End Sub

End Class
