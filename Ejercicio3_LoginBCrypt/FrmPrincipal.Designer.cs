// ============================================================
// Parcial #3 - Parte Práctica - Ejercicio 3
// Archivo: FrmPrincipal.Designer.cs  ->  Diseño visual del menú principal
// Autor: Wilson Wu | Ingeniería en Sistemas y Computación
// Nota: el método InitializeComponent() lo mantiene el diseñador de
// Visual Studio; ahí se crean y ubican todos los controles de la ventana.
// ============================================================
namespace Ejercicio3_LoginBCrypt
{
    partial class FrmPrincipal
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
            lblBienvenida = new Label();
            lblUsuario = new Label();
            lblHistorial = new Label();
            dgvIntentos = new DataGridView();
            lblResumen = new Label();
            btnActualizar = new Button();
            btnCerrarSesion = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvIntentos).BeginInit();
            SuspendLayout();
            //
            // lblBienvenida
            //
            lblBienvenida.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(0, 120, 215);
            lblBienvenida.Location = new Point(20, 15);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(740, 45);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "¡Bienvenido!";
            //
            // lblUsuario
            //
            lblUsuario.Location = new Point(22, 62);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(740, 25);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario:";
            //
            // lblHistorial
            //
            lblHistorial.AutoSize = true;
            lblHistorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHistorial.Location = new Point(22, 100);
            lblHistorial.Name = "lblHistorial";
            lblHistorial.Size = new Size(338, 23);
            lblHistorial.TabIndex = 2;
            lblHistorial.Text = "Historial de intentos de inicio de sesión";
            //
            // dgvIntentos
            //
            dgvIntentos.AllowUserToAddRows = false;
            dgvIntentos.AllowUserToDeleteRows = false;
            dgvIntentos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvIntentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIntentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIntentos.Location = new Point(22, 130);
            dgvIntentos.Name = "dgvIntentos";
            dgvIntentos.ReadOnly = true;
            dgvIntentos.RowHeadersVisible = false;
            dgvIntentos.RowHeadersWidth = 51;
            dgvIntentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIntentos.Size = new Size(740, 300);
            dgvIntentos.TabIndex = 3;
            //
            // lblResumen
            //
            lblResumen.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblResumen.Location = new Point(22, 445);
            lblResumen.Name = "lblResumen";
            lblResumen.Size = new Size(400, 25);
            lblResumen.TabIndex = 4;
            lblResumen.Text = "Exitosos: 0 | Fallidos: 0";
            //
            // btnActualizar
            //
            btnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActualizar.Location = new Point(482, 440);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(135, 35);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            //
            // btnCerrarSesion
            //
            btnCerrarSesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCerrarSesion.Location = new Point(627, 440);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(135, 35);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            //
            // FrmPrincipal
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 491);
            Controls.Add(btnCerrarSesion);
            Controls.Add(btnActualizar);
            Controls.Add(lblResumen);
            Controls.Add(dgvIntentos);
            Controls.Add(lblHistorial);
            Controls.Add(lblUsuario);
            Controls.Add(lblBienvenida);
            MinimumSize = new Size(600, 400);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Menú principal - Parcial #3";
            Load += FrmPrincipal_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIntentos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // ---------- Controles del formulario ----------
        private Label lblBienvenida;        // "¡Bienvenido, {nombre}!"
        private Label lblUsuario;           // Usuario y fecha/hora del acceso
        private Label lblHistorial;         // Título de la tabla de intentos
        private DataGridView dgvIntentos;   // Historial de la tabla IntentosLogin
        private Label lblResumen;           // Total de intentos exitosos y fallidos
        private Button btnActualizar;       // Vuelve a cargar el historial
        private Button btnCerrarSesion;     // Cierra el menú y regresa al login
    }
}
