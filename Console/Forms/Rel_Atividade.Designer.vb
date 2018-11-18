<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rel_Atividade
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rel_Atividade))
        Me.gbRelAtividade = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotalAtividades = New System.Windows.Forms.Label()
        Me.chkInativo = New System.Windows.Forms.CheckBox()
        Me.dtPeriodo2 = New System.Windows.Forms.DateTimePicker()
        Me.dtPeriodo1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblData = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.cboSituacao = New System.Windows.Forms.ComboBox()
        Me.lblSituacao = New System.Windows.Forms.Label()
        Me.txtCodigo = New System.Windows.Forms.TextBox()
        Me.cboTipoAtividade = New System.Windows.Forms.ComboBox()
        Me.lblCodigo = New System.Windows.Forms.Label()
        Me.lblTipoAtividade = New System.Windows.Forms.Label()
        Me.grdRelAtividades = New System.Windows.Forms.DataGridView()
        Me.btnGerar = New System.Windows.Forms.Button()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.gbRelAtividade.SuspendLayout()
        CType(Me.grdRelAtividades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbRelAtividade
        '
        resources.ApplyResources(Me.gbRelAtividade, "gbRelAtividade")
        Me.gbRelAtividade.Controls.Add(Me.Label3)
        Me.gbRelAtividade.Controls.Add(Me.lblTotalAtividades)
        Me.gbRelAtividade.Controls.Add(Me.chkInativo)
        Me.gbRelAtividade.Controls.Add(Me.dtPeriodo2)
        Me.gbRelAtividade.Controls.Add(Me.dtPeriodo1)
        Me.gbRelAtividade.Controls.Add(Me.Label2)
        Me.gbRelAtividade.Controls.Add(Me.Label1)
        Me.gbRelAtividade.Controls.Add(Me.lblData)
        Me.gbRelAtividade.Controls.Add(Me.lblUsuario)
        Me.gbRelAtividade.Controls.Add(Me.cboSituacao)
        Me.gbRelAtividade.Controls.Add(Me.lblSituacao)
        Me.gbRelAtividade.Controls.Add(Me.txtCodigo)
        Me.gbRelAtividade.Controls.Add(Me.cboTipoAtividade)
        Me.gbRelAtividade.Controls.Add(Me.lblCodigo)
        Me.gbRelAtividade.Controls.Add(Me.lblTipoAtividade)
        Me.gbRelAtividade.Controls.Add(Me.grdRelAtividades)
        Me.gbRelAtividade.Controls.Add(Me.btnGerar)
        Me.gbRelAtividade.Controls.Add(Me.lblPeriodo)
        Me.gbRelAtividade.Name = "gbRelAtividade"
        Me.gbRelAtividade.TabStop = False
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'lblTotalAtividades
        '
        resources.ApplyResources(Me.lblTotalAtividades, "lblTotalAtividades")
        Me.lblTotalAtividades.Name = "lblTotalAtividades"
        '
        'chkInativo
        '
        resources.ApplyResources(Me.chkInativo, "chkInativo")
        Me.chkInativo.Name = "chkInativo"
        Me.chkInativo.UseVisualStyleBackColor = True
        '
        'dtPeriodo2
        '
        resources.ApplyResources(Me.dtPeriodo2, "dtPeriodo2")
        Me.dtPeriodo2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPeriodo2.Name = "dtPeriodo2"
        '
        'dtPeriodo1
        '
        resources.ApplyResources(Me.dtPeriodo1, "dtPeriodo1")
        Me.dtPeriodo1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtPeriodo1.Name = "dtPeriodo1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'lblData
        '
        resources.ApplyResources(Me.lblData, "lblData")
        Me.lblData.Name = "lblData"
        '
        'lblUsuario
        '
        resources.ApplyResources(Me.lblUsuario, "lblUsuario")
        Me.lblUsuario.Name = "lblUsuario"
        '
        'cboSituacao
        '
        resources.ApplyResources(Me.cboSituacao, "cboSituacao")
        Me.cboSituacao.FormattingEnabled = True
        Me.cboSituacao.Name = "cboSituacao"
        '
        'lblSituacao
        '
        resources.ApplyResources(Me.lblSituacao, "lblSituacao")
        Me.lblSituacao.Name = "lblSituacao"
        '
        'txtCodigo
        '
        resources.ApplyResources(Me.txtCodigo, "txtCodigo")
        Me.txtCodigo.Name = "txtCodigo"
        '
        'cboTipoAtividade
        '
        resources.ApplyResources(Me.cboTipoAtividade, "cboTipoAtividade")
        Me.cboTipoAtividade.FormattingEnabled = True
        Me.cboTipoAtividade.Name = "cboTipoAtividade"
        '
        'lblCodigo
        '
        resources.ApplyResources(Me.lblCodigo, "lblCodigo")
        Me.lblCodigo.Name = "lblCodigo"
        '
        'lblTipoAtividade
        '
        resources.ApplyResources(Me.lblTipoAtividade, "lblTipoAtividade")
        Me.lblTipoAtividade.Name = "lblTipoAtividade"
        '
        'grdRelAtividades
        '
        Me.grdRelAtividades.AllowUserToAddRows = False
        Me.grdRelAtividades.AllowUserToDeleteRows = False
        Me.grdRelAtividades.AllowUserToOrderColumns = True
        Me.grdRelAtividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        resources.ApplyResources(Me.grdRelAtividades, "grdRelAtividades")
        Me.grdRelAtividades.Name = "grdRelAtividades"
        Me.grdRelAtividades.ReadOnly = True
        Me.grdRelAtividades.RowTemplate.Height = 24
        '
        'btnGerar
        '
        resources.ApplyResources(Me.btnGerar, "btnGerar")
        Me.btnGerar.Name = "btnGerar"
        Me.btnGerar.UseVisualStyleBackColor = True
        '
        'lblPeriodo
        '
        resources.ApplyResources(Me.lblPeriodo, "lblPeriodo")
        Me.lblPeriodo.Name = "lblPeriodo"
        '
        'Rel_Atividade
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.gbRelAtividade)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "Rel_Atividade"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gbRelAtividade.ResumeLayout(False)
        Me.gbRelAtividade.PerformLayout()
        CType(Me.grdRelAtividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbRelAtividade As System.Windows.Forms.GroupBox
    Friend WithEvents cboTipoAtividade As System.Windows.Forms.ComboBox
    Friend WithEvents lblTipoAtividade As System.Windows.Forms.Label
    Friend WithEvents btnGerar As System.Windows.Forms.Button
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As System.Windows.Forms.TextBox
    Friend WithEvents lblCodigo As System.Windows.Forms.Label
    Friend WithEvents cboSituacao As System.Windows.Forms.ComboBox
    Friend WithEvents lblSituacao As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblData As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents grdRelAtividades As System.Windows.Forms.DataGridView
    Friend WithEvents dtPeriodo2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtPeriodo1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkInativo As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAtividades As System.Windows.Forms.Label
End Class
