Public Class diary_page
    Private diaryEntries As New Dictionary(Of String, DiaryEntry)


    Private currentDate As String = ""


    Private Structure DiaryEntry
        Public Title As String
        Public EntryText As String
        Public Mood As String
        Public Targets As String
    End Structure
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnback.Click
        menupage.Show()
        Hide()

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txttitle.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles datetxt.TextChanged

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtentry.TextChanged

    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtsearchdate.TextChanged

    End Sub

    Private Sub btnNextEntry_Click(sender As Object, e As EventArgs) Handles btnnextentry.Click
        NavigateEntries(1)
    End Sub

    Private Sub btnPreviousEntry_Click(sender As Object, e As EventArgs) Handles btnpreviousentry.Click
        NavigateEntries(-1)
    End Sub

    Private Sub NavigateEntries(direction As Integer)
        Dim dateList As List(Of String) = diaryEntries.Keys.ToList()
        dateList.Sort()

        If currentDate = "" Then

            If dateList.Count > 0 Then
                currentDate = If(direction > 0, dateList(0), dateList(dateList.Count - 1))
                DisplayEntry(currentDate)
            End If
        Else
            Dim currentIndex As Integer = dateList.IndexOf(currentDate)
            If currentIndex >= 0 AndAlso (currentIndex + direction) >= 0 AndAlso (currentIndex + direction) < dateList.Count Then
                currentDate = dateList(currentIndex + direction)
                DisplayEntry(currentDate)
            Else
                MessageBox.Show(If(direction > 0, "No more entries.", "No previous entries."))
            End If
        End If
    End Sub


    Private Sub DisplayEntry(dateStr As String)
        If diaryEntries.ContainsKey(dateStr) Then
            Dim entry As DiaryEntry = diaryEntries(dateStr)
            datetxt.Text = dateStr
            txttitle.Text = entry.Title
            txtentry.Text = entry.EntryText
            txtmood.Text = entry.Mood
            txttargets.Text = entry.Targets
        End If
    End Sub

    Private Sub btnAddEntry_Click(sender As Object, e As EventArgs) Handles btnAddEntry.Click
        Dim dateStr As String = datetxt.Text
        Dim newEntry As New DiaryEntry With {
            .Title = txttitle.Text,
            .EntryText = txtentry.Text,
            .Mood = txtmood.Text,
            .Targets = txttargets.Text
        }


        If dateStr <> "" Then

            If diaryEntries.ContainsKey(dateStr) Then
                diaryEntries(dateStr) = newEntry
            Else
                diaryEntries.Add(dateStr, newEntry)
            End If

            MessageBox.Show("Entry added/updated successfully!")
        Else
            MessageBox.Show("Please enter a valid date.")
        End If

    End Sub
End Class