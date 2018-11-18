Imports System.Data.SqlClient
Imports System

Public Class DBConnection

    Public connectionString As String

    Public connection As SqlConnection

    Public command As SqlCommand

    Public Sub open()
        If verificaPC() = "*****-PC" Then
            Me.connectionString = "Server=******-PC\sql2014; Database=CCBANCO; User Id=sa; Password=**********;"
            Me.connection = New SqlConnection(Me.connectionString)
            Me.connection.Open()

        ElseIf verificaPC() = "******-NOTE" Then            
            Me.connectionString = "Data Source=*****-NOTE\SQL2014;Initial Catalog=Console;User ID=sa;Password=********"
            Me.connection = New SqlConnection(Me.connectionString)
            Me.connection.Open()
        Else
            MessageBox.Show("Por favor entre em contato com o administrador!")
        End If
    End Sub

    Public Sub executeQuery(ByVal query As String)

        Me.command = New SqlCommand()
        Me.command.Connection = Me.connection
        Me.command.CommandText = query
        Me.command.CommandType = CommandType.Text

        Me.command.ExecuteNonQuery()

    End Sub

    Public Function getResult() As System.Data.DataTable

        Dim dataTable As DataTable
        Dim dataReader As SqlDataReader


        dataTable = New DataTable()
        dataReader = Me.command.ExecuteReader(CommandBehavior.CloseConnection)

        dataTable.Load(dataReader, LoadOption.OverwriteChanges)
        dataReader.Close()
        dataReader.Dispose()

        Return (dataTable)

    End Function

    Public Sub close()

        If ((Me.connection Is Nothing) = False) Then


            If (Me.connection.State = ConnectionState.Open) Then

                Me.connection.Close()

            End If

        End If

    End Sub

    Public Function verificaPC()
        Dim namePC As String = System.Net.Dns.GetHostName

        Return namePC
    End Function

End Class
