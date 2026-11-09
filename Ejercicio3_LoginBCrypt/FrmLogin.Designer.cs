// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: FrmLogin.Designer.cs  ->  Diseño visual del formulario de login
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// Nota: el método InitializeComponent() lo mantiene el diseñador de
// Visual Studio; ahí se crean y ubican todos los controles de la ventana.
// ============================================================
namespace Ejercicio3_LoginBCrypt
{
    partial class FrmLogin
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
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            chkMostrar = new CheckBox();
            btnIngresar = new Button();
            btnRegistrar = new Button();
            lblEstado = new Label();
            lblAutor = new Label();
            SuspendLayout();
            //
            // lblTitulo
            //
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(340, 40);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inicio de Sesión";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblUsuario
            //
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(30, 70);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            //
            // txtUsuario
            //
            txtUsuario.Location = new Point(30, 93);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(320, 27);
            txtUsuario.TabIndex = 2;
            //
            // lblPassword
            //
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(30, 130);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(86, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Contraseña:";
            //
            // txtPassword
            //
            txtPassword.Location = new Point(30, 153);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(320, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            //
            // chkMostrar
            //
            chkMostrar.AutoSize = true;
            chkMostrar.Location = new Point(30, 186);
            chkMostrar.Name = "chkMostrar";
            chkMostrar.Size = new Size(166, 24);
            chkMostrar.TabIndex = 5;
            chkMostrar.Text = "Mostrar contraseña";
            chkMostrar.UseVisualStyleBackColor = true;
            chkMostrar.CheckedChanged += chkMostrar_CheckedChanged;
            //
            // btnIngresar
            //
            btnIngresar.BackColor = Color.FromArgb(0, 120, 215);
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(30, 222);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(155, 38);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            //
            // btnRegistrar
            //
            btnRegistrar.Location = new Point(195, 222);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(155, 38);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar usuario";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            //
            // lblEstado
            //
            lblEstado.Location = new Point(30, 268);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(320, 25);
            lblEstado.TabIndex = 8;
            lblEstado.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblAutor
            //
            lblAutor.ForeColor = Color.Gray;
            lblAutor.Font = new Font("Segoe UI", 8F);
            lblAutor.Location = new Point(10, 300);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(360, 20);
            lblAutor.TabIndex = 9;
            lblAutor.Text = "Wilson Wu - Ing. en Sistemas y Computación - Parcial #3";
            lblAutor.TextAlign = ContentAlignment.MiddleCenter;
            //
            // FrmLogin
            //
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 330);
            Controls.Add(lblAutor);
            Controls.Add(lblEstado);
            Controls.Add(btnRegistrar);
            Controls.Add(btnIngresar);
            Controls.Add(chkMostrar);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login BCrypt - Parcial #3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ---------- Controles del formulario ----------
        private Label lblTitulo;        // Título "Inicio de Sesión"
        private Label lblUsuario;       // Etiqueta "Usuario:"
        private TextBox txtUsuario;     // Caja de texto del usuario
        private Label lblPassword;      // Etiqueta "Contraseña:"
        private TextBox txtPassword;    // Caja de la contraseña (muestra puntos)
        private CheckBox chkMostrar;    // Mostrar u ocultar la contraseña
        private Button btnIngresar;     // Verifica con BCrypt e inicia sesión
        private Button btnRegistrar;    // Abre el formulario de registro
        private Label lblEstado;        // Mensajes de error o de éxito
        private Label lblAutor;         // Datos del estudiante al pie
    }
}
