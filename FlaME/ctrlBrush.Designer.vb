﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctrlBrush
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.tabShape = New System.Windows.Forms.TabControl()
        Me.TabPage37 = New System.Windows.Forms.TabPage()
        Me.TabPage38 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudRadius = New System.Windows.Forms.NumericUpDown()
        Me.tabShape.SuspendLayout()
        CType(Me.nudRadius, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabShape
        '
        Me.tabShape.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.tabShape.Controls.Add(Me.TabPage37)
        Me.tabShape.Controls.Add(Me.TabPage38)
        Me.tabShape.ItemSize = New System.Drawing.Size(64, 24)
        Me.tabShape.Location = New System.Drawing.Point(139, 0)
        Me.tabShape.Margin = New System.Windows.Forms.Padding(0)
        Me.tabShape.Multiline = True
        Me.tabShape.Name = "tabShape"
        Me.tabShape.Padding = New System.Drawing.Point(0, 0)
        Me.tabShape.SelectedIndex = 0
        Me.tabShape.Size = New System.Drawing.Size(161, 32)
        Me.tabShape.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.tabShape.TabIndex = 41
        '
        'TabPage37
        '
        Me.TabPage37.Location = New System.Drawing.Point(4, 28)
        Me.TabPage37.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage37.Name = "TabPage37"
        Me.TabPage37.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage37.Size = New System.Drawing.Size(153, 0)
        Me.TabPage37.TabIndex = 0
        Me.TabPage37.Text = "Circular"
        Me.TabPage37.UseVisualStyleBackColor = True
        '
        'TabPage38
        '
        Me.TabPage38.Location = New System.Drawing.Point(4, 28)
        Me.TabPage38.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPage38.Name = "TabPage38"
        Me.TabPage38.Padding = New System.Windows.Forms.Padding(4)
        Me.TabPage38.Size = New System.Drawing.Size(153, 0)
        Me.TabPage38.TabIndex = 1
        Me.TabPage38.Text = "Square"
        Me.TabPage38.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 20)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Radius"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.UseCompatibleTextRendering = True
        '
        'nudRadius
        '
        Me.nudRadius.DecimalPlaces = 1
        Me.nudRadius.Increment = New Decimal(New Integer() {5, 0, 0, 65536})
        Me.nudRadius.Location = New System.Drawing.Point(60, 0)
        Me.nudRadius.Margin = New System.Windows.Forms.Padding(4)
        Me.nudRadius.Maximum = New Decimal(New Integer() {512, 0, 0, 0})
        Me.nudRadius.Name = "nudRadius"
        Me.nudRadius.Size = New System.Drawing.Size(75, 22)
        Me.nudRadius.TabIndex = 40
        Me.nudRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ctrlBrush
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tabShape)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudRadius)
        Me.Name = "ctrlBrush"
        Me.Size = New System.Drawing.Size(334, 35)
        Me.tabShape.ResumeLayout(False)
        CType(Me.nudRadius, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabShape As System.Windows.Forms.TabControl
    Friend WithEvents TabPage37 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage38 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudRadius As System.Windows.Forms.NumericUpDown

End Class
