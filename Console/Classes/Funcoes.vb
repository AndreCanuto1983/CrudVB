Imports Console.MDI
Imports Console.DBConnection
Imports System.Data.SqlClient
Imports Console

Public Class Funcoes

    'Dim combob As DataSet

    Public Sub preencherCombo(combo As ComboBox, tabela As String) 
        Dim db As New DBConnection

        Try
            db.open()
            Dim cd As New SqlCommand("select * from " & tabela, db.connection)
            Dim ad As New SqlDataAdapter(cd)
            Dim ds As New DataSet
            ad.Fill(ds, tabela)

            Dim dt As New DataTable
            dt.Columns.Add("Descricao", GetType(System.String))
            dt.Columns.Add("Codigo", GetType(System.String))

            Dim dr As DataRow
            Dim drNovaRow As DataRow

            'percorre a tabela funcionarios definida e preenche com dados da tabela da base de dados 
            For Each dr In ds.Tables(tabela).Rows()
                drNovaRow = dt.NewRow()
                drNovaRow("Descricao") = dr("Descricao")
                drNovaRow("Codigo") = dr("Codigo")
                dt.Rows.Add(drNovaRow)
            Next

            With combo
                .DataSource = dt
                .DisplayMember = "Nome"
                .ValueMember = "CódigoDoFuncionário"
                .SelectedIndex = 0
            End With
            cd.Dispose()

        Catch ex As Exception
            MsgBox("Erro ao preencher ComboBox", Err.Description, Err.Number)
        Finally
            db.close()
        End Try

    End Sub



End Class
