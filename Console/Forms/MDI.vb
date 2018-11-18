Imports Console
Imports System.Data.SqlClient

Public Class MDI
    Private Sub Console_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim usuario As SqlDataReader
        Dim mdiDao = New MdiDAO()
        usuario = MdiDAO.getUsuario()
        lblUsuarioLogado.Text = usuario("Usuario")
        lblPerfil.Text = usuario("Perfil")
        lblVersao.Text = usuario("Versao")
        Dim AbrirConexao As New DBConnection
        Call AbrirConexao.open()
        Login.Hide()
        Dim funcoes = New Funcoes()
        funcoes.TamanhoTela(Me)
    End Sub

    Public Sub CadastroDeAtividadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastroDeAtividadeToolStripMenuItem.Click
        'Declaração da variável Incluir (nome do form que vai ser chamado)
        Dim Cad_Atividade As New Cad_Atividade
        Dim Funcoes As New Funcoes

        Cad_Atividade.MdiParent = Me 'Permite que o Form Filho seja aberto dentro do Form MDI
        Funcoes.Centraliza(Me, Cad_Atividade) ' Centraliza form na tela 
        Cad_Atividade.WindowState = FormWindowState.Maximized 'Maximiza o form filho dentro do MDI
        Cad_Atividade.Show() 'Chama o Form Cadastro de Atividade, lembrar de declarar o form

        Dim usuario As SqlDataReader
        Dim mdiDao = New MdiDAO()
        usuario = mdiDao.getUsuario()
        Cad_Atividade.lblCodUsuario.Text = usuario("Codigo")
        Cad_Atividade.lblNomeUsuario.Text = usuario("Usuario")
    End Sub

    Private Sub RelaçãoDeAtividadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelaçãoDeAtividadeToolStripMenuItem.Click
        Dim Rel_Atividade As New Rel_Atividade
        Rel_Atividade.MdiParent = Me 'Permite que o Form Filho seja aberto dentro do Form MDI
        Rel_Atividade.Show()
        Dim usuario As SqlDataReader
        Dim mdiDao = New MdiDAO()
        usuario = mdiDao.getUsuario()
        Rel_Atividade.lblUsuario.Text = usuario("Usuario")
        Rel_Atividade.lblData.Text = System.DateTime.Today
    End Sub

    Private Sub MDI_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dim maquina = String.Empty
        Dim usuario As SqlDataReader
        Dim mdiDao = New MdiDAO()
        usuario = mdiDao.getUsuario()
        maquina = usuario("Maquina")
        mdiDao.LimparTemp(maquina)
        Dim cx = New DBConnection
        cx.close()
        Login.Dispose()
        Me.Dispose()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        lblData.Text = Convert.ToString(DateAndTime.Now.ToLongDateString())
        lblHorario.Text = Convert.ToString(DateTime.Now.ToLongTimeString())
    End Sub
End Class