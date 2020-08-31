Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Class Page2

    Private Sub Button2_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Dim con As New System.Data.SqlClient.SqlConnection("Data Source=127.0.0.1,1433;Initial Catalog=PS_UserData;Trusted_Connection=Yes;")
        Dim cmd As System.Data.SqlClient.SqlCommand = New System.Data.SqlClient.SqlCommand("SELECT GuildName FROM PS_GameData.dbo.Guilds", con)
        Dim reader As SqlDataReader
        Try
            con.Open()
            reader = cmd.ExecuteReader()
            ListBox1.Items.Clear()
            Do While reader.Read()
                ListBox1.Items.Add(reader("GuildName")
                    )
            Loop
            reader.Close()
            con.Close()
        Catch ex As Exception
            If MessageBox.Show("Gilden konnten nicht geladen werden.") Then
                Dim Page2 As New Page2

            Else
                MessageBox.Show("Gilden konnten nicht geladen werden.")

            End If
        End Try
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.Windows.RoutedEventArgs) Handles Button3.Click
        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim reader As SqlDataReader

        con.ConnectionString = "Data Source=127.0.0.1,1433;Initial Catalog=PS_UserData;Trusted_Connection=Yes;"
        cmd.Connection = con
        cmd.CommandText = "select b.GuildID, b.CharID, b.CharID, a.CharName, g.GuildID, g.GuildName, g.MasterUserID, g.MasterName, g.MasterCharID, g.Country, g.TotalCount, g.GuildPoint, g.Del, d.UseHouse, d.Etin, d.Rank, d.Remark from PS_GameData.dbo.Guilds g INNER JOIN PS_GameData.dbo.GuildDetails d ON g.GuildID=d.GuildID INNER JOIN PS_GameData.dbo.GuildChars b ON g.GuildID=b.GuildID INNER JOIN PS_GameData.dbo.Chars a ON b.CharID=a.CharID Where g.GuildName = '" & ListBox1.SelectedItem & "'"


        Try

            TabControl1.SelectedIndex = 1
            con.Open()
            reader = cmd.ExecuteReader()
            ListBox2.Items.Clear()
            ListView1.Items.Clear()
            Do While reader.Read()
                TextBox3.Text = (reader("GuildID")
                )
                TextBox4.Text = (reader("GuildName")
                )
                TextBox5.Text = (reader("MasterUserID")
                )
                TextBox7.Text = (reader("MasterName")
                )
                TextBox8.Text = (reader("Country")
                )
                TextBox8.Text = IIf(TextBox8.Text = 0, "Light", "Dark")
                TextBox9.Text = (reader("TotalCount")
                )
                TextBox10.Text = (reader("GuildPoint")
                )
                TextBox11.Text = (reader("Del")
                )
                TextBox11.Text = IIf(TextBox11.Text = 0, "nein", "ja")
                TextBox12.Text = (reader("UseHouse")
                )
                TextBox12.Text = IIf(TextBox12.Text = 0, "nein", "ja")
                TextBox13.Text = (reader("Etin")
                )
                TextBox14.Text = (reader("Rank")
                )
                TextBox15.Text = (reader("Remark")
                )
                ListBox2.Items.Add(reader("CharName")
                )
                TextBox6.Text = (reader("MasterCharID")
                )

            Loop

            reader.Close()
            con.Close()
        Catch ex As Exception
            If MessageBox.Show("Gilde konnte nicht geladen werden.") Then
                Dim Page2 As New Page2

            Else
                MessageBox.Show("Gilde erfolgreich geladen")
                Me.NavigationService.Navigate(TabItem1)
            End If
        End Try
    End Sub

    Private Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim Window1 As New Window
        Window1.Show
    End Sub
End Class
