﻿
Public Module modWarnings

    Public WarningImages As New ImageList
End Module

Public Class frmWarnings

    Public Sub New(result As clsResult, windowTitle As String)
        InitializeComponent()

        Icon = ProgramIcon

        Text = windowTitle

        tvwWarnings.StateImageList = WarningImages
        result.MakeNodes(tvwWarnings.Nodes)
        tvwWarnings.ExpandAll()

        AddHandler tvwWarnings.NodeMouseDoubleClick, AddressOf NodeDoubleClicked
    End Sub

    Private Sub NodeDoubleClicked(sender As Object, e As TreeNodeMouseClickEventArgs)

        Dim item As iResultItem = CType(e.Node.Tag, iResultItem)
        item.DoubleClicked()
    End Sub

    Private Sub frmWarnings_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        RemoveHandler tvwWarnings.NodeMouseDoubleClick, AddressOf NodeDoubleClicked
    End Sub
End Class
