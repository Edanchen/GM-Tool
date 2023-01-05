Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Class MainWindow
    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim con As New System.Data.SqlClient.SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=ADM_Tool;Trusted_Connection=Yes;")
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("SELECT * FROM dbo.Account WHERE Benutzer = '" & TextBox1.Text & "' AND Passwort = '" & TextBox2.Text & "'", con)
        con.Open()
        Dim sdr As System.Data.SqlClient.SqlDataReader = cmd.ExecuteReader()
        ' If the record can be queried, Pass verification and open another form.  
        If (sdr.Read() = True) Then
            MessageBox.Show("Herzlich Willkommen im Shaiya GM Tool v1.")
            Dim GMTool As New Page2
            Me.NavigationService.Navigate(GMTool)

        Else
            MessageBox.Show("Benutzername oder Password Falsch!")
        End If
        con.Close()
    End Sub
End Class
