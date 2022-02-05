namespace Pyatnashki
{
    partial class Pyatnashki
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pyatnashki));
            this.NewGameButton = new System.Windows.Forms.Button();
            this.RepeatGameButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Motion = new System.Windows.Forms.Label();
            this.Time = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.textBoxMot = new System.Windows.Forms.TextBox();
            this.Mix = new System.Windows.Forms.Button();
            this.Mix_New = new System.Windows.Forms.Button();
            this.BLastResult = new System.Windows.Forms.Button();
            this.BBestSteps = new System.Windows.Forms.Button();
            this.BBestTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nick = new System.Windows.Forms.TextBox();
            this.data = new System.Windows.Forms.DateTimePicker();
            this.Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.AntiqueWhite;
            this.NewGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewGameButton.Location = new System.Drawing.Point(619, 91);
            this.NewGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(200, 68);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New game\r\n";
            this.NewGameButton.UseVisualStyleBackColor = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // RepeatGameButton
            // 
            this.RepeatGameButton.BackColor = System.Drawing.Color.AntiqueWhite;
            this.RepeatGameButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepeatGameButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RepeatGameButton.Location = new System.Drawing.Point(619, 184);
            this.RepeatGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.RepeatGameButton.Name = "RepeatGameButton";
            this.RepeatGameButton.Size = new System.Drawing.Size(200, 68);
            this.RepeatGameButton.TabIndex = 1;
            this.RepeatGameButton.Text = "Repeat game\r\n";
            this.RepeatGameButton.UseVisualStyleBackColor = false;
            this.RepeatGameButton.Click += new System.EventHandler(this.RepeatGameButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(97, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 75;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(401, 370);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridView1_CellClick);
            // 
            // Motion
            // 
            this.Motion.AutoSize = true;
            this.Motion.BackColor = System.Drawing.Color.Transparent;
            this.Motion.CausesValidation = false;
            this.Motion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Motion.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Motion.Location = new System.Drawing.Point(363, 488);
            this.Motion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Motion.Name = "Motion";
            this.Motion.Size = new System.Drawing.Size(101, 32);
            this.Motion.TabIndex = 3;
            this.Motion.Text = "Turns:";
            // 
            // Time
            // 
            this.Time.AutoSize = true;
            this.Time.BackColor = System.Drawing.Color.Transparent;
            this.Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Time.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.Time.Location = new System.Drawing.Point(91, 488);
            this.Time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Time.Name = "Time";
            this.Time.Size = new System.Drawing.Size(91, 32);
            this.Time.TabIndex = 4;
            this.Time.Text = "Time:";
            this.Time.Click += new System.EventHandler(this.Time_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // textBoxTime
            // 
            this.textBoxTime.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBoxTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxTime.Location = new System.Drawing.Point(190, 498);
            this.textBoxTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(132, 22);
            this.textBoxTime.TabIndex = 5;
            this.textBoxTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMot
            // 
            this.textBoxMot.BackColor = System.Drawing.Color.AntiqueWhite;
            this.textBoxMot.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxMot.Location = new System.Drawing.Point(472, 498);
            this.textBoxMot.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMot.Name = "textBoxMot";
            this.textBoxMot.ReadOnly = true;
            this.textBoxMot.Size = new System.Drawing.Size(132, 22);
            this.textBoxMot.TabIndex = 6;
            this.textBoxMot.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Mix
            // 
            this.Mix.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Mix.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mix.Location = new System.Drawing.Point(619, 278);
            this.Mix.Name = "Mix";
            this.Mix.Size = new System.Drawing.Size(200, 68);
            this.Mix.TabIndex = 7;
            this.Mix.Text = "Mix";
            this.Mix.UseVisualStyleBackColor = false;
            this.Mix.Click += new System.EventHandler(this.Mix_Click);
            // 
            // Mix_New
            // 
            this.Mix_New.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Mix_New.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mix_New.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Mix_New.Location = new System.Drawing.Point(619, 376);
            this.Mix_New.Name = "Mix_New";
            this.Mix_New.Size = new System.Drawing.Size(200, 68);
            this.Mix_New.TabIndex = 8;
            this.Mix_New.Text = "Mix new game";
            this.Mix_New.UseVisualStyleBackColor = false;
            this.Mix_New.Click += new System.EventHandler(this.Mix_New_Click);
            // 
            // BLastResult
            // 
            this.BLastResult.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BLastResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BLastResult.Location = new System.Drawing.Point(406, 30);
            this.BLastResult.Name = "BLastResult";
            this.BLastResult.Size = new System.Drawing.Size(92, 47);
            this.BLastResult.TabIndex = 9;
            this.BLastResult.Text = "Last results";
            this.BLastResult.UseVisualStyleBackColor = false;
            this.BLastResult.Click += new System.EventHandler(this.BLastResult_Click);
            // 
            // BBestSteps
            // 
            this.BBestSteps.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BBestSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BBestSteps.Location = new System.Drawing.Point(250, 30);
            this.BBestSteps.Name = "BBestSteps";
            this.BBestSteps.Size = new System.Drawing.Size(100, 47);
            this.BBestSteps.TabIndex = 10;
            this.BBestSteps.Text = "Result steps";
            this.BBestSteps.UseVisualStyleBackColor = false;
            this.BBestSteps.Click += new System.EventHandler(this.BBestSteps_Click_1);
            // 
            // BBestTime
            // 
            this.BBestTime.BackColor = System.Drawing.Color.AntiqueWhite;
            this.BBestTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BBestTime.Location = new System.Drawing.Point(97, 30);
            this.BBestTime.Name = "BBestTime";
            this.BBestTime.Size = new System.Drawing.Size(92, 47);
            this.BBestTime.TabIndex = 11;
            this.BBestTime.Text = "Result time";
            this.BBestTime.UseVisualStyleBackColor = false;
            this.BBestTime.Click += new System.EventHandler(this.BBestTime_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(617, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nickname";
            // 
            // nick
            // 
            this.nick.BackColor = System.Drawing.Color.AntiqueWhite;
            this.nick.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nick.Location = new System.Drawing.Point(719, 42);
            this.nick.Name = "nick";
            this.nick.Size = new System.Drawing.Size(100, 22);
            this.nick.TabIndex = 14;
            this.nick.Text = "NoName";
            // 
            // data
            // 
            this.data.CalendarMonthBackground = System.Drawing.Color.AntiqueWhite;
            this.data.Location = new System.Drawing.Point(650, 520);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(200, 22);
            this.data.TabIndex = 15;
            // 
            // Delete
            // 
            this.Delete.BackColor = System.Drawing.Color.AntiqueWhite;
            this.Delete.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Delete.Location = new System.Drawing.Point(704, 488);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(75, 23);
            this.Delete.TabIndex = 16;
            this.Delete.Text = "delete";
            this.Delete.UseVisualStyleBackColor = false;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Pyatnashki
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Пятнашки.Properties.Resources.depositphotos_7258723_stock_photo_wood_panels;
            this.ClientSize = new System.Drawing.Size(880, 554);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.data);
            this.Controls.Add(this.nick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BBestTime);
            this.Controls.Add(this.BBestSteps);
            this.Controls.Add(this.BLastResult);
            this.Controls.Add(this.Mix_New);
            this.Controls.Add(this.Mix);
            this.Controls.Add(this.textBoxMot);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.Time);
            this.Controls.Add(this.Motion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.RepeatGameButton);
            this.Controls.Add(this.NewGameButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pyatnashki";
            this.Text = "Пятнашки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.Pyatnashki_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button RepeatGameButton;
        private System.Windows.Forms.Button Mix;
        private System.Windows.Forms.Button Mix_New;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Label Motion;
        private System.Windows.Forms.Label Time;
        private System.Windows.Forms.Timer gameTimer;

        private System.Windows.Forms.TextBox textBoxTime;
        private System.Windows.Forms.TextBox textBoxMot;
        private System.Windows.Forms.Button BLastResult;
        private System.Windows.Forms.Button BBestSteps;
        private System.Windows.Forms.Button BBestTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nick;
        private System.Windows.Forms.DateTimePicker data;
        private System.Windows.Forms.Button Delete;
    }
}

