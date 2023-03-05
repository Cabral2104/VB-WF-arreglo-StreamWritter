Public Class Form1
    Private length As Integer = 0
    Private index As Integer = 0
    Private valor As Integer
    Private array As Contacto()

    Private nombreArchivo As String ' Agregamos una variable para guardar el nombre del archivo

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Generamos el nombre del archivo y lo guardamos en la variable correspondiente
        nombreArchivo = My.Computer.FileSystem.SpecialDirectories.Desktop & "\contactos.txt"
        ' Si el archivo no existe, lo creamos con un encabezado
        If Not My.Computer.FileSystem.FileExists(nombreArchivo) Then
            My.Computer.FileSystem.WriteAllText(nombreArchivo, "Lista de contactos:" & vbCrLf & vbCrLf, False)
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        valor = Integer.Parse(txtNumContactos.Text)
        index = valor
        array = New Contacto(index - 1) {}
        If length < index Then
            Dim x = New Contacto()
            x.nombre_ = txtNombre.Text
            x.fechadenacimiento_ = dtpFechaNacimiento.Value
            x.telefono_ = txtTelefono.Text
            x.correo_ = txtCorreo.Text

            ' Crear la cadena de texto con los datos del contacto
            Dim datosContacto As String = "Nombre: " & x.nombre_ & vbCrLf & "Fecha de nacimiento: " & x.fechadenacimiento_.ToString() & vbCrLf & "Teléfono: " & x.telefono_ & vbCrLf & "Correo electrónico: " & x.correo_ & vbCrLf & vbCrLf

            ' Agregar la cadena al final del archivo de texto
            My.Computer.FileSystem.WriteAllText(nombreArchivo, datosContacto, True)

            array(length) = x
            length += 1
            Dim linea As String = x.ToString() + Environment.NewLine
            lblGuardados.Text = lblGuardados.Text & linea
            txtNombre.Clear()
            dtpFechaNacimiento.Value = DateTime.Now
            txtTelefono.Clear()
            txtCorreo.Clear()
        End If

        If length = index Then
            MessageBox.Show("se han registrado todos")
        End If
    End Sub

    Private Sub txtNcontactos_TextChanged(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub
End Class