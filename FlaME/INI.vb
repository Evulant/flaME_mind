﻿
Public Class clsINIRead
    Public Class clsSection
        Public Name As String
#If Mono = 0.0# Then
        Public Structure sProperty
#Else
        Public Class sProperty
#End If
            Public Name As String
            Public Value As String
#If Mono = 0.0# Then
        End Structure
#Else
        End Class
#End If
        Public Properties As New SimpleList(Of sProperty)

        Public Sub CreateProperty(ByVal Name As String, ByVal Value As String)
            Dim newProperty As New sProperty

            newProperty.Name = Name
            newProperty.Value = Value
            Properties.Add(newProperty)
        End Sub

        Public Function ReadFile(ByVal File As System.IO.StreamReader) As clsResult
            Dim ReturnResult As New clsResult

            Dim InvalidLineCount As Integer = 0
            Dim CurrentEntryNum As Integer = -1
            Dim LineText As String = Nothing
            Dim A As Integer

            Do
                LineText = File.ReadLine
                If LineText Is Nothing Then
                    Exit Do
                End If
                LineText = LineText.Trim
                A = LineText.IndexOf("#"c)
                If A >= 0 Then
                    LineText = Strings.Left(LineText, A).Trim
                End If
                If LineText.Length >= 1 Then
                    A = LineText.IndexOf("="c)
                    If A >= 0 Then
                        CreateProperty(LineText.Substring(0, A).ToLower.Trim, LineText.Substring(A + 1, LineText.Length - A - 1).Trim)
                    Else
                        InvalidLineCount += 1
                    End If
                ElseIf LineText.Length > 0 Then
                    InvalidLineCount += 1
                End If
            Loop

            Properties.RemoveBuffer()

            If InvalidLineCount > 0 Then
                ReturnResult.Warning_Add("There were " & InvalidLineCount & " invalid lines that were ignored.")
            End If

            Return ReturnResult
        End Function

        Public Function Translate(ByVal SectionNum As Integer, ByVal Translator As clsINIRead.clsSectionTranslator, ByRef ErrorCount As sErrorCount) As clsResult
            Dim ReturnResult As New clsResult

            Dim A As Integer
            Dim TranslatorResult As enumTranslatorResult

            For A = 0 To Properties.ItemCount - 1
                TranslatorResult = Translator.Translate(SectionNum, Properties(A))
                Select Case TranslatorResult
                    Case enumTranslatorResult.NameUnknown
                        If ErrorCount.NameErrorCount < 16 Then
                            ReturnResult.Warning_Add("Property name " & ControlChars.Quote & Properties(A).Name & ControlChars.Quote & " is unknown.")
                        End If
                        ErrorCount.NameErrorCount += 1
                    Case enumTranslatorResult.ValueInvalid
                        If ErrorCount.ValueErrorCount < 16 Then
                            ReturnResult.Warning_Add("Value " & ControlChars.Quote & Properties(A).Value & ControlChars.Quote & " for property name " & ControlChars.Quote & Properties(A).Name & ControlChars.Quote & " is not valid.")
                        End If
                        ErrorCount.ValueErrorCount += 1
                End Select
            Next

            Return ReturnResult
        End Function

        Public Function Translate(ByVal Translator As clsINIRead.clsTranslator) As clsResult
            Dim ReturnResult As New clsResult

            Dim A As Integer
            Dim TranslatorResult As enumTranslatorResult
            Dim ErrorCount As sErrorCount

            ErrorCount.NameWarningCountMax = 16
            ErrorCount.ValueWarningCountMax = 16

            For A = 0 To Properties.ItemCount - 1
                TranslatorResult = Translator.Translate(Properties(A))
                Select Case TranslatorResult
                    Case enumTranslatorResult.NameUnknown
                        If ErrorCount.NameErrorCount < 16 Then
                            ReturnResult.Warning_Add("Property name " & ControlChars.Quote & Properties(A).Name & ControlChars.Quote & " is unknown.")
                        End If
                        ErrorCount.NameErrorCount += 1
                    Case enumTranslatorResult.ValueInvalid
                        If ErrorCount.ValueErrorCount < 16 Then
                            ReturnResult.Warning_Add("Value " & ControlChars.Quote & Properties(A).Value & ControlChars.Quote & " for property name " & ControlChars.Quote & Properties(A).Name & ControlChars.Quote & " is not valid.")
                        End If
                        ErrorCount.ValueErrorCount += 1
                End Select
            Next

            If ErrorCount.NameErrorCount > ErrorCount.NameWarningCountMax Then
                ReturnResult.Warning_Add("There were " & ErrorCount.NameErrorCount & " unknown property names that were ignored.")
            End If
            If ErrorCount.ValueErrorCount > ErrorCount.ValueWarningCountMax Then
                ReturnResult.Warning_Add("There were " & ErrorCount.ValueErrorCount & " invalid values that were ignored.")
            End If

            Return ReturnResult
        End Function

        Public Function GetLastPropertyValue(ByVal LCasePropertyName As String) As String
            Dim A As Integer

            For A = Properties.ItemCount - 1 To 0 Step -1
                If Properties(A).Name = LCasePropertyName Then
                    Return Properties(A).Value
                End If
            Next
            Return Nothing
        End Function
    End Class
    Public Sections As New SimpleClassList(Of clsSection)

    Public Sub CreateSection(ByVal Name As String)
        Dim newSection As New clsSection
        newSection.Name = Name

        Sections.Add(newSection)
    End Sub

    Public Function ReadFile(ByVal File As IO.StreamReader) As clsResult
        Dim ReturnResult As New clsResult

        Dim InvalidLineCount As Integer = 0
        Dim CurrentEntryNum As Integer = -1
        Dim LineText As String = Nothing
        Dim A As Integer
        Dim SectionName As String

        Do
            LineText = File.ReadLine
            If LineText Is Nothing Then
                Exit Do
            End If
            LineText = LineText.Trim
            A = LineText.IndexOf("#"c)
            If A >= 0 Then
                LineText = Strings.Left(LineText, A).Trim
            End If
            If LineText.Length >= 2 Then
                If LineText.Chars(0) = "["c Then
                    If LineText.Chars(LineText.Length - 1) = "]"c Then
                        SectionName = LineText.Substring(1, LineText.Length - 2)
                        For A = 0 To Sections.ItemCount - 1
                            If Sections(A).Name = SectionName Then
                                Exit For
                            End If
                        Next
                        CurrentEntryNum = A
                        If CurrentEntryNum = Sections.ItemCount Then
                            CreateSection(SectionName)
                        End If
                    Else
                        InvalidLineCount += 1
                    End If
                ElseIf CurrentEntryNum >= 0 Then
                    A = LineText.IndexOf("="c)
                    If A >= 0 Then
                        Sections(CurrentEntryNum).CreateProperty(LineText.Substring(0, A).ToLower.Trim, LineText.Substring(A + 1, LineText.Length - A - 1).Trim)
                    Else
                        InvalidLineCount += 1
                    End If
                Else
                    InvalidLineCount += 1
                End If
            ElseIf LineText.Length > 0 Then
                InvalidLineCount += 1
            End If
        Loop

        Sections.RemoveBuffer()

        If InvalidLineCount > 0 Then
            ReturnResult.Warning_Add("There were " & InvalidLineCount & " invalid lines that were ignored.")
        End If

        Return ReturnResult
    End Function

    Public Enum enumTranslatorResult As Byte
        NameUnknown
        ValueInvalid
        Translated
    End Enum

    Public Structure sErrorCount
        Public NameErrorCount As Integer
        Public ValueErrorCount As Integer
        Public NameWarningCountMax As Integer
        Public ValueWarningCountMax As Integer
    End Structure

    Public Function Translate(ByVal Translator As clsINIRead.clsSectionTranslator) As clsResult
        Dim ReturnResult As New clsResult

        Dim A As Integer
        Dim ErrorCount As sErrorCount

        ErrorCount.NameWarningCountMax = 16
        ErrorCount.ValueWarningCountMax = 16

        For A = 0 To Sections.ItemCount - 1
            ReturnResult.Append(Sections(A).Translate(A, Translator, ErrorCount), "")
        Next

        If ErrorCount.NameErrorCount > ErrorCount.NameWarningCountMax Then
            ReturnResult.Warning_Add("There were " & ErrorCount.NameErrorCount & " unknown property names that were ignored.")
        End If
        If ErrorCount.ValueErrorCount > ErrorCount.ValueWarningCountMax Then
            ReturnResult.Warning_Add("There were " & ErrorCount.ValueErrorCount & " invalid values that were ignored.")
        End If

        Return ReturnResult
    End Function

    Public MustInherit Class clsSectionTranslator

        Public MustOverride Function Translate(ByVal INISectionNum As Integer, ByVal INIProperty As clsINIRead.clsSection.sProperty) As enumTranslatorResult
    End Class

    Public MustInherit Class clsTranslator

        Public MustOverride Function Translate(ByVal INIProperty As clsINIRead.clsSection.sProperty) As enumTranslatorResult
    End Class
End Class

Public Class clsINIWrite

    Public File As IO.StreamWriter
    Public LineEndChar As Char = Chr(10)
    Public EqualsChar As Char = "="c

    Public Sub New()

    End Sub

    Public Shared Function CreateFile(ByVal Output As IO.Stream) As clsINIWrite
        Dim NewINI As New clsINIWrite

        NewINI.File = New IO.StreamWriter(Output, UTF8Encoding)

        Return NewINI
    End Function

    Public Sub SectionName_Append(ByVal Name As String)

        Name = Name.Replace(LineEndChar, "")

        File.Write("["c & Name & "]"c & LineEndChar)
    End Sub

    Public Sub Property_Append(ByVal Name As String, ByVal Value As String)

        Name = Name.Replace(LineEndChar, "")
        Name = Name.Replace(EqualsChar, "")
        Value = Value.Replace(LineEndChar, "")

        File.Write(Name & " " & EqualsChar & " " & Value & LineEndChar)
    End Sub

    Public Sub Gap_Append()

        File.Write(LineEndChar)
    End Sub
End Class