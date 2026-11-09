// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: FrmRegistro.Designer.cs  ->  Diseño visual del formulario de registro
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// Nota: el método InitializeComponent() lo mantiene el diseñador de
// Visual Studio; ahí se crean y ubican todos los controles de la ventana.
// ============================================================
namespace Ejercicio3_LoginBCrypt
{
    partial class FrmRegistro
    {
        // Contenedor de componentes no visuales (lo usa el diseñador).
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Libera los recursos de los controles al cerrar el formulario.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            lblHash = new Label();
            txtHash = new TextBox();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(380, 35);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Usuario";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblNombre
            //
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(30, 55);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(136, 20);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre completo:";
            //
            // txtNombre
            //
            txtNombre.Location = new Point(30, 78);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(360, 27);
            txtNombre.TabIndex = 2;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(30, 113);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario:";
            //
            // txtUsuario
            //
            txtUsuario.Location = new Point(30, 136);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(360, 27);
            txtUsuario.TabIndex = 4;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 171);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Contraseña:";
            //
            // txtPassword
            //
            txtPassword.Location = new Point(30, 194);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(360, 27);
            txtPassword.TabIndex = 6;
            txtPassword.UseSystemPasswordChar = true;
            //
            // lblConfirmar
            //
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(30, 229);
            lblConfirmar.Name = "lblConfirmar";
            lblConfirmar.Size = new Size(160, 20);
            lblConfirmar.TabIndex = 7;
            lblConfirmar.Text = "Confirmar contraseña:";
            //
            // txtConfirmar
            //
            txtConfirmar.Location = new Point(30, 252);
            txtConfirmar.Name = "txtConfirmar";
            txtConfirmar.Size = new Size(360, 27);
            txtConfirmar.TabIndex = 8;
            txtConfirmar.UseSystemPasswordChar = true;
            //
            // btnGuardar
            //
            btnGuardar.BackColor = Color.FromArgb(0, 120, 215);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(30, 292);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(175, 38);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Generar hash y guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            //
            // btnCancelar
            //
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(215, 292);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(175, 38);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            //
            // lblHash
            //
            lblHash.AutoSize = true;
            lblHash.Location = new Point(30, 340);
            lblHash.Name = "lblHash";
            lblHash.Size = new Size(205, 20);
            lblHash.TabIndex = 11;
            lblHash.Text = "Hash BCrypt guardado en BD:";
            //
            // txtHash
            //
            txtHash.Font = new Font("Consolas", 8F);
            txtHash.Location = new Point(30, 363);
            txtHash.Name = "txtHash";
            txtHash.ReadOnly = true;
            txtHash.Size = new Size(360, 23);
            txtHash.TabIndex = 12;
            //
            // FrmRegistro
            //
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(420, 405);
            Controls.Add(txtHash);
            Controls.Add(lblHash);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtConfirmar);
            Controls.Add(lblConfirmar);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmRegistro";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registro de usuario";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ---------- Controles del formulario ----------
        private Label lblTitulo;        // Título "Registrar Usuario"
        private Label lblNombre;        // Etiqueta "Nombre completo:"
        private TextBox txtNombre;      // Nombre que se mostrará al entrar
        private Label lblUsuario;       // Etiqueta "Usuario:"
        private TextBox txtUsuario;     // Nombre de usuario para el login
        private Label lblPassword;      // Etiqueta "Contraseña:"
        private TextBox txtPassword;    // Contraseña (muestra puntos)
        private Label lblConfirmar;     // Etiqueta "Confirmar contraseña:"
        private TextBox txtConfirmar;   // Repetición de la contraseña
        private Button btnGuardar;      // Genera el hash BCrypt y guarda en la BD
        private Button btnCancelar;     // Cierra sin guardar
        private Label lblHash;          // Etiqueta "Hash BCrypt guardado en BD:"
        private TextBox txtHash;        // Muestra el hash generado (solo lectura)
    }
}
